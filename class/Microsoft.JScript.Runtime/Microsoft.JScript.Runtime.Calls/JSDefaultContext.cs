using System;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;

namespace Microsoft.JScript.Runtime.Calls {

	public static class JSDefaultContext {

		public static CodeContext Default;
		public static ContextId JSContext;
		public static ScriptEngine _JSScriptEngine;

		public static CodeContext CreateDefaultJSContext ()
		{
			throw new NotImplementedException ();
		}
	}
}
