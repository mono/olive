using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.JScript.Compiler
{
	public class DList<ElementType, ParentType>
	{
		public DList ()
		{
			throw new NotImplementedException ();
		}
		public void Append (ElementType Item)
		{
			throw new NotImplementedException ();
		}
		public DList<ElementType, ParentType> Copy ()
		{
			throw new NotImplementedException ();
		}
		public ElementType Last ()
		{
			throw new NotImplementedException ();
		}

		public ParentType Parent {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		public class Iterator
		{
			public Iterator (DList<ElementType, ParentType> DL)
			{
				throw new NotImplementedException ();
			}
			public void Advance ()
			{
				throw new NotImplementedException ();
			}
			public void Insert (ElementType Item)
			{
				throw new NotImplementedException ();
			}
			public void Remove ()
			{
				throw new NotImplementedException ();
			}

			public ElementType Element {
				get { throw new NotImplementedException (); }
			}
			public bool ElementAvailable {
				get { throw new NotImplementedException (); }
			}
		}
	}
}
