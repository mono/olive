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
// Copyright (c) 2007 Novell, Inc. (http://www.novell.com)
//
// Authors:
//	Chris Toshok (toshok@ximian.com)
//

using System;

using System.Collections.Generic;

namespace System.Windows {

	public static class EventManager {

		static Dictionary<Type, Dictionary <string, RoutedEvent>> eventsByType = new Dictionary<Type, Dictionary<string, RoutedEvent>>();

		public static RoutedEvent[] GetRoutedEvents ()
		{
			int count = 0;
			foreach (Type t in eventsByType.Keys)
				count += eventsByType[t].Values.Count;

			RoutedEvent[] event_array = new RoutedEvent[count];
			int idx = 0;
			foreach (Type t in eventsByType.Keys) {
				Dictionary<string, RoutedEvent> events = eventsByType[t];
				events.Values.CopyTo (event_array, idx);
				idx += events.Count;
			}

			return event_array;
		}

		public static RoutedEvent[] GetRoutedEventsForOwner (Type ownerType)
		{
			Dictionary<string, RoutedEvent> events = eventsByType[ownerType];
			if (events == null)
				return new RoutedEvent[0];

			RoutedEvent[] event_array = new RoutedEvent[events.Values.Count];
			events.Values.CopyTo (event_array, 0);
			return event_array;
		}

		public static void RegisterClassHandler (Type classType, RoutedEvent routedEvent, Delegate handler)
		{
			throw new NotImplementedException ();
		}

		public static void RegisterClassHandler (Type classType, RoutedEvent routedEvent, Delegate handler, bool handledEventsToo)
		{
			throw new NotImplementedException ();
		}

		public static RoutedEvent RegisterRoutedEvent (string name, RoutingStrategy routingStrategy, Type handlerType, Type ownerType)
		{
			RoutedEvent re = new RoutedEvent (name, handlerType, ownerType, routingStrategy);
			Dictionary<string, RoutedEvent> events;

			if (eventsByType.ContainsKey (ownerType)) {
				events = eventsByType[ownerType];
			}
			else {
				events = eventsByType[ownerType] = new Dictionary<string, RoutedEvent>();
			}

			if (events.ContainsKey (name))
				throw new InvalidOperationException (String.Format ("Type '{0}' already has routed event '{1}' registered.", ownerType, name));

			events[name] = re;

			return re;
		}
	}

}
