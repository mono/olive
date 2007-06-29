using System;

namespace Mono.XsltDebugger
{
	public class XsltDebuggerException : ApplicationException
	{
		public XsltDebuggerException ()
			: this ("XSLT debugger exception is raised")
		{
		}

		public XsltDebuggerException (string message)
			: this (message, null)
		{
		}

		public XsltDebuggerException (string message, Exception innerException)
			: base (message, innerException)
		{
		}
	}
}
