using System;
using System.Collections.Generic;
using System.Text;
using Mono.JScript.Compiler.ParseTree;

namespace Mono.JScript.Compiler
{
	public class Parser
	{
		public Parser (char[] Input)
			: this (Input, new IdentifierTable ())
		{
		}

		public Parser (char[] Input, IdentifierTable IDTable)
		{
			lexer = new Tokenizer (Input, IDTable);
			diagnostics = new List<Diagnostic> ();
			Next (); // innit on first token 
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
			return diagnostics.Count == 0;
		}

		#endregion

		#region private methods

		#region statements

		private FunctionStatement ParseFunctionDeclaration ()
		{
			return new FunctionStatement (ParseFunctionDefinition());
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
			BlockStatement block = new BlockStatement (children, new TextSpan (start, current));
			children.Parent = block;
			return block;
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
			Token start = current;
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
					return ParseThrow ();
				case Token.Type.Return:
					return ParseReturn ();
				case Token.Type.Function:
					return ParseFunctionDeclaration ();
				case Token.Type.Identifier:
					return ParseExpressionStatement ();
				default:
					SyntaxError.Add("Statement start with a strange token :" + Enum.GetName(typeof(Token.Type), current.Kind));
					break;
			}
			return new Statement(Statement.Operation.Block, new TextSpan(start,current));
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
			Token start = current;
			Next ();
			CheckSyntaxExpected (Token.Type.LeftParenthesis);
			Token leftParen = current;
			Expression condition = ParseExpression ();
			CheckSyntaxExpected (Token.Type.RightParenthesis);
			Token rightParen = current;
			Statement ifBody = ParseStatement ();
			Statement elseBody = null;
			TextPoint elsePoint = new TextPoint();
			if (current.Kind == Token.Type.Else) {
				elsePoint = new TextPoint(current.StartPosition);
				elseBody = ParseStatement ();
			}
			return new IfStatement (condition, ifBody, elseBody, new TextSpan (start, current), new TextSpan (start, rightParen), new TextPoint (leftParen.StartPosition), new TextPoint (rightParen.StartPosition), elsePoint);
		}

		private WhileStatement ParseWhile ()
		{
			Token start = current;
			Next ();
			CheckSyntaxExpected (Token.Type.LeftParenthesis);
			Token leftParen = current;
			Expression condition = ParseExpression ();
			CheckSyntaxExpected (Token.Type.RightParenthesis);
			Token rightParen = current;
			Statement body = ParseStatement ();
			return new WhileStatement (condition, body, new TextSpan (start, current), new TextSpan (start, rightParen), new TextPoint (leftParen.StartPosition), new TextPoint (rightParen.StartPosition));
		}

		private DoStatement ParseDo ()
		{
			Token start = current;
			Next ();
			Statement body = ParseStatement ();
			Next ();
			CheckSyntaxExpected (Token.Type.While);
			Token whileToken = current;
			Next ();
			CheckSyntaxExpected (Token.Type.LeftParenthesis);
			Token leftParen = current;
			Expression condition = ParseExpression ();
			CheckSyntaxExpected (Token.Type.RightParenthesis);
			Token rightParen = current;
			Next ();
			CheckSyntaxExpected (Token.Type.SemiColon);
			return new DoStatement (body, condition, new TextSpan (start, current), new TextSpan (start, start), new TextPoint (whileToken.StartPosition), new TextPoint (leftParen.StartPosition), new TextPoint (rightParen.StartPosition));
		}

