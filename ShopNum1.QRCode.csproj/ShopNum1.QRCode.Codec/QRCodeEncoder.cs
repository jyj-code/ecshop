using ShopNum1.QRCode.Codec.Util;
using System;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Text;

namespace ShopNum1.QRCode.Codec
{
    public class QRCodeEncoder
    {
        internal QRCodeEncoder.ERROR_CORRECTION error_CORRECTION_0;

        internal QRCodeEncoder.ENCODE_MODE encode_MODE_0;

        internal int int_0;

        internal int int_1;

        internal int int_2;

        internal int int_3;

        internal System.Drawing.Color color_0;

        internal System.Drawing.Color color_1;

        internal int int_4;

        internal string string_0;

        public virtual System.Drawing.Color QRCodeBackgroundColor
        {
            get
            {
                return this.color_0;
            }
            set
            {
                this.color_0 = value;
            }
        }

        public virtual QRCodeEncoder.ENCODE_MODE QRCodeEncodeMode
        {
            get
            {
                return this.encode_MODE_0;
            }
            set
            {
                this.encode_MODE_0 = value;
            }
        }

        public virtual QRCodeEncoder.ERROR_CORRECTION QRCodeErrorCorrect
        {
            get
            {
                return this.error_CORRECTION_0;
            }
            set
            {
                this.error_CORRECTION_0 = value;
            }
        }

        public virtual System.Drawing.Color QRCodeForegroundColor
        {
            get
            {
                return this.color_1;
            }
            set
            {
                this.color_1 = value;
            }
        }

        public virtual int QRCodeScale
        {
            get
            {
                return this.int_4;
            }
            set
            {
                this.int_4 = value;
            }
        }

        public virtual int QRCodeVersion
        {
            get
            {
                return this.int_0;
            }
            set
            {
                if ((value < 0 ? false : value <= 40))
                {
                    this.int_0 = value;
                }
            }
        }

        public QRCodeEncoder()
        {
            this.error_CORRECTION_0 = QRCodeEncoder.ERROR_CORRECTION.M;
            this.encode_MODE_0 = QRCodeEncoder.ENCODE_MODE.BYTE;
            this.int_0 = 7;
            this.int_1 = 0;
            this.int_2 = 0;
            this.int_3 = 0;
            this.string_0 = "";
            this.int_4 = 4;
            this.color_0 = System.Drawing.Color.White;
            this.color_1 = System.Drawing.Color.Black;
        }

