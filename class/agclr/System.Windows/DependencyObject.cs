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
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Windows.Documents;

namespace System.Windows {
	public class DependencyObject {
		static ArrayList PendingDestroys = new ArrayList ();
		static volatile bool pending = false;
		static Hashtable objects = new Hashtable ();
		internal IntPtr _native;

		internal IntPtr native {
			get {
				return _native;
			}

			private set {
				_native = value;
				if (objects.Contains (value))
					return;
				objects [value] = this;
			}
		}

		public static readonly DependencyProperty NameProperty = 
			   DependencyProperty.Lookup (Kind.DEPENDENCY_OBJECT, "Name", typeof (string));

		public string Name {
			get { return (string) GetValue(NameProperty); }
		}
		static DependencyObject ()
		{
			NativeMethods.runtime_init ();
		}

		internal DependencyObject (IntPtr raw)
		{
			native = raw;
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
				Console.WriteLine (Environment.StackTrace);
			}

			return dop;
		}

		//
		// This version only looks up the object, if it has not been exposed,
		// we return null
		//
		internal static DependencyObject Lookup (IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
				return null;

			return (DependencyObject) objects [ptr];
		}
		
		static object CreateObject (Kind k, IntPtr raw)
		{
			if (k <= Kind.DEPENDENCY_OBJECT)
				throw new Exception ("the kind has to be a derived DependencyObject");

			//
			// FIXME: we should queue a timer
			//
			if (pending)
				ClearPendingDestroys ();
			
			NativeMethods.base_ref (raw);
			switch (k){
			case Kind.CANVAS:
				return new Canvas (raw);

			case Kind.IMAGE:
				return new Image (raw);

			case Kind.ROTATETRANSFORM:
				return new RotateTransform (raw);
				
			case Kind.SCALETRANSFORM:
				return new ScaleTransform (raw);

			case Kind.TRANSLATETRANSFORM:
				return new TranslateTransform (raw);
				
			case Kind.MATRIXTRANSFORM:
				return new MatrixTransform (raw);
				
			case Kind.STORYBOARD:
				return new Storyboard (raw);

			case Kind.DOUBLEANIMATIONUSINGKEYFRAMES:
				return new DoubleAnimationUsingKeyFrames (raw);
				
			case Kind.DOUBLEANIMATION: 
				return new DoubleAnimation (raw);
				
			case Kind.COLORANIMATION: 
				return new ColorAnimation (raw);
				
			case Kind.POINTANIMATION: 
				return new PointAnimation (raw);
				
			case Kind.ELLIPSE:
				return new Ellipse (raw);
				
			case Kind.LINE:
				return new Line (raw);
				
			case Kind.PATH:
				return new Path (raw);
				
			case Kind.POLYGON:
				return new Polygon (raw);
				
			case Kind.POLYLINE:
				return new Polyline (raw);
				
			case Kind.RECTANGLE:
				return new Rectangle (raw);
				
			case Kind.GEOMETRYGROUP:
				return new GeometryGroup (raw);
				
			case Kind.ELLIPSEGEOMETRY:
				return new EllipseGeometry (raw);
				
			case Kind.LINEGEOMETRY:
				return new LineGeometry (raw);
				
			case Kind.PATHGEOMETRY:
				return new PathGeometry (raw);
				
			case Kind.RECTANGLEGEOMETRY:
				return new RectangleGeometry (raw);
				
			case Kind.SOLIDCOLORBRUSH:
				return new SolidColorBrush (raw);
				
			case Kind.PATHFIGURE:
				return new PathFigure (raw);
				
			case Kind.ARCSEGMENT:
				return new ArcSegment (raw);
				
			case Kind.BEZIERSEGMENT:
				return new BezierSegment (raw);
				
			case Kind.LINESEGMENT:
				return new LineSegment (raw);
				
			case Kind.INLINES: 
				return new Inlines (raw);
				
			case Kind.POLYBEZIERSEGMENT:
				return new PolyBezierSegment (raw);
				
			case Kind.POLYLINESEGMENT:
				return new PolyLineSegment (raw);
				
			case Kind.POLYQUADRATICBEZIERSEGMENT:
				return new PolyQuadraticBezierSegment (raw);
				
			case Kind.QUADRATICBEZIERSEGMENT:
				return new QuadraticBezierSegment (raw);

			case Kind.TEXTBLOCK:
				return new TextBlock (raw);

			case Kind.RUN:
				return new Run (raw);

			case Kind.GLYPHS:
				return new Glyphs (raw);
				
			case Kind.STYLUSPOINT:
				return new StylusPoint (raw);
			
			case Kind.STYLUSINFO:
				return new StylusInfo (raw);

			case Kind.LINEBREAK:
				return new LineBreak (raw);
				
			case Kind.BEGINSTORYBOARD: 
				return new BeginStoryboard (raw);
				
			case Kind.EVENTTRIGGER: 
				return new EventTrigger (raw);

			case Kind.STROKE_COLLECTION: 
				return new StrokeCollection (raw);
				
			case Kind.STYLUSPOINT_COLLECTION: 
				return new StylusPointCollection (raw);
			
			case Kind.KEYFRAME_COLLECTION: 
				return new KeyFrameCollection (raw);
				
			case Kind.TIMELINEMARKER_COLLECTION: 
				return new TimelineMarkerCollection (raw);
				
			case Kind.GEOMETRY_COLLECTION: 
				return new GeometryCollection (raw);
					
			case Kind.GRADIENTSTOP_COLLECTION: 
				return new GradientStopCollection (raw);
				
			case Kind.MEDIAATTRIBUTE_COLLECTION: 
				return new MediaAttributeCollection (raw);
				
			case Kind.PATHFIGURE_COLLECTION: 
				return new PathFigureCollection (raw);
				
			case Kind.PATHSEGMENT_COLLECTION: 
				return new PathSegmentCollection (raw);
				
			case Kind.TIMELINE_COLLECTION: 
				return new TimelineCollection (raw);
				
			case Kind.TRANSFORM_COLLECTION: 
				return new TransformCollection (raw);
				
			case Kind.VISUAL_COLLECTION:
				return new VisualCollection (raw);
				
			case Kind.RESOURCE_COLLECTION:
				return new ResourceCollection (raw);

			case Kind.TRIGGERACTION_COLLECTION: 
				return new TriggerActionCollection (raw);
				
			case Kind.TRIGGER_COLLECTION: 
				return new TriggerCollection (raw);
				
			case Kind.CLOCKGROUP:
			case Kind.ANIMATIONCLOCK:
			case Kind.CLOCK: 
			case Kind.NAMESCOPE: 
			case Kind.TRIGGERACTION:
				throw new Exception (
					string.Format ("There is no managed equivalent of a {0} class.", k));
			case Kind.UIELEMENT:
			case Kind.PANEL:
			case Kind.TIMELINE: 
			case Kind.FRAMEWORKELEMENT:
			case Kind.BRUSH:
			case Kind.TRANSFORM:
			case Kind.SHAPE:
			case Kind.GEOMETRY:
			case Kind.VISUAL:
				throw new NotImplementedException (
					String.Format ("Should never get an abstract class from unmanaged code {0}", k));
			}

