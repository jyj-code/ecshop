using ShopNum1.QRCode.Geom;
using System;
namespace ShopNum1.QRCode.Codec.Util
{
	public class ConsoleCanvas : DebugCanvas
	{
		public void println(string string_Renamed)
		{
			Console.WriteLine(string_Renamed);
		}
		public void drawPoint(Point point, int color)
		{
		}
		public void drawCross(Point point, int color)
		{
		}
		public void drawPoints(Point[] points, int color)
		{
		}
		public void drawLine(Line line, int color)
		{
		}
		public void drawLines(Line[] lines, int color)
		{
		}
		public void drawPolygon(Point[] points, int color)
		{
		}
		public void drawMatrix(bool[][] matrix)
		{
		}
	}
}
