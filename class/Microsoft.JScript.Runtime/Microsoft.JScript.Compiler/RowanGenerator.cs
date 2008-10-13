//
// RowanGenerator
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
using MSA = Microsoft.Scripting.Ast;
using MJCP = Microsoft.JScript.Compiler.ParseTree;
using MJR = Microsoft.JScript.Runtime;
using MSAc = Microsoft.Scripting.Actions;
using MSO = Microsoft.Scripting.Operators;
using Microsoft.JScript.Runtime;
using Microsoft.JScript.Compiler;

namespace Microsoft.JScript.Compiler
{
	/// <summary>
	/// what I understand is that class is mainly a translator from compiler ast to runtime ast
	/// </summary>
	public class RowanGenerator
	{
		public RowanGenerator(IdentifierMappingTable IDMappingTable, Identifier This, Identifier Arguments)
		{
			idMappingTable = IDMappingTable;
			thisIdent = This;
			arguments = Arguments;
			Init ();
		}

		private IdentifierMappingTable idMappingTable;
		private Identifier thisIdent;
		private Identifier arguments;
		private int withinFunction;//TODO make a queue to have the last function
		private MSA.CodeBlock globalBlock;
		
		/*public void Bind()
		{
			throw new NotImplementedException();
		}*/
		
		public MSA.CodeBlock BindAndTransform (MJCP.Expression expression, MJCP.BindingInfo bindingInfo)
		{
			Init ();
			//TODO test to know the internal of this and know the use of bindinginfo
			globalBlock.Body = MSA.Ast.Block (Generate (expression));
			return globalBlock;
		}

		public MSA.CodeBlock BindAndTransform (DList<MJCP.Statement, MJCP.BlockStatement> statements, MJCP.BindingInfo bindingInfo, bool Print)
		{
			Init ();
			//TODO test to know the internal of this and know the use of bindinginfo
			globalBlock.Body = MSA.Ast.Block (Generate (statements, bindingInfo, Print));
			return globalBlock;
		}

		private void Init ()
		{
			globalBlock = Microsoft.Scripting.Ast.Ast.CodeBlock ("");
			globalBlock.IsGlobal = true;
			withinFunction = 0;
		}
		# region AST Converter

		private MSA.Expression ConvertToObject(MSA.Expression Value)
		{
			List<MSA.Expression> Args = new List<MSA.Expression>();
			Args.Add(MSA.Ast.CodeContext ());
			Args.Add(Value);
			MethodInfo met = typeof (Microsoft.JScript.Runtime.Convert).GetMethod ("ToObject");
			return MSA.Ast.Call (met, Args.ToArray());
		}

		#region Expression

