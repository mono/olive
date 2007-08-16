// 
// RegisterInfo.cs
// 
// Author: 
//     Marcos Cobena (marcoscobena@gmail.com)
// 
// Copyright 2007 Marcos Cobena (http://www.youcannoteatbits.org/)
// 

using System.Runtime.Serialization;

namespace System.ServiceModel.PeerResolvers
{
	[MessageContract (IsWrapped = false)]
	public class RegisterInfo
	{
		[MessageBodyMember (Name = "Register", Namespace = "http://schemas.microsoft.com/net/2006/05/peer")]
		RegisterInfoDC body;
		Guid client_id;
		string mesh_id;
		PeerNodeAddress node_address;
		
		public RegisterInfo ()
		{
		}
		
		public RegisterInfo (Guid client, string meshId, PeerNodeAddress address)
		{
			client_id = client;
			mesh_id = meshId;
			node_address = address;
			
			body = RegisterInfoDC.GetInstance ();
			body.ClientId = ClientId;
			body.MeshId = MeshId;
			body.NodeAddress = NodeAddress;
		}
		
		public Guid ClientId {
			get { return client_id; }
		}
		
		public string MeshId {
			get { return mesh_id; }
		}
		
		public PeerNodeAddress NodeAddress {
			get { return node_address; }
		}
		
		[MonoTODO]
		public bool HasBody ()
		{
			throw new NotImplementedException ();
		}
	}
	
	[DataContract]
	internal class RegisterInfoDC
	{
		public Guid client_id;
		private static RegisterInfoDC instance = null;
		public string mesh_id;
		public PeerNodeAddress node_address;
		
		private RegisterInfoDC ()
		{
		}
		
		public Guid ClientId {
			get { return client_id; }
			set { client_id = value; }
		}
		
		[DataMember (Name = "ClientId")]
		public string ClientIdToString {
			get { return client_id.ToString (); }
			set { client_id = new Guid (value); }
		}
		
		[DataMember]
		public string MeshId {
			get { return mesh_id; }
			set { mesh_id = value; }
		}
		
		[DataMember]
		public PeerNodeAddress NodeAddress {
			get { return node_address; }
			set { node_address = value; }
		}
		
		public static RegisterInfoDC GetInstance ()
		{
			if (instance == null)
				instance = new RegisterInfoDC ();
			
			return instance;
		}
	}
}
