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

		static DependencyObject ()
		{
			NativeMethods.runtime_init ();
		}
		
		//
		// This is mostly copied from Gtk#'s Object.GetObject
		// we need to take into account in the future:
		//    WeakReferences
		//    ToggleReferences (talk to Mike)
		//
		// 
		internal static DependencyObject Lookup (Kind k, IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
				return null;

			object reference = objects [ptr];
			if (reference != null)
				return (DependencyObject) reference;

			DependencyObject dop = (DependencyObject) CreateObject (k, ptr);
			if (dop == null){
				Console.WriteLine ("agclr: Returning a null object, did not know how to construct {0}", k);
			}

			return dop;
		}

		static object CreateObject (Kind k, IntPtr raw)
		{
			if (k <= Kind.DEPENDENCY_OBJECT)
				throw new Exception ("the kind has to be a derived DependencyObject");
			
			switch (k){
			case Kind.UIELEMENT:
				return null;

			case Kind.PANEL:
				return null;

			case Kind.CANVAS:
				return new Canvas (raw);

			case Kind.TIMELINE: return null;
			case Kind.TRANSFORM: return null;
			case Kind.ROTATETRANSFORM: return null;
			case Kind.SCALETRANSFORM: return null;
			case Kind.TRANSLATETRANSFORM: return null;
			case Kind.MATRIXTRANSFORM: return null;
			case Kind.STORYBOARD: return null;
			case Kind.DOUBLEANIMATION: return null;
			case Kind.COLORANIMATION: return null;
			case Kind.POINTANIMATION: return null;
			case Kind.SHAPE: return null;
			case Kind.ELLIPSE: return null;
			case Kind.LINE: return null;
			case Kind.PATH: return null;
			case Kind.POLYGON: return null;
			case Kind.POLYLINE: return null;
			case Kind.RECTANGLE: return null;
			case Kind.GEOMETRY: return null;
			case Kind.GEOMETRYGROUP: return null;
			case Kind.ELLIPSEGEOMETRY: return null;
			case Kind.LINEGEOMETRY: return null;
			case Kind.PATHGEOMETRY: return null;
			case Kind.RECTANGLEGEOMETRY: return null;
			case Kind.FRAMEWORKELEMENT: return null;
			case Kind.NAMESCOPE: return null;
			case Kind.CLOCK: return null;
			case Kind.ANIMATIONCLOCK: return null;
			case Kind.CLOCKGROUP: return null;
			case Kind.BRUSH: return null;
			case Kind.SOLIDCOLORBRUSH: return null;
			case Kind.PATHFIGURE: return null;
			case Kind.ARCSEGMENT: return null;
			case Kind.BEZIERSEGMENT: return null;
			case Kind.LINESEGMENT: return null;
			case Kind.POLYBEZIERSEGMENT: return null;
			case Kind.POLYLINESEGMENT: return null;
			case Kind.POLYQUADRATICBEZIERSEGMENT: return null;
			case Kind.QUADRATICBEZIERSEGMENT: return null;
			case Kind.TRIGGERACTION: return null;
			case Kind.BEGINSTORYBOARD: return null;
			case Kind.EVENTTRIGGER: return null;
			case Kind.STROKE_COLLECTION: return null;
			case Kind.INLINES: return null;
			case Kind.STYLUSPOINT_COLLECTION: return null;
			case Kind.KEYFRAME_COLLECTION: return null;
			case Kind.TIMELINEMARKER_COLLECTION: return null;
			case Kind.GEOMETRY_COLLECTION: return null;
			case Kind.GRADIENTSTOP_COLLECTION: return null;
			case Kind.MEDIAATTRIBUTE_COLLECTION: return null;
			case Kind.PATHFIGURE_COLLECTION: return null;
			case Kind.PATHSEGMENT_COLLECTION: return null;
			case Kind.TIMELINE_COLLECTION: return null;
			case Kind.TRANSFORM_COLLECTION: return null;
			case Kind.VISUAL_COLLECTION: return null;
			case Kind.RESOURCE_COLLECTION: return null;
			case Kind.TRIGGERACTION_COLLECTION: return null;
			case Kind.TRIGGER_COLLECTION: return null;
			}

			return null;
		}

		public virtual object GetValue (DependencyProperty property)
		{
			if (property == null)
				throw new ArgumentNullException ("property");
			
			IntPtr x = NativeMethods.dependency_object_get_value (native, property.native);

			if (x == IntPtr.Zero)
				return null;

			Kind k;
			unsafe {
				byte *px = (byte *) x;
				k = (Kind) (*((int *)px));

				px += 4;
				
				switch (k) {
				case Kind.INVALID:
					return null;
					
				case Kind.BOOL:
					if ((*((int *) px)) == 0)
						return false;
					return true;
					
				case Kind.DOUBLE:
					return *((double *) px);
					
				case Kind.INT64:
					return *((long *) px);
					
				case Kind.INT32:
					return *((int *) px);

				case Kind.STRING:
					return Marshal.PtrToStringAuto ((IntPtr) px);
				}
				
				//
				// If it is a dependency object
				if (k > Kind.DEPENDENCY_OBJECT){
					IntPtr vptr = *((IntPtr *) px);
					if (vptr == IntPtr.Zero)
						return null;
					
					return DependencyObject.Lookup (k, vptr);
				}
			}

			throw new NotImplementedException (String.Format ("Do not know how to convert {0}", k));
		}

		//
		// Ok, only the unmanaged known types would end up calling the
		// unmanaged side, so we do not have to worry about other types
		//
		public void SetValueBoxed (DependencyProperty property, object v)
		{
			unsafe {
				Value value;
				void *vp = &value;
				byte *p = (byte *) vp;
				p += 4;

				if (v is DependencyObject){
					DependencyObject dov = (DependencyObject) v;

					if (dov.native == IntPtr.Zero)
						throw new Exception (String.Format (
							"Object {0} has not set its native property", dov.GetType()));
					

					//
					// Keep track of this object, so we know how to map it
					// on the way out.
					//
					objects [dov.native] = dov;
					*((IntPtr *) p) = dov.native;
				} if (v is int){
					value.k = Kind.INT32;
					*((int *) p) = (int) v;
				} else if (v is bool){
					value.k = Kind.BOOL;
					*((int *) p) = ((bool)v) ? 1 : 0;
				} else if (v is double){
					value.k = Kind.DOUBLE;
					*((double *) p) = (double) v;
				} else if (v is long){
					value.k = Kind.INT64;
					*((long *) p) = (long) v;
				} else if (v is ulong){
					value.k = Kind.UINT64;
					*((ulong *) p) = (ulong) v;
				} else if (v is string){
					value.k = Kind.STRING;

					byte[] bytes = System.Text.Encoding.UTF8.GetBytes (v as string);
					IntPtr result = Marshal.AllocHGlobal (bytes.Length + 1);
					Marshal.Copy (bytes, 0, result, bytes.Length);
					Marshal.WriteByte (result, bytes.Length, 0);

					*((IntPtr *) p) = result;
				}
			}
		}

		//
		// This signature seems incredibly painful, why make
		// it generic if we still have to dig into its
		// internals?  am I missing something fundamentally
		// awesome about it.  Perhaps for derived classes it
		// would be awesome?  as it stands its just annoying.
		//
		public virtual void SetValue<T> (DependencyProperty property, T obj)
		{
			// Call another routine to avoid getting a billion copies
			// of the same code, one per data type.
			SetValueBoxed (property, obj);
		}
	}
}
