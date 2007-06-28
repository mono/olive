using System;

namespace Microsoft.JScript.Runtime {

	[Flags]
	public enum JSPropertyAttributes {
		None,
		ReadOnly,
		DontEnum,
		DontDelete,
		Internal
	}
}
