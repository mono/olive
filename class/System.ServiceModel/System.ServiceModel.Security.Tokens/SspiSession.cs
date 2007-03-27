using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using Mono.Security.Protocol.Ntlm;

namespace System.ServiceModel.Security
{
	internal abstract class SspiSession
	{
		internal static readonly byte [] NtlmSSP = new byte [] {
			0x4E, 0x54, 0x4C, 0x4D, 0x53, 0x53, 0x50, 0x00};

		public long Challenge, Context, ClientOSVersion, ServerOSVersion;
		public string ServerName, DomainName, DnsHostName, DnsDomainName;

		public bool Verify (byte [] expected, byte [] actual, int offset, int length)
		{
			if (expected.Length != length)
				return false;
			for (int i = 0; i < length; i++)
				if (expected [i] != actual [i + offset])
					return false;
			return true;
		}

		public SspiSecurityBufferStruct ReadSecurityBuffer (BinaryReader reader)
		{
			return new SspiSecurityBufferStruct (
				reader.ReadInt16 (),
				reader.ReadInt16 (),
				reader.ReadInt32 ());
		}
	}

	internal struct SspiSecurityBufferStruct
	{
		public SspiSecurityBufferStruct (short length, short allocatedSpace, int offset)
		{
			Length = length;
			AllocatedSpace = allocatedSpace;
			Offset = offset;
		}

		public readonly short Length;
		public readonly short AllocatedSpace;
		public readonly int Offset;
	}

	internal class SspiClientSession : SspiSession
	{
		Type2Message type2;
		Type3Message type3;

		public byte [] ProcessMessageType1 ()
		{
			MemoryStream ms = new MemoryStream ();
			BinaryWriter w = new BinaryWriter (ms);
			w.Write (NtlmSSP);
			w.Write ((int) 1); // MessageType
			// FIXME: flags
			w.Write ((uint) 0xE21882B7);
			// FIXME: supplied domain
			w.Write ((long) 0);
			// FIXME: supplied workstation
			w.Write ((long) 0);
			// FIXME: OSVersion
			w.Write ((long) 0x0F00000A28010500);
			w.Close ();
			return ms.ToArray ();
		}

		string TargetName;

		public void ProcessMessageType2 (byte [] raw)
		{
			/*
			MemoryStream ms = new MemoryStream (raw);
			if (!Verify (NtlmSSP, raw, 0, 8))
				throw new SecurityNegotiationException ("Expected NTLM SSPI header not found");
			BinaryReader reader = new BinaryReader (ms);
			reader.ReadInt64 (); // skip 8 bytes
			if (reader.ReadInt32 () != 2)
				throw new SecurityNegotiationException ("SSPI type 2 message is expected");
			SspiSecurityBufferStruct targetName = ReadSecurityBuffer (reader);
			int flags = reader.ReadInt32 ();
			Challenge = reader.ReadInt64 ();
			Context = reader.ReadInt64 ();
			SspiSecurityBufferStruct targetInfo = ReadSecurityBuffer (reader);
			ServerOSVersion = reader.ReadInt64 ();
			byte [] bytes = reader.ReadBytes (targetName.AllocatedSpace);
			TargetName = Encoding.Unicode.GetString (bytes, 0, targetName.Length);
			for (int size = 0; size < targetInfo.Length;) {
				short type = reader.ReadInt16 ();
				short length = reader.ReadInt16 ();
				size += length + 8;
				string s = Encoding.Unicode.GetString (reader.ReadBytes (length));
				switch (type) {
				case 0: break; // terminator
				case 1: ServerName = s; break;
				case 2: DomainName = s; break;
				case 3: DnsHostName = s; break;
				case 4: DnsDomainName = s; break;
				default:
					throw new ArgumentException (String.Format ("Invalid SSPI message type 2 subblock type: {0}", type));
				}
				if (type == 0)
					break; // terminator subblock
			}
			*/
			type2 = new Type2Message (raw);
		}

		public byte [] ProcessMessageType3 (string user, string password)
		{
			TargetName = Environment.MachineName;
			ServerName = Environment.MachineName;
			// FIXME
			DomainName = ServerName;// IPGlobalProperties.GetIPGlobalProperties ().DomainName;
			DnsHostName = Dns.GetHostName ();
			DnsDomainName = DnsHostName; // FIXME

			type3 = new Type3Message (NtlmVersion.Version3);
			type3.Flags = (NtlmFlags) (unchecked ((int) 0xE2188235));
			type3.Domain = DomainName;
			type3.Host = DnsHostName;
			type3.Challenge = type2.Nonce;
			type3.Username = user;
			type3.Password = password;

			return type3.GetBytes ();
		}
	}

	internal class SspiServerSession : SspiSession
	{
		public string TargetName;
		public long SuppliedDomain, SuppliedWorkstation;
		Type1Message type1;
		Type2Message type2;
		Type3Message type3;

