
/* this file is generated by gen-animation-types.cs.  do not modify */

using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Windows.Markup;

namespace System.Windows.Media.Animation {


public abstract class ColorAnimationBase : AnimationTimeline
{
	protected ColorAnimationBase () { }

	public override sealed Type TargetPropertyType { get { return typeof (Color); } }

	public new ColorAnimationBase Clone ()
	{
		throw new NotImplementedException ();
	} 

	public override sealed object GetCurrentValue (object defaultOriginValue, object defaultDestinationValue, AnimationClock animationClock)
	{
		return GetCurrentValue ((Color)defaultOriginValue, (Color) defaultDestinationValue, animationClock);
	}

	protected abstract Color GetCurrentValueCore (Color defaultOriginValue, Color defaultDestinationValue, AnimationClock animationClock);


	public Color GetCurrentValue (Color defaultOriginValue, Color defaultDestinationValue, AnimationClock animationClock)
	{
		throw new NotImplementedException ();
	}


}


}
