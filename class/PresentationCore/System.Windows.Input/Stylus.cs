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

using System;
using System.Security;
using System.Windows;

namespace System.Windows.Input {

	public static class Stylus {
		public static readonly RoutedEvent PreviewStylusDownEvent = new RoutedEvent ("PreviewStylusDown",
											     typeof (StylusDownEventHandler),
											     typeof (Stylus),
											     RoutingStrategy.Tunnel);
		public static readonly RoutedEvent PreviewStylusUpEvent = new RoutedEvent ("PreviewStylusUp",
											   typeof (StylusEventHandler),
											   typeof (Stylus),
											   RoutingStrategy.Tunnel);
		public static readonly RoutedEvent PreviewStylusMoveEvent = new RoutedEvent ("PreviewStylusMove",
											     typeof (StylusEventHandler),
											     typeof (Stylus),
											     RoutingStrategy.Tunnel);
		public static readonly RoutedEvent PreviewStylusInAirEvent = new RoutedEvent ("PreviewStylusInAir",
											      typeof (StylusEventHandler),
											      typeof (Stylus),
											      RoutingStrategy.Tunnel);
		public static readonly RoutedEvent PreviewStylusInAirMoveEvent = new RoutedEvent ("PreviewStylusInAirMove",
												  typeof (StylusEventHandler),
												  typeof (Stylus),
												  RoutingStrategy.Tunnel);
		public static readonly RoutedEvent PreviewStylusInRangeEvent = new RoutedEvent ("PreviewStylusInRange",
												typeof (StylusEventHandler),
												typeof (Stylus),
												RoutingStrategy.Tunnel);
		public static readonly RoutedEvent PreviewStylusOutOfRangeEvent = new RoutedEvent ("PreviewStylusOutOfRange",
												   typeof (StylusEventHandler),
												   typeof (Stylus),
												   RoutingStrategy.Tunnel);
		public static readonly RoutedEvent PreviewStylusSystemGestureEvent = new RoutedEvent ("PreviewStylusSystemGesture",
												      typeof (StylusEventHandler),
												      typeof (Stylus),
												      RoutingStrategy.Tunnel);
		public static readonly RoutedEvent PreviewStylusButtonDownEvent = new RoutedEvent ("PreviewStylusButtonDown",
												   typeof (StylusButtonEventHandler),
												   typeof (Stylus),
												   RoutingStrategy.Tunnel);
		public static readonly RoutedEvent PreviewStylusButtonUpEvent = new RoutedEvent ("PreviewStylusButtonUp",
												 typeof (StylusButtonEventHandler),
												 typeof (Stylus),
												 RoutingStrategy.Tunnel);




		public static readonly RoutedEvent StylusDownEvent = new RoutedEvent ("StylusDown",
										      typeof (StylusDownEventHandler),
										      typeof (Stylus),
										      RoutingStrategy.Bubble);
		public static readonly RoutedEvent StylusUpEvent = new RoutedEvent ("StylusUp",
										    typeof (StylusEventHandler),
										    typeof (Stylus),
										    RoutingStrategy.Bubble);
		public static readonly RoutedEvent StylusMoveEvent = new RoutedEvent ("StylusMove",
										      typeof (StylusEventHandler),
										      typeof (Stylus),
										      RoutingStrategy.Bubble);
		public static readonly RoutedEvent StylusInAirEvent = new RoutedEvent ("StylusInAir",
										       typeof (StylusEventHandler),
										       typeof (Stylus),
										       RoutingStrategy.Bubble);
		public static readonly RoutedEvent StylusInAirMoveEvent = new RoutedEvent ("StylusInAirMove",
											   typeof (StylusEventHandler),
											   typeof (Stylus),
											   RoutingStrategy.Bubble);
		public static readonly RoutedEvent StylusInRangeEvent = new RoutedEvent ("StylusInRange",
											 typeof (StylusEventHandler),
											 typeof (Stylus),
											 RoutingStrategy.Bubble);
		public static readonly RoutedEvent StylusOutOfRangeEvent = new RoutedEvent ("StylusOutOfRange",
											    typeof (StylusEventHandler),
											    typeof (Stylus),
											    RoutingStrategy.Bubble);
		public static readonly RoutedEvent StylusSystemGestureEvent = new RoutedEvent ("StylusSystemGesture",
											       typeof (StylusEventHandler),
											       typeof (Stylus),
											       RoutingStrategy.Bubble);
		public static readonly RoutedEvent StylusButtonDownEvent = new RoutedEvent ("StylusButtonDown",
											    typeof (StylusButtonEventHandler),
											    typeof (Stylus),
											    RoutingStrategy.Bubble);
		public static readonly RoutedEvent StylusButtonUpEvent = new RoutedEvent ("StylusButtonUp",
											  typeof (StylusButtonEventHandler),
											  typeof (Stylus),
											  RoutingStrategy.Bubble);

