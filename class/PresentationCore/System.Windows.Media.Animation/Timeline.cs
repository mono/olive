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
			throw new NotImplementedException ();
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
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}
		public bool AutoReverse {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}
		public Nullable<TimeSpan> BeginTime {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}
		public double DecelerationRatio {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}
		public Duration Duration {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}
		public FillBehavior FillBehavior {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}
		public string Name {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}
		public RepeatBehavior RepeatBehavior {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}
		public double SpeedRatio {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		public event EventHandler Completed;
		public event EventHandler CurrentGlobalSpeedInvalidated;
		public event EventHandler CurrentStateInvalidated;
		public event EventHandler CurrentTimeInvalidated;
		public event EventHandler RemoveRequested;
	}

}
