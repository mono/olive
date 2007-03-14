//
// XmlBinaryDictionaryWriter.cs
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

namespace System.Xml
{
	/* Binary Format (incomplete):

		Literal strings are represented as UTF-8 string, with a length
		prefixed to the string itself.

		Key indices are based on the rules below:
		- dictionary strings which can be found in IXmlDictionary are 
		  doubled its Key. e.g. if the string.Key is 4, then the
		  output is 8.
		- dictionary strings which cannot be found in IXmlDictionary
		  are stored in the XmlBinaryWriterSession, and its output
		  number is doubled + 1 e.g. if the string is the first
		  non-dictionary entry, then the output is 1, and 7 for the
		  fourth one.
		- When the index goes beyond 128, then it becomes 2 bytes,
		  where the first byte becomes 0x80 + idx % 0x80 and
		  the second byte becomes idx / 0x80.

		Below are operations. Prefixes are always raw strings.
		$string is length-prefixed string. @index is index as
		described above. [value] is length-prefixed raw array.

		01			: EndElement
		02 $value		: Comment
		04 $name		: local attribute by string
		05 $prefix $name	: global attribute by string
		06 @name		: local attribute by index
		07 $prefix @name	: global attribute by index
		0A @name		: default namespace
		0B $prefix @name	: prefixed namespace
		40 $name		: element w/o namespace by string
		41 $prefix $name	: element with namespace by string
		42 @name		: element w/o namespace by index
		42 $prefix @name	: element with namespace by index
		98 $value		: text/cdata/chars
		99 $value		: text/cdata/chars + EndElement
		9F [value]		: base64

		FIXME: Below are not implemented:
		byte : 7B
		short : 7C
		int : 7D
		long: 7E
		float: 7F
		double: 80
		decimal: 81
		DateTime: 82
		bool-false: 85
		bool-true: 86
		UniqueId: 8D
		TimeSpan: 8E
		Guid: B0
		Guid + EndElement: B1
		base64Binary: 9F
		(Uri is simply 98, QName is 98 '{' ns '}' 98 name)

		Error: PIs, doctype
		Ignored: XMLdecl
	*/

	// FIXME:
	//	- Support XmlDictionaryString.
	//	- Namespace node processing seems still incomplete.
	//	- Find out how it can write 0x9D (text + EndElement).

	internal class XmlBinaryDictionaryWriter : XmlDictionaryWriter
	{
		#region Fields
		Stream stream;
		IXmlDictionary dictionary;
		XmlBinaryWriterSession session;
		bool owns_stream;
		Encoding utf8Enc = new UTF8Encoding ();

		const string XmlNamespace = "http://www.w3.org/XML/1998/namespace";
		const string XmlnsNamespace = "http://www.w3.org/2000/xmlns/";

		WriteState state = WriteState.Start;
		bool open_start_element = false;
		bool open_attribute = false;
		int open_element_count;
		string xml_lang = null;
		XmlSpace xml_space = XmlSpace.None;
		ListDictionary new_namespaces = new ListDictionary ();
		XmlNamespaceManager nsmgr = new XmlNamespaceManager (new NameTable ());
		Stack<string> xml_lang_stack = new Stack<string> ();
		Stack<XmlSpace> xml_space_stack = new Stack<XmlSpace> ();

		string attr_value;
		string current_attr_prefix;
		SaveTarget save_target;

		enum SaveTarget {
			Namespaces,
			XmlLang,
			XmlSpace
		}

		// XmlWriterSettings support

		#endregion

		#region Constructors

		public XmlBinaryDictionaryWriter (Stream stream,
			IXmlDictionary dictionary,
			XmlBinaryWriterSession session, bool ownsStream)
		{
			this.stream = stream;
			this.dictionary = dictionary;
			this.session = session;
			owns_stream = ownsStream;

			xml_lang_stack.Push (null);
			xml_space_stack.Push (XmlSpace.None);
		}

		#endregion

		#region Properties

		public override WriteState WriteState {
			get { return state; }
		}
		
		public override string XmlLang {
			get { return xml_lang; }
		}

		public override XmlSpace XmlSpace {
			get { return xml_space; }
		}

		#endregion

		#region Methods

