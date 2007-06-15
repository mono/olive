//
// NativeMethods.cs
//
// Author:
//   Miguel de Icaza (miguel@novell.com)
//
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
using System;
using System.Windows;
using System.Runtime.InteropServices;

namespace Mono {

	internal static class NativeMethods {

		[DllImport("moon")]
		internal extern static void runtime_init ();

		[DllImport("moon")]
		internal extern static void surface_register_events (
			IntPtr surface,
			CallbackMouseEvent motion,
			CallbackMouseEvent down,
			CallbackMouseEvent up,
			CallbackMouseEvent enter,
			PlainEvent got_focus,
			PlainEvent lost_focus,
			PlainEvent loaded,
			PlainEvent mouse_leave,
			KeyboardEvent keydown,
			KeyboardEvent keyup);
	
#region Base
		[DllImport("moon")]
		internal extern static void base_ref (IntPtr ptr);

		[DllImport("moon")]
		internal extern static void base_unref (IntPtr ptr);
#endregion

		[DllImport("moon")]
		internal extern static IntPtr dependency_property_lookup (Kind type, string name);

		[DllImport("moon")]
		internal extern static IntPtr dependency_object_get_value (IntPtr obj, IntPtr property);
		
		[DllImport("moon")]
		internal extern static IntPtr dependency_object_set_value (IntPtr obj, IntPtr property, ref Value val);

		[DllImport("moon")]
		internal extern static IntPtr dependency_object_set_value (IntPtr obj, IntPtr property, IntPtr zero);

		[DllImport("moon")]
		internal extern static IntPtr dependency_object_find_name (IntPtr obj, string name, out Kind kind);
		
		[DllImport("moon")]
	    	internal extern static IntPtr xaml_create_from_str (string xaml, out Kind kind);

		[DllImport("moon")]
		internal extern static Value value_color_from_argb (uint c);

#region Items
		[DllImport("moon")]
		internal extern static IntPtr item_get_surface (IntPtr item);
		
		[DllImport("moon")]
		internal extern static void item_invalidate (IntPtr item);

		[DllImport("moon")]
		internal extern static void item_set_transform (IntPtr item, double [] transform);

		[DllImport("moon")]
		internal extern static void item_set_transform_origin (IntPtr item, Point p);

		[DllImport("moon")]
		internal extern static void uielement_transform_point (IntPtr item, ref double x, ref double y);
#endregion

#region Panel
		[DllImport("moon")]
		internal extern static IntPtr panel_get_children_collection (IntPtr panel);
		
		[DllImport("moon")]
		internal extern static IntPtr panel_new ();
#endregion
		
#region Collections
		[DllImport("moon")]
		internal extern static IntPtr collection_add (IntPtr collection, IntPtr value);
		
		[DllImport("moon")]
		internal extern static IntPtr resource_collection_new ();
		
		[DllImport("moon")]
		internal extern static IntPtr trigger_collection_new ();
		
		[DllImport("moon")]
		internal extern static IntPtr gradient_stop_collection_new ();
		
		[DllImport("moon")]
		internal extern static IntPtr media_attribute_collection_new ();
		
		[DllImport("moon")]
		internal extern static IntPtr path_figure_collection_new ();
		
		[DllImport("moon")]
		internal extern static IntPtr path_segment_collection_new ();
		
		[DllImport("moon")]
		internal extern static IntPtr collection_new ();
		
		[DllImport("moon")]
		internal extern static IntPtr visual_collection_new ();
		
		[DllImport("moon")]
		internal extern static IntPtr geometry_collection_new ();
		
		[DllImport("moon")]
		internal extern static IntPtr transform_collection_new ();
		
		[DllImport("moon")]
		internal extern static IntPtr timeline_collection_new ();
#endregion
		
#region Constructors
		[DllImport("moon")]
		internal extern static IntPtr rectangle_new ();
		
		[DllImport("moon")]
		internal extern static IntPtr framework_element_new ();
		
		[DllImport("moon")]
		internal extern static IntPtr visual_new ();
		
		[DllImport("moon")]
		internal extern static IntPtr path_segment_new ();
		
		[DllImport("moon")]
		internal extern static IntPtr geometry_new ();
		
		[DllImport("moon")]
		internal extern static IntPtr timeline_new ();
		
		[DllImport("moon")]
		internal extern static IntPtr timeline_group_new ();
		
		[DllImport("moon")]
		internal extern static IntPtr parallel_timeline_new ();
		
		[DllImport("moon")]
		internal extern static IntPtr shape_new ();
		
		[DllImport("moon")]
		internal extern static IntPtr uielement_new ();

		[DllImport("moon")]
		internal extern static IntPtr solid_color_brush_new ();
		
		[DllImport("moon")]
		internal extern static IntPtr radial_gradient_brush_new ();

		[DllImport("moon")]
		internal extern static IntPtr brush_new ();
		
		[DllImport("moon")]
		internal extern static IntPtr gradient_brush_new ();
		
		[DllImport("moon")]
		internal extern static IntPtr gradient_stop_new ();
		
