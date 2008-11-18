//
// RoutedEvent.cs
//
// Author:
//   Iain McCoy (iain@mccoy.id.au)
//   Chris Toshok (toshok@ximian.com)
//
// (C) 2005 Iain McCoy
// (C) 2007-2008 Novell, Inc.
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

namespace System.Windows {
	public sealed class RoutedEvent {

		internal RoutedEvent (string name,
				      Type handlerType,
				      Type ownerType,
				      RoutingStrategy routingStrategy)
		{
			this.name = name;
			this.handlerType = handlerType;
			this.ownerType = ownerType;
			this.routingStrategy = routingStrategy;
		}

		public RoutedEvent AddOwner (Type ownerType)
		{
			// XXX more here
			return this;
		}

		public override string ToString ()
		{
			return string.Format("{0}.{1}", OwnerType.Name, name);
		}

		public Type HandlerType {
			get { return handlerType; }
		}

		public string Name {
			get { return name; }
		}

		public Type OwnerType {
			get { return ownerType; }
		}

		public RoutingStrategy RoutingStrategy {
			get { return routingStrategy; }
		}

		string name;
		Type handlerType;
		Type ownerType;
		RoutingStrategy routingStrategy;
	}
}
