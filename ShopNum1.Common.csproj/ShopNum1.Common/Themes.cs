using System;
using System.IO;
using System.Xml;
namespace ShopNum1.Common
{
	public class Themes
	{
		public string GetValue(string fieldXmlPath, string nodeName)
		{
			XmlNodeList xmlNodeList = XmlOperator.ReadXmlReturnNodeList(fieldXmlPath, "SiteConfig");
			string result;
			foreach (XmlNode xmlNode in xmlNodeList)
			{
				foreach (XmlNode xmlNode2 in xmlNode.ChildNodes)
				{
					if (xmlNode2.Name == nodeName)
					{
						result = xmlNode2.InnerText;
						return result;
					}
				}
			}
			result = string.Empty;
			return result;
		}
		public static void DeleteFolder(string string_0)
		{
			if (Directory.Exists(string_0))
			{
				string[] fileSystemEntries = Directory.GetFileSystemEntries(string_0);
				for (int i = 0; i < fileSystemEntries.Length; i++)
				{
					string text = fileSystemEntries[i];
					if (File.Exists(text))
					{
						File.Delete(text);
					}
					else
					{
						Themes.DeleteFolder(text);
					}
				}
				Directory.Delete(string_0, true);
			}
		}
		public static void CopyFolder(string strFromPath, string strToPath, string strDirectory)
		{
			if (!Directory.Exists(strFromPath))
			{
				Directory.CreateDirectory(strFromPath);
			}
			string text = strFromPath.Substring(strFromPath.LastIndexOf("\\") + 1, strFromPath.Length - strFromPath.LastIndexOf("\\") - 1);
			if (!Directory.Exists(strToPath + "\\" + ((strDirectory == null) ? text : strDirectory)))
			{
				Directory.CreateDirectory(strToPath + "\\" + ((strDirectory == null) ? text : strDirectory));
			}
			string[] files = Directory.GetFiles(strFromPath);
			for (int i = 0; i < files.Length; i++)
			{
				string text2 = files[i].Substring(files[i].LastIndexOf("\\") + 1, files[i].Length - files[i].LastIndexOf("\\") - 1);
				File.Copy(files[i], string.Concat(new string[]
				{
					strToPath,
					"\\",
					(strDirectory == null) ? text : strDirectory,
					"\\",
					text2
				}), true);
			}
			DirectoryInfo directoryInfo = new DirectoryInfo(strFromPath);
			DirectoryInfo[] directories = directoryInfo.GetDirectories();
			for (int j = 0; j < directories.Length; j++)
			{
				string strFromPath2 = strFromPath + "\\" + directories[j].ToString();
				Themes.CopyFolder(strFromPath2, strToPath + "\\" + ((strDirectory == null) ? text : strDirectory), null);
			}
		}
	}
}
