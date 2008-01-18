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
			throw new NotImplementedException ();
		}

		public static int ComparePartUri (Uri firstPartUri, Uri secondPartUri)
		{
			throw new NotImplementedException ();
		}

		public static Uri Create (Uri packageUri)
		{
			throw new NotImplementedException ();
		}

		public static Uri Create (Uri packageUri, Uri partUri)
		{
			throw new NotImplementedException ();
		}

		public static Uri Create (Uri packageUri, Uri partUri, string fragment)
		{
			throw new NotImplementedException ();
		}

		public static Uri CreatePartUri (Uri partUri)
		{
			throw new NotImplementedException ();
		}

		public static Uri GetNormalizedPartUri (Uri partUri)
		{
			throw new NotImplementedException ();
		}

		public static Uri GetPackageUri (Uri packUri)
		{
			throw new NotImplementedException ();
		}

		public static Uri GetPartUri (Uri packUri)
		{
			throw new NotImplementedException ();
		}

		public static Uri GetRelationshipPartUri (Uri partUri)
		{
			throw new NotImplementedException ();
		}

		public static Uri GetRelativeUri (Uri sourcePartUri, Uri targetPartUri)
		{
			throw new NotImplementedException ();
		}

		public static Uri GetSourcePartUriFromRelationshipPartUri (Uri relationshipPartUri)
		{
			throw new NotImplementedException ();
		}

		public static bool IsRelationshipPartUri (Uri partUri)
		{
			throw new NotImplementedException ();
		}

		public static Uri ResolvePartUri (Uri sourcePartUri, Uri targetUri)
		{
			throw new NotImplementedException ();
		}


	}

}