		private MSA.Expression Generate(MJCP.Expression Input)
		{
			Init ();
			MSA.Expression result = null;
			if (Input == null)
				return null;
			List<MSA.Expression> arguments;
			List<MSA.Expression> initializers;
			MSA.Expression right;

			MJCP.BinaryOperatorExpression binOp;
			switch (Input.Opcode) {

				case MJCP.Expression.Operation.SyntaxError :
					return null;//sample show null
				case MJCP.Expression.Operation.@this :
					//TODO this must not be a variable!
					if (withinFunction > 1)//if this is call inside a function
						result = MSA.Ast.Read (globalBlock.CreateVariable (GetSymbolId(thisIdent), MSA.Variable.VariableKind.Global, null));
					else {//if this is call ouside of function
						arguments = new List<MSA.Expression> ();
						arguments.Add (MSA.Ast.CodeContext ());
						result = MSA.Ast.Call (typeof (MJR.JSOps).GetMethod ("GetGlobalObject"), arguments.ToArray ());
					}
					break;
				case MJCP.Expression.Operation.@false :
					result = MSA.Ast.False ();
					break;
				case MJCP.Expression.Operation.@true :
					result = MSA.Ast.True ();
					break;
				case MJCP.Expression.Operation.Identifier :
						Identifier id = ((MJCP.IdentifierExpression)Input).ID;//TODO make a tree of variable and allow to get it 
						result = MSA.Ast.Read (globalBlock.CreateVariable (GetSymbolId(id), MSA.Variable.VariableKind.Global, null));
						break;
				case MJCP.Expression.Operation.NumericLiteral :
					double val = 0;
					try {
						val = Double.Parse (((MJCP.NumericLiteralExpression)Input).Spelling);
						result = MSA.Ast.Constant (val);
					} catch {
						//TODO 
					}
					break;
				case MJCP.Expression.Operation.HexLiteral :
					result = MSA.Ast.Constant (((MJCP.HexLiteralExpression)Input).Value);
					break;
				case MJCP.Expression.Operation.OctalLiteral :
					result = MSA.Ast.Constant (((MJCP.OctalLiteralExpression)Input).Value);
					break;
				case MJCP.Expression.Operation.RegularExpressionLiteral :
					//TODO
					throw new NotImplementedException ();
				case MJCP.Expression.Operation.StringLiteral :
					result = MSA.Ast.Constant (((MJCP.StringLiteralExpression)Input).Value);
					break;
				case MJCP.Expression.Operation.ArrayLiteral :
					arguments = new List<MSA.Expression> ();
					
					arguments.Add (MSA.Ast.CodeContext ());

					initializers =new List<MSA.Expression> ();
					foreach (MJCP.ExpressionListElement element in ((MJCP.ArrayLiteralExpression)Input).Elements)
							initializers.Add (Generate (element.Value));
					arguments.Add (MSA.Ast.NewArray (typeof (object []), initializers));

					result = MSA.Ast.Call (typeof (MJR.JSCompilerHelpers).GetMethod ("ConstructArrayFromArrayLiteral"), arguments.ToArray ());
					break;
				case MJCP.Expression.Operation.ObjectLiteral :
					arguments = new List<MSA.Expression> ();

					arguments.Add (MSA.Ast.CodeContext ());
					
					initializers = new List<MSA.Expression> ();
					List<MSA.Expression> initializers2 = new List<MSA.Expression> ();
					foreach (MJCP.ObjectLiteralElement element in ((MJCP.ObjectLiteralExpression)Input).Elements) {
						initializers.Add (Generate (element.Name));
						initializers2.Add (Generate (element.Value));
					}
					arguments.Add (MSA.Ast.NewArray (typeof (object[]), initializers));
					arguments.Add (MSA.Ast.NewArray (typeof (object[]), initializers2));

					result = MSA.Ast.Call (typeof (MJR.JSCompilerHelpers).GetMethod ("ConstructObjectFromLiteral"), arguments.ToArray ());
					break;
				case MJCP.Expression.Operation.Parenthesized :
					result = Generate (((MJCP.UnaryOperatorExpression)Input).Operand); 
					break;
				case MJCP.Expression.Operation.Invocation :
					arguments = new List<MSA.Expression> ();
					//TODO fill arguments
					//args = new List<MSA.Arg> ();
					foreach (MJCP.ExpressionListElement element in ((MJCP.InvocationExpression)Input).Arguments.Arguments)
						arguments.Add (Generate (element.Value));
					
					MSA.Expression instance = Generate (((MJCP.InvocationExpression)Input).Target);
					//(Expression instance,) MethodInfo method, params Expression[] arguments
					//TODO MethodInfo!
					result = MSA.Ast.Call (instance, null, arguments.ToArray ());
					break;
				case MJCP.Expression.Operation.Subscript :
					arguments = new List<MSA.Expression> ();
					//TODO fill arguments and type result
					result = MSA.Ast.Action.Operator (MSO.GetItem, null, arguments.ToArray());
					break;
				case MJCP.Expression.Operation.Qualified :
					arguments = new List<MSA.Expression> ();
					//TODO fill arguments and type result
					result = MSA.Ast.Action.GetMember (GetSymbolId (((MJCP.QualifiedExpression)Input).Qualifier), null, arguments.ToArray());
					break;
				case MJCP.Expression.Operation.@new :
					MSA.Expression constructor = Generate (((MJCP.InvocationExpression)Input).Target);
					arguments = new List<MSA.Expression> ();
					foreach (MJCP.ExpressionListElement element in ((MJCP.InvocationExpression)Input).Arguments.Arguments)
						arguments.Add (Generate(element.Value));
					//todo fill the type result
					result = MSA.Ast.Action.Create (null, arguments.ToArray());
					break;
				case MJCP.Expression.Operation.Function :
					result = GenerateFunction (((MJCP.FunctionExpression)Input).Function);
					//the statement and expression is not the same
					result = MSA.Ast.Assign (GetVar (((MJCP.FunctionExpression)Input).Function.Name), result);
					break;
				case MJCP.Expression.Operation.delete :
					arguments = new List<MSA.Expression> ();
					//TODO fill arguments
					result = MSA.Ast.Call (typeof (MJR.JSCompilerHelpers).GetMethod ("Delete"), arguments.ToArray ());
					break;
				case MJCP.Expression.Operation.@void :
					arguments = new List<MSA.Expression> ();
					//TODO fill arguments
					result = MSA.Ast.Call (typeof (MJR.JSCompilerHelpers).GetMethod ("Void"), arguments.ToArray ());
					break;
				case MJCP.Expression.Operation.@typeof :
					arguments = new List<MSA.Expression> ();
					//TODO fill arguments
					result = MSA.Ast.Call (typeof (MJR.JSCompilerHelpers).GetMethod ("TypeOf"), arguments.ToArray ());
					break;
				case MJCP.Expression.Operation.PrefixPlusPlus :
					//
					break;
				case MJCP.Expression.Operation.PrefixMinusMinus :
					//
					break;
				case MJCP.Expression.Operation.PrefixPlus :
					arguments = new List<MSA.Expression> ();
					//TODO fill arguments
					result = MSA.Ast.Call (typeof (MJR.JSCompilerHelpers).GetMethod ("Positive"), arguments.ToArray());
					break;
				case MJCP.Expression.Operation.PrefixMinus :
					arguments = new List<MSA.Expression> ();
					//TODO fill arguments
					result = MSA.Ast.Call (typeof (MJR.JSCompilerHelpers).GetMethod ("Negate"), arguments.ToArray());
					break;
				case MJCP.Expression.Operation.Tilda :
					arguments = new List<MSA.Expression> ();
					//TODO fill arguments
					result = MSA.Ast.Call (typeof (MJR.JSCompilerHelpers).GetMethod ("OnesComplement"), arguments.ToArray());
					break;
				case MJCP.Expression.Operation.Bang :
					arguments = new List<MSA.Expression> ();
					//TODO fill arguments
					result = MSA.Ast.Call (typeof (MJR.JSCompilerHelpers).GetMethod ("Not"), arguments.ToArray());
					break;
				case MJCP.Expression.Operation.PostfixPlusPlus :
					//TODO
					break;
				case MJCP.Expression.Operation.PostfixMinusMinus :
					MJCP.UnaryOperatorExpression expr = (MJCP.UnaryOperatorExpression)Input;
					//TODO
					break;
				case MJCP.Expression.Operation.Comma :
					binOp = (MJCP.BinaryOperatorExpression)Input;
					arguments = new List<MSA.Expression> ();
					arguments.Add (Generate (binOp.Left));
					arguments.Add (Generate (binOp.Right));
					result = MSA.Ast.Comma (arguments);
					break;
				case MJCP.Expression.Operation.Equal :
					binOp = (MJCP.BinaryOperatorExpression)Input;
					result = GenerateBoundAssignment (binOp.Left, binOp.Right);
					break;
				case MJCP.Expression.Operation.StarEqual :
					binOp = (MJCP.BinaryOperatorExpression)Input;
					right = MSA.Ast.Multiply (Generate(binOp.Left), Generate(binOp.Right));
					result = GenerateBoundAssignment (binOp.Left, right);
					break;
				case MJCP.Expression.Operation.DivideEqual :
					binOp = (MJCP.BinaryOperatorExpression)Input;
					right = MSA.Ast.Multiply (Generate(binOp.Left), Generate(binOp.Right));
					result = GenerateBoundAssignment (binOp.Left, right);
					break;
				case MJCP.Expression.Operation.PercentEqual :
					binOp = (MJCP.BinaryOperatorExpression)Input;
					right = MSA.Ast.Modulo (Generate(binOp.Left), Generate(binOp.Right));
					result = GenerateBoundAssignment (binOp.Left, right);
					break;
				case MJCP.Expression.Operation.PlusEqual :
					binOp = (MJCP.BinaryOperatorExpression)Input;
					right = MSA.Ast.Add (Generate(binOp.Left), Generate(binOp.Right));
					result = GenerateBoundAssignment (binOp.Left, right);
					break;
				case MJCP.Expression.Operation.MinusEqual:
					binOp = (MJCP.BinaryOperatorExpression)Input;
					right = MSA.Ast.Subtract (Generate(binOp.Left), Generate(binOp.Right));
					result = GenerateBoundAssignment (binOp.Left, right);
					break;
				case MJCP.Expression.Operation.LessLessEqual:
					binOp = (MJCP.BinaryOperatorExpression)Input;
					right = MSA.Ast.LeftShift (Generate(binOp.Left), Generate(binOp.Right));
					result = GenerateBoundAssignment (binOp.Left, right);
					break;
				case MJCP.Expression.Operation.GreaterGreaterEqual:
					binOp = (MJCP.BinaryOperatorExpression)Input;
					right = MSA.Ast.RightShift (Generate(binOp.Left), Generate(binOp.Right));
					result = GenerateBoundAssignment (binOp.Left, right);
					break;
				case MJCP.Expression.Operation.GreaterGreaterGreaterEqual:
					binOp = (MJCP.BinaryOperatorExpression)Input;//TODO right shift unsigned
					right = MSA.Ast.RightShift (Generate(binOp.Left), Generate(binOp.Right));
					result = GenerateBoundAssignment (binOp.Left, right);
					break;
				case MJCP.Expression.Operation.AmpersandEqual:
					binOp = (MJCP.BinaryOperatorExpression)Input;
					right = MSA.Ast.And (Generate(binOp.Left), Generate(binOp.Right));
					result = GenerateBoundAssignment (binOp.Left, right);
					break;
				case MJCP.Expression.Operation.CircumflexEqual:
					binOp = (MJCP.BinaryOperatorExpression)Input;
					right = MSA.Ast.ExclusiveOr (Generate(binOp.Left), Generate(binOp.Right));
					result = GenerateBoundAssignment (binOp.Left, right);
					break;
				case MJCP.Expression.Operation.BarEqual:
					binOp = (MJCP.BinaryOperatorExpression)Input;
					right = MSA.Ast.Or (Generate(binOp.Left), Generate(binOp.Right));
					result = GenerateBoundAssignment (binOp.Left, right);
					break;
				case MJCP.Expression.Operation.BarBar :
					result = MSA.Ast.OrElse (Generate (((MJCP.BinaryOperatorExpression)Input).Left), Generate (((MJCP.BinaryOperatorExpression)Input).Right));
					break;
				case MJCP.Expression.Operation.AmpersandAmpersand :
					result = MSA.Ast.AndAlso (Generate (((MJCP.BinaryOperatorExpression)Input).Left), Generate (((MJCP.BinaryOperatorExpression)Input).Right));
					break;
				case MJCP.Expression.Operation.Bar:
					binOp = (MJCP.BinaryOperatorExpression)Input;
					result = MSA.Ast.Or (Generate(binOp.Left), Generate(binOp.Right));
					break;
				case MJCP.Expression.Operation.Circumflex:
					binOp = (MJCP.BinaryOperatorExpression)Input;
					result = MSA.Ast.ExclusiveOr (Generate(binOp.Left), Generate(binOp.Right));
					break;
				case MJCP.Expression.Operation.Ampersand:
					binOp = (MJCP.BinaryOperatorExpression)Input;
					result = MSA.Ast.And (Generate(binOp.Left), Generate(binOp.Right));
					break;
				case MJCP.Expression.Operation.EqualEqual:
					binOp = (MJCP.BinaryOperatorExpression)Input;
					result = MSA.Ast.Equal (Generate(binOp.Left), Generate(binOp.Right));
					break;
				case MJCP.Expression.Operation.BangEqual:
					binOp = (MJCP.BinaryOperatorExpression)Input;
					result = MSA.Ast.NotEqual (Generate(binOp.Left), Generate(binOp.Right));
					break;
				case MJCP.Expression.Operation.EqualEqualEqual:
					arguments = new List<MSA.Expression> ();
					//TODO fill arguments
					result = MSA.Ast.Call (typeof (MJR.JSCompilerHelpers).GetMethod ("Is"), arguments.ToArray());
					break;
				case MJCP.Expression.Operation.BangEqualEqual:
					arguments = new List<MSA.Expression> ();
					//TODO fill arguments
					result = MSA.Ast.Call (typeof (MJR.JSCompilerHelpers).GetMethod ("IsNot"), arguments.ToArray());
					break;
				case MJCP.Expression.Operation.Less:
					binOp = (MJCP.BinaryOperatorExpression)Input;
					result = MSA.Ast.LessThan (Generate(binOp.Left), Generate(binOp.Right));
					break;
				case MJCP.Expression.Operation.Greater:
					binOp = (MJCP.BinaryOperatorExpression)Input;
					result = MSA.Ast.GreaterThan (Generate(binOp.Left), Generate(binOp.Right));
					break;
				case MJCP.Expression.Operation.LessEqual:
					binOp = (MJCP.BinaryOperatorExpression)Input;
					result = MSA.Ast.LessThanEquals (Generate(binOp.Left), Generate(binOp.Right));
					break;
				case MJCP.Expression.Operation.GreaterEqual:
					binOp = (MJCP.BinaryOperatorExpression)Input;
					result = MSA.Ast.GreaterThanEquals (Generate(binOp.Left), Generate(binOp.Right));
					break;
				case MJCP.Expression.Operation.instanceof:
					arguments = new List<MSA.Expression> ();
					//TODO fill arguments
					result = MSA.Ast.Call (typeof (MJR.JSCompilerHelpers).GetMethod ("InstanceOf"), arguments.ToArray());
					break;
				case MJCP.Expression.Operation.@in:
					arguments = new List<MSA.Expression> ();
					//TODO fill arguments
					result = MSA.Ast.Call (typeof (MJR.JSCompilerHelpers).GetMethod ("In"), arguments.ToArray());
					break;
				case MJCP.Expression.Operation.LessLess:
					binOp = (MJCP.BinaryOperatorExpression)Input;
					result = MSA.Ast.LeftShift (Generate(binOp.Left), Generate(binOp.Right));
					break;
				case MJCP.Expression.Operation.GreaterGreater:
					binOp = (MJCP.BinaryOperatorExpression)Input;
					result = MSA.Ast.RightShift (Generate(binOp.Left), Generate(binOp.Right));
					break;
				case MJCP.Expression.Operation.GreaterGreaterGreater:
					arguments = new List<MSA.Expression> ();
					arguments.Add (Generate (((MJCP.BinaryOperatorExpression)Input).Left));
					arguments.Add (Generate (((MJCP.BinaryOperatorExpression)Input).Right));
					//TODO type result
					result = MSA.Ast.Action.Operator (MSO.RightShiftUnsigned, null, arguments.ToArray());
					break;
				case MJCP.Expression.Operation.Plus:
					binOp = (MJCP.BinaryOperatorExpression)Input;
					result = MSA.Ast.Add (Generate(binOp.Left), Generate(binOp.Right));
					break;
				case MJCP.Expression.Operation.Minus:
					binOp = (MJCP.BinaryOperatorExpression)Input;
					result = MSA.Ast.Subtract (Generate(binOp.Left), Generate(binOp.Right));
					break;
				case MJCP.Expression.Operation.Star:
					binOp = (MJCP.BinaryOperatorExpression)Input;
					result = MSA.Ast.Multiply (Generate(binOp.Left), Generate(binOp.Right));
					break;
				case MJCP.Expression.Operation.Divide:
					binOp = (MJCP.BinaryOperatorExpression)Input;
					result = MSA.Ast.Divide (Generate(binOp.Left), Generate(binOp.Right));
					break;
				case MJCP.Expression.Operation.Percent:
					binOp = (MJCP.BinaryOperatorExpression)Input;
					result = MSA.Ast.Modulo (Generate(binOp.Left), Generate(binOp.Right));
					break;
				case MJCP.Expression.Operation.Question:
					result = MSA.Ast.Condition (Generate (((MJCP.TernaryOperatorExpression)Input).First),
						Generate (((MJCP.TernaryOperatorExpression)Input).Second),
						Generate (((MJCP.TernaryOperatorExpression)Input).Third));
					break;
				case MJCP.Expression.Operation.@null:
					result = MSA.Ast.Null ();
					break;
			}
			//seems to have disappear now
			//result.SetLoc (GetRowanTextSpan (Input.Location));
			return result;
		}
		
