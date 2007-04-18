//
// IdentityCardEncryption.cs
//
// Author:
//	Atsushi Enomoto <atsushi@ximian.com>
//
// Copyright (C) 2007 Novell, Inc.  http://www.novell.com
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
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml;

// http://msdn2.microsoft.com/en-us/library/bb298802.aspx#infocardprofile_topic9

namespace Mono.ServiceModel.IdentitySelectors
{
	public class IdentityCardEncryption
	{
		static readonly byte [] encEntropy = new byte [] {
			0xd9, 0x59, 0x7b, 0x26, 0x1e, 0xd8, 0xb3, 0x44,
			0x93, 0x23, 0xb3, 0x96, 0x85, 0xde, 0x95, 0xfc };
		static readonly byte [] intEntropy = new byte [] {
			0xc4, 0x01, 0x7b, 0xf1, 0x6b, 0xad, 0x2f, 0x42,
			0xaf, 0xf4, 0x97, 0x7d, 0x4, 0x68, 0x3, 0xdb };

		/*
		public void Encrypt (string file, string password)
		{
			string content = new StreamReader (file, Encoding.UTF8).ReadToEnd ();
			string ns = "http://schemas.xmlsoap.org/ws/2005/05/identity";
			string encNS = EncryptedXml.XmlEncNamespaceUrl;

			byte [] salt = new byte [16];
			byte [] encKey = CreateEncryptionKey (password, salt);
			byte [] intKey = CreateIntegrityKey (password, salt);

			RijndaelManaged aes = new RijndaelManaged ();
			aes.Key = encKey;
			aes.GenerateIV ();

			byte [] results = null;

			XmlWriter w = XmlWriter.Create (Console.Out);
			w.WriteStartElement ("EncryptedStore", ns);
			w.WriteStartElement ("StoreSalt", ns);
			w.WriteString (Convert.ToBase64String (aes.IV));
			w.WriteEndElement ();
			w.WriteStartElement ("EncryptedData", encNS);
			w.WriteStartElement ("CipherData", encNS);
			w.WriteStartElement ("CipherValue", encNS);
			w.WriteString (Convert.ToBase64String (results));
			w.WriteEndElement ();
			w.WriteEndElement ();
			w.WriteEndElement ();
			w.WriteEndElement ();
		}
		*/

		public string Decrypt (string crdsfile, string password)
		{
			XmlDocument doc = new XmlDocument ();
			doc.Load (crdsfile);

			byte [] salt = Convert.FromBase64String (
				doc.DocumentElement.FirstChild.FirstChild.Value);
			if (salt.Length != 16)
				throw new ArgumentException (String.Format ("Invalid salt length: expected 16 bytes but got {1} bytes", salt.Length));
			byte [] cipherValue = Convert.FromBase64String (
				doc.DocumentElement.LastChild.InnerText);

			return Decrypt (password, salt, cipherValue);
		}

		public string Decrypt (string password, byte [] salt, byte [] cipherValue)
		{
			byte [] iv = CreateSubArray (cipherValue, 0, 16);
			byte [] integrity = CreateSubArray (cipherValue, 16, 32);
			byte [] content = CreateSubArray (cipherValue, 48, cipherValue.Length - 48);
			// LAMESPEC: the actual content is iv+content.
			content = JoinArray (iv, content);

			EncryptedData ed = new EncryptedData ();
			ed.CipherData = new CipherData ();
			ed.CipherData.CipherValue = content;

			byte [] encKey = CreateEncryptionKey (password, salt);
			if (encKey.Length != 32)
				throw new Exception ("INTERNAL ERROR: Unexpected encryption key size: " + encKey.Length);
			byte [] intKey = CreateIntegrityKey (password, salt);
			if (intKey.Length != 32)
				throw new Exception ("INTERNAL ERROR: Unexpected integrity key size: " + intKey.Length);
			RijndaelManaged aes = new RijndaelManaged ();
			aes.BlockSize = 128;
			aes.IV = iv;
			aes.Key = encKey;
			aes.Padding = PaddingMode.PKCS7;
			aes.Mode = CipherMode.CBC;

			ed.EncryptionMethod = new EncryptionMethod ();
			ed.EncryptionMethod.KeyAlgorithm = EncryptedXml.XmlEncAES256Url ;
			ed.EncryptionMethod.KeySize = 256;

			// FIXME: actually we need some hook to retrieve
			// TransformFinalBlock bytes for integrity check.
			byte [] bytes = new EncryptedXml ().DecryptData (ed, aes);

			// since the restored bytes contain BOM, they had
			// better be stripped by StreamReader (since I'm not
			// sure if future versions of this data keep BOM).
			MemoryStream ms = new MemoryStream (bytes);
			string s = new StreamReader (ms, Encoding.UTF8).ReadToEnd ();
			return s;
		}

		byte [] CreateEncryptionKey (string password, byte [] salt)
		{
			return CreateComputedKey (password, salt, encEntropy);
		}

		byte [] CreateIntegrityKey (string password, byte [] salt)
		{
			return CreateComputedKey (password, salt, intEntropy);
		}

		byte [] CreateComputedKey (string password, byte [] salt, byte [] entropy)
		{
			byte [] pkcs5 = new PasswordDeriveBytes (
				// LAMESPEC: the actual password string is decoded as utf-16LE
				Encoding.Unicode.GetBytes (password), salt, "SHA256", 1000).GetBytes (32);

			return SHA256.Create ().ComputeHash (JoinArray (entropy, pkcs5));
		}

		public static byte [] CreateSubArray (byte [] array, int index, int length)
		{
			byte [] ret = new byte [length];
			Array.Copy (array, index, ret, 0, length);
			return ret;
		}

		public static byte [] JoinArray (byte [] a1, byte [] a2)
		{
			byte [] ret = new byte [a1.Length + a2.Length];
			Array.Copy (a1, 0, ret, 0, a1.Length);
			Array.Copy (a2, 0, ret, a1.Length, a2.Length);
			return ret;
		}
	}
}
