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
// Copyright (c) 2008 Novell, Inc. (http://www.novell.com)
//
// Authors:
//	Alan McGovern (amcgovern@novell.com)
//

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace System.IO.Packaging.Tests {

    [TestFixture]
    public class FakePackagePartTests : TestBase {

        static void Main (string [] args)
        {
            FakePackagePartTests t = new FakePackagePartTests ();
            t.FixtureSetup ();
            t.Setup ();
            t.CreateRelationship2 ();
        }

        FakePackagePart part;
        public override void Setup ()
        {
            base.Setup ();
            part = new FakePackagePart (package, uris [0]);
        }

        [Test]
        [ExpectedException (typeof (ArgumentNullException))]
        public void Constructor1 ()
        {
            FakePackagePart p = new FakePackagePart (null, null);
        }

        [Test]
        [ExpectedException (typeof (ArgumentNullException))]
        public void Constructor2 ()
        {
            FakePackagePart p = new FakePackagePart (package, null);
        }

        [Test]
        [ExpectedException (typeof (ArgumentNullException))]
        public void Constructor3 ()
        {
            FakePackagePart p = new FakePackagePart (null, uris [0]);
        }

        [Test]
        public void Constructor4 ()
        {
            new FakePackagePart (package, uris [0], null);
        }

        [Test]
        public void Constructor5 ()
        {
            new FakePackagePart (package, uris [0], "");
        }

        [Test]
        [ExpectedException (typeof (ArgumentException))]
        public void Constructor6 ()
        {
            new FakePackagePart (package, uris [0], "dgsdgdfgd");
        }

        [Test]
        [ExpectedException (typeof (ArgumentNullException))]
        public void CreateRelationship1 ()
        {
            part.CreateRelationship (null, TargetMode.External, null);
        }

        [Test]
        [ExpectedException (typeof (ArgumentNullException))]
        public void CreateRelationship2 ()
        {
            part.CreateRelationship (uris [1], TargetMode.External, null);
        }

        [Test]
        [ExpectedException (typeof (ArgumentException))]
        public void CreateRelationship3a ()
        {
            part.CreateRelationship (uris [1], TargetMode.External, "");
        }

        [Test]
        [ExpectedException (typeof (ArgumentException))]
        public void CreateRelationship3b ()
        {
            part.CreateRelationship (uris [1], TargetMode.External, "    ");
        }

        [Test]
        public void CreateRelationship4 ()
        {
            part.CreateRelationship (uris [1], TargetMode.External, "blah");
        }


        [Test]
        public void CreateRelationship5 ()
        {
            PackageRelationship r = part.CreateRelationship (uris [1], TargetMode.External, "blah", null);
            Assert.IsNotNull (r.Id, "#1");
            Assert.AreEqual (part.Uri, r.SourceUri, "#2");
            Assert.AreEqual (uris [1], r.TargetUri, "#3");
        }

        [Test]
        [ExpectedException (typeof (ArgumentNullException))]
        public void CreateRelationship6 ()
        {
            part.CreateRelationship (uris [1], TargetMode.External, "blah", "");
        }

        [Test]
        public void CreateRelationship7 ()
        {
            part.CreateRelationship (uris [1], TargetMode.External, "blah", "asda");
        }

        [Test]
        [ExpectedException (typeof (Xml.XmlException))]
        public void CreateDupeRelationship ()
        {
            part.CreateRelationship (uris [1], TargetMode.External, "blah", "asda");
            part.CreateRelationship (uris [1], TargetMode.External, "blah", "asda");
        }

        [Test]
        [ExpectedException (typeof (Xml.XmlException))]
        public void CreateDupeRelationshipId ()
        {
            part.CreateRelationship (uris [1], TargetMode.External, "blah", "asda");
            part.CreateRelationship (uris [2], TargetMode.Internal, "aaa", "asda");
        }

		[Test]
        public void EnumeratePartsBreak ()
        {
            FakePackage package = new FakePackage (FileAccess.ReadWrite, false);

            package.CreatePart (uris [0], "a/a");
            package.CreatePart (uris [1], "a/a");
            package.CreatePart (uris [2], "a/a");

            Assert.IsTrue (package.GetParts () == package.GetParts (), "#1");
            try {
                foreach (PackagePart part in package.GetParts ())
                    package.DeletePart (part.Uri);
                Assert.Fail ("This should throw an exception");
            } catch {
            }

            PackagePartCollection c = package.GetParts ();
            package.CreatePart (new Uri ("/dfds", UriKind.Relative), "a/a");
            int count = 0;
            foreach (PackagePart p in c) { count++; }
            Assert.AreEqual (3, count, "Three added, one deleted, one added");
        }
    }
}