		public void ProcessMessageType1 (byte [] raw)
		{
			/*
			MemoryStream ms = new MemoryStream (raw);
			BinaryReader reader = new BinaryReader (ms);

			if (!Verify (NtlmSSP, raw, 0, 8))
				throw new SecurityNegotiationException ("Expected NTLM SSPI header not found");
			reader.ReadBytes (8);

			int flags = reader.ReadInt32 ();
			SuppliedDomain = reader.ReadInt64 ();
			SuppliedWorkstation = reader.ReadInt64 ();
			ClientOSVersion = reader.ReadInt64 ();
			*/
			type1 = new Type1Message (raw, NtlmVersion.Version3);
		}

		public byte [] ProcessMessageType2 ()
		{
			byte [] bytes = new byte [8];
			RandomNumberGenerator.Create ().GetNonZeroBytes (bytes);
			Challenge = bytes [0] << 24 + bytes [1] << 16 + bytes [2] << 8 + bytes [3];
			Context = 0; // FIXME
			ServerOSVersion = 0x0F00000A28010500; // FIXME
			TargetName = Environment.MachineName;
			ServerName = Environment.MachineName;
			// FIXME
			DomainName = ServerName;// IPGlobalProperties.GetIPGlobalProperties ().DomainName;
			DnsHostName = Dns.GetHostName ();
			DnsDomainName = DnsHostName; // FIXME

			/*
			MemoryStream ms = new MemoryStream ();
			BinaryWriter w = new BinaryWriter (ms);
			w.Write (NtlmSSP);
			w.Write ((int) 2); // MessageType
			// target name security buffer
			byte [] targetNameBytes = Encoding.Unicode.GetBytes (TargetName);
			int targetNameOffset = 56; // FIXME: could be different?
			w.Write ((short) (targetNameBytes.Length));
			w.Write ((short) (targetNameBytes.Length));
			w.Write (targetNameOffset);
			// FIXME: flags
			w.Write ((uint) 0xE21882B7);
			w.Write (Challenge);
			w.Write (Context);
			// FIXME: OSVersion
			w.Write ((long) 0x0F00000A28010500);
			byte [] targetInfo = GetTargetInfoSecurityBuffer ();

			w.Write ((short) (targetInfo.Length));
			w.Write ((short) (targetInfo.Length));
			w.Write (targetNameOffset + targetNameBytes.Length);

			// data
			w.Write (targetNameBytes);
			w.Write (targetInfo);

			w.Close ();

			return ms.ToArray ();
			*/

			type2 = new Type2Message (NtlmVersion.Version3);
			type2.Flags = (NtlmFlags) (unchecked ((int) 0xE21882B7));
			type2.TargetName = TargetName;
			type2.Target.ServerName = ServerName;
			type2.Target.DomainName = DomainName;
			type2.Target.DnsHostName = DnsHostName;
			type2.Target.DnsDomainName = DnsDomainName;
			return type2.GetBytes ();
		}

		/*
		byte [] GetTargetInfoSecurityBuffer ()
		{
			// target info security buffer
			MemoryStream ms = new MemoryStream ();
			BinaryWriter tw = new BinaryWriter (ms);
			tw.Write ((short) 1);
			byte [] bytes = Encoding.Unicode.GetBytes (ServerName);
			tw.Write ((short) bytes.Length);
			tw.Write (bytes);
			tw.Write ((short) 2);
			bytes = Encoding.Unicode.GetBytes (DomainName);
			tw.Write ((short) bytes.Length);
			tw.Write (bytes);
			tw.Write ((short) 3);
			bytes = Encoding.Unicode.GetBytes (DnsHostName);
			tw.Write ((short) bytes.Length);
			tw.Write (bytes);
			tw.Write ((short) 4);
			bytes = Encoding.Unicode.GetBytes (DnsDomainName);
			tw.Write ((short) bytes.Length);
			tw.Write (bytes);
			tw.Write ((short) 0);
			tw.Write ((short) 0);
			tw.Close ();
			return ms.ToArray ();
		}
		*/

		public void ProcessMessageType3 (byte [] raw)
		{
			/*
			MemoryStream ms = new MemoryStream (raw);
			if (!Verify (NtlmSSP, raw, 0, 8))
				throw new SecurityNegotiationException ("Expected NTLM SSPI header not found");
			BinaryReader reader = new BinaryReader (ms);
			reader.ReadInt64 (); // skip 8 bytes
			if (reader.ReadInt32 () != 3)
				throw new SecurityNegotiationException ("SSPI type 3 message is expected");
			SspiSecurityBufferStruct lmResInfo = ReadSecurityBuffer (reader);
			SspiSecurityBufferStruct ntlmResInfo = ReadSecurityBuffer (reader);
			SspiSecurityBufferStruct targetNameInfo = ReadSecurityBuffer (reader);
			SspiSecurityBufferStruct userNameInfo = ReadSecurityBuffer (reader);
			SspiSecurityBufferStruct wsNameInfo = ReadSecurityBuffer (reader);
			SspiSecurityBufferStruct sessionKeyInfo = ReadSecurityBuffer (reader);
			int flags = reader.ReadInt32 ();
			ServerOSVersion = reader.ReadInt64 ();
			*/
			type3 = new Type3Message (raw, NtlmVersion.Version3);
		}
	}
}
