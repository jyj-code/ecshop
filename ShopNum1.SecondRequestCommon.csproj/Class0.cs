using System;
using System.IO;
using System.Net;
using System.Text;
internal class Class0
{
	public string method_0(string string_0, string string_1)
	{
		HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string_0);
		httpWebRequest.Method = "POST";
		httpWebRequest.ContentType = "application/x-www-form-urlencoded";
		httpWebRequest.Accept = "*/*";
		httpWebRequest.Timeout = 15000;
		httpWebRequest.AllowAutoRedirect = false;
		string result = null;
		try
		{
			StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream());
			streamWriter.Write(string_1);
			streamWriter.Close();
			WebResponse response = httpWebRequest.GetResponse();
			if (response != null)
			{
				StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
				result = streamReader.ReadToEnd();
				streamReader.Close();
			}
		}
		catch (Exception)
		{
			throw;
		}
		finally
		{
		}
		return result;
	}
	public string method_1(string string_0)
	{
		HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string_0);
		httpWebRequest.Method = "GET";
		httpWebRequest.ContentType = "application/x-www-form-urlencoded";
		httpWebRequest.Accept = "*/*";
		httpWebRequest.Timeout = 15000;
		httpWebRequest.AllowAutoRedirect = false;
		string result = null;
		try
		{
			WebResponse response = httpWebRequest.GetResponse();
			if (response != null)
			{
				StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
				result = streamReader.ReadToEnd();
				streamReader.Close();
			}
		}
		catch (Exception)
		{
			throw;
		}
		finally
		{
		}
		return result;
	}
}
