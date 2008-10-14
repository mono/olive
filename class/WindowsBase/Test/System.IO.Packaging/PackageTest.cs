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

namespace System.IO.Packaging.Tests
{
    [TestFixture]
    [Category("NotWorking")]
    public class PackageTest : TestBase
    {
        string path = "test.package";

        [Test]
        [ExpectedException (typeof(IOException))]
        public void ClosedStream()
        {
            stream = new FakeStream (false, false, false);
            package = Package.Open(stream);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ReadableStream()
        {
            stream = new FakeStream(true, false, false);
            package = Package.Open(stream);
        }

        [Test]
        [ExpectedException(typeof(FileFormatException))]
        public void ReadableSeekableStream()
        {
            stream = new FakeStream(true, false, true);
            package = Package.Open(stream);
        }

        [Test]
        [ExpectedException(typeof(IOException))]
        public void SetFileModeOnStream()
        {
            stream = new FakeStream(true, false, true);
            package = Package.Open(stream, FileMode.Truncate);
        }

        [Test]
        [ExpectedException(typeof(FileFormatException))]
        public void WriteOnlyAccess()
        {
            stream = new FakeStream(true, false, true);
            package = Package.Open("path", FileMode.OpenOrCreate, FileAccess.Write);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ReadOnlyAccess()
        {
            stream = new FakeStream(true, false, true);
            package = Package.Open("path", FileMode.CreateNew, FileAccess.Read);
        }

        [Test]
        [ExpectedException(typeof(FileFormatException))]
        public void CorruptStream()
        {
            FakeStream stream = new FakeStream(true, true, true);
            stream.Write(new byte[1024], 0, 1024);
            Package p = Package.Open(stream);
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void FileShareReadWrite()
        {
            package = Package.Open(path, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
        }
    }
}
