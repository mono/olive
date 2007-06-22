//
// Value.cs: represents the unmanaged Value structure from runtime.cpp
//
// Author:
//   Miguel de Icaza (miguel@novell.com)
//
// Copyright 2007 Novell, Inc.
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
using System.Windows;
using System.Runtime.InteropServices;

namespace Mono {

	[StructLayout(LayoutKind.Explicit)]
	public struct Value {

		[FieldOffset (0)]
		public Kind k;

		// this needs to be 8 (so don't change it) so that the
		// overall structure is large enough on 64 bit
		// systems.  alternatively we could have just used
		// another int field here to pad it
		// correctly.. regardless, since we never use this
		// field in the C# code, and we advance by IntPtr.Size
		// to give us the proper padding, this should work,
		// even for 32 bit systems.

		[FieldOffset (8)]
		public long vlong; // The biggest size
	}
}
