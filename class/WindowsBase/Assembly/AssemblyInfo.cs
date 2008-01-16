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
using System.Windows.Markup;

[assembly: AssemblyVersion (Consts.FxVersion)]

/* TODO COMPLETE INFORMATION

[assembly: AssemblyTitle ("")]
[assembly: AssemblyDescription ("")]

[assembly: CLSCompliant (true)]
[assembly: AssemblyFileVersion ("0.0.0.1")]

[assembly: ComVisible (false)]

*/

[assembly: AssemblyDelaySign (true)]
[assembly: AssemblyKeyFile ("../msfinal3.pub")]

[assembly: XmlnsDefinitionAttribute ("http://schemas.microsoft.com/xps/2005/06", "System.Windows.Media")]
[assembly: XmlnsDefinitionAttribute ("http://schemas.microsoft.com/xps/2005/06", "System.Windows.Input")]
[assembly: XmlnsDefinitionAttribute ("http://schemas.microsoft.com/xps/2005/06", "System.Windows")]

[assembly: XmlnsDefinitionAttribute ("http://schemas.microsoft.com/winfx/2006/xaml/presentation", "System.Windows.Media")]
[assembly: XmlnsDefinitionAttribute ("http://schemas.microsoft.com/winfx/2006/xaml/presentation", "System.Windows.Input")]
[assembly: XmlnsDefinitionAttribute ("http://schemas.microsoft.com/winfx/2006/xaml/presentation", "System.Windows")]

[assembly: XmlnsDefinitionAttribute ("http://schemas.microsoft.com/winfx/2006/xaml/composite-font", "System.Windows.Media")]

[assembly: XmlnsDefinitionAttribute ("http://schemas.microsoft.com/netfx/2007/xaml/presentation", "System.Windows.Media")]
[assembly: XmlnsDefinitionAttribute ("http://schemas.microsoft.com/netfx/2007/xaml/presentation", "System.Windows.Input")]
[assembly: XmlnsDefinitionAttribute ("http://schemas.microsoft.com/netfx/2007/xaml/presentation", "System.Windows")]

[assembly: XmlnsPrefixAttribute     ("http://schemas.microsoft.com/xps/2005/06", "metro")]
[assembly: XmlnsPrefixAttribute     ("http://schemas.microsoft.com/netfx/2007/xaml/presentation", "wpf")]
[assembly: XmlnsPrefixAttribute     ("http://schemas.microsoft.com/winfx/2006/xaml/presentation", "av")]