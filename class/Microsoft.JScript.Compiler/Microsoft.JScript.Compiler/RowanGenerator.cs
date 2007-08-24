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
			MSIA.Expression result;
			if (Input == null)
				return null;
					
			switch (Input.Opcode) {

				case MJCP.Expression.Operation.SyntaxError :
				case MJCP.Expression.Operation.@this :
				case MJCP.Expression.Operation.@false :
					result = new MSIA.ConstantExpression (false);
					break;
				case MJCP.Expression.Operation.@true :
					result = new MSIA.ConstantExpression (true);
					break;
				case MJCP.Expression.Operation.Identifier :
						Identifier id = ((MJCP.IdentifierExpression)Input).ID;
						result = new MSIA.BoundExpression (new MSIA.VariableReference (idMappingTable.GetRowanID (id)));
						break;
				case MJCP.Expression.Operation.NumericLiteral :
				case MJCP.Expression.Operation.HexLiteral :
				case MJCP.Expression.Operation.OctalLiteral :
				case MJCP.Expression.Operation.RegularExpressionLiteral :
				case MJCP.Expression.Operation.StringLiteral :
				case MJCP.Expression.Operation.ArrayLiteral :
				case MJCP.Expression.Operation.ObjectLiteral :
				case MJCP.Expression.Operation.Parenthesized :
				case MJCP.Expression.Operation.Invocation :
				case MJCP.Expression.Operation.Subscript :
				case MJCP.Expression.Operation.Qualified :
				case MJCP.Expression.Operation.@new :
				case MJCP.Expression.Operation.Function :
				case MJCP.Expression.Operation.delete :
				case MJCP.Expression.Operation.@void :
				case MJCP.Expression.Operation.@typeof :
				case MJCP.Expression.Operation.PrefixPlusPlus :
				case MJCP.Expression.Operation.PrefixMinusMinus :
				case MJCP.Expression.Operation.PrefixPlus :
				case MJCP.Expression.Operation.PrefixMinus :
				case MJCP.Expression.Operation.Tilda :
				case MJCP.Expression.Operation.Bang :
				case MJCP.Expression.Operation.PostfixPlusPlus :
				case MJCP.Expression.Operation.PostfixMinusMinus :
				case MJCP.Expression.Operation.Comma :
				case MJCP.Expression.Operation.Equal :
				case MJCP.Expression.Operation.StarEqual :
				case MJCP.Expression.Operation.DivideEqual :
				case MJCP.Expression.Operation.PercentEqual :
				case MJCP.Expression.Operation.PlusEqual :
				case MJCP.Expression.Operation.MinusEqual :
				case MJCP.Expression.Operation.LessLessEqual :
				case MJCP.Expression.Operation.GreaterGreaterEqual :
				case MJCP.Expression.Operation.GreaterGreaterGreaterEqual :
				case MJCP.Expression.Operation.AmpersandEqual :
				case MJCP.Expression.Operation.CircumflexEqual :
				case MJCP.Expression.Operation.BarEqual :
				case MJCP.Expression.Operation.BarBar :
				case MJCP.Expression.Operation.AmpersandAmpersand :
				case MJCP.Expression.Operation.Bar :
				case MJCP.Expression.Operation.Circumflex :
				case MJCP.Expression.Operation.Ampersand :
				case MJCP.Expression.Operation.EqualEqual :
				case MJCP.Expression.Operation.BangEqual :
				case MJCP.Expression.Operation.EqualEqualEqual :
				case MJCP.Expression.Operation.BangEqualEqual :
				case MJCP.Expression.Operation.Less :
				case MJCP.Expression.Operation.Greater :
				case MJCP.Expression.Operation.LessEqual :
				case MJCP.Expression.Operation.GreaterEqual :
				case MJCP.Expression.Operation.instanceof :
				case MJCP.Expression.Operation.@in :
				case MJCP.Expression.Operation.LessLess :
				case MJCP.Expression.Operation.GreaterGreater :
				case MJCP.Expression.Operation.GreaterGreaterGreater :
				case MJCP.Expression.Operation.Plus :
				case MJCP.Expression.Operation.Minus :
				case MJCP.Expression.Operation.Star :
				case MJCP.Expression.Operation.Divide :
				case MJCP.Expression.Operation.Percent :
				case MJCP.Expression.Operation.Question :
				case MJCP.Expression.Operation.@null:
					break;
			}
			/*MSIA.ActionExpression;
			MSIA.AndExpression;
			MSIA.ArrayIndexExpression;
			MSIA.BinaryExpression;
			MSIA.BoundExpression;
			MSIA.CallExpression;
			MSIA.CallWithThisExpression;
			MSIA.CodeBlockExpression;
			MSIA.CodeContextExpression;
			MSIA.CommaExpression;
			MSIA.ConditionalExpression;
			MSIA.ConstantExpression;
			MSIA.DeleteDynamicMemberExpression;
			MSIA.DeleteIndexExpression;
			MSIA.DynamicNewExpression;
			MSIA.EnvironmentExpression;
			MSIA.Expression;
			MSIA.IndexExpression;
			MSIA.MemberExpression;
			MSIA.MethodCallExpression;
			MSIA.NewArrayExpression;
			MSIA.NewExpression;
			MSIA.OrExpression;
			MSIA.ParamsExpression;
			MSIA.ParenthesisExpression;
			MSIA.ShortCircuitExpression;
			MSIA.StaticUnaryExpression;
			MSIA.ThrowExpression;
			MSIA.TypeBinaryExpression;
			MSIA.VoidExpression;*/
			
			//result.SetLoc (GetRowanTextSpan (Input.Location));
			return null;
		}

		#endregion

		public MSIA.Statement Generate (ParseTree.FunctionDefinition Input)
		{
			throw new NotImplementedException();
		}

		#region Statement

		public MSIA.Statement Generate (ParseTree.Statement Input)
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
					result = GenerateEmpty (Input);
					break;
				case MJCP.Statement.Operation.Expression:
					result = GenerateExpressionStatement ((MJCP.ExpressionStatement)Input);
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
					result = GenerateForStatement ((MJCP.ForStatement)Input);
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
				case MJCP.Statement.Operation.Continue:
					result = GenerateBreakOrContinueStatement ((MJCP.BreakOrContinueStatement)Input);
					break;
				case MJCP.Statement.Operation.Return:
				case MJCP.Statement.Operation.Throw:
					result = GenerateReturnOrThrowStatement ((MJCP.ReturnOrThrowStatement)Input);
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
					result = GenerateSyntaxErrorStatement (Input);
					break;
				default:
					throw new Exception ("Bad kind of statement to translate from compiler ast to runtime ast.");
			}
			return result;
		}

		private MSIA.Statement GenerateVarDeclaration (Microsoft.JScript.Compiler.ParseTree.VariableDeclarationStatement variableDeclarationStatement)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private MSIA.Statement GenerateEmpty (Microsoft.JScript.Compiler.ParseTree.Statement Input)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private MSIA.Statement GenerateExpressionStatement (Microsoft.JScript.Compiler.ParseTree.ExpressionStatement expressionStatement)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private MSIA.Statement GenerateIfStatement (Microsoft.JScript.Compiler.ParseTree.IfStatement ifStatement)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private MSIA.Statement GenerateDoStatement (Microsoft.JScript.Compiler.ParseTree.DoStatement doStatement)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private MSIA.Statement GenerateWhileStatement (Microsoft.JScript.Compiler.ParseTree.WhileStatement whileStatement)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private MSIA.Statement GenerateForStatement (Microsoft.JScript.Compiler.ParseTree.ForStatement forStatement)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private MSIA.Statement GenerateDeclarationForStatement (Microsoft.JScript.Compiler.ParseTree.DeclarationForStatement declarationForStatement)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private MSIA.Statement GenerateForInStatement (Microsoft.JScript.Compiler.ParseTree.ForInStatement forInStatement)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private MSIA.Statement GenerateDeclarationForInStatement (Microsoft.JScript.Compiler.ParseTree.DeclarationForInStatement declarationForInStatement)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private MSIA.Statement GenerateBreakOrContinueStatement (Microsoft.JScript.Compiler.ParseTree.BreakOrContinueStatement breakOrContinueStatement)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private MSIA.Statement GenerateReturnOrThrowStatement (Microsoft.JScript.Compiler.ParseTree.ReturnOrThrowStatement returnOrThrowStatement)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private MSIA.Statement GenerateWithStatement (Microsoft.JScript.Compiler.ParseTree.WithStatement withStatement)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private MSIA.Statement GenerateLabelStatement (Microsoft.JScript.Compiler.ParseTree.LabelStatement labelStatement)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private MSIA.Statement GenerateSwitchStatement (Microsoft.JScript.Compiler.ParseTree.SwitchStatement switchStatement)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private MSIA.Statement GenerateTryStatement (Microsoft.JScript.Compiler.ParseTree.TryStatement tryStatement)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private MSIA.Statement GenerateFunctionStatement (Microsoft.JScript.Compiler.ParseTree.FunctionStatement functionStatement)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private MSIA.Statement GenerateSyntaxErrorStatement (Microsoft.JScript.Compiler.ParseTree.Statement Input)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private MSIA.BlockStatement GenerateBlockStatement (MJCP.BlockStatement blockStatement)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		#endregion

		public MSIA.BlockStatement Generate(DList<ParseTree.Statement, ParseTree.BlockStatement> Input, bool PrintExpressions)
		{
			throw new NotImplementedException();
		}

		public MSIA.Statement Generate (ParseTree.Statement Input, bool PrintExpressions)
		{
			throw new NotImplementedException();
		}

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

	}
}
