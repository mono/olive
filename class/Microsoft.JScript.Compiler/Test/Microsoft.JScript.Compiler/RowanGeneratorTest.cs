using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.JScript.Compiler;
using NUnit.Core;
using NUnit.Framework;
using MSIA = Microsoft.Scripting.Ast;
using MSA = Microsoft.Scripting.Actions;
using MJCP = Microsoft.JScript.Compiler.ParseTree;
using MJR = Microsoft.JScript.Runtime;
using MSO = Microsoft.Scripting.Operators;
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
			//Assert.IsInstanceOfType (typeof (string[]), ((MSIA.NewArrayExpression)call.Arguments[4]).ExpressionType, "#7.5.1");
			
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

		[Test]
		public void GenerateIdentifier ()
		{
			Parser parser = new Parser ("foo;".ToCharArray (), idtable);
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.BoundExpression), exp, "#1");
			Assert.AreEqual (maptable.GetRowanID (idtable.InsertIdentifier ("foo")), ((MSIA.BoundExpression)exp).Name, "#2");
			Assert.AreEqual (maptable.GetRowanID (idtable.InsertIdentifier("foo")), ((MSIA.BoundExpression)exp).Reference.Name, "#3");
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
		
		[Test]
		public void GenerateInvocation ()
		{
			Parser parser = new Parser ("foo();".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.ActionExpression), exp, "#1");
			Assert.IsInstanceOfType (typeof (MSA.CallAction), ((MSIA.ActionExpression)exp).Action, "#2");
		}

		[Test]
		public void GenerateSubscript ()
		{
			Parser parser = new Parser ("this.foo[0];".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.ActionExpression), exp, "#1");
			Assert.IsInstanceOfType (typeof (MSA.DoOperationAction), ((MSIA.ActionExpression)exp).Action, "#2");
			Assert.AreEqual (MSO.GetItem, ((MSA.DoOperationAction)((MSIA.ActionExpression)exp).Action).Operation, "#3");
		}

		[Test]
		public void GenerateQualified ()
		{
			Parser parser = new Parser ("this.foo;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.ActionExpression), exp, "#1");
			Assert.IsInstanceOfType (typeof (MSA.GetMemberAction), ((MSIA.ActionExpression)exp).Action, "#2");
		}

		[Test]
		public void GenerateNew ()
		{
			Parser parser = new Parser ("new foo();".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.DynamicNewExpression), exp, "#1");
		}

		[Test]
		public void GenerateFunctionExp ()
		{
			Parser parser = new Parser ("function foo() {}".ToCharArray (), idtable);
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.BoundAssignment), exp, "#1");
			Assert.AreEqual (MSO.None, ((MSIA.BoundAssignment)exp).Operator, "#2");
			//TODO more test
		}

		[Test]
		public void GenerateDelete ()
		{
			Parser parser = new Parser ("delete foo;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.MethodCallExpression), exp, "#1");
			Assert.AreEqual (typeof (MJR.JSCompilerHelpers).GetMethod ("Delete"), ((MSIA.MethodCallExpression)exp).Method, "#2");
		}

		[Test]
		public void GenerateVoid ()
		{
			Parser parser = new Parser ("void foo;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.MethodCallExpression), exp, "#1");
			Assert.AreEqual (typeof (MJR.JSCompilerHelpers).GetMethod ("Void"), ((MSIA.MethodCallExpression)exp).Method, "#2");
		}

		[Test]
		public void GenerateTypeof ()
		{
			Parser parser = new Parser ("typeof foo;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.MethodCallExpression), exp, "#1");
			Assert.AreEqual (typeof (MJR.JSCompilerHelpers).GetMethod ("TypeOf"), ((MSIA.MethodCallExpression)exp).Method, "#2");
		}

		[Test]
		public void GeneratePrefixPlusPlus ()
		{
			Parser parser = new Parser ("++foo;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.BoundAssignment), exp, "#1");
			Assert.IsInstanceOfType (typeof (MSIA.ActionExpression), ((MSIA.BoundAssignment)exp).Value, "#2");
			MSA.Action action = ((MSIA.ActionExpression)((MSIA.BoundAssignment)exp).Value).Action;
			Assert.IsInstanceOfType (typeof (MSA.DoOperationAction), action, "#3");
			Assert.AreEqual (MSO.Add, ((MSA.DoOperationAction)action).Operation, "#4");
		}

		[Test]
		public void GeneratePrefixMinusMinus ()
		{
			Parser parser = new Parser ("--foo;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.BoundAssignment), exp, "#1");
			Assert.IsInstanceOfType (typeof (MSIA.ActionExpression), ((MSIA.BoundAssignment)exp).Value, "#2");
			MSA.Action action = ((MSIA.ActionExpression)((MSIA.BoundAssignment)exp).Value).Action;
			Assert.IsInstanceOfType (typeof (MSA.DoOperationAction), action, "#3");
			Assert.AreEqual (MSO.Subtract, ((MSA.DoOperationAction)action).Operation, "#4");
		}

		[Test]
		public void GeneratePrefixPlus ()
		{
			Parser parser = new Parser ("+foo;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.MethodCallExpression), exp, "#1");
			Assert.AreEqual (typeof (MJR.JSCompilerHelpers).GetMethod ("Positive"), ((MSIA.MethodCallExpression)exp).Method, "#2");
		}

		[Test]
		public void GeneratePrefixMinus ()
		{
			Parser parser = new Parser ("-foo;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.MethodCallExpression), exp, "#1");
			Assert.AreEqual (typeof (MJR.JSCompilerHelpers).GetMethod ("Negate"), ((MSIA.MethodCallExpression)exp).Method, "#2");
		}

		[Test]
		public void GenerateTilda ()
		{
			Parser parser = new Parser ("~foo;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.MethodCallExpression), exp, "#1");
			Assert.AreEqual (typeof (MJR.JSCompilerHelpers).GetMethod ("OnesComplement"), ((MSIA.MethodCallExpression)exp).Method, "#2");
		}

		[Test]
		public void GenerateBang ()
		{
			Parser parser = new Parser ("!foo;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.MethodCallExpression), exp, "#1");
			Assert.AreEqual (typeof (MJR.JSCompilerHelpers).GetMethod ("Not"), ((MSIA.MethodCallExpression)exp).Method, "#2");
		}

		[Test]
		public void GeneratePostfixPlusPlus ()
		{
			Parser parser = new Parser ("foo++;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.CommaExpression), exp, "#1");
			Assert.AreEqual (2, ((MSIA.CommaExpression)exp).Expressions.Count, "#2");
			Assert.IsInstanceOfType (typeof (MSIA.BoundAssignment), ((MSIA.CommaExpression)exp).Expressions[0], "#3");
			Assert.IsInstanceOfType (typeof (MSIA.BoundAssignment), ((MSIA.CommaExpression)exp).Expressions[1], "#4");
			Assert.IsInstanceOfType (typeof (MSIA.MethodCallExpression), ((MSIA.BoundAssignment)((MSIA.CommaExpression)exp).Expressions[0]).Value, "#5");
			Assert.AreEqual (typeof (MJR.Convert).GetMethod ("ToNumber", new Type[] {typeof(object)}), ((MSIA.MethodCallExpression)((MSIA.BoundAssignment)((MSIA.CommaExpression)exp).Expressions[0]).Value).Method, "#6");
			Assert.IsInstanceOfType (typeof (MSIA.ActionExpression), ((MSIA.BoundAssignment)((MSIA.CommaExpression)exp).Expressions[1]).Value, "#7");
			MSIA.ActionExpression  action = (MSIA.ActionExpression)((MSIA.BoundAssignment)((MSIA.CommaExpression)exp).Expressions[1]).Value;
			Assert.IsInstanceOfType (typeof (MSA.DoOperationAction), action.Action, "#8");
			Assert.AreEqual (MSO.Add, ((MSA.DoOperationAction)action.Action).Operation, "#9");
		}

		[Test]
		public void GeneratePostfixMinusMinus ()
		{
			Parser parser = new Parser ("foo--;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.CommaExpression), exp, "#1");
			Assert.AreEqual (2, ((MSIA.CommaExpression)exp).Expressions.Count, "#2");
			Assert.IsInstanceOfType (typeof (MSIA.BoundAssignment), ((MSIA.CommaExpression)exp).Expressions[0], "#3");
			Assert.IsInstanceOfType (typeof (MSIA.BoundAssignment), ((MSIA.CommaExpression)exp).Expressions[1], "#4");
			Assert.IsInstanceOfType (typeof (MSIA.MethodCallExpression), ((MSIA.BoundAssignment)((MSIA.CommaExpression)exp).Expressions[0]).Value, "#5");
			Assert.AreEqual (typeof (MJR.Convert).GetMethod ("ToNumber", new Type[] {typeof(object)}), ((MSIA.MethodCallExpression)((MSIA.BoundAssignment)((MSIA.CommaExpression)exp).Expressions[0]).Value).Method, "#6");
			Assert.IsInstanceOfType (typeof (MSIA.ActionExpression), ((MSIA.BoundAssignment)((MSIA.CommaExpression)exp).Expressions[1]).Value, "#7");
			MSIA.ActionExpression action = (MSIA.ActionExpression)((MSIA.BoundAssignment)((MSIA.CommaExpression)exp).Expressions[1]).Value;
			Assert.IsInstanceOfType (typeof (MSA.DoOperationAction), action.Action, "#8");
			Assert.AreEqual (MSO.Subtract, ((MSA.DoOperationAction)action.Action).Operation, "#9");
		}

		[Test]
		public void GenerateComma ()
		{
			Parser parser = new Parser ("1,5;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.CommaExpression), exp, "#1");
			Assert.AreEqual (1, ((MSIA.CommaExpression)exp).ValueIndex, "#1");
		}
		
		[Test]
		public void GenerateEqual ()
		{
			Parser parser = new Parser ("foo = 5;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.BoundAssignment), exp, "#1");
			Assert.AreEqual (MSO.None, ((MSIA.BoundAssignment)exp).Operator, "#2");
		}

		[Test]
		public void GenerateStarEqual ()
		{
			Parser parser = new Parser ("foo *= 5;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.BoundAssignment), exp, "#1");
			Assert.AreEqual (MSO.InPlaceMultiply, ((MSIA.BoundAssignment)exp).Operator, "#2");
		}

		[Test]
		public void GenerateDivideEqual ()
		{
			Parser parser = new Parser ("foo /= 5;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.BoundAssignment), exp, "#1");
			Assert.AreEqual (MSO.InPlaceDivide, ((MSIA.BoundAssignment)exp).Operator, "#2");
		}

		[Test]
		public void GeneratePercentEqual ()
		{
			Parser parser = new Parser ("foo %= 5;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.BoundAssignment), exp, "#1");
			Assert.AreEqual (MSO.InPlaceMod, ((MSIA.BoundAssignment)exp).Operator, "#2");
		}

		[Test]
		public void GeneratePlusEqual ()
		{
			Parser parser = new Parser ("foo += 5;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.BoundAssignment), exp, "#1");
			Assert.AreEqual (MSO.InPlaceAdd, ((MSIA.BoundAssignment)exp).Operator, "#2");
		}

		[Test]
		public void GenerateMinusEqual ()
		{
			Parser parser = new Parser ("foo -= 5;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.BoundAssignment), exp, "#1");
			Assert.AreEqual (MSO.InPlaceSubtract, ((MSIA.BoundAssignment)exp).Operator, "#2");
		}

		[Test]
		public void GenerateLessLessEqual ()
		{
			Parser parser = new Parser ("foo <<= 5;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.BoundAssignment), exp, "#1");
			Assert.AreEqual (MSO.InPlaceLeftShift, ((MSIA.BoundAssignment)exp).Operator, "#2");
		}

		[Test]
		public void GenerateGreaterGreaterEqual ()
		{
			Parser parser = new Parser ("foo >>= 5;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.BoundAssignment), exp, "#1");
			Assert.AreEqual (MSO.InPlaceRightShift, ((MSIA.BoundAssignment)exp).Operator, "#2");
		}
		
		[Test]
		public void GenerateGreaterGreaterGreaterEqual ()
		{
			Parser parser = new Parser ("foo >>>= 5;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.BoundAssignment), exp, "#1");
			Assert.AreEqual (MSO.InPlaceRightShiftUnsigned, ((MSIA.BoundAssignment)exp).Operator, "#2");
		}

		[Test]
		public void GenerateAmpersandEqual ()
		{
			Parser parser = new Parser ("foo &= 5;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.BoundAssignment), exp, "#1");
			Assert.AreEqual (MSO.InPlaceBitwiseAnd, ((MSIA.BoundAssignment)exp).Operator, "#2");
		}

		[Test]
		public void GenerateCircumflexEqual ()
		{
			Parser parser = new Parser ("foo ^= 5;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.BoundAssignment), exp, "#1");
			Assert.AreEqual (MSO.InPlaceXor, ((MSIA.BoundAssignment)exp).Operator, "#2");
		}

		[Test]
		public void GenerateBarEqual ()
		{
			Parser parser = new Parser ("foo |= 5;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.BoundAssignment), exp, "#1");
			Assert.AreEqual (MSO.InPlaceBitwiseOr, ((MSIA.BoundAssignment)exp).Operator, "#2");
		}

		[Test]
		public void GenerateBarBar ()
		{
			Parser parser = new Parser ("true || false;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.OrExpression), exp, "#1");
		}

		[Test]
		public void GenerateAmpersandAmpersand ()
		{
			Parser parser = new Parser ("true && false;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.AndExpression), exp, "#1");
		}

		[Test]
		public void GenerateBar ()
		{
			Parser parser = new Parser ("0 | 1;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.ActionExpression), exp, "#1");
			Assert.IsInstanceOfType (typeof (MSA.DoOperationAction), ((MSIA.ActionExpression)exp).Action, "#2");
			Assert.AreEqual (MSO.BitwiseOr, ((MSA.DoOperationAction)((MSIA.ActionExpression)exp).Action).Operation, "#3");
		}

		[Test]
		public void GenerateCircumflex ()
		{
			Parser parser = new Parser ("0 ^ 1;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.ActionExpression), exp, "#1");
			Assert.IsInstanceOfType (typeof (MSA.DoOperationAction), ((MSIA.ActionExpression)exp).Action, "#2");
			Assert.AreEqual (MSO.Xor, ((MSA.DoOperationAction)((MSIA.ActionExpression)exp).Action).Operation, "#3");
		}

		[Test]
		public void GenerateAmpersand ()
		{
			Parser parser = new Parser ("0 & 1;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.ActionExpression), exp, "#1");
			Assert.IsInstanceOfType (typeof (MSA.DoOperationAction), ((MSIA.ActionExpression)exp).Action, "#2");
			Assert.AreEqual (MSO.BitwiseAnd, ((MSA.DoOperationAction)((MSIA.ActionExpression)exp).Action).Operation, "#3");
		}

		[Test]
		public void GenerateEqualEqual ()
		{
			Parser parser = new Parser ("0 == 1;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.ActionExpression), exp, "#1");
			Assert.IsInstanceOfType (typeof (MSA.DoOperationAction), ((MSIA.ActionExpression)exp).Action, "#2");
			Assert.AreEqual (MSO.Equal, ((MSA.DoOperationAction)((MSIA.ActionExpression)exp).Action).Operation, "#3");
		}

		[Test]
		public void GenerateBangEqual ()
		{
			Parser parser = new Parser ("0 != 1;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.ActionExpression), exp, "#1");
			Assert.IsInstanceOfType (typeof (MSA.DoOperationAction), ((MSIA.ActionExpression)exp).Action, "#2");
			Assert.AreEqual (MSO.NotEqual, ((MSA.DoOperationAction)((MSIA.ActionExpression)exp).Action).Operation, "#3");
		}

		[Test]
		public void GenerateEqualEqualEqual ()
		{
			Parser parser = new Parser ("0 === 1;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.MethodCallExpression), exp, "#1");
			Assert.AreEqual (typeof (MJR.JSCompilerHelpers).GetMethod ("Is"), ((MSIA.MethodCallExpression)exp).Method, "#2");
		}

		[Test]
		public void GenerateBangEqualEqual ()
		{
			Parser parser = new Parser ("0 !== 1;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.MethodCallExpression), exp, "#1");
			Assert.AreEqual (typeof (MJR.JSCompilerHelpers).GetMethod ("IsNot"), ((MSIA.MethodCallExpression)exp).Method, "#2");
		}

		[Test]
		public void GenerateLess ()
		{
			Parser parser = new Parser ("0 < 1;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.ActionExpression), exp, "#1");
			Assert.IsInstanceOfType (typeof (MSA.DoOperationAction), ((MSIA.ActionExpression)exp).Action, "#2");
			Assert.AreEqual (MSO.LessThan, ((MSA.DoOperationAction)((MSIA.ActionExpression)exp).Action).Operation, "#3");
		}

		[Test]
		public void GenerateGreater ()
		{
			Parser parser = new Parser ("0 > 1;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.ActionExpression), exp, "#1");
			Assert.IsInstanceOfType (typeof (MSA.DoOperationAction), ((MSIA.ActionExpression)exp).Action, "#2");
			Assert.AreEqual (MSO.GreaterThan, ((MSA.DoOperationAction)((MSIA.ActionExpression)exp).Action).Operation, "#3");
		}

		[Test]
		public void GenerateLessEqual ()
		{
			Parser parser = new Parser ("0 <= 1;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.ActionExpression), exp, "#1");
			Assert.IsInstanceOfType (typeof (MSA.DoOperationAction), ((MSIA.ActionExpression)exp).Action, "#2");
			Assert.AreEqual (MSO.LessThanOrEqual, ((MSA.DoOperationAction)((MSIA.ActionExpression)exp).Action).Operation, "#3");
		}

		[Test]
		public void GenerateGreaterEqual ()
		{
			Parser parser = new Parser ("0 >= 1;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.ActionExpression), exp, "#1");
			Assert.IsInstanceOfType (typeof (MSA.DoOperationAction), ((MSIA.ActionExpression)exp).Action, "#2");
			Assert.AreEqual (MSO.GreaterThanOrEqual, ((MSA.DoOperationAction)((MSIA.ActionExpression)exp).Action).Operation, "#3");
		}

		[Test]
		public void GenerateInstanceof ()
		{
			Parser parser = new Parser ("bar instanceof foo;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.MethodCallExpression), exp, "#1");
			Assert.AreEqual (typeof (MJR.JSCompilerHelpers).GetMethod ("InstanceOf"), ((MSIA.MethodCallExpression)exp).Method, "#2");
		}

		[Test]
		public void GenerateIn ()
		{
			Parser parser = new Parser ("foo in bar;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.MethodCallExpression), exp, "#1");
			Assert.AreEqual (typeof (MJR.JSCompilerHelpers).GetMethod ("In"), ((MSIA.MethodCallExpression)exp).Method, "#2");
		}

		[Test]
		public void GenerateLessLess ()
		{
			Parser parser = new Parser ("foo << 1;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.ActionExpression), exp, "#1");
			Assert.IsInstanceOfType (typeof (MSA.DoOperationAction), ((MSIA.ActionExpression)exp).Action, "#2");
			Assert.AreEqual (MSO.LeftShift, ((MSA.DoOperationAction)((MSIA.ActionExpression)exp).Action).Operation, "#3");
		}

		[Test]
		public void GenerateGreaterGreater ()
		{
			Parser parser = new Parser ("foo >> 1;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.ActionExpression), exp, "#1");
			Assert.IsInstanceOfType (typeof (MSA.DoOperationAction), ((MSIA.ActionExpression)exp).Action, "#2");
			Assert.AreEqual (MSO.RightShift, ((MSA.DoOperationAction)((MSIA.ActionExpression)exp).Action).Operation, "#3");
		}

		[Test]
		public void GenerateGreaterGreaterGreater ()
		{
			Parser parser = new Parser ("foo >>> 1;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.ActionExpression), exp, "#1");
			Assert.IsInstanceOfType (typeof (MSA.DoOperationAction), ((MSIA.ActionExpression)exp).Action, "#2");
			Assert.AreEqual (MSO.RightShiftUnsigned, ((MSA.DoOperationAction)((MSIA.ActionExpression)exp).Action).Operation, "#3");
		}
		
		[Test]
		public void GeneratePlus ()
		{
			Parser parser = new Parser ("foo + 1;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.ActionExpression), exp, "#1");
			Assert.IsInstanceOfType (typeof (MSA.DoOperationAction), ((MSIA.ActionExpression)exp).Action, "#2");
			Assert.AreEqual (MSO.Add, ((MSA.DoOperationAction)((MSIA.ActionExpression)exp).Action).Operation, "#3");
		}

		[Test]
		public void GenerateMinus ()
		{
			Parser parser = new Parser ("foo - 1;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.ActionExpression), exp, "#1");
			Assert.IsInstanceOfType (typeof (MSA.DoOperationAction), ((MSIA.ActionExpression)exp).Action, "#2");
			Assert.AreEqual (MSO.Subtract, ((MSA.DoOperationAction)((MSIA.ActionExpression)exp).Action).Operation, "#3");
		}

		[Test]
		public void GenerateStar ()
		{
			Parser parser = new Parser ("foo * 1;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.ActionExpression), exp, "#1");
			Assert.IsInstanceOfType (typeof (MSA.DoOperationAction), ((MSIA.ActionExpression)exp).Action, "#2");
			Assert.AreEqual (MSO.Multiply, ((MSA.DoOperationAction)((MSIA.ActionExpression)exp).Action).Operation, "#3");
		}

		[Test]
		public void GenerateDivide ()
		{
			Parser parser = new Parser ("foo / 1;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.ActionExpression), exp, "#1");
			Assert.IsInstanceOfType (typeof (MSA.DoOperationAction), ((MSIA.ActionExpression)exp).Action, "#2");
			Assert.AreEqual (MSO.Divide, ((MSA.DoOperationAction)((MSIA.ActionExpression)exp).Action).Operation, "#3");
		}
		
		[Test]
		public void GeneratePercent ()
		{
			Parser parser = new Parser ("foo % 1;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.ActionExpression), exp, "#1");
			Assert.IsInstanceOfType (typeof (MSA.DoOperationAction), ((MSIA.ActionExpression)exp).Action, "#2");
			Assert.AreEqual (MSO.Mod, ((MSA.DoOperationAction)((MSIA.ActionExpression)exp).Action).Operation, "#3");
		}

		[Test]
		public void GenerateQuestion ()
		{
			Parser parser = new Parser ("foo?1:0;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.ConditionalExpression), exp, "#1");
		}
		
		[Test]
		public void GenerateNull ()
		{
			Parser parser = new Parser ("null;".ToCharArray ());
			List<Comment> comms = new List<Comment> ();
			MJCP.Expression input = parser.ParseExpression (ref comms);
			gen.SetGlobals (new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ()));
			MSIA.Expression exp = gen.Generate (input);
			Assert.IsInstanceOfType (typeof (MSIA.ConstantExpression), exp, "#1");
			Assert.IsNull (((MSIA.ConstantExpression)exp).Value, "#2");
		}

		//TODO
		[Test]
		[Ignore]
		public void GenerateRegularExpressionLiteral ()
		{
			Assert.Fail ();
		}

		#endregion

		//TODO
		[Test]
		[Ignore]
		public void SetGlobals ()
		{
			MSIA.CodeBlock globals = new MSIA.CodeBlock ("", new List<MSIA.Parameter> (0), new MSIA.EmptyStatement ());
			gen.SetGlobals (globals);
			Assert.Fail ();
		}
	}
}
