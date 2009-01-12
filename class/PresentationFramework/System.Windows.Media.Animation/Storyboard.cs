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

namespace System.Windows.Media.Animation {

	public class Storyboard : ParallelTimeline {
		public Storyboard ()
		{
		}


		public bool GetIsPaused ()
		{
			throw new NotImplementedException ();
		}

		public double GetCurrentGlobalSpeed ()
		{
			throw new NotImplementedException ();
		}

		public double GetCurrentProgress ()
		{
			throw new NotImplementedException ();
		}

		public int GetCurrentIteration ()
		{
			throw new NotImplementedException ();
		}

		public ClockState GetCurrentState ()
		{
			throw new NotImplementedException ();
		}

		public TimeSpan GetCurrentTime ()
		{
			throw new NotImplementedException ();
		}

		public void Begin ()
		{
			throw new NotImplementedException ();
		}

		public void Pause ()
		{
			throw new NotImplementedException ();
		}

		public void Remove ()
		{
			throw new NotImplementedException ();
		}

		public void Resume ()
		{
			throw new NotImplementedException ();
		}

		public void Seek (TimeSpan offset)
		{
			throw new NotImplementedException ();
		}

		public void Seek (TimeSpan offset, TimeSeekOrigin origin)
		{
			throw new NotImplementedException ();
		}


		public void SeekAlignedToLastTick (TimeSpan offset)
		{
			throw new NotImplementedException ();
		}

		public void SeekAlignedToLastTick (TimeSpan offset, TimeSeekOrigin origin)
		{
			throw new NotImplementedException ();
		}

		public void SetSpeedRatio (double speedRatio)
		{
			throw new NotImplementedException ();
		}

		public void SkipToFill ()
		{
			throw new NotImplementedException ();
		}

		public void Stop ()
		{
			throw new NotImplementedException ();
		}

		public void Begin (FrameworkContentElement containingObject)
		{
			throw new NotImplementedException ();
		}

		public void Begin (FrameworkContentElement containingObject,
				   bool isControllable)
		{
			throw new NotImplementedException ();
		}

		public void Begin (FrameworkContentElement containingObject,
				   HandoffBehavior handoffBehavior)
		{
			throw new NotImplementedException ();
		}

		public void Begin (FrameworkContentElement containingObject,
				   HandoffBehavior handoffBehavior,
				   bool isControllable)
		{
			throw new NotImplementedException ();
		}

		public Nullable<double> GetCurrentGlobalSpeed (FrameworkContentElement containingObject)
		{
			throw new NotImplementedException ();
		}

		public Nullable<int> GetCurrentIteration (FrameworkContentElement containingObject)
		{
			throw new NotImplementedException ();
		}

		public Nullable<double> GetCurrentProgress (FrameworkContentElement containingObject)
		{
			throw new NotImplementedException ();
		}

		public ClockState GetCurrentState (FrameworkContentElement containingObject)
		{
			throw new NotImplementedException ();
		}

		public Nullable<TimeSpan> GetCurrentTime (FrameworkContentElement containingObject)
		{
			throw new NotImplementedException ();
		}

		public bool GetIsPaused (FrameworkContentElement containingObject)
		{
			throw new NotImplementedException ();
		}

		public void Pause (FrameworkContentElement containingObject)
		{
			throw new NotImplementedException ();
		}

		public void Remove (FrameworkContentElement containingObject)
		{
			throw new NotImplementedException ();
		}

		public void Resume (FrameworkContentElement containingObject)
		{
			throw new NotImplementedException ();
		}

		public void Seek (FrameworkContentElement containingObject,
				  TimeSpan offset,
				  TimeSeekOrigin origin)
		{
			throw new NotImplementedException ();
		}

		public void SeekAlignedToLastTick (FrameworkContentElement containingObject,
						   TimeSpan offset,
						   TimeSeekOrigin origin)
		{
			throw new NotImplementedException ();
		}

		public void SetSpeedRatio (FrameworkContentElement containingObject,
					   double speedRatio)
		{
			throw new NotImplementedException ();
		}

		public void SkipToFill (FrameworkContentElement containingObject)
		{
			throw new NotImplementedException ();
		}

		public void Stop (FrameworkContentElement containingObject)
		{
			throw new NotImplementedException ();
		}

		public void Begin (FrameworkElement containingObject)
		{
			throw new NotImplementedException ();
		}

