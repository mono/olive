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
		internal extern static IntPtr dependency_object_set_value (IntPtr obj, IntPtr property, Value val);

		[DllImport("moon")]
	    	internal extern static IntPtr xaml_create_from_str (string xaml, out Kind kind);
	    
		
#region Items
		[DllImport("moon")]
		internal extern static IntPtr item_get_surface (IntPtr item);
		
		[DllImport("moon")]
		internal extern static void item_invalidate (IntPtr item);

		[DllImport("moon")]
		internal extern static void item_set_transform (IntPtr item, double [] transform);

		[DllImport("moon")]
		internal extern static void item_set_transform_origin (IntPtr item, Point p);
#endregion

#region Panel
		[DllImport("moon")]
		internal extern static IntPtr panel_get_children_collection (IntPtr panel);
#endregion
		
#region Canvas
		[DllImport("moon")]
		internal extern static IntPtr canvas_new ();
#endregion

#region Collections
		[DllImport("moon")]
		internal extern static IntPtr collection_add (IntPtr obj);
#endregion
		
#region Shapes
		[DllImport("moon")]
		internal extern static IntPtr rectangle_new ();
#endregion
	}
}
