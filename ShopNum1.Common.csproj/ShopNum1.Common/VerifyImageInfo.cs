using System;
using System.Drawing;
using System.Drawing.Imaging;
namespace ShopNum1.Common
{
	public class VerifyImageInfo
	{
		private Bitmap bitmap_0;
		private string string_0 = "image/pjpeg";
		private ImageFormat imageFormat_0 = ImageFormat.Jpeg;
		public Bitmap Image
		{
			get
			{
				return this.bitmap_0;
			}
			set
			{
				this.bitmap_0 = value;
			}
		}
		public string ContentType
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
			}
		}
		public ImageFormat ImageFormat
		{
			get
			{
				return this.imageFormat_0;
			}
			set
			{
				this.imageFormat_0 = value;
			}
		}
	}
}
