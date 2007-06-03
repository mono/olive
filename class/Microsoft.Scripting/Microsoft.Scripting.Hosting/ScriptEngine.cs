using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Microsoft.Scripting.Actions;

namespace Microsoft.Scripting.Hosting
{
	public abstract class ScriptEngine
	{
		protected ScriptEngine (LanguageProvider provider, EngineOptions engineOptions)
		{
			throw new NotImplementedException ();
		}

		public virtual void AddAssembly (Assembly assembly)
		{
			throw new NotImplementedException ();
		}

		public virtual string FormatException (Exception exception)
		{
			throw new NotImplementedException ();
		}

		protected virtual string[] FormatObjectMemberNames (IList<object> names)
		{
			throw new NotImplementedException ();
		}

		public abstract CompilerOptions GetDefaultCompilerOptions ();

		public virtual ErrorSink GetDefaultErrorSink ()
		{
			throw new NotImplementedException ();
		}

		public abstract IAttributesCollection GetGlobalsDictionary (IDictionary<string, object> globals);

		protected internal virtual LanguageContext GetLanguageContext (CompilerOptions compilerOptions)
		{
			throw new NotImplementedException ();
		}

		protected internal virtual LanguageContext GetLanguageContext (ScriptModule module)
		{
			throw new NotImplementedException ();
		}

		public virtual CompilerOptions GetModuleCompilerOptions (ScriptModule module)
		{
			throw new NotImplementedException ();
		}

		public virtual string[] GetObjectCallSignatures (object obj)
		{
			throw new NotImplementedException ();
		}

		public virtual string GetObjectDocumentation (object obj)
		{
			throw new NotImplementedException ();
		}

		protected virtual object Ops_Call (CodeContext context, object obj, object[] args)
		{
			throw new NotImplementedException ();
		}

		protected virtual IList<object> Ops_GetAttrNames (CodeContext context, object obj)
		{
			throw new NotImplementedException ();
		}

		protected virtual bool Ops_IsCallable (CodeContext context, object obj)
		{
			throw new NotImplementedException ();
		}

		protected virtual bool Ops_TryGetAttr (CodeContext context, object obj, SymbolId id, out object value)
		{
			throw new NotImplementedException ();
		}

		public abstract ScriptCompiler Compiler { get; }
		
		public abstract ActionBinder DefaultBinder { get; }
		
	}
}
