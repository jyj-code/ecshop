using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
namespace ZoomImageDemo
{
	public class CutPhotoHelp
	{
		public static string SaveCutPic(string pPath, string pSavedPath, int pPartStartPointX, int pPartStartPointY, int pPartWidth, int pPartHeight, int pOrigStartPointX, int pOrigStartPointY, int imageWidth, int imageHeight)
		{
			string result;
			using (Image image = Image.FromFile(pPath))
			{
				if (image.Width == imageWidth && image.Height == imageHeight)
				{
					result = CutPhotoHelp.SaveCutPic(pPath, pSavedPath, pPartStartPointX, pPartStartPointY, pPartWidth, pPartHeight, pOrigStartPointX, pOrigStartPointY);
				}
				else
				{
					string text = DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
					string text2 = pSavedPath + "\\" + text;
					Bitmap bitmap = CutPhotoHelp.MakeThumbnail(image, imageWidth, imageHeight);
					Bitmap bitmap2 = new Bitmap(pPartWidth, pPartHeight);
					Graphics graphics = Graphics.FromImage(bitmap2);
					Rectangle destRect = new Rectangle(new Point(pPartStartPointX, pPartStartPointY), new Size(pPartWidth, pPartHeight));
					Rectangle srcRect = new Rectangle(new Point(pOrigStartPointX, pOrigStartPointY), new Size(pPartWidth, pPartHeight));
					Graphics graphics2 = Graphics.FromImage(bitmap2);
					graphics2.Clear(Color.White);
					graphics2.InterpolationMode = InterpolationMode.HighQualityBicubic;
					graphics2.SmoothingMode = SmoothingMode.HighQuality;
					graphics.DrawImage(bitmap, destRect, srcRect, GraphicsUnit.Pixel);
					graphics2.Dispose();
					image.Dispose();
					if (File.Exists(text2))
					{
						File.SetAttributes(text2, FileAttributes.Normal);
						File.Delete(text2);
					}
					bitmap2.Save(text2, ImageFormat.Jpeg);
					bitmap2.Dispose();
					bitmap.Dispose();
					result = text;
				}
			}
			return result;
		}
		public static Bitmap MakeThumbnail(Image fromImg, int width, int height)
		{
			Bitmap bitmap = new Bitmap(width, height);
			int width2 = fromImg.Width;
			int height2 = fromImg.Height;
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.InterpolationMode = InterpolationMode.High;
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			graphics.Clear(Color.Transparent);
			graphics.DrawImage(fromImg, new Rectangle(0, 0, width, height), new Rectangle(0, 0, width2, height2), GraphicsUnit.Pixel);
			return bitmap;
		}
		public static string SaveCutPic(string pPath, string pSavedPath, int pPartStartPointX, int pPartStartPointY, int pPartWidth, int pPartHeight, int pOrigStartPointX, int pOrigStartPointY)
		{
			string text = DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
			string text2 = pSavedPath + "\\" + text;
			using (Image image = Image.FromFile(pPath))
			{
				Bitmap bitmap = new Bitmap(pPartWidth, pPartHeight);
				Graphics graphics = Graphics.FromImage(bitmap);
				Rectangle destRect = new Rectangle(new Point(pPartStartPointX, pPartStartPointY), new Size(pPartWidth, pPartHeight));
				Rectangle srcRect = new Rectangle(new Point(pOrigStartPointX, pOrigStartPointY), new Size(pPartWidth, pPartHeight));
				Graphics graphics2 = Graphics.FromImage(bitmap);
				graphics2.Clear(Color.White);
				graphics2.InterpolationMode = InterpolationMode.HighQualityBicubic;
				graphics2.SmoothingMode = SmoothingMode.HighQuality;
				graphics.DrawImage(image, destRect, srcRect, GraphicsUnit.Pixel);
				graphics2.Dispose();
				image.Dispose();
				if (File.Exists(text2))
				{
					File.SetAttributes(text2, FileAttributes.Normal);
					File.Delete(text2);
				}
				bitmap.Save(text2, ImageFormat.Jpeg);
				bitmap.Dispose();
			}
			return text;
		}
	}
}