			return null;
		}

		~DependencyObject ()
		{
			lock (PendingDestroys){
				PendingDestroys.Add (this.native);
				pending = true;
			}
		}

		static void ClearPendingDestroys ()
		{
			lock (PendingDestroys){
				foreach (IntPtr v in PendingDestroys){
					NativeMethods.base_unref (v);
				}
				PendingDestroys.Clear ();
			}
			pending = false;
		}
		
		public virtual object GetValue (DependencyProperty property)
		{
			if (property == null)
				throw new ArgumentNullException ("property");
			
			CheckNative ();
			
			unsafe {
				Value* val = (Value*)NativeMethods.dependency_object_get_value (native, property.native);
				if (val == null) {
					if (property.IsValueType && !property.IsNullable)
						Console.WriteLine ("Found null for object {0}, with property {1}", GetType ().FullName, property.Name);
				
					return null;
				}

				switch (val->k) {
				case Kind.INVALID:
					return null;
					
				case Kind.BOOL:
					return val->u.i32 != 0;
					
				case Kind.DOUBLE:
					return val->u.d;
					
				case Kind.UINT64:
					return val->u.ui64;
					
				case Kind.INT64:
					return val->u.i64;
					
				case Kind.TIMESPAN:
					return new TimeSpan (val->u.i64);
						
				case Kind.INT32:
					return val->u.i32;

				case Kind.STRING:
					return Marshal.PtrToStringAuto (val->u.p);

				case Kind.POINT: {
					UnmanagedPoint *point = (UnmanagedPoint*)val->u.p;
					return new Point (point->x, point->y);
				}
					
				case Kind.RECT: {
					UnmanagedRect *rect = (UnmanagedRect*)val->u.p;
					return new Rect (rect->left, rect->top, rect->width, rect->height);
				}
				
				case Kind.DOUBLE_ARRAY: {
					UnmanagedArray *array = (UnmanagedArray*)val->u.p;
					double [] values = new double [array->count];
					Marshal.Copy ((IntPtr) (&array->first_d), values, 0, array->count);
					return values;
				}
					
				case Kind.POINT_ARRAY: {
					UnmanagedArray *array = (UnmanagedArray*)val->u.p;
					Point [] values = new Point [array->count];
					Point* first = (Point*) &array->first_pnt;
					for (int i = 0; i < array->count; i++) {
						values [i] = first [i];
					}
					return values;
				}
					
				case Kind.COLOR: {
					UnmanagedColor *color = (UnmanagedColor*)val->u.p;
					if (color == null)
						return new Color ();
					return Color.FromScRgb ((float)color->a, (float)color->r, (float)color->g, (float)color->b);
				}
					
				case Kind.MATRIX: {
					double *dp = (double*)val->u.p;
					
					return new Matrix (dp [0], dp [1], dp [2], dp [3], dp [4], dp [5]);					
				}
					
				case Kind.DURATION: {
					UnmanagedDuration* duration = (UnmanagedDuration*)val->u.p;
					if (duration == null)
						return Duration.Automatic;

					return new Duration (duration->kind, new TimeSpan (duration->timespan));
				}
					
				case Kind.KEYTIME: {
					UnmanagedKeyTime* keytime = (UnmanagedKeyTime*)val->u.p;
					if (keytime == null)
						return KeyTime.Uniform;
					return new KeyTime ((KeyTimeType) keytime->kind, keytime->percent, new TimeSpan (keytime->timespan));
				}
					
				case Kind.REPEATBEHAVIOR: {
					UnmanagedRepeatBehavior *repeat = (UnmanagedRepeatBehavior*)val->u.p;
					if (repeat == null)
						return new RepeatBehavior ();

					return new RepeatBehavior (repeat->kind, repeat->count, new TimeSpan (repeat->timespan));
				}

				}

				//
				// If it is a dependency object
				if (val->k > Kind.DEPENDENCY_OBJECT){
 					if (val->u.p == IntPtr.Zero)
 						return null;
					
 					return DependencyObject.Lookup (val->k, val->u.p);
				}

				throw new NotImplementedException (String.Format ("Do not know how to convert {0}", val->k));
			}
		}

