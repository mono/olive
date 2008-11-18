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

		[Test]
		public void TestRoutedEvent ()
		{
			Assert.AreEqual (typeof (DragDrop), DragDrop.PreviewQueryContinueDragEvent.OwnerType);
			Assert.AreEqual ("PreviewQueryContinueDrag", DragDrop.PreviewQueryContinueDragEvent.Name);
			Assert.AreEqual ("DragDrop.PreviewQueryContinueDrag", DragDrop.PreviewQueryContinueDragEvent.ToString());
			Assert.AreEqual (typeof (QueryContinueDragEventHandler), DragDrop.PreviewQueryContinueDragEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, DragDrop.PreviewQueryContinueDragEvent.RoutingStrategy);

			Assert.AreEqual (typeof (DragDrop), DragDrop.QueryContinueDragEvent.OwnerType);
			Assert.AreEqual ("QueryContinueDrag", DragDrop.QueryContinueDragEvent.Name);
			Assert.AreEqual ("DragDrop.QueryContinueDrag", DragDrop.QueryContinueDragEvent.ToString());
			Assert.AreEqual (typeof (QueryContinueDragEventHandler), DragDrop.QueryContinueDragEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, DragDrop.QueryContinueDragEvent.RoutingStrategy);

			Assert.AreEqual (typeof (DragDrop), DragDrop.PreviewGiveFeedbackEvent.OwnerType);
			Assert.AreEqual ("PreviewGiveFeedback", DragDrop.PreviewGiveFeedbackEvent.Name);
			Assert.AreEqual ("DragDrop.PreviewGiveFeedback", DragDrop.PreviewGiveFeedbackEvent.ToString());
			Assert.AreEqual (typeof (GiveFeedbackEventHandler), DragDrop.PreviewGiveFeedbackEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, DragDrop.PreviewGiveFeedbackEvent.RoutingStrategy);

			Assert.AreEqual (typeof (DragDrop), DragDrop.GiveFeedbackEvent.OwnerType);
			Assert.AreEqual ("GiveFeedback", DragDrop.GiveFeedbackEvent.Name);
			Assert.AreEqual ("DragDrop.GiveFeedback", DragDrop.GiveFeedbackEvent.ToString());
			Assert.AreEqual (typeof (GiveFeedbackEventHandler), DragDrop.GiveFeedbackEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, DragDrop.GiveFeedbackEvent.RoutingStrategy);

			Assert.AreEqual (typeof (DragDrop), DragDrop.PreviewDragEnterEvent.OwnerType);
			Assert.AreEqual ("PreviewDragEnter", DragDrop.PreviewDragEnterEvent.Name);
			Assert.AreEqual ("DragDrop.PreviewDragEnter", DragDrop.PreviewDragEnterEvent.ToString());
			Assert.AreEqual (typeof (DragEventHandler), DragDrop.PreviewDragEnterEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, DragDrop.PreviewDragEnterEvent.RoutingStrategy);

			Assert.AreEqual (typeof (DragDrop), DragDrop.DragEnterEvent.OwnerType);
			Assert.AreEqual ("DragEnter", DragDrop.DragEnterEvent.Name);
			Assert.AreEqual ("DragDrop.DragEnter", DragDrop.DragEnterEvent.ToString());
			Assert.AreEqual (typeof (DragEventHandler), DragDrop.DragEnterEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, DragDrop.DragEnterEvent.RoutingStrategy);

			Assert.AreEqual (typeof (DragDrop), DragDrop.PreviewDragOverEvent.OwnerType);
			Assert.AreEqual ("PreviewDragOver", DragDrop.PreviewDragOverEvent.Name);
			Assert.AreEqual ("DragDrop.PreviewDragOver", DragDrop.PreviewDragOverEvent.ToString());
			Assert.AreEqual (typeof (DragEventHandler), DragDrop.PreviewDragOverEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, DragDrop.PreviewDragOverEvent.RoutingStrategy);

			Assert.AreEqual (typeof (DragDrop), DragDrop.DragOverEvent.OwnerType);
			Assert.AreEqual ("DragOver", DragDrop.DragOverEvent.Name);
			Assert.AreEqual ("DragDrop.DragOver", DragDrop.DragOverEvent.ToString());
			Assert.AreEqual (typeof (DragEventHandler), DragDrop.DragOverEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, DragDrop.DragOverEvent.RoutingStrategy);

			Assert.AreEqual (typeof (DragDrop), DragDrop.PreviewDragLeaveEvent.OwnerType);
			Assert.AreEqual ("PreviewDragLeave", DragDrop.PreviewDragLeaveEvent.Name);
			Assert.AreEqual ("DragDrop.PreviewDragLeave", DragDrop.PreviewDragLeaveEvent.ToString());
			Assert.AreEqual (typeof (DragEventHandler), DragDrop.PreviewDragLeaveEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, DragDrop.PreviewDragLeaveEvent.RoutingStrategy);

			Assert.AreEqual (typeof (DragDrop), DragDrop.DragLeaveEvent.OwnerType);
			Assert.AreEqual ("DragLeave", DragDrop.DragLeaveEvent.Name);
			Assert.AreEqual ("DragDrop.DragLeave", DragDrop.DragLeaveEvent.ToString());
			Assert.AreEqual (typeof (DragEventHandler), DragDrop.DragLeaveEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, DragDrop.DragLeaveEvent.RoutingStrategy);

			Assert.AreEqual (typeof (DragDrop), DragDrop.PreviewDropEvent.OwnerType);
			Assert.AreEqual ("PreviewDrop", DragDrop.PreviewDropEvent.Name);
			Assert.AreEqual ("DragDrop.PreviewDrop", DragDrop.PreviewDropEvent.ToString());
			Assert.AreEqual (typeof (DragEventHandler), DragDrop.PreviewDropEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, DragDrop.PreviewDropEvent.RoutingStrategy);

			Assert.AreEqual (typeof (DragDrop), DragDrop.DropEvent.OwnerType);
			Assert.AreEqual ("Drop", DragDrop.DropEvent.Name);
			Assert.AreEqual ("DragDrop.Drop", DragDrop.DropEvent.ToString());
			Assert.AreEqual (typeof (DragEventHandler), DragDrop.DropEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, DragDrop.DropEvent.RoutingStrategy);
		}
	}
}
