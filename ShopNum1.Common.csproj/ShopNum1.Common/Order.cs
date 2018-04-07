using System;
namespace ShopNum1.Common
{
	public class Order
	{
		public string CreateOrderNumber()
		{
			string text = DateTime.Today.Year.ToString();
			string text2 = DateTime.Today.Month.ToString();
			if (text2.Length == 1)
			{
				text2 = "0" + text2;
			}
			string text3 = DateTime.Today.Day.ToString();
			if (text3.Length == 1)
			{
				text3 = "0" + text3;
			}
			string text4 = DateTime.Now.Minute.ToString();
			if (text4.Length == 1)
			{
				text4 = "0" + text4;
			}
			string text5 = DateTime.Now.Second.ToString();
			if (text5.Length == 1)
			{
				text5 = "0" + text5;
			}
			string text6 = DateTime.Now.Millisecond.ToString();
			if (text6.Length == 1)
			{
				text6 = "00" + text6;
			}
			else if (text6.Length == 2)
			{
				text6 = "0" + text6;
			}
			return string.Concat(new string[]
			{
				text,
				text2,
				text3,
				text4,
				text5,
				text6
			});
		}
	}
}
