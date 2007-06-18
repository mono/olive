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
			This,
			False,
			True,
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
			New,
			Function,
			Delete,
			Void,
			Typeof,
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
			Instanceof,
			In,
			LessLess,
			GreaterGreater,
			GreaterGreaterGreater,
			Plus,
			Minus,
			Star,
			Divide,
			Percent,
			Question,
			Null
		}
	}
}
