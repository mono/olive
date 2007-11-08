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

	class ArgsPoker : InputEventArgs {
		public ArgsPoker (InputDevice device, int timestamp)
			: base (device, timestamp)
		{
		}

		public void DoInvokeEventHandler (Delegate genericDelegate, object target)
		{
			base.InvokeEventHandler (genericDelegate, target);
		}
	}

	[TestFixture]
	public class InputEventArgsTest {

		[Test]
		public void CtorNullDevice ()
		{
			InputEventArgs e = new InputEventArgs (null, 1000);
		}

		[Test]
		public void CtorNegativeTimestamp ()
		{
			InputEventArgs e = new InputEventArgs (Keyboard.PrimaryDevice, -1);
		}

		bool delegate_reached;
		object delegate_sender;
		InputEventArgs delegate_args;
		public void input_delegate (object sender, InputEventArgs e)
		{
			delegate_reached = true;
			delegate_sender = sender;
			delegate_args = e;
		}

		[Test]
		public void TestInvokeEventHandler ()
		{
			ArgsPoker e = new ArgsPoker (Keyboard.PrimaryDevice, 0);
			object test_obj = new object ();

			e.DoInvokeEventHandler (Delegate.CreateDelegate (typeof (InputEventHandler), this, "input_delegate"), test_obj);

			Assert.IsTrue (delegate_reached);
			Assert.AreEqual (test_obj, delegate_sender);
			Assert.AreEqual (e, delegate_args);
		}
	}
}
