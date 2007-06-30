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

namespace Microsoft.JScript.Compiler.ParseTree
{
	public class Expression
	{
		public readonly TextSpan Location;
		public readonly Operation Opcode;

		public Expression (Operation Opcode, TextSpan Location)
		{
			this.Opcode = Opcode;
			this.Location = Location;
		}

		public enum Operation
		{
			SyntaxError,
			@this,
			@false,
			@true,
			Identifier,
			NumericLiteral,
			HexLiteral,
			OctalLiteral,
			RegularExpressionLiteral,
			StringLiteral,
			ArrayLiteral,
			ObjectLiteral,
			Parenthesized,
			Invocation,
			Subscript,
			Qualified,
			@new,
			Function,
			delete,
			@void,
			@typeof,
			PrefixPlusPlus,
			PrefixMinusMinus,
			PrefixPlus,
			PrefixMinus,
			Tilda,
			Bang,
			PostfixPlusPlus,
			PostfixMinusMinus,
			Comma,
			Equal,
			StarEqual,
			DivideEqual,
			PercentEqual,
			PlusEqual,
			MinusEqual,
			LessLessEqual,
			GreaterGreaterEqual,
			GreaterGreaterGreaterEqual,
			AmpersandEqual,
			CircumflexEqual,
			BarEqual,
			BarBar,
			AmpersandAmpersand,
			Bar,
			Circumflex,
			Ampersand,
			EqualEqual,
			BangEqual,
			EqualEqualEqual,
			BangEqualEqual,
			Less,
			Greater,
			LessEqual,
			GreaterEqual,
			instanceof,
			@in,
			LessLess,
			GreaterGreater,
			GreaterGreaterGreater,
			Plus,
			Minus,
			Star,
			Divide,
			Percent,
			Question,
			@null
		}
	}
}
