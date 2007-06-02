using System;
using System.IO;
using System.Reflection;
using Microsoft.Scripting.Hosting;

namespace Microsoft.Scripting.Silverlight
{
	public class SilverlightPAL : PlatformAdaptationLayer
	{
		[MonoTODO]
		public override bool DirectoryExists (string path)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public override bool FileExists (string path)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public override string [] GetFiles (string path, string searchPattern)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public override string GetFullPath (string path)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public override Assembly LoadAssembly (string name)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public override Stream OpenInputFileStream (string path)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public override Stream OpenOutputFileStream (string path)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public override void TerminateScriptExecution (int exitCode)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public override System.Action<System.Exception> EventExceptionHandler {
			get { throw new NotImplementedException (); }
		}
	}
}
