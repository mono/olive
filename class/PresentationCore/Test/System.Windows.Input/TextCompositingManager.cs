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
	public class TextCompositingManagerTest {

		[Test]
		public void RoutedEvents ()
		{
			Assert.AreEqual (typeof (TextCompositionManager), TextCompositionManager.PreviewTextInputStartEvent.OwnerType);
			Assert.AreEqual ("PreviewTextInputStart", TextCompositionManager.PreviewTextInputStartEvent.Name);
			Assert.AreEqual ("TextCompositionManager.PreviewTextInputStart", TextCompositionManager.PreviewTextInputStartEvent.ToString());
			Assert.AreEqual (typeof (TextCompositionEventHandler), TextCompositionManager.PreviewTextInputStartEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, TextCompositionManager.PreviewTextInputStartEvent.RoutingStrategy);

			Assert.AreEqual (typeof (TextCompositionManager), TextCompositionManager.TextInputStartEvent.OwnerType);
			Assert.AreEqual ("TextInputStart", TextCompositionManager.TextInputStartEvent.Name);
			Assert.AreEqual ("TextCompositionManager.TextInputStart", TextCompositionManager.TextInputStartEvent.ToString());
			Assert.AreEqual (typeof (TextCompositionEventHandler), TextCompositionManager.TextInputStartEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, TextCompositionManager.TextInputStartEvent.RoutingStrategy);

			Assert.AreEqual (typeof (TextCompositionManager), TextCompositionManager.PreviewTextInputUpdateEvent.OwnerType);
			Assert.AreEqual ("PreviewTextInputUpdate", TextCompositionManager.PreviewTextInputUpdateEvent.Name);
			Assert.AreEqual ("TextCompositionManager.PreviewTextInputUpdate", TextCompositionManager.PreviewTextInputUpdateEvent.ToString());
			Assert.AreEqual (typeof (TextCompositionEventHandler), TextCompositionManager.PreviewTextInputUpdateEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, TextCompositionManager.PreviewTextInputUpdateEvent.RoutingStrategy);

			Assert.AreEqual (typeof (TextCompositionManager), TextCompositionManager.TextInputUpdateEvent.OwnerType);
			Assert.AreEqual ("TextInputUpdate", TextCompositionManager.TextInputUpdateEvent.Name);
			Assert.AreEqual ("TextCompositionManager.TextInputUpdate", TextCompositionManager.TextInputUpdateEvent.ToString());
			Assert.AreEqual (typeof (TextCompositionEventHandler), TextCompositionManager.TextInputUpdateEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, TextCompositionManager.TextInputUpdateEvent.RoutingStrategy);

			Assert.AreEqual (typeof (TextCompositionManager), TextCompositionManager.PreviewTextInputEvent.OwnerType);
			Assert.AreEqual ("PreviewTextInput", TextCompositionManager.PreviewTextInputEvent.Name);
			Assert.AreEqual ("TextCompositionManager.PreviewTextInput", TextCompositionManager.PreviewTextInputEvent.ToString());
			Assert.AreEqual (typeof (TextCompositionEventHandler), TextCompositionManager.PreviewTextInputEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, TextCompositionManager.PreviewTextInputEvent.RoutingStrategy);

			Assert.AreEqual (typeof (TextCompositionManager), TextCompositionManager.TextInputEvent.OwnerType);
			Assert.AreEqual ("TextInput", TextCompositionManager.TextInputEvent.Name);
			Assert.AreEqual ("TextCompositionManager.TextInput", TextCompositionManager.TextInputEvent.ToString());
			Assert.AreEqual (typeof (TextCompositionEventHandler), TextCompositionManager.TextInputEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, TextCompositionManager.TextInputEvent.RoutingStrategy);
		}
	}

}