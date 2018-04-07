using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
namespace ShopNum1.WebControl
{
	public class ShopNum1_KuaiDiRequest
	{
		private string string_0 = "http://www.kuaidi100.com/applyurl?key={0}&com={1}&nu={2}";
		private string string_1 = "http://api.kuaidi100.com/api?id={0}&com={1}&nu={2}&valicode=[]&show=3&muti=1&order=asc";
		private string string_2 = "";
		private string string_3 = "2";
		private string string_4 = "desc";
		private string string_5 = "1";
		public string apikey
		{
			get
			{
				if (this.string_2 == "")
				{
					this.string_2 = ConfigurationManager.AppSettings["KuaiDiApiKey"].ToString();
				}
				return this.string_2;
			}
			set
			{
				this.string_2 = value;
			}
		}
		public string showtype
		{
			get
			{
				return this.string_3;
			}
			set
			{
				this.string_3 = value;
			}
		}
		public string order
		{
			get
			{
				return this.string_4;
			}
			set
			{
				this.string_4 = value;
			}
		}
		public string muti
		{
			get
			{
				return this.string_5;
			}
			set
			{
				this.string_5 = value;
			}
		}
		public string GetKuaidiInfo(string kuaicom, string kuainum, string vlicode)
		{
			string requestUriString = string.Empty;
			if (kuaicom == "shunfeng")
			{
				requestUriString = string.Format(this.string_0, this.apikey, kuaicom, kuainum);
			}
			else
			{
				requestUriString = string.Format(this.string_1, this.apikey, kuaicom, kuainum);
			}
			WebRequest webRequest = WebRequest.Create(requestUriString);
			WebResponse response = webRequest.GetResponse();
			Stream responseStream = response.GetResponseStream();
			Encoding uTF = Encoding.UTF8;
			StreamReader streamReader = new StreamReader(responseStream, uTF);
			return streamReader.ReadToEnd();
		}
		private string method_0(string string_6)
		{
			WebRequest webRequest = WebRequest.Create(string_6);
			WebResponse response = webRequest.GetResponse();
			Stream responseStream = response.GetResponseStream();
			Encoding uTF = Encoding.UTF8;
			StreamReader streamReader = new StreamReader(responseStream, uTF);
			return streamReader.ReadToEnd();
		}
		public string GetKuaidiInfo(string kuaicom, string kuainum, string vlicode, string kuaidishow, string kuaidimuti, string kuaidiorder)
		{
			if (kuaidishow == "")
			{
				kuaidishow = this.showtype;
			}
			if (kuaidimuti == "")
			{
				kuaidimuti = this.muti;
			}
			if (kuaidiorder == "")
			{
				kuaidiorder = this.order;
			}
			string requestUriString = string.Format(this.string_1, new object[]
			{
				this.apikey,
				kuaicom,
				kuainum,
				kuaidishow,
				kuaidimuti,
				kuaidiorder
			});
			WebRequest webRequest = WebRequest.Create(requestUriString);
			WebResponse response = webRequest.GetResponse();
			Stream responseStream = response.GetResponseStream();
			Encoding uTF = Encoding.UTF8;
			StreamReader streamReader = new StreamReader(responseStream, uTF);
			return streamReader.ReadToEnd();
		}
	}
}
