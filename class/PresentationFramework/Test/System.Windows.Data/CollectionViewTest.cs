//
// CollectionViewTest.cs
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
using System.ComponentModel;
using System.Windows.Data;
using NUnit.Framework;

namespace MonoTests.System.Windows.Data
{
	public class CollectionViewTest
	{
		[Test]
		[ExpectedException (typeof(ArgumentNullException))]
		public void CreateCollectionView ()
		{
			new CollectionView (null);
		}

		[Test]
		public void CanFilter ()
		{
			var cv = new CollectionView (new object[] { });
			Assert.IsTrue (cv.CanFilter, "A1");
		}

		[Test]
		public void CanGroup ()
		{
			var cv = new CollectionView (new object[] { });
			Assert.IsFalse (cv.CanGroup, "A1");
		}

		[Test]
		public void CanSort ()
		{
			var cv = new CollectionView (new object[] { });
			Assert.IsFalse (cv.CanSort, "A1");
		}

		[Test]
		public void GetComparer ()
		{
			var cv = new CollectionView (new object[] { });
			Assert.IsNull (cv.Comparer);
		}

		[Test]
		public void GetCount ()
		{
			object[] list = { 0, 1, 2, 3, 4, 5, 6 };
			var cv = new CollectionView (list);
			Assert.AreEqual (7, cv.Count, "A1");
		}

		[Test]
		public void GetCountWithFilter ()
		{
			object[] list = { 0, 1, 2, 3, 4, 5, 6 };
			var cv = new CollectionView (list);
			cv.Filter = item => (int)item % 2 == 0;
			Assert.AreEqual (4, cv.Count, "A1");
		}

		[Test]
		public void EnumerateItems ()
		{
			object[] list = { 0, 99, 22, 7, 11, 4, 3 };
			var cv = new CollectionView (list);
			CollectionAssert.AreEquivalent (list, cv, "A1");
		}

		[Test]
		public void EnumerateItemsWithFilter ()
		{
			object[] list = { 0, 1, 2, 3, 4, 5, 6 };
			object[] filteredList = { 0, 2, 4, 6 };
			var cv = new CollectionView (list);
			cv.Filter = item => (int)item % 2 == 0;
			CollectionAssert.AreEquivalent (filteredList, cv, "A1");
		}

		[Test]
		public void GetGroupDescriptions ()
		{
			var cv = new CollectionView (new object[] { });
			Assert.IsNull (cv.GroupDescriptions, "A1");
		}

		[Test]
		public void GetGroups ()
		{
			var cv = new CollectionView (new object[] { });
			Assert.IsNull (cv.Groups, "A1");
		}

		[Test]
		public void GetSortDescriptions ()
		{
			var cv = new CollectionView (new object[] { });
			CollectionAssert.IsEmpty (cv.SortDescriptions, "A1");
		}

		[Test]
		[ExpectedException (typeof(NotSupportedException))]
		public void AddToSortDescriptions ()
		{
			var cv = new CollectionView (new object[] { });
			cv.SortDescriptions.Add (new SortDescription ());
		}

		[Test]
		public void RemoveFromSortDescriptions ()
		{
			var cv = new CollectionView (new object[] { });
			Assert.IsFalse (cv.SortDescriptions.Remove (new SortDescription ()), "A1");
		}

		[Test]
		[ExpectedException (typeof(NotSupportedException))]
		public void RemoveAtIndexFromSortDescriptions ()
		{
			var cv = new CollectionView (new object[] { });
			cv.SortDescriptions.RemoveAt (0);
		}

		[Test]
		[ExpectedException (typeof(NotSupportedException))]
		public void ClearSortDescriptions ()
		{
			var cv = new CollectionView (new object[] { });
			cv.SortDescriptions.Clear ();
		}

		[Test]
		[ExpectedException (typeof(ArgumentOutOfRangeException))]
		public void SetItemInSortDescriptions ()
		{
			var cv = new CollectionView (new object[] { });
			cv.SortDescriptions [0] = new SortDescription ();
		}

		[Test]
		[ExpectedException (typeof(NotSupportedException))]
		public void InsertIntoSortDescriptions ()
		{
			var cv = new CollectionView (new object[] { });
			cv.SortDescriptions.Insert (0, new SortDescription ());
		}

		[Test]
		public void PassesFilter ()
		{
			var cv = new CollectionView (new object[] { });
			Assert.IsTrue (cv.PassesFilter (new object ()), "A1");
		}

		[Test]
		public void PassesFilterWithFilterSet ()
		{
			object[] list = { 1, 2, 3, 4, 5, 6 };
			var cv = new CollectionView (list);
			cv.Filter = item => (int)item % 2 == 0;
			Assert.IsTrue (cv.PassesFilter (4), "A1");
			Assert.IsFalse (cv.PassesFilter (3), "A2");
			Assert.IsTrue (cv.PassesFilter (98), "A3");
			Assert.IsFalse (cv.PassesFilter (99), "A4");
		}

		[Test]
		public void Contains ()
		{
			object[] list = { 1, 2, 3, 4, 5, 6 };
			var cv = new CollectionView (list);
			cv.Filter = item => (int)item % 2 == 0;
			Assert.IsTrue (cv.Contains (4), "A1");
			Assert.IsFalse (cv.Contains (3), "A2");
			Assert.IsFalse (cv.Contains (98), "A3");
			Assert.IsFalse (cv.Contains (99), "A4");
		}

		[Test]
		[ExpectedException (typeof(ArgumentOutOfRangeException))]
		public void GetItemAtLessThan0 ()
		{
			var cv = new CollectionView (new object[] { });
			cv.GetItemAt (-1);
		}

		[Test]
		public void GetItemAt ()
		{
			object[] list = { 1, 2, 3, 4, 5, 6 };
			var cv = new CollectionView (list);
			Assert.AreEqual (4, cv.GetItemAt (3), "A1");
			Assert.IsNull (cv.GetItemAt (99), "A2");
		}

		[Test]
		public void IndexOf ()
		{
			object[] list = { 1, 7, 3, 3, 5, 6 };
			var cv = new CollectionView (list);
			Assert.AreEqual (2, cv.IndexOf (3), "A1");
			Assert.AreEqual (-1, cv.IndexOf (99), "A2");
		}

		[Test]
		public void OnCurrentChanging ()
		{
			var cv = new UnprotectedCollectionView (new object[] { });
			cv.UnprotectedOnCurrentChanging ();
			Assert.AreEqual (-1, cv.CurrentPosition, "A1");
		}

		class UnprotectedCollectionView : CollectionView
		{
			public UnprotectedCollectionView (IEnumerable collection) : base (collection)
			{
			}

			public void UnprotectedOnCurrentChanging ()
			{
				OnCurrentChanging ();
			}
		}
	}
}
