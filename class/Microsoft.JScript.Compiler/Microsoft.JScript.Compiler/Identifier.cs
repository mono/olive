using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.JScript.Compiler
{
	public class Identifier : IComparable<Identifier>
	{
		public readonly Token.Type KeywordValue;
		public readonly string Spelling;
		private int identifierID;

		public Identifier (string Spelling, IdentifierTable IDTable) 
			: this(Spelling,Token.Type.Identifier,IDTable)
		{
		}

		public Identifier (string Spelling, Token.Type KeywordValue, IdentifierTable IDTable)
		{
			this.Spelling = Spelling;
			this.KeywordValue = KeywordValue;
			identifierID = IDTable.NextIdentifierID;
		}

		public int CompareTo (Identifier Other)
		{
			if (identifierID > Other.identifierID)
				return 1;
			else if (identifierID < Other.identifierID)
				return -1;
			else
				return 0;
		}
	}
}
