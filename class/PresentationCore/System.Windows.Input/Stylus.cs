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
	}

}
