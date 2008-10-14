using System;
using System.Collections.Generic;
using Microsoft.Scripting;

namespace Microsoft.JScript.Runtime {

	public class JSGlobalObject : JSObject {
		public JSGlobalObject (CodeContext context, Scope scope)
			: base (null)
		{
		}

		#region Global members

		public static object AddReference (CodeContext context, object assembly)
		{
			throw new NotImplementedException ();
		}

		public static string decodeURI (object encodedURI)
		{
			throw new NotImplementedException ();
		}

		public static string decodeURIComponent (object encodedURI)
		{
			throw new NotImplementedException ();
		}

		public static string encodeURI (object uri)
		{
			throw new NotImplementedException ();
		}

		public static string encodeURIComponent (object uriComponent)
		{
			throw new NotImplementedException ();
		}

		public static string escape (object @string)
		{
			throw new NotImplementedException ();
		}

		public static object eval (CodeContext context, params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static object Eval (CodeContext context, string expression)
		{
			throw new NotImplementedException ();
		}

		public static object Import (CodeContext context, string container)
		{
			throw new NotImplementedException ();
		}

		public static object ImportAlias (CodeContext context, string container)
		{
			throw new NotImplementedException ();
		}

		public static bool isFinite (double number)
		{
			throw new NotImplementedException ();
		}

		public static bool isNaN (object num)
		{
			double number = Convert.ToNumber (num);
			return Double.IsNaN (number);
		}

		public static object LoadModule (CodeContext context, string module)
		{
			throw new NotImplementedException ();
		}

		public static object LoadModuleFromFile (CodeContext context, string module, string language)
		{
			throw new NotImplementedException ();
		}

		public static double parseFloat (object @string)
		{
			string str = Convert.ToString (@string).Trim ();
			if (str.StartsWith ("Infinity") || str.StartsWith ("+Infinity"))
				return Double.PositiveInfinity;
			else if (str.StartsWith ("-Infinity"))
				return Double.NegativeInfinity;

			if (str.Trim () == "")
				return 0;
			try {
				return Double.Parse (str, System.Globalization.NumberStyles.Float);
			} catch {
				return Double.NaN;
			}
		}

		public static double parseInt (object @string, object radix)
		{
			throw new NotImplementedException ();
		}

		public static object print (CodeContext context, params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static string unescape (object @string)
		{
			throw new NotImplementedException ();
		}

		#endregion

		public override IDictionary<object, object> AsObjectKeyedDictionary ()
		{
			return base.AsObjectKeyedDictionary ();
		}

		public override bool DeleteCustomMember (CodeContext context, SymbolId name)
		{
			return base.DeleteCustomMember (context, name);
		}

		public override bool DeleteItem (SymbolId name)
		{
			return base.DeleteItem (name);
		}

		public override IDictionary<object, object> GetCustomMemberDictionary (CodeContext context)
		{
			return base.GetCustomMemberDictionary (context);
		}

		public override IList<object> GetMemberNames (CodeContext context)
		{
			return base.GetMemberNames (context);
		}

		public override IEnumerator<KeyValuePair<object, object>> GetEnumerator ()
		{
			return base.GetEnumerator ();
		}

		public override void SetCustomMember (CodeContext context, SymbolId name, object value)
		{
			base.SetCustomMember (context, name, value);
		}

		public override void SetItem (SymbolId name, object value)
		{
			base.SetItem (name, value);
		}

		public override bool TryGetBoundCustomMember (CodeContext context, SymbolId name, out object value)
		{
			return base.TryGetBoundCustomMember (context, name, out value);
		}

		public override bool TryGetCustomMember (CodeContext context, SymbolId name, out object value)
		{
			return base.TryGetCustomMember (context, name, out value);
		}

		public override bool TryGetItem (SymbolId name, out object value)
		{
			return base.TryGetItem (name, out value);
		}

		public override int Count {
			get { return base.Count; }
		}

		public override ICollection<object> Keys {
			get { return base.Keys; }
		}

		public override IDictionary<SymbolId, object> SymbolAttributes {
			get { return base.SymbolAttributes; }
		}
	}
}
