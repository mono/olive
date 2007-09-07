using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.JScript.Compiler;
using NUnit.Core;
using NUnit.Framework;
using MSIA = Microsoft.Scripting.Internal.Ast;
using MJCP = Microsoft.JScript.Compiler.ParseTree;
using MJR = Microsoft.JScript.Runtime;

namespace MonoTests.Microsoft.JScript.Compiler
{
	[TestFixture]
	public class RowanGeneratorTest
	{
		RowanGenerator gen;
		IdentifierTable idtable;
		IdentifierMappingTable maptable;

		[SetUp]
		public void init ()
		{
			idtable = new IdentifierTable ();
			maptable = new IdentifierMappingTable ();
			gen = new RowanGenerator (maptable,
									idtable.InsertIdentifier ("this"),
									idtable.InsertIdentifier ("_"),
									idtable.InsertIdentifier ("arguments"),
									idtable.InsertIdentifier ("eval"));
		}
		
		[Test]
		public void Bind ()
		{
			gen.Bind ();
		}

		[Test]
		public void ConvertToObject ()
		{
			MSIA.ConstantExpression val = new MSIA.ConstantExpression (0);

			MSIA.Expression expr = gen.ConvertToObject (new MSIA.ConstantExpression (0));
			Assert.IsInstanceOfType (typeof (MSIA.MethodCallExpression), expr, "#1");
			MSIA.MethodCallExpression result = ((MSIA.MethodCallExpression)expr);
			Assert.AreEqual (2, result.Arguments.Count, "#2");
			Assert.IsInstanceOfType (typeof (MSIA.CodeContextExpression), result.Arguments[0], "#3");
			//Console.WriteLine (val.Value);
			//Console.WriteLine (((MSIA.ConstantExpression)result.Arguments[1]).Value);
			//Console.WriteLine (val.ExpressionType);
			//Console.WriteLine (((MSIA.ConstantExpression)result.Arguments[1]).ExpressionType);
			//Console.WriteLine (val.Span);
			//Console.WriteLine (((MSIA.ConstantExpression)result.Arguments[1]).Span);
			//Assert.AreEqual (val, result.Arguments[1], "#4"); //bug here whereas is equal
			Assert.IsNull (result.Instance, "#5");
			Assert.AreEqual (typeof (MJR.Convert).GetMethod ("ToObject"), result.Method, "#6"); 
		}

		[Test]
		public void GenerateFunctionDefinition ()
		{
			Parser parser = new Parser ("function foo() {}".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Statement input = parser.ParseStatement (ref comms);
			//seems to be important to init the globals else it bug everywhere!!
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));

			Assert.IsInstanceOfType (typeof (MJCP.ExpressionStatement), input, "#1");
			MJCP.Expression exp = ((MJCP.ExpressionStatement)input).Expression;
			Assert.IsInstanceOfType (typeof (MJCP.FunctionExpression), exp, "#2");
			MJCP.FunctionDefinition def = ((MJCP.FunctionExpression)exp).Function;

			MSIA.Statement result = gen.Generate (def);
			
			Assert.IsInstanceOfType (typeof (MSIA.ExpressionStatement), result, "#3");
			MSIA.ExpressionStatement sta = (MSIA.ExpressionStatement) result;
			Assert.IsInstanceOfType (typeof (MSIA.BoundAssignment), sta.Expression, "#4");
			MSIA.BoundAssignment boundexp = ((MSIA.BoundAssignment)sta.Expression);
			Assert.IsInstanceOfType (typeof (MSIA.MethodCallExpression), boundexp.Value, "#5");
			MSIA.MethodCallExpression call = (MSIA.MethodCallExpression)boundexp.Value;
			Assert.AreEqual (7, call.Arguments.Count, "#6");
			Assert.IsInstanceOfType (typeof (MSIA.CodeContextExpression), call.Arguments[0], "#7.1");

			Assert.IsInstanceOfType (typeof (MSIA.ConstantExpression), call.Arguments[1], "#7.2");
			Assert.AreEqual ("foo", ((MSIA.ConstantExpression) call.Arguments[1]).Value, "#7.2.1");

			Assert.IsInstanceOfType (typeof (MSIA.ConstantExpression), call.Arguments[2], "#7.3");
			Assert.AreEqual (-1, ((MSIA.ConstantExpression)call.Arguments[2]).Value, "#7.3.1");

			Assert.IsInstanceOfType (typeof (MSIA.CodeBlockExpression), call.Arguments[3], "#7.4");
			//BODY is test with statement test so not needed
			//Assert.IsInstanceOfType (typeof (MSIA.CodeBlockExpression), ((MSIA.CodeBlockExpression)call.Arguments[3]).Block.Body, "#7.4.1");
			Assert.AreEqual ("_", ((MSIA.CodeBlockExpression)call.Arguments[3]).Block.Name, "#7.4.2");
			Assert.IsFalse (((MSIA.CodeBlockExpression)call.Arguments[3]).Block.ParameterArray, "#7.4.3");
			//todo test parameters
			//Assert.IsNull (((MSIA.CodeBlockExpression)call.Arguments[3]).Block.Parameters, "#7.4.4");

			Assert.IsInstanceOfType (typeof (MSIA.NewArrayExpression), call.Arguments[4], "#7.5");
			Assert.IsInstanceOfType (typeof (string[]), ((MSIA.NewArrayExpression)call.Arguments[4]).ExpressionType, "#7.5.1");
			
			Assert.IsInstanceOfType (typeof (MSIA.ConstantExpression), call.Arguments[5], "#7.6");
			Assert.IsInstanceOfType (typeof (MSIA.ConstantExpression), call.Arguments[6], "#7.7");
			
			MSIA.Expression expr = call.Arguments[0];
		}
		#region statement

