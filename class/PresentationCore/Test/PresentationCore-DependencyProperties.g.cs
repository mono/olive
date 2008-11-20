using NUnit.Framework;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
#if notyet
using System.Windows.Media.Media3D;
#endif

// Assembly: PresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
//   Type: System.Windows.Media.Animation.AnimationTimeline
namespace MonoTests.System.Windows.Media.Animation {
	public partial class AnimationTimelineTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (AnimationTimeline), AnimationTimeline.IsAdditiveProperty.OwnerType);
			Assert.AreEqual ("IsAdditive", AnimationTimeline.IsAdditiveProperty.Name);
			Assert.AreEqual ("IsAdditive", AnimationTimeline.IsAdditiveProperty.ToString());
			Assert.AreEqual (typeof (bool), AnimationTimeline.IsAdditiveProperty.PropertyType);
			Assert.IsFalse (AnimationTimeline.IsAdditiveProperty.ReadOnly);

			Assert.AreEqual (typeof (AnimationTimeline), AnimationTimeline.IsCumulativeProperty.OwnerType);
			Assert.AreEqual ("IsCumulative", AnimationTimeline.IsCumulativeProperty.Name);
			Assert.AreEqual ("IsCumulative", AnimationTimeline.IsCumulativeProperty.ToString());
			Assert.AreEqual (typeof (bool), AnimationTimeline.IsCumulativeProperty.PropertyType);
			Assert.IsFalse (AnimationTimeline.IsCumulativeProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.ArcSegment
namespace MonoTests.System.Windows.Media {
	public partial class ArcSegmentTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (ArcSegment), ArcSegment.PointProperty.OwnerType);
			Assert.AreEqual ("Point", ArcSegment.PointProperty.Name);
			Assert.AreEqual ("Point", ArcSegment.PointProperty.ToString());
			Assert.AreEqual (typeof (Point), ArcSegment.PointProperty.PropertyType);
			Assert.IsFalse (ArcSegment.PointProperty.ReadOnly);

			Assert.AreEqual (typeof (ArcSegment), ArcSegment.SizeProperty.OwnerType);
			Assert.AreEqual ("Size", ArcSegment.SizeProperty.Name);
			Assert.AreEqual ("Size", ArcSegment.SizeProperty.ToString());
			Assert.AreEqual (typeof (Size), ArcSegment.SizeProperty.PropertyType);
			Assert.IsFalse (ArcSegment.SizeProperty.ReadOnly);

			Assert.AreEqual (typeof (ArcSegment), ArcSegment.RotationAngleProperty.OwnerType);
			Assert.AreEqual ("RotationAngle", ArcSegment.RotationAngleProperty.Name);
			Assert.AreEqual ("RotationAngle", ArcSegment.RotationAngleProperty.ToString());
			Assert.AreEqual (typeof (double), ArcSegment.RotationAngleProperty.PropertyType);
			Assert.IsFalse (ArcSegment.RotationAngleProperty.ReadOnly);

			Assert.AreEqual (typeof (ArcSegment), ArcSegment.IsLargeArcProperty.OwnerType);
			Assert.AreEqual ("IsLargeArc", ArcSegment.IsLargeArcProperty.Name);
			Assert.AreEqual ("IsLargeArc", ArcSegment.IsLargeArcProperty.ToString());
			Assert.AreEqual (typeof (bool), ArcSegment.IsLargeArcProperty.PropertyType);
			Assert.IsFalse (ArcSegment.IsLargeArcProperty.ReadOnly);

			Assert.AreEqual (typeof (ArcSegment), ArcSegment.SweepDirectionProperty.OwnerType);
			Assert.AreEqual ("SweepDirection", ArcSegment.SweepDirectionProperty.Name);
			Assert.AreEqual ("SweepDirection", ArcSegment.SweepDirectionProperty.ToString());
			Assert.AreEqual (typeof (SweepDirection), ArcSegment.SweepDirectionProperty.PropertyType);
			Assert.IsFalse (ArcSegment.SweepDirectionProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Automation.AutomationProperties
namespace MonoTests.System.Windows.Automation {
	public partial class AutomationPropertiesTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (AutomationProperties), AutomationProperties.AutomationIdProperty.OwnerType);
			Assert.AreEqual ("AutomationId", AutomationProperties.AutomationIdProperty.Name);
			Assert.AreEqual ("AutomationId", AutomationProperties.AutomationIdProperty.ToString());
			Assert.AreEqual (typeof (string), AutomationProperties.AutomationIdProperty.PropertyType);
			Assert.IsFalse (AutomationProperties.AutomationIdProperty.ReadOnly);

			Assert.AreEqual (typeof (AutomationProperties), AutomationProperties.NameProperty.OwnerType);
			Assert.AreEqual ("Name", AutomationProperties.NameProperty.Name);
			Assert.AreEqual ("Name", AutomationProperties.NameProperty.ToString());
			Assert.AreEqual (typeof (string), AutomationProperties.NameProperty.PropertyType);
			Assert.IsFalse (AutomationProperties.NameProperty.ReadOnly);

			Assert.AreEqual (typeof (AutomationProperties), AutomationProperties.HelpTextProperty.OwnerType);
			Assert.AreEqual ("HelpText", AutomationProperties.HelpTextProperty.Name);
			Assert.AreEqual ("HelpText", AutomationProperties.HelpTextProperty.ToString());
			Assert.AreEqual (typeof (string), AutomationProperties.HelpTextProperty.PropertyType);
			Assert.IsFalse (AutomationProperties.HelpTextProperty.ReadOnly);

			Assert.AreEqual (typeof (AutomationProperties), AutomationProperties.AcceleratorKeyProperty.OwnerType);
			Assert.AreEqual ("AcceleratorKey", AutomationProperties.AcceleratorKeyProperty.Name);
			Assert.AreEqual ("AcceleratorKey", AutomationProperties.AcceleratorKeyProperty.ToString());
			Assert.AreEqual (typeof (string), AutomationProperties.AcceleratorKeyProperty.PropertyType);
			Assert.IsFalse (AutomationProperties.AcceleratorKeyProperty.ReadOnly);

			Assert.AreEqual (typeof (AutomationProperties), AutomationProperties.AccessKeyProperty.OwnerType);
			Assert.AreEqual ("AccessKey", AutomationProperties.AccessKeyProperty.Name);
			Assert.AreEqual ("AccessKey", AutomationProperties.AccessKeyProperty.ToString());
			Assert.AreEqual (typeof (string), AutomationProperties.AccessKeyProperty.PropertyType);
			Assert.IsFalse (AutomationProperties.AccessKeyProperty.ReadOnly);

			Assert.AreEqual (typeof (AutomationProperties), AutomationProperties.ItemStatusProperty.OwnerType);
			Assert.AreEqual ("ItemStatus", AutomationProperties.ItemStatusProperty.Name);
			Assert.AreEqual ("ItemStatus", AutomationProperties.ItemStatusProperty.ToString());
			Assert.AreEqual (typeof (string), AutomationProperties.ItemStatusProperty.PropertyType);
			Assert.IsFalse (AutomationProperties.ItemStatusProperty.ReadOnly);

			Assert.AreEqual (typeof (AutomationProperties), AutomationProperties.ItemTypeProperty.OwnerType);
			Assert.AreEqual ("ItemType", AutomationProperties.ItemTypeProperty.Name);
			Assert.AreEqual ("ItemType", AutomationProperties.ItemTypeProperty.ToString());
			Assert.AreEqual (typeof (string), AutomationProperties.ItemTypeProperty.PropertyType);
			Assert.IsFalse (AutomationProperties.ItemTypeProperty.ReadOnly);

			Assert.AreEqual (typeof (AutomationProperties), AutomationProperties.IsColumnHeaderProperty.OwnerType);
			Assert.AreEqual ("IsColumnHeader", AutomationProperties.IsColumnHeaderProperty.Name);
			Assert.AreEqual ("IsColumnHeader", AutomationProperties.IsColumnHeaderProperty.ToString());
			Assert.AreEqual (typeof (bool), AutomationProperties.IsColumnHeaderProperty.PropertyType);
			Assert.IsFalse (AutomationProperties.IsColumnHeaderProperty.ReadOnly);

			Assert.AreEqual (typeof (AutomationProperties), AutomationProperties.IsRowHeaderProperty.OwnerType);
			Assert.AreEqual ("IsRowHeader", AutomationProperties.IsRowHeaderProperty.Name);
			Assert.AreEqual ("IsRowHeader", AutomationProperties.IsRowHeaderProperty.ToString());
			Assert.AreEqual (typeof (bool), AutomationProperties.IsRowHeaderProperty.PropertyType);
			Assert.IsFalse (AutomationProperties.IsRowHeaderProperty.ReadOnly);

			Assert.AreEqual (typeof (AutomationProperties), AutomationProperties.IsRequiredForFormProperty.OwnerType);
			Assert.AreEqual ("IsRequiredForForm", AutomationProperties.IsRequiredForFormProperty.Name);
			Assert.AreEqual ("IsRequiredForForm", AutomationProperties.IsRequiredForFormProperty.ToString());
			Assert.AreEqual (typeof (bool), AutomationProperties.IsRequiredForFormProperty.PropertyType);
			Assert.IsFalse (AutomationProperties.IsRequiredForFormProperty.ReadOnly);

			Assert.AreEqual (typeof (AutomationProperties), AutomationProperties.LabeledByProperty.OwnerType);
			Assert.AreEqual ("LabeledBy", AutomationProperties.LabeledByProperty.Name);
			Assert.AreEqual ("LabeledBy", AutomationProperties.LabeledByProperty.ToString());
			Assert.AreEqual (typeof (UIElement), AutomationProperties.LabeledByProperty.PropertyType);
			Assert.IsFalse (AutomationProperties.LabeledByProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Media3D.AxisAngleRotation3D
namespace MonoTests.System.Windows.Media.Media3D {
	public partial class AxisAngleRotation3DTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (AxisAngleRotation3D), AxisAngleRotation3D.AxisProperty.OwnerType);
			Assert.AreEqual ("Axis", AxisAngleRotation3D.AxisProperty.Name);
			Assert.AreEqual ("Axis", AxisAngleRotation3D.AxisProperty.ToString());
			Assert.AreEqual (typeof (Vector3D), AxisAngleRotation3D.AxisProperty.PropertyType);
			Assert.IsFalse (AxisAngleRotation3D.AxisProperty.ReadOnly);

			Assert.AreEqual (typeof (AxisAngleRotation3D), AxisAngleRotation3D.AngleProperty.OwnerType);
			Assert.AreEqual ("Angle", AxisAngleRotation3D.AngleProperty.Name);
			Assert.AreEqual ("Angle", AxisAngleRotation3D.AngleProperty.ToString());
			Assert.AreEqual (typeof (double), AxisAngleRotation3D.AngleProperty.PropertyType);
			Assert.IsFalse (AxisAngleRotation3D.AngleProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Navigation.BaseUriHelper
namespace MonoTests.System.Windows.Navigation {
	public partial class BaseUriHelperTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (BaseUriHelper), BaseUriHelper.BaseUriProperty.OwnerType);
			Assert.AreEqual ("BaseUri", BaseUriHelper.BaseUriProperty.Name);
			Assert.AreEqual ("BaseUri", BaseUriHelper.BaseUriProperty.ToString());
			Assert.AreEqual (typeof (System.Uri), BaseUriHelper.BaseUriProperty.PropertyType);
			Assert.IsFalse (BaseUriHelper.BaseUriProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Effects.BevelBitmapEffect
namespace MonoTests.System.Windows.Media.Effects {
	public partial class BevelBitmapEffectTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (BevelBitmapEffect), BevelBitmapEffect.BevelWidthProperty.OwnerType);
			Assert.AreEqual ("BevelWidth", BevelBitmapEffect.BevelWidthProperty.Name);
			Assert.AreEqual ("BevelWidth", BevelBitmapEffect.BevelWidthProperty.ToString());
			Assert.AreEqual (typeof (double), BevelBitmapEffect.BevelWidthProperty.PropertyType);
			Assert.IsFalse (BevelBitmapEffect.BevelWidthProperty.ReadOnly);

			Assert.AreEqual (typeof (BevelBitmapEffect), BevelBitmapEffect.ReliefProperty.OwnerType);
			Assert.AreEqual ("Relief", BevelBitmapEffect.ReliefProperty.Name);
			Assert.AreEqual ("Relief", BevelBitmapEffect.ReliefProperty.ToString());
			Assert.AreEqual (typeof (double), BevelBitmapEffect.ReliefProperty.PropertyType);
			Assert.IsFalse (BevelBitmapEffect.ReliefProperty.ReadOnly);

			Assert.AreEqual (typeof (BevelBitmapEffect), BevelBitmapEffect.LightAngleProperty.OwnerType);
			Assert.AreEqual ("LightAngle", BevelBitmapEffect.LightAngleProperty.Name);
			Assert.AreEqual ("LightAngle", BevelBitmapEffect.LightAngleProperty.ToString());
			Assert.AreEqual (typeof (double), BevelBitmapEffect.LightAngleProperty.PropertyType);
			Assert.IsFalse (BevelBitmapEffect.LightAngleProperty.ReadOnly);

			Assert.AreEqual (typeof (BevelBitmapEffect), BevelBitmapEffect.SmoothnessProperty.OwnerType);
			Assert.AreEqual ("Smoothness", BevelBitmapEffect.SmoothnessProperty.Name);
			Assert.AreEqual ("Smoothness", BevelBitmapEffect.SmoothnessProperty.ToString());
			Assert.AreEqual (typeof (double), BevelBitmapEffect.SmoothnessProperty.PropertyType);
			Assert.IsFalse (BevelBitmapEffect.SmoothnessProperty.ReadOnly);

			Assert.AreEqual (typeof (BevelBitmapEffect), BevelBitmapEffect.EdgeProfileProperty.OwnerType);
			Assert.AreEqual ("EdgeProfile", BevelBitmapEffect.EdgeProfileProperty.Name);
			Assert.AreEqual ("EdgeProfile", BevelBitmapEffect.EdgeProfileProperty.ToString());
			Assert.AreEqual (typeof (EdgeProfile), BevelBitmapEffect.EdgeProfileProperty.PropertyType);
			Assert.IsFalse (BevelBitmapEffect.EdgeProfileProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.BezierSegment
namespace MonoTests.System.Windows.Media {
	public partial class BezierSegmentTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (BezierSegment), BezierSegment.Point1Property.OwnerType);
			Assert.AreEqual ("Point1", BezierSegment.Point1Property.Name);
			Assert.AreEqual ("Point1", BezierSegment.Point1Property.ToString());
			Assert.AreEqual (typeof (Point), BezierSegment.Point1Property.PropertyType);
			Assert.IsFalse (BezierSegment.Point1Property.ReadOnly);

			Assert.AreEqual (typeof (BezierSegment), BezierSegment.Point2Property.OwnerType);
			Assert.AreEqual ("Point2", BezierSegment.Point2Property.Name);
			Assert.AreEqual ("Point2", BezierSegment.Point2Property.ToString());
			Assert.AreEqual (typeof (Point), BezierSegment.Point2Property.PropertyType);
			Assert.IsFalse (BezierSegment.Point2Property.ReadOnly);

			Assert.AreEqual (typeof (BezierSegment), BezierSegment.Point3Property.OwnerType);
			Assert.AreEqual ("Point3", BezierSegment.Point3Property.Name);
			Assert.AreEqual ("Point3", BezierSegment.Point3Property.ToString());
			Assert.AreEqual (typeof (Point), BezierSegment.Point3Property.PropertyType);
			Assert.IsFalse (BezierSegment.Point3Property.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Effects.BitmapEffectGroup
namespace MonoTests.System.Windows.Media.Effects {
	public partial class BitmapEffectGroupTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (BitmapEffectGroup), BitmapEffectGroup.ChildrenProperty.OwnerType);
			Assert.AreEqual ("Children", BitmapEffectGroup.ChildrenProperty.Name);
			Assert.AreEqual ("Children", BitmapEffectGroup.ChildrenProperty.ToString());
			Assert.AreEqual (typeof (BitmapEffectCollection), BitmapEffectGroup.ChildrenProperty.PropertyType);
			Assert.IsFalse (BitmapEffectGroup.ChildrenProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Effects.BitmapEffectInput
namespace MonoTests.System.Windows.Media.Effects {
	public partial class BitmapEffectInputTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (BitmapEffectInput), BitmapEffectInput.InputProperty.OwnerType);
			Assert.AreEqual ("Input", BitmapEffectInput.InputProperty.Name);
			Assert.AreEqual ("Input", BitmapEffectInput.InputProperty.ToString());
			Assert.AreEqual (typeof (BitmapSource), BitmapEffectInput.InputProperty.PropertyType);
			Assert.IsFalse (BitmapEffectInput.InputProperty.ReadOnly);

			Assert.AreEqual (typeof (BitmapEffectInput), BitmapEffectInput.AreaToApplyEffectUnitsProperty.OwnerType);
			Assert.AreEqual ("AreaToApplyEffectUnits", BitmapEffectInput.AreaToApplyEffectUnitsProperty.Name);
			Assert.AreEqual ("AreaToApplyEffectUnits", BitmapEffectInput.AreaToApplyEffectUnitsProperty.ToString());
			Assert.AreEqual (typeof (BrushMappingMode), BitmapEffectInput.AreaToApplyEffectUnitsProperty.PropertyType);
			Assert.IsFalse (BitmapEffectInput.AreaToApplyEffectUnitsProperty.ReadOnly);

			Assert.AreEqual (typeof (BitmapEffectInput), BitmapEffectInput.AreaToApplyEffectProperty.OwnerType);
			Assert.AreEqual ("AreaToApplyEffect", BitmapEffectInput.AreaToApplyEffectProperty.Name);
			Assert.AreEqual ("AreaToApplyEffect", BitmapEffectInput.AreaToApplyEffectProperty.ToString());
			Assert.AreEqual (typeof (Rect), BitmapEffectInput.AreaToApplyEffectProperty.PropertyType);
			Assert.IsFalse (BitmapEffectInput.AreaToApplyEffectProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Imaging.BitmapImage
namespace MonoTests.System.Windows.Media.Imaging {
	public partial class BitmapImageTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (BitmapImage), BitmapImage.UriCachePolicyProperty.OwnerType);
			Assert.AreEqual ("UriCachePolicy", BitmapImage.UriCachePolicyProperty.Name);
			Assert.AreEqual ("UriCachePolicy", BitmapImage.UriCachePolicyProperty.ToString());
			Assert.AreEqual (typeof (System.Net.Cache.RequestCachePolicy), BitmapImage.UriCachePolicyProperty.PropertyType);
			Assert.IsFalse (BitmapImage.UriCachePolicyProperty.ReadOnly);

			Assert.AreEqual (typeof (BitmapImage), BitmapImage.UriSourceProperty.OwnerType);
			Assert.AreEqual ("UriSource", BitmapImage.UriSourceProperty.Name);
			Assert.AreEqual ("UriSource", BitmapImage.UriSourceProperty.ToString());
			Assert.AreEqual (typeof (System.Uri), BitmapImage.UriSourceProperty.PropertyType);
			Assert.IsFalse (BitmapImage.UriSourceProperty.ReadOnly);

			Assert.AreEqual (typeof (BitmapImage), BitmapImage.StreamSourceProperty.OwnerType);
			Assert.AreEqual ("StreamSource", BitmapImage.StreamSourceProperty.Name);
			Assert.AreEqual ("StreamSource", BitmapImage.StreamSourceProperty.ToString());
			Assert.AreEqual (typeof (System.IO.Stream), BitmapImage.StreamSourceProperty.PropertyType);
			Assert.IsFalse (BitmapImage.StreamSourceProperty.ReadOnly);

			Assert.AreEqual (typeof (BitmapImage), BitmapImage.DecodePixelWidthProperty.OwnerType);
			Assert.AreEqual ("DecodePixelWidth", BitmapImage.DecodePixelWidthProperty.Name);
			Assert.AreEqual ("DecodePixelWidth", BitmapImage.DecodePixelWidthProperty.ToString());
			Assert.AreEqual (typeof (int), BitmapImage.DecodePixelWidthProperty.PropertyType);
			Assert.IsFalse (BitmapImage.DecodePixelWidthProperty.ReadOnly);

			Assert.AreEqual (typeof (BitmapImage), BitmapImage.DecodePixelHeightProperty.OwnerType);
			Assert.AreEqual ("DecodePixelHeight", BitmapImage.DecodePixelHeightProperty.Name);
			Assert.AreEqual ("DecodePixelHeight", BitmapImage.DecodePixelHeightProperty.ToString());
			Assert.AreEqual (typeof (int), BitmapImage.DecodePixelHeightProperty.PropertyType);
			Assert.IsFalse (BitmapImage.DecodePixelHeightProperty.ReadOnly);

			Assert.AreEqual (typeof (BitmapImage), BitmapImage.RotationProperty.OwnerType);
			Assert.AreEqual ("Rotation", BitmapImage.RotationProperty.Name);
			Assert.AreEqual ("Rotation", BitmapImage.RotationProperty.ToString());
			Assert.AreEqual (typeof (Rotation), BitmapImage.RotationProperty.PropertyType);
			Assert.IsFalse (BitmapImage.RotationProperty.ReadOnly);

			Assert.AreEqual (typeof (BitmapImage), BitmapImage.SourceRectProperty.OwnerType);
			Assert.AreEqual ("SourceRect", BitmapImage.SourceRectProperty.Name);
			Assert.AreEqual ("SourceRect", BitmapImage.SourceRectProperty.ToString());
			Assert.AreEqual (typeof (Int32Rect), BitmapImage.SourceRectProperty.PropertyType);
			Assert.IsFalse (BitmapImage.SourceRectProperty.ReadOnly);

			Assert.AreEqual (typeof (BitmapImage), BitmapImage.CreateOptionsProperty.OwnerType);
			Assert.AreEqual ("CreateOptions", BitmapImage.CreateOptionsProperty.Name);
			Assert.AreEqual ("CreateOptions", BitmapImage.CreateOptionsProperty.ToString());
			Assert.AreEqual (typeof (BitmapCreateOptions), BitmapImage.CreateOptionsProperty.PropertyType);
			Assert.IsFalse (BitmapImage.CreateOptionsProperty.ReadOnly);

			Assert.AreEqual (typeof (BitmapImage), BitmapImage.CacheOptionProperty.OwnerType);
			Assert.AreEqual ("CacheOption", BitmapImage.CacheOptionProperty.Name);
			Assert.AreEqual ("CacheOption", BitmapImage.CacheOptionProperty.ToString());
			Assert.AreEqual (typeof (BitmapCacheOption), BitmapImage.CacheOptionProperty.PropertyType);
			Assert.IsFalse (BitmapImage.CacheOptionProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Effects.BlurBitmapEffect
namespace MonoTests.System.Windows.Media.Effects {
	public partial class BlurBitmapEffectTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (BlurBitmapEffect), BlurBitmapEffect.RadiusProperty.OwnerType);
			Assert.AreEqual ("Radius", BlurBitmapEffect.RadiusProperty.Name);
			Assert.AreEqual ("Radius", BlurBitmapEffect.RadiusProperty.ToString());
			Assert.AreEqual (typeof (double), BlurBitmapEffect.RadiusProperty.PropertyType);
			Assert.IsFalse (BlurBitmapEffect.RadiusProperty.ReadOnly);

			Assert.AreEqual (typeof (BlurBitmapEffect), BlurBitmapEffect.KernelTypeProperty.OwnerType);
			Assert.AreEqual ("KernelType", BlurBitmapEffect.KernelTypeProperty.Name);
			Assert.AreEqual ("KernelType", BlurBitmapEffect.KernelTypeProperty.ToString());
			Assert.AreEqual (typeof (KernelType), BlurBitmapEffect.KernelTypeProperty.PropertyType);
			Assert.IsFalse (BlurBitmapEffect.KernelTypeProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Effects.BlurEffect
namespace MonoTests.System.Windows.Media.Effects {
	public partial class BlurEffectTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (BlurEffect), BlurEffect.RadiusProperty.OwnerType);
			Assert.AreEqual ("Radius", BlurEffect.RadiusProperty.Name);
			Assert.AreEqual ("Radius", BlurEffect.RadiusProperty.ToString());
			Assert.AreEqual (typeof (double), BlurEffect.RadiusProperty.PropertyType);
			Assert.IsFalse (BlurEffect.RadiusProperty.ReadOnly);

			Assert.AreEqual (typeof (BlurEffect), BlurEffect.KernelTypeProperty.OwnerType);
			Assert.AreEqual ("KernelType", BlurEffect.KernelTypeProperty.Name);
			Assert.AreEqual ("KernelType", BlurEffect.KernelTypeProperty.ToString());
			Assert.AreEqual (typeof (KernelType), BlurEffect.KernelTypeProperty.PropertyType);
			Assert.IsFalse (BlurEffect.KernelTypeProperty.ReadOnly);

			Assert.AreEqual (typeof (BlurEffect), BlurEffect.RenderingBiasProperty.OwnerType);
			Assert.AreEqual ("RenderingBias", BlurEffect.RenderingBiasProperty.Name);
			Assert.AreEqual ("RenderingBias", BlurEffect.RenderingBiasProperty.ToString());
			Assert.AreEqual (typeof (RenderingBias), BlurEffect.RenderingBiasProperty.PropertyType);
			Assert.IsFalse (BlurEffect.RenderingBiasProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Animation.BooleanKeyFrame
namespace MonoTests.System.Windows.Media.Animation {
	public partial class BooleanKeyFrameTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (BooleanKeyFrame), BooleanKeyFrame.KeyTimeProperty.OwnerType);
			Assert.AreEqual ("KeyTime", BooleanKeyFrame.KeyTimeProperty.Name);
			Assert.AreEqual ("KeyTime", BooleanKeyFrame.KeyTimeProperty.ToString());
			Assert.AreEqual (typeof (KeyTime), BooleanKeyFrame.KeyTimeProperty.PropertyType);
			Assert.IsFalse (BooleanKeyFrame.KeyTimeProperty.ReadOnly);

			Assert.AreEqual (typeof (BooleanKeyFrame), BooleanKeyFrame.ValueProperty.OwnerType);
			Assert.AreEqual ("Value", BooleanKeyFrame.ValueProperty.Name);
			Assert.AreEqual ("Value", BooleanKeyFrame.ValueProperty.ToString());
			Assert.AreEqual (typeof (bool), BooleanKeyFrame.ValueProperty.PropertyType);
			Assert.IsFalse (BooleanKeyFrame.ValueProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.Brush
namespace MonoTests.System.Windows.Media {
	public partial class BrushTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (Brush), Brush.OpacityProperty.OwnerType);
			Assert.AreEqual ("Opacity", Brush.OpacityProperty.Name);
			Assert.AreEqual ("Opacity", Brush.OpacityProperty.ToString());
			Assert.AreEqual (typeof (double), Brush.OpacityProperty.PropertyType);
			Assert.IsFalse (Brush.OpacityProperty.ReadOnly);

			Assert.AreEqual (typeof (Brush), Brush.TransformProperty.OwnerType);
			Assert.AreEqual ("Transform", Brush.TransformProperty.Name);
			Assert.AreEqual ("Transform", Brush.TransformProperty.ToString());
			Assert.AreEqual (typeof (Transform), Brush.TransformProperty.PropertyType);
			Assert.IsFalse (Brush.TransformProperty.ReadOnly);

			Assert.AreEqual (typeof (Brush), Brush.RelativeTransformProperty.OwnerType);
			Assert.AreEqual ("RelativeTransform", Brush.RelativeTransformProperty.Name);
			Assert.AreEqual ("RelativeTransform", Brush.RelativeTransformProperty.ToString());
			Assert.AreEqual (typeof (Transform), Brush.RelativeTransformProperty.PropertyType);
			Assert.IsFalse (Brush.RelativeTransformProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.Animation.ByteAnimation
namespace MonoTests.System.Windows.Media.Animation {
	public partial class ByteAnimationTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (ByteAnimation), ByteAnimation.FromProperty.OwnerType);
			Assert.AreEqual ("From", ByteAnimation.FromProperty.Name);
			Assert.AreEqual ("From", ByteAnimation.FromProperty.ToString());
			Assert.AreEqual (typeof (byte?), ByteAnimation.FromProperty.PropertyType);
			Assert.IsFalse (ByteAnimation.FromProperty.ReadOnly);

			Assert.AreEqual (typeof (ByteAnimation), ByteAnimation.ToProperty.OwnerType);
			Assert.AreEqual ("To", ByteAnimation.ToProperty.Name);
			Assert.AreEqual ("To", ByteAnimation.ToProperty.ToString());
			Assert.AreEqual (typeof (byte?), ByteAnimation.ToProperty.PropertyType);
			Assert.IsFalse (ByteAnimation.ToProperty.ReadOnly);

			Assert.AreEqual (typeof (ByteAnimation), ByteAnimation.ByProperty.OwnerType);
			Assert.AreEqual ("By", ByteAnimation.ByProperty.Name);
			Assert.AreEqual ("By", ByteAnimation.ByProperty.ToString());
			Assert.AreEqual (typeof (byte?), ByteAnimation.ByProperty.PropertyType);
			Assert.IsFalse (ByteAnimation.ByProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.Animation.ByteKeyFrame
namespace MonoTests.System.Windows.Media.Animation {
	public partial class ByteKeyFrameTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (ByteKeyFrame), ByteKeyFrame.KeyTimeProperty.OwnerType);
			Assert.AreEqual ("KeyTime", ByteKeyFrame.KeyTimeProperty.Name);
			Assert.AreEqual ("KeyTime", ByteKeyFrame.KeyTimeProperty.ToString());
			Assert.AreEqual (typeof (KeyTime), ByteKeyFrame.KeyTimeProperty.PropertyType);
			Assert.IsFalse (ByteKeyFrame.KeyTimeProperty.ReadOnly);

			Assert.AreEqual (typeof (ByteKeyFrame), ByteKeyFrame.ValueProperty.OwnerType);
			Assert.AreEqual ("Value", ByteKeyFrame.ValueProperty.Name);
			Assert.AreEqual ("Value", ByteKeyFrame.ValueProperty.ToString());
			Assert.AreEqual (typeof (byte), ByteKeyFrame.ValueProperty.PropertyType);
			Assert.IsFalse (ByteKeyFrame.ValueProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.Media3D.Camera
namespace MonoTests.System.Windows.Media.Media3D {
	public partial class CameraTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (Camera), Camera.TransformProperty.OwnerType);
			Assert.AreEqual ("Transform", Camera.TransformProperty.Name);
			Assert.AreEqual ("Transform", Camera.TransformProperty.ToString());
			Assert.AreEqual (typeof (Transform3D), Camera.TransformProperty.PropertyType);
			Assert.IsFalse (Camera.TransformProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Animation.CharKeyFrame
namespace MonoTests.System.Windows.Media.Animation {
	public partial class CharKeyFrameTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (CharKeyFrame), CharKeyFrame.KeyTimeProperty.OwnerType);
			Assert.AreEqual ("KeyTime", CharKeyFrame.KeyTimeProperty.Name);
			Assert.AreEqual ("KeyTime", CharKeyFrame.KeyTimeProperty.ToString());
			Assert.AreEqual (typeof (KeyTime), CharKeyFrame.KeyTimeProperty.PropertyType);
			Assert.IsFalse (CharKeyFrame.KeyTimeProperty.ReadOnly);

			Assert.AreEqual (typeof (CharKeyFrame), CharKeyFrame.ValueProperty.OwnerType);
			Assert.AreEqual ("Value", CharKeyFrame.ValueProperty.Name);
			Assert.AreEqual ("Value", CharKeyFrame.ValueProperty.ToString());
			Assert.AreEqual (typeof (char), CharKeyFrame.ValueProperty.PropertyType);
			Assert.IsFalse (CharKeyFrame.ValueProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.Animation.ColorAnimation
namespace MonoTests.System.Windows.Media.Animation {
	public partial class ColorAnimationTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (ColorAnimation), ColorAnimation.FromProperty.OwnerType);
			Assert.AreEqual ("From", ColorAnimation.FromProperty.Name);
			Assert.AreEqual ("From", ColorAnimation.FromProperty.ToString());
			Assert.AreEqual (typeof (Color?), ColorAnimation.FromProperty.PropertyType);
			Assert.IsFalse (ColorAnimation.FromProperty.ReadOnly);

			Assert.AreEqual (typeof (ColorAnimation), ColorAnimation.ToProperty.OwnerType);
			Assert.AreEqual ("To", ColorAnimation.ToProperty.Name);
			Assert.AreEqual ("To", ColorAnimation.ToProperty.ToString());
			Assert.AreEqual (typeof (Color?), ColorAnimation.ToProperty.PropertyType);
			Assert.IsFalse (ColorAnimation.ToProperty.ReadOnly);

			Assert.AreEqual (typeof (ColorAnimation), ColorAnimation.ByProperty.OwnerType);
			Assert.AreEqual ("By", ColorAnimation.ByProperty.Name);
			Assert.AreEqual ("By", ColorAnimation.ByProperty.ToString());
			Assert.AreEqual (typeof (Color?), ColorAnimation.ByProperty.PropertyType);
			Assert.IsFalse (ColorAnimation.ByProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.Imaging.ColorConvertedBitmap
namespace MonoTests.System.Windows.Media.Imaging {
	public partial class ColorConvertedBitmapTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (ColorConvertedBitmap), ColorConvertedBitmap.SourceProperty.OwnerType);
			Assert.AreEqual ("Source", ColorConvertedBitmap.SourceProperty.Name);
			Assert.AreEqual ("Source", ColorConvertedBitmap.SourceProperty.ToString());
			Assert.AreEqual (typeof (BitmapSource), ColorConvertedBitmap.SourceProperty.PropertyType);
			Assert.IsFalse (ColorConvertedBitmap.SourceProperty.ReadOnly);

			Assert.AreEqual (typeof (ColorConvertedBitmap), ColorConvertedBitmap.SourceColorContextProperty.OwnerType);
			Assert.AreEqual ("SourceColorContext", ColorConvertedBitmap.SourceColorContextProperty.Name);
			Assert.AreEqual ("SourceColorContext", ColorConvertedBitmap.SourceColorContextProperty.ToString());
			Assert.AreEqual (typeof (ColorContext), ColorConvertedBitmap.SourceColorContextProperty.PropertyType);
			Assert.IsFalse (ColorConvertedBitmap.SourceColorContextProperty.ReadOnly);

			Assert.AreEqual (typeof (ColorConvertedBitmap), ColorConvertedBitmap.DestinationColorContextProperty.OwnerType);
			Assert.AreEqual ("DestinationColorContext", ColorConvertedBitmap.DestinationColorContextProperty.Name);
			Assert.AreEqual ("DestinationColorContext", ColorConvertedBitmap.DestinationColorContextProperty.ToString());
			Assert.AreEqual (typeof (ColorContext), ColorConvertedBitmap.DestinationColorContextProperty.PropertyType);
			Assert.IsFalse (ColorConvertedBitmap.DestinationColorContextProperty.ReadOnly);

			Assert.AreEqual (typeof (ColorConvertedBitmap), ColorConvertedBitmap.DestinationFormatProperty.OwnerType);
			Assert.AreEqual ("DestinationFormat", ColorConvertedBitmap.DestinationFormatProperty.Name);
			Assert.AreEqual ("DestinationFormat", ColorConvertedBitmap.DestinationFormatProperty.ToString());
			Assert.AreEqual (typeof (PixelFormat), ColorConvertedBitmap.DestinationFormatProperty.PropertyType);
			Assert.IsFalse (ColorConvertedBitmap.DestinationFormatProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Animation.ColorKeyFrame
namespace MonoTests.System.Windows.Media.Animation {
	public partial class ColorKeyFrameTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (ColorKeyFrame), ColorKeyFrame.KeyTimeProperty.OwnerType);
			Assert.AreEqual ("KeyTime", ColorKeyFrame.KeyTimeProperty.Name);
			Assert.AreEqual ("KeyTime", ColorKeyFrame.KeyTimeProperty.ToString());
			Assert.AreEqual (typeof (KeyTime), ColorKeyFrame.KeyTimeProperty.PropertyType);
			Assert.IsFalse (ColorKeyFrame.KeyTimeProperty.ReadOnly);

			Assert.AreEqual (typeof (ColorKeyFrame), ColorKeyFrame.ValueProperty.OwnerType);
			Assert.AreEqual ("Value", ColorKeyFrame.ValueProperty.Name);
			Assert.AreEqual ("Value", ColorKeyFrame.ValueProperty.ToString());
			Assert.AreEqual (typeof (Color), ColorKeyFrame.ValueProperty.PropertyType);
			Assert.IsFalse (ColorKeyFrame.ValueProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.CombinedGeometry
namespace MonoTests.System.Windows.Media {
	public partial class CombinedGeometryTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (CombinedGeometry), CombinedGeometry.GeometryCombineModeProperty.OwnerType);
			Assert.AreEqual ("GeometryCombineMode", CombinedGeometry.GeometryCombineModeProperty.Name);
			Assert.AreEqual ("GeometryCombineMode", CombinedGeometry.GeometryCombineModeProperty.ToString());
			Assert.AreEqual (typeof (GeometryCombineMode), CombinedGeometry.GeometryCombineModeProperty.PropertyType);
			Assert.IsFalse (CombinedGeometry.GeometryCombineModeProperty.ReadOnly);

			Assert.AreEqual (typeof (CombinedGeometry), CombinedGeometry.Geometry1Property.OwnerType);
			Assert.AreEqual ("Geometry1", CombinedGeometry.Geometry1Property.Name);
			Assert.AreEqual ("Geometry1", CombinedGeometry.Geometry1Property.ToString());
			Assert.AreEqual (typeof (Geometry), CombinedGeometry.Geometry1Property.PropertyType);
			Assert.IsFalse (CombinedGeometry.Geometry1Property.ReadOnly);

			Assert.AreEqual (typeof (CombinedGeometry), CombinedGeometry.Geometry2Property.OwnerType);
			Assert.AreEqual ("Geometry2", CombinedGeometry.Geometry2Property.Name);
			Assert.AreEqual ("Geometry2", CombinedGeometry.Geometry2Property.ToString());
			Assert.AreEqual (typeof (Geometry), CombinedGeometry.Geometry2Property.PropertyType);
			Assert.IsFalse (CombinedGeometry.Geometry2Property.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.ContentElement
namespace MonoTests.System.Windows {
	public partial class ContentElementTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreSame (ContentElement.IsFocusedProperty, UIElement.IsFocusedProperty);
			Assert.AreSame (ContentElement.IsEnabledProperty, UIElement.IsEnabledProperty);
			Assert.AreSame (ContentElement.FocusableProperty, UIElement.FocusableProperty);
			Assert.AreSame (ContentElement.AllowDropProperty, UIElement.AllowDropProperty);
			Assert.AreSame (ContentElement.IsMouseDirectlyOverProperty, UIElement.IsMouseDirectlyOverProperty);
			Assert.AreSame (ContentElement.IsMouseOverProperty, UIElement.IsMouseOverProperty);
			Assert.AreSame (ContentElement.IsStylusOverProperty, UIElement.IsStylusOverProperty);
			Assert.AreSame (ContentElement.IsKeyboardFocusWithinProperty, UIElement.IsKeyboardFocusWithinProperty);
			Assert.AreSame (ContentElement.IsMouseCapturedProperty, UIElement.IsMouseCapturedProperty);
			Assert.AreSame (ContentElement.IsMouseCaptureWithinProperty, UIElement.IsMouseCaptureWithinProperty);
			Assert.AreSame (ContentElement.IsStylusDirectlyOverProperty, UIElement.IsStylusDirectlyOverProperty);
			Assert.AreSame (ContentElement.IsStylusCapturedProperty, UIElement.IsStylusCapturedProperty);
			Assert.AreSame (ContentElement.IsStylusCaptureWithinProperty, UIElement.IsStylusCaptureWithinProperty);
			Assert.AreSame (ContentElement.IsKeyboardFocusedProperty, UIElement.IsKeyboardFocusedProperty);
		}
	}
}
//   Type: System.Windows.Media.Imaging.CroppedBitmap
namespace MonoTests.System.Windows.Media.Imaging {
	public partial class CroppedBitmapTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (CroppedBitmap), CroppedBitmap.SourceProperty.OwnerType);
			Assert.AreEqual ("Source", CroppedBitmap.SourceProperty.Name);
			Assert.AreEqual ("Source", CroppedBitmap.SourceProperty.ToString());
			Assert.AreEqual (typeof (BitmapSource), CroppedBitmap.SourceProperty.PropertyType);
			Assert.IsFalse (CroppedBitmap.SourceProperty.ReadOnly);

			Assert.AreEqual (typeof (CroppedBitmap), CroppedBitmap.SourceRectProperty.OwnerType);
			Assert.AreEqual ("SourceRect", CroppedBitmap.SourceRectProperty.Name);
			Assert.AreEqual ("SourceRect", CroppedBitmap.SourceRectProperty.ToString());
			Assert.AreEqual (typeof (Int32Rect), CroppedBitmap.SourceRectProperty.PropertyType);
			Assert.IsFalse (CroppedBitmap.SourceRectProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Interop.D3DImage
namespace MonoTests.System.Windows.Interop {
	public partial class D3DImageTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (D3DImage), D3DImage.IsFrontBufferAvailableProperty.OwnerType);
			Assert.AreEqual ("IsFrontBufferAvailable", D3DImage.IsFrontBufferAvailableProperty.Name);
			Assert.AreEqual ("IsFrontBufferAvailable", D3DImage.IsFrontBufferAvailableProperty.ToString());
			Assert.AreEqual (typeof (bool), D3DImage.IsFrontBufferAvailableProperty.PropertyType);
			Assert.IsTrue (D3DImage.IsFrontBufferAvailableProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.DashStyle
namespace MonoTests.System.Windows.Media {
	public partial class DashStyleTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (DashStyle), DashStyle.OffsetProperty.OwnerType);
			Assert.AreEqual ("Offset", DashStyle.OffsetProperty.Name);
			Assert.AreEqual ("Offset", DashStyle.OffsetProperty.ToString());
			Assert.AreEqual (typeof (double), DashStyle.OffsetProperty.PropertyType);
			Assert.IsFalse (DashStyle.OffsetProperty.ReadOnly);

			Assert.AreEqual (typeof (DashStyle), DashStyle.DashesProperty.OwnerType);
			Assert.AreEqual ("Dashes", DashStyle.DashesProperty.Name);
			Assert.AreEqual ("Dashes", DashStyle.DashesProperty.ToString());
			Assert.AreEqual (typeof (DoubleCollection), DashStyle.DashesProperty.PropertyType);
			Assert.IsFalse (DashStyle.DashesProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Animation.DecimalAnimation
namespace MonoTests.System.Windows.Media.Animation {
	public partial class DecimalAnimationTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (DecimalAnimation), DecimalAnimation.FromProperty.OwnerType);
			Assert.AreEqual ("From", DecimalAnimation.FromProperty.Name);
			Assert.AreEqual ("From", DecimalAnimation.FromProperty.ToString());
			Assert.AreEqual (typeof (decimal?), DecimalAnimation.FromProperty.PropertyType);
			Assert.IsFalse (DecimalAnimation.FromProperty.ReadOnly);

			Assert.AreEqual (typeof (DecimalAnimation), DecimalAnimation.ToProperty.OwnerType);
			Assert.AreEqual ("To", DecimalAnimation.ToProperty.Name);
			Assert.AreEqual ("To", DecimalAnimation.ToProperty.ToString());
			Assert.AreEqual (typeof (decimal?), DecimalAnimation.ToProperty.PropertyType);
			Assert.IsFalse (DecimalAnimation.ToProperty.ReadOnly);

			Assert.AreEqual (typeof (DecimalAnimation), DecimalAnimation.ByProperty.OwnerType);
			Assert.AreEqual ("By", DecimalAnimation.ByProperty.Name);
			Assert.AreEqual ("By", DecimalAnimation.ByProperty.ToString());
			Assert.AreEqual (typeof (decimal?), DecimalAnimation.ByProperty.PropertyType);
			Assert.IsFalse (DecimalAnimation.ByProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.Animation.DecimalKeyFrame
namespace MonoTests.System.Windows.Media.Animation {
	public partial class DecimalKeyFrameTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (DecimalKeyFrame), DecimalKeyFrame.KeyTimeProperty.OwnerType);
			Assert.AreEqual ("KeyTime", DecimalKeyFrame.KeyTimeProperty.Name);
			Assert.AreEqual ("KeyTime", DecimalKeyFrame.KeyTimeProperty.ToString());
			Assert.AreEqual (typeof (KeyTime), DecimalKeyFrame.KeyTimeProperty.PropertyType);
			Assert.IsFalse (DecimalKeyFrame.KeyTimeProperty.ReadOnly);

			Assert.AreEqual (typeof (DecimalKeyFrame), DecimalKeyFrame.ValueProperty.OwnerType);
			Assert.AreEqual ("Value", DecimalKeyFrame.ValueProperty.Name);
			Assert.AreEqual ("Value", DecimalKeyFrame.ValueProperty.ToString());
			Assert.AreEqual (typeof (decimal), DecimalKeyFrame.ValueProperty.PropertyType);
			Assert.IsFalse (DecimalKeyFrame.ValueProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.Media3D.DiffuseMaterial
namespace MonoTests.System.Windows.Media.Media3D {
	public partial class DiffuseMaterialTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (DiffuseMaterial), DiffuseMaterial.ColorProperty.OwnerType);
			Assert.AreEqual ("Color", DiffuseMaterial.ColorProperty.Name);
			Assert.AreEqual ("Color", DiffuseMaterial.ColorProperty.ToString());
			Assert.AreEqual (typeof (Color), DiffuseMaterial.ColorProperty.PropertyType);
			Assert.IsFalse (DiffuseMaterial.ColorProperty.ReadOnly);

			Assert.AreEqual (typeof (DiffuseMaterial), DiffuseMaterial.AmbientColorProperty.OwnerType);
			Assert.AreEqual ("AmbientColor", DiffuseMaterial.AmbientColorProperty.Name);
			Assert.AreEqual ("AmbientColor", DiffuseMaterial.AmbientColorProperty.ToString());
			Assert.AreEqual (typeof (Color), DiffuseMaterial.AmbientColorProperty.PropertyType);
			Assert.IsFalse (DiffuseMaterial.AmbientColorProperty.ReadOnly);

			Assert.AreEqual (typeof (DiffuseMaterial), DiffuseMaterial.BrushProperty.OwnerType);
			Assert.AreEqual ("Brush", DiffuseMaterial.BrushProperty.Name);
			Assert.AreEqual ("Brush", DiffuseMaterial.BrushProperty.ToString());
			Assert.AreEqual (typeof (Brush), DiffuseMaterial.BrushProperty.PropertyType);
			Assert.IsFalse (DiffuseMaterial.BrushProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Media3D.DirectionalLight
namespace MonoTests.System.Windows.Media.Media3D {
	public partial class DirectionalLightTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (DirectionalLight), DirectionalLight.DirectionProperty.OwnerType);
			Assert.AreEqual ("Direction", DirectionalLight.DirectionProperty.Name);
			Assert.AreEqual ("Direction", DirectionalLight.DirectionProperty.ToString());
			Assert.AreEqual (typeof (Vector3D), DirectionalLight.DirectionProperty.PropertyType);
			Assert.IsFalse (DirectionalLight.DirectionProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Animation.DoubleAnimation
namespace MonoTests.System.Windows.Media.Animation {
	public partial class DoubleAnimationTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (DoubleAnimation), DoubleAnimation.FromProperty.OwnerType);
			Assert.AreEqual ("From", DoubleAnimation.FromProperty.Name);
			Assert.AreEqual ("From", DoubleAnimation.FromProperty.ToString());
			Assert.AreEqual (typeof (double?), DoubleAnimation.FromProperty.PropertyType);
			Assert.IsFalse (DoubleAnimation.FromProperty.ReadOnly);

			Assert.AreEqual (typeof (DoubleAnimation), DoubleAnimation.ToProperty.OwnerType);
			Assert.AreEqual ("To", DoubleAnimation.ToProperty.Name);
			Assert.AreEqual ("To", DoubleAnimation.ToProperty.ToString());
			Assert.AreEqual (typeof (double?), DoubleAnimation.ToProperty.PropertyType);
			Assert.IsFalse (DoubleAnimation.ToProperty.ReadOnly);

			Assert.AreEqual (typeof (DoubleAnimation), DoubleAnimation.ByProperty.OwnerType);
			Assert.AreEqual ("By", DoubleAnimation.ByProperty.Name);
			Assert.AreEqual ("By", DoubleAnimation.ByProperty.ToString());
			Assert.AreEqual (typeof (double?), DoubleAnimation.ByProperty.PropertyType);
			Assert.IsFalse (DoubleAnimation.ByProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.Animation.DoubleAnimationUsingPath
namespace MonoTests.System.Windows.Media.Animation {
	public partial class DoubleAnimationUsingPathTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (DoubleAnimationUsingPath), DoubleAnimationUsingPath.PathGeometryProperty.OwnerType);
			Assert.AreEqual ("PathGeometry", DoubleAnimationUsingPath.PathGeometryProperty.Name);
			Assert.AreEqual ("PathGeometry", DoubleAnimationUsingPath.PathGeometryProperty.ToString());
			Assert.AreEqual (typeof (PathGeometry), DoubleAnimationUsingPath.PathGeometryProperty.PropertyType);
			Assert.IsFalse (DoubleAnimationUsingPath.PathGeometryProperty.ReadOnly);

			Assert.AreEqual (typeof (DoubleAnimationUsingPath), DoubleAnimationUsingPath.SourceProperty.OwnerType);
			Assert.AreEqual ("Source", DoubleAnimationUsingPath.SourceProperty.Name);
			Assert.AreEqual ("Source", DoubleAnimationUsingPath.SourceProperty.ToString());
			Assert.AreEqual (typeof (PathAnimationSource), DoubleAnimationUsingPath.SourceProperty.PropertyType);
			Assert.IsFalse (DoubleAnimationUsingPath.SourceProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Animation.DoubleKeyFrame
namespace MonoTests.System.Windows.Media.Animation {
	public partial class DoubleKeyFrameTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (DoubleKeyFrame), DoubleKeyFrame.KeyTimeProperty.OwnerType);
			Assert.AreEqual ("KeyTime", DoubleKeyFrame.KeyTimeProperty.Name);
			Assert.AreEqual ("KeyTime", DoubleKeyFrame.KeyTimeProperty.ToString());
			Assert.AreEqual (typeof (KeyTime), DoubleKeyFrame.KeyTimeProperty.PropertyType);
			Assert.IsFalse (DoubleKeyFrame.KeyTimeProperty.ReadOnly);

			Assert.AreEqual (typeof (DoubleKeyFrame), DoubleKeyFrame.ValueProperty.OwnerType);
			Assert.AreEqual ("Value", DoubleKeyFrame.ValueProperty.Name);
			Assert.AreEqual ("Value", DoubleKeyFrame.ValueProperty.ToString());
			Assert.AreEqual (typeof (double), DoubleKeyFrame.ValueProperty.PropertyType);
			Assert.IsFalse (DoubleKeyFrame.ValueProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.DrawingBrush
namespace MonoTests.System.Windows.Media {
	public partial class DrawingBrushTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (DrawingBrush), DrawingBrush.DrawingProperty.OwnerType);
			Assert.AreEqual ("Drawing", DrawingBrush.DrawingProperty.Name);
			Assert.AreEqual ("Drawing", DrawingBrush.DrawingProperty.ToString());
			Assert.AreEqual (typeof (Drawing), DrawingBrush.DrawingProperty.PropertyType);
			Assert.IsFalse (DrawingBrush.DrawingProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.DrawingGroup
namespace MonoTests.System.Windows.Media {
	public partial class DrawingGroupTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (DrawingGroup), DrawingGroup.ChildrenProperty.OwnerType);
			Assert.AreEqual ("Children", DrawingGroup.ChildrenProperty.Name);
			Assert.AreEqual ("Children", DrawingGroup.ChildrenProperty.ToString());
			Assert.AreEqual (typeof (DrawingCollection), DrawingGroup.ChildrenProperty.PropertyType);
			Assert.IsFalse (DrawingGroup.ChildrenProperty.ReadOnly);

			Assert.AreEqual (typeof (DrawingGroup), DrawingGroup.ClipGeometryProperty.OwnerType);
			Assert.AreEqual ("ClipGeometry", DrawingGroup.ClipGeometryProperty.Name);
			Assert.AreEqual ("ClipGeometry", DrawingGroup.ClipGeometryProperty.ToString());
			Assert.AreEqual (typeof (Geometry), DrawingGroup.ClipGeometryProperty.PropertyType);
			Assert.IsFalse (DrawingGroup.ClipGeometryProperty.ReadOnly);

			Assert.AreEqual (typeof (DrawingGroup), DrawingGroup.OpacityProperty.OwnerType);
			Assert.AreEqual ("Opacity", DrawingGroup.OpacityProperty.Name);
			Assert.AreEqual ("Opacity", DrawingGroup.OpacityProperty.ToString());
			Assert.AreEqual (typeof (double), DrawingGroup.OpacityProperty.PropertyType);
			Assert.IsFalse (DrawingGroup.OpacityProperty.ReadOnly);

			Assert.AreEqual (typeof (DrawingGroup), DrawingGroup.OpacityMaskProperty.OwnerType);
			Assert.AreEqual ("OpacityMask", DrawingGroup.OpacityMaskProperty.Name);
			Assert.AreEqual ("OpacityMask", DrawingGroup.OpacityMaskProperty.ToString());
			Assert.AreEqual (typeof (Brush), DrawingGroup.OpacityMaskProperty.PropertyType);
			Assert.IsFalse (DrawingGroup.OpacityMaskProperty.ReadOnly);

			Assert.AreEqual (typeof (DrawingGroup), DrawingGroup.TransformProperty.OwnerType);
			Assert.AreEqual ("Transform", DrawingGroup.TransformProperty.Name);
			Assert.AreEqual ("Transform", DrawingGroup.TransformProperty.ToString());
			Assert.AreEqual (typeof (Transform), DrawingGroup.TransformProperty.PropertyType);
			Assert.IsFalse (DrawingGroup.TransformProperty.ReadOnly);

			Assert.AreEqual (typeof (DrawingGroup), DrawingGroup.GuidelineSetProperty.OwnerType);
			Assert.AreEqual ("GuidelineSet", DrawingGroup.GuidelineSetProperty.Name);
			Assert.AreEqual ("GuidelineSet", DrawingGroup.GuidelineSetProperty.ToString());
			Assert.AreEqual (typeof (GuidelineSet), DrawingGroup.GuidelineSetProperty.PropertyType);
			Assert.IsFalse (DrawingGroup.GuidelineSetProperty.ReadOnly);

			Assert.AreEqual (typeof (DrawingGroup), DrawingGroup.BitmapEffectProperty.OwnerType);
			Assert.AreEqual ("BitmapEffect", DrawingGroup.BitmapEffectProperty.Name);
			Assert.AreEqual ("BitmapEffect", DrawingGroup.BitmapEffectProperty.ToString());
			Assert.AreEqual (typeof (BitmapEffect), DrawingGroup.BitmapEffectProperty.PropertyType);
			Assert.IsFalse (DrawingGroup.BitmapEffectProperty.ReadOnly);

			Assert.AreEqual (typeof (DrawingGroup), DrawingGroup.BitmapEffectInputProperty.OwnerType);
			Assert.AreEqual ("BitmapEffectInput", DrawingGroup.BitmapEffectInputProperty.Name);
			Assert.AreEqual ("BitmapEffectInput", DrawingGroup.BitmapEffectInputProperty.ToString());
			Assert.AreEqual (typeof (BitmapEffectInput), DrawingGroup.BitmapEffectInputProperty.PropertyType);
			Assert.IsFalse (DrawingGroup.BitmapEffectInputProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.DrawingImage
namespace MonoTests.System.Windows.Media {
	public partial class DrawingImageTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (DrawingImage), DrawingImage.DrawingProperty.OwnerType);
			Assert.AreEqual ("Drawing", DrawingImage.DrawingProperty.Name);
			Assert.AreEqual ("Drawing", DrawingImage.DrawingProperty.ToString());
			Assert.AreEqual (typeof (Drawing), DrawingImage.DrawingProperty.PropertyType);
			Assert.IsFalse (DrawingImage.DrawingProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Effects.DropShadowBitmapEffect
namespace MonoTests.System.Windows.Media.Effects {
	public partial class DropShadowBitmapEffectTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (DropShadowBitmapEffect), DropShadowBitmapEffect.ShadowDepthProperty.OwnerType);
			Assert.AreEqual ("ShadowDepth", DropShadowBitmapEffect.ShadowDepthProperty.Name);
			Assert.AreEqual ("ShadowDepth", DropShadowBitmapEffect.ShadowDepthProperty.ToString());
			Assert.AreEqual (typeof (double), DropShadowBitmapEffect.ShadowDepthProperty.PropertyType);
			Assert.IsFalse (DropShadowBitmapEffect.ShadowDepthProperty.ReadOnly);

			Assert.AreEqual (typeof (DropShadowBitmapEffect), DropShadowBitmapEffect.ColorProperty.OwnerType);
			Assert.AreEqual ("Color", DropShadowBitmapEffect.ColorProperty.Name);
			Assert.AreEqual ("Color", DropShadowBitmapEffect.ColorProperty.ToString());
			Assert.AreEqual (typeof (Color), DropShadowBitmapEffect.ColorProperty.PropertyType);
			Assert.IsFalse (DropShadowBitmapEffect.ColorProperty.ReadOnly);

			Assert.AreEqual (typeof (DropShadowBitmapEffect), DropShadowBitmapEffect.DirectionProperty.OwnerType);
			Assert.AreEqual ("Direction", DropShadowBitmapEffect.DirectionProperty.Name);
			Assert.AreEqual ("Direction", DropShadowBitmapEffect.DirectionProperty.ToString());
			Assert.AreEqual (typeof (double), DropShadowBitmapEffect.DirectionProperty.PropertyType);
			Assert.IsFalse (DropShadowBitmapEffect.DirectionProperty.ReadOnly);

			Assert.AreEqual (typeof (DropShadowBitmapEffect), DropShadowBitmapEffect.NoiseProperty.OwnerType);
			Assert.AreEqual ("Noise", DropShadowBitmapEffect.NoiseProperty.Name);
			Assert.AreEqual ("Noise", DropShadowBitmapEffect.NoiseProperty.ToString());
			Assert.AreEqual (typeof (double), DropShadowBitmapEffect.NoiseProperty.PropertyType);
			Assert.IsFalse (DropShadowBitmapEffect.NoiseProperty.ReadOnly);

			Assert.AreEqual (typeof (DropShadowBitmapEffect), DropShadowBitmapEffect.OpacityProperty.OwnerType);
			Assert.AreEqual ("Opacity", DropShadowBitmapEffect.OpacityProperty.Name);
			Assert.AreEqual ("Opacity", DropShadowBitmapEffect.OpacityProperty.ToString());
			Assert.AreEqual (typeof (double), DropShadowBitmapEffect.OpacityProperty.PropertyType);
			Assert.IsFalse (DropShadowBitmapEffect.OpacityProperty.ReadOnly);

			Assert.AreEqual (typeof (DropShadowBitmapEffect), DropShadowBitmapEffect.SoftnessProperty.OwnerType);
			Assert.AreEqual ("Softness", DropShadowBitmapEffect.SoftnessProperty.Name);
			Assert.AreEqual ("Softness", DropShadowBitmapEffect.SoftnessProperty.ToString());
			Assert.AreEqual (typeof (double), DropShadowBitmapEffect.SoftnessProperty.PropertyType);
			Assert.IsFalse (DropShadowBitmapEffect.SoftnessProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Effects.DropShadowEffect
namespace MonoTests.System.Windows.Media.Effects {
	public partial class DropShadowEffectTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (DropShadowEffect), DropShadowEffect.ShadowDepthProperty.OwnerType);
			Assert.AreEqual ("ShadowDepth", DropShadowEffect.ShadowDepthProperty.Name);
			Assert.AreEqual ("ShadowDepth", DropShadowEffect.ShadowDepthProperty.ToString());
			Assert.AreEqual (typeof (double), DropShadowEffect.ShadowDepthProperty.PropertyType);
			Assert.IsFalse (DropShadowEffect.ShadowDepthProperty.ReadOnly);

			Assert.AreEqual (typeof (DropShadowEffect), DropShadowEffect.ColorProperty.OwnerType);
			Assert.AreEqual ("Color", DropShadowEffect.ColorProperty.Name);
			Assert.AreEqual ("Color", DropShadowEffect.ColorProperty.ToString());
			Assert.AreEqual (typeof (Color), DropShadowEffect.ColorProperty.PropertyType);
			Assert.IsFalse (DropShadowEffect.ColorProperty.ReadOnly);

			Assert.AreEqual (typeof (DropShadowEffect), DropShadowEffect.DirectionProperty.OwnerType);
			Assert.AreEqual ("Direction", DropShadowEffect.DirectionProperty.Name);
			Assert.AreEqual ("Direction", DropShadowEffect.DirectionProperty.ToString());
			Assert.AreEqual (typeof (double), DropShadowEffect.DirectionProperty.PropertyType);
			Assert.IsFalse (DropShadowEffect.DirectionProperty.ReadOnly);

			Assert.AreEqual (typeof (DropShadowEffect), DropShadowEffect.OpacityProperty.OwnerType);
			Assert.AreEqual ("Opacity", DropShadowEffect.OpacityProperty.Name);
			Assert.AreEqual ("Opacity", DropShadowEffect.OpacityProperty.ToString());
			Assert.AreEqual (typeof (double), DropShadowEffect.OpacityProperty.PropertyType);
			Assert.IsFalse (DropShadowEffect.OpacityProperty.ReadOnly);

			Assert.AreEqual (typeof (DropShadowEffect), DropShadowEffect.BlurRadiusProperty.OwnerType);
			Assert.AreEqual ("BlurRadius", DropShadowEffect.BlurRadiusProperty.Name);
			Assert.AreEqual ("BlurRadius", DropShadowEffect.BlurRadiusProperty.ToString());
			Assert.AreEqual (typeof (double), DropShadowEffect.BlurRadiusProperty.PropertyType);
			Assert.IsFalse (DropShadowEffect.BlurRadiusProperty.ReadOnly);

			Assert.AreEqual (typeof (DropShadowEffect), DropShadowEffect.RenderingBiasProperty.OwnerType);
			Assert.AreEqual ("RenderingBias", DropShadowEffect.RenderingBiasProperty.Name);
			Assert.AreEqual ("RenderingBias", DropShadowEffect.RenderingBiasProperty.ToString());
			Assert.AreEqual (typeof (RenderingBias), DropShadowEffect.RenderingBiasProperty.PropertyType);
			Assert.IsFalse (DropShadowEffect.RenderingBiasProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.EllipseGeometry
namespace MonoTests.System.Windows.Media {
	public partial class EllipseGeometryTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (EllipseGeometry), EllipseGeometry.RadiusXProperty.OwnerType);
			Assert.AreEqual ("RadiusX", EllipseGeometry.RadiusXProperty.Name);
			Assert.AreEqual ("RadiusX", EllipseGeometry.RadiusXProperty.ToString());
			Assert.AreEqual (typeof (double), EllipseGeometry.RadiusXProperty.PropertyType);
			Assert.IsFalse (EllipseGeometry.RadiusXProperty.ReadOnly);

			Assert.AreEqual (typeof (EllipseGeometry), EllipseGeometry.RadiusYProperty.OwnerType);
			Assert.AreEqual ("RadiusY", EllipseGeometry.RadiusYProperty.Name);
			Assert.AreEqual ("RadiusY", EllipseGeometry.RadiusYProperty.ToString());
			Assert.AreEqual (typeof (double), EllipseGeometry.RadiusYProperty.PropertyType);
			Assert.IsFalse (EllipseGeometry.RadiusYProperty.ReadOnly);

			Assert.AreEqual (typeof (EllipseGeometry), EllipseGeometry.CenterProperty.OwnerType);
			Assert.AreEqual ("Center", EllipseGeometry.CenterProperty.Name);
			Assert.AreEqual ("Center", EllipseGeometry.CenterProperty.ToString());
			Assert.AreEqual (typeof (Point), EllipseGeometry.CenterProperty.PropertyType);
			Assert.IsFalse (EllipseGeometry.CenterProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Effects.EmbossBitmapEffect
namespace MonoTests.System.Windows.Media.Effects {
	public partial class EmbossBitmapEffectTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (EmbossBitmapEffect), EmbossBitmapEffect.LightAngleProperty.OwnerType);
			Assert.AreEqual ("LightAngle", EmbossBitmapEffect.LightAngleProperty.Name);
			Assert.AreEqual ("LightAngle", EmbossBitmapEffect.LightAngleProperty.ToString());
			Assert.AreEqual (typeof (double), EmbossBitmapEffect.LightAngleProperty.PropertyType);
			Assert.IsFalse (EmbossBitmapEffect.LightAngleProperty.ReadOnly);

			Assert.AreEqual (typeof (EmbossBitmapEffect), EmbossBitmapEffect.ReliefProperty.OwnerType);
			Assert.AreEqual ("Relief", EmbossBitmapEffect.ReliefProperty.Name);
			Assert.AreEqual ("Relief", EmbossBitmapEffect.ReliefProperty.ToString());
			Assert.AreEqual (typeof (double), EmbossBitmapEffect.ReliefProperty.PropertyType);
			Assert.IsFalse (EmbossBitmapEffect.ReliefProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Media3D.EmissiveMaterial
namespace MonoTests.System.Windows.Media.Media3D {
	public partial class EmissiveMaterialTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (EmissiveMaterial), EmissiveMaterial.ColorProperty.OwnerType);
			Assert.AreEqual ("Color", EmissiveMaterial.ColorProperty.Name);
			Assert.AreEqual ("Color", EmissiveMaterial.ColorProperty.ToString());
			Assert.AreEqual (typeof (Color), EmissiveMaterial.ColorProperty.PropertyType);
			Assert.IsFalse (EmissiveMaterial.ColorProperty.ReadOnly);

			Assert.AreEqual (typeof (EmissiveMaterial), EmissiveMaterial.BrushProperty.OwnerType);
			Assert.AreEqual ("Brush", EmissiveMaterial.BrushProperty.Name);
			Assert.AreEqual ("Brush", EmissiveMaterial.BrushProperty.ToString());
			Assert.AreEqual (typeof (Brush), EmissiveMaterial.BrushProperty.PropertyType);
			Assert.IsFalse (EmissiveMaterial.BrushProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Input.FocusManager
namespace MonoTests.System.Windows.Input {
	public partial class FocusManagerTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (FocusManager), FocusManager.FocusedElementProperty.OwnerType);
			Assert.AreEqual ("FocusedElement", FocusManager.FocusedElementProperty.Name);
			Assert.AreEqual ("FocusedElement", FocusManager.FocusedElementProperty.ToString());
			Assert.AreEqual (typeof (IInputElement), FocusManager.FocusedElementProperty.PropertyType);
			Assert.IsFalse (FocusManager.FocusedElementProperty.ReadOnly);

			Assert.AreEqual (typeof (FocusManager), FocusManager.IsFocusScopeProperty.OwnerType);
			Assert.AreEqual ("IsFocusScope", FocusManager.IsFocusScopeProperty.Name);
			Assert.AreEqual ("IsFocusScope", FocusManager.IsFocusScopeProperty.ToString());
			Assert.AreEqual (typeof (bool), FocusManager.IsFocusScopeProperty.PropertyType);
			Assert.IsFalse (FocusManager.IsFocusScopeProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.Imaging.FormatConvertedBitmap
namespace MonoTests.System.Windows.Media.Imaging {
	public partial class FormatConvertedBitmapTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (FormatConvertedBitmap), FormatConvertedBitmap.SourceProperty.OwnerType);
			Assert.AreEqual ("Source", FormatConvertedBitmap.SourceProperty.Name);
			Assert.AreEqual ("Source", FormatConvertedBitmap.SourceProperty.ToString());
			Assert.AreEqual (typeof (BitmapSource), FormatConvertedBitmap.SourceProperty.PropertyType);
			Assert.IsFalse (FormatConvertedBitmap.SourceProperty.ReadOnly);

			Assert.AreEqual (typeof (FormatConvertedBitmap), FormatConvertedBitmap.DestinationFormatProperty.OwnerType);
			Assert.AreEqual ("DestinationFormat", FormatConvertedBitmap.DestinationFormatProperty.Name);
			Assert.AreEqual ("DestinationFormat", FormatConvertedBitmap.DestinationFormatProperty.ToString());
			Assert.AreEqual (typeof (PixelFormat), FormatConvertedBitmap.DestinationFormatProperty.PropertyType);
			Assert.IsFalse (FormatConvertedBitmap.DestinationFormatProperty.ReadOnly);

			Assert.AreEqual (typeof (FormatConvertedBitmap), FormatConvertedBitmap.DestinationPaletteProperty.OwnerType);
			Assert.AreEqual ("DestinationPalette", FormatConvertedBitmap.DestinationPaletteProperty.Name);
			Assert.AreEqual ("DestinationPalette", FormatConvertedBitmap.DestinationPaletteProperty.ToString());
			Assert.AreEqual (typeof (BitmapPalette), FormatConvertedBitmap.DestinationPaletteProperty.PropertyType);
			Assert.IsFalse (FormatConvertedBitmap.DestinationPaletteProperty.ReadOnly);

			Assert.AreEqual (typeof (FormatConvertedBitmap), FormatConvertedBitmap.AlphaThresholdProperty.OwnerType);
			Assert.AreEqual ("AlphaThreshold", FormatConvertedBitmap.AlphaThresholdProperty.Name);
			Assert.AreEqual ("AlphaThreshold", FormatConvertedBitmap.AlphaThresholdProperty.ToString());
			Assert.AreEqual (typeof (double), FormatConvertedBitmap.AlphaThresholdProperty.PropertyType);
			Assert.IsFalse (FormatConvertedBitmap.AlphaThresholdProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Media3D.GeneralTransform3DGroup
namespace MonoTests.System.Windows.Media.Media3D {
	public partial class GeneralTransform3DGroupTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (GeneralTransform3DGroup), GeneralTransform3DGroup.ChildrenProperty.OwnerType);
			Assert.AreEqual ("Children", GeneralTransform3DGroup.ChildrenProperty.Name);
			Assert.AreEqual ("Children", GeneralTransform3DGroup.ChildrenProperty.ToString());
			Assert.AreEqual (typeof (GeneralTransform3DCollection), GeneralTransform3DGroup.ChildrenProperty.PropertyType);
			Assert.IsFalse (GeneralTransform3DGroup.ChildrenProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.GeneralTransformGroup
namespace MonoTests.System.Windows.Media {
	public partial class GeneralTransformGroupTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (GeneralTransformGroup), GeneralTransformGroup.ChildrenProperty.OwnerType);
			Assert.AreEqual ("Children", GeneralTransformGroup.ChildrenProperty.Name);
			Assert.AreEqual ("Children", GeneralTransformGroup.ChildrenProperty.ToString());
			Assert.AreEqual (typeof (GeneralTransformCollection), GeneralTransformGroup.ChildrenProperty.PropertyType);
			Assert.IsFalse (GeneralTransformGroup.ChildrenProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Geometry
namespace MonoTests.System.Windows.Media {
	public partial class GeometryTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (Geometry), Geometry.TransformProperty.OwnerType);
			Assert.AreEqual ("Transform", Geometry.TransformProperty.Name);
			Assert.AreEqual ("Transform", Geometry.TransformProperty.ToString());
			Assert.AreEqual (typeof (Transform), Geometry.TransformProperty.PropertyType);
			Assert.IsFalse (Geometry.TransformProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.GeometryDrawing
namespace MonoTests.System.Windows.Media {
	public partial class GeometryDrawingTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (GeometryDrawing), GeometryDrawing.BrushProperty.OwnerType);
			Assert.AreEqual ("Brush", GeometryDrawing.BrushProperty.Name);
			Assert.AreEqual ("Brush", GeometryDrawing.BrushProperty.ToString());
			Assert.AreEqual (typeof (Brush), GeometryDrawing.BrushProperty.PropertyType);
			Assert.IsFalse (GeometryDrawing.BrushProperty.ReadOnly);

			Assert.AreEqual (typeof (GeometryDrawing), GeometryDrawing.PenProperty.OwnerType);
			Assert.AreEqual ("Pen", GeometryDrawing.PenProperty.Name);
			Assert.AreEqual ("Pen", GeometryDrawing.PenProperty.ToString());
			Assert.AreEqual (typeof (Pen), GeometryDrawing.PenProperty.PropertyType);
			Assert.IsFalse (GeometryDrawing.PenProperty.ReadOnly);

			Assert.AreEqual (typeof (GeometryDrawing), GeometryDrawing.GeometryProperty.OwnerType);
			Assert.AreEqual ("Geometry", GeometryDrawing.GeometryProperty.Name);
			Assert.AreEqual ("Geometry", GeometryDrawing.GeometryProperty.ToString());
			Assert.AreEqual (typeof (Geometry), GeometryDrawing.GeometryProperty.PropertyType);
			Assert.IsFalse (GeometryDrawing.GeometryProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.GeometryGroup
namespace MonoTests.System.Windows.Media {
	public partial class GeometryGroupTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (GeometryGroup), GeometryGroup.FillRuleProperty.OwnerType);
			Assert.AreEqual ("FillRule", GeometryGroup.FillRuleProperty.Name);
			Assert.AreEqual ("FillRule", GeometryGroup.FillRuleProperty.ToString());
			Assert.AreEqual (typeof (FillRule), GeometryGroup.FillRuleProperty.PropertyType);
			Assert.IsFalse (GeometryGroup.FillRuleProperty.ReadOnly);

			Assert.AreEqual (typeof (GeometryGroup), GeometryGroup.ChildrenProperty.OwnerType);
			Assert.AreEqual ("Children", GeometryGroup.ChildrenProperty.Name);
			Assert.AreEqual ("Children", GeometryGroup.ChildrenProperty.ToString());
			Assert.AreEqual (typeof (GeometryCollection), GeometryGroup.ChildrenProperty.PropertyType);
			Assert.IsFalse (GeometryGroup.ChildrenProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Media3D.GeometryModel3D
namespace MonoTests.System.Windows.Media.Media3D {
	public partial class GeometryModel3DTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (GeometryModel3D), GeometryModel3D.GeometryProperty.OwnerType);
			Assert.AreEqual ("Geometry", GeometryModel3D.GeometryProperty.Name);
			Assert.AreEqual ("Geometry", GeometryModel3D.GeometryProperty.ToString());
			Assert.AreEqual (typeof (Geometry3D), GeometryModel3D.GeometryProperty.PropertyType);
			Assert.IsFalse (GeometryModel3D.GeometryProperty.ReadOnly);

			Assert.AreEqual (typeof (GeometryModel3D), GeometryModel3D.MaterialProperty.OwnerType);
			Assert.AreEqual ("Material", GeometryModel3D.MaterialProperty.Name);
			Assert.AreEqual ("Material", GeometryModel3D.MaterialProperty.ToString());
			Assert.AreEqual (typeof (Material), GeometryModel3D.MaterialProperty.PropertyType);
			Assert.IsFalse (GeometryModel3D.MaterialProperty.ReadOnly);

			Assert.AreEqual (typeof (GeometryModel3D), GeometryModel3D.BackMaterialProperty.OwnerType);
			Assert.AreEqual ("BackMaterial", GeometryModel3D.BackMaterialProperty.Name);
			Assert.AreEqual ("BackMaterial", GeometryModel3D.BackMaterialProperty.ToString());
			Assert.AreEqual (typeof (Material), GeometryModel3D.BackMaterialProperty.PropertyType);
			Assert.IsFalse (GeometryModel3D.BackMaterialProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.GlyphRunDrawing
namespace MonoTests.System.Windows.Media {
	public partial class GlyphRunDrawingTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (GlyphRunDrawing), GlyphRunDrawing.GlyphRunProperty.OwnerType);
			Assert.AreEqual ("GlyphRun", GlyphRunDrawing.GlyphRunProperty.Name);
			Assert.AreEqual ("GlyphRun", GlyphRunDrawing.GlyphRunProperty.ToString());
			Assert.AreEqual (typeof (GlyphRun), GlyphRunDrawing.GlyphRunProperty.PropertyType);
			Assert.IsFalse (GlyphRunDrawing.GlyphRunProperty.ReadOnly);

			Assert.AreEqual (typeof (GlyphRunDrawing), GlyphRunDrawing.ForegroundBrushProperty.OwnerType);
			Assert.AreEqual ("ForegroundBrush", GlyphRunDrawing.ForegroundBrushProperty.Name);
			Assert.AreEqual ("ForegroundBrush", GlyphRunDrawing.ForegroundBrushProperty.ToString());
			Assert.AreEqual (typeof (Brush), GlyphRunDrawing.ForegroundBrushProperty.PropertyType);
			Assert.IsFalse (GlyphRunDrawing.ForegroundBrushProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.GradientBrush
namespace MonoTests.System.Windows.Media {
	public partial class GradientBrushTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (GradientBrush), GradientBrush.ColorInterpolationModeProperty.OwnerType);
			Assert.AreEqual ("ColorInterpolationMode", GradientBrush.ColorInterpolationModeProperty.Name);
			Assert.AreEqual ("ColorInterpolationMode", GradientBrush.ColorInterpolationModeProperty.ToString());
			Assert.AreEqual (typeof (ColorInterpolationMode), GradientBrush.ColorInterpolationModeProperty.PropertyType);
			Assert.IsFalse (GradientBrush.ColorInterpolationModeProperty.ReadOnly);

			Assert.AreEqual (typeof (GradientBrush), GradientBrush.MappingModeProperty.OwnerType);
			Assert.AreEqual ("MappingMode", GradientBrush.MappingModeProperty.Name);
			Assert.AreEqual ("MappingMode", GradientBrush.MappingModeProperty.ToString());
			Assert.AreEqual (typeof (BrushMappingMode), GradientBrush.MappingModeProperty.PropertyType);
			Assert.IsFalse (GradientBrush.MappingModeProperty.ReadOnly);

			Assert.AreEqual (typeof (GradientBrush), GradientBrush.SpreadMethodProperty.OwnerType);
			Assert.AreEqual ("SpreadMethod", GradientBrush.SpreadMethodProperty.Name);
			Assert.AreEqual ("SpreadMethod", GradientBrush.SpreadMethodProperty.ToString());
			Assert.AreEqual (typeof (GradientSpreadMethod), GradientBrush.SpreadMethodProperty.PropertyType);
			Assert.IsFalse (GradientBrush.SpreadMethodProperty.ReadOnly);

			Assert.AreEqual (typeof (GradientBrush), GradientBrush.GradientStopsProperty.OwnerType);
			Assert.AreEqual ("GradientStops", GradientBrush.GradientStopsProperty.Name);
			Assert.AreEqual ("GradientStops", GradientBrush.GradientStopsProperty.ToString());
			Assert.AreEqual (typeof (GradientStopCollection), GradientBrush.GradientStopsProperty.PropertyType);
			Assert.IsFalse (GradientBrush.GradientStopsProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.GradientStop
namespace MonoTests.System.Windows.Media {
	public partial class GradientStopTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (GradientStop), GradientStop.ColorProperty.OwnerType);
			Assert.AreEqual ("Color", GradientStop.ColorProperty.Name);
			Assert.AreEqual ("Color", GradientStop.ColorProperty.ToString());
			Assert.AreEqual (typeof (Color), GradientStop.ColorProperty.PropertyType);
			Assert.IsFalse (GradientStop.ColorProperty.ReadOnly);

			Assert.AreEqual (typeof (GradientStop), GradientStop.OffsetProperty.OwnerType);
			Assert.AreEqual ("Offset", GradientStop.OffsetProperty.Name);
			Assert.AreEqual ("Offset", GradientStop.OffsetProperty.ToString());
			Assert.AreEqual (typeof (double), GradientStop.OffsetProperty.PropertyType);
			Assert.IsFalse (GradientStop.OffsetProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.GuidelineSet
namespace MonoTests.System.Windows.Media {
	public partial class GuidelineSetTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (GuidelineSet), GuidelineSet.GuidelinesXProperty.OwnerType);
			Assert.AreEqual ("GuidelinesX", GuidelineSet.GuidelinesXProperty.Name);
			Assert.AreEqual ("GuidelinesX", GuidelineSet.GuidelinesXProperty.ToString());
			Assert.AreEqual (typeof (DoubleCollection), GuidelineSet.GuidelinesXProperty.PropertyType);
			Assert.IsFalse (GuidelineSet.GuidelinesXProperty.ReadOnly);

			Assert.AreEqual (typeof (GuidelineSet), GuidelineSet.GuidelinesYProperty.OwnerType);
			Assert.AreEqual ("GuidelinesY", GuidelineSet.GuidelinesYProperty.Name);
			Assert.AreEqual ("GuidelinesY", GuidelineSet.GuidelinesYProperty.ToString());
			Assert.AreEqual (typeof (DoubleCollection), GuidelineSet.GuidelinesYProperty.PropertyType);
			Assert.IsFalse (GuidelineSet.GuidelinesYProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.ImageBrush
namespace MonoTests.System.Windows.Media {
	public partial class ImageBrushTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (ImageBrush), ImageBrush.ImageSourceProperty.OwnerType);
			Assert.AreEqual ("ImageSource", ImageBrush.ImageSourceProperty.Name);
			Assert.AreEqual ("ImageSource", ImageBrush.ImageSourceProperty.ToString());
			Assert.AreEqual (typeof (ImageSource), ImageBrush.ImageSourceProperty.PropertyType);
			Assert.IsFalse (ImageBrush.ImageSourceProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.ImageDrawing
namespace MonoTests.System.Windows.Media {
	public partial class ImageDrawingTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (ImageDrawing), ImageDrawing.ImageSourceProperty.OwnerType);
			Assert.AreEqual ("ImageSource", ImageDrawing.ImageSourceProperty.Name);
			Assert.AreEqual ("ImageSource", ImageDrawing.ImageSourceProperty.ToString());
			Assert.AreEqual (typeof (ImageSource), ImageDrawing.ImageSourceProperty.PropertyType);
			Assert.IsFalse (ImageDrawing.ImageSourceProperty.ReadOnly);

			Assert.AreEqual (typeof (ImageDrawing), ImageDrawing.RectProperty.OwnerType);
			Assert.AreEqual ("Rect", ImageDrawing.RectProperty.Name);
			Assert.AreEqual ("Rect", ImageDrawing.RectProperty.ToString());
			Assert.AreEqual (typeof (Rect), ImageDrawing.RectProperty.PropertyType);
			Assert.IsFalse (ImageDrawing.RectProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Input.InputLanguageManager
namespace MonoTests.System.Windows.Input {
	public partial class InputLanguageManagerTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (InputLanguageManager), InputLanguageManager.InputLanguageProperty.OwnerType);
			Assert.AreEqual ("InputLanguage", InputLanguageManager.InputLanguageProperty.Name);
			Assert.AreEqual ("InputLanguage", InputLanguageManager.InputLanguageProperty.ToString());
			Assert.AreEqual (typeof (System.Globalization.CultureInfo), InputLanguageManager.InputLanguageProperty.PropertyType);
			Assert.IsFalse (InputLanguageManager.InputLanguageProperty.ReadOnly);

			Assert.AreEqual (typeof (InputLanguageManager), InputLanguageManager.RestoreInputLanguageProperty.OwnerType);
			Assert.AreEqual ("RestoreInputLanguage", InputLanguageManager.RestoreInputLanguageProperty.Name);
			Assert.AreEqual ("RestoreInputLanguage", InputLanguageManager.RestoreInputLanguageProperty.ToString());
			Assert.AreEqual (typeof (bool), InputLanguageManager.RestoreInputLanguageProperty.PropertyType);
			Assert.IsFalse (InputLanguageManager.RestoreInputLanguageProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Input.InputMethod
namespace MonoTests.System.Windows.Input {
	public partial class InputMethodTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (InputMethod), InputMethod.IsInputMethodEnabledProperty.OwnerType);
			Assert.AreEqual ("IsInputMethodEnabled", InputMethod.IsInputMethodEnabledProperty.Name);
			Assert.AreEqual ("IsInputMethodEnabled", InputMethod.IsInputMethodEnabledProperty.ToString());
			Assert.AreEqual (typeof (bool), InputMethod.IsInputMethodEnabledProperty.PropertyType);
			Assert.IsFalse (InputMethod.IsInputMethodEnabledProperty.ReadOnly);

			Assert.AreEqual (typeof (InputMethod), InputMethod.IsInputMethodSuspendedProperty.OwnerType);
			Assert.AreEqual ("IsInputMethodSuspended", InputMethod.IsInputMethodSuspendedProperty.Name);
			Assert.AreEqual ("IsInputMethodSuspended", InputMethod.IsInputMethodSuspendedProperty.ToString());
			Assert.AreEqual (typeof (bool), InputMethod.IsInputMethodSuspendedProperty.PropertyType);
			Assert.IsFalse (InputMethod.IsInputMethodSuspendedProperty.ReadOnly);

			Assert.AreEqual (typeof (InputMethod), InputMethod.PreferredImeStateProperty.OwnerType);
			Assert.AreEqual ("PreferredImeState", InputMethod.PreferredImeStateProperty.Name);
			Assert.AreEqual ("PreferredImeState", InputMethod.PreferredImeStateProperty.ToString());
			Assert.AreEqual (typeof (InputMethodState), InputMethod.PreferredImeStateProperty.PropertyType);
			Assert.IsFalse (InputMethod.PreferredImeStateProperty.ReadOnly);

			Assert.AreEqual (typeof (InputMethod), InputMethod.PreferredImeConversionModeProperty.OwnerType);
			Assert.AreEqual ("PreferredImeConversionMode", InputMethod.PreferredImeConversionModeProperty.Name);
			Assert.AreEqual ("PreferredImeConversionMode", InputMethod.PreferredImeConversionModeProperty.ToString());
			Assert.AreEqual (typeof (ImeConversionModeValues), InputMethod.PreferredImeConversionModeProperty.PropertyType);
			Assert.IsFalse (InputMethod.PreferredImeConversionModeProperty.ReadOnly);

			Assert.AreEqual (typeof (InputMethod), InputMethod.PreferredImeSentenceModeProperty.OwnerType);
			Assert.AreEqual ("PreferredImeSentenceMode", InputMethod.PreferredImeSentenceModeProperty.Name);
			Assert.AreEqual ("PreferredImeSentenceMode", InputMethod.PreferredImeSentenceModeProperty.ToString());
			Assert.AreEqual (typeof (ImeSentenceModeValues), InputMethod.PreferredImeSentenceModeProperty.PropertyType);
			Assert.IsFalse (InputMethod.PreferredImeSentenceModeProperty.ReadOnly);

			Assert.AreEqual (typeof (InputMethod), InputMethod.InputScopeProperty.OwnerType);
			Assert.AreEqual ("InputScope", InputMethod.InputScopeProperty.Name);
			Assert.AreEqual ("InputScope", InputMethod.InputScopeProperty.ToString());
			Assert.AreEqual (typeof (InputScope), InputMethod.InputScopeProperty.PropertyType);
			Assert.IsFalse (InputMethod.InputScopeProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Animation.Int16Animation
namespace MonoTests.System.Windows.Media.Animation {
	public partial class Int16AnimationTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (Int16Animation), Int16Animation.FromProperty.OwnerType);
			Assert.AreEqual ("From", Int16Animation.FromProperty.Name);
			Assert.AreEqual ("From", Int16Animation.FromProperty.ToString());
			Assert.AreEqual (typeof (short?), Int16Animation.FromProperty.PropertyType);
			Assert.IsFalse (Int16Animation.FromProperty.ReadOnly);

			Assert.AreEqual (typeof (Int16Animation), Int16Animation.ToProperty.OwnerType);
			Assert.AreEqual ("To", Int16Animation.ToProperty.Name);
			Assert.AreEqual ("To", Int16Animation.ToProperty.ToString());
			Assert.AreEqual (typeof (short?), Int16Animation.ToProperty.PropertyType);
			Assert.IsFalse (Int16Animation.ToProperty.ReadOnly);

			Assert.AreEqual (typeof (Int16Animation), Int16Animation.ByProperty.OwnerType);
			Assert.AreEqual ("By", Int16Animation.ByProperty.Name);
			Assert.AreEqual ("By", Int16Animation.ByProperty.ToString());
			Assert.AreEqual (typeof (short?), Int16Animation.ByProperty.PropertyType);
			Assert.IsFalse (Int16Animation.ByProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.Animation.Int16KeyFrame
namespace MonoTests.System.Windows.Media.Animation {
	public partial class Int16KeyFrameTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (Int16KeyFrame), Int16KeyFrame.KeyTimeProperty.OwnerType);
			Assert.AreEqual ("KeyTime", Int16KeyFrame.KeyTimeProperty.Name);
			Assert.AreEqual ("KeyTime", Int16KeyFrame.KeyTimeProperty.ToString());
			Assert.AreEqual (typeof (KeyTime), Int16KeyFrame.KeyTimeProperty.PropertyType);
			Assert.IsFalse (Int16KeyFrame.KeyTimeProperty.ReadOnly);

			Assert.AreEqual (typeof (Int16KeyFrame), Int16KeyFrame.ValueProperty.OwnerType);
			Assert.AreEqual ("Value", Int16KeyFrame.ValueProperty.Name);
			Assert.AreEqual ("Value", Int16KeyFrame.ValueProperty.ToString());
			Assert.AreEqual (typeof (short), Int16KeyFrame.ValueProperty.PropertyType);
			Assert.IsFalse (Int16KeyFrame.ValueProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.Animation.Int32Animation
namespace MonoTests.System.Windows.Media.Animation {
	public partial class Int32AnimationTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (Int32Animation), Int32Animation.FromProperty.OwnerType);
			Assert.AreEqual ("From", Int32Animation.FromProperty.Name);
			Assert.AreEqual ("From", Int32Animation.FromProperty.ToString());
			Assert.AreEqual (typeof (int?), Int32Animation.FromProperty.PropertyType);
			Assert.IsFalse (Int32Animation.FromProperty.ReadOnly);

			Assert.AreEqual (typeof (Int32Animation), Int32Animation.ToProperty.OwnerType);
			Assert.AreEqual ("To", Int32Animation.ToProperty.Name);
			Assert.AreEqual ("To", Int32Animation.ToProperty.ToString());
			Assert.AreEqual (typeof (int?), Int32Animation.ToProperty.PropertyType);
			Assert.IsFalse (Int32Animation.ToProperty.ReadOnly);

			Assert.AreEqual (typeof (Int32Animation), Int32Animation.ByProperty.OwnerType);
			Assert.AreEqual ("By", Int32Animation.ByProperty.Name);
			Assert.AreEqual ("By", Int32Animation.ByProperty.ToString());
			Assert.AreEqual (typeof (int?), Int32Animation.ByProperty.PropertyType);
			Assert.IsFalse (Int32Animation.ByProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.Animation.Int32KeyFrame
namespace MonoTests.System.Windows.Media.Animation {
	public partial class Int32KeyFrameTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (Int32KeyFrame), Int32KeyFrame.KeyTimeProperty.OwnerType);
			Assert.AreEqual ("KeyTime", Int32KeyFrame.KeyTimeProperty.Name);
			Assert.AreEqual ("KeyTime", Int32KeyFrame.KeyTimeProperty.ToString());
			Assert.AreEqual (typeof (KeyTime), Int32KeyFrame.KeyTimeProperty.PropertyType);
			Assert.IsFalse (Int32KeyFrame.KeyTimeProperty.ReadOnly);

			Assert.AreEqual (typeof (Int32KeyFrame), Int32KeyFrame.ValueProperty.OwnerType);
			Assert.AreEqual ("Value", Int32KeyFrame.ValueProperty.Name);
			Assert.AreEqual ("Value", Int32KeyFrame.ValueProperty.ToString());
			Assert.AreEqual (typeof (int), Int32KeyFrame.ValueProperty.PropertyType);
			Assert.IsFalse (Int32KeyFrame.ValueProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.Animation.Int64Animation
namespace MonoTests.System.Windows.Media.Animation {
	public partial class Int64AnimationTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (Int64Animation), Int64Animation.FromProperty.OwnerType);
			Assert.AreEqual ("From", Int64Animation.FromProperty.Name);
			Assert.AreEqual ("From", Int64Animation.FromProperty.ToString());
			Assert.AreEqual (typeof (long?), Int64Animation.FromProperty.PropertyType);
			Assert.IsFalse (Int64Animation.FromProperty.ReadOnly);

			Assert.AreEqual (typeof (Int64Animation), Int64Animation.ToProperty.OwnerType);
			Assert.AreEqual ("To", Int64Animation.ToProperty.Name);
			Assert.AreEqual ("To", Int64Animation.ToProperty.ToString());
			Assert.AreEqual (typeof (long?), Int64Animation.ToProperty.PropertyType);
			Assert.IsFalse (Int64Animation.ToProperty.ReadOnly);

			Assert.AreEqual (typeof (Int64Animation), Int64Animation.ByProperty.OwnerType);
			Assert.AreEqual ("By", Int64Animation.ByProperty.Name);
			Assert.AreEqual ("By", Int64Animation.ByProperty.ToString());
			Assert.AreEqual (typeof (long?), Int64Animation.ByProperty.PropertyType);
			Assert.IsFalse (Int64Animation.ByProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.Animation.Int64KeyFrame
namespace MonoTests.System.Windows.Media.Animation {
	public partial class Int64KeyFrameTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (Int64KeyFrame), Int64KeyFrame.KeyTimeProperty.OwnerType);
			Assert.AreEqual ("KeyTime", Int64KeyFrame.KeyTimeProperty.Name);
			Assert.AreEqual ("KeyTime", Int64KeyFrame.KeyTimeProperty.ToString());
			Assert.AreEqual (typeof (KeyTime), Int64KeyFrame.KeyTimeProperty.PropertyType);
			Assert.IsFalse (Int64KeyFrame.KeyTimeProperty.ReadOnly);

			Assert.AreEqual (typeof (Int64KeyFrame), Int64KeyFrame.ValueProperty.OwnerType);
			Assert.AreEqual ("Value", Int64KeyFrame.ValueProperty.Name);
			Assert.AreEqual ("Value", Int64KeyFrame.ValueProperty.ToString());
			Assert.AreEqual (typeof (long), Int64KeyFrame.ValueProperty.PropertyType);
			Assert.IsFalse (Int64KeyFrame.ValueProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.Media3D.Light
namespace MonoTests.System.Windows.Media.Media3D {
	public partial class LightTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (Light), Light.ColorProperty.OwnerType);
			Assert.AreEqual ("Color", Light.ColorProperty.Name);
			Assert.AreEqual ("Color", Light.ColorProperty.ToString());
			Assert.AreEqual (typeof (Color), Light.ColorProperty.PropertyType);
			Assert.IsFalse (Light.ColorProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.LinearGradientBrush
namespace MonoTests.System.Windows.Media {
	public partial class LinearGradientBrushTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (LinearGradientBrush), LinearGradientBrush.StartPointProperty.OwnerType);
			Assert.AreEqual ("StartPoint", LinearGradientBrush.StartPointProperty.Name);
			Assert.AreEqual ("StartPoint", LinearGradientBrush.StartPointProperty.ToString());
			Assert.AreEqual (typeof (Point), LinearGradientBrush.StartPointProperty.PropertyType);
			Assert.IsFalse (LinearGradientBrush.StartPointProperty.ReadOnly);

			Assert.AreEqual (typeof (LinearGradientBrush), LinearGradientBrush.EndPointProperty.OwnerType);
			Assert.AreEqual ("EndPoint", LinearGradientBrush.EndPointProperty.Name);
			Assert.AreEqual ("EndPoint", LinearGradientBrush.EndPointProperty.ToString());
			Assert.AreEqual (typeof (Point), LinearGradientBrush.EndPointProperty.PropertyType);
			Assert.IsFalse (LinearGradientBrush.EndPointProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Animation.LinearQuaternionKeyFrame
namespace MonoTests.System.Windows.Media.Animation {
	public partial class LinearQuaternionKeyFrameTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (LinearQuaternionKeyFrame), LinearQuaternionKeyFrame.UseShortestPathProperty.OwnerType);
			Assert.AreEqual ("UseShortestPath", LinearQuaternionKeyFrame.UseShortestPathProperty.Name);
			Assert.AreEqual ("UseShortestPath", LinearQuaternionKeyFrame.UseShortestPathProperty.ToString());
			Assert.AreEqual (typeof (bool), LinearQuaternionKeyFrame.UseShortestPathProperty.PropertyType);
			Assert.IsFalse (LinearQuaternionKeyFrame.UseShortestPathProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.LineGeometry
namespace MonoTests.System.Windows.Media {
	public partial class LineGeometryTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (LineGeometry), LineGeometry.StartPointProperty.OwnerType);
			Assert.AreEqual ("StartPoint", LineGeometry.StartPointProperty.Name);
			Assert.AreEqual ("StartPoint", LineGeometry.StartPointProperty.ToString());
			Assert.AreEqual (typeof (Point), LineGeometry.StartPointProperty.PropertyType);
			Assert.IsFalse (LineGeometry.StartPointProperty.ReadOnly);

			Assert.AreEqual (typeof (LineGeometry), LineGeometry.EndPointProperty.OwnerType);
			Assert.AreEqual ("EndPoint", LineGeometry.EndPointProperty.Name);
			Assert.AreEqual ("EndPoint", LineGeometry.EndPointProperty.ToString());
			Assert.AreEqual (typeof (Point), LineGeometry.EndPointProperty.PropertyType);
			Assert.IsFalse (LineGeometry.EndPointProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.LineSegment
namespace MonoTests.System.Windows.Media {
	public partial class LineSegmentTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (LineSegment), LineSegment.PointProperty.OwnerType);
			Assert.AreEqual ("Point", LineSegment.PointProperty.Name);
			Assert.AreEqual ("Point", LineSegment.PointProperty.ToString());
			Assert.AreEqual (typeof (Point), LineSegment.PointProperty.PropertyType);
			Assert.IsFalse (LineSegment.PointProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Media3D.MaterialGroup
namespace MonoTests.System.Windows.Media.Media3D {
	public partial class MaterialGroupTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (MaterialGroup), MaterialGroup.ChildrenProperty.OwnerType);
			Assert.AreEqual ("Children", MaterialGroup.ChildrenProperty.Name);
			Assert.AreEqual ("Children", MaterialGroup.ChildrenProperty.ToString());
			Assert.AreEqual (typeof (MaterialCollection), MaterialGroup.ChildrenProperty.PropertyType);
			Assert.IsFalse (MaterialGroup.ChildrenProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Animation.MatrixAnimationUsingPath
namespace MonoTests.System.Windows.Media.Animation {
	public partial class MatrixAnimationUsingPathTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (MatrixAnimationUsingPath), MatrixAnimationUsingPath.DoesRotateWithTangentProperty.OwnerType);
			Assert.AreEqual ("DoesRotateWithTangent", MatrixAnimationUsingPath.DoesRotateWithTangentProperty.Name);
			Assert.AreEqual ("DoesRotateWithTangent", MatrixAnimationUsingPath.DoesRotateWithTangentProperty.ToString());
			Assert.AreEqual (typeof (bool), MatrixAnimationUsingPath.DoesRotateWithTangentProperty.PropertyType);
			Assert.IsFalse (MatrixAnimationUsingPath.DoesRotateWithTangentProperty.ReadOnly);

			Assert.AreEqual (typeof (MatrixAnimationUsingPath), MatrixAnimationUsingPath.IsAngleCumulativeProperty.OwnerType);
			Assert.AreEqual ("IsAngleCumulative", MatrixAnimationUsingPath.IsAngleCumulativeProperty.Name);
			Assert.AreEqual ("IsAngleCumulative", MatrixAnimationUsingPath.IsAngleCumulativeProperty.ToString());
			Assert.AreEqual (typeof (bool), MatrixAnimationUsingPath.IsAngleCumulativeProperty.PropertyType);
			Assert.IsFalse (MatrixAnimationUsingPath.IsAngleCumulativeProperty.ReadOnly);

			Assert.AreEqual (typeof (MatrixAnimationUsingPath), MatrixAnimationUsingPath.IsOffsetCumulativeProperty.OwnerType);
			Assert.AreEqual ("IsOffsetCumulative", MatrixAnimationUsingPath.IsOffsetCumulativeProperty.Name);
			Assert.AreEqual ("IsOffsetCumulative", MatrixAnimationUsingPath.IsOffsetCumulativeProperty.ToString());
			Assert.AreEqual (typeof (bool), MatrixAnimationUsingPath.IsOffsetCumulativeProperty.PropertyType);
			Assert.IsFalse (MatrixAnimationUsingPath.IsOffsetCumulativeProperty.ReadOnly);

			Assert.AreEqual (typeof (MatrixAnimationUsingPath), MatrixAnimationUsingPath.PathGeometryProperty.OwnerType);
			Assert.AreEqual ("PathGeometry", MatrixAnimationUsingPath.PathGeometryProperty.Name);
			Assert.AreEqual ("PathGeometry", MatrixAnimationUsingPath.PathGeometryProperty.ToString());
			Assert.AreEqual (typeof (PathGeometry), MatrixAnimationUsingPath.PathGeometryProperty.PropertyType);
			Assert.IsFalse (MatrixAnimationUsingPath.PathGeometryProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Media3D.MatrixCamera
namespace MonoTests.System.Windows.Media.Media3D {
	public partial class MatrixCameraTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (MatrixCamera), MatrixCamera.ViewMatrixProperty.OwnerType);
			Assert.AreEqual ("ViewMatrix", MatrixCamera.ViewMatrixProperty.Name);
			Assert.AreEqual ("ViewMatrix", MatrixCamera.ViewMatrixProperty.ToString());
			Assert.AreEqual (typeof (Matrix3D), MatrixCamera.ViewMatrixProperty.PropertyType);
			Assert.IsFalse (MatrixCamera.ViewMatrixProperty.ReadOnly);

			Assert.AreEqual (typeof (MatrixCamera), MatrixCamera.ProjectionMatrixProperty.OwnerType);
			Assert.AreEqual ("ProjectionMatrix", MatrixCamera.ProjectionMatrixProperty.Name);
			Assert.AreEqual ("ProjectionMatrix", MatrixCamera.ProjectionMatrixProperty.ToString());
			Assert.AreEqual (typeof (Matrix3D), MatrixCamera.ProjectionMatrixProperty.PropertyType);
			Assert.IsFalse (MatrixCamera.ProjectionMatrixProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Animation.MatrixKeyFrame
namespace MonoTests.System.Windows.Media.Animation {
	public partial class MatrixKeyFrameTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (MatrixKeyFrame), MatrixKeyFrame.KeyTimeProperty.OwnerType);
			Assert.AreEqual ("KeyTime", MatrixKeyFrame.KeyTimeProperty.Name);
			Assert.AreEqual ("KeyTime", MatrixKeyFrame.KeyTimeProperty.ToString());
			Assert.AreEqual (typeof (KeyTime), MatrixKeyFrame.KeyTimeProperty.PropertyType);
			Assert.IsFalse (MatrixKeyFrame.KeyTimeProperty.ReadOnly);

			Assert.AreEqual (typeof (MatrixKeyFrame), MatrixKeyFrame.ValueProperty.OwnerType);
			Assert.AreEqual ("Value", MatrixKeyFrame.ValueProperty.Name);
			Assert.AreEqual ("Value", MatrixKeyFrame.ValueProperty.ToString());
			Assert.AreEqual (typeof (Matrix), MatrixKeyFrame.ValueProperty.PropertyType);
			Assert.IsFalse (MatrixKeyFrame.ValueProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.MatrixTransform
namespace MonoTests.System.Windows.Media {
	public partial class MatrixTransformTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (MatrixTransform), MatrixTransform.MatrixProperty.OwnerType);
			Assert.AreEqual ("Matrix", MatrixTransform.MatrixProperty.Name);
			Assert.AreEqual ("Matrix", MatrixTransform.MatrixProperty.ToString());
			Assert.AreEqual (typeof (Matrix), MatrixTransform.MatrixProperty.PropertyType);
			Assert.IsFalse (MatrixTransform.MatrixProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Media3D.MatrixTransform3D
namespace MonoTests.System.Windows.Media.Media3D {
	public partial class MatrixTransform3DTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (MatrixTransform3D), MatrixTransform3D.MatrixProperty.OwnerType);
			Assert.AreEqual ("Matrix", MatrixTransform3D.MatrixProperty.Name);
			Assert.AreEqual ("Matrix", MatrixTransform3D.MatrixProperty.ToString());
			Assert.AreEqual (typeof (Matrix3D), MatrixTransform3D.MatrixProperty.PropertyType);
			Assert.IsFalse (MatrixTransform3D.MatrixProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.MediaTimeline
namespace MonoTests.System.Windows.Media {
	public partial class MediaTimelineTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (MediaTimeline), MediaTimeline.SourceProperty.OwnerType);
			Assert.AreEqual ("Source", MediaTimeline.SourceProperty.Name);
			Assert.AreEqual ("Source", MediaTimeline.SourceProperty.ToString());
			Assert.AreEqual (typeof (System.Uri), MediaTimeline.SourceProperty.PropertyType);
			Assert.IsFalse (MediaTimeline.SourceProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Media3D.MeshGeometry3D
namespace MonoTests.System.Windows.Media.Media3D {
	public partial class MeshGeometry3DTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (MeshGeometry3D), MeshGeometry3D.PositionsProperty.OwnerType);
			Assert.AreEqual ("Positions", MeshGeometry3D.PositionsProperty.Name);
			Assert.AreEqual ("Positions", MeshGeometry3D.PositionsProperty.ToString());
			Assert.AreEqual (typeof (Point3DCollection), MeshGeometry3D.PositionsProperty.PropertyType);
			Assert.IsFalse (MeshGeometry3D.PositionsProperty.ReadOnly);

			Assert.AreEqual (typeof (MeshGeometry3D), MeshGeometry3D.NormalsProperty.OwnerType);
			Assert.AreEqual ("Normals", MeshGeometry3D.NormalsProperty.Name);
			Assert.AreEqual ("Normals", MeshGeometry3D.NormalsProperty.ToString());
			Assert.AreEqual (typeof (Vector3DCollection), MeshGeometry3D.NormalsProperty.PropertyType);
			Assert.IsFalse (MeshGeometry3D.NormalsProperty.ReadOnly);

			Assert.AreEqual (typeof (MeshGeometry3D), MeshGeometry3D.TextureCoordinatesProperty.OwnerType);
			Assert.AreEqual ("TextureCoordinates", MeshGeometry3D.TextureCoordinatesProperty.Name);
			Assert.AreEqual ("TextureCoordinates", MeshGeometry3D.TextureCoordinatesProperty.ToString());
			Assert.AreEqual (typeof (PointCollection), MeshGeometry3D.TextureCoordinatesProperty.PropertyType);
			Assert.IsFalse (MeshGeometry3D.TextureCoordinatesProperty.ReadOnly);

			Assert.AreEqual (typeof (MeshGeometry3D), MeshGeometry3D.TriangleIndicesProperty.OwnerType);
			Assert.AreEqual ("TriangleIndices", MeshGeometry3D.TriangleIndicesProperty.Name);
			Assert.AreEqual ("TriangleIndices", MeshGeometry3D.TriangleIndicesProperty.ToString());
			Assert.AreEqual (typeof (Int32Collection), MeshGeometry3D.TriangleIndicesProperty.PropertyType);
			Assert.IsFalse (MeshGeometry3D.TriangleIndicesProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Media3D.Model3D
namespace MonoTests.System.Windows.Media.Media3D {
	public partial class Model3DTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (Model3D), Model3D.TransformProperty.OwnerType);
			Assert.AreEqual ("Transform", Model3D.TransformProperty.Name);
			Assert.AreEqual ("Transform", Model3D.TransformProperty.ToString());
			Assert.AreEqual (typeof (Transform3D), Model3D.TransformProperty.PropertyType);
			Assert.IsFalse (Model3D.TransformProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Media3D.Model3DGroup
namespace MonoTests.System.Windows.Media.Media3D {
	public partial class Model3DGroupTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (Model3DGroup), Model3DGroup.ChildrenProperty.OwnerType);
			Assert.AreEqual ("Children", Model3DGroup.ChildrenProperty.Name);
			Assert.AreEqual ("Children", Model3DGroup.ChildrenProperty.ToString());
			Assert.AreEqual (typeof (Model3DCollection), Model3DGroup.ChildrenProperty.PropertyType);
			Assert.IsFalse (Model3DGroup.ChildrenProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Media3D.ModelUIElement3D
namespace MonoTests.System.Windows.Media.Media3D {
	public partial class ModelUIElement3DTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (ModelUIElement3D), ModelUIElement3D.ModelProperty.OwnerType);
			Assert.AreEqual ("Model", ModelUIElement3D.ModelProperty.Name);
			Assert.AreEqual ("Model", ModelUIElement3D.ModelProperty.ToString());
			Assert.AreEqual (typeof (Model3D), ModelUIElement3D.ModelProperty.PropertyType);
			Assert.IsFalse (ModelUIElement3D.ModelProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Media3D.ModelVisual3D
namespace MonoTests.System.Windows.Media.Media3D {
	public partial class ModelVisual3DTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (ModelVisual3D), ModelVisual3D.ContentProperty.OwnerType);
			Assert.AreEqual ("Content", ModelVisual3D.ContentProperty.Name);
			Assert.AreEqual ("Content", ModelVisual3D.ContentProperty.ToString());
			Assert.AreEqual (typeof (Model3D), ModelVisual3D.ContentProperty.PropertyType);
			Assert.IsFalse (ModelVisual3D.ContentProperty.ReadOnly);

			Assert.AreSame (ModelVisual3D.TransformProperty, Visual3D.TransformProperty);
#endif
		}
	}
}
//   Type: System.Windows.Media.NumberSubstitution
namespace MonoTests.System.Windows.Media {
	public partial class NumberSubstitutionTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (NumberSubstitution), NumberSubstitution.CultureSourceProperty.OwnerType);
			Assert.AreEqual ("CultureSource", NumberSubstitution.CultureSourceProperty.Name);
			Assert.AreEqual ("CultureSource", NumberSubstitution.CultureSourceProperty.ToString());
			Assert.AreEqual (typeof (NumberCultureSource), NumberSubstitution.CultureSourceProperty.PropertyType);
			Assert.IsFalse (NumberSubstitution.CultureSourceProperty.ReadOnly);

			Assert.AreEqual (typeof (NumberSubstitution), NumberSubstitution.CultureOverrideProperty.OwnerType);
			Assert.AreEqual ("CultureOverride", NumberSubstitution.CultureOverrideProperty.Name);
			Assert.AreEqual ("CultureOverride", NumberSubstitution.CultureOverrideProperty.ToString());
			Assert.AreEqual (typeof (System.Globalization.CultureInfo), NumberSubstitution.CultureOverrideProperty.PropertyType);
			Assert.IsFalse (NumberSubstitution.CultureOverrideProperty.ReadOnly);

			Assert.AreEqual (typeof (NumberSubstitution), NumberSubstitution.SubstitutionProperty.OwnerType);
			Assert.AreEqual ("Substitution", NumberSubstitution.SubstitutionProperty.Name);
			Assert.AreEqual ("Substitution", NumberSubstitution.SubstitutionProperty.ToString());
			Assert.AreEqual (typeof (NumberSubstitutionMethod), NumberSubstitution.SubstitutionProperty.PropertyType);
			Assert.IsFalse (NumberSubstitution.SubstitutionProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Animation.ObjectKeyFrame
namespace MonoTests.System.Windows.Media.Animation {
	public partial class ObjectKeyFrameTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (ObjectKeyFrame), ObjectKeyFrame.KeyTimeProperty.OwnerType);
			Assert.AreEqual ("KeyTime", ObjectKeyFrame.KeyTimeProperty.Name);
			Assert.AreEqual ("KeyTime", ObjectKeyFrame.KeyTimeProperty.ToString());
			Assert.AreEqual (typeof (KeyTime), ObjectKeyFrame.KeyTimeProperty.PropertyType);
			Assert.IsFalse (ObjectKeyFrame.KeyTimeProperty.ReadOnly);

			Assert.AreEqual (typeof (ObjectKeyFrame), ObjectKeyFrame.ValueProperty.OwnerType);
			Assert.AreEqual ("Value", ObjectKeyFrame.ValueProperty.Name);
			Assert.AreEqual ("Value", ObjectKeyFrame.ValueProperty.ToString());
			Assert.AreEqual (typeof (object), ObjectKeyFrame.ValueProperty.PropertyType);
			Assert.IsFalse (ObjectKeyFrame.ValueProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.Media3D.OrthographicCamera
namespace MonoTests.System.Windows.Media.Media3D {
	public partial class OrthographicCameraTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (OrthographicCamera), OrthographicCamera.WidthProperty.OwnerType);
			Assert.AreEqual ("Width", OrthographicCamera.WidthProperty.Name);
			Assert.AreEqual ("Width", OrthographicCamera.WidthProperty.ToString());
			Assert.AreEqual (typeof (double), OrthographicCamera.WidthProperty.PropertyType);
			Assert.IsFalse (OrthographicCamera.WidthProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Effects.OuterGlowBitmapEffect
namespace MonoTests.System.Windows.Media.Effects {
	public partial class OuterGlowBitmapEffectTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (OuterGlowBitmapEffect), OuterGlowBitmapEffect.GlowColorProperty.OwnerType);
			Assert.AreEqual ("GlowColor", OuterGlowBitmapEffect.GlowColorProperty.Name);
			Assert.AreEqual ("GlowColor", OuterGlowBitmapEffect.GlowColorProperty.ToString());
			Assert.AreEqual (typeof (Color), OuterGlowBitmapEffect.GlowColorProperty.PropertyType);
			Assert.IsFalse (OuterGlowBitmapEffect.GlowColorProperty.ReadOnly);

			Assert.AreEqual (typeof (OuterGlowBitmapEffect), OuterGlowBitmapEffect.GlowSizeProperty.OwnerType);
			Assert.AreEqual ("GlowSize", OuterGlowBitmapEffect.GlowSizeProperty.Name);
			Assert.AreEqual ("GlowSize", OuterGlowBitmapEffect.GlowSizeProperty.ToString());
			Assert.AreEqual (typeof (double), OuterGlowBitmapEffect.GlowSizeProperty.PropertyType);
			Assert.IsFalse (OuterGlowBitmapEffect.GlowSizeProperty.ReadOnly);

			Assert.AreEqual (typeof (OuterGlowBitmapEffect), OuterGlowBitmapEffect.NoiseProperty.OwnerType);
			Assert.AreEqual ("Noise", OuterGlowBitmapEffect.NoiseProperty.Name);
			Assert.AreEqual ("Noise", OuterGlowBitmapEffect.NoiseProperty.ToString());
			Assert.AreEqual (typeof (double), OuterGlowBitmapEffect.NoiseProperty.PropertyType);
			Assert.IsFalse (OuterGlowBitmapEffect.NoiseProperty.ReadOnly);

			Assert.AreEqual (typeof (OuterGlowBitmapEffect), OuterGlowBitmapEffect.OpacityProperty.OwnerType);
			Assert.AreEqual ("Opacity", OuterGlowBitmapEffect.OpacityProperty.Name);
			Assert.AreEqual ("Opacity", OuterGlowBitmapEffect.OpacityProperty.ToString());
			Assert.AreEqual (typeof (double), OuterGlowBitmapEffect.OpacityProperty.PropertyType);
			Assert.IsFalse (OuterGlowBitmapEffect.OpacityProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Animation.ParallelTimeline
namespace MonoTests.System.Windows.Media.Animation {
	public partial class ParallelTimelineTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (ParallelTimeline), ParallelTimeline.SlipBehaviorProperty.OwnerType);
			Assert.AreEqual ("SlipBehavior", ParallelTimeline.SlipBehaviorProperty.Name);
			Assert.AreEqual ("SlipBehavior", ParallelTimeline.SlipBehaviorProperty.ToString());
			Assert.AreEqual (typeof (SlipBehavior), ParallelTimeline.SlipBehaviorProperty.PropertyType);
			Assert.IsFalse (ParallelTimeline.SlipBehaviorProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.PathFigure
namespace MonoTests.System.Windows.Media {
	public partial class PathFigureTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (PathFigure), PathFigure.StartPointProperty.OwnerType);
			Assert.AreEqual ("StartPoint", PathFigure.StartPointProperty.Name);
			Assert.AreEqual ("StartPoint", PathFigure.StartPointProperty.ToString());
			Assert.AreEqual (typeof (Point), PathFigure.StartPointProperty.PropertyType);
			Assert.IsFalse (PathFigure.StartPointProperty.ReadOnly);

			Assert.AreEqual (typeof (PathFigure), PathFigure.IsFilledProperty.OwnerType);
			Assert.AreEqual ("IsFilled", PathFigure.IsFilledProperty.Name);
			Assert.AreEqual ("IsFilled", PathFigure.IsFilledProperty.ToString());
			Assert.AreEqual (typeof (bool), PathFigure.IsFilledProperty.PropertyType);
			Assert.IsFalse (PathFigure.IsFilledProperty.ReadOnly);

			Assert.AreEqual (typeof (PathFigure), PathFigure.SegmentsProperty.OwnerType);
			Assert.AreEqual ("Segments", PathFigure.SegmentsProperty.Name);
			Assert.AreEqual ("Segments", PathFigure.SegmentsProperty.ToString());
			Assert.AreEqual (typeof (PathSegmentCollection), PathFigure.SegmentsProperty.PropertyType);
			Assert.IsFalse (PathFigure.SegmentsProperty.ReadOnly);

			Assert.AreEqual (typeof (PathFigure), PathFigure.IsClosedProperty.OwnerType);
			Assert.AreEqual ("IsClosed", PathFigure.IsClosedProperty.Name);
			Assert.AreEqual ("IsClosed", PathFigure.IsClosedProperty.ToString());
			Assert.AreEqual (typeof (bool), PathFigure.IsClosedProperty.PropertyType);
			Assert.IsFalse (PathFigure.IsClosedProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.PathGeometry
namespace MonoTests.System.Windows.Media {
	public partial class PathGeometryTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (PathGeometry), PathGeometry.FillRuleProperty.OwnerType);
			Assert.AreEqual ("FillRule", PathGeometry.FillRuleProperty.Name);
			Assert.AreEqual ("FillRule", PathGeometry.FillRuleProperty.ToString());
			Assert.AreEqual (typeof (FillRule), PathGeometry.FillRuleProperty.PropertyType);
			Assert.IsFalse (PathGeometry.FillRuleProperty.ReadOnly);

			Assert.AreEqual (typeof (PathGeometry), PathGeometry.FiguresProperty.OwnerType);
			Assert.AreEqual ("Figures", PathGeometry.FiguresProperty.Name);
			Assert.AreEqual ("Figures", PathGeometry.FiguresProperty.ToString());
			Assert.AreEqual (typeof (PathFigureCollection), PathGeometry.FiguresProperty.PropertyType);
			Assert.IsFalse (PathGeometry.FiguresProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.PathSegment
namespace MonoTests.System.Windows.Media {
	public partial class PathSegmentTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (PathSegment), PathSegment.IsStrokedProperty.OwnerType);
			Assert.AreEqual ("IsStroked", PathSegment.IsStrokedProperty.Name);
			Assert.AreEqual ("IsStroked", PathSegment.IsStrokedProperty.ToString());
			Assert.AreEqual (typeof (bool), PathSegment.IsStrokedProperty.PropertyType);
			Assert.IsFalse (PathSegment.IsStrokedProperty.ReadOnly);

			Assert.AreEqual (typeof (PathSegment), PathSegment.IsSmoothJoinProperty.OwnerType);
			Assert.AreEqual ("IsSmoothJoin", PathSegment.IsSmoothJoinProperty.Name);
			Assert.AreEqual ("IsSmoothJoin", PathSegment.IsSmoothJoinProperty.ToString());
			Assert.AreEqual (typeof (bool), PathSegment.IsSmoothJoinProperty.PropertyType);
			Assert.IsFalse (PathSegment.IsSmoothJoinProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Pen
namespace MonoTests.System.Windows.Media {
	public partial class PenTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (Pen), Pen.BrushProperty.OwnerType);
			Assert.AreEqual ("Brush", Pen.BrushProperty.Name);
			Assert.AreEqual ("Brush", Pen.BrushProperty.ToString());
			Assert.AreEqual (typeof (Brush), Pen.BrushProperty.PropertyType);
			Assert.IsFalse (Pen.BrushProperty.ReadOnly);

			Assert.AreEqual (typeof (Pen), Pen.ThicknessProperty.OwnerType);
			Assert.AreEqual ("Thickness", Pen.ThicknessProperty.Name);
			Assert.AreEqual ("Thickness", Pen.ThicknessProperty.ToString());
			Assert.AreEqual (typeof (double), Pen.ThicknessProperty.PropertyType);
			Assert.IsFalse (Pen.ThicknessProperty.ReadOnly);

			Assert.AreEqual (typeof (Pen), Pen.StartLineCapProperty.OwnerType);
			Assert.AreEqual ("StartLineCap", Pen.StartLineCapProperty.Name);
			Assert.AreEqual ("StartLineCap", Pen.StartLineCapProperty.ToString());
			Assert.AreEqual (typeof (PenLineCap), Pen.StartLineCapProperty.PropertyType);
			Assert.IsFalse (Pen.StartLineCapProperty.ReadOnly);

			Assert.AreEqual (typeof (Pen), Pen.EndLineCapProperty.OwnerType);
			Assert.AreEqual ("EndLineCap", Pen.EndLineCapProperty.Name);
			Assert.AreEqual ("EndLineCap", Pen.EndLineCapProperty.ToString());
			Assert.AreEqual (typeof (PenLineCap), Pen.EndLineCapProperty.PropertyType);
			Assert.IsFalse (Pen.EndLineCapProperty.ReadOnly);

			Assert.AreEqual (typeof (Pen), Pen.DashCapProperty.OwnerType);
			Assert.AreEqual ("DashCap", Pen.DashCapProperty.Name);
			Assert.AreEqual ("DashCap", Pen.DashCapProperty.ToString());
			Assert.AreEqual (typeof (PenLineCap), Pen.DashCapProperty.PropertyType);
			Assert.IsFalse (Pen.DashCapProperty.ReadOnly);

			Assert.AreEqual (typeof (Pen), Pen.LineJoinProperty.OwnerType);
			Assert.AreEqual ("LineJoin", Pen.LineJoinProperty.Name);
			Assert.AreEqual ("LineJoin", Pen.LineJoinProperty.ToString());
			Assert.AreEqual (typeof (PenLineJoin), Pen.LineJoinProperty.PropertyType);
			Assert.IsFalse (Pen.LineJoinProperty.ReadOnly);

			Assert.AreEqual (typeof (Pen), Pen.MiterLimitProperty.OwnerType);
			Assert.AreEqual ("MiterLimit", Pen.MiterLimitProperty.Name);
			Assert.AreEqual ("MiterLimit", Pen.MiterLimitProperty.ToString());
			Assert.AreEqual (typeof (double), Pen.MiterLimitProperty.PropertyType);
			Assert.IsFalse (Pen.MiterLimitProperty.ReadOnly);

			Assert.AreEqual (typeof (Pen), Pen.DashStyleProperty.OwnerType);
			Assert.AreEqual ("DashStyle", Pen.DashStyleProperty.Name);
			Assert.AreEqual ("DashStyle", Pen.DashStyleProperty.ToString());
			Assert.AreEqual (typeof (DashStyle), Pen.DashStyleProperty.PropertyType);
			Assert.IsFalse (Pen.DashStyleProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Media3D.PerspectiveCamera
namespace MonoTests.System.Windows.Media.Media3D {
	public partial class PerspectiveCameraTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (PerspectiveCamera), PerspectiveCamera.FieldOfViewProperty.OwnerType);
			Assert.AreEqual ("FieldOfView", PerspectiveCamera.FieldOfViewProperty.Name);
			Assert.AreEqual ("FieldOfView", PerspectiveCamera.FieldOfViewProperty.ToString());
			Assert.AreEqual (typeof (double), PerspectiveCamera.FieldOfViewProperty.PropertyType);
			Assert.IsFalse (PerspectiveCamera.FieldOfViewProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Effects.PixelShader
namespace MonoTests.System.Windows.Media.Effects {
	public partial class PixelShaderTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (PixelShader), PixelShader.UriSourceProperty.OwnerType);
			Assert.AreEqual ("UriSource", PixelShader.UriSourceProperty.Name);
			Assert.AreEqual ("UriSource", PixelShader.UriSourceProperty.ToString());
			Assert.AreEqual (typeof (System.Uri), PixelShader.UriSourceProperty.PropertyType);
			Assert.IsFalse (PixelShader.UriSourceProperty.ReadOnly);

			Assert.AreEqual (typeof (PixelShader), PixelShader.ShaderRenderModeProperty.OwnerType);
			Assert.AreEqual ("ShaderRenderMode", PixelShader.ShaderRenderModeProperty.Name);
			Assert.AreEqual ("ShaderRenderMode", PixelShader.ShaderRenderModeProperty.ToString());
			Assert.AreEqual (typeof (ShaderRenderMode), PixelShader.ShaderRenderModeProperty.PropertyType);
			Assert.IsFalse (PixelShader.ShaderRenderModeProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Animation.Point3DAnimation
namespace MonoTests.System.Windows.Media.Animation {
	public partial class Point3DAnimationTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (Point3DAnimation), Point3DAnimation.FromProperty.OwnerType);
			Assert.AreEqual ("From", Point3DAnimation.FromProperty.Name);
			Assert.AreEqual ("From", Point3DAnimation.FromProperty.ToString());
			Assert.AreEqual (typeof (Point3D?), Point3DAnimation.FromProperty.PropertyType);
			Assert.IsFalse (Point3DAnimation.FromProperty.ReadOnly);

			Assert.AreEqual (typeof (Point3DAnimation), Point3DAnimation.ToProperty.OwnerType);
			Assert.AreEqual ("To", Point3DAnimation.ToProperty.Name);
			Assert.AreEqual ("To", Point3DAnimation.ToProperty.ToString());
			Assert.AreEqual (typeof (Point3D?), Point3DAnimation.ToProperty.PropertyType);
			Assert.IsFalse (Point3DAnimation.ToProperty.ReadOnly);

			Assert.AreEqual (typeof (Point3DAnimation), Point3DAnimation.ByProperty.OwnerType);
			Assert.AreEqual ("By", Point3DAnimation.ByProperty.Name);
			Assert.AreEqual ("By", Point3DAnimation.ByProperty.ToString());
			Assert.AreEqual (typeof (Point3D?), Point3DAnimation.ByProperty.PropertyType);
			Assert.IsFalse (Point3DAnimation.ByProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Animation.Point3DKeyFrame
namespace MonoTests.System.Windows.Media.Animation {
	public partial class Point3DKeyFrameTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (Point3DKeyFrame), Point3DKeyFrame.KeyTimeProperty.OwnerType);
			Assert.AreEqual ("KeyTime", Point3DKeyFrame.KeyTimeProperty.Name);
			Assert.AreEqual ("KeyTime", Point3DKeyFrame.KeyTimeProperty.ToString());
			Assert.AreEqual (typeof (KeyTime), Point3DKeyFrame.KeyTimeProperty.PropertyType);
			Assert.IsFalse (Point3DKeyFrame.KeyTimeProperty.ReadOnly);

			Assert.AreEqual (typeof (Point3DKeyFrame), Point3DKeyFrame.ValueProperty.OwnerType);
			Assert.AreEqual ("Value", Point3DKeyFrame.ValueProperty.Name);
			Assert.AreEqual ("Value", Point3DKeyFrame.ValueProperty.ToString());
			Assert.AreEqual (typeof (Point3D), Point3DKeyFrame.ValueProperty.PropertyType);
			Assert.IsFalse (Point3DKeyFrame.ValueProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Animation.PointAnimation
namespace MonoTests.System.Windows.Media.Animation {
	public partial class PointAnimationTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (PointAnimation), PointAnimation.FromProperty.OwnerType);
			Assert.AreEqual ("From", PointAnimation.FromProperty.Name);
			Assert.AreEqual ("From", PointAnimation.FromProperty.ToString());
			Assert.AreEqual (typeof (Point?), PointAnimation.FromProperty.PropertyType);
			Assert.IsFalse (PointAnimation.FromProperty.ReadOnly);

			Assert.AreEqual (typeof (PointAnimation), PointAnimation.ToProperty.OwnerType);
			Assert.AreEqual ("To", PointAnimation.ToProperty.Name);
			Assert.AreEqual ("To", PointAnimation.ToProperty.ToString());
			Assert.AreEqual (typeof (Point?), PointAnimation.ToProperty.PropertyType);
			Assert.IsFalse (PointAnimation.ToProperty.ReadOnly);

			Assert.AreEqual (typeof (PointAnimation), PointAnimation.ByProperty.OwnerType);
			Assert.AreEqual ("By", PointAnimation.ByProperty.Name);
			Assert.AreEqual ("By", PointAnimation.ByProperty.ToString());
			Assert.AreEqual (typeof (Point?), PointAnimation.ByProperty.PropertyType);
			Assert.IsFalse (PointAnimation.ByProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.Animation.PointAnimationUsingPath
namespace MonoTests.System.Windows.Media.Animation {
	public partial class PointAnimationUsingPathTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (PointAnimationUsingPath), PointAnimationUsingPath.PathGeometryProperty.OwnerType);
			Assert.AreEqual ("PathGeometry", PointAnimationUsingPath.PathGeometryProperty.Name);
			Assert.AreEqual ("PathGeometry", PointAnimationUsingPath.PathGeometryProperty.ToString());
			Assert.AreEqual (typeof (PathGeometry), PointAnimationUsingPath.PathGeometryProperty.PropertyType);
			Assert.IsFalse (PointAnimationUsingPath.PathGeometryProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Animation.PointKeyFrame
namespace MonoTests.System.Windows.Media.Animation {
	public partial class PointKeyFrameTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (PointKeyFrame), PointKeyFrame.KeyTimeProperty.OwnerType);
			Assert.AreEqual ("KeyTime", PointKeyFrame.KeyTimeProperty.Name);
			Assert.AreEqual ("KeyTime", PointKeyFrame.KeyTimeProperty.ToString());
			Assert.AreEqual (typeof (KeyTime), PointKeyFrame.KeyTimeProperty.PropertyType);
			Assert.IsFalse (PointKeyFrame.KeyTimeProperty.ReadOnly);

			Assert.AreEqual (typeof (PointKeyFrame), PointKeyFrame.ValueProperty.OwnerType);
			Assert.AreEqual ("Value", PointKeyFrame.ValueProperty.Name);
			Assert.AreEqual ("Value", PointKeyFrame.ValueProperty.ToString());
			Assert.AreEqual (typeof (Point), PointKeyFrame.ValueProperty.PropertyType);
			Assert.IsFalse (PointKeyFrame.ValueProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.Media3D.PointLightBase
namespace MonoTests.System.Windows.Media.Media3D {
	public partial class PointLightBaseTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (PointLightBase), PointLightBase.PositionProperty.OwnerType);
			Assert.AreEqual ("Position", PointLightBase.PositionProperty.Name);
			Assert.AreEqual ("Position", PointLightBase.PositionProperty.ToString());
			Assert.AreEqual (typeof (Point3D), PointLightBase.PositionProperty.PropertyType);
			Assert.IsFalse (PointLightBase.PositionProperty.ReadOnly);

			Assert.AreEqual (typeof (PointLightBase), PointLightBase.RangeProperty.OwnerType);
			Assert.AreEqual ("Range", PointLightBase.RangeProperty.Name);
			Assert.AreEqual ("Range", PointLightBase.RangeProperty.ToString());
			Assert.AreEqual (typeof (double), PointLightBase.RangeProperty.PropertyType);
			Assert.IsFalse (PointLightBase.RangeProperty.ReadOnly);

			Assert.AreEqual (typeof (PointLightBase), PointLightBase.ConstantAttenuationProperty.OwnerType);
			Assert.AreEqual ("ConstantAttenuation", PointLightBase.ConstantAttenuationProperty.Name);
			Assert.AreEqual ("ConstantAttenuation", PointLightBase.ConstantAttenuationProperty.ToString());
			Assert.AreEqual (typeof (double), PointLightBase.ConstantAttenuationProperty.PropertyType);
			Assert.IsFalse (PointLightBase.ConstantAttenuationProperty.ReadOnly);

			Assert.AreEqual (typeof (PointLightBase), PointLightBase.LinearAttenuationProperty.OwnerType);
			Assert.AreEqual ("LinearAttenuation", PointLightBase.LinearAttenuationProperty.Name);
			Assert.AreEqual ("LinearAttenuation", PointLightBase.LinearAttenuationProperty.ToString());
			Assert.AreEqual (typeof (double), PointLightBase.LinearAttenuationProperty.PropertyType);
			Assert.IsFalse (PointLightBase.LinearAttenuationProperty.ReadOnly);

			Assert.AreEqual (typeof (PointLightBase), PointLightBase.QuadraticAttenuationProperty.OwnerType);
			Assert.AreEqual ("QuadraticAttenuation", PointLightBase.QuadraticAttenuationProperty.Name);
			Assert.AreEqual ("QuadraticAttenuation", PointLightBase.QuadraticAttenuationProperty.ToString());
			Assert.AreEqual (typeof (double), PointLightBase.QuadraticAttenuationProperty.PropertyType);
			Assert.IsFalse (PointLightBase.QuadraticAttenuationProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.PolyBezierSegment
namespace MonoTests.System.Windows.Media {
	public partial class PolyBezierSegmentTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (PolyBezierSegment), PolyBezierSegment.PointsProperty.OwnerType);
			Assert.AreEqual ("Points", PolyBezierSegment.PointsProperty.Name);
			Assert.AreEqual ("Points", PolyBezierSegment.PointsProperty.ToString());
			Assert.AreEqual (typeof (PointCollection), PolyBezierSegment.PointsProperty.PropertyType);
			Assert.IsFalse (PolyBezierSegment.PointsProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.PolyLineSegment
namespace MonoTests.System.Windows.Media {
	public partial class PolyLineSegmentTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (PolyLineSegment), PolyLineSegment.PointsProperty.OwnerType);
			Assert.AreEqual ("Points", PolyLineSegment.PointsProperty.Name);
			Assert.AreEqual ("Points", PolyLineSegment.PointsProperty.ToString());
			Assert.AreEqual (typeof (PointCollection), PolyLineSegment.PointsProperty.PropertyType);
			Assert.IsFalse (PolyLineSegment.PointsProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.PolyQuadraticBezierSegment
namespace MonoTests.System.Windows.Media {
	public partial class PolyQuadraticBezierSegmentTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (PolyQuadraticBezierSegment), PolyQuadraticBezierSegment.PointsProperty.OwnerType);
			Assert.AreEqual ("Points", PolyQuadraticBezierSegment.PointsProperty.Name);
			Assert.AreEqual ("Points", PolyQuadraticBezierSegment.PointsProperty.ToString());
			Assert.AreEqual (typeof (PointCollection), PolyQuadraticBezierSegment.PointsProperty.PropertyType);
			Assert.IsFalse (PolyQuadraticBezierSegment.PointsProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Media3D.ProjectionCamera
namespace MonoTests.System.Windows.Media.Media3D {
	public partial class ProjectionCameraTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (ProjectionCamera), ProjectionCamera.NearPlaneDistanceProperty.OwnerType);
			Assert.AreEqual ("NearPlaneDistance", ProjectionCamera.NearPlaneDistanceProperty.Name);
			Assert.AreEqual ("NearPlaneDistance", ProjectionCamera.NearPlaneDistanceProperty.ToString());
			Assert.AreEqual (typeof (double), ProjectionCamera.NearPlaneDistanceProperty.PropertyType);
			Assert.IsFalse (ProjectionCamera.NearPlaneDistanceProperty.ReadOnly);

			Assert.AreEqual (typeof (ProjectionCamera), ProjectionCamera.FarPlaneDistanceProperty.OwnerType);
			Assert.AreEqual ("FarPlaneDistance", ProjectionCamera.FarPlaneDistanceProperty.Name);
			Assert.AreEqual ("FarPlaneDistance", ProjectionCamera.FarPlaneDistanceProperty.ToString());
			Assert.AreEqual (typeof (double), ProjectionCamera.FarPlaneDistanceProperty.PropertyType);
			Assert.IsFalse (ProjectionCamera.FarPlaneDistanceProperty.ReadOnly);

			Assert.AreEqual (typeof (ProjectionCamera), ProjectionCamera.PositionProperty.OwnerType);
			Assert.AreEqual ("Position", ProjectionCamera.PositionProperty.Name);
			Assert.AreEqual ("Position", ProjectionCamera.PositionProperty.ToString());
			Assert.AreEqual (typeof (Point3D), ProjectionCamera.PositionProperty.PropertyType);
			Assert.IsFalse (ProjectionCamera.PositionProperty.ReadOnly);

			Assert.AreEqual (typeof (ProjectionCamera), ProjectionCamera.LookDirectionProperty.OwnerType);
			Assert.AreEqual ("LookDirection", ProjectionCamera.LookDirectionProperty.Name);
			Assert.AreEqual ("LookDirection", ProjectionCamera.LookDirectionProperty.ToString());
			Assert.AreEqual (typeof (Vector3D), ProjectionCamera.LookDirectionProperty.PropertyType);
			Assert.IsFalse (ProjectionCamera.LookDirectionProperty.ReadOnly);

			Assert.AreEqual (typeof (ProjectionCamera), ProjectionCamera.UpDirectionProperty.OwnerType);
			Assert.AreEqual ("UpDirection", ProjectionCamera.UpDirectionProperty.Name);
			Assert.AreEqual ("UpDirection", ProjectionCamera.UpDirectionProperty.ToString());
			Assert.AreEqual (typeof (Vector3D), ProjectionCamera.UpDirectionProperty.PropertyType);
			Assert.IsFalse (ProjectionCamera.UpDirectionProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.QuadraticBezierSegment
namespace MonoTests.System.Windows.Media {
	public partial class QuadraticBezierSegmentTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (QuadraticBezierSegment), QuadraticBezierSegment.Point1Property.OwnerType);
			Assert.AreEqual ("Point1", QuadraticBezierSegment.Point1Property.Name);
			Assert.AreEqual ("Point1", QuadraticBezierSegment.Point1Property.ToString());
			Assert.AreEqual (typeof (Point), QuadraticBezierSegment.Point1Property.PropertyType);
			Assert.IsFalse (QuadraticBezierSegment.Point1Property.ReadOnly);

			Assert.AreEqual (typeof (QuadraticBezierSegment), QuadraticBezierSegment.Point2Property.OwnerType);
			Assert.AreEqual ("Point2", QuadraticBezierSegment.Point2Property.Name);
			Assert.AreEqual ("Point2", QuadraticBezierSegment.Point2Property.ToString());
			Assert.AreEqual (typeof (Point), QuadraticBezierSegment.Point2Property.PropertyType);
			Assert.IsFalse (QuadraticBezierSegment.Point2Property.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Animation.QuaternionAnimation
namespace MonoTests.System.Windows.Media.Animation {
	public partial class QuaternionAnimationTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (QuaternionAnimation), QuaternionAnimation.FromProperty.OwnerType);
			Assert.AreEqual ("From", QuaternionAnimation.FromProperty.Name);
			Assert.AreEqual ("From", QuaternionAnimation.FromProperty.ToString());
			Assert.AreEqual (typeof (Quaternion?), QuaternionAnimation.FromProperty.PropertyType);
			Assert.IsFalse (QuaternionAnimation.FromProperty.ReadOnly);

			Assert.AreEqual (typeof (QuaternionAnimation), QuaternionAnimation.ToProperty.OwnerType);
			Assert.AreEqual ("To", QuaternionAnimation.ToProperty.Name);
			Assert.AreEqual ("To", QuaternionAnimation.ToProperty.ToString());
			Assert.AreEqual (typeof (Quaternion?), QuaternionAnimation.ToProperty.PropertyType);
			Assert.IsFalse (QuaternionAnimation.ToProperty.ReadOnly);

			Assert.AreEqual (typeof (QuaternionAnimation), QuaternionAnimation.ByProperty.OwnerType);
			Assert.AreEqual ("By", QuaternionAnimation.ByProperty.Name);
			Assert.AreEqual ("By", QuaternionAnimation.ByProperty.ToString());
			Assert.AreEqual (typeof (Quaternion?), QuaternionAnimation.ByProperty.PropertyType);
			Assert.IsFalse (QuaternionAnimation.ByProperty.ReadOnly);

			Assert.AreEqual (typeof (QuaternionAnimation), QuaternionAnimation.UseShortestPathProperty.OwnerType);
			Assert.AreEqual ("UseShortestPath", QuaternionAnimation.UseShortestPathProperty.Name);
			Assert.AreEqual ("UseShortestPath", QuaternionAnimation.UseShortestPathProperty.ToString());
			Assert.AreEqual (typeof (bool), QuaternionAnimation.UseShortestPathProperty.PropertyType);
			Assert.IsFalse (QuaternionAnimation.UseShortestPathProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Animation.QuaternionKeyFrame
namespace MonoTests.System.Windows.Media.Animation {
	public partial class QuaternionKeyFrameTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (QuaternionKeyFrame), QuaternionKeyFrame.KeyTimeProperty.OwnerType);
			Assert.AreEqual ("KeyTime", QuaternionKeyFrame.KeyTimeProperty.Name);
			Assert.AreEqual ("KeyTime", QuaternionKeyFrame.KeyTimeProperty.ToString());
			Assert.AreEqual (typeof (KeyTime), QuaternionKeyFrame.KeyTimeProperty.PropertyType);
			Assert.IsFalse (QuaternionKeyFrame.KeyTimeProperty.ReadOnly);

			Assert.AreEqual (typeof (QuaternionKeyFrame), QuaternionKeyFrame.ValueProperty.OwnerType);
			Assert.AreEqual ("Value", QuaternionKeyFrame.ValueProperty.Name);
			Assert.AreEqual ("Value", QuaternionKeyFrame.ValueProperty.ToString());
			Assert.AreEqual (typeof (Quaternion), QuaternionKeyFrame.ValueProperty.PropertyType);
			Assert.IsFalse (QuaternionKeyFrame.ValueProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Media3D.QuaternionRotation3D
namespace MonoTests.System.Windows.Media.Media3D {
	public partial class QuaternionRotation3DTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (QuaternionRotation3D), QuaternionRotation3D.QuaternionProperty.OwnerType);
			Assert.AreEqual ("Quaternion", QuaternionRotation3D.QuaternionProperty.Name);
			Assert.AreEqual ("Quaternion", QuaternionRotation3D.QuaternionProperty.ToString());
			Assert.AreEqual (typeof (Quaternion), QuaternionRotation3D.QuaternionProperty.PropertyType);
			Assert.IsFalse (QuaternionRotation3D.QuaternionProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.RadialGradientBrush
namespace MonoTests.System.Windows.Media {
	public partial class RadialGradientBrushTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (RadialGradientBrush), RadialGradientBrush.CenterProperty.OwnerType);
			Assert.AreEqual ("Center", RadialGradientBrush.CenterProperty.Name);
			Assert.AreEqual ("Center", RadialGradientBrush.CenterProperty.ToString());
			Assert.AreEqual (typeof (Point), RadialGradientBrush.CenterProperty.PropertyType);
			Assert.IsFalse (RadialGradientBrush.CenterProperty.ReadOnly);

			Assert.AreEqual (typeof (RadialGradientBrush), RadialGradientBrush.RadiusXProperty.OwnerType);
			Assert.AreEqual ("RadiusX", RadialGradientBrush.RadiusXProperty.Name);
			Assert.AreEqual ("RadiusX", RadialGradientBrush.RadiusXProperty.ToString());
			Assert.AreEqual (typeof (double), RadialGradientBrush.RadiusXProperty.PropertyType);
			Assert.IsFalse (RadialGradientBrush.RadiusXProperty.ReadOnly);

			Assert.AreEqual (typeof (RadialGradientBrush), RadialGradientBrush.RadiusYProperty.OwnerType);
			Assert.AreEqual ("RadiusY", RadialGradientBrush.RadiusYProperty.Name);
			Assert.AreEqual ("RadiusY", RadialGradientBrush.RadiusYProperty.ToString());
			Assert.AreEqual (typeof (double), RadialGradientBrush.RadiusYProperty.PropertyType);
			Assert.IsFalse (RadialGradientBrush.RadiusYProperty.ReadOnly);

			Assert.AreEqual (typeof (RadialGradientBrush), RadialGradientBrush.GradientOriginProperty.OwnerType);
			Assert.AreEqual ("GradientOrigin", RadialGradientBrush.GradientOriginProperty.Name);
			Assert.AreEqual ("GradientOrigin", RadialGradientBrush.GradientOriginProperty.ToString());
			Assert.AreEqual (typeof (Point), RadialGradientBrush.GradientOriginProperty.PropertyType);
			Assert.IsFalse (RadialGradientBrush.GradientOriginProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.RectangleGeometry
namespace MonoTests.System.Windows.Media {
	public partial class RectangleGeometryTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (RectangleGeometry), RectangleGeometry.RadiusXProperty.OwnerType);
			Assert.AreEqual ("RadiusX", RectangleGeometry.RadiusXProperty.Name);
			Assert.AreEqual ("RadiusX", RectangleGeometry.RadiusXProperty.ToString());
			Assert.AreEqual (typeof (double), RectangleGeometry.RadiusXProperty.PropertyType);
			Assert.IsFalse (RectangleGeometry.RadiusXProperty.ReadOnly);

			Assert.AreEqual (typeof (RectangleGeometry), RectangleGeometry.RadiusYProperty.OwnerType);
			Assert.AreEqual ("RadiusY", RectangleGeometry.RadiusYProperty.Name);
			Assert.AreEqual ("RadiusY", RectangleGeometry.RadiusYProperty.ToString());
			Assert.AreEqual (typeof (double), RectangleGeometry.RadiusYProperty.PropertyType);
			Assert.IsFalse (RectangleGeometry.RadiusYProperty.ReadOnly);

			Assert.AreEqual (typeof (RectangleGeometry), RectangleGeometry.RectProperty.OwnerType);
			Assert.AreEqual ("Rect", RectangleGeometry.RectProperty.Name);
			Assert.AreEqual ("Rect", RectangleGeometry.RectProperty.ToString());
			Assert.AreEqual (typeof (Rect), RectangleGeometry.RectProperty.PropertyType);
			Assert.IsFalse (RectangleGeometry.RectProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Animation.RectAnimation
namespace MonoTests.System.Windows.Media.Animation {
	public partial class RectAnimationTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (RectAnimation), RectAnimation.FromProperty.OwnerType);
			Assert.AreEqual ("From", RectAnimation.FromProperty.Name);
			Assert.AreEqual ("From", RectAnimation.FromProperty.ToString());
			Assert.AreEqual (typeof (Rect?), RectAnimation.FromProperty.PropertyType);
			Assert.IsFalse (RectAnimation.FromProperty.ReadOnly);

			Assert.AreEqual (typeof (RectAnimation), RectAnimation.ToProperty.OwnerType);
			Assert.AreEqual ("To", RectAnimation.ToProperty.Name);
			Assert.AreEqual ("To", RectAnimation.ToProperty.ToString());
			Assert.AreEqual (typeof (Rect?), RectAnimation.ToProperty.PropertyType);
			Assert.IsFalse (RectAnimation.ToProperty.ReadOnly);

			Assert.AreEqual (typeof (RectAnimation), RectAnimation.ByProperty.OwnerType);
			Assert.AreEqual ("By", RectAnimation.ByProperty.Name);
			Assert.AreEqual ("By", RectAnimation.ByProperty.ToString());
			Assert.AreEqual (typeof (Rect?), RectAnimation.ByProperty.PropertyType);
			Assert.IsFalse (RectAnimation.ByProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.Animation.RectKeyFrame
namespace MonoTests.System.Windows.Media.Animation {
	public partial class RectKeyFrameTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (RectKeyFrame), RectKeyFrame.KeyTimeProperty.OwnerType);
			Assert.AreEqual ("KeyTime", RectKeyFrame.KeyTimeProperty.Name);
			Assert.AreEqual ("KeyTime", RectKeyFrame.KeyTimeProperty.ToString());
			Assert.AreEqual (typeof (KeyTime), RectKeyFrame.KeyTimeProperty.PropertyType);
			Assert.IsFalse (RectKeyFrame.KeyTimeProperty.ReadOnly);

			Assert.AreEqual (typeof (RectKeyFrame), RectKeyFrame.ValueProperty.OwnerType);
			Assert.AreEqual ("Value", RectKeyFrame.ValueProperty.Name);
			Assert.AreEqual ("Value", RectKeyFrame.ValueProperty.ToString());
			Assert.AreEqual (typeof (Rect), RectKeyFrame.ValueProperty.PropertyType);
			Assert.IsFalse (RectKeyFrame.ValueProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.RenderOptions
namespace MonoTests.System.Windows.Media {
	public partial class RenderOptionsTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (RenderOptions), RenderOptions.EdgeModeProperty.OwnerType);
			Assert.AreEqual ("EdgeMode", RenderOptions.EdgeModeProperty.Name);
			Assert.AreEqual ("EdgeMode", RenderOptions.EdgeModeProperty.ToString());
			Assert.AreEqual (typeof (EdgeMode), RenderOptions.EdgeModeProperty.PropertyType);
			Assert.IsFalse (RenderOptions.EdgeModeProperty.ReadOnly);

			Assert.AreEqual (typeof (RenderOptions), RenderOptions.BitmapScalingModeProperty.OwnerType);
			Assert.AreEqual ("BitmapScalingMode", RenderOptions.BitmapScalingModeProperty.Name);
			Assert.AreEqual ("BitmapScalingMode", RenderOptions.BitmapScalingModeProperty.ToString());
			Assert.AreEqual (typeof (BitmapScalingMode), RenderOptions.BitmapScalingModeProperty.PropertyType);
			Assert.IsFalse (RenderOptions.BitmapScalingModeProperty.ReadOnly);

			Assert.AreEqual (typeof (RenderOptions), RenderOptions.CachingHintProperty.OwnerType);
			Assert.AreEqual ("CachingHint", RenderOptions.CachingHintProperty.Name);
			Assert.AreEqual ("CachingHint", RenderOptions.CachingHintProperty.ToString());
			Assert.AreEqual (typeof (CachingHint), RenderOptions.CachingHintProperty.PropertyType);
			Assert.IsFalse (RenderOptions.CachingHintProperty.ReadOnly);

			Assert.AreEqual (typeof (RenderOptions), RenderOptions.CacheInvalidationThresholdMinimumProperty.OwnerType);
			Assert.AreEqual ("CacheInvalidationThresholdMinimum", RenderOptions.CacheInvalidationThresholdMinimumProperty.Name);
			Assert.AreEqual ("CacheInvalidationThresholdMinimum", RenderOptions.CacheInvalidationThresholdMinimumProperty.ToString());
			Assert.AreEqual (typeof (double), RenderOptions.CacheInvalidationThresholdMinimumProperty.PropertyType);
			Assert.IsFalse (RenderOptions.CacheInvalidationThresholdMinimumProperty.ReadOnly);

			Assert.AreEqual (typeof (RenderOptions), RenderOptions.CacheInvalidationThresholdMaximumProperty.OwnerType);
			Assert.AreEqual ("CacheInvalidationThresholdMaximum", RenderOptions.CacheInvalidationThresholdMaximumProperty.Name);
			Assert.AreEqual ("CacheInvalidationThresholdMaximum", RenderOptions.CacheInvalidationThresholdMaximumProperty.ToString());
			Assert.AreEqual (typeof (double), RenderOptions.CacheInvalidationThresholdMaximumProperty.PropertyType);
			Assert.IsFalse (RenderOptions.CacheInvalidationThresholdMaximumProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.RotateTransform
namespace MonoTests.System.Windows.Media {
	public partial class RotateTransformTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (RotateTransform), RotateTransform.AngleProperty.OwnerType);
			Assert.AreEqual ("Angle", RotateTransform.AngleProperty.Name);
			Assert.AreEqual ("Angle", RotateTransform.AngleProperty.ToString());
			Assert.AreEqual (typeof (double), RotateTransform.AngleProperty.PropertyType);
			Assert.IsFalse (RotateTransform.AngleProperty.ReadOnly);

			Assert.AreEqual (typeof (RotateTransform), RotateTransform.CenterXProperty.OwnerType);
			Assert.AreEqual ("CenterX", RotateTransform.CenterXProperty.Name);
			Assert.AreEqual ("CenterX", RotateTransform.CenterXProperty.ToString());
			Assert.AreEqual (typeof (double), RotateTransform.CenterXProperty.PropertyType);
			Assert.IsFalse (RotateTransform.CenterXProperty.ReadOnly);

			Assert.AreEqual (typeof (RotateTransform), RotateTransform.CenterYProperty.OwnerType);
			Assert.AreEqual ("CenterY", RotateTransform.CenterYProperty.Name);
			Assert.AreEqual ("CenterY", RotateTransform.CenterYProperty.ToString());
			Assert.AreEqual (typeof (double), RotateTransform.CenterYProperty.PropertyType);
			Assert.IsFalse (RotateTransform.CenterYProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.Media3D.RotateTransform3D
namespace MonoTests.System.Windows.Media.Media3D {
	public partial class RotateTransform3DTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (RotateTransform3D), RotateTransform3D.CenterXProperty.OwnerType);
			Assert.AreEqual ("CenterX", RotateTransform3D.CenterXProperty.Name);
			Assert.AreEqual ("CenterX", RotateTransform3D.CenterXProperty.ToString());
			Assert.AreEqual (typeof (double), RotateTransform3D.CenterXProperty.PropertyType);
			Assert.IsFalse (RotateTransform3D.CenterXProperty.ReadOnly);

			Assert.AreEqual (typeof (RotateTransform3D), RotateTransform3D.CenterYProperty.OwnerType);
			Assert.AreEqual ("CenterY", RotateTransform3D.CenterYProperty.Name);
			Assert.AreEqual ("CenterY", RotateTransform3D.CenterYProperty.ToString());
			Assert.AreEqual (typeof (double), RotateTransform3D.CenterYProperty.PropertyType);
			Assert.IsFalse (RotateTransform3D.CenterYProperty.ReadOnly);

			Assert.AreEqual (typeof (RotateTransform3D), RotateTransform3D.CenterZProperty.OwnerType);
			Assert.AreEqual ("CenterZ", RotateTransform3D.CenterZProperty.Name);
			Assert.AreEqual ("CenterZ", RotateTransform3D.CenterZProperty.ToString());
			Assert.AreEqual (typeof (double), RotateTransform3D.CenterZProperty.PropertyType);
			Assert.IsFalse (RotateTransform3D.CenterZProperty.ReadOnly);

			Assert.AreEqual (typeof (RotateTransform3D), RotateTransform3D.RotationProperty.OwnerType);
			Assert.AreEqual ("Rotation", RotateTransform3D.RotationProperty.Name);
			Assert.AreEqual ("Rotation", RotateTransform3D.RotationProperty.ToString());
			Assert.AreEqual (typeof (Rotation3D), RotateTransform3D.RotationProperty.PropertyType);
			Assert.IsFalse (RotateTransform3D.RotationProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Animation.Rotation3DAnimation
namespace MonoTests.System.Windows.Media.Animation {
	public partial class Rotation3DAnimationTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (Rotation3DAnimation), Rotation3DAnimation.FromProperty.OwnerType);
			Assert.AreEqual ("From", Rotation3DAnimation.FromProperty.Name);
			Assert.AreEqual ("From", Rotation3DAnimation.FromProperty.ToString());
			Assert.AreEqual (typeof (Rotation3D), Rotation3DAnimation.FromProperty.PropertyType);
			Assert.IsFalse (Rotation3DAnimation.FromProperty.ReadOnly);

			Assert.AreEqual (typeof (Rotation3DAnimation), Rotation3DAnimation.ToProperty.OwnerType);
			Assert.AreEqual ("To", Rotation3DAnimation.ToProperty.Name);
			Assert.AreEqual ("To", Rotation3DAnimation.ToProperty.ToString());
			Assert.AreEqual (typeof (Rotation3D), Rotation3DAnimation.ToProperty.PropertyType);
			Assert.IsFalse (Rotation3DAnimation.ToProperty.ReadOnly);

			Assert.AreEqual (typeof (Rotation3DAnimation), Rotation3DAnimation.ByProperty.OwnerType);
			Assert.AreEqual ("By", Rotation3DAnimation.ByProperty.Name);
			Assert.AreEqual ("By", Rotation3DAnimation.ByProperty.ToString());
			Assert.AreEqual (typeof (Rotation3D), Rotation3DAnimation.ByProperty.PropertyType);
			Assert.IsFalse (Rotation3DAnimation.ByProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Animation.Rotation3DKeyFrame
namespace MonoTests.System.Windows.Media.Animation {
	public partial class Rotation3DKeyFrameTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (Rotation3DKeyFrame), Rotation3DKeyFrame.KeyTimeProperty.OwnerType);
			Assert.AreEqual ("KeyTime", Rotation3DKeyFrame.KeyTimeProperty.Name);
			Assert.AreEqual ("KeyTime", Rotation3DKeyFrame.KeyTimeProperty.ToString());
			Assert.AreEqual (typeof (KeyTime), Rotation3DKeyFrame.KeyTimeProperty.PropertyType);
			Assert.IsFalse (Rotation3DKeyFrame.KeyTimeProperty.ReadOnly);

			Assert.AreEqual (typeof (Rotation3DKeyFrame), Rotation3DKeyFrame.ValueProperty.OwnerType);
			Assert.AreEqual ("Value", Rotation3DKeyFrame.ValueProperty.Name);
			Assert.AreEqual ("Value", Rotation3DKeyFrame.ValueProperty.ToString());
			Assert.AreEqual (typeof (Rotation3D), Rotation3DKeyFrame.ValueProperty.PropertyType);
			Assert.IsFalse (Rotation3DKeyFrame.ValueProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.ScaleTransform
namespace MonoTests.System.Windows.Media {
	public partial class ScaleTransformTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (ScaleTransform), ScaleTransform.ScaleXProperty.OwnerType);
			Assert.AreEqual ("ScaleX", ScaleTransform.ScaleXProperty.Name);
			Assert.AreEqual ("ScaleX", ScaleTransform.ScaleXProperty.ToString());
			Assert.AreEqual (typeof (double), ScaleTransform.ScaleXProperty.PropertyType);
			Assert.IsFalse (ScaleTransform.ScaleXProperty.ReadOnly);

			Assert.AreEqual (typeof (ScaleTransform), ScaleTransform.ScaleYProperty.OwnerType);
			Assert.AreEqual ("ScaleY", ScaleTransform.ScaleYProperty.Name);
			Assert.AreEqual ("ScaleY", ScaleTransform.ScaleYProperty.ToString());
			Assert.AreEqual (typeof (double), ScaleTransform.ScaleYProperty.PropertyType);
			Assert.IsFalse (ScaleTransform.ScaleYProperty.ReadOnly);

			Assert.AreEqual (typeof (ScaleTransform), ScaleTransform.CenterXProperty.OwnerType);
			Assert.AreEqual ("CenterX", ScaleTransform.CenterXProperty.Name);
			Assert.AreEqual ("CenterX", ScaleTransform.CenterXProperty.ToString());
			Assert.AreEqual (typeof (double), ScaleTransform.CenterXProperty.PropertyType);
			Assert.IsFalse (ScaleTransform.CenterXProperty.ReadOnly);

			Assert.AreEqual (typeof (ScaleTransform), ScaleTransform.CenterYProperty.OwnerType);
			Assert.AreEqual ("CenterY", ScaleTransform.CenterYProperty.Name);
			Assert.AreEqual ("CenterY", ScaleTransform.CenterYProperty.ToString());
			Assert.AreEqual (typeof (double), ScaleTransform.CenterYProperty.PropertyType);
			Assert.IsFalse (ScaleTransform.CenterYProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.Media3D.ScaleTransform3D
namespace MonoTests.System.Windows.Media.Media3D {
	public partial class ScaleTransform3DTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (ScaleTransform3D), ScaleTransform3D.ScaleXProperty.OwnerType);
			Assert.AreEqual ("ScaleX", ScaleTransform3D.ScaleXProperty.Name);
			Assert.AreEqual ("ScaleX", ScaleTransform3D.ScaleXProperty.ToString());
			Assert.AreEqual (typeof (double), ScaleTransform3D.ScaleXProperty.PropertyType);
			Assert.IsFalse (ScaleTransform3D.ScaleXProperty.ReadOnly);

			Assert.AreEqual (typeof (ScaleTransform3D), ScaleTransform3D.ScaleYProperty.OwnerType);
			Assert.AreEqual ("ScaleY", ScaleTransform3D.ScaleYProperty.Name);
			Assert.AreEqual ("ScaleY", ScaleTransform3D.ScaleYProperty.ToString());
			Assert.AreEqual (typeof (double), ScaleTransform3D.ScaleYProperty.PropertyType);
			Assert.IsFalse (ScaleTransform3D.ScaleYProperty.ReadOnly);

			Assert.AreEqual (typeof (ScaleTransform3D), ScaleTransform3D.ScaleZProperty.OwnerType);
			Assert.AreEqual ("ScaleZ", ScaleTransform3D.ScaleZProperty.Name);
			Assert.AreEqual ("ScaleZ", ScaleTransform3D.ScaleZProperty.ToString());
			Assert.AreEqual (typeof (double), ScaleTransform3D.ScaleZProperty.PropertyType);
			Assert.IsFalse (ScaleTransform3D.ScaleZProperty.ReadOnly);

			Assert.AreEqual (typeof (ScaleTransform3D), ScaleTransform3D.CenterXProperty.OwnerType);
			Assert.AreEqual ("CenterX", ScaleTransform3D.CenterXProperty.Name);
			Assert.AreEqual ("CenterX", ScaleTransform3D.CenterXProperty.ToString());
			Assert.AreEqual (typeof (double), ScaleTransform3D.CenterXProperty.PropertyType);
			Assert.IsFalse (ScaleTransform3D.CenterXProperty.ReadOnly);

			Assert.AreEqual (typeof (ScaleTransform3D), ScaleTransform3D.CenterYProperty.OwnerType);
			Assert.AreEqual ("CenterY", ScaleTransform3D.CenterYProperty.Name);
			Assert.AreEqual ("CenterY", ScaleTransform3D.CenterYProperty.ToString());
			Assert.AreEqual (typeof (double), ScaleTransform3D.CenterYProperty.PropertyType);
			Assert.IsFalse (ScaleTransform3D.CenterYProperty.ReadOnly);

			Assert.AreEqual (typeof (ScaleTransform3D), ScaleTransform3D.CenterZProperty.OwnerType);
			Assert.AreEqual ("CenterZ", ScaleTransform3D.CenterZProperty.Name);
			Assert.AreEqual ("CenterZ", ScaleTransform3D.CenterZProperty.ToString());
			Assert.AreEqual (typeof (double), ScaleTransform3D.CenterZProperty.PropertyType);
			Assert.IsFalse (ScaleTransform3D.CenterZProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Animation.SingleAnimation
namespace MonoTests.System.Windows.Media.Animation {
	public partial class SingleAnimationTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (SingleAnimation), SingleAnimation.FromProperty.OwnerType);
			Assert.AreEqual ("From", SingleAnimation.FromProperty.Name);
			Assert.AreEqual ("From", SingleAnimation.FromProperty.ToString());
			Assert.AreEqual (typeof (float?), SingleAnimation.FromProperty.PropertyType);
			Assert.IsFalse (SingleAnimation.FromProperty.ReadOnly);

			Assert.AreEqual (typeof (SingleAnimation), SingleAnimation.ToProperty.OwnerType);
			Assert.AreEqual ("To", SingleAnimation.ToProperty.Name);
			Assert.AreEqual ("To", SingleAnimation.ToProperty.ToString());
			Assert.AreEqual (typeof (float?), SingleAnimation.ToProperty.PropertyType);
			Assert.IsFalse (SingleAnimation.ToProperty.ReadOnly);

			Assert.AreEqual (typeof (SingleAnimation), SingleAnimation.ByProperty.OwnerType);
			Assert.AreEqual ("By", SingleAnimation.ByProperty.Name);
			Assert.AreEqual ("By", SingleAnimation.ByProperty.ToString());
			Assert.AreEqual (typeof (float?), SingleAnimation.ByProperty.PropertyType);
			Assert.IsFalse (SingleAnimation.ByProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.Animation.SingleKeyFrame
namespace MonoTests.System.Windows.Media.Animation {
	public partial class SingleKeyFrameTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (SingleKeyFrame), SingleKeyFrame.KeyTimeProperty.OwnerType);
			Assert.AreEqual ("KeyTime", SingleKeyFrame.KeyTimeProperty.Name);
			Assert.AreEqual ("KeyTime", SingleKeyFrame.KeyTimeProperty.ToString());
			Assert.AreEqual (typeof (KeyTime), SingleKeyFrame.KeyTimeProperty.PropertyType);
			Assert.IsFalse (SingleKeyFrame.KeyTimeProperty.ReadOnly);

			Assert.AreEqual (typeof (SingleKeyFrame), SingleKeyFrame.ValueProperty.OwnerType);
			Assert.AreEqual ("Value", SingleKeyFrame.ValueProperty.Name);
			Assert.AreEqual ("Value", SingleKeyFrame.ValueProperty.ToString());
			Assert.AreEqual (typeof (float), SingleKeyFrame.ValueProperty.PropertyType);
			Assert.IsFalse (SingleKeyFrame.ValueProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.Animation.SizeAnimation
namespace MonoTests.System.Windows.Media.Animation {
	public partial class SizeAnimationTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (SizeAnimation), SizeAnimation.FromProperty.OwnerType);
			Assert.AreEqual ("From", SizeAnimation.FromProperty.Name);
			Assert.AreEqual ("From", SizeAnimation.FromProperty.ToString());
			Assert.AreEqual (typeof (Size?), SizeAnimation.FromProperty.PropertyType);
			Assert.IsFalse (SizeAnimation.FromProperty.ReadOnly);

			Assert.AreEqual (typeof (SizeAnimation), SizeAnimation.ToProperty.OwnerType);
			Assert.AreEqual ("To", SizeAnimation.ToProperty.Name);
			Assert.AreEqual ("To", SizeAnimation.ToProperty.ToString());
			Assert.AreEqual (typeof (Size?), SizeAnimation.ToProperty.PropertyType);
			Assert.IsFalse (SizeAnimation.ToProperty.ReadOnly);

			Assert.AreEqual (typeof (SizeAnimation), SizeAnimation.ByProperty.OwnerType);
			Assert.AreEqual ("By", SizeAnimation.ByProperty.Name);
			Assert.AreEqual ("By", SizeAnimation.ByProperty.ToString());
			Assert.AreEqual (typeof (Size?), SizeAnimation.ByProperty.PropertyType);
			Assert.IsFalse (SizeAnimation.ByProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.Animation.SizeKeyFrame
namespace MonoTests.System.Windows.Media.Animation {
	public partial class SizeKeyFrameTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (SizeKeyFrame), SizeKeyFrame.KeyTimeProperty.OwnerType);
			Assert.AreEqual ("KeyTime", SizeKeyFrame.KeyTimeProperty.Name);
			Assert.AreEqual ("KeyTime", SizeKeyFrame.KeyTimeProperty.ToString());
			Assert.AreEqual (typeof (KeyTime), SizeKeyFrame.KeyTimeProperty.PropertyType);
			Assert.IsFalse (SizeKeyFrame.KeyTimeProperty.ReadOnly);

			Assert.AreEqual (typeof (SizeKeyFrame), SizeKeyFrame.ValueProperty.OwnerType);
			Assert.AreEqual ("Value", SizeKeyFrame.ValueProperty.Name);
			Assert.AreEqual ("Value", SizeKeyFrame.ValueProperty.ToString());
			Assert.AreEqual (typeof (Size), SizeKeyFrame.ValueProperty.PropertyType);
			Assert.IsFalse (SizeKeyFrame.ValueProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.SkewTransform
namespace MonoTests.System.Windows.Media {
	public partial class SkewTransformTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (SkewTransform), SkewTransform.AngleXProperty.OwnerType);
			Assert.AreEqual ("AngleX", SkewTransform.AngleXProperty.Name);
			Assert.AreEqual ("AngleX", SkewTransform.AngleXProperty.ToString());
			Assert.AreEqual (typeof (double), SkewTransform.AngleXProperty.PropertyType);
			Assert.IsFalse (SkewTransform.AngleXProperty.ReadOnly);

			Assert.AreEqual (typeof (SkewTransform), SkewTransform.AngleYProperty.OwnerType);
			Assert.AreEqual ("AngleY", SkewTransform.AngleYProperty.Name);
			Assert.AreEqual ("AngleY", SkewTransform.AngleYProperty.ToString());
			Assert.AreEqual (typeof (double), SkewTransform.AngleYProperty.PropertyType);
			Assert.IsFalse (SkewTransform.AngleYProperty.ReadOnly);

			Assert.AreEqual (typeof (SkewTransform), SkewTransform.CenterXProperty.OwnerType);
			Assert.AreEqual ("CenterX", SkewTransform.CenterXProperty.Name);
			Assert.AreEqual ("CenterX", SkewTransform.CenterXProperty.ToString());
			Assert.AreEqual (typeof (double), SkewTransform.CenterXProperty.PropertyType);
			Assert.IsFalse (SkewTransform.CenterXProperty.ReadOnly);

			Assert.AreEqual (typeof (SkewTransform), SkewTransform.CenterYProperty.OwnerType);
			Assert.AreEqual ("CenterY", SkewTransform.CenterYProperty.Name);
			Assert.AreEqual ("CenterY", SkewTransform.CenterYProperty.ToString());
			Assert.AreEqual (typeof (double), SkewTransform.CenterYProperty.PropertyType);
			Assert.IsFalse (SkewTransform.CenterYProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.SolidColorBrush
namespace MonoTests.System.Windows.Media {
	public partial class SolidColorBrushTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (SolidColorBrush), SolidColorBrush.ColorProperty.OwnerType);
			Assert.AreEqual ("Color", SolidColorBrush.ColorProperty.Name);
			Assert.AreEqual ("Color", SolidColorBrush.ColorProperty.ToString());
			Assert.AreEqual (typeof (Color), SolidColorBrush.ColorProperty.PropertyType);
			Assert.IsFalse (SolidColorBrush.ColorProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.Media3D.SpecularMaterial
namespace MonoTests.System.Windows.Media.Media3D {
	public partial class SpecularMaterialTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (SpecularMaterial), SpecularMaterial.ColorProperty.OwnerType);
			Assert.AreEqual ("Color", SpecularMaterial.ColorProperty.Name);
			Assert.AreEqual ("Color", SpecularMaterial.ColorProperty.ToString());
			Assert.AreEqual (typeof (Color), SpecularMaterial.ColorProperty.PropertyType);
			Assert.IsFalse (SpecularMaterial.ColorProperty.ReadOnly);

			Assert.AreEqual (typeof (SpecularMaterial), SpecularMaterial.BrushProperty.OwnerType);
			Assert.AreEqual ("Brush", SpecularMaterial.BrushProperty.Name);
			Assert.AreEqual ("Brush", SpecularMaterial.BrushProperty.ToString());
			Assert.AreEqual (typeof (Brush), SpecularMaterial.BrushProperty.PropertyType);
			Assert.IsFalse (SpecularMaterial.BrushProperty.ReadOnly);

			Assert.AreEqual (typeof (SpecularMaterial), SpecularMaterial.SpecularPowerProperty.OwnerType);
			Assert.AreEqual ("SpecularPower", SpecularMaterial.SpecularPowerProperty.Name);
			Assert.AreEqual ("SpecularPower", SpecularMaterial.SpecularPowerProperty.ToString());
			Assert.AreEqual (typeof (double), SpecularMaterial.SpecularPowerProperty.PropertyType);
			Assert.IsFalse (SpecularMaterial.SpecularPowerProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Animation.SplineByteKeyFrame
namespace MonoTests.System.Windows.Media.Animation {
	public partial class SplineByteKeyFrameTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (SplineByteKeyFrame), SplineByteKeyFrame.KeySplineProperty.OwnerType);
			Assert.AreEqual ("KeySpline", SplineByteKeyFrame.KeySplineProperty.Name);
			Assert.AreEqual ("KeySpline", SplineByteKeyFrame.KeySplineProperty.ToString());
			Assert.AreEqual (typeof (KeySpline), SplineByteKeyFrame.KeySplineProperty.PropertyType);
			Assert.IsFalse (SplineByteKeyFrame.KeySplineProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.Animation.SplineColorKeyFrame
namespace MonoTests.System.Windows.Media.Animation {
	public partial class SplineColorKeyFrameTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (SplineColorKeyFrame), SplineColorKeyFrame.KeySplineProperty.OwnerType);
			Assert.AreEqual ("KeySpline", SplineColorKeyFrame.KeySplineProperty.Name);
			Assert.AreEqual ("KeySpline", SplineColorKeyFrame.KeySplineProperty.ToString());
			Assert.AreEqual (typeof (KeySpline), SplineColorKeyFrame.KeySplineProperty.PropertyType);
			Assert.IsFalse (SplineColorKeyFrame.KeySplineProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.Animation.SplineDecimalKeyFrame
namespace MonoTests.System.Windows.Media.Animation {
	public partial class SplineDecimalKeyFrameTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (SplineDecimalKeyFrame), SplineDecimalKeyFrame.KeySplineProperty.OwnerType);
			Assert.AreEqual ("KeySpline", SplineDecimalKeyFrame.KeySplineProperty.Name);
			Assert.AreEqual ("KeySpline", SplineDecimalKeyFrame.KeySplineProperty.ToString());
			Assert.AreEqual (typeof (KeySpline), SplineDecimalKeyFrame.KeySplineProperty.PropertyType);
			Assert.IsFalse (SplineDecimalKeyFrame.KeySplineProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.Animation.SplineDoubleKeyFrame
namespace MonoTests.System.Windows.Media.Animation {
	public partial class SplineDoubleKeyFrameTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (SplineDoubleKeyFrame), SplineDoubleKeyFrame.KeySplineProperty.OwnerType);
			Assert.AreEqual ("KeySpline", SplineDoubleKeyFrame.KeySplineProperty.Name);
			Assert.AreEqual ("KeySpline", SplineDoubleKeyFrame.KeySplineProperty.ToString());
			Assert.AreEqual (typeof (KeySpline), SplineDoubleKeyFrame.KeySplineProperty.PropertyType);
			Assert.IsFalse (SplineDoubleKeyFrame.KeySplineProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.Animation.SplineInt16KeyFrame
namespace MonoTests.System.Windows.Media.Animation {
	public partial class SplineInt16KeyFrameTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (SplineInt16KeyFrame), SplineInt16KeyFrame.KeySplineProperty.OwnerType);
			Assert.AreEqual ("KeySpline", SplineInt16KeyFrame.KeySplineProperty.Name);
			Assert.AreEqual ("KeySpline", SplineInt16KeyFrame.KeySplineProperty.ToString());
			Assert.AreEqual (typeof (KeySpline), SplineInt16KeyFrame.KeySplineProperty.PropertyType);
			Assert.IsFalse (SplineInt16KeyFrame.KeySplineProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.Animation.SplineInt32KeyFrame
namespace MonoTests.System.Windows.Media.Animation {
	public partial class SplineInt32KeyFrameTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (SplineInt32KeyFrame), SplineInt32KeyFrame.KeySplineProperty.OwnerType);
			Assert.AreEqual ("KeySpline", SplineInt32KeyFrame.KeySplineProperty.Name);
			Assert.AreEqual ("KeySpline", SplineInt32KeyFrame.KeySplineProperty.ToString());
			Assert.AreEqual (typeof (KeySpline), SplineInt32KeyFrame.KeySplineProperty.PropertyType);
			Assert.IsFalse (SplineInt32KeyFrame.KeySplineProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.Animation.SplineInt64KeyFrame
namespace MonoTests.System.Windows.Media.Animation {
	public partial class SplineInt64KeyFrameTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (SplineInt64KeyFrame), SplineInt64KeyFrame.KeySplineProperty.OwnerType);
			Assert.AreEqual ("KeySpline", SplineInt64KeyFrame.KeySplineProperty.Name);
			Assert.AreEqual ("KeySpline", SplineInt64KeyFrame.KeySplineProperty.ToString());
			Assert.AreEqual (typeof (KeySpline), SplineInt64KeyFrame.KeySplineProperty.PropertyType);
			Assert.IsFalse (SplineInt64KeyFrame.KeySplineProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.Animation.SplinePoint3DKeyFrame
namespace MonoTests.System.Windows.Media.Animation {
	public partial class SplinePoint3DKeyFrameTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (SplinePoint3DKeyFrame), SplinePoint3DKeyFrame.KeySplineProperty.OwnerType);
			Assert.AreEqual ("KeySpline", SplinePoint3DKeyFrame.KeySplineProperty.Name);
			Assert.AreEqual ("KeySpline", SplinePoint3DKeyFrame.KeySplineProperty.ToString());
			Assert.AreEqual (typeof (KeySpline), SplinePoint3DKeyFrame.KeySplineProperty.PropertyType);
			Assert.IsFalse (SplinePoint3DKeyFrame.KeySplineProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Animation.SplinePointKeyFrame
namespace MonoTests.System.Windows.Media.Animation {
	public partial class SplinePointKeyFrameTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (SplinePointKeyFrame), SplinePointKeyFrame.KeySplineProperty.OwnerType);
			Assert.AreEqual ("KeySpline", SplinePointKeyFrame.KeySplineProperty.Name);
			Assert.AreEqual ("KeySpline", SplinePointKeyFrame.KeySplineProperty.ToString());
			Assert.AreEqual (typeof (KeySpline), SplinePointKeyFrame.KeySplineProperty.PropertyType);
			Assert.IsFalse (SplinePointKeyFrame.KeySplineProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.Animation.SplineQuaternionKeyFrame
namespace MonoTests.System.Windows.Media.Animation {
	public partial class SplineQuaternionKeyFrameTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (SplineQuaternionKeyFrame), SplineQuaternionKeyFrame.KeySplineProperty.OwnerType);
			Assert.AreEqual ("KeySpline", SplineQuaternionKeyFrame.KeySplineProperty.Name);
			Assert.AreEqual ("KeySpline", SplineQuaternionKeyFrame.KeySplineProperty.ToString());
			Assert.AreEqual (typeof (KeySpline), SplineQuaternionKeyFrame.KeySplineProperty.PropertyType);
			Assert.IsFalse (SplineQuaternionKeyFrame.KeySplineProperty.ReadOnly);

			Assert.AreEqual (typeof (SplineQuaternionKeyFrame), SplineQuaternionKeyFrame.UseShortestPathProperty.OwnerType);
			Assert.AreEqual ("UseShortestPath", SplineQuaternionKeyFrame.UseShortestPathProperty.Name);
			Assert.AreEqual ("UseShortestPath", SplineQuaternionKeyFrame.UseShortestPathProperty.ToString());
			Assert.AreEqual (typeof (bool), SplineQuaternionKeyFrame.UseShortestPathProperty.PropertyType);
			Assert.IsFalse (SplineQuaternionKeyFrame.UseShortestPathProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Animation.SplineRectKeyFrame
namespace MonoTests.System.Windows.Media.Animation {
	public partial class SplineRectKeyFrameTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (SplineRectKeyFrame), SplineRectKeyFrame.KeySplineProperty.OwnerType);
			Assert.AreEqual ("KeySpline", SplineRectKeyFrame.KeySplineProperty.Name);
			Assert.AreEqual ("KeySpline", SplineRectKeyFrame.KeySplineProperty.ToString());
			Assert.AreEqual (typeof (KeySpline), SplineRectKeyFrame.KeySplineProperty.PropertyType);
			Assert.IsFalse (SplineRectKeyFrame.KeySplineProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.Animation.SplineRotation3DKeyFrame
namespace MonoTests.System.Windows.Media.Animation {
	public partial class SplineRotation3DKeyFrameTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (SplineRotation3DKeyFrame), SplineRotation3DKeyFrame.KeySplineProperty.OwnerType);
			Assert.AreEqual ("KeySpline", SplineRotation3DKeyFrame.KeySplineProperty.Name);
			Assert.AreEqual ("KeySpline", SplineRotation3DKeyFrame.KeySplineProperty.ToString());
			Assert.AreEqual (typeof (KeySpline), SplineRotation3DKeyFrame.KeySplineProperty.PropertyType);
			Assert.IsFalse (SplineRotation3DKeyFrame.KeySplineProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Animation.SplineSingleKeyFrame
namespace MonoTests.System.Windows.Media.Animation {
	public partial class SplineSingleKeyFrameTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (SplineSingleKeyFrame), SplineSingleKeyFrame.KeySplineProperty.OwnerType);
			Assert.AreEqual ("KeySpline", SplineSingleKeyFrame.KeySplineProperty.Name);
			Assert.AreEqual ("KeySpline", SplineSingleKeyFrame.KeySplineProperty.ToString());
			Assert.AreEqual (typeof (KeySpline), SplineSingleKeyFrame.KeySplineProperty.PropertyType);
			Assert.IsFalse (SplineSingleKeyFrame.KeySplineProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.Animation.SplineSizeKeyFrame
namespace MonoTests.System.Windows.Media.Animation {
	public partial class SplineSizeKeyFrameTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (SplineSizeKeyFrame), SplineSizeKeyFrame.KeySplineProperty.OwnerType);
			Assert.AreEqual ("KeySpline", SplineSizeKeyFrame.KeySplineProperty.Name);
			Assert.AreEqual ("KeySpline", SplineSizeKeyFrame.KeySplineProperty.ToString());
			Assert.AreEqual (typeof (KeySpline), SplineSizeKeyFrame.KeySplineProperty.PropertyType);
			Assert.IsFalse (SplineSizeKeyFrame.KeySplineProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.Animation.SplineVector3DKeyFrame
namespace MonoTests.System.Windows.Media.Animation {
	public partial class SplineVector3DKeyFrameTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (SplineVector3DKeyFrame), SplineVector3DKeyFrame.KeySplineProperty.OwnerType);
			Assert.AreEqual ("KeySpline", SplineVector3DKeyFrame.KeySplineProperty.Name);
			Assert.AreEqual ("KeySpline", SplineVector3DKeyFrame.KeySplineProperty.ToString());
			Assert.AreEqual (typeof (KeySpline), SplineVector3DKeyFrame.KeySplineProperty.PropertyType);
			Assert.IsFalse (SplineVector3DKeyFrame.KeySplineProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Animation.SplineVectorKeyFrame
namespace MonoTests.System.Windows.Media.Animation {
	public partial class SplineVectorKeyFrameTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (SplineVectorKeyFrame), SplineVectorKeyFrame.KeySplineProperty.OwnerType);
			Assert.AreEqual ("KeySpline", SplineVectorKeyFrame.KeySplineProperty.Name);
			Assert.AreEqual ("KeySpline", SplineVectorKeyFrame.KeySplineProperty.ToString());
			Assert.AreEqual (typeof (KeySpline), SplineVectorKeyFrame.KeySplineProperty.PropertyType);
			Assert.IsFalse (SplineVectorKeyFrame.KeySplineProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.Media3D.SpotLight
namespace MonoTests.System.Windows.Media.Media3D {
	public partial class SpotLightTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (SpotLight), SpotLight.DirectionProperty.OwnerType);
			Assert.AreEqual ("Direction", SpotLight.DirectionProperty.Name);
			Assert.AreEqual ("Direction", SpotLight.DirectionProperty.ToString());
			Assert.AreEqual (typeof (Vector3D), SpotLight.DirectionProperty.PropertyType);
			Assert.IsFalse (SpotLight.DirectionProperty.ReadOnly);

			Assert.AreEqual (typeof (SpotLight), SpotLight.OuterConeAngleProperty.OwnerType);
			Assert.AreEqual ("OuterConeAngle", SpotLight.OuterConeAngleProperty.Name);
			Assert.AreEqual ("OuterConeAngle", SpotLight.OuterConeAngleProperty.ToString());
			Assert.AreEqual (typeof (double), SpotLight.OuterConeAngleProperty.PropertyType);
			Assert.IsFalse (SpotLight.OuterConeAngleProperty.ReadOnly);

			Assert.AreEqual (typeof (SpotLight), SpotLight.InnerConeAngleProperty.OwnerType);
			Assert.AreEqual ("InnerConeAngle", SpotLight.InnerConeAngleProperty.Name);
			Assert.AreEqual ("InnerConeAngle", SpotLight.InnerConeAngleProperty.ToString());
			Assert.AreEqual (typeof (double), SpotLight.InnerConeAngleProperty.PropertyType);
			Assert.IsFalse (SpotLight.InnerConeAngleProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.StreamGeometry
namespace MonoTests.System.Windows.Media {
	public partial class StreamGeometryTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (StreamGeometry), StreamGeometry.FillRuleProperty.OwnerType);
			Assert.AreEqual ("FillRule", StreamGeometry.FillRuleProperty.Name);
			Assert.AreEqual ("FillRule", StreamGeometry.FillRuleProperty.ToString());
			Assert.AreEqual (typeof (FillRule), StreamGeometry.FillRuleProperty.PropertyType);
			Assert.IsFalse (StreamGeometry.FillRuleProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Animation.StringKeyFrame
namespace MonoTests.System.Windows.Media.Animation {
	public partial class StringKeyFrameTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (StringKeyFrame), StringKeyFrame.KeyTimeProperty.OwnerType);
			Assert.AreEqual ("KeyTime", StringKeyFrame.KeyTimeProperty.Name);
			Assert.AreEqual ("KeyTime", StringKeyFrame.KeyTimeProperty.ToString());
			Assert.AreEqual (typeof (KeyTime), StringKeyFrame.KeyTimeProperty.PropertyType);
			Assert.IsFalse (StringKeyFrame.KeyTimeProperty.ReadOnly);

			Assert.AreEqual (typeof (StringKeyFrame), StringKeyFrame.ValueProperty.OwnerType);
			Assert.AreEqual ("Value", StringKeyFrame.ValueProperty.Name);
			Assert.AreEqual ("Value", StringKeyFrame.ValueProperty.ToString());
			Assert.AreEqual (typeof (string), StringKeyFrame.ValueProperty.PropertyType);
			Assert.IsFalse (StringKeyFrame.ValueProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Input.Stylus
namespace MonoTests.System.Windows.Input {
	public partial class StylusTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (Stylus), Stylus.IsPressAndHoldEnabledProperty.OwnerType);
			Assert.AreEqual ("IsPressAndHoldEnabled", Stylus.IsPressAndHoldEnabledProperty.Name);
			Assert.AreEqual ("IsPressAndHoldEnabled", Stylus.IsPressAndHoldEnabledProperty.ToString());
			Assert.AreEqual (typeof (bool), Stylus.IsPressAndHoldEnabledProperty.PropertyType);
			Assert.IsFalse (Stylus.IsPressAndHoldEnabledProperty.ReadOnly);

			Assert.AreEqual (typeof (Stylus), Stylus.IsFlicksEnabledProperty.OwnerType);
			Assert.AreEqual ("IsFlicksEnabled", Stylus.IsFlicksEnabledProperty.Name);
			Assert.AreEqual ("IsFlicksEnabled", Stylus.IsFlicksEnabledProperty.ToString());
			Assert.AreEqual (typeof (bool), Stylus.IsFlicksEnabledProperty.PropertyType);
			Assert.IsFalse (Stylus.IsFlicksEnabledProperty.ReadOnly);

			Assert.AreEqual (typeof (Stylus), Stylus.IsTapFeedbackEnabledProperty.OwnerType);
			Assert.AreEqual ("IsTapFeedbackEnabled", Stylus.IsTapFeedbackEnabledProperty.Name);
			Assert.AreEqual ("IsTapFeedbackEnabled", Stylus.IsTapFeedbackEnabledProperty.ToString());
			Assert.AreEqual (typeof (bool), Stylus.IsTapFeedbackEnabledProperty.PropertyType);
			Assert.IsFalse (Stylus.IsTapFeedbackEnabledProperty.ReadOnly);

			Assert.AreEqual (typeof (Stylus), Stylus.IsTouchFeedbackEnabledProperty.OwnerType);
			Assert.AreEqual ("IsTouchFeedbackEnabled", Stylus.IsTouchFeedbackEnabledProperty.Name);
			Assert.AreEqual ("IsTouchFeedbackEnabled", Stylus.IsTouchFeedbackEnabledProperty.ToString());
			Assert.AreEqual (typeof (bool), Stylus.IsTouchFeedbackEnabledProperty.PropertyType);
			Assert.IsFalse (Stylus.IsTouchFeedbackEnabledProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.TextDecoration
namespace MonoTests.System.Windows {
	public partial class TextDecorationTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (TextDecoration), TextDecoration.PenProperty.OwnerType);
			Assert.AreEqual ("Pen", TextDecoration.PenProperty.Name);
			Assert.AreEqual ("Pen", TextDecoration.PenProperty.ToString());
			Assert.AreEqual (typeof (Pen), TextDecoration.PenProperty.PropertyType);
			Assert.IsFalse (TextDecoration.PenProperty.ReadOnly);

			Assert.AreEqual (typeof (TextDecoration), TextDecoration.PenOffsetProperty.OwnerType);
			Assert.AreEqual ("PenOffset", TextDecoration.PenOffsetProperty.Name);
			Assert.AreEqual ("PenOffset", TextDecoration.PenOffsetProperty.ToString());
			Assert.AreEqual (typeof (double), TextDecoration.PenOffsetProperty.PropertyType);
			Assert.IsFalse (TextDecoration.PenOffsetProperty.ReadOnly);

			Assert.AreEqual (typeof (TextDecoration), TextDecoration.PenOffsetUnitProperty.OwnerType);
			Assert.AreEqual ("PenOffsetUnit", TextDecoration.PenOffsetUnitProperty.Name);
			Assert.AreEqual ("PenOffsetUnit", TextDecoration.PenOffsetUnitProperty.ToString());
			Assert.AreEqual (typeof (TextDecorationUnit), TextDecoration.PenOffsetUnitProperty.PropertyType);
			Assert.IsFalse (TextDecoration.PenOffsetUnitProperty.ReadOnly);

			Assert.AreEqual (typeof (TextDecoration), TextDecoration.PenThicknessUnitProperty.OwnerType);
			Assert.AreEqual ("PenThicknessUnit", TextDecoration.PenThicknessUnitProperty.Name);
			Assert.AreEqual ("PenThicknessUnit", TextDecoration.PenThicknessUnitProperty.ToString());
			Assert.AreEqual (typeof (TextDecorationUnit), TextDecoration.PenThicknessUnitProperty.PropertyType);
			Assert.IsFalse (TextDecoration.PenThicknessUnitProperty.ReadOnly);

			Assert.AreEqual (typeof (TextDecoration), TextDecoration.LocationProperty.OwnerType);
			Assert.AreEqual ("Location", TextDecoration.LocationProperty.Name);
			Assert.AreEqual ("Location", TextDecoration.LocationProperty.ToString());
			Assert.AreEqual (typeof (TextDecorationLocation), TextDecoration.LocationProperty.PropertyType);
			Assert.IsFalse (TextDecoration.LocationProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.TextEffect
namespace MonoTests.System.Windows.Media {
	public partial class TextEffectTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (TextEffect), TextEffect.TransformProperty.OwnerType);
			Assert.AreEqual ("Transform", TextEffect.TransformProperty.Name);
			Assert.AreEqual ("Transform", TextEffect.TransformProperty.ToString());
			Assert.AreEqual (typeof (Transform), TextEffect.TransformProperty.PropertyType);
			Assert.IsFalse (TextEffect.TransformProperty.ReadOnly);

			Assert.AreEqual (typeof (TextEffect), TextEffect.ClipProperty.OwnerType);
			Assert.AreEqual ("Clip", TextEffect.ClipProperty.Name);
			Assert.AreEqual ("Clip", TextEffect.ClipProperty.ToString());
			Assert.AreEqual (typeof (Geometry), TextEffect.ClipProperty.PropertyType);
			Assert.IsFalse (TextEffect.ClipProperty.ReadOnly);

			Assert.AreEqual (typeof (TextEffect), TextEffect.ForegroundProperty.OwnerType);
			Assert.AreEqual ("Foreground", TextEffect.ForegroundProperty.Name);
			Assert.AreEqual ("Foreground", TextEffect.ForegroundProperty.ToString());
			Assert.AreEqual (typeof (Brush), TextEffect.ForegroundProperty.PropertyType);
			Assert.IsFalse (TextEffect.ForegroundProperty.ReadOnly);

			Assert.AreEqual (typeof (TextEffect), TextEffect.PositionStartProperty.OwnerType);
			Assert.AreEqual ("PositionStart", TextEffect.PositionStartProperty.Name);
			Assert.AreEqual ("PositionStart", TextEffect.PositionStartProperty.ToString());
			Assert.AreEqual (typeof (int), TextEffect.PositionStartProperty.PropertyType);
			Assert.IsFalse (TextEffect.PositionStartProperty.ReadOnly);

			Assert.AreEqual (typeof (TextEffect), TextEffect.PositionCountProperty.OwnerType);
			Assert.AreEqual ("PositionCount", TextEffect.PositionCountProperty.Name);
			Assert.AreEqual ("PositionCount", TextEffect.PositionCountProperty.ToString());
			Assert.AreEqual (typeof (int), TextEffect.PositionCountProperty.PropertyType);
			Assert.IsFalse (TextEffect.PositionCountProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.TileBrush
namespace MonoTests.System.Windows.Media {
	public partial class TileBrushTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (TileBrush), TileBrush.ViewportUnitsProperty.OwnerType);
			Assert.AreEqual ("ViewportUnits", TileBrush.ViewportUnitsProperty.Name);
			Assert.AreEqual ("ViewportUnits", TileBrush.ViewportUnitsProperty.ToString());
			Assert.AreEqual (typeof (BrushMappingMode), TileBrush.ViewportUnitsProperty.PropertyType);
			Assert.IsFalse (TileBrush.ViewportUnitsProperty.ReadOnly);

			Assert.AreEqual (typeof (TileBrush), TileBrush.ViewboxUnitsProperty.OwnerType);
			Assert.AreEqual ("ViewboxUnits", TileBrush.ViewboxUnitsProperty.Name);
			Assert.AreEqual ("ViewboxUnits", TileBrush.ViewboxUnitsProperty.ToString());
			Assert.AreEqual (typeof (BrushMappingMode), TileBrush.ViewboxUnitsProperty.PropertyType);
			Assert.IsFalse (TileBrush.ViewboxUnitsProperty.ReadOnly);

			Assert.AreEqual (typeof (TileBrush), TileBrush.ViewportProperty.OwnerType);
			Assert.AreEqual ("Viewport", TileBrush.ViewportProperty.Name);
			Assert.AreEqual ("Viewport", TileBrush.ViewportProperty.ToString());
			Assert.AreEqual (typeof (Rect), TileBrush.ViewportProperty.PropertyType);
			Assert.IsFalse (TileBrush.ViewportProperty.ReadOnly);

			Assert.AreEqual (typeof (TileBrush), TileBrush.ViewboxProperty.OwnerType);
			Assert.AreEqual ("Viewbox", TileBrush.ViewboxProperty.Name);
			Assert.AreEqual ("Viewbox", TileBrush.ViewboxProperty.ToString());
			Assert.AreEqual (typeof (Rect), TileBrush.ViewboxProperty.PropertyType);
			Assert.IsFalse (TileBrush.ViewboxProperty.ReadOnly);

			Assert.AreEqual (typeof (TileBrush), TileBrush.StretchProperty.OwnerType);
			Assert.AreEqual ("Stretch", TileBrush.StretchProperty.Name);
			Assert.AreEqual ("Stretch", TileBrush.StretchProperty.ToString());
			Assert.AreEqual (typeof (Stretch), TileBrush.StretchProperty.PropertyType);
			Assert.IsFalse (TileBrush.StretchProperty.ReadOnly);

			Assert.AreEqual (typeof (TileBrush), TileBrush.TileModeProperty.OwnerType);
			Assert.AreEqual ("TileMode", TileBrush.TileModeProperty.Name);
			Assert.AreEqual ("TileMode", TileBrush.TileModeProperty.ToString());
			Assert.AreEqual (typeof (TileMode), TileBrush.TileModeProperty.PropertyType);
			Assert.IsFalse (TileBrush.TileModeProperty.ReadOnly);

			Assert.AreEqual (typeof (TileBrush), TileBrush.AlignmentXProperty.OwnerType);
			Assert.AreEqual ("AlignmentX", TileBrush.AlignmentXProperty.Name);
			Assert.AreEqual ("AlignmentX", TileBrush.AlignmentXProperty.ToString());
			Assert.AreEqual (typeof (AlignmentX), TileBrush.AlignmentXProperty.PropertyType);
			Assert.IsFalse (TileBrush.AlignmentXProperty.ReadOnly);

			Assert.AreEqual (typeof (TileBrush), TileBrush.AlignmentYProperty.OwnerType);
			Assert.AreEqual ("AlignmentY", TileBrush.AlignmentYProperty.Name);
			Assert.AreEqual ("AlignmentY", TileBrush.AlignmentYProperty.ToString());
			Assert.AreEqual (typeof (AlignmentY), TileBrush.AlignmentYProperty.PropertyType);
			Assert.IsFalse (TileBrush.AlignmentYProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Animation.Timeline
namespace MonoTests.System.Windows.Media.Animation {
	public partial class TimelineTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (Timeline), Timeline.AccelerationRatioProperty.OwnerType);
			Assert.AreEqual ("AccelerationRatio", Timeline.AccelerationRatioProperty.Name);
			Assert.AreEqual ("AccelerationRatio", Timeline.AccelerationRatioProperty.ToString());
			Assert.AreEqual (typeof (double), Timeline.AccelerationRatioProperty.PropertyType);
			Assert.IsFalse (Timeline.AccelerationRatioProperty.ReadOnly);

			Assert.AreEqual (typeof (Timeline), Timeline.AutoReverseProperty.OwnerType);
			Assert.AreEqual ("AutoReverse", Timeline.AutoReverseProperty.Name);
			Assert.AreEqual ("AutoReverse", Timeline.AutoReverseProperty.ToString());
			Assert.AreEqual (typeof (bool), Timeline.AutoReverseProperty.PropertyType);
			Assert.IsFalse (Timeline.AutoReverseProperty.ReadOnly);

			Assert.AreEqual (typeof (Timeline), Timeline.BeginTimeProperty.OwnerType);
			Assert.AreEqual ("BeginTime", Timeline.BeginTimeProperty.Name);
			Assert.AreEqual ("BeginTime", Timeline.BeginTimeProperty.ToString());
			Assert.AreEqual (typeof (TimeSpan?), Timeline.BeginTimeProperty.PropertyType);
			Assert.IsFalse (Timeline.BeginTimeProperty.ReadOnly);

			Assert.AreEqual (typeof (Timeline), Timeline.DecelerationRatioProperty.OwnerType);
			Assert.AreEqual ("DecelerationRatio", Timeline.DecelerationRatioProperty.Name);
			Assert.AreEqual ("DecelerationRatio", Timeline.DecelerationRatioProperty.ToString());
			Assert.AreEqual (typeof (double), Timeline.DecelerationRatioProperty.PropertyType);
			Assert.IsFalse (Timeline.DecelerationRatioProperty.ReadOnly);

			Assert.AreEqual (typeof (Timeline), Timeline.DesiredFrameRateProperty.OwnerType);
			Assert.AreEqual ("DesiredFrameRate", Timeline.DesiredFrameRateProperty.Name);
			Assert.AreEqual ("DesiredFrameRate", Timeline.DesiredFrameRateProperty.ToString());
			Assert.AreEqual (typeof (int?), Timeline.DesiredFrameRateProperty.PropertyType);
			Assert.IsFalse (Timeline.DesiredFrameRateProperty.ReadOnly);

			Assert.AreEqual (typeof (Timeline), Timeline.DurationProperty.OwnerType);
			Assert.AreEqual ("Duration", Timeline.DurationProperty.Name);
			Assert.AreEqual ("Duration", Timeline.DurationProperty.ToString());
			Assert.AreEqual (typeof (Duration), Timeline.DurationProperty.PropertyType);
			Assert.IsFalse (Timeline.DurationProperty.ReadOnly);

			Assert.AreEqual (typeof (Timeline), Timeline.FillBehaviorProperty.OwnerType);
			Assert.AreEqual ("FillBehavior", Timeline.FillBehaviorProperty.Name);
			Assert.AreEqual ("FillBehavior", Timeline.FillBehaviorProperty.ToString());
			Assert.AreEqual (typeof (FillBehavior), Timeline.FillBehaviorProperty.PropertyType);
			Assert.IsFalse (Timeline.FillBehaviorProperty.ReadOnly);

			Assert.AreEqual (typeof (Timeline), Timeline.NameProperty.OwnerType);
			Assert.AreEqual ("Name", Timeline.NameProperty.Name);
			Assert.AreEqual ("Name", Timeline.NameProperty.ToString());
			Assert.AreEqual (typeof (string), Timeline.NameProperty.PropertyType);
			Assert.IsFalse (Timeline.NameProperty.ReadOnly);

			Assert.AreEqual (typeof (Timeline), Timeline.RepeatBehaviorProperty.OwnerType);
			Assert.AreEqual ("RepeatBehavior", Timeline.RepeatBehaviorProperty.Name);
			Assert.AreEqual ("RepeatBehavior", Timeline.RepeatBehaviorProperty.ToString());
			Assert.AreEqual (typeof (RepeatBehavior), Timeline.RepeatBehaviorProperty.PropertyType);
			Assert.IsFalse (Timeline.RepeatBehaviorProperty.ReadOnly);

			Assert.AreEqual (typeof (Timeline), Timeline.SpeedRatioProperty.OwnerType);
			Assert.AreEqual ("SpeedRatio", Timeline.SpeedRatioProperty.Name);
			Assert.AreEqual ("SpeedRatio", Timeline.SpeedRatioProperty.ToString());
			Assert.AreEqual (typeof (double), Timeline.SpeedRatioProperty.PropertyType);
			Assert.IsFalse (Timeline.SpeedRatioProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.Animation.TimelineGroup
namespace MonoTests.System.Windows.Media.Animation {
	public partial class TimelineGroupTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (TimelineGroup), TimelineGroup.ChildrenProperty.OwnerType);
			Assert.AreEqual ("Children", TimelineGroup.ChildrenProperty.Name);
			Assert.AreEqual ("Children", TimelineGroup.ChildrenProperty.ToString());
			Assert.AreEqual (typeof (TimelineCollection), TimelineGroup.ChildrenProperty.PropertyType);
			Assert.IsFalse (TimelineGroup.ChildrenProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Media3D.Transform3DGroup
namespace MonoTests.System.Windows.Media.Media3D {
	public partial class Transform3DGroupTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (Transform3DGroup), Transform3DGroup.ChildrenProperty.OwnerType);
			Assert.AreEqual ("Children", Transform3DGroup.ChildrenProperty.Name);
			Assert.AreEqual ("Children", Transform3DGroup.ChildrenProperty.ToString());
			Assert.AreEqual (typeof (Transform3DCollection), Transform3DGroup.ChildrenProperty.PropertyType);
			Assert.IsFalse (Transform3DGroup.ChildrenProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Imaging.TransformedBitmap
namespace MonoTests.System.Windows.Media.Imaging {
	public partial class TransformedBitmapTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (TransformedBitmap), TransformedBitmap.SourceProperty.OwnerType);
			Assert.AreEqual ("Source", TransformedBitmap.SourceProperty.Name);
			Assert.AreEqual ("Source", TransformedBitmap.SourceProperty.ToString());
			Assert.AreEqual (typeof (BitmapSource), TransformedBitmap.SourceProperty.PropertyType);
			Assert.IsFalse (TransformedBitmap.SourceProperty.ReadOnly);

			Assert.AreEqual (typeof (TransformedBitmap), TransformedBitmap.TransformProperty.OwnerType);
			Assert.AreEqual ("Transform", TransformedBitmap.TransformProperty.Name);
			Assert.AreEqual ("Transform", TransformedBitmap.TransformProperty.ToString());
			Assert.AreEqual (typeof (Transform), TransformedBitmap.TransformProperty.PropertyType);
			Assert.IsFalse (TransformedBitmap.TransformProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.TransformGroup
namespace MonoTests.System.Windows.Media {
	public partial class TransformGroupTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (TransformGroup), TransformGroup.ChildrenProperty.OwnerType);
			Assert.AreEqual ("Children", TransformGroup.ChildrenProperty.Name);
			Assert.AreEqual ("Children", TransformGroup.ChildrenProperty.ToString());
			Assert.AreEqual (typeof (TransformCollection), TransformGroup.ChildrenProperty.PropertyType);
			Assert.IsFalse (TransformGroup.ChildrenProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.TranslateTransform
namespace MonoTests.System.Windows.Media {
	public partial class TranslateTransformTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (TranslateTransform), TranslateTransform.XProperty.OwnerType);
			Assert.AreEqual ("X", TranslateTransform.XProperty.Name);
			Assert.AreEqual ("X", TranslateTransform.XProperty.ToString());
			Assert.AreEqual (typeof (double), TranslateTransform.XProperty.PropertyType);
			Assert.IsFalse (TranslateTransform.XProperty.ReadOnly);

			Assert.AreEqual (typeof (TranslateTransform), TranslateTransform.YProperty.OwnerType);
			Assert.AreEqual ("Y", TranslateTransform.YProperty.Name);
			Assert.AreEqual ("Y", TranslateTransform.YProperty.ToString());
			Assert.AreEqual (typeof (double), TranslateTransform.YProperty.PropertyType);
			Assert.IsFalse (TranslateTransform.YProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.Media3D.TranslateTransform3D
namespace MonoTests.System.Windows.Media.Media3D {
	public partial class TranslateTransform3DTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (TranslateTransform3D), TranslateTransform3D.OffsetXProperty.OwnerType);
			Assert.AreEqual ("OffsetX", TranslateTransform3D.OffsetXProperty.Name);
			Assert.AreEqual ("OffsetX", TranslateTransform3D.OffsetXProperty.ToString());
			Assert.AreEqual (typeof (double), TranslateTransform3D.OffsetXProperty.PropertyType);
			Assert.IsFalse (TranslateTransform3D.OffsetXProperty.ReadOnly);

			Assert.AreEqual (typeof (TranslateTransform3D), TranslateTransform3D.OffsetYProperty.OwnerType);
			Assert.AreEqual ("OffsetY", TranslateTransform3D.OffsetYProperty.Name);
			Assert.AreEqual ("OffsetY", TranslateTransform3D.OffsetYProperty.ToString());
			Assert.AreEqual (typeof (double), TranslateTransform3D.OffsetYProperty.PropertyType);
			Assert.IsFalse (TranslateTransform3D.OffsetYProperty.ReadOnly);

			Assert.AreEqual (typeof (TranslateTransform3D), TranslateTransform3D.OffsetZProperty.OwnerType);
			Assert.AreEqual ("OffsetZ", TranslateTransform3D.OffsetZProperty.Name);
			Assert.AreEqual ("OffsetZ", TranslateTransform3D.OffsetZProperty.ToString());
			Assert.AreEqual (typeof (double), TranslateTransform3D.OffsetZProperty.PropertyType);
			Assert.IsFalse (TranslateTransform3D.OffsetZProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.UIElement
namespace MonoTests.System.Windows {
	public partial class UIElementTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (UIElement), UIElement.IsMouseDirectlyOverProperty.OwnerType);
			Assert.AreEqual ("IsMouseDirectlyOver", UIElement.IsMouseDirectlyOverProperty.Name);
			Assert.AreEqual ("IsMouseDirectlyOver", UIElement.IsMouseDirectlyOverProperty.ToString());
			Assert.AreEqual (typeof (bool), UIElement.IsMouseDirectlyOverProperty.PropertyType);
			Assert.IsTrue (UIElement.IsMouseDirectlyOverProperty.ReadOnly);

			Assert.AreEqual (typeof (UIElement), UIElement.IsMouseOverProperty.OwnerType);
			Assert.AreEqual ("IsMouseOver", UIElement.IsMouseOverProperty.Name);
			Assert.AreEqual ("IsMouseOver", UIElement.IsMouseOverProperty.ToString());
			Assert.AreEqual (typeof (bool), UIElement.IsMouseOverProperty.PropertyType);
			Assert.IsTrue (UIElement.IsMouseOverProperty.ReadOnly);

			Assert.AreEqual (typeof (UIElement), UIElement.IsStylusOverProperty.OwnerType);
			Assert.AreEqual ("IsStylusOver", UIElement.IsStylusOverProperty.Name);
			Assert.AreEqual ("IsStylusOver", UIElement.IsStylusOverProperty.ToString());
			Assert.AreEqual (typeof (bool), UIElement.IsStylusOverProperty.PropertyType);
			Assert.IsTrue (UIElement.IsStylusOverProperty.ReadOnly);

			Assert.AreEqual (typeof (UIElement), UIElement.IsKeyboardFocusWithinProperty.OwnerType);
			Assert.AreEqual ("IsKeyboardFocusWithin", UIElement.IsKeyboardFocusWithinProperty.Name);
			Assert.AreEqual ("IsKeyboardFocusWithin", UIElement.IsKeyboardFocusWithinProperty.ToString());
			Assert.AreEqual (typeof (bool), UIElement.IsKeyboardFocusWithinProperty.PropertyType);
			Assert.IsTrue (UIElement.IsKeyboardFocusWithinProperty.ReadOnly);

			Assert.AreEqual (typeof (UIElement), UIElement.IsMouseCapturedProperty.OwnerType);
			Assert.AreEqual ("IsMouseCaptured", UIElement.IsMouseCapturedProperty.Name);
			Assert.AreEqual ("IsMouseCaptured", UIElement.IsMouseCapturedProperty.ToString());
			Assert.AreEqual (typeof (bool), UIElement.IsMouseCapturedProperty.PropertyType);
			Assert.IsTrue (UIElement.IsMouseCapturedProperty.ReadOnly);

			Assert.AreEqual (typeof (UIElement), UIElement.IsMouseCaptureWithinProperty.OwnerType);
			Assert.AreEqual ("IsMouseCaptureWithin", UIElement.IsMouseCaptureWithinProperty.Name);
			Assert.AreEqual ("IsMouseCaptureWithin", UIElement.IsMouseCaptureWithinProperty.ToString());
			Assert.AreEqual (typeof (bool), UIElement.IsMouseCaptureWithinProperty.PropertyType);
			Assert.IsTrue (UIElement.IsMouseCaptureWithinProperty.ReadOnly);

			Assert.AreEqual (typeof (UIElement), UIElement.IsStylusDirectlyOverProperty.OwnerType);
			Assert.AreEqual ("IsStylusDirectlyOver", UIElement.IsStylusDirectlyOverProperty.Name);
			Assert.AreEqual ("IsStylusDirectlyOver", UIElement.IsStylusDirectlyOverProperty.ToString());
			Assert.AreEqual (typeof (bool), UIElement.IsStylusDirectlyOverProperty.PropertyType);
			Assert.IsTrue (UIElement.IsStylusDirectlyOverProperty.ReadOnly);

			Assert.AreEqual (typeof (UIElement), UIElement.IsStylusCapturedProperty.OwnerType);
			Assert.AreEqual ("IsStylusCaptured", UIElement.IsStylusCapturedProperty.Name);
			Assert.AreEqual ("IsStylusCaptured", UIElement.IsStylusCapturedProperty.ToString());
			Assert.AreEqual (typeof (bool), UIElement.IsStylusCapturedProperty.PropertyType);
			Assert.IsTrue (UIElement.IsStylusCapturedProperty.ReadOnly);

			Assert.AreEqual (typeof (UIElement), UIElement.IsStylusCaptureWithinProperty.OwnerType);
			Assert.AreEqual ("IsStylusCaptureWithin", UIElement.IsStylusCaptureWithinProperty.Name);
			Assert.AreEqual ("IsStylusCaptureWithin", UIElement.IsStylusCaptureWithinProperty.ToString());
			Assert.AreEqual (typeof (bool), UIElement.IsStylusCaptureWithinProperty.PropertyType);
			Assert.IsTrue (UIElement.IsStylusCaptureWithinProperty.ReadOnly);

			Assert.AreEqual (typeof (UIElement), UIElement.IsKeyboardFocusedProperty.OwnerType);
			Assert.AreEqual ("IsKeyboardFocused", UIElement.IsKeyboardFocusedProperty.Name);
			Assert.AreEqual ("IsKeyboardFocused", UIElement.IsKeyboardFocusedProperty.ToString());
			Assert.AreEqual (typeof (bool), UIElement.IsKeyboardFocusedProperty.PropertyType);
			Assert.IsTrue (UIElement.IsKeyboardFocusedProperty.ReadOnly);

			Assert.AreEqual (typeof (UIElement), UIElement.AllowDropProperty.OwnerType);
			Assert.AreEqual ("AllowDrop", UIElement.AllowDropProperty.Name);
			Assert.AreEqual ("AllowDrop", UIElement.AllowDropProperty.ToString());
			Assert.AreEqual (typeof (bool), UIElement.AllowDropProperty.PropertyType);
			Assert.IsFalse (UIElement.AllowDropProperty.ReadOnly);

			Assert.AreEqual (typeof (UIElement), UIElement.RenderTransformProperty.OwnerType);
			Assert.AreEqual ("RenderTransform", UIElement.RenderTransformProperty.Name);
			Assert.AreEqual ("RenderTransform", UIElement.RenderTransformProperty.ToString());
			Assert.AreEqual (typeof (Transform), UIElement.RenderTransformProperty.PropertyType);
			Assert.IsFalse (UIElement.RenderTransformProperty.ReadOnly);

			Assert.AreEqual (typeof (UIElement), UIElement.RenderTransformOriginProperty.OwnerType);
			Assert.AreEqual ("RenderTransformOrigin", UIElement.RenderTransformOriginProperty.Name);
			Assert.AreEqual ("RenderTransformOrigin", UIElement.RenderTransformOriginProperty.ToString());
			Assert.AreEqual (typeof (Point), UIElement.RenderTransformOriginProperty.PropertyType);
			Assert.IsFalse (UIElement.RenderTransformOriginProperty.ReadOnly);

			Assert.AreEqual (typeof (UIElement), UIElement.OpacityProperty.OwnerType);
			Assert.AreEqual ("Opacity", UIElement.OpacityProperty.Name);
			Assert.AreEqual ("Opacity", UIElement.OpacityProperty.ToString());
			Assert.AreEqual (typeof (double), UIElement.OpacityProperty.PropertyType);
			Assert.IsFalse (UIElement.OpacityProperty.ReadOnly);

			Assert.AreEqual (typeof (UIElement), UIElement.OpacityMaskProperty.OwnerType);
			Assert.AreEqual ("OpacityMask", UIElement.OpacityMaskProperty.Name);
			Assert.AreEqual ("OpacityMask", UIElement.OpacityMaskProperty.ToString());
			Assert.AreEqual (typeof (Brush), UIElement.OpacityMaskProperty.PropertyType);
			Assert.IsFalse (UIElement.OpacityMaskProperty.ReadOnly);

#if notyet
			Assert.AreEqual (typeof (UIElement), UIElement.BitmapEffectProperty.OwnerType);
			Assert.AreEqual ("BitmapEffect", UIElement.BitmapEffectProperty.Name);
			Assert.AreEqual ("BitmapEffect", UIElement.BitmapEffectProperty.ToString());
			Assert.AreEqual (typeof (BitmapEffect), UIElement.BitmapEffectProperty.PropertyType);
			Assert.IsFalse (UIElement.BitmapEffectProperty.ReadOnly);

			Assert.AreEqual (typeof (UIElement), UIElement.EffectProperty.OwnerType);
			Assert.AreEqual ("Effect", UIElement.EffectProperty.Name);
			Assert.AreEqual ("Effect", UIElement.EffectProperty.ToString());
			Assert.AreEqual (typeof (Effect), UIElement.EffectProperty.PropertyType);
			Assert.IsFalse (UIElement.EffectProperty.ReadOnly);

			Assert.AreEqual (typeof (UIElement), UIElement.BitmapEffectInputProperty.OwnerType);
			Assert.AreEqual ("BitmapEffectInput", UIElement.BitmapEffectInputProperty.Name);
			Assert.AreEqual ("BitmapEffectInput", UIElement.BitmapEffectInputProperty.ToString());
			Assert.AreEqual (typeof (BitmapEffectInput), UIElement.BitmapEffectInputProperty.PropertyType);
			Assert.IsFalse (UIElement.BitmapEffectInputProperty.ReadOnly);

			Assert.AreEqual (typeof (UIElement), UIElement.UidProperty.OwnerType);
			Assert.AreEqual ("Uid", UIElement.UidProperty.Name);
			Assert.AreEqual ("Uid", UIElement.UidProperty.ToString());
			Assert.AreEqual (typeof (string), UIElement.UidProperty.PropertyType);
			Assert.IsFalse (UIElement.UidProperty.ReadOnly);
#endif

			Assert.AreEqual (typeof (UIElement), UIElement.VisibilityProperty.OwnerType);
			Assert.AreEqual ("Visibility", UIElement.VisibilityProperty.Name);
			Assert.AreEqual ("Visibility", UIElement.VisibilityProperty.ToString());
			Assert.AreEqual (typeof (Visibility), UIElement.VisibilityProperty.PropertyType);
			Assert.IsFalse (UIElement.VisibilityProperty.ReadOnly);

			Assert.AreEqual (typeof (UIElement), UIElement.ClipToBoundsProperty.OwnerType);
			Assert.AreEqual ("ClipToBounds", UIElement.ClipToBoundsProperty.Name);
			Assert.AreEqual ("ClipToBounds", UIElement.ClipToBoundsProperty.ToString());
			Assert.AreEqual (typeof (bool), UIElement.ClipToBoundsProperty.PropertyType);
			Assert.IsFalse (UIElement.ClipToBoundsProperty.ReadOnly);

#if notyet
			Assert.AreEqual (typeof (UIElement), UIElement.ClipProperty.OwnerType);
			Assert.AreEqual ("Clip", UIElement.ClipProperty.Name);
			Assert.AreEqual ("Clip", UIElement.ClipProperty.ToString());
			Assert.AreEqual (typeof (Geometry), UIElement.ClipProperty.PropertyType);
			Assert.IsFalse (UIElement.ClipProperty.ReadOnly);
#endif

			Assert.AreEqual (typeof (UIElement), UIElement.SnapsToDevicePixelsProperty.OwnerType);
			Assert.AreEqual ("SnapsToDevicePixels", UIElement.SnapsToDevicePixelsProperty.Name);
			Assert.AreEqual ("SnapsToDevicePixels", UIElement.SnapsToDevicePixelsProperty.ToString());
			Assert.AreEqual (typeof (bool), UIElement.SnapsToDevicePixelsProperty.PropertyType);
			Assert.IsFalse (UIElement.SnapsToDevicePixelsProperty.ReadOnly);

			Assert.AreEqual (typeof (UIElement), UIElement.IsFocusedProperty.OwnerType);
			Assert.AreEqual ("IsFocused", UIElement.IsFocusedProperty.Name);
			Assert.AreEqual ("IsFocused", UIElement.IsFocusedProperty.ToString());
			Assert.AreEqual (typeof (bool), UIElement.IsFocusedProperty.PropertyType);
			Assert.IsTrue (UIElement.IsFocusedProperty.ReadOnly);

			Assert.AreEqual (typeof (UIElement), UIElement.IsEnabledProperty.OwnerType);
			Assert.AreEqual ("IsEnabled", UIElement.IsEnabledProperty.Name);
			Assert.AreEqual ("IsEnabled", UIElement.IsEnabledProperty.ToString());
			Assert.AreEqual (typeof (bool), UIElement.IsEnabledProperty.PropertyType);
			Assert.IsFalse (UIElement.IsEnabledProperty.ReadOnly);

			Assert.AreEqual (typeof (UIElement), UIElement.IsHitTestVisibleProperty.OwnerType);
			Assert.AreEqual ("IsHitTestVisible", UIElement.IsHitTestVisibleProperty.Name);
			Assert.AreEqual ("IsHitTestVisible", UIElement.IsHitTestVisibleProperty.ToString());
			Assert.AreEqual (typeof (bool), UIElement.IsHitTestVisibleProperty.PropertyType);
			Assert.IsFalse (UIElement.IsHitTestVisibleProperty.ReadOnly);

			Assert.AreEqual (typeof (UIElement), UIElement.IsVisibleProperty.OwnerType);
			Assert.AreEqual ("IsVisible", UIElement.IsVisibleProperty.Name);
			Assert.AreEqual ("IsVisible", UIElement.IsVisibleProperty.ToString());
			Assert.AreEqual (typeof (bool), UIElement.IsVisibleProperty.PropertyType);
			Assert.IsTrue (UIElement.IsVisibleProperty.ReadOnly);

			Assert.AreEqual (typeof (UIElement), UIElement.FocusableProperty.OwnerType);
			Assert.AreEqual ("Focusable", UIElement.FocusableProperty.Name);
			Assert.AreEqual ("Focusable", UIElement.FocusableProperty.ToString());
			Assert.AreEqual (typeof (bool), UIElement.FocusableProperty.PropertyType);
			Assert.IsFalse (UIElement.FocusableProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.UIElement3D
namespace MonoTests.System.Windows {
	public partial class UIElement3DTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreSame (UIElement3D.IsMouseDirectlyOverProperty, UIElement.IsMouseDirectlyOverProperty);
			Assert.AreSame (UIElement3D.IsMouseOverProperty, UIElement.IsMouseOverProperty);
			Assert.AreSame (UIElement3D.IsStylusOverProperty, UIElement.IsStylusOverProperty);
			Assert.AreSame (UIElement3D.IsKeyboardFocusWithinProperty, UIElement.IsKeyboardFocusWithinProperty);
			Assert.AreSame (UIElement3D.IsMouseCapturedProperty, UIElement.IsMouseCapturedProperty);
			Assert.AreSame (UIElement3D.IsMouseCaptureWithinProperty, UIElement.IsMouseCaptureWithinProperty);
			Assert.AreSame (UIElement3D.IsStylusDirectlyOverProperty, UIElement.IsStylusDirectlyOverProperty);
			Assert.AreSame (UIElement3D.IsStylusCapturedProperty, UIElement.IsStylusCapturedProperty);
			Assert.AreSame (UIElement3D.IsStylusCaptureWithinProperty, UIElement.IsStylusCaptureWithinProperty);
			Assert.AreSame (UIElement3D.IsKeyboardFocusedProperty, UIElement.IsKeyboardFocusedProperty);
			Assert.AreSame (UIElement3D.AllowDropProperty, UIElement.AllowDropProperty);
			Assert.AreSame (UIElement3D.VisibilityProperty, UIElement.VisibilityProperty);
			Assert.AreSame (UIElement3D.IsFocusedProperty, UIElement.IsFocusedProperty);
			Assert.AreSame (UIElement3D.IsEnabledProperty, UIElement.IsEnabledProperty);
			Assert.AreSame (UIElement3D.IsHitTestVisibleProperty, UIElement.IsHitTestVisibleProperty);
			Assert.AreSame (UIElement3D.IsVisibleProperty, UIElement.IsVisibleProperty);
			Assert.AreSame (UIElement3D.FocusableProperty, UIElement.FocusableProperty);
#endif
		}
	}
}
//   Type: System.Windows.Media.Animation.Vector3DAnimation
namespace MonoTests.System.Windows.Media.Animation {
	public partial class Vector3DAnimationTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (Vector3DAnimation), Vector3DAnimation.FromProperty.OwnerType);
			Assert.AreEqual ("From", Vector3DAnimation.FromProperty.Name);
			Assert.AreEqual ("From", Vector3DAnimation.FromProperty.ToString());
			Assert.AreEqual (typeof (Vector3D?), Vector3DAnimation.FromProperty.PropertyType);
			Assert.IsFalse (Vector3DAnimation.FromProperty.ReadOnly);

			Assert.AreEqual (typeof (Vector3DAnimation), Vector3DAnimation.ToProperty.OwnerType);
			Assert.AreEqual ("To", Vector3DAnimation.ToProperty.Name);
			Assert.AreEqual ("To", Vector3DAnimation.ToProperty.ToString());
			Assert.AreEqual (typeof (Vector3D?), Vector3DAnimation.ToProperty.PropertyType);
			Assert.IsFalse (Vector3DAnimation.ToProperty.ReadOnly);

			Assert.AreEqual (typeof (Vector3DAnimation), Vector3DAnimation.ByProperty.OwnerType);
			Assert.AreEqual ("By", Vector3DAnimation.ByProperty.Name);
			Assert.AreEqual ("By", Vector3DAnimation.ByProperty.ToString());
			Assert.AreEqual (typeof (Vector3D?), Vector3DAnimation.ByProperty.PropertyType);
			Assert.IsFalse (Vector3DAnimation.ByProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Animation.Vector3DKeyFrame
namespace MonoTests.System.Windows.Media.Animation {
	public partial class Vector3DKeyFrameTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (Vector3DKeyFrame), Vector3DKeyFrame.KeyTimeProperty.OwnerType);
			Assert.AreEqual ("KeyTime", Vector3DKeyFrame.KeyTimeProperty.Name);
			Assert.AreEqual ("KeyTime", Vector3DKeyFrame.KeyTimeProperty.ToString());
			Assert.AreEqual (typeof (KeyTime), Vector3DKeyFrame.KeyTimeProperty.PropertyType);
			Assert.IsFalse (Vector3DKeyFrame.KeyTimeProperty.ReadOnly);

			Assert.AreEqual (typeof (Vector3DKeyFrame), Vector3DKeyFrame.ValueProperty.OwnerType);
			Assert.AreEqual ("Value", Vector3DKeyFrame.ValueProperty.Name);
			Assert.AreEqual ("Value", Vector3DKeyFrame.ValueProperty.ToString());
			Assert.AreEqual (typeof (Vector3D), Vector3DKeyFrame.ValueProperty.PropertyType);
			Assert.IsFalse (Vector3DKeyFrame.ValueProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Animation.VectorAnimation
namespace MonoTests.System.Windows.Media.Animation {
	public partial class VectorAnimationTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (VectorAnimation), VectorAnimation.FromProperty.OwnerType);
			Assert.AreEqual ("From", VectorAnimation.FromProperty.Name);
			Assert.AreEqual ("From", VectorAnimation.FromProperty.ToString());
			Assert.AreEqual (typeof (Vector?), VectorAnimation.FromProperty.PropertyType);
			Assert.IsFalse (VectorAnimation.FromProperty.ReadOnly);

			Assert.AreEqual (typeof (VectorAnimation), VectorAnimation.ToProperty.OwnerType);
			Assert.AreEqual ("To", VectorAnimation.ToProperty.Name);
			Assert.AreEqual ("To", VectorAnimation.ToProperty.ToString());
			Assert.AreEqual (typeof (Vector?), VectorAnimation.ToProperty.PropertyType);
			Assert.IsFalse (VectorAnimation.ToProperty.ReadOnly);

			Assert.AreEqual (typeof (VectorAnimation), VectorAnimation.ByProperty.OwnerType);
			Assert.AreEqual ("By", VectorAnimation.ByProperty.Name);
			Assert.AreEqual ("By", VectorAnimation.ByProperty.ToString());
			Assert.AreEqual (typeof (Vector?), VectorAnimation.ByProperty.PropertyType);
			Assert.IsFalse (VectorAnimation.ByProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.Animation.VectorKeyFrame
namespace MonoTests.System.Windows.Media.Animation {
	public partial class VectorKeyFrameTest {
		[Test]
		public void DependencyProperties () {
			Assert.AreEqual (typeof (VectorKeyFrame), VectorKeyFrame.KeyTimeProperty.OwnerType);
			Assert.AreEqual ("KeyTime", VectorKeyFrame.KeyTimeProperty.Name);
			Assert.AreEqual ("KeyTime", VectorKeyFrame.KeyTimeProperty.ToString());
			Assert.AreEqual (typeof (KeyTime), VectorKeyFrame.KeyTimeProperty.PropertyType);
			Assert.IsFalse (VectorKeyFrame.KeyTimeProperty.ReadOnly);

			Assert.AreEqual (typeof (VectorKeyFrame), VectorKeyFrame.ValueProperty.OwnerType);
			Assert.AreEqual ("Value", VectorKeyFrame.ValueProperty.Name);
			Assert.AreEqual ("Value", VectorKeyFrame.ValueProperty.ToString());
			Assert.AreEqual (typeof (Vector), VectorKeyFrame.ValueProperty.PropertyType);
			Assert.IsFalse (VectorKeyFrame.ValueProperty.ReadOnly);

		}
	}
}
//   Type: System.Windows.Media.VideoDrawing
namespace MonoTests.System.Windows.Media {
	public partial class VideoDrawingTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (VideoDrawing), VideoDrawing.PlayerProperty.OwnerType);
			Assert.AreEqual ("Player", VideoDrawing.PlayerProperty.Name);
			Assert.AreEqual ("Player", VideoDrawing.PlayerProperty.ToString());
			Assert.AreEqual (typeof (MediaPlayer), VideoDrawing.PlayerProperty.PropertyType);
			Assert.IsFalse (VideoDrawing.PlayerProperty.ReadOnly);

			Assert.AreEqual (typeof (VideoDrawing), VideoDrawing.RectProperty.OwnerType);
			Assert.AreEqual ("Rect", VideoDrawing.RectProperty.Name);
			Assert.AreEqual ("Rect", VideoDrawing.RectProperty.ToString());
			Assert.AreEqual (typeof (Rect), VideoDrawing.RectProperty.PropertyType);
			Assert.IsFalse (VideoDrawing.RectProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Media3D.Viewport2DVisual3D
namespace MonoTests.System.Windows.Media.Media3D {
	public partial class Viewport2DVisual3DTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreSame (Viewport2DVisual3D.VisualProperty, VisualBrush.VisualProperty);
			Assert.AreEqual (typeof (Viewport2DVisual3D), Viewport2DVisual3D.GeometryProperty.OwnerType);
			Assert.AreEqual ("Geometry", Viewport2DVisual3D.GeometryProperty.Name);
			Assert.AreEqual ("Geometry", Viewport2DVisual3D.GeometryProperty.ToString());
			Assert.AreEqual (typeof (Geometry3D), Viewport2DVisual3D.GeometryProperty.PropertyType);
			Assert.IsFalse (Viewport2DVisual3D.GeometryProperty.ReadOnly);

			Assert.AreEqual (typeof (Viewport2DVisual3D), Viewport2DVisual3D.MaterialProperty.OwnerType);
			Assert.AreEqual ("Material", Viewport2DVisual3D.MaterialProperty.Name);
			Assert.AreEqual ("Material", Viewport2DVisual3D.MaterialProperty.ToString());
			Assert.AreEqual (typeof (Material), Viewport2DVisual3D.MaterialProperty.PropertyType);
			Assert.IsFalse (Viewport2DVisual3D.MaterialProperty.ReadOnly);

			Assert.AreEqual (typeof (Viewport2DVisual3D), Viewport2DVisual3D.IsVisualHostMaterialProperty.OwnerType);
			Assert.AreEqual ("IsVisualHostMaterial", Viewport2DVisual3D.IsVisualHostMaterialProperty.Name);
			Assert.AreEqual ("IsVisualHostMaterial", Viewport2DVisual3D.IsVisualHostMaterialProperty.ToString());
			Assert.AreEqual (typeof (bool), Viewport2DVisual3D.IsVisualHostMaterialProperty.PropertyType);
			Assert.IsFalse (Viewport2DVisual3D.IsVisualHostMaterialProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Media3D.Viewport3DVisual
namespace MonoTests.System.Windows.Media.Media3D {
	public partial class Viewport3DVisualTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (Viewport3DVisual), Viewport3DVisual.CameraProperty.OwnerType);
			Assert.AreEqual ("Camera", Viewport3DVisual.CameraProperty.Name);
			Assert.AreEqual ("Camera", Viewport3DVisual.CameraProperty.ToString());
			Assert.AreEqual (typeof (Camera), Viewport3DVisual.CameraProperty.PropertyType);
			Assert.IsFalse (Viewport3DVisual.CameraProperty.ReadOnly);

			Assert.AreEqual (typeof (Viewport3DVisual), Viewport3DVisual.ViewportProperty.OwnerType);
			Assert.AreEqual ("Viewport", Viewport3DVisual.ViewportProperty.Name);
			Assert.AreEqual ("Viewport", Viewport3DVisual.ViewportProperty.ToString());
			Assert.AreEqual (typeof (Rect), Viewport3DVisual.ViewportProperty.PropertyType);
			Assert.IsFalse (Viewport3DVisual.ViewportProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.Media3D.Visual3D
namespace MonoTests.System.Windows.Media.Media3D {
	public partial class Visual3DTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (Visual3D), Visual3D.TransformProperty.OwnerType);
			Assert.AreEqual ("Transform", Visual3D.TransformProperty.Name);
			Assert.AreEqual ("Transform", Visual3D.TransformProperty.ToString());
			Assert.AreEqual (typeof (Transform3D), Visual3D.TransformProperty.PropertyType);
			Assert.IsFalse (Visual3D.TransformProperty.ReadOnly);
#endif
		}
	}
}
//   Type: System.Windows.Media.VisualBrush
namespace MonoTests.System.Windows.Media {
	public partial class VisualBrushTest {
		[Test]
		public void DependencyProperties () {
			Assert.Fail ("Class not implemented yet");
#if notyet
			Assert.AreEqual (typeof (VisualBrush), VisualBrush.VisualProperty.OwnerType);
			Assert.AreEqual ("Visual", VisualBrush.VisualProperty.Name);
			Assert.AreEqual ("Visual", VisualBrush.VisualProperty.ToString());
			Assert.AreEqual (typeof (Visual), VisualBrush.VisualProperty.PropertyType);
			Assert.IsFalse (VisualBrush.VisualProperty.ReadOnly);

			Assert.AreEqual (typeof (VisualBrush), VisualBrush.AutoLayoutContentProperty.OwnerType);
			Assert.AreEqual ("AutoLayoutContent", VisualBrush.AutoLayoutContentProperty.Name);
			Assert.AreEqual ("AutoLayoutContent", VisualBrush.AutoLayoutContentProperty.ToString());
			Assert.AreEqual (typeof (bool), VisualBrush.AutoLayoutContentProperty.PropertyType);
			Assert.IsFalse (VisualBrush.AutoLayoutContentProperty.ReadOnly);
#endif
		}
	}
}
