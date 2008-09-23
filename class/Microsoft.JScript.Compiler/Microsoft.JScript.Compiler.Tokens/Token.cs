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

namespace Microsoft.JScript.Compiler
{
	public class Token
	{
		/// <summary>
		/// Token types from ECMA-262
		/// </summary>
		public enum Type
		{
			None = 0,
			EndOfInput = 1,

			//Punctuator
			LeftBrace,// {
			RightBrace,// }
			LeftParenthesis,// (
			RightParenthesis,// )
			LeftBracket,// [
			RightBracket,// ]
			Dot,// .
			Semicolon,// ;
			Comma,// , 
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
			Ampersand,// & 
			Bar,// | 
			Circumflex,// ^
			Bang,// ! 
			Tilda,// ~ 
			AmpersandAmpersand,// && 
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
			AmpersandEqual,// &= 
			BarEqual,// |= 
			CircumflexEqual,// ^=
			Divide,// / 
			DivideEqual,// /=

			//Keywords
			@break,
			@else,
			@new,
			var,
			@case,
			@finally,
			@return,
			@void,
			@catch,
			@for,
			@switch,
			@while,
			@continue,
			function,
			@this,
			with,
			@default,
			@if,
			@throw,
			delete,
			@in,
			@try,
			@do,
			instanceof,
			@typeof,

			//FuturekeyWord
			@abstract,
			@enum,
			@int,
			@short,
			boolean,
			export,
			@interface,
			@static,
			@byte,
			extends,
			@long,
			super,
			@char,
			final,
			native,
			synchronized,
			@class,
			@float,
			packate,
			throws,
			@const,
			@goto,
			@private,
			transient,
			debugger,
			implements,
			@protected,
			@volatile,
			@double,
			import,
			@public,

			//literal
			@null,
			@true,
			@false,
			NumericLiteral,
			HexIntegerLiteral,
			OctalIntegerLiteral,
			StringLiteral,
			RegularExpressionLiteral,

			Identifier,

			Bad,
			Comment
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
		private Token next = null;

		public Token InsertSemicolonBefore()
		{
			Token semicolon = new Token (Token.Type.Semicolon, StartPosition, StartLine, StartColumn, false);
			semicolon.next = this;
			return semicolon;
		}

		//by default 1 must be change in inherited token which differ
		public virtual int Width {
			get { return 1; }
		}

		public bool FirstOnLine
		{
			get { return firstOnLine; }
		}
		public Token this[Tokenizer InputStream]
		{
			get { 
				if (next == null)
					return InputStream.GetNext(); 
				return next;
			}
		}

	}
}
