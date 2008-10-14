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
using System.Linq;

namespace System.IO.Packaging.Tests
{
    [TestFixture]
    [Category("NotWorking")]
    public class PackageRelationshipTests : TestBase
    {
        [Test]
        public void AddInvalidRelationshipTwice()
        {
            try
            {
                package.CreateRelationship(new Uri("", UriKind.Relative), TargetMode.Internal, "bmp");
            }
            catch (ArgumentException)
            {
                try
                {
                    package.CreateRelationship(new Uri("", UriKind.Relative), TargetMode.Internal, "bmp");
                }
                catch (ArgumentException)
                {
                    Assert.AreEqual(0, package.GetRelationships().Count(), "Need to be buggy and return null");
                    return; // Success
                }
            }

            Assert.Fail("Should have thrown an ArgumentException then InvalidOperationException");
        }

        [Test]
        public void AddThreeRelationShips()
        {
            PackageRelationship r1 = package.CreateRelationship(uris[0], TargetMode.Internal, "a");
            PackageRelationship r2 = package.CreateRelationship(uris[1], TargetMode.Internal, "b");
            PackageRelationship r3 = package.CreateRelationship(uris[2], TargetMode.Internal, "a");

            Assert.AreEqual(3, package.GetRelationships().Count(), "#1");
            Assert.AreEqual(2, package.GetRelationshipsByType("a").Count(), "#2");
        }

        [Test]
        public void CheckProperties()
        {
            AddThreeRelationShips();
            PackageRelationship r = package.GetRelationshipsByType("b").ToArray()[0];
            Assert.AreEqual(uris[1], r.TargetUri, "#1");
            Assert.AreEqual(TargetMode.Internal, r.TargetMode, "#2");
            Assert.AreEqual(new Uri("/", UriKind.Relative), r.SourceUri, "#3");
            Assert.AreEqual("b", r.RelationshipType, "#4");
            Assert.AreEqual(package, r.Package, "#5");
            Assert.IsTrue(package == r.Package, "#6");
            Assert.IsTrue(!string.IsNullOrEmpty(r.Id), "#7");
        }

        [Test]
        public void RemoveById()
        {
            AddThreeRelationShips();
            PackageRelationship r = package.GetRelationshipsByType("a").ToArray()[0];
            package.DeleteRelationship(r.Id);
            Assert.AreEqual(2, package.GetRelationships().Count(), "#1");
            Assert.AreEqual(1, package.GetRelationshipsByType("a").Count(), "#2");
        }

        [Test]
        public void RemoveThreeRelationships()
        {
            AddThreeRelationShips();
            foreach (PackageRelationship p in new List<PackageRelationship>(package.GetRelationships()))
                package.DeleteRelationship(p.Id);
            Assert.AreEqual(0, package.GetRelationships().Count(), "Should contain no relationships");
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveThreeRelationshipsBreak()
        {
            AddThreeRelationShips();
            foreach (PackageRelationship p in package.GetRelationships())
                package.DeleteRelationship(p.Id);
        }
    }
}
