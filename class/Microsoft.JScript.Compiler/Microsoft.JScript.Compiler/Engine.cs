//
// Microsoft.JScript.Compiler
//
// Author:
//   Olivier Dufour (olivier.duff@gmail.com)
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
using System.Collections.Generic;
using System.Text;
using Microsoft.Scripting.Actions;
using Microsoft.Scripting.Hosting;
using Microsoft.Scripting;
using System.Reflection;
using Microsoft.JScript.Runtime;
using Microsoft.JScript.Runtime.Calls;

namespace Microsoft.JScript.Compiler
{
	public class Engine : ScriptEngine
	{
		public Engine(LanguageProvider provider, EngineOptions engineOptions)
			: base(provider, engineOptions, new JSContext ())
		{
			//compiler = new JavaScriptCompiler (this);
		}

		/*public override void AddAssembly(Assembly assembly)
		{
			throw new NotImplementedException();
		}*/

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
			return JSErrorConvertor.FormatException (exception, Options); 
		}

		protected override string[] FormatObjectMemberNames(IList<object> names)
		{
			throw new NotImplementedException();
		}

		public override Microsoft.Scripting.CompilerOptions GetDefaultCompilerOptions()
		{
			return new CompilerOptions ();
		}

		/*public override ErrorSink GetDefaultErrorSink()
		{
			return new JSErrorSink ();
		}*/

		/*public override IAttributesCollection GetGlobalsDictionary(IDictionary<string, object> globals)
		{
			throw new NotImplementedException();
		}*/

		protected override LanguageContext GetLanguageContext(Microsoft.Scripting.CompilerOptions compilerOptions)
		{
			return context;
		}

		protected override LanguageContext GetLanguageContext(ScriptModule module)
		{
			throw new NotImplementedException();
			//return context.GetLanguageContextForModule (module);
		}

		public override Microsoft.Scripting.CompilerOptions GetModuleCompilerOptions(ScriptModule scriptModule)
		{
			return GetDefaultCompilerOptions ();
			//TODO scriptModule.GetCompilerOptions ();
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
			throw new NotImplementedException ();
		}

		protected override IList<object> Ops_GetAttrNames(CodeContext context, object obj)
		{
			return JSOps.GetAttrNames (context, obj);
		}

		protected override bool Ops_IsCallable(CodeContext context, object obj)
		{
			throw new NotImplementedException ();
		}

		protected override bool Ops_TryGetAttr(CodeContext context, object obj, SymbolId id, out object value)
		{
			throw new NotImplementedException();
		}

		/*public override ScriptCompiler Compiler {
			get { return compiler; }
		}*/

		private JSContext context;
		//private JavaScriptCompiler compiler;

		public static Engine CurrentEngine
		{
			get { throw new NotImplementedException (); }
		}

		public override ActionBinder DefaultBinder {
			get { return JSBinder.Default; }
		}
	}


}
