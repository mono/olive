using System;
using Microsoft.Scripting;

namespace Microsoft.JScript.Runtime {

	public static class JSEnumOps {
		public static object BitwiseAnd ([NotNull] object self, [NotNull] object other)
		{
			throw new NotImplementedException ();
		}

		public static object BitwiseOr ([NotNull] object self, [NotNull] object other)
		{
			throw new NotImplementedException ();
		}

		public static bool Equal ([NotNull] object self, [NotNull] object other)
		{
			throw new NotImplementedException ();
		}

		public static object ExclusiveOr ([NotNull] object self, [NotNull] object other)
		{
			throw new NotImplementedException ();
		}

		public static bool NotEqual ([NotNull] object self, [NotNull] object other)
		{
			return !Equal (self, other);
		}

		public static object OnesComplement ([NotNull] object self)
		{
			throw new NotImplementedException ();
		}
	}
}
