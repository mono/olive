//
// System.Workflow.Runtime.Configuration.WorkflowRuntimeServiceElementCollection
//
// Authors:
//	Joel Reed (joelwreed@gmail.com)
//

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
using System.Configuration;

namespace System.Workflow.Runtime.Configuration {

	[ConfigurationCollection (typeof (WorkflowRuntimeServiceElement), CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
	public sealed class WorkflowRuntimeServiceElementCollection : ConfigurationElementCollection
	{
		public void Add (WorkflowRuntimeServiceElement element)
		{
			BaseAdd (element);
		}

		public void Clear ()
		{
			BaseClear ();
		}

		public bool ContainsKey (object key)
		{
			return (BaseGet (key) != null);
		}

		public void CopyTo (WorkflowRuntimeServiceElement[] array, int index)
		{
			((ICollection)this).CopyTo (array, index);
		}

		protected override ConfigurationElement CreateNewElement ()
		{
			return new WorkflowRuntimeServiceElement ();
		}

		protected override object GetElementKey (ConfigurationElement element)
		{
			return ((WorkflowRuntimeServiceElement)element).Type;
		}

		public int IndexOf (WorkflowRuntimeServiceElement element)
		{
			return BaseIndexOf (element);
		}

		public void Remove (WorkflowRuntimeServiceElement element)
		{
			BaseRemove (element.Type);
		}

		public void RemoveAt (int index)
		{
			BaseRemoveAt (index);
		}

		[MonoTODO ("is this right?")]
		public void RemoveAt (object key)
		{
			BaseRemove (key);
		}

		public WorkflowRuntimeServiceElement this [int index] {
			get { return (WorkflowRuntimeServiceElement)BaseGet (index); }
			set { if (BaseGet (index) != null) BaseRemoveAt (index); BaseAdd (index, value); }
		}

		public WorkflowRuntimeServiceElement this [object key] {
			get { return (WorkflowRuntimeServiceElement)BaseGet (key); }
			set {
				WorkflowRuntimeServiceElement el = (WorkflowRuntimeServiceElement)BaseGet (key);
				if (el == null) {
					BaseAdd (value);
					return;
				}
				int index = IndexOf (el);
				BaseRemoveAt (index);
				BaseAdd (index, value);
			}
		}

	}

}

