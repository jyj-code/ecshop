using System;
using System.IO;
using System.Net;
using System.Web;
namespace ShopNum1.Second
{
	public class UrlImgOperate
	{
		private string string_0 = string.Empty;
		private string string_1 = string.Empty;
		private byte[] byte_0;
		private FileInfo fileInfo_0;
		public UrlImgOperate()
		{
		}
		public UrlImgOperate(FileInfo fileInfo)
		{
			if (fileInfo == null || !fileInfo.Exists)
			{
				throw new ArgumentException("FileInfo is null or not exists!");
			}
			this.fileInfo_0 = fileInfo;
		}
		public UrlImgOperate(string fileName, byte[] content)
		{
			if (string.IsNullOrEmpty(fileName))
			{
				throw new ArgumentNullException("fileName");
			}
			if (content == null || content.Length == 0)
			{
				throw new ArgumentNullException("content");
			}
			this.string_0 = fileName;
			this.byte_0 = content;
		}
		public UrlImgOperate(string string_2)
		{
			if (string_2 != null)
			{
				string path = "";
				string text = "";
				if (!string_2.Contains("http://"))
				{
					throw new ArgumentException("url format error!");
				}
				int num = string_2.IndexOf("http://") + 7;
				num = string_2.IndexOf("/", num) + 1;
				int num2 = string_2.LastIndexOf("/") + 1;
				path = string_2.Substring(num, num2 - num);
				text = string_2.Substring(num2);
				if (!(text == "noImage.gif"))
				{
					path = "~/ImgUpload/";
					if (!Directory.Exists(HttpContext.Current.Server.MapPath(path)))
					{
						Directory.CreateDirectory(HttpContext.Current.Server.MapPath(path));
					}
					if (!File.Exists(HttpContext.Current.Server.MapPath(path) + text))
					{
						WebClient webClient = new WebClient();
						try
						{
							if (text != "noImage.gif")
							{
								webClient.DownloadFile(string_2, HttpContext.Current.Server.MapPath(path) + text);
							}
						}
						catch
						{
							return;
						}
					}
					FileInfo fileInfo = new FileInfo(HttpContext.Current.Server.MapPath(path) + text);
					if (fileInfo == null || !fileInfo.Exists)
					{
						throw new ArgumentException("FileInfo is null or not exists!");
					}
					this.fileInfo_0 = fileInfo;
				}
			}
		}
		public string GetUrlFileName(string string_2)
		{
			string result;
			if (string_2 == null)
			{
				result = "";
			}
			else
			{
				string text = "";
				if (string_2.Contains("http://"))
				{
					int num = string_2.IndexOf("http://") + 7;
					num = string_2.IndexOf("/", num) + 1;
					int num2 = string_2.LastIndexOf("/") + 1;
					string_2.Substring(num, num2 - num);
					text = string_2.Substring(num2);
				}
				result = text;
			}
			return result;
		}
		protected string DownImage(string string_2)
		{
			string result;
			if (string_2.Contains("http://"))
			{
				int num = string_2.IndexOf("http://") + 7;
				num = string_2.IndexOf("/", num) + 1;
				int num2 = string_2.LastIndexOf("/") + 1;
				string text = string_2.Substring(num, num2 - num);
				string str = string_2.Substring(num2);
				text = "~/ImgUpload/";
				string path = HttpContext.Current.Server.MapPath(text);
				if (!Directory.Exists(path))
				{
					Directory.CreateDirectory(path);
				}
				if (!File.Exists(HttpContext.Current.Server.MapPath(text) + str))
				{
					WebClient webClient = new WebClient();
					webClient.DownloadFile(string_2, HttpContext.Current.Server.MapPath(text) + str);
				}
				result = text + str;
			}
			else
			{
				result = "";
			}
			return result;
		}
		public UrlImgOperate(string fileName, byte[] content, string mimeType) : this(fileName, content)
		{
			if (string.IsNullOrEmpty(mimeType))
			{
				throw new ArgumentNullException("mimeType");
			}
			this.string_1 = mimeType;
		}
		public string GetFileName()
		{
			if (this.string_0 != null && this.fileInfo_0 != null && this.fileInfo_0.Exists)
			{
				this.string_0 = this.fileInfo_0.FullName;
			}
			return this.string_0;
		}
		public string GetMimeType()
		{
			if (this.string_1 == null)
			{
				this.string_1 = this.GetMimeType(this.GetContent());
			}
			return this.string_1;
		}
		public byte[] GetContent()
		{
			if (this.byte_0 == null && this.fileInfo_0 != null && this.fileInfo_0.Exists)
			{
				using (Stream stream = this.fileInfo_0.OpenRead())
				{
					this.byte_0 = new byte[stream.Length];
					stream.Read(this.byte_0, 0, this.byte_0.Length);
				}
			}
			return this.byte_0;
		}
		public string GetMimeType(byte[] fileData)
		{
			string fileSuffix = this.GetFileSuffix(fileData);
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
		public string GetMimeType(string fileName)
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
		public string GetFileSuffix(byte[] fileData)
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
	}
}
