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

using System.ComponentModel;
using System.Windows.Markup;
using System.Windows.Threading;

namespace System.Windows {

	[ContentProperty ("VisualTree")]
	public class FrameworkTemplate : DispatcherObject, INameScope {
		protected FrameworkTemplate ()
		{
		}

		[EditorBrowsable (EditorBrowsableState.Advanced)]
		public bool ShouldSerializeVisualTree ()
		{
			throw new NotImplementedException ();
		}

		[EditorBrowsable (EditorBrowsableState.Advanced)]
		public bool ShouldSerializeResources (XamlDesignerSerializationManager manager)
		{
			throw new NotImplementedException ();
		}

		public void RegisterName (string name, object scopedElement)
		{
			throw new NotImplementedException ();
		}

		public void UnregisterName (string name)
		{
			throw new NotImplementedException ();
		}

		public void Seal ()
		{
			throw new NotImplementedException ();
		}

		protected virtual void ValidateTemplatedParent (FrameworkElement templatedParent)
		{
			throw new NotImplementedException ();
		}

		public DependencyObject LoadContent ()
		{
			throw new NotImplementedException ();
		}

		public object FindName (string name, FrameworkElement templatedParent)
		{
			throw new NotImplementedException ();
		}

		object INameScope.FindName (string name)
		{
			throw new NotImplementedException ();
		}

#if notyet
		public FrameworkElementFactory VisualTree {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}
#endif

		public bool HasContent {
			get { throw new NotImplementedException (); }
		}

		public bool IsSealed {
			get { throw new NotImplementedException (); }
		}

#if notyet
		[DesignerSerializationVisibility (DesignerSerializationVisibility.Content)]
		public ResourceDictionary Resources {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}
#endif
	}

}