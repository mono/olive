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
using MonoJC = Microsoft.JScript.Compiler;
using MonoJCH = Microsoft.JScript.Compiler.Hosting;
using MonoJCS = Microsoft.JScript.Compiler.Shell;
using MsS = Microsoft.Scripting;

namespace MonoTests.Microsoft.JScript.Compiler.Hosting
{
	[TestFixture]
	public class LanguageProviderTest
	{
		MonoJCH.LanguageProvider provider;

		[SetUp]
		public void Init ()
		{
			MsS.ScriptDomainManager scriptMgr = MsS.ScriptDomainManager.CurrentManager;
			provider = (MonoJCH.LanguageProvider)scriptMgr.GetLanguageProvider (typeof (MonoJCH.LanguageProvider));
		}


		[Test]
		public void GetCommandLine ()
		{
			Assert.IsInstanceOfType (typeof (MonoJCS.CommandLine), provider.GetCommandLine ());
		}

		[Test]
		public void GetEngine ()
		{
			Assert.IsInstanceOfType (typeof (MonoJC.Engine), provider.GetEngine (new MonoJC.EngineOptions ()));
		}

		[Test]
		public void GetOptionsParser ()
		{
			Assert.IsInstanceOfType (typeof (MonoJC.OptionsParser), provider.GetOptionsParser ());
		}

		[Test]
		public void GetTokenCategorizer ()
		{
			Assert.IsInstanceOfType (typeof (MonoJC.TokenCategorizer), provider.GetTokenCategorizer ());
		}

		[Test]
		public void LanguageDisplayName ()
		{
			Assert.AreEqual ("JavaScript", provider.LanguageDisplayName);
		}		
	}
}
