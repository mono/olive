using System;
using System.Collections.Generic;
using System.Text;

namespace Mono.JScript.Compiler
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
