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

using System.ComponentModel;
using System.Windows;
using System.Windows.Markup;

namespace System.Windows.Media.Animation {

	public class TimelineGroup : Timeline, IAddChild {
		protected TimelineGroup (TimeSpan? beginTime)
			: base (beginTime)
		{
		}

		protected TimelineGroup (TimeSpan? beginTime, Duration duration)
			: base (beginTime, duration)
		{
		}

		protected TimelineGroup (TimeSpan? beginTime, Duration duration, RepeatBehavior repeatBehavior)
			: base (beginTime, duration, repeatBehavior)
		{
		}

		protected TimelineGroup ()
		{
		}

		protected override Freezable CreateInstanceCore ()
		{
			return new TimelineGroup ();
		}

		public new TimelineGroup CloneCurrentValue ()
		{
			throw new NotImplementedException ();
		}

		public new TimelineGroup Clone ()
		{
			return new TimelineGroup ();
		}

		protected internal override Clock AllocateClock ()
		{
			throw new NotImplementedException ();
		}

		public new ClockGroup CreateClock ()
		{
			throw new NotImplementedException ();
		}

		void IAddChild.AddChild (object child)
		{
			AddChild (child);
		}

		void IAddChild.AddText (string text)
		{
			AddText (text);
		}

		[EditorBrowsable (EditorBrowsableState.Never)]
		protected virtual void AddChild (object child)
		{
			throw new NotImplementedException ();
		}

		[EditorBrowsable (EditorBrowsableState.Never)]
		protected virtual void AddText (string text)
		{
			throw new NotImplementedException ();
		}

		public static readonly DependencyProperty ChildrenProperty;
		public TimelineCollection Children {
		    get { return (TimelineCollection)GetValue (ChildrenProperty); }
		    set { SetValue (ChildrenProperty, value); }
		}
	}
}