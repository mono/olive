// ErrorConstructor.cs
//
// Authors:
//	Olivier Dufour <olivier.duff@gmail.com>
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

namespace Microsoft.JScript.Runtime.Types {

	public class ErrorConstructor : FunctionObjectWithThis {
		
		public ErrorConstructor (CodeContext context, ErrorType errorType) : base (context, "", delegate { return null;}, new string []{}, true )
		{
			throw new NotImplementedException ();
		}

		public static object callError (CodeContext context, object instance, params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static object callEvalError (CodeContext context, object instance, params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static object callRangeError (CodeContext context, object instance, params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static object callReferenceError (CodeContext context, object instance, params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static object callSyntaxError (CodeContext context, object instance, params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static object callTypeError (CodeContext context, object instance, params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static object callURIError (CodeContext context, object instance, params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static object constructError (CodeContext context, object self, params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static object constructEvalError (CodeContext context, object self, params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static object constructRangeError (CodeContext context, object self, params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static object constructReferenceError (CodeContext context, object self, params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static object constructSyntaxError (CodeContext context, object self, params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static object constructTypeError (CodeContext context, object self, params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static object constructURIError (CodeContext context, object self, params object [] arguments)
		{
			throw new NotImplementedException ();
		}
	}
}
