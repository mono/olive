using NUnit.Core;
using NUnit.Framework;
using Mono.JScript.Compiler;

namespace Mono.JScript.Compiler.Tests
{
	[TestFixture]
	public class LexerTest
	{
		[Test]
		public void AffectTest()
		{
			Tokenizer l1 = new Tokenizer ("var i = 10;".ToCharArray(), new IdentifierTable ());
			Assert.AreEqual(Token.Type.Var, l1.GetNext().Kind);
			Assert.AreEqual (Token.Type.Identifier, l1.GetNext().Kind);
			//Assert.AreEqual("i", l1.Value());
			Assert.AreEqual (Token.Type.Equal, l1.GetNext().Kind);
			Assert.AreEqual (Token.Type.NumericLiteral, l1.GetNext().Kind);
			//Assert.AreEqual("10", l1.Value());
			Assert.AreEqual (Token.Type.SemiColon, l1.GetNext().Kind);    
			//Assert.IsFalse(l1.Advance());
			Assert.AreEqual (Token.Type.EOF, l1.GetNext().Kind);   
		}

		[Test]
		public void PlusTest()
		{
			Tokenizer l1 = new Tokenizer ("$test_var++;".ToCharArray (), new IdentifierTable ());
			Assert.AreEqual (Token.Type.Identifier, l1.GetNext().Kind);
			//Assert.AreEqual("$test_var", l1.Value());
			Assert.AreEqual (Token.Type.PlusPlus, l1.GetNext().Kind);
			Assert.AreEqual (Token.Type.SemiColon, l1.GetNext().Kind);
			//Assert.IsFalse(l1.Advance());
			Assert.AreEqual (Token.Type.EOF, l1.GetNext().Kind);
		}

		[Test]
		public void MinusTest()
		{
			Tokenizer l1 = new Tokenizer ("$test_var--;".ToCharArray (), new IdentifierTable ());
			Assert.AreEqual (Token.Type.Identifier, l1.GetNext().Kind);
			//Assert.AreEqual("$test_var", l1.Value());
			Assert.AreEqual (Token.Type.MinusMinus, l1.GetNext().Kind);
			Assert.AreEqual (Token.Type.SemiColon, l1.GetNext().Kind);
			//Assert.IsFalse(l1.Advance());
			Assert.AreEqual (Token.Type.EOF, l1.GetNext().Kind);
		}
	}
}