		private MSA.Expression GenerateBoundAssignment (MJCP.Expression left, MSA.Expression right)
		{
			//todo see BoundAssignment Ast partial Write and Assign 
			if (left is MJCP.IdentifierExpression)
				return MSA.Ast.Assign (GetVar (((MJCP.IdentifierExpression)left).ID), right);
			else if(left.Opcode == MJCP.Expression.Operation.Parenthesized)
				return GenerateBoundAssignment(((MJCP.UnaryOperatorExpression)left).Operand, right);
			else if (left.Opcode == MJCP.Expression.Operation.Qualified)
				return MSA.Ast.Assign (GetVar (((MJCP.QualifiedExpression)left).Qualifier), right);
			
			throw new Exception ("can not be assigned!" + left.Opcode.ToString());
		}
		
		private MSA.Expression GenerateBoundAssignment (MJCP.Expression left, MJCP.Expression right)
		{
			return GenerateBoundAssignment (left, Generate (right));
		}

		#endregion
				
		private MSA.Expression Generate (MJCP.FunctionDefinition Input)
		{
			MSA.Variable v = GetVar (Input.Name);
			MSA.Expression val = GenerateFunction (Input);
			MSA.BoundAssignment bound = MSA.Ast.Assign (v, val);
			return MSA.Ast.Statement (bound);
		}

