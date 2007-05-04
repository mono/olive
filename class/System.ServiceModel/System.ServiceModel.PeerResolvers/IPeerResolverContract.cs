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
        public interface IPeerResolverContract
        {
                ServiceSettingsResponseInfo GetServiceSettings ();
                RefreshResponseInfo Refresh (RefreshInfo refreshInfo);
                RegisterResponseInfo Register (RegisterInfo registerInfo);
                ResolveResponseInfo Resolve (ResolveInfo resolveInfo);
                void Unregister (UnregisterInfo unregisterInfo);
                RegisterResponseInfo Update (UpdateInfo updateInfo);
        }
}