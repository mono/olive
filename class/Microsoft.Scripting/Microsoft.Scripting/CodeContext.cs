using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Scripting
{
	public sealed class CodeContext
	{
		public const string ContextFieldName = "__global_context";

		public CodeContext (CodeContext parent, IAttributesCollection locals)
		{
			throw new NotImplementedException ();
		}

		public CodeContext (Scope scope, LanguageContext context)
		{
			this.scope = scope;
			this.context = context;
		}

		private Scope scope;
		private LanguageContext context;

		public LanguageContext LanguageContext { get { return context; } }
		public IAttributesCollection Locals { get { throw new NotImplementedException (); } }
		public Scope Scope { get { return Scope; } }
	}


}
