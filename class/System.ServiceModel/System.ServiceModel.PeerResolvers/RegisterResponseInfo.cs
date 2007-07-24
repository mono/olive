// 
// RegisterResponseInfo.cs
// 
// Author: 
//     Marcos Cobena (marcoscobena@gmail.com)
// 
// Copyright 2007 Marcos Cobena (http://www.youcannoteatbits.org/)
// 

namespace System.ServiceModel.PeerResolvers
{
	[MessageContract (IsWrapped = false)]
	public class RegisterResponseInfo
	{
		Guid registration_id;
		TimeSpan registration_lifetime;
		
		public RegisterResponseInfo ()
		{
		}
		
		public RegisterResponseInfo (Guid registrationId, TimeSpan registrationLifetime)
		{
			registration_id = registrationId;
			registration_lifetime = registrationLifetime;
		}
		
		public Guid RegistrationId {
			get { return registration_id; }
			set { registration_id = value; }
		}
		public TimeSpan RegistrationLifetime {
			get { return registration_lifetime; }
			set { registration_lifetime = value; }
		}
		
		[MonoTODO]
		public bool HasBody ()
		{
			throw new NotImplementedException ();
		}
	}
}
