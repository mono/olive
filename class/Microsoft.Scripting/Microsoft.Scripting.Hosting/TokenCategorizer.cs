using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Scripting.Hosting
{
	public abstract class TokenCategorizer
	{
		public abstract void Initialize (object state, SourceUnitReader sourceReader, SourceLocation initialLocation);
		
		public abstract TokenInfo ReadToken ();

		public virtual IEnumerable<TokenInfo> ReadTokens (int countOfChars)
		{
			throw new NotImplementedException ();
		}

		public virtual bool SkipToken ()
		{
			throw new NotImplementedException ();
		}

		public abstract SourceLocation CurrentPosition { get; }
		public abstract object CurrentState { get; }
		public abstract ErrorSink ErrorSink { get; set; }
		public abstract bool IsRestartable { get; }


	}
}