		[DllImport("moon")]
		internal extern static IntPtr image_brush_new ();
		
		[DllImport("moon")]
		internal extern static IntPtr linear_gradient_brush_new ();
		
		[DllImport("moon")]
		internal extern static IntPtr media_attribute_new ();
		
		[DllImport("moon")]
		internal extern static IntPtr skew_transform_new ();
		
		[DllImport("moon")]
		internal extern static IntPtr tile_brush_new ();
		
		[DllImport("moon")]
		internal extern static IntPtr transform_new ();
		
		[DllImport("moon")]
		internal extern static IntPtr video_brush_new ();
		
		[DllImport("moon")]
		internal extern static IntPtr canvas_new ();

		[DllImport("moon")]
		internal extern static IntPtr geometry_group_new ();

		[DllImport("moon")]
		internal extern static IntPtr ellipse_geometry_new ();

		[DllImport("moon")]
		internal extern static IntPtr line_geometry_new ();

		[DllImport("moon")]
		internal extern static IntPtr path_geometry_new ();

		[DllImport("moon")]
		internal extern static IntPtr rectangle_geometry_new ();

		[DllImport("moon")]
		internal extern static IntPtr path_figure_new ();

		[DllImport("moon")]
		internal extern static IntPtr arc_segment_new ();

		[DllImport("moon")]
		internal extern static IntPtr bezier_segment_new ();

		[DllImport("moon")]
		internal extern static IntPtr line_segment_new ();

		[DllImport("moon")]
		internal extern static IntPtr poly_bezier_segment_new ();

		[DllImport("moon")]
		internal extern static IntPtr poly_line_segment_new ();

		[DllImport("moon")]
		internal extern static IntPtr poly_quadratic_bezier_segment_new ();

		[DllImport("moon")]
		internal extern static IntPtr quadratic_bezier_segment_new ();

		[DllImport("moon")]
		internal extern static IntPtr ellipse_new ();

		[DllImport("moon")]
		internal extern static IntPtr line_new ();

		[DllImport("moon")]
		internal extern static IntPtr polygon_new ();

		[DllImport("moon")]
		internal extern static IntPtr polyline_new ();

		[DllImport("moon")]
		internal extern static IntPtr path_new ();

		[DllImport("moon")]
		internal extern static IntPtr rotate_transform_new ();

		[DllImport("moon")]
		internal extern static IntPtr translate_transform_new ();

		[DllImport("moon")]
		internal extern static IntPtr scale_transform_new ();

		[DllImport("moon")]
		internal extern static IntPtr matrix_transform_new ();

		[DllImport("moon")]
		internal extern static IntPtr transform_group_new ();
		
		[DllImport("moon")]
		internal extern static IntPtr downloader_new ();

		[DllImport("moon")]
		internal extern static IntPtr storyboard_new ();

		[DllImport("moon")]
		internal extern static IntPtr beginstoryboard_new ();

		[DllImport("moon")]
		internal extern static IntPtr animation_new ();

		[DllImport("moon")]
		internal extern static IntPtr coloranimation_new ();

		[DllImport("moon")]
		internal extern static IntPtr trigger_action_collection_new ();


#endregion

#region Storyboard
		[DllImport("moon")]
		internal extern static IntPtr storyboard_begin (IntPtr native);
		
		[DllImport("moon")]
		internal extern static IntPtr storyboard_pause (IntPtr native);
		
		[DllImport("moon")]
		internal extern static IntPtr storyboard_resume (IntPtr native);
		
		[DllImport("moon")]
		internal extern static IntPtr storyboard_seek (IntPtr native, long timespan);
		
		[DllImport("moon")]
		internal extern static IntPtr storyboard_stop (IntPtr native);
		
		[DllImport("moon")]
		internal extern static IntPtr double_animation_new ();

		[DllImport("moon")]
		internal extern static IntPtr color_animation_new ();

		[DllImport("moon")]
		internal extern static IntPtr event_trigger_new ();

		[DllImport("moon")]
		internal extern static IntPtr point_animation_new ();

		[DllImport("moon")]
		internal extern static IntPtr begin_storyboard_new ();
#endregion
		
#region APIs that we do not have a Managed class implemented yet.

		[DllImport("moon")]
		internal extern static IntPtr point_animation_using_key_frames_new ();

#endregion

#region Downloader
		[DllImport("moon")]
		internal extern static void downloader_abort (IntPtr handle);
		
		[DllImport("moon")]
		internal extern static string downloader_get_response_text (IntPtr handle, string partname);

		[DllImport("moon")]
		internal extern static void downloader_open (IntPtr handle, string verb, string uri, bool async);

		[DllImport("moon")]
		internal extern static void downloader_send (IntPtr handle);

		internal delegate void UpdateFunction (int kind);
		[DllImport("moon")]
		internal extern static void downloader_want_events (IntPtr handle, UpdateFunction func);
#endregion
		
		[DllImport ("moon")]
		internal extern static IntPtr surface_attach (IntPtr surface, IntPtr toplevel);

	}
}
