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
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace System.IO.Packaging.Tests {
    [TestFixture]
    public class PackageTest : TestBase {

        static void Main (string [] args)
        {
            PackageTest t = new PackageTest ();
            t.FixtureSetup ();
            t.Setup ();
            t.FileShareReadWrite ();
        }
        string path = "test.package";

        public override void Setup ()
        {
            if (File.Exists (path))
                File.Delete (path);
        }

        public override void TearDown ()
        {
			try {
	            if (package != null)
	                package.Close ();
			} catch {
				// FIXME: This shouldn't be required when i implement this
			}
            if (File.Exists (path))
                File.Delete (path);
        }

        [Test]
        [ExpectedException (typeof (FileFormatException))]
        [Ignore ("Won't work until zip parsing is availabl")]
        public void CorruptStream ()
        {
            stream = new FakeStream (true, true, true);
            stream.Write (new byte [1024], 0, 1024);
            package = Package.Open (stream);
        }

        [Test]
        [ExpectedException (typeof (NotSupportedException))]
        public void FileShareReadWrite ()
        {
            package = Package.Open (path, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
        }
		
        [Test]
        [ExpectedException (typeof (FileNotFoundException))]
        public void OpenNonExistantPath ()
        {
            package = Package.Open (path, FileMode.Open);
        }

        [Test]
        public void NonExistantPath ()
        {
            package = Package.Open (path);
        }

        [Test]
        public void PreExistingPath ()
        {
            package = Package.Open (path);
            package.Close ();
            package = Package.Open (path);
        }

        [Test]
        public void CreatePath ()
        {
            package = Package.Open (path, FileMode.Create);
            Assert.AreEqual (FileAccess.ReadWrite, package.FileOpenAccess, "#1");
        }

        [Test]
        [ExpectedException (typeof (ArgumentException))]
        public void CreatePathReadonly ()
        {
            package = Package.Open (path, FileMode.Create, FileAccess.Read);
            package.Close ();
        }

        [Test]
        public void CreatePathTwice ()
        {
            package = Package.Open (path, FileMode.Create);
            package.Close ();
            package = Package.Open (path, FileMode.Open);
            Assert.AreEqual (FileAccess.ReadWrite, package.FileOpenAccess);
        }

        [Test]
        public void OpenPathReadonly ()
        {
            package = Package.Open (path, FileMode.Create);
            package.Close ();
            package = Package.Open (path, FileMode.Open, FileAccess.Read);
            Assert.AreEqual (FileAccess.Read, package.FileOpenAccess, "Should be read access");
        }

        [Test]
        [ExpectedException (typeof (ArgumentException))]
        public void ReadableStream ()
        {
            stream = new FakeStream (true, false, false);
            package = Package.Open (stream);
        }

        [Test]
        [ExpectedException (typeof (FileFormatException))]
        public void ReadableSeekableStream ()
        {
            stream = new FakeStream (true, false, true);
            package = Package.Open (stream);
        }

        [Test]
        [ExpectedException (typeof (FileFormatException))]
        [Ignore ("Won't work until zip parsing is availabl")]
        public void ReadableSeekableFullStream ()
        {
            stream = new FakeStream (true, false, true);
            stream.Write (new byte [10], 0, 10);
            package = Package.Open (stream);
        }

        [Test]
        [ExpectedException (typeof (ArgumentException))]
        public void ReadOnlyAccess ()
        {
            stream = new FakeStream (true, false, true);
            package = Package.Open (path, FileMode.CreateNew, FileAccess.Read);
        }

        [Test]
        [ExpectedException (typeof (IOException))]
        public void SetFileModeOnUnwriteableStream ()
        {
            stream = new FakeStream (true, false, true);
            package = Package.Open (stream, FileMode.Truncate);
        }

        [Test]
        [ExpectedException (typeof (NotSupportedException))]
        public void SetAppendOnWriteableStream ()
        {
            stream = new FakeStream (true, true, true);
            package = Package.Open (stream, FileMode.Append);
        }

        [Test]
        public void SetCreateNewOnWriteableStream ()
        {
            stream = new FakeStream (true, true, true);
            package = Package.Open (stream, FileMode.CreateNew);
        }

        [Test]
        public void SetCreateOnWriteableStream ()
        {
            stream = new FakeStream (true, true, true);
            package = Package.Open (stream, FileMode.Create);
        }

        [Test]
        [ExpectedException (typeof (FileFormatException))]
        public void SetOpenOnWriteableStream ()
        {
            stream = new FakeStream (true, true, true);
            package = Package.Open (stream, FileMode.Open);
        }

        [Test]
        public void SetOpenOrCreateOnWriteableStream ()
        {
            stream = new FakeStream (true, true, true);
            package = Package.Open (stream, FileMode.OpenOrCreate);
        }

        [Test]
        [ExpectedException (typeof (NotSupportedException))]
        public void SetTruncateOnWriteableStream ()
        {
            stream = new FakeStream (true, true, true);
            package = Package.Open (stream, FileMode.Truncate);
        }

        [Test]
        [ExpectedException (typeof (NotSupportedException))]
        public void SetTruncateOnWriteablePath ()
        {
            stream = new FakeStream (true, true, true);
            File.Create (path).Close ();
            package = Package.Open (path, FileMode.Truncate);
        }

        [Test]
        [ExpectedException (typeof (FileFormatException))]
        public void StreamOpen ()
        {
            stream = new FakeStream (true, true, true);
            package = Package.Open (stream, FileMode.Open);
        }

        [Test]
        public void StreamCreate ()
        {
            stream = new FakeStream (true, true, true);
            package = Package.Open (stream, FileMode.Create);
        }

        [Test]
        [ExpectedException (typeof (IOException))]
        public void UnusableStream ()
        {
            stream = new FakeStream (false, false, false);
            package = Package.Open (stream);
        }

        // Bug - I'm passing in FileAccess.Write but it thinks I've passed FileAccess.Read
        [Test]
        [ExpectedException (typeof (ArgumentException))]
        public void WriteAccessDoesntExist ()
        {
            package = Package.Open (path, FileMode.OpenOrCreate, FileAccess.Write);
        }

        [Test]
        public void ReadWriteAccessDoesntExist ()
        {
            package = Package.Open (path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        }

        [Test]
        [ExpectedException (typeof (FileFormatException))]
        public void WriteOnlyAccessExists ()
        {
            System.IO.File.Create (path).Close ();
            package = Package.Open (path, FileMode.OpenOrCreate, FileAccess.Write);
        }
    }
}
