using System;
using System.IO;
namespace ShopNum1.Common
{
	public static class TextFile
	{
		public static void WriteFile(string filePath, string strMessage)
		{
			try
			{
				using (StreamWriter streamWriter = new StreamWriter(filePath, true))
				{
					streamWriter.WriteLine(strMessage);
					streamWriter.Flush();
					streamWriter.Close();
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public static void ReadFile(string filePath)
		{
			try
			{
				using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
				{
					using (StreamReader streamReader = new StreamReader(fileStream))
					{
						while (streamReader.Peek() >= 0)
						{
							Console.WriteLine(streamReader.ReadLine());
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
