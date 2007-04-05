//
// NativeInfocardCryptoHandle.cs
//
// Author:
//	Atsushi Enomoto <atsushi@ximian.com>
//
// Copyright (C) 2007 Novell, Inc.  http://www.novell.com
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
using System;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Xml;

namespace System.IdentityModel.Selectors
{
	// see http://msdn2.microsoft.com/en-us/library/aa702727.aspx

	[StructLayout (LayoutKind.Sequential)]
	struct NativeInfocardCryptoHandle
	{
		// This field order must be fixed for win32 API interop:
		NativeInfocardHandleType handle_type;
		long expiration;
		NativeCryptoParameters parameters;

		public string ToXmlString ()
		{
			// FIXME: implement
			throw new NotImplementedException ();
		}
	}

	[StructLayout (LayoutKind.Explicit)]
	struct NativeCryptoParameters
	{
		[FieldOffset (0)]
		NativeAsymmetricCryptoParameters asymmetric;
		[FieldOffset (0)]
		NativeSymmetricCryptoParameters symmetric;
		[FieldOffset (0)]
		NativeTransformCryptoParameters transform;
		[FieldOffset (0)]
		NativeHashCryptoParameters hash;

		public NativeAsymmetricCryptoParameters Asymmetric {
			get { return asymmetric; }
		}

		public NativeSymmetricCryptoParameters Symmetric {
			get { return symmetric; }
		}

		public NativeTransformCryptoParameters Transform {
			get { return transform; }
		}

		public NativeHashCryptoParameters Hash {
			get { return hash; }
		}
	}

#pragma warning disable 169
	[StructLayout (LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	struct NativeAsymmetricCryptoParameters
	{
		int key_size;
		string encalg;
		string sigalg;
	}

	[StructLayout (LayoutKind.Sequential)]
	struct NativeSymmetricCryptoParameters
	{
		int key_size;
		int block_size;
		int feedback_size;
	}

	[StructLayout (LayoutKind.Sequential)]
	struct NativeTransformCryptoParameters
	{
		int input_block_size;
		int output_block_size;
		bool multi_block_supported;
		bool reusable;
	}

	[StructLayout (LayoutKind.Sequential)]
	struct NativeHashCryptoParameters
	{
		int hash_size;
		NativeTransformCryptoParameters transform;
	}

#pragma warning restore 169
}
