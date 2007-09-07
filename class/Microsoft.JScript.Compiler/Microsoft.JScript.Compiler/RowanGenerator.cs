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
using System.Reflection;
using Microsoft.Scripting;
using MSIA = Microsoft.Scripting.Internal.Ast;
using MJCP = Microsoft.JScript.Compiler.ParseTree;
using MJR = Microsoft.JScript.Runtime;

namespace Microsoft.JScript.Compiler
{
	/// <summary>
	/// what I understand is that class is mainly a translator from compiler ast to runtime ast
	/// </summary>
	public class RowanGenerator
	{
		public RowanGenerator(IdentifierMappingTable IDMappingTable, Identifier This, Identifier Underscore, Identifier Arguments, Identifier Eval)
		{
			idMappingTable = IDMappingTable;
			thisIdent = This;
			underscore = Underscore;
			arguments = Arguments;
			eval = Eval;
		}

		private IdentifierMappingTable idMappingTable;
		private	Identifier thisIdent;
		private	Identifier underscore;
		private	Identifier arguments;
		private	Identifier eval;

		public void Bind()
		{
			throw new NotImplementedException();
		}

		# region AST Converter

		public MSIA.Expression ConvertToObject(MSIA.Expression Value)
		{
			List<MSIA.Expression> Args = new List<MSIA.Expression>();
			Args.Add(new MSIA.CodeContextExpression());
			Args.Add(Value);
			MethodInfo met = typeof (Microsoft.JScript.Runtime.Convert).GetMethod ("ToObject");
			return new MSIA.MethodCallExpression (met, null, Args);
		}

		#region Expression