		//TODO: use sub function to slim this one
		private LoopStatement ParseFor ()
		{
			Token start = current;
			Token firstSemiColon;
			Expression condition;
			Token secondSemiColon;
			Expression increment;
			Token rightParen;
			Statement body;
			Next ();
			CheckSyntaxExpected (Token.Type.LeftParenthesis);
			Token leftParen = current;
			Next();

			if (current.Kind == Token.Type.Var) {
				VariableDeclarationStatement varDecl = ParseVarDeclaration ();

				if (current.Kind == Token.Type.In) {
					//DeclarationForInStatement
					Token inToken = current;
					Next ();
					Expression collection = ParseExpression ();
					CheckSyntaxExpected (Token.Type.RightParenthesis);
					rightParen = current;
					Next ();
					body = ParseStatement ();
					VariableDeclaration item;
					if (varDecl.Declarations.Count == 1) {
						item = varDecl.Declarations[0].Declaration;
					} else {
						item = null;
						Error (DiagnosticCode.SyntaxError, new TextSpan (start, current));
					}
					return new DeclarationForInStatement (item, collection, body, new TextSpan (start, current),
						new TextSpan (start, rightParen), new TextPoint (inToken.StartPosition),
						new TextPoint (leftParen.StartPosition), new TextPoint (rightParen.StartPosition));
				} else {
					CheckSyntaxExpected (Token.Type.SemiColon);
					firstSemiColon = current;
					Next ();
					condition = ParseExpression ();
					CheckSyntaxExpected (Token.Type.SemiColon);
					secondSemiColon = current;
					Next ();
					increment = ParseExpression ();
					CheckSyntaxExpected (Token.Type.RightParenthesis);
					rightParen = current;
					Next ();
					body = ParseStatement ();
					return new DeclarationForStatement (varDecl.Declarations, condition, increment, body,
						new TextSpan (start, current), new TextSpan (start, rightParen),
						new TextPoint (firstSemiColon.StartPosition),
						new TextPoint (secondSemiColon.StartPosition),
						new TextPoint (leftParen.StartPosition), new TextPoint (rightParen.StartPosition));
				}

				CheckSyntaxExpected (Token.Type.SemiColon);
				firstSemiColon = current;
				Next ();
				condition = ParseExpression ();
				CheckSyntaxExpected (Token.Type.SemiColon);
				secondSemiColon = current;
				Next ();
				increment = ParseExpression ();
				CheckSyntaxExpected (Token.Type.RightParenthesis);
				rightParen = current;
				Next ();
				body = ParseStatement ();
				return new DeclarationForStatement (varDecl.Declarations, condition, increment, body,
					new TextSpan (start, current), new TextSpan (start, rightParen),
					new TextPoint (firstSemiColon.StartPosition),
					new TextPoint (secondSemiColon.StartPosition),
					new TextPoint (leftParen.StartPosition), new TextPoint (rightParen.StartPosition));
				
			} else {
				Expression initial = ParseExpression ();
				
				if (current.Kind == Token.Type.In) {
					Token inToken = current;
					Next ();
					Expression collection = ParseExpression ();
					CheckSyntaxExpected (Token.Type.RightParenthesis);
					rightParen = current;
					Next ();
					body = ParseStatement ();
					return new ExpressionForInStatement (initial, collection, body, new TextSpan (start, current),
						new TextSpan (start, rightParen), new TextPoint (inToken.StartPosition),
						new TextPoint (leftParen.StartPosition), new TextPoint (rightParen.StartPosition));
				}

				CheckSyntaxExpected (Token.Type.SemiColon);
				firstSemiColon = current;
				Next ();
				condition = ParseExpression ();
				CheckSyntaxExpected (Token.Type.SemiColon);
				secondSemiColon = current;
				Next ();
				increment = ParseExpression ();
				CheckSyntaxExpected (Token.Type.RightParenthesis);
				rightParen = current;
				Next ();
				body = ParseStatement ();
				return new ExpressionForStatement (initial, condition, increment, body,
					new TextSpan (start, current), new TextSpan (start, rightParen),
					new TextPoint (firstSemiColon.StartPosition), new TextPoint (secondSemiColon.StartPosition),
					new TextPoint (leftParen.StartPosition), new TextPoint (rightParen.StartPosition));
			}
		}

		private BreakOrContinueStatement ParseBreakOrContinue ()
		{
			Token start = current;
			Statement.Operation opcode = Statement.Operation.Continue;
			if (current.Kind == Token.Type.Break)
				opcode = Statement.Operation.Break;
			Next();
			CheckSyntaxExpected(Token.Type.Identifier);
			Identifier label = (current as IdentifierToken).Spelling;
			return new BreakOrContinueStatement (opcode, label, new TextSpan (start, current), new TextPoint (current.StartPosition));
		}

