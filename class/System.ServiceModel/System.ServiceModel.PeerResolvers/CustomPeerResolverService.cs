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
		private bool opened;
		private TimeSpan refresh_interval;

		public CustomPeerResolverService ()
		{
			cleanup_interval = new TimeSpan(0, 1, 0);
			control_shape = false;
			opened = false;
			refresh_interval = new TimeSpan(0, 10, 0);
		}

		[MonoTODO ("To check for InvalidOperationException")]
		public TimeSpan CleanupInterval {
			get { return cleanup_interval; }
			set {
				if ((value == TimeSpan.Zero) || (value > TimeSpan.MaxValue))
					throw new ArgumentOutOfRangeException(
					"The interval is either zero or greater than MaxValue.");

				cleanup_interval = value;
			}
		}

		public bool ControlShape {
			get { return control_shape; }
			set { control_shape = value; }
		}

		[MonoTODO ("To check for InvalidOperationException")]
		public TimeSpan RefreshInterval {
			get { return refresh_interval; }
			set {
				if ((value == TimeSpan.Zero) || (value > TimeSpan.MaxValue))
					throw new ArgumentOutOfRangeException(
					"The interval is either zero or greater than MaxValue.");

				refresh_interval = value;
			}
		}

		[MonoTODO]
		public virtual void Close ()
		{
			if (! opened)
				throw new InvalidOperationException("The service has been closed by a previous call to this method.");
		}

		[MonoTODO]
		public virtual ServiceSettingsResponseInfo GetServiceSettings ()
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public virtual void Open ()
		{
			if ((cleanup_interval == TimeSpan.Zero) || (refresh_interval == TimeSpan.Zero))
				throw new ArgumentException("CleanupInterval or RefreshInterval are set to a time span interval of 0.");

			if (opened)
				throw new InvalidOperationException("The service has been started by a previous call to this method.");
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