		public static readonly RoutedEvent StylusEnterEvent = new RoutedEvent ("StylusEnter",
										       typeof (StylusEventHandler),
										       typeof (Stylus),
										       RoutingStrategy.Direct);
		public static readonly RoutedEvent StylusLeaveEvent = new RoutedEvent ("StylusLeave",
										       typeof (StylusEventHandler),
										       typeof (Stylus),
										       RoutingStrategy.Direct);

		public static readonly RoutedEvent GotStylusCaptureEvent = new RoutedEvent ("GotStylusCapture",
											    typeof (StylusEventHandler),
											    typeof (Stylus),
											    RoutingStrategy.Bubble);
		public static readonly RoutedEvent LostStylusCaptureEvent = new RoutedEvent ("LostStylusCapture",
											     typeof (StylusEventHandler),
											     typeof (Stylus),
											     RoutingStrategy.Bubble);


		public static IInputElement Captured {
			get { throw new NotImplementedException (); }
		}

		public static StylusDevice CurrentStylusDevice {
			get { throw new NotImplementedException (); }
		}

		public static IInputElement DirectlyOver {
			get { throw new NotImplementedException (); }
		}

		public static void AddGotStylusCaptureHandler (DependencyObject element, StylusEventHandler handler)
		{
		    if (element == null) throw new ArgumentNullException ("element");
		    if (handler == null) throw new ArgumentNullException ("handler");
		
		    if (element is UIElement)
		        ((UIElement)element).AddHandler (GotStylusCaptureEvent, handler);
		    else if (element is ContentElement)
		        ((ContentElement)element).AddHandler (GotStylusCaptureEvent, handler);
		    else
		        throw new NotSupportedException ();
		}
		
		public static void RemoveGotStylusCaptureHandler (DependencyObject element, StylusEventHandler handler)
		{
		    if (element == null) throw new ArgumentNullException ("element");
		    if (handler == null) throw new ArgumentNullException ("handler");
		
		    if (element is UIElement)
		        ((UIElement)element).RemoveHandler (GotStylusCaptureEvent, handler);
		    else if (element is ContentElement)
		        ((ContentElement)element).RemoveHandler (GotStylusCaptureEvent, handler);
		    else
		        throw new NotSupportedException ();
		}
		
		public static void AddLostStylusCaptureHandler (DependencyObject element, StylusEventHandler handler)
		{
		    if (element == null) throw new ArgumentNullException ("element");
		    if (handler == null) throw new ArgumentNullException ("handler");
		
		    if (element is UIElement)
		        ((UIElement)element).AddHandler (LostStylusCaptureEvent, handler);
		    else if (element is ContentElement)
		        ((ContentElement)element).AddHandler (LostStylusCaptureEvent, handler);
		    else
		        throw new NotSupportedException ();
		}
		
