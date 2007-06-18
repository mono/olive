using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.JScript.Compiler
{
	public class Comment
	{

		public Comment (string Spelling, TextSpan Location)
		{
			this.spelling = Spelling;
			this.location = Location;
		}

		private TextSpan location;
		private string spelling;

		public TextSpan Location {
			get { return location; } 
		}

		public string Spelling {
			get { return spelling; } 
		}

	}
}
