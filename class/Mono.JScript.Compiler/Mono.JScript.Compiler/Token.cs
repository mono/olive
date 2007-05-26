using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.JScript.Compiler
{
	public struct Token
	{
		/// <summary>
		/// Token types from ECMA-262
		/// </summary>
		public enum Type
		{
			EOF = 0,

			//Punctuator
			LeftBrace,// {
			RightBrace,// }
			LeftParenthesis,// (
			RightParenthesis,// )
			LeftBracket,// [
			RightBracket,// ]
			Dot,// .
			SemiColon,// ;
			Coma,// , 
			Less,// < 
			Greater,// > 
			LessEqual,// <=
			GreaterEqual,// >= 
			EqualEqual,// == 
			BangEqual,// != 
			EqualEqualEqual,// === 
			BangEqualEqual,// !==
			Plus,// + 
			Minus,// - 
			Star,// * 
			Percent,// % 
			PlusPlus,// ++ 
			MinusMinus,// --
			LessLess,// << 
			GreaterGreater,// >> 
			GreaterGreaterGreater,// >>> 
			And,// & 
			Bar,// | 
			Circumflex,// ^
			Bang,// ! 
			Tilda,// ~ 
			AndAnd,// && 
			BarBar,// || 
			Question,// ? 
			Colon,// :
			Equal,// = 
			PlusEqual,// += 
			MinusEqual,// -= 
			StarEqual,// *= 
			PercentEqual,// %= 
			LessLessEqual,// <<=
			GreaterGreaterEqual,// >>= 
			GreaterGreaterGreaterEqual,// >>>= 
			AndEqual,// &= 
			BarEqual,// |= 
			CircumflexEqual,// ^=
			Slash,// / 
			SlashEqual,// /=

			//Keywords
			Break,
			Else,
			New,
			Var,
			Case,
			Finally,
			Return,
			Void,
			Catch,
			For,
			Switch,
			While,
			Continue,
			Function,
			This,
			With,
			Default,
			If,
			Throw,
			Delete,
			In,
			Try,
			Do,
			Instanceof,
			Typeof,

			//FuturekeyWord
			Abstract,
			Enum,
			Int,
			Short,
			Boolean,
			Export,
			Interface,
			Static,
			Byte,
			Extends,
			Long,
			Super,
			Char,
			Final,
			Native,
			Synchronized,
			Class,
			Float,
			Package,
			Throws,
			Const,
			Goto,
			Private,
			Transient,
			Debugger,
			Implements,
			Protected,
			Volatile,
			Double,
			Import,
			Public,

			//literal
			Null,
			True,
			False,
			NumericLiteral,
			HexIntegerLiteral,
			StringLiteral,
			RegularExpressionLiteral,

			Identifier,

			Error
		}

		public Token(Token.Type Kind, int StartPosition, int StartLine, int StartColumn, bool FirstOnLine)
		{
			this.Kind = Kind;
			this.StartPosition = StartPosition;
			this.StartLine = StartLine;
			this.StartColumn = StartColumn;
			this.firstOnLine = FirstOnLine;
		}

		public readonly Token.Type Kind;
		public readonly int StartColumn;
		public readonly int StartLine;
		public readonly int StartPosition;
		private bool firstOnLine;

		public bool FirstOnLine
		{
			get { return firstOnLine; }
		}
		public Token this[Tokenizer InputStream]
		{
			get { return InputStream.GetNext(); }
		}

	}
}
