using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.JScript.Compiler
{
	public class IdentifierTable
	{
		public IdentifierTable ()
		{
			throw new NotImplementedException ();
		}

		public Identifier InsertIdentifier (string Spelling)
		{
			throw new NotImplementedException ();
		}

		public Identifier InsertIdentifier (char[] Text, int StartIndex, int Count)
		{
			throw new NotImplementedException ();
		}

		
		public int NextIdentifierID {
			get { throw new NotImplementedException (); } 
		}

	}
}
