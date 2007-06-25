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

using System.Windows;

namespace System.Windows.Media.Animation {

	public abstract class AnimationTimeline : Timeline {
		public static readonly DependencyProperty IsAdditiveProperty;
		public static readonly DependencyProperty IsCumulativeProperty;

		protected internal override Clock AllocateClock ()
		{
			throw new NotImplementedException ();
		}

		public new AnimationTimeline Clone ()
		{
			throw new NotImplementedException ();
		}

		public new AnimationClock CreateClock ()
		{
			throw new NotImplementedException ();
		}

		public virtual Object GetCurrentValue (object defaultOriginValue,
						       object defaultDestinationValue,
						       AnimationClock animationClock)
		{
			return animationClock.GetCurrentValue (defaultOriginValue, defaultDestinationValue);
		}

		protected override Duration GetNaturalDurationCore (Clock clock)
		{
			throw new NotImplementedException ();
		}


		public virtual bool IsDestinationDefault {
			get { throw new NotImplementedException (); }
		}
		public abstract Type TargetPropertyType { get; }
	}

}
	
