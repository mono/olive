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
//	Chris Toshok (toshok@novell.com)
//

using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Security;

namespace System.Windows {

	public static class DragDrop
	{
		static DragDrop ()
		{
			DragEnterEvent = EventManager.RegisterRoutedEvent ("DragEnter", RoutingStrategy.Bubble,
									   typeof (DragEventHandler), typeof (DragDrop));
			DragLeaveEvent = EventManager.RegisterRoutedEvent ("DragLeave", RoutingStrategy.Bubble,
									   typeof (DragEventHandler), typeof (DragDrop));
			DragOverEvent = EventManager.RegisterRoutedEvent ("DragOver", RoutingStrategy.Bubble,
									  typeof (DragEventHandler), typeof (DragDrop));
			DropEvent = EventManager.RegisterRoutedEvent ("Drop", RoutingStrategy.Bubble,
								      typeof (DragEventHandler), typeof (DragDrop));
			GiveFeedbackEvent = EventManager.RegisterRoutedEvent ("GiveFeedback", RoutingStrategy.Bubble,
									      typeof (GiveFeedbackEventHandler), typeof (DragDrop));
			QueryContinueDragEvent = EventManager.RegisterRoutedEvent ("QueryContinueDrag", RoutingStrategy.Bubble,
										   typeof (QueryContinueDragEventHandler),
										   typeof (DragDrop));

			PreviewDragEnterEvent = EventManager.RegisterRoutedEvent ("PreviewDragEnter", RoutingStrategy.Tunnel,
									   typeof (DragEventHandler), typeof (DragDrop));
			PreviewDragLeaveEvent = EventManager.RegisterRoutedEvent ("PreviewDragLeave", RoutingStrategy.Tunnel,
									   typeof (DragEventHandler), typeof (DragDrop));
			PreviewDragOverEvent = EventManager.RegisterRoutedEvent ("PreviewDragOver", RoutingStrategy.Tunnel,
									  typeof (DragEventHandler), typeof (DragDrop));
			PreviewDropEvent = EventManager.RegisterRoutedEvent ("PreviewDrop", RoutingStrategy.Tunnel,
								      typeof (DragEventHandler), typeof (DragDrop));
			PreviewGiveFeedbackEvent = EventManager.RegisterRoutedEvent ("PreviewGiveFeedback", RoutingStrategy.Tunnel,
									      typeof (GiveFeedbackEventHandler), typeof (DragDrop));
			PreviewQueryContinueDragEvent = EventManager.RegisterRoutedEvent ("PreviewQueryContinueDrag",
											  RoutingStrategy.Tunnel,
											  typeof (QueryContinueDragEventHandler),
											  typeof (DragDrop));
		}

		public static readonly RoutedEvent DragEnterEvent;
		public static readonly RoutedEvent DragLeaveEvent;
		public static readonly RoutedEvent DragOverEvent;
		public static readonly RoutedEvent DropEvent;
		public static readonly RoutedEvent GiveFeedbackEvent;
		public static readonly RoutedEvent PreviewDragEnterEvent;
		public static readonly RoutedEvent PreviewDragLeaveEvent;
		public static readonly RoutedEvent PreviewDragOverEvent;
		public static readonly RoutedEvent PreviewDropEvent;
		public static readonly RoutedEvent PreviewGiveFeedbackEvent;
		public static readonly RoutedEvent PreviewQueryContinueDragEvent;
		public static readonly RoutedEvent QueryContinueDragEvent;

		public static void AddDragEnterHandler (DependencyObject element, DragEventHandler handler)
		{
			UIElement.AddHandler (element, DragEnterEvent, handler);
		}

		public static void AddDragLeaveHandler (DependencyObject element, DragEventHandler handler)
		{
			UIElement.AddHandler (element, DragLeaveEvent, handler);
		}

		public static void AddDragOverHandler (DependencyObject element, DragEventHandler handler)
		{
			UIElement.AddHandler (element, DragOverEvent, handler);
		}

		public static void AddDropHandler (DependencyObject element, DragEventHandler handler)
		{
			UIElement.AddHandler (element, DropEvent, handler);
		}

