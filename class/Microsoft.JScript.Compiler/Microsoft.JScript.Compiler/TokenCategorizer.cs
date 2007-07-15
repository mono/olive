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
using Microsoft.Scripting.Hosting;
using Microsoft.Scripting;

namespace Microsoft.JScript.Compiler
{
	public class TokenCategorizer : Microsoft.Scripting.Hosting.TokenCategorizer
	{
		public TokenCategorizer()
		{
		}

		private Tokenizer tokenizer;
		private object state;
		private ErrorSink errorSink;

		public override void Initialize(object state, SourceUnitReader sourceReader, SourceLocation initialLocation)
		{
			Tokenizer tokenizer = new Tokenizer (sourceReader.ReadToEnd ().ToCharArray (), new IdentifierTable ());
			tokenizer.Position = initialLocation;
			this.state = state;
			errorSink = new ErrorSink ();
		}

		public override TokenInfo ReadToken()
		{
			Token token = tokenizer.GetNext ();
			SourceLocation location = new SourceLocation(token.StartPosition,token.StartLine,token.StartColumn);
			SourceSpan span = new SourceSpan (location, tokenizer.Position);
			TokenTriggers trigger = GetTrigger(token.Kind);
			TokenCategory category = GetCategory (token.Kind);
			return new TokenInfo (span, category, trigger);
		}

		[MonoTODO]
		private TokenCategory GetCategory(Token.Type type)
		{
			throw new NotImplementedException ();
			/*switch (type) {				
				case Token.Type.None:					
				case Token.Type.EndOfInput:					
				case Token.Type.LeftBrace:					
				case Token.Type.RightBrace:					
				case Token.Type.LeftParenthesis:					
				case Token.Type.RightParenthesis:					
				case Token.Type.LeftBracket:					
				case Token.Type.RightBracket:					
				case Token.Type.Dot:					
				case Token.Type.Semicolon:					
				case Token.Type.Comma:					
				case Token.Type.Less:					
				case Token.Type.Greater:					
				case Token.Type.LessEqual:					
				case Token.Type.GreaterEqual:					
				case Token.Type.EqualEqual:					
				case Token.Type.BangEqual:					
				case Token.Type.EqualEqualEqual:					
				case Token.Type.BangEqualEqual:					
				case Token.Type.Plus:					
				case Token.Type.Minus:					
				case Token.Type.Star:					
				case Token.Type.Percent:					
				case Token.Type.PlusPlus:					
				case Token.Type.MinusMinus:					
				case Token.Type.LessLess:					
				case Token.Type.GreaterGreater:					
				case Token.Type.GreaterGreaterGreater:					
				case Token.Type.Ampersand:					
				case Token.Type.Bar:					
				case Token.Type.Circumflex:					
				case Token.Type.Bang:					
				case Token.Type.Tilda:					
				case Token.Type.AmpersandAmpersand:					
				case Token.Type.BarBar:					
				case Token.Type.Question:					
				case Token.Type.Colon:					
				case Token.Type.Equal:					
				case Token.Type.PlusEqual:					
				case Token.Type.MinusEqual:					
				case Token.Type.StarEqual:					
				case Token.Type.PercentEqual:					
				case Token.Type.LessLessEqual:					
				case Token.Type.GreaterGreaterEqual:					
				case Token.Type.GreaterGreaterGreaterEqual:					
				case Token.Type.AmpersandEqual:					
				case Token.Type.BarEqual:					
				case Token.Type.CircumflexEqual:					
				case Token.Type.Divide:					
				case Token.Type.DivideEqual:
				case Token.Type.@break:
				case Token.Type.@else:
				case Token.Type.@new:					
				case Token.Type.var:					
				case Token.Type.@case:					
				case Token.Type.@finally:					
				case Token.Type.@return:					
				case Token.Type.@void:					
				case Token.Type.@catch:					
				case Token.Type.@for:					
				case Token.Type.@switch:					
				case Token.Type.@while:					
				case Token.Type.@continue:					
				case Token.Type.function:					
				case Token.Type.@this:					
				case Token.Type.with:					
				case Token.Type.@default:					
				case Token.Type.@if:					
				case Token.Type.@throw:					
				case Token.Type.delete:					
				case Token.Type.@in:					
				case Token.Type.@try:					
				case Token.Type.@do:					
				case Token.Type.instanceof:					
				case Token.Type.@typeof:					
				case Token.Type.@abstract:					
				case Token.Type.@enum:					
				case Token.Type.@int:					
				case Token.Type.@short:					
				case Token.Type.boolean:					
				case Token.Type.export:					
				case Token.Type.@interface:					
				case Token.Type.@static:					
				case Token.Type.@byte:					
				case Token.Type.extends:					
				case Token.Type.@long:					
				case Token.Type.super:					
				case Token.Type.@char:					
				case Token.Type.final:					
				case Token.Type.native:					
				case Token.Type.synchronized:					
				case Token.Type.@class:					
				case Token.Type.@float:					
				case Token.Type.packate:					
				case Token.Type.throws:					
				case Token.Type.@const:					
				case Token.Type.@goto:					
				case Token.Type.@private:					
				case Token.Type.transient:					
				case Token.Type.debugger:					
				case Token.Type.implements:					
				case Token.Type.@protected:					
				case Token.Type.@volatile:					
				case Token.Type.@double:					
				case Token.Type.import:					
				case Token.Type.@public:					
				case Token.Type.@null:					
				case Token.Type.@true:					
				case Token.Type.@false:					
				case Token.Type.NumericLiteral:					
				case Token.Type.HexIntegerLiteral:					
				case Token.Type.OctalIntegerLiteral:					
				case Token.Type.StringLiteral:					
				case Token.Type.RegularExpressionLiteral:					
				case Token.Type.Identifier:					
				case Token.Type.Bad:					
				case Token.Type.Comment:
					return TokenCategory.Comment;
			}
			return TokenCategory.Comment;*/
		}