		private void AddMissingElementXmlns ()
		{
			// push new namespaces to manager.
			if (new_namespaces.Count > 0) {
				foreach (DictionaryEntry ent in new_namespaces) {
					string prefix = (string) ent.Key;
					string ns = ent.Value as string;
					XmlDictionaryString dns = ent.Value as XmlDictionaryString;
					if (ns != null) {
						if (prefix.Length > 0) {
							stream.WriteByte (0x09);
							WriteNamePart (prefix);
						}
						else
							stream.WriteByte (0x08);
						WriteNamePart (ns);
						nsmgr.AddNamespace (prefix, ns);
					} else {
						if (prefix.Length > 0) {
							stream.WriteByte (0x0B);
							WriteNamePart (prefix);
						}
						else
							stream.WriteByte (0x0A);
						// FIXME: index could be > 256
						stream.WriteByte ((byte) (dns.Key != 0 ? dns.Key << 1 : 0));
						nsmgr.AddNamespace (prefix, dns.Value);
					}
				}
				new_namespaces.Clear ();
			}
		}

		private void CheckState ()
		{
			CheckOutputState ();
		}

		private void CheckOutputState ()
		{
			if (state == WriteState.Closed) {
				throw new InvalidOperationException ("The Writer is closed.");
			}
		}

		public override void Close ()
		{
			CloseOpenAttributeAndElements ();

			if (owns_stream)
				stream.Close ();
			else if (state != WriteState.Closed)
				stream.Flush ();
			state = WriteState.Closed;
		}

		private void CloseOpenAttributeAndElements ()
		{
			if (open_attribute)
				WriteEndAttribute ();

			 while (open_element_count > 0)
				WriteEndElement ();
		}

		private void CloseStartElement ()
		{
			if (!open_start_element)
				return;

			AddMissingElementXmlns ();

			state = WriteState.Content;
			open_start_element = false;
		}

		public override void Flush ()
		{
			stream.Flush ();
		}

		public override string LookupPrefix (string ns)
		{
			if (ns == null || ns == String.Empty)
				throw new ArgumentException ("The Namespace cannot be empty.");
			foreach (DictionaryEntry de in new_namespaces) {
				XmlDictionaryString dns = de.Value as XmlDictionaryString;
				string cns = dns != null ? dns.Value : de.Value as string;
				if (ns == cns)
					return (string) de.Key;
			}

			string prefix = nsmgr.LookupPrefix (nsmgr.NameTable.Get (ns));
			// XmlNamespaceManager might return such prefix that
			// is *previously* mapped to ns passed above.
			if (prefix == null || nsmgr.LookupNamespace (prefix) != ns)
				return null;
			return prefix;
		}

		public override void WriteBase64 (byte[] buffer, int index, int count)
		{
			CheckState ();

			if (!open_attribute) {
				CloseStartElement ();
			}

			WriteToStream (0x9F, buffer, index, count);
		}

		public override void WriteCData (string text)
		{
			if (text.IndexOf ("]]>") >= 0)
				throw new ArgumentException ("CDATA section cannot contain text \"]]>\".");

			CheckState ();
			CloseStartElement ();

			WriteTextBinary (text);
		}

		public override void WriteCharEntity (char ch)
		{
			WriteChars (new char [] {ch}, 0, 1);
		}

		public override void WriteChars (char[] buffer, int index, int count)
		{
			CheckState ();

			if (!open_attribute) {
				CloseStartElement ();
			}

			if (count == 0)
				stream.WriteByte (0x8B);
			else {
				byte [] data = utf8Enc.GetBytes (buffer, index, count);
				WriteToStream (0x98, data, 0, data.Length);
			}
		}

		public override void WriteComment (string text)
		{
			if (text.EndsWith("-"))
				throw new ArgumentException ("An XML comment cannot contain \"--\" inside.");
			else if (text.IndexOf("--") > 0)
				throw new ArgumentException ("An XML comment cannot end with \"-\".");

			CheckState ();
			CloseStartElement ();

			// FIXME: this 0xA8 might be wrong
			if (text.Length == 0)
				stream.WriteByte (0xA8);
			WriteToStream (0x02, text);
		}

		public override void WriteDocType (string name, string pubid, string sysid, string subset)
		{
			throw new NotSupportedException ("This XmlWriter implementation does not support document type.");
		}

