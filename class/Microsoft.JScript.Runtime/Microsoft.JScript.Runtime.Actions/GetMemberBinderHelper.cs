using System;
using Microsoft.Scripting;
using Microsoft.Scripting.Actions;
using Microsoft.JScript.Runtime.Calls;

namespace Microsoft.JScript.Runtime.Actions {

	public class GetMemberBinderHelper<T> : Microsoft.Scripting.Actions.GetMemberBinderHelper<T> {
		public GetMemberBinderHelper (CodeContext context, GetMemberAction action, object[] args) : base (context, action, args)
		{
			throw new NotImplementedException ();
		}

		public StandardRule<T> MakeRule ()
		{
			throw new NotImplementedException ();
		}
	}
}
