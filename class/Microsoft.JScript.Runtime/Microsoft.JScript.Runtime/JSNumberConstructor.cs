using System;
using Microsoft.Scripting;

namespace Microsoft.JScript.Runtime {

	public class JSNumberConstructor : JSFunctionObject {

		public const double MAX_VALUE = double.MaxValue;
		public const double MIN_VALUE = 4.94065645841247E-324;
		public const double NaN = double.NaN;
		public const double NEGATIVE_INFINITY = double.NegativeInfinity;
		public const double POSITIVE_INFINITY = double.PositiveInfinity;

		public JSNumberConstructor (CodeContext context) : base (context, "", new string []{}, true )
		{
		}

		public static object call (CodeContext context, params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static new object construct (CodeContext context, object self, params object [] arguments)
		{
			throw new NotImplementedException ();
		}
	}
}
