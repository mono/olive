using System;
using Microsoft.Scripting;
using Microsoft.Scripting.Internal;
using IronPython.Runtime.Types;

namespace Microsoft.JScript.Runtime {

	public static class JSBooleanObjectOps {

		[OperatorMethod]
		public static double Add ([NotNull] JSBooleanObject x, bool y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static double Add ([NotNull] JSBooleanObject x, double y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static double Add ([NotNull] JSBooleanObject x, None y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static double Add ([NotNull] JSBooleanObject x, [NotNull] JSBooleanObject y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static double Add ([NotNull] JSBooleanObject x, [NotNull] JSNumberObject y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static string Add ([NotNull] JSBooleanObject x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static double Add ([NotNull] JSBooleanObject x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static string Add ([NotNull] JSBooleanObject x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}
	}
}
