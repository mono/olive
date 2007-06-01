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

		#region private fields

		private Tokenizer lexer;
		private Token current;
		private List<String> SyntaxError = new List<string>();
		private bool syntaxIncomplete = false;
		#endregion

		#region public methods

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
				
		public Expression ParseExpression (ref List<Comment> Comments)
		{
			Expression ex = ParseExpression();
			Comments = lexer.Comments;
			return ex;
		}

		public Statement ParseStatement (ref List<Comment> Comments)
		{
			Statement sta = ParseStatement ();
			Comments = lexer.Comments;
			return sta;
		}

		public bool SyntaxIncomplete ()
		{
			return syntaxIncomplete;
		}

		public bool SyntaxOK ()
		{
			return (SyntaxError.Count > 0);
		}

		#endregion

		private Statement ParseFunctionDeclaration()
		{
			Token start = current;

			Next ();
			CheckSyntaxExpected (Token.Type.Identifier);
			Identifier id = ((IdentifierToken)current).Spelling;
			TextPoint NameLocation = new TextPoint (this.current.StartPosition);

			Next ();
			CheckSyntaxExpected(Token.Type.LeftParenthesis);
			TextPoint leftParenLocation = new TextPoint(this.current.StartPosition);
			
			Next ();
			List<Parameter> parametters = ParseListParametter ();
			CheckSyntaxExpected (Token.Type.RightParenthesis);
			TextPoint rightParenLocation = new TextPoint (this.current.StartPosition);
			Token headerEnd = this.current;
			
			Next ();
			BlockStatement body = ParseBlock ();
			TextSpan location = new TextSpan (start,current);
			TextSpan HeaderLocation = new TextSpan (start,headerEnd);


			FunctionDefinition func = new FunctionDefinition(id,parametters,body,location,HeaderLocation,NameLocation,leftParenLocation,rightParenLocation);
			return new FunctionStatement (func);
		}
		
		private List<Parameter> ParseListParametter ()
		{
			List<Parameter> result = new List<Parameter>();
			if (current.Kind == Token.Type.RightParenthesis)
				return result;

			CheckSyntaxExpected (Token.Type.Identifier);
			Next ();
			TextPoint comma;
			while (current.Kind == Token.Type.Comma) {
				comma = new TextPoint (current.StartPosition);
				Next ();
				CheckSyntaxExpected (Token.Type.Identifier);
				result.Add (new Parameter ((current as IdentifierToken).Spelling, new TextSpan (current, current), comma));
				Next ();
			}
			return result;
		}

		private BlockStatement ParseBlock ()
		{
			Token start = current;
			DList<Statement,BlockStatement> children = new DList<Statement,BlockStatement>();

			CheckSyntaxExpected (Token.Type.LeftBrace);
			
			Next ();
			List<Statement> statements = ParseListStatement ();
			foreach (Statement statement in statements)
				children.Append (statement);
			CheckSyntaxExpected (Token.Type.RightBrace);
			return new BlockStatement (children, new TextSpan (start, current));
		}

		private List<Statement> ParseListStatement ()
		{
			List<Statement> result = new List<Statement>();
			while (current.Kind != Token.Type.RightBrace && current.Kind != Token.Type.EndOfInput) {
				result.Add(ParseStatement ());
			}
			return result;
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
				default:
					SyntaxError.Add("Statement start with a strange token :" + Enum.GetName(typeof(Token.Type), current.Kind));
					break;
			}
			//TODO
			return new Statement(Statement.Operation.Block, new TextSpan(0, 0, 0, 0, 0, 0));
			
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

		private Expression ParseExpression ()
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
				default:
					SyntaxError.Add("Statement start with a strange token :" + Enum.GetName(typeof(Token.Type), current.Kind));
					break;
			}
			//TODO
			return new Expression(Expression.Operation.Bang, new TextSpan(0, 0, 0, 0, 0, 0));
			
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


	}
}
