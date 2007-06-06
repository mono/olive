using System;

namespace Microsoft.Scripting.Silverlight
{
	public static class ErrorHandler
	{
		[MonoTODO]
		public static void DisplayError (Exception e)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public static void DisplayError (Exception e, string errorType)
		{
			// we could use HtmlPage.Document and populate error contents
			// (<div><h2>message</h2><p><b>Exception details:</b> details</p></div>),
			// but that'd be probably better done at client side
			// with just some JS call.
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public static void LogEventHandlerError (Exception e)
		{
		}

		[MonoTODO]
		public static int ErrorCount {
			get { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public static Exception [] Errors {
			get { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public static int MaxErrorsToReport {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public static bool ReportErrors {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}
	}
}
