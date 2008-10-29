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
using System.Xml;
using zipsharp;

namespace System.IO.Packaging {

	public sealed class ZipPackage : Package
	{
		private Dictionary<Uri, ZipPackagePart> parts = new Dictionary<Uri, ZipPackagePart> ();
		internal Dictionary<Uri, MemoryStream> PartStreams = new Dictionary<Uri, MemoryStream> ();

		internal Stream PackageStream { get; set; }
		
		internal ZipPackage (FileAccess access)
			: base (access)
		{

		}

		internal ZipPackage (FileAccess access, bool streaming)
			: base (access, streaming)
		{

		}
		
		protected override void Dispose (bool disposing)
		{
			foreach (Stream s in PartStreams.Values)
				s.Close ();
			
			PackageStream.Close ();
		}

		protected override void FlushCore ()
		{
			// Ensure that all the data has been read out of the package
			// stream already. Otherwise we'll lose data when we recreate the zip
			foreach (ZipPackagePart part in parts.Values)
				part.GetStream ().Dispose ();

			// Empty the package stream
			PackageStream.Position = 0;
			PackageStream.SetLength (0);

			// Recreate the zip file
			using (ZipArchive archive = new ZipArchive(PackageStream, Append.Create, false)) {

				// Write all the part streams
				foreach (ZipPackagePart part in parts.Values) {
					Stream partStream = part.GetStream ();
					partStream.Seek (0, SeekOrigin.Begin);
					
					using (Stream destination = archive.GetStream (part.Uri.ToString ())) {
						int count = (int) Math.Min (2048, partStream.Length);
						byte[] buffer = new byte [count];

						while ((count = partStream.Read (buffer, 0, buffer.Length)) != 0)
							destination.Write (buffer, 0, count);
					}
				}
			}
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
			ZipPackagePart part = null;
			parts.TryGetValue (partUri, out part);
			return part;
		}

		protected override PackagePart[] GetPartsCore ()
		{
			ZipPackagePart[] p = new ZipPackagePart [parts.Count];
			parts.Values.CopyTo (p, 0);
			return p;
		}
	}
}
