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
// Authors:
//
//   	Andreas Nahr (ClassDevelopment@A-SoftTech.com)
//	Jordi Mas i Hernandez <jordimash@gmail.com>
//

using System;
using System.Reflection;
using System.Resources;
using System.Security;
using System.Security.Permissions;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Workflow.ComponentModel.Serialization;

// General Information about the System.Workflow.Activities assembly
// v3.0 Assembly

[assembly: AssemblyCompany (Consts.MonoCompany)]
[assembly: AssemblyProduct (Consts.MonoProduct)]
[assembly: AssemblyCopyright (Consts.MonoCopyright)]
[assembly: AssemblyTrademark ("")]

[assembly: AssemblyVersion (Consts.FxVersion)]
[assembly: SatelliteContractVersion (Consts.FxVersion)]
[assembly: AssemblyFileVersion (Consts.FxFileVersion)]

[assembly: CLSCompliant (true)]

// FIXME: Next two entries not in original
[assembly: AssemblyDelaySign (true)]
[assembly: AssemblyKeyFile ("../winfx3.pub")]

[assembly: ComVisible (false)]

[assembly: CompilationRelaxations (CompilationRelaxations.NoStringInterning)]
[assembly: Debuggable (DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: RuntimeCompatibility (WrapNonExceptionThrows = true)]

[assembly: XmlnsPrefix ("http://schemas.microsoft.com/winfx/2006/xaml/workflow", "wf")]

[assembly: XmlnsDefinition ("http://schemas.microsoft.com/winfx/2006/xaml/workflow", "System.Workflow.Activities")]
[assembly: XmlnsDefinition ("http://schemas.microsoft.com/winfx/2006/xaml/workflow", "System.Workflow.Activities.Rules")]
[assembly: XmlnsDefinition ("http://schemas.microsoft.com/winfx/2006/xaml/workflow", "System.Workflow.Activities.Rules.Design")]
