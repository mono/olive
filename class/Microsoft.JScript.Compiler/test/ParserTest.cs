using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Core;
using NUnit.Framework;
using Mono.JScript.Compiler;

namespace Mono.JScript.Compiler.Tests
{
	[TestFixture]
	public class ParserTest
	{
		[Test]
		public void SyntaxOKTest()
		{
			Parser parser = new Parser("var } function + i 'Hello',".ToCharArray());
			List<Comment> comments = new List<Comment> ();
			parser.ParseProgram (ref comments);
			Assert.IsFalse (parser.SyntaxOK());
		}

		[Test]
		public void VarTest ()
		{
			Parser parser = new Parser ("var a = 10;".ToCharArray ());
			List<Comment> comments = new List<Comment> ();
			parser.ParseProgram (ref comments);
			Assert.IsTrue (parser.SyntaxOK ());
		}
	}
}
