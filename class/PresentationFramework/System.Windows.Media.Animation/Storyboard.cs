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

namespace System.Windows.Media.Animation {

	public class Storyboard : ParallelTimeline {
		public static readonly DependencyProperty TargetNameProperty;
		public static readonly DependencyProperty TargetPropertyProperty;

		public Storyboard ()
		{
		}


		public void Begin (FrameworkContentElement containingObject)
		{
		}

		public void Begin (FrameworkContentElement containingObject,
				   bool isControllable)
		{
		}

		public void Begin (FrameworkContentElement containingObject,
				   HandoffBehavior handoffBehavior)
		{
		}

		public void Begin (FrameworkElement containingObject,
				   bool isControllable)
		{
		}

		public void Begin (FrameworkElement containingObject,
				   FrameworkTemplate frameworkTemplate)
		{
		}

		public void Begin (FrameworkElement containingObject,
				   HandoffBehavior handoffBehavior)
		{
		}

		public void Begin (FrameworkContentElement containingObject,
				   HandoffBehavior handoffBehavior,
				   bool isControllable)
		{
		}

		public void Begin (FrameworkElement containingObject,
				   FrameworkTemplate frameworkTemplate,
				   bool isControllable)
		{
		}

		public void Begin (FrameworkElement containingObject,
				   FrameworkTemplate frameworkTemplate,
				   HandoffBehavior handoffBehavior)
		{
		}


		public void Begin (FrameworkElement containingObject,
				   HandoffBehavior handoffBehavior,
				   bool isControllable)
		{
		}

		public void Begin (FrameworkElement containingObject,
				   FrameworkTemplate frameworkTemplate,
				   HandoffBehavior handoffBehavior,
				   bool isControllable)
		{
		}

		public Storyboard Clone ()
		{
		}

		protected override Freezable CreateInstanceCore ()
		{
		}

		public Nullable<double> GetCurrentGlobalSpeed (FrameworkContentElement containingObject)
		{
		}

		public Nullable<double> GetCurrentGlobalSpeed (FrameworkElement containingObject)
		{
		}

		public Nullable<int> GetCurrentIteration (FrameworkContentElement containingObject)
		{
		}

		public Nullable<int> GetCurrentIteration (FrameworkElement containingObject)
		{
		}

		public Nullable<double> GetCurrentProgress (FrameworkContentElement containingObject)
		{
		}

		public Nullable<double> GetCurrentProgress (FrameworkContentElement containingObject)
		{
		}

		public ClockState GetCurrentState (FrameworkContentElement containingObject)
		{
		}

		public ClockState GetCurrentState (FrameworkElement containingObject)
		{
		}

		public Nullable<TimeSpan> GetCurrentTime (FrameworkContentElement containingObject)
		{
		}

		public Nullable<TimeSpan> GetCurrentTime (FrameworkElement containingObject)
		{
		}

		public bool GetIsPaused (FrameworkContentElement containingObject)
		{
		}

		public bool GetIsPaused (FrameworkElement containingObject)
		{
		}

		public static string GetTargetName (DependencyObject element)
		{
		}

		public static PropertyPath GetTargetProperty (DependencyObject element)
		{
		}

		public void Pause (FrameworkContentElement containingObject)
		{
		}

		public void Pause (FrameworkElement containingObject)
		{
		}

		public void Remove (FrameworkContentElement containingObject)
		{
		}

		public void Remove (FrameworkElement containingObject)
		{
		}

		public void Resume (FrameworkContentElement containingObject)
		{
		}

		public void Resume (FrameworkElement containingObject)
		{
		}

		public void Seek (FrameworkContentElement containingObject,
				  TimeSpan offset,
				  TimeSeekOrigin origin)
		{
		}

		public void Seek (FrameworkElement containingObject,
				  TimeSpan offset,
				  TimeSeekOrigin origin)
		{
		}

		public void SeekAlignedToLastTick (FrameworkContentElement containingObject,
						   TimeSpan offset,
						   TimeSeekOrigin origin)
		{
		}

		public void SeekAlignedToLastTick (FrameworkElement containingObject,
						   TimeSpan offset,
						   TimeSeekOrigin origin)
		{
		}


		public void SetSpeedRatio (FrameworkContentElement containingObject,
					   double speedRatio)
		{
		}

		public void SetSpeedRatio (FrameworkElement containingObject,
					   double speedRatio)
		{
		}

		public static void SetTargetName (DependencyObject element,
						  string name)
		{
		}

		public static void SetTargetProperty (DependencyObject element,
						      PropertyPath path)
		{
		}

		public void SkipToFill (FrameworkContentElement containingObject)
		{
		}

		public void SkipToFill (FrameworkElement containingObject)
		{
		}

		public void Stop (FrameworkContentElement containingObject)
		{
		}

		public void Stop (FrameworkElement containingObject)
		{
		}
	}

}
