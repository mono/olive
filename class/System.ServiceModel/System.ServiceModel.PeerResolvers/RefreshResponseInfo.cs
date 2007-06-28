// 
// RefreshResponseInfo.cs
// 
// Author: 
//     Marcos Cobena (marcoscobena@gmail.com)
// 
// Copyright 2007 Marcos Cobena (http://www.youcannoteatbits.org/)
// 

namespace System.ServiceModel.PeerResolvers
{
	public class RefreshResponseInfo
	{
		private TimeSpan registration_lifetime;
		private RefreshResult result;
		
		public RefreshResponseInfo ()
		{
		}
		
		public RefreshResponseInfo (TimeSpan registrationLifetime, RefreshResult result)
		{
			registration_lifetime = registrationLifetime;
			this.result = result;
		}
		
		public TimeSpan RegistrationLifetime {
			get { return registration_lifetime; }
			set { registration_lifetime = value; }
		}
		
		public RefreshResult Result {
			get { return result; }
			set { result = value; }
		}
		
		[MonoTODO]
		public bool HasBody ()
		{
			throw new NotImplementedException ();
		}
	}
}