using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Scripting
{
	public struct ContextId : IEquatable<ContextId>
	{
		public static ContextId Empty;
		public static ContextId RegisterContext (object identifier)
		{ throw new NotImplementedException (); }
		public static ContextId LookupContext (object identifier)
		{ throw new NotImplementedException (); }
		public int Id {
			get { throw new NotImplementedException (); }
		}

		public bool Equals (ContextId other)
		{ throw new NotImplementedException (); }

		public override int GetHashCode ()
		{ throw new NotImplementedException (); }

		public override bool Equals (object obj)
		{ throw new NotImplementedException (); }

		public static bool operator == (ContextId self, ContextId other)
		{ throw new NotImplementedException (); }

		public static bool operator != (ContextId self, ContextId other)
		{ throw new NotImplementedException (); }

	}
}
