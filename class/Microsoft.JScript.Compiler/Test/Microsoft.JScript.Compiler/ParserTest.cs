using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Core;
using NUnit.Framework;
using Microsoft.JScript.Compiler;
using Microsoft.JScript.Compiler.ParseTree;

namespace MonoTests.Microsoft.JScript.Compiler
{
	[TestFixture]
	public class ParserTest
	{
		[Test]
		public void SyntaxOKTest ()
		{
			Parser parser = new Parser ("var } function + i 'Hello',".ToCharArray());
			List<Comment> comments = new List<Comment> ();
			parser.ParseProgram (ref comments);
			Assert.IsFalse (parser.SyntaxOK ());
		}

		[Test]
		public void VarTest ()
		{
			Parser parser = new Parser ("var a = 10;".ToCharArray ());
			List<Comment> comments = new List<Comment> ();
			DList<Statement, BlockStatement > list = parser.ParseProgram (ref comments);
			DList<Statement, BlockStatement>.Iterator it = new DList<Statement,BlockStatement>.Iterator(list);
			Assert.IsInstanceOfType (typeof(VariableDeclarationStatement), it.Element, "#1.1");
			//VariableDeclarationStatement var = ((VariableDeclarationStatement)it.Element);
			//TODO check value 10
			Assert.IsTrue (parser.SyntaxOK ());
		}

		[Test]
		public void FunctionTest ()
		{
			Parser parser = new Parser ("function foo() {}".ToCharArray ());
			List<Comment> comments = new List<Comment> ();
			DList<Statement, BlockStatement> list = parser.ParseProgram (ref comments);
			DList<Statement, BlockStatement>.Iterator it = new DList<Statement, BlockStatement>.Iterator (list);
			Assert.IsInstanceOfType (typeof (FunctionStatement), it.Element, "#2.1");
			FunctionStatement foo = ((FunctionStatement)it.Element);
			Assert.AreEqual ("foo", foo.Function.Name.Spelling, "#2.2");
			Assert.IsTrue (parser.SyntaxOK ());
		}

		[Test]
		public void BlockTest ()
		{
			Parser parser = new Parser ("{}".ToCharArray ());
			List<Comment> comments = new List<Comment> ();
			DList<Statement, BlockStatement> list = parser.ParseProgram (ref comments);
			DList<Statement, BlockStatement>.Iterator it = new DList<Statement, BlockStatement>.Iterator (list);
			Assert.IsInstanceOfType (typeof (BlockStatement), it.Element, "#3.1");
			Assert.IsTrue (parser.SyntaxOK ());
		}

		[Test]
		public void IfTest ()
		{
			Parser parser = new Parser ("if (true) { } else  ;".ToCharArray ());
			List<Comment> comments = new List<Comment> ();
			DList<Statement, BlockStatement> list = parser.ParseProgram (ref comments);
			DList<Statement, BlockStatement>.Iterator it = new DList<Statement, BlockStatement>.Iterator (list);
			Assert.IsInstanceOfType (typeof (IfStatement), it.Element, "#4.1");
			IfStatement ifelse = ((IfStatement)it.Element);
			Assert.AreEqual (Expression.Operation.@true, ifelse.Condition.Opcode, "#4.2");
			Assert.IsTrue (parser.SyntaxOK ());
		}

		[Test]
		public void WhileTest ()
		{
			Parser parser = new Parser ("while (true) { }".ToCharArray ());
			List<Comment> comments = new List<Comment> ();
			DList<Statement, BlockStatement> list = parser.ParseProgram (ref comments);
			DList<Statement, BlockStatement>.Iterator it = new DList<Statement, BlockStatement>.Iterator (list);
			Assert.IsInstanceOfType (typeof (WhileStatement), it.Element, "#5.1");
			WhileStatement whilest = ((WhileStatement)it.Element);
			Assert.AreEqual (Expression.Operation.@true, whilest.Condition.Opcode,  "#5.2");
			Assert.IsTrue (parser.SyntaxOK ());
		}

		[Test]
		public void DoWhileTest ()
		{
			Parser parser = new Parser ("do { }while (true);".ToCharArray ());
			List<Comment> comments = new List<Comment> ();
			DList<Statement, BlockStatement> list = parser.ParseProgram (ref comments);
			DList<Statement, BlockStatement>.Iterator it = new DList<Statement, BlockStatement>.Iterator (list);
			Assert.IsInstanceOfType (typeof (DoStatement), it.Element, "#6.1");
			DoStatement dost = ((DoStatement)it.Element);
			Assert.AreEqual (Expression.Operation.@true, dost.Condition.Opcode, "#6.2");
			Assert.IsTrue (parser.SyntaxOK ());
		}

		[Test]
		public void ForTest ()
		{
			Parser parser = new Parser ("for (var i = 0 ; i < 5 ; i++ ) { }".ToCharArray ());
			List<Comment> comments = new List<Comment> ();
			DList<Statement, BlockStatement> list = parser.ParseProgram (ref comments);
			DList<Statement, BlockStatement>.Iterator it = new DList<Statement, BlockStatement>.Iterator (list);
			Assert.IsInstanceOfType (typeof (DeclarationForStatement), it.Element, "#7.1");
			DeclarationForStatement forst = ((DeclarationForStatement)it.Element);
			//Assert.AreEqual (Expression.Operation.@true, forst.Initial.i.Condition.Opcode, "#7.2");
			//TODO
			Assert.IsTrue (parser.SyntaxOK ());
		}

	}
}
