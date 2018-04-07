using System;
using System.Security.Cryptography;
using System.Text;
namespace ShopNum1.Payment
{
	public class ShengPayMent
	{
		public bool CreateUrl(PayInfo payInfo_0, out string strUrl)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string s = string.Concat(new string[]
			{
				payInfo_0.ShenPayName,
				payInfo_0.Version,
				payInfo_0.Charset,
				payInfo_0.MsgSender,
				payInfo_0.SendTime,
				payInfo_0.OrderNo,
				payInfo_0.OrderAmount,
				payInfo_0.OrderTime,
				payInfo_0.PayType,
				payInfo_0.InstCode,
				payInfo_0.PageUrl,
				payInfo_0.NotifyUrl,
				payInfo_0.PName,
				payInfo_0.BuyerContact,
				payInfo_0.BuyerIp,
				payInfo_0.Ext1,
				payInfo_0.SignType,
				payInfo_0.keyMer
			});
			MD5 mD = new MD5CryptoServiceProvider();
			byte[] signed = mD.ComputeHash(Encoding.GetEncoding("gbk").GetBytes(s));
			string text = ShengPayMent.byte2mac(signed);
			payInfo_0.SignMsg = text.ToUpper();
			stringBuilder.Append("<html><head> \r\n<script type=\"text/javascript\">window.onload = function() { form1.submit(); }</script>\r\n</head>\r\n<body>");
			stringBuilder.Append(" <form id=\"form1\" method=\"post\" action=\"http://mas.sdo.com/web-acquire-channel/cashier.htm\">");
			stringBuilder.Append(" <input name=\"Name\" type=\"hidden\" id=\"Name\" value=\"" + payInfo_0.ShenPayName + "\" />");
			stringBuilder.Append(" <input name=\"Version\" type=\"hidden\" id=\"Version\" value=\"" + payInfo_0.Version + "\" />");
			stringBuilder.Append(" <input name=\"Charset\" type=\"hidden\" id=\"Charset\" value=\"" + payInfo_0.Charset + "\" />");
			stringBuilder.Append(" <input name=\"MsgSender\" type=\"hidden\" id=\"MsgSender\" value=\"" + payInfo_0.MsgSender + "\" />");
			stringBuilder.Append(" <input name=\"SendTime\" type=\"hidden\" id=\"SendTime\" value=\"" + payInfo_0.SendTime + "\" />");
			stringBuilder.Append(" <input name=\"OrderNo\" type=\"hidden\" id=\"OrderNo\" value=\"" + payInfo_0.OrderNo + "\" />");
			stringBuilder.Append(" <input name=\"OrderAmount\" type=\"hidden\" id=\"OrderAmount\" value=\"" + payInfo_0.OrderAmount + "\" />");
			stringBuilder.Append(" <input name=\"OrderTime\" type=\"hidden\" id=\"OrderTime\" value=\"" + payInfo_0.OrderTime + "\" />");
			stringBuilder.Append("  <input name=\"PayType\" type=\"hidden\" id=\"PayType\" value=\"" + payInfo_0.PayType + "\" />");
			stringBuilder.Append("  <input name=\"payChannel\" type=\"text\" id=\"payChannel\" value=\"" + payInfo_0.PayChannel + "\"/>");
			stringBuilder.Append("  <input name=\"InstCode\" type=\"hidden\" id=\"InstCode\" value=\"" + payInfo_0.InstCode + "\" />");
			stringBuilder.Append(" <input name=\"PageUrl\" type=\"hidden\" id=\"PageUrl\" value=\"" + payInfo_0.PageUrl + "\" />");
			stringBuilder.Append(" <input name=\"NotifyUrl\" type=\"hidden\" id=\"NotifyUrl\" value=\"" + payInfo_0.NotifyUrl + "\" />");
			stringBuilder.Append(" <input name=\"ProductName\" type=\"hidden\" id=\"ProductName\" value=\"" + payInfo_0.PName + "\" />");
			stringBuilder.Append(" <input name=\"BuyerContact\" type=\"hidden\" id=\"BuyerContact\" value=\"" + payInfo_0.BuyerContact + "\" />");
			stringBuilder.Append(" <input name=\"BuyerIp\" type=\"hidden\" id=\"BuyerIp\" value=\"" + payInfo_0.BuyerIp + "\" />");
			stringBuilder.Append(" <input name=\"Ext1\" type=\"hidden\" id=\"Ext1\" value=\"" + payInfo_0.Ext1 + "\" />");
			stringBuilder.Append(" <input name=\"SignType\" type=\"hidden\" id=\"SignType\" value=\"" + payInfo_0.SignType + "\" />");
			stringBuilder.Append(" <input name=\"SignMsg\" type=\"hidden\" id=\"SignMsg\" value=\"" + payInfo_0.SignMsg + "\" />");
			stringBuilder.Append(" </form>");
			stringBuilder.Append("\r\n</body>");
			stringBuilder.Append("</html>");
			strUrl = stringBuilder.ToString();
			return true;
		}
		public static string byte2mac(byte[] signed)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < signed.Length; i++)
			{
				byte b = signed[i];
				stringBuilder.AppendFormat("{0:x2}", b);
			}
			return stringBuilder.ToString();
		}
	}
}
