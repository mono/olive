//
// SilverlightPAL.cs
//
// Authors:
//	Atsushi Enomoto  <atsushi@ximian.com>
//
// Copyright (C) 2007 Novell, Inc (http://www.novell.com)
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
using System.IO;
using System.Reflection;
using Microsoft.Scripting.Hosting;

namespace Microsoft.Scripting.Silverlight
{
	// Actually I doubt that IronPython 2.0alpha1 can create this instance 
	// according to the constructor sequence:
	//	ScriptDomainManager.CurrentManager
	//	-> .TryCreateLocal(null,out manager)
	//	-> .GetSetupInformation()
	//	   returns new ScriptEnvironmentSetup(true)
	//	-> .ctor(setup[above])
	//	-> setup.CreatePAL()
	//	-> Utils.Reflection.CreateInstance<PAL>(PALType)
	//
	// In the sequence above, there is no chance to set this type during
	// the instantiation process of ScriptDomainManager.CurrentManager.

	public class SilverlightPAL : PlatformAdaptationLayer
	{
		[MonoTODO]
		public override bool DirectoryExists (string path)
		{
			return base.DirectoryExists (path);
		}

		[MonoTODO]
		public override bool FileExists (string path)
		{
			return base.FileExists (path);
		}

		[MonoTODO]
		public override string [] GetFiles (string path, string searchPattern)
		{
			return base.GetFiles (path, searchPattern);
		}

		[MonoTODO]
		public override string GetFullPath (string path)
		{
			return base.GetFullPath (path);
		}

		[MonoTODO]
		public override Assembly LoadAssembly (string name)
		{
			return base.LoadAssembly (name);
		}

		[MonoTODO]
		public override Stream OpenInputFileStream (string path)
		{
			return base.OpenInputFileStream (path);
		}

		[MonoTODO]
		public override Stream OpenOutputFileStream (string path)
		{
			return base.OpenOutputFileStream (path);
		}

		[MonoTODO]
		public override void TerminateScriptExecution (int exitCode)
		{
			base.TerminateScriptExecution (exitCode);
		}

		[MonoTODO]
		public override System.Action<System.Exception> EventExceptionHandler {
			get { return base.EventExceptionHandler; }
		}
	}
}
