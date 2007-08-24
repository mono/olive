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
			Assert.AreEqual (val, result.Arguments[1], "#4"); //bug here whereas is equal
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
			Assert.IsInstanceOfType (typeof (MJCP.FunctionStatement), input, "#1");//bug here
			MJCP.FunctionDefinition def = ((MJCP.FunctionStatement)input).Function;

			MSIA.Statement result = gen.Generate (def);
			
			Assert.IsInstanceOfType (typeof (MSIA.ExpressionStatement), result, "#2");
			MSIA.ExpressionStatement sta = (MSIA.ExpressionStatement) result;
			Assert.IsInstanceOfType (typeof (MSIA.BoundAssignment), sta.Expression, "#3");
			MSIA.BoundAssignment exp = ((MSIA.BoundAssignment)sta.Expression);
			Assert.IsInstanceOfType (typeof (MSIA.MethodCallExpression), exp.Value, "#4");
			//TODO
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
		}

		[Test]
		public void SetGlobals ()
		{
			//gen.SetGlobals();
		}
	}
}
