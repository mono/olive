// 
// ChatServer.cs
// 
// Author: 
//     Marcos Cobena (marcoscobena@gmail.com)
// 
// Copyright 2007 Marcos Cobena (http://www.youcannoteatbits.org/)
// 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
				cprs = new MyCustomPeerResolverService ();
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
				cprs.ControlShape = true;
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
	
	[ServiceBehavior (InstanceContextMode = InstanceContextMode.Single)]
	public class MyCustomPeerResolverService : CustomPeerResolverService
	{
		object mesh_lock = new object ();
		int nodes_count = 0;
		// First registered node will receive every update, just for testing purposes.
		Node unique_node = null;
		
		public override RegisterResponseInfo Register (RegisterInfo registerInfo)
		{
			Node n = new Node ();
			RegisterResponseInfo rri;
			
			if (ControlShape)
			{
				lock (mesh_lock)
				{
					Guid guid = Guid.NewGuid ();
					n.RegistrationId = guid;
					n.Address = registerInfo.NodeAddress;
					n.ClientId = registerInfo.ClientId;
					Console.WriteLine ("Register: {0}", n.ClientId);
					
					if (nodes_count == 0)
						unique_node = n;
					
					nodes_count ++;
					rri = new RegisterResponseInfo (n.RegistrationId, TimeSpan.MaxValue);
				}
			}
			else
				rri = base.Register (registerInfo);
			
			return rri;
		}
		
		public override ResolveResponseInfo Resolve (ResolveInfo resolveInfo)
		{
			ResolveResponseInfo rri = new ResolveResponseInfo ();
			
			if (ControlShape) {
				lock (mesh_lock)
				{
					if (nodes_count == 0)
						rri.Addresses = new PeerNodeAddress [0];
					else if (unique_node != null) {
						Node n = unique_node;
						rri.Addresses = new PeerNodeAddress [] {n.Address};
					}
					
					Console.WriteLine ("Resolve: {0}", resolveInfo.MeshId);
				}
			}
			else
				rri = base.Resolve (resolveInfo);
			
			return rri;
		}
		
		public override void Unregister (UnregisterInfo unregisterInfo)
		{
			if (ControlShape)
			{
				lock (mesh_lock) {
					if (nodes_count == 1) {
						unique_node = null;
						nodes_count --;
					}
					
					Console.WriteLine ("Unregister");
				}
			}
			else
				base.Unregister (unregisterInfo);
		}
	}
	
	internal class Node
	{
		public Guid ClientId;
		public Guid RegistrationId;
		public PeerNodeAddress Address;
	}
}
