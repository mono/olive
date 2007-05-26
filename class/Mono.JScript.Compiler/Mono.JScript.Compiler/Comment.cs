using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.JScript.Compiler
{
	public class Comment
	{
		public Comment (string Spelling, TextSpan Location)
		{
		}

		public TextSpan Location {
			get { throw new NotImplementedException (); } 
		}

		public string Spelling {
			get { throw new NotImplementedException (); } 
		}

	}
}
