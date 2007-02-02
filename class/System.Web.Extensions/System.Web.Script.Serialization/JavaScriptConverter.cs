using System;
using System.Collections.Generic;
using System.Security.Permissions;

namespace System.Web.Script.Serialization
{
	[AspNetHostingPermissionAttribute (SecurityAction.LinkDemand,
		Level = AspNetHostingPermissionLevel.Minimal)]
	[AspNetHostingPermissionAttribute(SecurityAction.InheritanceDemand, 
		Level = AspNetHostingPermissionLevel.Minimal)]
	public abstract class JavaScriptConverter
	{
		protected JavaScriptConverter ()
		{
		}
		
		public abstract object Deserialize (
			IDictionary<string, object> dictionary,
			Type type,
			JavaScriptSerializer serializer);
		
		public abstract IDictionary<string, object> Serialize (
			object obj, JavaScriptSerializer serializer);
		
		public abstract IEnumerable<Type> SupportedTypes { get; }
	}
}