		public static void RemoveLostStylusCaptureHandler (DependencyObject element, StylusEventHandler handler)
		{
		    if (element == null) throw new ArgumentNullException ("element");
		    if (handler == null) throw new ArgumentNullException ("handler");
		
		    if (element is UIElement)
		        ((UIElement)element).RemoveHandler (LostStylusCaptureEvent, handler);
		    else if (element is ContentElement)
		        ((ContentElement)element).RemoveHandler (LostStylusCaptureEvent, handler);
		    else
		        throw new NotSupportedException ();
		}
		
		public static void AddPreviewStylusButtonDownHandler (DependencyObject element, StylusButtonEventHandler handler)
		{
		    if (element == null) throw new ArgumentNullException ("element");
		    if (handler == null) throw new ArgumentNullException ("handler");
		
		    if (element is UIElement)
		        ((UIElement)element).AddHandler (PreviewStylusButtonDownEvent, handler);
		    else if (element is ContentElement)
		        ((ContentElement)element).AddHandler (PreviewStylusButtonDownEvent, handler);
		    else
		        throw new NotSupportedException ();
		}
		
		public static void RemovePreviewStylusButtonDownHandler (DependencyObject element, StylusButtonEventHandler handler)
		{
		    if (element == null) throw new ArgumentNullException ("element");
		    if (handler == null) throw new ArgumentNullException ("handler");
		
		    if (element is UIElement)
		        ((UIElement)element).RemoveHandler (PreviewStylusButtonDownEvent, handler);
		    else if (element is ContentElement)
		        ((ContentElement)element).RemoveHandler (PreviewStylusButtonDownEvent, handler);
		    else
		        throw new NotSupportedException ();
		}
		
		public static void AddPreviewStylusButtonUpHandler (DependencyObject element, StylusButtonEventHandler handler)
		{
		    if (element == null) throw new ArgumentNullException ("element");
		    if (handler == null) throw new ArgumentNullException ("handler");
		
		    if (element is UIElement)
		        ((UIElement)element).AddHandler (PreviewStylusButtonUpEvent, handler);
		    else if (element is ContentElement)
		        ((ContentElement)element).AddHandler (PreviewStylusButtonUpEvent, handler);
		    else
		        throw new NotSupportedException ();
		}
		
		public static void RemovePreviewStylusButtonUpHandler (DependencyObject element, StylusButtonEventHandler handler)
		{
		    if (element == null) throw new ArgumentNullException ("element");
		    if (handler == null) throw new ArgumentNullException ("handler");
		
		    if (element is UIElement)
		        ((UIElement)element).RemoveHandler (PreviewStylusButtonUpEvent, handler);
		    else if (element is ContentElement)
		        ((ContentElement)element).RemoveHandler (PreviewStylusButtonUpEvent, handler);
		    else
		        throw new NotSupportedException ();
		}
		
		public static void AddPreviewStylusDownHandler (DependencyObject element, StylusDownEventHandler handler)
		{
		    if (element == null) throw new ArgumentNullException ("element");
		    if (handler == null) throw new ArgumentNullException ("handler");
		
		    if (element is UIElement)
		        ((UIElement)element).AddHandler (PreviewStylusDownEvent, handler);
		    else if (element is ContentElement)
		        ((ContentElement)element).AddHandler (PreviewStylusDownEvent, handler);
		    else
		        throw new NotSupportedException ();
		}
		
		public static void RemovePreviewStylusDownHandler (DependencyObject element, StylusDownEventHandler handler)
		{
		    if (element == null) throw new ArgumentNullException ("element");
		    if (handler == null) throw new ArgumentNullException ("handler");
		
		    if (element is UIElement)
		        ((UIElement)element).RemoveHandler (PreviewStylusDownEvent, handler);
		    else if (element is ContentElement)
		        ((ContentElement)element).RemoveHandler (PreviewStylusDownEvent, handler);
		    else
		        throw new NotSupportedException ();
		}
		
