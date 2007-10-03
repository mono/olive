using System;

namespace Microsoft.JScript.Runtime {
	public static class Runtime {
		//TODO work on that to do better than that quick hack
		public static long DoubleToInt64 (double val)
		{
			return (long)Math.Floor (val);
		}

		public static long UncheckedDecimalToInt64 (decimal val)
		{
			return (long)Math.Floor ((double)val);
		}
	}
}
