using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.IO;
using System.Web;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_ArticleComment_Action : IShopNum1_ArticleComment_Action
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
		public DataTable Search(string guid, string articleName, string memLoginID, string title, string sendTime1, string sendTime2, string replyTime1, string replyTime2, int isReply, int isAudit, int isDeleted, string IP)
		{
			string text = string.Empty;
			text = "SELECT A.Guid,A.ArticleGuid,B.Title As ArticleTitle,A.MemLoginID,A.Title,A.Rank,A.SendTime,A.Content,A.IPAddress,A.ReplyUser,A.ReplyTime,A.ReplyContent,A.IsAudit,A.IsReply,A.IsDeleted  FROM ShopNum1_ArticleComment AS A,ShopNum1_Article AS B    WHERE A.ArticleGuid = B.Guid ";
			if (Operator.FormatToEmpty(articleName) != string.Empty)
			{
				text = text + " AND B.Title LIKE '%" + Operator.FilterString(articleName) + "%'";
			}
			if (Operator.FormatToEmpty(memLoginID) != string.Empty)
			{
				text = text + " AND A.MemLoginID LIKE '%" + Operator.FilterString(memLoginID) + "%'";
			}
			if (Operator.FormatToEmpty(title) != string.Empty)
			{
				text = text + " AND A.Title LIKE '%" + Operator.FilterString(title) + "%'";
			}
			if (Operator.FormatToEmpty(IP) != string.Empty)
			{
				text = text + "AND A.IPAddress like'%" + Operator.FilterString(IP) + "%'";
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
			else if (isAudit == 0 || isAudit == 1 || isAudit == 2)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND A.IsAudit=",
					isAudit,
					" "
				});
			}
			if (Operator.FormatToEmpty(sendTime1) != string.Empty)
			{
				text = text + " AND A.SendTime>='" + Operator.FilterString(sendTime1) + "' ";
			}
			if (Operator.FormatToEmpty(sendTime2) != string.Empty)
			{
				text = text + " AND A.SendTime<='" + Operator.FilterString(sendTime2) + "' ";
			}
			if (Operator.FormatToEmpty(replyTime1) != string.Empty)
			{
				text = text + " AND A.ReplyTime>='" + Operator.FilterString(replyTime1) + "'";
			}
			if (Operator.FormatToEmpty(replyTime2) != string.Empty)
			{
				text = text + " AND A.ReplyTime<='" + Operator.FilterString(replyTime2) + "' ";
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
		public DataTable SearchNew(string guid, string articleName, string memLoginID, string title, string sendTime1, string sendTime2, string replyTime1, string replyTime2, int isReply, int isAudit, int isDeleted, string IP, string SubstationID)
		{
			string text = string.Empty;
			text = "SELECT A.Guid,A.ArticleGuid,B.Title As ArticleTitle, B.SubstationID,A.MemLoginID,A.Title,A.Rank,A.SendTime,A.Content,A.IPAddress,A.ReplyUser,A.ReplyTime,A.ReplyContent,A.IsAudit,A.IsReply,A.IsDeleted  FROM ShopNum1_ArticleComment AS A,ShopNum1_Article AS B    WHERE A.ArticleGuid = B.Guid ";
			if (Operator.FormatToEmpty(articleName) != string.Empty)
			{
				text = text + " AND B.Title LIKE '%" + Operator.FilterString(articleName) + "%'";
			}
			if (Operator.FormatToEmpty(memLoginID) != string.Empty)
			{
				text = text + " AND A.MemLoginID LIKE '%" + Operator.FilterString(memLoginID) + "%'";
			}
			if (Operator.FormatToEmpty(title) != string.Empty)
			{
				text = text + " AND A.Title LIKE '%" + Operator.FilterString(title) + "%'";
			}
			if (Operator.FormatToEmpty(IP) != string.Empty)
			{
				text = text + "AND A.IPAddress like'%" + Operator.FilterString(IP) + "%'";
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
			else if (isAudit == 0 || isAudit == 1 || isAudit == 2)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND A.IsAudit=",
					isAudit,
					" "
				});
			}
			if (Operator.FormatToEmpty(sendTime1) != string.Empty)
			{
				text = text + " AND A.SendTime>='" + Operator.FilterString(sendTime1) + "' ";
			}
			if (Operator.FormatToEmpty(sendTime2) != string.Empty)
			{
				text = text + " AND A.SendTime<='" + Operator.FilterString(sendTime2) + "' ";
			}
			if (Operator.FormatToEmpty(replyTime1) != string.Empty)
			{
				text = text + " AND A.ReplyTime>='" + Operator.FilterString(replyTime1) + "'";
			}
			if (Operator.FormatToEmpty(replyTime2) != string.Empty)
			{
				text = text + " AND A.ReplyTime<='" + Operator.FilterString(replyTime2) + "' ";
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
			if (SubstationID != "-1")
			{
				text = text + " AND B.SubstationID='" + SubstationID + "' ";
			}
			text += "Order by A.SendTime Desc";
			File.AppendAllText(HttpContext.Current.Server.MapPath("~/log/tsql.txt"), text);
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Search(string guid, string articleName, string memLoginID, string title, string sendTime1, string sendTime2, string replyTime1, string replyTime2, int isReply, int isAudit, int isDeleted, string IP, string ArticleGuid)
		{
			string text = string.Empty;
			text = "SELECT A.Guid,A.ArticleGuid,B.Title As ArticleTitle,A.MemLoginID,A.Title,A.Rank,A.SendTime,A.Content,A.IPAddress,A.ReplyUser,A.ReplyTime,A.ReplyContent,A.IsAudit,A.IsReply,A.IsDeleted  FROM ShopNum1_ArticleComment AS A,ShopNum1_Article AS B    WHERE A.ArticleGuid = B.Guid ";
			if (Operator.FormatToEmpty(articleName) != string.Empty)
			{
				text = text + " AND B.Title LIKE '%" + Operator.FilterString(articleName) + "%'";
			}
			if (Operator.FormatToEmpty(memLoginID) != string.Empty)
			{
				text = text + " AND A.MemLoginID LIKE '%" + Operator.FilterString(memLoginID) + "%'";
			}
			if (Operator.FormatToEmpty(title) != string.Empty)
			{
				text = text + " AND A.Title LIKE '%" + Operator.FilterString(title) + "%'";
			}
			if (Operator.FormatToEmpty(IP) != string.Empty)
			{
				text = text + "AND A.IPAddress like'%" + Operator.FilterString(IP) + "%'";
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
			else if (isAudit == 0 || isAudit == 1 || isAudit == 2)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND A.IsAudit=",
					isAudit,
					" "
				});
			}
			if (Operator.FormatToEmpty(sendTime1) != string.Empty)
			{
				text = text + " AND A.SendTime>='" + Operator.FilterString(sendTime1) + "' ";
			}
			if (Operator.FormatToEmpty(sendTime2) != string.Empty)
			{
				text = text + " AND A.SendTime<='" + Operator.FilterString(sendTime2) + "' ";
			}
			if (Operator.FormatToEmpty(replyTime1) != string.Empty)
			{
				text = text + " AND A.ReplyTime>='" + Operator.FilterString(replyTime1) + "'";
			}
			if (Operator.FormatToEmpty(replyTime2) != string.Empty)
			{
				text = text + " AND A.ReplyTime<='" + Operator.FilterString(replyTime2) + "' ";
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
			if (ArticleGuid != "0")
			{
				text = text + " AND A.ArticleGuid=" + ArticleGuid + " ";
			}
			text += "Order by A.SendTime Desc";
			File.AppendAllText(HttpContext.Current.Server.MapPath("~/log/tsql2.txt"), text);
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Search(string guid, string articleName, string memLoginID, string title, string sendTime1, string sendTime2, string replyTime1, string replyTime2, int isReply, int isAudit, int isDeleted, string IP, string ArticleGuid, string SubstationID)
		{
			string text = string.Empty;
			text = "SELECT A.Guid,A.ArticleGuid,B.Title As ArticleTitle,B.SubstationID,A.MemLoginID,A.Title,A.Rank,A.SendTime,A.Content,A.IPAddress,A.ReplyUser,A.ReplyTime,A.ReplyContent,A.IsAudit,A.IsReply,A.IsDeleted  FROM ShopNum1_ArticleComment AS A,ShopNum1_Article AS B    WHERE A.ArticleGuid = B.Guid ";
			if (Operator.FormatToEmpty(articleName) != string.Empty)
			{
				text = text + " AND B.Title LIKE '%" + Operator.FilterString(articleName) + "%'";
			}
			if (Operator.FormatToEmpty(memLoginID) != string.Empty)
			{
				text = text + " AND A.MemLoginID LIKE '%" + Operator.FilterString(memLoginID) + "%'";
			}
			if (Operator.FormatToEmpty(title) != string.Empty)
			{
				text = text + " AND A.Title LIKE '%" + Operator.FilterString(title) + "%'";
			}
			if (Operator.FormatToEmpty(IP) != string.Empty)
			{
				text = text + "AND A.IPAddress like'%" + Operator.FilterString(IP) + "%'";
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
			else if (isAudit == 0 || isAudit == 1 || isAudit == 2)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND A.IsAudit=",
					isAudit,
					" "
				});
			}
			if (Operator.FormatToEmpty(sendTime1) != string.Empty)
			{
				text = text + " AND A.SendTime>='" + Operator.FilterString(sendTime1) + "' ";
			}
			if (Operator.FormatToEmpty(sendTime2) != string.Empty)
			{
				text = text + " AND A.SendTime<='" + Operator.FilterString(sendTime2) + "' ";
			}
			if (Operator.FormatToEmpty(replyTime1) != string.Empty)
			{
				text = text + " AND A.ReplyTime>='" + Operator.FilterString(replyTime1) + "'";
			}
			if (Operator.FormatToEmpty(replyTime2) != string.Empty)
			{
				text = text + " AND A.ReplyTime<='" + Operator.FilterString(replyTime2) + "' ";
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
			if (ArticleGuid != "0")
			{
				text = text + " AND A.ArticleGuid=" + ArticleGuid + " ";
			}
			if (SubstationID != "-1")
			{
				text = text + " AND B.SubstationID='" + SubstationID + "' ";
			}
			text += "Order by A.SendTime Desc";
			File.AppendAllText(HttpContext.Current.Server.MapPath("~/log/tsqlv.txt"), text + "|");
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchByGuid(string guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT A.Guid,A.ArticleGuid,B.Title As ArticleTitle,B.CreateTime,A.MemLoginID,A.Title,A.Rank,A.SendTime,A.Content,A.IPAddress,A.ReplyUser,A.ReplyTime,A.ReplyContent,A.IsAudit,A.IsReply,A.IsDeleted  FROM ShopNum1_ArticleComment AS A,ShopNum1_Article AS B   WHERE A.ArticleGuid = B.Guid  AND A.Guid=" + guid;
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int Update(ShopNum1_ArticleComment articleComment)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_ArticleComment SET   ReplyUser\t='",
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
				"UPDATE  ShopNum1_ArticleComment SET  IsAudit\t=",
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
			strSql = "DELETE FROM ShopNum1_ArticleComment WHERE Guid IN (" + guids + ")";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable Search(string memLoginID, int isDeleted)
		{
			string text = string.Empty;
			text = "SELECT A.Guid,A.ArticleGuid,B.Title As ArticleTitle,A.MemLoginID,A.Title,A.Rank,A.SendTime,A.Content,A.IPAddress,A.ReplyUser,A.ReplyTime,A.ReplyContent,A.IsAudit,A.IsReply,A.IsDeleted  FROM ShopNum1_ArticleComment AS A,ShopNum1_Article AS B    WHERE A.ArticleGuid = B.Guid ";
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
			text += "\tGuid\t, \tMemLoginID\t, \tArticleGuid\t, \tTitle\t, \tContent\t, \tSendTime\t, \tReplyUser\t, \tReplyTime\t, \tReplyContent\t, \tIPAddress\t, \tRank\t, \tIsReply\t, \tIsAudit\t, \tIsDeleted   FROM ShopNum1_ArticleComment  WHERE IsDeleted = 0";
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
		public int UpdateScoreByCommentArticle(string memloginid, string rankscore, string score)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@memloginid";
			array2[0] = memloginid;
			array[1] = "@rankscore";
			array2[1] = rankscore;
			array[2] = "@score";
			array2[2] = score;
			return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdateScoreByCommentArticle", array, array2);
		}
		public DataTable GetArticleCommentInfoByGuid(string guid)
		{
			string strSql = string.Empty;
			strSql = "select MemLoginID,IsAudit from ShopNum1_Shop_NewsComment where Guid IN (" + guid + ")";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable SearchArticleCommentInfo(string memberloginid, string commenttitle, string articletitle, string isaudit, string createtime1, string createtime2)
		{
			string[] array = new string[6];
			string[] array2 = new string[6];
			array[0] = "@memberloginid";
			array2[0] = memberloginid;
			array[1] = "@commenttitle";
			array2[1] = commenttitle;
			array[2] = "@articletitle";
			array2[2] = articletitle;
			array[3] = "@isaudit";
			array2[3] = isaudit;
			array[4] = "@createtime1";
			array2[4] = createtime1;
			array[5] = "@createtime2";
			array2[5] = createtime2;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchArticleCommentInfo", array, array2);
		}
	}
}
