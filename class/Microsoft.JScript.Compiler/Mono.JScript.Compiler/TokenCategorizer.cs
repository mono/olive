using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Scripting.Hosting;
using Microsoft.Scripting;

namespace Mono.JScript.Compiler
{
	public class TokenCategorizer : Microsoft.Scripting.Hosting.TokenCategorizer
	{
		public TokenCategorizer()
		{
			throw new NotImplementedException();
		}

		public override void Initialize(object state, SourceUnitReader sourceReader, SourceLocation initialLocation)
		{
			throw new NotImplementedException();
		}

		public override TokenInfo ReadToken()
		{
			throw new NotImplementedException();
		}

		public override IEnumerable<TokenInfo> ReadTokens(int countOfChars)
		{
			throw new NotImplementedException();
		}

		public override bool SkipToken()
		{
			throw new NotImplementedException();
		}


		public override SourceLocation CurrentPosition {
			get { throw new NotImplementedException(); }
		}

		public override object CurrentState {
			get { throw new NotImplementedException(); }
		}

		public override ErrorSink ErrorSink {
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}

		public override bool IsRestartable {
			get { throw new NotImplementedException(); }
		}

	}

 

}
