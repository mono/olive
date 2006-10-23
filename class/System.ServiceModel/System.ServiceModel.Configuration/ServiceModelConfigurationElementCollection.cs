//
// ServiceModelConfigurationElementCollection.cs
//
// Author:
//	Atsushi Enomoto <atsushi@ximian.com>
//
// Copyright (C) 2005 Novell, Inc.  http://www.novell.com
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
using System.Configuration;

namespace System.ServiceModel.Configuration
{
	public abstract class ServiceModelConfigurationElementCollection<ConfigurationElementType> : ConfigurationElementCollection
		where ConfigurationElementType : ConfigurationElement, new()
	{
		internal ServiceModelConfigurationElementCollection ()
		{
		}

		public ConfigurationElementType this [int index] {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		public virtual ConfigurationElementType this [object key] {
			get {
				if (key is ConfigurationProperty)
					return (ConfigurationElementType) base [(ConfigurationProperty) key];
				if (key is string)
					return (ConfigurationElementType) base [(string) key];
				else
					throw new NotImplementedException ();
			}
			set {
				if (key is ConfigurationProperty)
					base [(ConfigurationProperty) key] = value;
				if (key is string)
					base [(string) key] = value;
				else
					throw new NotImplementedException ();
			}
		}

		public override ConfigurationElementCollectionType CollectionType {
			get { return ConfigurationElementCollectionType.BasicMap; }
		}

		protected override string ElementName {
			get {
				Type attrType = typeof (ConfigurationCollectionAttribute);
				return ((ConfigurationCollectionAttribute) Attribute.GetCustomAttribute (GetType (), attrType, true)).AddItemName; 
			}
		}

		public void Add (ConfigurationElementType element)
		{
			BaseAdd (element);
		}

		[MonoTODO]
		protected override void BaseAdd (ConfigurationElement element)
		{
			base.BaseAdd (element);
		}

		[MonoTODO]
		public void Clear ()
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public virtual bool ContainsKey (object o)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		protected override ConfigurationElement CreateNewElement ()
		{
			return (ConfigurationElement) Activator.CreateInstance (typeof (ConfigurationElementType), new object [0]);
		}

		[MonoTODO]
		public void CopyTo (ConfigurationElementType [] array, int index)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public int IndexOf (ConfigurationElementType item)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public void Remove (ConfigurationElementType item)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public void RemoveAt (int index)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO]
		public void RemoveAt (object index)
		{
			throw new NotImplementedException ();
		}
	}
}