		//
		// How do we support "null" values, should the caller take care of that?
		//
		internal static Value GetAsValue (object v)
		{
			Value value = new Value ();
			unsafe {
				if (v is DependencyObject){
					DependencyObject dov = (DependencyObject) v;

					if (dov.native == IntPtr.Zero)
						throw new Exception (String.Format (
							"Object {0} has not set its native property", dov.GetType()));

					//
					// Keep track of this object, so we know how to map it
					// if it comes back. 
					//
					objects [dov.native] = dov;
					value.k = dov.GetKind ();
					value.u.p = dov.native;
				} else if (v is int || (v.GetType ().IsEnum && v.GetType ().GetElementType () == typeof (int))){
					value.k = Kind.INT32;
					value.u.i32 = (int) v;
				} else if (v is bool){
					value.k = Kind.BOOL;
					value.u.i32 = ((bool) v) ? 1 : 0;
				} else if (v is double){
					value.k = Kind.DOUBLE;
					value.u.d = (double) v;
				} else if (v is long){
					value.k = Kind.INT64;
					value.u.i64 = (long) v;
				} else if (v is TimeSpan) {
					TimeSpan ts = (TimeSpan) v;
					value.k = Kind.TIMESPAN;
					value.u.i64 = ts.Ticks;
				} else if (v is ulong){
					value.k = Kind.UINT64;
					value.u.ui64 = (ulong) v;
				} else if (v is string){
					value.k = Kind.STRING;

					byte[] bytes = System.Text.Encoding.UTF8.GetBytes (v as string);
					IntPtr result = Marshal.AllocHGlobal (bytes.Length + 1);
					Marshal.Copy (bytes, 0, result, bytes.Length);
					Marshal.WriteByte (result, bytes.Length, 0);

					value.u.p = result;
				} else if (v is double []){
					double [] dv = (double []) v;

					value.k = Kind.DOUBLE_ARRAY;
					value.u.p = Marshal.AllocHGlobal (sizeof (UnmanagedArray) + sizeof (double) * dv.Length);
					UnmanagedArray* array = (UnmanagedArray*) value.u.p;
					array->count = dv.Length;
					array->refcount = 1;
					Marshal.Copy (dv, 0, (IntPtr) (&array->first_d), array->count);
				} else if (v is Point []){
					Point [] dv = (Point []) v;

					value.k = Kind.POINT_ARRAY;
					value.u.p = Marshal.AllocHGlobal (sizeof (UnmanagedArray) + sizeof (Point) * dv.Length);
					UnmanagedArray* array = (UnmanagedArray*) value.u.p;
					array->count = dv.Length;
					array->refcount = 1;
					Point * dp = (Point*) &array->first_pnt;
					for (int i = 0; i < dv.Length; i++)
						dp [i] = dv [i];
					
				} else if (v is Rect) {
					Rect rect = (Rect) v;
					value.k = Kind.RECT;
					value.u.p = Marshal.AllocHGlobal (sizeof (Rect));
					Marshal.StructureToPtr (rect, value.u.p, false); // Unmanaged and managed structure layout is equal.
				} else if (v is Point) {
					Point pnt = (Point) v;
					value.k = Kind.POINT;
					value.u.p = Marshal.AllocHGlobal (sizeof (Point));
					Marshal.StructureToPtr (pnt, value.u.p, false); // Unmanaged and managed structure layout is equal.
				} else if (v is Color){
					Color c = (Color) v;
					value.k = Kind.COLOR;
					value.u.p = Marshal.AllocHGlobal (sizeof (UnmanagedColor));
					UnmanagedColor* color = (UnmanagedColor*) value.u.p;
					color->r = c.ScR;
					color->g = c.ScG;
					color->b = c.ScB;
					color->a = c.ScA;
				} else if (v is Matrix) {
					Matrix mat = (Matrix) v;
					value.k = Kind.MATRIX;
					value.u.p = Marshal.AllocHGlobal (sizeof (double) * 6);
					Marshal.StructureToPtr (mat, value.u.p, false); // Unmanaged and managed structure layout is equal.
				} else if (v is Duration) {
					Duration d = (Duration) v;
					value.k = Kind.DURATION;
					value.u.p = Marshal.AllocHGlobal (sizeof (UnmanagedDuration));
					UnmanagedDuration* duration = (UnmanagedDuration*) value.u.p;
					duration->kind = d.KindInternal;
					duration->timespan = d.TimeSpanInternal.Ticks;
				} else if (v is KeyTime) {
					KeyTime k = (KeyTime) v;
					value.k = Kind.KEYTIME;
					value.u.p = Marshal.AllocHGlobal (sizeof (UnmanagedKeyTime));
					UnmanagedKeyTime* keytime = (UnmanagedKeyTime*) value.u.p;
					keytime->kind = (int) k.type;
					keytime->percent = k.percent;
					keytime->timespan = k.time_span.Ticks;
				} else if (v is RepeatBehavior) {
					RepeatBehavior d = (RepeatBehavior) v;
					value.k = Kind.REPEATBEHAVIOR;
					value.u.p = Marshal.AllocHGlobal (sizeof (UnmanagedRepeatBehavior));
					UnmanagedRepeatBehavior* rep = (UnmanagedRepeatBehavior*) value.u.p;
					rep->kind = d.kind;
					rep->count = d.count;
					rep->timespan = d.duration.Ticks;
				} else {
					throw new NotImplementedException (
						String.Format ("Do not know how to encode {0} yet", v.GetType ()));
				}
			}
			return value;
		}


