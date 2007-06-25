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

using System.Windows;
using System.ComponentModel;

namespace System.Windows {

	//[TypeConverterAttribute(typeof(DurationConverter))] 
	public struct Duration {

		internal enum DurationType {
			Timespan,
			Automatic,
			Forever
		}

		TimeSpan timeSpan;
		DurationType durationType;

		public Duration (TimeSpan timeSpan)
		{
			this.durationType = DurationType.Timespan;
			this.timeSpan = timeSpan;
		}

		internal Duration (DurationType t)
		{
			this.durationType = t;
			timeSpan = TimeSpan.Zero;
		}

		public Duration Add (Duration duration)
		{
			if (duration.IsForever || this.IsForever)
				return new Duration (DurationType.Forever);
			else if (duration.IsAutomatic || this.IsAutomatic)
				return new Duration (DurationType.Automatic);
			else
				return new Duration (timeSpan + duration.timeSpan);
		}

		public static int Compare (Duration t1,
					   Duration t2)
		{
			if (t1.durationType == DurationType.Forever) {
				return (t2.durationType == DurationType.Forever ? 0 : -1);
			}
			else if (t1.durationType == DurationType.Automatic) {
			}
			else if (t1.durationType == DurationType.Timespan) {
				
			}
			

			switch (t1.durationType) {
			case DurationType.Forever:
			case DurationType.Automatic:
			case DurationType.Timespan:
				break;
			}

			if (t1.IsForever && t2.IsForever)
				return 0;
			else if (t1.IsAutomatic && t2.IsAutomatic)
				return 0;
			else
				return (int)(t2.TimeSpan - t1.TimeSpan).Ticks;
		}

		public bool Equals (Duration duration)
		{
			throw new NotImplementedException ();
		}

		public override bool Equals (Object value)
		{
			throw new NotImplementedException ();
		}

		public static bool Equals (Duration t1,
					   Duration t2)
		{
			throw new NotImplementedException ();
		}

		public override int GetHashCode ()
		{
			throw new NotImplementedException ();
		}

		public static Duration Plus (Duration duration)
		{
			throw new NotImplementedException ();
		}

		public Duration Subtract (Duration duration)
		{
			if (duration.IsForever || this.IsForever)
				return new Duration (DurationType.Forever);
			else if (duration.IsAutomatic || this.IsAutomatic)
				return new Duration (DurationType.Automatic);
			else
				return new Duration (timeSpan - duration.timeSpan);
		}

		public override string ToString ()
		{
			throw new NotImplementedException ();
		}

		public static implicit operator Duration (TimeSpan timeSpan)
		{
			return new Duration (timeSpan);
		}

		public static Duration operator + (Duration t1,
						   Duration t2)
		{
			return t1.Add (t2);
		}

		public static bool operator == (Duration t1,
						Duration t2)
		{
			return t1.Equals (t2);
		}

		public static bool operator > (Duration t1,
					       Duration t2)
		{
			return Compare (t1, t2) > 0;
		}

		public static bool operator >= (Duration t1,
						Duration t2)
		{
			return Compare (t1, t2) >= 0;
		}

		public static bool operator != (Duration t1,
						Duration t2)
		{
			return !t1.Equals (t2);
		}

		public static bool operator < (Duration t1,
					       Duration t2)
		{
			return Compare (t1, t2) < 0;
		}

		public static bool operator <= (Duration t1,
						Duration t2)
		{
			return Compare (t1, t2) <= 0;
		}

		public static Duration operator - (Duration t1,
						   Duration t2)
		{
			return t1.Subtract (t2);
		}

		public static Duration operator + (Duration duration)
		{
			throw new NotImplementedException ();
		}

		public static Duration Automatic {
			get {
				return new Duration (DurationType.Automatic);
			}
		}

		internal bool IsAutomatic {
			get {
				return durationType == DurationType.Automatic;
			}
		}

		public static Duration Forever {
			get {
				return new Duration (DurationType.Forever);
			}
		}

		internal bool IsForever {
			get {
				return durationType == DurationType.Forever;
			}
		}

		public bool HasTimeSpan {
			get {
				return durationType == DurationType.Timespan;
			}
		}

		public TimeSpan TimeSpan {
			get {
				return timeSpan;
			}
		}
	}

}


