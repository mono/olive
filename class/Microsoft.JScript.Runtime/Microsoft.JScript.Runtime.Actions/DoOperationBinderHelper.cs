using System;
using Microsoft.Scripting;
using Microsoft.Scripting.Actions;

namespace Microsoft.JScript.Runtime.Actions {
	
	public class DoOperationBinderHelper<T> : BinderHelper<T, DoOperationAction> {

		public DoOperationBinderHelper (CodeContext context, DoOperationAction action, object[] args) : base (context, action)
		{
			throw new NotImplementedException ();
		}

		public StandardRule<T> MakeRule ()
		{
			throw new NotImplementedException ();
		}

	}
}
