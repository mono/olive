//
// PropertyGroupDescription.cs
//
// Author:
//       Antonius Riha <antoniusriha@gmail.com>
//
// Copyright (c) 2012 Antonius Riha
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using System.ComponentModel;
using System.Globalization;

namespace System.Windows.Data
{
	public class PropertyGroupDescription : GroupDescription
	{
		public PropertyGroupDescription ()
		{
		}

		public PropertyGroupDescription (string propertyName)
		{
		}

		public PropertyGroupDescription (string propertyName, IValueConverter converter)
		{
		}

		public PropertyGroupDescription (string propertyName, IValueConverter converter,
		                                 StringComparison stringComparison)
		{
		}

		public IValueConverter Converter { get; set; }

		public string PropertyName { get; set; }

		public StringComparison StringComparison { get; set; }

		public override object GroupNameFromItem (object item, int level, CultureInfo culture)
		{
			throw new NotImplementedException ();
		}

		public override bool NamesMatch (object groupName, object itemName)
		{
			return base.NamesMatch (groupName, itemName);
		}
	}
}
