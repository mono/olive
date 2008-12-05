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

using System.Collections.ObjectModel;

namespace System.Workflow.ComponentModel
{
	[Serializable]
	public sealed class WorkflowParameterBindingCollection : KeyedCollection <string, WorkflowParameterBinding>
	{
		private Activity owner;

		public WorkflowParameterBindingCollection (Activity ownerActivity)
		{
			owner = ownerActivity;
		}

		// Methods
		protected override void ClearItems ()
		{
			base.ClearItems ();
		}

		public WorkflowParameterBinding GetItem (string key)
		{
			return (WorkflowParameterBinding) base[key];
		}

		protected override string GetKeyForItem (WorkflowParameterBinding item)
		{
			return item.ParameterName;
		}

		protected override void InsertItem (int index, WorkflowParameterBinding item)
		{
			if (Contains (item.ParameterName)) {
				Remove (item.ParameterName);
			}

			base.InsertItem (index, item);
		}

		protected override void RemoveItem (int index)
		{
			base.RemoveItem (index);
		}

		protected override void SetItem (int index, WorkflowParameterBinding item)
		{
			base.SetItem (index, item);
		}
	}
}

