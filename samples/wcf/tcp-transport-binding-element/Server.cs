// 
// Server.cs
// 
// Author: 
//     Marcos Cobena (marcoscobena@gmail.com)
// 
// Copyright 2007 Marcos Cobena (http://www.youcannoteatbits.org/)
// 

using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;

namespace ProgrammingChannels
{
	class Service
	{
		public static void Main ()
		{
			CustomBinding binding = new CustomBinding ();
			
			binding.Elements.Add (new TextMessageEncodingBindingElement ());
			binding.Elements.Add (new TcpTransportBindingElement ());
			
			BindingParameterCollection bpcol =
				new BindingParameterCollection ();
			
//			using (IChannelListener<IDuplexSessionChannel> listener =
//				binding.BuildChannelListener<IDuplexSessionChannel> (
//					new Uri ("net.tcp://localhost/Server"), bpcol))
//			{
				IChannelListener<IDuplexSessionChannel> listener =
					binding.BuildChannelListener<IDuplexSessionChannel> (
						new Uri ("net.tcp://localhost/"), bpcol);
				
				listener.Open ();
				
				IDuplexSessionChannel channel =
					listener.AcceptChannel ();
				
				Console.WriteLine ("Listening for messages...");
				
				channel.Open ();
				
				Message message = channel.Receive ();
				
				Console.WriteLine ("Message received.");
				Console.WriteLine ("Message action: {0}", 
					message.Headers.Action);
				Console.WriteLine ("Message content: {0}", 
					message.GetBody<string> ());

				message = Message.CreateMessage (
					//channel.Manager.MessageVersion, 
					MessageVersion.Default,
					"Action", "Hello, World, from service side");
				
				channel.Send (message);
				
				message.Close ();
				channel.Close ();
				listener.Close ();
//			}
		}
	}
}
