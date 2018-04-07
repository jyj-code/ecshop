using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_PreTransfer_Action : IShopNum1_PreTransfer_Action
	{
		public int InsertPay(ShopNum1_PreTransfer shopNum1_PreTransfer)
		{
			string strSql = string.Format("insert into ShopNum1_PreTransfer([Guid],[OrderNumber],[OperateMoney],[Date],[Memo],[MemLoginID],[RMemberID],[YzCode],[OperateStatus],[IsDeleted],[type])\r\n            values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')", new object[]
			{
				Guid.NewGuid(),
				shopNum1_PreTransfer.OrderNumber,
				shopNum1_PreTransfer.OperateMoney,
				Convert.ToDateTime(shopNum1_PreTransfer.Date).ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"),
				shopNum1_PreTransfer.Memo,
				shopNum1_PreTransfer.MemLoginID,
				shopNum1_PreTransfer.RMemberID,
				shopNum1_PreTransfer.YzCode,
				shopNum1_PreTransfer.OperateStatus,
				shopNum1_PreTransfer.IsDeleted,
				shopNum1_PreTransfer.type
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable Search(string OrderNumber, string SendMemLoginID, string GetMemLoginID, string date1, string date2, int IsDeleted)
		{
			string text = string.Empty;
			text = "    SELECT * FROM ShopNum1_PreTransfer   WHERE  1=1    ";
			if (!string.IsNullOrEmpty(OrderNumber))
			{
				text = text + "    AND    OrderNumber  LIKE  '%" + OrderNumber + "%'   ";
			}
			if (!string.IsNullOrEmpty(SendMemLoginID))
			{
				text = text + "    AND    MemLoginID ='" + SendMemLoginID + "'   ";
			}
			if (!string.IsNullOrEmpty(GetMemLoginID))
			{
				text = text + "    AND     RMemberID ='" + GetMemLoginID + "'   ";
			}
			if (!string.IsNullOrEmpty(date1))
			{
				text = text + "    AND     Date  >'" + date1 + "'   ";
			}
			if (!string.IsNullOrEmpty(date2))
			{
				text = text + "    AND     Date  <'" + date2 + "'   ";
			}
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"    AND      IsDeleted =",
				IsDeleted,
				"   "
			});
			text += "    ORDER  BY  Date DESC   ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int Delete(string guids)
		{
			string strSql = string.Empty;
			strSql = "   DELETE   ShopNum1_PreTransfer  WHERE   Guid  IN (" + guids + ")  ";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
	}
}
