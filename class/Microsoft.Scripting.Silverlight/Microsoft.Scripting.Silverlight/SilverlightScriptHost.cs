//
// SilverlightScriptHost.cs
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
		}

		[MonoTODO]
		public override void EngineCreated (IScriptEngine engine)
		{
			base.EngineCreated (engine);
		}

		[MonoTODO]
		public override string [] GetSourceFileNames (string mask, string searchPattern)
		{
			return base.GetSourceFileNames (mask, searchPattern);
		}

		[MonoTODO]
		public override SourceFileUnit GetSourceFileUnit (IScriptEngine engine, string path, string name)
		{
			return base.GetSourceFileUnit (engine, path, name);
		}

		[MonoTODO]
		public override void ModuleCreated (IScriptModule module)
		{
			base.ModuleCreated (module);
		}

		[MonoTODO]
		public override string NormalizePath (string path)
		{
			return base.NormalizePath (path);
		}

		[MonoTODO]
		public override SourceFileUnit ResolveSourceFileUnit (string name)
		{
			return base.ResolveSourceFileUnit (name);
		}

		[MonoTODO]
		public override bool SourceDirectoryExists (string path)
		{
			return base.SourceDirectoryExists (path);
		}

		[MonoTODO]
		public override bool SourceFileExists (string path)
		{
			return base.SourceFileExists (path);
		}

		[MonoTODO]
		public override bool TryGetVariable (IScriptEngine engine, SymbolId name, out object value)
		{
			return base.TryGetVariable (engine, name, out value);
		}

		[MonoTODO]
		protected override IList<string> SourceUnitResolutionPath {
			get { return base.SourceUnitResolutionPath; }
		}
	}
}
