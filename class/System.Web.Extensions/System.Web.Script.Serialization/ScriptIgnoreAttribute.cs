using System;
using System.Security.Permissions;
using System.Web;

namespace System.Web.Script.Serialization
{
	[AttributeUsageAttribute (AttributeTargets.Property|AttributeTargets.Field)]
	[AspNetHostingPermissionAttribute (SecurityAction.LinkDemand,
		Level = AspNetHostingPermissionLevel.Minimal)]
	public sealed class ScriptIgnoreAttribute : Attribute
	{
	}
}
