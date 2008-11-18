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

using System;
using System.ComponentModel;
using System.Windows;

namespace System.Windows.Media {

	public static class Brushes {
		public static SolidColorBrush AliceBlue { get { return new SolidColorBrush (Colors.AliceBlue); } }
		public static SolidColorBrush AntiqueWhite { get { return new SolidColorBrush (Colors.AntiqueWhite); } }
		public static SolidColorBrush Aqua { get { return new SolidColorBrush (Colors.Aqua); } }
		public static SolidColorBrush Aquamarine { get { return new SolidColorBrush (Colors.Aquamarine); } }
		public static SolidColorBrush Azure { get { return new SolidColorBrush (Colors.Azure); } }
		public static SolidColorBrush Beige { get { return new SolidColorBrush (Colors.Beige); } }
		public static SolidColorBrush Bisque { get { return new SolidColorBrush (Colors.Bisque); } }
		public static SolidColorBrush Black { get { return new SolidColorBrush (Colors.Black); } }
		public static SolidColorBrush BlanchedAlmond { get { return new SolidColorBrush (Colors.BlanchedAlmond); } }
		public static SolidColorBrush Blue { get { return new SolidColorBrush (Colors.Blue); } }
		public static SolidColorBrush BlueViolet { get { return new SolidColorBrush (Colors.BlueViolet); } }
		public static SolidColorBrush Brown { get { return new SolidColorBrush (Colors.Brown); } }
		public static SolidColorBrush BurlyWood { get { return new SolidColorBrush (Colors.BurlyWood); } }
		public static SolidColorBrush CadetBlue { get { return new SolidColorBrush (Colors.CadetBlue); } }
		public static SolidColorBrush Chartreuse { get { return new SolidColorBrush (Colors.Chartreuse); } }
		public static SolidColorBrush Chocolate { get { return new SolidColorBrush (Colors.Chocolate); } }
		public static SolidColorBrush Coral { get { return new SolidColorBrush (Colors.Coral); } }
		public static SolidColorBrush CornflowerBlue { get { return new SolidColorBrush (Colors.CornflowerBlue); } }
		public static SolidColorBrush Cornsilk { get { return new SolidColorBrush (Colors.Cornsilk); } }
		public static SolidColorBrush Crimson { get { return new SolidColorBrush (Colors.Crimson); } }
		public static SolidColorBrush Cyan { get { return new SolidColorBrush (Colors.Cyan); } }
		public static SolidColorBrush DarkBlue { get { return new SolidColorBrush (Colors.DarkBlue); } }
		public static SolidColorBrush DarkCyan { get { return new SolidColorBrush (Colors.DarkCyan); } }
		public static SolidColorBrush DarkGoldenrod { get { return new SolidColorBrush (Colors.DarkGoldenrod); } }
		public static SolidColorBrush DarkGray { get { return new SolidColorBrush (Colors.DarkGray); } }
		public static SolidColorBrush DarkGreen { get { return new SolidColorBrush (Colors.DarkGreen); } }
		public static SolidColorBrush DarkKhaki { get { return new SolidColorBrush (Colors.DarkKhaki); } }
		public static SolidColorBrush DarkMagenta { get { return new SolidColorBrush (Colors.DarkMagenta); } }
		public static SolidColorBrush DarkOliveGreen { get { return new SolidColorBrush (Colors.DarkOliveGreen); } }
		public static SolidColorBrush DarkOrange { get { return new SolidColorBrush (Colors.DarkOrange); } }
		public static SolidColorBrush DarkOrchid { get { return new SolidColorBrush (Colors.DarkOrchid); } }
		public static SolidColorBrush DarkRed { get { return new SolidColorBrush (Colors.DarkRed); } }
		public static SolidColorBrush DarkSalmon { get { return new SolidColorBrush (Colors.DarkSalmon); } }
		public static SolidColorBrush DarkSeaGreen { get { return new SolidColorBrush (Colors.DarkSeaGreen); } }
		public static SolidColorBrush DarkSlateBlue { get { return new SolidColorBrush (Colors.DarkSlateBlue); } }
		public static SolidColorBrush DarkSlateGray { get { return new SolidColorBrush (Colors.DarkSlateGray); } }
		public static SolidColorBrush DarkTurquoise { get { return new SolidColorBrush (Colors.DarkTurquoise); } }
		public static SolidColorBrush DarkViolet { get { return new SolidColorBrush (Colors.DarkViolet); } }
		public static SolidColorBrush DeepPink { get { return new SolidColorBrush (Colors.DeepPink); } }
		public static SolidColorBrush DeepSkyBlue { get { return new SolidColorBrush (Colors.DeepSkyBlue); } }
		public static SolidColorBrush DimGray { get { return new SolidColorBrush (Colors.DimGray); } }
		public static SolidColorBrush DodgerBlue { get { return new SolidColorBrush (Colors.DodgerBlue); } }
		public static SolidColorBrush Firebrick { get { return new SolidColorBrush (Colors.Firebrick); } }
		public static SolidColorBrush FloralWhite { get { return new SolidColorBrush (Colors.FloralWhite); } }
		public static SolidColorBrush ForestGreen { get { return new SolidColorBrush (Colors.ForestGreen); } }
		public static SolidColorBrush Fuchsia { get { return new SolidColorBrush (Colors.Fuchsia); } }
		public static SolidColorBrush Gainsboro { get { return new SolidColorBrush (Colors.Gainsboro); } }
		public static SolidColorBrush GhostWhite { get { return new SolidColorBrush (Colors.GhostWhite); } }
		public static SolidColorBrush Goldenrod { get { return new SolidColorBrush (Colors.Goldenrod); } }
		public static SolidColorBrush Gold { get { return new SolidColorBrush (Colors.Gold); } }
		public static SolidColorBrush Gray { get { return new SolidColorBrush (Colors.Gray); } }
		public static SolidColorBrush Green { get { return new SolidColorBrush (Colors.Green); } }
		public static SolidColorBrush GreenYellow { get { return new SolidColorBrush (Colors.GreenYellow); } }
		public static SolidColorBrush Honeydew { get { return new SolidColorBrush (Colors.Honeydew); } }
		public static SolidColorBrush HotPink { get { return new SolidColorBrush (Colors.HotPink); } }
		public static SolidColorBrush IndianRed { get { return new SolidColorBrush (Colors.IndianRed); } }
		public static SolidColorBrush Indigo { get { return new SolidColorBrush (Colors.Indigo); } }
		public static SolidColorBrush Ivory { get { return new SolidColorBrush (Colors.Ivory); } }
		public static SolidColorBrush Khaki { get { return new SolidColorBrush (Colors.Khaki); } }
		public static SolidColorBrush LavenderBlush { get { return new SolidColorBrush (Colors.LavenderBlush); } }
		public static SolidColorBrush Lavender { get { return new SolidColorBrush (Colors.Lavender); } }
		public static SolidColorBrush LawnGreen { get { return new SolidColorBrush (Colors.LawnGreen); } }
		public static SolidColorBrush LemonChiffon { get { return new SolidColorBrush (Colors.LemonChiffon); } }
		public static SolidColorBrush LightBlue { get { return new SolidColorBrush (Colors.LightBlue); } }
		public static SolidColorBrush LightCoral { get { return new SolidColorBrush (Colors.LightCoral); } }
		public static SolidColorBrush LightCyan { get { return new SolidColorBrush (Colors.LightCyan); } }
		public static SolidColorBrush LightGoldenrodYellow { get { return new SolidColorBrush (Colors.LightGoldenrodYellow); } }
		public static SolidColorBrush LightGray { get { return new SolidColorBrush (Colors.LightGray); } }
		public static SolidColorBrush LightGreen { get { return new SolidColorBrush (Colors.LightGreen); } }
		public static SolidColorBrush LightPink { get { return new SolidColorBrush (Colors.LightPink); } }
		public static SolidColorBrush LightSalmon { get { return new SolidColorBrush (Colors.LightSalmon); } }
		public static SolidColorBrush LightSeaGreen { get { return new SolidColorBrush (Colors.LightSeaGreen); } }
		public static SolidColorBrush LightSkyBlue { get { return new SolidColorBrush (Colors.LightSkyBlue); } }
		public static SolidColorBrush LightSlateGray { get { return new SolidColorBrush (Colors.LightSlateGray); } }
		public static SolidColorBrush LightSteelBlue { get { return new SolidColorBrush (Colors.LightSteelBlue); } }
		public static SolidColorBrush LightYellow { get { return new SolidColorBrush (Colors.LightYellow); } }
		public static SolidColorBrush Lime { get { return new SolidColorBrush (Colors.Lime); } }
		public static SolidColorBrush LimeGreen { get { return new SolidColorBrush (Colors.LimeGreen); } }
		public static SolidColorBrush Linen { get { return new SolidColorBrush (Colors.Linen); } }
		public static SolidColorBrush Magenta { get { return new SolidColorBrush (Colors.Magenta); } }
		public static SolidColorBrush Maroon { get { return new SolidColorBrush (Colors.Maroon); } }
		public static SolidColorBrush MediumAquamarine { get { return new SolidColorBrush (Colors.MediumAquamarine); } }
		public static SolidColorBrush MediumBlue { get { return new SolidColorBrush (Colors.MediumBlue); } }
		public static SolidColorBrush MediumOrchid { get { return new SolidColorBrush (Colors.MediumOrchid); } }
		public static SolidColorBrush MediumPurple { get { return new SolidColorBrush (Colors.MediumPurple); } }
		public static SolidColorBrush MediumSeaGreen { get { return new SolidColorBrush (Colors.MediumSeaGreen); } }
		public static SolidColorBrush MediumSlateBlue { get { return new SolidColorBrush (Colors.MediumSlateBlue); } }
		public static SolidColorBrush MediumSpringGreen { get { return new SolidColorBrush (Colors.MediumSpringGreen); } }
		public static SolidColorBrush MediumTurquoise { get { return new SolidColorBrush (Colors.MediumTurquoise); } }
		public static SolidColorBrush MediumVioletRed { get { return new SolidColorBrush (Colors.MediumVioletRed); } }
		public static SolidColorBrush MidnightBlue { get { return new SolidColorBrush (Colors.MidnightBlue); } }
		public static SolidColorBrush MintCream { get { return new SolidColorBrush (Colors.MintCream); } }
		public static SolidColorBrush MistyRose { get { return new SolidColorBrush (Colors.MistyRose); } }
		public static SolidColorBrush Moccasin { get { return new SolidColorBrush (Colors.Moccasin); } }
		public static SolidColorBrush NavajoWhite { get { return new SolidColorBrush (Colors.NavajoWhite); } }
		public static SolidColorBrush Navy { get { return new SolidColorBrush (Colors.Navy); } }
		public static SolidColorBrush OldLace { get { return new SolidColorBrush (Colors.OldLace); } }
		public static SolidColorBrush OliveDrab { get { return new SolidColorBrush (Colors.OliveDrab); } }
		public static SolidColorBrush Olive { get { return new SolidColorBrush (Colors.Olive); } }
		public static SolidColorBrush Orange { get { return new SolidColorBrush (Colors.Orange); } }
		public static SolidColorBrush OrangeRed { get { return new SolidColorBrush (Colors.OrangeRed); } }
		public static SolidColorBrush Orchid { get { return new SolidColorBrush (Colors.Orchid); } }
		public static SolidColorBrush PaleGoldenrod { get { return new SolidColorBrush (Colors.PaleGoldenrod); } }
		public static SolidColorBrush PaleGreen { get { return new SolidColorBrush (Colors.PaleGreen); } }
		public static SolidColorBrush PaleTurquoise { get { return new SolidColorBrush (Colors.PaleTurquoise); } }
		public static SolidColorBrush PaleVioletRed { get { return new SolidColorBrush (Colors.PaleVioletRed); } }
		public static SolidColorBrush PapayaWhip { get { return new SolidColorBrush (Colors.PapayaWhip); } }
		public static SolidColorBrush PeachPuff { get { return new SolidColorBrush (Colors.PeachPuff); } }
		public static SolidColorBrush Peru { get { return new SolidColorBrush (Colors.Peru); } }
		public static SolidColorBrush Pink { get { return new SolidColorBrush (Colors.Pink); } }
		public static SolidColorBrush Plum { get { return new SolidColorBrush (Colors.Plum); } }
		public static SolidColorBrush PowderBlue { get { return new SolidColorBrush (Colors.PowderBlue); } }
		public static SolidColorBrush Purple { get { return new SolidColorBrush (Colors.Purple); } }
		public static SolidColorBrush Red { get { return new SolidColorBrush (Colors.Red); } }
		public static SolidColorBrush RosyBrown { get { return new SolidColorBrush (Colors.RosyBrown); } }
		public static SolidColorBrush RoyalBlue { get { return new SolidColorBrush (Colors.RoyalBlue); } }
		public static SolidColorBrush SaddleBrown { get { return new SolidColorBrush (Colors.SaddleBrown); } }
		public static SolidColorBrush Salmon { get { return new SolidColorBrush (Colors.Salmon); } }
		public static SolidColorBrush SandyBrown { get { return new SolidColorBrush (Colors.SandyBrown); } }
		public static SolidColorBrush SeaGreen { get { return new SolidColorBrush (Colors.SeaGreen); } }
		public static SolidColorBrush SeaShell { get { return new SolidColorBrush (Colors.SeaShell); } }
		public static SolidColorBrush Sienna { get { return new SolidColorBrush (Colors.Sienna); } }
		public static SolidColorBrush Silver { get { return new SolidColorBrush (Colors.Silver); } }
		public static SolidColorBrush SkyBlue { get { return new SolidColorBrush (Colors.SkyBlue); } }
		public static SolidColorBrush SlateBlue { get { return new SolidColorBrush (Colors.SlateBlue); } }
		public static SolidColorBrush SlateGray { get { return new SolidColorBrush (Colors.SlateGray); } }
		public static SolidColorBrush Snow { get { return new SolidColorBrush (Colors.Snow); } }
		public static SolidColorBrush SpringGreen { get { return new SolidColorBrush (Colors.SpringGreen); } }
		public static SolidColorBrush SteelBlue { get { return new SolidColorBrush (Colors.SteelBlue); } }
		public static SolidColorBrush Tan { get { return new SolidColorBrush (Colors.Tan); } }
		public static SolidColorBrush Teal { get { return new SolidColorBrush (Colors.Teal); } }
		public static SolidColorBrush Thistle { get { return new SolidColorBrush (Colors.Thistle); } }
		public static SolidColorBrush Tomato { get { return new SolidColorBrush (Colors.Tomato); } }
		public static SolidColorBrush Transparent { get { return new SolidColorBrush (Colors.Transparent); } }
		public static SolidColorBrush Turquoise { get { return new SolidColorBrush (Colors.Turquoise); } }
		public static SolidColorBrush Violet { get { return new SolidColorBrush (Colors.Violet); } }
		public static SolidColorBrush Wheat { get { return new SolidColorBrush (Colors.Wheat); } }
		public static SolidColorBrush White { get { return new SolidColorBrush (Colors.White); } }
		public static SolidColorBrush WhiteSmoke { get { return new SolidColorBrush (Colors.WhiteSmoke); } }
		public static SolidColorBrush Yellow { get { return new SolidColorBrush (Colors.Yellow); } }
		public static SolidColorBrush YellowGreen { get { return new SolidColorBrush (Colors.YellowGreen); } }
	}
}