using System;

namespace System.Windows
{
	public class ApplicationUnhandledExceptionEventArgs : EventArgs
	{
		Exception ex;
		bool handled;

		public ApplicationUnhandledExceptionEventArgs (Exception ex, bool handled)
		{
			if (ex == null)
				throw new ArgumentNullException ("ex");
			this.ex = ex;
			this.handled = handled;
		}

		public Exception ExceptionObject {
			get { return ex; }
		}

		public bool Handled {
			get { return handled; }
		}
	}
}

