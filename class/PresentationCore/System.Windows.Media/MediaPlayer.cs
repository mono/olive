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

using System.Windows;
using System.Windows.Media.Animation;

namespace System.Windows.Media {

	public class MediaPlayer : Animatable {
		public MediaPlayer ()
		{
		}

		protected override void CloneCore (Freezable sourceFreezable)
		{
			throw new NotImplementedException ();
		}

		protected override void CloneCurrentValueCore (Freezable sourceFreezable)
		{
			throw new NotImplementedException ();
		}

		protected override Freezable CreateInstanceCore ()
		{
			return new MediaPlayer ();
		}

		protected override void GetAsFrozenCore (Freezable sourceFreezable)
		{
			throw new NotImplementedException ();
		}

		protected new void ReadPreamble ()
		{
			throw new NotImplementedException ();
		}

		protected new void WritePreamble ()
		{
			throw new NotImplementedException ();
		}

		public void Play ()
		{
			throw new NotImplementedException ();
		}

		public void Pause ()
		{
			throw new NotImplementedException ();
		}

		public void Stop ()
		{
			throw new NotImplementedException ();
		}

		public void Open (Uri source)
		{
			throw new NotImplementedException ();
		}

		public void Close ()
		{
			throw new NotImplementedException ();
		}

		public Duration NaturalDuration {
			get { throw new NotImplementedException (); }
		}

		public Uri Source {
			get { throw new NotImplementedException (); }
		}

		public bool IsBuffering {
			get { throw new NotImplementedException (); }
		}

		public double BufferingProgress {
			get { throw new NotImplementedException (); }
		}

		public double DownloadProgress {
			get { throw new NotImplementedException (); }
		}
			
		public double Volume {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		public double SpeedRatio {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		public int NaturalVideoHeight {
			get { throw new NotImplementedException (); }
		}

		public int NaturalVideoWidth {
			get { throw new NotImplementedException (); }
		}

		public double Balance {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		public bool ScrubbingEnabled {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		public bool CanPause {
			get { throw new NotImplementedException (); }
		}

		public bool HasAudio {
			get { throw new NotImplementedException (); }
		}

		public bool HasVideo {
			get { throw new NotImplementedException (); }
		}

		public TimeSpan Position {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		public MediaClock Clock {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		public bool IsMuted {
			get { throw new NotImplementedException (); }
			set { throw new NotImplementedException (); }
		}

		public event EventHandler<MediaScriptCommandEventArgs> ScriptCommand;
		public event EventHandler<ExceptionEventArgs> MediaFailed;
		public event EventHandler MediaEnded;
		public event EventHandler MediaOpened;
		public event EventHandler BufferingStarted;
		public event EventHandler BufferingEnded;
	}

}