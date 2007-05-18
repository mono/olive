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
using System.ServiceModel.PeerResolvers;

namespace ChatServer
{
	public class ChatServer
	{
		public static void Main ()
		{
			CustomPeerResolverService cprs;
			ServiceHost sh;

			try {
				cprs = new CustomPeerResolverService ();

				cprs.RefreshInterval = TimeSpan.FromSeconds(5);

				sh = new ServiceHost(cprs);
				
				cprs.ControlShape = true;
				cprs.Open();
				sh.Open(TimeSpan.FromDays(1000000));
				
				Console.WriteLine("Server started successfully.");
				Console.ReadLine();
				
				cprs.Close();
				sh.Close();
			} catch (Exception e) {
				Console.WriteLine ("[!] {0}", e.Message);
			}
		}
	}
}