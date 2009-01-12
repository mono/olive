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

using System;
using System.Windows;
using System.Windows.Media.Effects;
using System.Windows.Threading;

namespace System.Windows.Media {

	public abstract class Visual : DependencyObject {
		protected Visual ()
		{
		}

		protected void AddVisualChild (Visual child)
		{
			throw new NotImplementedException ();
		}

		public DependencyObject FindCommonVisualAncestor (DependencyObject otherVisual)
		{
			throw new NotImplementedException ();
		}

		protected virtual Visual GetVisualChild (int index)
		{
			throw new NotImplementedException ();
		}

		protected virtual GeometryHitTestResult HitTestCore (GeometryHitTestParameters hitTestParameters)
		{
			throw new NotImplementedException ();
		}

		protected virtual HitTestResult HitTestCore (PointHitTestParameters hitTestParameters)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO("enable Visual3D case")]
		[MonoTODO("descendant == null case")]
		public bool IsAncestorOf (DependencyObject descendant)
		{
			if (!(descendant is Visual /*|| descendant is Visual3D*/))
				throw new ArgumentException (string.Format ("'{0}' is not a Visual or Visual3D", descendant.GetType()));

			throw new NotImplementedException ();
		}

		[MonoTODO("enable Visual3D case")]
		[MonoTODO("ancestor == null case")]
		public bool IsDescendantOf (DependencyObject ancestor)
		{
			if (!(ancestor is Visual /*|| ancestor is Visual3D*/))
				throw new ArgumentException (string.Format ("'{0}' is not a Visual or Visual3D", ancestor.GetType()));

			throw new NotImplementedException ();
		}

		protected internal virtual void OnVisualChildrenChanged (DependencyObject visualAdded,
									 DependencyObject visualRemoved)
		{
			throw new NotImplementedException ();
		}

		protected internal virtual void OnVisualParentChanged (DependencyObject oldParent)
		{
			throw new NotImplementedException ();
		}

		public Point PointFromScreen (Point point)
		{
			throw new NotImplementedException ();
		}

		public Point PointToScreen (Point point)
		{
			throw new NotImplementedException ();
		}

		protected void RemoveVisualChild (Visual child)
		{
			throw new NotImplementedException ();
		}

		public GeneralTransform TransformToAncestor (Visual ancestor)
		{
			throw new NotImplementedException ();
		}

		public GeneralTransform TransformToDescendant (Visual descendant)
		{
			throw new NotImplementedException ();
		}

		public GeneralTransform TransformToVisual (Visual visual)
		{
			throw new NotImplementedException ();
		}

		[Obsolete ("BitmapEffects are inefficient and will be deprecated in a future release. Use UIElement.Effect and ShaderEffects instead.")]
		protected internal BitmapEffect VisualBitmapEffect {
			get {
				throw new NotImplementedException ();
			}
			protected set {
				throw new NotImplementedException ();
			}
		}

#if waiting
		protected internal BitmapEffectInput VisualBitmapEffectInput {
			get {
				throw new NotImplementedException ();
			}
			protected set {
				throw new NotImplementedException ();
			}
		}
#endif
		protected internal BitmapScalingMode VisualBitmapScalingMode {
			get {
				throw new NotImplementedException ();
			}
			protected set {
				throw new NotImplementedException ();
			}
		}

		protected virtual int VisualChildrenCount {
			get {
				throw new NotImplementedException ();
			}
		}

		protected internal Geometry VisualClip {
			get {
				throw new NotImplementedException ();
			}
			protected set {
				throw new NotImplementedException ();
			}
		}

		protected internal EdgeMode VisualEdgeMode {
			get {
				throw new NotImplementedException ();
			}
			protected set {
				throw new NotImplementedException ();
			}
		}

		protected internal Vector VisualOffset {
			get {
				throw new NotImplementedException ();
			}
			protected set {
				throw new NotImplementedException ();
			}
		}

		protected internal double VisualOpacity {
			get {
				throw new NotImplementedException ();
			}
			protected set {
				throw new NotImplementedException ();
			}
		}

		protected internal Brush VisualOpacityMask {
			get {
				throw new NotImplementedException ();
			}
			protected set {
				throw new NotImplementedException ();
			}
		}

		protected DependencyObject VisualParent {
			get {
				throw new NotImplementedException ();
			}
		}

		protected internal Transform VisualTransform {
			get {
				throw new NotImplementedException ();
			}
			protected set {
				throw new NotImplementedException ();
			}
		}

		protected internal DoubleCollection VisualXSnappingGuidelines {
			get {
				throw new NotImplementedException ();
			}
			protected set {
				throw new NotImplementedException ();
			}
		}

		protected internal DoubleCollection VisualYSnappingGuidelines {
			get {
				throw new NotImplementedException ();
			}
			protected set {
				throw new NotImplementedException ();
			}
		}
	}
}
