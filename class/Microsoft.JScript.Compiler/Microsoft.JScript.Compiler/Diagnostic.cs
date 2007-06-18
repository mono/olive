using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.JScript.Compiler
{
	public class Diagnostic
	{
		public Diagnostic(DiagnosticCode Code, TextSpan Location)
		{
			this.Code = Code;
			this.Location = Location;
		}
		
		public readonly DiagnosticCode Code;
		public readonly TextSpan Location;
	}

 

}