        public virtual bool[][] calQrcode(byte[] qrcodeData)
        {
            bool[][] flagArray;
            int i;
            int num;
            int k;
            string str;
            MemoryStream memoryStream;
            BufferedStream bufferedStream;
            int[] numArray;
            int num1;
            int num2 = 0;
            int length = (int)qrcodeData.Length;
            int[] int2 = new int[length + 32];
            sbyte[] numArray1 = new sbyte[length + 32];
            if (length > 0)
            {
                if (this.int_1 > 1)
                {
                    int2[0] = 3;
                    numArray1[0] = 4;
                    int2[1] = this.int_2 - 1;
                    numArray1[1] = 4;
                    int2[2] = this.int_1 - 1;
                    numArray1[2] = 4;
                    int2[3] = this.int_3;
                    numArray1[3] = 8;
                    num2 = 4;
                }
                numArray1[num2] = 4;
                switch (this.encode_MODE_0)
                {
                    case QRCodeEncoder.ENCODE_MODE.ALPHA_NUMERIC:
                        {
                            numArray = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 };
                            int2[num2] = 2;
                            num2++;
                            int2[num2] = length;
                            numArray1[num2] = 9;
                            num1 = num2;
                            num2++;
                            for (i = 0; i < length; i++)
                            {
                                char chr = (char)qrcodeData[i];
                                sbyte num3 = 0;
                                if (!(chr < '0' ? true : chr >= ':'))
                                {
                                    num3 = (sbyte)(chr - 48);
                                }
                                else if ((chr < 'A' ? true : chr >= '['))
                                {
                                    if (chr == ' ')
                                    {
                                        num3 = 36;
                                    }
                                    if (chr == '$')
                                    {
                                        num3 = 37;
                                    }
                                    if (chr == '%')
                                    {
                                        num3 = 38;
                                    }
                                    if (chr == '*')
                                    {
                                        num3 = 39;
                                    }
                                    if (chr == '+')
                                    {
                                        num3 = 40;
                                    }
                                    if (chr == '-')
                                    {
                                        num3 = 41;
                                    }
                                    if (chr == '.')
                                    {
                                        num3 = 42;
                                    }
                                    if (chr == '/')
                                    {
                                        num3 = 43;
                                    }
                                    if (chr == ':')
                                    {
                                        num3 = 44;
                                    }
                                }
                                else
                                {
                                    num3 = (sbyte)(chr - 55);
                                }
                                if (i % 2 != 0)
                                {
                                    int2[num2] = int2[num2] * 45 + num3;
                                    numArray1[num2] = 11;
                                    if (i < length - 1)
                                    {
                                        num2++;
                                    }
                                }
                                else
                                {
                                    int2[num2] = num3;
                                    numArray1[num2] = 6;
                                }
                            }
                            num2++;
                            break;
                        }
                    case QRCodeEncoder.ENCODE_MODE.NUMERIC:
                        {
                            numArray = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 };
                            int2[num2] = 1;
                            num2++;
                            int2[num2] = length;
                            numArray1[num2] = 10;
                            num1 = num2;
                            num2++;
                            for (i = 0; i < length; i++)
                            {
                                if (i % 3 != 0)
                                {
                                    int2[num2] = int2[num2] * 10 + (qrcodeData[i] - 48);
                                    if (i % 3 != 1)
                                    {
                                        numArray1[num2] = 10;
                                        if (i < length - 1)
                                        {
                                            num2++;
                                        }
                                    }
                                    else
                                    {
                                        numArray1[num2] = 7;
                                    }
                                }
                                else
                                {
                                    int2[num2] = qrcodeData[i] - 48;
                                    numArray1[num2] = 4;
                                }
                            }
                            num2++;
                            break;
                        }
                    default:
                        {
                            numArray = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8 };
                            int2[num2] = 4;
                            num2++;
                            int2[num2] = length;
                            numArray1[num2] = 8;
                            num1 = num2;
                            num2++;
                            for (i = 0; i < length; i++)
                            {
                                int2[i + num2] = qrcodeData[i] & 255;
                                numArray1[i + num2] = 8;
                            }
                            num2 = num2 + length;
                            break;
                        }
                }
                int num4 = 0;
                for (i = 0; i < num2; i++)
                {
                    num4 = num4 + numArray1[i];
                }
                switch (this.error_CORRECTION_0)
                {
                    case QRCodeEncoder.ERROR_CORRECTION.L:
                        {
                            num = 1;
                            break;
                        }
                    case QRCodeEncoder.ERROR_CORRECTION.M:
                        {
                            num = 0;
                            break;
                        }
                    case QRCodeEncoder.ERROR_CORRECTION.Q:
                        {
                            num = 3;
                            break;
                        }
                    case QRCodeEncoder.ERROR_CORRECTION.H:
                        {
                            num = 2;
                            break;
                        }
                    default:
                        {
                            goto case QRCodeEncoder.ERROR_CORRECTION.M;
                        }
                }
                int[][] numArray2 = new int[][] { new int[] { 0, 128, 224, 352, 512, 688, 864, 992, 1232, 1456, 1728, 2032, 2320, 2672, 2920, 3320, 3624, 4056, 4504, 5016, 5352, 5712, 6256, 6880, 7312, 8000, 8496, 9024, 9544, 10136, 10984, 11640, 12328, 13048, 13800, 14496, 15312, 15936, 16816, 17728, 18672 }, new int[] { 0, 152, 272, 440, 640, 864, 1088, 1248, 1552, 1856, 2192, 2592, 2960, 3424, 3688, 4184, 4712, 5176, 5768, 6360, 6888, 7456, 8048, 8752, 9392, 10208, 10960, 11744, 12248, 13048, 13880, 14744, 15640, 16568, 17528, 18448, 19472, 20528, 21616, 22496, 23648 }, new int[] { 0, 72, 128, 208, 288, 368, 480, 528, 688, 800, 976, 1120, 1264, 1440, 1576, 1784, 2024, 2264, 2504, 2728, 3080, 3248, 3536, 3712, 4112, 4304, 4768, 5024, 5288, 5608, 5960, 6344, 6760, 7208, 7688, 7888, 8432, 8768, 9136, 9776, 10208 }, new int[] { 0, 104, 176, 272, 384, 496, 608, 704, 880, 1056, 1232, 1440, 1648, 1952, 2088, 2360, 2600, 2936, 3176, 3560, 3880, 4096, 4544, 4912, 5312, 5744, 6032, 6464, 6968, 7288, 7880, 8264, 8920, 9368, 9848, 10288, 10832, 11408, 12016, 12656, 13328 } };
                int[][] numArray3 = numArray2;
                int num5 = 0;
                if (this.int_0 != 0)
                {
                    num5 = numArray3[num][this.int_0];
                }
                else
                {
                    this.int_0 = 1;
                    i = 1;
                    while (i <= 40)
                    {
                        if (numArray3[num][i] >= num4 + numArray[this.int_0])
                        {
                            num5 = numArray3[num][i];
                            goto Label1;
                        }
                        else
                        {
                            QRCodeEncoder int0 = this;
                            int0.int_0 = int0.int_0 + 1;
                            i++;
                        }
                    }
                }
            Label1:
                num4 = num4 + numArray[this.int_0];
                numArray1[num1] = (sbyte)(numArray1[num1] + numArray[this.int_0]);
                int num6 = (new int[] { 0, 26, 44, 70, 100, 134, 172, 196, 242, 292, 346, 404, 466, 532, 581, 655, 733, 815, 901, 991, 1085, 1156, 1258, 1364, 1474, 1588, 1706, 1828, 1921, 2051, 2185, 2323, 2465, 2611, 2761, 2876, 3034, 3196, 3362, 3532, 3706 })[this.int_0];
                int[] numArray4 = new int[] { 0, 0, 7, 7, 7, 7, 7, 0, 0, 0, 0, 0, 0, 0, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 3, 3, 3, 3, 3, 3, 3, 0, 0, 0, 0, 0, 0 };
                int num7 = numArray4[this.int_0] + (num6 << 3);
                sbyte[] numArray5 = new sbyte[num7];
                sbyte[] numArray6 = new sbyte[num7];
                sbyte[] numArray7 = new sbyte[num7];
                sbyte[] numArray8 = new sbyte[15];
                sbyte[] numArray9 = new sbyte[15];
                sbyte[] numArray10 = new sbyte[1];
                sbyte[] numArray11 = new sbyte[128];
                try
                {
                    str = string.Concat("qrv", Convert.ToString(this.int_0), "_", Convert.ToString(num));
                    memoryStream = new MemoryStream((byte[])Class3.smethod_0().GetObject(str));
                    bufferedStream = new BufferedStream(memoryStream);
                    SystemUtils.ReadInput(bufferedStream, numArray5, 0, (int)numArray5.Length);
                    SystemUtils.ReadInput(bufferedStream, numArray6, 0, (int)numArray6.Length);
                    SystemUtils.ReadInput(bufferedStream, numArray7, 0, (int)numArray7.Length);
                    SystemUtils.ReadInput(bufferedStream, numArray8, 0, (int)numArray8.Length);
                    SystemUtils.ReadInput(bufferedStream, numArray9, 0, (int)numArray9.Length);
                    SystemUtils.ReadInput(bufferedStream, numArray10, 0, (int)numArray10.Length);
                    SystemUtils.ReadInput(bufferedStream, numArray11, 0, (int)numArray11.Length);
                    bufferedStream.Close();
                    memoryStream.Close();
                }
                catch (Exception exception)
                {
                    SystemUtils.WriteStackTrace(exception, Console.Error);
                }
                sbyte num8 = 1;
                sbyte num9 = 1;
                while (true)
                {
                    if (num9 >= 128)
                    {
                        break;
                    }
                    else if (numArray11[num9] == 0)
                    {
                        num8 = num9;
                        break;
                    }
                    else
                    {
                        num9 = (sbyte)(num9 + 1);
                    }
                }
                sbyte[] numArray12 = new sbyte[num8];
                Array.Copy(numArray11, 0, numArray12, 0, (int)num8);
                sbyte[] numArray13 = new sbyte[] { 0, 1, 2, 3, 4, 5, 7, 8, 8, 8, 8, 8, 8, 8, 8 };
                sbyte[] numArray14 = new sbyte[] { 8, 8, 8, 8, 8, 8, 8, 8, 7, 5, 4, 3, 2, 1, 0 };
                int num10 = num5 >> 3;
                int int01 = 4 * this.int_0 + 17;
                sbyte[] numArray15 = new sbyte[int01 * int01 + int01];
                try
                {
                    str = string.Concat("qrvfr", Convert.ToString(this.int_0));
                    memoryStream = new MemoryStream((byte[])Class3.smethod_0().GetObject(str));
                    bufferedStream = new BufferedStream(memoryStream);
                    SystemUtils.ReadInput(bufferedStream, numArray15, 0, (int)numArray15.Length);
                    bufferedStream.Close();
                    memoryStream.Close();
                }
                catch (Exception exception1)
                {
                    SystemUtils.WriteStackTrace(exception1, Console.Error);
                }
                if (num4 <= num5 - 4)
                {
                    int2[num2] = 0;
                    numArray1[num2] = 4;
                }
                else if (num4 < num5)
                {
                    int2[num2] = 0;
                    numArray1[num2] = (sbyte)(num5 - num4);
                }
                else if (num4 > num5)
                {
                    Console.Out.WriteLine("overflow");
                }
                sbyte[] numArray16 = QRCodeEncoder.smethod_0(int2, numArray1, num10);
                sbyte[] numArray17 = QRCodeEncoder.smethod_1(numArray16, numArray10[0], numArray12, num10, num6);
                sbyte[][] numArray18 = new sbyte[int01][];
                for (int j = 0; j < int01; j++)
                {
                    numArray18[j] = new sbyte[int01];
                }
                for (i = 0; i < int01; i++)
                {
                    for (k = 0; k < int01; k++)
                    {
                        numArray18[k][i] = 0;
                    }
                }
                for (i = 0; i < num6; i++)
                {
                    sbyte num11 = numArray17[i];
                    for (k = 7; k >= 0; k--)
                    {
                        int num12 = i * 8 + k;
                        numArray18[numArray5[num12] & 255][numArray6[num12] & 255] = (sbyte)(255 * (num11 & 1) ^ numArray7[num12]);
                        num11 = (sbyte)SystemUtils.URShift(num11 & 255, 1);
                    }
                }
                for (int l = numArray4[this.int_0]; l > 0; l--)
                {
                    int num13 = l + num6 * 8 - 1;
                    numArray18[numArray5[num13] & 255][numArray6[num13] & 255] = (sbyte)(255 ^ numArray7[num13]);
                }
                sbyte num14 = QRCodeEncoder.smethod_3(numArray18, numArray4[this.int_0] + num6 * 8);
                sbyte num15 = (sbyte)(1 << (num14 & 31));
                sbyte num16 = (sbyte)(num << 3 | num14);
                string[] strArrays = new string[] { "101010000010010", "101000100100101", "101111001111100", "101101101001011", "100010111111001", "100000011001110", "100111110010111", "100101010100000", "111011111000100", "111001011110011", "111110110101010", "111100010011101", "110011000101111", "110001100011000", "110110001000001", "110100101110110", "001011010001001", "001001110111110", "001110011100111", "001100111010000", "000011101100010", "000001001010101", "000110100001100", "000100000111011", "011010101011111", "011000001101000", "011111100110001", "011101000000110", "010010010110100", "010000110000011", "010111011011010", "010101111101101" };
                string[] strArrays1 = strArrays;
                for (i = 0; i < 15; i++)
                {
                    sbyte num17 = sbyte.Parse(strArrays1[num16].Substring(i, i + 1 - i));
                    numArray18[numArray13[i] & 255][numArray14[i] & 255] = (sbyte)(num17 * 255);
                    numArray18[numArray8[i] & 255][numArray9[i] & 255] = (sbyte)(num17 * 255);
                }
                bool[][] flagArray1 = new bool[int01][];
                for (int m = 0; m < int01; m++)
                {
                    flagArray1[m] = new bool[int01];
                }
                int num18 = 0;
                for (i = 0; i < int01; i++)
                {
                    for (k = 0; k < int01; k++)
                    {
                        if (((numArray18[k][i] & num15) != 0 ? false : numArray15[num18] != 49))
                        {
                            flagArray1[k][i] = false;
                        }
                        else
                        {
                            flagArray1[k][i] = true;
                        }
                        num18++;
                    }
                    num18++;
                }
                flagArray = flagArray1;
            }
            else
            {
                flagArray = new bool[][] { new bool[1] };
            }
            return flagArray;
        }

        public virtual int calStructureappendParity(sbyte[] originaldata)
        {
            int num = 0;
            int num1 = 0;
            int length = (int)originaldata.Length;
            if (length <= 1)
            {
                num1 = -1;
            }
            else
            {
                num1 = 0;
                while (num < length)
                {
                    num1 = num1 ^ originaldata[num] & 255;
                    num++;
                }
            }
            return num1;
        }

        public virtual Bitmap Encode(string content, Encoding encoding)
        {
            bool[][] flagArray = this.calQrcode(encoding.GetBytes(content));
            SolidBrush solidBrush = new SolidBrush(this.color_0);
            Bitmap bitmap = new Bitmap((int)flagArray.Length * this.int_4 + 1, (int)flagArray.Length * this.int_4 + 1);
            Graphics graphic = Graphics.FromImage(bitmap);
            graphic.FillRectangle(solidBrush, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
            solidBrush.Color = this.color_1;
            for (int i = 0; i < (int)flagArray.Length; i++)
            {
                for (int j = 0; j < (int)flagArray.Length; j++)
                {
                    if (flagArray[j][i])
                    {
                        graphic.FillRectangle(solidBrush, j * this.int_4, i * this.int_4, this.int_4, this.int_4);
                    }
                }
            }
            return bitmap;
        }

        public virtual Bitmap Encode(string content)
        {
            Bitmap bitmap;
            bitmap = (!QRCodeUtility.IsUniCode(content) ? this.Encode(content, Encoding.ASCII) : this.Encode(content, Encoding.Unicode));
            return bitmap;
        }

        public virtual void setStructureappend(int int_5, int int_6, int int_7)
        {
            if ((int_6 <= 1 || int_6 > 16 || int_5 <= 0 || int_5 > 16 || int_7 < 0 ? false : int_7 <= 255))
            {
                this.int_2 = int_5;
                this.int_1 = int_6;
                this.int_3 = int_7;
            }
        }

        private static sbyte[] smethod_0(int[] int_5, sbyte[] sbyte_0, int int_6)
        {
            bool flag;
            int num5;
            int length = sbyte_0.Length;
            int index = 0;
            int num3 = 8;
            int num4 = 0;
            if (length == int_5.Length)
            {
            }
            for (num5 = 0; num5 < length; num5++)
            {
                num4 += sbyte_0[num5];
            }
            int num6 = ((num4 - 1) / 8) + 1;
            sbyte[] numArray = new sbyte[int_6];
            for (num5 = 0; num5 < num6; num5++)
            {
                numArray[num5] = 0;
            }
            for (num5 = 0; num5 < length; num5++)
            {
                int num7 = int_5[num5];
                int num8 = sbyte_0[num5];
                flag = true;
                if (num8 != 0)
                {
                    goto Label_00E1;
                }
                break;
            Label_0078:
                if (num3 > num8)
                {
                    numArray[index] = (sbyte)((numArray[index] << num8) | num7);
                    num3 -= num8;
                    flag = false;
                }
                else
                {
                    num8 -= num3;
                    numArray[index] = (sbyte)((numArray[index] << num3) | (num7 >> num8));
                    if (num8 == 0)
                    {
                        flag = false;
                    }
                    else
                    {
                        num7 &= (((int)1) << num8) - 1;
                        flag = true;
                    }
                    index++;
                    num3 = 8;
                }
            Label_00E1:
                if (flag)
                {
                    goto Label_0078;
                }
            }
            if (num3 != 8)
            {
                numArray[index] = (sbyte)(numArray[index] << num3);
            }
            else
            {
                index--;
            }
            if (index < (int_6 - 1))
            {
                for (flag = true; index < (int_6 - 1); flag = !flag)
                {
                    index++;
                    if (flag)
                    {
                        numArray[index] = -20;
                    }
                    else
                    {
                        numArray[index] = 0x11;
                    }
                }
            }
            return numArray;

        }

        private static sbyte[] smethod_1(sbyte[] sbyte_0, sbyte sbyte_1, sbyte[] sbyte_2, int int_5, int int_6)
        {
            int i;
            sbyte[] numArray;
            sbyte[][] numArray1 = new sbyte[256][];
            for (i = 0; i < 256; i++)
            {
                numArray1[i] = new sbyte[sbyte_1];
            }
            try
            {
                string str = string.Concat("rsc", sbyte_1.ToString());
                MemoryStream memoryStream = new MemoryStream((byte[])Class3.smethod_0().GetObject(str));
                BufferedStream bufferedStream = new BufferedStream(memoryStream);
                for (i = 0; i < 256; i++)
                {
                    SystemUtils.ReadInput(bufferedStream, numArray1[i], 0, (int)numArray1[i].Length);
                }
                bufferedStream.Close();
                memoryStream.Close();
            }
            catch (Exception exception)
            {
                SystemUtils.WriteStackTrace(exception, Console.Error);
            }
            int j = 0;
            int l = 0;
            int k = 0;
            sbyte[][] sbyte0 = new sbyte[(int)sbyte_2.Length][];
            sbyte[] numArray2 = new sbyte[int_6];
            Array.Copy(sbyte_0, 0, numArray2, 0, (int)sbyte_0.Length);
            for (j = 0; j < (int)sbyte_2.Length; j++)
            {
                sbyte0[j] = new sbyte[(sbyte_2[j] & 255) - sbyte_1];
            }
            for (j = 0; j < int_5; j++)
            {
                sbyte0[k][l] = sbyte_0[j];
                l++;
                if (l >= (sbyte_2[k] & 255) - sbyte_1)
                {
                    l = 0;
                    k++;
                }
            }
            for (k = 0; k < (int)sbyte_2.Length; k++)
            {
                sbyte[] numArray3 = new sbyte[(int)sbyte0[k].Length];
                sbyte0[k].CopyTo(numArray3, 0);
                for (l = (sbyte_2[k] & 255) - sbyte_1; l > 0; l--)
                {
                    sbyte num = numArray3[0];
                    if (num != 0)
                    {
                        sbyte[] numArray4 = new sbyte[(int)numArray3.Length - 1];
                        Array.Copy(numArray3, 1, numArray4, 0, (int)numArray3.Length - 1);
                        sbyte[] numArray5 = numArray1[num & 255];
                        numArray3 = QRCodeEncoder.smethod_2(numArray4, numArray5, "xor");
                    }
                    else if (sbyte_1 >= (int)numArray3.Length)
                    {
                        numArray = new sbyte[sbyte_1];
                        Array.Copy(numArray3, 1, numArray, 0, (int)numArray3.Length - 1);
                        numArray[sbyte_1 - 1] = 0;
                        numArray3 = new sbyte[(int)numArray.Length];
                        numArray.CopyTo(numArray3, 0);
                    }
                    else
                    {
                        numArray = new sbyte[(int)numArray3.Length - 1];
                        Array.Copy(numArray3, 1, numArray, 0, (int)numArray3.Length - 1);
                        numArray3 = new sbyte[(int)numArray.Length];
                        numArray.CopyTo(numArray3, 0);
                    }
                }
                Array.Copy(numArray3, 0, numArray2, (int)sbyte_0.Length + k * sbyte_1, (int)sbyte_1);
            }
            return numArray2;
        }

        private static sbyte[] smethod_2(sbyte[] sbyte_0, sbyte[] sbyte_1, string string_1)
        {
            sbyte[] numArray;
            sbyte[] numArray1;
            if ((int)sbyte_0.Length <= (int)sbyte_1.Length)
            {
                numArray = new sbyte[(int)sbyte_1.Length];
                sbyte_1.CopyTo(numArray, 0);
                numArray1 = new sbyte[(int)sbyte_0.Length];
                sbyte_0.CopyTo(numArray1, 0);
            }
            else
            {
                numArray = new sbyte[(int)sbyte_0.Length];
                sbyte_0.CopyTo(numArray, 0);
                numArray1 = new sbyte[(int)sbyte_1.Length];
                sbyte_1.CopyTo(numArray1, 0);
            }
            int length = (int)numArray.Length;
            int num = (int)numArray1.Length;
            sbyte[] numArray2 = new sbyte[length];
            for (int i = 0; i < length; i++)
            {
                if (i >= num)
                {
                    numArray2[i] = numArray[i];
                }
                else if ((object)string_1 != (object)"xor")
                {
                    numArray2[i] = (sbyte)(numArray[i] | numArray1[i]);
                }
                else
                {
                    numArray2[i] = (sbyte)(numArray[i] ^ numArray1[i]);
                }
            }
            return numArray2;
        }

        private static sbyte smethod_3(sbyte[][] sbyte_0, int int_5)
        {
            int k;
            int length = (int)sbyte_0.Length;
            int[] numArray = new int[8];
            int[] numArray1 = new int[8];
            int[] numArray2 = new int[8];
            int[] numArray3 = new int[8];
            int sbyte0 = 0;
            int num = 0;
            int[] numArray4 = new int[8];
            for (int i = 0; i < length; i++)
            {
                int[] numArray5 = new int[8];
                int[] numArray6 = new int[8];
                bool[] flagArray = new bool[8];
                bool[] flagArray1 = new bool[8];
                for (int j = 0; j < length; j++)
                {
                    if ((j <= 0 ? false : i > 0))
                    {
                        sbyte0 = sbyte_0[j][i] & sbyte_0[j - 1][i] & sbyte_0[j][i - 1] & sbyte_0[j - 1][i - 1] & 255;
                        num = sbyte_0[j][i] & 255 | sbyte_0[j - 1][i] & 255 | sbyte_0[j][i - 1] & 255 | sbyte_0[j - 1][i - 1] & 255;
                    }
                    for (k = 0; k < 8; k++)
                    {
                        numArray5[k] = (numArray5[k] & 63) << 1 | SystemUtils.URShift(sbyte_0[j][i] & 255, k) & 1;
                        numArray6[k] = (numArray6[k] & 63) << 1 | SystemUtils.URShift(sbyte_0[i][j] & 255, k) & 1;
                        if ((sbyte_0[j][i] & 1 << (k & 31)) != 0)
                        {
                            numArray4[k] = numArray4[k] + 1;
                        }
                        if (numArray5[k] == 93)
                        {
                            numArray2[k] = numArray2[k] + 40;
                        }
                        if (numArray6[k] == 93)
                        {
                            numArray2[k] = numArray2[k] + 40;
                        }
                        if ((j <= 0 ? false : i > 0))
                        {
                            if (((sbyte0 & 1) != 0 ? true : (num & 1) == 0))
                            {
                                numArray1[k] = numArray1[k] + 3;
                            }
                            sbyte0 = sbyte0 >> 1;
                            num = num >> 1;
                        }
                        if (((numArray5[k] & 31) == 0 ? false : (numArray5[k] & 31) != 31))
                        {
                            flagArray[k] = false;
                        }
                        else if (j > 3)
                        {
                            if (!flagArray[k])
                            {
                                numArray[k] = numArray[k] + 3;
                                flagArray[k] = true;
                            }
                            else
                            {
                                numArray[k] = numArray[k] + 1;
                            }
                        }
                        if (((numArray6[k] & 31) == 0 ? false : (numArray6[k] & 31) != 31))
                        {
                            flagArray1[k] = false;
                        }
                        else if (j > 3)
                        {
                            if (!flagArray1[k])
                            {
                                numArray[k] = numArray[k] + 3;
                                flagArray1[k] = true;
                            }
                            else
                            {
                                numArray[k] = numArray[k] + 1;
                            }
                        }
                    }
                }
            }
            int num1 = 0;
            sbyte num2 = 0;
            int[] numArray7 = new int[] { 90, 80, 70, 60, 50, 40, 30, 20, 10, 0, 0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 90 };
            for (k = 0; k < 8; k++)
            {
                numArray3[k] = numArray7[20 * numArray4[k] / int_5];
                int num3 = numArray[k] + numArray1[k] + numArray2[k] + numArray3[k];
                if ((num3 < num1 ? true : k == 0))
                {
                    num2 = (sbyte)k;
                    num1 = num3;
                }
            }
            return num2;
        }

        public enum ENCODE_MODE
        {
            ALPHA_NUMERIC,
            NUMERIC,
            BYTE
        }

        public enum ERROR_CORRECTION
        {
            L,
            M,
            Q,
            H
        }
    }
}