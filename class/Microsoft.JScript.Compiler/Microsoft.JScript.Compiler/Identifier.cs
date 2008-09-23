//
// Microsoft.JScript.Compiler
//
// Author:
//   Olivier Dufour (olivier.duff@gmail.com)
//
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.JScript.Compiler.Tokens;

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
