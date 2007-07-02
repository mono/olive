using System;
using Microsoft.Scripting;
using Microsoft.Scripting.Internal;

namespace Microsoft.JScript.Runtime {

	public static class JSEnumOps {

		[OperatorMethod]
		public static object BitwiseAnd ([NotNull] object self, [NotNull] object other)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static object BitwiseOr ([NotNull] object self, [NotNull] object other)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static bool Equal ([NotNull] object self, [NotNull] object other)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static object ExclusiveOr ([NotNull] object self, [NotNull] object other)
		{
			throw new NotImplementedException ();
		}

		[OperatorMethod]
		public static bool NotEqual ([NotNull] object self, [NotNull] object other)
		{
			return !Equal (self, other);
		}

		[OperatorMethod]
		public static object OnesComplement ([NotNull] object self)
		{
			throw new NotImplementedException ();
		}
	}
}
