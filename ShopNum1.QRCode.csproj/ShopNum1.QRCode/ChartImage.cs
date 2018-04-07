using ShopNum1.QRCode.Codec;
using System;
using System.Drawing;
using System.IO;
using System.Text;
namespace ShopNum1.QRCode
{
	public class ChartImage
	{
		public void CreateChartImage(string saveImagePath, string URL, int Totalwidth, int Totalheight)
		{
			if (!string.IsNullOrEmpty(URL))
			{
				QRCodeEncoder qRCodeEncoder = new QRCodeEncoder();
				string a = "NUMERIC";
				if (a == "Byte")
				{
					qRCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
				}
				else if (a == "AlphaNumeric")
				{
					qRCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.ALPHA_NUMERIC;
				}
				else if (a == "Numeric")
				{
					qRCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.NUMERIC;
				}
				try
				{
					qRCodeEncoder.QRCodeScale = 5;
				}
				catch (Exception)
				{
					return;
				}
				try
				{
					int qRCodeVersion = (int)Convert.ToInt16(7);
					qRCodeEncoder.QRCodeVersion = qRCodeVersion;
				}
				catch (Exception)
				{
					return;
				}
				string a2 = "H";
				if (a2 == "L")
				{
					qRCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
				}
				else if (a2 == "M")
				{
					qRCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
				}
				else if (a2 == "Q")
				{
					qRCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.Q;
				}
				else if (a2 == "H")
				{
					qRCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.H;
				}
				new MemoryStream();
				Image image = qRCodeEncoder.Encode(URL, Encoding.UTF8);
				Bitmap bitmap = new Bitmap(Totalwidth, Totalheight);
				Graphics graphics = Graphics.FromImage(bitmap);
				SolidBrush solidBrush = new SolidBrush(Color.White);
				graphics.DrawImage(image, 1, 1);
				bitmap.Save(saveImagePath);
				solidBrush.Dispose();
				graphics.Dispose();
				bitmap.Dispose();
			}
		}
	}
}
