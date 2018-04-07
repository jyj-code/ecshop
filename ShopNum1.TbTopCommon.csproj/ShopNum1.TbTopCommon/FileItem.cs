using System;
using System.IO;
using System.Net;
using System.Web;
namespace ShopNum1.TbTopCommon
{
	public class FileItem
	{
		private string string_0 = string.Empty;
		private string string_1 = string.Empty;
		private byte[] byte_0;
		private FileInfo fileInfo_0;
		public FileItem(FileInfo fileInfo)
		{
			if (fileInfo == null || !fileInfo.Exists)
			{
				throw new ArgumentException("FileInfo is null or not exists!");
			}
			this.fileInfo_0 = fileInfo;
		}
		public FileItem(string fileName, byte[] content)
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
		public FileItem()
		{
		}
		public FileItem(string string_2, string path)
		{
			if (string_2 != null)
			{
				string text = "";
				if (!string_2.Contains("http://"))
				{
					throw new ArgumentException("url format error!");
				}
				int startIndex = string_2.IndexOf("http://") + 7;
				startIndex = string_2.IndexOf("/", startIndex) + 1;
				int startIndex2 = string_2.LastIndexOf("/") + 1;
				text = string_2.Substring(startIndex2);
				if (!(text == "noImage.gif"))
				{
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
						catch (Exception)
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
		public FileItem(string string_2)
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
		public static string GetUrlFileName(string string_2)
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
		public static bool DownImage(string string_2, string path)
		{
			bool result;
			if (string_2.Contains("http://"))
			{
				int startIndex = string_2.IndexOf("http://") + 7;
				startIndex = string_2.IndexOf("/", startIndex) + 1;
				int startIndex2 = string_2.LastIndexOf("/") + 1;
				string str = string_2.Substring(startIndex2);
				if (!Directory.Exists(HttpContext.Current.Server.MapPath(path)))
				{
					Directory.CreateDirectory(HttpContext.Current.Server.MapPath(path));
				}
				if (!File.Exists(HttpContext.Current.Server.MapPath(path) + str))
				{
					WebClient webClient = new WebClient();
					webClient.DownloadFile(string_2, HttpContext.Current.Server.MapPath(path) + str);
				}
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}
		public bool DownImage(string string_2, string path, out string imgpath)
		{
			imgpath = string.Empty;
			bool result;
			if (string_2.Contains("http://"))
			{
				int startIndex = string_2.IndexOf("http://") + 7;
				startIndex = string_2.IndexOf("/", startIndex) + 1;
				int startIndex2 = string_2.LastIndexOf("/") + 1;
				string text = string_2.Substring(startIndex2);
				if (!Directory.Exists(path))
				{
					Directory.CreateDirectory(HttpContext.Current.Server.MapPath(path));
				}
				if (!File.Exists(path + "\\" + text))
				{
					WebClient webClient = new WebClient();
					webClient.DownloadFile(string_2, path + "\\" + text);
				}
				imgpath = text;
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}
		public FileItem(string fileName, byte[] content, string mimeType) : this(fileName, content)
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
				this.string_1 = Sys.GetMimeType(this.GetContent());
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
	}
}
