//
// JsonWriter.cs
//
// Author:
//	Atsushi Enomoto  <atsushi@ximian.com>
//
// Copyright (C) 2007 Novell, Inc (http://www.novell.com)
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
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;

namespace System.Xml
{
	// FIXME: quotas check
	class JsonReader : XmlDictionaryReader, IXmlJsonReaderInitializer
	{
		class ElementInfo
		{
			public readonly string Name;
			public readonly string Type;
			public bool HasContent;

			public ElementInfo (string name, string type)
			{
				this.Name = name;
				this.Type = type;
			}
		}

		TextReader reader;
		XmlDictionaryReaderQuotas quotas;
		OnXmlDictionaryReaderClose on_close;
		XmlNameTable name_table = new NameTable ();

		XmlNodeType current_node, attr_state; // Attribute(type)/Text(value)/None
		string simple_value;
		string next_element;
		ReadState read_state = ReadState.Initial;
		bool content_stored;
		bool finished;
		Stack<ElementInfo> elements = new Stack<ElementInfo> ();

		int line = 1, column = 0;

		int saved_char = -1;

		// Constructors

		public JsonReader (byte [] buffer, int offset, int count, Encoding encoding, XmlDictionaryReaderQuotas quotas, OnXmlDictionaryReaderClose onClose)
		{
			SetInput (buffer, offset, count, encoding, quotas, onClose);
		}

		public JsonReader (Stream stream, Encoding encoding, XmlDictionaryReaderQuotas quotas, OnXmlDictionaryReaderClose onClose)
		{
			SetInput (stream, encoding, quotas, onClose);
		}

		// IXmlJsonReaderInitializer

		public void SetInput (byte [] buffer, int offset, int count, Encoding encoding, XmlDictionaryReaderQuotas quotas, OnXmlDictionaryReaderClose onClose)
		{
			SetInput (new MemoryStream (buffer, offset, count), encoding, quotas, onClose);
		}

		public void SetInput (Stream stream, Encoding encoding, XmlDictionaryReaderQuotas quotas, OnXmlDictionaryReaderClose onClose)
		{
			reader = new StreamReader (stream, encoding ?? Encoding.UTF8);
			if (quotas == null)
				throw new ArgumentNullException ("quotas");
			this.quotas = quotas;
			this.on_close = onClose;
		}

		// XmlDictionaryReader

		public override int AttributeCount {
			get { return current_node == XmlNodeType.Element ? 1 : 0; }
		}

		public override string BaseURI {
			get { return String.Empty; }
		}

		public override int Depth {
			get {
				int mod =
					attr_state == XmlNodeType.Attribute ? 1 :
					attr_state == XmlNodeType.Text ? 2 :
					0;
				return read_state != ReadState.Interactive ? 0 : elements.Count - 1 + mod;
			}
		}

		public override bool EOF {
			get {
				switch (read_state) {
				case ReadState.Closed:
				case ReadState.EndOfFile:
					return true;
				default:
					return false;
				}
			}
		}

		public override bool HasValue {
			get {
				switch (NodeType) {
				case XmlNodeType.Attribute:
				case XmlNodeType.Text:
					return true;
				default:
					return false;
				}
			}
		}

		public override bool IsEmptyElement {
			get { return false; }
		}

		public override string LocalName {
			get {
				switch (NodeType) {
				case XmlNodeType.Attribute:
					return "type";
				case XmlNodeType.Element:
				case XmlNodeType.EndElement:
					return elements.Peek ().Name;
				default:
					return String.Empty;
				}
			}
		}

		public override string NamespaceURI {
			get { return String.Empty; }
		}

		public override XmlNameTable NameTable {
			get { return name_table; }
		}

		public override XmlNodeType NodeType {
			get { return attr_state != XmlNodeType.None ? attr_state : current_node; }
		}

		public override string Prefix {
			get { return String.Empty; }
		}

		public override ReadState ReadState {
			get { return read_state; }
		}

		public override string Value {
			get { return attr_state != XmlNodeType.None ? elements.Peek ().Type : current_node == XmlNodeType.Text ? simple_value : String.Empty; }
		}

		public override void Close ()
		{
			if (on_close != null) {
				on_close (this);
				on_close = null;
			}
			read_state = ReadState.Closed;
		}

		public override string GetAttribute (int index)
		{
			if (index == 0 && AttributeCount == 1)
				return elements.Peek ().Type;
			throw new ArgumentOutOfRangeException ("index", "Index is must be 0 and only valid on an element on this XmlDictionaryReader");
		}

		public override string GetAttribute (string name)
		{
			if (current_node == XmlNodeType.Element && name == "type")
				return elements.Peek ().Type;
			return null;
		}

