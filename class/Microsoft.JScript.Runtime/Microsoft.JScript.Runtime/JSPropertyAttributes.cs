using System;

namespace Microsoft.JScript.Runtime {

	[Serializable]
	[Flags]
	public enum JSPropertyAttributes {
		None,
		ReadOnly,
		DontEnum,
		DontDelete,
		Internal
	}
}