		public MSIA.Expression Generate(ParseTree.Expression Input)
		{
			MSIA.Expression result = null;
			if (Input == null)
				return null;
					
			switch (Input.Opcode) {

				case MJCP.Expression.Operation.SyntaxError :
					return null;//sample show null
				case MJCP.Expression.Operation.@this :
					result = new MSIA.BoundExpression (GetVarRef (thisIdent));
					break;
				case MJCP.Expression.Operation.@false :
					result = new MSIA.ConstantExpression (false);
					break;
				case MJCP.Expression.Operation.@true :
					result = new MSIA.ConstantExpression (true);
					break;
				case MJCP.Expression.Operation.Identifier :
						Identifier id = ((MJCP.IdentifierExpression)Input).ID;
						result = new MSIA.BoundExpression (GetVarRef (id));
						break;
				case MJCP.Expression.Operation.NumericLiteral :
					double val = 0;
					if (Double.TryParse (((MJCP.NumericLiteralExpression)Input).Spelling, out val)) {
						result = new MSIA.ConstantExpression (val);
					}
					break;
				case MJCP.Expression.Operation.HexLiteral :
					result = new MSIA.ConstantExpression (((MJCP.HexLiteralExpression)Input).Value);
					break;
				case MJCP.Expression.Operation.OctalLiteral :
					result = new MSIA.ConstantExpression (((MJCP.OctalLiteralExpression)Input).Value);
					break;
				case MJCP.Expression.Operation.RegularExpressionLiteral :
				//MethodCallExpression MakeRegex
				case MJCP.Expression.Operation.StringLiteral :
					result = new MSIA.ConstantExpression (((MJCP.StringLiteralExpression)Input).Value);
					break;
				case MJCP.Expression.Operation.ArrayLiteral :
				//MethodCallExpression ConstructArrayFromArrayLiteral
				case MJCP.Expression.Operation.ObjectLiteral :
				//MethodCallExpression ConstructObjectFromLiteral
				case MJCP.Expression.Operation.Parenthesized :
				//ParenthesisExpression 
				case MJCP.Expression.Operation.Invocation :
				//CallWithThisExpression or CallExpression
				case MJCP.Expression.Operation.Subscript :
				//ActionExpression
				case MJCP.Expression.Operation.Qualified :
				//ActionExpression
				case MJCP.Expression.Operation.@new :
					MSIA.Expression constructor = Generate (((MJCP.InvocationExpression)Input).Target);
					List<MSIA.Arg> args = new List<MSIA.Arg> ();
					foreach (MJCP.ExpressionListElement element in ((MJCP.InvocationExpression)Input).Arguments.Arguments)
						args.Add (MSIA.Arg.Simple (Generate(element.Value)));
					result = new MSIA.DynamicNewExpression (constructor, args.ToArray(), false, false, 0, 0);
					break;
				case MJCP.Expression.Operation.Function :
					result = GenerateFunction (((MJCP.FunctionExpression)Input).Function);
					break;
				case MJCP.Expression.Operation.delete :
				//MethodCallExpression Delete
				case MJCP.Expression.Operation.@void :
				//MethodCallExpression Void
				case MJCP.Expression.Operation.@typeof :
				//MethodCallExpression TypeOf
				case MJCP.Expression.Operation.PrefixPlusPlus :
					//
				case MJCP.Expression.Operation.PrefixMinusMinus :
					//
				case MJCP.Expression.Operation.PrefixPlus :
				//MethodCallExpression Positive
				case MJCP.Expression.Operation.PrefixMinus :
				//MethodCallExpression Negate
				case MJCP.Expression.Operation.Tilda :
				//MethodCallExpression OnesComplement
				case MJCP.Expression.Operation.Bang :
				//MethodCallExpression Not
				case MJCP.Expression.Operation.PostfixPlusPlus :
					//
				case MJCP.Expression.Operation.PostfixMinusMinus :
					//
				case MJCP.Expression.Operation.Comma :
				//CommaExpression
				case MJCP.Expression.Operation.Equal :
				//Boundassignment
				case MJCP.Expression.Operation.StarEqual :
				//Boundassignment
				case MJCP.Expression.Operation.DivideEqual :
				//Boundassignment
				case MJCP.Expression.Operation.PercentEqual :
				//Boundassignment
				case MJCP.Expression.Operation.PlusEqual :
				//Boundassignment
				case MJCP.Expression.Operation.MinusEqual:
				//Boundassignment
				case MJCP.Expression.Operation.LessLessEqual:
				//Boundassignment
				case MJCP.Expression.Operation.GreaterGreaterEqual:
				//Boundassignment
				case MJCP.Expression.Operation.GreaterGreaterGreaterEqual:
				//Boundassignment
				case MJCP.Expression.Operation.AmpersandEqual:
				//Boundassignment
				case MJCP.Expression.Operation.CircumflexEqual:
				//Boundassignment
				case MJCP.Expression.Operation.BarEqual:
				//Boundassignment
				case MJCP.Expression.Operation.BarBar :
					result = new MSIA.OrExpression (Generate (((MJCP.BinaryOperatorExpression)Input).Left), Generate (((MJCP.BinaryOperatorExpression)Input).Right), GetRowanTextSpan (Input.Location));
					break;
				case MJCP.Expression.Operation.AmpersandAmpersand :
					result = new MSIA.AndExpression (Generate (((MJCP.BinaryOperatorExpression)Input).Left), Generate (((MJCP.BinaryOperatorExpression)Input).Right), GetRowanTextSpan (Input.Location));
					break;
				case MJCP.Expression.Operation.Bar:
				//MethodCallExpression
				case MJCP.Expression.Operation.Circumflex:
				//MethodCallExpression
				case MJCP.Expression.Operation.Ampersand:
				//MethodCallExpression
				case MJCP.Expression.Operation.EqualEqual:
				//MethodCallExpression
				case MJCP.Expression.Operation.BangEqual:
				//MethodCallExpression
				case MJCP.Expression.Operation.EqualEqualEqual:
				//MethodCallExpression
				case MJCP.Expression.Operation.BangEqualEqual:
				//MethodCallExpression
				case MJCP.Expression.Operation.Less:
				//MethodCallExpression
				case MJCP.Expression.Operation.Greater:
				//MethodCallExpression
				case MJCP.Expression.Operation.LessEqual:
				//MethodCallExpression
				case MJCP.Expression.Operation.GreaterEqual:
				//MethodCallExpression
				case MJCP.Expression.Operation.instanceof:
				//MethodCallExpression InstanceOf
				case MJCP.Expression.Operation.@in:
				//MethodCallExpression In
				case MJCP.Expression.Operation.LessLess:
				//MethodCallExpression
				case MJCP.Expression.Operation.GreaterGreater:
				//MethodCallExpression
				case MJCP.Expression.Operation.GreaterGreaterGreater:
				//MethodCallExpression
				case MJCP.Expression.Operation.Plus:
				//MethodCallExpression
				case MJCP.Expression.Operation.Minus:
				//MethodCallExpression
				case MJCP.Expression.Operation.Star:
				//MethodCallExpression
				case MJCP.Expression.Operation.Divide:
				//MethodCallExpression
				case MJCP.Expression.Operation.Percent:
				//MethodCallExpression
				case MJCP.Expression.Operation.Question:
				//ConditionalExpression
				case MJCP.Expression.Operation.@null:
					return new MSIA.ConstantExpression (null);
					break;
			}
			/*MSIA.ActionExpression;
			MSIA.ArrayIndexExpression;
			MSIA.BinaryExpression;
			MSIA.CodeBlockExpression;
			MSIA.CodeContextExpression;
			MSIA.ConditionalExpression;
			MSIA.DynamicNewExpression;
			MSIA.EnvironmentExpression;
			MSIA.Expression;
			MSIA.IndexExpression;
			MSIA.MemberExpression;
			MSIA.MethodCallExpression;
			MSIA.NewArrayExpression;
			MSIA.ParamsExpression;
			MSIA.ParenthesisExpression;
			MSIA.ShortCircuitExpression;
			MSIA.StaticUnaryExpression;
			MSIA.ThrowExpression;
			MSIA.TypeBinaryExpression;
			MSIA.VoidExpression;*/
			
			result.SetLoc (GetRowanTextSpan (Input.Location));
			return result;
		}

