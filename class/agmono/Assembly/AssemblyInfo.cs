//
// AssemblyInfo.cs
//
// Author:
//   Iain McCoy (iain@mccoy.id.au)
//   Andreas Nahr (ClassDevelopment@A-SoftTech.com)
//
// (C) 2003 Ximian, Inc.  http://www.ximian.com
// (C) 2004 Novell (http://www.novell.com)
//
// this file based on mcs/class/Mono.Data.SqlClient/Assembly/AssemblyInfo.cs

using System;
using System.Reflection;
using System.Runtime.InteropServices;

// General Information about the Mono.Moonlight assembly

[assembly: AssemblyVersion (Consts.FxVersion)]
[assembly: SatelliteContractVersion (Consts.FxVersion)]

[assembly: AssemblyTitle ("Mono.Moonlight.dll")]
[assembly: AssemblyDescription ("Mono.Moonlight.dll")]
[assembly: AssemblyConfiguration ("Development version")]
[assembly: AssemblyCompany ("MONO development team")]
[assembly: AssemblyProduct ("MONO CLI")]
[assembly: AssemblyCopyright ("(c) 2007 Various Authors")]
[assembly: AssemblyTrademark ("")]

[assembly: AssemblyDefaultAlias ("Mono.Moonlight.dll")]
[assembly: AssemblyInformationalVersion ("0.0.0.1")]
[assembly: NeutralResourcesLanguage ("en-US")]

[assembly: ComVisible (false)]

[assembly: AssemblyDelaySign (true)]
#if NET_2_1
[assembly: AssemblyKeyFile ("../winfx3.pub")]
#else
// For our desktop use, use the mono.pub key.
[assembly: AssemblyKeyFile ("../mono.pub")]
#endif
