//
// SyndicationItemFormatter.cs
//
// Author:
//	Atsushi Enomoto  <atsushi@ximian.com>
//
// Copyright (C) 2007 Novell, Inc (http://www.novell.com)
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
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace System.ServiceModel.Syndication
{
	[DataContract]
	public abstract class SyndicationItemFormatter
	{
		#region static members

		[MonoTODO]
		protected internal static SyndicationCategory CreateCategory (SyndicationItem item)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected internal static SyndicationLink CreateLink (SyndicationItem item)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected internal static SyndicationPerson CreatePerson (SyndicationItem item)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected internal static void LoadElementExtensions (XmlReader reader, SyndicationCategory category, int maxExtensionSize)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected internal static void LoadElementExtensions (XmlReader reader, SyndicationItem item, int maxExtensionSize)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected internal static void LoadElementExtensions (XmlReader reader, SyndicationLink link, int maxExtensionSize)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected internal static void LoadElementExtensions (XmlReader reader, SyndicationPerson person, int maxExtensionSize)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected internal static bool TryParseAttribute (string name, string ns, string value, SyndicationCategory category, string version)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected internal static bool TryParseAttribute (string name, string ns, string value, SyndicationItem item, string version)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected internal static bool TryParseAttribute (string name, string ns, string value, SyndicationLink link, string version)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected internal static bool TryParseAttribute (string name, string ns, string value, SyndicationPerson person, string version)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected internal static bool TryParseContent (XmlReader reader, SyndicationItem item, string contentType, string version, out SyndicationContent content)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected internal static bool TryParseElement (XmlReader reader, SyndicationCategory category, string version)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected internal static bool TryParseElement (XmlReader reader, SyndicationItem item, string version)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected internal static bool TryParseElement (XmlReader reader, SyndicationLink link, string version)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected internal static bool TryParseElement (XmlReader reader, SyndicationPerson person, string version)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected internal static void WriteAttributeExtensions (XmlWriter writer, SyndicationCategory category, string version)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected internal static void WriteAttributeExtensions (XmlWriter writer, SyndicationItem item, string version)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected internal static void WriteAttributeExtensions (XmlWriter writer, SyndicationLink link, string version)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected internal static void WriteAttributeExtensions (XmlWriter writer, SyndicationPerson person, string version)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected internal void WriteElementExtensions (XmlWriter writer, SyndicationCategory category, string version)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected internal static void WriteElementExtensions (XmlWriter writer, SyndicationItem item, string version)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected internal void WriteElementExtensions (XmlWriter writer, SyndicationLink link, string version)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected internal void WriteElementExtensions (XmlWriter writer, SyndicationPerson person, string version)
		{
			throw new NotImplementedException ();
		}

		#endregion

		#region instance members

		[MonoTODO]
		protected SyndicationItemFormatter ()
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected SyndicationItemFormatter (SyndicationItem itemToWrite)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected internal virtual void SetItem (SyndicationItem item)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public SyndicationItem Item { 
			get { throw new NotImplementedException (); }
		}

		[MonoTODO]
		public abstract string Version { get; }

		[MonoTODO]
		protected abstract SyndicationItem CreateItemInstance ();

		public abstract bool CanRead (XmlReader reader);

		public abstract void ReadFrom (XmlReader reader);

		[MonoTODO]
		public abstract void WriteTo (XmlWriter writer);

		[MonoTODO]
		public override string ToString ()
		{
			return base.ToString ();
		}

		#endregion
	}
}
