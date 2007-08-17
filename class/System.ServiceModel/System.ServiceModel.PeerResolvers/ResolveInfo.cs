// 
// ResolveInfo.cs
// 
// Author: 
//     Marcos Cobena (marcoscobena@gmail.com)
// 
// Copyright 2007 Marcos Cobena (http://www.youcannoteatbits.org/)
// 

namespace System.ServiceModel.PeerResolvers
{
	[MessageContract (IsWrapped = false)]
	public class ResolveInfo
	{
		Guid client_id;
		int max_addresses;
		string mesh_id;
		
		public ResolveInfo ()
		{
		}
		
		public ResolveInfo (Guid clientId, string meshId, int maxAddresses)
		{
			client_id = clientId;
			mesh_id = meshId;
			max_addresses = maxAddresses;
		}
		
		public Guid ClientId {
			get { return client_id; }
		}
		public int MaxAddresses {
			get { return max_addresses; }
		}
		public string MeshId {
			get { return mesh_id; }
		}
		
		[MonoTODO]
		public bool HasBody()
		{
			throw new NotImplementedException ();
		}
	}
}
