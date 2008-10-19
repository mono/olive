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
using System.Scripting;
using SLE = System.Linq.Expressions;
using MJCP = Microsoft.JScript.Compiler.ParseTree;
using MJR = Microsoft.JScript.Runtime;
using MSAc = Microsoft.Scripting.Actions;
using Microsoft.JScript.Runtime;
using Microsoft.JScript.Compiler;
using Microsoft.JScript.Compiler.Helpers;

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
		private Microsoft.Scripting.Ast.LambdaBuilder builder;
		
		/*public void Bind()
		{
			throw new NotImplementedException();
		}*/
		
		public SLE.LambdaExpression BindAndTransform (MJCP.Expression expression, MJCP.BindingInfo bindingInfo)
		{
			Init ();
			//TODO test to know the internal of this and know the use of bindinginfo
			builder.Body = SLE.Expression.Block (Generate (expression));
			return builder.MakeLambda ();
		}

		public SLE.LambdaExpression BindAndTransform (DList<MJCP.Statement, MJCP.BlockStatement> statements, MJCP.BindingInfo bindingInfo, bool Print)
		{
			Init ();
			//TODO test to know the internal of this and know the use of bindinginfo
			builder.Body = SLE.Expression.Block (Generate (statements, bindingInfo, Print));
			return builder.MakeLambda ();
		}

		private void Init ()
		{
			builder = Microsoft.Scripting.Ast.Utils.Lambda (typeof(object), "name todo");
			builder.IsGlobal = true;
			withinFunction = 0;
		}
		# region AST Converter

		private SLE.Expression ConvertToObject(SLE.Expression Value)
		{
			List<SLE.Expression> Args = new List<SLE.Expression>();
			Args.Add(SLE.Expression.CodeContext ());
			Args.Add(Value);
			MethodInfo met = typeof (Microsoft.JScript.Runtime.Convert).GetMethod ("ToObject");
			return SLE.Expression.Call (met, Args.ToArray());
		}

		#region Expression

		private SLE.Expression Generate(MJCP.Expression Input)
		{
			Init ();
			SLE.Expression result = null;
			if (Input == null)
				return null;
			List<SLE.Expression> arguments;
			List<SLE.Expression> initializers;
			SLE.Expression right;

			MJCP.BinaryOperatorExpression binOp;
			switch (Input.Opcode) {

				case MJCP.Expression.Operation.SyntaxError :
					return null;//sample show null
				case MJCP.Expression.Operation.@this :
					//TODO this must not be a variable!
					if (withinFunction > 1)//if this is call inside a function
						result = SLE.Expression.Read (builder.CreateVariable (GetSymbolId(thisIdent), SLE.Variable.VariableKind.Global, null));
					else {//if this is call ouside of function
						arguments = new List<SLE.Expression> ();
						arguments.Add (SLE.Expression.CodeContext ());
						result = SLE.Expression.Call (typeof (MJR.JSOps).GetMethod ("GetGlobalObject"), arguments.ToArray ());
					}
					break;
				case MJCP.Expression.Operation.@false :
					result = SLE.Expression.False ();
					break;
				case MJCP.Expression.Operation.@true :
					result = SLE.Expression.True ();
					break;
				case MJCP.Expression.Operation.Identifier :
						Identifier id = ((MJCP.IdentifierExpression)Input).ID;//TODO make a tree of variable and allow to get it 
						result = SLE.Expression.Read (builder.CreateVariable (GetSymbolId(id), SLE.Variable.VariableKind.Global, null));
						break;
				case MJCP.Expression.Operation.NumericLiteral :
					double val = 0;
					try {
						val = Double.Parse (((MJCP.NumericLiteralExpression)Input).Spelling);
						result = SLE.Expression.Constant (val);
					} catch {
						//TODO 
					}
					break;
				case MJCP.Expression.Operation.HexLiteral :
					result = SLE.Expression.Constant (((MJCP.HexLiteralExpression)Input).Value);
					break;
				case MJCP.Expression.Operation.OctalLiteral :
					result = SLE.Expression.Constant (((MJCP.OctalLiteralExpression)Input).Value);
					break;
				case MJCP.Expression.Operation.RegularExpressionLiteral :
					//TODO
					throw new NotImplementedException ();
				case MJCP.Expression.Operation.StringLiteral :
					result = SLE.Expression.Constant (((MJCP.StringLiteralExpression)Input).Value);
					break;
				case MJCP.Expression.Operation.ArrayLiteral :
					arguments = new List<SLE.Expression> ();
					
					arguments.Add (SLE.Expression.CodeContext ());

					initializers =new List<SLE.Expression> ();
					foreach (MJCP.ExpressionListElement element in ((MJCP.ArrayLiteralExpression)Input).Elements)
							initializers.Add (Generate (element.Value));
					arguments.Add (SLE.Expression.NewArray (typeof (object []), initializers));

					result = SLE.Expression.Call (typeof (CompilerHelpers).GetMethod ("ConstructArrayFromArrayLiteral"), arguments.ToArray ());
					break;
				case MJCP.Expression.Operation.ObjectLiteral :
					arguments = new List<SLE.Expression> ();

					arguments.Add (SLE.Expression.CodeContext ());
					
					initializers = new List<SLE.Expression> ();
					List<SLE.Expression> initializers2 = new List<SLE.Expression> ();
					foreach (MJCP.ObjectLiteralElement element in ((MJCP.ObjectLiteralExpression)Input).Elements) {
						initializers.Add (Generate (element.Name));
						initializers2.Add (Generate (element.Value));
					}
					arguments.Add (SLE.Expression.NewArray (typeof (object[]), initializers));
					arguments.Add (SLE.Expression.NewArray (typeof (object[]), initializers2));

					result = SLE.Expression.Call (typeof (CompilerHelpers).GetMethod ("ConstructObjectFromLiteral"), arguments.ToArray ());
					break;
				case MJCP.Expression.Operation.Parenthesized :
					result = Generate (((MJCP.UnaryOperatorExpression)Input).Operand); 
					break;
				case MJCP.Expression.Operation.Invocation :
					arguments = new List<SLE.Expression> ();
					//TODO fill arguments
					//args = new List<SLE.Arg> ();
					foreach (MJCP.ExpressionListElement element in ((MJCP.InvocationExpression)Input).Arguments.Arguments)
						arguments.Add (Generate (element.Value));
					
					SLE.Expression instance = Generate (((MJCP.InvocationExpression)Input).Target);
					//(Expression instance,) MethodInfo method, params Expression[] arguments
					//TODO MethodInfo!
					result = SLE.Expression.Call (instance, null, arguments.ToArray ());
					break;
				case MJCP.Expression.Operation.Subscript :
					arguments = new List<SLE.Expression> ();
					//TODO fill arguments and type result
					result = SLE.Expression.Action.Operator (MSO.GetItem, null, arguments.ToArray());
					break;
				case MJCP.Expression.Operation.Qualified :
					arguments = new List<SLE.Expression> ();
					//TODO fill arguments and type result
					result = SLE.Expression.Action.GetMember (GetSymbolId (((MJCP.QualifiedExpression)Input).Qualifier), null, arguments.ToArray());
					break;
				case MJCP.Expression.Operation.@new :
					SLE.Expression constructor = Generate (((MJCP.InvocationExpression)Input).Target);
					arguments = new List<SLE.Expression> ();
					foreach (MJCP.ExpressionListElement element in ((MJCP.InvocationExpression)Input).Arguments.Arguments)
						arguments.Add (Generate(element.Value));
					//todo fill the type result
					result = SLE.Expression.Action.Create (null, arguments.ToArray());
					break;
				case MJCP.Expression.Operation.Function :
					result = GenerateFunction (((MJCP.FunctionExpression)Input).Function);
					//the statement and expression is not the same
					result = SLE.Expression.Assign (GetVar (((MJCP.FunctionExpression)Input).Function.Name), result);
					break;
				case MJCP.Expression.Operation.delete :
					arguments = new List<SLE.Expression> ();
					//TODO fill arguments
					result = SLE.Expression.Call (typeof (CompilerHelpers).GetMethod ("Delete"), arguments.ToArray ());
					break;
				case MJCP.Expression.Operation.@void :
					arguments = new List<SLE.Expression> ();
					//TODO fill arguments
					result = SLE.Expression.Call (typeof (CompilerHelpers).GetMethod ("Void"), arguments.ToArray ());
					break;
				case MJCP.Expression.Operation.@typeof :
					arguments = new List<SLE.Expression> ();
					//TODO fill arguments
					result = SLE.Expression.Call (typeof (CompilerHelpers).GetMethod ("TypeOf"), arguments.ToArray ());
					break;
				case MJCP.Expression.Operation.PrefixPlusPlus :
					//
					break;
				case MJCP.Expression.Operation.PrefixMinusMinus :
					//
					break;
				case MJCP.Expression.Operation.PrefixPlus :
					arguments = new List<SLE.Expression> ();
					//TODO fill arguments
					result = SLE.Expression.Call (typeof (CompilerHelpers).GetMethod ("Positive"), arguments.ToArray());
					break;
				case MJCP.Expression.Operation.PrefixMinus :
					arguments = new List<SLE.Expression> ();
					//TODO fill arguments
					result = SLE.Expression.Call (typeof (CompilerHelpers).GetMethod ("Negate"), arguments.ToArray());
					break;
				case MJCP.Expression.Operation.Tilda :
					arguments = new List<SLE.Expression> ();
					//TODO fill arguments
					result = SLE.Expression.Call (typeof (CompilerHelpers).GetMethod ("OnesComplement"), arguments.ToArray());
					break;
				case MJCP.Expression.Operation.Bang :
					arguments = new List<SLE.Expression> ();
					//TODO fill arguments
					result = SLE.Expression.Call (typeof (CompilerHelpers).GetMethod ("Not"), arguments.ToArray());
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
					arguments = new List<SLE.Expression> ();
					arguments.Add (Generate (binOp.Left));
					arguments.Add (Generate (binOp.Right));
					result = SLE.Expression.Comma (arguments);
					break;
				case MJCP.Expression.Operation.Equal :
					binOp = (MJCP.BinaryOperatorExpression)Input;
					result = GenerateBoundAssignment (binOp.Left, binOp.Right);
					break;
				case MJCP.Expression.Operation.StarEqual :
					binOp = (MJCP.BinaryOperatorExpression)Input;
					right = SLE.Expression.Multiply (Generate(binOp.Left), Generate(binOp.Right));
					result = GenerateBoundAssignment (binOp.Left, right);
					break;
				case MJCP.Expression.Operation.DivideEqual :
					binOp = (MJCP.BinaryOperatorExpression)Input;
					right = SLE.Expression.Multiply (Generate(binOp.Left), Generate(binOp.Right));
					result = GenerateBoundAssignment (binOp.Left, right);
					break;
				case MJCP.Expression.Operation.PercentEqual :
					binOp = (MJCP.BinaryOperatorExpression)Input;
					right = SLE.Expression.Modulo (Generate(binOp.Left), Generate(binOp.Right));
					result = GenerateBoundAssignment (binOp.Left, right);
					break;
				case MJCP.Expression.Operation.PlusEqual :
					binOp = (MJCP.BinaryOperatorExpression)Input;
					right = SLE.Expression.Add (Generate(binOp.Left), Generate(binOp.Right));
					result = GenerateBoundAssignment (binOp.Left, right);
					break;
				case MJCP.Expression.Operation.MinusEqual:
					binOp = (MJCP.BinaryOperatorExpression)Input;
					right = SLE.Expression.Subtract (Generate(binOp.Left), Generate(binOp.Right));
					result = GenerateBoundAssignment (binOp.Left, right);
					break;
				case MJCP.Expression.Operation.LessLessEqual:
					binOp = (MJCP.BinaryOperatorExpression)Input;
					right = SLE.Expression.LeftShift (Generate(binOp.Left), Generate(binOp.Right));
					result = GenerateBoundAssignment (binOp.Left, right);
					break;
				case MJCP.Expression.Operation.GreaterGreaterEqual:
					binOp = (MJCP.BinaryOperatorExpression)Input;
					right = SLE.Expression.RightShift (Generate(binOp.Left), Generate(binOp.Right));
					result = GenerateBoundAssignment (binOp.Left, right);
					break;
				case MJCP.Expression.Operation.GreaterGreaterGreaterEqual:
					binOp = (MJCP.BinaryOperatorExpression)Input;//TODO right shift unsigned
					right = SLE.Expression.RightShift (Generate(binOp.Left), Generate(binOp.Right));
					result = GenerateBoundAssignment (binOp.Left, right);
					break;
				case MJCP.Expression.Operation.AmpersandEqual:
					binOp = (MJCP.BinaryOperatorExpression)Input;
					right = SLE.Expression.And (Generate(binOp.Left), Generate(binOp.Right));
					result = GenerateBoundAssignment (binOp.Left, right);
					break;
				case MJCP.Expression.Operation.CircumflexEqual:
					binOp = (MJCP.BinaryOperatorExpression)Input;
					right = SLE.Expression.ExclusiveOr (Generate(binOp.Left), Generate(binOp.Right));
					result = GenerateBoundAssignment (binOp.Left, right);
					break;
				case MJCP.Expression.Operation.BarEqual:
					binOp = (MJCP.BinaryOperatorExpression)Input;
					right = SLE.Expression.Or (Generate(binOp.Left), Generate(binOp.Right));
					result = GenerateBoundAssignment (binOp.Left, right);
					break;
				case MJCP.Expression.Operation.BarBar :
					result = SLE.Expression.OrElse (Generate (((MJCP.BinaryOperatorExpression)Input).Left), Generate (((MJCP.BinaryOperatorExpression)Input).Right));
					break;
				case MJCP.Expression.Operation.AmpersandAmpersand :
					result = SLE.Expression.AndAlso (Generate (((MJCP.BinaryOperatorExpression)Input).Left), Generate (((MJCP.BinaryOperatorExpression)Input).Right));
					break;
				case MJCP.Expression.Operation.Bar:
					binOp = (MJCP.BinaryOperatorExpression)Input;
					result = SLE.Expression.Or (Generate(binOp.Left), Generate(binOp.Right));
					break;
				case MJCP.Expression.Operation.Circumflex:
					binOp = (MJCP.BinaryOperatorExpression)Input;
					result = SLE.Expression.ExclusiveOr (Generate(binOp.Left), Generate(binOp.Right));
					break;
				case MJCP.Expression.Operation.Ampersand:
					binOp = (MJCP.BinaryOperatorExpression)Input;
					result = SLE.Expression.And (Generate(binOp.Left), Generate(binOp.Right));
					break;
				case MJCP.Expression.Operation.EqualEqual:
					binOp = (MJCP.BinaryOperatorExpression)Input;
					result = SLE.Expression.Equal (Generate(binOp.Left), Generate(binOp.Right));
					break;
				case MJCP.Expression.Operation.BangEqual:
					binOp = (MJCP.BinaryOperatorExpression)Input;
					result = SLE.Expression.NotEqual (Generate(binOp.Left), Generate(binOp.Right));
					break;
				case MJCP.Expression.Operation.EqualEqualEqual:
					arguments = new List<SLE.Expression> ();
					//TODO fill arguments
					result = SLE.Expression.Call (typeof (CompilerHelpers).GetMethod ("Is"), arguments.ToArray());
					break;
				case MJCP.Expression.Operation.BangEqualEqual:
					arguments = new List<SLE.Expression> ();
					//TODO fill arguments
					result = SLE.Expression.Call (typeof (CompilerHelpers).GetMethod ("IsNot"), arguments.ToArray());
					break;
				case MJCP.Expression.Operation.Less:
					binOp = (MJCP.BinaryOperatorExpression)Input;
					result = SLE.Expression.LessThan (Generate(binOp.Left), Generate(binOp.Right));
					break;
				case MJCP.Expression.Operation.Greater:
					binOp = (MJCP.BinaryOperatorExpression)Input;
					result = SLE.Expression.GreaterThan (Generate(binOp.Left), Generate(binOp.Right));
					break;
				case MJCP.Expression.Operation.LessEqual:
					binOp = (MJCP.BinaryOperatorExpression)Input;
					result = SLE.Expression.LessThanEquals (Generate(binOp.Left), Generate(binOp.Right));
					break;
				case MJCP.Expression.Operation.GreaterEqual:
					binOp = (MJCP.BinaryOperatorExpression)Input;
					result = SLE.Expression.GreaterThanEquals (Generate(binOp.Left), Generate(binOp.Right));
					break;
				case MJCP.Expression.Operation.instanceof:
					arguments = new List<SLE.Expression> ();
					//TODO fill arguments
					result = SLE.Expression.Call (typeof (CompilerHelpers).GetMethod ("InstanceOf"), arguments.ToArray());
					break;
				case MJCP.Expression.Operation.@in:
					arguments = new List<SLE.Expression> ();
					//TODO fill arguments
					result = SLE.Expression.Call (typeof (CompilerHelpers).GetMethod ("In"), arguments.ToArray());
					break;
				case MJCP.Expression.Operation.LessLess:
					binOp = (MJCP.BinaryOperatorExpression)Input;
					result = SLE.Expression.LeftShift (Generate(binOp.Left), Generate(binOp.Right));
					break;
				case MJCP.Expression.Operation.GreaterGreater:
					binOp = (MJCP.BinaryOperatorExpression)Input;
					result = SLE.Expression.RightShift (Generate(binOp.Left), Generate(binOp.Right));
					break;
				case MJCP.Expression.Operation.GreaterGreaterGreater:
					arguments = new List<SLE.Expression> ();
					arguments.Add (Generate (((MJCP.BinaryOperatorExpression)Input).Left));
					arguments.Add (Generate (((MJCP.BinaryOperatorExpression)Input).Right));
					//TODO type result
					result = SLE.Expression.Action.Operator (MSO.RightShiftUnsigned, null, arguments.ToArray());
					break;
				case MJCP.Expression.Operation.Plus:
					binOp = (MJCP.BinaryOperatorExpression)Input;
					result = SLE.Expression.Add (Generate(binOp.Left), Generate(binOp.Right));
					break;
				case MJCP.Expression.Operation.Minus:
					binOp = (MJCP.BinaryOperatorExpression)Input;
					result = SLE.Expression.Subtract (Generate(binOp.Left), Generate(binOp.Right));
					break;
				case MJCP.Expression.Operation.Star:
					binOp = (MJCP.BinaryOperatorExpression)Input;
					result = SLE.Expression.Multiply (Generate(binOp.Left), Generate(binOp.Right));
					break;
				case MJCP.Expression.Operation.Divide:
					binOp = (MJCP.BinaryOperatorExpression)Input;
					result = SLE.Expression.Divide (Generate(binOp.Left), Generate(binOp.Right));
					break;
				case MJCP.Expression.Operation.Percent:
					binOp = (MJCP.BinaryOperatorExpression)Input;
					result = SLE.Expression.Modulo (Generate(binOp.Left), Generate(binOp.Right));
					break;
				case MJCP.Expression.Operation.Question:
					result = SLE.Expression.Condition (Generate (((MJCP.TernaryOperatorExpression)Input).First),
						Generate (((MJCP.TernaryOperatorExpression)Input).Second),
						Generate (((MJCP.TernaryOperatorExpression)Input).Third));
					break;
				case MJCP.Expression.Operation.@null:
					result = SLE.Expression.Null ();
					break;
			}
			//seems to have disappear now
			//result.SetLoc (GetRowanTextSpan (Input.Location));
			return result;
		}
		
		private SLE.Expression GenerateBoundAssignment (MJCP.Expression left, SLE.Expression right)
		{
			//todo see BoundAssignment Ast partial Write and Assign 
			if (left is MJCP.IdentifierExpression)
				return SLE.Expression.Assign (GetVar (((MJCP.IdentifierExpression)left).ID), right);
			else if(left.Opcode == MJCP.Expression.Operation.Parenthesized)
				return GenerateBoundAssignment(((MJCP.UnaryOperatorExpression)left).Operand, right);
			else if (left.Opcode == MJCP.Expression.Operation.Qualified)
				return SLE.Expression.Assign (GetVar (((MJCP.QualifiedExpression)left).Qualifier), right);
			
			throw new Exception ("can not be assigned!" + left.Opcode.ToString());
		}
		
		private SLE.Expression GenerateBoundAssignment (MJCP.Expression left, MJCP.Expression right)
		{
			return GenerateBoundAssignment (left, Generate (right));
		}

		#endregion
				
		private SLE.Expression Generate (MJCP.FunctionDefinition Input)
		{
			SLE.Variable v = GetVar (Input.Name);
			SLE.Expression val = GenerateFunction (Input);
			SLE.BoundAssignment bound = SLE.Expression.Assign (v, val);
			return SLE.Expression.Statement (bound);
		}

		//[MonoTODO ("fill all detail and complete test")]
		private SLE.Expression GenerateFunction (MJCP.FunctionDefinition Input)
		{
			SLE.Variable vr = GetVar (Input.Name);
			List<SLE.Expression> arguments = new List<SLE.Expression> ();
			//TODO: a lot have to be found here
			arguments.Add (SLE.Expression.CodeContext ());
			arguments.Add (SLE.Expression.Constant (Input.Name.Spelling));
			arguments.Add (SLE.Expression.Constant (-1));//must be something but not found for moment
			string name = "_";//TODO: find what is behind this or hardcoded?
			withinFunction++;
			//TODO best is to do a node system or a queue if needed to get the function
			//I think I will have to do that for variable system 
			SLE.Expression body = this.Generate (Input.Body);//must be that but not tested
			withinFunction--;
			SLE.CodeBlock block = SLE.Expression.CodeBlock (name);
			block.Parent= builder;
			block.Body = body;
			List<SLE.Variable> parameters = this.Generate (Input.Parameters, block);
			arguments.Add (SLE.Expression.CodeBlockExpression (block, false));//TODO maybe use other ones with more 
			List<SLE.Expression> initializers = new List<SLE.Expression> ();// TODO fill it
			arguments.Add (SLE.Expression.NewArray (typeof (string[]), initializers));
			arguments.Add (SLE.Expression.Constant (true));
			arguments.Add (SLE.Expression.Constant (false));

			return SLE.Expression.Call (typeof (MJR.JSFunctionObject).GetMethod ("MakeFunction"), arguments.ToArray());
		}

