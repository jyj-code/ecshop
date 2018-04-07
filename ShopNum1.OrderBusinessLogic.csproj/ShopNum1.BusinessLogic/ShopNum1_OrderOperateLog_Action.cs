using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_OrderOperateLog_Action : IShopNum1_OrderOperateLog_Action
	{
		public DataTable Search(string orderInfoGuid)
		{
			string text = string.Empty;
			text = "SELECT Guid,OrderInfoGuid,CreateUser,OderStatus,ShipmentStatus,PaymentStatus,Memo,OperateDateTime,IsDeleted  FROM ShopNum1_OrderOperateLog  WHERE 0=0 ";
			if (orderInfoGuid != "-1")
			{
				text = string.Concat(new object[]
				{
					text,
					" AND OrderInfoGuid='",
					new Guid(orderInfoGuid),
					"'"
				});
			}
			text += "ORDER BY OperateDateTime DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int Add(ShopNum1_OrderOperateLog orderOperateLog)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_OrderOperateLog( Guid,OrderInfoGuid,CreateUser,OderStatus,ShipmentStatus,PaymentStatus,CurrentStateMsg,NextStateMsg,Memo,OperateDateTime,IsDeleted ) VALUES ( '",
				orderOperateLog.Guid,
				"','",
				orderOperateLog.OrderInfoGuid,
				"','",
				orderOperateLog.CreateUser,
				"',",
				orderOperateLog.OderStatus,
				",",
				orderOperateLog.ShipmentStatus,
				",",
				orderOperateLog.PaymentStatus,
				",'",
				Operator.FilterString(orderOperateLog.CurrentStateMsg),
				"','",
				Operator.FilterString(orderOperateLog.NextStateMsg),
				"','",
				Operator.FilterString(orderOperateLog.Memo),
				"','",
				orderOperateLog.OperateDateTime,
				"',",
				orderOperateLog.IsDeleted,
				")"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
	}
}
