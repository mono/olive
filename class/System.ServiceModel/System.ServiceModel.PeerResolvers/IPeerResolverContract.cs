// 
// IPeerResolverContract.cs
// 
// Author: 
//     Marcos Cobena (marcoscobena@gmail.com)
// 
// Copyright 2007 Marcos Cobena (http://www.youcannoteatbits.org/)
// 

namespace System.ServiceModel.PeerResolvers
{
	[ServiceContract]
	public interface IPeerResolverContract
	{
		[OperationContract]
		ServiceSettingsResponseInfo GetServiceSettings ();
		[OperationContract]
		RefreshResponseInfo Refresh (RefreshInfo refreshInfo);
		[OperationContract]
		RegisterResponseInfo Register (RegisterInfo registerInfo);
		[OperationContract]
		ResolveResponseInfo Resolve (ResolveInfo resolveInfo);
		[OperationContract]
		void Unregister (UnregisterInfo unregisterInfo);
		[OperationContract]
		RegisterResponseInfo Update (UpdateInfo updateInfo);
	}
}