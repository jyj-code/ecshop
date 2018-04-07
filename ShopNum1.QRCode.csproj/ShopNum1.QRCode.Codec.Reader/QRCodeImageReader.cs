using ShopNum1.QRCode.Codec.Data;
using ShopNum1.QRCode.Codec.Reader.Pattern;
using ShopNum1.QRCode.Codec.Util;
using ShopNum1.QRCode.ExceptionHandler;
using ShopNum1.QRCode.Geom;
using System;
using System.Collections;
namespace ShopNum1.QRCode.Codec.Reader
{
	public class QRCodeImageReader
	{
		private class Class2
		{
			public int int_0;
			public int int_1;
			public int int_2;
			public int int_3;
			private QRCodeImageReader qrcodeImageReader_0;
			public Class2(QRCodeImageReader qrcodeImageReader_1)
			{
				this.method_0(qrcodeImageReader_1);
			}
			private void method_0(QRCodeImageReader qrcodeImageReader_1)
			{
				this.qrcodeImageReader_0 = qrcodeImageReader_1;
			}
			public QRCodeImageReader method_1()
			{
				return this.qrcodeImageReader_0;
			}
		}
		public const bool POINT_DARK = true;
		public const bool POINT_LIGHT = false;
		internal DebugCanvas debugCanvas_0;
		public static int DECIMAL_POINT = 21;
		internal SamplingGrid samplingGrid_0;
		internal bool[][] bool_0;
		public QRCodeImageReader()
		{
			this.debugCanvas_0 = QRCodeDecoder.Canvas;
		}
		internal virtual bool[][] applyMedianFilter(bool[][] image, int threshold)
		{
			bool[][] array = new bool[image.Length][];
			for (int i = 0; i < image.Length; i++)
			{
				array[i] = new bool[image[0].Length];
			}
			for (int j = 1; j < image[0].Length - 1; j++)
			{
				for (int k = 1; k < image.Length - 1; k++)
				{
					int num = 0;
					for (int l = -1; l < 2; l++)
					{
						for (int m = -1; m < 2; m++)
						{
							if (image[k + m][j + l])
							{
								num++;
							}
						}
					}
					if (num > threshold)
					{
						array[k][j] = true;
					}
				}
			}
			return array;
		}
		internal virtual bool[][] applyCrossMaskingMedianFilter(bool[][] image, int threshold)
		{
			bool[][] array = new bool[image.Length][];
			for (int i = 0; i < image.Length; i++)
			{
				array[i] = new bool[image[0].Length];
			}
			for (int j = 2; j < image[0].Length - 2; j++)
			{
				for (int k = 2; k < image.Length - 2; k++)
				{
					int num = 0;
					for (int l = -2; l < 3; l++)
					{
						if (image[k + l][j])
						{
							num++;
						}
						if (image[k][j + l])
						{
							num++;
						}
					}
					if (num > threshold)
					{
						array[k][j] = true;
					}
				}
			}
			return array;
		}
		internal virtual bool[][] filterImage(int[][] image)
		{
			this.imageToGrayScale(image);
			return this.grayScaleToBitmap(image);
		}
		internal virtual void imageToGrayScale(int[][] image)
		{
			for (int i = 0; i < image[0].Length; i++)
			{
				for (int j = 0; j < image.Length; j++)
				{
					int num = image[j][i] >> 16 & 255;
					int num2 = image[j][i] >> 8 & 255;
					int num3 = image[j][i] & 255;
					int num4 = (num * 30 + num2 * 59 + num3 * 11) / 100;
					image[j][i] = num4;
				}
			}
		}
		internal virtual bool[][] grayScaleToBitmap(int[][] grayScale)
		{
			int[][] middleBrightnessPerArea = this.getMiddleBrightnessPerArea(grayScale);
			int num = middleBrightnessPerArea.Length;
			int num2 = grayScale.Length / num;
			int num3 = grayScale[0].Length / num;
			bool[][] array = new bool[grayScale.Length][];
			for (int i = 0; i < grayScale.Length; i++)
			{
				array[i] = new bool[grayScale[0].Length];
			}
			for (int j = 0; j < num; j++)
			{
				for (int k = 0; k < num; k++)
				{
					for (int l = 0; l < num3; l++)
					{
						for (int m = 0; m < num2; m++)
						{
							array[num2 * k + m][num3 * j + l] = ((grayScale[num2 * k + m][num3 * j + l] < middleBrightnessPerArea[k][j]) ? true : false);
						}
					}
				}
			}
			return array;
		}
		internal virtual int[][] getMiddleBrightnessPerArea(int[][] image)
		{
			int num = 4;
			int num2 = image.Length / 4;
			int num3 = image[0].Length / 4;
			int[][][] array = new int[4][][];
			for (int i = 0; i < num; i++)
			{
				array[i] = new int[num][];
				for (int j = 0; j < num; j++)
				{
					array[i][j] = new int[2];
				}
			}
			for (int k = 0; k < num; k++)
			{
				for (int l = 0; l < num; l++)
				{
					array[l][k][0] = 255;
					for (int m = 0; m < num3; m++)
					{
						for (int n = 0; n < num2; n++)
						{
							int num4 = image[num2 * l + n][num3 * k + m];
							if (num4 < array[l][k][0])
							{
								array[l][k][0] = num4;
							}
							if (num4 > array[l][k][1])
							{
								array[l][k][1] = num4;
							}
						}
					}
				}
			}
			int[][] array2 = new int[num][];
			for (int num5 = 0; num5 < num; num5++)
			{
				array2[num5] = new int[num];
			}
			for (int k = 0; k < num; k++)
			{
				for (int l = 0; l < num; l++)
				{
					array2[l][k] = (array[l][k][0] + array[l][k][1]) / 2;
				}
			}
			return array2;
		}
		public virtual QRCodeSymbol getQRCodeSymbol(int[][] image)
		{
			int num = (image.Length < image[0].Length) ? image[0].Length : image.Length;
			QRCodeImageReader.DECIMAL_POINT = 23 - QRCodeUtility.sqrt(num / 256);
			this.bool_0 = this.filterImage(image);
			this.debugCanvas_0.println("Drawing matrix.");
			this.debugCanvas_0.drawMatrix(this.bool_0);
			this.debugCanvas_0.println("Scanning Finder Pattern.");
			FinderPattern finderPattern = null;
			try
			{
				finderPattern = FinderPattern.findFinderPattern(this.bool_0);
			}
			catch (FinderPatternNotFoundException)
			{
				this.debugCanvas_0.println("Not found, now retrying...");
				this.bool_0 = this.applyCrossMaskingMedianFilter(this.bool_0, 5);
				this.debugCanvas_0.drawMatrix(this.bool_0);
				for (int i = 0; i < 1000000000; i++)
				{
				}
				try
				{
					finderPattern = FinderPattern.findFinderPattern(this.bool_0);
				}
				catch (FinderPatternNotFoundException ex)
				{
					throw new SymbolNotFoundException(ex.Message);
				}
				catch (VersionInformationException ex2)
				{
					throw new SymbolNotFoundException(ex2.Message);
				}
			}
			catch (VersionInformationException ex3)
			{
				throw new SymbolNotFoundException(ex3.Message);
			}
			this.debugCanvas_0.println("FinderPattern at");
			string string_Renamed = finderPattern.getCenter(0).ToString() + finderPattern.getCenter(1).ToString() + finderPattern.getCenter(2).ToString();
			this.debugCanvas_0.println(string_Renamed);
			int[] angle = finderPattern.getAngle();
			this.debugCanvas_0.println("Angle*4098: Sin " + Convert.ToString(angle[0]) + "  Cos " + Convert.ToString(angle[1]));
			int version = finderPattern.Version;
			this.debugCanvas_0.println("Version: " + Convert.ToString(version));
			if (version < 1 || version > 40)
			{
				throw new InvalidVersionException("Invalid version: " + version);
			}
			AlignmentPattern alignmentPattern = null;
			try
			{
				alignmentPattern = AlignmentPattern.findAlignmentPattern(this.bool_0, finderPattern);
			}
			catch (AlignmentPatternNotFoundException ex4)
			{
				throw new SymbolNotFoundException(ex4.Message);
			}
			int num2 = alignmentPattern.getCenter().Length;
			this.debugCanvas_0.println("AlignmentPatterns at");
			for (int j = 0; j < num2; j++)
			{
				string text = "";
				for (int k = 0; k < num2; k++)
				{
					text += alignmentPattern.getCenter()[k][j].ToString();
				}
				this.debugCanvas_0.println(text);
			}
			this.debugCanvas_0.println("Creating sampling grid.");
			this.samplingGrid_0 = this.getSamplingGrid(finderPattern, alignmentPattern);
			this.debugCanvas_0.println("Reading grid.");
			bool[][] moduleMatrix = null;
			try
			{
				moduleMatrix = this.getQRCodeMatrix(this.bool_0, this.samplingGrid_0);
			}
			catch (IndexOutOfRangeException)
			{
				throw new SymbolNotFoundException("Sampling grid exceeded image boundary");
			}
			return new QRCodeSymbol(moduleMatrix);
		}
		public virtual QRCodeSymbol getQRCodeSymbolWithAdjustedGrid(Point adjust)
		{
			if (this.bool_0 == null || this.samplingGrid_0 == null)
			{
				throw new SystemException("This method must be called after QRCodeImageReader.getQRCodeSymbol() called");
			}
			this.samplingGrid_0.adjust(adjust);
			this.debugCanvas_0.println(string.Concat(new object[]
			{
				"Sampling grid adjusted d(",
				adjust.X,
				",",
				adjust.Y,
				")"
			}));
			bool[][] moduleMatrix = null;
			try
			{
				moduleMatrix = this.getQRCodeMatrix(this.bool_0, this.samplingGrid_0);
			}
			catch (IndexOutOfRangeException)
			{
				throw new SymbolNotFoundException("Sampling grid exceeded image boundary");
			}
			return new QRCodeSymbol(moduleMatrix);
		}
		internal virtual SamplingGrid getSamplingGrid(FinderPattern finderPattern, AlignmentPattern alignmentPattern)
		{
			Point[][] center = alignmentPattern.getCenter();
			int version = finderPattern.Version;
			int num = version / 7 + 2;
			center[0][0] = finderPattern.getCenter(0);
			center[num - 1][0] = finderPattern.getCenter(1);
			center[0][num - 1] = finderPattern.getCenter(2);
			int num2 = num - 1;
			SamplingGrid samplingGrid = new SamplingGrid(num2);
			Axis axis = new Axis(finderPattern.getAngle(), finderPattern.getModuleSize());
			for (int i = 0; i < num2; i++)
			{
				for (int j = 0; j < num2; j++)
				{
					QRCodeImageReader.Class2 @class = new QRCodeImageReader.Class2(this);
					Line line = new Line();
					Line line2 = new Line();
					axis.ModulePitch = finderPattern.getModuleSize();
					Point[][] logicalCenter = AlignmentPattern.getLogicalCenter(finderPattern);
					Point point = center[j][i];
					Point point2 = center[j + 1][i];
					Point point3 = center[j][i + 1];
					Point point4 = center[j + 1][i + 1];
					Point point5 = logicalCenter[j][i];
					Point point6 = logicalCenter[j + 1][i];
					Point point7 = logicalCenter[j][i + 1];
					Point point8 = logicalCenter[j + 1][i + 1];
					if (j == 0 && i == 0)
					{
						if (num2 == 1)
						{
							point = axis.translate(point, -3, -3);
							point2 = axis.translate(point2, 3, -3);
							point3 = axis.translate(point3, -3, 3);
							point4 = axis.translate(point4, 6, 6);
							point5.translate(-6, -6);
							point6.translate(3, -3);
							point7.translate(-3, 3);
							point8.translate(6, 6);
						}
						else
						{
							point = axis.translate(point, -3, -3);
							point2 = axis.translate(point2, 0, -6);
							point3 = axis.translate(point3, -6, 0);
							point5.translate(-6, -6);
							point6.translate(0, -6);
							point7.translate(-6, 0);
						}
					}
					else if (j == 0 && i == num2 - 1)
					{
						point = axis.translate(point, -6, 0);
						point3 = axis.translate(point3, -3, 3);
						point4 = axis.translate(point4, 0, 6);
						point5.translate(-6, 0);
						point7.translate(-6, 6);
						point8.translate(0, 6);
					}
					else if (j == num2 - 1 && i == 0)
					{
						point = axis.translate(point, 0, -6);
						point2 = axis.translate(point2, 3, -3);
						point4 = axis.translate(point4, 6, 0);
						point5.translate(0, -6);
						point6.translate(6, -6);
						point8.translate(6, 0);
					}
					else if (j == num2 - 1 && i == num2 - 1)
					{
						point3 = axis.translate(point3, 0, 6);
						point2 = axis.translate(point2, 6, 0);
						point4 = axis.translate(point4, 6, 6);
						point7.translate(0, 6);
						point6.translate(6, 0);
						point8.translate(6, 6);
					}
					else if (j == 0)
					{
						point = axis.translate(point, -6, 0);
						point3 = axis.translate(point3, -6, 0);
						point5.translate(-6, 0);
						point7.translate(-6, 0);
					}
					else if (j == num2 - 1)
					{
						point2 = axis.translate(point2, 6, 0);
						point4 = axis.translate(point4, 6, 0);
						point6.translate(6, 0);
						point8.translate(6, 0);
					}
					else if (i == 0)
					{
						point = axis.translate(point, 0, -6);
						point2 = axis.translate(point2, 0, -6);
						point5.translate(0, -6);
						point6.translate(0, -6);
					}
					else if (i == num2 - 1)
					{
						point3 = axis.translate(point3, 0, 6);
						point4 = axis.translate(point4, 0, 6);
						point7.translate(0, 6);
						point8.translate(0, 6);
					}
					if (j == 0)
					{
						point6.translate(1, 0);
						point8.translate(1, 0);
					}
					else
					{
						point5.translate(-1, 0);
						point7.translate(-1, 0);
					}
					if (i == 0)
					{
						point7.translate(0, 1);
						point8.translate(0, 1);
					}
					else
					{
						point5.translate(0, -1);
						point6.translate(0, -1);
					}
					int num3 = point6.X - point5.X;
					int num4 = point7.Y - point5.Y;
					if (version < 7)
					{
						num3 += 3;
						num4 += 3;
					}
					@class.int_0 = this.getAreaModulePitch(point, point2, num3 - 1);
					@class.int_1 = this.getAreaModulePitch(point, point3, num4 - 1);
					@class.int_2 = this.getAreaModulePitch(point3, point4, num3 - 1);
					@class.int_3 = this.getAreaModulePitch(point2, point4, num4 - 1);
					line.setP1(point);
					line2.setP1(point);
					line.setP2(point3);
					line2.setP2(point2);
					samplingGrid.initGrid(j, i, num3, num4);
					for (int k = 0; k < num3; k++)
					{
						Line line3 = new Line(line.getP1(), line.getP2());
						axis.Origin = line3.getP1();
						axis.ModulePitch = @class.int_0;
						line3.setP1(axis.translate(k, 0));
						axis.Origin = line3.getP2();
						axis.ModulePitch = @class.int_2;
						line3.setP2(axis.translate(k, 0));
						samplingGrid.setXLine(j, i, k, line3);
					}
					for (int k = 0; k < num4; k++)
					{
						Line line4 = new Line(line2.getP1(), line2.getP2());
						axis.Origin = line4.getP1();
						axis.ModulePitch = @class.int_1;
						line4.setP1(axis.translate(0, k));
						axis.Origin = line4.getP2();
						axis.ModulePitch = @class.int_3;
						line4.setP2(axis.translate(0, k));
						samplingGrid.setYLine(j, i, k, line4);
					}
				}
			}
			return samplingGrid;
		}
		internal virtual int getAreaModulePitch(Point start, Point point_0, int logicalDistance)
		{
			Line line = new Line(start, point_0);
			int length = line.Length;
			return (length << QRCodeImageReader.DECIMAL_POINT) / logicalDistance;
		}
		internal virtual bool[][] getQRCodeMatrix(bool[][] image, SamplingGrid gridLines)
		{
			int totalWidth = gridLines.TotalWidth;
			this.debugCanvas_0.println("gridSize=" + totalWidth);
			Point point = null;
			bool[][] array = new bool[totalWidth][];
			for (int i = 0; i < totalWidth; i++)
			{
				array[i] = new bool[totalWidth];
			}
			for (int j = 0; j < gridLines.getHeight(); j++)
			{
				for (int k = 0; k < gridLines.getWidth(); k++)
				{
					ArrayList.Synchronized(new ArrayList(10));
					for (int l = 0; l < gridLines.getHeight(k, j); l++)
					{
						for (int m = 0; m < gridLines.getWidth(k, j); m++)
						{
							int x = gridLines.getXLine(k, j, m).getP1().X;
							int y = gridLines.getXLine(k, j, m).getP1().Y;
							int x2 = gridLines.getXLine(k, j, m).getP2().X;
							int y2 = gridLines.getXLine(k, j, m).getP2().Y;
							int x3 = gridLines.getYLine(k, j, l).getP1().X;
							int y3 = gridLines.getYLine(k, j, l).getP1().Y;
							int x4 = gridLines.getYLine(k, j, l).getP2().X;
							int y4 = gridLines.getYLine(k, j, l).getP2().Y;
							int num = (y2 - y) * (x3 - x4) - (y4 - y3) * (x - x2);
							int num2 = (x * y2 - x2 * y) * (x3 - x4) - (x3 * y4 - x4 * y3) * (x - x2);
							int num3 = (x3 * y4 - x4 * y3) * (y2 - y) - (x * y2 - x2 * y) * (y4 - y3);
							array[gridLines.getX(k, m)][gridLines.getY(j, l)] = image[num2 / num][num3 / num];
							if (j == gridLines.getHeight() - 1 && k == gridLines.getWidth() - 1 && l == gridLines.getHeight(k, j) - 1 && m == gridLines.getWidth(k, j) - 1)
							{
								point = new Point(num2 / num, num3 / num);
							}
						}
					}
				}
			}
			if (point.X > image.Length - 1 || point.Y > image[0].Length - 1)
			{
				throw new IndexOutOfRangeException("Sampling grid pointed out of image");
			}
			this.debugCanvas_0.drawPoint(point, Color_Fields.BLUE);
			return array;
		}
	}
}
