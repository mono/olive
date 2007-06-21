// Author:
//   Rolf Bjarne Kvinge  (RKvinge@novell.com)
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

using Mono;
using System;
using System.Windows;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace System.Windows.Controls
{
	public class InkPresenter : Canvas {
		
		public static readonly DependencyProperty StrokesProperty = 
			DependencyProperty.Lookup (Kind.INKPRESENTER, "Strokes", typeof (StrokeCollection)); 
		
		public InkPresenter() : base (NativeMethods.ink_presenter_new ()) 
		{
			NativeMethods.base_ref (native);
		}
	
		internal InkPresenter (IntPtr raw) : base (raw) 
		{
		}
		
		public StrokeCollection Strokes { 
			get {
				return (StrokeCollection) GetValue (StrokesProperty);
			}
			set {
				SetValue (StrokesProperty, value);
			}
		}

		internal override Kind GetKind ()
		{
			return Kind.INKPRESENTER;
		}
	}
}
