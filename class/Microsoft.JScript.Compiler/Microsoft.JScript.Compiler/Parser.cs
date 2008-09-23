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
using Microsoft.JScript.Compiler.ParseTree;

namespace Microsoft.JScript.Compiler
{
	public class Parser
	{
		public Parser (char[] Input, bool ECMA3Mode)
			: this (Input, new IdentifierTable (), ECMA3Mode)
		{
		}

		public Parser (char[] Input, IdentifierTable IDTable, bool ECMA3Mode)
		{
			this.ECMA3Mode = ECMA3Mode;
			lexer = new Tokenizer (Input, IDTable);
			diagnostics = new List<Diagnostic> ();
			Next (); // innit on first token 
		}

		#region private fields

		private Tokenizer lexer;
		private Token current;
		private List<String> SyntaxError = new List<string>();
		private bool syntaxIncomplete = false;
		private int withinIteration;
		private int withinSwitch;
		private List<string> LabelSet = new List<string> ();
		private bool ECMA3Mode;
		private BindingInfo BindingInfo;
		private List<Diagnostic> diagnostics;

		#endregion

		#region public members

		public DList<Statement, BlockStatement> ParseProgram (ref List<Comment> Comments, ref BindingInfo BindingInfo)
		{
			Init ();
			DList<Statement, BlockStatement> result = new DList<Statement, BlockStatement> ();
			while (current.Kind != Token.Type.EndOfInput) {
				if (current.Kind == Token.Type.function)
					result.Append (ParseFunctionDeclaration ());
				else
					result.Append (ParseStatement ());
				Next ();
			}
			Comments = lexer.Comments;
			return result;
		}
				
		public Expression ParseExpression (ref List<Comment> Comments, ref BindingInfo BindingInfo)
		{
			Init ();
			Expression ex = ParseExpression();
			Comments = lexer.Comments;
			this.BindingInfo = BindingInfo;
			return ex;
		}

		/*public Statement ParseStatement (ref List<Comment> Comments)
		{
			Init ();
			Statement sta = ParseStatement ();
			Comments = lexer.Comments;
			return sta;
		}*///remove in the new version

		public bool SyntaxIncomplete ()
		{
			return syntaxIncomplete;
		}

		public bool SyntaxOK ()
		{
			return diagnostics.Count == 0;
		}

		public List<Diagnostic> Diagnostics {
			get { return diagnostics; }
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
				Next ();
			}
			return result;
		}