		//[MonoTODO ("fill all detail and complete test")]
		private MSA.Expression GenerateFunction (MJCP.FunctionDefinition Input)
		{
			MSA.Variable vr = GetVar (Input.Name);
			List<MSA.Expression> arguments = new List<MSA.Expression> ();
			//TODO: a lot have to be found here
			arguments.Add (MSA.Ast.CodeContext ());
			arguments.Add (MSA.Ast.Constant (Input.Name.Spelling));
			arguments.Add (MSA.Ast.Constant (-1));//must be something but not found for moment
			string name = "_";//TODO: find what is behind this or hardcoded?
			withinFunction++;
			//TODO best is to do a node system or a queue if needed to get the function
			//I think I will have to do that for variable system 
			MSA.Expression body = this.Generate (Input.Body);//must be that but not tested
			withinFunction--;
			MSA.CodeBlock block = MSA.Ast.CodeBlock (name);
			block.Parent= globalBlock;
			block.Body = body;
			List<MSA.Variable> parameters = this.Generate (Input.Parameters, block);
			arguments.Add (MSA.Ast.CodeBlockExpression (block, false));//TODO maybe use other ones with more 
			List<MSA.Expression> initializers = new List<MSA.Expression> ();// TODO fill it
			arguments.Add (MSA.Ast.NewArray (typeof (string[]), initializers));
			arguments.Add (MSA.Ast.Constant (true));
			arguments.Add (MSA.Ast.Constant (false));

			return MSA.Ast.Call (typeof (MJR.JSFunctionObject).GetMethod ("MakeFunction"), arguments.ToArray());
		}

