using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Scripting.Actions;
using Microsoft.Scripting.Hosting;
using Microsoft.Scripting;
using System.Reflection;

namespace Microsoft.JScript.Compiler
{
	public class Engine : ScriptEngine
	{
		public Engine(LanguageProvider provider, EngineOptions engineOptions)
			: base(provider, engineOptions)
		{
		}

		public override void AddAssembly(Assembly assembly)
		{
			throw new NotImplementedException();
		}

		public void AddToPath(string Directory)
		{
			throw new NotImplementedException();
		}

		public ScriptModule CreateOptimizedModule(string FileName, string ModuleName)
		{
			throw new NotImplementedException();
		}

		public override string FormatException(Exception exception)
		{
			throw new NotImplementedException();
		}

		protected override string[] FormatObjectMemberNames(IList<object> names)
		{
			throw new NotImplementedException();
		}

		public override Microsoft.Scripting.CompilerOptions GetDefaultCompilerOptions()
		{
			throw new NotImplementedException();
		}

		public override ErrorSink GetDefaultErrorSink()
		{
			throw new NotImplementedException();
		}

		public override IAttributesCollection GetGlobalsDictionary(IDictionary<string, object> globals)
		{
			throw new NotImplementedException();
		}

		protected override LanguageContext GetLanguageContext(Microsoft.Scripting.CompilerOptions compilerOptions)
		{
			throw new NotImplementedException();
		}

		protected override LanguageContext GetLanguageContext(ScriptModule module)
		{
			throw new NotImplementedException();
		}

		public override Microsoft.Scripting.CompilerOptions GetModuleCompilerOptions(ScriptModule scriptModule)
		{
			throw new NotImplementedException();
		}

		public override string[] GetObjectCallSignatures(object obj)
		{
			throw new NotImplementedException();
		}

		public override string GetObjectDocumentation(object obj)
		{
			throw new NotImplementedException();
		}

		public object Import(string ModuleName)
		{
			throw new NotImplementedException();
		}

		public void InitializeModules(string Prefix, string Executable, string Version)
		{
			throw new NotImplementedException();
		}

		protected override object Ops_Call(CodeContext context, object obj, object[] args)
		{
			throw new NotImplementedException();
		}

		protected override IList<object> Ops_GetAttrNames(CodeContext context, object obj)
		{
			throw new NotImplementedException();
		}

		protected override bool Ops_IsCallable(CodeContext context, object obj)
		{
			throw new NotImplementedException();
		}

		protected override bool Ops_TryGetAttr(CodeContext context, object obj, SymbolId id, out object value)
		{
			throw new NotImplementedException();
		}

		public override ScriptCompiler Compiler {
			get {
				throw new NotImplementedException();
			}
		}

		public static Engine CurrentEngine
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public override ActionBinder DefaultBinder
		{
			get
			{
				throw new NotImplementedException();
			}
		}

	}


}
