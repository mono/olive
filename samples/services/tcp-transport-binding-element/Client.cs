// 
// Client.cs
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
	class Client
	{
		public static void Main()
		{
			RunClient();
		}
		
		static void RunClient()
		{
			Console.WriteLine("Press ENTER when service is ready.");
			Console.ReadLine();
			
			CustomBinding binding = new CustomBinding();
			binding.Elements.Add(new TcpTransportBindingElement());
			
			BindingParameterCollection bpcol = 
				new BindingParameterCollection();
			
//			using (IChannelFactory<IDuplexSessionChannel> factory =
//			binding.BuildChannelFactory<IDuplexSessionChannel>(bpcol))
//			{
				IChannelFactory<IDuplexSessionChannel> factory =
					binding.BuildChannelFactory<IDuplexSessionChannel>(bpcol);
				
				factory.Open();
				
				IDuplexSessionChannel channel = factory.CreateChannel(
					new EndpointAddress("net.tcp://localhost/"));
				
				channel.Open();
				
				Console.ReadLine();
				
				Message message = Message.CreateMessage(
					//channel.Manager.MessageVersion, 
					MessageVersion.Default,
					"some action", "This is the body data");
				
				channel.Send(message);
				
				channel.Close();
				factory.Close();
//			}
		}
	}
}
