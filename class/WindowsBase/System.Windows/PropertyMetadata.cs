//
// PropertyMetadata.cs
//
// Author:
//   Iain McCoy (iain@mccoy.id.au)
//
// (C) 2005 Iain McCoy
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

namespace System.Windows {
	public class PropertyMetadata {
		private object defaultValue;
		private bool isSealed;
		private PropertyChangedCallback propertyChangedCallback;
		private CoerceValueCallback coerceValueCallback;
		private bool readOnly;
		
		public object DefaultValue {
			get { return defaultValue; }
			set { defaultValue = value; }
		}

		protected bool IsSealed {
			get { return isSealed; }
		}

		public PropertyChangedCallback PropertyChangedCallback {
			get { return propertyChangedCallback; }
			set { propertyChangedCallback = value; }
		}

		public CoerceValueCallback CoerceValueCallback {
			get { return coerceValueCallback; }
			set { coerceValueCallback = value; }
		}

		public bool ReadOnly {
			get { return readOnly; }
		}

		public PropertyMetadata()
		{
		}

		public PropertyMetadata(object defaultValue)
		{
			this.defaultValue = defaultValue;
		}

		public PropertyMetadata(PropertyChangedCallback propertyChangedCallback)
		{
			this.propertyChangedCallback = propertyChangedCallback;
		}

		public PropertyMetadata(object defaultValue, PropertyChangedCallback propertyChangedCallback)
		{
			this.defaultValue = defaultValue;
			this.propertyChangedCallback = propertyChangedCallback;
		}

		public PropertyMetadata (object defaultValue, PropertyChangedCallback propertyChangedCallback, CoerceValueCallback coerceValueCallback)
		{
			this.defaultValue = defaultValue;
			this.coerceValueCallback = coerceValueCallback;
		}
		
		[MonoTODO()]		
		protected virtual void Merge (PropertyMetadata baseMetadata, DependencyProperty dp)
		{
			throw new NotImplementedException("Merge(PropertyMetadata baseMetadata, DependencyProperty dp)");
		}
		
		[MonoTODO()]		
		protected virtual void OnApply (DependencyProperty dp, Type targetType)
		{
			throw new NotImplementedException("OnApply(DependencyProperty dp, Type targetType)");
		}
	}
}
