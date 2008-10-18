// RegExpPrototype.cs
//
// Authors:
//   Olivier Dufour <olivier.duff@gmail.com>
//
// Copyright (C) 2008 Olivier Dufour
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
//

using System;
using Microsoft.Scripting;
using Microsoft.Scripting.Runtime;

namespace Microsoft.JScript.Runtime.Types {

	[Serializable]
	public class RegExpPrototype : JSObject {

		public RegExpPrototype (CodeContext context, JSObject prototype) : base (prototype)
		{
		}

		public static RegExpObject compile (object thisob, object source, object flags)
		{
			throw new NotImplementedException ();
		}

		public static object exec (CodeContext context, object thisob, object input)
		{
			throw new NotImplementedException ();
		}

		public static bool test (object thisob, object input)
		{
			throw new NotImplementedException ();
		}

		public static string toString (object thisob)
		{
			throw new NotImplementedException ();
		}
	}
}
