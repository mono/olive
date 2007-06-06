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
