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

using System.Collections;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace System.Windows {

	public class FrameworkElement : UIElement, ISupportInitialize, IFrameworkInputElement {

		public bool ApplyTemplate ()
		{
			throw new NotImplementedException ();
		}

		public virtual bool MoveFocus (TraversalRequest request)
		{
			throw new NotImplementedException ();
		}

		[EditorBrowsable (EditorBrowsableState.Advanced)]
		public bool ShouldSerializeResources ()
		{
			throw new NotImplementedException ();
		}

		[EditorBrowsable (EditorBrowsableState.Advanced)]
		public bool ShouldSerializeStyle ()
		{
			throw new NotImplementedException ();
		}

		[EditorBrowsable (EditorBrowsableState.Advanced)]
		public bool ShouldSerializeTriggers ()
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

		public object FindName (string name)
		{
			throw new NotImplementedException ();
		}

		public object FindResource (object resourceKey)
		{
			throw new NotImplementedException ();
		}

		public object TryFindResource (object resourceKey)
		{
			throw new NotImplementedException ();
		}

		protected void AddLogicalChild (object child)
		{
			throw new NotImplementedException ();
		}

		protected void RemoveLogicalChild (object child)
		{
			throw new NotImplementedException ();
		}

		public void BeginInit ()
		{
			throw new NotImplementedException ();
		}

		public void EndInit ()
		{
			throw new NotImplementedException ();
		}

		public void BeginStoryboard (Storyboard storyboard, HandoffBehavior handoffBehavior, bool isControllable)
		{
			throw new NotImplementedException ();
		}

		public void BeginStoryboard (Storyboard storyboard, HandoffBehavior handoffBehavior)
		{
			throw new NotImplementedException ();
		}

		public void BeginStoryboard (Storyboard storyboard)
		{
			throw new NotImplementedException ();
		}
		public void BringIntoView ()
		{
			throw new NotImplementedException ();
		}

		public void BringIntoView (Rect targetRectangle)
		{
			throw new NotImplementedException ();
		}

		public virtual void OnApplyTemplate ()
		{
			throw new NotImplementedException ();
		}

		protected virtual void OnContextMenuOpening (ContextMenuEventArgs args)
		{
			throw new NotImplementedException ();
		}

		protected virtual void OnContextMenuClosing (ContextMenuEventArgs args)
		{
			throw new NotImplementedException ();
		}

		protected override void OnGotFocus (RoutedEventArgs e)
		{
			throw new NotImplementedException ();
		}

		protected virtual void OnInitialized (EventArgs e)
		{
			throw new NotImplementedException (); 
		}

		protected override void OnPropertyChanged (DependencyPropertyChangedEventArgs e)
		{
			throw new NotImplementedException ();
		}

		protected override void OnRenderSizeChanged (SizeChangedInfo sizeInfo)
		{
			throw new NotImplementedException ();
		}

#if notyet
		protected virtual void OnStyleChanged (Style oldStyle, Style newStyle)
		{
			throw new NotImplementedException ();
		}

		protected virtual void OnToolTipOpening (ToolTipEventArgs e)
		{
			throw new NotImplementedException ();
		}

		protected virtual void OnToolTipClosing (ToolTipEventArgs e)
		{
			throw new NotImplementedException ();
		}
#endif

		protected virtual void ParentLayoutInvalidated (UIElement child)
		{
			throw new NotImplementedException ();
		}

		public void SetResourceReference (DependencyProperty dp, object name)
		{
			throw new NotImplementedException ();
		}

#if notyet
		public BindingExpression GetBindingExpression (DependencyProperty dp)
		{
			throw new NotImplementedException ();
		}

		public BindingExpression SetBinding (DependencyProperty dp, string path)
		{
			throw new NotImplementedException ();
		}

		public BindingExpressionBase SetBinding (DependencyProperty dp, BindingBase binding)
		{
			throw new NotImplementedException ();
		}
#endif

		protected DependencyObject GetTemplateChild (string childName)
		{
			throw new NotImplementedException ();
		}

		protected override DependencyObject GetUIParentCore ()
		{
			throw new NotImplementedException ();
		}

		public override DependencyObject PredictFocus (FocusNavigationDirection direction)
		{
			throw new NotImplementedException ();
		}

		protected override Geometry GetLayoutClip (Size layoutSlotSize)
		{
			throw new NotImplementedException ();
		}

		protected override void OnVisualParentChanged (DependencyObject oldParent)
		{
			throw new NotImplementedException ();
		}

		protected override Visual GetVisualChild (int index)
		{
			throw new NotImplementedException ();
		}

		protected override int VisualChildrenCount {
			get { throw new NotImplementedException (); }
		}

		protected override void ArrangeCore (Rect finalRect)
		{
			throw new NotImplementedException ();
		}

		protected virtual Size ArrangeOverride (Size arrangeBounds)
		{
			throw new NotImplementedException ();
		}

		protected override Size MeasureCore (Size constraint)
		{
			throw new NotImplementedException ();
		}

		protected virtual Size MeasureOverride (Size constraint)
		{
			throw new NotImplementedException ();
		}

		protected internal virtual IEnumerator LogicalChildren {
			get { throw new NotImplementedException (); }
		}

		public DependencyObject Parent {
			get { throw new NotImplementedException (); }
		}

		public DependencyObject TemplatedParent {
			get { throw new NotImplementedException (); }
		}
			
		public static readonly DependencyProperty ActualHeightProperty;
		public double ActualHeight {
		    get { return (double)GetValue (ActualHeightProperty); }
		    private set { SetValue (ActualHeightProperty, value); }
		}

		public static readonly DependencyProperty ActualWidthProperty;
		public double ActualWidth {
		    get { return (double)GetValue (ActualWidthProperty); }
		    private set { SetValue (ActualWidthProperty, value); }
		}
		
#if notyet
		public static readonly DependencyProperty BindingGroupProperty;
		public BindingGroup BindingGroup {
		    get { return (BindingGroup)GetValue (BindingGroupProperty); }
		    set { SetValue (BindingGroupProperty, value); }
		}

		public static readonly DependencyProperty ContextMenuProperty;
		public ContextMenu ContextMenu {
		    get { return (ContextMenu)GetValue (ContextMenuProperty); }
		    set { SetValue (ContextMenuProperty, value); }
		}
#endif
		
		public static readonly DependencyProperty CursorProperty;
		public Cursor Cursor {
		    get { return (Cursor)GetValue (CursorProperty); }
		    set { SetValue (CursorProperty, value); }
		}

		public static readonly DependencyProperty DataContextProperty;

		[DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)]
		[Localizability (LocalizationCategory.NeverLocalize)]
		public object DataContext {
		    get { return (object)GetValue (DataContextProperty); }
		    set { SetValue (DataContextProperty, value); }
		}

		protected static readonly DependencyProperty DefaultStyleKeyProperty;
		protected object DefaultStyleKey {
		    get { return (object)GetValue (DefaultStyleKeyProperty); }
		    set { SetValue (DefaultStyleKeyProperty, value); }
		}

		public static readonly DependencyProperty NameProperty;

		[MergableProperty (false)]
		[Localizability (LocalizationCategory.NeverLocalize)]
		public string Name {
		    get { return (string)GetValue (NameProperty); }
		    set { SetValue (NameProperty, value); }
		}

		public static readonly DependencyProperty MarginProperty;
		public Thickness Margin {
		    get { return (Thickness)GetValue (MarginProperty); }
		    set { SetValue (MarginProperty, value); }
		}
		
		public static readonly RoutedEvent ContextMenuClosingEvent /* XXX = */ ;
#if notyet
		public event ContextMenuEventHandler ContextMenuClosing {
		    add { AddHandler (ContextMenuClosingEvent, value}; }
		    remove { RemoveHandler (ContextMenuClosingEvent, value); }
		}
#endif

		public static readonly RoutedEvent ContextMenuOpeningEvent /* XXX = */ ;
#if notyet
		public event ContextMenuEventHandler ContextMenuOpening {
		    add { AddHandler (ContextMenuOpeningEvent, value}; }
		    remove { RemoveHandler (ContextMenuOpeningEvent, value); }
		}
#endif

		public static readonly DependencyProperty HeightProperty;

		[TypeConverter (typeof (LengthConverter))]
		[Localizability (LocalizationCategory.None, Readability = Readability.Unreadable)]
		public double Height {
		    get { return (double)GetValue (HeightProperty); }
		    set { SetValue (HeightProperty, value); }
		}
		
		public static readonly DependencyProperty MaxHeightProperty;

		[TypeConverter (typeof (LengthConverter))]
		[Localizability (LocalizationCategory.None, Readability = Readability.Unreadable)]
		public double MaxHeight {
		    get { return (double)GetValue (MaxHeightProperty); }
		    set { SetValue (MaxHeightProperty, value); }
		}

		public static readonly DependencyProperty MinHeightProperty;

		[TypeConverter (typeof (LengthConverter))]
		[Localizability (LocalizationCategory.None, Readability = Readability.Unreadable)]
		public double MinHeight {
		    get { return (double)GetValue (MinHeightProperty); }
		    set { SetValue (MinHeightProperty, value); }
		}

		public static readonly DependencyProperty WidthProperty;

		[TypeConverter (typeof (LengthConverter))]
		[Localizability (LocalizationCategory.None, Readability = Readability.Unreadable)]
		public double Width {
		    get { return (double)GetValue (WidthProperty); }
		    set { SetValue (WidthProperty, value); }
		}
		
		public static readonly DependencyProperty MaxWidthProperty;

		[TypeConverter (typeof (LengthConverter))]
		[Localizability (LocalizationCategory.None, Readability = Readability.Unreadable)]
		public double MaxWidth {
		    get { return (double)GetValue (MaxWidthProperty); }
		    set { SetValue (MaxWidthProperty, value); }
		}

		public static readonly DependencyProperty MinWidthProperty;

		[TypeConverter (typeof (LengthConverter))]
		[Localizability (LocalizationCategory.None, Readability = Readability.Unreadable)]
		public double MinWidth {
		    get { return (double)GetValue (MinWidthProperty); }
		    set { SetValue (MinWidthProperty, value); }
		}

		public static readonly DependencyProperty OverridesDefaultStyleProperty;
		public bool OverridesDefaultStyle {
		    get { return (bool)GetValue (OverridesDefaultStyleProperty); }
		    set { SetValue (OverridesDefaultStyleProperty, value); }
		}

		public static readonly DependencyProperty TagProperty;
		[Localizability (LocalizationCategory.NeverLocalize)]
		public object Tag {
		    get { return (object)GetValue (TagProperty); }
		    set { SetValue (TagProperty, value); }
		}
		
		public static readonly DependencyProperty ToolTipProperty;

		[Localizability (LocalizationCategory.ToolTip)]
		public object ToolTip {
		    get { return (object)GetValue (ToolTipProperty); }
		    set { SetValue (ToolTipProperty, value); }
		}

		public static readonly DependencyProperty ForceCursorProperty;
		public bool ForceCursor {
		    get { return (bool)GetValue (ForceCursorProperty); }
		    set { SetValue (ForceCursorProperty, value); }
		}

		public static readonly DependencyProperty HorizontalAlignmentProperty;
		public HorizontalAlignment HorizontalAlignment {
		    get { return (HorizontalAlignment)GetValue (HorizontalAlignmentProperty); }
		    set { SetValue (HorizontalAlignmentProperty, value); }
		}

		public static readonly DependencyProperty VerticalAlignmentProperty;
		public VerticalAlignment VerticalAlignment {
		    get { return (VerticalAlignment)GetValue (VerticalAlignmentProperty); }
		    set { SetValue (VerticalAlignmentProperty, value); }
		}
		
		public static readonly DependencyProperty InheritanceBehaviorProperty;
		public InheritanceBehavior InheritanceBehavior {
		    get { return (InheritanceBehavior)GetValue (InheritanceBehaviorProperty); }
		    set { SetValue (InheritanceBehaviorProperty, value); }
		}

		public static readonly DependencyProperty TriggersProperty;

		[DesignerSerializationVisibility (DesignerSerializationVisibility.Content)]
		public TriggerCollection Triggers {
		    get { return (TriggerCollection)GetValue (TriggersProperty); }
		    set { SetValue (TriggersProperty, value); }
		}

		public static readonly DependencyProperty LanguageProperty;
#if notyet
		public XmlLanguage Language {
		    get { return (XmlLanguage)GetValue (LanguageProperty); }
		    set { SetValue (LanguageProperty, value); }
		}
#endif

		public static readonly DependencyProperty LayoutTransformProperty;
		public Transform LayoutTransform {
		    get { return (Transform)GetValue (LayoutTransformProperty); }
		    set { SetValue (LayoutTransformProperty, value); }
		}
		
		public static readonly DependencyProperty FlowDirectionProperty;

		public FlowDirection FlowDirection {
		    get { return (FlowDirection)GetValue (FlowDirectionProperty); }
		    set { SetValue (FlowDirectionProperty, value); }
		}

		public static FlowDirection GetFlowDirection (DependencyObject element)
		{
		    return (FlowDirection)element.GetValue (FlowDirectionProperty);
		}
		
		public static void SetFlowDirection (DependencyObject element, FlowDirection value)
		{
			element.SetValue (FlowDirectionProperty, value);
		}
		
	}
}
