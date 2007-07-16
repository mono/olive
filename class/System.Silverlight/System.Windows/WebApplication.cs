using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Browser;

namespace System.Windows
{
	public class WebApplication
	{
		static readonly object lockobj = new object ();
		static WebApplication current;

		public static WebApplication Current {
			get {
				if (current == null)
					lock (lockobj) {
						current = new WebApplication ();
					}
				return current;
			}
		}

		readonly IntPtr plugin_handle;
		IDictionary<string, string> startup_args;

		private WebApplication ()
		{
			object o = AppDomain.CurrentDomain.GetData ("PluginInstance");
			if (o is IntPtr)
				plugin_handle = (IntPtr) o;

		}

		internal IntPtr PluginHandle {
			get { return plugin_handle; }
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

			ScriptableObjectGenerator.Generate (plugin_handle, scriptKey, instance);
		}

		// it is non-null on silverlight apps, and null on console apps
		[MonoTODO]
		public IDictionary<string, string> StartupArguments {
			get { return startup_args; }
		}

		public event EventHandler<ApplicationUnhandledExceptionEventArgs> ApplicationUnhandledException;

		internal static T GetProperty<T> (IntPtr obj, string name)
		{
			return (T) GetPropertyInternal (Current.plugin_handle, obj, name);
		}

		internal static void SetProperty (IntPtr obj, string name, object value)
		{
			SetPropertyInternal (Current.plugin_handle, obj, name, value);
		}

		internal static void InvokeMethod (IntPtr obj, string name, params object [] args)
		{
			InvokeMethodInternal (Current.plugin_handle, obj, name, args);
		}

		internal static T InvokeMethod<T> (IntPtr obj, string name, params object [] args)
		{
			return (T) InvokeMethodInternal (Current.plugin_handle, obj, name, args);
		}

		// note that those functions do not exist

		[DllImport ("moonplugin")]
		static extern object GetPropertyInternal (IntPtr xpp, IntPtr obj, string name);

		[DllImport ("moonplugin")]
		static extern object SetPropertyInternal (IntPtr xpp, IntPtr obj, string name, object value);

		[DllImport ("moonplugin")]
		static extern object InvokeMethodInternal (IntPtr xpp, IntPtr obj, string name, object [] args);
	}
}

