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
		IDictionary<string, string> startup_args;

		private WebApplication ()
		{
			//instance = GetCurrentInstance ();
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

			string js = ScriptableObjectGenerator.GenerateJavaScript (scriptKey, instance);
			// FIXME: probably we need to hook script access to the
			// contents of this script object.

			// ... so, can we just eval this generated JS?
			Console.WriteLine (js);
			//HtmlPage.Document.InvokeMethod ("eval", js);
		}

		// it is non-null on silverlight apps, and null on console apps
		[MonoTODO]
		public IDictionary<string, string> StartupArguments {
			get { return startup_args; }
		}

		public event EventHandler<ApplicationUnhandledExceptionEventArgs> ApplicationUnhandledException;

		internal T GetProperty<T> (IntPtr obj, string name)
		{
			return (T) GetPropertyInternal (instance, obj, name);
		}

		internal T InvokeMethod<T> (IntPtr obj, string name, params object [] args)
		{
			return (T) InvokeMethodInternal (instance, obj, name, args);
		}

		// note that those functions do not exist
		[DllImport ("moon")]
		static extern IntPtr GetCurrentInstance ();

		[DllImport ("moon")]
		static extern object GetPropertyInternal (IntPtr xpp, IntPtr obj, string name);

		[DllImport ("moon")]
		static extern object InvokeMethodInternal (IntPtr xpp, IntPtr obj, string name, object [] args);
	}
}