		public override string GetAttribute (string localName, string ns)
		{
			if (current_node == XmlNodeType.Element && localName == "type" && ns == String.Empty)
				return elements.Peek ().Type;
			return null;
		}

		public override string LookupNamespace (string prefix)
		{
			if (prefix == null)
				throw new ArgumentNullException ("prefix");
			else if (prefix.Length == 0)
				return String.Empty;
			return null;
		}

		public override bool MoveToAttribute (string name)
		{
			if (current_node != XmlNodeType.Element || name != "type")
				return false;
			attr_state = XmlNodeType.Attribute;
			return true;
		}

		public override bool MoveToAttribute (string localName, string ns)
		{
			if (current_node != XmlNodeType.Element || localName != "type" || ns != String.Empty)
				return false;
			attr_state = XmlNodeType.Attribute;
			return true;
		}

		public override bool MoveToElement ()
		{
			if (attr_state == XmlNodeType.None)
				return false;
			attr_state = XmlNodeType.None;
			return true;
		}

		public override bool MoveToFirstAttribute ()
		{
			if (current_node != XmlNodeType.Element)
				return false;
			attr_state = XmlNodeType.Attribute;
			return true;
		}

		public override bool MoveToNextAttribute ()
		{
			if (attr_state != XmlNodeType.None)
				return false;
			return MoveToFirstAttribute ();
		}

		public override bool ReadAttributeValue ()
		{
			if (attr_state != XmlNodeType.Attribute)
				return false;
			attr_state = XmlNodeType.Text;
			return true;
		}

		public override void ResolveEntity ()
		{
			throw new NotSupportedException ();
		}

		public override bool Read ()
		{
			switch (read_state) {
			case ReadState.EndOfFile:
			case ReadState.Closed:
			case ReadState.Error:
				return false;
			case ReadState.Initial:
				read_state = ReadState.Interactive;
				next_element = "root";
				current_node = XmlNodeType.Element;
				break;
			}

			if (content_stored) {
				if (current_node == XmlNodeType.Element) {
					if (elements.Peek ().Type == "null") {
						// since null is not consumed as text content, it skips Text state.
						current_node = XmlNodeType.EndElement;
						content_stored = false;
					}
					else
						current_node = XmlNodeType.Text;
					return true;
				} else if (current_node == XmlNodeType.Text) {
					current_node = XmlNodeType.EndElement;
					content_stored = false;
					return true;
				}
			}
			else if (current_node == XmlNodeType.EndElement) {
				// clear EndElement state
				elements.Pop ();
				if (elements.Count > 0)
					elements.Peek ().HasContent = true;
				else
					finished = true;
			}

			SkipWhitespaces ();

			// Default. May be overriden only as EndElement or None.
			current_node = XmlNodeType.Element;

			if (!ReadContent (false))
				return false;
			if (finished)
				throw XmlError ("Multiple top-level content is not allowed");
			return true;
		}

		bool ReadContent (bool objectValue)
		{
			int ch = ReadChar ();
			if (ch < 0) {
				ReadEndOfStream ();
				return false;
			}

			bool itemMustFollow = false;

			if (!objectValue && elements.Count > 0 && elements.Peek ().HasContent) {
				if (ch == ',') {
					switch (elements.Peek ().Type) {
					case "object":
					case "array":
						SkipWhitespaces ();
						ch = ReadChar ();
						itemMustFollow = true;
						break;
					}
				}
				else if (ch != '}' && ch != ']')
					throw XmlError ("Comma is required unless an array or object is at the end");
			}

			if (elements.Count > 0 && elements.Peek ().Type == "array")
				next_element = "item";

			switch (ch) {
			case '{':
				ReadStartObject ();
				return true;
			case '[':
				ReadStartArray ();
				return true;
			case '}':
				if (itemMustFollow)
					throw XmlError ("Invalid comma before an end of object");
				if (objectValue)
					throw XmlError ("Invalid end of object as an object content");
				ReadEndObject ();
				return true;
			case ']':
				if (itemMustFollow)
					throw XmlError ("Invalid comma before an end of array");
				if (objectValue)
					throw XmlError ("Invalid end of array as an object content");
				ReadEndArray ();
				return true;
			case '"':
				string s = ReadStringLiteral ();
				if (!objectValue && elements.Count > 0 && elements.Peek ().Type == "object") {
					string name = s;
					next_element = name;
					SkipWhitespaces ();
					Expect (':');
					SkipWhitespaces ();
					ReadContent (true);
				}
				else
					ReadAsSimpleContent ("string", s);
				return true;
			case '-':
				ReadNumber (ch);
				return true;
			case 'n':
				if (ReadChar () == 'u' &&
				    ReadChar () == 'l' &&
				    ReadChar () == 'l') {
				    	ReadAsSimpleContent ("null", "null");
					return true;
				}
				goto default;
			case 't':
				if (ReadChar () == 'r' &&
				    ReadChar () == 'u' &&
				    ReadChar () == 'e') {
				    	ReadAsSimpleContent ("boolean", "true");
					return true;
				}
				goto default;
			case 'f':
				if (ReadChar () == 'a' &&
				    ReadChar () == 'l' &&
				    ReadChar () == 's' &&
				    ReadChar () == 'e') {
				    	ReadAsSimpleContent ("boolean", "false");
					return true;
				}
				goto default;
			default:
				if ('0' <= ch && ch <= '9') {
					ReadNumber (ch);
					return true;
				}
				throw XmlError ("Unexpected token");
			}
		}

