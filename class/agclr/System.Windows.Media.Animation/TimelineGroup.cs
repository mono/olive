//
// TimelineGroup.cs
//
// Author:
//   Miguel de Icaza (miguel@novell.com)
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
using System;
using System.Windows;
using System.Windows.Media;
using Mono;

namespace System.Windows.Media.Animation {

	public abstract class TimelineGroup : Timeline {

		internal TimelineGroup (IntPtr raw) :  base (raw)
		{
			// nothing
		}
		
		public TimelineGroup () : base (NativeMethods.timeline_group_new ())
		{
			NativeMethods.base_ref (native);
		}

		static TimelineGroup ()
		{
			// Documentation says Children's type is TimeLineCollection, while 
			// MS' bits says it's a Timeline. This looks too weird for it to be
			// true, so we're assuming the bits are wrong and the docs right
			// for a change.
			ChildrenProperty = DependencyProperty.Lookup (Kind.TIMELINEGROUP, "Children", typeof (TimelineCollection));
		}
	
		public TimelineCollection Children {
			get {
				return (TimelineCollection) GetValue (ChildrenProperty);
			}
		
			set {
				SetValue (ChildrenProperty, value);
			}
		}

		public static readonly DependencyProperty ChildrenProperty;
		
		protected internal override Kind GetKind ()
		{
			return Kind.TIMELINEGROUP;
		}
	}
}
