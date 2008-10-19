// JSFunctionObjectWithThis.cs
//
// Authors:
//   Olivier Dufour <olivier.duff@gmail.com>
//
// Copyright (C) 2008 Olivier Dufour
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
//

using System;
using Microsoft.Scripting;
using Microsoft.Scripting.Ast;
using Microsoft.Scripting.Actions;
using Microsoft.Scripting.Runtime;
using System.Linq.Expressions;

namespace Microsoft.JScript.Runtime.Types {

	[Serializable]
	public class FunctionObject : JSObject {

		public FunctionObject (CodeContext context, string name, CallTargetN callTarget,
					 string [] argNames, bool isStandardConstructor)
			: base (GetPrototype ())
		{//ECMA 13.2
			this.context = context;
			this.name = name;
			this.argNames = argNames;
			this.callTarget = callTarget;
			SetItem (SymbolTable.StringToId ("length"), new JSAttributedProperty(argNames.Length, JSPropertyAttributes.DontDelete | JSPropertyAttributes.DontEnum | JSPropertyAttributes.ReadOnly));
			if (isStandardConstructor) {
				constructTarget = Delegate.CreateDelegate (typeof (ConstructTargetN), context, this.GetType ().GetMethod ("construct"), true) as ConstructTargetN;
				SetItem (SymbolTable.StringToId ("constructor"), new JSAttributedProperty (constructTarget, JSPropertyAttributes.DontEnum));
			}
			SetItem (SymbolTable.StringToId ("prototype"), new JSAttributedProperty (prototype, JSPropertyAttributes.DontDelete));
		}

		protected FunctionObject (CodeContext context, string name, string [] argNames,
					    bool isStandardConstructor)
			: this (context, name, null, argNames, isStandardConstructor)
		{
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
			return Call (context, JSOps.GetGlobalObject(context), args);
		}

		public static object construct (CodeContext context, object self, params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public object Construct (CodeContext context, params object [] args)
		{
			return this.constructTarget (this, args);
		}

		protected virtual Expression [] CreateArguments<T> (RuleBuilder<T> rule, int hasInstance, params Expression[] preargs) where T : class
		{
			throw new NotImplementedException ();
		}

		protected internal virtual Expression[] GetArgumentsForRule<T>(Microsoft.JScript.Runtime.Actions.CallBinderHelper<T, OldCallAction>  callHelper) where T : class
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

		public override RuleBuilder<T> GetRule<T> (OldDynamicAction action, CodeContext context, object [] args)
		{
			throw new NotImplementedException ();
		}

		public static FunctionObject MakeFunction (CodeContext context, string name,
							     Delegate target, string [] argNames, bool isStandardConstructor,
							     bool usesArguments)
		{
			//usesArguments
			return new FunctionObject (context, name, (CallTargetN)target, argNames, isStandardConstructor);
		}

		public static FunctionObject MakeFunction (CodeContext context, string name,
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
