using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.JScript.Compiler
{
	public class IdentifierTable
	{

		private Dictionary<string, Identifier> identifiers;
		public IdentifierTable ()
		{
			identifiers = new Dictionary<string, Identifier> ();
		}

		public Identifier InsertIdentifier (string Spelling)
		{
			Identifier result;
			if (!identifiers.TryGetValue(Spelling, out result)) {
				result = new Identifier (Spelling, this);
				identifiers.Add (Spelling, result);
			}
			return result;
		}

		public Identifier InsertIdentifier (char[] Text, int StartIndex, int Count)
		{
			return InsertIdentifier (Text.ToString ());
			//TODO : must have to do something to do with count and StartIndex
		}
				
		public int NextIdentifierID {
			get { return identifiers.Count; } 
		}

	}
}
