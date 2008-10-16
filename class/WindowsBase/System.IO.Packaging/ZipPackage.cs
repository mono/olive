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
// Copyright (c) 2007 Novell, Inc. (http://www.novell.com)
//
// Authors:
//	Chris Toshok (toshok@ximian.com)
//

using System;
using System.Collections.Generic;
using System.IO;

namespace System.IO.Packaging {

	public sealed class ZipPackage : Package
	{
		private Dictionary<Uri, PackagePart> parts = new Dictionary<Uri, PackagePart> ();
		
		internal ZipPackage (FileAccess access)
			: base (access)
		{
			
		}

		protected override void Dispose (bool disposing)
		{
			throw new NotImplementedException ();
		}

		protected override void FlushCore ()
		{
			throw new NotImplementedException ();
		}

		protected override PackagePart CreatePartCore (Uri partUri, string contentType, CompressionOption compressionOption)
		{
			ZipPackagePart part = new ZipPackagePart (this, partUri, contentType, compressionOption);
			parts.Add (part.Uri, part);
			return part;
		}

		protected override void DeletePartCore (Uri partUri)
		{
			parts.Remove (partUri);
		}

		protected override PackagePart GetPartCore (Uri partUri)
		{
			PackagePart part = null;
			parts.TryGetValue (partUri, out part);
			return part;
		}

		protected override PackagePart[] GetPartsCore ()
		{
			PackagePart[] p = new PackagePart [parts.Count];
			parts.Values.CopyTo (p, 0);
			return p;
		}
	}

}
