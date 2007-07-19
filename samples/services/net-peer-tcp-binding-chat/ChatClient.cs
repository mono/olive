// 
// ChatClient.cs
// 
// Author: 
//     Marcos Cobena (marcoscobena@gmail.com)
// 
// Copyright 2007 Marcos Cobena (http://www.youcannoteatbits.org/)
// 

using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.PeerResolvers;

namespace ChatClient
{
	public class ChatClient : IChatService
	{
		string username;
		
		public ChatClient (string username)
		{
			this.username = username;
		}
		
		public static void Main ()
		{
			InstanceContext ic = new InstanceContext (new ChatClient ("Marcos"));
			NetPeerTcpBinding nptb = new NetPeerTcpBinding ();
			NetTcpBinding ntb = new NetTcpBinding ();
			ntb.Security.Mode = SecurityMode.None;
			nptb.Resolver.Custom.Address = new EndpointAddress ("net.tcp://localhost/ChatServer");
			nptb.Resolver.Custom.Binding = ntb;
			nptb.Resolver.Mode = PeerResolverMode.Auto;
//			nptb.Resolver.ReferralPolicy = PeerReferralPolicy.Service;
			nptb.Security.Mode = SecurityMode.None;
			DuplexChannelFactory<IChatChannel> factory = 
				new DuplexChannelFactory<IChatChannel> (ic, 
				                                        nptb, 
				                                        new EndpointAddress ("net.p2p://chatMesh/ChatServer"));
			Console.WriteLine ("Here!");
			IChatChannel channel = factory.CreateChannel ();
			channel.Open ();
			channel.Join ("Marcos");
			// Right here, run the same process separately.
			Console.ReadLine ();
			channel.Leave ("Marcos");
			channel.Close ();
			factory.Close ();
		}
		
		public void Join (string username)
		{
			Console.WriteLine ("\"{0}\" joined the conversation.", username);
		}
		
		public void Leave (string username)
		{
			Console.WriteLine ("\"{0}\" left the conversation.", username);
		}
		
		public void SendMessage (string username, string message)
		{
			throw new NotImplementedException ();
		}
	}
	
	[ServiceContract (CallbackContract = typeof (IChatService))]
	public interface IChatService
	{
		[OperationContract (IsOneWay = true)]
		void Join (string username);
		
		[OperationContract (IsOneWay = true)]
		void Leave (string username);
		
		[OperationContract (IsOneWay = true)]
		void SendMessage (string username, string message);
	}
	
	public interface IChatChannel : IChatService, IClientChannel
	{
	}
}
