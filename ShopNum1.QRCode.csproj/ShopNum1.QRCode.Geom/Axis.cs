using ShopNum1.QRCode.Codec.Reader;
using System;
namespace ShopNum1.QRCode.Geom
{
	public class Axis
	{
		internal int int_0;
		internal int int_1;
		internal int int_2;
		internal Point point_0;
		public virtual Point Origin
		{
			set
			{
				this.point_0 = value;
			}
		}
		public virtual int ModulePitch
		{
			set
			{
				this.int_2 = value;
			}
		}
		public Axis(int[] angle, int modulePitch)
		{
			this.int_0 = angle[0];
			this.int_1 = angle[1];
			this.int_2 = modulePitch;
			this.point_0 = new Point();
		}
		public virtual Point translate(Point offset)
		{
			int x = offset.X;
			int y = offset.Y;
			return this.translate(x, y);
		}
		public virtual Point translate(Point origin, Point offset)
		{
			this.Origin = origin;
			int x = offset.X;
			int y = offset.Y;
			return this.translate(x, y);
		}
		public virtual Point translate(Point origin, int moveX, int moveY)
		{
			this.Origin = origin;
			return this.translate(moveX, moveY);
		}
		public virtual Point translate(Point origin, int modulePitch, int moveX, int moveY)
		{
			this.Origin = origin;
			this.int_2 = modulePitch;
			return this.translate(moveX, moveY);
		}
		public virtual Point translate(int moveX, int moveY)
		{
			long num = (long)QRCodeImageReader.DECIMAL_POINT;
			Point point = new Point();
			int num2 = (moveX == 0) ? 0 : (this.int_2 * moveX >> (int)num);
			int num3 = (moveY == 0) ? 0 : (this.int_2 * moveY >> (int)num);
			point.translate(num2 * this.int_1 - num3 * this.int_0 >> (int)num, num2 * this.int_0 + num3 * this.int_1 >> (int)num);
			point.translate(this.point_0.X, this.point_0.Y);
			return point;
		}
	}
}
