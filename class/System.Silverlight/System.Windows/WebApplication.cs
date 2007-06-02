using System;
using System.Collections.Generic;

namespace System.Windows
{
	public class WebApplication
	{
		[MonoTODO]
		public void RegisterScriptableObject (string scriptKey, object instance)
		{
		}

		[MonoTODO]
		public static WebApplication Current {
			get { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public IDictionary<string, string> StartupArguments {
			get { throw new NotImplementedException (); }
		}

		public event EventHandler<ApplicationUnhandledExceptionEventArgs> ApplicationUnhandledException;
	}
}