		#endregion

		public MSIA.Statement Generate (ParseTree.FunctionDefinition Input)
		{
			MSIA.VariableReference vr = GetVarRef (Input.Name);
			MSIA.Expression val = GenerateFunction (Input);
			MSIA.BoundAssignment bound = new Microsoft.Scripting.Internal.Ast.BoundAssignment (vr, val, Operators.None);
			return new MSIA.ExpressionStatement (bound);
		}

		[MonoTODO ("fill all detail and complete test")]
		private MSIA.Expression GenerateFunction (ParseTree.FunctionDefinition Input)
		{
			MSIA.VariableReference vr = GetVarRef (Input.Name);
			List<MSIA.Expression> arguments = new List<MSIA.Expression> ();
			//TODO: a lot have to be found here
			arguments.Add (new MSIA.CodeContextExpression ());
			arguments.Add (new MSIA.ConstantExpression (Input.Name.Spelling));
			arguments.Add (new MSIA.ConstantExpression (-1));//must be something but not found for moment
			string name = "_";//TODO: find what is behind this or hardcoded?
			MSIA.Statement body = this.Generate (Input.Body);//must be that but not tested

			MSIA.CodeBlock block = new MSIA.CodeBlock (name, null, body);
			List<MSIA.Parameter> parameters = this.Generate (Input.Parameters, block);
			block.Parameters = parameters;
			arguments.Add (new MSIA.CodeBlockExpression (block, true));//true or false?
			List<MSIA.Expression> initializers = new List<MSIA.Expression> ();// TODO fill it
			arguments.Add (MSIA.NewArrayExpression.NewArrayInit (typeof (string[]), initializers));
			arguments.Add (new MSIA.ConstantExpression (true));
			arguments.Add (new MSIA.ConstantExpression (false));

			return new MSIA.MethodCallExpression (typeof (MJR.JSFunctionObject).GetMethod ("MakeFunction"), null, arguments);
		}

		private List<MSIA.Parameter> Generate (List<MJCP.Parameter> parameters, MSIA.CodeBlock block)
		{
			List<MSIA.Parameter> result = new List<MSIA.Parameter> ();
			foreach (MJCP.Parameter p in parameters)
				result.Add (MSIA.Parameter.Create (block, idMappingTable.GetRowanID (p.Name)));
			return result;
		}

		#region Statement

		public MSIA.BlockStatement Generate (DList<MJCP.Statement, MJCP.BlockStatement> Input, bool PrintExpressions)
		{
			DList<MJCP.Statement, MJCP.BlockStatement>.Iterator it = new DList<MJCP.Statement, MJCP.BlockStatement>.Iterator (Input);
			List<MSIA.Statement> statements = new List<MSIA.Statement> ();
			while (it.ElementAvailable) {
				statements.Add (Generate (it.Element, PrintExpressions));
				it.Advance ();
			}
			return new MSIA.BlockStatement (statements.ToArray ());

		}

