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

using System.Security;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace System.Windows {

	public class Application : DispatcherObject {
		private Uri mStartUri;

		[SecurityCritical]
		public Application ()
		{
		}

		public int Run ()
		{
			return 1;
		}

		[SecurityCritical]
		public int Run (Window mainWindow)
		{
			return 1;
		}

		public void Shutdown ()
		{
			throw new NotImplementedException ();
		}

		[SecurityCritical]
		public void Shutdown (int exitCode)
		{
			throw new NotImplementedException ();
		}
		
		public Uri StartupUri
		{
			get { return mStartUri; }
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("StartupUri");
				}
				mStartUri = value;
			}
		}

		public static Application Current {
			get { throw new NotImplementedException (); }
		}

		public Window MainWindow  {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		public event StartupEventHandler Startup;
		protected virtual void OnStartup (StartupEventArgs args)
		{
			if (Startup != null)
				Startup (this, args);
		}

		public event ExitEventHandler Exit;
		protected virtual void OnExit (ExitEventArgs args)
		{
			if (Exit != null)
				Exit (this, args);
		}

		public event EventHandler Activated;
		protected virtual void OnActivated (EventArgs args)
		{
			if (Activated != null)
				Activated (this, args);
		}

		public event EventHandler Deactivated;
		protected virtual void OnDeactivated (EventArgs args)
		{
			if (Deactivated != null)
				Deactivated (this, args);
		}

		public event NavigationStoppedEventHandler NavigationStopped;
		protected virtual void OnNavigationStopped (NavigationEventArgs args)
		{
			if (NavigationStopped != null)
				NavigationStopped (this, args);
		}

		public event NavigationProgressEventHandler NavigationProgress;
		protected virtual void OnNavigationProgress (NavigationProgressEventArgs args)
		{
			if (NavigationProgress != null)
				NavigationProgress (this, args);
		}

		public event NavigatingCancelEventHandler Navigating;
		protected virtual void OnNavigating (NavigatingCancelEventArgs args)
		{
			if (Navigating != null)
				Navigating (this, args);
		}

		public event FragmentNavigationEventHandler FragmentNavigation;
		protected virtual void OnFragmentNavigation (FragmentNavigationEventArgs args)
		{
			if (FragmentNavigation != null)
				FragmentNavigation (this, args);
		}

		public event NavigatedEventHandler Navigated;
		protected virtual void OnNavigated (NavigationEventArgs args)
		{
			if (Navigated != null)
				Navigated (this, args);
		}

		public event SessionEndingCancelEventHandler SessionEnding;
		protected virtual void OnSessionEnding (SessionEndingCancelEventArgs args)
		{
			if (SessionEnding != null)
				SessionEnding (this, args);
		}

		public event LoadCompletedEventHandler LoadCompleted;
		protected virtual void OnLoadCompleted (NavigationEventArgs args)
		{
			if (LoadCompleted != null)
				LoadCompleted (this, args);
		}

		public event NavigationFailedEventHandler NavigationFailed;
		protected virtual void OnNavigationFailed (NavigationFailedEventArgs args)
		{
			if (NavigationFailed != null)
				NavigationFailed (this, args);
		}

	}

}
