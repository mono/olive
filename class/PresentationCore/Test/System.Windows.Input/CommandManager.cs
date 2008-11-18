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
	public class CommandManagerTest {

		[Test]
		public void RoutedEvents ()
		{
			Assert.AreEqual (typeof (CommandManager), CommandManager.PreviewExecutedEvent.OwnerType);
			Assert.AreEqual ("PreviewExecuted", CommandManager.PreviewExecutedEvent.Name);
			Assert.AreEqual ("CommandManager.PreviewExecuted", CommandManager.PreviewExecutedEvent.ToString());
			Assert.AreEqual (typeof (ExecutedRoutedEventHandler), CommandManager.PreviewExecutedEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, CommandManager.PreviewExecutedEvent.RoutingStrategy);

			Assert.AreEqual (typeof (CommandManager), CommandManager.ExecutedEvent.OwnerType);
			Assert.AreEqual ("Executed", CommandManager.ExecutedEvent.Name);
			Assert.AreEqual ("CommandManager.Executed", CommandManager.ExecutedEvent.ToString());
			Assert.AreEqual (typeof (ExecutedRoutedEventHandler), CommandManager.ExecutedEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, CommandManager.ExecutedEvent.RoutingStrategy);

			Assert.AreEqual (typeof (CommandManager), CommandManager.PreviewCanExecuteEvent.OwnerType);
			Assert.AreEqual ("PreviewCanExecute", CommandManager.PreviewCanExecuteEvent.Name);
			Assert.AreEqual ("CommandManager.PreviewCanExecute", CommandManager.PreviewCanExecuteEvent.ToString());
			Assert.AreEqual (typeof (CanExecuteRoutedEventHandler), CommandManager.PreviewCanExecuteEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Tunnel, CommandManager.PreviewCanExecuteEvent.RoutingStrategy);

			Assert.AreEqual (typeof (CommandManager), CommandManager.CanExecuteEvent.OwnerType);
			Assert.AreEqual ("CanExecute", CommandManager.CanExecuteEvent.Name);
			Assert.AreEqual ("CommandManager.CanExecute", CommandManager.CanExecuteEvent.ToString());
			Assert.AreEqual (typeof (CanExecuteRoutedEventHandler), CommandManager.CanExecuteEvent.HandlerType);
			Assert.AreEqual (RoutingStrategy.Bubble, CommandManager.CanExecuteEvent.RoutingStrategy);
		}
	}

}