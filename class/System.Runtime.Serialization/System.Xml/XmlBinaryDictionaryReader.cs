//
// XmlBinaryDictionaryReader.cs
//
// Author:
//	Atsushi Enomoto  <atsushi@ximian.com>
//
// Copyright (C) 2005, 2007 Novell, Inc.  http://www.novell.com
//

//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

using QName = System.Xml.XmlQualifiedName;
using BF = System.Xml.XmlBinaryFormat;

namespace System.Xml
{
	// FIXME:
	//	- native value data (7B-82, 8D-A0) are not implemented.
	//	- support XmlDictionaryReaderQuotas.
	//	- support XmlBinaryReaderSession.
	//	- handle namespaces as expected.

	internal class XmlBinaryDictionaryReader : XmlDictionaryReader, IXmlNamespaceResolver
	{
		internal interface ISource
		{
			int Position { get; }
			int ReadByte ();
			int Read (byte [] data, int offset, int count);
			BinaryReader Reader { get; }
		}

		internal class StreamSource : ISource
		{
			BinaryReader stream;
			int position;

			public StreamSource (Stream stream)
			{
				this.stream = new BinaryReader (stream);
			}

			public int Position {
				get { return position - 1; }
			}

			public BinaryReader Reader {
				get { return stream; }
			}

			public int ReadByte ()
			{
				if (!stream.BaseStream.CanRead)
					return -1;
				position++;
				return stream.ReadByte ();
			}

			public int Read (byte [] data, int offset, int count)
			{
				int ret = stream.Read (data, offset, count);
				position += ret;
				return ret;
			}
		}

		class NodeInfo
		{
			public int Position;
			public string Prefix;
			public XmlDictionaryString DictLocalName;
			public XmlDictionaryString DictNS;
			public string Value;
			public XmlNodeType NodeType;
			public object TypedValue;

			string name;
			string local_name;
			string ns;

			public string LocalName {
				get { return DictLocalName != null ? DictLocalName.Value : local_name; }
				set {
					DictLocalName = null;
					local_name = value;
				}
			}

			public string NS {
				get { return DictNS != null ? DictNS.Value : ns; }
				set {
					DictNS = null;
					ns = value;
				}
			}

			public string Name {
				get {
					if (name == null)
						name = Prefix.Length > 0 ?
							String.Concat (Prefix, ":", LocalName) :
							LocalName;
					return name;
				}
			}

			public virtual void Reset ()
			{
				Position = 0;
				LocalName = NS = Prefix = Value = String.Empty;
				NodeType = XmlNodeType.None;
			}
		}

		class AttrNodeInfo : NodeInfo
		{
			public int ValueIndex;
			public int NSSlot;

			public override void Reset ()
			{
				base.Reset ();
				ValueIndex = -1;
				NSSlot = -1;
			}
		}

		ISource source;
		IXmlDictionary dictionary;
		XmlDictionaryReaderQuotas quota;
		XmlBinaryReaderSession session;
		OnXmlDictionaryReaderClose on_close;
		XmlParserContext context;

		ReadState state = ReadState.Initial;
		NodeInfo node;
		NodeInfo current;
		List<AttrNodeInfo> attributes = new List<AttrNodeInfo> ();
		List<NodeInfo> attr_values = new List<NodeInfo> ();
		List<NodeInfo> node_stack = new List<NodeInfo> ();
		List<QName> ns_store = new List<QName> ();
		int attr_count;
		int attr_value_count;
		int current_attr = -1;
		int depth = -1;
		// next byte in the source (one byte token ahead always
		// happens because there is no "end of start element" mark).
		int next = -1;
		// this is for binary identifier 0x9D (and possible 0x9E, 0x9F)
		bool is_next_end_element;
		// temporary buffer for utf8enc.GetString()
		byte [] tmp_buffer = new byte [128];
		UTF8Encoding utf8enc = new UTF8Encoding ();

		public XmlBinaryDictionaryReader (byte [] buffer, int offset,
			int count, IXmlDictionary dictionary,
			XmlDictionaryReaderQuotas quota,
			XmlBinaryReaderSession session,
			OnXmlDictionaryReaderClose onClose)
		{
			source = /*new ArraySource (buffer, offset, count);*/
				new StreamSource (new MemoryStream (buffer, offset, count));
			Initialize (dictionary, quota, session, onClose);
		}

