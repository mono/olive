// 
// CustomPeerResolverService.cs
// 
// Author: 
//     Marcos Cobena (marcoscobena@gmail.com)
// 
// Copyright 2007 Marcos Cobena (http://www.youcannoteatbits.org/)
// 

namespace System.ServiceModel.PeerResolvers
{
	public class CustomPeerResolverService : IPeerResolverContract
	{
		private TimeSpan cleanup_interval;
		private bool control_shape;
		private TimeSpan refresh_interval;

		[MonoTODO]
		public CustomPeerResolverService ()
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public TimeSpan CleanupInterval {
			get { return cleanup_interval; }
			set { cleanup_interval = value; }
		}

		[MonoTODO]
		public bool ControlShape {
			get { return control_shape; }
			set { control_shape = value; }
		}

		[MonoTODO]
		public TimeSpan RefreshInterval {
			get { return refresh_interval; }
			set { refresh_interval = value; }
		}

		[MonoTODO]
		public virtual void Close ()
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public virtual ServiceSettingsResponseInfo GetServiceSettings ()
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public virtual void Open ()
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public virtual RefreshResponseInfo Refresh (RefreshInfo refreshInfo)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public virtual RegisterResponseInfo Register (RegisterInfo registerInfo)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public virtual RegisterResponseInfo Register (Guid clientId, 
							      string meshId, 
							      PeerNodeAddress address)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public virtual ResolveResponseInfo Resolve (ResolveInfo resolveInfo)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public virtual void Unregister (UnregisterInfo unregisterInfo)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public virtual RegisterResponseInfo Update (UpdateInfo updateInfo)
		{
			throw new NotImplementedException ();
		}

		~CustomPeerResolverService ()
		{
		}

		[MonoTODO]
		protected Object MemberwiseClone ()
		{
			throw new NotImplementedException ();
		}
	}
}