		public static void AddPreviewStylusInAirMoveHandler (DependencyObject element, StylusEventHandler handler)
		{
		    if (element == null) throw new ArgumentNullException ("element");
		    if (handler == null) throw new ArgumentNullException ("handler");
		
		    if (element is UIElement)
		        ((UIElement)element).AddHandler (PreviewStylusInAirMoveEvent, handler);
		    else if (element is ContentElement)
		        ((ContentElement)element).AddHandler (PreviewStylusInAirMoveEvent, handler);
		    else
		        throw new NotSupportedException ();
		}
		
		public static void RemovePreviewStylusInAirMoveHandler (DependencyObject element, StylusEventHandler handler)
		{
		    if (element == null) throw new ArgumentNullException ("element");
		    if (handler == null) throw new ArgumentNullException ("handler");
		
		    if (element is UIElement)
		        ((UIElement)element).RemoveHandler (PreviewStylusInAirMoveEvent, handler);
		    else if (element is ContentElement)
		        ((ContentElement)element).RemoveHandler (PreviewStylusInAirMoveEvent, handler);
		    else
		        throw new NotSupportedException ();
		}
		
		public static void AddPreviewStylusInRangeHandler (DependencyObject element, StylusEventHandler handler)
		{
		    if (element == null) throw new ArgumentNullException ("element");
		    if (handler == null) throw new ArgumentNullException ("handler");
		
		    if (element is UIElement)
		        ((UIElement)element).AddHandler (PreviewStylusInRangeEvent, handler);
		    else if (element is ContentElement)
		        ((ContentElement)element).AddHandler (PreviewStylusInRangeEvent, handler);
		    else
		        throw new NotSupportedException ();
		}
		
		public static void RemovePreviewStylusInRangeHandler (DependencyObject element, StylusEventHandler handler)
		{
		    if (element == null) throw new ArgumentNullException ("element");
		    if (handler == null) throw new ArgumentNullException ("handler");
		
		    if (element is UIElement)
		        ((UIElement)element).RemoveHandler (PreviewStylusInRangeEvent, handler);
		    else if (element is ContentElement)
		        ((ContentElement)element).RemoveHandler (PreviewStylusInRangeEvent, handler);
		    else
		        throw new NotSupportedException ();
		}
		
		public static void AddPreviewStylusMoveHandler (DependencyObject element, StylusEventHandler handler)
		{
		    if (element == null) throw new ArgumentNullException ("element");
		    if (handler == null) throw new ArgumentNullException ("handler");
		
		    if (element is UIElement)
		        ((UIElement)element).AddHandler (PreviewStylusMoveEvent, handler);
		    else if (element is ContentElement)
		        ((ContentElement)element).AddHandler (PreviewStylusMoveEvent, handler);
		    else
		        throw new NotSupportedException ();
		}
		
		public static void RemoveddPreviewStylusMoveHandler (DependencyObject element, StylusEventHandler handler)
		{
		    if (element == null) throw new ArgumentNullException ("element");
		    if (handler == null) throw new ArgumentNullException ("handler");
		
		    if (element is UIElement)
		        ((UIElement)element).RemoveHandler (PreviewStylusMoveEvent, handler);
		    else if (element is ContentElement)
		        ((ContentElement)element).RemoveHandler (PreviewStylusMoveEvent, handler);
		    else
		        throw new NotSupportedException ();
		}
		
		public static void AddPreviewStylusOutOfRangeHandler (DependencyObject element, StylusEventHandler handler)
		{
		    if (element == null) throw new ArgumentNullException ("element");
		    if (handler == null) throw new ArgumentNullException ("handler");
		
		    if (element is UIElement)
		        ((UIElement)element).AddHandler (PreviewStylusOutOfRangeEvent, handler);
		    else if (element is ContentElement)
		        ((ContentElement)element).AddHandler (PreviewStylusOutOfRangeEvent, handler);
		    else
		        throw new NotSupportedException ();
		}
		