		void ReadStartObject ()
		{
			elements.Push (new ElementInfo (next_element, "object"));
		}

		void ReadStartArray ()
		{
			elements.Push (new ElementInfo (next_element, "array"));
		}

		void ReadEndObject ()
		{
			if (elements.Count == 0 || elements.Peek ().Type != "object")
				throw XmlError ("Unexpected end of object");
			current_node = XmlNodeType.EndElement;
		}

		void ReadEndArray ()
		{
			if (elements.Count == 0 || elements.Peek ().Type != "array")
				throw XmlError ("Unexpected end of array");
			current_node = XmlNodeType.EndElement;
		}

		void ReadEndOfStream ()
		{
			if (elements.Count > 0)
				throw XmlError (String.Format ("{0} missing end of arrays or objects", elements.Count));
			read_state = ReadState.EndOfFile;
			current_node = XmlNodeType.None;
		}

		void ReadAsSimpleContent (string type, string value)
		{
			elements.Push (new ElementInfo (next_element, type));
			simple_value = value;
			content_stored = true;
		}

		void ReadNumber (int ch)
		{
			elements.Push (new ElementInfo (next_element, "number"));
			content_stored = true;

			int init = ch;
			int prev;
			bool floating = false, exp = false;

			StringBuilder sb = new StringBuilder ();
			bool cont = true;
			do {
				sb.Append ((char) ch);
				prev = ch;
				ch = ReadChar ();

				if (prev == '-' && !IsNumber (ch)) // neither '.', '-' or '+' nor anything else is valid
					throw XmlError ("Invalid JSON number");

				switch (ch) {
				case 'e':
				case 'E':
					if (exp)
						throw XmlError ("Invalid JSON number token. Either 'E' or 'e' must not occur more than once");
					if (!IsNumber (prev))
						throw XmlError ("Invalid JSON number token. only a number is valid before 'E' or 'e'");
					exp = true;
					break;
				case '.':
					if (floating)
						throw XmlError ("Invalid JSON number token. '.' must not occur twice");
					if (exp)
						throw XmlError ("Invalid JSON number token. '.' must not occur after 'E' or 'e'");
					floating = true;
					break;
				default:
					if (!IsNumber (ch)) {
						saved_char = ch;
						cont = false;
					}
					break;
				}
			} while (cont);

			if (!IsNumber (prev)) // only number is valid at the end
				throw XmlError ("Invalid JSON number");

			simple_value = sb.ToString ();

			if (init == '0' && !floating && !exp && simple_value != "0")
				throw XmlError ("Invalid JSON number");
		}

		bool IsNumber (int c)
		{
			return '0' <= c && c <= '9';
		}

		// FIXME: implement
		string ReadStringLiteral ()
		{
			StringBuilder sb = new StringBuilder ();

			do {
				int ch = ReadChar ();
				if (ch < 0)
					throw XmlError ("Unexpected end of stream in string literal");
				if (ch == '"')
					return sb.ToString ();
				sb.Append ((char) ch);
			} while (true);
		}

		int ReadChar ()
		{
			int v = saved_char >= 0 ? saved_char : reader.Read ();
			saved_char = -1;
			if (v == '\n') {
				line++;
				column = 0;
			}
			else
				column++;
			return v;
		}

		void SkipWhitespaces ()
		{
			do {
				switch (reader.Peek ()) {
				case ' ':
				case '\t':
				case '\r':
				case '\n':
					reader.Read ();
					continue;
				default:
					return;
				}
			} while (true);
		}

		void Expect (char c)
		{
			int v = ReadChar ();
			if (v < 0)
				throw XmlError (String.Format ("Expected '{0}' but got EOF", c));
			if (v != c)
				throw XmlError (String.Format ("Expected '{0}' but got '{1}'", c, (char) v));
		}

		Exception XmlError (string s)
		{
			return new XmlException (String.Format ("{0} ({1},{2})", s, line, column));
		}
	}
}
