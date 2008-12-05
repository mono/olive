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
using System.Collections.Generic;

namespace System.Workflow.Runtime
{
	public sealed class CorrelationToken : DependencyObject
	{
		private bool initialized = false;
		private string name;
		private string owner_activity;
		private ICollection <CorrelationProperty> properties;

		// Methods
		static CorrelationToken ()
		{

		}

		public CorrelationToken ()
		{
			properties = new List <CorrelationProperty> ();
		}

		public CorrelationToken (string name) : this ()
		{
			this.name = name;
		}

		// Properties
		public bool Initialized {
			get { return initialized; }
		}

		public string Name {
			get { return name; }
			set { name = value; }
		}

		public string OwnerActivityName {
			get { return owner_activity; }
			set { owner_activity = value; }
		}

		public ICollection <CorrelationProperty> Properties {
			get { return properties; }
		}

		public void Initialize (Activity activity, ICollection <CorrelationProperty> propertyValues)
		{
			if (initialized == true)
				throw new InvalidOperationException ("CorrelationToken was already initialized");

			foreach (CorrelationProperty property in propertyValues)
				properties.Add (property);

			initialized = true;
		}

		public void SubscribeForCorrelationTokenInitializedEvent (Activity activity, IActivityEventListener<CorrelationTokenEventArgs> dataChangeListener)
		{

		}

		public void UnsubscribeFromCorrelationTokenInitializedEvent (Activity activity, IActivityEventListener<CorrelationTokenEventArgs> dataChangeListener)
		{

		}
	}
}

