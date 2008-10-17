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
//  Alan McGovern (amcgovern@novell.com)
//

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace System.IO.Packaging {

	public abstract class PackagePart
	{
		private string contentType;
		private int relationshipId;
		private Dictionary<string, PackageRelationship> relationships;
		private Stream PartStream { get; set;  }
		
		protected PackagePart (Package package, Uri partUri)
			: this(package, partUri, null)
		{
			
		}

		protected internal PackagePart (Package package, Uri partUri, string contentType)
			: this (package, partUri, contentType, CompressionOption.Normal)
		{
			
		}

		protected internal PackagePart (Package package, Uri partUri, string contentType, CompressionOption compressionOption)
		{
			Check.Package (package);
			Check.PartUri (partUri);
			Check.ContentTypeIsValid (contentType);

			Package = package;
			Uri = partUri;
			ContentType = contentType;
			CompressionOption = compressionOption;

			relationships = new Dictionary<string, PackageRelationship> ();
		}

		public CompressionOption CompressionOption {
			get; private set;
		}

		public string ContentType {
			get {
				if (contentType == null && (contentType = GetContentTypeCore()) == null)
					throw new NotSupportedException ("If contentType is not supplied in the constructor, GetContentTypeCore must be overridden");
				return contentType;
			}
			private set {
				contentType = value;
			}
		}

		public Package Package {
			get; private set;
		}

		public Uri Uri {
			get; private set;
		}

		private void CheckIsRelationship ()
		{
			foreach (PackageRelationship r in Package.GetRelationships ())
				if (r.TargetUri == Uri)
					throw new InvalidOperationException ("A relationship cannot have relationships to other parts"); 
		}

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

			if (relationships.ContainsKey (id))
				throw new XmlException ("A relationship with this ID already exists");
			
			PackageRelationship r = new PackageRelationship (id, Package, relationshipType, Uri, targetMode, targetUri);
			relationships.Add (r.Id, r);
			return r;
		}

		public void DeleteRelationship (string id)
		{
			CheckIsRelationship ();
			relationships.Remove (id);
		}

		public bool RelationshipExists (string id)
		{
			CheckIsRelationship ();
			return relationships.ContainsKey (id);
		}

		public PackageRelationship GetRelationship (string id)
		{
			CheckIsRelationship ();
			return relationships [id];
		}

		public PackageRelationshipCollection GetRelationships ()
		{
			CheckIsRelationship ();
			return new PackageRelationshipCollection (relationships.Values);
		}

		public PackageRelationshipCollection GetRelationshipsByType (string relationshipType)
		{
			CheckIsRelationship ();
			return new PackageRelationshipCollection (relationships.Values, delegate (PackageRelationship r) {
				return r.RelationshipType == relationshipType;
			});
		}

		public Stream GetStream ()
		{
			// FIXME: Need to find out what kind of access the streams are usually opened with
			// Appears to be read/write/seek == true.
			return GetStream (Package.FileOpenAccess == FileAccess.Read ? FileMode.Open : FileMode.OpenOrCreate);
		}

		public Stream GetStream (FileMode mode)
		{
			return GetStream (mode, Package.FileOpenAccess);
		}

		public Stream GetStream (FileMode mode, FileAccess access)
		{
			return GetStreamCore (mode, access);
		}

		protected abstract Stream GetStreamCore (FileMode mode, FileAccess access);

		protected virtual string GetContentTypeCore ()
		{
			return null;
		}

		private string NextId ()
		{
			while (true)
			{
				string s = relationshipId.ToString ();
				if (!RelationshipExists (s))
					return s;
				relationshipId ++;
			}
		}
	}
}