/*
		private List<SLE.Variable> Generate (List<MJCP.Parameter> parameters, SLE.CodeBlock sblock)
		{
			List<SLE.Variable> result = new List<SLE.Variable> ();
			foreach (MJCP.Parameter p in parameters)
				result.Add (sblock.CreateParameter (GetSymbolId (p.Name), typeof(MJR.JSObject)));
			//TODO type of param but no type in parameters so jsobject 
			return result;
		}
*/
		#region Statement

		private SLE.Block Generate (DList<MJCP.Statement, MJCP.BlockStatement> Input, MJCP.BindingInfo bindingInfo, bool PrintExpressions)
		{
			//todo how to use bindingInfo
			DList<MJCP.Statement, MJCP.BlockStatement>.Iterator it = new DList<MJCP.Statement, MJCP.BlockStatement>.Iterator (Input);
			List<SLE.Expression> statements = new List<SLE.Expression> ();
			while (it.ElementAvailable) {
				statements.Add (Generate (it.Element, PrintExpressions));
				it.Advance ();
			}
			return SLE.Expression.Block (statements.ToArray());
		}

		private SLE.Expression Generate (MJCP.Statement Input, bool PrintExpressions)
		{
			SLE.Expression result;
			switch (Input.Opcode) {
				case MJCP.Statement.Operation.Block:
					result = GenerateBlockStatement ((MJCP.BlockStatement)Input);
					break;
				case MJCP.Statement.Operation.VariableDeclaration:
					result = GenerateVarDeclaration ((MJCP.VariableDeclarationStatement)Input);
					break;
				case MJCP.Statement.Operation.Empty:
					result = SLE.Expression.Empty ();
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
					result = SLE.Expression.Break ();
					break;
				case MJCP.Statement.Operation.Continue:
					result = SLE.Expression.Continue ();
					break;
				case MJCP.Statement.Operation.Return:
					result = SLE.Expression.Return (Generate (((MJCP.ReturnOrThrowStatement)Input).Value));
					break;
				case MJCP.Statement.Operation.Throw:
					result = SLE.Expression.Throw (Generate (((MJCP.ReturnOrThrowStatement)Input).Value));
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

		private SLE.Expression Generate (MJCP.Statement Input)
		{
			return Generate (Input, false);
		}

		private SLE.Expression GenerateBlockStatement (MJCP.BlockStatement blockStatement)
		{
			DList<MJCP.Statement, MJCP.BlockStatement>.Iterator it = new DList<MJCP.Statement, MJCP.BlockStatement>.Iterator (blockStatement.Children);
			List<SLE.Expression> statements = new List<SLE.Expression> ();
			while (it.ElementAvailable){
				 SLE.Expression statement = Generate (it.Element);
				 statements.Add (statement);
				 it.Advance ();
			}
			return SLE.Expression.Block (statements);
		}

		private SLE.Expression GenerateVarDeclaration (MJCP.VariableDeclarationStatement variableDeclarationStatement)
		{
			List<SLE.Expression> expressions = new List<SLE.Expression> ();
			foreach (MJCP.VariableDeclarationListElement element in variableDeclarationStatement.Declarations) {
				SLE.Variable vr = GetVar (element.Declaration.Name);
				SLE.Expression value = null;
				if (element.Declaration is MJCP.InitializerVariableDeclaration) {
					value = Generate (((MJCP.InitializerVariableDeclaration)element.Declaration).Initializer);
					expressions.Add (SLE.Expression.Assign (vr, value));
				}							
			}
			if (expressions.Count == 0)
				return SLE.Expression.Empty ();
			return SLE.Expression.Comma (expressions);
		}

		//[MonoTODO ("PrintExpressions is not used")]
		private SLE.Expression GenerateExpressionStatement (MJCP.ExpressionStatement expressionStatement, bool PrintExpressions)
		{
			return SLE.Expression.Statement (Generate (expressionStatement.Expression));
		}

		private SLE.Expression GenerateIfStatement (MJCP.IfStatement ifStatement)
		{
			SLE.Expression @else = Generate (ifStatement.ElseBody);
			List<SLE.IfStatementTest> tests = new List<SLE.IfStatementTest> ();
			tests.Add (SLE.Expression.IfCondition (Generate (ifStatement.Condition), Generate (ifStatement.IfBody)));
			//TODO strange to have list here maybe for elseif in other language
			return SLE.Expression.If (tests.ToArray(), @else);
		}

		private SLE.Expression GenerateDoStatement (MJCP.DoStatement doStatement)
		{
			SLE.Expression test = Generate (doStatement.Condition);
			SLE.Expression body = Generate (doStatement.Body);
			SourceSpan span = GetRowanTextSpan (doStatement.Location);
			SourceLocation header = GetRowanStartLocation (doStatement.HeaderLocation);
			return SLE.Expression.Do (span, header, body).While (test);
		}

		private SLE.Expression GenerateWhileStatement (MJCP.WhileStatement whileStatement)
		{
			SLE.Expression test = Generate (whileStatement.Condition);
			SLE.Expression body = Generate (whileStatement.Body);
			SourceSpan span = GetRowanTextSpan (whileStatement.Location);
			SourceLocation header = GetRowanStartLocation (whileStatement.HeaderLocation);
			return SLE.Expression.While (span, header, test, body, null);
		}

		private SLE.Expression GenerateExpressionForStatement (MJCP.ForStatement forStatement)
		{
			//TODO unit test + inital somewhere
			SLE.Expression test = Generate (forStatement.Condition);
			SLE.Expression increment = Generate (forStatement.Increment);
			SLE.Expression body = Generate (forStatement.Body);
			SourceSpan span = GetRowanTextSpan (forStatement.Location);
			SourceLocation header = GetRowanStartLocation (forStatement.HeaderLocation);
			return SLE.Expression.Loop (span, header, test, increment, body, null);
		}

		private SLE.Expression GenerateDeclarationForStatement (MJCP.DeclarationForStatement declarationForStatement)
		{
			//TODO unit test + inital somewhere
			SLE.Expression test = Generate (declarationForStatement.Condition);
			SLE.Expression increment = Generate (declarationForStatement.Increment);
			SLE.Expression body = Generate (declarationForStatement.Body);
			SourceSpan span = GetRowanTextSpan (declarationForStatement.Location);
			SourceLocation header = GetRowanStartLocation (declarationForStatement.HeaderLocation);
			return SLE.Expression.Loop (span, header, test, increment, body, null);
		}

		private SLE.Expression GenerateForInStatement (MJCP.ForInStatement forInStatement)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private SLE.Expression GenerateDeclarationForInStatement (MJCP.DeclarationForInStatement declarationForInStatement)
		{
			throw new Exception ("The method or operation is not implemented.");
		}

		private SLE.Expression GenerateWithStatement (MJCP.WithStatement withStatement)
		{
			return SLE.Expression.Scope (Generate (withStatement.Scope),Generate (withStatement.Body));
		}

		private SLE.Expression GenerateLabelStatement (MJCP.LabelStatement labelStatement)
		{
			//TODO must use label somewhere maybe done a collection of label with statement
			//labelStatement.Label
			return SLE.Expression.Labeled (Generate (labelStatement.Labeled));
		}

		private SLE.Expression GenerateSwitchStatement (MJCP.SwitchStatement switchStatement)
		{
			SLE.Expression testValue = Generate (switchStatement.Value);
			
			SourceSpan span = GetRowanTextSpan (switchStatement.Location);
			SourceLocation header = GetRowanStartLocation (switchStatement.HeaderLocation);
			SLE.SwitchStatementBuilder builder = SLE.Expression.Switch (span, header, testValue);
			
			DList<MJCP.CaseClause, MJCP.SwitchStatement>.Iterator it = new DList<MJCP.CaseClause, MJCP.SwitchStatement>.Iterator (switchStatement.Cases);
			while (it.ElementAvailable) {
				if ( it.Element is MJCP.ValueCaseClause)
					builder.Case ((int)((SLE.ConstantExpression)Generate(((MJCP.ValueCaseClause)it.Element).Value)).Value, Generate (it.Element.Children));
				else //default
					builder.Default (Generate (it.Element.Children));
				it.Advance ();
			}
			return builder.ToStatement ();
		}

		private SLE.Expression Generate (DList<MJCP.Statement, MJCP.CaseClause> children)
		{
			List<SLE.Expression> statements = new List<SLE.Expression> ();
			DList<MJCP.Statement, MJCP.CaseClause>.Iterator it = new DList<MJCP.Statement, MJCP.CaseClause>.Iterator (children);
			while (it.ElementAvailable) {
				statements.Add (Generate (it.Element));
				it.Advance ();
			}
			return SLE.Expression.Block (statements);
		}
		
		private SLE.CatchBlock[] Generate (MJCP.CatchClause Catch)
		{
			return new SLE.CatchBlock[] {SLE.Expression.Catch (typeof(object), Generate (Catch.Handler))};
		}
		
		private SLE.Expression GenerateTryStatement (MJCP.TryStatement tryStatement)
		{
			SourceSpan span = GetRowanTextSpan (tryStatement.Location);
			SLE.Expression body = Generate (tryStatement.Block);
			
			if (tryStatement.Catch != null) {
				SLE.CatchBlock[] handlers = Generate(tryStatement.Catch);
				if (tryStatement.Finally != null) {
					SLE.Expression @finally = Generate (tryStatement.Finally.Handler);	
					return SLE.Expression.TryCatchFinally (span, SourceLocation.None, body, handlers, @finally);
				}
				return SLE.Expression.TryCatch (span, SourceLocation.None, body, handlers);
			}
			else if (tryStatement.Finally != null) {
				SLE.Expression finallySuite = Generate (tryStatement.Finally.Handler);
				return SLE.Expression.TryFinally (span, SourceLocation.None, body, finallySuite);
			}
			return SLE.Expression.Try (span, SourceLocation.None,body);				
		}

		private SLE.Expression GenerateFunctionStatement (MJCP.FunctionStatement functionStatement)
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
/*
		private SLE.Variable GetVar(Identifier ID)
		{
			throw new NotImplementedException();
		}
*/
	}
}
