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
//	Alan McGovern (amcgovern@novell.com)
//

using System;
using System.Collections.Generic;

namespace System.IO.Packaging {

	public abstract class Package : IDisposable
	{
		private PackagePartCollection partsCollection = new PackagePartCollection ();
		private Dictionary<string, PackageRelationship> relationships = new Dictionary<string, PackageRelationship> ();
		
		private Uri Uri = new Uri ("/", UriKind.Relative);
		
		protected Package (FileAccess fileOpenAccess)
			: this (fileOpenAccess, false)
		{
			
		}

		protected Package (FileAccess fileOpenAccess, bool streaming)
		{
			FileOpenAccess = fileOpenAccess;
			Streaming = streaming;
		}

		void IDisposable.Dispose ()
		{
			Flush ();
			Dispose (true);
		}

		protected virtual void Dispose (bool disposing)
		{

			// Nothing here needs to be disposed of
		}

		public FileAccess FileOpenAccess {
			get; private set;
		}

		public PackageProperties PackageProperties {
			get; private set;
		}

		private int RelationshipId {
			get; set;
		}

		private bool Streaming {
			get; set;
		}

		public void Close ()
		{
			// FIXME: Ensure that Flush is actually called before dispose
			Flush ();
			Dispose (true);
		}

		public void Flush ()
		{
			FlushCore ();
		}

		protected abstract void FlushCore ();

		public PackagePart CreatePart (Uri partUri, string contentType)
		{
			return CreatePart (partUri, contentType, CompressionOption.NotCompressed);
		}

		public PackagePart CreatePart (Uri partUri, string contentType, CompressionOption compressionOption)
		{
			Check.PartUri (partUri);
			Check.ContentTypeIsValid (contentType);

			if (PartExists (partUri))
				throw new InvalidOperationException ("This partUri is already contained in the package");
			
			PackagePart part = CreatePartCore (partUri, contentType, compressionOption);
			partsCollection.Parts.Add (part);
			return part;
		}

		public void DeletePart (Uri partUri)
		{
			Check.PartUri (partUri);
			DeletePartCore (partUri);
			partsCollection.Parts.RemoveAll (p => p.Uri == partUri);
		}

		protected abstract PackagePart CreatePartCore (Uri parentUri, string contentType, CompressionOption compressionOption);
		protected abstract void DeletePartCore (Uri partUri);

		public PackageRelationship CreateRelationship (Uri targetUri, TargetMode targetMode, string relationshipType)
		{
			return CreateRelationship (targetUri, targetMode, relationshipType, null);
		}

		public PackageRelationship CreateRelationship (Uri targetUri, TargetMode targetMode, string relationshipType, string id)
		{
			Check.TargetUri (targetUri);
			
			Check.RelationshipTypeIsValid (relationshipType);
			Check.IdIsValid (id);

			if (id == null)
				id = NextId ();
			
			PackageRelationship r = new PackageRelationship (id, this, relationshipType, Uri, targetMode, targetUri);
			relationships.Add (r.Id, r);
			return r;
		}

		public void DeleteRelationship (string id)
		{
			relationships.Remove (id);
		}

		public PackagePart GetPart (Uri partUri)
		{
			Check.PartUri (partUri);
			return GetPartCore (partUri);
		}

		protected abstract PackagePart GetPartCore (Uri partUri);

		public PackagePartCollection GetParts ()
		{
			partsCollection.Parts.Clear ();
			partsCollection.Parts.AddRange (GetPartsCore());
			return partsCollection;
		}

		protected abstract PackagePart [] GetPartsCore ();


		public virtual bool PartExists (Uri partUri)
		{
			return GetPart (partUri) != null;
		}

		public PackageRelationship GetRelationship (string id)
		{
			return relationships [id];
		}

		public PackageRelationshipCollection GetRelationships ()
		{
			return new PackageRelationshipCollection (relationships.Values);
		}

		public PackageRelationshipCollection GetRelationshipsByType (string relationshipType)
		{
			return new PackageRelationshipCollection (relationships.Values,
			                                          delegate (PackageRelationship r) { return r.RelationshipType == relationshipType; });
		}

		public bool RelationshipExists (string id)
		{
			return relationships.ContainsKey (id);
		}

		private string NextId ()
		{
			while (true)
			{
				string s = RelationshipId.ToString ();
				if (!relationships.ContainsKey (s))
					return s;
				
				RelationshipId++;
			}
		}

		public static Package Open (Stream stream)
		{
			return Open (stream, FileMode.Open);
		}

		public static Package Open (string path)
		{
			return Open (path, FileMode.OpenOrCreate);
		}

		public static Package Open (Stream stream, FileMode packageMode)
		{
			return Open (stream, packageMode, FileAccess.Read);
		}

		public static Package Open (string path, FileMode packageMode)
		{
			return Open (path, packageMode, FileAccess.ReadWrite);
		}

		public static Package Open (Stream stream, FileMode packageMode, FileAccess packageAccess)
		{
			return OpenCore (stream, packageMode, packageAccess);
		}

		public static Package Open (string path, FileMode packageMode, FileAccess packageAccess)
		{
			return Open (path, packageMode, packageAccess, FileShare.None);
		}

		public static Package Open (string path, FileMode packageMode, FileAccess packageAccess, FileShare packageShare)
		{
			if (packageShare != FileShare.Read && packageShare != FileShare.None)
				throw new NotSupportedException ("FileShare.Read and FileShare.None are the only supported options");

			FileInfo info = new FileInfo (path);
			
			// Bug - MS.NET appears to test for FileAccess.ReadWrite, not FileAccess.Write
			if (packageAccess != FileAccess.ReadWrite && !info.Exists)
				throw new ArgumentException ("packageAccess", "Cannot create stream with FileAccess.Read");

			
			if (info.Exists && packageMode == FileMode.OpenOrCreate && info.Length == 0)
				throw new FileFormatException ("Stream length cannot be zero with FileMode.Open");

			Stream s = File.Open (path, packageMode, packageAccess, packageShare);
			return Open (s, packageMode, packageAccess);
		}

		private static Package OpenCore (Stream stream, FileMode packageMode, FileAccess packageAccess)
		{
			if ((packageAccess & FileAccess.Read) == FileAccess.Read && !stream.CanRead)
				throw new IOException ("Stream does not support reading");

			if ((packageAccess & FileAccess.Write) == FileAccess.Write && !stream.CanWrite)
				throw new IOException ("Stream does not support reading");
			
			if (!stream.CanSeek)
				throw new ArgumentException ("stream", "Stream must support seeking");
			
			if (packageMode == FileMode.Open && stream.Length == 0)
				throw new FileFormatException("Stream length cannot be zero with FileMode.Open");

			if (packageMode == FileMode.Append || packageMode == FileMode.Truncate)
			{
				if (stream.CanWrite)
					throw new NotSupportedException (string.Format("PackageMode.{0} is not supported", packageMode));
				else
					throw new IOException (string.Format("PackageMode.{0} is not supported", packageMode));
			}

			// FIXME: MS docs say that a ZipPackage is returned by default.
			// It looks like if you create a custom package, you cannot use Package.Open.
			ZipPackage package = new ZipPackage (packageAccess);
			package.PackageStream = stream;
			return package;
		}
	}
}

