using System;
using Microsoft.Scripting;
using Microsoft.Scripting.Actions;
using Microsoft.Scripting.Internal.Ast;
using Microsoft.Scripting.Internal.Generation;

namespace Microsoft.JScript.Runtime.Calls {

	public class JSBinder : ActionBinder {

		public readonly ActionBinder Default;

		public JSBinder (CodeContext context)
			: base (context)
		{
		}

		public override bool CanConvertFrom (Type fromType, Type toType, NarrowingLevel level)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		public override object Convert (object obj, Type toType)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		public override Expression ConvertExpression (Expression expr, Type toType)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		public override void EmitConvertFromObject (CodeGen cg, Type paramType)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		protected override StandardRule<T> MakeRule<T> (Action action, object [] args)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		public override bool PreferConvert (Type t1, Type t2)
		{
			throw new Exception ("The method or operation is not implemented.");
		}
	}
}
