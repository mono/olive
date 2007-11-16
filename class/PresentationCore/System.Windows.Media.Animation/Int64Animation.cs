
/* this file is generated by gen-animation-types.cs.  do not modify */

using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Windows.Markup;

namespace System.Windows.Media.Animation {


public class Int64Animation : Int64AnimationBase
{
	public static readonly DependencyProperty ByProperty; /* XXX initialize */
	public static readonly DependencyProperty FromProperty; /* XXX initialize */
	public static readonly DependencyProperty ToProperty; /* XXX initialize */

	public Int64Animation ()
	{
	}

	public Int64Animation (long toValue, Duration duration)
	{
	}

	public Int64Animation (long toValue, Duration duration, FillBehavior fillBehavior)
	{
	}

	public Int64Animation (long fromValue, long toValue, Duration duration)
	{
	}

	public Int64Animation (long fromValue, long tovalue, Duration duration, FillBehavior fillBehavior)
	{
	}

	public long? By {
		get { return (long?) GetValue (ByProperty); }
		set { SetValue (ByProperty, value); }
	}

	public long? From {
		get { return (long?) GetValue (FromProperty); }
		set { SetValue (FromProperty, value); }
	}

	public long? To {
		get { return (long?) GetValue (ToProperty); }
		set { SetValue (ToProperty, value); }
	}

	public bool IsAdditive {
		get { return (bool) GetValue (AnimationTimeline.IsAdditiveProperty); }
		set { SetValue (AnimationTimeline.IsAdditiveProperty, value); }
	}

	public bool IsCumulative {
		get { return (bool) GetValue (AnimationTimeline.IsCumulativeProperty); }
		set { SetValue (AnimationTimeline.IsCumulativeProperty, value); }
	}

	public new Int64Animation Clone ()
	{
		throw new NotImplementedException ();
	}

	protected override Freezable CreateInstanceCore ()
	{
		throw new NotImplementedException ();
	}

	protected override long GetCurrentValueCore (long defaultOriginValue, long defaultDestinationValue, AnimationClock animationClock)
	{
		throw new NotImplementedException ();
	}
}


}