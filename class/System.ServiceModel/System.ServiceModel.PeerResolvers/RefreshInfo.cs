// 
// RefreshInfo.cs
// 
// Author: 
//     Marcos Cobena (marcoscobena@gmail.com)
// 
// Copyright 2007 Marcos Cobena (http://www.youcannoteatbits.org/)
// 

using System;

namespace System.ServiceModel.PeerResolvers
{
	public class RefreshInfo
	{
		private string mesh_id;
		private Guid registration_id;
		
		public RefreshInfo ()
		{
		}
		
		public RefreshInfo (string meshId, Guid regId)
		{
			mesh_id = meshId;
			registration_id = regId;
		}
		
		public string MeshId {
			get { return mesh_id; }
		}
		
		public Guid RegistrationId {
			get { return registration_id; }
		}
		
		[MonoTODO]
		public bool HasBody ()
		{
			throw new NotImplementedException ();
		}
	}
}