		public XmlBinaryDictionaryReader (Stream stream,
			IXmlDictionary dictionary,
			XmlDictionaryReaderQuotas quota,
			XmlBinaryReaderSession session,
			OnXmlDictionaryReaderClose onClose)
		{
			source = new StreamSource (stream);
			Initialize (dictionary, quota, session, onClose);
		}

		private void Initialize (IXmlDictionary dictionary,
			XmlDictionaryReaderQuotas quota,
			XmlBinaryReaderSession session,
			OnXmlDictionaryReaderClose onClose)
		{
			if (dictionary == null)
				dictionary = new XmlDictionary ();
			this.dictionary = dictionary;

			if (quota == null)
				quota = new XmlDictionaryReaderQuotas ();
			this.quota = quota;

			if (session == null)
				session = new XmlBinaryReaderSession ();
			this.session = session;

			on_close = onClose;

			if (context == null) {
				NameTable nt = new NameTable ();
				context = new XmlParserContext (nt,
					new XmlNamespaceManager (nt),
					null, XmlSpace.None);
			}
			this.context = context;

			current = node = new NodeInfo ();
			current.Reset ();
		}

		public override int AttributeCount {
			get { return attr_count; }
		}

		public override string BaseURI {
			get { return context.BaseURI; }
		}

		public override int Depth {
			get { return depth < 0 ? 0 : depth; }
		}

		public override bool EOF {
			get { return state == ReadState.EndOfFile || state == ReadState.Error; }
		}

		public override bool HasValue {
			get { return current.Value.Length > 0; }
		}

		public override bool IsEmptyElement {
			get { return false; }
		}

		public override XmlNodeType NodeType {
			get { return current.NodeType; }
		}

		public override string Prefix {
			get { return current.Prefix; }
		}

		public override string LocalName {
			get { return current.LocalName; }
		}

		public override string NamespaceURI {
			get { return current.NS; }
		}

		public override XmlNameTable NameTable {
			get { return context.NameTable; }
		}

		public override XmlDictionaryReaderQuotas Quotas {
			get { return quota; }
		}

		public override ReadState ReadState {
			get { return state; }
		}

		public override string Value {
			get { return current.Value; }
		}

		public override void Close ()
		{
			if (on_close != null)
				on_close (this);
		}

		public override string GetAttribute (int i)
		{
			if (i >= attr_count)
				throw new ArgumentOutOfRangeException (String.Format ("Specified attribute index is {0} and should be less than {1}", i, attr_count));
			return attributes [i].Value;
		}

		public override string GetAttribute (string name)
		{
			for (int i = 0; i < attributes.Count; i++)
				if (attributes [i].Name == name)
					return attributes [i].Value;
			return null;
		}

		public override string GetAttribute (string localName, string ns)
		{
			for (int i = 0; i < attributes.Count; i++)
				if (attributes [i].LocalName == localName &&
					attributes [i].NS == ns)
					return attributes [i].Value;
			return null;
		}

		public IDictionary<string,string> GetNamespacesInScope (
			XmlNamespaceScope scope)
		{
			return context.NamespaceManager.GetNamespacesInScope (scope);
		}

		public string LookupPrefix (string ns)
		{
			return context.NamespaceManager.LookupPrefix (NameTable.Get (ns));
		}

		public override string LookupNamespace (string prefix)
		{
			return context.NamespaceManager.LookupNamespace (
				NameTable.Get (prefix));
		}

		public override bool MoveToElement ()
		{
			bool ret = current_attr >= 0;
			current_attr = -1;
			current = node;
			return ret;
		}

		public override bool MoveToFirstAttribute ()
		{
			if (attr_count == 0)
				return false;
			current_attr = 0;
			current = attributes [current_attr];
			return true;
		}

		public override bool MoveToNextAttribute ()
		{
			if (++current_attr < attr_count) {
				current = attributes [current_attr];
				return true;
			} else {
				--current_attr;
				return false;
			}
		}

		public override void MoveToAttribute (int i)
		{
			if (i >= attr_count)
				throw new ArgumentOutOfRangeException (String.Format ("Specified attribute index is {0} and should be less than {1}", i, attr_count));
			current_attr = i;
			current = attributes [i];
		}

		public override bool MoveToAttribute (string name)
		{
			for (int i = 0; i < attributes.Count; i++) {
				if (attributes [i].Name == name) {
					MoveToAttribute (i);
					return true;
				}
			}
			return false;
		}

