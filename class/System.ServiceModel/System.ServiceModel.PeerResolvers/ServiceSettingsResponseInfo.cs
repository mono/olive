// 
// ServiceSettingsResponseInfo.cs
// 
// Author: 
//     Marcos Cobena (marcoscobena@gmail.com)
// 
// Copyright 2007 Marcos Cobena (http://www.youcannoteatbits.org/)
// 

namespace System.ServiceModel.PeerResolvers
{
	public class ServiceSettingsResponseInfo
	{
		private bool control_mesh_shape;
		
		public ServiceSettingsResponseInfo ()
		{
			control_mesh_shape = true;
		}
		
		public ServiceSettingsResponseInfo (bool control)
		{
			control_mesh_shape = control;
		}
		
		public bool ControlMeshShape {
			get { return control_mesh_shape; }
			set { control_mesh_shape = value; }
		}
		
		[MonoTODO]
		public bool HasBody ()
		{
			throw new NotImplementedException ();
		}
	}
}