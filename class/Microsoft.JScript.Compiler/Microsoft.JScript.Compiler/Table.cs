using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Mono.JScript.Compiler
{
	public class Table<KeyType, ValueType> where KeyType : IComparable<KeyType>
	{
		public Table()
		{
			throw new NotImplementedException();
		}

		public void Insert(KeyType Key, ValueType Value, bool OverwriteExistingEntry)
		{
			throw new NotImplementedException();
		}

		public void InsertIfNotPresent(KeyType Key, ValueType Value)
		{
			Insert (Key, Value, false);
		}

		public ValueType Lookup(KeyType Key)
		{
			throw new NotImplementedException();
		}

	}
}