		[Test]
		public void GenerateBlockStatement ()
		{
			DList<MJCP.Statement, MJCP.BlockStatement> Children = new DList<MJCP.Statement, MJCP.BlockStatement> ();
			TextSpan Location = new TextSpan (0, 0, 0, 10, 0, 10);
			MJCP.BlockStatement input = new MJCP.BlockStatement (Children, Location);
			Children.Parent = input;
			
			MSIA.Statement result = gen.Generate (input);
			Assert.IsInstanceOfType(typeof(MSIA.BlockStatement), result, "#1");
		}
		
		[Test]
		public void GenerateVariableDeclaration ()
		{
			Parser parser = new Parser ("var test = true;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Statement input = parser.ParseStatement (ref comms);
			//seems to be important to init the globals else it bug everywhere!!
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Statement result = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.ExpressionStatement), result, "#2");
			MSIA.Expression exp = ((MSIA.ExpressionStatement)result).Expression;
			Assert.IsInstanceOfType (typeof (MSIA.CommaExpression), exp, "#3");
			exp = ((MSIA.CommaExpression)exp).Expressions[0];
			Assert.IsInstanceOfType (typeof (MSIA.BoundAssignment), exp, "#4");
			//TODO test
			//((MSIA.BoundAssignment)exp).Reference;
			//((MSIA.BoundAssignment)exp).Value;
			//((MSIA.BoundAssignment)exp).Operator;
		}

		#endregion

		#region expression

		[Test]
		public void GenerateSyntaxError ()
		{
			MJCP.Expression input = new MJCP.Expression (MJCP.Expression.Operation.SyntaxError, new TextSpan (0,0,0,0,0,0));
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			Assert.IsNull (gen.Generate (input), "#1");
		}

		[Test]
		public void Generatethis ()
		{
			MJCP.Expression input = new MJCP.Expression (MJCP.Expression.Operation.@this, new TextSpan (0,0,0,0,0,0));
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.MethodCallExpression), exp, "#1");
			//here strange so must detect that there is no parent function
			Assert.AreEqual ("GetGlobalObject", ((MSIA.MethodCallExpression)exp).Method.Name, "#2");
			Assert.IsNull ( ((MSIA.MethodCallExpression)exp).Instance, "#3");
			Assert.AreEqual (1,((MSIA.MethodCallExpression)exp).Arguments.Count, "#4");
			Assert.IsInstanceOfType (typeof (MSIA.CodeContextExpression), ((MSIA.MethodCallExpression)exp).Arguments[0], "#5");

			// 2cd pass with a parent function to have a real this
			Parser parser = new Parser ("function foo () { var bar; this.bar=5;}".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			exp = gen.Generate (input);
			IList<MSIA.Statement> statements = ((MSIA.BlockStatement)((MSIA.CodeBlockExpression)((MSIA.MethodCallExpression)((MSIA.BoundAssignment)exp).Value).Arguments[3]).Block.Body).Statements;
			exp = ((MSIA.ExpressionStatement)statements[0]).Expression;//the this
			Assert.IsInstanceOfType (typeof (MSIA.BoundAssignment), exp, "#6");
			//((MSIA.BoundAssignment)exp).Reference.Name.
			//maptable.

		}

		[Test]
		public void GenerateFalse ()
		{
			Parser parser = new Parser ("false;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.ConstantExpression), exp, "#1");
			Assert.AreEqual (false, ((MSIA.ConstantExpression)exp).Value, "#2");
		}

		[Test]
		public void GenerateTrue()
		{
			Parser parser = new Parser ("true;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.ConstantExpression), exp, "#1");
			Assert.AreEqual (true, ((MSIA.ConstantExpression)exp).Value, "#2");
		}

		//TODO : fix this test
		[Test]
		public void GenerateIdentifier ()
		{
			Parser parser = new Parser ("foo;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.BoundExpression), exp, "#1");
			Assert.AreEqual (maptable.GetRowanID (idtable.InsertIdentifier("foo")), ((MSIA.BoundExpression)exp).Reference.Name, "#2");
		}

		[Test]
		public void GenerateNumeric ()
		{
			Parser parser = new Parser ("5;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.ConstantExpression), exp, "#1");
			Assert.AreEqual (5, ((MSIA.ConstantExpression)exp).Value, "#2");
		}
		
		[Test]
		public void GenerateHex ()
		{
			Parser parser = new Parser ("0x15;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.ConstantExpression), exp, "#1");
			Assert.AreEqual (21, ((MSIA.ConstantExpression)exp).Value, "#2");
		}

		[Test]
		public void GenerateOctal ()
		{
			Parser parser = new Parser ("015;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.ConstantExpression), exp, "#1");
			Assert.AreEqual (13, ((MSIA.ConstantExpression)exp).Value, "#2");
		}
		
		[Test]
		public void GenerateString ()
		{
			Parser parser = new Parser ("\"bar\";".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.ConstantExpression), exp, "#1");
			Assert.AreEqual ("bar", ((MSIA.ConstantExpression)exp).Value, "#2");
		}

		[Test]
		public void GenerateArray ()
		{
			Parser parser = new Parser ("[3, 2, 1];".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.MethodCallExpression), exp, "#1");
			Assert.AreEqual (typeof (MJR.JSCompilerHelpers).GetMethod ("ConstructArrayFromArrayLiteral"), ((MSIA.MethodCallExpression)exp).Method, "#2");
		}

		[Test]
		public void GenerateParenthesized ()
		{
			Parser parser = new Parser ("(47);".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.ParenthesisExpression), exp, "#1");
		}


		/*
		case MJCP.Expression.Operation.RegularExpressionLiteral :
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
		 */

		#endregion

		[Test]
		public void SetGlobals ()
		{
			//gen.SetGlobals();
		}
	}
}