		public void Begin (FrameworkElement containingObject,
				   bool isControllable)
		{
			throw new NotImplementedException ();
		}

		public void Begin (FrameworkElement containingObject,
				   FrameworkTemplate frameworkTemplate)
		{
			throw new NotImplementedException ();
		}

		public void Begin (FrameworkElement containingObject,
				   HandoffBehavior handoffBehavior)
		{
			throw new NotImplementedException ();
		}

		public void Begin (FrameworkElement containingObject,
				   FrameworkTemplate frameworkTemplate,
				   bool isControllable)
		{
			throw new NotImplementedException ();
		}

		public void Begin (FrameworkElement containingObject,
				   FrameworkTemplate frameworkTemplate,
				   HandoffBehavior handoffBehavior)
		{
			throw new NotImplementedException ();
		}


		public void Begin (FrameworkElement containingObject,
				   HandoffBehavior handoffBehavior,
				   bool isControllable)
		{
			throw new NotImplementedException ();
		}

		public void Begin (FrameworkElement containingObject,
				   FrameworkTemplate frameworkTemplate,
				   HandoffBehavior handoffBehavior,
				   bool isControllable)
		{
			throw new NotImplementedException ();
		}

		public new Storyboard Clone ()
		{
			throw new NotImplementedException ();
		}

		protected override Freezable CreateInstanceCore ()
		{
			throw new NotImplementedException ();
		}

		public Nullable<double> GetCurrentGlobalSpeed (FrameworkElement containingObject)
		{
			throw new NotImplementedException ();
		}

		public Nullable<int> GetCurrentIteration (FrameworkElement containingObject)
		{
			throw new NotImplementedException ();
		}

		public Nullable<double> GetCurrentProgress (FrameworkElement containingObject)
		{
			throw new NotImplementedException ();
		}

		public ClockState GetCurrentState (FrameworkElement containingObject)
		{
			throw new NotImplementedException ();
		}

		public Nullable<TimeSpan> GetCurrentTime (FrameworkElement containingObject)
		{
			throw new NotImplementedException ();
		}

		public bool GetIsPaused (FrameworkElement containingObject)
		{
			throw new NotImplementedException ();
		}

#region Target Property
		public static readonly DependencyProperty TargetProperty;
		[DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)]
		public static DependencyObject GetTarget (DependencyObject obj)
		{
		    return (DependencyObject)obj.GetValue (TargetProperty);
		}
		
		public static void SetTarget (DependencyObject obj, DependencyObject value)
		{
			obj.SetValue (TargetProperty, value);
		}
#endregion

#region TargetName Property
		public static readonly DependencyProperty TargetNameProperty;
		public static string GetTargetName (DependencyObject obj)
		{
		    return (string)obj.GetValue (TargetNameProperty);
		}
		
		public static void SetTargetName (DependencyObject obj, string value)
		{
			obj.SetValue (TargetNameProperty, value);
		}
#endregion

#region TargetProperty Property
		public static readonly DependencyProperty TargetPropertyProperty;
		public static PropertyPath GetTargetProperty (DependencyObject obj)
		{
		    return (PropertyPath)obj.GetValue (TargetPropertyProperty);
		}
		
		public static void SetTargetProperty (DependencyObject obj, PropertyPath value)
		{
			obj.SetValue (TargetPropertyProperty, value);
		}
#endregion
		
		public void Pause (FrameworkElement containingObject)
		{
			throw new NotImplementedException ();
		}

		public void Remove (FrameworkElement containingObject)
		{
			throw new NotImplementedException ();
		}

		public void Resume (FrameworkElement containingObject)
		{
			throw new NotImplementedException ();
		}

		public void Seek (FrameworkElement containingObject,
				  TimeSpan offset,
				  TimeSeekOrigin origin)
		{
			throw new NotImplementedException ();
		}

		public void SeekAlignedToLastTick (FrameworkElement containingObject,
						   TimeSpan offset,
						   TimeSeekOrigin origin)
		{
			throw new NotImplementedException ();
		}

		public void SetSpeedRatio (FrameworkElement containingObject,
					   double speedRatio)
		{
			throw new NotImplementedException ();
		}

		public void SkipToFill (FrameworkElement containingObject)
		{
			throw new NotImplementedException ();
		}

		public void Stop (FrameworkElement containingObject)
		{
			throw new NotImplementedException ();
		}
	}

}
