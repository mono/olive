using System;
using Microsoft.Scripting;
using System.Runtime.CompilerServices;

namespace Microsoft.JScript.Runtime {

	public static class JSEnumOps {

		[SpecialName]
		public static object BitwiseAnd ([NotNull] object self, [NotNull] object other)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static object BitwiseOr ([NotNull] object self, [NotNull] object other)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool Equal ([NotNull] object self, [NotNull] object other)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static object ExclusiveOr ([NotNull] object self, [NotNull] object other)
		{
			throw new NotImplementedException ();
		}

		[SpecialName]
		public static bool NotEqual ([NotNull] object self, [NotNull] object other)
		{
			return !Equal (self, other);
		}

		[SpecialName]
		public static object OnesComplement ([NotNull] object self)
		{
			throw new NotImplementedException ();
		}
	}
}
