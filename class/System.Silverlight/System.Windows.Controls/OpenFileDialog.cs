//
// OpenFileDialog.cs
//
// Authors:
//	Atsushi Enomoto  <atsushi@ximian.com>
//
// Copyright (C) 2007 Novell, Inc (http://www.novell.com)
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
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace System.Windows.Controls
{
	// It simply opens a native file dialog
	//
	// Note that those unmanaged icalls are not in the runtime yet.
	public class OpenFileDialog
	{
		OpenFileDialogOptions opt;
		IntPtr handle;

		[MonoTODO]
		public OpenFileDialog ()
		{
			handle = CreateOpenFileDialog ();
			opt = new OpenFileDialogOptions ();
		}

		[MonoTODO]
		public void Dispose ()
		{
			DestroyOpenFileDialog (handle);
		}

		[MonoTODO]
		public DialogResult ShowDialog ()
		{
			return (DialogResult) ShowDialog (handle, opt);
		}

		// selection results

		[MonoTODO]
		public FileDialogFileInfo SelectedFile {
			get { return GetSelectedFile (handle); }
		}

		[MonoTODO]
		public IEnumerable<FileDialogFileInfo> SelectedFiles {
			get { return new FileDialogFileInfoCollection (handle, GetSelectedFiles (handle)); }
		}

		// dialog options

		public bool EnableMultiSelection {
			get { return opt.EnableMultiSelection; }
			set { opt.EnableMultiSelection = value; }
		}

		public string Filter {
			get { return opt.Filter; }
			set { opt.Filter = value; }
		}

		public int FilterIndex {
			get { return opt.FilterIndex; }
			set { opt.FilterIndex = value; }
		}

		public string Title {
			get { return opt.Title; }
			set { opt.Title = value; }
		}

		class OpenFileDialogOptions
		{
			public bool EnableMultiSelection;
			public string Filter;
			public int FilterIndex;
			public string Title;

			public OpenFileDialogOptions ()
			{
			}
		}

		[DllImport ("moon")]
		static extern IntPtr CreateOpenFileDialog ();

		[DllImport ("moon")]
		static extern void DestroyOpenFileDialog (IntPtr handle);

		[DllImport ("moon")]
		static extern int ShowDialog (IntPtr handle, OpenFileDialogOptions options);

		[DllImport ("moon")]
		static extern FileDialogFileInfo GetSelectedFile (IntPtr handle);

		[DllImport ("moon")]
		static extern IntPtr GetSelectedFiles (IntPtr handle);
	}

	class FileDialogFileInfoCollection : IEnumerable<FileDialogFileInfo>
	{
		IntPtr dialog_handle; // handle for GtkFileChooser
		IntPtr list_handle; // handle for GList

		public FileDialogFileInfoCollection (IntPtr dialog, IntPtr list)
		{
			dialog_handle = dialog;
			list_handle = list;
		}

		public IntPtr Dialog {
			get { return dialog_handle; }
		}

		public IntPtr List {
			get { return list_handle; }
		}

		public IEnumerator<FileDialogFileInfo> GetEnumerator ()
		{
			return new FileDialogFileInfoEnumerator (this);
		}

		IEnumerator IEnumerable.GetEnumerator ()
		{
			return GetEnumerator ();
		}
	}

	class FileDialogFileInfoEnumerator : IEnumerator<FileDialogFileInfo>
	{
		FileDialogFileInfoCollection files;
		FileDialogFileInfo current;

		public FileDialogFileInfoEnumerator (FileDialogFileInfoCollection files)
		{
			this.files = files;
		}

		public void Dispose ()
		{
			if (files != null)
				DestroyIterator (files.List);
			files = null;
		}

		public bool MoveNext ()
		{
			if (files == null)
				throw Disposed ();
			if (!SelectNextFile (files.List))
				return false;
			current = null;
			return true;
		}

		public void Reset ()
		{
			if (files == null)
				throw Disposed ();
			ResetFileIterator (files.List);
			current = null;
		}

		public FileDialogFileInfo Current {
			get {
				if (files == null)
					throw Disposed ();
				if (current == null)
					current = GetSelectedFileFromList (files.Dialog, files.List);
				return current;
			}
		}

		Exception Disposed ()
		{
			return new ObjectDisposedException ("FileDialogFileInfoEnumerator");
		}

		object IEnumerator.Current {
			get { return Current; }
		}

		[DllImport ("moon")]
		static extern void DestroyIterator (IntPtr list);

		[DllImport ("moon")]
		static extern void ResetFileIterator (IntPtr list);

		[DllImport ("moon")]
		static extern bool SelectNextFile (IntPtr list);

		[DllImport ("moon")]
		static extern FileDialogFileInfo GetSelectedFileFromList (IntPtr dialog, IntPtr list);
	}
}
