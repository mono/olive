using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Scripting
{
	public abstract class CompilerOptions : ICloneable
	{
		protected CompilerOptions ()
		{
			throw new NotImplementedException();
		}

		public abstract object Clone ();

		public virtual bool PythonTrueDivision { get { throw new NotImplementedException (); } }
	}

}
