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
//	Chris Toshok (toshok@ximian.com)
//

using System;
using System.Security;

namespace System.Windows {
	public static class DataFormats
	{
		public static readonly string Bitmap = "Bitmap";
		public static readonly string CommaSeparatedValue = "CSV";
		public static readonly string Dib = "DeviceIndependentBitmap";
		public static readonly string Dif = "DataInterchangeFormat";
		public static readonly string EnhancedMetafile = "EnhancedMetafile";
		public static readonly string FileDrop = "FileDrop";
		public static readonly string Html = "HTML Format";
		public static readonly string Locale = "Locale";
		public static readonly string MetafilePicture = "MetaFilePict";
		public static readonly string OemText = "OEMText";
		public static readonly string Palette = "Palette";
		public static readonly string PenData = "PenData";
		public static readonly string Riff = "RiffAudio";
		public static readonly string Rtf = "Rich Text Format";
		public static readonly string Serializable = "PersistentObject";
		public static readonly string StringFormat = "System.String";
		public static readonly string SymbolicLink = "SymbolicLink";
		public static readonly string Text = "Text";
		public static readonly string Tiff = "TaggedImageFileFormat";
		public static readonly string UnicodeText = "UnicodeText";
		public static readonly string WaveAudio = "WaveAudio";
		public static readonly string Xaml = "Xaml";
		public static readonly string XamlPackage = "XamlPackage";

		public static DataFormat GetDataFormat (int id)
		{
			throw new NotImplementedException ();
		}

		[SecurityCritical]
		public static DataFormat GetDataFormat (string format)
		{
			throw new NotImplementedException ();
		}
	}
}