		private List<MSA.Variable> Generate (List<MJCP.Parameter> parameters, MSA.CodeBlock sblock)
		{
			List<MSA.Variable> result = new List<MSA.Variable> ();
			foreach (MJCP.Parameter p in parameters)
				result.Add (sblock.CreateParameter (GetSymbolId (p.Name), typeof(MJR.JSObject)));
			//TODO type of param but no type in parameters so jsobject 
			return result;
		}

		#region Statement

		private MSA.Block Generate (DList<MJCP.Statement, MJCP.BlockStatement> Input, MJCP.BindingInfo bindingInfo, bool PrintExpressions)
		{
			//todo how to use bindingInfo
			DList<MJCP.Statement, MJCP.BlockStatement>.Iterator it = new DList<MJCP.Statement, MJCP.BlockStatement>.Iterator (Input);
			List<MSA.Expression> statements = new List<MSA.Expression> ();
			while (it.ElementAvailable) {
				statements.Add (Generate (it.Element, PrintExpressions));
				it.Advance ();
			}
			return MSA.Ast.Block (statements.ToArray());
		}

		private MSA.Expression Generate (MJCP.Statement Input, bool PrintExpressions)
		{
			MSA.Expression result;
			switch (Input.Opcode) {
				case MJCP.Statement.Operation.Block:
					result = GenerateBlockStatement ((MJCP.BlockStatement)Input);
					break;
				case MJCP.Statement.Operation.VariableDeclaration:
					result = GenerateVarDeclaration ((MJCP.VariableDeclarationStatement)Input);
					break;
				case MJCP.Statement.Operation.Empty:
					result = MSA.Ast.Empty ();
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
					result = MSA.Ast.Break ();
					break;
				case MJCP.Statement.Operation.Continue:
					result = MSA.Ast.Continue ();
					break;
				case MJCP.Statement.Operation.Return:
					result = MSA.Ast.Return (Generate (((MJCP.ReturnOrThrowStatement)Input).Value));
					break;
				case MJCP.Statement.Operation.Throw:
					result = MSA.Ast.Throw (Generate (((MJCP.ReturnOrThrowStatement)Input).Value));
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

		private MSA.Expression Generate (MJCP.Statement Input)
		{
			return Generate (Input, false);
		}

		private MSA.Expression GenerateBlockStatement (MJCP.BlockStatement blockStatement)
		{
			DList<MJCP.Statement, MJCP.BlockStatement>.Iterator it = new DList<MJCP.Statement, MJCP.BlockStatement>.Iterator (blockStatement.Children);
			List<MSA.Expression> statements = new List<MSA.Expression> ();
			while (it.ElementAvailable){
				 MSA.Expression statement = Generate (it.Element);
				 statements.Add (statement);
				 it.Advance ();
			}
			return MSA.Ast.Block (statements);
		}

		private MSA.Expression GenerateVarDeclaration (MJCP.VariableDeclarationStatement variableDeclarationStatement)
		{
			List<MSA.Expression> expressions = new List<MSA.Expression> ();
			foreach (MJCP.VariableDeclarationListElement element in variableDeclarationStatement.Declarations) {
				MSA.Variable vr = GetVar (element.Declaration.Name);
				MSA.Expression value = null;
				if (element.Declaration is MJCP.InitializerVariableDeclaration) {
					value = Generate (((MJCP.InitializerVariableDeclaration)element.Declaration).Initializer);
					expressions.Add (MSA.Ast.Assign (vr, value));
				}							
			}
			if (expressions.Count == 0)
				return MSA.Ast.Empty ();
			return MSA.Ast.Comma (expressions);
		}

		//[MonoTODO ("PrintExpressions is not used")]
		private MSA.Expression GenerateExpressionStatement (MJCP.ExpressionStatement expressionStatement, bool PrintExpressions)
		{
			return MSA.Ast.Statement (Generate (expressionStatement.Expression));
		}

		private MSA.Expression GenerateIfStatement (MJCP.IfStatement ifStatement)
		{
			MSA.Expression @else = Generate (ifStatement.ElseBody);
			List<MSA.IfStatementTest> tests = new List<MSA.IfStatementTest> ();
			tests.Add (MSA.Ast.IfCondition (Generate (ifStatement.Condition), Generate (ifStatement.IfBody)));
			//TODO strange to have list here maybe for elseif in other language
			return MSA.Ast.If (tests.ToArray(), @else);
		}

		private MSA.Expression GenerateDoStatement (MJCP.DoStatement doStatement)
		{
			MSA.Expression test = Generate (doStatement.Condition);
			MSA.Expression body = Generate (doStatement.Body);
			SourceSpan span = GetRowanTextSpan (doStatement.Location);
			SourceLocation header = GetRowanStartLocation (doStatement.HeaderLocation);
			return MSA.Ast.Do (span, header, body).While (test);
		}

		private MSA.Expression GenerateWhileStatement (MJCP.WhileStatement whileStatement)
		{
			MSA.Expression test = Generate (whileStatement.Condition);
			MSA.Expression body = Generate (whileStatement.Body);
			SourceSpan span = GetRowanTextSpan (whileStatement.Location);
			SourceLocation header = GetRowanStartLocation (whileStatement.HeaderLocation);
			return MSA.Ast.While (span, header, test, body, null);
		}

		private MSA.Expression GenerateExpressionForStatement (MJCP.ForStatement forStatement)
		{
			//TODO unit test + inital somewhere
			MSA.Expression test = Generate (forStatement.Condition);
			MSA.Expression increment = Generate (forStatement.Increment);
			MSA.Expression body = Generate (forStatement.Body);
			SourceSpan span = GetRowanTextSpan (forStatement.Location);
			SourceLocation header = GetRowanStartLocation (forStatement.HeaderLocation);
			return MSA.Ast.Loop (span, header, test, increment, body, null);
		}

		private MSA.Expression GenerateDeclarationForStatement (MJCP.DeclarationForStatement declarationForStatement)
		{
			//TODO unit test + inital somewhere
			MSA.Expression test = Generate (declarationForStatement.Condition);
			MSA.Expression increment = Generate (declarationForStatement.Increment);
			MSA.Expression body = Generate (declarationForStatement.Body);
			SourceSpan span = GetRowanTextSpan (declarationForStatement.Location);
			SourceLocation header = GetRowanStartLocation (declarationForStatement.HeaderLocation);
			return MSA.Ast.Loop (span, header, test, increment, body, null);
		}

		private MSA.Expression GenerateForInStatement (MJCP.ForInStatement forInStatement)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private MSA.Expression GenerateDeclarationForInStatement (MJCP.DeclarationForInStatement declarationForInStatement)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private MSA.Expression GenerateWithStatement (MJCP.WithStatement withStatement)
		{
			return MSA.Ast.Scope (Generate (withStatement.Scope),Generate (withStatement.Body));
		}

		private MSA.Expression GenerateLabelStatement (MJCP.LabelStatement labelStatement)
		{
			//TODO must use label somewhere maybe done a collection of label with statement
			//labelStatement.Label
			return MSA.Ast.Labeled (Generate (labelStatement.Labeled));
		}

		private MSA.Expression GenerateSwitchStatement (MJCP.SwitchStatement switchStatement)
		{
			MSA.Expression testValue = Generate (switchStatement.Value);
			
			SourceSpan span = GetRowanTextSpan (switchStatement.Location);
			SourceLocation header = GetRowanStartLocation (switchStatement.HeaderLocation);
			MSA.SwitchStatementBuilder builder = MSA.Ast.Switch (span, header, testValue);
			
			DList<MJCP.CaseClause, MJCP.SwitchStatement>.Iterator it = new DList<MJCP.CaseClause, MJCP.SwitchStatement>.Iterator (switchStatement.Cases);
			while (it.ElementAvailable) {
				if ( it.Element is MJCP.ValueCaseClause)
					builder.Case ((int)((MSA.ConstantExpression)Generate(((MJCP.ValueCaseClause)it.Element).Value)).Value, Generate (it.Element.Children));
				else //default
					builder.Default (Generate (it.Element.Children));
				it.Advance ();
			}
			return builder.ToStatement ();
		}

		private MSA.Expression Generate (DList<MJCP.Statement, MJCP.CaseClause> children)
		{
			List<MSA.Expression> statements = new List<MSA.Expression> ();
			DList<MJCP.Statement, MJCP.CaseClause>.Iterator it = new DList<MJCP.Statement, MJCP.CaseClause>.Iterator (children);
			while (it.ElementAvailable) {
				statements.Add (Generate (it.Element));
				it.Advance ();
			}
			return MSA.Ast.Block (statements);
		}
		
		private MSA.CatchBlock[] Generate (MJCP.CatchClause Catch)
		{
			return new MSA.CatchBlock[] {MSA.Ast.Catch (typeof(object), Generate (Catch.Handler))};
		}
		
		private MSA.Expression GenerateTryStatement (MJCP.TryStatement tryStatement)
		{
			SourceSpan span = GetRowanTextSpan (tryStatement.Location);
			MSA.Expression body = Generate (tryStatement.Block);
			
			if (tryStatement.Catch != null) {
				MSA.CatchBlock[] handlers = Generate(tryStatement.Catch);
				if (tryStatement.Finally != null) {
					MSA.Expression @finally = Generate (tryStatement.Finally.Handler);	
					return MSA.Ast.TryCatchFinally (span, SourceLocation.None, body, handlers, @finally);
				}
				return MSA.Ast.TryCatch (span, SourceLocation.None, body, handlers);
			}
			else if (tryStatement.Finally != null) {
				MSA.Expression finallySuite = Generate (tryStatement.Finally.Handler);
				return MSA.Ast.TryFinally (span, SourceLocation.None, body, finallySuite);
			}
			return MSA.Ast.Try (span, SourceLocation.None,body);				
		}

		private MSA.Expression GenerateFunctionStatement (MJCP.FunctionStatement functionStatement)
		{
			return Generate (functionStatement.Function);
		}

		#endregion

		#endregion

		#region Location Converter

		private static SourceLocation GetRowanEndLocation(TextSpan Location)
		{
			return new SourceLocation (Location.EndPosition, Location.EndLine, Location.EndColumn);
		}

		private static SourceLocation GetRowanStartLocation(TextSpan Location)
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

		private SymbolId GetSymbolId (Identifier ID)
		{
			return idMappingTable.GetRowanID (ID);
		}
			
		//TODO when variable is ever created we must get it back
		// so will search in current block and parent block if not field
		// else will search in object tree if contain this member 
		private MSA.Variable GetVar(Identifier ID)
		{
			throw new NotImplementedException();
		}
	}
}
