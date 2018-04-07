using ShopNum1.Common;
using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
namespace ShopNum1.Payment
{
	public class TLPayReq
	{
		[CompilerGenerated]
		private TLPay tlpay_0;
		public string pickupUrl
		{
			get
			{
				return "http://" + ShopSettings.siteDomain + "/PayReturn/TLPay/Tl_Recive.aspx";
			}
		}
		public string receiveUrl
		{
			get
			{
				return "http://" + ShopSettings.siteDomain + "/PayReturn/TLPay/Tl_Recive.aspx";
			}
		}
		public string requestUrl
		{
			get
			{
				return ConfigurationManager.AppSettings["TLPayUrl"];
			}
		}
		public TLPay TLPay_0
		{
			get;
			set;
		}
		public TLPayReq()
		{
		}
		public TLPayReq(TLPay tlpay_1)
		{
			this.TLPay_0 = tlpay_1;
		}
		public string GetParastring()
		{
			StringBuilder parastrBuilder = this.GetParastrBuilder();
			parastrBuilder.Append("signMsg=" + this.GetSignString());
			return parastrBuilder.ToString();
		}
		public StringBuilder GetParastrBuilder()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("inputCharset=" + this.TLPay_0.inputCharset + "&");
			stringBuilder.Append("pickupUrl=" + this.pickupUrl + "&");
			stringBuilder.Append("version=" + this.TLPay_0.version + "&");
			stringBuilder.Append("signType=" + this.TLPay_0.signType + "&");
			stringBuilder.Append("merchantId=" + this.TLPay_0.merchantId + "&");
			stringBuilder.Append("orderNo=" + this.TLPay_0.orderNo + "&");
			stringBuilder.Append("orderAmount=" + this.TLPay_0.orderAmount + "&");
			stringBuilder.Append("orderCurrency=" + this.TLPay_0.orderCurrency + "&");
			stringBuilder.Append("orderDatetime=" + this.TLPay_0.orderDatetime + "&");
			stringBuilder.Append("ext1=" + this.TLPay_0.String_2 + "&");
			stringBuilder.Append("payType=" + this.TLPay_0.payType + "&");
			if (!string.IsNullOrEmpty(this.TLPay_0.issuerId))
			{
				stringBuilder.Append("issuerId=" + this.TLPay_0.issuerId + "&");
			}
			return stringBuilder;
		}
		public string GetSignString()
		{
			StringBuilder parastrBuilder = this.GetParastrBuilder();
			parastrBuilder.Append("key=" + this.TLPay_0.String_2);
			string text = parastrBuilder.ToString();
			MD5 mD = new MD5CryptoServiceProvider();
			byte[] bytes = mD.ComputeHash(Encoding.Default.GetBytes(text), 0, text.Length);
			return this.byteToHexStr(bytes);
		}
		public string byteToHexStr(byte[] bytes)
		{
			string text = "";
			if (bytes != null)
			{
				for (int i = 0; i < bytes.Length; i++)
				{
					text += bytes[i].ToString("X2");
				}
			}
			return text;
		}
		public void SendRequest()
		{
			HttpWebRequest httpWebRequest = WebRequest.Create(this.requestUrl) as HttpWebRequest;
			httpWebRequest.Method = "Post";
			httpWebRequest.ContentType = "application/x-www-form-urlencoded";
			Stream requestStream = httpWebRequest.GetRequestStream();
			using (requestStream)
			{
				byte[] bytes = Encoding.Default.GetBytes(this.GetParastring());
				requestStream.Write(bytes, 0, bytes.Length);
			}
			HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
			Stream responseStream = httpWebResponse.GetResponseStream();
			using (responseStream)
			{
				byte[] array = new byte[10240];
				responseStream.Read(array, 0, 10240);
				array.ToString();
			}
		}
	}
}
