// Author:
//   Rolf Bjarne Kvinge  (RKvinge@novell.com)
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

using Mono;
using System;


namespace System.Windows
{
	internal class ManagedDownloader
	{
		public ManagedDownloader()
		{
		}
		
		public static IntPtr CreateDownloader (IntPtr native)
		{
			Console.WriteLine ("ManagedDownloader.CreateDownloader ({0})", native);
			return IntPtr.Zero;
					}

		public static void DestroyDownloader (IntPtr state)
		{
			Console.WriteLine ("ManagedDownloader.DestroyDownloader ({0})", state);
		}

		public static void Open (string verb, string uri, bool async, IntPtr state)
		{
			Console.WriteLine ("ManagedDownloader.Open ({0}, {1}, {2}, {3})", verb, uri, async, state);
		}

		public static void Send (IntPtr state)
		{
			Console.WriteLine ("ManagedDownloader.Send ({0})", state);
		}

		public static void Abort (IntPtr state)
		{
			Console.WriteLine ("ManagedDownloader.Abort ({0})", state);
		}

		public static string GetResponseText (string part, IntPtr state)
		{
			Console.WriteLine ("ManagedDownloader.GetResponseText ({0}, {1})", part, state);
			return null;
		}
	}
}
