using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_VedioCommentChecked_Action : IShopNum1_VedioCommentChecked_Action
	{
		public int Add(ShopNum1_Shop_Video shop_Video)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_Shop_Video( \tGuid\t, \tTitle\t, \tImgAdd\t, \tVideoAdd\t, \tCategoryGuid\t, \tKeyWords\t, \tContent\t, \tOrderID, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsRecommend\t, \tShopID\t, \tMemLoginID\t, \tIsAudit  ) VALUES (  '",
				shop_Video.Guid,
				"',  '",
				shop_Video.Title,
				"',  '",
				Operator.FilterString(shop_Video.ImgAdd),
				"',  '",
				Operator.FilterString(shop_Video.VideoAdd),
				"',  '",
				Operator.FilterString(shop_Video.CategoryGuid),
				"',  '",
				shop_Video.KeyWords,
				"',  '",
				shop_Video.Content,
				"',  ",
				shop_Video.OrderID,
				",  ",
				shop_Video.CreateUser,
				",  ",
				shop_Video.CreateTime,
				",  ",
				shop_Video.ModifyUser,
				",  ",
				shop_Video.ModifyTime,
				",  ",
				shop_Video.IsRecommend,
				",  ",
				shop_Video.ShopID,
				", )"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable Search(string Title, string memLoginID, string name, string CommentTime1, string CommentTime2, string replyTime1, string replyTime2, int isReply, int isAudit, string ipAddress, string ShopID)
		{
			string text = string.Empty;
			text = "SELECT A.Guid,A.Title,A.CommentType,A.Comment,A.CommentTime,A.Reply,A.ReplyTime,A.IsDelete,A.IPAddress,A.VideoGuid,B.Title AS Name,A.ShopID,C.ShopName,A.IsReply,A.MemLoginID,A.IsAudit  FROM ShopNum1_Shop_VideoComment AS A,ShopNum1_Shop_Video AS B,ShopNum1_ShopInfo AS C   WHERE A.VideoGuid=B.Guid AND A.ShopID=C.ShopID ";
			if (Operator.FormatToEmpty(Title) != string.Empty)
			{
				text = text + " AND A.Title LIKE '%" + Operator.FilterString(Title) + "%'";
			}
			if (Operator.FormatToEmpty(memLoginID) != string.Empty)
			{
				text = text + " AND A.MemLoginID LIKE '%" + memLoginID + "%'";
			}
			if (Operator.FormatToEmpty(name) != string.Empty)
			{
				text = text + " AND B.Title LIKE '%" + Operator.FilterString(name) + "%'";
			}
			if (isReply == 0 || isReply == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND A.IsReply=",
					isReply,
					" "
				});
			}
			if (isAudit == -2)
			{
				text += " AND A.IsAudit IN(0,2) ";
			}
			if (isAudit == 0 || isAudit == 1 || isAudit == 2)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND A.IsAudit=",
					isAudit,
					" "
				});
			}
			if (Operator.FormatToEmpty(CommentTime1) != string.Empty)
			{
				text = text + " AND A.CommentTime>='" + Operator.FilterString(CommentTime1) + "' ";
			}
			if (Operator.FormatToEmpty(CommentTime2) != string.Empty)
			{
				text = text + " AND A.CommentTime<='" + Operator.FilterString(CommentTime2) + "' ";
			}
			if (Operator.FormatToEmpty(replyTime1) != string.Empty)
			{
				text = text + " AND A.ReplyTime>='" + Operator.FilterString(replyTime1) + "'";
			}
			if (Operator.FormatToEmpty(replyTime2) != string.Empty)
			{
				text = text + " AND A.ReplyTime<='" + Operator.FilterString(replyTime2) + "' ";
			}
			if (Operator.FormatToEmpty(ipAddress) != string.Empty)
			{
				text = text + " AND A.IPAddress = '" + Operator.FilterString(ipAddress) + "'";
			}
			if (Operator.FormatToEmpty(ShopID) != string.Empty)
			{
				text = text + " AND A.ShopID = '" + ShopID.Replace(ShopSettings.GetValue("PersonShopUrl"), "") + "'";
			}
			text += "Order by A.CommentTime Desc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Search(string Title, string memLoginID, string name, string CommentTime1, string CommentTime2, string replyTime1, string replyTime2, int isReply, int isAudit, string ipAddress, string ShopID, string SubstationID)
		{
			string text = string.Empty;
			text = "SELECT A.Guid,A.Title,A.CommentType,A.Comment,A.CommentTime,A.Reply,A.ReplyTime,A.IsDelete,A.IPAddress,A.VideoGuid,B.Title AS Name,A.ShopID,C.ShopName,C.SubstationID,A.IsReply,A.MemLoginID,A.IsAudit  FROM ShopNum1_Shop_VideoComment AS A,ShopNum1_Shop_Video AS B,ShopNum1_ShopInfo AS C   WHERE A.VideoGuid=B.Guid AND A.ShopID=C.ShopID ";
			if (Operator.FormatToEmpty(Title) != string.Empty)
			{
				text = text + " AND A.Title LIKE '%" + Operator.FilterString(Title) + "%'";
			}
			if (Operator.FormatToEmpty(memLoginID) != string.Empty)
			{
				text = text + " AND A.MemLoginID LIKE '%" + memLoginID + "%'";
			}
			if (Operator.FormatToEmpty(name) != string.Empty)
			{
				text = text + " AND B.Title LIKE '%" + Operator.FilterString(name) + "%'";
			}
			if (isReply == 0 || isReply == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND A.IsReply=",
					isReply,
					" "
				});
			}
			if (isAudit == -2)
			{
				text += " AND A.IsAudit IN(0,2) ";
			}
			if (isAudit == 0 || isAudit == 1 || isAudit == 2)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND A.IsAudit=",
					isAudit,
					" "
				});
			}
			if (Operator.FormatToEmpty(CommentTime1) != string.Empty)
			{
				text = text + " AND A.CommentTime>='" + Operator.FilterString(CommentTime1) + "' ";
			}
			if (Operator.FormatToEmpty(CommentTime2) != string.Empty)
			{
				text = text + " AND A.CommentTime<='" + Operator.FilterString(CommentTime2) + "' ";
			}
			if (Operator.FormatToEmpty(replyTime1) != string.Empty)
			{
				text = text + " AND A.ReplyTime>='" + Operator.FilterString(replyTime1) + "'";
			}
			if (Operator.FormatToEmpty(replyTime2) != string.Empty)
			{
				text = text + " AND A.ReplyTime<='" + Operator.FilterString(replyTime2) + "' ";
			}
			if (Operator.FormatToEmpty(ipAddress) != string.Empty)
			{
				text = text + " AND A.IPAddress = '" + Operator.FilterString(ipAddress) + "'";
			}
			if (Operator.FormatToEmpty(ShopID) != string.Empty)
			{
				text = text + " AND A.ShopID = '" + ShopID.Replace(ShopSettings.GetValue("PersonShopUrl"), "") + "'";
			}
			if (SubstationID != "-1")
			{
				text = text + " AND   C.SubstationID = '" + Operator.FilterString(SubstationID) + "'";
			}
			text += "Order by A.CommentTime Desc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchByGuid(string guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT A.Guid,A.Title,A.CommentType,A.Comment,A.CommentTime,A.Reply,A.ReplyTime,A.IsDelete,A.IPAddress,B.Title AS Name,A.ShopID,A.IsReply,A.MemLoginID,A.IsAudit  FROM ShopNum1_Shop_VideoComment AS A,ShopNum1_Shop_Video AS B  WHERE A.VideoGuid=B.Guid  AND A.Guid=" + guid;
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int Update(ShopNum1_Shop_Video shop_Video)
		{
			return 0;
		}
		public int UpdateAudit(string guids, int isAudit)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("UPDATE ");
			stringBuilder.Append("ShopNum1_Shop_VideoComment");
			stringBuilder.Append(" SET ");
			stringBuilder.Append("isAudit = " + isAudit);
			stringBuilder.Append(" WHERE ");
			stringBuilder.Append("[Guid] in(" + guids + ")");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public int Delete(string guids)
		{
			List<string> list = new List<string>();
			string item = string.Empty;
			item = "DELETE FROM ShopNum1_Shop_VideoComment  WHERE [Guid] IN (" + guids + ") ";
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
		public DataTable Search(string memLoginID, int isDeleted)
		{
			return null;
		}
		public DataTable Search(string articleGuid, int isReply, int isAudit, int count)
		{
			return null;
		}
		public DataTable MemberShopVideoComment(string memloginid)
		{
			return null;
		}
		public int DeleteShopVideoComment(string guid)
		{
			return 0;
		}
		public DataTable GetShopVideoByGuid(string guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT A.CreateTime,A.Title,A.ImgAdd,A.VideoAdd,A.KeyWords,A.MemLoginID,B.Name,A.isAudit FROM ShopNum1_Shop_Video AS A,ShopNum1_Shop_VideoCategory AS B WHERE A.CategoryGuid=B.Guid AND A.Guid=" + guid;
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetMemLoginIDByGuid(string guid)
		{
			string strSql = string.Empty;
			strSql = "select MemLoginID,isAudit from ShopNum1_Shop_VideoComment where guid in (" + guid + ")";
			return DatabaseExcetue.ReturnDataTable(strSql);
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
			array2[2] = " *  ";
			array[3] = "@tablename";
			array2[3] = "ShopNum1_VideoComment";
			array[4] = "@condition";
			array2[4] = commonModel.Condition;
			array[5] = "@ordercolumn";
			array2[5] = "CreateTime";
			array[6] = "@sortvalue";
			array2[6] = "desc";
			array[7] = "@resultnum";
			array2[7] = commonModel.Resultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
		public int DeleteVideoComment(string guids)
		{
			string strSql = string.Empty;
			strSql = "DELETE FROM ShopNum1_VideoComment  WHERE [Guid] IN (" + guids + ") ";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetVideoCommentDetailByGuid(string guid)
		{
			string text = string.Empty;
			text += "   SELECT A.*,B.Title  AS  VideoTitle   FROM ShopNum1_VideoComment AS A LEFT JOIN ShopNum1_Video AS B     ";
			text += "   ON A.VideoGuid=B.Guid    ";
			text = text + "   WHERE A.Guid='" + guid + "'     ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
	}
}
