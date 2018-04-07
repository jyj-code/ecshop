using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
namespace tenpay
{
	public class TenpayDual_TenpayHttpClient
	{
		private string string_0;
		private string string_1;
		private string string_2;
		private string string_3;
		private string string_4;
		private string string_5;
		private string string_6;
		private int int_0;
		private int int_1;
		private string string_7;
		public TenpayDual_TenpayHttpClient()
		{
			this.string_6 = "";
			this.string_4 = "";
			this.string_5 = "";
			this.string_0 = "";
			this.string_1 = "";
			this.string_2 = "POST";
			this.string_3 = "";
			this.int_0 = 60;
			this.int_1 = 0;
			this.string_7 = "gb2312";
		}
		public void setReqContent(string reqContent)
		{
			this.string_0 = reqContent;
		}
		public string getResContent()
		{
			return this.string_1;
		}
		public void setMethod(string method)
		{
			this.string_2 = method;
		}
		public string getErrInfo()
		{
			return this.string_3;
		}
		public void setCertInfo(string certFile, string certPasswd)
		{
			this.string_4 = certFile;
			this.string_5 = certPasswd;
		}
		public void setCaInfo(string caFile)
		{
			this.string_6 = caFile;
		}
		public void setTimeOut(int timeOut)
		{
			this.int_0 = timeOut;
		}
		public int getResponseCode()
		{
			return this.int_1;
		}
		public void setCharset(string charset)
		{
			this.string_7 = charset;
		}
		public bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
		{
			return true;
		}
		public bool call()
		{
			HttpWebResponse httpWebResponse = null;
			bool result;
			try
			{
				string text = null;
				HttpWebRequest httpWebRequest;
				if (this.string_2.ToUpper() == "POST")
				{
					string[] array = Regex.Split(this.string_0, "\\?");
					httpWebRequest = (HttpWebRequest)WebRequest.Create(array[0]);
					if (array.Length >= 2)
					{
						text = array[1];
					}
				}
				else
				{
					httpWebRequest = (HttpWebRequest)WebRequest.Create(this.string_0);
				}
				ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(this.CheckValidationResult);
				if (this.string_4 != "")
				{
					httpWebRequest.ClientCertificates.Add(new X509Certificate2(this.string_4, this.string_5));
				}
				httpWebRequest.Timeout = this.int_0 * 1000;
				Encoding encoding = Encoding.GetEncoding(this.string_7);
				if (text != null)
				{
					byte[] bytes = encoding.GetBytes(text);
					httpWebRequest.Method = "POST";
					httpWebRequest.ContentType = "application/x-www-form-urlencoded";
					httpWebRequest.ContentLength = (long)bytes.Length;
					Stream requestStream = httpWebRequest.GetRequestStream();
					requestStream.Write(bytes, 0, bytes.Length);
					requestStream.Close();
				}
				httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), encoding);
				this.string_1 = streamReader.ReadToEnd();
				streamReader.Close();
				httpWebResponse.Close();
			}
			catch (Exception ex)
			{
				this.string_3 += ex.Message;
				if (httpWebResponse != null)
				{
					this.int_1 = Convert.ToInt32(httpWebResponse.StatusCode);
				}
				result = false;
				return result;
			}
			this.int_1 = Convert.ToInt32(httpWebResponse.StatusCode);
			result = true;
			return result;
		}
	}
}
