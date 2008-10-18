// StringPrototype.cs
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
	public class StringPrototype : StringObject {

		public StringPrototype (CodeContext context, JSObject prototype) : base (prototype, "")
		{
		}

		public static string anchor (object thisob, object anchorName)
		{
			throw new NotImplementedException ();
		}

		public static string big (object thisob)
		{
			throw new NotImplementedException ();
		}

		public static string blink (object thisob)
		{
			throw new NotImplementedException ();
		}

		public static string bold (object thisob)
		{
			throw new NotImplementedException ();
		}

		public static string charAt (object thisob, double pos)
		{
			throw new NotImplementedException ();
		}

		public static object charCodeAt (object thisob, double pos)
		{
			throw new NotImplementedException ();
		}

		public static string concat (object thisob, params object [] args)
		{
			throw new NotImplementedException ();
		}

		public static string @fixed (object thisob)
		{
			throw new NotImplementedException ();
		}

		public static string fontcolor (object thisob, object colorName)
		{
			throw new NotImplementedException ();
		}

		public static string fontsize (object thisob, object fontSize)
		{
			throw new NotImplementedException ();
		}

		public static int indexOf (object thisob, object searchString, double position)
		{
			throw new NotImplementedException ();
		}

		public static string italics (object thisob)
		{
			throw new NotImplementedException ();
		}

		public static int lastIndexOf (object thisob, object searchString, double position)
		{
			throw new NotImplementedException ();
		}

		public static string link (object thisob, object linkRef)
		{
			throw new NotImplementedException ();
		}

		public static int localeCompare (object thisob, object thatob)
		{
			throw new NotImplementedException ();
		}

		public static object match (CodeContext context, object thisob, object regExp)
		{
			throw new NotImplementedException ();
		}

		public static string replace (CodeContext context, object thisob, object regExp, object replacement)
		{
			throw new NotImplementedException ();
		}

		public static int search (CodeContext context, object thisob, object regExp)
		{
			throw new NotImplementedException ();
		}

		public static string slice (object thisob, double start, object end)
		{
			throw new NotImplementedException ();
		}

		public static string small (object thisob)
		{
			throw new NotImplementedException ();
		}

		public static ArrayObject split (CodeContext context, object thisob, object separator, object limit)
		{
			throw new NotImplementedException ();
		}

		public static string strike (object thisob)
		{
			throw new NotImplementedException ();
		}

		public static string sub (object thisob)
		{
			throw new NotImplementedException ();
		}

		public static string substr (object thisob, double start, object count)
		{
			throw new NotImplementedException ();
		}

		public static string substring (object thisob, double start, object end)
		{
			throw new NotImplementedException ();
		}

		public static string sup (object thisob)
		{
			throw new NotImplementedException ();
		}

		public static string toLocaleLowerCase (object thisob)
		{
			throw new NotImplementedException ();
		}

		public static string toLocaleUpperCase (object thisob)
		{
			throw new NotImplementedException ();
		}

		public static string toLowerCase (object thisob)
		{
			throw new NotImplementedException ();
		}

		public static string toString (object thisob)
		{
			throw new NotImplementedException ();
		}

		public static string toUpperCase (object thisob)
		{
			throw new NotImplementedException ();
		}

		public static object valueOf (object thisob)
		{
			throw new NotImplementedException ();
		}
	}
}
