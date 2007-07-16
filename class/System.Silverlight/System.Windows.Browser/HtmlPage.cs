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
using System.Runtime.InteropServices;

namespace System.Windows.Browser {

	public class HtmlPage : HtmlObject {

		private static BrowserInformation browser_info;

		public HtmlPage ()
		{
		}

		public static BrowserInformation BrowserInformation {
			get {
				if (browser_info == null)
					browser_info = new BrowserInformation ();
				return browser_info;
			}
		}

		public static string Cookies {
			get { return null; }
			set { ; }
		}

		public static string CurrentBookmark {
			get { return null; }
			set { ; }
		}

		public static HtmlDocument Document {
			get {
				Console.WriteLine ("YO!");
				return null;
			}
		}

		public static Uri DocumentUri {
			get { return null; }
		}

		public static IDictionary<string,string> QueryString {
			get { return null; }
		}

		public static HtmlObject Window {
			get { return null; }
		}

		public static void Navigate (string navigateToUri)
		{
			Navigate (WebApplication.Current.PluginHandle, navigateToUri);
		}

		public static ScriptableObject Navigate (string navigateToUri, string target)
		{
			IntPtr handle = Navigate (WebApplication.Current.PluginHandle, navigateToUri, target, null);
			return new ScriptableObject (handle);
		}

		public static ScriptableObject Navigate (string navigateToUri, string target, string targetFeatures)
		{
			IntPtr handle = Navigate (WebApplication.Current.PluginHandle, navigateToUri, target, targetFeatures);
			return new ScriptableObject (handle);
		}

		public static void NavigateToBookmark (string bookmark)
		{
			NavigateToBookmark (WebApplication.Current.PluginHandle, bookmark);
		}

		public static void Submit ()
		{
			Submit (WebApplication.Current.PluginHandle, null);
		}

		public static void Submit (string formId)
		{
			Submit (WebApplication.Current.PluginHandle, formId);
		}

		[DllImport ("moonplugin")]
		static extern void Navigate (IntPtr npp, string uri);

		[DllImport ("moonplugin")]
		static extern IntPtr Navigate (IntPtr npp, string uri, string target, string features);

		[DllImport ("moonplugin")]
		static extern void NavigateToBookmark (IntPtr xpp, string bookmark);

		[DllImport ("moonplugin")]
		static extern void Submit (IntPtr xpp, string formId);
	}
}
