using System;
using System.Text;
using System.Windows.Browser;
using System.Windows.Browser.Serialization;
using System.Runtime.InteropServices;
using System.Reflection;
using Mono;

namespace System.Windows
{
	internal class ScriptableObjectGenerator
	{
		public static void Generate (IntPtr plugin_handle, string nameOnJS, object obj)
		{
			new ScriptableObjectGenerator (plugin_handle, nameOnJS, obj).Generate ();
		}

		string name;
		object obj;
		Type type;
		IntPtr plugin_handle;
		IntPtr scriptable_wrapper;

		ScriptableObjectGenerator (IntPtr plugin_handle, string name, object obj)
		{
			this.plugin_handle = plugin_handle;
			this.name = name;
			this.obj = obj;
			type = obj.GetType ();
		}

		delegate void InvokeDelegate (IntPtr obj_handle, IntPtr method_handle,
					      [In, MarshalAs(UnmanagedType.LPArray,
							     ArraySubType=UnmanagedType.Struct, SizeParamIndex=3)] Value[] args,
					      int arg_count,
					      ref Value return_value);

		delegate void SetPropertyDelegate (IntPtr obj_handle, IntPtr property_handle, Value value);
		delegate void GetPropertyDelegate (IntPtr obj_handle, IntPtr property_handle, ref Value value);

		static object ObjectFromValue (Value v)
		{
			switch (v.k) {
			case Kind.BOOL:
				return v.u.i32 != 0;
			case Kind.UINT64:
				return v.u.ui64;
			case Kind.INT32:
				return v.u.i32;
			case Kind.INT64:
				return v.u.i64;
			case Kind.DOUBLE:
				return v.u.d;
			case Kind.STRING:
				return Marshal.PtrToStringAuto (v.u.p);
			default:
				throw new NotSupportedException ();
			}
		}

		static void ValueFromObject (ref Value v, object o)
		{
			switch (Type.GetTypeCode (o.GetType())) {
			case TypeCode.Boolean:
				v.k = Kind.BOOL;
				v.u.i32 = ((bool) o) ? 1 : 0;
				break;
			case TypeCode.Double:
				v.k = Kind.DOUBLE;
				v.u.d = (double)o;
				break;
			case TypeCode.Int64:
				v.k = Kind.INT64;
				v.u.d = (long)o;
				break;
			case TypeCode.UInt64:
				v.k = Kind.UINT64;
				v.u.d = (ulong)o;
				break;
			case TypeCode.String:
				v.k = Kind.STRING;
				byte[] bytes = System.Text.Encoding.UTF8.GetBytes (o as string);
				IntPtr result = Marshal.AllocHGlobal (bytes.Length + 1);
				Marshal.Copy (bytes, 0, result, bytes.Length);
				Marshal.WriteByte (result, bytes.Length, 0);
				v.u.p = result;
				break;
			default:
				throw new NotSupportedException ();
			}
		}

		static void InvokeFromUnmanaged (IntPtr obj_handle, IntPtr method_handle, Value[] args, int arg_count, ref Value return_value)
		{
			object obj = GCHandle.FromIntPtr (obj_handle).Target;
			MethodInfo mi = (MethodInfo)GCHandle.FromIntPtr (method_handle).Target;

			object[] margs = new object[args.Length];
			for (int i = 0; i < args.Length; i ++) {
				margs[i] = ObjectFromValue (args[i]);
			}

			object rv = mi.Invoke (obj, margs);

			if (mi.ReturnType != typeof (void))
				ValueFromObject (ref return_value, rv);
		}

		static void SetPropertyFromUnmanaged (IntPtr obj_handle, IntPtr property_handle, Value value)
		{
			object obj = GCHandle.FromIntPtr (obj_handle).Target;
			PropertyInfo pi = (PropertyInfo)GCHandle.FromIntPtr (property_handle).Target;

			object v = ObjectFromValue (value);

			pi.SetValue (obj, v, null);

		}

		static void GetPropertyFromUnmanaged (IntPtr obj_handle, IntPtr property_handle, ref Value value)
		{
			object obj = GCHandle.FromIntPtr (obj_handle).Target;
			PropertyInfo pi = (PropertyInfo)GCHandle.FromIntPtr (property_handle).Target;

			object v = pi.GetValue (obj, null);

			ValueFromObject (ref value, v);
		}

		static InvokeDelegate invoke = new InvokeDelegate (InvokeFromUnmanaged);
		static SetPropertyDelegate set_prop = new SetPropertyDelegate (SetPropertyFromUnmanaged);
		static GetPropertyDelegate get_prop = new GetPropertyDelegate (GetPropertyFromUnmanaged);

