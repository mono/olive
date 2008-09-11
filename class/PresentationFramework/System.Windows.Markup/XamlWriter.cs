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
// Copyright (c) 2008 Novell, Inc. (http://www.novell.com)
//

using System;
using System.ComponentModel;
using System.IO;
using System.Xml;

namespace System.Windows.Markup {

	public static class XamlWriter
	{
		public static string Save (object obj)
		{
			if (obj == null)
				throw new ArgumentNullException ();
			throw new NotImplementedException ();
		}

		public static void Save (object obj, Stream stream)
		{
			if (obj == null || stream == null)
				throw new ArgumentNullException ();
			throw new NotImplementedException ();
		}

		public static void Save (object obj, TextWriter writer)
		{
			if (obj == null || writer == null)
				throw new ArgumentNullException ();
			throw new NotImplementedException ();
		}

		public static void Save (object obj, XmlWriter writer)
		{
			if (obj == null || writer == null)
				throw new ArgumentNullException ();
			throw new NotImplementedException ();
		}

		public static void Save (object obj, XamlDesignerSerializationManager manager)
		{
			if (obj == null || manager == null)
				throw new ArgumentNullException ();
			throw new NotImplementedException ();
		}
	}

}
