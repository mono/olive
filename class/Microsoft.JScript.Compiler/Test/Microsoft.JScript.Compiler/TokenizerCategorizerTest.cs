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

using NUnit.Core;
using NUnit.Framework;
using MJC = Microsoft.JScript.Compiler;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;

namespace MonoTests.Microsoft.JScript.Compiler
{
	[TestFixture]
	public class TokenizerCategorizerTest
	{
		MJC.TokenCategorizer tokenCategorizer;

		private TokenInfo InitAndRead (string code)
		{
			tokenCategorizer = new MJC.TokenCategorizer ();
			ScriptDomainManager scriptMgr = ScriptDomainManager.CurrentManager;
			
			tokenCategorizer.Initialize ( new object () ,
										  new SourceCodeUnit (new MJC.Engine (scriptMgr.GetLanguageProvider (typeof (MJC.Hosting.LanguageProvider)), new MJC.EngineOptions ()), code, "test").GetReader (), 
										  new SourceLocation ());
			return tokenCategorizer.ReadToken ();
		}
		
		[Test]
		public void ReadToken()
		{

			TokenInfo info = InitAndRead (""); 
			Assert.AreEqual (TokenCategory.EndOfStream, info.Category, "#1");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#2");
			info = InitAndRead ("{");
			Assert.AreEqual (TokenCategory.Delimiter, info.Category, "#3");
			Assert.AreEqual (TokenTriggers.MatchBraces, info.Trigger, "#4");
			info = InitAndRead ("}");
			Assert.AreEqual (TokenCategory.Delimiter, info.Category, "#5");
			Assert.AreEqual (TokenTriggers.MatchBraces, info.Trigger, "#6");
			info = InitAndRead ("[");
			Assert.AreEqual (TokenCategory.Delimiter, info.Category, "#7");
			Assert.AreEqual (TokenTriggers.MatchBraces, info.Trigger, "#8");
			info = InitAndRead ("]");
			Assert.AreEqual (TokenCategory.Delimiter, info.Category, "#9");
			Assert.AreEqual (TokenTriggers.MatchBraces, info.Trigger, "#10");
			info = InitAndRead ("(");
			Assert.AreEqual (TokenCategory.Delimiter, info.Category, "#11");
			Assert.AreEqual (TokenTriggers.MatchBraces | TokenTriggers.ParameterStart, info.Trigger, "#12");
			info = InitAndRead (")");
			Assert.AreEqual (TokenCategory.Delimiter, info.Category, "#13");
			Assert.AreEqual (TokenTriggers.MatchBraces | TokenTriggers.ParameterEnd, info.Trigger, "#14");
			info = InitAndRead (".");
			Assert.AreEqual (TokenCategory.Delimiter, info.Category, "#15");
			Assert.AreEqual (TokenTriggers.MemberSelect, info.Trigger, "#16");
			info = InitAndRead (",");
			Assert.AreEqual (TokenCategory.Delimiter, info.Category, "#17");
			Assert.AreEqual (TokenTriggers.ParameterNext, info.Trigger, "#18");
			//TODO end it
		}	
	}
}