		public override void WriteEndAttribute ()
		{
			if (!open_attribute)
				throw new InvalidOperationException("Token EndAttribute in state Start would result in an invalid XML document.");

			CheckState ();

			open_attribute = false;

			if (attr_value != null) {
				switch (save_target) {
				case SaveTarget.XmlLang:
					xml_lang = attr_value;
					break;
				case SaveTarget.XmlSpace:
					switch (attr_value) {
					case "preserve":
						xml_space = XmlSpace.Preserve;
						break;
					case "default":
						xml_space = XmlSpace.Default;
						break;
					default:
						throw new ArgumentException (String.Format ("Invalid xml:space value: '{0}'", attr_value));
					}
					break;
				case SaveTarget.Namespaces:
					if (current_attr_prefix.Length > 0 && attr_value.Length == 0)
						throw new ArgumentException ("Cannot use prefix with an empty namespace.");

					// add namespace
					nsmgr.AddNamespace (current_attr_prefix, attr_value);
					break;
				}
				WriteTextBinary (attr_value);
				attr_value = null;
			}
		}

		public override void WriteEndDocument ()
		{
			CloseOpenAttributeAndElements ();

			switch (state) {
			case WriteState.Start:
				throw new InvalidOperationException ("Document has not started.");
			case WriteState.Prolog:
				throw new ArgumentException ("This document does not have a root element.");
			}

			state = WriteState.Start;
		}

		public override void WriteEndElement ()
		{
			if (open_element_count == 0)
				throw new InvalidOperationException("There was no XML start tag open.");

			if (open_attribute)
				WriteEndAttribute ();

			CheckState ();
			AddMissingElementXmlns ();

			stream.WriteByte (0x01);

			open_element_count--;
			xml_lang = xml_lang_stack.Pop ();
			xml_space = xml_space_stack.Pop ();
			open_start_element = false;

			nsmgr.PopScope ();
		}

		public override void WriteEntityRef (string name)
		{
			throw new NotSupportedException ("This XmlWriter implementation does not support entity references.");
		}

		public override void WriteFullEndElement ()
		{
			WriteEndElement ();
		}

		public override void WriteProcessingInstruction (string name, string text)
		{
			if (name != "xml")
				throw new ArgumentException ("Processing instructions are not supported. ('xml' is allowed for XmlDeclaration; this is because of design problem of ECMA XmlWriter)");
			// Otherwise, silently ignored. WriteStartDocument()
			// is still callable after this method(!)
		}

		public override void WriteRaw (string data)
		{
			WriteString (data);
		}

		public override void WriteRaw (char[] buffer, int index, int count)
		{
			WriteChars (buffer, index, count);
		}

		public override void WriteStartAttribute (string prefix, string localName, string ns)
		{
			if (prefix == "xml") {
				// MS.NET looks to allow other names than 
				// lang and space (e.g. xml:link, xml:hack).
				ns = XmlNamespace;
				if (localName == "lang") {
					save_target = SaveTarget.XmlLang;
					attr_value = String.Empty;
				}
				else if (localName == "space") {
					save_target = SaveTarget.XmlSpace;
					attr_value = String.Empty;
				}
			}
			if (prefix == null)
				prefix = String.Empty;

			if (prefix.Length > 0 && (ns == null || ns.Length == 0))
				if (prefix != "xmlns")
					throw new ArgumentException ("Cannot use prefix with an empty namespace.");

			if (prefix == "xmlns") {
				if (localName == null || localName.Length == 0) {
					localName = prefix;
					prefix = String.Empty;
				}
			}

			// Note that null namespace with "xmlns" are allowed.
			if ((prefix == "xmlns" || localName == "xmlns" && prefix == String.Empty) && ns != null && ns != XmlnsNamespace)
				throw new ArgumentException (String.Format ("The 'xmlns' attribute is bound to the reserved namespace '{0}'", XmlnsNamespace));

			CheckState ();

			if (state == WriteState.Content)
				throw new InvalidOperationException ("Token StartAttribute in state " + WriteState + " would result in an invalid XML document.");

			if (prefix == null)
				prefix = String.Empty;

			if (ns == null)
				ns = String.Empty;

			int nsIdentifier = prefix.Length > 0 ? 0x05 : 0x04;

			if (ns != String.Empty && prefix != "xmlns") {
				if (prefix.Length > 0) {
					XmlDictionaryString dns = new_namespaces [prefix] as XmlDictionaryString;
					string existingNS = dns != null ? dns.Value : new_namespaces [prefix] as string;
					if (existingNS != null && existingNS != ns)
						throw new ArgumentException (String.Format ("The prefix '{0}' is already bound to the namespace '{1}' and cannot be reassigned to '{2}'", prefix, existingNS, ns));
				}
				else
					prefix = GetNewPrefix (ns, ref nsIdentifier);

				string existingPrefix = LookupPrefix (ns);

				if (existingPrefix != prefix)
					new_namespaces.Add (prefix, ns);
			}

			// Write to Stream
			stream.WriteByte ((byte) nsIdentifier);
			WriteNames (/*nsIdentifier > 1 ? String.Empty : */prefix, localName);

			open_attribute = true;
			state = WriteState.Attribute;

			if (prefix == "xmlns" || prefix == String.Empty && localName == "xmlns") {
				current_attr_prefix = (prefix == "xmlns") ? localName : String.Empty;
				save_target = SaveTarget.Namespaces;
				attr_value = String.Empty;
			}
		}