		private WithStatement ParseWith ()
		{
			Token start = current;
			Next();
			CheckSyntaxExpected(Token.Type.LeftParenthesis);
			Token leftParen = current;
			Expression scope = ParseExpression();
			CheckSyntaxExpected(Token.Type.RightParenthesis);
			Token rightParen = current;
			Next();
			Statement body = ParseStatement();

			return new WithStatement (scope, body, new TextSpan (start, current), new TextSpan (start, rightParen), new TextPoint (leftParen.StartPosition), new TextPoint (rightParen.StartPosition));
		}

		private SwitchStatement ParseSwitch ()
		{
			Token start = current;
			Next();
			CheckSyntaxExpected(Token.Type.LeftParenthesis);
			Token leftParen = current;
			Expression Value = ParseExpression();
			CheckSyntaxExpected(Token.Type.RightParenthesis);
			Token rightParen = current;
			Next();
			CheckSyntaxExpected (Token.Type.LeftBrace);
			Token leftBrace = current;
			Next ();
			DList<CaseClause, SwitchStatement> cases = new DList<CaseClause, SwitchStatement> ();
			bool defaultFlag = false;
			while (current.Kind == Token.Type.Case || current.Kind == Token.Type.Default) {
				if (current.Kind == Token.Type.Case)
					cases.Append (ParseValueCaseClause ());
				else {
					if (defaultFlag)
						Error (DiagnosticCode.SwitchHasMultipleDefaults, new TextSpan (start, current));
					cases.Append (ParseDefaultCaseClause ());
					defaultFlag = true;
				}
				Next ();			
			}
			CheckSyntaxExpected (Token.Type.RightBrace);
			SwitchStatement switchStatement = new SwitchStatement (Value, cases, new TextSpan (start, current), new TextSpan (start, rightParen), new TextPoint (leftParen.StartPosition), new TextPoint (rightParen.StartPosition), new TextPoint (leftBrace.StartPosition));
			cases.Parent = switchStatement;
			return switchStatement;
		}

		private DefaultCaseClause ParseDefaultCaseClause ()
		{
			Token start = current;
			Next ();
			CheckSyntaxExpected (Token.Type.Colon);
			Token colon = current;
			Next ();
			DList<Statement, CaseClause> children = new DList<Statement,CaseClause>();
			do {
				if (current.Kind == Token.Type.Case
					|| current.Kind == Token.Type.Default
					|| current.Kind == Token.Type.RightBrace
					|| current.Kind == Token.Type.EndOfInput)
					break;
				children.Append (ParseStatement ());
			} while (true);
			DefaultCaseClause result = new DefaultCaseClause (children, new TextSpan (start, current), new TextSpan (start, colon), new TextPoint (colon.StartPosition));
			children.Parent = result;
			return result;
		}

		private ValueCaseClause ParseValueCaseClause ()
		{
			Token start = current;
			Next ();
			Expression expression = ParseExpression ();
			CheckSyntaxExpected (Token.Type.Colon);
			Token colon = current;
			Next ();
			DList<Statement, CaseClause> children = new DList<Statement, CaseClause> ();
			do {
				if (current.Kind == Token.Type.Case
					|| current.Kind == Token.Type.Default
					|| current.Kind == Token.Type.RightBrace
					|| current.Kind == Token.Type.EndOfInput)
					break;
				children.Append (ParseStatement ());
			} while (true);
			ValueCaseClause result = new ValueCaseClause (expression, children, new TextSpan (start, current), new TextSpan (start, colon), new TextPoint (colon.StartPosition));
			children.Parent = result;
			return result;
		}

		private ReturnOrThrowStatement ParseReturn ()
		{
			Token start = current;
			Next ();
			Expression expr = null;
			if (current.Kind != Token.Type.SemiColon)
				expr = ParseExpression();

			return new ReturnOrThrowStatement (Statement.Operation.Return, expr, new TextSpan (start, current));

		}

		private ReturnOrThrowStatement ParseThrow ()
		{
			Token start = current;
			Next ();
			Expression expr = ParseExpression ();
			return new ReturnOrThrowStatement (Statement.Operation.Throw, expr, new TextSpan (start, current));
		}

