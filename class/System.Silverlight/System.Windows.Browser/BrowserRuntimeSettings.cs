using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading;

namespace System.Windows.Browser
{
	public sealed class BrowserRuntimeSettings
	{
		[NonSerialized]
		CultureInfo culture;
		[NonSerialized]
		CultureInfo ui_culture;

		bool debug, html, httpnet, script;

		[DllImport ("moonplugin")]
		static extern void LoadBrowserRuntimeSettings (BrowserRuntimeSettings instance);

		internal BrowserRuntimeSettings ()
		{
			culture = Thread.CurrentThread.CurrentCulture;
			ui_culture = Thread.CurrentThread.CurrentUICulture;
			LoadBrowserRuntimeSettings (this);
		}

		public CultureInfo Culture {
			get { return culture; }
		}

		public bool EnableDebugging {
			get { return debug; }
		}

		public bool EnableHtmlAccess {
			get { return html; }
		}

		public bool EnableHttpNetworkAccess {
			get { return httpnet; }
		}

		public bool EnableScriptAccess {
			get { return script; }
		}

		public CultureInfo UICulture {
			get { return ui_culture; }
		}
	}
}

