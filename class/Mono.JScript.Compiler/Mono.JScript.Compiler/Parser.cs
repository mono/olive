using System;
using System.Collections.Generic;
using System.Text;
using Mono.JScript.Compiler.ParseTree;

namespace Mono.JScript.Compiler
{
	public class Parser
	{
		public Parser (char[] Input) : this(Input,new IdentifierTable())
		{
		}

		public Parser (char[] Input, IdentifierTable IDTable)
		{
			lexer = new Tokenizer (Input, IDTable);
		}

		private Tokenizer lexer;
		private Token current;
		private List<String> SyntaxError = new List<string>();
		private bool syntaxIncomplete = false;

		public DList<Statement, BlockStatement> ParseProgram (ref List<Comment> Comments)
		{
			DList<Statement, BlockStatement> result = new DList<Statement, BlockStatement> ();
			
			while (current.Kind != Token.Type.EndOfInput) {
				Next ();
				if (current.Kind == Token.Type.Function)
					result.Append (ParseFunctionDeclaration ());
				else
					result.Append (ParseStatement ());
			}
			Comments = lexer.Comments;
			return result;
		}

		public Statement ParseFunctionDeclaration()
		{
			Token start = current;
			Next ();
			CheckSyntaxExpected (Token.Type.Identifier);
			Next ();
			CheckSyntaxExpected(Token.Type.LeftParenthesis);
			Next ();
			ParseListParametter ();
			CheckSyntaxExpected (Token.Type.RightParenthesis);
			Next ();
			ParseBlock ();
			return new Statement (Statement.Operation.Function, new TextSpan (start.StartLine,start.StartColumn,lexer.Position.Line,lexer.Position.Column, start.StartPosition,lexer.Position.Index));
		}

		private void ParseListParametter ()
		{
			CheckSyntaxExpected (Token.Type.Identifier);
			Next ();
			while (current.Kind == Token.Type.Coma) {
				Next ();
				CheckSyntaxExpected (Token.Type.Identifier);
				Next ();
			}
		}

		private void ParseBlock ()
		{
			CheckSyntaxExpected (Token.Type.LeftBrace);
			Next ();
			ParseListStatement ();
			CheckSyntaxExpected (Token.Type.RightBrace);
		}

		private void ParseListStatement ()
		{
			while (current.Kind != Token.Type.RightBrace && current.Kind != Token.Type.EndOfInput) {
				ParseStatement ();
			}
		}

		public Expression ParseExpression (ref List<Comment> Comments)
		{
			throw new NotImplementedException ();
		}

		public Statement ParseStatement (ref List<Comment> Comments)
		{
			return ParseStatement ();
			Comments = lexer.Comments;
		}

		private Statement ParseStatement ()
		{
			switch (current.Kind) {
				case Token.Type.LeftBrace:
					ParseBlock ();
					break;
				case Token.Type.Var:
					ParseVarDeclaration ();
					break;
				case Token.Type.If:
					ParseIfElse ();
					break;
				case Token.Type.While:
					ParseWhile ();
					break;
				case Token.Type.Do:
					ParseDo ();
					break;
				case Token.Type.For:
					ParseFor ();
					break;
				case Token.Type.Continue:
					ParseContinue ();
					break;
				case Token.Type.With:
					ParseWith ();
					break;
				case Token.Type.Switch:
					ParseSwitch ();
					break;
				case Token.Type.Throw:
					ParseThrow ();
					break;
				case Token.Type.Try:
					ParseTry ();
					break;
				case Token.Type.Break:
					ParseBreak ();
					break;
				case Token.Type.Return:
					ParseReturn ();
					break;
				case Token.Type.Function:
					ParseFunctionDeclaration ();
					break;
				case Token.Type.Identifier:
					Token ident = current;
					Next ();
					ParseExpression ();
					break;
			}
			//TODO
			/*
		| proc_call { $$ = $1; }
		| inner_call
		| increment_or_decremente
		*/
			throw new Exception ("The method or operation is not implemented.");
		}

		private void ParseVarDeclaration ()
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private void ParseIfElse ()
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private void ParseWhile ()
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private void ParseDo ()
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private void ParseFor ()
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private void ParseContinue ()
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private void ParseWith ()
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private void ParseSwitch ()
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private void ParseThrow ()
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private void ParseTry ()
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private void ParseReturn ()
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private void ParseBreak ()
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private void ParseExpression ()
		{
			switch (current.Kind) {
				case Token.Type.Equal:
					ParseSetVar ();
					break;
				case Token.Type.LeftParenthesis:
					ParseFunctionCall ();
					break;
				case Token.Type.PlusPlus:
					ParsePlusPlus ();
					break;
				case Token.Type.MinusMinus:
					ParseMinusMinus ();
					break;
				case Token.Type.Plus:
					ParsePlus ();
					break;
				case Token.Type.Star:
					ParseStar ();
					break;
				case Token.Type.Minus:
					ParseMinus ();
					break;
				case Token.Type.Divide:
					ParseDivide ();
					break;
				case Token.Type.Percent:
					ParsePercent ();
					break;
				case Token.Type.LessLess:
					ParseLessLess ();
					break;
				case Token.Type.GreaterGreater:
					ParseGreaterGreater ();
					break;
				case Token.Type.Dot:
					ParseMemberCall ();
					break;
				case Token.Type.New:
					ParseNew ();
					break;
			}
		}

		private void ParseGreaterGreater ()
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private void ParseStar ()
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private void ParseNew ()
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private void ParseMemberCall ()
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private void ParseLessLess ()
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private void ParsePercent ()
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private void ParseDivide ()
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private void ParseMinus ()
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private void ParseMinusMinus ()
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private void ParsePlus ()
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private void ParsePlusPlus ()
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private void ParseFunctionCall ()
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private void ParseSetVar ()
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private void Next ()
		{
			current = lexer.GetNext ();
		}
		private void CheckSyntaxExpected (Token.Type type)
		{
			if (current.Kind != type)
				SyntaxError.Add (Enum.GetName (typeof(Token.Type), type) + " expected.");
		}

		public bool SyntaxIncomplete ()
		{
			return syntaxIncomplete;
		}

		public bool SyntaxOK ()
		{
			return (SyntaxError.Count > 0);
		}

	}
}