		private TryStatement ParseTry ()
		{
			Token start = current;
			Next ();
			BlockStatement block = ParseBlock ();
			Next();
			bool flag = false;
			CatchClause catchClause = null;
			FinallyClause finallyClause = null;

			if (current.Kind == Token.Type.Catch) {
				Token start2 = current;
				flag = true;
				Next ();
				CheckSyntaxExpected (Token.Type.LeftParenthesis);
				Token left = current;
				Next ();
				CheckSyntaxExpected (Token.Type.Identifier);
				Token id = current;
				Identifier name = (current as IdentifierToken).Spelling;
				Next();
				CheckSyntaxExpected (Token.Type.RightParenthesis);
				Token right = current;
				Next();
				BlockStatement handler = ParseBlock();
				catchClause = new CatchClause(name, handler,new TextSpan(start2,current), new TextSpan(id, id), new TextPoint(left.StartPosition),new TextPoint(right.StartPosition));
			} 

			if (current.Kind == Token.Type.Finally) {
				Token start3 = current;
				flag = true;
				Next ();
				BlockStatement handler2 = ParseBlock();
				finallyClause = new FinallyClause(handler2,new TextSpan(start3,current));
			}

			if (flag) {
				diagnostics.Add(new Diagnostic(DiagnosticCode.TryHasNoHandlers,new TextSpan(start,current)));
			}
			return new TryStatement (block, catchClause, finallyClause, new TextSpan (start, current));
		}
		
		#endregion

		#region expressions
		
		private Expression ParseMemberExpression ()
		{
			Token start = current;
			Expression expr;
			switch (current.Kind) {
				//primary expression
				case Token.Type.This:
					expr = new Expression (Expression.Operation.This, new TextSpan (current, current));
					break;
				case Token.Type.Identifier:
					expr = new IdentifierExpression ((current as IdentifierToken).Spelling, new TextSpan (current, current));
					break;
				case Token.Type.Null:
					expr = new NullExpression (new TextSpan (current, current));
					break;
				case Token.Type.True:
					expr = new Expression (Expression.Operation.True, new TextSpan (current, current));
					break;
				case Token.Type.False:
					expr = new Expression (Expression.Operation.False, new TextSpan (current, current));
					break;
				case Token.Type.NumericLiteral:
					expr = new NumericLiteralExpression ((current as NumericLiteralToken).Spelling, new TextSpan (current, current));
					break;
				case Token.Type.StringLiteral:
					expr = new StringLiteralExpression ((current as StringLiteralToken).Value, (current as StringLiteralToken).Spelling, new TextSpan (current, current));
					break;
				case Token.Type.LeftBracket:
					expr = ParseArrayLiteral ();
					break;
				case Token.Type.LeftBrace:
					expr = ParseObjectLiteral ();
					break;
				case Token.Type.LeftParenthesis: // here not sure can be more than one thing... ;(
					Next ();
					expr = ParseExpression ();
					CheckSyntaxExpected (Token.Type.RightParenthesis);
					Next ();
					break;
				//end primary
				case Token.Type.Function:
					expr = new FunctionExpression (ParseFunctionDefinition ());
					break;
				case Token.Type.New:
					expr = ParseNew ();
					break;
				default:
					SyntaxError.Add ("expression start with a strange token :" + Enum.GetName (typeof (Token.Type), current.Kind));
					return new Expression (Expression.Operation.SyntaxError, new TextSpan (start, current));
			}
			
			start = current;

			switch (current.Kind) {
				case Token.Type.LeftBracket:
					Next ();
					Expression subscript = ParseExpression ();
					Next ();
					CheckSyntaxExpected (Token.Type.RightBracket);					
					return new SubscriptExpression (expr, subscript, new TextSpan (start, current), new TextPoint (start.StartPosition));
				case Token.Type.Dot:
					Next ();
					CheckSyntaxExpected (Token.Type.Identifier);
					return new QualifiedExpression (expr, ((IdentifierToken)current).Spelling, new TextSpan (start, current), new TextPoint (start.StartPosition), new TextPoint (current.StartPosition));
			}
			return expr;
		}
		/*
		ArgumentList.cs
		BinaryOperatorExpression.cs
		ForInStatement.cs
		FunctionDefinition.cs
		HexLiteralExpression.cs
		IdentifierExpression.cs
		InvocationExpression.cs
		LabelStatement.cs
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
		VariableDeclaration.cs
		VariableDeclarationListElement.cs
		 */
		private FunctionDefinition ParseFunctionDefinition ()
		{
			Token start = current;

			Next ();
			CheckSyntaxExpected (Token.Type.Identifier);
			Identifier id = ((IdentifierToken)current).Spelling;
			TextPoint NameLocation = new TextPoint (this.current.StartPosition);

			Next ();
			CheckSyntaxExpected (Token.Type.LeftParenthesis);
			TextPoint leftParenLocation = new TextPoint (this.current.StartPosition);

			Next ();
			List<Parameter> parametters = ParseListParametter ();
			CheckSyntaxExpected (Token.Type.RightParenthesis);
			TextPoint rightParenLocation = new TextPoint (this.current.StartPosition);
			Token headerEnd = this.current;

			Next ();
			BlockStatement body = ParseBlock ();
			TextSpan location = new TextSpan (start, current);
			TextSpan HeaderLocation = new TextSpan (start, headerEnd);

			return new FunctionDefinition (id, parametters, body, location, HeaderLocation, NameLocation, leftParenLocation, rightParenLocation);
		}

