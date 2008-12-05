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
// Authors:
//
//	Copyright (C) 2006 Jordi Mas i Hernandez <jordimash@gmail.com>
//

using System;
using System.Collections;
using System.ComponentModel;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel.Design;
using System.Reflection;

namespace System.Workflow.ComponentModel
{
	public sealed class ActivityBind : MarkupExtension, IPropertyValueProvider
	{
		private string name;
		private string path;

		public ActivityBind ()
		{

		}

		public ActivityBind (string name)
		{
			this.name = name;
		}

		public ActivityBind (string name, string path)
		{
			this.name = name;
			this.path = path;
		}

		// Properties
		public string Name {
			get { return name;}
			set { name = value;}
		}
		public string Path {
			get { return path;}
			set { path = value;}
		}

		[MonoTODO]
		public IDictionary UserData {
			get { throw new NotImplementedException (); }
		}

		// Methods
		public object GetRuntimeValue (Activity activity)
		{
			return GetRuntimeValue (activity, null);
		}

		public object GetRuntimeValue (Activity activity, Type targetType)
		{
			if (activity == null) {
				throw new ArgumentNullException ("activity is a null reference");
			}

			Type activity_type = activity.GetType ();

			PropertyInfo info = activity_type.GetProperty (Path, BindingFlags.FlattenHierarchy  |
				BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.Instance);

			return info.GetValue (activity, null);
		}

		[MonoTODO]
		ICollection IPropertyValueProvider.GetPropertyValues (ITypeDescriptorContext context)
		{
			throw new NotImplementedException ();
		}

		public override object ProvideValue (IServiceProvider provider)
		{
			return this;
		}

		public void SetRuntimeValue (Activity activity, object value)
		{
			if (activity == null) {
				throw new ArgumentNullException ("activity is a null reference");
			}

			Type activity_type = activity.GetType ();

			PropertyInfo info = activity_type.GetProperty (Path, BindingFlags.FlattenHierarchy  |
				BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.Instance);

			info.SetValue (activity, value, null);
		}

		public override string ToString ()
		{
			return base.ToString ();
		}
	}
}

