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
			return (diagnostics.Count > 0);
		}

		#endregion

		private FunctionStatement ParseFunctionDeclaration ()
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
					return ParseBlock ();
				case Token.Type.Var:
					return ParseVarDeclaration ();
				case Token.Type.If:
					return ParseIfElse ();
				case Token.Type.While:
					return ParseWhile ();
				case Token.Type.Do:
					return ParseDo ();
				case Token.Type.For:
					return ParseFor ();
				case Token.Type.Continue:
				case Token.Type.Break:
					return ParseBreakOrContinue ();
				case Token.Type.With:
					return ParseWith ();
				case Token.Type.Switch:
					return ParseSwitch ();
				case Token.Type.Try:
					return ParseTry ();
				case Token.Type.Throw:
				case Token.Type.Return:
					return ParseReturnOrThrow ();
				case Token.Type.Function:
					return ParseFunctionDeclaration ();
				case Token.Type.Identifier:
					IdentifierToken ident = current as IdentifierToken;
					Next ();
					return ParseExpressionStatement ();
				default:
					SyntaxError.Add("Statement start with a strange token :" + Enum.GetName(typeof(Token.Type), current.Kind));
					break;
			}
			//TODO
			return new Statement(Statement.Operation.Block, new TextSpan(0, 0, 0, 0, 0, 0));
			
		}

		private ExpressionStatement ParseExpressionStatement ()
		{
			Token start = current;
			Expression expr = ParseExpression();
			return new ExpressionStatement (expr, new TextSpan (start, current));
		}

		private VariableDeclarationStatement ParseVarDeclaration ()
		{
			Token start = current;
			List<VariableDeclarationListElement> declarations = new List<VariableDeclarationListElement>();
			do {
				Next ();
				CheckSyntaxExpected (Token.Type.Identifier);
				Identifier name = (current as IdentifierToken).Spelling;
				Next ();
				VariableDeclaration declaration;
				if (current.Kind == Token.Type.Equal) {
					Token start2 = current;
					Next ();
					Expression initializer = ParseExpression ();
					declaration = new InitializerVariableDeclaration (name, initializer, new TextSpan (start2, current), new TextPoint (start2.StartPosition));
					Next ();
				}
				else
					declaration = new VariableDeclaration (name, new TextSpan (current, current));

				VariableDeclarationListElement vardeclarListElt = new VariableDeclarationListElement (declaration, new TextPoint (current.StartPosition));
				declarations.Add (vardeclarListElt);
			} while (current.Kind == Token.Type.Comma);
			VariableDeclarationStatement statement = new VariableDeclarationStatement (declarations, new TextSpan (start, current));
			CheckSyntaxExpected (Token.Type.SemiColon);
			return statement;
		}

		private IfStatement ParseIfElse ()
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private WhileStatement ParseWhile ()
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private DoStatement ParseDo ()
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private ForStatement ParseFor ()
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private BreakOrContinueStatement ParseBreakOrContinue ()
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private WithStatement ParseWith ()
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private SwitchStatement ParseSwitch ()
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private ReturnOrThrowStatement ParseReturnOrThrow ()
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private TryStatement ParseTry ()
		{
			throw new Exception ("The method or operation is not implemented.");
		}
		/*
		ArgumentList.cs
		ArrayLiteralExpression.cs
		BinaryOperatorExpression.cs
		CaseClause.cs
		CatchClause.cs
		DeclarationForInStatement.cs
		DeclarationForStatement.cs
		DefaultCaseClause.cs
		ExpressionForInStatement.cs
		ExpressionForStatement.cs
		ExpressionListElement.cs
		FinallyClause.cs
		ForInStatement.cs
		FunctionDefinition.cs
		HexLiteralExpression.cs
		IdentifierExpression.cs
		InvocationExpression.cs
		LabelStatement.cs
		LoopStatement.cs
		NullExpression.cs
		NumericLiteralExpression.cs
		ObjectLiteralElement.cs
		ObjectLiteralExpression.cs
		OctalLiteralExpression.cs
		Parameter.cs
		QualifiedExpression.cs
		RegularExpressionLiteralExpression.cs
		StringLiteralExpression.cs
		SubscriptExpression.cs
		TernaryOperatorExpression.cs
		UnaryOperatorExpression.cs
		ValueCaseClause.cs
		VariableDeclaration.cs
		VariableDeclarationListElement.cs
		 */
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

		private Expression ParseGreaterGreater ()
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private Expression ParseStar ()
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private Expression ParseNew ()
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private Expression ParseMemberCall ()
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private Expression ParseLessLess ()
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private Expression ParsePercent ()
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private Expression ParseDivide ()
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private Expression ParseMinus ()
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private Expression ParseMinusMinus ()
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private Expression ParsePlus ()
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private Expression ParsePlusPlus ()
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private FunctionExpression ParseFunctionCall ()
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
			if (current.Kind == type)
				return;

			//default
			DiagnosticCode code = DiagnosticCode.SyntaxError;

			switch (type) {
				case Token.Type.Case:
				case Token.Type.Default:
					code = DiagnosticCode.CaseOrDefaultExpected;
					break;
				case Token.Type.Identifier:
					code = DiagnosticCode.IdentifierExpected;
					break;
				case Token.Type.LeftBrace:
					code = DiagnosticCode.LeftBraceExpected;
					break;
				case Token.Type.LeftParenthesis:
					code = DiagnosticCode.LeftParenExpected;
					break;
				case Token.Type.SemiColon:
					current.InsertSemicolonBefore ();
					return;
			}
				diagnostics.Add(new Diagnostic(code, new TextSpan(current.StartLine,current.StartColumn, lexer.Position.Line, lexer.Position.Column,current.StartPosition, lexer.Position.Index)));
		}

		private List<Diagnostic> diagnostics;

		public List<Diagnostic> Diagnostics { get {	return diagnostics;	} }
		/* TODO 
			SwitchHasMultipleDefaults,
			TryHasNoHandlers,
			BadDivideOrRegularExpressionLiteral,
			EnclosingLabelShadowed,
			NoEnclosingLabel,
			BreakContextInvalid,
			ContinueContextInvalid,
			ContinueLabelInvalid,
			MalformedEscapeSequence,
			HexLiteralNoDigits,
			MalformedNumericLiteral,
			NumericLiteralThenIdentifier,
			UnterminatedStringLiteral,
			UnterminatedComment,
			ExtraneousCharacter
		 */
	}
}
