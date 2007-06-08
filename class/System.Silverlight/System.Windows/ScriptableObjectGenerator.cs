using System;
using System.Reflection;
using System.Text;
using System.Windows.Browser;
using System.Windows.Browser.Serialization;

namespace System.Windows
{
	internal class ScriptableObjectGenerator
	{
		public static string GenerateJavaScript (string nameOnJS, object obj)
		{
			return new ScriptableObjectGenerator (nameOnJS, obj).Generate ();
		}

		string name;
		object obj;
		Type type;
		JavaScriptSerializer ser;
		StringBuilder sb;

		ScriptableObjectGenerator (string name, object obj)
		{
			this.name = name;
			this.obj = obj;
			sb = new StringBuilder ();
			type = obj.GetType ();
			ser = new JavaScriptSerializer ();
		}

		static readonly object [] empty_args = new object [0];

		public string Generate ()
		{
			sb.Append ("document.getElementById('SilverlightControl').Contents.").Append (name).Append (" = {\n");

			bool hasItem = false;

			// add properties

			foreach (PropertyInfo pi in type.GetProperties ()) {
				if (pi.GetCustomAttributes (typeof (ScriptableAttribute), false).Length == 0)
					continue;
				GenerateProperty (pi, hasItem);
				hasItem = true;
			}

			// add events
			foreach (EventInfo ei in type.GetEvents ()) {
				if (ei.GetCustomAttributes (typeof (ScriptableAttribute), false).Length == 0)
					continue;
				GenerateEvent (ei, hasItem);
				hasItem = true;
			}

			// add functions
			foreach (MethodInfo mi in type.GetMethods ()) {
				if (mi.GetCustomAttributes (typeof (ScriptableAttribute), false).Length == 0)
					continue;
				GenerateMethod (mi, hasItem);
				hasItem = true;
			}

			sb.Append ("};\n");

			if (!hasItem)
				throw new ArgumentException (String.Format ("The scriptable type {0} does not have scriptable members", type));

			return sb.ToString ();
		}

		void GenerateProperty (PropertyInfo pi, bool hasItem)
		{
			if (!IsSupportedType (pi.PropertyType))
				throw new NotSupportedException (String.Format ("The scriptable object type {0} has a property {1} whose type {2} is not supported", type, pi, pi.PropertyType));
			if (hasItem)
				sb.Append (",\n");

			// FIXME: probably we will have to hook them at NPP side?
			sb.Append (pi.Name).Append (" : ").Append (pi.CanRead ? ser.Serialize (pi.GetValue (obj, empty_args)) : "null").Append ('\n');
		}

		void GenerateEvent (EventInfo ei, bool hasItem)
		{
			// types in event delegate (return type or parameters)
			// are not validated.
			sb.Append (ei.Name).Append (" : null // FIXME: how to bind an event?");
			// FIXME: do we have to bind something here, or can
			// we just hook them at NPP side?
		}

		void GenerateMethod (MethodInfo mi, bool hasItem)
		{
			if (mi.ReturnType != typeof (void) && !IsSupportedType (mi.ReturnType))
				throw new NotSupportedException (String.Format ("The scriptable object type {0} has a method {1} whose return type {2} is not supported", type, mi, mi.ReturnType));
			if (hasItem)
				sb.Append (",\n");

			sb.Append (mi.Name).Append (" : function(");
			bool hasParam = false;
			foreach (ParameterInfo para in mi.GetParameters ()) {
				if (para.IsOut || !IsSupportedType (para.ParameterType))
					throw new NotSupportedException (String.Format ("The scriptable object type {0} has an event {1} whose parameter {2} is of not supported type", type, mi, para));
				if (hasParam)
					sb.Append (", ");
				sb.Append (para.Name);
				hasParam = true;
			}
			sb.Append (") {\n");
			// FIXME: do we have to bind something here, or can
			// we just hook them at NPP side?
			sb.Append ("}\n");
		}

		bool IsSupportedType (Type type)
		{
			switch (Type.GetTypeCode (type)) {
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
	}
}