		[MonoTODO]
		private TokenTriggers GetTrigger(Token.Type type)
		{
			throw new NotImplementedException ();
			/*switch (type) {
				case Token.Type.None:
				case Token.Type.EndOfInput:
				case Token.Type.LeftBrace:
				case Token.Type.RightBrace:
				case Token.Type.LeftParenthesis:
				case Token.Type.RightParenthesis:
				case Token.Type.LeftBracket:
				case Token.Type.RightBracket:
				case Token.Type.Dot:
				case Token.Type.Semicolon:
				case Token.Type.Comma:
				case Token.Type.Less:
				case Token.Type.Greater:
				case Token.Type.LessEqual:
				case Token.Type.GreaterEqual:
				case Token.Type.EqualEqual:
				case Token.Type.BangEqual:
				case Token.Type.EqualEqualEqual:
				case Token.Type.BangEqualEqual:
				case Token.Type.Plus:
				case Token.Type.Minus:
				case Token.Type.Star:
				case Token.Type.Percent:
				case Token.Type.PlusPlus:
				case Token.Type.MinusMinus:
				case Token.Type.LessLess:
				case Token.Type.GreaterGreater:
				case Token.Type.GreaterGreaterGreater:
				case Token.Type.Ampersand:
				case Token.Type.Bar:
				case Token.Type.Circumflex:
				case Token.Type.Bang:
				case Token.Type.Tilda:
				case Token.Type.AmpersandAmpersand:
				case Token.Type.BarBar:
				case Token.Type.Question:
				case Token.Type.Colon:
				case Token.Type.Equal:
				case Token.Type.PlusEqual:
				case Token.Type.MinusEqual:
				case Token.Type.StarEqual:
				case Token.Type.PercentEqual:
				case Token.Type.LessLessEqual:
				case Token.Type.GreaterGreaterEqual:
				case Token.Type.GreaterGreaterGreaterEqual:
				case Token.Type.AmpersandEqual:
				case Token.Type.BarEqual:
				case Token.Type.CircumflexEqual:
				case Token.Type.Divide:
				case Token.Type.DivideEqual:
				case Token.Type.@break:
				case Token.Type.@else:
				case Token.Type.@new:
				case Token.Type.var:
				case Token.Type.@case:
				case Token.Type.@finally:
				case Token.Type.@return:
				case Token.Type.@void:
				case Token.Type.@catch:
				case Token.Type.@for:
				case Token.Type.@switch:
				case Token.Type.@while:
				case Token.Type.@continue:
				case Token.Type.function:
				case Token.Type.@this:
				case Token.Type.with:
				case Token.Type.@default:
				case Token.Type.@if:
				case Token.Type.@throw:
				case Token.Type.delete:
				case Token.Type.@in:
				case Token.Type.@try:
				case Token.Type.@do:
				case Token.Type.instanceof:
				case Token.Type.@typeof:
				case Token.Type.@abstract:
				case Token.Type.@enum:
				case Token.Type.@int:
				case Token.Type.@short:
				case Token.Type.boolean:
				case Token.Type.export:
				case Token.Type.@interface:
				case Token.Type.@static:
				case Token.Type.@byte:
				case Token.Type.extends:
				case Token.Type.@long:
				case Token.Type.super:
				case Token.Type.@char:
				case Token.Type.final:
				case Token.Type.native:
				case Token.Type.synchronized:
				case Token.Type.@class:
				case Token.Type.@float:
				case Token.Type.packate:
				case Token.Type.throws:
				case Token.Type.@const:
				case Token.Type.@goto:
				case Token.Type.@private:
				case Token.Type.transient:
				case Token.Type.debugger:
				case Token.Type.implements:
				case Token.Type.@protected:
				case Token.Type.@volatile:
				case Token.Type.@double:
				case Token.Type.import:
				case Token.Type.@public:
				case Token.Type.@null:
				case Token.Type.@true:
				case Token.Type.@false:
				case Token.Type.NumericLiteral:
				case Token.Type.HexIntegerLiteral:
				case Token.Type.OctalIntegerLiteral:
				case Token.Type.StringLiteral:
				case Token.Type.RegularExpressionLiteral:
				case Token.Type.Identifier:
				case Token.Type.Bad:
				case Token.Type.Comment:
					return TokenTriggers.MatchBraces;
			}
			return TokenTriggers.MatchBraces;*/
		}

		public override IEnumerable<TokenInfo> ReadTokens(int countOfChars)
		{
			List<TokenInfo> list = new List<TokenInfo> (countOfChars);
			for (int i = 0; i < countOfChars; i++)
				list.Add(ReadToken ());
			return list;
		}

		public override bool SkipToken()
		{
			Token token = tokenizer.GetNext ();
			return (token.Kind != Token.Type.EndOfInput && token.Kind != Token.Type.Bad);
		}

		public override SourceLocation CurrentPosition {
			get { return tokenizer.Position; }
		}

		public override object CurrentState {
			get { return state; }
		}

		public override ErrorSink ErrorSink {
			get { return errorSink; }
			set { errorSink = value; }
		}

		public override bool IsRestartable {
			get { return false; }
		}

	}

 

}
