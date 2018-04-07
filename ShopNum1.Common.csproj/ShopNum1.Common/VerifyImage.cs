using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Security.Cryptography;
namespace ShopNum1.Common
{
	public class VerifyImage : IVerifyImage
	{
		private static byte[] byte_0 = new byte[4];
		private static RNGCryptoServiceProvider rngcryptoServiceProvider_0 = new RNGCryptoServiceProvider();
		private static Font[] font_0 = new Font[]
		{
			new Font(new FontFamily("Times New Roman"), (float)(16 + VerifyImage.smethod_0(4)), FontStyle.Bold),
			new Font(new FontFamily("Georgia"), (float)(16 + VerifyImage.smethod_0(4)), FontStyle.Bold),
			new Font(new FontFamily("Arial"), (float)(16 + VerifyImage.smethod_0(4)), FontStyle.Bold),
			new Font(new FontFamily("Comic Sans MS"), (float)(16 + VerifyImage.smethod_0(4)), FontStyle.Bold),
			new Font(new FontFamily("Tahoma"), (float)(16 + VerifyImage.smethod_0(4)), FontStyle.Bold)
		};
		private static int smethod_0(int int_0)
		{
			VerifyImage.rngcryptoServiceProvider_0.GetBytes(VerifyImage.byte_0);
			int num = BitConverter.ToInt32(VerifyImage.byte_0, 0);
			num %= int_0 + 1;
			if (num < 0)
			{
				num = -num;
			}
			return num;
		}
		private static int smethod_1(int int_0, int int_1)
		{
			return VerifyImage.smethod_0(int_1 - int_0) + int_0;
		}
		public VerifyImageInfo GenerateImage(string code, int width, int height, Color bgcolor, int textcolor)
		{
			VerifyImageInfo verifyImageInfo = new VerifyImageInfo();
			verifyImageInfo.ImageFormat = ImageFormat.Jpeg;
			verifyImageInfo.ContentType = "image/pjpeg";
			Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
			Graphics graphics = Graphics.FromImage(bitmap);
			Rectangle rectangle = new Rectangle(0, 0, width, height);
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			graphics.Clear(bgcolor);
			int num = (textcolor == 2) ? 60 : 0;
			SolidBrush solidBrush = new SolidBrush(Color.FromArgb(VerifyImage.smethod_0(100), VerifyImage.smethod_0(100), VerifyImage.smethod_0(100)));
			for (int i = 0; i < 3; i++)
			{
				Pen pen = new Pen(Color.FromArgb(VerifyImage.smethod_0(150) + num, VerifyImage.smethod_0(150) + num, VerifyImage.smethod_0(150) + num), 1f);
				graphics.DrawLine(pen, new PointF(0f + (float)VerifyImage.smethod_0(20), 0f + (float)VerifyImage.smethod_0(height)), new PointF(0f + (float)VerifyImage.smethod_0(width), 0f + (float)VerifyImage.smethod_0(height)));
			}
			Matrix matrix = new Matrix();
			for (int i = 0; i < code.Length; i++)
			{
				matrix.Reset();
				matrix.RotateAt((float)(VerifyImage.smethod_0(30) - 15), new PointF((float)Convert.ToInt64((double)width * (0.1 * (double)i)), (float)Convert.ToInt64((double)height * 0.5)));
				graphics.Transform = matrix;
				solidBrush.Color = Color.FromArgb(VerifyImage.smethod_0(150) + num + 20, VerifyImage.smethod_0(150) + num + 20, VerifyImage.smethod_0(150) + num + 20);
				PointF point = new PointF(0f + (float)VerifyImage.smethod_0(4) + (float)(i * 20), 3f + (float)VerifyImage.smethod_0(3));
				graphics.DrawString((VerifyImage.smethod_0(1) == 1) ? code[i].ToString() : code[i].ToString().ToUpper(), VerifyImage.font_0[VerifyImage.smethod_0(VerifyImage.font_0.Length - 1)], solidBrush, point);
				graphics.ResetTransform();
			}
			double num2 = (double)(VerifyImage.smethod_1(5, 10) * ((VerifyImage.smethod_0(10) == 1) ? 1 : -1));
			using (Bitmap bitmap2 = (Bitmap)bitmap.Clone())
			{
				for (int j = 0; j < height; j++)
				{
					for (int i = 0; i < width; i++)
					{
						int num3 = (int)((double)i + num2 * Math.Sin(3.1415926535897931 * (double)j / 84.5));
						int num4 = (int)((double)j + num2 * Math.Cos(3.1415926535897931 * (double)i / 54.5));
						if (num3 < 0 || num3 >= width)
						{
							num3 = 0;
						}
						if (num4 < 0 || num4 >= height)
						{
							num4 = 0;
						}
						bitmap.SetPixel(i, j, bitmap2.GetPixel(num3, num4));
					}
				}
			}
			solidBrush.Dispose();
			graphics.Dispose();
			verifyImageInfo.Image = bitmap;
			return verifyImageInfo;
		}
	}
}
