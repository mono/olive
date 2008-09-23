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
using NUnit.Core;
using NUnit.Framework;
using Microsoft.JScript.Compiler;
using Microsoft.JScript.Compiler.ParseTree;

namespace MonoTests.Microsoft.JScript.Compiler
{
	[TestFixture]
	public class ParserTest
	{
		Parser parser;

		[Test]
		public void SyntaxOKTest ()
		{
			parser = new Parser ("var } function + i 'Hello',".ToCharArray ());
			List<Comment> comments = new List<Comment> ();
			parser.ParseProgram (ref comments);
			Assert.IsFalse (parser.SyntaxOK ());
		}

		# region statements

		[Test]
		public void VarTest ()
		{
			parser = new Parser ("var a = 10;".ToCharArray ());
			List<Comment> comments = new List<Comment> ();
			DList<Statement, BlockStatement > list = parser.ParseProgram (ref comments);
			DList<Statement, BlockStatement>.Iterator it = new DList<Statement,BlockStatement>.Iterator(list);
			Assert.IsInstanceOfType (typeof(VariableDeclarationStatement), it.Element, "#1.1");
			Assert.IsTrue (parser.SyntaxOK ());
		}

		[Test]
		public void FunctionTest ()
		{
			parser = new Parser ("function foo() {}".ToCharArray ());
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
			parser = new Parser ("{}".ToCharArray ());
			List<Comment> comments = new List<Comment> ();
			DList<Statement, BlockStatement> list = parser.ParseProgram (ref comments);
			DList<Statement, BlockStatement>.Iterator it = new DList<Statement, BlockStatement>.Iterator (list);
			Assert.IsInstanceOfType (typeof (BlockStatement), it.Element, "#3.1");
			Assert.IsTrue (parser.SyntaxOK ());
		}

		[Test]
		public void IfTest ()
		{
			parser = new Parser ("if (true) { } else  ;".ToCharArray ());
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
			parser = new Parser ("while (true) { }".ToCharArray ());
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
			parser = new Parser ("do { }while (true);".ToCharArray ());
			List<Comment> comments = new List<Comment> ();
			DList<Statement, BlockStatement> list = parser.ParseProgram (ref comments);
			DList<Statement, BlockStatement>.Iterator it = new DList<Statement, BlockStatement>.Iterator (list);
			Assert.IsInstanceOfType (typeof (DoStatement), it.Element, "#6.1");
			DoStatement dost = ((DoStatement)it.Element);
			Assert.AreEqual (Expression.Operation.@true, dost.Condition.Opcode, "#6.2");
			Assert.IsTrue (parser.SyntaxOK (), PrintSyntax ("#6", parser));
		}

		private string PrintSyntax (string id, Parser parser)
		{
			string result = string.Empty;
			foreach (Diagnostic d in parser.Diagnostics) {
				result += (id + Enum.GetName (typeof (DiagnosticCode), d.Code));
			}
			return result;
		}

		[Test]
		public void ForTest ()
		{
			parser = new Parser ("for (var i = 0 ; i < 5 ; i++ ) { break; }".ToCharArray ());
			List<Comment> comments = new List<Comment> ();
			DList<Statement, BlockStatement> list = parser.ParseProgram (ref comments);
			DList<Statement, BlockStatement>.Iterator it = new DList<Statement, BlockStatement>.Iterator (list);
			Assert.IsInstanceOfType (typeof (DeclarationForStatement), it.Element, "#7.1");
			DeclarationForStatement forst = ((DeclarationForStatement)it.Element);
			Assert.IsInstanceOfType (typeof (BlockStatement), forst.Body, "#7.2");
			it = new DList<Statement, BlockStatement>.Iterator (((BlockStatement)forst.Body).Children);
			Assert.IsInstanceOfType (typeof (BreakOrContinueStatement), it.Element, "#7.3");
			Assert.IsTrue (parser.SyntaxOK ());
		}

		[Test]
		public void WithTest ()
		{
			parser = new Parser ("with (test) {}".ToCharArray ());
			List<Comment> comments = new List<Comment> ();
			DList<Statement, BlockStatement> list = parser.ParseProgram (ref comments);
			DList<Statement, BlockStatement>.Iterator it = new DList<Statement, BlockStatement>.Iterator (list);
			Assert.IsInstanceOfType (typeof (WithStatement), it.Element, "#8.1");
			Assert.IsTrue (parser.SyntaxOK ());
		}

		[Test]
		public void switchTest ()
		{
			parser = new Parser ("switch (test) { case a: break; default: break;}".ToCharArray ());
			List<Comment> comments = new List<Comment> ();
			DList<Statement, BlockStatement> list = parser.ParseProgram (ref comments);
			DList<Statement, BlockStatement>.Iterator it = new DList<Statement, BlockStatement>.Iterator (list);
			Assert.IsInstanceOfType (typeof (SwitchStatement), it.Element, "#9.1");
			Assert.IsTrue (parser.SyntaxOK ());
		}

