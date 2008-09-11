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
// Copyright (c) 2008 Novell, Inc. (http://www.novell.com)
//

using System;
using System.ComponentModel;
using System.Xml;

namespace System.Windows.Markup {

	public sealed class XmlAttributeProperties {

		internal XmlAttributeProperties ()
		{
		}

		[Browsable(false)]
		public static readonly DependencyProperty XmlNamespaceMapsProperty;

		[Browsable(false)]
		public static readonly DependencyProperty XmlnsDefinitionProperty;

		[Browsable(false)]
		public static readonly DependencyProperty XmlnsDictionaryProperty;

		[Localizability(LocalizationCategory.NeverLocalize)]
		[Browsable(false)]
		public static readonly DependencyProperty XmlSpaceProperty;

		[AttachedPropertyBrowsableForType (typeof(DependencyObject))]
		[DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)]
		public static string GetXmlNamespaceMaps (DependencyObject dependencyObject)
		{
			if (dependencyObject == null)
				throw new ArgumentNullException ();

			return (string)dependencyObject.GetValue (XmlNamespaceMapsProperty);
		}

		[DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)]
		[DesignerSerializationOptions (DesignerSerializationOptions.SerializeAsAttribute)]
		[AttachedPropertyBrowsableForType (typeof(DependencyObject))]
		public static string GetXmlnsDefinition (DependencyObject dependencyObject)
		{
			if (dependencyObject == null)
				throw new ArgumentNullException ();

			return (string)dependencyObject.GetValue (XmlnsDefinitionProperty);
		}

		[DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)]
		[AttachedPropertyBrowsableForType (typeof(DependencyObject))]
		public static XmlnsDictionary GetXmlnsDictionary (DependencyObject dependencyObject)
		{
			if (dependencyObject == null)
				throw new ArgumentNullException ();

			return (XmlnsDictionary)dependencyObject.GetValue (XmlnsDictionaryProperty);
		}

		[AttachedPropertyBrowsableForType (typeof(DependencyObject))]
		[DesignerSerializationOptions (DesignerSerializationOptions.SerializeAsAttribute)]
		public static string GetXmlSpace (DependencyObject dependencyObject)
		{
			if (dependencyObject == null)
				throw new ArgumentNullException ();

			return (string)dependencyObject.GetValue (XmlSpaceProperty);
		}

		public static void SetXmlNamespaceMaps(DependencyObject dependencyObject, string value)
		{
			if (dependencyObject == null)
				throw new ArgumentNullException ();

			dependencyObject.SetValue (XmlNamespaceMapsProperty, value);
		}

		public static void SetXmlnsDefinition(DependencyObject dependencyObject, string value)
		{
			if (dependencyObject == null)
				throw new ArgumentNullException ();

			dependencyObject.SetValue (XmlnsDefinitionProperty, value);
		}

		public static void SetXmlnsDictionary(DependencyObject dependencyObject, XmlnsDictionary value)
		{
			if (dependencyObject == null)
				throw new ArgumentNullException ();

			dependencyObject.SetValue (XmlnsDictionaryProperty, value);
		}

		public static void SetXmlSpace(DependencyObject dependencyObject, string value)
		{
			if (dependencyObject == null)
				throw new ArgumentNullException ();

			dependencyObject.SetValue (XmlSpaceProperty, value);
		}
	}
}

