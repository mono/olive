using System;
using Microsoft.Scripting;
using Microsoft.Scripting.Actions;
using Microsoft.JScript.Runtime.Calls;

namespace Microsoft.JScript.Runtime.Actions {

	public class SetMemberBinderHelper<T> {
		public SetMemberBinderHelper (JSBinder binder, SetMemberAction action)
		{
			this.action = action;
			this.binder = binder;
		}
		private SetMemberAction action;
		private JSBinder binder;
		//TODO must have here internal thing here
	}
}
