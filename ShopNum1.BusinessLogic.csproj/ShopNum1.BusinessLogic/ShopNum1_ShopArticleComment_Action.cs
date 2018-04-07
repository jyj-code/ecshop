using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_ShopArticleComment_Action : IShopNum1_ShopArticleComment_Action
	{
		public int Add(ShopNum1_ArticleComment articleComment)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_ArticleComment( \tGuid\t, \tArticleGuid\t, \tMemLoginID\t, \tTitle\t, \tContent\t, \tSendTime\t, \tIPAddress\t, \tRank, \tIsReply\t, \tIsAudit\t, \tIsDeleted  ) VALUES (  '",
				articleComment.Guid,
				"',  '",
				articleComment.ArticleGuid,
				"',  '",
				Operator.FilterString(articleComment.MemLoginID),
				"',  '",
				Operator.FilterString(articleComment.Title),
				"',  '",
				Operator.FilterString(articleComment.Content),
				"',  '",
				articleComment.SendTime,
				"',  '",
				articleComment.IPAddress,
				"',  ",
				articleComment.Rank,
				",  ",
				articleComment.IsReply,
				",  ",
				articleComment.IsAudit,
				",  ",
				articleComment.IsDeleted,
				")"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable Search(string title, string memLoginID, string name, string commentTime1, string commentTime2, string replyTime1, string replyTime2, int isReply, int isAudit, string iPAddress, string shopID)
		{
			string text = string.Empty;
			text = "SELECT A.Guid,A.Title,B.Title AS Name,A.Rank,A.Content,A.CommentTime,A.ReplyContent,A.ReplyTime,A.IsDeleted,A.MemLoginID,A.ArticleGuid,A.ShopID,C.ShopName,A.IsAudit,A.IPAddress,A.IsReply  FROM ShopNum1_Shop_NewsComment AS A,ShopNum1_Shop_News AS B ,ShopNum1_ShopInfo AS C    WHERE A.ArticleGuid = B.Guid AND A.ShopID=C.ShopID ";
			if (Operator.FormatToEmpty(title) != string.Empty)
			{
				text = text + " AND A.Title LIKE '%" + Operator.FilterString(title) + "%'";
			}
			if (Operator.FormatToEmpty(memLoginID) != string.Empty)
			{
				text = text + " AND A.MemLoginID LIKE '%" + Operator.FilterString(memLoginID) + "%'";
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
				text += " AND A.IsAudit IN (0,2) ";
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
			if (Operator.FormatToEmpty(commentTime1) != string.Empty)
			{
				text = text + " AND A.CommentTime>='" + Operator.FilterString(commentTime1) + "' ";
			}
			if (Operator.FormatToEmpty(commentTime2) != string.Empty)
			{
				text = text + " AND A.CommentTime<='" + Operator.FilterString(commentTime2) + "' ";
			}
			if (Operator.FormatToEmpty(replyTime1) != string.Empty)
			{
				text = text + " AND A.ReplyTime>='" + Operator.FilterString(replyTime1) + "'";
			}
			if (Operator.FormatToEmpty(replyTime2) != string.Empty)
			{
				text = text + " AND A.ReplyTime<='" + Operator.FilterString(replyTime2) + "' ";
			}
			if (Operator.FormatToEmpty(iPAddress) != string.Empty)
			{
				text = text + " AND A.IPAddress = '" + Operator.FilterString(iPAddress) + "'";
			}
			if (Operator.FormatToEmpty(shopID) != string.Empty)
			{
				text = text + " AND A.ShopID = '" + Operator.FilterString(shopID.Replace(ShopSettings.GetValue("PersonShopUrl"), "")) + "'";
			}
			text += "Order by A.CommentTime Desc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Search(string title, string memLoginID, string name, string commentTime1, string commentTime2, string replyTime1, string replyTime2, int isReply, int isAudit, string iPAddress, string shopID, string SubstationID)
		{
			string text = string.Empty;
			text = "SELECT A.Guid,A.Title,B.Title AS Name,A.Rank,A.Content,A.CommentTime,A.ReplyContent,A.ReplyTime,A.IsDeleted,A.MemLoginID,A.ArticleGuid,A.ShopID,C.ShopName,A.IsAudit,A.IPAddress,C.SubstationID,A.IsReply  FROM ShopNum1_Shop_NewsComment AS A,ShopNum1_Shop_News AS B ,ShopNum1_ShopInfo AS C    WHERE A.ArticleGuid = B.Guid AND A.ShopID=C.ShopID ";
			if (Operator.FormatToEmpty(title) != string.Empty)
			{
				text = text + " AND A.Title LIKE '%" + Operator.FilterString(title) + "%'";
			}
			if (Operator.FormatToEmpty(memLoginID) != string.Empty)
			{
				text = text + " AND A.MemLoginID LIKE '%" + Operator.FilterString(memLoginID) + "%'";
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
				text += " AND A.IsAudit IN (0,2) ";
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
			if (Operator.FormatToEmpty(commentTime1) != string.Empty)
			{
				text = text + " AND A.CommentTime>='" + Operator.FilterString(commentTime1) + "' ";
			}
			if (Operator.FormatToEmpty(commentTime2) != string.Empty)
			{
				text = text + " AND A.CommentTime<='" + Operator.FilterString(commentTime2) + "' ";
			}
			if (Operator.FormatToEmpty(replyTime1) != string.Empty)
			{
				text = text + " AND A.ReplyTime>='" + Operator.FilterString(replyTime1) + "'";
			}
			if (Operator.FormatToEmpty(replyTime2) != string.Empty)
			{
				text = text + " AND A.ReplyTime<='" + Operator.FilterString(replyTime2) + "' ";
			}
			if (Operator.FormatToEmpty(iPAddress) != string.Empty)
			{
				text = text + " AND A.IPAddress = '" + Operator.FilterString(iPAddress) + "'";
			}
			if (Operator.FormatToEmpty(shopID) != string.Empty)
			{
				text = text + " AND A.ShopID = '" + Operator.FilterString(shopID.Replace(ShopSettings.GetValue("PersonShopUrl"), "")) + "'";
			}
			if (SubstationID != "-1")
			{
				text = text + " AND  C.SubstationID= '" + Operator.FilterString(SubstationID) + "'";
			}
			text += "Order by A.CommentTime Desc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchByGuid(string guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT A.Guid,A.ArticleGuid,B.Title As ArticleTitle,B.MemLoginID AS ArticleMemLoginID,A.MemLoginID,A.Title,A.Rank,A.CommentTime,A.Content,A.IPAddress,A.ReplyUser,A.ReplyTime,A.ReplyContent,A.IsAudit,A.IsReply,A.ShopID  FROM ShopNum1_Shop_NewsComment AS A,ShopNum1_Shop_News AS B  WHERE A.ArticleGuid = B.Guid  AND A.Guid=" + guid;
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int Update(ShopNum1_ArticleComment articleComment)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE ShopNum1_Shop_NewsComment SET   ReplyUser\t='",
				articleComment.ReplyUser,
				"', \tReplyTime\t='",
				articleComment.ReplyTime,
				"',\tReplyContent\t='",
				articleComment.ReplyContent,
				"',\tIsReply\t=",
				articleComment.IsReply,
				"  WHERE Guid='",
				articleComment.Guid,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int UpdateAudit(string guids, int isAudit)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE ShopNum1_Shop_NewsComment SET  IsAudit\t=",
				isAudit,
				" WHERE Guid in ('",
				guids,
				"')"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int UpdateAuditNew(string guids, int isAudit)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE ShopNum1_Shop_NewsComment SET  IsAudit\t=",
				isAudit,
				" WHERE Guid in (",
				guids,
				")"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Delete(string guids)
		{
			string strSql = string.Empty;
			strSql = "DELETE FROM ShopNum1_Shop_NewsComment WHERE Guid IN (" + guids + ")";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable Search(string memLoginID, int isDeleted)
		{
			string text = string.Empty;
			text = "SELECT A.Guid,A.ArticleGuid,B.Title As ArticleTitle,A.MemLoginID,A.Title,A.Rank,A.SendTime,A.Content,A.IPAddress,A.ReplyUser,A.ReplyTime,A.ReplyContent,A.IsAudit,A.IsReply,A.IsDeleted  FROM ShopNum1_Shop_NewsComment AS A,ShopNum1_Article AS B    WHERE A.ArticleGuid = B.Guid ";
			if (Operator.FormatToEmpty(memLoginID) != string.Empty)
			{
				text = text + " AND A.MemLoginID LIKE '%" + Operator.FilterString(memLoginID) + "%'";
			}
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND A.IsDeleted=",
					isDeleted,
					" "
				});
			}
			text += "Order by A.SendTime Desc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Search(string articleGuid, int isReply, int isAudit, int count)
		{
			string text = string.Empty;
			if (count > 0)
			{
				text = "SELECT top " + count;
			}
			else
			{
				text = "SELECT ";
			}
			text += "\tGuid\t, \tMemLoginID\t, \tArticleGuid\t, \tTitle\t, \tContent\t, \tSendTime\t, \tReplyUser\t, \tReplyTime\t, \tReplyContent\t, \tIPAddress\t, \tRank\t, \tIsReply\t, \tIsAudit\t, \tIsDeleted   FROM  ShopNum1_Shop_NewsComment  WHERE IsDeleted = 1";
			if (articleGuid != "-1")
			{
				text = text + " AND ArticleGuid='" + articleGuid + "' ";
			}
			if (isReply == 0 || isReply == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND IsReply=",
					isReply,
					" "
				});
			}
			if (isAudit == 0 || isAudit == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND IsAudit=",
					isAudit,
					" "
				});
			}
			text += "ORDER BY SendTime DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetMemloginIDByGuid(string guid)
		{
			string strSql = "select MemLoginID,IsAudit from ShopNum1_Shop_NewsComment where guid in (" + guid + ")";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable MemberShopArticleComment(string memloginid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@memloginid";
			array2[0] = memloginid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_MemberShopArticleComment", array, array2);
		}
		public int DeleteShopArticleComment(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedure("Pro_ShopNum1_DeleteShopArticleComment", array, array2);
		}
		public DataTable SearchShopArticleComment(string memberloginid, string commenttitle, string articletitle, string articlememloginid, string isaudit, string createtime1, string createtime2)
		{
			string[] array = new string[7];
			string[] array2 = new string[7];
			array[0] = "@memberloginid";
			array2[0] = memberloginid;
			array[1] = "@commenttitle";
			array2[1] = commenttitle;
			array[2] = "@articletitle";
			array2[2] = articletitle;
			array[3] = "@articlememloginid";
			array2[3] = articlememloginid;
			array[4] = "@isaudit";
			array2[4] = isaudit;
			array[5] = "@createtime1";
			array2[5] = createtime1;
			array[6] = "@createtime2";
			array2[6] = createtime2;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchShopArticleComment", array, array2);
		}
		public int Shop_NewsCommentAdd(ShopNum1_Shop_NewsComment Shop_NewsComment)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_Shop_NewsComment( \tGuid\t, \tArticleGuid\t, \tMemLoginID\t, \tTitle\t, \tContent\t, \tCommentTime\t, \tIPAddress\t, \tRank, \tShopID, \tCommentType, \tIsReply\t, \tIsAudit\t, \tIsDeleted  ) VALUES (  '",
				Shop_NewsComment.Guid,
				"',  '",
				Shop_NewsComment.ArticleGuid,
				"',  '",
				Operator.FilterString(Shop_NewsComment.MemLoginID),
				"',  '",
				Operator.FilterString(Shop_NewsComment.Title),
				"',  '",
				Operator.FilterString(Shop_NewsComment.Content),
				"',  '",
				Shop_NewsComment.CommentTime,
				"',  '",
				Shop_NewsComment.IPAddress,
				"',  ",
				Shop_NewsComment.Rank,
				",  ",
				Shop_NewsComment.ShopID,
				",  ",
				Shop_NewsComment.CommentType,
				",  ",
				Shop_NewsComment.IsReply,
				",  ",
				Shop_NewsComment.IsAudit,
				",  ",
				Shop_NewsComment.IsDeleted,
				")"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetShopArticleCommentByGuid(string articleguid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@articleguid";
			array2[0] = articleguid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopArticleCommentByGuid", array, array2);
		}
	}
}
