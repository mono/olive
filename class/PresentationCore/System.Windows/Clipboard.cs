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
// Copyright (c) 2007 Novell, Inc. (http://www.novell.com)
//
// Authors:
//	Chris Toshok (toshok@novell.com)
//

using System;
using System.Security;
using System.IO;
using System.Collections.Specialized;
#if notyet
using System.Windows.Media.Imaging;
#endif

namespace System.Windows {

	public static class Clipboard
	{
		[SecurityCritical]
		public static void Clear ()
		{
			throw new NotImplementedException ();
		}

		public static bool ContainsAudio ()
		{
			throw new NotImplementedException ();
		}

		public static bool ContainsData (string format)
		{
			throw new NotImplementedException ();
		}

		public static bool ContainsFileDropList ()
		{
			throw new NotImplementedException ();
		}

		public static bool ContainsText ()
		{
			throw new NotImplementedException ();
		}

		public static bool ContainsText (TextDataFormat format)
		{
			throw new NotImplementedException ();
		}

		public static Stream GetAudioStream ()
		{
			throw new NotImplementedException ();
		}

		public static object GetData (string format)
		{
			throw new NotImplementedException ();
		}

		[SecurityCritical]
		public static IDataObject GetDataObject ()
		{
			throw new NotImplementedException ();
		}

		public static StringCollection GetFileDropList ()
		{
			throw new NotImplementedException ();
		}

#if notyet
		public static BitmapSource GetImage ()
		{
			throw new NotImplementedException ();
		}
#endif
		public static string GetText ()
		{
			throw new NotImplementedException ();
		}

		public static string GetText (TextDataFormat format)
		{
			throw new NotImplementedException ();
		}

		public static bool IsCurrent (IDataObject data)
		{
			throw new NotImplementedException ();
		}

		public static void SetAudio (byte[] audioBytes)
		{
			throw new NotImplementedException ();
		}
		public static void SetAudio (Stream audioStream)
		{
			throw new NotImplementedException ();
		}

		public static void SetData (string format, object data)
		{
			throw new NotImplementedException ();
		}

		[SecurityCritical]
		public static void SetDataObject (object data)
		{
			throw new NotImplementedException ();
		}

		[SecurityCritical]
		public static void SetDataObject (object data, bool copy)
		{
			throw new NotImplementedException ();
		}

		public static void SetFileDropList (StringCollection fileDropList)
		{
			throw new NotImplementedException ();
		}

#if notyet
		public static void SetImage (BitmapSource image)
		{
			throw new NotImplementedException ();
		}
#endif

		public static void SetText (string text)
		{
			throw new NotImplementedException ();
		}

		public static void SetText (string text, TextDataFormat format)
		{
			throw new NotImplementedException ();
		}
	}
}
