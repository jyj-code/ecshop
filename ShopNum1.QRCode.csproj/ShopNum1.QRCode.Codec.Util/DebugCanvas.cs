using ShopNum1.QRCode.Geom;
using System;
namespace ShopNum1.QRCode.Codec.Util
{
	public interface DebugCanvas
	{
		void println(string string_Renamed);
		void drawPoint(Point point, int color);
		void drawCross(Point point, int color);
		void drawPoints(Point[] points, int color);
		void drawLine(Line line, int color);
		void drawLines(Line[] lines, int color);
		void drawPolygon(Point[] points, int color);
		void drawMatrix(bool[][] matrix);
	}
}
