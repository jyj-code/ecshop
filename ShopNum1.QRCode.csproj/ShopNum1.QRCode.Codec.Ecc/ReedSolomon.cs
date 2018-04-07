using System;
namespace ShopNum1.QRCode.Codec.Ecc
{
	public class ReedSolomon
	{
		internal int[] int_0;
		internal int[] int_1 = new int[512];
		internal int[] int_2 = new int[256];
		internal int int_3;
		internal int int_4;
		internal int[] int_5;
		internal int[] int_6;
		internal int[] int_7;
		internal int[] int_8 = new int[256];
		internal int int_9;
		internal int[] int_10 = new int[256];
		internal int int_11 = 0;
		internal bool bool_0 = true;
		public virtual bool CorrectionSucceeded
		{
			get
			{
				return this.bool_0;
			}
		}
		public virtual int NumCorrectedErrors
		{
			get
			{
				return this.int_9;
			}
		}
		public ReedSolomon(int[] source, int NPAR)
		{
			this.initializeGaloisTables();
			this.int_0 = source;
			this.int_3 = NPAR;
			this.int_4 = NPAR * 2;
			this.int_5 = new int[this.int_4];
			this.int_6 = new int[this.int_4];
			this.int_7 = new int[this.int_4];
		}
		internal virtual void initializeGaloisTables()
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			int num7 = 0;
			int num8 = 1;
			this.int_1[0] = 1;
			this.int_1[255] = this.int_1[0];
			this.int_2[0] = 0;
			int i;
			for (i = 1; i < 256; i++)
			{
				int num9 = num;
				num = num2;
				num2 = num3;
				num3 = num4;
				num4 = (num5 ^ num9);
				num5 = (num6 ^ num9);
				num6 = (num7 ^ num9);
				num7 = num8;
				num8 = num9;
				this.int_1[i] = num8 + num7 * 2 + num6 * 4 + num5 * 8 + num4 * 16 + num3 * 32 + num2 * 64 + num * 128;
				this.int_1[i + 255] = this.int_1[i];
			}
			i = 1;
			IL_101:
			while (i < 256)
			{
				for (int j = 0; j < 256; j++)
				{
					if (this.int_1[j] == i)
					{
						this.int_2[i] = j;
						IL_FB:
						i++;
						goto IL_101;
					}
				}
                //goto IL_FB;
			}
		}
		internal virtual int gmult(int int_12, int int_13)
		{
			int result;
			if (int_12 == 0 || int_13 == 0)
			{
				result = 0;
			}
			else
			{
				int num = this.int_2[int_12];
				int num2 = this.int_2[int_13];
				result = this.int_1[num + num2];
			}
			return result;
		}
		internal virtual int ginv(int int_12)
		{
			return this.int_1[255 - this.int_2[int_12]];
		}
		internal virtual void decode_data(int[] data)
		{
			for (int i = 0; i < this.int_4; i++)
			{
				int num = 0;
				for (int j = 0; j < data.Length; j++)
				{
					num = (data[j] ^ this.gmult(this.int_1[i + 1], num));
				}
				this.int_5[i] = num;
			}
		}
		public virtual void correct()
		{
			this.decode_data(this.int_0);
			this.bool_0 = true;
			bool flag = false;
			for (int i = 0; i < this.int_5.Length; i++)
			{
				if (this.int_5[i] != 0)
				{
					flag = true;
				}
			}
			if (flag)
			{
				this.bool_0 = this.correct_errors_erasures(this.int_0, this.int_0.Length, 0, new int[1]);
			}
		}
		internal virtual void Modified_Berlekamp_Massey()
		{
			int[] array = new int[this.int_4];
			int[] array2 = new int[this.int_4];
			int[] array3 = new int[this.int_4];
			int[] array4 = new int[this.int_4];
			this.init_gamma(array4);
			this.copy_poly(array3, array4);
			this.mul_z_poly(array3);
			this.copy_poly(array, array4);
			int num = -1;
			int num2 = this.int_11;
			for (int i = this.int_11; i < 8; i++)
			{
				int num3 = this.compute_discrepancy(array, this.int_5, num2, i);
				if (num3 != 0)
				{
					for (int j = 0; j < this.int_4; j++)
					{
						array2[j] = (array[j] ^ this.gmult(num3, array3[j]));
					}
					if (num2 < i - num)
					{
						int num4 = i - num;
						num = i - num2;
						for (int j = 0; j < this.int_4; j++)
						{
							array3[j] = this.gmult(array[j], this.ginv(num3));
						}
						num2 = num4;
					}
					for (int j = 0; j < this.int_4; j++)
					{
						array[j] = array2[j];
					}
				}
				this.mul_z_poly(array3);
			}
			for (int j = 0; j < this.int_4; j++)
			{
				this.int_6[j] = array[j];
			}
			this.compute_modified_omega();
		}
		internal virtual void compute_modified_omega()
		{
			int[] array = new int[this.int_4 * 2];
			this.mult_polys(array, this.int_6, this.int_5);
			this.zero_poly(this.int_7);
			for (int i = 0; i < this.int_3; i++)
			{
				this.int_7[i] = array[i];
			}
		}
		internal virtual void mult_polys(int[] int_12, int[] int_13, int[] int_14)
		{
			int[] array = new int[this.int_4 * 2];
			for (int i = 0; i < this.int_4 * 2; i++)
			{
				int_12[i] = 0;
			}
			for (int i = 0; i < this.int_4; i++)
			{
				for (int j = this.int_4; j < this.int_4 * 2; j++)
				{
					array[j] = 0;
				}
				for (int j = 0; j < this.int_4; j++)
				{
					array[j] = this.gmult(int_14[j], int_13[i]);
				}
				for (int j = this.int_4 * 2 - 1; j >= i; j--)
				{
					array[j] = array[j - i];
				}
				for (int j = 0; j < i; j++)
				{
					array[j] = 0;
				}
				for (int j = 0; j < this.int_4 * 2; j++)
				{
					int_12[j] ^= array[j];
				}
			}
		}
		internal virtual void init_gamma(int[] gamma)
		{
			int[] array = new int[this.int_4];
			this.zero_poly(gamma);
			this.zero_poly(array);
			gamma[0] = 1;
			for (int i = 0; i < this.int_11; i++)
			{
				this.copy_poly(array, gamma);
				this.scale_poly(this.int_1[this.int_10[i]], array);
				this.mul_z_poly(array);
				this.add_polys(gamma, array);
			}
		}
		internal virtual void compute_next_omega(int int_12, int[] A, int[] int_13, int[] int_14)
		{
			for (int i = 0; i < this.int_4; i++)
			{
				int_13[i] = (int_14[i] ^ this.gmult(int_12, A[i]));
			}
		}
		internal virtual int compute_discrepancy(int[] lambda, int[] S, int L, int int_12)
		{
			int num = 0;
			for (int i = 0; i <= L; i++)
			{
				num ^= this.gmult(lambda[i], S[int_12 - i]);
			}
			return num;
		}
		internal virtual void add_polys(int[] int_12, int[] int_13)
		{
			for (int i = 0; i < this.int_4; i++)
			{
				int_12[i] ^= int_13[i];
			}
		}
		internal virtual void copy_poly(int[] int_12, int[] int_13)
		{
			for (int i = 0; i < this.int_4; i++)
			{
				int_12[i] = int_13[i];
			}
		}
		internal virtual void scale_poly(int int_12, int[] poly)
		{
			for (int i = 0; i < this.int_4; i++)
			{
				poly[i] = this.gmult(int_12, poly[i]);
			}
		}
		internal virtual void zero_poly(int[] poly)
		{
			for (int i = 0; i < this.int_4; i++)
			{
				poly[i] = 0;
			}
		}
		internal virtual void mul_z_poly(int[] int_12)
		{
			for (int i = this.int_4 - 1; i > 0; i--)
			{
				int_12[i] = int_12[i - 1];
			}
			int_12[0] = 0;
		}
		internal virtual void Find_Roots()
		{
			this.int_9 = 0;
			for (int i = 1; i < 256; i++)
			{
				int num = 0;
				for (int j = 0; j < this.int_3 + 1; j++)
				{
					num ^= this.gmult(this.int_1[j * i % 255], this.int_6[j]);
				}
				if (num == 0)
				{
					this.int_8[this.int_9] = 255 - i;
					this.int_9++;
				}
			}
		}
		internal virtual bool correct_errors_erasures(int[] codeword, int csize, int nerasures, int[] erasures)
		{
			this.int_11 = nerasures;
			for (int i = 0; i < this.int_11; i++)
			{
				this.int_10[i] = erasures[i];
			}
			this.Modified_Berlekamp_Massey();
			this.Find_Roots();
			bool result;
			if (this.int_9 <= this.int_3 || this.int_9 > 0)
			{
				for (int j = 0; j < this.int_9; j++)
				{
					if (this.int_8[j] >= csize)
					{
						result = false;
						return result;
					}
				}
				for (int j = 0; j < this.int_9; j++)
				{
					int i = this.int_8[j];
					int num = 0;
					for (int k = 0; k < this.int_4; k++)
					{
						num ^= this.gmult(this.int_7[k], this.int_1[(255 - i) * k % 255]);
					}
					int num2 = 0;
					for (int k = 1; k < this.int_4; k += 2)
					{
						num2 ^= this.gmult(this.int_6[k], this.int_1[(255 - i) * (k - 1) % 255]);
					}
					int num3 = this.gmult(num, this.ginv(num2));
					codeword[csize - i - 1] ^= num3;
				}
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}
	}
}
