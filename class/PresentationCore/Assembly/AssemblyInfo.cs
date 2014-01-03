//
// AssemblyInfo.cs
//
// Author:
//   Andreas Nahr (ClassDevelopment@A-SoftTech.com)
//
// (C) 2003 Ximian, Inc.  http://www.ximian.com
//

//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;
using System.Reflection;
using System.Resources;
using System.Security;
using System.Security.Permissions;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Input;
using System.Windows.Markup;

// General Information about the PresentationCore assembly
// v3.0 Assembly

[assembly: AssemblyCompany (Consts.MonoCompany)]
[assembly: AssemblyProduct (Consts.MonoProduct)]
[assembly: AssemblyCopyright (Consts.MonoCopyright)]
[assembly: AssemblyVersion (Consts.FxVersion)]

[assembly: NeutralResourcesLanguage ("en")]
[assembly: CLSCompliant (true)]
[assembly: AssemblyDelaySign (true)]
[assembly: AssemblyKeyFile ("../winfx3.pub")]

[assembly: ComVisible (false)]
[assembly: AllowPartiallyTrustedCallers]

[assembly: RuntimeCompatibility (WrapNonExceptionThrows = true)]
[assembly: Dependency ("System,", LoadHint.Always)]
[assembly: Dependency ("WindowsBase,", LoadHint.Always)]
[assembly: SecurityCritical]
[assembly: PermissionSet (SecurityAction.RequestMinimum, Name = "FullTrust")]
[assembly: SecurityPermission (SecurityAction.RequestMinimum, SkipVerification = true)]

[assembly: XmlnsPrefix ("http://schemas.microsoft.com/winfx/2006/xaml", "x")]
[assembly: XmlnsPrefix ("http://schemas.microsoft.com/xps/2005/06", "xps")]
[assembly: XmlnsPrefix ("http://schemas.microsoft.com/netfx/2007/xaml/presentation", "wpf")]
[assembly: XmlnsPrefix ("http://schemas.microsoft.com/winfx/2006/xaml/presentation", "av")]

[assembly: XmlnsDefinition ("http://schemas.microsoft.com/netfx/2007/xaml/presentation", "System.Windows")]
[assembly: XmlnsDefinition ("http://schemas.microsoft.com/netfx/2007/xaml/presentation", "System.Windows.Input")]
[assembly: XmlnsDefinition ("http://schemas.microsoft.com/netfx/2007/xaml/presentation", "System.Windows.Ink")]
[assembly: XmlnsDefinition ("http://schemas.microsoft.com/netfx/2007/xaml/presentation", "System.Windows.Automation")]
[assembly: XmlnsDefinition ("http://schemas.microsoft.com/netfx/2007/xaml/presentation", "System.Windows.Media")]
[assembly: XmlnsDefinition ("http://schemas.microsoft.com/netfx/2007/xaml/presentation", "System.Windows.Media.Animation")]
[assembly: XmlnsDefinition ("http://schemas.microsoft.com/netfx/2007/xaml/presentation", "System.Windows.Media.Media3D")]
[assembly: XmlnsDefinition ("http://schemas.microsoft.com/netfx/2007/xaml/presentation", "System.Windows.Media.Imaging")]
[assembly: XmlnsDefinition ("http://schemas.microsoft.com/netfx/2007/xaml/presentation", "System.Windows.Media.Effects")]
[assembly: XmlnsDefinition ("http://schemas.microsoft.com/netfx/2007/xaml/presentation", "System.Windows.Media.TextFormatting")]

[assembly: XmlnsDefinition ("http://schemas.microsoft.com/winfx/2006/xaml", "System.Windows.Markup")]

[assembly: XmlnsDefinition ("http://schemas.microsoft.com/winfx/2006/xaml/presentation", "System.Windows")]
[assembly: XmlnsDefinition ("http://schemas.microsoft.com/winfx/2006/xaml/presentation", "System.Windows.Input")]
[assembly: XmlnsDefinition ("http://schemas.microsoft.com/winfx/2006/xaml/presentation", "System.Windows.Ink")]
[assembly: XmlnsDefinition ("http://schemas.microsoft.com/winfx/2006/xaml/presentation", "System.Windows.Automation")]
[assembly: XmlnsDefinition ("http://schemas.microsoft.com/winfx/2006/xaml/presentation", "System.Windows.Media")]
[assembly: XmlnsDefinition ("http://schemas.microsoft.com/winfx/2006/xaml/presentation", "System.Windows.Media.Animation")]
[assembly: XmlnsDefinition ("http://schemas.microsoft.com/winfx/2006/xaml/presentation", "System.Windows.Media.Media3D")]
[assembly: XmlnsDefinition ("http://schemas.microsoft.com/winfx/2006/xaml/presentation", "System.Windows.Media.Imaging")]
[assembly: XmlnsDefinition ("http://schemas.microsoft.com/winfx/2006/xaml/presentation", "System.Windows.Media.Effects")]
[assembly: XmlnsDefinition ("http://schemas.microsoft.com/winfx/2006/xaml/presentation", "System.Windows.Media.TextFormatting")]

[assembly: XmlnsDefinition ("http://schemas.microsoft.com/winfx/2006/xaml/composite-font", "System.Windows.Media")]

[assembly: XmlnsDefinition ("http://schemas.microsoft.com/xps/2005/06", "System.Windows")]
[assembly: XmlnsDefinition ("http://schemas.microsoft.com/xps/2005/06", "System.Windows.Media")]
[assembly: XmlnsDefinition ("http://schemas.microsoft.com/xps/2005/06", "System.Windows.Media.Animation")]
[assembly: XmlnsDefinition ("http://schemas.microsoft.com/xps/2005/06", "System.Windows.Media.Media3D")]
[assembly: XmlnsDefinition ("http://schemas.microsoft.com/xps/2005/06", "System.Windows.Input")]
[assembly: XmlnsDefinition ("http://schemas.microsoft.com/xps/2005/06", "System.Windows.Media.TextFormatting")]
[assembly: XmlnsDefinition ("http://schemas.microsoft.com/xps/2005/06", "System.Windows.Automation")]
[assembly: XmlnsDefinition ("http://schemas.microsoft.com/xps/2005/06", "System.Windows.Media.Effects")]
[assembly: XmlnsDefinition ("http://schemas.microsoft.com/xps/2005/06", "System.Windows.Media.Imaging")]

#if NET_4_0
[assembly: TypeForwardedTo (typeof(IUriContext))]
#endif

#if NET_4_5
[assembly: TypeForwardedTo (typeof(ICommand))]
#endif
