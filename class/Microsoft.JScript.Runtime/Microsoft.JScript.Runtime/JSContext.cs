// JSContext.cs
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
using Microsoft.Scripting.Actions;
using Microsoft.Scripting.Hosting;
using Microsoft.Scripting.Ast;

namespace Microsoft.JScript.Runtime {
//TODO
	public sealed class JSContext : LanguageContext {
		public JSContext (ScriptDomainManager manager) : base (manager)
		{
			throw new NotImplementedException ();
		}

		public static JSContext GetContext (CodeContext context)
		{
			throw new NotImplementedException ();
		}

		public override ErrorSink GetCompilerErrorSink ()
		{
			throw new NotImplementedException ();
		}

		public override ScopeExtension CreateScopeExtension (Scope scope)
		{
			throw new NotImplementedException ();
		}

		public override ServiceType GetService<ServiceType> (params object[] args)
		{
			throw new NotImplementedException ();
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

		public override bool EqualReturnBool (CodeContext context, object x, object y)
		{
			return base.EqualReturnBool (context, x, y);
		}

		public override bool IsTrue (object obj)
		{
			return base.IsTrue (obj);
		}

		public override bool RemoveName (CodeContext context, SymbolId name)
		{
			return base.RemoveName (context, name);
		}

		public override CodeBlock ParseSourceCode (CompilerContext context)
		{
			throw new NotImplementedException ();
		}

		public override string FormatException (Exception exception)
		{
			throw new NotImplementedException ();
		}

		public void ExecuteOptimizedModule (string path)
		{
			throw new NotImplementedException ();
		}

		public override void GetExceptionMessage (Exception exception, out string message, out string typeName)
		{
			throw new NotImplementedException ();
		}

		public override void SetName (CodeContext context, SymbolId name, object value)
		{
			throw new NotImplementedException ();
		}

		public override string DisplayName {
			get { throw new NotImplementedException (); }
		}

		public bool ECMA3Mode {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		public override Version LanguageVersion {
			get { throw new NotImplementedException (); }
		}
	}
}
