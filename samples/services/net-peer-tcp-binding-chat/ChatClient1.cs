// 
// ChatClient1.cs
// 
// Author: 
//     Marcos Cobena (marcoscobena@gmail.com)
// 
// Copyright 2007 Marcos Cobena (http://www.youcannoteatbits.org/)
// 

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.PeerResolvers;

namespace ChatClient
{
	public class ChatClient1
	{
		string username;
		
		public ChatClient1 (string username)
		{
			this.username = username;
		}
		
		public static void Main ()
		{
			BasicHttpBinding binding = new BasicHttpBinding ();
			EndpointAddress ea = new EndpointAddress (
				new Uri ("http://localhost:8080/ChatServer"));
			IPeerResolverContract proxy = ChannelFactory<IPeerResolverContract>.CreateChannel (binding, ea);
			try {
				Guid guid = Guid.NewGuid ();
				Console.WriteLine (guid);
				RegisterInfo ri = new RegisterInfo (
					guid, "net.p2p://chatMesh/ChatServer", 
					new PeerNodeAddress (new EndpointAddress ("http://localhost:8080/ChatServer"), 
					                     new ReadOnlyCollection<System.Net.IPAddress> (new List<System.Net.IPAddress> ())));
				RegisterResponseInfo rri = proxy.Register (ri);
				Console.WriteLine ("Response: {0}", rri);
			}
			catch (Exception e) {
				Console.WriteLine (e.Message);
			}
		}
	}
}
