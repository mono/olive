//
// DependencyObject.cs
//
// Author:
//   Iain McCoy (iain@mccoy.id.au)
//   Miguel de Icaza (miguel@novell.com)
//
// Copyright 2005 Iain McCoy
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
using System.Collections.Generic;

namespace System.Windows {
	public class DependencyObject {
		string name;
		private static Dictionary<Type,Dictionary<string,DependencyProperty>> property_declarations =
			new Dictionary<Type,Dictionary<string,DependencyProperty>>();
		
		public virtual object GetValue(DependencyProperty dp)
		{
			throw new NotImplementedException ();
		}

		public void SetValue<T>(DependencyProperty dp, T value)
		{
			throw new NotImplementedException ();
		}

		public DependencyObject FindName (string name)
		{
			throw new NotImplementedException ();			
		}

		public string Name {
			get {
				return name;
			}
		}

		internal static void Register (Type t, DependencyProperty dp)
                {
			Dictionary<string,DependencyProperty> type_declarations;
			
			if (!property_declarations.TryGetValue (t, out type_declarations)){
				property_declarations [t] = new Dictionary<string,DependencyProperty>();
			}

			Console.WriteLine ("This code is not bound to unmanaged code");
			return;
			
			if (!type_declarations.ContainsKey (dp.Name))
				type_declarations [dp.Name] = dp;
			else
				throw new Exception("A property named " + dp.Name + " already exists on " + t.Name);
                }
	}
}
