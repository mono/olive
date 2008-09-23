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
			info = InitAndRead ("<");
			Assert.AreEqual (TokenCategory.Operator, info.Category, "#19");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#20");
			info = InitAndRead (">");
			Assert.AreEqual (TokenCategory.Operator, info.Category, "#21");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#22");
			info = InitAndRead ("<=");
			Assert.AreEqual (TokenCategory.Operator, info.Category, "#23");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#24");
			info = InitAndRead (">=");
			Assert.AreEqual (TokenCategory.Operator, info.Category, "#25");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#26");
			info = InitAndRead ("==");
			Assert.AreEqual (TokenCategory.Operator, info.Category, "#27");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#28");
			info = InitAndRead ("!=");
			Assert.AreEqual (TokenCategory.Operator, info.Category, "#29");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#30");
			info = InitAndRead ("===");
			Assert.AreEqual (TokenCategory.Operator, info.Category, "#31");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#32");
			info = InitAndRead ("!==");
			Assert.AreEqual (TokenCategory.Operator, info.Category, "#33");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#34");
			info = InitAndRead ("+");
			Assert.AreEqual (TokenCategory.Operator, info.Category, "#35");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#36");
			info = InitAndRead ("-");
			Assert.AreEqual (TokenCategory.Operator, info.Category, "#37");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#38");
			info = InitAndRead ("*");
			Assert.AreEqual (TokenCategory.Operator, info.Category, "#39");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#40");
			info = InitAndRead ("%");
			Assert.AreEqual (TokenCategory.Operator, info.Category, "#41");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#42");
			info = InitAndRead ("++");
			Assert.AreEqual (TokenCategory.Operator, info.Category, "#43");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#44");
			info = InitAndRead ("--");
			Assert.AreEqual (TokenCategory.Operator, info.Category, "#45");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#46");
			info = InitAndRead ("<<");
			Assert.AreEqual (TokenCategory.Operator, info.Category, "#47");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#48");
			info = InitAndRead (">>");
			Assert.AreEqual (TokenCategory.Operator, info.Category, "#49");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#50");
			info = InitAndRead (">>>");
			Assert.AreEqual (TokenCategory.Operator, info.Category, "#51");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#52");
			info = InitAndRead ("&");
			Assert.AreEqual (TokenCategory.Operator, info.Category, "#53");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#54");
			info = InitAndRead ("|");
			Assert.AreEqual (TokenCategory.Operator, info.Category, "#55");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#56");
			info = InitAndRead ("^");
			Assert.AreEqual (TokenCategory.Operator, info.Category, "#57");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#58");
			info = InitAndRead ("!");
			Assert.AreEqual (TokenCategory.Operator, info.Category, "#59");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#60");
			info = InitAndRead ("~");
			Assert.AreEqual (TokenCategory.Operator, info.Category, "#61");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#62");
			info = InitAndRead ("&&");
			Assert.AreEqual (TokenCategory.Operator, info.Category, "#63");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#64");
			info = InitAndRead ("||");
			Assert.AreEqual (TokenCategory.Operator, info.Category, "#65");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#66");
			info = InitAndRead ("?");
			Assert.AreEqual (TokenCategory.Operator, info.Category, "#67");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#68");
			info = InitAndRead (":");
			Assert.AreEqual (TokenCategory.Operator, info.Category, "#69");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#70");
			info = InitAndRead ("=");
			Assert.AreEqual (TokenCategory.Operator, info.Category, "#71");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#72");
			info = InitAndRead ("+=");
			Assert.AreEqual (TokenCategory.Operator, info.Category, "#73");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#74");
			info = InitAndRead ("-=");
			Assert.AreEqual (TokenCategory.Operator, info.Category, "#75");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#76");
			info = InitAndRead ("*=");
			Assert.AreEqual (TokenCategory.Operator, info.Category, "#77");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#78");
			info = InitAndRead ("%=");
			Assert.AreEqual (TokenCategory.Operator, info.Category, "#79");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#80");
			info = InitAndRead ("<<=");
			Assert.AreEqual (TokenCategory.Operator, info.Category, "#81");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#82");
			info = InitAndRead (">>=");
			Assert.AreEqual (TokenCategory.Operator, info.Category, "#83");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#84");
			info = InitAndRead (">>>=");
			Assert.AreEqual (TokenCategory.Operator, info.Category, "#85");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#86");
			info = InitAndRead ("&=");
			Assert.AreEqual (TokenCategory.Operator, info.Category, "#87");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#88");
			info = InitAndRead ("|=");
			Assert.AreEqual (TokenCategory.Operator, info.Category, "#89");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#90");
			info = InitAndRead ("^=");
			Assert.AreEqual (TokenCategory.Operator, info.Category, "#91");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#92");
			info = InitAndRead ("/");
			Assert.AreEqual (TokenCategory.Operator, info.Category, "#93");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#94");
			info = InitAndRead ("/=");
			Assert.AreEqual (TokenCategory.Operator, info.Category, "#95");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#96");
			info = InitAndRead ("break");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#97");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#98");
			info = InitAndRead ("else");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#99");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#100");
			info = InitAndRead ("new");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#101");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#102");
			info = InitAndRead ("var");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#103");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#104");
			info = InitAndRead ("case");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#105");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#106");
			info = InitAndRead ("finally");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#107");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#108");
			info = InitAndRead ("return");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#109");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#110");
			info = InitAndRead ("void");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#111");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#112");
			info = InitAndRead ("catch");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#113");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#114");
			info = InitAndRead ("for");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#115");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#116");
			info = InitAndRead ("switch");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#117");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#118");
			info = InitAndRead ("while");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#119");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#120");
			info = InitAndRead ("continue");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#121");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#122");
			info = InitAndRead ("function");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#123");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#124");
			info = InitAndRead ("this");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#125");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#126");
			info = InitAndRead ("with");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#127");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#128");
			info = InitAndRead ("default");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#129");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#130");
			info = InitAndRead ("if");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#131");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#132");
			info = InitAndRead ("throw");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#133");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#134");
			info = InitAndRead ("delete");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#135");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#136");
			info = InitAndRead ("in");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#137");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#138");
			info = InitAndRead ("try");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#139");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#140");
			info = InitAndRead ("do");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#141");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#142");
			info = InitAndRead ("instanceof");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#143");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#144");
			info = InitAndRead ("typeof");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#145");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#146");
			info = InitAndRead ("abstract");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#147");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#148");
			info = InitAndRead ("enum");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#149");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#150");
			info = InitAndRead ("int");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#151");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#152");
			info = InitAndRead ("short");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#153");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#154");
			info = InitAndRead ("boolean");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#155");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#156");
			info = InitAndRead ("export");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#157");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#158");
			info = InitAndRead ("interface");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#159");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#160");
			info = InitAndRead ("static");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#161");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#162");
			info = InitAndRead ("byte");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#163");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#164");
			info = InitAndRead ("extends");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#165");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#166");
			info = InitAndRead ("long");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#167");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#168");
			info = InitAndRead ("super");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#169");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#170");
			info = InitAndRead ("char");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#171");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#172");
			info = InitAndRead ("final");
			Assert.AreEqual (TokenCategory.None, info.Category, "#173");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#174");
			info = InitAndRead ("native");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#175");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#176");
			info = InitAndRead ("synchronized");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#177");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#178");
			info = InitAndRead ("class");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#179");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#180");
			info = InitAndRead ("float");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#181");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#182");
			info = InitAndRead ("packate");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#183");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#184");
			info = InitAndRead ("throws");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#185");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#186");
			info = InitAndRead ("const");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#187");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#188");
			info = InitAndRead ("goto");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#189");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#190");
			info = InitAndRead ("private");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#191");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#192");
			info = InitAndRead ("transient");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#193");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#194");
			info = InitAndRead ("debugger");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#195");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#196");
			info = InitAndRead ("implements");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#197");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#198");
			info = InitAndRead ("protected");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#199");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#200");
			info = InitAndRead ("volatile");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#201");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#202");
			info = InitAndRead ("double");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#203");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#204");
			info = InitAndRead ("import");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#205");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#206");
			info = InitAndRead ("public");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#207");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#208");
			info = InitAndRead ("null");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#209");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#210");
			info = InitAndRead ("true");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#211");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#212");
			info = InitAndRead ("false");
			Assert.AreEqual (TokenCategory.Keyword, info.Category, "#213");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#214");
			info = InitAndRead ("0x32");
			Assert.AreEqual (TokenCategory.None, info.Category, "#215");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#216");
			info = InitAndRead ("065");
			Assert.AreEqual (TokenCategory.None, info.Category, "#217");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#218");
			info = InitAndRead ("62");
			Assert.AreEqual (TokenCategory.NumericLiteral, info.Category, "#219");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#220");
			info = InitAndRead ("\"test\"");
			Assert.AreEqual (TokenCategory.StringLiteral, info.Category, "#221");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#222");
			//TODO : support of regular expression
			/*info = InitAndRead ("/a[a-z]{2,4}/");
			Assert.AreEqual (TokenCategory.Identifier, info.Category, "#223");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#224");*/
			info = InitAndRead ("foo");
			Assert.AreEqual (TokenCategory.Identifier, info.Category, "#225");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#226");
			info = InitAndRead ("£");
			Assert.AreEqual (TokenCategory.Error, info.Category, "#227");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#228");
			//Comment never make a token
			/*info = InitAndRead ("//Comment");
			Assert.AreEqual (TokenCategory.Identifier, info.Category, "#229");
			Assert.AreEqual (TokenTriggers.None, info.Trigger, "#230");*/

		}	
	}
}
