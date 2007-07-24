// Author:
//   Rolf Bjarne Kvinge  (RKvinge@novell.com)
//
// Copyright 2007 Novell, Inc.
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

using Mono;
using System;
using System.Windows;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace System.Windows.Controls
{
	public class MediaElement : MediaBase {
		
		public static readonly DependencyProperty AttributesProperty = 
			DependencyProperty.Lookup (Kind.MEDIAELEMENT, "Attributes", typeof (MediaAttributeCollection));
		
		public static readonly DependencyProperty AutoPlayProperty = 
			DependencyProperty.Lookup (Kind.MEDIAELEMENT, "AutoPlay", typeof (bool));
		
		public static readonly DependencyProperty BalanceProperty = 
			DependencyProperty.Lookup (Kind.MEDIAELEMENT, "Balance", typeof (double));
		
		public static readonly DependencyProperty BufferingProgressProperty = 
			DependencyProperty.Lookup (Kind.MEDIAELEMENT, "BufferingProgress", typeof (double));
		
		public static readonly DependencyProperty BufferingTimeProperty = 
			DependencyProperty.Lookup (Kind.MEDIAELEMENT, "BufferingTime", typeof (TimeSpan));
		
		public static readonly DependencyProperty CanSeekProperty = 
			DependencyProperty.Lookup (Kind.MEDIAELEMENT, "CanSeek", typeof (bool));
		
		public static readonly DependencyProperty CurrentStateProperty = 
			DependencyProperty.Lookup (Kind.MEDIAELEMENT, "CurrentState", typeof (string));
		
		public static readonly DependencyProperty DownloadProgressProperty = 
			DependencyProperty.Lookup (Kind.MEDIAELEMENT, "DownloadProgress", typeof (double));
		
		public static readonly DependencyProperty IsMutedProperty = 
			DependencyProperty.Lookup (Kind.MEDIAELEMENT, "IsMuted", typeof (bool));
		
		public static readonly DependencyProperty MarkersProperty = 
			DependencyProperty.Lookup (Kind.MEDIAELEMENT, "Markers", typeof (TimelineMarkerCollection));
		
		public static readonly DependencyProperty NaturalDurationProperty = 
			DependencyProperty.Lookup (Kind.MEDIAELEMENT, "NaturalDuration", typeof (Duration));
		
		public static readonly DependencyProperty NaturalVideoHeightProperty = 
			DependencyProperty.Lookup (Kind.MEDIAELEMENT, "NaturalVideoHeight", typeof (double));
		
		public static readonly DependencyProperty NaturalVideoWidthProperty = 
			DependencyProperty.Lookup (Kind.MEDIAELEMENT, "NaturalVideoWidth", typeof (double));
		
		public static readonly DependencyProperty PositionProperty = 
			DependencyProperty.Lookup (Kind.MEDIAELEMENT, "Position", typeof (TimeSpan));
		
		public static readonly DependencyProperty VolumeProperty = 
			DependencyProperty.Lookup (Kind.MEDIAELEMENT, "Volume", typeof (double));
		
		
		public MediaElement() : base (NativeMethods.media_element_new ()) 
		{
			NativeMethods.base_ref (native);
		}
	
		internal MediaElement (IntPtr raw) : base (raw) 
		{
		}
		
		public void Pause()
		{
			NativeMethods.media_element_pause (native);
		}
		
		public void Play()
		{
			NativeMethods.media_element_play (native);
		}
		
		public void SetSource(DependencyObject Downloader, string PartName)
		{
			NativeMethods.media_element_set_source (native, Downloader.native, PartName);
		}
		
		public void Stop()
		{
			NativeMethods.media_element_stop (native);
		}

		public MediaAttributeCollection Attributes { 
			get {
				return (MediaAttributeCollection) GetValue (AttributesProperty);
			}
			set {
				SetValue (AttributesProperty, value);
			}
		}
		
		public bool AutoPlay { 
			get {
				return (bool) GetValue (AutoPlayProperty);
			}
			set {
				SetValue (AutoPlayProperty, value);
			}
		}
		
		public double Balance { 
			get {
				return (double) GetValue (BalanceProperty); 
			}
			set {
				SetValue (BalanceProperty, value);
			}
		}
		
		public double BufferingProgress {
			get {
				return (double) GetValue (BufferingProgressProperty); 
			}
			set {
				SetValue (BufferingProgressProperty, value);
			}
		}
		
		public TimeSpan BufferingTime { 
			get {
				return (TimeSpan) GetValue (BufferingTimeProperty);
			}
			set {
				SetValue (BufferingTimeProperty, value);
			}
		}
		
		public bool CanSeek { 
			get {
				return (bool) GetValue (CanSeekProperty);
			}
		}
		
		public string CurrentState { 
			get {
				return (string) GetValue (CurrentStateProperty);
			}
		}
		
		public double DownloadProgress { 
			get {
				return (double) GetValue (DownloadProgressProperty);
			}
			set {
				SetValue (DownloadProgressProperty, value);
			}
		}
		
		public bool IsMuted { 
			get {
				return (bool) GetValue (IsMutedProperty);
			}
			set {
				SetValue (IsMutedProperty, value);
			}
		}
		
		public TimelineMarkerCollection Markers { 
			get {
				return (TimelineMarkerCollection) GetValue (MarkersProperty);
			}
			set {
				SetValue (MarkersProperty, value);
			}
		}
		
		public Duration NaturalDuration { 
			get {
				return (Duration) GetValue (NaturalDurationProperty);
			}
			set {
				SetValue (NaturalDurationProperty, value);
			}
		}
		
		public double NaturalVideoHeight { 
			get {
				return (double) GetValue (NaturalVideoHeightProperty);
			}
			set {
				SetValue (NaturalVideoHeightProperty, value);
			}
		}
		
		public double NaturalVideoWidth { 
			get {
				return (double) GetValue (NaturalVideoWidthProperty);
			}
			set {
				SetValue (NaturalVideoWidthProperty, value);
			}
		}
		
		public TimeSpan Position { 
			get {
				return (TimeSpan) GetValue (PositionProperty);
			}
			set {
				SetValue (PositionProperty, value);
			}
		}
		
		public double Volume { 
			get {
				return (double) GetValue (VolumeProperty);
			}
			set {
				SetValue (VolumeProperty, value);
			}
		}

		internal override Kind GetKind ()
		{
			return Kind.MEDIAELEMENT;
		}
		
		
		public event EventHandler BufferingProgressChanged;
		public event EventHandler CurrentStateChanged;
		public event EventHandler DownloadProgressChanged;
		public event TimelineMarkerEventHandler MarkerReached;
	}
}