		private Expression ParseObjectLiteral ()
		{
			Token start = current;
			Next ();
			List<ObjectLiteralElement> elements = new List<ObjectLiteralElement> ();
			if (current.Kind == Token.Type.RightBrace) {
				return new ObjectLiteralExpression (elements, new TextSpan (start, current));
			}
			
			ObjectLiteralElement element;
			TextPoint comma = new TextPoint ();
			TextPoint colon = new TextPoint ();
			do {
				if (current.Kind != Token.Type.Identifier
					&& current.Kind != Token.Type.StringLiteral
					&& current.Kind != Token.Type.NumericLiteral) {
					Error (DiagnosticCode.SyntaxError, new TextSpan (current, current));
					return new Expression (Expression.Operation.SyntaxError, new TextSpan (current, current));					
				}
				Expression name = ParseExpression ();
				CheckSyntaxExpected (Token.Type.Colon);
				colon = new TextPoint (current.StartPosition);
				Next ();
				Expression val = ParseExpression ();
				element = new ObjectLiteralElement (name, val, colon, comma);
				elements.Add (element);
				comma = new TextPoint (current.StartPosition);
			} while (current.Kind == Token.Type.Comma);
			CheckSyntaxExpected (Token.Type.RightBrace);
			elements.Add (element);
			return new ObjectLiteralExpression (elements, new TextSpan (start, current));
		}

		private ArrayLiteralExpression ParseArrayLiteral ()
		{
			Token start = current;
			Next();
			List<ExpressionListElement> elements = new List<ExpressionListElement> ();
			if (current.Kind == Token.Type.RightBracket) {
				return new ArrayLiteralExpression (elements, new TextSpan(start, current));
			}
			// TODO elision?
			TextPoint comma = new TextPoint();
			do {
				Expression exp = ParseExpression ();
				ExpressionListElement element = new ExpressionListElement (exp, comma);
				elements.Add (element);
				comma = new TextPoint(current.StartPosition);
			} while (current.Kind == Token.Type.Comma);
			CheckSyntaxExpected (Token.Type.RightBracket);
			return new ArrayLiteralExpression (elements, new TextSpan(start, current));
		}

		private Expression ParseExpression ()
		{
			return ParseExpression (false);
		}

