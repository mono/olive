using System;
using System.Collections;
using Microsoft.Scripting;

namespace Microsoft.JScript.Runtime {

	public static class JSCompilerHelpers {
		public static JSArrayObject ConstructArrayFromArrayLiteral (CodeContext context, object [] values)
		{
			throw new NotImplementedException ();
		}

		public static IAttributesCollection ConstructCatchScopeObject (CodeContext context, SymbolId catchName)
		{
			throw new NotImplementedException ();
		}

		public static object ConstructObjectFromLiteral (CodeContext context, object [] names, object [] values)
		{
			throw new NotImplementedException ();
		}

		public static IAttributesCollection ConstructScopeObject (CodeContext context, object value)
		{
			throw new NotImplementedException ();
		}

		public static bool Delete (CodeContext context, SymbolId name)
		{
			throw new NotImplementedException ();
		}

		public static IEnumerator GetEnumeratorForIteration (CodeContext context, object o)
		{
			throw new NotImplementedException ();
		}

		public static bool In (object PropertyInstance, object ObjectInstance)
		{
			throw new NotImplementedException ();
		}

		public static bool InstanceOf (object ObjectInstance, object FunctionInstance)
		{
			throw new NotImplementedException ();
		}

		public static object Is (object x, object y)
		{
			throw new NotImplementedException ();
		}

		public static object IsNot (object x, object y)
		{
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
			throw new NotImplementedException ();
		}

		public static bool Not (object x)
		{
			throw new NotImplementedException ();
		}

		public static int OnesComplement (object x)
		{
			throw new NotImplementedException ();
		}

		public static double Positive (object x)
		{
			throw new NotImplementedException ();
		}

		public static void PrintExpression (object o)
		{
			throw new NotImplementedException ();
		}

		public static string TypeOf (object O)
		{
			throw new NotImplementedException ();
		}

		public static object Void (object Operand)
		{
			throw new NotImplementedException ();
		}
	}
}
