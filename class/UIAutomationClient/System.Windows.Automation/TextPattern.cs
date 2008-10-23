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
//      Brad Taylor <brad@getcoded.net>
// 

using System;
using System.Windows.Automation.Text;

namespace System.Windows.Automation
{
	public class TextPattern : BasePattern
	{
#region Constructor
		private TextPattern ()
		{
		}
#endregion

#region Public Methods
		public TextPatternRange[] GetSelection ()
		{
			throw new NotImplementedException ();
		}

		public TextPatternRange[] GetVisibleRanges ()
		{
			throw new NotImplementedException ();
		}

		public TextPatternRange RangeFromChild (AutomationElement childElement)
		{
			throw new NotImplementedException ();
		}

		public TextPatternRange RangeFromPoint (Point screenLocation)
		{
			throw new NotImplementedException ();
		}
#endregion
		
#region Public Fields
		public static readonly AutomationTextAttribute AnimationStyleAttribute;

		public static readonly AutomationTextAttribute BackgroundColorAttribute;

		public static readonly AutomationTextAttribute BulletStyleAttribute;

		public static readonly AutomationTextAttribute CapStyleAttribute;

		public static readonly AutomationTextAttribute CultureAttribute;

		public static readonly AutomationTextAttribute FontNameAttribute;

		public static readonly AutomationTextAttribute FontSizeAttribute;

		public static readonly AutomationTextAttribute FontWeightAttribute;

		public static readonly AutomationTextAttribute ForegroundColorAttribute;

		public static readonly AutomationTextAttribute HorizontalTextAlignmentAttribute;

		public static readonly AutomationTextAttribute IndentationFirstLineAttribute;

		public static readonly AutomationTextAttribute IndentationLeadingAttribute;

		public static readonly AutomationTextAttribute IndentationTrailingAttribute;

		public static readonly AutomationTextAttribute IsHiddenAttribute;

		public static readonly AutomationTextAttribute IsItalicAttribute;

		public static readonly AutomationTextAttribute IsReadOnlyAttribute;

		public static readonly AutomationTextAttribute IsSubscriptAttribute;

		public static readonly AutomationTextAttribute IsSuperscriptAttribute;

		public static readonly AutomationTextAttribute MarginBottomAttribute;

		public static readonly AutomationTextAttribute MarginLeadingAttribute;

		public static readonly AutomationTextAttribute MarginTopAttribute;

		public static readonly AutomationTextAttribute MarginTrailingAttribute;

		public static readonly Object MixedAttributeValue;

		public static readonly AutomationTextAttribute OutlineStylesAttribute;

		public static readonly AutomationTextAttribute OverlineColorAttribute;

		public static readonly AutomationTextAttribute OverlineStyleAttribute;

		public static readonly AutomationPattern Pattern;
		
		public static readonly AutomationTextAttribute StrikethroughColorAttribute;

		public static readonly AutomationTextAttribute StrikethroughStyleAttribute;

		public static readonly AutomationTextAttribute TabsAttribute;

		public static readonly AutomationEvent TextChangedEvent;

		public static readonly AutomationTextAttribute TextFlowDirectionsAttribute;
		
		public static readonly AutomationEvent TextSelectionChangedEvent;

		public static readonly AutomationTextAttribute UnderlineColorAttribute;

		public static readonly AutomationTextAttribute UnderlineStyleAttribute;
#endregion
	}
}