		[Test]
		public void TryTest ()
		{
			parser = new Parser ("try {} finally {}".ToCharArray ());
			List<Comment> comments = new List<Comment> ();
			DList<Statement, BlockStatement> list = parser.ParseProgram (ref comments);
			DList<Statement, BlockStatement>.Iterator it = new DList<Statement, BlockStatement>.Iterator (list);
			Assert.IsInstanceOfType (typeof (TryStatement), it.Element, "#10.1");
			Assert.IsTrue (parser.SyntaxOK ());
		}

		[Test]
		public void ThrowTest ()
		{
			parser = new Parser ("throw a;".ToCharArray ());
			List<Comment> comments = new List<Comment> ();
			DList<Statement, BlockStatement> list = parser.ParseProgram (ref comments);
			DList<Statement, BlockStatement>.Iterator it = new DList<Statement, BlockStatement>.Iterator (list);
			Assert.IsInstanceOfType (typeof (ReturnOrThrowStatement), it.Element, "#11.1");
			Assert.IsTrue (parser.SyntaxOK ());
		}

		[Test]
		public void ReturnTest ()
		{
			parser = new Parser ("return a;".ToCharArray ());
			List<Comment> comments = new List<Comment> ();
			DList<Statement, BlockStatement> list = parser.ParseProgram (ref comments);
			DList<Statement, BlockStatement>.Iterator it = new DList<Statement, BlockStatement>.Iterator (list);
			Assert.IsInstanceOfType (typeof (ReturnOrThrowStatement), it.Element, "#12.1");
			Assert.IsTrue (parser.SyntaxOK ());
		}

		[Test]
		public void EmptyTest ()
		{
			parser = new Parser (";".ToCharArray ());
			List<Comment> comments = new List<Comment> ();
			DList<Statement, BlockStatement> list = parser.ParseProgram (ref comments);
			DList<Statement, BlockStatement>.Iterator it = new DList<Statement, BlockStatement>.Iterator (list);
			Assert.AreEqual (Statement.Operation.Empty, it.Element.Opcode, "#12.1");
			Assert.IsTrue (parser.SyntaxOK ());
		}

		[Test]
		public void LabelTest ()
		{
			parser = new Parser ("a : {}".ToCharArray ());
			List<Comment> comments = new List<Comment> ();
			DList<Statement, BlockStatement> list = parser.ParseProgram (ref comments);
			DList<Statement, BlockStatement>.Iterator it = new DList<Statement, BlockStatement>.Iterator (list);
			Assert.IsInstanceOfType (typeof (LabelStatement), it.Element, "#12.1");
			Assert.IsTrue (parser.SyntaxOK ());
		}

		[Test]
		public void ReturnTest2 ()
		{
			parser = new Parser ("return ;".ToCharArray ());
			List<Comment> comments = new List<Comment> ();
			DList<Statement, BlockStatement> list = parser.ParseProgram (ref comments);
			DList<Statement, BlockStatement>.Iterator it = new DList<Statement, BlockStatement>.Iterator (list);
			Assert.IsInstanceOfType (typeof (ReturnOrThrowStatement), it.Element, "#14.1");
			Assert.IsTrue (parser.SyntaxOK ());
		}

		#endregion

		#region Expressions

		[Test]
		public void AddTest ()
		{
			Parser parser = new Parser ("var i = 5 + 1;".ToCharArray ());
			List<Comment> comments = new List<Comment> ();
			DList<Statement, BlockStatement> list = parser.ParseProgram (ref comments);
			DList<Statement, BlockStatement>.Iterator it = new DList<Statement, BlockStatement>.Iterator (list);
			Assert.IsInstanceOfType (typeof (VariableDeclarationStatement), it.Element, "#8.1");
			VariableDeclarationStatement varst = ((VariableDeclarationStatement)it.Element);
			Assert.AreEqual ("i", varst.Declarations[0].Declaration.Name.Spelling, "#8.2");
			Assert.IsInstanceOfType (typeof (InitializerVariableDeclaration), varst.Declarations[0].Declaration, "#8.3");
			InitializerVariableDeclaration ini = (InitializerVariableDeclaration)varst.Declarations[0].Declaration;
			Assert.IsInstanceOfType (typeof (BinaryOperatorExpression), ini.Initializer, "#8.4");
			Assert.AreEqual (Expression.Operation.Plus, ini.Initializer.Opcode, "#8.5");			 
			Assert.IsTrue (parser.SyntaxOK ());
		}

		#endregion

	}
}
