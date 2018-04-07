using ShopNum1.QRCode.Codec.Util;
using ShopNum1.QRCode.ExceptionHandler;
using System;
using System.IO;
namespace ShopNum1.QRCode.Codec.Reader
{
	public class QRCodeDataBlockReader
	{
		private const int int_0 = 1;
		private const int int_1 = 2;
		private const int int_2 = 4;
		private const int int_3 = 8;
		internal int[] int_4;
		internal int int_5;
		internal int int_6;
		internal int int_7;
		internal int int_8;
		internal int int_9;
		internal DebugCanvas debugCanvas_0;
		private int[][] int_10 = new int[][]
		{
			new int[]
			{
				10,
				9,
				8,
				8
			},
			new int[]
			{
				12,
				11,
				16,
				10
			},
			new int[]
			{
				14,
				13,
				16,
				12
			}
		};
		internal virtual int NextMode
		{
			get
			{
				int result;
				if (this.int_6 > this.int_4.Length - this.int_9 - 2)
				{
					result = 0;
				}
				else
				{
					result = this.getNextBits(4);
				}
				return result;
			}
		}
		public virtual sbyte[] DataByte
		{
			get
			{
				this.debugCanvas_0.println("Reading data blocks.");
				MemoryStream memoryStream = new MemoryStream();
				try
				{
					int nextMode;
					while (true)
					{
						nextMode = this.NextMode;
						if (nextMode == 0)
						{
							break;
						}
						if (nextMode != 1 && nextMode != 2 && nextMode != 4 && nextMode != 8)
						{
							goto IL_14D;
						}
						this.int_8 = this.getDataLength(nextMode);
						if (this.int_8 < 1)
						{
							goto IL_1AE;
						}
						int num = nextMode;
						switch (num)
						{
						case 1:
						{
							sbyte[] array = SystemUtils.ToSByteArray(SystemUtils.ToByteArray(this.getFigureString(this.int_8)));
							memoryStream.Write(SystemUtils.ToByteArray(array), 0, array.Length);
							break;
						}
						case 2:
						{
							sbyte[] array2 = SystemUtils.ToSByteArray(SystemUtils.ToByteArray(this.getRomanAndFigureString(this.int_8)));
							memoryStream.Write(SystemUtils.ToByteArray(array2), 0, array2.Length);
							break;
						}
						case 3:
							break;
						case 4:
						{
							sbyte[] array3 = this.get8bitByteArray(this.int_8);
							memoryStream.Write(SystemUtils.ToByteArray(array3), 0, array3.Length);
							break;
						}
						default:
							if (num == 8)
							{
								sbyte[] array4 = SystemUtils.ToSByteArray(SystemUtils.ToByteArray(this.getKanjiString(this.int_8)));
								memoryStream.Write(SystemUtils.ToByteArray(array4), 0, array4.Length);
							}
							break;
						}
					}
					if (memoryStream.Length <= 0L)
					{
						throw new InvalidDataBlockException("Empty data block");
					}
					goto IL_236;
					IL_14D:
					throw new InvalidDataBlockException(string.Concat(new object[]
					{
						"Invalid mode: ",
						nextMode,
						" in (block:",
						this.int_6,
						" bit:",
						this.int_7,
						")"
					}));
					IL_1AE:
					throw new InvalidDataBlockException("Invalid data length: " + this.int_8);
				}
				catch (IndexOutOfRangeException throwable)
				{
					SystemUtils.WriteStackTrace(throwable, Console.Error);
					throw new InvalidDataBlockException(string.Concat(new object[]
					{
						"Data Block Error in (block:",
						this.int_6,
						" bit:",
						this.int_7,
						")"
					}));
				}
				catch (IOException ex)
				{
					throw new InvalidDataBlockException(ex.Message);
				}
				IL_236:
				return SystemUtils.ToSByteArray(memoryStream.ToArray());
			}
		}
		public virtual string DataString
		{
			get
			{
				this.debugCanvas_0.println("Reading data blocks...");
				string text = "";
				while (true)
				{
					int nextMode = this.NextMode;
					this.debugCanvas_0.println("mode: " + nextMode);
					if (nextMode == 0)
					{
						break;
					}
					if (nextMode == 1 || nextMode == 2 || nextMode == 4 || nextMode == 8)
					{
					}
					this.int_8 = this.getDataLength(nextMode);
					this.debugCanvas_0.println(Convert.ToString(this.int_4[this.int_6]));
					Console.Out.WriteLine("length: " + this.int_8);
					int num = nextMode;
					switch (num)
					{
					case 1:
						text += this.getFigureString(this.int_8);
						break;
					case 2:
						text += this.getRomanAndFigureString(this.int_8);
						break;
					case 3:
						break;
					case 4:
						text += this.get8bitByteString(this.int_8);
						break;
					default:
						if (num == 8)
						{
							text += this.getKanjiString(this.int_8);
						}
						break;
					}
				}
				Console.Out.WriteLine("");
				return text;
			}
		}
		public QRCodeDataBlockReader(int[] blocks, int version, int numErrorCorrectionCode)
		{
			this.int_6 = 0;
			this.int_7 = 7;
			this.int_8 = 0;
			this.int_4 = blocks;
			this.int_9 = numErrorCorrectionCode;
			if (version <= 9)
			{
				this.int_5 = 0;
			}
			else if (version >= 10 && version <= 26)
			{
				this.int_5 = 1;
			}
			else if (version >= 27 && version <= 40)
			{
				this.int_5 = 2;
			}
			this.debugCanvas_0 = QRCodeDecoder.Canvas;
		}
		internal virtual int getNextBits(int numBits)
		{
			int result;
			if (numBits < this.int_7 + 1)
			{
				int num = 0;
				for (int i = 0; i < numBits; i++)
				{
					num += 1 << i;
				}
				num <<= this.int_7 - numBits + 1;
				int num2 = (this.int_4[this.int_6] & num) >> this.int_7 - numBits + 1;
				this.int_7 -= numBits;
				result = num2;
			}
			else if (numBits < this.int_7 + 1 + 8)
			{
				int num3 = 0;
				for (int i = 0; i < this.int_7 + 1; i++)
				{
					num3 += 1 << i;
				}
				int num2 = (this.int_4[this.int_6] & num3) << numBits - (this.int_7 + 1);
				this.int_6++;
				num2 += this.int_4[this.int_6] >> 8 - (numBits - (this.int_7 + 1));
				this.int_7 -= numBits % 8;
				if (this.int_7 < 0)
				{
					this.int_7 = 8 + this.int_7;
				}
				result = num2;
			}
			else if (numBits < this.int_7 + 1 + 16)
			{
				int num3 = 0;
				int num4 = 0;
				for (int i = 0; i < this.int_7 + 1; i++)
				{
					num3 += 1 << i;
				}
				int num5 = (this.int_4[this.int_6] & num3) << numBits - (this.int_7 + 1);
				this.int_6++;
				int num6 = this.int_4[this.int_6] << numBits - (this.int_7 + 1 + 8);
				this.int_6++;
				for (int i = 0; i < numBits - (this.int_7 + 1 + 8); i++)
				{
					num4 += 1 << i;
				}
				num4 <<= 8 - (numBits - (this.int_7 + 1 + 8));
				int num7 = (this.int_4[this.int_6] & num4) >> 8 - (numBits - (this.int_7 + 1 + 8));
				int num2 = num5 + num6 + num7;
				this.int_7 -= (numBits - 8) % 8;
				if (this.int_7 < 0)
				{
					this.int_7 = 8 + this.int_7;
				}
				result = num2;
			}
			else
			{
				Console.Out.WriteLine("ERROR!");
				result = 0;
			}
			return result;
		}
		internal virtual int guessMode(int mode)
		{
			int result;
			switch (mode)
			{
			case 3:
				result = 1;
				return result;
			case 5:
				result = 4;
				return result;
			case 6:
				result = 4;
				return result;
			case 7:
				result = 4;
				return result;
			case 9:
				result = 8;
				return result;
			case 10:
				result = 8;
				return result;
			case 11:
				result = 8;
				return result;
			case 12:
				result = 4;
				return result;
			case 13:
				result = 4;
				return result;
			case 14:
				result = 4;
				return result;
			case 15:
				result = 4;
				return result;
			}
			result = 8;
			return result;
		}
		internal virtual int getDataLength(int modeIndicator)
		{
			int num = 0;
			while (modeIndicator >> num != 1)
			{
				num++;
			}
			return this.getNextBits(this.int_10[this.int_5][num]);
		}
		internal virtual string getFigureString(int dataLength)
		{
			int num = dataLength;
			int num2 = 0;
			string text = "";
			do
			{
				if (num >= 3)
				{
					num2 = this.getNextBits(10);
					if (num2 < 100)
					{
						text += "0";
					}
					if (num2 < 10)
					{
						text += "0";
					}
					num -= 3;
				}
				else if (num == 2)
				{
					num2 = this.getNextBits(7);
					if (num2 < 10)
					{
						text += "0";
					}
					num -= 2;
				}
				else if (num == 1)
				{
					num2 = this.getNextBits(4);
					num--;
				}
				text += Convert.ToString(num2);
			}
			while (num > 0);
			return text;
		}
		internal virtual string getRomanAndFigureString(int dataLength)
		{
			int num = dataLength;
			string text = "";
			char[] array = new char[]
			{
				'0',
				'1',
				'2',
				'3',
				'4',
				'5',
				'6',
				'7',
				'8',
				'9',
				'A',
				'B',
				'C',
				'D',
				'E',
				'F',
				'G',
				'H',
				'I',
				'J',
				'K',
				'L',
				'M',
				'N',
				'O',
				'P',
				'Q',
				'R',
				'S',
				'T',
				'U',
				'V',
				'W',
				'X',
				'Y',
				'Z',
				' ',
				'$',
				'%',
				'*',
				'+',
				'-',
				'.',
				'/',
				':'
			};
			do
			{
				if (num > 1)
				{
					int nextBits = this.getNextBits(11);
					int num2 = nextBits / 45;
					int num3 = nextBits % 45;
					text += Convert.ToString(array[num2]);
					text += Convert.ToString(array[num3]);
					num -= 2;
				}
				else if (num == 1)
				{
					int nextBits = this.getNextBits(6);
					text += Convert.ToString(array[nextBits]);
					num--;
				}
			}
			while (num > 0);
			return text;
		}
		public virtual sbyte[] get8bitByteArray(int dataLength)
		{
			int num = dataLength;
			MemoryStream memoryStream = new MemoryStream();
			do
			{
				this.debugCanvas_0.println("Length: " + num);
				int nextBits = this.getNextBits(8);
				memoryStream.WriteByte((byte)nextBits);
				num--;
			}
			while (num > 0);
			return SystemUtils.ToSByteArray(memoryStream.ToArray());
		}
		internal virtual string get8bitByteString(int dataLength)
		{
			int num = dataLength;
			string text = "";
			do
			{
				int nextBits = this.getNextBits(8);
				text += (char)nextBits;
				num--;
			}
			while (num > 0);
			return text;
		}
		internal virtual string getKanjiString(int dataLength)
		{
			int num = dataLength;
			string text = "";
			do
			{
				int nextBits = this.getNextBits(13);
				int num2 = nextBits % 192;
				int num3 = nextBits / 192;
				int num4 = (num3 << 8) + num2;
				int num5;
				if (num4 + 33088 <= 40956)
				{
					num5 = num4 + 33088;
				}
				else
				{
					num5 = num4 + 49472;
				}
				text += new string(SystemUtils.ToCharArray(SystemUtils.ToByteArray(new sbyte[]
				{
					(sbyte)(num5 >> 8),
					(sbyte)(num5 & 255)
				})));
				num--;
			}
			while (num > 0);
			return text;
		}
	}
}
