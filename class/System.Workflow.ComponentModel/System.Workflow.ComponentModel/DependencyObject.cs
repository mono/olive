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

using System.ComponentModel;
using System.Collections.Generic;
using System.Collections;

namespace System.Workflow.ComponentModel
{
	[Serializable]
	public abstract class DependencyObject : IComponent, IDisposable
	{
		private IDictionary <DependencyProperty, object> values;
		private IDictionary <DependencyProperty, ActivityBind> bindings;

		// Constructors
		protected DependencyObject ()
		{
			values = new Dictionary <DependencyProperty, object> ();
			bindings = new Dictionary <DependencyProperty, ActivityBind> ();
		}

		// Properties
		[MonoTODO]
		public ISite Site {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		[MonoTODO]
		protected DependencyObject ParentDependencyObject {
			get {
				throw new NotImplementedException ();
			}
		}

		// Methods
		public void AddHandler (DependencyProperty dependencyEvent, object value)
		{
			ArrayList handlers = null;
			object obj;

			if (dependencyEvent == null) {
				throw new ArgumentNullException ("DependencyProperty parameter cannot be null");
			}

			if (value == null) {
				throw new ArgumentNullException ("Value parameter cannot be null");
			}

			if (dependencyEvent.IsEvent == false) {
				throw new ArgumentException ("DependencyProperty is not an event");
			}

			if (values.TryGetValue (dependencyEvent, out obj) == true) {
				handlers = (ArrayList) obj;
			} else {
				handlers = new ArrayList ();
				values.Add (dependencyEvent, handlers);

			}

			handlers.Add (value);
		}

		public void Dispose ()
		{

		}

		public ActivityBind GetBinding (DependencyProperty dependencyProperty)
		{
			ActivityBind binding;
			bindings.TryGetValue (dependencyProperty, out binding);
			return binding;
		}


		protected virtual object GetBoundValue (ActivityBind bind, Type targetType)
		{
			Activity activity = GetActivityByClassName ((Activity)this, bind.Name);
			return bind.GetRuntimeValue (activity, targetType);
		}

		protected T[] GetInvocationList <T> (DependencyProperty dependencyEvent)
		{
			object obj;
			T [] rslt;

			if (values.TryGetValue (dependencyEvent, out obj) == true) {
				ArrayList handlers = (ArrayList) obj;
				rslt = new T [handlers.Count];

				for (int i = 0; i < handlers.Count; i++) {
					rslt[i] = (T) handlers [i];
				}
			} else {
				rslt = new T [0];
			}

			return rslt;
		}

		public object GetValue (DependencyProperty dependencyProperty)
		{
			return GetValueBase (dependencyProperty);
		}

		public object GetValueBase (DependencyProperty dependencyProperty)
		{
			object obj;
			ActivityBind bind;

			if (dependencyProperty == null) {
				throw new ArgumentNullException ("DependencyProperty cannot be null");
			}

			bind = GetBinding (dependencyProperty);

			if (bind != null) {
				 return GetBoundValue (bind, dependencyProperty.PropertyType);
			}

			values.TryGetValue (dependencyProperty, out obj);

			if (obj == null) {
				return dependencyProperty.DefaultMetadata.DefaultValue;
			}

			return obj;
		}

		protected virtual void InitializeProperties ()
		{

		}

		public bool IsBindingSet (DependencyProperty dependencyProperty)
		{
			if (dependencyProperty == null) {
				throw new ArgumentNullException ("The dependencyProperty parameter cannot be null");
			}

			return bindings.ContainsKey (dependencyProperty);
		}

		[MonoTODO]
		public bool MetaEquals (DependencyObject dependencyObject)
		{
			throw new NotImplementedException ();
		}

		public void RemoveHandler (DependencyProperty dependencyEvent, object value)
		{
			ArrayList handlers;

			handlers = (ArrayList) values [dependencyEvent];

			if (handlers == null) {
				return;
			}

			handlers.Remove (value);
		}

		public bool RemoveProperty (DependencyProperty dependencyProperty)
		{
			throw new NotImplementedException ();
		}

		public void SetBinding (DependencyProperty dependencyProperty, ActivityBind bind)
		{
			if (dependencyProperty == null) {
				throw new ArgumentNullException ("The dependencyProperty parameter cannot be null");
			}

			if (bind == null) {
				throw new ArgumentNullException ("The binding parameter cannot be null");
			}

			if (bindings.ContainsKey (dependencyProperty) == true) {
				bindings[dependencyProperty] = bind;
			}
			else {
				bindings.Add (dependencyProperty, bind);
			}
		}

		public void SetValue (DependencyProperty dependencyProperty, object value)
		{
			SetValueBase (dependencyProperty, value);
		}

		public void SetValueBase (DependencyProperty dependencyProperty, object value)
		{
			if (values.ContainsKey (dependencyProperty) == true) {
				values[dependencyProperty] = value;

			}
			else {
				values.Add (dependencyProperty, value);
			}
		}

		// Events
		public event EventHandler Disposed
        	{
                	add { }
                	remove { }
        	}

		private Activity GetActivityByClassName (Activity start_activity, string name)
		{
			List <Activity> list = new List <Activity> ();
			Activity current = start_activity.GetRootActivity ();

			while (current != null) {

				// TODO: Path + Name
				if (name.Equals (current.GetType().Name)) {
					return current;
				}

				if (Activity.IsBasedOnType (current, typeof (CompositeActivity))) {
					CompositeActivity  composite = (CompositeActivity) current;
					foreach (Activity activity in composite.Activities) {
						list.Add (activity);
					}
				}

				if (list.Count == 0) {
					break;
				}

				current = list [0];
				list.Remove (current);
			}

			return null;
		}
	}
}