		public MSIA.Statement Generate (ParseTree.Statement Input, bool PrintExpressions)
		{
			MSIA.Statement result;
			switch (Input.Opcode) {
				case MJCP.Statement.Operation.Block:
					result = GenerateBlockStatement ((MJCP.BlockStatement)Input);
					break;
				case MJCP.Statement.Operation.VariableDeclaration:
					result = GenerateVarDeclaration ((MJCP.VariableDeclarationStatement)Input);
					break;
				case MJCP.Statement.Operation.Empty:
					result = new MSIA.EmptyStatement ();
					break;
				case MJCP.Statement.Operation.Expression:
					result = GenerateExpressionStatement ((MJCP.ExpressionStatement)Input, PrintExpressions);
					break;
				case MJCP.Statement.Operation.If:
					result = GenerateIfStatement ((MJCP.IfStatement)Input);
					break;
				case MJCP.Statement.Operation.Do:
					result = GenerateDoStatement ((MJCP.DoStatement)Input);
					break;
				case MJCP.Statement.Operation.While:
					result = GenerateWhileStatement ((MJCP.WhileStatement)Input);
					break;
				case MJCP.Statement.Operation.ExpressionFor:
					result = GenerateExpressionForStatement ((MJCP.ForStatement)Input);
					break;
				case MJCP.Statement.Operation.DeclarationFor:
					result = GenerateDeclarationForStatement ((MJCP.DeclarationForStatement)Input);
					break;
				case MJCP.Statement.Operation.ExpressionForIn:
					result = GenerateForInStatement ((MJCP.ForInStatement)Input);
					break;
				case MJCP.Statement.Operation.DeclarationForIn:
					result = GenerateDeclarationForInStatement ((MJCP.DeclarationForInStatement)Input);
					break;
				case MJCP.Statement.Operation.Break:
					result = new MSIA.BreakStatement ();
					break;
				case MJCP.Statement.Operation.Continue:
					result = new MSIA.ContinueStatement ();
					break;
				case MJCP.Statement.Operation.Return:
					result = new MSIA.ReturnStatement (Generate (((MJCP.ReturnOrThrowStatement)Input).Value));
					break;
				case MJCP.Statement.Operation.Throw:
					result = new MSIA.ExpressionStatement (new MSIA.ThrowExpression (Generate (((MJCP.ReturnOrThrowStatement)Input).Value)));
					break;
				case MJCP.Statement.Operation.With:
					result = GenerateWithStatement ((MJCP.WithStatement)Input);
					break;
				case MJCP.Statement.Operation.Label:
					result = GenerateLabelStatement ((MJCP.LabelStatement)Input);
					break;
				case MJCP.Statement.Operation.Switch:
					result = GenerateSwitchStatement ((MJCP.SwitchStatement)Input);
					break;
				case MJCP.Statement.Operation.Try:
					result = GenerateTryStatement ((MJCP.TryStatement)Input);
					break;
				case MJCP.Statement.Operation.Function:
					result = GenerateFunctionStatement ((MJCP.FunctionStatement)Input);
					break;
				case MJCP.Statement.Operation.SyntaxError:
					return null;//my sample return null...
				default:
					throw new Exception ("Bad kind of statement to translate from compiler ast to runtime ast.");
			}
			return result;
		}

		public MSIA.Statement Generate (ParseTree.Statement Input)
		{
			return Generate (Input, false);
		}

		private MSIA.BlockStatement GenerateBlockStatement (MJCP.BlockStatement blockStatement)
		{
			DList<MJCP.Statement, MJCP.BlockStatement>.Iterator it = new DList<MJCP.Statement, MJCP.BlockStatement>.Iterator (blockStatement.Children);
			List<MSIA.Statement> statements = new List<MSIA.Statement> ();
			while (it.ElementAvailable){
				 MSIA.Statement statement = Generate (it.Element);
				 statements.Add (statement);
				 it.Advance ();
			}
			return new MSIA.BlockStatement (statements.ToArray());
		}

