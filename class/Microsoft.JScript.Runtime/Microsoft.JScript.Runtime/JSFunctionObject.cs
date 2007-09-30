using System;
using Microsoft.Scripting;
using Microsoft.Scripting.Internal.Ast;
using Microsoft.Scripting.Actions;

namespace Microsoft.JScript.Runtime {

	[Serializable]
	public class JSFunctionObject : JSObject, IActionable, ICallableWithCodeContext, ICallableWithThis, IConstructorWithCodeContext {
		
		public JSFunctionObject (CodeContext context, string name, int length, CallTargetN callTarget,
					 string [] argNames, bool isStandardConstructor)
			: base (null)
		{
			throw new NotImplementedException ();
		}

		protected JSFunctionObject (CodeContext context, string name, int length, string [] argNames,
					    bool isStandardConstructor)
			: base (null)
		{
			throw new NotImplementedException ();
		}

		private CodeContext context;
		private string name;
		private CallTargetN callTarget;
		private string[] argNames;
		private bool isStandardConstructor;
		
		public virtual object Call (CodeContext context, object instance, object [] args)
		{
			throw new NotImplementedException ();
		}

		object ICallableWithCodeContext.Call (CodeContext context, object [] args)
		{
			throw new NotImplementedException ();
		}

		public static object construct (CodeContext context, object self, params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public object Construct (CodeContext context, params object [] args)
		{
			throw new NotImplementedException ();
		}

		protected virtual Expression [] GetArgumentsForRule<T> (StandardRule<T> rule, CallAction action)
		{
			throw new NotImplementedException ();
		}

		public override string GetClassName ()
		{
			throw new NotImplementedException ();
		}

		public StandardRule<T> GetRule<T> (Action action, CodeContext context, object [] args)
		{
			throw new NotImplementedException ();
		}

		public static JSFunctionObject MakeFunction (CodeContext context, string name, int length,
							     Delegate target, string [] argNames, bool isStandardConstructor,
							     bool usesArguments)
		{
			//TODO
			throw new NotImplementedException ();
		}

		protected CallTargetN CallTarget {
			get { return callTarget; }
			set { callTarget = value; }
		}

		public CodeContext Context {
			get { return context; }
			set { context = value; }
		}

		public virtual Delegate Target {
			get { throw new NotImplementedException (); }
		}
	}
}
