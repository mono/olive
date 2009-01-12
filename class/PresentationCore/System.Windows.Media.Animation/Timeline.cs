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

using System.ComponentModel;
using System.Windows;

namespace System.Windows.Media.Animation {

	//[RuntimeNamePropertyAttribute("Name")] 
	//[LocalizabilityAttribute(LocalizationCategory.None, Readability=Readability.Unreadable)] 
	public abstract class Timeline : Animatable
	{
		public static readonly DependencyProperty AccelerationRatioProperty;
		public static readonly DependencyProperty AutoReverseProperty;
		public static readonly DependencyProperty BeginTimeProperty;
		public static readonly DependencyProperty DecelerationRatioProperty;
		public static readonly DependencyProperty DesiredFrameRateProperty;
		public static readonly DependencyProperty DurationProperty;
		public static readonly DependencyProperty FillBehaviorProperty;
		public static readonly DependencyProperty NameProperty;
		public static readonly DependencyProperty RepeatBehaviorProperty;
		public static readonly DependencyProperty SpeedRatioProperty;

		protected Timeline ()
		{
		}

		protected Timeline (Nullable<TimeSpan> beginTime)
		{
			throw new NotImplementedException ();
		}

		protected Timeline (Nullable<TimeSpan> beginTime,
				    Duration duration)
		{
			throw new NotImplementedException ();
		}

		protected Timeline (Nullable<TimeSpan> beginTime,
				    Duration duration,
				    RepeatBehavior repeatBehavior)
		{
			throw new NotImplementedException ();
		}

		protected internal virtual Clock AllocateClock ()
		{
			throw new NotImplementedException ();
		}

		public new Timeline Clone ()
		{
			throw new NotImplementedException ();
		}

		public new Timeline CloneCurrentValue ()
		{
			throw new NotImplementedException ();
		}

		public Clock CreateClock ()
		{
			throw new NotImplementedException ();
		}

		public Clock CreateClock (bool hasControllableRoot)
		{
			throw new NotImplementedException ();
		}

		protected override bool FreezeCore (bool isChecking)
		{
			throw new NotImplementedException ();
		}

		protected override void GetAsFrozenCore (Freezable sourceFreezable)
		{
			throw new NotImplementedException ();
		}

		protected override void GetCurrentValueAsFrozenCore (Freezable sourceFreezable)
		{
			throw new NotImplementedException ();
		}

		public static Nullable<int> GetDesiredFrameRate (Timeline timeline)
		{
			throw new NotImplementedException ();
		}

		protected internal Duration GetNaturalDuration (Clock clock)
		{
			throw new NotImplementedException ();
		}

		protected virtual Duration GetNaturalDurationCore (Clock clock)
		{
			throw new NotImplementedException ();
		}

		public static void SetDesiredFrameRate (Timeline timeline,
							Nullable<int> desiredFrameRate)
		{
			throw new NotImplementedException ();
		}

		public double AccelerationRatio {
			get { return (double)GetValue (AccelerationRatioProperty); }
			set { SetValue (AccelerationRatioProperty, value); }
		}

		[DefaultValue(false)]
		public bool AutoReverse {
			get { return (bool)GetValue (AutoReverseProperty); }
			set { SetValue (AutoReverseProperty, value); }
		}
		public Nullable<TimeSpan> BeginTime {
			get { return (Nullable<TimeSpan>)GetValue (BeginTimeProperty); }
			set { SetValue (BeginTimeProperty, value); }
		}
		public double DecelerationRatio {
			get { return (double)GetValue (DecelerationRatioProperty); }
			set { SetValue (DecelerationRatioProperty, value); }
		}
		public Duration Duration {
			get { return (Duration)GetValue (DurationProperty); }
			set { SetValue (DurationProperty, value); }
		}
		public FillBehavior FillBehavior {
			get { return (FillBehavior)GetValue (FillBehaviorProperty); }
			set { SetValue (FillBehaviorProperty, value); }
		}

		[DefaultValue (null)]
		[MergableProperty (false)]
		public string Name {
			get { return (string)GetValue (NameProperty); }
			set { SetValue (NameProperty, value); }
		}
		public RepeatBehavior RepeatBehavior {
			get { return (RepeatBehavior)GetValue (RepeatBehaviorProperty); }
			set { SetValue (RepeatBehaviorProperty, value); }
		}

		[DefaultValue (1.0)]
		public double SpeedRatio {
			get { return (double)GetValue (SpeedRatioProperty); }
			set { SetValue (SpeedRatioProperty, value); }
		}

		public event EventHandler Completed;
		public event EventHandler CurrentGlobalSpeedInvalidated;
		public event EventHandler CurrentStateInvalidated;
		public event EventHandler CurrentTimeInvalidated;
		public event EventHandler RemoveRequested;
	}

}
