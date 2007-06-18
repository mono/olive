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
			Assert.IsTrue (it.Element is VariableDeclarationStatement,"#1 :"+ it.Element.GetType().ToString());
			//VariableDeclarationStatement var = ((VariableDeclarationStatement)it.Element);
			//TODO check value 10
			Assert.IsTrue (parser.SyntaxOK ());
		}

	}
}
