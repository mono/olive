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
using System.Windows.Threading;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;

namespace System.Windows.Media {

	public abstract class DrawingContext : DispatcherObject {

		internal DrawingContext ()
		{
		}

		protected abstract void DisposeCore ();
		public abstract void DrawDrawing (Drawing drawing);
		public abstract void DrawEllipse (Brush brush, Pen pen, Point center, double rx, double ry);
#if notyet
		public abstract void DrawGeometry (Brush brush, Pen pen, Geometry geometry);
		public abstract void DrawGlyphRun (Brush brush, GlyphRun run);
#endif

		public abstract void DrawImage (ImageSource image, Rect rect, AnimationClock clock);
		public abstract void DrawImage (ImageSource source, Rect rect);
		public abstract void DrawLine (Pen pen, Point point1, AnimationClock clock1, Point point2, AnimationClock clock2);
		public abstract void DrawLine (Pen pen, Point point1, Point point2);
		public abstract void DrawRectangle (Brush brush, Pen pen, Rect rect);
		public abstract void DrawRectangle (Brush brush, Pen pen, Rect rect, AnimationClock clock);
		public abstract void DrawRoundedRectangle (Brush brush, Pen pen,
							   Rect rect, AnimationClock rectClock,
							   double rx, AnimationClock rxClock,
							   double ry, AnimationClock ryClock);
		public abstract void DrawRoundedRectangle (Brush brush, Pen pen, Rect rect, double rx, double ry);
#if notyet
		public abstract void DrawText (FormattedText text, Point point);
#endif
		public abstract void DrawVideo (MediaPlayer player, Rect rect);
		public abstract void DrawVideo (MediaPlayer player, Rect rect, AnimationClock clock);
		public abstract void Pop ();
#if notyet
		public abstract void PushClip (Geometry geometry);
		public abstract void PushEffect (BitmapEffect effect, BitmapEffectInput effectInput);
		public abstract void PushGuidelineSet (GuidelineSet set);
#endif
		public abstract void PushOpacity (double opacity);
		public abstract void PushOpacity (double opacity, AnimationClock clock);
		public abstract void PushOpacityMask (Brush brush);
		public abstract void PushTransform (Transform transform);

		protected virtual void VerifyApiNonstructuralChange ()
		{
			throw new NotImplementedException ();
		}
	}

}
