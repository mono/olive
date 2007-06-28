using System;
using Microsoft.Scripting;

namespace Microsoft.JScript.Runtime {

	public class JSAttributedProperty {

		object value;
		JSPropertyAttributes attr;

		public JSAttributedProperty (object setValue, JSPropertyAttributes setAttributes)
		{
			this.value = setValue;
			this.attr = setAttributes;
		}

		public JSPropertyAttributes Attributes {
			get { return attr;  }
		}

		public bool IsDontDelete {
			get { return (attr & JSPropertyAttributes.DontDelete) != 0; }
		}

		public bool IsDontEnum {
			get { return (attr & JSPropertyAttributes.DontEnum) != 0; }
		}

		public bool IsInternal {
			get { return (attr & JSPropertyAttributes.Internal) != 0; }
		}

		public bool IsReadOnly {
			get { return (attr & JSPropertyAttributes.ReadOnly) != 0; }
		}

		public object Value {
			get { return this.@value; }
		}
	}
}
