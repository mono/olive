using System;
using Microsoft.Scripting;
using System.Runtime.CompilerServices;

namespace Microsoft.JScript.Runtime {

	public static class JSEnumOps {

		[SpecialName]
		public static object op_BitwiseAnd ([NotNull] object self, [NotNull] object other)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static object op_BitwiseOr ([NotNull] object self, [NotNull] object other)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Equality ([NotNull] object self, [NotNull] object other)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static object op_ExclusiveOr ([NotNull] object self, [NotNull] object other)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool op_Inequality ([NotNull] object self, [NotNull] object other)
		{
			return !op_Equality (self, other);
		}

		[SpecialName]
		public static object op_OnesComplement ([NotNull] object self)
		{
			throw new NotImplementedException ();
		}
	}
}
