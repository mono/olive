using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace System.IO.Packaging.Tests {
    class FakePackageTests : TestBase {

        //static void Main (string [] args)
        //{
        //    FakePackageTests t = new FakePackageTests ();
        //    t.FixtureSetup ();
        //    t.Setup ();
        //    t.RelationshipPartGetStream ();
        //}
        private new FakePackage package;
        public override void Setup ()
        {
            package = new FakePackage (FileAccess.ReadWrite, true);
        }

        [Test]
        public void CheckAutomaticParts ()
        {
            package.CreatePart (uris [0], contentType);
            Assert.AreEqual (1, package.CreatedParts.Count (), "#1");
            Assert.AreEqual (uris [0], package.CreatedParts [0], "#2");
            Assert.AreEqual (0, package.DeletedParts.Count (), "#3");
            Assert.AreEqual (1, package.GetParts ().Count (), "#4");
        }

        [Test]
        public void CheckAutomaticParts2 ()
        {
            package.CreateRelationship (uris [0], TargetMode.External, "relationship");
            Assert.AreEqual (1, package.CreatedParts.Count (), "#1");
            Assert.AreEqual (relationshipUri, package.CreatedParts [0], "#2");
            Assert.AreEqual (0, package.DeletedParts.Count (), "#3");
            Assert.AreEqual (1, package.GetParts ().Count (), "#4");

            PackagePart p = package.GetPart (relationshipUri);
            Assert.AreEqual (package, p.Package, "#5");
            Assert.AreEqual (CompressionOption.NotCompressed, p.CompressionOption, "#6");
            Assert.AreEqual ("application/vnd.openxmlformats-package.relationships+xml", p.ContentType, "#7");
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RelationshipPartGetRelationships ()
        {
            CheckAutomaticParts2 ();
            PackagePart p = package.GetPart (relationshipUri);
            p.GetRelationships ();
        }
    }
}
