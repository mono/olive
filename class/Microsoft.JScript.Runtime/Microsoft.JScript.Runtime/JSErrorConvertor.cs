using System;
using Microsoft.Scripting;
using System.Text;

namespace Microsoft.JScript.Runtime {

	public static class JSErrorConvertor {
		public static string FormatException (Exception exception, EngineOptions options)
		{
			StringBuilder builder = new StringBuilder ();
			builder.AppendLine (" Error: ");
			builder.AppendLine (exception.Message);
			if (options.ShowClrExceptions) {
				builder.AppendLine ();
				builder.AppendLine ("CLR Exception");
				builder.Append (exception.GetType().Name + " : ");
				builder.AppendLine (exception.Message);
				builder.AppendLine (exception.StackTrace);
			}
			return builder.ToString ();
		}

		public static string GetErrorText (JSError key)
		{
			throw new NotImplementedException ();
		}
	}
}
