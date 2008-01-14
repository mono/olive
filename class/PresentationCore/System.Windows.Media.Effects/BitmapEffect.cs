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
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Media.Animation;
#if notyet
using System.Windows.Media.Imaging;
#endif

namespace System.Windows.Media.Effects {

	public abstract class BitmapEffect : Animatable {

		protected BitmapEffect ()
		{
			throw new NotImplementedException ();
		}

		public BitmapEffect Clone ()
		{
			throw new NotImplementedException ();
		}

		public BitmapEffect CloneCurrentValue ()
		{
			throw new NotImplementedException ();
		}

#if notyet
		public BitmapSource GetOutput (BitmapEffectInput input)
		{
			throw new NotImplementedException ();
		}
#endif

		[SecurityTreatAsSafe]
		[SecurityCritical]
		protected static SafeHandle CreateBitmapEffectOuter()
		{
			throw new NotImplementedException ();
		}
		
		[SecurityTreatAsSafe]
		[SecurityCritical]
		protected static void InitializeBitmapEffect (SafeHandle outerObject, SafeHandle innerObject)
		{
			throw new NotImplementedException ();
		}

		[SecurityTreatAsSafe]
		[SecurityCritical]
		protected static void SetValue (SafeHandle effect, string propertyName, object value)
		{
			throw new NotImplementedException ();
		}

		protected abstract SafeHandle CreateUnmanagedEffect();
		protected abstract void UpdateUnmanagedPropertyState (SafeHandle unmanagedEffect);
	}
}

