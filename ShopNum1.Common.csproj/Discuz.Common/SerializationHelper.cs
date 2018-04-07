using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
namespace Discuz.Common
{
	public class SerializationHelper
	{
		private static Dictionary<int, XmlSerializer> dictionary_0 = new Dictionary<int, XmlSerializer>();
		private SerializationHelper()
		{
		}
		public static XmlSerializer GetSerializer(Type type_0)
		{
			int hashCode = type_0.GetHashCode();
			if (!SerializationHelper.dictionary_0.ContainsKey(hashCode))
			{
				SerializationHelper.dictionary_0.Add(hashCode, new XmlSerializer(type_0));
			}
			return SerializationHelper.dictionary_0[hashCode];
		}
		public static object Load(Type type, string filename)
		{
			FileStream fileStream = null;
			object result;
			try
			{
				fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
				XmlSerializer xmlSerializer = new XmlSerializer(type);
				result = xmlSerializer.Deserialize(fileStream);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (fileStream != null)
				{
					fileStream.Close();
				}
			}
			return result;
		}
		public static bool Save(object object_0, string filename)
		{
			bool result = false;
			FileStream fileStream = null;
			try
			{
				fileStream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
				XmlSerializer xmlSerializer = new XmlSerializer(object_0.GetType());
				xmlSerializer.Serialize(fileStream, object_0);
				result = true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (fileStream != null)
				{
					fileStream.Close();
				}
			}
			return result;
		}
		public static string Serialize(object object_0)
		{
			string result = "";
			XmlSerializer serializer = SerializationHelper.GetSerializer(object_0.GetType());
			MemoryStream memoryStream = new MemoryStream();
			XmlTextWriter xmlTextWriter = null;
			StreamReader streamReader = null;
			try
			{
				xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
				xmlTextWriter.Formatting = Formatting.Indented;
				serializer.Serialize(xmlTextWriter, object_0);
				memoryStream.Seek(0L, SeekOrigin.Begin);
				streamReader = new StreamReader(memoryStream);
				result = streamReader.ReadToEnd();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (xmlTextWriter != null)
				{
					xmlTextWriter.Close();
				}
				if (streamReader != null)
				{
					streamReader.Close();
				}
				memoryStream.Close();
			}
			return result;
		}
		public static object DeSerialize(Type type, string string_0)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(string_0);
			object result;
			try
			{
				XmlSerializer serializer = SerializationHelper.GetSerializer(type);
				result = serializer.Deserialize(new MemoryStream(bytes));
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}
	}
}