		private MSIA.Statement GenerateVarDeclaration (Microsoft.JScript.Compiler.ParseTree.VariableDeclarationStatement variableDeclarationStatement)
		{
			List<MSIA.Expression> expressions = new List<MSIA.Expression> ();
			foreach (MJCP.VariableDeclarationListElement element in variableDeclarationStatement.Declarations) {
				MSIA.VariableReference vr = GetVarRef (element.Declaration.Name);
				MSIA.Expression value = null;
				if (element.Declaration is MJCP.InitializerVariableDeclaration) {
					value = Generate (((MJCP.InitializerVariableDeclaration)element.Declaration).Initializer);
				}
				expressions.Add (new MSIA.BoundAssignment (vr, value, Operators.None));			
			}
			if (expressions.Count == 0)
				return new MSIA.EmptyStatement ();
			MSIA.CommaExpression exp = new MSIA.CommaExpression (expressions, expressions.Count - 1);
			return new MSIA.ExpressionStatement (exp);
		}

		[MonoTODO ("PrintExpressions is not used")]
		private MSIA.Statement GenerateExpressionStatement (MJCP.ExpressionStatement expressionStatement, bool PrintExpressions)
		{
			return new MSIA.ExpressionStatement (Generate (expressionStatement.Expression));
		}

		private MSIA.Statement GenerateIfStatement (MJCP.IfStatement ifStatement)
		{
			MSIA.Statement @else = Generate (ifStatement.ElseBody);
			List<MSIA.IfStatementTest> tests = new List<MSIA.IfStatementTest> ();
			tests.Add (new MSIA.IfStatementTest (Generate (ifStatement.Condition), Generate (ifStatement.IfBody)));
			//TODO strange to have list here maybe for elseif in other language
			return new MSIA.IfStatement (tests.ToArray(), @else);
		}

		private MSIA.Statement GenerateDoStatement (MJCP.DoStatement doStatement)
		{
			MSIA.Expression test = Generate (doStatement.Condition);
			MSIA.Statement body = Generate (doStatement.Body);
			SourceSpan span = GetRowanTextSpan (doStatement.Location);
			SourceLocation header = GetRowanStartLocation (doStatement.HeaderLocation);
			return new MSIA.DoStatement (test, body, span, header);
		}

		private MSIA.Statement GenerateWhileStatement (MJCP.WhileStatement whileStatement)
		{
			MSIA.Expression test = Generate (whileStatement.Condition);
			MSIA.Statement body = Generate (whileStatement.Body);
			SourceSpan span = GetRowanTextSpan (whileStatement.Location);
			SourceLocation header = GetRowanStartLocation (whileStatement.HeaderLocation);
			return new MSIA.LoopStatement (test, null, body, null, span, header);
		}

		private MSIA.Statement GenerateExpressionForStatement (MJCP.ForStatement forStatement)
		{
			//TODO unit test + inital somewhere
			MSIA.Expression test = Generate (forStatement.Condition);
			MSIA.Expression increment = Generate (forStatement.Increment);
			MSIA.Statement body = Generate (forStatement.Body);
			SourceSpan span = GetRowanTextSpan (forStatement.Location);
			SourceLocation header = GetRowanStartLocation (forStatement.HeaderLocation);
			return new MSIA.LoopStatement (test, increment, body, null, span, header);
		}

		private MSIA.Statement GenerateDeclarationForStatement (MJCP.DeclarationForStatement declarationForStatement)
		{
			//TODO unit test + inital somewhere
			MSIA.Expression test = Generate (declarationForStatement.Condition);
			MSIA.Expression increment = Generate (declarationForStatement.Increment);
			MSIA.Statement body = Generate (declarationForStatement.Body);
			SourceSpan span = GetRowanTextSpan (declarationForStatement.Location);
			SourceLocation header = GetRowanStartLocation (declarationForStatement.HeaderLocation);
			return new MSIA.LoopStatement (test, increment, body, null, span, header);
		}

