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

using System.Windows;
using System.Windows.Media.Animation;

namespace System.Windows.Media {

	public class VisualBrush : TileBrush
	{
		public VisualBrush (Visual visual)
		{
			Visual = visual;
		}

		public VisualBrush ()
		{
		}

		public VisualBrush Clone ()
		{
			throw new NotImplementedException ();
		}

		public VisualBrush CloneCurrentValue ()
		{
			throw new NotImplementedException ();
		}

		protected override Freezable CreateInstanceCore ()
		{
			throw new NotImplementedException ();
		}

		protected override void OnPropertyChanged (DependencyPropertyChangedEventArgs args)
		{
			base.OnPropertyChanged (args);
		}

		protected override void GetContentBounds (out Rect bounds)
		{
			throw new NotImplementedException ();
		}

		public static readonly DependencyProperty AutoLayoutContentProperty;
		public bool AutoLayoutContent {
		    get { return (bool)GetValue (AutoLayoutContentProperty); }
		    set { SetValue (AutoLayoutContentProperty, value); }
		}

		public static readonly DependencyProperty VisualProperty;
		public Visual Visual {
		    get { return (Visual)GetValue (VisualProperty); }
		    set { SetValue (VisualProperty, value); }
		}
		
	}

}
