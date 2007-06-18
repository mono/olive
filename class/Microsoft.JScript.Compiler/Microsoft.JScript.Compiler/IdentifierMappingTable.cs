using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Scripting;

namespace Microsoft.JScript.Compiler
{
	public class IdentifierMappingTable
	{
		public IdentifierMappingTable()
		{
			identifierMapping = new Dictionary<Identifier, SymbolId>();
		}

		private Dictionary<Identifier, SymbolId> identifierMapping;
		
		public SymbolId GetRowanID(Identifier ID)
		{
			if (identifierMapping.ContainsKey(ID))
				return identifierMapping[ID];
			//else create a symbole and add
			//TODO : check with nunit test if I am good for int value of symbole
			SymbolId result = new SymbolId((int)ID.KeywordValue);
			identifierMapping.Add(ID, result);
			return result;

		}
	}


}
