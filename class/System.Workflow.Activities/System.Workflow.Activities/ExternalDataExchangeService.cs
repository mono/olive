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

#if RUNTIME_DEP

using System;
using System.Workflow.Runtime.Hosting;

namespace System.Workflow.Activities
{
	public class ExternalDataExchangeService : WorkflowRuntimeService
	{
		public ExternalDataExchangeService ()
		{

		}

		// Methods
		public void AddService (object service)
		{
			Object[] objs = null;
			Type type;
			Type[] interfaces;

			if (service == null)
				throw new ArgumentNullException ("service is a null reference ");

			interfaces = service.GetType().GetInterfaces();

			for (int i = 0; i < interfaces.Length; i++) {
				objs = interfaces[i].GetCustomAttributes (typeof (ExternalDataExchangeAttribute), true);

				if (objs.Length > 0)
					break;
			}

			if (objs == null || objs.Length == 0)
				throw new InvalidOperationException ("Service does not implement an interface with the ExternalDataExchange attribute.");

			Runtime.AddService (service);
		}

		public object GetService (Type serviceType)
		{
			return Runtime.GetService (serviceType);
		}

		public void RemoveService (object service)
		{
			if (service == null)
				throw new ArgumentNullException ("service is a null reference ");
			
			Runtime.RemoveService (service);
		}

		protected override void Start ()
		{
			base.Start ();
		}
	}

}

#endif