using NUnit.Core;
using NUnit.Framework;
using Microsoft.JScript.Compiler;

namespace MonoTests.Microsoft.JScript.Compiler
{
	[TestFixture]
	public class TokenizerTest
	{
		[Test]
		public void AffectTest()
		{
			Tokenizer l1 = new Tokenizer ("var i = 10;".ToCharArray(), new IdentifierTable ());
			Assert.AreEqual (Token.Type.var, l1.GetNext ().Kind, "#1.1");
			Assert.AreEqual (Token.Type.Identifier, l1.GetNext().Kind,"#1.2");
			//Assert.AreEqual("i", l1.Value());
			Assert.AreEqual (Token.Type.Equal, l1.GetNext ().Kind, "#1.3");
			Assert.AreEqual (Token.Type.NumericLiteral, l1.GetNext ().Kind, "#1.4");
			//Assert.AreEqual("10", l1.Value());
			Assert.AreEqual (Token.Type.Semicolon, l1.GetNext ().Kind, "#1.5");    
			//Assert.IsFalse(l1.Advance());
			Assert.AreEqual (Token.Type.EndOfInput, l1.GetNext ().Kind, "#1.6");   
		}

		[Test]
		public void PlusTest()
		{
			Tokenizer l1 = new Tokenizer ("$test_var++;".ToCharArray (), new IdentifierTable ());
			Assert.AreEqual (Token.Type.Identifier, l1.GetNext ().Kind, "#2.1");
			//Assert.AreEqual("$test_var", l1.Value());
			Assert.AreEqual (Token.Type.PlusPlus, l1.GetNext ().Kind, "#2.2");
			Assert.AreEqual (Token.Type.Semicolon, l1.GetNext ().Kind, "#2.3");
			//Assert.IsFalse(l1.Advance());
			Assert.AreEqual (Token.Type.EndOfInput, l1.GetNext ().Kind, "#2.4");
		}

		[Test]
		public void MinusTest()
		{
			Tokenizer l1 = new Tokenizer ("$test_var--;".ToCharArray (), new IdentifierTable ());
			Assert.AreEqual (Token.Type.Identifier, l1.GetNext ().Kind, "#3.1");
			//Assert.AreEqual("$test_var", l1.Value());
			Assert.AreEqual (Token.Type.MinusMinus, l1.GetNext ().Kind, "#3.2");
			Assert.AreEqual (Token.Type.Semicolon, l1.GetNext ().Kind, "#3.3");
			//Assert.IsFalse(l1.Advance());
			Assert.AreEqual (Token.Type.EndOfInput, l1.GetNext ().Kind, "#3.4");
		}

		[Test]
		public void WhitespaceTest ()
		{
			Tokenizer t = new Tokenizer (" ".ToCharArray (), new IdentifierTable ());
			Assert.AreEqual (Token.Type.EndOfInput, t.GetNext ().Kind, "#4.1");
		}

		[Test]
		public void LineCommentTest ()
		{
			Tokenizer t = new Tokenizer ("// \n ;".ToCharArray (), new IdentifierTable ());
			Assert.AreEqual (Token.Type.Semicolon, t.GetNext ().Kind, "#5.1");
			Assert.AreEqual ("// ",t.Comments[0].Spelling, "#5.1");
		}

		[Test]
		public void BlockCommentTest ()
		{
			Tokenizer t = new Tokenizer ("/*abcdef*/ ;".ToCharArray (), new IdentifierTable ());
			Assert.AreEqual (Token.Type.Semicolon, t.GetNext ().Kind, "#6.1");
			Assert.AreEqual ("/*abcdef*/", t.Comments[0].Spelling, "#6.2");
		}
	}
}
