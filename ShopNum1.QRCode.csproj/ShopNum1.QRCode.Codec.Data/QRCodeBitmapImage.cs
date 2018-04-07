using System;
using System.Drawing;
namespace ShopNum1.QRCode.Codec.Data
{
	public class QRCodeBitmapImage : QRCodeImage
	{
		private Bitmap bitmap_0;
		public virtual int Width
		{
			get
			{
				return this.bitmap_0.Width;
			}
		}
		public virtual int Height
		{
			get
			{
				return this.bitmap_0.Height;
			}
		}
		public QRCodeBitmapImage(Bitmap image)
		{
			this.bitmap_0 = image;
		}
		public virtual int getPixel(int int_0, int int_1)
		{
			return this.bitmap_0.GetPixel(int_0, int_1).ToArgb();
		}
	}
}
