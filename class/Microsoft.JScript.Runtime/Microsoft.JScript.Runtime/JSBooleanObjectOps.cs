using System;
using Microsoft.Scripting;
using System.Runtime.CompilerServices;

namespace Microsoft.JScript.Runtime {

	public static class JSBooleanObjectOps {

		[SpecialName]
		public static double op_Addition ([NotNull] JSBooleanObject x, bool y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Addition ([NotNull] JSBooleanObject x, double y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Addition ([NotNull] JSBooleanObject x, None y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Addition ([NotNull] JSBooleanObject x, [NotNull] JSBooleanObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Addition ([NotNull] JSBooleanObject x, [NotNull] JSNumberObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static string op_Addition ([NotNull] JSBooleanObject x, [NotNull] JSObject y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static double op_Addition ([NotNull] JSBooleanObject x, [NotNull] UnDefined y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static string op_Addition ([NotNull] JSBooleanObject x, [NotNull] string y)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static string op_Addition ([NotNull] JSBooleanObject x, [NotNull] ConcatString y)
		{
			throw new NotImplementedException ();
		}
	}
}
