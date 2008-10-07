using System;
using Microsoft.Scripting;
using Microsoft.Scripting.Ast;
using Microsoft.Scripting.Actions;

namespace Microsoft.JScript.Runtime {

	[Serializable]
	public class JSFunctionObject : JSObject, IConstructorWithCodeContext {

		public JSFunctionObject (CodeContext context, string name, CallTargetN callTarget,
					 string [] argNames, bool isStandardConstructor)
			: base (GetPrototype ())
		{//ECMA 13.2
			this.context = context;
			this.name = name;
			this.argNames = argNames;
			SetCustomMember (context, SymbolTable.StringToId ("length"), new JSAttributedProperty(argNames.Length, JSPropertyAttributes.DontDelete | JSPropertyAttributes.DontEnum | JSPropertyAttributes.ReadOnly));
			if (isStandardConstructor) {
				constructTarget = Delegate.CreateDelegate (typeof (ConstructTargetN), context, this.GetType ().GetMethod ("construct"), true) as ConstructTargetN;
				SetCustomMember (context, SymbolTable.StringToId ("constructor"), new JSAttributedProperty (constructTarget, JSPropertyAttributes.DontEnum));
			}
			SetCustomMember (null, SymbolTable.StringToId ("prototype"), new JSAttributedProperty (prototype, JSPropertyAttributes.DontDelete));
		}

		protected JSFunctionObject (CodeContext context, string name, string [] argNames,
					    bool isStandardConstructor)
			: base (null)
		{
			throw new NotImplementedException ();
		}

		private CodeContext context;
		private string name;
		private CallTargetN callTarget;
		private ConstructTargetN constructTarget;
		private string[] argNames;
		
		public virtual object Call (CodeContext context, object instance, object [] args)
		{
			return callTarget (args);
		}

		public object Call (CodeContext context, object [] args)
		{
			return Call (context, null, args);
		}

		public static object construct (CodeContext context, object self, params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public object Construct (CodeContext context, params object [] args)
		{
			return this.constructTarget (this, args);
		}

		protected virtual Expression [] CreateArguments<T> (StandardRule<T> rule, int hasInstance, params Expression[] preargs)
		{
			throw new NotImplementedException ();
		}

		protected internal virtual Expression [] GetArgumentsForRule<T> (CallBinderHelper<T, CallAction> callHelper)
		{
			throw new NotImplementedException ();
		}

		public override string GetClassName ()
		{
			return "Function";
		}

		public virtual object GetDefaultValue ()
		{
			throw new NotImplementedException ();
		}

		public override StandardRule<T> GetRule<T> (DynamicAction action, CodeContext context, object [] args)
		{
			throw new NotImplementedException ();
		}

		public static JSFunctionObject MakeFunction (CodeContext context, string name,
							     Delegate target, string [] argNames, bool isStandardConstructor,
							     bool usesArguments)
		{
			//usesArguments
			return new JSFunctionObject (context, name, (CallTargetN)target, argNames, isStandardConstructor);
		}

		public static JSFunctionObject MakeFunction (CodeContext context, string name,
			Delegate target, string [] argNames, bool isStandardConstructor)
		{
			return MakeFunction (context, name, (CallTargetN)target, argNames, isStandardConstructor, false);
		}

		public ConstructTargetN ConstructTarget {
			get { return constructTarget; }
		}

		public CodeContext Context {
			get { return context; }
		}

		public override LanguageContext LanguageContext {
			get { throw new NotImplementedException (); }
		}

		public bool UsesArguments {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		public int Length {
			get { throw new NotImplementedException (); }
		}

		public string[] ArgNames {
			get { throw new NotImplementedException (); }
		}

		public virtual Delegate Target {
			get { return callTarget; }
		}

		internal static JSObject GetPrototype ()
		{
			return funcPrototype;
		}

		internal static JSObject funcPrototype = null;
	}
}
