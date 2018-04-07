using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.IO;
namespace ShopNum1.Common
{
	public class ShopNum1Zip
	{
		private static bool smethod_0(string string_0, ZipOutputStream zipOutputStream_0, string string_1)
		{
			bool flag = true;
			ZipEntry zipEntry = null;
			FileStream fileStream = null;
			Crc32 crc = new Crc32();
			string[] array;
			try
			{
				zipEntry = new ZipEntry(Path.Combine(string_1, Path.GetFileName(string_0) + "/"));
				zipOutputStream_0.PutNextEntry(zipEntry);
				zipOutputStream_0.Flush();
				string[] files = Directory.GetFiles(string_0);
				array = files;
				for (int i = 0; i < array.Length; i++)
				{
					string path = array[i];
					fileStream = File.OpenRead(path);
					byte[] array2 = new byte[fileStream.Length];
					fileStream.Read(array2, 0, array2.Length);
					zipEntry = new ZipEntry(Path.Combine(string_1, Path.GetFileName(string_0) + "/" + Path.GetFileName(path)));
					zipEntry.DateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
					zipEntry.Size = fileStream.Length;
					fileStream.Close();
					crc.Reset();
					crc.Update(array2);
					zipEntry.Crc = crc.Value;
					zipOutputStream_0.PutNextEntry(zipEntry);
					zipOutputStream_0.Write(array2, 0, array2.Length);
				}
			}
			catch
			{
				flag = false;
			}
			finally
			{
				if (fileStream != null)
				{
					fileStream.Close();
					fileStream = null;
				}
				if (zipEntry != null)
				{
					zipEntry = null;
				}
				GC.Collect();
				GC.Collect(1);
			}
			string[] directories = Directory.GetDirectories(string_0);
			array = directories;
			bool result;
			for (int i = 0; i < array.Length; i++)
			{
				string string_2 = array[i];
				if (!ShopNum1Zip.smethod_0(string_2, zipOutputStream_0, Path.Combine(string_1, Path.GetFileName(string_0))))
				{
					result = false;
					return result;
				}
			}
			result = flag;
			return result;
		}
		public static bool ZipFileDictory(string FolderToZip, string ZipedFile, string Password)
		{
			bool result;
			if (!Directory.Exists(FolderToZip))
			{
				result = false;
			}
			else
			{
				ZipOutputStream zipOutputStream = new ZipOutputStream(File.Create(ZipedFile));
				zipOutputStream.SetLevel(6);
				zipOutputStream.Password = Password;
				bool flag = ShopNum1Zip.smethod_0(FolderToZip, zipOutputStream, "");
				zipOutputStream.Finish();
				zipOutputStream.Close();
				result = flag;
			}
			return result;
		}
		private static bool smethod_1(string string_0, string string_1, string string_2)
		{
			if (!File.Exists(string_0))
			{
				throw new FileNotFoundException("指定要压缩的文件: " + string_0 + " 不存在!");
			}
			FileStream fileStream = null;
			ZipOutputStream zipOutputStream = null;
			ZipEntry zipEntry = null;
			bool result = true;
			try
			{
				fileStream = File.OpenRead(string_0);
				byte[] array = new byte[fileStream.Length];
				fileStream.Read(array, 0, array.Length);
				fileStream.Close();
				fileStream = File.Create(string_1);
				zipOutputStream = new ZipOutputStream(fileStream);
				zipOutputStream.Password = string_2;
				zipEntry = new ZipEntry(Path.GetFileName(string_0));
				zipOutputStream.PutNextEntry(zipEntry);
				zipOutputStream.SetLevel(6);
				zipOutputStream.Write(array, 0, array.Length);
			}
			catch
			{
				result = false;
			}
			finally
			{
				if (zipEntry != null)
				{
					zipEntry = null;
				}
				if (zipOutputStream != null)
				{
					zipOutputStream.Finish();
					zipOutputStream.Close();
				}
				if (fileStream != null)
				{
					fileStream.Close();
					fileStream = null;
				}
				GC.Collect();
				GC.Collect(1);
			}
			return result;
		}
		public static bool Zip(string FileToZip, string ZipedFile, string Password)
		{
			bool result;
			if (Directory.Exists(FileToZip))
			{
				result = ShopNum1Zip.ZipFileDictory(FileToZip, ZipedFile, Password);
			}
			else
			{
				result = (File.Exists(FileToZip) && ShopNum1Zip.smethod_1(FileToZip, ZipedFile, Password));
			}
			return result;
		}
	}
}
