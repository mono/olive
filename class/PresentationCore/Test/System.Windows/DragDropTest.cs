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
using System.Windows;
using NUnit.Framework;

namespace MonoTests.System.Windows {

	[TestFixture]
	public class DragDropTest {

		void _checkEvent (RoutedEvent ev,
				  string expected_name, Type expected_handler_type,
				  Type expected_owner_type, RoutingStrategy expected_routing_strategy)
		{
			Assert.AreEqual (expected_handler_type, ev.HandlerType);
			Assert.AreEqual (expected_name, ev.Name);
			Assert.AreEqual (expected_owner_type, ev.OwnerType);
			Assert.AreEqual (expected_routing_strategy, ev.RoutingStrategy);
		}

		[Test]
		public void TestRoutedEventDefaults ()
		{
			_checkEvent (DragDrop.DragEnterEvent, "DragEnter",
				     typeof (DragEventHandler), typeof (DragDrop), RoutingStrategy.Bubble);
			_checkEvent (DragDrop.DragLeaveEvent, "DragLeave",
				     typeof (DragEventHandler), typeof (DragDrop), RoutingStrategy.Bubble);
			_checkEvent (DragDrop.DragOverEvent, "DragOver",
				     typeof (DragEventHandler), typeof (DragDrop), RoutingStrategy.Bubble);
			_checkEvent (DragDrop.DropEvent, "Drop",
				     typeof (DragEventHandler), typeof (DragDrop), RoutingStrategy.Bubble);
			_checkEvent (DragDrop.GiveFeedbackEvent, "GiveFeedback",
				     typeof (GiveFeedbackEventHandler), typeof (DragDrop), RoutingStrategy.Bubble);
			_checkEvent (DragDrop.QueryContinueDragEvent, "QueryContinueDrag",
				     typeof (QueryContinueDragEventHandler), typeof (DragDrop), RoutingStrategy.Bubble);

			_checkEvent (DragDrop.PreviewDragEnterEvent, "PreviewDragEnter",
				     typeof (DragEventHandler), typeof (DragDrop), RoutingStrategy.Tunnel);
			_checkEvent (DragDrop.PreviewDragLeaveEvent, "PreviewDragLeave",
				     typeof (DragEventHandler), typeof (DragDrop), RoutingStrategy.Tunnel);
			_checkEvent (DragDrop.PreviewDragOverEvent, "PreviewDragOver",
				     typeof (DragEventHandler), typeof (DragDrop), RoutingStrategy.Tunnel);
			_checkEvent (DragDrop.PreviewDropEvent, "PreviewDrop",
				     typeof (DragEventHandler), typeof (DragDrop), RoutingStrategy.Tunnel);
			_checkEvent (DragDrop.PreviewGiveFeedbackEvent, "PreviewGiveFeedback",
				     typeof (GiveFeedbackEventHandler), typeof (DragDrop), RoutingStrategy.Tunnel);
			_checkEvent (DragDrop.PreviewQueryContinueDragEvent, "PreviewQueryContinueDrag",
				     typeof (QueryContinueDragEventHandler), typeof (DragDrop), RoutingStrategy.Tunnel);
		}
	}
}
