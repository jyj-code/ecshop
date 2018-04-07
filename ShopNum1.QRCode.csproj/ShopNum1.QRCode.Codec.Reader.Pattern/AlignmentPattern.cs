using ShopNum1.QRCode.Codec.Util;
using ShopNum1.QRCode.ExceptionHandler;
using ShopNum1.QRCode.Geom;
using System;
namespace ShopNum1.QRCode.Codec.Reader.Pattern
{
	public class AlignmentPattern
	{
		internal const int int_0 = 1;
		internal const int int_1 = 2;
		internal const int int_2 = 3;
		internal const int int_3 = 4;
		internal static DebugCanvas debugCanvas_0;
		internal Point[][] point_0;
		internal int int_4;
		public virtual int LogicalDistance
		{
			get
			{
				return this.int_4;
			}
		}
		internal AlignmentPattern(Point[][] point_1, int int_5)
		{
			this.point_0 = point_1;
			this.int_4 = int_5;
		}
		public static AlignmentPattern findAlignmentPattern(bool[][] image, FinderPattern finderPattern)
		{
			Point[][] logicalCenter = AlignmentPattern.getLogicalCenter(finderPattern);
			int int_ = logicalCenter[1][0].X - logicalCenter[0][0].X;
			Point[][] point_ = AlignmentPattern.smethod_0(image, finderPattern, logicalCenter);
			return new AlignmentPattern(point_, int_);
		}
		public virtual Point[][] getCenter()
		{
			return this.point_0;
		}
		public virtual void setCenter(Point[][] center)
		{
			this.point_0 = center;
		}
		internal static Point[][] smethod_0(bool[][] bool_0, FinderPattern finderPattern_0, Point[][] point_1)
		{
			int moduleSize = finderPattern_0.getModuleSize();
			Axis axis = new Axis(finderPattern_0.getAngle(), moduleSize);
			int num = point_1.Length;
			Point[][] array = new Point[num][];
			for (int i = 0; i < num; i++)
			{
				array[i] = new Point[num];
			}
			axis.Origin = finderPattern_0.getCenter(0);
			array[0][0] = axis.translate(3, 3);
			AlignmentPattern.debugCanvas_0.drawCross(array[0][0], Color_Fields.BLUE);
			axis.Origin = finderPattern_0.getCenter(1);
			array[num - 1][0] = axis.translate(-3, 3);
			AlignmentPattern.debugCanvas_0.drawCross(array[num - 1][0], Color_Fields.BLUE);
			axis.Origin = finderPattern_0.getCenter(2);
			array[0][num - 1] = axis.translate(3, -3);
			AlignmentPattern.debugCanvas_0.drawCross(array[0][num - 1], Color_Fields.BLUE);
			Point point = array[0][0];
			for (int j = 0; j < num; j++)
			{
				int k = 0;
				while (k < num)
				{
					if (k == 0 && j == 0)
					{
						goto IL_FB;
					}
					if (k == 0)
					{
						if (j == num - 1)
						{
							goto IL_FB;
						}
					}
					bool arg_110_0 = k != num - 1 || j != 0;
					IL_110:
					if (arg_110_0)
					{
						Point point2 = null;
						if (j == 0)
						{
							if (k > 0 && k < num - 1)
							{
								point2 = axis.translate(array[k - 1][j], point_1[k][j].X - point_1[k - 1][j].X, 0);
							}
							array[k][j] = new Point(point2.X, point2.Y);
							AlignmentPattern.debugCanvas_0.drawCross(array[k][j], Color_Fields.RED);
						}
						else if (k == 0)
						{
							if (j > 0 && j < num - 1)
							{
								point2 = axis.translate(array[k][j - 1], 0, point_1[k][j].Y - point_1[k][j - 1].Y);
							}
							array[k][j] = new Point(point2.X, point2.Y);
							AlignmentPattern.debugCanvas_0.drawCross(array[k][j], Color_Fields.RED);
						}
						else
						{
							Point point3 = axis.translate(array[k - 1][j], point_1[k][j].X - point_1[k - 1][j].X, 0);
							Point point4 = axis.translate(array[k][j - 1], 0, point_1[k][j].Y - point_1[k][j - 1].Y);
							array[k][j] = new Point((point3.X + point4.X) / 2, (point3.Y + point4.Y) / 2 + 1);
						}
						if (finderPattern_0.Version > 1)
						{
							Point point5 = AlignmentPattern.smethod_1(bool_0, array[k][j]);
							if (array[k][j].distanceOf(point5) < 6)
							{
								AlignmentPattern.debugCanvas_0.drawCross(array[k][j], Color_Fields.RED);
								int num2 = point5.X - array[k][j].X;
								int num3 = point5.Y - array[k][j].Y;
								AlignmentPattern.debugCanvas_0.println(string.Concat(new object[]
								{
									"Adjust AP(",
									k,
									",",
									j,
									") to d(",
									num2,
									",",
									num3,
									")"
								}));
								array[k][j] = point5;
							}
						}
						AlignmentPattern.debugCanvas_0.drawCross(array[k][j], Color_Fields.BLUE);
						AlignmentPattern.debugCanvas_0.drawLine(new Line(point, array[k][j]), Color_Fields.LIGHTBLUE);
						point = array[k][j];
					}
					k++;
					continue;
					IL_FB:
					arg_110_0 = false;
					goto IL_110;
				}
			}
			return array;
		}
		internal static Point smethod_1(bool[][] bool_0, Point point_1)
		{
			int x = point_1.X;
			int y = point_1.Y;
			if (x < 0 || y < 0 || x > bool_0.Length - 1 || y > bool_0[0].Length - 1)
			{
				throw new AlignmentPatternNotFoundException("Alignment Pattern finder exceeded out of image");
			}
			if (!bool_0[point_1.X][point_1.Y])
			{
				int num = 0;
				bool flag = false;
				while (!flag)
				{
					num++;
					for (int i = num; i > -num; i--)
					{
						for (int j = num; j > -num; j--)
						{
							int num2 = point_1.X + j;
							int num3 = point_1.Y + i;
							if (num2 < 0 || num3 < 0 || num2 > bool_0.Length - 1 || num3 > bool_0[0].Length - 1)
							{
								throw new AlignmentPatternNotFoundException("Alignment Pattern finder exceeded out of image");
							}
							if (bool_0[num2][num3])
							{
								point_1 = new Point(point_1.X + j, point_1.Y + i);
								flag = true;
							}
						}
					}
				}
			}
			int num6;
			int num5;
			int num4 = num5 = (num6 = point_1.X);
			int num9;
			int num8;
			int num7 = num8 = (num9 = point_1.Y);
			while (num4 >= 1 && !AlignmentPattern.smethod_2(bool_0, num4, num8, num4 - 1, num8))
			{
				num4--;
			}
			while (num6 < bool_0.Length - 1 && !AlignmentPattern.smethod_2(bool_0, num6, num8, num6 + 1, num8))
			{
				num6++;
			}
			while (num7 >= 1 && !AlignmentPattern.smethod_2(bool_0, num5, num7, num5, num7 - 1))
			{
				num7--;
			}
			while (num9 < bool_0[0].Length - 1 && !AlignmentPattern.smethod_2(bool_0, num5, num9, num5, num9 + 1))
			{
				num9++;
			}
			return new Point((num4 + num6 + 1) / 2, (num7 + num9 + 1) / 2);
		}
		internal static bool smethod_2(bool[][] bool_0, int int_5, int int_6, int int_7, int int_8)
		{
			if (int_5 < 0 || int_6 < 0 || int_7 < 0 || int_8 < 0 || int_5 > bool_0.Length || int_6 > bool_0[0].Length || int_7 > bool_0.Length || int_8 > bool_0[0].Length)
			{
				throw new AlignmentPatternNotFoundException("Alignment Pattern Finder exceeded image edge");
			}
			return !bool_0[int_5][int_6] && bool_0[int_7][int_8];
		}
		public static Point[][] getLogicalCenter(FinderPattern finderPattern)
		{
			int version = finderPattern.Version;
			Point[][] array = new Point[1][];
			for (int i = 0; i < 1; i++)
			{
				array[i] = new Point[1];
			}
			int[] array2 = new int[1];
			array2 = LogicalSeed.getSeed(version);
			array = new Point[array2.Length][];
			for (int j = 0; j < array2.Length; j++)
			{
				array[j] = new Point[array2.Length];
			}
			for (int k = 0; k < array.Length; k++)
			{
				for (int l = 0; l < array.Length; l++)
				{
					array[l][k] = new Point(array2[l], array2[k]);
				}
			}
			return array;
		}
		static AlignmentPattern()
		{
			AlignmentPattern.debugCanvas_0 = QRCodeDecoder.Canvas;
		}
	}
}