		public static void RemovePreviewStylusOutOfRangeHandler (DependencyObject element, StylusEventHandler handler)
		{
		    if (element == null) throw new ArgumentNullException ("element");
		    if (handler == null) throw new ArgumentNullException ("handler");
		
		    if (element is UIElement)
		        ((UIElement)element).RemoveHandler (PreviewStylusOutOfRangeEvent, handler);
		    else if (element is ContentElement)
		        ((ContentElement)element).RemoveHandler (PreviewStylusOutOfRangeEvent, handler);
		    else
		        throw new NotSupportedException ();
		}
		
		public static void AddPreviewStylusSystemGestureHandler (DependencyObject element, StylusSystemGestureEventHandler handler)
		{
		    if (element == null) throw new ArgumentNullException ("element");
		    if (handler == null) throw new ArgumentNullException ("handler");
		
		    if (element is UIElement)
		        ((UIElement)element).AddHandler (PreviewStylusSystemGestureEvent, handler);
		    else if (element is ContentElement)
		        ((ContentElement)element).AddHandler (PreviewStylusSystemGestureEvent, handler);
		    else
		        throw new NotSupportedException ();
		}
		
		public static void RemovePreviewStylusSystemGestureHandler (DependencyObject element, StylusSystemGestureEventHandler handler)
		{
		    if (element == null) throw new ArgumentNullException ("element");
		    if (handler == null) throw new ArgumentNullException ("handler");
		
		    if (element is UIElement)
		        ((UIElement)element).RemoveHandler (PreviewStylusSystemGestureEvent, handler);
		    else if (element is ContentElement)
		        ((ContentElement)element).RemoveHandler (PreviewStylusSystemGestureEvent, handler);
		    else
		        throw new NotSupportedException ();
		}
		
		public static void AddPreviewStylusUpHandler (DependencyObject element, StylusEventHandler handler)
		{
		    if (element == null) throw new ArgumentNullException ("element");
		    if (handler == null) throw new ArgumentNullException ("handler");
		
		    if (element is UIElement)
		        ((UIElement)element).AddHandler (PreviewStylusUpEvent, handler);
		    else if (element is ContentElement)
		        ((ContentElement)element).AddHandler (PreviewStylusUpEvent, handler);
		    else
		        throw new NotSupportedException ();
		}
		
		public static void RemovePreviewStylusUpHandler (DependencyObject element, StylusEventHandler handler)
		{
		    if (element == null) throw new ArgumentNullException ("element");
		    if (handler == null) throw new ArgumentNullException ("handler");
		
		    if (element is UIElement)
		        ((UIElement)element).RemoveHandler (PreviewStylusUpEvent, handler);
		    else if (element is ContentElement)
		        ((ContentElement)element).RemoveHandler (PreviewStylusUpEvent, handler);
		    else
		        throw new NotSupportedException ();
		}
		
		public static void AddStylusButtonDownHandler (DependencyObject element, StylusButtonEventHandler handler)
		{
		    if (element == null) throw new ArgumentNullException ("element");
		    if (handler == null) throw new ArgumentNullException ("handler");
		
		    if (element is UIElement)
		        ((UIElement)element).AddHandler (StylusButtonDownEvent, handler);
		    else if (element is ContentElement)
		        ((ContentElement)element).AddHandler (StylusButtonDownEvent, handler);
		    else
		        throw new NotSupportedException ();
		}
		
		public static void RemoveStylusButtonDownHandler (DependencyObject element, StylusButtonEventHandler handler)
		{
		    if (element == null) throw new ArgumentNullException ("element");
		    if (handler == null) throw new ArgumentNullException ("handler");
		
		    if (element is UIElement)
		        ((UIElement)element).RemoveHandler (StylusButtonDownEvent, handler);
		    else if (element is ContentElement)
		        ((ContentElement)element).RemoveHandler (StylusButtonDownEvent, handler);
		    else
		        throw new NotSupportedException ();
		}
		
