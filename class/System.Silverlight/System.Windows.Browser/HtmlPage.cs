//
// System.Windows.Browser.HtmlPage class
//
// Authors:
//	Sebastien Pouliot  <sebastien@ximian.com>
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

using System.Collections.Generic;

namespace System.Windows.Browser {

	public class HtmlPage : HtmlObject {

		private static BrowserInformation browser_info;

		public HtmlPage ()
		{
		}

		public static BrowserInformation BrowserInformation {
			get { return browser_info; }
		}

		public static string Cookies {
			get { return null; }
			set { ; }
		}

		public static string CurrentBookmark {
			get { return null; }
			set { ; }
		}
/*
		public static HtmlDocument Document {
			get { return null; }
		}
*/
		public static Uri DocumentUri {
			get { return null; }
		}

		public static IDictionary<string,string> QueryString {
			get { return null; }
		}

		public static HtmlObject Window {
			get { return null; }
		}

		[MonoTODO]
		public static void Navigate (string navigateToUri)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public static ScriptableObject Navigate (string navigateToUri, string target)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public static ScriptableObject Navigate (string navigateToUri, string target, string targetFeatures)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public static void NavigateToBookmark (string bookmark)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public static void Submit ()
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public static void Submit (string formId)
		{
			throw new NotImplementedException ();
		}
	}
}
