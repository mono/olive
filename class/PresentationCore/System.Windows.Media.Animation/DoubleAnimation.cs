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

namespace System.Windows.Media.Animation {

	public class DoubleAnimation : DoubleAnimationBase {
		public static readonly DependencyProperty ByProperty;
		public static readonly DependencyProperty FromProperty;
		public static readonly DependencyProperty ToProperty;

		public DoubleAnimation ()
		{
			throw new NotImplementedException ();
		}

		public DoubleAnimation (double toValue,
					Duration duration)
		{
			throw new NotImplementedException ();
		}

		public DoubleAnimation (double fromValue,
					double toValue,
					Duration duration)
		{
			throw new NotImplementedException ();
		}

		public DoubleAnimation (double toValue,
					Duration duration,
					FillBehavior fillBehavior)
		{
			throw new NotImplementedException ();
		}

		public DoubleAnimation (double fromValue,
					double toValue,
					Duration duration,
					FillBehavior fillBehavior)
		{
			throw new NotImplementedException ();
		}

		public new DoubleAnimation Clone ()
		{
			throw new NotImplementedException ();
		}

		protected override Freezable CreateInstanceCore ()
		{
			throw new NotImplementedException ();
		}

		protected override double GetCurrentValueCore (double defaultOriginValue,
							       double defaultDestinationValue,
							       AnimationClock animationClock)
		{
			throw new NotImplementedException ();
		}

		public Nullable<double> By { 
			get { return (Nullable<double>)GetValue (ByProperty); }
			set { SetValue (ByProperty, value); }
		}

		public Nullable<double> From { 
			get { return (Nullable<double>)GetValue (FromProperty); }
			set { SetValue (FromProperty, value); }
		}

		public bool IsAdditive { 
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		public bool IsCumulative { 
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		public Nullable<double> To { 
			get { return (Nullable<double>)GetValue (ToProperty); }
			set { SetValue (ToProperty, value); }
		}
	}

}
