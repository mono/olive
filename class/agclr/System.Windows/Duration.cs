//
// Duration.cs
//
// This class implementation is not very complete, nor has it been
// tested, this is here just so we can get other things elsewhere
// to compile and run for now
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
using Mono;
using System;

namespace System.Windows {
	public struct Duration  {
		const int TIMESPAN = 1;
		const int AUTOMATIC = 2;
		const int FOREVER = 3;
		int kind;
		TimeSpan time_span;

		static Duration automatic = new Duration (AUTOMATIC);
		static Duration forever = new Duration (FOREVER);
		
		internal Duration (int k)
		{
			kind = k;
			time_span = new TimeSpan (0);
		}
		
		public Duration (TimeSpan timeSpan)
		{
			time_span = timeSpan;
			kind = TIMESPAN;
		}

		public static bool Equals (Duration t1, Duration t2)
		{
			if (t1.kind == TIMESPAN && t2.kind == TIMESPAN){
				return t1.time_span == t2.time_span;
			}
			return t1.kind == t2.kind;
		}
		
		public override bool Equals (object o)
		{
			if (!(o is Duration))
				return false;

			return Equals (this, (Duration) o);
		}
		
		public bool Equals (Duration value)
		{
			return Equals (this, value);
		}

		public static int Compare (Duration t1, Duration t2)
		{
			if (t1.kind == t2.kind && t1.kind == TIMESPAN)
				return TimeSpan.Compare (t1.time_span, t2.time_span);
			return (int) t1.kind - (int) t2.kind;
		}
			
		public override int GetHashCode ()
		{
			if (kind == TIMESPAN)
				return time_span.GetHashCode ();
			else
				return (int) kind;
		}

		public Duration Add (Duration duration)
		{
			if (kind == duration.kind && kind == TIMESPAN)
				return new Duration (time_span.Add (duration.time_span));
			return this;
		}

		public Duration Substract (Duration duration)
		{
			if (kind == duration.kind && kind == TIMESPAN)
				return new Duration (time_span.Add (duration.time_span));
			return this;
		}

		public override string ToString ()
		{
			return kind == TIMESPAN ? time_span.ToString () : (kind == AUTOMATIC ? "automatic" : "forever");
		}

		public static implicit operator Duration (TimeSpan timeSpan)
		{
			return new Duration (timeSpan);
		}
		
		public static Duration operator + (Duration t1, Duration t2)
		{
			return t1.Add (t2);
		}
		
		public static Duration operator - (Duration t1, Duration t2)
		{
			return t1.Substract (t2);
		}
		
		public static bool operator == (Duration t1, Duration t2)
		{
			if (t1.kind == TIMESPAN && t2.kind == TIMESPAN){
				return t1.time_span == t2.time_span;
			}
			return t1.kind == t2.kind;
		}
		
		public static bool operator != (Duration t1, Duration t2)
		{
			if (t1.kind != t2.kind)
				return true;
			if (t1.kind == TIMESPAN)
				return t1.time_span != t2.time_span;
			return false;
		}
		
		public static bool operator > (Duration t1, Duration t2)
		{
			throw new NotImplementedException ();
		}
		
		public static bool operator >= (Duration t1, Duration t2)
		{
			throw new NotImplementedException ();
		}
		
		public static bool operator < (Duration t1, Duration t2)
		{
			throw new NotImplementedException ();
		}
		
		public static bool operator <= (Duration t1, Duration t2)
		{
			throw new NotImplementedException ();
		}
		
		public static Duration operator + (Duration duration)
		{
			throw new NotImplementedException ();
		}

		public static Duration Automatic {
			get { return automatic; }
		}
		
		public static Duration Forever {
			get { return forever; } 
		}

		public bool HasTimeSpan {
			get {
				return (kind == TIMESPAN);
			}
		}
		public TimeSpan TimeSpan {
			get {
				if (kind == TIMESPAN)
					return time_span;
				throw new Exception ("This is not a TimeSpan duration");
			}
		}
	}
}
