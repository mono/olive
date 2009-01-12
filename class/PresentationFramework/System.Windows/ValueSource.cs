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
// Author:
//	Chris Toshok (toshok@ximian.com)
//

namespace System.Windows {

	public struct ValueSource {

		internal ValueSource (bool isAnimated,
				      bool isCoerced,
				      bool isExpression,
				      BaseValueSource baseValueSource)
		{
			this.isAnimated = isAnimated;
			this.isCoerced = isCoerced;
			this.isExpression = isExpression;
			this.baseValueSource = baseValueSource;
		}

		public static bool operator == (ValueSource vs1, ValueSource vs2)
		{
			return (vs1.IsAnimated == vs2.IsAnimated &&
				vs1.IsCoerced == vs2.IsCoerced &&
				vs1.IsExpression == vs2.IsExpression &&
				vs1.BaseValueSource == vs2.BaseValueSource);
		}

		public static bool operator != (ValueSource vs1, ValueSource vs2)
		{
			return !(vs1 == vs2);
		}

		public override bool Equals (object o)
		{
			return (o is ValueSource) && ((ValueSource)o) == this;
		}

		public override int GetHashCode ()
		{
			return (IsAnimated ? 1 : 2) ^ (IsCoerced ? 1 : 2) ^ (IsExpression ? 1 : 2) ^ (int)BaseValueSource;
		}

		public bool IsAnimated {
			get { return isAnimated; }
			internal set { isAnimated = value; }
		}

		public bool IsCoerced {
			get { return isCoerced; }
			internal set { isCoerced = value; }
		}

		public bool IsExpression {
			get { return isExpression; }
			internal set { isExpression = value; }
		}

		public BaseValueSource BaseValueSource {
			get { return baseValueSource; }
			internal set { baseValueSource = value; }
		}

		bool isAnimated;
		bool isCoerced;
		bool isExpression;
		BaseValueSource baseValueSource;
	}

}