using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using System;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_Consult_Action : IShopNum1_Consult_Action
	{
		public int Add()
		{
			return 0;
		}
		public DataTable Search(string guid, int IsDeleted, int IsReply)
		{
			string text = string.Empty;
			text = "SELECT ProductGuid,MemLoginID,SendTime,Content,IPAddress,ReplyUser,ReplyTime,ReplyContent,IsReply,IsDeleted,ConsultPeople  FROM ShopNum1_ProductConsult  WHERE IsDeleted = 0";
			if (Operator.FormatToEmpty(guid) != "0")
			{
				text = text + " AND ProductGuid = '" + guid + "' ";
			}
			if (IsReply == 0 || IsReply == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND IsReply=",
					IsReply,
					" "
				});
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Search(string MemLoginID, int IsDelete)
		{
			string text = string.Empty;
			text = "SELECT A.ProductGuid,B.Guid,B.Name,A.MemLoginID,A.SendTime,A.Content,A.IPAddress,A.ReplyUser,A.ReplyTime,A.ReplyContent,A.IsReply,A.IsDeleted,A.ConsultPeople  FROM ShopNum1_ProductConsult AS A,ShopNum1_Product AS B   WHERE A.ProductGuid = B.Guid AND A.IsDeleted =" + IsDelete;
			if (Operator.FormatToEmpty(MemLoginID) != "0")
			{
				text = text + " AND A.MemLoginID = '" + MemLoginID + "' ";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Search(string ProductName, int IsReply, string ConsultPeople, string SendTime1, string SendTime2)
		{
			string text = string.Empty;
			text = "SELECT A.ProductGuid,A.Guid,B.Name,A.MemLoginID,A.SendTime,A.Content,A.IPAddress,A.ReplyUser,A.ReplyTime,A.ReplyContent,A.IsReply,A.IsDeleted,A.ConsultPeople  FROM ShopNum1_ProductConsult AS A,ShopNum1_Product AS B   WHERE A.ProductGuid = B.Guid ";
			if (!string.IsNullOrEmpty(ProductName))
			{
				text = text + " AND B.Name = '" + ProductName + "'";
			}
			if (IsReply == 0 || IsReply == 1)
			{
				text = text + " AND IsReply=" + IsReply;
			}
			if (Operator.FormatToEmpty(ConsultPeople) != string.Empty)
			{
				text = text + " AND A.ConsultPeople like '%" + ConsultPeople + "%' ";
			}
			if (!string.IsNullOrEmpty(SendTime1))
			{
				text = text + " AND A.SendTime>='" + Operator.FilterString(SendTime1) + "' ";
			}
			if (Operator.FormatToEmpty(SendTime2) != string.Empty)
			{
				text = text + " AND A.SendTime<='" + Operator.FilterString(SendTime2) + "' ";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int Delete(string guids)
		{
			string strSql = string.Empty;
			strSql = "DELETE FROM ShopNum1_ProductConsult WHERE ProductGuid IN (" + guids + ")";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable SearchByGuid(string guid)
		{
			string text = string.Empty;
			text = "SELECT A.ProductGuid,B.Guid,B.Name,A.MemLoginID,A.SendTime,A.Content,A.IPAddress,A.ReplyUser,A.ReplyTime,A.ReplyContent,A.IsReply,A.IsDeleted,A.ConsultPeople  FROM ShopNum1_ProductConsult AS A,ShopNum1_Product AS B   WHERE A.ProductGuid = B.Guid ";
			if (!string.IsNullOrEmpty(guid))
			{
				text = text + " AND A.ProductGuid = " + guid;
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchByConsultGuid(string guid)
		{
			string text = string.Empty;
			text = "SELECT A.ProductGuid,B.Guid,B.Name,A.MemLoginID,A.SendTime,A.Content,A.IPAddress,A.ReplyUser,A.ReplyTime,A.ReplyContent,A.IsReply,A.IsDeleted,A.ConsultPeople  FROM ShopNum1_ProductConsult AS A,ShopNum1_Product AS B   WHERE A.ProductGuid = B.Guid ";
			if (!string.IsNullOrEmpty(guid))
			{
				text = text + " AND A.Guid = " + guid;
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
	}
}
