using System;
using System.Collections;
using Microsoft.Scripting;

namespace Microsoft.JScript.Runtime {

	public static class JSCompilerHelpers {
		public static JSArrayObject ConstructArrayFromArrayLiteral (CodeContext context, object [] values)
		{
			JSArrayObject result = new JSArrayObject ();
			foreach (object obj in values) {
				result.AddObjectKey (obj.ToString (), obj);
			}
			return result;
		}

		public static IAttributesCollection ConstructCatchScopeObject (CodeContext context, SymbolId catchName)
		{
			throw new NotImplementedException ();
		}

		public static object ConstructObjectFromLiteral (CodeContext context, object [] names, object [] values)
		{
			JSObject obj = new JSObject (((JSContext)context.LanguageContext).ObjectPrototype);
			for (int i = 0; i < names.Length; i++) {
				obj.AddObjectKey (names[i], values[i]);
			}
			return obj;
		}

		public static IAttributesCollection ConstructScopeObject (CodeContext context, object value)
		{
			throw new NotImplementedException ();
		}

		public static bool Delete (CodeContext context, SymbolId name)
		{
			return context.LanguageContext.RemoveName (context, name);
		}

		public static IEnumerator GetEnumeratorForIteration (CodeContext context, object o)
		{
			throw new NotImplementedException ();
		}

		public static bool In (object PropertyInstance, object ObjectInstance)
		{
			//TODO
			throw new NotImplementedException ();
		}

		public static bool InstanceOf (object ObjectInstance, object FunctionInstance)
		{
			//TODO
			throw new NotImplementedException ();
		}

		public static object Is (object x, object y)
		{
			//TODO
			throw new NotImplementedException ();
		}

		public static object IsNot (object x, object y)
		{
			//TODO
			throw new NotImplementedException ();
		}

		public static Exception MakeException (object value)
		{
			throw new NotImplementedException ();
		}

		public static JSRegExpObject MakeRegex (CodeContext context, string source, string flags)
		{
			throw new NotImplementedException ();
		}

		public static double Negate (object x)
		{
			return (-1) * Convert.ToNumber (x);
		}

		public static bool Not (object x)
		{
			return !Convert.ToBoolean (x);
		}

		public static int OnesComplement (object x)
		{
			return ~Convert.ToInt32 (x);
		}

		public static double Positive (object x)
		{
			return Convert.ToNumber (x);
		}

		public static void PrintExpressionValue (object o)
		{
			Console.WriteLine (o.ToString ());
		}

		public static string TypeOf (object O)
		{
			return O.GetType ().ToString ();
		}

		public static object Void (object Operand)
		{
			//TODO
			throw new NotImplementedException ();
		}
	}
}
