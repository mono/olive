using System;
using Microsoft.Scripting;
using Microsoft.Scripting.Actions;
using Microsoft.JScript.Runtime.Calls;

namespace Microsoft.JScript.Runtime.Actions {

	public class SetMemberBinderHelper<T> : MemberBinderHelper<T, SetMemberAction> {
		public SetMemberBinderHelper (CodeContext context, SetMemberAction action, object[] args) : base (context, action, args)
		{
		}
		public StandardRule<T> MakeRule ()
		{
			throw new NotImplementedException ();
		}
		//TODO must have here internal thing here
	}
}