		public static void AddStylusButtonUpHandler (DependencyObject element, StylusButtonEventHandler handler)
		{
		    if (element == null) throw new ArgumentNullException ("element");
		    if (handler == null) throw new ArgumentNullException ("handler");
		
		    if (element is UIElement)
		        ((UIElement)element).AddHandler (StylusButtonUpEvent, handler);
		    else if (element is ContentElement)
		        ((ContentElement)element).AddHandler (StylusButtonUpEvent, handler);
		    else
		        throw new NotSupportedException ();
		}
		
		public static void RemoveStylusButtonUpHandler (DependencyObject element, StylusButtonEventHandler handler)
		{
		    if (element == null) throw new ArgumentNullException ("element");
		    if (handler == null) throw new ArgumentNullException ("handler");
		
		    if (element is UIElement)
		        ((UIElement)element).RemoveHandler (StylusButtonUpEvent, handler);
		    else if (element is ContentElement)
		        ((ContentElement)element).RemoveHandler (StylusButtonUpEvent, handler);
		    else
		        throw new NotSupportedException ();
		}
		
		public static void AddStylusDownHandler (DependencyObject element, StylusDownEventHandler handler)
		{
		    if (element == null) throw new ArgumentNullException ("element");
		    if (handler == null) throw new ArgumentNullException ("handler");
		
		    if (element is UIElement)
		        ((UIElement)element).AddHandler (StylusDownEvent, handler);
		    else if (element is ContentElement)
		        ((ContentElement)element).AddHandler (StylusDownEvent, handler);
		    else
		        throw new NotSupportedException ();
		}
		
		public static void RemoveStylusDownHandler (DependencyObject element, StylusDownEventHandler handler)
		{
		    if (element == null) throw new ArgumentNullException ("element");
		    if (handler == null) throw new ArgumentNullException ("handler");
		
		    if (element is UIElement)
		        ((UIElement)element).RemoveHandler (StylusDownEvent, handler);
		    else if (element is ContentElement)
		        ((ContentElement)element).RemoveHandler (StylusDownEvent, handler);
		    else
		        throw new NotSupportedException ();
		}
		
		public static void AddStylusEnterHandler (DependencyObject element, StylusEventHandler handler)
		{
		    if (element == null) throw new ArgumentNullException ("element");
		    if (handler == null) throw new ArgumentNullException ("handler");
		
		    if (element is UIElement)
		        ((UIElement)element).AddHandler (StylusEnterEvent, handler);
		    else if (element is ContentElement)
		        ((ContentElement)element).AddHandler (StylusEnterEvent, handler);
		    else
		        throw new NotSupportedException ();
		}
		
		public static void RemoveStylusEnterHandler (DependencyObject element, StylusEventHandler handler)
		{
		    if (element == null) throw new ArgumentNullException ("element");
		    if (handler == null) throw new ArgumentNullException ("handler");
		
		    if (element is UIElement)
		        ((UIElement)element).RemoveHandler (StylusEnterEvent, handler);
		    else if (element is ContentElement)
		        ((ContentElement)element).RemoveHandler (StylusEnterEvent, handler);
		    else
		        throw new NotSupportedException ();
		}
		
		public static void AddStylusInAirMoveHandler (DependencyObject element, StylusEventHandler handler)
		{
		    if (element == null) throw new ArgumentNullException ("element");
		    if (handler == null) throw new ArgumentNullException ("handler");
		
		    if (element is UIElement)
		        ((UIElement)element).AddHandler (StylusInAirMoveEvent, handler);
		    else if (element is ContentElement)
		        ((ContentElement)element).AddHandler (StylusInAirMoveEvent, handler);
		    else
		        throw new NotSupportedException ();
		}
		
		public static void RemoveStylusInAirMoveHandler (DependencyObject element, StylusEventHandler handler)
		{
		    if (element == null) throw new ArgumentNullException ("element");
		    if (handler == null) throw new ArgumentNullException ("handler");
		
		    if (element is UIElement)
		        ((UIElement)element).RemoveHandler (StylusInAirMoveEvent, handler);
		    else if (element is ContentElement)
		        ((ContentElement)element).RemoveHandler (StylusInAirMoveEvent, handler);
		    else
		        throw new NotSupportedException ();
		}
		