		public override bool MoveToAttribute (string localName, string ns)
		{
			for (int i = 0; i < attributes.Count; i++) {
				if (attributes [i].LocalName == localName &&
					attributes [i].NS == ns) {
					MoveToAttribute (i);
					return true;
				}
			}
			return false;
		}

		public override bool ReadAttributeValue ()
		{
			if (current_attr < 0)
				return false;
			int start = attributes [current_attr].ValueIndex;
			int end = current_attr + 1 == attr_count ? attr_value_count : attributes [current_attr + 1].ValueIndex;
			end--;
			for (int i = start; i < end; i++) {
				if (current == attributes [i]) {
					current = attributes [i + 1];
					return true;
				}
			}
			return false;
		}

		public override bool Read ()
		{
			switch (state) {
			case ReadState.Closed:
			case ReadState.EndOfFile:
			case ReadState.Error:
				return false;
			}
			if (node.NodeType == XmlNodeType.Element) {
				// push element scope
				context.NamespaceManager.PushScope ();
				if (node_stack.Count == depth) {
					node_stack.Add (node);
					node = new NodeInfo ();
				}
			}

			// clear.
			state = ReadState.Interactive;
			attr_count = 0;
			attr_value_count = 0;
			current = node;

			if (is_next_end_element) {
				is_next_end_element = false;
				ProcessEndElement ();
				return true;
			}

			int ident = next >= 0 ? next : source.ReadByte ();
			next = -1;

			// check end of source.
			if (ident < 0) {
				state = ReadState.EndOfFile;
				current.Reset ();
				return false;
			}

			is_next_end_element = ident > 0x80 && (ident & 1) == 1;
			ident -= is_next_end_element ? 1 : 0;
/*
			if (0x3F <= ident && ident <= 0x42)
				ReadElementBinary ((byte) ident);
			else {
				switch (ident) {
				case 0x3C: // end element
					ProcessEndElement ();
					break;
				case 0x3D: // comment
					node.Value = ReadUTF8 ();
					node.NodeType = XmlNodeType.Comment;
					break;
				default:
					ReadTextOrValue ((byte) ident, node, false);
					break;
				}
			}
*/
			switch (ident) {
			case BF.EndElement:
				ProcessEndElement ();
				break;
			case BF.Comment:
				node.Value = ReadUTF8 ();
				node.NodeType = XmlNodeType.Comment;
				break;
			case BF.ElemString:
			case BF.ElemStringPrefix:
			case BF.ElemIndex:
			case BF.ElemIndexPrefix:
				ReadElementBinary ((byte) ident);
				break;

			default:
				ReadTextOrValue ((byte) ident, node, false);
				break;
			}

			return true;
		}

		private void ProcessEndElement ()
		{
			if (depth < 0)
				throw new XmlException ("Unexpected end of element while there is no element started.");
			node = node_stack [depth];
			node.NodeType = XmlNodeType.EndElement;
			depth--;
			context.NamespaceManager.PopScope ();
		}

