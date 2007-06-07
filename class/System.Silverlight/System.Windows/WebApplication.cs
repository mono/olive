using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Browser;

namespace System.Windows
{
	public class WebApplication
	{
		static object lockobj = new object ();
		static WebApplication current;

		[MonoTODO]
		public static WebApplication Current {
			get {
				if (current == null)
					lock (lockobj) {
						current = new WebApplication ();
					}
				return current;
			}
		}

		readonly IntPtr instance;

		private WebApplication ()
		{
			instance = GetCurrentInstance ();
		}

		[MonoTODO]
		public void RegisterScriptableObject (string scriptKey, object instance)
		{
			if (scriptKey == null)
				throw new ArgumentNullException ("scriptKey");
			if (instance == null)
				throw new ArgumentNullException ("instance");

			if (scriptKey.Length == 0)
				throw new ArgumentException ("scriptKey");

			object [] atts = instance.GetType ().GetCustomAttributes (typeof (ScriptableAttribute), false);
			// It neither supports ScriptableObject nor its derived types such as HtmlElement.
			if (atts.Length == 0)
				throw new NotSupportedException ("The argument object type does not have a ScriptableAttribute");

			throw new NotImplementedException ();
		}

		[MonoTODO]
		public IDictionary<string, string> StartupArguments {
			get { throw new NotImplementedException (); }
		}

		public event EventHandler<ApplicationUnhandledExceptionEventArgs> ApplicationUnhandledException;

		[DllImport ("moon")]
		static extern IntPtr GetCurrentInstance ();
	}
}

