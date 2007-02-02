using System;
using System.Security.Permissions;
using System.Web;

namespace System.Web.Script.Serialization
{
	[AspNetHostingPermissionAttribute (SecurityAction.InheritanceDemand, 
		Level = AspNetHostingPermissionLevel.Minimal)]
	[AspNetHostingPermissionAttribute(SecurityAction.LinkDemand,
		Level = AspNetHostingPermissionLevel.Minimal)]
	public abstract class JavaScriptTypeResolver
	{
		protected JavaScriptTypeResolver ()
		{
		}
		
		public abstract Type ResolveType (string id);
		
		public abstract string ResolveTypeId (Type type);
	}
}
