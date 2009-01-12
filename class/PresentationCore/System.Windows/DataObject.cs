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
// Author:
//	Chris Toshok (toshok@ximian.com)
//

using System.IO;
using System.Security;
using System.Collections.Specialized;
using System.Windows.Media.Imaging;

namespace System.Windows {

	public class DataObject : IDataObject {
		[SecurityCritical]
		public DataObject ()
		{
		}

		[SecurityCritical]
		public DataObject (object data)
		{
		}

		[SecurityCritical]
		public DataObject (string format, object data)
		{
		}

		[SecurityCritical]
		public DataObject (string format, object data, bool autoConvert)
		{
		}

		[SecurityCritical]
		public DataObject (Type format, object data)
		{
		}

		public bool ContainsAudio ()
		{
			throw new NotImplementedException ();
		}

		public Stream GetAudioStream ()
		{
			throw new NotImplementedException ();
		}

		public void SetAudio (byte[] audioBytes)
		{
			throw new NotImplementedException ();
		}

		public void SetAudio (Stream audioStream)
		{
			throw new NotImplementedException ();
		}

		public bool ContainsImage ()
		{
			throw new NotImplementedException ();
		}

#if notyet
		public BitmapSource GetImage ()
		{
			throw new NotImplementedException ();
		}

		public void SetImage (BitmapSource image)
		{
			throw new NotImplementedException ();
		}
#endif

		public bool ContainsFileDropList ()
		{
			throw new NotImplementedException ();
		}

		public StringCollection GetFileDropList ()
		{
			throw new NotImplementedException ();
		}

		public void SetFileDropList (StringCollection fileDropList)
		{
			throw new NotImplementedException ();
		}

		public bool ContainsText ()
		{
			throw new NotImplementedException ();
		}

		public bool ContainsText (TextDataFormat format)
		{
			throw new NotImplementedException ();
		}

		public string GetText ()
		{
			throw new NotImplementedException ();
		}

		public string GetText (TextDataFormat format)
		{
			throw new NotImplementedException ();
		}

		public void SetText (string text)
		{
			throw new NotImplementedException ();
		}

		public void SetText (string text, TextDataFormat format)
		{
			throw new NotImplementedException ();
		}

		public virtual object GetData (string format, bool autoConvert)
		{
			throw new NotImplementedException ();
		}

		public virtual object GetData (Type format)
		{
			throw new NotImplementedException ();
		}

		public virtual object GetData (string format)
		{
			throw new NotImplementedException ();
		}

		public virtual bool GetDataPresent (string format, bool autoConvert)
		{
			throw new NotImplementedException ();
		}

		public virtual bool GetDataPresent (Type format)
		{
			throw new NotImplementedException ();
		}

		public virtual bool GetDataPresent (string format)
		{
			throw new NotImplementedException ();
		}

		public string[] GetFormats ()
		{
			throw new NotImplementedException ();
		}

		public string[] GetFormats (bool autoConvert)
		{
			throw new NotImplementedException ();
		}

		[SecurityCritical]
		public virtual void SetData (object data)
		{
			throw new NotImplementedException ();
		}

		[SecurityCritical]
		public virtual void SetData (string format, object data)
		{
			throw new NotImplementedException ();
		}

		[SecurityCritical]
		public virtual void SetData (string format, object data, bool autoConvert)
		{
			throw new NotImplementedException ();
		}

		[SecurityCritical]
		public virtual void SetData (Type format, object data)
		{
			throw new NotImplementedException ();
		}

		public static void AddCopyingHandler (DependencyObject element, DataObjectCopyingEventHandler handler)
		{
			throw new NotImplementedException ();
		}

		public static void RemoveCopyingHandler (DependencyObject element, DataObjectCopyingEventHandler handler)
		{
			throw new NotImplementedException ();
		}

		public static void AddPastingHandler (DependencyObject element, DataObjectPastingEventHandler handler)
		{
			throw new NotImplementedException ();
		}

		public static void RemovePastingHandler (DependencyObject element, DataObjectPastingEventHandler handler)
		{
			throw new NotImplementedException ();
		}

		public static void AddSettingDataHandler (DependencyObject element, DataObjectSettingDataEventHandler handler)
		{
			throw new NotImplementedException ();
		}

		public static void RemoveSettingDataHandler (DependencyObject element, DataObjectSettingDataEventHandler handler)
		{
			throw new NotImplementedException ();
		}

		public static readonly RoutedEvent CopyingEvent;
		public static readonly RoutedEvent PastingEvent;
		public static readonly RoutedEvent SettingDataEvent;
	}

}