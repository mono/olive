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
	[ServiceBehavior (UseSynchronizationContext = false, InstanceContextMode = InstanceContextMode.Single, 
	                  ConcurrencyMode = ConcurrencyMode.Multiple)]
	public class CustomPeerResolverService : IPeerResolverContract
	{
		private TimeSpan cleanup_interval;
		private bool control_shape;
		private bool opened;
		private TimeSpan refresh_interval;

		public CustomPeerResolverService ()
		{
			cleanup_interval = new TimeSpan (0, 1, 0);
			control_shape = false;
			opened = false;
			refresh_interval = new TimeSpan (0, 10, 0);
		}

		[MonoTODO ("To check for InvalidOperationException")]
		public TimeSpan CleanupInterval {
			get { return cleanup_interval; }
			set {
				if ((value < TimeSpan.Zero) || (value > TimeSpan.MaxValue))
					throw new ArgumentOutOfRangeException (
					"The interval is either zero or greater than max value.");

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
				if ((value < TimeSpan.Zero) || (value > TimeSpan.MaxValue))
					throw new ArgumentOutOfRangeException (
					"The interval is either zero or greater than max value.");

				refresh_interval = value;
			}
		}

		[MonoTODO]
		public virtual void Close ()
		{
			if (! opened)
				throw new InvalidOperationException ("The service has never been opened or it was closed by a previous call to this method.");
		}

		[MonoTODO]
		public virtual ServiceSettingsResponseInfo GetServiceSettings ()
		{
			if (! opened)
				throw new InvalidOperationException ("The service has never been opened or it was closed previously.");
		
//			return new ServiceSettingsResponseInfo ();
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public virtual void Open ()
		{
			if ((cleanup_interval == TimeSpan.Zero) || (refresh_interval == TimeSpan.Zero))
				throw new ArgumentException ("Cleanup interval or refresh interval are set to a time span interval of zero.");

			if (opened)
				throw new InvalidOperationException ("The service has been started by a previous call to this method.");
			
			opened = true;
		}

		[MonoTODO]
		public virtual RefreshResponseInfo Refresh (RefreshInfo refreshInfo)
		{
			if (refreshInfo == null)
				throw new ArgumentException ("Refresh info cannot be null.");
			
			if (! opened)
				throw new InvalidOperationException ("The service has never been opened or it was closed previously.");
			
//			return new RefreshResponseInfo ();
			throw new NotImplementedException ();
		}

		public virtual RegisterResponseInfo Register (RegisterInfo registerInfo)
		{
			if (registerInfo == null)
				throw new ArgumentException ("Register info cannot be null.");
			
			if (! opened)
				throw new InvalidOperationException ("The service has never been opened or it was closed previously.");
			
			return Register (registerInfo.ClientId, registerInfo.MeshId, registerInfo.NodeAddress);
		}

		[MonoTODO]
		public virtual RegisterResponseInfo Register (Guid clientId, 
			string meshId, 
			PeerNodeAddress address)
		{
			RegisterResponseInfo rri = new RegisterResponseInfo ();
			
			if (ControlShape) {
				// FIXME: To update mesh node here.
			}
			
			return rri;
		}

		[MonoTODO]
		public virtual ResolveResponseInfo Resolve (ResolveInfo resolveInfo)
		{
			if (resolveInfo == null)
				throw new ArgumentException ("Resolve info cannot be null.");
			
			if (! opened)
				throw new InvalidOperationException ("The service has never been opened or it was closed previously.");
			
//			return new ResolveResponseInfo ();
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public virtual void Unregister (UnregisterInfo unregisterInfo)
		{
			if (unregisterInfo == null)
				throw new ArgumentException ("Unregister info cannot be null.");
			
			if (! opened)
				throw new InvalidOperationException ("The service has never been opened or it was closed previously.");
			
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public virtual RegisterResponseInfo Update (UpdateInfo updateInfo)
		{
			if (updateInfo == null)
				throw new ArgumentException ("Update info cannot be null.");
			
			if (! opened)
				throw new InvalidOperationException ("The service has never been opened or it was closed previously.");
			
//			return new RegisterResponseInfo ();
			throw new NotImplementedException ();
		}
	}
}
