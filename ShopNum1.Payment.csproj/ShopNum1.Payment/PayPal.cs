using System;
using System.Text;
namespace ShopNum1.Payment
{
	public class PayPal
	{
		public bool CreateUrl(string gatewayurl, string business, string item_name, string item_number, decimal amount, string string_0, string string_1, string string_2, string string_3, string currency, string successful, string error, out string url1)
		{
			bool result = true;
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(gatewayurl);
				stringBuilder.Append("=" + business);
				stringBuilder.Append("&item_name=" + item_name + " Order " + item_number);
				stringBuilder.Append("&item_number=" + item_number);
				stringBuilder.Append("&amount=" + string.Format("{0:0.00}", amount));
				stringBuilder.Append("&on0=" + string_0);
				stringBuilder.Append("&os0=" + string_1);
				stringBuilder.Append("&on1=" + string_2);
				stringBuilder.Append("&lang=" + string_3);
				stringBuilder.Append("&currency=" + currency);
				stringBuilder.Append("&return=" + successful);
				stringBuilder.Append("&cancel_return=" + error);
				string text = stringBuilder.ToString();
				url1 = text;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}
	}
}