		public static void AddStylusInRangeHandler (DependencyObject element, StylusEventHandler handler)
		{
		    if (element == null) throw new ArgumentNullException ("element");
		    if (handler == null) throw new ArgumentNullException ("handler");
		
		    if (element is UIElement)
		        ((UIElement)element).AddHandler (StylusInRangeEvent, handler);
		    else if (element is ContentElement)
		        ((ContentElement)element).AddHandler (StylusInRangeEvent, handler);
		    else
		        throw new NotSupportedException ();
		}
		
		public static void RemoveStylusInRangeHandler (DependencyObject element, StylusEventHandler handler)
		{
		    if (element == null) throw new ArgumentNullException ("element");
		    if (handler == null) throw new ArgumentNullException ("handler");
		
		    if (element is UIElement)
		        ((UIElement)element).RemoveHandler (StylusInRangeEvent, handler);
		    else if (element is ContentElement)
		        ((ContentElement)element).RemoveHandler (StylusInRangeEvent, handler);
		    else
		        throw new NotSupportedException ();
		}
		
		public static void AddStylusLeaveHandler (DependencyObject element, StylusEventHandler handler)
		{
		    if (element == null) throw new ArgumentNullException ("element");
		    if (handler == null) throw new ArgumentNullException ("handler");
		
		    if (element is UIElement)
		        ((UIElement)element).AddHandler (StylusLeaveEvent, handler);
		    else if (element is ContentElement)
		        ((ContentElement)element).AddHandler (StylusLeaveEvent, handler);
		    else
		        throw new NotSupportedException ();
		}
		
		public static void RemoveStylusLeaveHandler (DependencyObject element, StylusEventHandler handler)
		{
		    if (element == null) throw new ArgumentNullException ("element");
		    if (handler == null) throw new ArgumentNullException ("handler");
		
		    if (element is UIElement)
		        ((UIElement)element).RemoveHandler (StylusLeaveEvent, handler);
		    else if (element is ContentElement)
		        ((ContentElement)element).RemoveHandler (StylusLeaveEvent, handler);
		    else
		        throw new NotSupportedException ();
		}
		
		public static void AddStylusMoveHandler (DependencyObject element, StylusEventHandler handler)
		{
		    if (element == null) throw new ArgumentNullException ("element");
		    if (handler == null) throw new ArgumentNullException ("handler");
		
		    if (element is UIElement)
		        ((UIElement)element).AddHandler (StylusMoveEvent, handler);
		    else if (element is ContentElement)
		        ((ContentElement)element).AddHandler (StylusMoveEvent, handler);
		    else
		        throw new NotSupportedException ();
		}
		
		public static void RemoveStylusMoveHandler (DependencyObject element, StylusEventHandler handler)
		{
		    if (element == null) throw new ArgumentNullException ("element");
		    if (handler == null) throw new ArgumentNullException ("handler");
		
		    if (element is UIElement)
		        ((UIElement)element).RemoveHandler (StylusMoveEvent, handler);
		    else if (element is ContentElement)
		        ((ContentElement)element).RemoveHandler (StylusMoveEvent, handler);
		    else
		        throw new NotSupportedException ();
		}
		
		public static void AddStylusOutOfRangeHandler (DependencyObject element, StylusEventHandler handler)
		{
		    if (element == null) throw new ArgumentNullException ("element");
		    if (handler == null) throw new ArgumentNullException ("handler");
		
		    if (element is UIElement)
		        ((UIElement)element).AddHandler (StylusOutOfRangeEvent, handler);
		    else if (element is ContentElement)
		        ((ContentElement)element).AddHandler (StylusOutOfRangeEvent, handler);
		    else
		        throw new NotSupportedException ();
		}
		
