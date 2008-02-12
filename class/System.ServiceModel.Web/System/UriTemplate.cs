//
// UriTemplate.cs
//
// Author:
//	Atsushi Enomoto  <atsushi@ximian.com>
//
// Copyright (C) 2008 Novell, Inc (http://www.novell.com)
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Globalization;
using System.Text;

namespace System
{
	public class UriTemplate
	{
		static readonly ReadOnlyCollection<string> empty_strings = new ReadOnlyCollection<string> (new string [0]);

		string template;
		Uri uri;
		ReadOnlyCollection<string> path, query;

		public UriTemplate (string template)
		{
			if (template == null)
				throw new ArgumentNullException ("template");
			this.template = template;

			int q = template.IndexOf ('?');
			path = ParseTemplate (template, 0, q >= 0 ? q : template.Length);
			if (q >= 0)
				query = ParseTemplate (template, q, template.Length);
			else
				query = empty_strings;
		}

		public ReadOnlyCollection<string> PathSegmentVariableNames {
			get { return path; }
		}

		public ReadOnlyCollection<string> QueryValueVariableNames {
			get { return query; }
		}

		public Uri BindByName (Uri baseAddress, NameValueCollection parameters)
		{
			CheckBaseAddress (baseAddress);

			int src = 0;
			StringBuilder sb = new StringBuilder (template.Length);
			BindByName (ref src, sb, path, parameters);
			BindByName (ref src, sb, query, parameters);
			sb.Append (template.Substring (src));
			return new Uri (baseAddress.ToString () + sb.ToString ());
		}

		void BindByName (ref int src, StringBuilder sb, ReadOnlyCollection<string> names, NameValueCollection parameters)
		{
			foreach (string name in names) {
				int s = template.IndexOf ('{', src);
				int e = template.IndexOf ('}', s + 1);
				sb.Append (template.Substring (src, s - src));
				string value = parameters [name];
				if (value == null)
					throw new FormatException (String.Format ("The argument name value collection does not contain value for '{0}'", name));
				sb.Append (value);
				src = e + 1;
			}
		}

		public Uri BindByPosition (Uri baseAddress, params string [] values)
		{
			CheckBaseAddress (baseAddress);

			if (values.Length != path.Count + query.Count)
				throw new FormatException (String.Format ("Template '{0}' contains {1} parameters but the argument values to bind are {2}", template, path.Count + query.Count, values.Length));

			int src = 0, index = 0;
			StringBuilder sb = new StringBuilder (template.Length);
			BindByPosition (ref src, sb, path, values, ref index);
			BindByPosition (ref src, sb, query, values, ref index);
			sb.Append (template.Substring (src));
			return new Uri (baseAddress.ToString () + sb.ToString ());
		}

		void BindByPosition (ref int src, StringBuilder sb, ReadOnlyCollection<string> names, string [] values, ref int index)
		{
			foreach (string name in names) {
				int s = template.IndexOf ('{', src);
				int e = template.IndexOf ('}', s + 1);
				sb.Append (template.Substring (src, s - src));
				string value = values [index++];
				if (value == null)
					throw new FormatException (String.Format ("The argument value collection contains null at {0}", index - 1));
				sb.Append (value);
				src = e + 1;
			}
		}

		[MonoTODO]
		public bool IsEquivalentTo (UriTemplate other)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public UriTemplateMatch Match (Uri baseAddress, Uri candidate)
		{
			throw new NotImplementedException ();
		}

		public override string ToString ()
		{
			return template;
		}

		void CheckBaseAddress (Uri baseAddress)
		{
			if (baseAddress == null)
				throw new ArgumentNullException ("baseAddress");
			if (!baseAddress.IsAbsoluteUri)
			throw new ArgumentException ("baseAddress must be an absolute URI.");
			if (baseAddress.Scheme == Uri.UriSchemeHttp ||
			    baseAddress.Scheme == Uri.UriSchemeHttps)
				return;
			throw new ArgumentException ("baseAddress scheme must be either http or https.");
		}

		ReadOnlyCollection<string> ParseTemplate (string template, int index, int end)
		{
			List<string> list = null;
			for (int i = index; i <= end; ) {
				i = template.IndexOf ('{', i);
				if (i < 0 || i > end)
					break;
				int e = template.IndexOf ('}', i + 1);
				if (e < 0 || i > end)
					break;
				if (list == null)
					list = new List<string> ();
				i++;
				string name = template.Substring (i, e - i);
				string uname = name.ToUpper (CultureInfo.InvariantCulture);
				if (list.Contains (uname) || (path != null && path.Contains (uname)))
					throw new InvalidOperationException (String.Format ("The URI template string contains duplicate template item {{'{0}'}}", name));
				list.Add (uname);
				i = e + 1;
			}
			return list != null ? new ReadOnlyCollection<string> (list) : empty_strings;
		}
	}
}