		static readonly string [] defPrefixes = new string [] {
			"a", "b", "c", "d", "e", "f", "g", "h", "i",
			"j", "k", "l", "m", "n", "o", "p", "q", "r",
			"s", "t", "u", "v", "w", "x", "y", "z", String.Empty};

		private string GetNewPrefix (string ns, ref int nsIdentifier)
		{
			string prefix = nsmgr.LookupPrefix (nsmgr.NameTable.Get (ns));
			if (prefix != null)
				return prefix;
			int startIndex = 0x21 + new_namespaces.Count;
			nsIdentifier = startIndex;
			foreach (DictionaryEntry de in new_namespaces) {
Console.WriteLine ("trying: {0}/{1}, {2:x}", de.Key, de.Value, nsIdentifier);
				if (ns == (string) de.Value)
					return (string) de.Key;
Console.WriteLine ("different: {0}/{1}", de.Key, de.Value);
				nsIdentifier++;
			}

			for (nsIdentifier = startIndex; nsIdentifier < 0x3D; nsIdentifier++) {
				prefix = defPrefixes [nsIdentifier - 0x21];
				if (new_namespaces [prefix] == null)
					return prefix;
			}
			nsIdentifier = 1;

			for (int i = 1; ; i++) {
				prefix = String.Concat ("d", XmlConvert.ToString (open_element_count), "p", XmlConvert.ToString (i));
				if (new_namespaces [prefix] == null)
					return prefix;
			}
		}

		public override void WriteStartDocument ()
		{
			WriteStartDocument (false);
		}

		public override void WriteStartDocument (bool standalone)
		{
			if (state != WriteState.Start)
				throw new InvalidOperationException("WriteStartDocument should be the first call.");

			CheckOutputState ();

			// write nothing to stream.

			state = WriteState.Prolog;
		}

		void PrepareStartElement ()
		{
			CheckState ();
			CloseStartElement ();

			xml_lang_stack.Push (xml_lang);
			xml_space_stack.Push (xml_space);
			nsmgr.PushScope ();
		}

		public override void WriteStartElement (string prefix, string localName, string ns)
		{
			PrepareStartElement ();

			if ((prefix != null && prefix != String.Empty) && ((ns == null) || (ns == String.Empty)))
				throw new ArgumentException ("Cannot use a prefix with an empty namespace.");

			if (ns == null)
				ns = String.Empty;
			if (ns == String.Empty)
				prefix = String.Empty;

			if (prefix == null && ns != null)
				prefix = nsmgr.LookupPrefix (nsmgr.NameTable.Get (ns));
			if (prefix == null)
				prefix = String.Empty;

			stream.WriteByte ((byte) (prefix.Length > 0 ? 0x41 : 0x40));
			WriteNames (prefix, localName);

			PushElement (prefix, ns, ns);
		}

		void PushElement (string prefix, string ns, object nsobj)
		{
			open_element_count++;
			state = WriteState.Element;
			open_start_element = true;

			if (ns.Length == 0)
				return;

			string existing = LookupPrefix (ns);
			if (existing == prefix)
				return;

			new_namespaces.Add (prefix, nsobj);
		}

