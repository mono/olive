//
// DependencyObject.cs
//
// Author:
//   Iain McCoy (iain@mccoy.id.au)
//   Chris Toshok (toshok@ximian.com)
//
// (C) 2005 Iain McCoy
// (C) 2007 Novell, Inc.
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

using System.Collections;
using System.Windows.Threading;

namespace System.Windows {
	public class DependencyObject : DispatcherObject {
		private static Hashtable propertyDeclarations = new Hashtable();
		private Hashtable properties = new Hashtable();
		private DependencyObjectType dependencyObjectType;

		[MonoTODO]
		public bool IsSealed {
			get { throw new NotImplementedException (); }
		}

		public DependencyObjectType DependencyObjectType { 
			get { return dependencyObjectType; }
		}

		public void ClearValue(DependencyProperty dp)
		{
			if (IsSealed)
				throw new InvalidOperationException ("Cannot manipulate property values on a sealed DependencyObject");

			properties[dp] = null;
		}
		
		[MonoTODO]
		public void ClearValue(DependencyPropertyKey key)
		{
			ClearValue (key.DependencyProperty);
		}

		public override bool Equals (object obj)
		{
			throw new NotImplementedException("Equals");
		}

		public override int GetHashCode ()
		{
			throw new NotImplementedException("GetHashCode");
		}

		[MonoTODO]
		public LocalValueEnumerator GetLocalValueEnumerator()
		{
			return new LocalValueEnumerator(properties);
		}
		
		public object GetValue(DependencyProperty dp)
		{
			object val = properties[dp];
			return val == null ? dp.DefaultMetadata.DefaultValue : val;
		}
		
		[MonoTODO]
		public void InvalidateProperty(DependencyProperty dp)
		{
			throw new NotImplementedException("InvalidateProperty(DependencyProperty dp)");
		}
		
		[MonoTODO]
		protected virtual void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
		{
			throw new NotImplementedException();
		}
		
		public object ReadLocalValue(DependencyProperty dp)
		{
			object val = properties[dp];
			return val == null ? DependencyProperty.UnsetValue : val;
		}
		
		public void SetValue(DependencyProperty dp, object value)
		{
			if (IsSealed)
				throw new InvalidOperationException ("Cannot manipulate property values on a sealed DependencyObject");

			if (!dp.IsValidType (value))
				throw new ArgumentException ("value not of the correct type for this DependencyProperty");

			ValidateValueCallback validate = dp.ValidateValueCallback;
			if (validate != null && !validate(value))
				throw new Exception("Value does not validate");
			else
				properties[dp] = value;
		}
		
		[MonoTODO]
		public void SetValue(DependencyPropertyKey key, object value)
		{
			SetValue (key.DependencyProperty, value);
		}
		

		internal static DependencyProperty lookup(Type t, string name)
		{
			return (DependencyProperty)((Hashtable)propertyDeclarations[t])[name];
		}

		internal static void register(Type t, DependencyProperty dp)
		{
			if (propertyDeclarations[t] == null)
				propertyDeclarations[t] = new Hashtable();
			Hashtable typeDeclarations = (Hashtable)propertyDeclarations[t];
			if (!typeDeclarations.ContainsKey(dp.Name))
				typeDeclarations[dp.Name] = dp;
			else
				throw new ArgumentException("A property named " + dp.Name + " already exists on " + t.Name);
		}
	}
}
