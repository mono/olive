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
using System.IO;

namespace System.IO.Packaging {

	public abstract class PackagePart
	{
		protected PackagePart (Package package, Uri partUri)
		{
			throw new NotImplementedException ();
		}

		protected PackagePart (Package package, Uri partUri, string contentType)
		{
			throw new NotImplementedException ();
		}

		protected PackagePart (Package package, Uri partUri, string contentType, CompressionOption compressionOption)
		{
			throw new NotImplementedException ();
		}

		public CompressionOption CompressionOption {
			get { throw new NotImplementedException (); }
		}

		public string ContentType {
			get { throw new NotImplementedException (); }
		}

		public Package Package {
			get { throw new NotImplementedException (); }
		}

		public Uri Uri {
			get { throw new NotImplementedException (); }
		}

		public PackageRelationship CreateRelationship (Uri targetUri, TargetMode targetMode, string relationshipType)
		{
			throw new NotImplementedException ();
		}

		public PackageRelationship CreateRelationship (Uri targetUri, TargetMode targetMode, string relationship, string id)
		{
			throw new NotImplementedException ();
		}

		public void DeleteRelationship (string id)
		{
			throw new NotImplementedException ();
		}

		public bool RelationshipExists (string id)
		{
			throw new NotImplementedException ();
		}

		public PackageRelationship GetRelationship (string id)
		{
			throw new NotImplementedException ();
		}

		public PackageRelationshipCollection GetRelationships ()
		{
			throw new NotImplementedException ();
		}

		public PackageRelationshipCollection GetRelationshipsByType (string relationshipType)
		{
			throw new NotImplementedException ();
		}

		public Stream GetStream ()
		{
			throw new NotImplementedException ();
		}

		public Stream GetStream (FileMode mode)
		{
			throw new NotImplementedException ();
		}

		public Stream GetStream (FileMode mode, FileAccess access)
		{
			throw new NotImplementedException ();
		}

		protected abstract Stream GetStreamCore (FileMode mode, FileAccess access);

		protected virtual string GetContentTypeCore ()
		{
			throw new NotImplementedException ();
		}
	}
}