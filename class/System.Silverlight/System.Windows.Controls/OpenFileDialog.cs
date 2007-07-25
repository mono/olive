//
// OpenFileDialog.cs
//
// Authors:
//	Atsushi Enomoto  <atsushi@ximian.com>
//	Miguel de Icaza  <miguel@ximian.com>
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
		FileDialogFileInfo file_info;
		FileDialogFileInfo [] files;
		
		IntPtr handle;
		bool allow_multiple_selection = false;
		string filter = "";
		int filter_index = 0;
		string title = null;
		
		public OpenFileDialog ()
		{
		}

		public void Dispose ()
		{
		}

		public DialogResult ShowDialog ()
		{
			string path = open_file_dialog_show (
				handle, title == null ? "" : title,
				allow_multiple_selection,
				filter == null ? "" : filter,
				filter_index);

			if (path != null){
				file_info = new FileDialogFileInfo (path);
				if (allow_multiple_selection){
					//
					// TODO
					//
				}
				
				return DialogResult.OK;
			} else {
				file_info = null;
				return DialogResult.Cancel;
			}
		}

		// selection results

		public FileDialogFileInfo SelectedFile {
			get {
				return file_info;
			}
		}

		public IEnumerable<FileDialogFileInfo> SelectedFiles {
			get { yield return file_info; }
		}

		// dialog options

		public bool EnableMultiSelection {
			get { return allow_multiple_selection; }
			set { allow_multiple_selection = value; }
		}

		public string Filter {
			get { return filter; }
			set { filter = value; }
		}

		public int FilterIndex {
			get { return filter_index; }
			set { filter_index = value; }
		}

		public string Title {
			get { return title; }
			set { title = value; }
		}

		[DllImport ("moon")]
		static extern string open_file_dialog_show (IntPtr handle, string title, bool multsel, string filter, int idx);
	}
}
