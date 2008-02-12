//
// UriTemplate.cs
//
// Author:
//	Atsushi Enomoto  <atsushi@ximian.com>
//
// Copyright (C) 2008 Novell, Inc (http://www.novell.com)
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
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using NUnit.Framework;

namespace MonoTests.System
{
	[TestFixture]
	public class UriTemplateTest
	{
		[Test]
		[ExpectedException (typeof (ArgumentNullException))]
		public void ConstructorNull ()
		{
			new UriTemplate (null);
		}

		[Test]
		public void ConstructorEmpty ()
		{
			// it does not raise an error at this state.
			new UriTemplate (String.Empty);
		}

		[Test]
		public void ConstructorBrokenTemplate ()
		{
			// it does not raise an error at this state.
			new UriTemplate ("{");
		}

		[Test]
		public void ToString ()
		{
			Assert.AreEqual ("urn:foo", new UriTemplate ("urn:foo").ToString (), "#1");
			Assert.AreEqual ("{", new UriTemplate ("{").ToString (), "#2");
		}

		[Test]
		public void Variables ()
		{
			var t = new UriTemplate ("urn:foo");
			Assert.AreEqual (0, t.PathSegmentVariableNames.Count, "#1a");
			Assert.AreEqual (0, t.QueryValueVariableNames.Count, "#1b");
			t = new UriTemplate ("http://localhost:8080/");
			Assert.AreEqual (0, t.PathSegmentVariableNames.Count, "#2a");
			Assert.AreEqual (0, t.QueryValueVariableNames.Count, "#2b");
			t = new UriTemplate ("http://localhost:8080/foo/");
			Assert.AreEqual (0, t.PathSegmentVariableNames.Count, "#3a");
			Assert.AreEqual (0, t.QueryValueVariableNames.Count, "#3b");
			t = new UriTemplate ("http://localhost:8080/{foo}");
			Assert.AreEqual (1, t.PathSegmentVariableNames.Count, "#4a");
			Assert.AreEqual ("FOO", t.PathSegmentVariableNames [0], "#4b");
			Assert.AreEqual (0, t.QueryValueVariableNames.Count, "#4c");
			t = new UriTemplate ("http://localhost:8080/{foo}/{");
			Assert.AreEqual (1, t.PathSegmentVariableNames.Count, "#5a");
			Assert.AreEqual ("FOO", t.PathSegmentVariableNames [0], "#5b");
			Assert.AreEqual (0, t.QueryValueVariableNames.Count, "#5c");
			t = new UriTemplate ("http://localhost:8080/hoge?test={foo}&test2={bar}");
			Assert.AreEqual (0, t.PathSegmentVariableNames.Count, "#6a");
			Assert.AreEqual (2, t.QueryValueVariableNames.Count, "#6b");
			Assert.AreEqual ("FOO", t.QueryValueVariableNames [0], "#6c");
			Assert.AreEqual ("BAR", t.QueryValueVariableNames [1], "#6d");
		}

		[Test]
		[ExpectedException (typeof (InvalidOperationException))]
		public void DuplicateNameInTemplate ()
		{
			// one name to two places to match
			new UriTemplate ("http://localhost:8080/hoge?test={foo}&test2={foo}");
		}

		[Test]
		[ExpectedException (typeof (InvalidOperationException))]
		public void DuplicateNameInTemplate2 ()
		{
			// one name to two places to match
			new UriTemplate ("http://localhost:8080/hoge/{foo}?test={foo}");
		}

		[Test]
		[ExpectedException (typeof (ArgumentNullException))]
		public void BindByNameNullBaseAddress ()
		{
			var t = new UriTemplate ("http://localhost:8080/");
			t.BindByName (null, new NameValueCollection ());
		}

		[Test]
		[ExpectedException (typeof (ArgumentException))]
		public void BindByNameRelativeBaseAddress ()
		{
			var t = new UriTemplate ("http://localhost:8080/");
			t.BindByName (new Uri ("", UriKind.Relative), new NameValueCollection ());
		}

		[Test]
		[ExpectedException (typeof (ArgumentException))]
		public void BindByNameFileUriBaseAddress ()
		{
			var t = new UriTemplate ("http://localhost:8080/");
			t.BindByName (new Uri ("file:///"), new NameValueCollection ());
		}

		[Test] // it is allowed.
		public void BindByNameFileExtraNames ()
		{
			var t = new UriTemplate ("http://localhost:8080/");
			var n = new NameValueCollection ();
			n.Add ("name", "value");
			t.BindByName (new Uri ("http://localhost/"), n);
		}

		[Test]
		[ExpectedException (typeof (FormatException))]
		public void BindByNameFileMissingName ()
		{
			var t = new UriTemplate ("/{foo}/");
			t.BindByName (new Uri ("http://localhost/"), new NameValueCollection ());
		}

		[Test]
		public void BindByName ()
		{
			var t = new UriTemplate ("/{foo}/{bar}/");
			var n = new NameValueCollection ();
			n.Add ("Bar", "value1"); // case insensitive
			n.Add ("FOO", "value2"); // case insensitive
			var u = t.BindByName (new Uri ("http://localhost/"), n);
			Assert.AreEqual ("http://localhost/value2/value1/", u.ToString ());
		}

		[Test]
		[ExpectedException (typeof (ArgumentNullException))]
		public void BindByPositionNullBaseAddress ()
		{
			var t = new UriTemplate ("http://localhost:8080/");
			t.BindByPosition (null);
		}

		[Test]
		[ExpectedException (typeof (ArgumentException))]
		public void BindByPositionRelativeBaseAddress ()
		{
			var t = new UriTemplate ("http://localhost:8080/");
			t.BindByPosition (new Uri ("", UriKind.Relative));
		}

		[Test]
		[ExpectedException (typeof (ArgumentException))]
		public void BindByPositionFileUriBaseAddress ()
		{
			var t = new UriTemplate ("http://localhost:8080/");
			t.BindByPosition (new Uri ("file:///"));
		}

		[Test] // it is NOT allowed (unlike BindByName)
		[ExpectedException (typeof (FormatException))]
		public void BindByPositionFileExtraValues ()
		{
			var t = new UriTemplate ("http://localhost:8080/");
			t.BindByPosition (new Uri ("http://localhost/"), "value");
		}

		[Test]
		[ExpectedException (typeof (FormatException))]
		public void BindByPositionFileMissingValues ()
		{
			var t = new UriTemplate ("/{foo}/");
			t.BindByPosition (new Uri ("http://localhost/"));
		}

		[Test]
		public void BindByPosition ()
		{
			var t = new UriTemplate ("/{foo}/{bar}/");
			var u = t.BindByPosition (new Uri ("http://localhost/"), "value1", "value2");
			Assert.AreEqual ("http://localhost/value1/value2/", u.ToString ());
		}
	}
}
