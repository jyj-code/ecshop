using ShopNum1.DataAccess;
using ShopNum1.Interface;
using System;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_SubstationReport_Action : IShopNum1_SubstationReport_Action
	{
		public DataTable GetSubstationAdSell(string StarDate, string EndDate)
		{
			string text = string.Empty;
			text += "    select SubstationID, sum(PayMoney) as SumMoney,count(SubstationID) as BuyTime,avg(PayMoney) as AvgPrice  from   ShopNum1_AdvertPay       ";
			text += "   where 1=1      ";
			if (!string.IsNullOrEmpty(StarDate))
			{
				text = text + "     and    CreateTime >'" + StarDate + "'      ";
			}
			if (!string.IsNullOrEmpty(EndDate))
			{
				text = text + "     and    CreateTime <'" + EndDate + "'      ";
			}
			text += "    group by SubstationID   order by SumMoney  desc  ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetOneSubstationAdSellMsg(string SubstationID, string StarDate, string EndDate)
		{
			string text = string.Empty;
			text += "    select AdId, sum(PayMoney) as SumMoney,count(AdId) as BuyTime,avg(PayMoney) as AvgPrice  from   ShopNum1_AdvertPay      ";
			text += "   where 1=1      ";
			if (!string.IsNullOrEmpty(StarDate))
			{
				text = text + "     and    CreateTime >'" + StarDate + "'      ";
			}
			if (!string.IsNullOrEmpty(EndDate))
			{
				text = text + "     and    CreateTime <'" + EndDate + "'      ";
			}
			text = text + "    and    SubstationID='" + SubstationID + "'       ";
			text += "    group by AdId  order by SumMoney  desc      ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetMemLoginIDSellMsg(string StarDate, string EndDate)
		{
			string text = string.Empty;
			text += "    select MemLoginID, count(MemLoginID) as BuyCount,sum(PayMoney) as BuyMoney     ";
			text += "   from ShopNum1_AdvertPay      ";
			if (!string.IsNullOrEmpty(StarDate))
			{
				text = text + "     and    CreateTime >'" + StarDate + "'      ";
			}
			if (!string.IsNullOrEmpty(EndDate))
			{
				text = text + "     and    CreateTime <'" + EndDate + "'      ";
			}
			text += "    group by MemLoginID order by BuyMoney desc    ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetAll(string SubstationID, string AdId, string IsCancel, string IsExamine)
		{
			string text = string.Empty;
			text += "  select * from  ShopNum1_AdvertPay   where 1=1   ";
			if (SubstationID != "-1")
			{
				text = text + "   and   SubstationID ='" + SubstationID + "'   ";
			}
			if (AdId != "-1")
			{
				text = text + "   and   AdId ='" + AdId + "'   ";
			}
			if (IsCancel != "-1")
			{
				text = text + "   and   IsCancel ='" + IsCancel + "'   ";
			}
			if (IsExamine != "-1")
			{
				text = text + "   and   IsExamine ='" + IsExamine + "'   ";
			}
			text += "   order  by  ModifyTime desc    ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetSubstationSumShopData()
		{
			string text = string.Empty;
			text += "      SELECT SubstationID,COUNT(SubstationID) AS SumShop  FROM  ShopNum1_ShopInfo       ";
			text += "      GROUP BY SubstationID       ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetSubstationOrder()
		{
			string text = string.Empty;
			text += "      SELECT B.SubstationID,COUNT(B.SubstationID) AS orderCount,sum(A.ShouldPayPrice) AS SellMoney   FROM ShopNum1_OrderInfo AS A LEFT JOIN ShopNum1_ShopInfo AS B ON      ";
			text += "      A.ShopID=B.MemLoginID  WHERE  A.OderStatus=3     GROUP BY B.SubstationID          ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
	}
}
