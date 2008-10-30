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

	public static class PackUriHelper
	{
		public static readonly string UriSchemePack;

		public static int ComparePackUri (Uri firstPackUri, Uri secondPackUri)
		{
			// FIXME: Do i need to do validation that it is a pack:// uri?
			if (firstPackUri == null)
				return secondPackUri == null ? 0 : -1;
			if (secondPackUri == null)
				return 1;

			// FIXME: What exactly is compared. Lets assume originalstring
			return firstPackUri.OriginalString.CompareTo (secondPackUri.OriginalString);
		}

		public static int ComparePartUri (Uri firstPartUri, Uri secondPartUri)
		{
			// FIXME: Do i need to do validation that it is a part URI?
			if (firstPartUri == null)
				return secondPartUri == null ? 0 : -1;
			if (secondPartUri == null)
				return 1;

			return firstPartUri.OriginalString.CompareTo (secondPartUri.OriginalString);
		}

		public static Uri Create (Uri packageUri)
		{
			return Create (packageUri, null, null);
		}

		public static Uri Create (Uri packageUri, Uri partUri)
		{
			return Create (packageUri, partUri, null);
		}

		public static Uri Create (Uri packageUri, Uri partUri, string fragment)
		{
			//Check.PackageUri (packageUri);
			
			if (fragment != null && (fragment.Length == 0 || fragment[0] != '#'))
				throw new ArgumentException ("Fragment", "Fragment must not be empty and must start with '#'");

			// FIXME: Validate that partUri is a valid one? Must be relative, must start with '/'
			if (partUri != null)
				packageUri = new Uri(packageUri, partUri);

			if (fragment != null)
				packageUri = new Uri(packageUri, fragment);

			return packageUri;
		}

		public static Uri CreatePartUri (Uri partUri)
		{
			Check.PartUri (partUri);
			
			if (partUri.OriginalString[0] != '/')
				partUri = new Uri(new Uri ("/", UriKind.Relative), partUri);
			return partUri;
		}

		public static Uri GetNormalizedPartUri (Uri partUri)
		{
			Check.PartUri (partUri);
			return new Uri (partUri.ToString ().ToUpperInvariant (), UriKind.Relative);
		}

		public static Uri GetPackageUri (Uri packUri)
		{
			//Check.PackUri (packUri);
			string s = packUri.Host.Replace (',', '/');
			return new Uri (s, UriKind.Relative);
		}

		public static Uri GetPartUri (Uri packUri)
		{
			throw new NotImplementedException ();
		}

		public static Uri GetRelationshipPartUri (Uri partUri)
		{
			Check.PartUri (partUri);
			return new Uri ("/_rels" + partUri.OriginalString + ".rels");
		}

		public static Uri GetRelativeUri (Uri sourcePartUri, Uri targetPartUri)
		{
			//Check.SourcePartUri (sourcePartUri);
			//Check.TargetPartUri (targetPartUri);

			return sourcePartUri;
		}

		public static Uri GetSourcePartUriFromRelationshipPartUri (Uri relationshipPartUri)
		{
			//Check.RelationshipPartUri (relationshipPartUri);
			if (!IsRelationshipPartUri (relationshipPartUri))
				throw new Exception  ("is not a relationship part!?");
			return null;
		}

		public static bool IsRelationshipPartUri (Uri partUri)
		{
			Check.PartUri (partUri);
			return partUri.OriginalString.StartsWith ("/_rels") && partUri.OriginalString.EndsWith (".rels");
		}

		public static Uri ResolvePartUri (Uri sourcePartUri, Uri targetUri)
		{
			throw new NotImplementedException ();
		}
	}

}
