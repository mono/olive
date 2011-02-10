using System;
using System.Net;
using System.Net.Sockets;

public class Tset
{
	public static void Main ()
	{
		var ip = IPAddress.Parse ("239.255.255.250");
		while (true) {
			UdpClient udp = new UdpClient (3802);
			udp.JoinMulticastGroup (ip, 1);
			IPEndPoint dummy = null;
			udp.Receive (ref dummy);
			Console.WriteLine ("Received");
			udp.DropMulticastGroup (ip);
			udp.Close ();
		}
	}
}

