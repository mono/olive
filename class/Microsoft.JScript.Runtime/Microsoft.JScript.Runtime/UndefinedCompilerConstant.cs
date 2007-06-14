using System;
using Microsoft.Scripting;
using Microsoft.Scripting.Internal.Generation;

namespace Microsoft.JScript.Runtime {
	public class UndefinedCompilerConstant : CompilerConstant {
		public UndefinedCompilerConstant ()
		{
		}

		public override object Create ()
		{
			throw new NotImplementedException ();
		}

		public override void EmitCreation (CodeGen cg)
		{
			throw new NotImplementedException ();
		}

		public override string Name {
			get { throw new NotImplementedException (); }
		}

		public override Type Type {
			get { throw new NotImplementedException (); }
		}
	}
}
