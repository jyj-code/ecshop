using System;
namespace ShopNum1.Payment
{
	public class Allbuy
	{
		public bool Createurl(string merchant, string BillNo, string amount, string Date, string Remark, string BackUrl, out string string_0)
		{
			bool result = true;
			try
			{
				string_0 = "http://www.allbuy.cn/newpayment/iepayment2.asp" + this.method_0(merchant, BillNo, amount, Date, Remark, BackUrl);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}
		private string method_0(string string_0, string string_1, string string_2, string string_3, string string_4, string string_5)
		{
			string result = "";
			try
			{
				result = string.Concat(new string[]
				{
					"?merchant=",
					string_0,
					"&BillNo=",
					string_1,
					"&amount=",
					string_2,
					"&Date=",
					string_3,
					"&Remark=",
					string_4,
					"&BackUrl=",
					string_5
				});
			}
			catch (Exception ex)
			{
				result = "创建URL时出错,错误信息:" + ex.Message;
			}
			return result;
		}
	}
}
