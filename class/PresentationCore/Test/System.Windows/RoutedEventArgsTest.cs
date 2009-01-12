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
	public class RoutedEventArgsTest {

		delegate void SourceChangedEventHandler (object source, SourceChangedEventArgs args);
		class SourceChangedEventArgs : EventArgs {
			public object SourceArg;
		}

		class Poker : RoutedEventArgs {
			public Poker (RoutedEvent routedEvent, object source)
				: base (routedEvent, source)
			{
			}

			public void InvokeHandler (Delegate genericHandler, object genericTarget)
			{
				base.InvokeEventHandler (genericHandler, genericTarget);
			}

			protected override void OnSetSource (object source)
			{
				if (OnSetSourceCalled != null) {
					SourceChangedEventArgs args = new SourceChangedEventArgs ();

					args.SourceArg = source;

					OnSetSourceCalled (this, args);
				}
				base.OnSetSource (source);
			}

			public event SourceChangedEventHandler OnSetSourceCalled;
		}

		[Test]
		public void NullCtorTest_routedEvent ()
		{
			new RoutedEventArgs (null, new object());
			// succeeds
		}

		[Test]
		public void NullCtorTest_source ()
		{
			new RoutedEventArgs (ContentElement.DragEnterEvent, null);
			// succeeds
		}

		[Test]
		public void TestSource ()
		{
			object source1 = new object();
			object source2 = new object();

			Poker p = new Poker (ContentElement.DragEnterEvent, source1);

			Assert.AreSame (source1, p.Source);
			Assert.AreSame (source1, p.OriginalSource);

			p.OnSetSourceCalled += delegate (object source, SourceChangedEventArgs e) {
				Assert.AreSame (source2, p.Source);
			};

			p.Source = source2;

			Assert.AreSame (source1, p.OriginalSource);
		}

		[Test]
		public void TestSetSourceNull ()
		{
			object source = new object();

			Poker p = new Poker (ContentElement.DragEnterEvent, source);

			p.Source = null;

			Assert.IsNull (p.Source);
			Assert.AreSame (source, p.OriginalSource);
		}

		void invalidDelegateType (object sender, DragEventArgs args)
		{
		}

		object _this;
		object _sender;
		EventArgs _args;

		void validDelegateType (object sender, RoutedEventArgs args)
		{
			_this = this;
			_sender = sender;
			_args = args;
		}

		void baseDelegateType (object sender, RoutedEventArgs args)
		{
			_this = this;
			_sender = sender;
			_args = args;
		}

		[Test]
		[ExpectedException (typeof (ArgumentNullException))]
		public void InvokeHandler_nullDelegate ()
		{
			Poker p = new Poker (ContentElement.DragEnterEvent, new object());

			p.InvokeHandler (null, new object());
		}

		[Test]
		[ExpectedException (typeof (ArgumentNullException))]
		public void InvokeHandler_nullTarget ()
		{
			Poker p = new Poker (ContentElement.DragEnterEvent, new object ());

			p.InvokeHandler ((Delegate)new RoutedEventHandler(validDelegateType), null);
		}

		[Test]
		[ExpectedException (typeof (ArgumentException))]
		public void InvokeHandler_invalidTypeDelegate ()
		{
			Poker p = new Poker (ContentElement.DragEnterEvent, new object());

			p.InvokeHandler ((Delegate)new DragEventHandler(invalidDelegateType), new object());
		}

		[Test]
		public void InvokeHandler_baseTypeDelegate ()
		{
			_this = _sender = _args = null;

			Poker p = new Poker (ContentElement.DragEnterEvent, new object());
			object target = new Object();

			p.InvokeHandler ((Delegate)new DragEventHandler(baseDelegateType), target);

			Assert.AreSame (this, _this, "1");
			Assert.AreSame (target, _sender, "2");
			Assert.AreEqual (p, _args, "3");
		}

		[Test]
		public void InvokeHandler_validTarget ()
		{
			_this = _sender = _args = null;

			Poker p = new Poker (ContentElement.DragEnterEvent, new object ());
			object target = new Object ();

			p.InvokeHandler ((Delegate)new RoutedEventHandler(validDelegateType), target);

			Assert.AreSame (this, _this, "1");
			Assert.AreSame (target, _sender, "2");
			Assert.AreEqual (p, _args, "3");
		}

		[Test]
		public void OriginalSource ()
		{
			RoutedEventArgs re;
			object source1 = new object();
			object source2 = new object();
			
			re = new RoutedEventArgs (ContentElement.DragEnterEvent, source1);
			Assert.AreSame (source1, re.OriginalSource, "4");
			Assert.AreSame (source1, re.Source, "5");
			re.Source = source2;
			Assert.AreSame (source1, re.OriginalSource, "6");

			re = new RoutedEventArgs ();
			Assert.IsNull (re.OriginalSource, "1");
			Assert.IsNull (re.Source, "2");
			re.Source = source1;
			Assert.IsNull (re.OriginalSource, "3");
		}
	}
}
