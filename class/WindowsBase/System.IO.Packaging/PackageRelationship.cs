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

	public class PackageRelationship
	{
		private string id;
		private Package package;
		private string relationshipType;
		private Uri sourceUri;
		private TargetMode targetMode;
		private Uri targetUri;
		
		internal PackageRelationship (string id, Package package, string relationshipType,
		                              Uri sourceUri, TargetMode targetMode, Uri targetUri)
		{
			Check.IdIsValid (id);
			Check.Package (package);
			Check.RelationshipTypeIsValid (relationshipType);
			Check.SourceUri (sourceUri);
			Check.TargetUri (targetUri);

			this.id = id;
			this.package = package;
			this.relationshipType = relationshipType;
			this.sourceUri = sourceUri;
			this.targetMode = targetMode;
			this.targetUri = targetUri;
		}

		public string Id {
			get { return id; }
		}
		public Package Package {
			get { return package; }
		}
		public string RelationshipType {
			get { return relationshipType; }
		}
		public Uri SourceUri {
			get { return sourceUri; }
		}
		public TargetMode TargetMode {
			get { return targetMode; }
		}
		public Uri TargetUri  {
			get { return targetUri; }
		}
	}
}
