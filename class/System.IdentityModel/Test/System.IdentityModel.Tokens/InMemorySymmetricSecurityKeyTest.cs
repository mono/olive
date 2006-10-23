//
// InMemorySymmetricSecurityKeyTest.cs
//
// Author:
//	Atsushi Enomoto <atsushi@ximian.com>
//
// Copyright (C) 2006 Novell, Inc.  http://www.novell.com
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
using System.IO;
using System.Text;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;

using Key = System.IdentityModel.Tokens.InMemorySymmetricSecurityKey;
using AES = System.Security.Cryptography.RijndaelManaged;

namespace MonoTests.System.IdentityModel.Tokens
{
	[TestFixture]
	public class InMemorySymmetricSecurityKeyTest
	{
		static X509Certificate2 cert;
		static byte [] raw;
		static byte [] wssc_label = Encoding.UTF8.GetBytes ("WS-SecureConversationWS-SecureConversation");

		static InMemorySymmetricSecurityKeyTest ()
		{
			cert = new X509Certificate2 ("Test/Resources/test.pfx", "mono");
			// randomly generated with RijndaelManaged
			// GenerateIV() and GenerateKey().
			raw = Convert.FromBase64String ("eX2EeE969RCv/5Lx8OIGLHtJrSD5PzVzO3tTy9JxU58=");
		}

		[Test]
		public void CreateSimple ()
		{
			Key key = new Key (raw);
			Assert.AreEqual (256, key.KeySize, "#1");
			// the returned value must be a clone.
			Assert.IsFalse (Object.ReferenceEquals (key.GetSymmetricKey (), raw), "#2");
		}

		[Test]
		public void GetSymmetricAlgorithm ()
		{
			Key key = new Key (raw);
			AES aes = key.GetSymmetricAlgorithm (SecurityAlgorithms.Aes256Encryption) as AES;
			Assert.IsNotNull (aes, "#1");
		}

		[Test]
		// hmm, no error
		public void GetSymmetricAlgorithmWrongSize ()
		{
			Key key = new Key (raw);
			Assert.IsNotNull (key.GetSymmetricAlgorithm (SecurityAlgorithms.Aes192Encryption));
		}

		[Test]
		// no error???
		public void GetSymmetricAlgorithmWrongSize2 ()
		{
			AES aes = new AES ();
			aes.KeySize = 192;
			aes.GenerateKey ();
			Key key = new Key (aes.Key);
			Assert.IsNotNull (key.GetSymmetricAlgorithm (SecurityAlgorithms.Aes256Encryption));
		}

		[Test]
		public void GenerateDerivedKey ()
		{
			Key key = new Key (raw);
			byte [] nonce = new byte [256];

			byte [] derived = key.GenerateDerivedKey (
				SecurityAlgorithms.Psha1KeyDerivation,
				wssc_label, nonce, key.KeySize, 0);
			Assert.IsTrue (Convert.ToBase64String (derived) != Convert.ToBase64String (raw), "#4");
			// the precomputed derivation value.
			byte [] expected = Convert.FromBase64String ("50UfLeg58TbfADujVeafUAS8typGX9LvqLOXezK/eJY=");
			Assert.AreEqual (Convert.ToBase64String (expected), Convert.ToBase64String (derived), "#5");
		}
	}
}
