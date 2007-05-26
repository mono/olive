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
		}

		private Statement ParseStatement ()
		{
			//TODO
			/*
		  block { $$ = $1; }
		| decl_var { $$ = $1; }
		| setvar { $$ = $1; }
		| if_else { $$ = $1; }
		| while { $$ = $1; }
		| do { $$ = $1; }
		| for { $$ = $1; }
		| continue { $$ = $1; }
		| with { $$ = $1; }
		| switch { $$ = $1; }
		| throw { $$ = $1; }
		| try { $$ = $1; }
		| proc_call { $$ = $1; }
		| return { $$ = $1; }
		| function_decl
		| inner_call
		| increment_or_decremente
		*/
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
