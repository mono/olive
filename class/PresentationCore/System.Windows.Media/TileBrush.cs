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

	public abstract class TileBrush : Brush {
		protected TileBrush ()
		{
		}

		public TileBrush Clone ()
		{
			throw new NotImplementedException ();
		}

		public TileBrush CloneCurrentValue ()
		{
			throw new NotImplementedException ();
		}

		protected abstract void GetContentBounds (out Rect bounds);

		public static readonly DependencyProperty ViewportUnitsProperty;
		public BrushMappingMode ViewportUnits {
		    get { return (BrushMappingMode)GetValue (ViewportUnitsProperty); }
		    set { SetValue (ViewportUnitsProperty, value); }
		}

		public static readonly DependencyProperty TileModeProperty;
		public TileMode TileMode {
		    get { return (TileMode)GetValue (TileModeProperty); }
		    set { SetValue (TileModeProperty, value); }
		}

		public static readonly DependencyProperty AlignmentYProperty;
		public AlignmentY AlignmentY {
		    get { return (AlignmentY)GetValue (AlignmentYProperty); }
		    set { SetValue (AlignmentYProperty, value); }
		}

		public static readonly DependencyProperty AlignmentXProperty;
		public AlignmentX AlignmentX {
		    get { return (AlignmentX)GetValue (AlignmentXProperty); }
		    set { SetValue (AlignmentXProperty, value); }
		}

		public static readonly DependencyProperty StretchProperty;
		public Stretch Stretch {
		    get { return (Stretch)GetValue (StretchProperty); }
		    set { SetValue (StretchProperty, value); }
		}

		public static readonly DependencyProperty ViewboxProperty;
		public Rect Viewbox {
		    get { return (Rect)GetValue (ViewboxProperty); }
		    set { SetValue (ViewboxProperty, value); }
		}

		public static readonly DependencyProperty ViewportProperty;
		public Rect Viewport {
		    get { return (Rect)GetValue (ViewportProperty); }
		    set { SetValue (ViewportProperty, value); }
		}

		public static readonly DependencyProperty ViewboxUnitsProperty;
		public BrushMappingMode ViewboxUnits {
		    get { return (BrushMappingMode)GetValue (ViewboxUnitsProperty); }
		    set { SetValue (ViewboxUnitsProperty, value); }
		}
		
	}

}