		private UnaryOperatorExpression ParseUnaryExpression (bool noIn)
		{
			Token start = current;
			UnaryOperatorExpression expr;
			// get by first token
			switch (current.Kind) {
				case Token.Type.LeftParenthesis:
					Next ();
					expr = new UnaryOperatorExpression (this.ParseExpression (noIn), Expression.Operation.Parenthesized, new TextSpan (start, current));
					break;
				case Token.Type.Plus:
					Next ();
					expr = new UnaryOperatorExpression (this.ParseExpression (noIn), Expression.Operation.PrefixPlus, new TextSpan (start, current));
					break;
				case Token.Type.Minus:
					Next ();
					expr = new UnaryOperatorExpression (this.ParseExpression (noIn), Expression.Operation.PrefixMinus, new TextSpan (start, current));
					break;
				case Token.Type.PlusPlus:
					Next ();
					expr = new UnaryOperatorExpression (this.ParseExpression (noIn), Expression.Operation.PrefixPlusPlus, new TextSpan (start, current));
					break;
				case Token.Type.MinusMinus:
					Next ();
					expr = new UnaryOperatorExpression (this.ParseExpression (noIn), Expression.Operation.PrefixMinusMinus, new TextSpan (start, current));
					break;
				case Token.Type.Bang:
					Next ();
					expr = new UnaryOperatorExpression (this.ParseExpression (noIn), Expression.Operation.Bang, new TextSpan (start, current));
					break;
				case Token.Type.Tilda:
					Next ();
					expr = new UnaryOperatorExpression (this.ParseExpression (noIn), Expression.Operation.Tilda, new TextSpan (start, current));
					break;
				case Token.Type.Delete:
					Next ();
					expr = new UnaryOperatorExpression (this.ParseExpression (noIn), Expression.Operation.Delete, new TextSpan (start, current));
					break;
				case Token.Type.Typeof:
					Next ();
					expr = new UnaryOperatorExpression (this.ParseExpression (noIn), Expression.Operation.Typeof, new TextSpan (start, current));
					break;
				case Token.Type.Void:
					Next ();
					expr = new UnaryOperatorExpression (this.ParseExpression (noIn), Expression.Operation.Void, new TextSpan (start, current));
					break;
				default:
					SyntaxError.Add ("Unary operator start with a strange token :" + Enum.GetName (typeof (Token.Type), current.Kind));
					return null;//TODO
			}
			switch (current.Kind) {
				case Token.Type.PlusPlus:
					expr = new UnaryOperatorExpression (expr, Expression.Operation.PostfixPlusPlus, new TextSpan (start, current));
					Next ();
					break;
				case Token.Type.MinusMinus:
					expr = new UnaryOperatorExpression (expr, Expression.Operation.PostfixMinusMinus, new TextSpan (start, current));
					Next ();
					break;
			}
			return expr;
		}

		[MonoTODO]
		private Expression ParseExpression (bool noIn)
		{
			Token start = current;
			// TODO CALL MEMBER AND UNARY EXPRESSION		
			// RegularExpressionLiteralExpression
			// HexLiteralExpression
			// Logical operator
			// || ou &&
			//	ou | ou ^ ou &
			// Conditionnal operator
			// == ou != ou === ou !== ou < ou > ou <= ou >= ou instanceof ou in (si avec in))
			//math operator
			// << ou >> ou >>> ou + ou - ou * ou / ou %
			Next ();
			switch (current.Kind) {
					//assigment
				case Token.Type.Equal:
				case Token.Type.StarEqual:
				case Token.Type.DivideEqual:
				case Token.Type.PercentEqual:
				case Token.Type.PlusEqual:
				case Token.Type.MinusEqual:
				case Token.Type.GreaterGreaterEqual:
				case Token.Type.LessLessEqual:
				case Token.Type.GreaterGreaterGreaterEqual:
				case Token.Type.AmpersandEqual:
				case Token.Type.CircumflexEqual:
				case Token.Type.BangEqual:
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
				case Token.Type.Colon:
				case Token.Type.SemiColon:
					ParseNew ();//TODO
					break;
				default:
					SyntaxError.Add("Statement start with a strange token :" + Enum.GetName(typeof(Token.Type), current.Kind));
					break;
			}
			
			return new Expression(Expression.Operation.Bang, new TextSpan(start,current));
			
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
			//new MemberExpression Arguments
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

		#endregion

		#region helpers

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
			Error (code, new TextSpan (current,current));
		}

		#endregion

		#endregion

		private List<Diagnostic> diagnostics;

		public List<Diagnostic> Diagnostics {
			get { return diagnostics; }
		}

		private void Error(DiagnosticCode code , TextSpan loc)
		{
			diagnostics.Add (new Diagnostic (code, loc));
		}
		/* TODO 
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