		void Generate ()
		{
			bool hasItem = false;

			GCHandle obj_handle = GCHandle.Alloc (obj); // XXX leak

			scriptable_wrapper = moonlight_scriptable_object_wrapper_create (plugin_handle, (IntPtr)obj_handle,
											 invoke, set_prop, get_prop);

			// add properties

			foreach (PropertyInfo pi in type.GetProperties ()) {
				if (pi.GetCustomAttributes (typeof (ScriptableAttribute), false).Length == 0)
					continue;
				GenerateProperty (pi);
				hasItem = true;
			}

			// add events
			foreach (EventInfo ei in type.GetEvents ()) {
				if (ei.GetCustomAttributes (typeof (ScriptableAttribute), false).Length == 0)
					continue;
				GenerateEvent (ei);
				hasItem = true;
			}

			// add functions
			foreach (MethodInfo mi in type.GetMethods ()) {
				if (mi.GetCustomAttributes (typeof (ScriptableAttribute), false).Length == 0)
					continue;
				GenerateMethod (mi);
				hasItem = true;
			}

			if (!hasItem)
				throw new ArgumentException (String.Format ("The scriptable type {0} does not have scriptable members", type));

			moonlight_scriptable_object_register (plugin_handle, name, scriptable_wrapper);
		}

		void GenerateProperty (PropertyInfo pi)
		{
			TypeCode tc = Type.GetTypeCode (pi.PropertyType);
			if (!IsSupportedType (tc))
				throw new NotSupportedException (String.Format ("The scriptable object type {0} has a property {1} whose type {2} is not supported", type, pi, pi.PropertyType));

			GCHandle prop_handle = GCHandle.Alloc (pi); // XXX leak

			moonlight_scriptable_object_add_property (plugin_handle,
								  scriptable_wrapper,
								  (IntPtr)prop_handle,
								  pi.Name,
								  tc,
								  pi.CanRead,
								  pi.CanWrite);
		}

		void GenerateEvent (EventInfo ei)
		{
			Console.WriteLine ("TODO - events aren't hooked up yet for scriptable objects");
		}

		void GenerateMethod (MethodInfo mi)
		{
			TypeCode rc = Type.GetTypeCode (mi.ReturnType);
			
			if (mi.ReturnType != typeof (void) && !IsSupportedType (rc))
				throw new NotSupportedException (String.Format ("The scriptable object type {0} has a method {1} whose return type {2} is not supported", type, mi, mi.ReturnType));

			ParameterInfo[] ps = mi.GetParameters();
			TypeCode[] tcs = new TypeCode [ps.Length];

				foreach (ParameterInfo p in ps) {
					TypeCode pc = Type.GetTypeCode (p.ParameterType);
					if (p.IsOut || !IsSupportedType (pc))
						throw new NotSupportedException (String.Format ("The scriptable object type {0} has an event {1} whose parameter {2} is of not supported type", type, mi, p));

					tcs[p.Position] = pc;
				}

				GCHandle method_handle = GCHandle.Alloc (mi); // XXX leak

				moonlight_scriptable_object_add_method (plugin_handle,
									scriptable_wrapper,
									(IntPtr)method_handle,
									mi.Name,
									Type.GetTypeCode (mi.ReturnType),
									tcs,
									tcs.Length);
		}

		bool IsSupportedType (TypeCode tc)
		{
			switch (tc) {
			// string
			case TypeCode.Char:
			case TypeCode.String:
			// boolean
			case TypeCode.Boolean:
			// number
			case TypeCode.Byte:
			case TypeCode.SByte:
			case TypeCode.Int16:
			case TypeCode.Int32:
			case TypeCode.Int64:
			case TypeCode.UInt16:
			case TypeCode.UInt32:
			case TypeCode.UInt64:
			case TypeCode.Single:
			case TypeCode.Double:
			// case TypeCode.Decimal: // decimal is unsupported(!)
				return true;
			}
			return false;
		}

		[DllImport ("moonplugin")]
		static extern IntPtr moonlight_scriptable_object_wrapper_create (IntPtr plugin_handle, IntPtr obj_handle,
										 InvokeDelegate invoke,
										 SetPropertyDelegate set_prop,
										 GetPropertyDelegate get_prop);

		[DllImport ("moonplugin")]
		static extern void moonlight_scriptable_object_add_property (IntPtr plugin_handle,
									     IntPtr wrapper,
									     IntPtr property_handle,
									     string property_name,
									     TypeCode property_type,
									     bool readable,
									     bool writable);
		[DllImport ("moonplugin")]
		static extern void moonlight_scriptable_object_add_method (IntPtr plugin_handle,
									   IntPtr wrapper,
									   IntPtr method_handle,
									   string method_name,
									   TypeCode method_return_type,
									   TypeCode[] method_parameter_types,
									   int parameter_count);

		[DllImport ("moonplugin")]
		static extern void moonlight_scriptable_object_register (IntPtr plugin_handle,
									 string name,
									 IntPtr wrapper);
	}
}
