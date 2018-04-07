using System;
namespace ShopNum1.QRCode.Codec.Data
{
	public interface QRCodeImage
	{
		int Width
		{
			get;
		}
		int Height
		{
			get;
		}
		int getPixel(int int_0, int int_1);
	}
}
