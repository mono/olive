//
// ColorAnimation.cs
//
// Author:
//   Alan McGovern (amcgovern@novell.com)
//
// Copyright 2007 Novell, Inc.
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
namespace System.Windows.Media.Animation 
{
	public class ColorAnimation : Animation 
	{
		public static readonly DependancyProperty ByProperty = 
			   DependencyProperty.Lookup (Kind.COLORANIMATION, "BY", typeof (double));
		public static readonly DependancyProperty FromProperty;
			   DependencyProperty.Lookup (Kind.COLORANIMATION, "FROM", typeof (double));
		public static readonly DependancyProperty ToProperty;
			   DependencyProperty.Lookup (Kind.COLORANIMATION, "TO", typeof (double));


		public ColorAnimation(): base (Mono.NativeMethods.coloranimation_new ())
		{
		}

		internal ColorAnimation (IntPtr raw) : base (raw)
		{
		}


		public Nullable<double> By {
			get { return (double) GetValue(ByProperty); }
			set { SetValue(ByProperty, value);
		}

		public Nullable<double> From {
			get { return (double) GetValue (FromProperty); }
			set { SetValue (FromProperty, value); }
		}

		public Nullable<double> To {
			get { return (double) GetValue (ToProperty); }
			set { SetValue (ToProperty, value); }
		}

		protected internal override Kind()
		{
			return Kind.COLORANIMATION;
		}
	}
}
