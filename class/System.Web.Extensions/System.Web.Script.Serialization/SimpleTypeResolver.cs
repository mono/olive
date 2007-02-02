using System;
using System.Web;
using System.Security.Permissions;

namespace System.Web.Script.Serialization
{
	[AspNetHostingPermissionAttribute (SecurityAction.LinkDemand,
		Level = AspNetHostingPermissionLevel.Minimal)]
	[AspNetHostingPermissionAttribute (SecurityAction.InheritanceDemand,
		Level = AspNetHostingPermissionLevel.Minimal)]
	public class SimpleTypeResolver : JavaScriptTypeResolver
	{
		public override Type ResolveType (string id)
		{
			if (id == null)
				throw new ArgumentNullException ("id");
			throw new NotImplementedException ();
		}
		
		public override string ResolveTypeId (Type type)
		{
			if (type == null)
				throw new ArgumentNullException ("type");
			throw new NotImplementedException ();
		}
	}
}
