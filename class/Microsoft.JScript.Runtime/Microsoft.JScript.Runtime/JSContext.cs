using System;
using Microsoft.Scripting;
using Microsoft.Scripting.Actions;
using Microsoft.Scripting.Hosting;

namespace Microsoft.JScript.Runtime {

	public sealed class JSContext : LanguageContext {
		public JSContext (ScriptEngine engine)
			: base (engine)
		{
		}

		public override object Call (CodeContext context, object function, object [] args)
		{
			return base.Call (context, function, args);
		}

		public override object CallWithArgsKeywordsTupleDict (CodeContext context, object func, object [] args, string [] names, object argsTuple, object kwDict)
		{
			return base.CallWithArgsKeywordsTupleDict (context, func, args, names, argsTuple, kwDict);
		}

		public override object CallWithArgsTuple (CodeContext context, object func, object [] args, object argsTuple)
		{
			return base.CallWithArgsTuple (context, func, args, argsTuple);
		}

		public override object CallWithKeywordArgs (CodeContext context, object func, object [] args, string [] names)
		{
			return base.CallWithKeywordArgs (context, func, args, names);
		}

		public override object CallWithThis (CodeContext context, object function, object instance, object [] args)
		{
			return base.CallWithThis (context, function, instance, args);
		}

		public override object DeleteIndex (CodeContext context, object target, object index)
		{
			return base.DeleteIndex (context, target, index);
		}

		public override object DeleteMember (CodeContext context, object target, SymbolId name)
		{
			return base.DeleteMember (context, target, name);
		}

		public override bool EqualReturnBool (CodeContext context, object x, object y)
		{
			return base.EqualReturnBool (context, x, y);
		}

		public override object GetBoundMember (CodeContext context, object target, SymbolId name)
		{
			return base.GetBoundMember (context, target, name);
		}

		public override object GetIndex (CodeContext context, object target, object index)
		{
			return base.GetIndex (context, target, index);
		}

		public override LanguageContext GetLanguageContextForModule (ScriptModule module)
		{
			return base.GetLanguageContextForModule (module);
		}

		public override object GetMember (CodeContext context, object target, SymbolId name)
		{
			return base.GetMember (context, target, name);
		}

		public override bool IsTrue (object obj)
		{
			return base.IsTrue (obj);
		}

		public override object PushExceptionHandler (CodeContext context, Exception exception)
		{
			return base.PushExceptionHandler (context, exception);
		}

		public override bool RemoveName (Scope scope, SymbolId name)
		{
			return base.RemoveName (scope, name);
		}

		public override void SetIndex (CodeContext context, object target, object index, object value)
		{
			base.SetIndex (context, target, index, value);
		}

		public override void SetMember (CodeContext context, object target, SymbolId name, object value)
		{
			base.SetMember (context, target, name, value);
		}

		public override void SetName (Scope scope, SymbolId name, object value)
		{
			base.SetName (scope, name, value);
		}

		public override bool TryGetSwitchIndex (CodeContext context, object exprVal, out int index)
		{
			return base.TryGetSwitchIndex (context, exprVal, out index);
		}

		public JSFunctionObject ArrayConstructor {
			get { throw new NotImplementedException (); }
		}

		public JSObject ArrayPrototype {
			get { throw new NotImplementedException (); }
		}

		public override ActionBinder Binder {
			get { return base.Binder; }
		}

		public JSFunctionObject BooleanConstructor {
			get { throw new NotImplementedException (); }
		}

		public JSObject BooleanPrototype {
			get { throw new NotImplementedException (); }
		}

		public override ContextId ContextId {
			get { return base.ContextId; }
		}

		public JSFunctionObject DateConstructor {
			get { throw new NotImplementedException (); }
		}

		public JSObject DatePrototype {
			get { throw new NotImplementedException (); }
		}

		public JSFunctionObject ErrorConstructor {
			get { throw new NotImplementedException (); }
		}

		public JSObject ErrorPrototype {
			get { throw new NotImplementedException (); }
		}

		public JSFunctionObject EvalErrorConstructor {
			get { throw new NotImplementedException (); }
		}

		public JSObject EvalErrorPrototype {
			get { throw new NotImplementedException (); }
		}

		public JSFunctionObject FunctionConstructor {
			get { throw new NotImplementedException (); }
		}

		public JSObject FunctionPrototype {
			get { throw new NotImplementedException (); }
		}

		public JSObject MathObject {
			get { throw new NotImplementedException (); }
		}

		public JSFunctionObject NumberConstructor {
			get { throw new NotImplementedException (); }
		}

		public JSObject NumberPrototype {
			get { throw new NotImplementedException (); }
		}

		public JSFunctionObject ObjectConstructor {
			get { throw new NotImplementedException (); }
		}

		public JSObject ObjectPrototype {
			get { throw new NotImplementedException (); }
		}

		public JSFunctionObject RangeErrorConstructor {
			get { throw new NotImplementedException (); }
		}

		public JSObject RangeErrorPrototype {
			get { throw new NotImplementedException (); }
		}

		public JSFunctionObject ReferenceErrorConstructor {
			get { throw new NotImplementedException (); }
		}

		public JSObject ReferenceErrorPrototype {
			get { throw new NotImplementedException (); }
		}

		public JSRegExpConstructor RegExpConstructor {
			get { throw new NotImplementedException (); }
		}

		public JSObject RegExpPrototype {
			get { throw new NotImplementedException (); }
		}

		public override bool ShowCls {
			get { throw new Exception ("The method or operation is not implemented."); }
			set { throw new Exception ("The method or operation is not implemented."); }
		}

		public JSFunctionObject StringConstructor {
			get { throw new NotImplementedException (); }
		}

		public JSObject StringPrototype {
			get { throw new NotImplementedException (); }
		}

		public JSFunctionObject SyntaxErrorConstructor {
			get { throw new NotImplementedException (); }
		}

		public JSObject SyntaxErrorPrototype {
			get { throw new NotImplementedException (); }
		}

		public JSFunctionObject TypeErrorConstructor {
			get { throw new NotImplementedException (); }
		}

		public JSObject TypeErrorPrototype {
			get { throw new NotImplementedException (); }
		}

		public JSFunctionObject URIErrorConstructor {
			get { throw new NotImplementedException (); }
		}

		public JSObject URIErrorPrototype {
			get { throw new NotImplementedException (); }
		}

	}
}
