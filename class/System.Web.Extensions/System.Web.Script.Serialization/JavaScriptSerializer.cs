using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Permissions;

namespace System.Web.Script.Serialization
{
	[AspNetHostingPermissionAttribute (SecurityAction.LinkDemand,
		Level = AspNetHostingPermissionLevel.Minimal)]
	[AspNetHostingPermissionAttribute (SecurityAction.InheritanceDemand,
		Level = AspNetHostingPermissionLevel.Minimal)]
	public class JavaScriptSerializer
	{
		JavaScriptTypeResolver resolver;
		int max_json_length, recursion_limit;

		public JavaScriptSerializer ()
			: this (new SimpleTypeResolver ())
		{
		}
		
		public JavaScriptSerializer (JavaScriptTypeResolver resolver)
		{
			if (resolver == null)
				throw new ArgumentNullException ("resolver");
			this.resolver = resolver;
		}

		public T ConvertToType<T> (object obj)
		{
			throw new NotImplementedException ();
		}
		
		public T Deserialize<T> (string input)
		{
			throw new NotImplementedException ();
		}
		
		public object DeserializeObject (string input)
		{
			throw new NotImplementedException ();
		}
		
		public int MaxJsonLength {
			get { return max_json_length; }
			set {
				if (value <= 0)
					throw new ArgumentException ("value cannot be non-positive value.");
				max_json_length = value;
			}
		}
		
		public int RecursionLimit {
			get { return recursion_limit; }
			set {
				if (value <= 0)
					throw new ArgumentException ("value cannot be non-positive value.");
				recursion_limit = value;
			}
		}
		
		public void RegisterConverters (IEnumerable<JavaScriptConverter> converters)
		{
			throw new NotImplementedException ();
		}
		
		public string Serialize (object obj)
		{
			StringBuilder sb = new StringBuilder ();
			Serialize (obj, sb);
			return sb.ToString ();
		}
		
		public void Serialize (object obj, StringBuilder output)
		{
			throw new NotImplementedException ();
		}
	}
}
