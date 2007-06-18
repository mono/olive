using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.JScript.Compiler.ParseTree
{
	public class ObjectLiteralExpression : Expression
	{
		public readonly List<ObjectLiteralElement> Elements;

		public ObjectLiteralExpression(List<ObjectLiteralElement> Elements, TextSpan Location)
			:base(Operation.ObjectLiteral, Location)
		{
			this.Elements = Elements;
		}
	}
}