		private void ReadElementBinary (int ident)
		{
			// element
			depth++;
			node.NodeType = XmlNodeType.Element;
			switch (ident) {
			case 0x3F:
				node.LocalName = ReadUTF8 ();
				break;
			case 0x40:
				node.Prefix = ReadUTF8 ();
				goto case 0x3F;
			case 0x41:
				node.DictLocalName = ReadDictName ();
				break;
			case 0x42:
				node.Prefix = ReadUTF8 ();
				goto case 0x41;
			}

			bool loop = true;
			do {
				ident = next < 0 ? ReadByteOrError () : next;
				next = -1;

				switch (ident) {
				case BF.AttrString:
				case BF.AttrStringPrefix:
				case BF.AttrIndex:
				case BF.AttrIndexPrefix:
				case BF.GlobalAttrIndex:
				case BF.GlobalAttrIndexInElemNS:
					ReadAttribute ((byte) ident);
					break;
				case BF.DefaultNSString:
				case BF.PrefixNSString:
				case BF.DefaultNSIndex:
				case BF.PrefixNSIndex:
					ReadNamespace ((byte) ident);
					break;
				default:
					next = ident;
					loop = false;
					break;
				}
/*
				if (ident < 4) {
					// attributes
					if (attributes.Count == attr_count)
						attributes.Add (new AttrNodeInfo ());
					AttrNodeInfo a = attributes [attr_count++];
					a.Reset ();
					a.Position = source.Position;
					switch (ident) {
					case 0:
						a.LocalName = ReadUTF8 ();
						break;
					case 1:
						a.Prefix = ReadUTF8 ();
						goto case 0;
					case 2:
						a.DictLocalName = ReadDictName ();
						break;
					case 3:
						a.Prefix = ReadUTF8 ();
						goto case 2;
					}
					ReadAttributeValueBinary (a);
				}
				else if (ident < 6) {
					// namespaces
					string prefix = ident == 4 ?
						String.Empty : ReadUTF8 ();
					string ns = ReadUTF8 ();
					ns_store.Add (new QName (prefix, ns));
					context.NamespaceManager.AddNamespace (prefix, ns);
				}
				else if (0x22 <= ident && ident < 0x3C) {
					// attributes with predefined ns index
					if (attributes.Count == attr_count)
						attributes.Add (new AttrNodeInfo ());
					AttrNodeInfo a = attributes [attr_count++];
					a.Reset ();
					a.Position = source.Position;
					a.NSSlot = ident - 0x22;
					a.LocalName = ReadUTF8 ();
					ReadAttributeValueBinary (a);
				}
				else {
					next = ident;
					break;
				}
*/
			} while (loop);

			foreach (AttrNodeInfo a in attributes) {
				if (a.NSSlot >= 0) {
					if (a.NSSlot >= ns_store.Count)
						throw new XmlException (String.Format ("Binary XML data is not valid. An attribute node has an invalid index at position {0}. Index is {1}.", a.Position, a.NSSlot));
					a.NS = ns_store [a.NSSlot].Namespace;
					a.Prefix = ns_store [a.NSSlot].Name;
				}
			}

			ns_store.Clear ();
		}

		private void ReadAttribute (byte ident)
		{
			if (attributes.Count == attr_count)
				attributes.Add (new AttrNodeInfo ());
			AttrNodeInfo a = attributes [attr_count++];
			a.Reset ();
			a.Position = source.Position;

			switch (ident) {
			case BF.AttrString:
				a.LocalName = ReadUTF8 ();
				break;
			case BF.AttrStringPrefix:
				a.Prefix = ReadUTF8 ();
				goto case BF.AttrString;
			case BF.AttrIndex:
				a.DictLocalName = ReadDictName ();
				break;
			case BF.AttrIndexPrefix:
				a.Prefix = ReadUTF8 ();
				goto case BF.AttrIndex;
			case BF.GlobalAttrIndex:
				a.DictLocalName = ReadDictName ();
				// FIXME: retrieve namespace
				break;
			case BF.GlobalAttrIndexInElemNS:
				a.Prefix = node.Prefix;
				a.DictLocalName = ReadDictName ();
				a.NS = node.NS;
				break;
			}
			ReadAttributeValueBinary (a);
		}

		private void ReadNamespace (byte ident)
		{
			string prefix = null, ns = null;
			switch (ident) {
			case BF.DefaultNSString:
				prefix = String.Empty;
				ns = ReadUTF8 ();
				break;
			case BF.PrefixNSString:
				prefix = ReadUTF8 ();
				ns = ReadUTF8 ();
				break;
			case BF.DefaultNSIndex:
				prefix = String.Empty;
				// FIXME: no need to retrieve dictionary string?
				ns = ReadDictName ().Value;
				break;
			case BF.PrefixNSIndex:
				prefix = ReadUTF8 ();
				// FIXME: no need to retrieve dictionary string?
				ns = ReadDictName ().Value;
				break;
			}
			ns_store.Add (new QName (prefix, ns));
			context.NamespaceManager.AddNamespace (prefix, ns);
		}

		private void ReadAttributeValueBinary (AttrNodeInfo a)
		{
			a.ValueIndex = attr_value_count;
			do {
				if (attr_value_count == attr_values.Count)
					attr_values.Add (new NodeInfo ());
				NodeInfo v = attr_values [attr_value_count++];
				v.Reset ();
				next = ReadByteOrError ();
				if (!ReadTextOrValue ((byte) next, v, true))
					break;
			} while (true);
		}

