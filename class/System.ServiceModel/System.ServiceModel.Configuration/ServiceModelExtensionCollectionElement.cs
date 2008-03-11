//
// ServiceModelExtensionCollectionElement.cs
//
// Author:
//	Atsushi Enomoto <atsushi@ximian.com>
//
// Copyright (C) 2006 Novell, Inc.  http://www.novell.com
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
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace System.ServiceModel.Configuration
{
	[MonoTODO]
	public class ServiceModelExtensionCollectionElement<TServiceModelExtensionElement> 
		: ConfigurationElement,
		ICollection<TServiceModelExtensionElement>,
		IEnumerable<TServiceModelExtensionElement>, 
		IEnumerable
		where TServiceModelExtensionElement : ServiceModelExtensionElement
	{
		Dictionary<Type, TServiceModelExtensionElement> _list = new Dictionary<Type, TServiceModelExtensionElement> ();

		public virtual void Add (TServiceModelExtensionElement element)
		{
			throw new NotImplementedException ();
		}
		
		public virtual bool CanAdd (TServiceModelExtensionElement element) {
			throw new NotImplementedException ();
		}

		public void Clear ()
		{
			throw new NotImplementedException ();
		}

		public bool Contains (TServiceModelExtensionElement element)
		{
			throw new NotImplementedException ();
		}

		public bool ContainsKey (string elementName)
		{
			throw new NotImplementedException ();
		}

		public bool ContainsKey (Type elementType)
		{
			throw new NotImplementedException ();
		}

		public void CopyTo (TServiceModelExtensionElement[] elements,
			int start)
		{
			throw new NotImplementedException ();
		}

		public IEnumerator<TServiceModelExtensionElement> GetEnumerator ()
		{
			foreach (PropertyInformation pi in ElementInformation.Properties) {
				TServiceModelExtensionElement val = pi.Value as TServiceModelExtensionElement;
				if (val != null)
					yield return val;
			}
		}

		public bool Remove (TServiceModelExtensionElement element)
		{
			throw new NotImplementedException ();
		}

		IEnumerator IEnumerable.GetEnumerator ()
		{
			return GetEnumerator ();
		}

		bool ICollection<TServiceModelExtensionElement>.IsReadOnly {
			get { throw new NotImplementedException (); }
		}

		public TServiceModelExtensionElement this [int index] {
			get {
				throw new NotImplementedException ();
			}
		}

		public TServiceModelExtensionElement this [Type extensionType] {
			get {
				return _list[extensionType];
			}
		}

		protected override void DeserializeElement (System.Xml.XmlReader reader, bool serializeCollectionKey) {
			base.DeserializeElement (reader, serializeCollectionKey);
		}

		protected override bool OnDeserializeUnrecognizedElement (string elementName, System.Xml.XmlReader reader) {
			TServiceModelExtensionElement ext= DeserializeExtensionElement (elementName, reader);
			if (ext == null)
				return false;
			_list [ext.GetType ()] = ext;
			return true;
		}

		internal virtual TServiceModelExtensionElement DeserializeExtensionElement (string elementName, System.Xml.XmlReader reader) {
			return null;
		}

		[MonoTODO]
		public int Count {
			get { throw new NotImplementedException (); }
		}
	}
}
