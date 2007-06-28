using System;
using System.Collections.Generic;
using Microsoft.Scripting;

namespace Microsoft.JScript.Runtime {

	public class JSGlobalObject : JSObject {
		public JSGlobalObject (ScriptModule scriptModule)
			: base (null)
		{
		}

		#region Global members

		public static object addRerefence (CodeContext context, params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static object addRerefenceToFile (CodeContext context, params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static string decodeURI (object encodedURI)
		{
			throw new NotImplementedException ();
		}

		public static object decodeURI (params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static string decodeURIComponent (object encodedURI)
		{
			throw new NotImplementedException ();
		}

		public static object decodeURIComponent (params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static string encodeURI (object uri)
		{
			throw new NotImplementedException ();
		}

		public static object encodeURI (params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static string encodeURIComponent (object uriComponent)
		{
			throw new NotImplementedException ();
		}

		public static object encodeURIComponent (params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static string escape (object @string)
		{
			throw new NotImplementedException ();
		}

		public static object escape (params object [] arguments)
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

		public static object import (CodeContext context, params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static object importAlias (CodeContext context, params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static bool isFinite (double number)
		{
			throw new NotImplementedException ();
		}

		public static object isFinite (params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static bool isNaN (object num)
		{
			throw new NotImplementedException ();
		}

		public static object isNaN (params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static object loadModule (CodeContext context, params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static object loadModuleFromFile (CodeContext context, params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static double parseFloat (object @string)
		{
			throw new NotImplementedException ();
		}

		public static object parseFloat (params object [] arguments)
		{
			throw new NotImplementedException ();
		}

		public static double parseInt (object @string, object radix)
		{
			throw new NotImplementedException ();
		}

		public static object parseInt (params object [] arguments)
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

		public static object unescape (params object [] arguments)
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

		public override IDictionary<object, object> GetCustomMemberDictionary (CodeContext context)
		{
			return base.GetCustomMemberDictionary (context);
		}

		public override IList<object> GetCustomMemberNames (CodeContext context)
		{
			return base.GetCustomMemberNames (context);
		}

		public override IEnumerator<KeyValuePair<object, object>> GetEnumerator ()
		{
			return base.GetEnumerator ();
		}

		public override void SetCustomMember (CodeContext context, SymbolId name, object value)
		{
			base.SetCustomMember (context, name, value);
		}

		public override bool TryGetBoundCustomMember (CodeContext context, SymbolId name, out object value)
		{
			return base.TryGetBoundCustomMember (context, name, out value);
		}

		public override bool TryGetCustomMember (CodeContext context, SymbolId name, out object value)
		{
			return base.TryGetCustomMember (context, name, out value);
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