		private bool ReadTextOrValue (byte ident, NodeInfo node, bool canSkip)
		{
			switch (ident) {
			case BF.BoolFalse:
				node.Value = null;
				node.TypedValue = false;
				node.NodeType = XmlNodeType.Text;
				break;
			case BF.BoolTrue:
				node.Value = null;
				node.TypedValue = true;
				node.NodeType = XmlNodeType.Text;
				break;
			case BF.Int8:
				node.Value = null;
				node.TypedValue = ReadByteOrError ();
				node.NodeType = XmlNodeType.Text;
				break;
			case BF.Int16:
			case BF.Int32:
			case BF.Int64:
			case BF.Single:
			case BF.Double:
			case BF.Decimal:
			case BF.DateTime:
			//case BF.UniqueId: // identical to .Text
			case BF.Base64:

			case BF.TimeSpan:
			case BF.Guid:
				throw new NotImplementedException ();

			case BF.Text:
				node.Value = ReadUTF8 ();
				node.NodeType = XmlNodeType.Text;
				break;
			case BF.EmptyText:
				node.Value = String.Empty;
				node.NodeType = XmlNodeType.Text;
				break;
			default:
				if (!canSkip)
					throw new ArgumentException (String.Format ("Unexpected binary XML data at position {1}: {0:X}", ident, source.Position));
				next = ident;
				return false;
			}
			return true;
/*
			if (ident == 0x8B) {
				// empty text
				node.Value = String.Empty;
				node.NodeType = XmlNodeType.Text;
			}
			else if (0x83 <= ident && ident <= 0x85 ||
				0x9D <= ident && ident <= 0x9F) {
				// text
				int sizeSpec = ident > 0x90 ? ident - 0x9D : ident - 0x83;
				node.Value = ReadUTF8 (sizeSpec);
				node.NodeType = XmlNodeType.Text;
				is_next_end_element = ident > 0x90;
			}
			else {
				switch (ident) {
				case 0x7B: // byte
				case 0x7C: // short
				case 0x7D: // int
				case 0x7E: // long
				case 0x7F: // float
				case 0x80: // double
				case 0x81: // decimal
				case 0x82: // DateTime
				case 0x8D: // UniqueId
				case 0x8E: // TimeSpan
				case 0x8F: // Guid
				case 0xA0: // base64Binary
					Console.WriteLine ("At position {0}({0:X})", source.Position);
					throw new NotImplementedException ();
				default:
					if (!canSkip)
						throw new ArgumentException (String.Format ("Unexpected binary XML data at position {1}: {0:X}", ident, source.Position));
					next = ident;
					return false;
				}
			}
			return true;
*/
		}

		private int ReadInt (int sizeSpec)
		{
			int size = 0;
			// If sizeSpec < 0, then it is variant size specifier.
			// Otherwise it is fixed size s = sizeSpec + 1 byte(s).
			if (sizeSpec < 0) {
				do {
					size <<= 7;
					byte got = ReadByteOrError ();
					size += got;
					if (got < 0x80)
						break;
					size -= 0x80;
				} while (true);
			} else {
				for (int i = 0; i < sizeSpec + 1; i++)
					size += ReadByteOrError () << i;
			}
			return size;
		}

		private string ReadUTF8 ()
		{
			return ReadUTF8 (-1);
		}

		private string ReadUTF8 (int sizeSpec)
		{
			int size = ReadInt (sizeSpec);
			if (tmp_buffer.Length < size) {
				int extlen = tmp_buffer.Length * 2;
				tmp_buffer = new byte [size < extlen ? extlen : size];
			}
			size = source.Read (tmp_buffer, 0, size);
			return utf8enc.GetString (tmp_buffer, 0, size);
		}

		private XmlDictionaryString ReadDictName ()
		{
			int key = ReadInt (-1);
			XmlDictionaryString s;
			// FIXME: use XmlBinaryReaderSession
			if (dictionary.TryLookup (key, out s))
				return s;
			throw new XmlException (String.Format ("Input XML binary stream is invalid. No matching XML dictionary string entry at {0}. Binary stream position at {1}", key, source.Position));
		}

		private byte ReadByteOrError ()
		{
			int ret = source.ReadByte ();
			if (ret < 0)
				throw new XmlException (String.Format ("Unexpected end of binary stream. Position is at {0}", source.Position));
			return (byte) ret;
		}

		public override void ResolveEntity ()
		{
			throw new NotSupportedException ("this XmlReader does not support ResolveEntity.");
		}
	}
}
