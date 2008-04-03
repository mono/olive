﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace MonoTests.Features.Contracts
{
	// Define a service contract.
	[ServiceContract (Namespace = "http://MonoTests.Features.Contracts")]
	public interface IPrimitiveTesterContract
	{
		[OperationContract]
		int AddByte (byte n1, byte n2);

		[OperationContract]
		int AddSByte (sbyte n1, sbyte n2);

		[OperationContract]
		int AddShort (short n1, short n2);

		[OperationContract]
		int AddUShort (ushort n1, ushort n2);

		[OperationContract]
		int AddInt (int n1, int n2);

		[OperationContract]
		uint AddUInt (uint n1, uint n2);

		[OperationContract]
		long AddLong (long n1, long n2);

		[OperationContract]
		ulong AddULong (ulong n1, ulong n2);

		[OperationContract]
		double AddDouble (double n1, double n2);

		[OperationContract]
		float AddFloat (float n1, float n2);

		[OperationContract]
		void AddByRef(double n1, double n2, out double n3, out double n4);
	}
	
	public class PrimitiveTester : IPrimitiveTesterContract
	{		
		public int AddByte (byte n1, byte n2) {
			return (byte) n1 + n2;
		}

		public int AddSByte (sbyte n1, sbyte n2) {
			return n1 + n2;
		}

		public int AddShort (short n1, short n2) {
			return n1 + n2;
		}

		public int AddUShort (ushort n1, ushort n2) {
			return n1 + n2;
		}

		public int AddInt (int n1, int n2) {
			return n1 + n2;
		}

		public uint AddUInt (uint n1, uint n2) {
			return n1 + n2;
		}

		public long AddLong (long n1, long n2) {
			return n1 + n2;
		}

		public ulong AddULong (ulong n1, ulong n2) {
			return n1 + n2;
		}

		public double AddDouble (double n1, double n2) {
			return n1 + n2;
		}

		public float AddFloat (float n1, float n2) {
			return n1 + n2;
		}

		public void AddByRef (double n1, double n2, out double n3, out double n4) {
			n3 = n4 = n1 + n2;
		}
	}	
}