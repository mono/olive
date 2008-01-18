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

namespace System.IO.Packaging {

	public abstract class Package : IDisposable
	{
		protected Package (FileAccess openFileAccess)
		{
			throw new NotImplementedException ();
		}

		protected Package (FileAccess openfileAccess, bool streaming)
		{
			throw new NotImplementedException ();
		}

		void IDisposable.Dispose ()
		{
		}

		protected virtual void Dispose (bool disposing)
		{
			throw new NotImplementedException ();
		}

		public FileAccess FileOpenAccess {
			get { throw new NotImplementedException (); }
		}

		public PackageProperties PackageProperties {
			get { throw new NotImplementedException (); }
		}

		public void Close ()
		{
			throw new NotImplementedException ();
		}

		public void Flush ()
		{
			throw new NotImplementedException ();
		}

		protected abstract void FlushCore ();

		public PackagePart CreatePart (Uri partUri, string contentType)
		{
			throw new NotImplementedException ();
		}

		public PackagePart CreatePart (Uri partUri, string contentType, CompressionOption compressionOption)
		{
			throw new NotImplementedException ();
		}

		public void DeletePart (Uri partUri)
		{
			throw new NotImplementedException ();
		}

		protected abstract PackagePart CreatePartCore (Uri parentUri, string contentType, CompressionOption compressionOption);
		protected abstract void DeletePartCore (Uri partUri);

		public PackageRelationship CreateRelationship (Uri targetUri, TargetMode targetMode, string relationshipType)
		{
			throw new NotImplementedException ();
		}

		public PackageRelationship CreateRelationship (Uri targetUri, TargetMode targetMode, string relationshipType, string id)
		{
			throw new NotImplementedException ();
		}

		public void DeleteRelationship (string id)
		{
			throw new NotImplementedException ();
		}

		public PackagePart GetPart (Uri partUri)
		{
			throw new NotImplementedException ();
		}

		protected abstract PackagePart GetPartCore (Uri partUri);

		public PackagePartCollection GetParts ()
		{
			throw new NotImplementedException ();
		}

		protected abstract PackagePart[] GetPartsCore ();


		public virtual bool PartExists (Uri partUri)
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

		public bool RelationshipExists (string id)
		{
			throw new NotImplementedException ();
		}

		public static Package Open (Stream stream)
		{
			throw new NotImplementedException ();
		}

		public static Package Open (string path)
		{
			throw new NotImplementedException ();
		}

		public static Package Open (Stream stream, FileMode packageMode)
		{
			throw new NotImplementedException ();
		}

		public static Package Open (string path, FileMode packageMode)
		{
			throw new NotImplementedException ();
		}

		public static Package Open (Stream stream, FileMode packageMode, FileAccess packageAccess)
		{
			throw new NotImplementedException ();
		}

		public static Package Open (string path, FileMode packageMode, FileAccess packageAccess)
		{
			throw new NotImplementedException ();
		}

		public static Package Open (string path, FileMode packageMode, FileAccess packageAccess, FileShare packageShare)
		{
			throw new NotImplementedException ();
		}
	}
}

