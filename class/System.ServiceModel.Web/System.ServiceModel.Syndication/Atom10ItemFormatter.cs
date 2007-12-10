//
// Atom10ItemFormatter.cs
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
using System.Xml.Schema;
using System.Xml.Serialization;

namespace System.ServiceModel.Syndication
{
	[XmlRoot ("entry", Namespace = "http://www.w3.org/2005/Atom")]
	public class Atom10ItemFormatter : SyndicationItemFormatter, IXmlSerializable
	{
		bool preserve_att_ext, preserve_elem_ext;
		Type item_type;

		public Atom10ItemFormatter ()
		{
		}

		public Atom10ItemFormatter (SyndicationItem feedToWrite)
			: base (feedToWrite)
		{
		}

		public Atom10ItemFormatter (Type itemTypeToCreate)
		{
			if (itemTypeToCreate == null)
				throw new ArgumentNullException ("itemTypeToCreate");
			item_type = itemTypeToCreate;
		}

		protected Type ItemType {
			get { return item_type; }
		}

		public bool PreserveAttributeExtensions {
			get { return preserve_att_ext; }
			set { preserve_att_ext = value; }
		}

		public bool PreserveElementExtensions {
			get { return preserve_elem_ext; }
			set { preserve_elem_ext = value; }
		}

		public override string Version {
			get { return "Atom10"; }
		}

		[MonoTODO]
		protected override SyndicationItem CreateItemInstance ()
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public override bool CanRead (XmlReader reader)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public override void ReadFrom (XmlReader reader)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public override void WriteTo (XmlWriter writer)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		void IXmlSerializable.ReadXml (XmlReader reader)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		void IXmlSerializable.WriteXml (XmlWriter writer)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		XmlSchema IXmlSerializable.GetSchema ()
		{
			throw new NotImplementedException ();
		}
	}
}
