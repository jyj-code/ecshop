using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_Vedio_List_Action : IShopNum1_Vedio_List_Action
	{
		public int UpdateAudit(string guids, int isAudit)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE ShopNum1_Shop_Video SET  IsAudit\t=",
				isAudit,
				" WHERE Guid in (",
				guids,
				")"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Delete(string guids)
		{
			List<string> list = new List<string>();
			string item = string.Empty;
			item = "DELETE FROM ShopNum1_Shop_Video  WHERE [Guid] IN (" + guids + ") ";
			list.Add(item);
			int result;
			try
			{
				DatabaseExcetue.RunTransactionSql(list);
				result = 1;
			}
			catch
			{
				result = 0;
			}
			return result;
		}
		public DataTable Search(string title, string memLoginID, string commentTime1, string commentTime2, int isAudit)
		{
			string text = string.Empty;
			text = "SELECT A.Guid,A.Title,A.ImgAdd,A.VideoAdd,A.CategoryGuid,A.KeyWords,A.Content,A.CreateUser,A.CreateTime,A.ModifyUser,A.ModifyTime,A.OrderID,B.name,A.IsRecommend,A.ShopID,A.IsAudit,A.MemLoginID  FROM ShopNum1_Shop_Video AS A,ShopNum1_Shop_VideoCategory AS B  WHERE A.CategoryGuid=B.Guid ";
			if (Operator.FormatToEmpty(title) != string.Empty)
			{
				text = text + " AND A.Title LIKE '%" + Operator.FilterString(title) + "%'";
			}
			if (Operator.FormatToEmpty(memLoginID) != string.Empty)
			{
				text = text + " AND A.MemLoginID LIKE '%" + memLoginID + "%'";
			}
			if (isAudit == -2)
			{
				text += " AND A.IsAudit IN (0,2) ";
			}
			else if (isAudit == -3)
			{
				text += " AND A.IsAudit IN (1,2,3) ";
			}
			else if (isAudit == 0 || isAudit == 1 || isAudit == 2 || isAudit == 3)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND A.IsAudit=",
					isAudit,
					" "
				});
			}
			if (Operator.FormatToEmpty(commentTime1) != string.Empty)
			{
				text = text + " AND A.CreateTime>='" + Operator.FilterString(commentTime1) + "' ";
			}
			if (Operator.FormatToEmpty(commentTime2) != string.Empty)
			{
				text = text + " AND A.CreateTime<='" + Operator.FilterString(commentTime2) + "' ";
			}
			text += "Order by A.OrderID Desc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Search(string title, string memLoginID, string commentTime1, string commentTime2, int isAudit, string SubstationID)
		{
			string text = string.Empty;
			text = "SELECT A.Guid,A.Title,A.ImgAdd,A.VideoAdd,A.CategoryGuid,A.KeyWords,A.Content,A.CreateUser,A.CreateTime,A.ModifyUser,A.ModifyTime,A.OrderID,B.name,A.IsRecommend,A.ShopID,A.IsAudit,C.SubstationID,A.MemLoginID  FROM ShopNum1_Shop_Video AS A,ShopNum1_Shop_VideoCategory AS B,ShopNum1_ShopInfo AS C    WHERE A.CategoryGuid=B.Guid AND  A.MemLoginID=C.MemLoginID  ";
			if (Operator.FormatToEmpty(title) != string.Empty)
			{
				text = text + " AND A.Title LIKE '%" + Operator.FilterString(title) + "%'";
			}
			if (Operator.FormatToEmpty(memLoginID) != string.Empty)
			{
				text = text + " AND A.MemLoginID LIKE '%" + memLoginID + "%'";
			}
			if (isAudit == -2)
			{
				text += " AND A.IsAudit IN (0,2) ";
			}
			else if (isAudit == -3)
			{
				text += " AND A.IsAudit IN (1,2,3) ";
			}
			else if (isAudit == 0 || isAudit == 1 || isAudit == 2 || isAudit == 3)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND A.IsAudit=",
					isAudit,
					" "
				});
			}
			if (Operator.FormatToEmpty(commentTime1) != string.Empty)
			{
				text = text + " AND A.CreateTime>='" + Operator.FilterString(commentTime1) + "' ";
			}
			if (Operator.FormatToEmpty(commentTime2) != string.Empty)
			{
				text = text + " AND A.CreateTime<='" + Operator.FilterString(commentTime2) + "' ";
			}
			if (SubstationID != "-1")
			{
				text = text + " AND  C.SubstationID='" + SubstationID + "' ";
			}
			text += "Order by     A.CreateTime        Desc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetVedioAll(string commentTitle, string VedioName, string VedioMemLoginID, string isAudit, string createTime1, string createTime2, string memLoginID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("a.Guid,");
			stringBuilder.Append("a.Title,");
			stringBuilder.Append("b.Title as Name,");
			stringBuilder.Append("a.VideoGuid,");
			stringBuilder.Append("a.MemLoginID,");
			stringBuilder.Append("a.ShopID,");
			stringBuilder.Append("a.IsAudit,");
			stringBuilder.Append("a.CommentTime");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_Shop_VideoComment AS a,");
			stringBuilder.Append("ShopNum1_Shop_Video AS b");
			stringBuilder.Append(" WHERE a.VideoGuid=b.Guid");
			if (Operator.FormatToEmpty(commentTitle) != "-1")
			{
				stringBuilder.Append(" AND a.Title LIKE '%" + Operator.FilterString(commentTitle) + "%'");
			}
			if (Operator.FormatToEmpty(VedioName) != "-1")
			{
				stringBuilder.Append(" AND b.Title LIKE '%" + Operator.FilterString(VedioName) + "%'");
			}
			if (Operator.FormatToEmpty(VedioMemLoginID) != "-1")
			{
				stringBuilder.Append(" AND b.ShopID = '" + Operator.FilterString(VedioMemLoginID) + "'");
			}
			if (Operator.FormatToEmpty(isAudit) != "-1")
			{
				stringBuilder.Append(" AND a.IsAudit LIKE '%" + isAudit + "%'");
			}
			if (Operator.FormatToEmpty(createTime1) != "-1")
			{
				stringBuilder.Append(" AND a.CommentTime>='" + createTime1 + "' ");
			}
			if (Operator.FormatToEmpty(createTime2) != "-1")
			{
				stringBuilder.Append(" AND a.CommentTime<='" + createTime2 + "' ");
			}
			stringBuilder.Append(" ORDER BY CommentTime DESC");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable GetTitleByGuid(string guids)
		{
			string strSql = string.Empty;
			strSql = "    SELECT     Title  FROM   ShopNum1_Video   WHERE  Guid  ='" + guids + "'   ";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
	}
}
