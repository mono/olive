using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.JScript.Compiler.ParseTree;

namespace Microsoft.JScript.Compiler
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
				if (current.Kind == Token.Type.function)
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
				if (CheckSyntaxExpected (Token.Type.Identifier))
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
				case Token.Type.var:
					return ParseVarDeclaration ();
				case Token.Type.@if:
					return ParseIfElse ();
				case Token.Type.@while:
					return ParseWhile ();
				case Token.Type.@do:
					return ParseDo ();
				case Token.Type.@for:
					return ParseFor ();
				case Token.Type.@continue:
				case Token.Type.@break:
					return ParseBreakOrContinue ();
				case Token.Type.with:
					return ParseWith ();
				case Token.Type.@switch:
					return ParseSwitch ();
				case Token.Type.@try:
					return ParseTry ();
				case Token.Type.@throw:
					return ParseThrow ();
				case Token.Type.@return:
					return ParseReturn ();
				case Token.Type.function:
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
			InsertSemicolon ();
			return new ExpressionStatement (expr, new TextSpan (start, current));
		}

		private VariableDeclarationStatement ParseVarDeclaration ()
		{
			Token start = current;
			List<VariableDeclarationListElement> declarations = new List<VariableDeclarationListElement>();
			do {
				Next ();
				Identifier name = null;
				if (CheckSyntaxExpected (Token.Type.Identifier))
					name = (current as IdentifierToken).Spelling;

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
			InsertSemicolon ();
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
			if (current.Kind == Token.Type.@else) {
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
			CheckSyntaxExpected (Token.Type.@while);
			Token whileToken = current;
			Next ();
			CheckSyntaxExpected (Token.Type.LeftParenthesis);
			Token leftParen = current;
			Next ();
			Expression condition = ParseExpression ();
			CheckSyntaxExpected (Token.Type.RightParenthesis);
			Token rightParen = current;
			Next ();
			InsertSemicolon ();
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

			if (current.Kind == Token.Type.var) {
				VariableDeclarationStatement varDecl = ParseVarDeclaration ();

				if (current.Kind == Token.Type.@in) {
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
					CheckSyntaxExpected (Token.Type.Semicolon);
					firstSemiColon = current;
					Next ();
					condition = ParseExpression ();
					CheckSyntaxExpected (Token.Type.Semicolon);
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
			} else {
				Expression initial = ParseExpression ();

				if (current.Kind == Token.Type.@in) {
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
				CheckSyntaxExpected (Token.Type.Semicolon);
				firstSemiColon = current;
				Next ();
				condition = ParseExpression ();
				CheckSyntaxExpected (Token.Type.Semicolon);
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
			if (current.Kind == Token.Type.@break)
				opcode = Statement.Operation.Break;
			Next();
			Identifier label = null;
			if (current.Kind != Token.Type.Semicolon) {
				if (CheckSyntaxExpected (Token.Type.Identifier))
					label = (current as IdentifierToken).Spelling;
			}
			InsertSemicolon ();
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
			while (current.Kind == Token.Type.@case || current.Kind == Token.Type.@default) {
				if (current.Kind == Token.Type.@case)
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
				if (current.Kind == Token.Type.@case
					|| current.Kind == Token.Type.@default
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
				if (current.Kind == Token.Type.@case
					|| current.Kind == Token.Type.@default
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
			if (current.Kind != Token.Type.Semicolon)
				expr = ParseExpression();
			InsertSemicolon ();
			return new ReturnOrThrowStatement (Statement.Operation.Return, expr, new TextSpan (start, current));

		}

		private ReturnOrThrowStatement ParseThrow ()
		{
			Token start = current;
			Next ();
			Expression expr = ParseExpression ();
			InsertSemicolon ();
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

			if (current.Kind == Token.Type.@catch) {
				Token start2 = current;
				flag = true;
				Next ();
				CheckSyntaxExpected (Token.Type.LeftParenthesis);
				Token left = current;
				Next ();
				Token id = current;
				Identifier name = null;
				if (CheckSyntaxExpected (Token.Type.Identifier))
					name = (current as IdentifierToken).Spelling;

				Next();
				CheckSyntaxExpected (Token.Type.RightParenthesis);
				Token right = current;
				Next();
				BlockStatement handler = ParseBlock();
				catchClause = new CatchClause(name, handler,new TextSpan(start2,current), new TextSpan(id, id), new TextPoint(left.StartPosition),new TextPoint(right.StartPosition));
			}

			if (current.Kind == Token.Type.@finally) {
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

		private Expression ParseLeftHandSideExpression ()
		{
			Token start = current;
			Expression expr;
			switch (current.Kind) {
				//primary expression
				case Token.Type.@this:
					expr = new Expression (Expression.Operation.@this, new TextSpan (current, current));
					break;
				case Token.Type.Identifier:
					expr = new IdentifierExpression ((current as IdentifierToken).Spelling, new TextSpan (current, current));
					break;
				case Token.Type.@null:
					expr = new NullExpression (new TextSpan (current, current));
					break;
				case Token.Type.@true:
					expr = new Expression (Expression.Operation.@true, new TextSpan (current, current));
					break;
				case Token.Type.@false:
					expr = new Expression (Expression.Operation.@false, new TextSpan (current, current));
					break;
				case Token.Type.NumericLiteral:
					expr = new NumericLiteralExpression (((NumericLiteralToken)current).Spelling, new TextSpan (current, current));
					break;
				case Token.Type.HexIntegerLiteral:
					expr = new HexLiteralExpression (((HexIntegerLiteralToken)current).Value, new TextSpan (current, current));
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
				case Token.Type.LeftParenthesis:
					Next ();
					expr = ParseExpression ();
					CheckSyntaxExpected (Token.Type.RightParenthesis);
					Next ();
					break;
				//end primary
				case Token.Type.function:
					expr = new FunctionExpression (ParseFunctionDefinition ());
					break;
				case Token.Type.@new:
					Next ();
					Expression target = ParseExpression ();
					Next ();
					ArgumentList arguments;
					if (current.Kind == Token.Type.LeftParenthesis) {
						arguments = this.ParseArgumentList ();
					} else {
						arguments = new ArgumentList (new List<ExpressionListElement> (), new TextSpan (start, current));
					}
					expr = new InvocationExpression (target, arguments,Expression.Operation.@new, new TextSpan(start,current));
					break;
				default:
					SyntaxError.Add ("expression start with a strange token :" + Enum.GetName (typeof (Token.Type), current.Kind));
					return new Expression (Expression.Operation.SyntaxError, new TextSpan (start, current));
			}
			return ParseRightExpression (expr);
		}

		//not in ecma but more clean to cut it from left hand side expr
		//group some of member expression and call expression
		private Expression ParseRightExpression (Expression expr)
		{
			Token start = current;

			switch (current.Kind) {
				case Token.Type.LeftParenthesis:
					ArgumentList argumentList = ParseArgumentList ();
					return new InvocationExpression (expr, argumentList, Expression.Operation.Invocation, new TextSpan (start, current));
				case Token.Type.LeftBracket:
					Next ();
					Expression subscript = ParseExpression ();
					Next ();
					CheckSyntaxExpected (Token.Type.RightBracket);
					return new SubscriptExpression (expr, subscript, new TextSpan (start, current), new TextPoint (start.StartPosition));
				case Token.Type.Dot:
					Next ();
					Identifier id = null;
					if (CheckSyntaxExpected (Token.Type.Identifier))
						id = ((IdentifierToken)current).Spelling;
					return new QualifiedExpression (expr, id, new TextSpan (start, current), new TextPoint (start.StartPosition), new TextPoint (current.StartPosition));
			}
			return expr;
		}

		private Expression ParsePostfixExpression ()
		{
			Expression expr = ParseLeftHandSideExpression ();
			Next();
			switch (current.Kind) {
				case Token.Type.PlusPlus :
					expr = new UnaryOperatorExpression (expr, Expression.Operation.PostfixPlusPlus, new TextSpan (expr.Location.StartLine, expr.Location.StartColumn, current.StartLine, current.StartColumn + current.Width, expr.Location.StartPosition, current.StartPosition+current.Width));
					break;
				case Token.Type.MinusMinus:
					expr = new UnaryOperatorExpression (expr, Expression.Operation.PostfixMinusMinus, new TextSpan (expr.Location.StartLine, expr.Location.StartColumn, current.StartLine, current.StartColumn + current.Width, expr.Location.StartPosition, current.StartPosition + current.Width));
					break;
			}
			return expr;
		}

		private Expression ParseUnaryExpression (bool noIn)
		{
			Token start = current;
			Expression expr;
			// get by first token
			switch (current.Kind) {
				case Token.Type.delete:
					Next ();
					expr = new UnaryOperatorExpression (this.ParseExpression (noIn), Expression.Operation.delete, new TextSpan (start, current));
					break;
				case Token.Type.@void:
					Next ();
					expr = new UnaryOperatorExpression (this.ParseExpression (noIn), Expression.Operation.@void, new TextSpan (start, current));
					break;
				case Token.Type.@typeof:
					Next ();
					expr = new UnaryOperatorExpression (this.ParseExpression (noIn), Expression.Operation.@typeof, new TextSpan (start, current));
					break;
				case Token.Type.PlusPlus:
					Next ();
					expr = new UnaryOperatorExpression (this.ParseExpression (noIn), Expression.Operation.PrefixPlusPlus, new TextSpan (start, current));
					break;
				case Token.Type.MinusMinus:
					Next ();
					expr = new UnaryOperatorExpression (this.ParseExpression (noIn), Expression.Operation.PrefixMinusMinus, new TextSpan (start, current));
					break;
				case Token.Type.Plus:
					Next ();
					expr = new UnaryOperatorExpression (this.ParseExpression (noIn), Expression.Operation.PrefixPlus, new TextSpan (start, current));
					break;
				case Token.Type.Minus:
					Next ();
					expr = new UnaryOperatorExpression (this.ParseExpression (noIn), Expression.Operation.PrefixMinus, new TextSpan (start, current));
					break;
				case Token.Type.Tilda:
					Next ();
					expr = new UnaryOperatorExpression (this.ParseExpression (noIn), Expression.Operation.Tilda, new TextSpan (start, current));
					break;
				case Token.Type.Bang:
					Next ();
					expr = new UnaryOperatorExpression (this.ParseExpression (noIn), Expression.Operation.Bang, new TextSpan (start, current));
					break;
				default:
					expr = ParsePostfixExpression ();
					break;
			}
			return expr;
		}

		private ArgumentList ParseArgumentList ()
		{
			Token start = current;
			CheckSyntaxExpected (Token.Type.LeftParenthesis);
			List<ExpressionListElement> arguments = new List<ExpressionListElement> ();
			Next ();
			while (current.Kind != Token.Type.RightParenthesis) {
				Expression arg = ParseExpression ();
				CheckSyntaxExpected (Token.Type.Comma);
				arguments.Add (new ExpressionListElement (arg, new TextPoint(current.StartPosition)));
			}
			return new ArgumentList (arguments, new TextSpan (start, current));
		}
		
		private Expression ParseMultiplicativeExpression(bool noIn)
		{
			Token start = current;
			Expression expr = ParseUnaryExpression (noIn);
			while (current.Kind == Token.Type.Star
				|| current.Kind == Token.Type.Divide
				|| current.Kind == Token.Type.Percent) {
				Expression.Operation op = Expression.Operation.SyntaxError;
				switch (current.Kind) {
					case Token.Type.Star:
						op = Expression.Operation.Star;
						break;
					case Token.Type.Divide:
						op = Expression.Operation.Divide;
						break;
					case Token.Type.Percent:
						op = Expression.Operation.Percent;
						break;
				}
				Next ();
				Expression right = ParseUnaryExpression (noIn);
				expr = new BinaryOperatorExpression (expr, right, op, new TextSpan (start, current), new TextPoint (start.StartPosition));
			}
			return expr;
		}

		private Expression ParseAdditiveExpression (bool noIn)
		{
			Token start = current;
			Expression expr = ParseMultiplicativeExpression (noIn);
			while (current.Kind == Token.Type.Plus
				|| current.Kind == Token.Type.Minus) {
				Expression.Operation op = Expression.Operation.SyntaxError;
				switch (current.Kind) {
					case Token.Type.Plus:
						op = Expression.Operation.Plus;
						break;
					case Token.Type.Minus:
						op = Expression.Operation.Minus;
						break;
				}
				Next ();
				Expression right = ParseMultiplicativeExpression (noIn);
				expr = new BinaryOperatorExpression (expr, right, op, new TextSpan (start, current), new TextPoint (start.StartPosition));
			}
			return expr;
		}

		private Expression ParseShiftExpression (bool noIn)
		{
			Token start = current;
			Expression.Operation op = Expression.Operation.SyntaxError;
			Expression expr = ParseAdditiveExpression (noIn);
			while (current.Kind == Token.Type.LessLess
				|| current.Kind == Token.Type.GreaterGreater
				|| current.Kind == Token.Type.GreaterGreaterGreater) {
				switch (current.Kind) {
					case Token.Type.LessLess:
						op = Expression.Operation.LessLess;
						break;
					case Token.Type.GreaterGreater:
						op = Expression.Operation.GreaterGreater;
						break;
					case Token.Type.GreaterGreaterGreater:
						op = Expression.Operation.GreaterGreaterGreater;
						break;
				}
				Next ();
				Expression right = ParseAdditiveExpression (noIn);
				expr = new BinaryOperatorExpression (expr, right, op, new TextSpan (start, current), new TextPoint (start.StartPosition));
			}
			return expr;
		}

		private Expression ParseRelationalExpression (bool noIn)
		{
			Token start = current;
			Expression.Operation op = Expression.Operation.SyntaxError;
			Expression expr = ParseShiftExpression (noIn);
			while (current.Kind == Token.Type.Less
				|| current.Kind == Token.Type.Greater
				|| current.Kind == Token.Type.GreaterEqual
				|| current.Kind == Token.Type.LessEqual
				|| current.Kind == Token.Type.instanceof
				|| (current.Kind == Token.Type.@in && !noIn)) {
				switch (current.Kind) {
					case Token.Type.Less:
						op = Expression.Operation.Less;
						break;
					case Token.Type.Greater:
						op = Expression.Operation.Greater;
						break;
					case Token.Type.GreaterEqual:
						op = Expression.Operation.GreaterEqual;
						break;
					case Token.Type.LessEqual:
						op = Expression.Operation.LessEqual;
						break;
					case Token.Type.instanceof:
						op = Expression.Operation.instanceof;
						break;
					case Token.Type.@in:
						if (noIn)
							return ParseShiftExpression (noIn);
						else
							op = Expression.Operation.@in;
						break;
				}
				Next ();
				Expression right = ParseShiftExpression (noIn);
				expr = new BinaryOperatorExpression (expr, right, op, new TextSpan (start, current), new TextPoint (start.StartPosition));
			}
			return expr;
		}

		private Expression ParseEqualityExpression (bool noIn)
		{
			Token start = current;
			Expression expr = ParseRelationalExpression (noIn);
			while (current.Kind == Token.Type.EqualEqual
				|| current.Kind == Token.Type.BangEqual
				|| current.Kind == Token.Type.EqualEqualEqual
				|| current.Kind == Token.Type.BangEqualEqual) {
				Expression.Operation op = Expression.Operation.SyntaxError;
				switch (current.Kind) {
					case Token.Type.EqualEqual:
						op = Expression.Operation.EqualEqual;
						break;
					case Token.Type.BangEqual:
						op = Expression.Operation.BangEqual;
						break;
					case Token.Type.EqualEqualEqual:
						op = Expression.Operation.EqualEqualEqual;
						break;
					case Token.Type.BangEqualEqual:
						op = Expression.Operation.BangEqualEqual;
						break;
				}
				Token ope = current;
				Next ();
				Expression right = ParseRelationalExpression (noIn);
				expr = new BinaryOperatorExpression (expr, right, op, new TextSpan (start, current), new TextPoint (ope.StartPosition));
			}
			return expr;
		}

		private Expression ParseBitwiseANDExpression (bool noIn)
		{
			Token start = current;
			Expression expr = ParseEqualityExpression (noIn);
			while (current.Kind == Token.Type.Ampersand) {
				Token op = current;
				Next ();
				Expression right = ParseEqualityExpression (noIn);
				expr = new BinaryOperatorExpression (expr, right, Expression.Operation.Ampersand, new TextSpan (start, current), new TextPoint (op.StartPosition));
			}
			return expr;
		}

		private Expression ParseBitwiseXORExpression (bool noIn)
		{
			Token start = current;
			Expression expr = ParseBitwiseANDExpression (noIn);
			while (current.Kind == Token.Type.Circumflex) {
				Token op = current;
				Next ();
				Expression right = ParseBitwiseANDExpression (noIn);
				expr = new BinaryOperatorExpression (expr, right, Expression.Operation.Circumflex, new TextSpan (start, current), new TextPoint (op.StartPosition));
			}
			return expr;
		}

		private Expression ParseBitwiseORExpression (bool noIn)
		{
			Token start = current;
			Expression expr = ParseBitwiseXORExpression (noIn);
			while (current.Kind == Token.Type.Bar) {
				Token op = current;
				Next ();
				Expression right = ParseBitwiseXORExpression (noIn);
				expr = new BinaryOperatorExpression (expr, right, Expression.Operation.Bar, new TextSpan (start, current), new TextPoint (op.StartPosition));
			}
			return expr;				
		}

		private Expression ParselogicalANDExpression (bool noIn)
		{
			Token start = current;
			Expression expr = ParseBitwiseORExpression (noIn);
			while (current.Kind == Token.Type.AmpersandAmpersand) {
				Token op = current;
				Next ();
				Expression right = ParseBitwiseORExpression (noIn);
				expr = new BinaryOperatorExpression (expr, right, Expression.Operation.AmpersandAmpersand, new TextSpan (start, current), new TextPoint (op.StartPosition));
			} 			
			return expr;
		}

		private Expression ParselogicalORExpression (bool noIn)
		{
			Token start = current;
			Expression expr = ParselogicalANDExpression (noIn);
			while (current.Kind == Token.Type.BarBar) {
				Next ();
				Expression right = ParselogicalANDExpression (noIn);
				expr = new BinaryOperatorExpression (expr, right, Expression.Operation.BarBar, new TextSpan (start, current), new TextPoint (start.StartPosition));
			}
			return expr;
		}

		private Expression ParseConditionalExpression (bool noIn)
		{
			Token start = current;
			Expression expr = ParselogicalORExpression (noIn);
			Expression.Operation op;
			if (current.Kind == Token.Type.Question) {
				Next ();
				Expression second = ParseAssignmentExpression (noIn);
				CheckSyntaxExpected (Token.Type.Colon);
				Token colon = current;
				Next ();				
				Expression third = ParseAssignmentExpression (noIn);
				expr = new TernaryOperatorExpression (expr, second, third, Expression.Operation.Question, new TextSpan (start, current), new TextPoint (start.StartPosition), new TextPoint (colon.StartPosition));
			} 
			return expr;
		}

		private Expression ParseAssignmentExpression (bool noIn)
		{
			Token start = current;
			Expression.Operation op;
			Expression expr = ParseConditionalExpression (noIn);
			switch (current.Kind) {
				case Token.Type.Equal:
					op = Expression.Operation.Equal;
					break;
				case Token.Type.StarEqual:
					op = Expression.Operation.StarEqual;
					break;
				case Token.Type.DivideEqual:
					op = Expression.Operation.DivideEqual;
					break;
				case Token.Type.PercentEqual:
					op = Expression.Operation.PercentEqual;
					break;
				case Token.Type.PlusEqual:
					op = Expression.Operation.PlusEqual;
					break;
				case Token.Type.MinusEqual:
					op = Expression.Operation.MinusEqual;
					break;
				case Token.Type.GreaterGreaterEqual:
					op = Expression.Operation.GreaterGreaterEqual;
					break;
				case Token.Type.LessLessEqual:
					op = Expression.Operation.LessLessEqual;
					break;
				case Token.Type.GreaterGreaterGreaterEqual:
					op = Expression.Operation.GreaterGreaterGreaterEqual;
					break;
				case Token.Type.AmpersandEqual:
					op = Expression.Operation.AmpersandEqual;
					break;
				case Token.Type.CircumflexEqual:
					op = Expression.Operation.CircumflexEqual;
					break;
				case Token.Type.BarEqual:
					op = Expression.Operation.BarEqual;
					break;
				default:
					return ParseConditionalExpression (noIn);
			}
			//only left hand side expression
			if (expr is TernaryOperatorExpression
				|| expr is BinaryOperatorExpression
				|| expr is UnaryOperatorExpression) {
				Error (DiagnosticCode.SyntaxError, expr.Location);
			}
			Token ope = current;
			Next ();
			Expression right = ParseAssignmentExpression (noIn);
			return new BinaryOperatorExpression (expr, right, op, new TextSpan (start, current), new TextPoint (ope.StartPosition));
		}

		private Expression ParseExpression ()
		{
			return ParseExpression (false);
		}
				
		private Expression ParseExpression (bool noIn)
		{
			//TODO list of expression
			//do {
			//	  ParseAssignmentExpression (noIn);
			//	  Next ();
			//} while (current.Kind == Token.Type.Comma);
			//
			return ParseAssignmentExpression (noIn);
		}

		/*
		LabelStatement.cs
		OctalLiteralExpression.cs
		RegularExpressionLiteralExpression.cs
		 */

		private FunctionDefinition ParseFunctionDefinition ()
		{
			Token start = current;

			Next ();
			Identifier id = null;
			if (CheckSyntaxExpected (Token.Type.Identifier))
				id = ((IdentifierToken)current).Spelling;

			TextPoint NameLocation = new TextPoint (current.StartPosition);

			Next ();
			TextPoint leftParenLocation = new TextPoint();
			CheckSyntaxExpected (Token.Type.LeftParenthesis);
			leftParenLocation = new TextPoint (current.StartPosition);

			Next ();
			List<Parameter> parametters = ParseListParametter ();
			TextPoint rightParenLocation = new TextPoint();
			CheckSyntaxExpected (Token.Type.RightParenthesis);
			rightParenLocation = new TextPoint (current.StartPosition);
			
			Token headerEnd = current;

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

		#endregion

		#region helpers

		private void Next ()
		{
			current = lexer.GetNext ();
		}

		private void InsertSemicolon ()
		{
			if (current.Kind == Token.Type.Semicolon)
				return;
			current.InsertSemicolonBefore ();
		}

		private bool CheckSyntaxExpected (Token.Type type)
		{
			if (current.Kind == type)
				return true;

			//default
			DiagnosticCode code = DiagnosticCode.SyntaxError;

			switch (type) {
				case Token.Type.@case:
				case Token.Type.@default:
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
				case Token.Type.Semicolon:
					code = DiagnosticCode.SemicolonExpected;
					break;
			}
			Error (code, new TextSpan (current,current));
			return false;
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
