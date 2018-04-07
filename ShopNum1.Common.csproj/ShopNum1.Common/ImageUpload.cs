using System;
using System.IO;
using System.Web;
namespace ShopNum1.Common
{
	public class ImageUpload
	{
		public static string GetFileSuffix(byte[] fileData)
		{
			string result;
			if (fileData == null || fileData.Length < 10)
			{
				result = null;
			}
			else if (fileData[0] == 71 && fileData[1] == 73 && fileData[2] == 70)
			{
				result = "GIF";
			}
			else if (fileData[1] == 80 && fileData[2] == 78 && fileData[3] == 71)
			{
				result = "PNG";
			}
			else if (fileData[6] == 74 && fileData[7] == 70 && fileData[8] == 73 && fileData[9] == 70)
			{
				result = "JPG";
			}
			else if (fileData[0] == 66 && fileData[1] == 77)
			{
				result = "BMP";
			}
			else
			{
				result = null;
			}
			return result;
		}
		public static string GetMimeType(byte[] fileData)
		{
			string fileSuffix = ImageUpload.GetFileSuffix(fileData);
			string text = fileSuffix;
			string result;
			if (text != null)
			{
				if (text == "JPG")
				{
					result = "image/jpeg";
					return result;
				}
				if (text == "GIF")
				{
					result = "image/gif";
					return result;
				}
				if (text == "PNG")
				{
					result = "image/png";
					return result;
				}
				if (text == "BMP")
				{
					result = "image/bmp";
					return result;
				}
			}
			result = "application/octet-stream";
			return result;
		}
		public static string GetMimeType(string fileName)
		{
			fileName = fileName.ToLower();
			string result;
			if (fileName.EndsWith(".bmp", StringComparison.CurrentCulture))
			{
				result = "image/bmp";
			}
			else if (fileName.EndsWith(".gif", StringComparison.CurrentCulture))
			{
				result = "image/gif";
			}
			else if (fileName.EndsWith(".jpg", StringComparison.CurrentCulture) || fileName.EndsWith(".jpeg", StringComparison.CurrentCulture))
			{
				result = "image/jpeg";
			}
			else if (fileName.EndsWith(".png", StringComparison.CurrentCulture))
			{
				result = "image/png";
			}
			else
			{
				result = "application/octet-stream";
			}
			return result;
		}
		public void CheckImgType(string fileName)
		{
			string fileName2 = HttpContext.Current.Server.MapPath(fileName);
			FileStream fileStream = new FileInfo(fileName2).OpenRead();
			byte[] buffer = new byte[fileStream.Length];
			fileStream.Read(buffer, 0, Convert.ToInt32(fileStream.Length));
		}
		public static bool CheckImgTypex(string[] ExtArry, string strExt)
		{
			bool result = false;
			for (int i = 0; i < ExtArry.Length; i++)
			{
				if (ExtArry[i] == strExt)
				{
					result = true;
				}
			}
			return result;
		}
	}
}
