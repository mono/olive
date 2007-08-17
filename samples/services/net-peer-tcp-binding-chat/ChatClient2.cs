// 
// ChatClient2.cs
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
	public class ChatClient2
	{
		string username;
		
		public ChatClient2 (string username)
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
				ResolveInfo ri = new ResolveInfo (
					guid, "net.p2p://chatMesh/ChatServer", 1);
				ResolveResponseInfo rri = proxy.Resolve (ri);
				Console.WriteLine ("Response: {0}", rri);
			}
			catch (Exception e) {
				Console.WriteLine (e.Message);
			}
		}
	}
}
