using System;
namespace ShopNum1.QRCode.Codec.Ecc
{
	public class BCH15_5
	{
		internal int[][] int_0;
		internal bool[] bool_0;
		internal int int_1;
		internal static string[] string_0 = new string[]
		{
			"c0",
			"c1",
			"c2",
			"c3",
			"c4",
			"c5",
			"c6",
			"c7",
			"c8",
			"c9",
			"d0",
			"d1",
			"d2",
			"d3",
			"d4"
		};
		public virtual int NumCorrectedError
		{
			get
			{
				return this.int_1;
			}
		}
		public BCH15_5(bool[] source)
		{
			this.int_0 = this.createGF16();
			this.bool_0 = source;
		}
		public virtual bool[] correct()
		{
			int[] int_ = this.calcSyndrome(this.bool_0);
			int[] errorPos = this.detectErrorBitPosition(int_);
			return this.correctErrorBit(this.bool_0, errorPos);
		}
		internal virtual int[][] createGF16()
		{
			this.int_0 = new int[16][];
			for (int i = 0; i < 16; i++)
			{
				this.int_0[i] = new int[4];
			}
			int[] array = new int[4];
			array[0] = 1;
			array[1] = 1;
			int[] array2 = array;
			for (int i = 0; i < 4; i++)
			{
				this.int_0[i][i] = 1;
			}
			for (int i = 0; i < 4; i++)
			{
				this.int_0[4][i] = array2[i];
			}
			for (int i = 5; i < 16; i++)
			{
				for (int j = 1; j < 4; j++)
				{
					this.int_0[i][j] = this.int_0[i - 1][j - 1];
				}
				if (this.int_0[i - 1][3] == 1)
				{
					for (int j = 0; j < 4; j++)
					{
						this.int_0[i][j] = (this.int_0[i][j] + array2[j]) % 2;
					}
				}
			}
			return this.int_0;
		}
		internal virtual int searchElement(int[] int_2)
		{
			int num = 0;
			while (num < 15 && (int_2[0] != this.int_0[num][0] || int_2[1] != this.int_0[num][1] || int_2[2] != this.int_0[num][2] || int_2[3] != this.int_0[num][3]))
			{
				num++;
			}
			return num;
		}
		internal virtual int[] getCode(int input)
		{
			int[] array = new int[15];
			int[] array2 = new int[8];
			for (int i = 0; i < 15; i++)
			{
				int num = array2[7];
				int num2;
				int num3;
				if (i < 7)
				{
					num2 = (input >> 6 - i) % 2;
					num3 = (num2 + num) % 2;
				}
				else
				{
					num2 = num;
					num3 = 0;
				}
				array2[7] = (array2[6] + num3) % 2;
				array2[6] = (array2[5] + num3) % 2;
				array2[5] = array2[4];
				array2[4] = (array2[3] + num3) % 2;
				array2[3] = array2[2];
				array2[2] = array2[1];
				array2[1] = array2[0];
				array2[0] = num3;
				array[14 - i] = num2;
			}
			return array;
		}
		internal virtual int addGF(int arg1, int arg2)
		{
			int[] array = new int[4];
			for (int i = 0; i < 4; i++)
			{
				int num = (arg1 < 0 || arg1 >= 15) ? 0 : this.int_0[arg1][i];
				int num2 = (arg2 < 0 || arg2 >= 15) ? 0 : this.int_0[arg2][i];
				array[i] = (num + num2) % 2;
			}
			return this.searchElement(array);
		}
		internal virtual int[] calcSyndrome(bool[] bool_1)
		{
			int[] array = new int[5];
			int[] array2 = new int[4];
			int i;
			for (i = 0; i < 15; i++)
			{
				if (bool_1[i])
				{
					for (int j = 0; j < 4; j++)
					{
						array2[j] = (array2[j] + this.int_0[i][j]) % 2;
					}
				}
			}
			i = this.searchElement(array2);
			array[0] = ((i >= 15) ? -1 : i);
			array2 = new int[4];
			for (i = 0; i < 15; i++)
			{
				if (bool_1[i])
				{
					for (int j = 0; j < 4; j++)
					{
						array2[j] = (array2[j] + this.int_0[i * 3 % 15][j]) % 2;
					}
				}
			}
			i = this.searchElement(array2);
			array[2] = ((i >= 15) ? -1 : i);
			array2 = new int[4];
			for (i = 0; i < 15; i++)
			{
				if (bool_1[i])
				{
					for (int j = 0; j < 4; j++)
					{
						array2[j] = (array2[j] + this.int_0[i * 5 % 15][j]) % 2;
					}
				}
			}
			i = this.searchElement(array2);
			array[4] = ((i >= 15) ? -1 : i);
			return array;
		}
		internal virtual int[] calcErrorPositionVariable(int[] int_2)
		{
			int[] array = new int[4];
			array[0] = int_2[0];
			int arg = (int_2[0] + int_2[1]) % 15;
			int num = this.addGF(int_2[2], arg);
			num = ((num >= 15) ? -1 : num);
			arg = (int_2[2] + int_2[1]) % 15;
			int num2 = this.addGF(int_2[4], arg);
			num2 = ((num2 >= 15) ? -1 : num2);
			array[1] = ((num2 >= 0 || num >= 0) ? ((num2 - num + 15) % 15) : -1);
			arg = (int_2[1] + array[0]) % 15;
			int arg2 = this.addGF(int_2[2], arg);
			arg = (int_2[0] + array[1]) % 15;
			array[2] = this.addGF(arg2, arg);
			return array;
		}
		internal virtual int[] detectErrorBitPosition(int[] int_2)
		{
			int[] array = this.calcErrorPositionVariable(int_2);
			int[] array2 = new int[4];
			int[] result;
			if (array[0] == -1)
			{
				result = array2;
			}
			else if (array[1] == -1)
			{
				array2[0] = 1;
				array2[1] = array[0];
				result = array2;
			}
			else
			{
				for (int i = 0; i < 15; i++)
				{
					int arg = i * 3 % 15;
					int num = i * 2 % 15;
					int num2 = i;
					int num3 = (array[0] + num) % 15;
					int arg2 = this.addGF(arg, num3);
					num3 = (array[1] + num2) % 15;
					int arg3 = this.addGF(num3, array[2]);
					int num4 = this.addGF(arg2, arg3);
					if (num4 >= 15)
					{
						array2[0]++;
						array2[array2[0]] = i;
					}
				}
				result = array2;
			}
			return result;
		}
		internal virtual bool[] correctErrorBit(bool[] bool_1, int[] errorPos)
		{
			for (int i = 1; i <= errorPos[0]; i++)
			{
				bool_1[errorPos[i]] = !bool_1[errorPos[i]];
			}
			this.int_1 = errorPos[0];
			return bool_1;
		}
	}
}
