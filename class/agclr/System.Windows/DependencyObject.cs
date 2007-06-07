//
// DependencyObject.cs
//
// Author:
//   Iain McCoy (iain@mccoy.id.au)
//   Miguel de Icaza (miguel@novell.com)
//
// Copyright 2005 Iain McCoy
// Copyright 2007 Novell, Inc.
//
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
using System.Collections;
using Mono;
using System.Windows;
using System.Windows.Controls;
using System.Runtime.InteropServices;

namespace System.Windows {
	public class DependencyObject {
		static Hashtable objects = new Hashtable ();
		internal IntPtr native;
		
		//
		// This is mostly copied from Gtk#'s Object.GetObject
		// we need to take into account in the future:
		//    WeakReferences
		//    ToggleReferences (talk to Mike)
		//
		// 
		internal static DependencyObject Lookup (Value.Kind k, IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
				return null;

			object reference = objects [ptr];
			if (reference != null)
				return (DependencyObject) reference;

			return (DependencyObject) CreateObject (k, ptr);
		}

		static object CreateObject (Value.Kind k, IntPtr raw)
		{
			if (k <= Value.Kind.DEPENDENCY_OBJECT)
				throw new Exception ("the kind has to be a derived DependencyObject");
			
			switch (k){
			case Value.Kind.UIELEMENT:
				return null;

			case Value.Kind.PANEL:
				return null;

			case Value.Kind.CANVAS:
				return new Canvas (raw);

			case Value.Kind.TIMELINE: return null;
			case Value.Kind.TRANSFORM: return null;
			case Value.Kind.ROTATETRANSFORM: return null;
			case Value.Kind.SCALETRANSFORM: return null;
			case Value.Kind.TRANSLATETRANSFORM: return null;
			case Value.Kind.MATRIXTRANSFORM: return null;
			case Value.Kind.STORYBOARD: return null;
			case Value.Kind.DOUBLEANIMATION: return null;
			case Value.Kind.COLORANIMATION: return null;
			case Value.Kind.POINTANIMATION: return null;
			case Value.Kind.SHAPE: return null;
			case Value.Kind.ELLIPSE: return null;
			case Value.Kind.LINE: return null;
			case Value.Kind.PATH: return null;
			case Value.Kind.POLYGON: return null;
			case Value.Kind.POLYLINE: return null;
			case Value.Kind.RECTANGLE: return null;
			case Value.Kind.GEOMETRY: return null;
			case Value.Kind.GEOMETRYGROUP: return null;
			case Value.Kind.ELLIPSEGEOMETRY: return null;
			case Value.Kind.LINEGEOMETRY: return null;
			case Value.Kind.PATHGEOMETRY: return null;
			case Value.Kind.RECTANGLEGEOMETRY: return null;
			case Value.Kind.FRAMEWORKELEMENT: return null;
			case Value.Kind.NAMESCOPE: return null;
			case Value.Kind.CLOCK: return null;
			case Value.Kind.ANIMATIONCLOCK: return null;
			case Value.Kind.CLOCKGROUP: return null;
			case Value.Kind.BRUSH: return null;
			case Value.Kind.SOLIDCOLORBRUSH: return null;
			case Value.Kind.PATHFIGURE: return null;
			case Value.Kind.ARCSEGMENT: return null;
			case Value.Kind.BEZIERSEGMENT: return null;
			case Value.Kind.LINESEGMENT: return null;
			case Value.Kind.POLYBEZIERSEGMENT: return null;
			case Value.Kind.POLYLINESEGMENT: return null;
			case Value.Kind.POLYQUADRATICBEZIERSEGMENT: return null;
			case Value.Kind.QUADRATICBEZIERSEGMENT: return null;
			case Value.Kind.TRIGGERACTION: return null;
			case Value.Kind.BEGINSTORYBOARD: return null;
			case Value.Kind.EVENTTRIGGER: return null;
			}

			return null;
		}

		public virtual object GetValue (DependencyProperty property)
		{
			IntPtr x = NativeMethods.dependency_object_get_value (native, property.native);

			if (x == IntPtr.Zero)
				return null;

			unsafe {
				byte *px = (byte *) x;
				Value.Kind k = (Value.Kind) (*((int *)px));

				px += 4;
				
				switch (k) {
				case Value.Kind.INVALID:
					return null;
					
				case Value.Kind.BOOL:
					throw new NotImplementedException ();
					
				case Value.Kind.DOUBLE:
					return *((double *) px);
					
				case Value.Kind.INT64:
					return *((long *) px);
					
				case Value.Kind.INT32:
					return *((int *) px);

				case Value.Kind.STRING:
					return Marshal.PtrToStringAuto ((IntPtr) px);
				}
				
				//
				// If it is a dependency object
				if (k > Value.Kind.DEPENDENCY_OBJECT){
					IntPtr vptr = *((IntPtr *) px);
					if (vptr == IntPtr.Zero)
						return null;
					
					return DependencyObject.Lookup (k, vptr);
				}
			}
			
			throw new NotImplementedException ();
		}

		public virtual void SetValue<T> (DependencyProperty property, T obj)
		{
		}
	}
}
