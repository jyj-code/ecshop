using ShopNum1.QRCode.Codec.Ecc;
using ShopNum1.QRCode.Codec.Reader.Pattern;
using ShopNum1.QRCode.Codec.Util;
using ShopNum1.QRCode.Geom;
using System;
using System.Collections;
namespace ShopNum1.QRCode.Codec.Data
{
	public class QRCodeSymbol
	{
		internal int int_0;
		internal int int_1;
		internal int int_2;
		internal int int_3;
		internal bool[][] bool_0;
		internal int int_4;
		internal int int_5;
		internal Point[][] point_0;
		internal int[][] int_6 = new int[][]
		{
			new int[]
			{
				7,
				10,
				13,
				17
			},
			new int[]
			{
				10,
				16,
				22,
				28
			},
			new int[]
			{
				15,
				26,
				36,
				44
			},
			new int[]
			{
				20,
				36,
				52,
				64
			},
			new int[]
			{
				26,
				48,
				72,
				88
			},
			new int[]
			{
				36,
				64,
				96,
				112
			},
			new int[]
			{
				40,
				72,
				108,
				130
			},
			new int[]
			{
				48,
				88,
				132,
				156
			},
			new int[]
			{
				60,
				110,
				160,
				192
			},
			new int[]
			{
				72,
				130,
				192,
				224
			},
			new int[]
			{
				80,
				150,
				224,
				264
			},
			new int[]
			{
				96,
				176,
				260,
				308
			},
			new int[]
			{
				104,
				198,
				288,
				352
			},
			new int[]
			{
				120,
				216,
				320,
				384
			},
			new int[]
			{
				132,
				240,
				360,
				432
			},
			new int[]
			{
				144,
				280,
				408,
				480
			},
			new int[]
			{
				168,
				308,
				448,
				532
			},
			new int[]
			{
				180,
				338,
				504,
				588
			},
			new int[]
			{
				196,
				364,
				546,
				650
			},
			new int[]
			{
				224,
				416,
				600,
				700
			},
			new int[]
			{
				224,
				442,
				644,
				750
			},
			new int[]
			{
				252,
				476,
				690,
				816
			},
			new int[]
			{
				270,
				504,
				750,
				900
			},
			new int[]
			{
				300,
				560,
				810,
				960
			},
			new int[]
			{
				312,
				588,
				870,
				1050
			},
			new int[]
			{
				336,
				644,
				952,
				1110
			},
			new int[]
			{
				360,
				700,
				1020,
				1200
			},
			new int[]
			{
				390,
				728,
				1050,
				1260
			},
			new int[]
			{
				420,
				784,
				1140,
				1350
			},
			new int[]
			{
				450,
				812,
				1200,
				1440
			},
			new int[]
			{
				480,
				868,
				1290,
				1530
			},
			new int[]
			{
				510,
				924,
				1350,
				1620
			},
			new int[]
			{
				540,
				980,
				1440,
				1710
			},
			new int[]
			{
				570,
				1036,
				1530,
				1800
			},
			new int[]
			{
				570,
				1064,
				1590,
				1890
			},
			new int[]
			{
				600,
				1120,
				1680,
				1980
			},
			new int[]
			{
				630,
				1204,
				1770,
				2100
			},
			new int[]
			{
				660,
				1260,
				1860,
				2220
			},
			new int[]
			{
				720,
				1316,
				1950,
				2310
			},
			new int[]
			{
				750,
				1372,
				2040,
				2430
			}
		};
		internal int[][] int_7 = new int[][]
		{
			new int[]
			{
				1,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				1,
				1
			},
			new int[]
			{
				1,
				1,
				2,
				2
			},
			new int[]
			{
				1,
				2,
				2,
				4
			},
			new int[]
			{
				1,
				2,
				4,
				4
			},
			new int[]
			{
				2,
				4,
				4,
				4
			},
			new int[]
			{
				2,
				4,
				6,
				5
			},
			new int[]
			{
				2,
				4,
				6,
				6
			},
			new int[]
			{
				2,
				5,
				8,
				8
			},
			new int[]
			{
				4,
				5,
				8,
				8
			},
			new int[]
			{
				4,
				5,
				8,
				11
			},
			new int[]
			{
				4,
				8,
				10,
				11
			},
			new int[]
			{
				4,
				9,
				12,
				16
			},
			new int[]
			{
				4,
				9,
				16,
				16
			},
			new int[]
			{
				6,
				10,
				12,
				18
			},
			new int[]
			{
				6,
				10,
				17,
				16
			},
			new int[]
			{
				6,
				11,
				16,
				19
			},
			new int[]
			{
				6,
				13,
				18,
				21
			},
			new int[]
			{
				7,
				14,
				21,
				25
			},
			new int[]
			{
				8,
				16,
				20,
				25
			},
			new int[]
			{
				8,
				17,
				23,
				25
			},
			new int[]
			{
				9,
				17,
				23,
				34
			},
			new int[]
			{
				9,
				18,
				25,
				30
			},
			new int[]
			{
				10,
				20,
				27,
				32
			},
			new int[]
			{
				12,
				21,
				29,
				35
			},
			new int[]
			{
				12,
				23,
				34,
				37
			},
			new int[]
			{
				12,
				25,
				34,
				40
			},
			new int[]
			{
				13,
				26,
				35,
				42
			},
			new int[]
			{
				14,
				28,
				38,
				45
			},
			new int[]
			{
				15,
				29,
				40,
				48
			},
			new int[]
			{
				16,
				31,
				43,
				51
			},
			new int[]
			{
				17,
				33,
				45,
				54
			},
			new int[]
			{
				18,
				35,
				48,
				57
			},
			new int[]
			{
				19,
				37,
				51,
				60
			},
			new int[]
			{
				19,
				38,
				53,
				63
			},
			new int[]
			{
				20,
				40,
				56,
				66
			},
			new int[]
			{
				21,
				43,
				59,
				70
			},
			new int[]
			{
				22,
				45,
				62,
				74
			},
			new int[]
			{
				24,
				47,
				65,
				77
			},
			new int[]
			{
				25,
				49,
				68,
				81
			}
		};
		public virtual int NumErrorCollectionCode
		{
			get
			{
				return this.int_6[this.int_0 - 1][this.int_1];
			}
		}
		public virtual int NumRSBlocks
		{
			get
			{
				return this.int_7[this.int_0 - 1][this.int_1];
			}
		}
		public virtual int Version
		{
			get
			{
				return this.int_0;
			}
		}
		public virtual string VersionReference
		{
			get
			{
				char[] array = new char[]
				{
					'L',
					'M',
					'Q',
					'H'
				};
				return Convert.ToString(this.int_0) + "-" + array[this.int_1];
			}
		}
		public virtual Point[][] AlignmentPattern
		{
			get
			{
				return this.point_0;
			}
		}
		public virtual int DataCapacity
		{
			get
			{
				return this.int_3;
			}
		}
		public virtual int ErrorCollectionLevel
		{
			get
			{
				return this.int_1;
			}
		}
		public virtual int MaskPatternReferer
		{
			get
			{
				return this.int_2;
			}
		}
		public virtual string MaskPatternRefererAsString
		{
			get
			{
				string text = Convert.ToString(this.MaskPatternReferer, 2);
				int length = text.Length;
				for (int i = 0; i < 3 - length; i++)
				{
					text = "0" + text;
				}
				return text;
			}
		}
		public virtual int Width
		{
			get
			{
				return this.int_4;
			}
		}
		public virtual int Height
		{
			get
			{
				return this.int_5;
			}
		}
		public virtual int[] Blocks
		{
			get
			{
				int width = this.Width;
				int height = this.Height;
				int num = width - 1;
				int num2 = height - 1;
				ArrayList arrayList = ArrayList.Synchronized(new ArrayList(10));
				ArrayList arrayList2 = ArrayList.Synchronized(new ArrayList(10));
				int num3 = 0;
				int num4 = 7;
				int num5 = 0;
				bool flag = true;
				bool flag2 = false;
				bool flag3 = true;
				do
				{
					arrayList.Add(this.getElement(num, num2));
					if (this.getElement(num, num2))
					{
						num3 += 1 << num4;
					}
					num4--;
					if (num4 == -1)
					{
						arrayList2.Add(num3);
						num4 = 7;
						num3 = 0;
					}
					do
					{
						if (flag3 == flag)
						{
							if ((num + num5) % 2 == 0)
							{
								num--;
							}
							else if (num2 > 0)
							{
								num++;
								num2--;
							}
							else
							{
								num--;
								if (num == 6)
								{
									num--;
									num5 = 1;
								}
								flag3 = flag2;
							}
						}
						else if ((num + num5) % 2 == 0)
						{
							num--;
						}
						else if (num2 < height - 1)
						{
							num++;
							num2++;
						}
						else
						{
							num--;
							if (num == 6)
							{
								num--;
								num5 = 1;
							}
							flag3 = flag;
						}
					}
					while (this.isInFunctionPattern(num, num2));
				}
				while (num != -1);
				int[] array = new int[arrayList2.Count];
				for (int i = 0; i < arrayList2.Count; i++)
				{
					int num6 = (int)arrayList2[i];
					array[i] = num6;
				}
				return array;
			}
		}
		public virtual bool getElement(int int_8, int int_9)
		{
			return this.bool_0[int_8][int_9];
		}
		public QRCodeSymbol(bool[][] moduleMatrix)
		{
			this.bool_0 = moduleMatrix;
			this.int_4 = moduleMatrix.Length;
			this.int_5 = moduleMatrix[0].Length;
			this.initialize();
		}
		internal virtual void initialize()
		{
			this.int_0 = (this.int_4 - 17) / 4;
			Point[][] array = new Point[1][];
			for (int i = 0; i < 1; i++)
			{
				array[i] = new Point[1];
			}
			int[] array2 = new int[1];
			if (this.int_0 >= 2 && this.int_0 <= 40)
			{
				array2 = LogicalSeed.getSeed(this.int_0);
				Point[][] array3 = new Point[array2.Length][];
				for (int j = 0; j < array2.Length; j++)
				{
					array3[j] = new Point[array2.Length];
				}
				array = array3;
			}
			for (int k = 0; k < array2.Length; k++)
			{
				for (int l = 0; l < array2.Length; l++)
				{
					array[l][k] = new Point(array2[l], array2[k]);
				}
			}
			this.point_0 = array;
			this.int_3 = this.method_0();
			bool[] formatInformation = this.readFormatInformation();
			this.decodeFormatInformation(formatInformation);
			this.unmask();
		}
		internal virtual bool[] readFormatInformation()
		{
			bool[] array = new bool[15];
			for (int i = 0; i <= 5; i++)
			{
				array[i] = this.getElement(8, i);
			}
			array[6] = this.getElement(8, 7);
			array[7] = this.getElement(8, 8);
			array[8] = this.getElement(7, 8);
			for (int i = 9; i <= 14; i++)
			{
				array[i] = this.getElement(14 - i, 8);
			}
			int number = 21522;
			for (int i = 0; i <= 14; i++)
			{
				bool flag = (SystemUtils.URShift(number, i) & 1) == 1;
				if (array[i] == flag)
				{
					array[i] = false;
				}
				else
				{
					array[i] = true;
				}
			}
			BCH15_5 bCH15_ = new BCH15_5(array);
			bool[] array2 = bCH15_.correct();
			bool[] array3 = new bool[5];
			for (int i = 0; i < 5; i++)
			{
				array3[i] = array2[10 + i];
			}
			return array3;
		}
		internal virtual void unmask()
		{
			bool[][] array = this.generateMaskPattern();
			int width = this.Width;
			for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < width; j++)
				{
					if (array[j][i])
					{
						this.reverseElement(j, i);
					}
				}
			}
		}
		internal virtual bool[][] generateMaskPattern()
		{
			int maskPatternReferer = this.MaskPatternReferer;
			int width = this.Width;
			int height = this.Height;
			bool[][] array = new bool[width][];
			for (int i = 0; i < width; i++)
			{
				array[i] = new bool[height];
			}
			for (int j = 0; j < height; j++)
			{
				for (int k = 0; k < width; k++)
				{
					if (!this.isInFunctionPattern(k, j))
					{
						switch (maskPatternReferer)
						{
						case 0:
							if ((j + k) % 2 == 0)
							{
								array[k][j] = true;
							}
							break;
						case 1:
							if (j % 2 == 0)
							{
								array[k][j] = true;
							}
							break;
						case 2:
							if (k % 3 == 0)
							{
								array[k][j] = true;
							}
							break;
						case 3:
							if ((j + k) % 3 == 0)
							{
								array[k][j] = true;
							}
							break;
						case 4:
							if ((j / 2 + k / 3) % 2 == 0)
							{
								array[k][j] = true;
							}
							break;
						case 5:
							if (j * k % 2 + j * k % 3 == 0)
							{
								array[k][j] = true;
							}
							break;
						case 6:
							if ((j * k % 2 + j * k % 3) % 2 == 0)
							{
								array[k][j] = true;
							}
							break;
						case 7:
							if ((j * k % 3 + (j + k) % 2) % 2 == 0)
							{
								array[k][j] = true;
							}
							break;
						}
					}
				}
			}
			return array;
		}
		private int method_0()
		{
			int version = this.Version;
			int num;
			if (version <= 6)
			{
				num = 31;
			}
			else
			{
				num = 67;
			}
			int num2 = version / 7 + 2;
			int num3 = (version == 1) ? 192 : (192 + (num2 * num2 - 3) * 25);
			int num4 = num3 + 8 * version + 2 - (num2 - 2) * 10;
			return (this.int_4 * this.int_4 - num4 - num) / 8;
		}
		internal virtual void decodeFormatInformation(bool[] formatInformation)
		{
			if (!formatInformation[4])
			{
				if (formatInformation[3])
				{
					this.int_1 = 0;
				}
				else
				{
					this.int_1 = 1;
				}
			}
			else if (formatInformation[3])
			{
				this.int_1 = 2;
			}
			else
			{
				this.int_1 = 3;
			}
			for (int i = 2; i >= 0; i--)
			{
				if (formatInformation[i])
				{
					this.int_2 += 1 << i;
				}
			}
		}
		public virtual void reverseElement(int int_8, int int_9)
		{
			this.bool_0[int_8][int_9] = !this.bool_0[int_8][int_9];
		}
		public virtual bool isInFunctionPattern(int targetX, int targetY)
		{
			bool result;
			if (targetX < 9 && targetY < 9)
			{
				result = true;
			}
			else if (targetX > this.Width - 9 && targetY < 9)
			{
				result = true;
			}
			else if (targetX < 9 && targetY > this.Height - 9)
			{
				result = true;
			}
			else
			{
				if (this.int_0 >= 7)
				{
					if (targetX > this.Width - 12 && targetY < 6)
					{
						result = true;
						return result;
					}
					if (targetX < 6 && targetY > this.Height - 12)
					{
						result = true;
						return result;
					}
				}
				if (targetX == 6 || targetY == 6)
				{
					result = true;
				}
				else
				{
					Point[][] alignmentPattern = this.AlignmentPattern;
					int num = alignmentPattern.Length;
					for (int i = 0; i < num; i++)
					{
						for (int j = 0; j < num; j++)
						{
							if ((j != 0 || i != 0) && (j != num - 1 || i != 0) && (j != 0 || i != num - 1) && (Math.Abs(alignmentPattern[j][i].X - targetX) < 3 && Math.Abs(alignmentPattern[j][i].Y - targetY) < 3))
							{
								result = true;
								return result;
							}
						}
					}
					result = false;
				}
			}
			return result;
		}
	}
}
