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
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace System.Windows.Media {

	//[LocalizabilityAttribute(LocalizationCategory.None, Readability=Readability.Unreadable)] 
	public abstract class GeneralTransform : Animatable, IFormattable {
		public new GeneralTransform Clone ()
		{
			throw new NotImplementedException ();
		}

		public new GeneralTransform CloneCurrentValue ()
		{
			throw new NotImplementedException ();
		}

		string IFormattable.ToString (string format,
					      IFormatProvider provider)
		{
			throw new NotImplementedException ();
		}

		public override string ToString ()
		{
			throw new NotImplementedException ();
		}

		public string ToString (IFormatProvider provider)
		{
			throw new NotImplementedException ();
		}

		public Point Transform (Point point)
		{
			throw new NotImplementedException ();
		}


		public abstract Rect TransformBounds (Rect rect);

		public abstract bool TryTransform (Point inPoint,
						   out Point result);

		public abstract GeneralTransform Inverse { get; }
	}

}
