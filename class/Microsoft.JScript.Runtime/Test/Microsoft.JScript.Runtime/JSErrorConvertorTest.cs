//
// Microsoft.JScript.Runtime
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
using Microsoft.JScript.Runtime;
using MSc = Microsoft.Scripting;

namespace MonoTests.Microsoft.JScript.Runtime
{
	[TestFixture]
	public class JSErrorConvertorTest
	{
		[Test]
		public void FormatException ()
		{
			Exception ex = new Exception("test message", new Exception ("inner exception test", null));
			try {
				throw ex;
			} catch (Exception e) {
				Console.WriteLine (e.StackTrace.ToString());

				MSc.EngineOptions option = new MSc.EngineOptions();
				option.ShowClrExceptions = true;
				string result = JSErrorConvertor.FormatException (e, option);
				Assert.AreEqual (" Error: test message\r\n\r\nCLR Exception\r\nException : test message\r\n" + e.StackTrace.ToString() +"\r\n", result, "#1");
				option.ShowClrExceptions = false;
				result = JSErrorConvertor.FormatException (e, option);
				Assert.AreEqual (" Error: test message\r\n", result, "#2");
			}			
		}
	}
}
