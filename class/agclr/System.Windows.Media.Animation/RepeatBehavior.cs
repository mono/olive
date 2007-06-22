//
// RepeatBehavior.cs
//
// Author:
//   Miguel de Icaza (miguel@novell.com)
//
// Copyright 2007 Novell, Inc.
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
namespace System.Windows.Media.Animation {

	public struct RepeatBehavior {
		const int DOUBLE = 1;
		const int TIMESPAN = 2;

		int kind;
		double count;
		TimeSpan duration;

		internal RepeatBehavior (int kind, double count, TimeSpan duration)
		{
			this.kind = kind;
			this.count = count;
			this.duration = duration;
		}

		public RepeatBehavior (double count)
		{
			kind = DOUBLE;
			this.count = count;
			duration = new TimeSpan (0);
		}

		public RepeatBehavior (TimeSpan duration)
		{
			kind = TIMESPAN;
			this.duration = duration;
			count = 0;
		}

		public double Count {
			get {
				if (kind == DOUBLE)
					return count;
				throw new Exception ("This RepeatBehavior does not contain a Count");
			}
		}

		public TimeSpan Duration {
			get {
				if (kind == TIMESPAN)
					return duration;
				throw new Exception ("This RepeatBehavior does not contain a Duration");
			}
		}

		public bool HasCount {
			get {
				return kind == DOUBLE;
			}
		}

		public bool HasDuration {
			get {
				return kind == TIMESPAN;
			}
		}
	}

}
