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
using System.ComponentModel;
using System.Windows;

namespace System.Windows.Media {

#if notyet
	[TypeConverterAttribute(typeof(TransformConverter))] 
#endif
	[LocalizabilityAttribute(LocalizationCategory.None, Readability=Readability.Unreadable)] 
	public abstract class Transform : GeneralTransform {

		internal Transform ()
		{
		}

		public new Transform Clone ()
		{
			throw new NotImplementedException ();
		}

		public new Transform CloneCurrentValue ()
		{
			throw new NotImplementedException ();
		}

		public static Transform Parse (string source)
		{
			throw new NotImplementedException ();
		}

		public override Rect TransformBounds (Rect rect)
		{
			throw new NotImplementedException ();
		}

		public override bool TryTransform (Point inPoint,
						   out Point result)
		{
			throw new NotImplementedException ();
		}

		public static Transform Identity {
			get {
				throw new NotImplementedException ();
			}
		}

		public override GeneralTransform Inverse {
			get {
				throw new NotImplementedException ();
			}
		}

		public abstract Matrix Value { get; }
	}

}
