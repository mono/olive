//
// CollectionView.cs
//
// Author:
//       Antonius Riha <antoniusriha@gmail.com>
//
// Copyright (c) 2014 Antonius Riha
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
using System.Globalization;
using System.Windows.Threading;

namespace System.Windows.Data
{
	public class CollectionView
		: DispatcherObject, ICollectionView, IEnumerable, INotifyCollectionChanged, INotifyPropertyChanged
	{
		readonly IEnumerable collection;
		readonly bool isDynamic;
		int count;
		bool isCountDirty;
		Predicate<object> filter;

		public CollectionView (IEnumerable collection)
		{
			if (collection == null)
				throw new ArgumentNullException ("collection");
			this.collection = collection;
			isDynamic = collection is INotifyCollectionChanged;
			isCountDirty = true;
		}

		public virtual bool CanFilter {
			get { return true; }
		}

		public virtual bool CanGroup {
			get { return false; }
		}

		public virtual bool CanSort {
			get { return false; }
		}

		public virtual IComparer Comparer {
			get { return null; }
		}

		public virtual int Count {
			get {
				if (!isCountDirty)
					return count;

				var i = 0;
				for (var j = GetEnumerator (); j.MoveNext (); i++) {
				}
				count = i;
				isCountDirty = false;
				return i;
			}
		}

		public virtual CultureInfo Culture { get; set; }

		public virtual object CurrentItem {
			get {
				throw new NotImplementedException ();
			}
		}

		public virtual int CurrentPosition {
			get {
				throw new NotImplementedException ();
			}
		}

		public virtual Predicate<object> Filter {
			get { return filter; }
			set {
				filter = value;
				Refresh ();
			}
		}

		public virtual ObservableCollection<GroupDescription> GroupDescriptions {
			get { return null; }
		}

		public virtual ReadOnlyObservableCollection<object> Groups {
			get { return null; }
		}

		public virtual bool IsCurrentAfterLast {
			get {
				throw new NotImplementedException ();
			}
		}

		public virtual bool IsCurrentBeforeFirst {
			get {
				throw new NotImplementedException ();
			}
		}

		public virtual bool IsEmpty {
			get { return Count == 0; }
		}

		public virtual bool NeedsRefresh {
			get {
				throw new NotImplementedException ();
			}
		}

		public virtual SortDescriptionCollection SortDescriptions {
			get { return new SortDescriptionCollection (); }
		}

		public virtual IEnumerable SourceCollection {
			get { return collection; }
		}

		protected bool IsCurrentInSync {
			get {
				throw new NotImplementedException ();
			}
		}

		protected bool IsDynamic {
			get { return isDynamic; }
		}

		protected bool IsRefreshDeferred {
			get {
				throw new NotImplementedException ();
			}
		}

		protected bool UpdatedOutsideDispatcher {
			get {
				throw new NotImplementedException ();
			}
		}

		public virtual bool Contains (object item)
		{
			foreach (var obj in this) {
				if (Equals (obj, item))
					return true;
			}

			return false;
		}

		public virtual IDisposable DeferRefresh ()
		{
			throw new NotImplementedException ();
		}

		public virtual object GetItemAt (int index)
		{
			if (index < 0)
				throw new ArgumentOutOfRangeException ("index is less than 0.");

			var i = 0;
			foreach (var item in this) {
				if (i++ == index)
					return item;
			}

			return null;
		}

		public virtual int IndexOf (object item)
		{
			var j = 0;
			for (var i = GetEnumerator (); i.MoveNext (); j++) {
				if (Equals (i.Current, item))
					return j;
			}

			return -1;
		}

		public virtual bool MoveCurrentTo (object item)
		{
			throw new NotImplementedException ();
		}

		public virtual bool MoveCurrentToFirst ()
		{
			throw new NotImplementedException ();
		}

		public virtual bool MoveCurrentToLast ()
		{
			throw new NotImplementedException ();
		}

		public virtual bool MoveCurrentToNext ()
		{
			throw new NotImplementedException ();
		}

		public virtual bool MoveCurrentToPosition (int position)
		{
			throw new NotImplementedException ();
		}

		public virtual bool MoveCurrentToPrevious ()
		{
			throw new NotImplementedException ();
		}

		public virtual bool PassesFilter (object item)
		{
			return Filter == null || Filter (item);
		}

		public virtual void Refresh ()
		{
			RefreshOverride ();
		}

		protected void ClearChangeLog ()
		{
			throw new NotImplementedException ();
		}

		protected virtual IEnumerator GetEnumerator ()
		{
			foreach (var item in SourceCollection) {
				if (PassesFilter (item))
					yield return item;
			}
		}

		protected bool OKToChangeCurrent ()
		{
			throw new NotImplementedException ();
		}

		protected virtual void OnBeginChangeLogging (NotifyCollectionChangedEventArgs args)
		{
			throw new NotImplementedException ();
		}

		protected virtual void OnCollectionChanged (NotifyCollectionChangedEventArgs args)
		{
			if (CollectionChanged != null)
				CollectionChanged (this, args);
		}

		protected void OnCollectionChanged (object sender, NotifyCollectionChangedEventArgs args)
		{
			throw new NotImplementedException ();
		}

		protected virtual void OnCurrentChanged ()
		{
			if (CurrentChanged != null)
				CurrentChanged (this, EventArgs.Empty);
		}

		protected void OnCurrentChanging ()
		{
			OnCurrentChanging (new CurrentChangingEventArgs (false));
			// CurrentPosition = -1;
		}

		protected virtual void OnCurrentChanging (CurrentChangingEventArgs args)
		{
			if (CurrentChanging != null)
				CurrentChanging (this, args);
		}

		protected virtual void OnPropertyChanged (PropertyChangedEventArgs e)
		{
			if (PropertyChanged != null)
				PropertyChanged (this, e);
		}

		protected virtual void ProcessCollectionChanged (NotifyCollectionChangedEventArgs args)
		{
			throw new NotImplementedException ();
		}

		protected void RefreshOrDefer ()
		{
			throw new NotImplementedException ();
		}

		protected virtual void RefreshOverride ()
		{
			throw new NotImplementedException ();
		}

		protected void SetCurrent (object newItem, int newPosition)
		{
			throw new NotImplementedException ();
		}

		public event EventHandler CurrentChanged;
		public event CurrentChangingEventHandler CurrentChanging;
		protected virtual event NotifyCollectionChangedEventHandler CollectionChanged;
		protected virtual event PropertyChangedEventHandler PropertyChanged;

		#region Explicit content

		IEnumerator IEnumerable.GetEnumerator ()
		{
			return GetEnumerator ();
		}

		event NotifyCollectionChangedEventHandler INotifyCollectionChanged.CollectionChanged {
			add { CollectionChanged += value; }
			remove { CollectionChanged -= value; }
		}

		event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged {
			add { PropertyChanged += value; }
			remove { PropertyChanged -= value; }
		}

		#endregion
	}
}
