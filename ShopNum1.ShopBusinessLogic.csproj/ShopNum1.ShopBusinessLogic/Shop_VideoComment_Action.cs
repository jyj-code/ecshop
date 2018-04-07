using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.ShopBusinessLogic
{
	public class Shop_VideoComment_Action : IShop_VideoComment_Action
	{
		public DataTable Search(string MemLoginID, string VideoTitle, int IsAudit, string SendTime1, string SendTime2)
		{
			string text = string.Empty;
			text = "select A.*,B.Title from ShopNum1_Shop_VideoComment as a Left join  ShopNum1_Shop_Video as b on a.VideoGuid =b.Guid where 1=1 ";
			if (Operator.FormatToEmpty(VideoTitle) != string.Empty)
			{
				text = text + " AND B.Title Like '%" + Operator.FilterString(VideoTitle) + "%'";
			}
			if (Operator.FormatToEmpty(MemLoginID) != string.Empty)
			{
				text = text + " AND A.MemLoginID = '" + MemLoginID + "'";
			}
			if (IsAudit != -1)
			{
				text = text + " AND A.IsAudit =" + IsAudit;
			}
			if (Operator.FormatToEmpty(SendTime1) != string.Empty)
			{
				text = text + " AND A.CommentTime>='" + Operator.FilterString(SendTime1) + "' ";
			}
			if (Operator.FormatToEmpty(SendTime2) != string.Empty)
			{
				text = text + " AND A.CommentTime<='" + Operator.FilterString(SendTime2) + "' ";
			}
			text += "  ORDER BY A.CommentTime DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchByGuid(string guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT * from ShopNum1_Shop_VideoComment where Guid =" + guid + " ORDER BY CreateTime DESC";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int UpdateAudit(string StrGuids)
		{
			string strSql = string.Empty;
			strSql = "UPDATE  ShopNum1_Shop_VideoComment SET IsAudit= 1 WHERE Guid in ('" + StrGuids + "')";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int UpdateAuditNot(string StrGuids)
		{
			string strSql = string.Empty;
			strSql = "UPDATE  ShopNum1_Shop_VideoComment SET IsAudit= 0 WHERE Guid in ('" + StrGuids + "')";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Delete(string guids)
		{
			string strSql = string.Empty;
			strSql = "delete from ShopNum1_Shop_VideoComment  WHERE Guid IN (" + guids + ") ";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable Search(string guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT * from ShopNum1_Shop_VideoComment where VideoGuid =" + guid + " ORDER BY CommentTime DESC";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetVideoCommentList(string guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT * from ShopNum1_Shop_VideoComment where VideoGuid ='" + guid + "' AND IsAudit = 1 ORDER BY CommentTime DESC";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int Add(ShopNum1_Shop_VideoComment videoComment_Action)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_Shop_VideoComment( \tGuid\t, \tTitle\t, \tCommentType\t, \tComment\t, \tCommentTime\t, \tIsDelete\t, \tVideoGuid\t, \tShopID\t, \tMemLoginID\t, \tIPAddress\t, \tIsReply\t, \tIsAudit\t  ) VALUES (  '",
				videoComment_Action.Guid,
				"',  '",
				videoComment_Action.Title,
				"',   ",
				videoComment_Action.CommentType,
				",  '",
				Operator.FilterString(videoComment_Action.Comment),
				"',  '",
				videoComment_Action.CommentTime,
				"',   0, '",
				videoComment_Action.VideoGuid,
				"',  '",
				videoComment_Action.ShopID,
				"',  '",
				videoComment_Action.MemLoginID,
				"',  '",
				videoComment_Action.IPAddress,
				"',   ",
				videoComment_Action.IsReply,
				",   ",
				videoComment_Action.IsAudit,
				" )"
			});
			int result;
			try
			{
				DatabaseExcetue.RunNonQuery(strSql);
				result = 1;
			}
			catch
			{
				result = 0;
			}
			return result;
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
			array2[3] = "ShopNum1_Shop_VideoComment";
			array[4] = "@condition";
			array2[4] = commonModel.Condition;
			array[5] = "@ordercolumn";
			array2[5] = "CommentTime";
			array[6] = "@sortvalue";
			array2[6] = "desc";
			array[7] = "@resultnum";
			array2[7] = commonModel.Resultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
		public DataTable GetTitleByGuid(string guid)
		{
			string strSql = string.Empty;
			strSql = "    SELECT   Title  FROM  ShopNum1_Shop_Video  WHERE  Guid ='" + guid + "'       ";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetVideoCommentDetail(string guid)
		{
			string text = string.Empty;
			text += "  SELECT  A.*,B.Title AS VideoTitle ";
			text += "  FROM ShopNum1_Shop_VideoComment AS A LEFT JOIN ShopNum1_Shop_Video AS B";
			text += "  ON A.VideoGuid=B.Guid";
			text = text + "  WHERE  A.Guid='" + guid + "'  ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
	}
}
