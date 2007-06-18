using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.JScript.Compiler
{
	public sealed class EngineOptions : Microsoft.Scripting.EngineOptions
	{
		public EngineOptions()
		{
		}
		
		//TODO Default value
		private int maximumRecursion;

		public int MaximumRecursion {
			get { return maximumRecursion; }
			set { maximumRecursion = value; }  
		}
	}

}
