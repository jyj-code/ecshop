using ShopNum1.QRCode.Codec.Util;
using System;
namespace ShopNum1.QRCode.Geom
{
	public class Line
	{
		internal int int_0;
		internal int int_1;
		internal int int_2;
		internal int int_3;
		public virtual bool Horizontal
		{
			get
			{
				return this.int_1 == this.int_3;
			}
		}
		public virtual bool Vertical
		{
			get
			{
				return this.int_0 == this.int_2;
			}
		}
		public virtual Point Center
		{
			get
			{
				int num = (this.int_0 + this.int_2) / 2;
				int num2 = (this.int_1 + this.int_3) / 2;
				return new Point(num, num2);
			}
		}
		public virtual int Length
		{
			get
			{
				int num = Math.Abs(this.int_2 - this.int_0);
				int num2 = Math.Abs(this.int_3 - this.int_1);
				return QRCodeUtility.sqrt(num * num + num2 * num2);
			}
		}
		public Line()
		{
			this.int_3 = 0;
			this.int_2 = 0;
			this.int_1 = 0;
			this.int_0 = 0;
		}
		public Line(int int_4, int int_5, int int_6, int int_7)
		{
			this.int_0 = int_4;
			this.int_1 = int_5;
			this.int_2 = int_6;
			this.int_3 = int_7;
		}
		public Line(Point point_0, Point point_1)
		{
			this.int_0 = point_0.X;
			this.int_1 = point_0.Y;
			this.int_2 = point_1.X;
			this.int_3 = point_1.Y;
		}
		public virtual Point getP1()
		{
			return new Point(this.int_0, this.int_1);
		}
		public virtual Point getP2()
		{
			return new Point(this.int_2, this.int_3);
		}
		public virtual void setLine(int int_4, int int_5, int int_6, int int_7)
		{
			this.int_0 = int_4;
			this.int_1 = int_5;
			this.int_2 = int_6;
			this.int_3 = int_7;
		}
		public virtual void setP1(Point point_0)
		{
			this.int_0 = point_0.X;
			this.int_1 = point_0.Y;
		}
		public virtual void setP1(int int_4, int int_5)
		{
			this.int_0 = int_4;
			this.int_1 = int_5;
		}
		public virtual void setP2(Point point_0)
		{
			this.int_2 = point_0.X;
			this.int_3 = point_0.Y;
		}
		public virtual void setP2(int int_4, int int_5)
		{
			this.int_2 = int_4;
			this.int_3 = int_5;
		}
		public virtual void translate(int int_4, int int_5)
		{
			this.int_0 += int_4;
			this.int_1 += int_5;
			this.int_2 += int_4;
			this.int_3 += int_5;
		}
		public static bool isNeighbor(Line line1, Line line2)
		{
			return Math.Abs(line1.getP1().X - line2.getP1().X) < 2 && Math.Abs(line1.getP1().Y - line2.getP1().Y) < 2 && Math.Abs(line1.getP2().X - line2.getP2().X) < 2 && Math.Abs(line1.getP2().Y - line2.getP2().Y) < 2;
		}
		public static bool isCross(Line line1, Line line2)
		{
			bool result;
			if (line1.Horizontal && line2.Vertical)
			{
				if (line1.getP1().Y > line2.getP1().Y && line1.getP1().Y < line2.getP2().Y && line2.getP1().X > line1.getP1().X && line2.getP1().X < line1.getP2().X)
				{
					result = true;
					return result;
				}
			}
			else if (line1.Vertical && line2.Horizontal && line1.getP1().X > line2.getP1().X && line1.getP1().X < line2.getP2().X && line2.getP1().Y > line1.getP1().Y && line2.getP1().Y < line1.getP2().Y)
			{
				result = true;
				return result;
			}
			result = false;
			return result;
		}
		public static Line getLongest(Line[] lines)
		{
			Line line = new Line();
			for (int i = 0; i < lines.Length; i++)
			{
				if (lines[i].Length > line.Length)
				{
					line = lines[i];
				}
			}
			return line;
		}
		public override string ToString()
		{
			return string.Concat(new string[]
			{
				"(",
				Convert.ToString(this.int_0),
				",",
				Convert.ToString(this.int_1),
				")-(",
				Convert.ToString(this.int_2),
				",",
				Convert.ToString(this.int_3),
				")"
			});
		}
	}
}
