using System;

namespace Microsoft.JScript.Runtime {

	[Flags]
	public enum JSPropertyAttributes {
		None = 0,
		ReadOnly = 1,
		DontEnum = 2,
		DontDelete = 4,
		Internal = 8
	}
}
