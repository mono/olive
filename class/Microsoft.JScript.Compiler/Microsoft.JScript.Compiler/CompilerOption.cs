using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.JScript.Compiler
{
	public class CompilerOptions : Microsoft.Scripting.CompilerOptions
	{
		public CompilerOptions()
		{
		}

		public override object Clone()
		{
			return this.MemberwiseClone ();
		}
	}
}
