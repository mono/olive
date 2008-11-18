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
using System.Windows.Media;
using NUnit.Framework;

namespace MonoTests.System.Windows {

	[TestFixture]
	public class DataObjectTest {
		[Test]
		public void TestRoutedEvents ()
		{
			Assert.Fail ("DataObject class isn't implemented");
#if notyet
			Assert.AreEqual (typeof (DataObject), DataObject.CopyingEvent.OwnerType);
			Assert.AreEqual ("Copying", DataObject.CopyingEvent.Name);
			Assert.AreEqual ("DataObject.Copying", DataObject.CopyingEvent.ToString());
			Assert.AreEqual (typeof (DataObjectCopyingEventHandler), DataObject.CopyingEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, DataObject.CopyingEvent.RoutingStrategy);

			Assert.AreEqual (typeof (DataObject), DataObject.PastingEvent.OwnerType);
			Assert.AreEqual ("Pasting", DataObject.PastingEvent.Name);
			Assert.AreEqual ("DataObject.Pasting", DataObject.PastingEvent.ToString());
			Assert.AreEqual (typeof (DataObjectPastingEventHandler), DataObject.PastingEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, DataObject.PastingEvent.RoutingStrategy);

			Assert.AreEqual (typeof (DataObject), DataObject.SettingDataEvent.OwnerType);
			Assert.AreEqual ("SettingData", DataObject.SettingDataEvent.Name);
			Assert.AreEqual ("DataObject.SettingData", DataObject.SettingDataEvent.ToString());
			Assert.AreEqual (typeof (DataObjectSettingDataEventHandler), DataObject.SettingDataEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, DataObject.SettingDataEvent.RoutingStrategy);
#endif
		}
	}
}