		public static void AddGiveFeedbackHandler (DependencyObject element, GiveFeedbackEventHandler handler)
		{
			UIElement.AddHandler (element, GiveFeedbackEvent, handler);
		}

		public static void AddPreviewDragEnterHandler (DependencyObject element, DragEventHandler handler)
		{
			UIElement.AddHandler (element, PreviewDragEnterEvent, handler);
		}

		public static void AddPreviewDragLeaveHandler (DependencyObject element, DragEventHandler handler)
		{
			UIElement.AddHandler (element, PreviewDragLeaveEvent, handler);
		}

		public static void AddPreviewDragOverHandler (DependencyObject element, DragEventHandler handler)
		{
			UIElement.AddHandler (element, PreviewDragOverEvent, handler);
		}

		public static void AddPreviewDropHandler (DependencyObject element, DragEventHandler handler)
		{
			UIElement.AddHandler (element, PreviewDropEvent, handler);
		}

		public static void AddPreviewGiveFeedbackHandler (DependencyObject element, GiveFeedbackEventHandler handler)
		{
			UIElement.AddHandler (element, PreviewGiveFeedbackEvent, handler);
		}

		public static void AddPreviewQueryContinueDragHandler (DependencyObject element, QueryContinueDragEventHandler handler)
		{
			UIElement.AddHandler (element, PreviewQueryContinueDragEvent, handler);
		}

		public static void AddQueryContinueDragHandler (DependencyObject element, QueryContinueDragEventHandler handler)
		{
			UIElement.AddHandler (element, QueryContinueDragEvent, handler);
		}


		public static void RemoveDragEnterHandler (DependencyObject element, DragEventHandler handler)
		{
			UIElement.RemoveHandler (element, DragEnterEvent, handler);
		}

		public static void RemoveDragLeaveHandler (DependencyObject element, DragEventHandler handler)
		{
			UIElement.RemoveHandler (element, DragLeaveEvent, handler);
		}

		public static void RemoveDragOverHandler (DependencyObject element, DragEventHandler handler)
		{
			UIElement.RemoveHandler (element, DragOverEvent, handler);
		}

		public static void RemoveDropHandler (DependencyObject element, DragEventHandler handler)
		{
			UIElement.RemoveHandler (element, DropEvent, handler);
		}

		public static void RemoveGiveFeedbackHandler (DependencyObject element, GiveFeedbackEventHandler handler)
		{
			UIElement.RemoveHandler (element, GiveFeedbackEvent, handler);
		}

		public static void RemovePreviewDragEnterHandler (DependencyObject element, DragEventHandler handler)
		{
			UIElement.RemoveHandler (element, PreviewDragEnterEvent, handler);
		}

		public static void RemovePreviewDragLeaveHandler (DependencyObject element, DragEventHandler handler)
		{
			UIElement.RemoveHandler (element, PreviewDragLeaveEvent, handler);
		}

		public static void RemovePreviewDragOverHandler (DependencyObject element, DragEventHandler handler)
		{
			UIElement.RemoveHandler (element, PreviewDragOverEvent, handler);
		}

		public static void RemovePreviewDropHandler (DependencyObject element, DragEventHandler handler)
		{
			UIElement.RemoveHandler (element, PreviewDropEvent, handler);
		}

		public static void RemovePreviewGiveFeedbackHandler (DependencyObject element, GiveFeedbackEventHandler handler)
		{
			UIElement.RemoveHandler (element, PreviewGiveFeedbackEvent, handler);
		}

		public static void RemovePreviewQueryContinueDragHandler (DependencyObject element, QueryContinueDragEventHandler handler)
		{
			UIElement.RemoveHandler (element, PreviewQueryContinueDragEvent, handler);
		}

		public static void RemoveQueryContinueDragHandler (DependencyObject element, QueryContinueDragEventHandler handler)
		{
			UIElement.RemoveHandler (element, QueryContinueDragEvent, handler);
		}

		[SecurityCritical]
		public static DragDropEffects DoDragDrop (DependencyObject dragSource, object data, DragDropEffects allowedEffects)
		{
			throw new NotImplementedException ();
		}


	}

}
