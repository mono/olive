using System;
using System.Security.Permissions;
using System.Web;

namespace System.Windows.Browser.Serialization
{
	public abstract class JavaScriptTypeResolver
	{
		protected JavaScriptTypeResolver ()
		{
		}
		
		public abstract Type ResolveType (string id);
		
		public abstract string ResolveTypeId (Type type);
	}
}
