using System;
namespace ShopNum1.QRCode.Geom
{
	public class SamplingGrid
	{
		private class Class0
		{
			private SamplingGrid samplingGrid_0;
			private Line[] line_0;
			private Line[] line_1;
			private void method_0(SamplingGrid samplingGrid_1)
			{
				this.samplingGrid_0 = samplingGrid_1;
			}
			public virtual int vmethod_0()
			{
				return this.line_0.Length;
			}
			public virtual int vmethod_1()
			{
				return this.line_1.Length;
			}
			public virtual Line[] vmethod_2()
			{
				return this.line_0;
			}
			public virtual Line[] vmethod_3()
			{
				return this.line_1;
			}
			public SamplingGrid method_1()
			{
				return this.samplingGrid_0;
			}
			public Class0(SamplingGrid samplingGrid_1, int int_0, int int_1)
			{
				this.method_0(samplingGrid_1);
				this.line_0 = new Line[int_0];
				this.line_1 = new Line[int_1];
			}
			public virtual Line vmethod_4(int int_0)
			{
				return this.line_0[int_0];
			}
			public virtual Line vmethod_5(int int_0)
			{
				return this.line_1[int_0];
			}
			public virtual void vmethod_6(int int_0, Line line_2)
			{
				this.line_0[int_0] = line_2;
			}
			public virtual void vmethod_7(int int_0, Line line_2)
			{
				this.line_1[int_0] = line_2;
			}
		}
		private SamplingGrid.Class0[][] class0_0;
		public virtual int TotalWidth
		{
			get
			{
				int num = 0;
				for (int i = 0; i < this.class0_0.Length; i++)
				{
					num += this.class0_0[i][0].vmethod_0();
					if (i > 0)
					{
						num--;
					}
				}
				return num;
			}
		}
		public virtual int TotalHeight
		{
			get
			{
				int num = 0;
				for (int i = 0; i < this.class0_0[0].Length; i++)
				{
					num += this.class0_0[0][i].vmethod_1();
					if (i > 0)
					{
						num--;
					}
				}
				return num;
			}
		}
		public SamplingGrid(int sqrtNumArea)
		{
			this.class0_0 = new SamplingGrid.Class0[sqrtNumArea][];
			for (int i = 0; i < sqrtNumArea; i++)
			{
				this.class0_0[i] = new SamplingGrid.Class0[sqrtNumArea];
			}
		}
		public virtual void initGrid(int int_0, int int_1, int width, int height)
		{
			this.class0_0[int_0][int_1] = new SamplingGrid.Class0(this, width, height);
		}
		public virtual void setXLine(int int_0, int int_1, int int_2, Line line)
		{
			this.class0_0[int_0][int_1].vmethod_6(int_2, line);
		}
		public virtual void setYLine(int int_0, int int_1, int int_2, Line line)
		{
			this.class0_0[int_0][int_1].vmethod_7(int_2, line);
		}
		public virtual Line getXLine(int int_0, int int_1, int int_2)
		{
			return this.class0_0[int_0][int_1].vmethod_4(int_2);
		}
		public virtual Line getYLine(int int_0, int int_1, int int_2)
		{
			return this.class0_0[int_0][int_1].vmethod_5(int_2);
		}
		public virtual Line[] getXLines(int int_0, int int_1)
		{
			return this.class0_0[int_0][int_1].vmethod_2();
		}
		public virtual Line[] getYLines(int int_0, int int_1)
		{
			return this.class0_0[int_0][int_1].vmethod_3();
		}
		public virtual int getWidth()
		{
			return this.class0_0[0].Length;
		}
		public virtual int getHeight()
		{
			return this.class0_0.Length;
		}
		public virtual int getWidth(int int_0, int int_1)
		{
			return this.class0_0[int_0][int_1].vmethod_0();
		}
		public virtual int getHeight(int int_0, int int_1)
		{
			return this.class0_0[int_0][int_1].vmethod_1();
		}
		public virtual int getX(int int_0, int int_1)
		{
			int num = int_1;
			for (int i = 0; i < int_0; i++)
			{
				num += this.class0_0[i][0].vmethod_0() - 1;
			}
			return num;
		}
		public virtual int getY(int int_0, int int_1)
		{
			int num = int_1;
			for (int i = 0; i < int_0; i++)
			{
				num += this.class0_0[0][i].vmethod_1() - 1;
			}
			return num;
		}
		public virtual void adjust(Point adjust)
		{
			int x = adjust.X;
			int y = adjust.Y;
			for (int i = 0; i < this.class0_0[0].Length; i++)
			{
				for (int j = 0; j < this.class0_0.Length; j++)
				{
					for (int k = 0; k < this.class0_0[j][i].vmethod_2().Length; k++)
					{
						this.class0_0[j][i].vmethod_2()[k].translate(x, y);
					}
					for (int l = 0; l < this.class0_0[j][i].vmethod_3().Length; l++)
					{
						this.class0_0[j][i].vmethod_3()[l].translate(x, y);
					}
				}
			}
		}
	}
}
