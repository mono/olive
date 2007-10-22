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
using System.Windows.Threading;

namespace System.Windows.Media {

	public abstract class Visual : DependencyObject {
		protected Visual ()
		{
			throw new NotImplementedException ();
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

#if waiting
		protected virtual GeometryHitTestResult HitTestCore (GeometryHitTestParameters hitTestParameters)
		{
			throw new NotImplementedException ();
		}

		protected virtual HitTestResult HitTestCore (PointHitTestParameters hitTestParameters)
		{
			throw new NotImplementedException ();
		}
#endif

		public bool IsAncestorOf (DependencyObject descendant)
		{
			throw new NotImplementedException ();
		}

		public bool IsDescendantOf (DependencyObject ancestor)
		{
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

#if waiting
		protected internal BitmapEffect VisualBitmapEffect {
			get {
				throw new NotImplementedException ();
			}
			protected set {
				throw new NotImplementedException ();
			}
		}

		protected internal BitmapEffectInput VisualBitmapEffectInput {
			get {
				throw new NotImplementedException ();
			}
			protected set {
				throw new NotImplementedException ();
			}
		}

		protected internal BitmapScalingMode VisualBitmapScalingMode {
			get {
				throw new NotImplementedException ();
			}
			protected set {
				throw new NotImplementedException ();
			}
		}
#endif

		protected virtual int VisualChildrenCount {
			get {
				throw new NotImplementedException ();
			}
		}

#if waiting
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
#endif

		protected internal double VisualOpacity {
			get {
				throw new NotImplementedException ();
			}
			protected set {
				throw new NotImplementedException ();
			}
		}

#if waiting
		protected internal Brush VisualOpacityMask {
			get {
				throw new NotImplementedException ();
			}
			protected set {
				throw new NotImplementedException ();
			}
		}
#endif

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

#if waiting
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
#endif
	}
}
