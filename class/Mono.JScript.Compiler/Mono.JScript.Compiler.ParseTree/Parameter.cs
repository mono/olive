using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.JScript.Compiler.ParseTree
{
	public class Parameter
	{
		public readonly TextSpan Location;
		public readonly Identifier Name;
		private readonly TextPoint CommaLocation;

		public Parameter(Identifier Name, TextSpan Location, TextPoint CommaLocation)
		{
			this.Location = Location;
			this.Name = Name;
			this.CommaLocation = CommaLocation;
		}
	}
}
