using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.JScript.Compiler
{
	public struct TextPoint
	{
		private int position;

		public TextPoint(int Position)
		{
			position = Position;
		}

		public int Position {
			get { return position; }
		}
	}

}
