using System;
using System.Net;
using System.Net.Sockets;

public class Tset
{
	public static void Main ()
	{
		var ip = IPAddress.Parse ("239.255.255.250");
		var bytes = new byte [] {60, 70, 75};
		UdpClient udp = new UdpClient ();
		udp.Connect (ip, 3802);
		udp.Send (bytes, 3);
		Console.WriteLine ("Sent");
		udp.Close ();
	}
}

