using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Web;
using System.Web.UI.WebControls;
namespace ShopNum1.Common
{
	public class ShopNum1UpLoad
	{
		public enum PhotoMode
		{
			HW,
			W,
			H,
			Cut
		}
		public static bool FileUpLoad(FileUpload fileUpload_0, string filepath, out string retstr)
		{
			Random random = new Random();
			string fileName = fileUpload_0.PostedFile.FileName;
			string text = HttpContext.Current.Server.MapPath(filepath);
			bool result;
			if (ShopNum1UpLoad.FileType(fileUpload_0, out retstr))
			{
				if (fileName.IndexOf(".") != -1)
				{
					string str = fileName.Substring(fileName.LastIndexOf("."));
					string str2 = DateTime.Now.ToString("yyyyMMddHHmmss");
					string str3 = str2 + random.Next(100, 999).ToString() + str;
					if (!Directory.Exists(text))
					{
						Directory.CreateDirectory(text);
					}
					fileUpload_0.PostedFile.SaveAs(text + str3);
					retstr = filepath + str3;
					result = true;
				}
				else
				{
					result = false;
				}
			}
			else
			{
				result = false;
			}
			return result;
		}
		public static bool FileType(FileUpload fileUpload_0)
		{
			bool result;
			if (fileUpload_0.HasFile)
			{
				string fileName = fileUpload_0.PostedFile.FileName;
				if (fileName.LastIndexOf(".") != -1)
				{
					string contentType = fileUpload_0.PostedFile.ContentType;
					string a = fileName.ToLower().Substring(fileName.LastIndexOf("."));
					result = ((contentType == "image/gif" || contentType == "image/x-png" || contentType == "image/png" || contentType == "image/pjpeg" || contentType == "image/jpeg" || contentType == "image/jpg" || contentType == "text/plain" || contentType == "application/vnd.ms-excel" || contentType == "application/octet-stream" || contentType == "application/x-shockwave-flash" || contentType == "application/x-zip-compressed" || contentType == "application/msword" || contentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet") && (a == ".gif" || a == ".jpg" || a == ".jpeg" || a == ".png" || a == ".xlsx" || a == ".xls" || a == ".exl" || a == ".doc" || a == ".docx" || a == ".txt" || a == ".zip" || a == ".rar" || a == ".swf"));
				}
				else
				{
					result = false;
				}
			}
			else
			{
				result = false;
			}
			return result;
		}
		public static bool FileType(FileUpload fileUpload_0, out string retstr)
		{
			string contentType = fileUpload_0.PostedFile.ContentType;
			string fileName = fileUpload_0.PostedFile.FileName;
			int contentLength = fileUpload_0.PostedFile.ContentLength;
			bool result;
			if (fileUpload_0.HasFile)
			{
				if (fileName.LastIndexOf(".") != -1)
				{
					string a = fileName.ToLower().Substring(fileName.LastIndexOf("."));
					if (contentLength < 1024000)
					{
						if ((contentType == "image/gif" || contentType == "application/x-rar-compressed" || contentType == "image/x-png" || contentType == "image/png" || contentType == "image/pjpeg" || contentType == "image/jpeg" || contentType == "image/jpg" || contentType == "text/plain" || contentType == "application/vnd.ms-excel" || contentType == "application/octet-stream" || contentType == "application/x-shockwave-flash" || contentType == "application/x-zip-compressed" || contentType == "application/msword" || contentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet") && (a == ".gif" || a == ".jpg" || a == ".jpeg" || a == ".png" || a == ".xlsx" || a == ".xls" || a == ".exl" || a == ".doc" || a == ".docx" || a == ".txt" || a == ".zip" || a == ".rar" || a == ".swf"))
						{
							retstr = "文件符合条件！";
							result = true;
						}
						else
						{
							retstr = "文件格式不正确！";
							result = false;
						}
					}
					else
					{
						retstr = "文件不能大于1M！";
						result = false;
					}
				}
				else
				{
					retstr = "文件格式不正确！";
					result = false;
				}
			}
			else
			{
				retstr = "文件不存在！";
				result = false;
			}
			return result;
		}
		public static bool ImageUpLoadWithName(FileUpload fileUpload_0, string filepath, out string retstr)
		{
			bool result;
			if (ShopNum1UpLoad.ImageType(fileUpload_0, out retstr))
			{
				string text = HttpContext.Current.Server.MapPath(filepath);
				if (File.Exists(text))
				{
					File.Delete(text);
				}
				fileUpload_0.PostedFile.SaveAs(text);
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}
		public static bool ImageUpLoad(FileUpload fileUpload_0, string filepath, out string retstr, bool shuiyin)
		{
			Random random = new Random();
			string fileName = fileUpload_0.PostedFile.FileName;
			string str = HttpContext.Current.Server.MapPath(filepath);
			bool result;
			if (ShopNum1UpLoad.ImageType(fileUpload_0, out retstr))
			{
				string str2 = fileName.Substring(fileName.LastIndexOf("."));
				string text = DateTime.Now.ToString("yyyyMMddHHmmss");
				lock (text)
				{
					Thread.Sleep(20);
				}
				string text2 = text + random.Next(100, 999).ToString() + str2;
				fileUpload_0.PostedFile.SaveAs(str + text2);
				if (shuiyin)
				{
					string text3 = str + text2;
					string text4 = str + "s_" + text2;
					string path_sypf = HttpContext.Current.Server.MapPath("~/upload/shuiyin.png");
					string path_syp = str + "sy_" + text2;
					try
					{
						ShopNum1UpLoad.MakeThumbnail(text3, text4, 450, 300, ShopNum1UpLoad.PhotoMode.HW);
						ShopNum1UpLoad.AddShuiYinPic(text4, path_syp, path_sypf);
						if (File.Exists(text3))
						{
							File.Delete(text3);
						}
						if (File.Exists(text4))
						{
							File.Delete(text4);
						}
						retstr = filepath + "sy_" + text2;
						goto IL_184;
					}
					catch (Exception ex)
					{
						if (File.Exists(text3))
						{
							File.Delete(text3);
						}
						if (File.Exists(text4))
						{
							File.Delete(text4);
						}
						retstr = ex.ToString();
						result = false;
						return result;
					}
				}
				retstr = filepath + text2;
				IL_184:
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}
		public static bool ImageUpLoad(FileUpload fileUpload_0, string filepath, out string retstr, bool shuiyin, int sytype, string syimg)
		{
			Random random = new Random();
			string fileName = fileUpload_0.PostedFile.FileName;
			string str = HttpContext.Current.Server.MapPath(filepath);
			bool result;
			if (ShopNum1UpLoad.ImageType(fileUpload_0, out retstr))
			{
				string str2 = fileName.Substring(fileName.LastIndexOf("."));
				string text = DateTime.Now.ToString("yyyyMMddHHmmss");
				lock (text)
				{
					Thread.Sleep(20);
				}
				string text2 = text + random.Next(100, 999).ToString() + str2;
				fileUpload_0.PostedFile.SaveAs(str + text2);
				if (shuiyin)
				{
					string text3 = str + text2;
					string text4 = str + "s_" + text2;
					string path_sypf = HttpContext.Current.Server.MapPath("~/upload/shuiyin.png");
					string path_syp = str + "sy_" + text2;
					try
					{
						ShopNum1UpLoad.MakeThumbnail(text3, text4, 450, 300, ShopNum1UpLoad.PhotoMode.HW);
						ShopNum1UpLoad.AddShuiYinPic(text4, path_syp, path_sypf);
						if (File.Exists(text3))
						{
							File.Delete(text3);
						}
						if (File.Exists(text4))
						{
							File.Delete(text4);
						}
						retstr = filepath + "sy_" + text2;
						goto IL_184;
					}
					catch (Exception ex)
					{
						if (File.Exists(text3))
						{
							File.Delete(text3);
						}
						if (File.Exists(text4))
						{
							File.Delete(text4);
						}
						retstr = ex.ToString();
						result = false;
						return result;
					}
				}
				retstr = filepath + text2;
				IL_184:
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}
		public static bool ImageUpLoad(FileUpload fileUpload_0, string filepath, bool sPic, int sPicwidth, int sPicheight, out string retstr)
		{
			Random random = new Random();
			string fileName = fileUpload_0.PostedFile.FileName;
			string str = HttpContext.Current.Server.MapPath(filepath);
			bool result;
			if (ShopNum1UpLoad.ImageType(fileUpload_0, out retstr))
			{
				if (fileName.LastIndexOf(".") != -1)
				{
					string str2 = fileName.Substring(fileName.LastIndexOf("."));
					string str3 = DateTime.Now.ToString("yyyyMMddHHmmss");
					string text = str3 + random.Next(100, 999).ToString() + str2;
					string originalImagePath = str + text;
					string thumbnailPath = str + "s_" + text;
					try
					{
						fileUpload_0.PostedFile.SaveAs(str + text);
						if (sPic)
						{
							ShopNum1UpLoad.MakeThumbnail(originalImagePath, thumbnailPath, sPicwidth, sPicheight, ShopNum1UpLoad.PhotoMode.HW);
						}
						retstr = filepath + text;
						result = true;
						return result;
					}
					catch (Exception ex)
					{
						retstr = ex.ToString();
						result = false;
						return result;
					}
				}
				result = false;
			}
			else
			{
				result = false;
			}
			return result;
		}
		public static bool ImageType(FileUpload fileUpload_0)
		{
			string contentType = fileUpload_0.PostedFile.ContentType;
			string fileName = fileUpload_0.PostedFile.FileName;
			int contentLength = fileUpload_0.PostedFile.ContentLength;
			bool result;
			if (fileUpload_0.HasFile)
			{
				if (fileName.LastIndexOf(".") != -1)
				{
					string a = fileName.ToLower().Substring(fileName.LastIndexOf("."));
					result = (contentLength < 1000000 && ((contentType == "image/gif" || contentType == "image/x-png" || contentType == "image/png" || contentType == "image/pjpeg" || contentType == "image/jpeg" || contentType == "image/jpg") && (a == ".gif" || a == ".jpg" || a == ".jpeg" || a == ".png")));
				}
				else
				{
					result = false;
				}
			}
			else
			{
				result = false;
			}
			return result;
		}
		public static bool ImageType(FileUpload fileUpload_0, out string retstr)
		{
			string contentType = fileUpload_0.PostedFile.ContentType;
			string fileName = fileUpload_0.PostedFile.FileName;
			int contentLength = fileUpload_0.PostedFile.ContentLength;
			bool result;
			if (fileUpload_0.HasFile)
			{
				if (fileName.LastIndexOf(".") != -1)
				{
					string a = fileName.ToLower().Substring(fileName.LastIndexOf("."));
					if (contentLength < 1048576)
					{
						if ((contentType == "image/gif" || contentType == "image/bmp" || contentType == "image/x-png" || contentType == "image/png" || contentType == "image/pjpeg" || contentType == "image/jpeg" || contentType == "image/jpg") && (a == ".gif" || a == ".jpg" || a == ".jpeg" || a == ".png"))
						{
							retstr = "文件符合条件！";
							result = true;
						}
						else
						{
							retstr = "文件格式不正确！";
							result = false;
						}
					}
					else
					{
						retstr = "文件不能大于1M！";
						result = false;
					}
				}
				else
				{
					retstr = "文件格式不正确！";
					result = false;
				}
			}
			else
			{
				retstr = "文件不存在！";
				result = false;
			}
			return result;
		}
		public static void AddShuiYinPic(string Path, string Path_syp, string Path_sypf)
		{
			System.Drawing.Image image = System.Drawing.Image.FromFile(Path);
			System.Drawing.Image image2 = System.Drawing.Image.FromFile(Path_sypf);
			Graphics graphics = Graphics.FromImage(image);
			graphics.DrawImage(image2, new Rectangle(image.Width - image2.Width, 0, image2.Width, image2.Height), 0, 0, image2.Width, image2.Height, GraphicsUnit.Pixel);
			graphics.Dispose();
			image.Save(Path_syp);
			image.Dispose();
		}
		public static void AddLeftShuiYinPic(string Path, string Path_syp, string Path_sypf)
		{
			System.Drawing.Image image = System.Drawing.Image.FromFile(Path);
			System.Drawing.Image image2 = System.Drawing.Image.FromFile(Path_sypf);
			Graphics graphics = Graphics.FromImage(image);
			graphics.DrawImage(image2, new Rectangle(0, 0, image2.Width, image2.Height), 0, 0, image2.Width, image2.Height, GraphicsUnit.Pixel);
			graphics.Dispose();
			image.Save(Path_syp);
			image.Dispose();
		}
		public static void AddShuiYinWord(string Path, string Path_sy, string addText)
		{
			System.Drawing.Image image = System.Drawing.Image.FromFile(Path);
			Graphics graphics = Graphics.FromImage(image);
			graphics.DrawImage(image, 0, 0, image.Width, image.Height);
			Font font = new Font("Verdana", 16f);
			Brush brush = new SolidBrush(Color.Blue);
			graphics.DrawString(addText, font, brush, 15f, 15f);
			graphics.Dispose();
			image.Save(Path_sy);
			image.Dispose();
		}
		public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, ShopNum1UpLoad.PhotoMode mode)
		{
			System.Drawing.Image image = System.Drawing.Image.FromFile(originalImagePath);
			int num = width;
			int num2 = height;
			int x = 0;
			int y = 0;
			int num3 = image.Width;
			int num4 = image.Height;
			switch (mode)
			{
			case ShopNum1UpLoad.PhotoMode.W:
				num2 = image.Height * width / image.Width;
				break;
			case ShopNum1UpLoad.PhotoMode.H:
				num = image.Width * height / image.Height;
				break;
			case ShopNum1UpLoad.PhotoMode.Cut:
				if ((double)image.Width / (double)image.Height > (double)num / (double)num2)
				{
					num4 = image.Height;
					num3 = image.Height * num / num2;
					y = 0;
					x = (image.Width - num3) / 2;
				}
				else
				{
					num3 = image.Width;
					num4 = image.Width * height / num;
					x = 0;
					y = (image.Height - num4) / 2;
				}
				break;
			}
			System.Drawing.Image image2 = new Bitmap(num, num2);
			Graphics graphics = Graphics.FromImage(image2);
			graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			graphics.Clear(Color.Transparent);
			graphics.DrawImage(image, new Rectangle(0, 0, num, num2), new Rectangle(x, y, num3, num4), GraphicsUnit.Pixel);
			try
			{
				image2.Save(thumbnailPath, ImageFormat.Jpeg);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				image.Dispose();
				image2.Dispose();
				graphics.Dispose();
			}
		}
	}
}
