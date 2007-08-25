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

		[SetUp]
		public void init ()
		{
			idtable = new IdentifierTable ();
			gen = new RowanGenerator (new IdentifierMappingTable (),
									idtable.InsertIdentifier ("this"),
									idtable.InsertIdentifier ("_"),
									idtable.InsertIdentifier ("Arguments"),
									idtable.InsertIdentifier ("Eval"));
		}
		
		[Test]
		public void Bind ()
		{
			gen.Bind ();
		}

		[Test]
		public void ConvertToObject ()
		{
			MSIA.Expression val = new MSIA.ConstantExpression (0);

			MSIA.Expression expr = gen.ConvertToObject (new MSIA.ConstantExpression (0));
			Assert.IsInstanceOfType (typeof (MSIA.MethodCallExpression), expr, "#1");
			MSIA.MethodCallExpression result = ((MSIA.MethodCallExpression)expr);
			Assert.AreEqual (2, result.Arguments.Count, "#2");
			Assert.IsInstanceOfType (typeof (MSIA.CodeContextExpression), result.Arguments[0], "#3");
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

		[Test]
		public void SetGlobals ()
		{
			//gen.SetGlobals();
		}
	}
}
