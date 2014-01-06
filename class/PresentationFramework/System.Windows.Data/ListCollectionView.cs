//
// ListCollectionView.cs
//
// Author:
//       Antonius Riha <antoniusriha@gmail.com>
//
// Copyright (c) 2012 Antonius Riha
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace System.Windows.Data
{
	public class ListCollectionView : CollectionView, IComparer
#if NET_4_0
		, IEditableCollectionViewAddNewItem, IEditableCollectionView, IItemProperties
#endif
	{
		public ListCollectionView (IList list) : base (list)
		{
		}

		public bool CanAddNew {
			get {
				throw new NotImplementedException ();
			}
		}
#if NET_4_0
		public bool CanAddNewItem {
			get {
				throw new NotImplementedException ();
			}
		}
#endif
		public bool CanCancelEdit {
			get {
				throw new NotImplementedException ();
			}
		}

		public override bool CanFilter {
			get {
				return base.CanFilter;
			}
		}

		public override bool CanGroup {
			get {
				return base.CanGroup;
			}
		}

		public bool CanRemove {
			get {
				throw new NotImplementedException ();
			}
		}

		public override bool CanSort {
			get {
				return base.CanSort;
			}
		}

		public override int Count {
			get {
				return base.Count;
			}
		}

		public object CurrentAddItem {
			get {
				throw new NotImplementedException ();
			}
		}

		public object CurrentEditItem {
			get {
				throw new NotImplementedException ();
			}
		}

		public IComparer CustomSort { get; set; }

		public override Predicate<object> Filter {
			get {
				return base.Filter;
			}
			set {
				base.Filter = value;
			}
		}

		public virtual GroupDescriptionSelectorCallback GroupBySelector { get; set; }

		public override ObservableCollection<GroupDescription> GroupDescriptions {
			get {
				throw new NotImplementedException ();
			}
		}

		public override ReadOnlyObservableCollection<Object> Groups {
			get {
				throw new NotImplementedException ();
			}
		}

		public bool IsAddingNew {
			get {
				throw new NotImplementedException ();
			}
		}

		public bool IsDataInGroupOrder { get; set; }

		public bool IsEditingItem {
			get {
				throw new NotImplementedException ();
			}
		}

		public override bool IsEmpty {
			get {
				return base.IsEmpty;
			}
		}

		public ReadOnlyCollection<ItemPropertyInfo> ItemProperties {
			get {
				throw new NotImplementedException ();
			}
		}

		public NewItemPlaceholderPosition NewItemPlaceholderPosition {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		public override SortDescriptionCollection SortDescriptions {
			get {
				return base.SortDescriptions;
			}
		}

		protected IComparer ActiveComparer { get; set; }

		protected Predicate<Object> ActiveFilter { get; set; }

		protected int InternalCount {
			get {
				throw new NotImplementedException ();
			}
		}

		protected IList InternalList {
			get {
				throw new NotImplementedException ();
			}
		}

		protected bool IsGrouping {
			get {
				throw new NotImplementedException ();
			}
		}

		protected bool UsesLocalArray {
			get {
				throw new NotImplementedException ();
			}
		}

		public object AddNew ()
		{
			throw new NotImplementedException ();
		}
#if NET_4_0
		public object AddNewItem (object newItem)
		{
			throw new NotImplementedException ();
		}
#endif
		public void CancelEdit ()
		{
			throw new NotImplementedException ();
		}

		public void CancelNew ()
		{
			throw new NotImplementedException ();
		}

		public void CommitEdit ()
		{
			throw new NotImplementedException ();
		}

		public void CommitNew ()
		{
			throw new NotImplementedException ();
		}

		public override bool Contains (object item)
		{
			return base.Contains (item);
		}

		public override object GetItemAt (int index)
		{
			return base.GetItemAt (index);
		}

		public override int IndexOf (object item)
		{
			return base.IndexOf (item);
		}

		public void EditItem (object item)
		{
			throw new NotImplementedException ();
		}

		public override bool MoveCurrentToPosition (int position)
		{
			return base.MoveCurrentToPosition (position);
		}

		public override bool PassesFilter (object item)
		{
			return base.PassesFilter (item);
		}

		public void Remove (object item)
		{
			throw new NotImplementedException ();
		}

		public void RemoveAt (int index)
		{
			throw new NotImplementedException ();
		}

		protected virtual int Compare (object x, object y)
		{
			throw new NotImplementedException ();
		}

		protected override IEnumerator GetEnumerator ()
		{
			return base.GetEnumerator ();
		}

		protected bool InternalContains (object item)
		{
			throw new NotImplementedException ();
		}

		protected IEnumerator InternalGetEnumerator ()
		{
			throw new NotImplementedException ();
		}

		protected int InternalIndexOf (object item)
		{
			throw new NotImplementedException ();
		}

		protected object InternalItemAt (int index)
		{
			throw new NotImplementedException ();
		}

		protected override void OnBeginChangeLogging (NotifyCollectionChangedEventArgs args)
		{
			base.OnBeginChangeLogging (args);
		}

		protected override void ProcessCollectionChanged (NotifyCollectionChangedEventArgs args)
		{
			base.ProcessCollectionChanged (args);
		}

		protected override void RefreshOverride ()
		{
			base.RefreshOverride ();
		}

		#region Explicit content

		int IComparer.Compare (object x, object y)
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}
