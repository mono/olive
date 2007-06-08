using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Core;
using NUnit.Framework;
using Mono.JScript.Compiler;

namespace MonoTests.JScript.Compiler
{
	[TestFixture]
	public class ParserTest
	{
		[Test]
		[Category ("NotWorking")]
		public void SyntaxOKTest()
		{
			Parser parser = new Parser("var } function + i 'Hello',".ToCharArray());
			List<Comment> comments = new List<Comment> ();
			parser.ParseProgram (ref comments);
			Assert.IsFalse (parser.SyntaxOK());
		}

		[Test]
		[Category ("NotWorking")]
		public void VarTest ()
		{
			Parser parser = new Parser ("var a = 10;".ToCharArray ());
			List<Comment> comments = new List<Comment> ();
			parser.ParseProgram (ref comments);
			Assert.IsTrue (parser.SyntaxOK ());
		}
	}
}