		public static void RemoveStylusOutOfRangeHandler (DependencyObject element, StylusEventHandler handler)
		{
		    if (element == null) throw new ArgumentNullException ("element");
		    if (handler == null) throw new ArgumentNullException ("handler");
		
		    if (element is UIElement)
		        ((UIElement)element).RemoveHandler (StylusOutOfRangeEvent, handler);
		    else if (element is ContentElement)
		        ((ContentElement)element).RemoveHandler (StylusOutOfRangeEvent, handler);
		    else
		        throw new NotSupportedException ();
		}
		
		public static void AddStylusSystemGestureHandler (DependencyObject element, StylusSystemGestureEventHandler handler)
		{
		    if (element == null) throw new ArgumentNullException ("element");
		    if (handler == null) throw new ArgumentNullException ("handler");
		
		    if (element is UIElement)
		        ((UIElement)element).AddHandler (StylusSystemGestureEvent, handler);
		    else if (element is ContentElement)
		        ((ContentElement)element).AddHandler (StylusSystemGestureEvent, handler);
		    else
		        throw new NotSupportedException ();
		}
		
		public static void RemoveStylusSystemGestureHandler (DependencyObject element, StylusSystemGestureEventHandler handler)
		{
		    if (element == null) throw new ArgumentNullException ("element");
		    if (handler == null) throw new ArgumentNullException ("handler");
		
		    if (element is UIElement)
		        ((UIElement)element).RemoveHandler (StylusSystemGestureEvent, handler);
		    else if (element is ContentElement)
		        ((ContentElement)element).RemoveHandler (StylusSystemGestureEvent, handler);
		    else
		        throw new NotSupportedException ();
		}
		
		public static void AddStylusUpHandler (DependencyObject element, StylusEventHandler handler)
		{
		    if (element == null) throw new ArgumentNullException ("element");
		    if (handler == null) throw new ArgumentNullException ("handler");
		
		    if (element is UIElement)
		        ((UIElement)element).AddHandler (StylusUpEvent, handler);
		    else if (element is ContentElement)
		        ((ContentElement)element).AddHandler (StylusUpEvent, handler);
		    else
		        throw new NotSupportedException ();
		}
		
		public static void RemoveStylusUpHandler (DependencyObject element, StylusEventHandler handler)
		{
		    if (element == null) throw new ArgumentNullException ("element");
		    if (handler == null) throw new ArgumentNullException ("handler");
		
		    if (element is UIElement)
		        ((UIElement)element).RemoveHandler (StylusUpEvent, handler);
		    else if (element is ContentElement)
		        ((ContentElement)element).RemoveHandler (StylusUpEvent, handler);
		    else
		        throw new NotSupportedException ();
		}

		public static bool Capture (IInputElement element)
		{
			throw new NotImplementedException ();
		}

		public static bool Capture (IInputElement element, CaptureMode captureMode)
		{
			throw new NotImplementedException ();
		}

		public static bool GetIsFlicksEnabled (DependencyObject element)
		{
			throw new NotImplementedException ();
		}

		public static bool GetIsPressAndHoldEnabled (DependencyObject element)
		{
			throw new NotImplementedException ();
		}

		public static bool GetIsTapFeedbackEnabled (DependencyObject element)
		{
			throw new NotImplementedException ();
		}

		public static bool GetIsTouchFeedbackEnabled (DependencyObject element)
		{
			throw new NotImplementedException ();
		}

		public static void SetIsFlicksEnabled (DependencyObject element, bool enabled)
		{
			throw new NotImplementedException ();
		}

		public static void SetIsPressAndHoldEnabled (DependencyObject element, bool enabled)
		{
			throw new NotImplementedException ();
		}

		public static void SetIsTapFeedbackEnabled (DependencyObject element, bool enabled)
		{
			throw new NotImplementedException ();
		}

		public static void SetIsTouchFeedbackEnabled (DependencyObject element, bool enabled)
		{
			throw new NotImplementedException ();
		}

		public static void Synchronize ()
		{
			throw new NotImplementedException ();
		}
	}

}