		private Statement ParseStatement ()
		{
			//Token start = current;
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
					return ParseContinue ();
				case Token.Type.@break:
					return ParseBreak ();
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
				//  SEEMS THAT MS DO NOT RESPECT SPEC AND FUNCTION IS GET AFTER THAT IN EXPRESSION
				// SO ONLY USE FOR PARSE PROGRAMME AND NOT HERE
				//case Token.Type.function:
				//	return ParseFunctionDeclaration ();
				case Token.Type.Semicolon:
					return new Statement (Statement.Operation.Empty, new TextSpan (current, current));
				case Token.Type.Identifier:
					return ParseLabelStatement(); //TODO if 2 not colon => expression statement
				default:
					if ( current.Kind != Token.Type.LeftBrace
						&& current.Kind != Token.Type.Comma)
						//&& current.Kind != Token.Type.function)
						return ParseExpressionStatement ();
					break;
			}
			SyntaxError.Add ("Statement start with a strange token :" + current.Kind.ToString ());
			return new Statement (Statement.Operation.SyntaxError, new TextSpan (current, current));
		}

		private LabelStatement ParseLabelStatement ()
		{
			Token start = current;
			CheckSyntaxExpected (Token.Type.Identifier);
			Identifier label = ((IdentifierToken)current).Spelling;
			Next ();
			CheckSyntaxExpected (Token.Type.Colon);
			TextPoint colon = new TextPoint (current.StartPosition);
			Next ();
			if (LabelSet.Contains (label.Spelling))
				Error (DiagnosticCode.EnclosingLabelShadowed, new TextSpan (start, current));
			LabelSet.Add (label.Spelling);
			Statement labeled = ParseStatement();
			LabelSet.Remove (label.Spelling);
			return new LabelStatement (label, labeled, new TextSpan (start, current), colon);
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
					Expression initializer = ParseAssignmentExpression (false);
					declaration = new InitializerVariableDeclaration (name, initializer, new TextSpan (start2, current), new TextPoint (start2.StartPosition));
					//Next ();
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
			Next ();
			Expression condition = ParseExpression ();
			CheckSyntaxExpected (Token.Type.RightParenthesis);
			Token rightParen = current;
			Next ();
			Statement ifBody = ParseStatement ();
			Next ();
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
			Next ();
			Expression condition = ParseExpression ();
			CheckSyntaxExpected (Token.Type.RightParenthesis);
			Token rightParen = current;
			withinIteration++;
			Statement body = ParseStatement ();
			withinIteration--;
			return new WhileStatement (condition, body, new TextSpan (start, current), new TextSpan (start, rightParen), new TextPoint (leftParen.StartPosition), new TextPoint (rightParen.StartPosition));
		}

		private DoStatement ParseDo ()
		{
			Token start = current;
			Next ();
			withinIteration++;
			Statement body = ParseStatement ();
			withinIteration--;
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
					withinIteration++;
					body = ParseStatement ();
					withinIteration--;
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
					withinIteration++;
					body = ParseStatement ();
					withinIteration--;
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
					withinIteration++;
					body = ParseStatement ();
					withinIteration--;
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
				withinIteration++;
				body = ParseStatement ();
				withinIteration--;
				return new ExpressionForStatement (initial, condition, increment, body,
					new TextSpan (start, current), new TextSpan (start, rightParen),
					new TextPoint (firstSemiColon.StartPosition), new TextPoint (secondSemiColon.StartPosition),
					new TextPoint (leftParen.StartPosition), new TextPoint (rightParen.StartPosition));
			}
		}

		private BreakOrContinueStatement ParseContinue ()
		{
			Token start = current;
			Next ();
			Identifier label = null;
			if (current.Kind != Token.Type.Semicolon) {
				if (CheckSyntaxExpected (Token.Type.Identifier))
					label = (current as IdentifierToken).Spelling;
				if (!LabelSet.Contains (label.Spelling))
					Error (DiagnosticCode.ContinueLabelInvalid, new TextSpan (start, current));
			} else if (withinIteration == 0)
				Error (DiagnosticCode.ContinueContextInvalid, new TextSpan (start, current));

			InsertSemicolon ();
			return new BreakOrContinueStatement (Statement.Operation.Continue, label, new TextSpan (start, current), new TextPoint (current.StartPosition));
		}

		private BreakOrContinueStatement ParseBreak ()
		{
			//todo test within vars
			Token start = current;
			Next();
			Identifier label = null;
			if (current.Kind != Token.Type.Semicolon) {
				if (CheckSyntaxExpected (Token.Type.Identifier))
					label = (current as IdentifierToken).Spelling;
				if ( !LabelSet.Contains(label.Spelling))
					Error (DiagnosticCode.NoEnclosingLabel, new TextSpan (start, current));
			} else if (withinIteration == 0 
					&& withinSwitch == 0)
				Error (DiagnosticCode.BreakContextInvalid, new TextSpan (start, current));
 
			InsertSemicolon ();
			return new BreakOrContinueStatement (Statement.Operation.Break, label, new TextSpan (start, current), new TextPoint (current.StartPosition));
		}

		private WithStatement ParseWith ()
		{
			Token start = current;
			Next();
			CheckSyntaxExpected(Token.Type.LeftParenthesis);
			Token leftParen = current;
			Next ();
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
			Next ();
			Expression Value = ParseExpression();
			CheckSyntaxExpected(Token.Type.RightParenthesis);
			Token rightParen = current;
			Next();
			CheckSyntaxExpected (Token.Type.LeftBrace);
			Token leftBrace = current;
			Next ();
			withinSwitch++;
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
			}
			withinSwitch--;
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
				Next ();
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
				Next ();
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
			bool flag = true;
			CatchClause catchClause = null;
			FinallyClause finallyClause = null;

			if (current.Kind == Token.Type.@catch) {
				Token start2 = current;
				flag = false;
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
				flag = false;
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
				case Token.Type.OctalIntegerLiteral:
					expr = new OctalLiteralExpression (((OctalIntegerLiteralToken)current).Value, new TextSpan (current, current));
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
					expr = new UnaryOperatorExpression(ParseExpression (), Expression.Operation.Parenthesized, new TextSpan(current,current));
					CheckSyntaxExpected (Token.Type.RightParenthesis);
					break;
				//end primary
				case Token.Type.function:
					expr = new FunctionExpression (ParseFunctionDefinition ());
					break;
				case Token.Type.@new:
					Next ();
					Expression target = ParseExpression ();
					ArgumentList arguments;
					if (current.Kind == Token.Type.LeftParenthesis) {
						arguments = this.ParseArgumentList ();
					} else {
						arguments = new ArgumentList (new List<ExpressionListElement> (), new TextSpan (start, current));
					}
					expr = new InvocationExpression (target, arguments,Expression.Operation.@new, new TextSpan(start,current));
					break;
				default:
					SyntaxError.Add ("Expression start with a strange token :" + current.Kind.ToString ());
					return new Expression (Expression.Operation.SyntaxError, new TextSpan (start, current));
			}
			Next (); // to go ahead for other part
			return ParseRightExpression (expr);
		}

		//not in ecma but more clean to cut it from left hand side expr
		//group some of member expression and call expression
		private Expression ParseRightExpression (Expression expr)
		{
			Token start = current;
			while(true) {
				switch (current.Kind) {
					case Token.Type.LeftParenthesis:
						ArgumentList argumentList = ParseArgumentList ();
						expr = new InvocationExpression (expr, argumentList, Expression.Operation.Invocation, new TextSpan (start, current));
						Next ();
						break;
					case Token.Type.LeftBracket:
						Next ();
						Expression subscript = ParseExpression ();
						CheckSyntaxExpected (Token.Type.RightBracket);
						expr = new SubscriptExpression (expr, subscript, new TextSpan (start, current), new TextPoint (start.StartPosition));
						Next ();
						break;
					case Token.Type.Dot:
						Next ();
						Identifier id = null;
						if (CheckSyntaxExpected (Token.Type.Identifier))
							id = ((IdentifierToken)current).Spelling;
						expr = new QualifiedExpression (expr, id, new TextSpan (start, current), new TextPoint (start.StartPosition), new TextPoint (current.StartPosition));
						Next ();
						break;
					default:
						return expr;
				}
			}
		}

		private Expression ParsePostfixExpression ()
		{
			Expression expr = ParseLeftHandSideExpression ();
			
			switch (current.Kind) {
				case Token.Type.PlusPlus :
					expr = new UnaryOperatorExpression (expr, Expression.Operation.PostfixPlusPlus, new TextSpan (expr.Location.StartLine, expr.Location.StartColumn, current.StartLine, current.StartColumn + current.Width, expr.Location.StartPosition, current.StartPosition+current.Width));
					Next ();
					break;
				case Token.Type.MinusMinus:
					expr = new UnaryOperatorExpression (expr, Expression.Operation.PostfixMinusMinus, new TextSpan (expr.Location.StartLine, expr.Location.StartColumn, current.StartLine, current.StartColumn + current.Width, expr.Location.StartPosition, current.StartPosition + current.Width));
					Next ();
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
			//Next (); //go ahead
			return expr;
		}

		private ArgumentList ParseArgumentList ()
		{
			Token start = current;
			CheckSyntaxExpected (Token.Type.LeftParenthesis);
			List<ExpressionListElement> arguments = new List<ExpressionListElement> ();
			Next ();
			while (current.Kind != Token.Type.RightParenthesis) {
				Expression arg = ParseAssignmentExpression (false);
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
					return expr;
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
			Token start = current;
			Expression expr = ParseAssignmentExpression (noIn);
			while (current.Kind == Token.Type.Comma) {
				Next ();
				Expression right = ParseAssignmentExpression (noIn);
				expr = new BinaryOperatorExpression (expr, right, Expression.Operation.Comma, new TextSpan (start, current), new TextPoint (start.StartPosition));
			}
			return expr;
		}

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
			Expression name;
			do {
				switch (current.Kind) {
					case Token.Type.Identifier:
						name = new IdentifierExpression ((current as IdentifierToken).Spelling, new TextSpan (current, current));
						break;
					case Token.Type.NumericLiteral:
						name = new NumericLiteralExpression (((NumericLiteralToken)current).Spelling, new TextSpan (current, current));
						break;
					case Token.Type.StringLiteral:
						name = new StringLiteralExpression ((current as StringLiteralToken).Value, (current as StringLiteralToken).Spelling, new TextSpan (current, current));
						break;
					default:
						Error (DiagnosticCode.SyntaxError, new TextSpan (current, current));
						return new Expression (Expression.Operation.SyntaxError, new TextSpan (current, current));					
				}
				Next ();
				CheckSyntaxExpected (Token.Type.Colon);
				colon = new TextPoint (current.StartPosition);
				Next ();
				Expression val = ParseAssignmentExpression (false);
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
			
			List<ExpressionListElement> elements = new List<ExpressionListElement> ();
			
			TextPoint comma = new TextPoint();
			do {
				Next ();
				if (current.Kind == Token.Type.RightBracket)
					break;
				Expression exp = null;
				//take care of elision
				if (current.Kind != Token.Type.Comma)
					exp = ParseAssignmentExpression (false);
				ExpressionListElement element = new ExpressionListElement (exp, comma);
				elements.Add (element);
				comma = new TextPoint(current.StartPosition);
			} while (current.Kind == Token.Type.Comma);
			CheckSyntaxExpected (Token.Type.RightBracket);
			return new ArrayLiteralExpression (elements, new TextSpan(start, current));
		}

		#endregion

		#region helpers

		private void Init ()
		{
			withinIteration = 0;
			withinSwitch = 0;
			LabelSet.Clear();
			SyntaxError.Clear();
			syntaxIncomplete = false;
		}

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

			if (current.Kind == Token.Type.EndOfInput)
				syntaxIncomplete = true;

			Error (code, new TextSpan (current,current));
			return false;
		}

		#endregion

		#endregion

		private void Error (DiagnosticCode code , TextSpan loc)
		{
			if (current.Kind == Token.Type.Bad)
				code = ((BadToken)current).Diagnostic;
			diagnostics.Add (new Diagnostic (code, loc));
		}

		//TODO finished bad token and syntax error management
		//TODO when no line terminator test is line have change...
		/* TODO 
			BadDivideOrRegularExpressionLiteral,
			MalformedEscapeSequence,
			NumericLiteralThenIdentifier,
			UnterminatedStringLiteral,
			UnterminatedComment,
			ExtraneousCharacter
		 */
	}
}
