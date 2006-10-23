//
// XmlBinaryDictionaryWriter.cs
//
// Author:
//	Atsushi Enomoto  <atsushi@ximian.com>
//
// Copyright (C) 2005 Novell, Inc.  http://www.novell.com
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
	/* Binary Format (maybe incomplete):

		StartAttribute without Prefix: 00 name
		StartAttribute with Prefix without nsIndex: 01 prefix name
		StartAttribute dict. without Prefix: 02 nameIdx
		StartAttribute dict. with Prefix: 03 prefix nameIdx
		StartAttribute with Prefix with nsIndex: [22-3B] name
		Missing default namespace: 04 ns (before 3C)
		Missing non-default namespace: 05 prefix ns (before 3C)
		EndElement: 3C
		Comment: 3D fixed_len utf8bin
		StartElement with no Prefix: 3F name
		StartElement with Prefix: 40 prefix name
		StartElement dict. with no Prefix: 41 name
		StartElement dict. with Prefix: 42 prefix nameIdx
		Empty string: 82
		Text, CDATA, Whitespace: 83 len utf8bin
		Text, CDATA, Whitespace + EndElement?: 9D len utf8bin

		FIXME: Below are not implemented:
		byte : 7B
		short : 7C
		int : 7D
		long: 7E
		float: 7F
		double: 80
		decimal: 81
		DateTime: 82
		UniqueId: 8D
		TimeSpan: 8E
		Guid: 8F
		base64Binary: A0
		(Uri is simply 83, QName is 83 '{' ns '}' 83 name)

		Error: PIs, doctype
		Ignored: XMLdecl

		prefix, name and ns are name strings: length utf8bin

	*/

	// FIXME:
	//	- Support XmlBinaryWriterSession (esp. EmitStrings).
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
					string ns = (string) ent.Value;
					if (prefix.Length > 0) {
						stream.WriteByte (0x05);
						WriteNamePart (prefix);
					}
					else
						stream.WriteByte (0x04);
					WriteNamePart (ns);
					nsmgr.AddNamespace (prefix, ns);
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

			// FIXME: I think this should be done, but WinFX beta1 
			// does not output missing ones.
			// while (open_element_count > 0) {
			//	WriteEndElement ();
			//}
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
			foreach (DictionaryEntry de in new_namespaces)
				if (ns == de.Value as string)
					return (string) de.Key;

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

			WriteToStream (0xA0, buffer, index, count);
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
				WriteToStream (0x83, data, 0, data.Length);
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

			WriteToStream (0x3D, text);
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

			stream.WriteByte (0x3C);

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
				throw new InvalidOperationException ("Processing instructions are not supported. ('xml' is allowed for XmlDeclaration; this is because of design problem of ECMA XmlWriter)");
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

			int nsIdentifier = prefix.Length > 0 ? 1 : 0;

			if (ns != String.Empty && prefix != "xmlns") {
				if (prefix.Length > 0) {
					string existingNS = new_namespaces [prefix] as string;
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
			WriteNames (nsIdentifier > 1 ? String.Empty : prefix, localName);

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

		public override void WriteStartElement (string prefix, string localName, string ns)
		{
			CheckState ();
			CloseStartElement ();

			xml_lang_stack.Push (xml_lang);
			xml_space_stack.Push (xml_space);
			nsmgr.PushScope ();

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

			stream.WriteByte ((byte) (prefix.Length > 0 ? 0x40 : 0x3F));
			WriteNames (prefix, localName);

			open_element_count++;
			state = WriteState.Element;
			open_start_element = true;

			if (ns.Length > 0) {
				string existing = LookupPrefix (ns);
				if (existing != prefix) {
					new_namespaces.Add (prefix, ns);
				}
			} else {
				if (ns != nsmgr.DefaultNamespace) {
					new_namespaces.Add ("", ns);
				}
			}
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

		private void WriteTextBinary (string text)
		{
			if (text.Length == 0)
				stream.WriteByte (0x8B);
			else
				WriteToStream (0x83, text);
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
