using System;
using System.Collections;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace Mono.XsltDebugger
{
	public abstract class XsltDebuggerBreakpoint
	{
		public virtual void Initialize (XsltDebuggerSession run)
		{
		}

		public abstract bool Match (XsltDebuggerContext ctx);

		public virtual string ToSummaryString ()
		{
			return ToString ();
		}
	}

	public class XsltStylesheetBreakpoint : XsltDebuggerBreakpoint
	{
		XPathNavigator style;
		string base_uri;
		int line, column;

		public XsltStylesheetBreakpoint (string baseUri, int line, int column)
		{
			this.base_uri = baseUri;
			this.line = line;
			this.column = column;
		}

		public int LineNumber {
			get { return line; }
		}

		public int LinePosition {
			get { return column; }
		}

		public string BaseUri {
			get { return base_uri; }
		}

		public override string ToSummaryString ()
		{
			return String.Format ("[style] {0} ({1},{2})", base_uri, line, column);
		}

		public override bool Equals (object o)
		{
			XsltStylesheetBreakpoint other = o as XsltStylesheetBreakpoint;
			return  other != null &&
				other.line == line &&
				other.column == column &&
				other.base_uri == base_uri;
		}

		public override int GetHashCode ()
		{
			return (line << 24) + (column << 16) + base_uri.GetHashCode ();
		}

		public override bool Match (XsltDebuggerContext ctx)
		{
			XPathNavigator s = ctx.StylesheetElement;
			IXmlLineInfo li = s as IXmlLineInfo;
			if (style != null)
				return s.IsSamePosition (style);
			if (li == null)
				return false;
			else if (base_uri != null && base_uri != s.BaseURI ||
				 line != li.LineNumber ||
				 column != 0 && column != li.LinePosition)
				return false;
			style = s;
			return true;
		}
	}

	public abstract class XsltOutputBreakpoint : XsltDebuggerBreakpoint
	{
	}

	public class XsltOutputXPathBreakpoint : XsltOutputBreakpoint
	{
		const string CustomCacheId = "XsltOutputXPathBreakpoint";

		// target XPath (and cache)
		XPathExpression exp;
		string xpath;

		public XsltOutputXPathBreakpoint (string xpath)
		{
			this.xpath = xpath;
		}

		public override bool Equals (object o)
		{
			XsltOutputXPathBreakpoint other = o as XsltOutputXPathBreakpoint;
			return other != null && other.xpath == xpath;
		}

		public override int GetHashCode ()
		{
			return xpath.GetHashCode ();
		}

		public override bool Match (XsltDebuggerContext ctx)
		{
			XPathNavigator last_node = ctx.Session.CustomCache [CustomCacheId] as XPathNavigator;

			XmlNodeWriter w = ctx.Session.Output as XmlNodeWriter;
			XmlNode n = w != null ? w.Document : null;
			if (n == null)
				return false; // it is not ready for debugging.

			if (exp == null)
				exp = n.CreateNavigator ().Compile (xpath);

			exp.SetContext (ctx.Session.Debugger.NamespaceManager);
			XPathNodeIterator i = w.Current.CreateNavigator ().Select (exp);
			bool next = last_node == null;
			while (i.MoveNext ()) {
				if (next) {
					ctx.Session.CustomCache [CustomCacheId] = i.Current;
					return true;
				} else if (i.Current.IsSamePosition (last_node))
					next = true;
			}
			return false;
		}

		public override string ToSummaryString ()
		{
			return String.Format ("[outout/xpath] {0}", xpath);
		}
	}
}
