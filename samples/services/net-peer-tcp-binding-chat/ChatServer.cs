// 
// ChatServer.cs
// 
// Author: 
//     Marcos Cobena (marcoscobena@gmail.com)
// 
// Copyright 2007 Marcos Cobena (http://www.youcannoteatbits.org/)
// 

using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.PeerResolvers;

namespace ChatServer
{
	// It works as .NET service, don't touch.
	public class ChatServer
	{
		public static void Main ()
		{
//			NetTcpBinding binding;
//			CustomBinding binding;
			BasicHttpBinding binding;
			CustomPeerResolverService cprs;
//			ServiceEndpoint se;
			ServiceHost sh;

			try {
				cprs = new CustomPeerResolverService ();
				sh = new ServiceHost (cprs);
//				binding = new NetTcpBinding ();
//				binding = new CustomBinding ();
//				binding.Elements.Add (new TextMessageEncodingBindingElement ());
//				binding.Elements.Add (new TcpTransportBindingElement ());
				binding = new BasicHttpBinding ();
//				binding.Security.Mode = SecurityMode.None;
				sh.AddServiceEndpoint (typeof (IPeerResolverContract), 
				                               binding, 
				                               new Uri ("http://localhost:8080/ChatServer"));
				cprs.ControlShape = false;
				cprs.Open ();
				sh.Open ();
				
				Console.WriteLine ("Server started successfully.");
				Console.ReadLine ();
				
				cprs.Close ();
				sh.Close ();
			} catch (Exception e) {
				Console.WriteLine ("[!] {0}", e.Message);
			}
		}
	}
}
