using System;
using System.Collections.Generic;
using Microsoft.Scripting;

namespace Microsoft.JScript.Runtime.Operations {
	public class JSOperators {

		public static readonly SymbolId OperatorInPlaceRightShiftUnsigned;
		public static readonly SymbolId OperatorReverseRightShiftUnsigned;
		public static readonly SymbolId OperatorRightShiftUnsigned;

		static Dictionary<string, OperatorMapping> operator_table;
		static Dictionary<OperatorMapping, SymbolId> reverse_operator_table;

		public JSOperators ()
		{
		}

		public static SymbolId OperatorToReversedSymbol (Operators op)
		{
			throw new NotImplementedException ();
		}

		public static SymbolId OperatorToSymbol (Operators op)
		{
			throw new NotImplementedException ();
		}

		public static Dictionary<string, OperatorMapping> OperatorTable {
			get { return operator_table; }
		}

		public static Dictionary<OperatorMapping, SymbolId> ReverseOperatorTable
		{
			get { return reverse_operator_table; }
		}
	}
}
