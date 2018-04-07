using ShopNum1.DataAccess;
using ShopNum1.Interface;
using System;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_CouponType_Action : IShopNum1_CouponType_Action
	{
		public DataTable search(int int_0, int isshow)
		{
			string text = string.Empty;
			text = "SELECT * FROM ShopNum1_Shop_CouponType WHERE 1=1 ";
			if (int_0 != -1)
			{
				text = text + " and ID=" + int_0;
			}
			if (isshow != -1)
			{
				text = text + " and IsShow=" + isshow;
			}
			text += " ORDER BY OrderID";
			return DatabaseExcetue.ReturnDataTable(text);
		}
	}
}
