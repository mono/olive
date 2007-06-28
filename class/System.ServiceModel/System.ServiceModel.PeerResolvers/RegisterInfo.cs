// 
// RegisterInfo.cs
// 
// Author: 
//     Marcos Cobena (marcoscobena@gmail.com)
// 
// Copyright 2007 Marcos Cobena (http://www.youcannoteatbits.org/)
// 

namespace System.ServiceModel.PeerResolvers
{
	public class RegisterInfo
	{
		private Guid client_id;
		private string mesh_id;
		private PeerNodeAddress node_address;
		
		public RegisterInfo ()
		{
		}
		
		public RegisterInfo (Guid client, string meshId, PeerNodeAddress address)
		{
			client_id = client;
			mesh_id = meshId;
			node_address = address;
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
}