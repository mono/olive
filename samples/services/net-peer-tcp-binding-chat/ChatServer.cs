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
                        ServiceHost host;

                        try {
                                cprs = new CustomPeerResolverService ();

                                cprs.RefreshInterval = TimeSpan.FromSeconds (5);
                        } catch (Exception e) {
                                Console.WriteLine ("[!] {0}", e.Message);
                        }
                }
        }
}