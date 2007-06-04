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
				case Token.Type.Return:
					return ParseReturnOrThrow ();
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
					return new DeclarationForStatement (varDecl.Declarations, condition, increment, body, new TextSpan (start, current), new TextSpan (start, rightParen), new TextPoint (firstSemiColon.StartPosition), new TextPoint (secondSemiColon.StartPosition), new TextPoint (leftParen.StartPosition), new TextPoint (rightParen.StartPosition));
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
				return new DeclarationForStatement (varDecl.Declarations, condition, increment, body, new TextSpan (start, current), new TextSpan (start, rightParen), new TextPoint (firstSemiColon.StartPosition), new TextPoint (secondSemiColon.StartPosition), new TextPoint (leftParen.StartPosition), new TextPoint (rightParen.StartPosition));
				//DeclarationForStatement
				
			} else {
				Expression initial = ParseExpression ();
				
				if (current.Kind == Token.Type.In) {
					//ExpressionForInStatement
					Token inToken = current;
					Next ();
					Expression collection = ParseExpression ();
					CheckSyntaxExpected (Token.Type.RightParenthesis);
					rightParen = current;
					Next ();
					body = ParseStatement ();
					return new ExpressionForInStatement (initial, collection, body, new TextSpan (start, current), new TextSpan (start, rightParen), new TextPoint (inToken.StartPosition), new TextPoint (leftParen.StartPosition), new TextPoint (rightParen.StartPosition));
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
				return new ExpressionForStatement (initial, condition, increment, body, new TextSpan (start, current), new TextSpan (start, rightParen), new TextPoint (firstSemiColon.StartPosition), new TextPoint (secondSemiColon.StartPosition), new TextPoint (leftParen.StartPosition), new TextPoint (rightParen.StartPosition));
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
						diagnostics.Add (new Diagnostic (DiagnosticCode.SwitchHasMultipleDefaults, new TextSpan (start, current)));
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
		DefaultCaseClause.cs
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
			Token start = current; //ident
			Next ();
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
				case Token.Type.Colon:
				case Token.Type.SemiColon:
					ParseIdentifier ();
					break;
				default:
					SyntaxError.Add("Statement start with a strange token :" + Enum.GetName(typeof(Token.Type), current.Kind));
					break;
			}
			
			return new Expression(Expression.Operation.Bang, new TextSpan(start,current));
			
		}

		private void ParseIdentifier ()
		{
			throw new Exception ("The method or operation is not implemented.");
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
