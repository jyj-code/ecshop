using ShopNum1.QRCode.Codec.Data;
using ShopNum1.QRCode.Codec.Ecc;
using ShopNum1.QRCode.Codec.Reader;
using ShopNum1.QRCode.Codec.Util;
using ShopNum1.QRCode.ExceptionHandler;
using ShopNum1.QRCode.Geom;
using System;
using System.Collections;
using System.Text;
namespace ShopNum1.QRCode.Codec
{
	public class QRCodeDecoder
	{
		internal class Class1
		{
			internal int int_0;
			internal bool bool_0;
			internal sbyte[] sbyte_0;
			private QRCodeDecoder qrcodeDecoder_0;
			public Class1(QRCodeDecoder qrcodeDecoder_1, sbyte[] sbyte_1, int int_1, bool bool_1)
			{
				this.method_0(qrcodeDecoder_1);
				this.sbyte_0 = sbyte_1;
				this.int_0 = int_1;
				this.bool_0 = bool_1;
			}
			private void method_0(QRCodeDecoder qrcodeDecoder_1)
			{
				this.qrcodeDecoder_0 = qrcodeDecoder_1;
			}
			public virtual sbyte[] vmethod_0()
			{
				return this.sbyte_0;
			}
			public virtual int vmethod_1()
			{
				return this.int_0;
			}
			public virtual bool vmethod_2()
			{
				return this.bool_0;
			}
			public QRCodeDecoder method_1()
			{
				return this.qrcodeDecoder_0;
			}
		}
		internal QRCodeSymbol qrcodeSymbol_0;
		internal int int_0;
		internal ArrayList arrayList_0;
		internal ArrayList arrayList_1 = ArrayList.Synchronized(new ArrayList(10));
		internal static DebugCanvas debugCanvas_0;
		internal QRCodeImageReader qrcodeImageReader_0;
		internal int int_1;
		internal bool bool_0;
		public static DebugCanvas Canvas
		{
			get
			{
				return QRCodeDecoder.debugCanvas_0;
			}
			set
			{
				QRCodeDecoder.debugCanvas_0 = value;
			}
		}
		internal virtual Point[] AdjustPoints
		{
			get
			{
				ArrayList arrayList = ArrayList.Synchronized(new ArrayList(10));
				for (int i = 0; i < 4; i++)
				{
					arrayList.Add(new Point(1, 1));
				}
				int num = 0;
				int num2 = 0;
				for (int j = 0; j > -4; j--)
				{
					for (int k = 0; k > -4; k--)
					{
						if (k != j && (k + j) % 2 == 0)
						{
							arrayList.Add(new Point(k - num, j - num2));
							num = k;
							num2 = j;
						}
					}
				}
				Point[] array = new Point[arrayList.Count];
				for (int l = 0; l < array.Length; l++)
				{
					array[l] = (Point)arrayList[l];
				}
				return array;
			}
		}
		public QRCodeDecoder()
		{
			this.int_0 = 0;
			this.arrayList_0 = ArrayList.Synchronized(new ArrayList(10));
			QRCodeDecoder.debugCanvas_0 = new DebugCanvasAdapter();
		}
		public virtual sbyte[] decodeBytes(QRCodeImage qrCodeImage)
		{
			Point[] adjustPoints = this.AdjustPoints;
			ArrayList arrayList = ArrayList.Synchronized(new ArrayList(10));
			sbyte[] result;
			while (this.int_0 < adjustPoints.Length)
			{
				try
				{
					QRCodeDecoder.Class1 @class = this.decode(qrCodeImage, adjustPoints[this.int_0]);
					if (@class.vmethod_2())
					{
						result = @class.vmethod_0();
						return result;
					}
					arrayList.Add(@class);
					QRCodeDecoder.debugCanvas_0.println("Decoding succeeded but could not correct");
					QRCodeDecoder.debugCanvas_0.println("all errors. Retrying..");
				}
				catch (DecodingFailedException ex)
				{
					if (ex.Message.IndexOf("Finder Pattern") >= 0)
					{
						throw ex;
					}
				}
				finally
				{
					this.int_0++;
				}
			}
			if (arrayList.Count == 0)
			{
				throw new DecodingFailedException("Give up decoding");
			}
			int num = -1;
			int num2 = 2147483647;
			for (int i = 0; i < arrayList.Count; i++)
			{
				QRCodeDecoder.Class1 @class = (QRCodeDecoder.Class1)arrayList[i];
				if (@class.vmethod_1() < num2)
				{
					num2 = @class.vmethod_1();
					num = i;
				}
			}
			QRCodeDecoder.debugCanvas_0.println("All trials need for correct error");
			QRCodeDecoder.debugCanvas_0.println("Reporting #" + num + " that,");
			QRCodeDecoder.debugCanvas_0.println("corrected minimum errors (" + num2 + ")");
			QRCodeDecoder.debugCanvas_0.println("Decoding finished.");
			result = ((QRCodeDecoder.Class1)arrayList[num]).vmethod_0();
			return result;
		}
		public virtual string decode(QRCodeImage qrCodeImage, Encoding encoding)
		{
			sbyte[] array = this.decodeBytes(qrCodeImage);
			byte[] array2 = new byte[array.Length];
			Buffer.BlockCopy(array, 0, array2, 0, array2.Length);
			return encoding.GetString(array2);
		}
		public virtual string decode(QRCodeImage qrCodeImage)
		{
			sbyte[] array = this.decodeBytes(qrCodeImage);
			byte[] array2 = new byte[array.Length];
			Buffer.BlockCopy(array, 0, array2, 0, array2.Length);
			Encoding encoding;
			if (QRCodeUtility.IsUnicode(array2))
			{
				encoding = Encoding.Unicode;
			}
			else
			{
				encoding = Encoding.ASCII;
			}
			return encoding.GetString(array2);
		}
		internal virtual QRCodeDecoder.Class1 decode(QRCodeImage qrCodeImage, Point adjust)
		{
			try
			{
				if (this.int_0 == 0)
				{
					QRCodeDecoder.debugCanvas_0.println("Decoding started");
					int[][] image = this.imageToIntArray(qrCodeImage);
					this.qrcodeImageReader_0 = new QRCodeImageReader();
					this.qrcodeSymbol_0 = this.qrcodeImageReader_0.getQRCodeSymbol(image);
				}
				else
				{
					QRCodeDecoder.debugCanvas_0.println("--");
					QRCodeDecoder.debugCanvas_0.println("Decoding restarted #" + this.int_0);
					this.qrcodeSymbol_0 = this.qrcodeImageReader_0.getQRCodeSymbolWithAdjustedGrid(adjust);
				}
			}
			catch (SymbolNotFoundException ex)
			{
				throw new DecodingFailedException(ex.Message);
			}
			QRCodeDecoder.debugCanvas_0.println("Created QRCode symbol.");
			QRCodeDecoder.debugCanvas_0.println("Reading symbol.");
			QRCodeDecoder.debugCanvas_0.println("Version: " + this.qrcodeSymbol_0.VersionReference);
			QRCodeDecoder.debugCanvas_0.println("Mask pattern: " + this.qrcodeSymbol_0.MaskPatternRefererAsString);
			int[] blocks = this.qrcodeSymbol_0.Blocks;
			QRCodeDecoder.debugCanvas_0.println("Correcting data errors.");
			blocks = this.correctDataBlocks(blocks);
			QRCodeDecoder.Class1 result;
			try
			{
				sbyte[] decodedByteArray = this.getDecodedByteArray(blocks, this.qrcodeSymbol_0.Version, this.qrcodeSymbol_0.NumErrorCollectionCode);
				result = new QRCodeDecoder.Class1(this, decodedByteArray, this.int_1, this.bool_0);
			}
			catch (InvalidDataBlockException ex2)
			{
				QRCodeDecoder.debugCanvas_0.println(ex2.Message);
				throw new DecodingFailedException(ex2.Message);
			}
			return result;
		}
		internal virtual int[][] imageToIntArray(QRCodeImage image)
		{
			int width = image.Width;
			int height = image.Height;
			int[][] array = new int[width][];
			for (int i = 0; i < width; i++)
			{
				array[i] = new int[height];
			}
			for (int j = 0; j < height; j++)
			{
				for (int k = 0; k < width; k++)
				{
					array[k][j] = image.getPixel(k, j);
				}
			}
			return array;
		}
		internal virtual int[] correctDataBlocks(int[] blocks)
		{
			int num = 0;
			int dataCapacity = this.qrcodeSymbol_0.DataCapacity;
			int[] array = new int[dataCapacity];
			int numErrorCollectionCode = this.qrcodeSymbol_0.NumErrorCollectionCode;
			int numRSBlocks = this.qrcodeSymbol_0.NumRSBlocks;
			int num2 = numErrorCollectionCode / numRSBlocks;
			int[] result;
			if (numRSBlocks == 1)
			{
				ReedSolomon reedSolomon = new ReedSolomon(blocks, num2);
				reedSolomon.correct();
				num += reedSolomon.NumCorrectedErrors;
				if (num > 0)
				{
					QRCodeDecoder.debugCanvas_0.println(Convert.ToString(num) + " data errors corrected.");
				}
				else
				{
					QRCodeDecoder.debugCanvas_0.println("No errors found.");
				}
				this.int_1 = num;
				this.bool_0 = reedSolomon.CorrectionSucceeded;
				result = blocks;
			}
			else
			{
				int num3 = dataCapacity % numRSBlocks;
				if (num3 == 0)
				{
					int num4 = dataCapacity / numRSBlocks;
					int[][] array2 = new int[numRSBlocks][];
					for (int i = 0; i < numRSBlocks; i++)
					{
						array2[i] = new int[num4];
					}
					int[][] array3 = array2;
					for (int i = 0; i < numRSBlocks; i++)
					{
						for (int j = 0; j < num4; j++)
						{
							array3[i][j] = blocks[j * numRSBlocks + i];
						}
						ReedSolomon reedSolomon = new ReedSolomon(array3[i], num2);
						reedSolomon.correct();
						num += reedSolomon.NumCorrectedErrors;
						this.bool_0 = reedSolomon.CorrectionSucceeded;
					}
					int num5 = 0;
					for (int i = 0; i < numRSBlocks; i++)
					{
						for (int j = 0; j < num4 - num2; j++)
						{
							array[num5++] = array3[i][j];
						}
					}
				}
				else
				{
					int num6 = dataCapacity / numRSBlocks;
					int num7 = dataCapacity / numRSBlocks + 1;
					int num8 = numRSBlocks - num3;
					int[][] array4 = new int[num8][];
					for (int k = 0; k < num8; k++)
					{
						array4[k] = new int[num6];
					}
					int[][] array5 = array4;
					int[][] array6 = new int[num3][];
					for (int l = 0; l < num3; l++)
					{
						array6[l] = new int[num7];
					}
					int[][] array7 = array6;
					for (int i = 0; i < numRSBlocks; i++)
					{
						if (i < num8)
						{
							int num9 = 0;
							for (int j = 0; j < num6; j++)
							{
								if (j == num6 - num2)
								{
									num9 = num3;
								}
								array5[i][j] = blocks[j * numRSBlocks + i + num9];
							}
							ReedSolomon reedSolomon = new ReedSolomon(array5[i], num2);
							reedSolomon.correct();
							num += reedSolomon.NumCorrectedErrors;
							this.bool_0 = reedSolomon.CorrectionSucceeded;
						}
						else
						{
							int num9 = 0;
							for (int j = 0; j < num7; j++)
							{
								if (j == num6 - num2)
								{
									num9 = num8;
								}
								array7[i - num8][j] = blocks[j * numRSBlocks + i - num9];
							}
							ReedSolomon reedSolomon = new ReedSolomon(array7[i - num8], num2);
							reedSolomon.correct();
							num += reedSolomon.NumCorrectedErrors;
							this.bool_0 = reedSolomon.CorrectionSucceeded;
						}
					}
					int num5 = 0;
					for (int i = 0; i < numRSBlocks; i++)
					{
						if (i < num8)
						{
							for (int j = 0; j < num6 - num2; j++)
							{
								array[num5++] = array5[i][j];
							}
						}
						else
						{
							for (int j = 0; j < num7 - num2; j++)
							{
								array[num5++] = array7[i - num8][j];
							}
						}
					}
				}
				if (num > 0)
				{
					QRCodeDecoder.debugCanvas_0.println(Convert.ToString(num) + " data errors corrected.");
				}
				else
				{
					QRCodeDecoder.debugCanvas_0.println("No errors found.");
				}
				this.int_1 = num;
				result = array;
			}
			return result;
		}
		internal virtual sbyte[] getDecodedByteArray(int[] blocks, int version, int numErrorCorrectionCode)
		{
			QRCodeDataBlockReader qRCodeDataBlockReader = new QRCodeDataBlockReader(blocks, version, numErrorCorrectionCode);
			sbyte[] dataByte;
			try
			{
				dataByte = qRCodeDataBlockReader.DataByte;
			}
			catch (InvalidDataBlockException ex)
			{
				throw ex;
			}
			return dataByte;
		}
		internal virtual string getDecodedString(int[] blocks, int version, int numErrorCorrectionCode)
		{
			string result = null;
			QRCodeDataBlockReader qRCodeDataBlockReader = new QRCodeDataBlockReader(blocks, version, numErrorCorrectionCode);
			try
			{
				result = qRCodeDataBlockReader.DataString;
			}
			catch (IndexOutOfRangeException ex)
			{
				throw new InvalidDataBlockException(ex.Message);
			}
			return result;
		}
	}
}
