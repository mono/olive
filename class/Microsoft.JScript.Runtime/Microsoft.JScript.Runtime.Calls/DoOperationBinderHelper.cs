using System;
using Microsoft.Scripting;
using Microsoft.Scripting.Actions;

namespace Microsoft.JScript.Runtime.Calls {
	
	public class DoOperationBinderHelper<T> {

		protected DoOperationAction _action;

		public DoOperationBinderHelper (ActionBinder binder, CodeContext context, DoOperationAction action)
		{
			throw new NotImplementedException ();
		}

		public static object DynamicInvokeBinaryOperation (CodeContext context, Operators op, object x, object y)
		{
			throw new NotImplementedException ();
		}

		public static object DynamicInvokeCompareOperation (CodeContext context, Operators op, object x, object y)
		{
			throw new NotImplementedException ();
		}

		public static object DynamicInvokeInplaceOperation (CodeContext context, Operators op, object x, object y)
		{
			throw new NotImplementedException ();
		}

		public StandardRule<T> MakeRule (object [] args)
		{
			throw new NotImplementedException ();
		}

		public override string ToString ()
		{
			return base.ToString ();
		}
	}
}