		public override void WriteString (string text)
		{
			switch (state) {
			case WriteState.Start:
			case WriteState.Prolog:
				throw new InvalidOperationException ("Token content in state Prolog would result in an invalid XML document.");
			}

			if (text == null)
				text = String.Empty;

			CheckState ();

			if (!open_attribute)
			{
				CloseStartElement ();
			}

			if (attr_value != null)
				attr_value += text;
			else
				WriteTextBinary (text);
		}

		public override void WriteSurrogateCharEntity (char lowChar, char highChar)
		{
			WriteChars (new char [] {highChar, lowChar}, 0, 2);
		}

		public override void WriteWhitespace (string ws)
		{
			for (int i = 0; i < ws.Length; i++) {
				switch (ws [i]) {
				case ' ': case '\t': case '\r': case '\n':
					continue;
				default:
					throw new ArgumentException ("Invalid Whitespace");
				}
			}

			CheckState ();

			if (!open_attribute) {
				CloseStartElement ();
			}

			WriteTextBinary (ws);
		}

		#region DictionaryString
		public override void WriteStartElement (string prefix, XmlDictionaryString localName, XmlDictionaryString namespaceUri)
		{
			PrepareStartElement ();

			if (prefix == null && namespaceUri.Value.Length > 0)
				prefix = nsmgr.LookupPrefix (nsmgr.NameTable.Get (namespaceUri.Value));
			if (prefix == null)
				prefix = String.Empty;

			if (prefix.Length == 0)
				stream.WriteByte (0x42);
			else
				WriteToStream (0x43, prefix);
			stream.WriteByte ((byte) (localName.Key != 0 ? localName.Key << 1 : 0));

			PushElement (prefix, namespaceUri.Value, namespaceUri);
		}
		#endregion

		#region WriteValue
		public override void WriteValue (Guid value)
		{
			stream.WriteByte (0xB0);
			byte [] bytes = value.ToByteArray ();
			stream.Write (bytes, 0, bytes.Length);
		}

		public override void WriteValue (UniqueId value)
		{
			WriteToStream (0x8D, value.ToString ());
		}

		public override void WriteValue (TimeSpan value)
		{
			stream.WriteByte (0x8E);
			WriteLong (value.Ticks);
		}
		#endregion

		private void WriteLong (long value)
		{
			long v = 0;
			for (int i = 0; i < 4; i++) {
				v = (v << 4) + value & 0xFF;
				value >>= 4;
			}
			for (int i = 0; i < 4; i++) {
				stream.WriteByte ((byte) (v & 0xFF));
				v >>= 4;
			}
		}

		private void WriteTextBinary (string text)
		{
			if (text.Length == 0)
				stream.WriteByte (0xA8);
			else
				WriteToStream (0x98, text);
		}

		private void WriteNames (string prefix, string localName)
		{
			if (prefix != String.Empty)
				WriteNamePart (prefix);
			WriteNamePart (localName);
		}

		private void WriteNamePart (string name)
		{
			byte [] data = utf8Enc.GetBytes (name);
//			int lengthAdjust = GetLengthAdjust (data.Length);
//			WriteLength (data.Length, lengthAdjust);
			stream.WriteByte ((byte) (data.Length));
			stream.Write (data, 0, data.Length);
		}

		private void WriteToStream (byte identifier, string text)
		{
			if (text.Length == 0) {
				stream.WriteByte (identifier);
				stream.WriteByte (0);
			} else {
				byte [] data = utf8Enc.GetBytes (text);
				WriteToStream (identifier, data, 0, data.Length);
			}
		}

		private void WriteToStream (byte identifier, byte [] data, int start, int len)
		{
			int lengthAdjust = GetLengthAdjust (len);
			stream.WriteByte ((byte) (identifier + lengthAdjust));
			WriteLength (len, lengthAdjust);
			stream.Write (data, start, len);
		}

		private int GetLengthAdjust (int count)
		{
			int lengthAdjust = 0;
			for (int ctmp = count; ctmp >= 0x100; ctmp /= 0x100)
				lengthAdjust++;
			return lengthAdjust;
		}

		private void WriteLength (int count, int lengthAdjust)
		{
			for (int i = 0, ctmp = count; i < lengthAdjust + 1; i++, ctmp /= 0x100)
				stream.WriteByte ((byte) (ctmp % 0x100));
		}

		#endregion
	}
}