		private MSIA.Statement GenerateForInStatement (MJCP.ForInStatement forInStatement)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private MSIA.Statement GenerateDeclarationForInStatement (MJCP.DeclarationForInStatement declarationForInStatement)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private MSIA.Statement GenerateWithStatement (MJCP.WithStatement withStatement)
		{
			return new MSIA.ScopeStatement (Generate (withStatement.Scope),Generate (withStatement.Body));
		}

		private MSIA.Statement GenerateLabelStatement (MJCP.LabelStatement labelStatement)
		{
			//TODO must use label somewhere maybe done a collection of label with statement
			//labelStatement.Label
			return new MSIA.LabeledStatement (Generate (labelStatement.Labeled));
		}

		private MSIA.Statement GenerateSwitchStatement (MJCP.SwitchStatement switchStatement)
		{
			MSIA.Expression testValue = Generate (switchStatement.Value);
			List<MSIA.SwitchCase> cases = new List<MSIA.SwitchCase>();
			DList<MJCP.CaseClause, MJCP.SwitchStatement>.Iterator it = new DList<MJCP.CaseClause, MJCP.SwitchStatement>.Iterator (switchStatement.Cases);
			while (it.ElementAvailable) {
				if ( it.Element is MJCP.ValueCaseClause)
					cases.Add(new MSIA.SwitchCase (Generate(((MJCP.ValueCaseClause)it.Element).Value), Generate (it.Element.Children)));
				else //default
					cases.Add (new MSIA.SwitchCase (null, Generate (it.Element.Children)));
				it.Advance ();
			}
			SourceSpan span = GetRowanTextSpan (switchStatement.Location);
			SourceLocation header = GetRowanStartLocation (switchStatement.HeaderLocation);
			return new MSIA.SwitchStatement (testValue, cases, span, header);
		}

		private MSIA.Statement Generate (DList<MJCP.Statement, MJCP.CaseClause> children)
		{
			List<MSIA.Statement> statements = new List<MSIA.Statement> ();
			DList<MJCP.Statement, MJCP.CaseClause>.Iterator it = new DList<MJCP.Statement, MJCP.CaseClause>.Iterator (children);
			while (it.ElementAvailable) {
				statements.Add (Generate (it.Element));
				it.Advance ();
			}
			return new MSIA.BlockStatement (statements.ToArray());
		}

		private MSIA.Statement GenerateTryStatement (MJCP.TryStatement tryStatement)
		{
			MSIA.Statement body = Generate (tryStatement.Block);
			List<MSIA.TryStatementHandler> handlers = new List<MSIA.TryStatementHandler> ();
			handlers.Add (new MSIA.TryStatementHandler(null, GetVarRef (tryStatement.Catch.Name), Generate(tryStatement.Catch.Handler)));
			MSIA.Statement finallySuite = Generate (tryStatement.Finally.Handler);
			SourceSpan span = GetRowanTextSpan (tryStatement.Location);
			return new MSIA.TryStatement (body, handlers.ToArray(), null, finallySuite, span, SourceLocation.None);
		}

		private MSIA.Statement GenerateFunctionStatement (MJCP.FunctionStatement functionStatement)
		{
			return Generate (functionStatement.Function);
		}

		#endregion

		#endregion

		#region Location Converter

		public static SourceLocation GetRowanEndLocation(TextSpan Location)
		{
			return new SourceLocation (Location.EndPosition, Location.EndLine, Location.EndColumn);
		}

		public static SourceLocation GetRowanStartLocation(TextSpan Location)
		{
			return new SourceLocation (Location.StartPosition, Location.StartLine, Location.StartColumn);
		}

		public static SourceSpan GetRowanTextSpan(TextSpan Location)
		{
			return GetRowanTextSpan (Location, Location);
		}

		public static SourceSpan GetRowanTextSpan(TextSpan StartLocation, TextSpan EndLocation)
		{
			return new SourceSpan (GetRowanStartLocation (StartLocation), GetRowanEndLocation (EndLocation));
		}

		#endregion

		//TODO : find the use of this!
		//maybe a main codeblock where all generated code is put
		public void SetGlobals(MSIA.CodeBlock Globals)
		{
			throw new NotImplementedException();
		}

		#region helpers

		private MSIA.VariableReference GetVarRef (Identifier ID)
		{
			return new MSIA.VariableReference (idMappingTable.GetRowanID (ID));
		}

		#endregion
	}
}
