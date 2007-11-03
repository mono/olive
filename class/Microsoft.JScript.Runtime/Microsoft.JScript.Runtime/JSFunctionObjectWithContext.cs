using System;
using Microsoft.Scripting;
using Microsoft.Scripting.Actions;
using Microsoft.Scripting.Ast;

namespace Microsoft.JScript.Runtime {

	[Serializable]
	public class JSFunctionObjectWithContext : JSFunctionObject {

		public JSFunctionObjectWithContext (CodeContext context, string name, int length, CallTargetWithContextN callTarget,
						    string [] argNames, bool isStandardConstructor)
			: base (context, name, length, argNames, isStandardConstructor)
		{
		}

		public JSFunctionObjectWithContext (CodeContext context, string name, int length, CallTargetWithContextN callTarget,
						    string [] argNames, bool isStandardConstructor, bool callWithRuntimeContext)
			: base (context, name, length, argNames, isStandardConstructor)
		{
		}

		public override object Call (CodeContext context, object instance, object [] args)
		{
			return base.Call (context, instance, args);
		}

		protected override Expression [] GetArgumentsForRule<T> (StandardRule<T> rule, CallAction action)
		{
			return base.GetArgumentsForRule<T> (rule, action);
		}

		public override Delegate Target {
			get { throw new NotImplementedException (); }
		}
	}
}
