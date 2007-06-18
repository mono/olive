using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.JScript.Compiler.ParseTree
{
	public class FunctionDefinition
	{
		public readonly BlockStatement Body;
		public readonly TextSpan HeaderLocation;
		public readonly TextSpan Location;
		public readonly Identifier Name;
		public readonly List<Parameter> Parameters;
		private readonly TextPoint NameLocation;
		private readonly TextPoint LeftParenLocation;
		private readonly TextPoint RightParenLocation;

		public FunctionDefinition(Identifier Name, List<Parameter> Parameters, BlockStatement Body, TextSpan Location, TextSpan HeaderLocation, TextPoint NameLocation, TextPoint LeftParenLocation, TextPoint RightParenLocation)
		{
			this.Name = Name;
			this.Parameters = Parameters;
			this.Body = Body;
			this.Location = Location;
			this.HeaderLocation = HeaderLocation;
			this.NameLocation = NameLocation;
			this.LeftParenLocation = LeftParenLocation;
			this.RightParenLocation = RightParenLocation;
		}
	}


}
