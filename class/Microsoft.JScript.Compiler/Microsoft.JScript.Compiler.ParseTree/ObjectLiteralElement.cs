using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.JScript.Compiler.ParseTree
{
	public struct ObjectLiteralElement
	{
		public readonly Expression Name;
		public readonly Expression Value;
		private readonly TextPoint ColonLocation;
		private readonly TextPoint CommaLocation;

		public ObjectLiteralElement(Expression Name, Expression Value, TextPoint ColonLocation, TextPoint CommaLocation)
		{
			this.Name = Name;
			this.Value = Value;
			this.ColonLocation = ColonLocation;
			this.CommaLocation = CommaLocation;
		}
	}

}