		//
		// This signature seems incredibly painful, why make
		// it generic if we still have to dig into its
		// internals?  am I missing something fundamentally
		// awesome about it.  Perhaps for derived classes it
		// would be awesome?  as it stands its just annoying.
		//

		//
		// SetValue differs from SetValue in that the caller
		// code has ensured the proper type is being passed (which
		// is already the case for anything that is a setter as the
		// setters are strongly typed)
		//
		// External users go through SetValue that can do conversions.
		//
		public virtual void SetValue<T> (DependencyProperty property, T obj)
		{
			if (property == null)
				throw new ArgumentNullException ("property");

			CheckNative ();
			
			if (obj == null){
				NativeMethods.dependency_object_set_value (native, property.native, IntPtr.Zero);
				return;
			}

			Type t = obj.GetType ();
			Value v;
			if (t == property.type || property.type.IsAssignableFrom (t))
				v = GetAsValue (obj);
			else
				v = GetAsValue (Convert.ChangeType (obj, property.type));
			
			NativeMethods.dependency_object_set_value (native, property.native, ref v);
		}

		public DependencyObject FindName (string name)
		{
			Kind k;
			IntPtr o = NativeMethods.dependency_object_find_name (native, name, out k);
			if (o == IntPtr.Zero)
				return null;

			return Lookup (k, o);
		}

		internal virtual Kind GetKind ()
		{
			return Kind.DEPENDENCY_OBJECT;
		}
		
		private void CheckNative ()
		{
			if (native == IntPtr.Zero){
				throw new Exception (
					string.Format ("Uninitialized object: this object ({0}) has not set its native handle or overwritten SetValue", GetType ().FullName));
			}
		}
	}
}
