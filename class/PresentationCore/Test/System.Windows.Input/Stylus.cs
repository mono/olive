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
using System.Windows.Input;
using NUnit.Framework;

namespace MonoTests.System.Windows.Input {

	[TestFixture]
	public class StylusTest {

		[Test]
		public void RoutedEvents ()
		{
#if notyet
			Assert.AreEqual (typeof (Stylus), Stylus.PreviewStylusDownEvent.OwnerType);
			Assert.AreEqual ("PreviewStylusDown", Stylus.PreviewStylusDownEvent.Name);
			Assert.AreEqual ("Stylus.PreviewStylusDown", Stylus.PreviewStylusDownEvent.ToString());
			Assert.AreEqual (typeof (StylusDownEventHandler), Stylus.PreviewStylusDownEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, Stylus.PreviewStylusDownEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Stylus), Stylus.StylusDownEvent.OwnerType);
			Assert.AreEqual ("StylusDown", Stylus.StylusDownEvent.Name);
			Assert.AreEqual ("Stylus.StylusDown", Stylus.StylusDownEvent.ToString());
			Assert.AreEqual (typeof (StylusDownEventHandler), Stylus.StylusDownEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, Stylus.StylusDownEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Stylus), Stylus.PreviewStylusUpEvent.OwnerType);
			Assert.AreEqual ("PreviewStylusUp", Stylus.PreviewStylusUpEvent.Name);
			Assert.AreEqual ("Stylus.PreviewStylusUp", Stylus.PreviewStylusUpEvent.ToString());
			Assert.AreEqual (typeof (StylusEventHandler), Stylus.PreviewStylusUpEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, Stylus.PreviewStylusUpEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Stylus), Stylus.StylusUpEvent.OwnerType);
			Assert.AreEqual ("StylusUp", Stylus.StylusUpEvent.Name);
			Assert.AreEqual ("Stylus.StylusUp", Stylus.StylusUpEvent.ToString());
			Assert.AreEqual (typeof (StylusEventHandler), Stylus.StylusUpEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, Stylus.StylusUpEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Stylus), Stylus.PreviewStylusMoveEvent.OwnerType);
			Assert.AreEqual ("PreviewStylusMove", Stylus.PreviewStylusMoveEvent.Name);
			Assert.AreEqual ("Stylus.PreviewStylusMove", Stylus.PreviewStylusMoveEvent.ToString());
			Assert.AreEqual (typeof (StylusEventHandler), Stylus.PreviewStylusMoveEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, Stylus.PreviewStylusMoveEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Stylus), Stylus.StylusMoveEvent.OwnerType);
			Assert.AreEqual ("StylusMove", Stylus.StylusMoveEvent.Name);
			Assert.AreEqual ("Stylus.StylusMove", Stylus.StylusMoveEvent.ToString());
			Assert.AreEqual (typeof (StylusEventHandler), Stylus.StylusMoveEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, Stylus.StylusMoveEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Stylus), Stylus.PreviewStylusInAirMoveEvent.OwnerType);
			Assert.AreEqual ("PreviewStylusInAirMove", Stylus.PreviewStylusInAirMoveEvent.Name);
			Assert.AreEqual ("Stylus.PreviewStylusInAirMove", Stylus.PreviewStylusInAirMoveEvent.ToString());
			Assert.AreEqual (typeof (StylusEventHandler), Stylus.PreviewStylusInAirMoveEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, Stylus.PreviewStylusInAirMoveEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Stylus), Stylus.StylusInAirMoveEvent.OwnerType);
			Assert.AreEqual ("StylusInAirMove", Stylus.StylusInAirMoveEvent.Name);
			Assert.AreEqual ("Stylus.StylusInAirMove", Stylus.StylusInAirMoveEvent.ToString());
			Assert.AreEqual (typeof (StylusEventHandler), Stylus.StylusInAirMoveEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, Stylus.StylusInAirMoveEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Stylus), Stylus.StylusEnterEvent.OwnerType);
			Assert.AreEqual ("StylusEnter", Stylus.StylusEnterEvent.Name);
			Assert.AreEqual ("Stylus.StylusEnter", Stylus.StylusEnterEvent.ToString());
			Assert.AreEqual (typeof (StylusEventHandler), Stylus.StylusEnterEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Direct, Stylus.StylusEnterEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Stylus), Stylus.StylusLeaveEvent.OwnerType);
			Assert.AreEqual ("StylusLeave", Stylus.StylusLeaveEvent.Name);
			Assert.AreEqual ("Stylus.StylusLeave", Stylus.StylusLeaveEvent.ToString());
			Assert.AreEqual (typeof (StylusEventHandler), Stylus.StylusLeaveEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Direct, Stylus.StylusLeaveEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Stylus), Stylus.PreviewStylusInRangeEvent.OwnerType);
			Assert.AreEqual ("PreviewStylusInRange", Stylus.PreviewStylusInRangeEvent.Name);
			Assert.AreEqual ("Stylus.PreviewStylusInRange", Stylus.PreviewStylusInRangeEvent.ToString());
			Assert.AreEqual (typeof (StylusEventHandler), Stylus.PreviewStylusInRangeEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, Stylus.PreviewStylusInRangeEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Stylus), Stylus.StylusInRangeEvent.OwnerType);
			Assert.AreEqual ("StylusInRange", Stylus.StylusInRangeEvent.Name);
			Assert.AreEqual ("Stylus.StylusInRange", Stylus.StylusInRangeEvent.ToString());
			Assert.AreEqual (typeof (StylusEventHandler), Stylus.StylusInRangeEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, Stylus.StylusInRangeEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Stylus), Stylus.PreviewStylusOutOfRangeEvent.OwnerType);
			Assert.AreEqual ("PreviewStylusOutOfRange", Stylus.PreviewStylusOutOfRangeEvent.Name);
			Assert.AreEqual ("Stylus.PreviewStylusOutOfRange", Stylus.PreviewStylusOutOfRangeEvent.ToString());
			Assert.AreEqual (typeof (StylusEventHandler), Stylus.PreviewStylusOutOfRangeEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, Stylus.PreviewStylusOutOfRangeEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Stylus), Stylus.StylusOutOfRangeEvent.OwnerType);
			Assert.AreEqual ("StylusOutOfRange", Stylus.StylusOutOfRangeEvent.Name);
			Assert.AreEqual ("Stylus.StylusOutOfRange", Stylus.StylusOutOfRangeEvent.ToString());
			Assert.AreEqual (typeof (StylusEventHandler), Stylus.StylusOutOfRangeEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, Stylus.StylusOutOfRangeEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Stylus), Stylus.PreviewStylusSystemGestureEvent.OwnerType);
			Assert.AreEqual ("PreviewStylusSystemGesture", Stylus.PreviewStylusSystemGestureEvent.Name);
			Assert.AreEqual ("Stylus.PreviewStylusSystemGesture", Stylus.PreviewStylusSystemGestureEvent.ToString());
			Assert.AreEqual (typeof (StylusSystemGestureEventHandler), Stylus.PreviewStylusSystemGestureEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, Stylus.PreviewStylusSystemGestureEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Stylus), Stylus.StylusSystemGestureEvent.OwnerType);
			Assert.AreEqual ("StylusSystemGesture", Stylus.StylusSystemGestureEvent.Name);
			Assert.AreEqual ("Stylus.StylusSystemGesture", Stylus.StylusSystemGestureEvent.ToString());
			Assert.AreEqual (typeof (StylusSystemGestureEventHandler), Stylus.StylusSystemGestureEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, Stylus.StylusSystemGestureEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Stylus), Stylus.GotStylusCaptureEvent.OwnerType);
			Assert.AreEqual ("GotStylusCapture", Stylus.GotStylusCaptureEvent.Name);
			Assert.AreEqual ("Stylus.GotStylusCapture", Stylus.GotStylusCaptureEvent.ToString());
			Assert.AreEqual (typeof (StylusEventHandler), Stylus.GotStylusCaptureEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, Stylus.GotStylusCaptureEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Stylus), Stylus.LostStylusCaptureEvent.OwnerType);
			Assert.AreEqual ("LostStylusCapture", Stylus.LostStylusCaptureEvent.Name);
			Assert.AreEqual ("Stylus.LostStylusCapture", Stylus.LostStylusCaptureEvent.ToString());
			Assert.AreEqual (typeof (StylusEventHandler), Stylus.LostStylusCaptureEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, Stylus.LostStylusCaptureEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Stylus), Stylus.StylusButtonDownEvent.OwnerType);
			Assert.AreEqual ("StylusButtonDown", Stylus.StylusButtonDownEvent.Name);
			Assert.AreEqual ("Stylus.StylusButtonDown", Stylus.StylusButtonDownEvent.ToString());
			Assert.AreEqual (typeof (StylusButtonEventHandler), Stylus.StylusButtonDownEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, Stylus.StylusButtonDownEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Stylus), Stylus.StylusButtonUpEvent.OwnerType);
			Assert.AreEqual ("StylusButtonUp", Stylus.StylusButtonUpEvent.Name);
			Assert.AreEqual ("Stylus.StylusButtonUp", Stylus.StylusButtonUpEvent.ToString());
			Assert.AreEqual (typeof (StylusButtonEventHandler), Stylus.StylusButtonUpEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, Stylus.StylusButtonUpEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Stylus), Stylus.PreviewStylusButtonDownEvent.OwnerType);
			Assert.AreEqual ("PreviewStylusButtonDown", Stylus.PreviewStylusButtonDownEvent.Name);
			Assert.AreEqual ("Stylus.PreviewStylusButtonDown", Stylus.PreviewStylusButtonDownEvent.ToString());
			Assert.AreEqual (typeof (StylusButtonEventHandler), Stylus.PreviewStylusButtonDownEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, Stylus.PreviewStylusButtonDownEvent.RoutingStrategy);

			Assert.AreEqual (typeof (Stylus), Stylus.PreviewStylusButtonUpEvent.OwnerType);
			Assert.AreEqual ("PreviewStylusButtonUp", Stylus.PreviewStylusButtonUpEvent.Name);
			Assert.AreEqual ("Stylus.PreviewStylusButtonUp", Stylus.PreviewStylusButtonUpEvent.ToString());
			Assert.AreEqual (typeof (StylusButtonEventHandler), Stylus.PreviewStylusButtonUpEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, Stylus.PreviewStylusButtonUpEvent.RoutingStrategy);
#endif
		}
	}

}