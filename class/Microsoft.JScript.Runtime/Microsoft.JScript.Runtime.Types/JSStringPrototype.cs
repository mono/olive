using System;
using Microsoft.Scripting;

namespace Microsoft.JScript.Runtime {

	[Serializable]
	public class JSStringPrototype : JSStringObject {

		public JSStringPrototype (CodeContext context, JSObject prototype) : base (prototype, "")
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

		public static JSArrayObject split (CodeContext context, object thisob, object separator, object limit)
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
