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
// Author:
//	Chris Toshok (toshok@ximian.com)
//

using System.ComponentModel;
using System.Windows.Markup;

namespace System.Windows {

	[ContentProperty ("Actions")]
	public class EventTrigger : TriggerBase, IAddChild {

		public EventTrigger ()
		{
		}

		public EventTrigger (RoutedEvent routedEvent)
		{
			this.routedEvent = routedEvent;
		}

		[EditorBrowsable (EditorBrowsableState.Advanced)]
		public bool ShouldSerializeActions ()
		{
			throw new NotImplementedException ();
		}

		protected virtual void AddChild (object child)
		{
			throw new NotImplementedException ();
		}

		protected virtual void AddText (string text)
		{
			throw new NotImplementedException ();
		}

		void IAddChild.AddChild (object child)
		{
			AddChild (child);
		}

		void IAddChild.AddText (string text)
		{
			AddText (text);
		}

#if notyet
		public TriggerActionCollection Actions {
			get { throw new NotImplementedException (); }
		}
#endif

		public RoutedEvent RoutedEvent {
			get { return routedEvent; }
			set { routedEvent = value; }
		}

		public string SourceName {
			get { return sourceName; }
			set { sourceName = value; }
		}

		RoutedEvent routedEvent;
		string sourceName;
	}
}