using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.ShopBusinessLogic
{
	public class Shop_ProductConsult_Action : IShop_ProductConsult_Action
	{
		public DataTable Search(string guid, int IsDeleted, int IsAudit, string ShopID)
		{
			string text = string.Empty;
			text = "SELECT ProductGuid,MemLoginID,SendTime,Content,Title,IPAddress,ReplyUser,ReplyTime,ReplyContent,IsReply,IsDeleted,ShopID,ConsultPeople  FROM ShopNum1_ShopProductConsult  WHERE IsDeleted = 0 AND ShopID ='" + ShopID + "'";
			if (guid != "-1")
			{
				text = text + " AND ProductGuid = '" + guid + "' ";
			}
			if (IsAudit != -1)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND IsAudit=",
					IsAudit,
					" "
				});
			}
			text += " ORDER BY SendTime  DESC ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Search(string MemLoginID, int IsDelete, string ShopID)
		{
			string text = string.Empty;
			text = string.Concat(new object[]
			{
				"SELECT A.ProductGuid,B.Guid,B.Name,A.MemLoginID,A.SendTime,A.Title,A.Content,A.IPAddress,A.ReplyUser,A.ReplyTime,A.ReplyContent,A.IsReply,A.IsDeleted,A.ConsultPeople  FROM ShopNum1_ShopProductConsult AS A,ShopNum1_Shop_Product AS B   WHERE A.ProductGuid = B.Guid AND A.ShopID ='",
				ShopID,
				"' AND A.IsDeleted =",
				IsDelete
			});
			if (Operator.FormatToEmpty(MemLoginID) != "-1")
			{
				text = text + " AND A.MemLoginID = '" + MemLoginID + "' order by A.SendTime desc ";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int Add(ShopNum1_ShopProductConsult ProductConsult)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_ShopProductConsult( \tGuid\t, \tProductGuid\t, \tTitle\t, \tContent\t, \tConsultPeople\t, \tMemLoginID\t, \tIsReply\t, \tIsAudit\t, \tSendTime\t, \tIsDeleted\t, \tShopID\t, \tIPAddress\t  ) VALUES (  '",
				ProductConsult.Guid,
				"',  '",
				ProductConsult.ProductGuid,
				"',  '",
				ProductConsult.Title,
				"',  '",
				ProductConsult.Content,
				"',  '",
				ProductConsult.ConsultPeople,
				"',  '",
				ProductConsult.MemLoginID,
				"',  ",
				ProductConsult.IsReply,
				",  ",
				ProductConsult.IsAudit,
				",  '",
				ProductConsult.SendTime,
				"',  ",
				ProductConsult.IsDeleted,
				",  '",
				ProductConsult.ShopID,
				"',  '",
				ProductConsult.IPAddress,
				"' )"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable Search(string ProductName, string IsAudit, string IsReply, string ConsultPeople, string SendTime1, string SendTime2, string ShopID)
		{
			string text = string.Empty;
			text = "SELECT A.ProductGuid,A.Guid,B.Name,B.IsPanicBuy,B.IsSpellBuy,A.MemLoginID,A.SendTime,A.Content,A.Title,A.IsAudit,A.IPAddress,A.ReplyUser,A.ReplyTime,A.ReplyContent,A.IsReply,A.ShopID,A.IsDeleted,A.ConsultPeople  FROM ShopNum1_ShopProductConsult AS A,ShopNum1_Shop_Product AS B   WHERE A.ProductGuid = B.Guid AND A.ShopID ='" + ShopID + "'  ";
			if (Operator.FormatToEmpty(ProductName) != "-1")
			{
				text = text + " AND B.Name LIKE '" + ProductName.Trim() + "%'";
			}
			if (IsAudit != "-1")
			{
				text = text + " AND A.IsAudit=" + IsAudit;
			}
			if (IsReply != "-1")
			{
				text = text + " AND A.IsReply=" + IsReply;
			}
			if (Operator.FormatToEmpty(ConsultPeople) != "-1")
			{
				text = text + " AND A.ConsultPeople like '%" + ConsultPeople + "%' ";
			}
			if (Operator.FormatToEmpty(SendTime1) != "-1")
			{
				text = text + " AND A.SendTime>='" + Operator.FilterString(SendTime1) + "' ";
			}
			if (Operator.FormatToEmpty(SendTime2) != "-1")
			{
				text = text + " AND A.SendTime<='" + Operator.FilterString(SendTime2) + "' ";
			}
			text += " order by A.sendtime desc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int DeleteByProductGuid(string ProductGuids)
		{
			string strSql = string.Empty;
			strSql = "DELETE FROM ShopNum1_ShopProductConsult WHERE ProductGuid IN (" + ProductGuids + ")";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int DeleteByGuid(string guids)
		{
			string strSql = string.Empty;
			strSql = "DELETE FROM ShopNum1_ShopProductConsult WHERE Guid IN (" + guids + ")";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Update(ShopNum1_ShopProductConsult ProductConsult)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_ShopProductConsult   SET \tReplyUser\t='",
				ProductConsult.ReplyUser,
				"',\tReplyTime\t='",
				ProductConsult.ReplyTime,
				"',\tReplyContent\t='",
				ProductConsult.ReplyContent,
				"',\tIsAudit\t=",
				ProductConsult.IsAudit,
				", \tIsReply\t=",
				ProductConsult.IsReply,
				"   WHERE Guid='",
				ProductConsult.Guid,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable SearchByGuid(string guid)
		{
			string text = string.Empty;
			text = "SELECT A.ProductGuid,A.Guid,B.Name,A.MemLoginID,A.SendTime,A.Title,A.Content,A.IPAddress,A.ReplyUser,A.ReplyTime,A.ReplyContent,A.IsReply,A.IsDeleted,A.ShopID,A.ConsultPeople  FROM ShopNum1_ShopProductConsult AS A,ShopNum1_Shop_Product AS B   WHERE A.ProductGuid = B.Guid ";
			if (Operator.FormatToEmpty(guid) != "-1")
			{
				text = text + " AND A.Guid =" + guid;
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Select_List(CommonPageModel commonModel)
		{
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@pagesize";
			array2[0] = commonModel.PageSize;
			array[1] = "@currentpage";
			array2[1] = commonModel.Currentpage;
			array[2] = "@columns";
			array2[2] = " * ";
			array[3] = "@tablename";
			array2[3] = "ShopNum1_ShopProductConsult";
			array[4] = "@condition";
			array2[4] = commonModel.Condition;
			array[5] = "@ordercolumn";
			array2[5] = "SendTime";
			array[6] = "@sortvalue";
			array2[6] = "desc";
			array[7] = "@resultnum";
			array2[7] = commonModel.Resultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
		public int MessageBoardReply(ShopNum1_ShopProductConsult ShopProductConsult)
		{
			string text = string.Empty;
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"   UPDATE   ShopNum1_ShopProductConsult  SET  ReplyTime ='",
				ShopProductConsult.ReplyTime,
				"'  ,  ReplyContent ='",
				ShopProductConsult.ReplyContent,
				"'  ,  IsReply=1     "
			});
			text = text + "   WHERE   Guid ='" + ShopProductConsult.Guid.ToString() + "'    ";
			return DatabaseExcetue.RunNonQuery(text);
		}
	}
}
