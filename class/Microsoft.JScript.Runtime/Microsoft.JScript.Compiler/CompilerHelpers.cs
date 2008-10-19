//
// CompilerHelpers
//
// Author:
//   Olivier Dufour (olivier.duff@gmail.com)
//
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
using System.Collections;
using Microsoft.Scripting;
using Microsoft.Scripting.Runtime;
using Microsoft.JScript.Runtime.Types;
using Microsoft.JScript.Runtime.Conversions;


namespace Microsoft.JScript.Compiler {

	public static class CompilerHelpers {
		public static ArrayObject ConstructArrayFromArrayLiteral (CodeContext context, object [] values)
		{
			ArrayObject result = new ArrayObject ();
			foreach (object obj in values) {
				result.AddObjectKey (obj.ToString (), obj);
			}
			return result;
		}

		public static IAttributesCollection ConstructCatchObject (CodeContext context, SymbolId catchName)
		{
			throw new NotImplementedException ();
		}

		public static IAttributesCollection ConstructCatchScopeObject (CodeContext context, SymbolId catchName)
		{
			throw new NotImplementedException ();
		}

		public static object ConstructObjectFromLiteral (CodeContext context, object [] names, object [] values)
		{
			/*JSObject obj = new JSObject (((JSContext)context.LanguageContext).Prototype);
			for (int i = 0; i < names.Length; i++) {
				obj.AddObjectKey (names[i], values[i]);
			}
			return obj;*/
			throw new NotImplementedException ();
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

		public static bool EqualReturnBool (CodeContext context, object x, object y)
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

		public static bool IsReturnBool (CodeContext context, object x, object y)
		{
			throw new NotImplementedException ();
		}

		public static bool IsTrue (object obj)
		{
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

		public static object PushExceptionHandler (CodeContext context, Exception clrException)
		{
			throw new NotImplementedException ();
		}

		public static Exception MakeException (object value)
		{
			throw new NotImplementedException ();
		}

		public static int GetSwitchIndex (object exprVal, int defaultval)
		{
			throw new NotImplementedException ();
		}

		public static RegExpObject MakeRegex (CodeContext context, string source, string flags)
		{
			throw new NotImplementedException ();
		}

		public static double Negate (object x)
		{
			return (-1) * ConvertHelper.ToNumber (x);
		}

		public static bool Not (object x)
		{
			return !ConvertHelper.ToBoolean (x);
		}

		public static int OnesComplement (object x)
		{
			return ~ConvertHelper.ToInt32 (x);
		}

		public static double Positive (object x)
		{
			return ConvertHelper.ToNumber (x);
		}

		public static void PrintExpressionValue (object o)
		{
			Console.WriteLine (o.ToString ());
		}

		public static string TypeOf (object O)
		{
			return O.GetType ().ToString ();
		}

		public static void ClearDynamicStackFrames ()
		{
			throw new NotImplementedException ();
		}

		public static void PopExceptionHandler ()
		{
			throw new NotImplementedException ();
		}

		public static object Void (object Operand)
		{
			//TODO
			throw new NotImplementedException ();
		}
	}
}
