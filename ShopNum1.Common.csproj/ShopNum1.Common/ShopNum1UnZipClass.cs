using ICSharpCode.SharpZipLib.Zip;
using System;
using System.IO;
namespace ShopNum1.Common
{
	public class ShopNum1UnZipClass
	{
		public static void UnZip(string FileToUpZip, string ZipedFolder, string Password)
		{
			if (File.Exists(FileToUpZip))
			{
				if (!Directory.Exists(ZipedFolder))
				{
					Directory.CreateDirectory(ZipedFolder);
				}
				ZipInputStream zipInputStream = null;
				ZipEntry zipEntry = null;
				try
				{
					zipInputStream = new ZipInputStream(File.OpenRead(FileToUpZip));
					zipInputStream.Password = Password;
					while ((zipEntry = zipInputStream.GetNextEntry()) != null)
					{
						if (zipEntry.Name != string.Empty)
						{
							string text = ZipedFolder + zipEntry.Name;
							if (zipEntry.Name.IndexOf("/") != -1 && !Directory.Exists(ZipedFolder + zipEntry.Name.Substring(0, zipEntry.Name.IndexOf("/"))))
							{
								Directory.CreateDirectory(ZipedFolder + zipEntry.Name.Substring(0, zipEntry.Name.IndexOf("/")));
							}
							text = text.Replace("\\", "/");
							if (text.EndsWith("/") || text.EndsWith("\\"))
							{
								Directory.CreateDirectory(text);
							}
							else
							{
								FileStream fileStream = File.Create(text);
								byte[] array = new byte[2048];
								while (true)
								{
									int num = zipInputStream.Read(array, 0, array.Length);
									if (num <= 0)
									{
										break;
									}
									fileStream.Write(array, 0, num);
								}
								if (fileStream != null)
								{
									fileStream.Close();
									fileStream.Dispose();
								}
							}
						}
					}
				}
				finally
				{
					if (zipEntry != null)
					{
						zipEntry = null;
					}
					if (zipInputStream != null)
					{
						zipInputStream.Close();
						zipInputStream.Dispose();
					}
					GC.Collect();
					GC.Collect(1);
				}
			}
		}
	}
}
