using System;
using System.Collections.Generic;
using System.Text;
//TODO move to Mono.Scripting
namespace Mono.JScript.Compiler
{
	public class SourceLocation
	{
		public static readonly SourceLocation None;
		public static readonly SourceLocation Invalid;
		public static readonly SourceLocation MinValue;

		public SourceLocation (int index, int line, int column)
		{
			throw new NotImplementedException ();
		}

		public int Index {
			get { throw new NotImplementedException (); }
		}

		public int Line {
			get { throw new NotImplementedException (); }
		}

		public int Column {
			get { throw new NotImplementedException (); }
		}

		public static bool operator == (SourceLocation left, SourceLocation right)
		{
			throw new NotImplementedException ();
		}

		public static bool operator != (SourceLocation left, SourceLocation right)
		{
			throw new NotImplementedException ();
		}

		public static bool operator < (SourceLocation left, SourceLocation right)
		{
			throw new NotImplementedException ();
		}

		public static bool operator > (SourceLocation left, SourceLocation right)
		{
			throw new NotImplementedException ();
		}

		public static bool operator <= (SourceLocation left, SourceLocation right)
		{
			throw new NotImplementedException ();
		}

		public static bool operator >= (SourceLocation left, SourceLocation right)
		{
			throw new NotImplementedException ();
		}

		public static int Compare (SourceLocation left, SourceLocation right)
		{
			throw new NotImplementedException ();
		}
		
		public bool IsValid {
			get { throw new NotImplementedException (); } 
		}

		public override bool Equals (object obj)
		{
			throw new NotImplementedException ();
		}
		
		public override int GetHashCode ()
		{
			throw new NotImplementedException ();
		}

		public override string ToString ()
		{
			throw new NotImplementedException ();
		}
		
	}
}
