// ArrayPrototype.cs
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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Microsoft.Scripting;
using Microsoft.Scripting.Runtime;

namespace Microsoft.JScript.Runtime.Types {

	[Serializable]
	public class ArrayPrototype : ArrayObject {

			
		
		static ArrayPrototype ()
		{
			DefaultJoinSeparator = ",";
		}

		public ArrayPrototype (CodeContext context, JSObject prototype)
		{
			throw new NotImplementedException ();
		}

		public static readonly string DefaultJoinSeparator;

		public static ArrayObject concat (CodeContext context, object thisob, params object [] args)
		{
			throw new NotImplementedException ();
		}

		public static string join (CodeContext context, object thisob, object separator)
		{
			throw new NotImplementedException ();
		}

		public static object pop (CodeContext context, object thisob)
		{
			throw new NotImplementedException ();
		}

		public static object push (CodeContext context, object thisob, params object [] args)
		{
			throw new NotImplementedException ();
		}

		public static object reverse (CodeContext context, object thisob)
		{
			throw new NotImplementedException ();
		}

		public static object shift (CodeContext context, object thisob)
		{
			throw new NotImplementedException ();
		}

		public static ArrayObject slice (CodeContext context, object thisob, double start, object end)
		{
			throw new NotImplementedException ();
		}

		public static object sort (CodeContext context, object thisob, object function)
		{
			throw new NotImplementedException ();
		}

		public static ArrayObject splice (CodeContext context, object thisob, double start, double deleteCnt,
						    params object [] args)
		{
			throw new NotImplementedException ();
		}

		public static string toLocaleString (CodeContext context, object thisob)
		{
			throw new NotImplementedException ();
		}

		public static string toString (CodeContext context, object thisob)
		{
			throw new NotImplementedException ();
		}

		public static object unshift (CodeContext context, object thisob, params object [] args)
		{
			throw new NotImplementedException ();
		}
	}
}
