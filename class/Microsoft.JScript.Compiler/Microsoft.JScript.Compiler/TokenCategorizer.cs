using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Scripting.Hosting;
using Microsoft.Scripting;

namespace Mono.JScript.Compiler
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

		//TODO
		private TokenCategory GetCategory(Token.Type type)
		{
			switch (type) {				
				case Token.Type.None:					
				case Token.Type.EndOfInput:					
				case Token.Type.LeftBrace:					
				case Token.Type.RightBrace:					
				case Token.Type.LeftParenthesis:					
				case Token.Type.RightParenthesis:					
				case Token.Type.LeftBracket:					
				case Token.Type.RightBracket:					
				case Token.Type.Dot:					
				case Token.Type.SemiColon:					
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
				case Token.Type.Break:					
				case Token.Type.Else:					
				case Token.Type.New:					
				case Token.Type.Var:					
				case Token.Type.Case:					
				case Token.Type.Finally:					
				case Token.Type.Return:					
				case Token.Type.Void:					
				case Token.Type.Catch:					
				case Token.Type.For:					
				case Token.Type.Switch:					
				case Token.Type.While:					
				case Token.Type.Continue:					
				case Token.Type.Function:					
				case Token.Type.This:					
				case Token.Type.With:					
				case Token.Type.Default:					
				case Token.Type.If:					
				case Token.Type.Throw:					
				case Token.Type.Delete:					
				case Token.Type.In:					
				case Token.Type.Try:					
				case Token.Type.Do:					
				case Token.Type.Instanceof:					
				case Token.Type.Typeof:					
				case Token.Type.Abstract:					
				case Token.Type.Enum:					
				case Token.Type.Int:					
				case Token.Type.Short:					
				case Token.Type.Boolean:					
				case Token.Type.Export:					
				case Token.Type.Interface:					
				case Token.Type.Static:					
				case Token.Type.Byte:					
				case Token.Type.Extends:					
				case Token.Type.Long:					
				case Token.Type.Super:					
				case Token.Type.Char:					
				case Token.Type.Final:					
				case Token.Type.Native:					
				case Token.Type.Synchronized:					
				case Token.Type.Class:					
				case Token.Type.Float:					
				case Token.Type.Package:					
				case Token.Type.Throws:					
				case Token.Type.Const:					
				case Token.Type.Goto:					
				case Token.Type.Private:					
				case Token.Type.Transient:					
				case Token.Type.Debugger:					
				case Token.Type.Implements:					
				case Token.Type.Protected:					
				case Token.Type.Volatile:					
				case Token.Type.Double:					
				case Token.Type.Import:					
				case Token.Type.Public:					
				case Token.Type.Null:					
				case Token.Type.True:					
				case Token.Type.False:					
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
			return TokenCategory.Comment;
		}

		//TODO
		private TokenTriggers GetTrigger(Token.Type type)
		{
			switch (type) {
				case Token.Type.Abstract:
				case Token.Type.None:
				case Token.Type.EndOfInput:
				case Token.Type.LeftBrace:
				case Token.Type.RightBrace:
				case Token.Type.LeftParenthesis:
				case Token.Type.RightParenthesis:
				case Token.Type.LeftBracket:
				case Token.Type.RightBracket:
				case Token.Type.Dot:
				case Token.Type.SemiColon:
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
				case Token.Type.Break:
				case Token.Type.Else:
				case Token.Type.New:
				case Token.Type.Var:
				case Token.Type.Case:
				case Token.Type.Finally:
				case Token.Type.Return:
				case Token.Type.Void:
				case Token.Type.Catch:
				case Token.Type.For:
				case Token.Type.Switch:
				case Token.Type.While:
				case Token.Type.Continue:
				case Token.Type.Function:
				case Token.Type.This:
				case Token.Type.With:
				case Token.Type.Default:
				case Token.Type.If:
				case Token.Type.Throw:
				case Token.Type.Delete:
				case Token.Type.In:
				case Token.Type.Try:
				case Token.Type.Do:
				case Token.Type.Instanceof:
				case Token.Type.Typeof:
				case Token.Type.Enum:
				case Token.Type.Int:
				case Token.Type.Short:
				case Token.Type.Boolean:
				case Token.Type.Export:
				case Token.Type.Interface:
				case Token.Type.Static:
				case Token.Type.Byte:
				case Token.Type.Extends:
				case Token.Type.Long:
				case Token.Type.Super:
				case Token.Type.Char:
				case Token.Type.Final:
				case Token.Type.Native:
				case Token.Type.Synchronized:
				case Token.Type.Class:
				case Token.Type.Float:
				case Token.Type.Package:
				case Token.Type.Throws:
				case Token.Type.Const:
				case Token.Type.Goto:
				case Token.Type.Private:
				case Token.Type.Transient:
				case Token.Type.Debugger:
				case Token.Type.Implements:
				case Token.Type.Protected:
				case Token.Type.Volatile:
				case Token.Type.Double:
				case Token.Type.Import:
				case Token.Type.Public:
				case Token.Type.Null:
				case Token.Type.True:
				case Token.Type.False:
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
			return TokenTriggers.MatchBraces;
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

		//TO check with test
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
