//
// FaultConverter.cs
//
// Author:
//	Atsushi Enomoto <atsushi@ximian.com>
//
// Copyright (C) 2006 Novell, Inc.  http://www.novell.com
//
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
using System;
using System.Collections.Generic;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace System.ServiceModel.Channels
{
	[MonoTODO]
	public abstract class FaultConverter
	{
		static FaultConverter soap12 = new Soap12FaultConverter ();
		static FaultConverter soap11 = new Soap11FaultConverter ();

		public static FaultConverter GetDefaultFaultConverter (MessageVersion version)
		{
			if (version == null)
				throw new ArgumentNullException ("version");
			return version.Envelope == EnvelopeVersion.Soap11 ? soap11 : soap12;
		}

		protected FaultConverter ()
		{
		}

		protected abstract bool OnTryCreateException (
			Message message, MessageFault fault, out Exception error);

		protected abstract bool OnTryCreateFaultMessage (
			Exception error, out Message message);

		public bool TryCreateException (Message message, MessageFault fault, out Exception error)
		{
			return OnTryCreateException (message, fault, out error);
		}

		public bool TryCreateFaultMessage (Exception error, out Message message)
		{
			return OnTryCreateFaultMessage (error, out message);
		}

		class Soap12FaultConverter : FaultConverter
		{
			public Soap12FaultConverter ()
			{
			}

			protected override bool OnTryCreateException (
				Message message, MessageFault fault, out Exception error)
			{
				error = null;
				return false;
			}

			protected override bool OnTryCreateFaultMessage (
				Exception error, out Message message)
			{
				message = null;
				return false;
			}
		}

		class Soap11FaultConverter : FaultConverter
		{
			public Soap11FaultConverter ()
			{
			}

			protected override bool OnTryCreateException (
				Message message, MessageFault fault, out Exception error)
			{
				error = null;
				return false;
			}

			protected override bool OnTryCreateFaultMessage (
				Exception error, out Message message)
			{
				message = null;
				return false;
			}
		}
	}
}
