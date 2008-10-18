// FunctionObjectWithRuntimeContext.cs
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
using Microsoft.Scripting.Ast;
using Microsoft.Scripting.Runtime;
using System.Linq.Expressions;
using Microsoft.JScript.Runtime.Actions;

namespace Microsoft.JScript.Runtime.Types {

	[Serializable]
	public class FunctionObjectWithRuntimeContext : FunctionObject {

		public FunctionObjectWithRuntimeContext (CodeContext context, string name, CallTargetEval callTarget,
						    string [] argNames, bool isStandardConstructor)
			: base (context, name, argNames, isStandardConstructor)
		{
		}

		internal FunctionObjectWithRuntimeContext (CodeContext context, string name, CallTargetEval callTarget,
						    string [] argNames, bool isStandardConstructor, bool callWithRuntimeContext)
			: base (context, name, argNames, isStandardConstructor)
		{
		}

		public override object Call (CodeContext context, object instance, object [] args)
		{
			return base.Call (context, instance, args);
		}

		protected internal override Expression [] GetArgumentsForRule<T> (Microsoft.JScript.Runtime.Actions.CallBinderHelper<T, OldCallAction> callhelper)
		{
			return base.GetArgumentsForRule<T> (callhelper);
		}

		public override Delegate Target {
			get { throw new NotImplementedException (); }
		}
	}
}
