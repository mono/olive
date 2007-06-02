using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;

namespace Microsoft.Scripting.Silverlight
{
	public class SilverlightScriptHost : ScriptHost
	{
		[MonoTODO]
		public SilverlightScriptHost (IScriptEnvironment environment)
			: base (environment)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public override void EngineCreated (IScriptEngine engine)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public override string [] GetSourceFileNames (string mask, string searchPattern)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public override SourceFileUnit GetSourceFileUnit (IScriptEngine engine, string path, string name)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public override void ModuleCreated (IScriptModule module)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public override string NormalizePath (string path)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public override SourceFileUnit ResolveSourceFileUnit (string name)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public override bool SourceDirectoryExists (string path)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public override bool SourceFileExists (string path)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public override bool TryGetVariable (IScriptEngine engine, SymbolId name, out object value)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected override IList<string> SourceUnitResolutionPath {
			get { throw new NotImplementedException (); }
		}
	}
}
