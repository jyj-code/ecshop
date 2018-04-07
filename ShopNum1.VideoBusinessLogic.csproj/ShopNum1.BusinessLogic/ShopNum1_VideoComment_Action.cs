using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_VideoComment_Action : IShopNum1_VideoComment_Action
	{
		public DataTable Search(string MemLoginID, string VideoTitle, int IsAudit, string SendTime1, string SendTime2)
		{
			string text = string.Empty;
			text = "select A.*,B.Title from ShopNum1_VideoComment as a Left join  ShopNum1_Video as b on a.VideoGuid =b.Guid where 1=1 ";
			if (Operator.FormatToEmpty(VideoTitle) != string.Empty)
			{
				text = text + " AND B.Title Like '%" + Operator.FilterString(VideoTitle) + "%'";
			}
			if (Operator.FormatToEmpty(MemLoginID) != string.Empty)
			{
				text = text + " AND A.MemLoginID like  '%" + Operator.FilterString(MemLoginID) + "%'";
			}
			if (IsAudit != -1)
			{
				text = text + " AND A.IsAudit =" + IsAudit;
			}
			if (Operator.FormatToEmpty(SendTime1) != string.Empty)
			{
				text = text + " AND A.CreateTime>='" + Operator.FilterString(SendTime1) + "' ";
			}
			if (Operator.FormatToEmpty(SendTime2) != string.Empty)
			{
				text = text + " AND A.CreateTime<='" + Operator.FilterString(SendTime2) + "' ";
			}
			text += "  ORDER BY A.CreateTime DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Search(string MemLoginID, string VideoTitle, int IsAudit, string SendTime1, string SendTime2, string SubstationID)
		{
			string text = string.Empty;
			text = "select A.*,B.Title,B.SubstationID from ShopNum1_VideoComment as a Left join  ShopNum1_Video as b on a.VideoGuid =b.Guid where 1=1 ";
			if (Operator.FormatToEmpty(VideoTitle) != string.Empty)
			{
				text = text + " AND B.Title Like '%" + Operator.FilterString(VideoTitle) + "%'";
			}
			if (Operator.FormatToEmpty(MemLoginID) != string.Empty)
			{
				text = text + " AND A.MemLoginID like  '%" + Operator.FilterString(MemLoginID) + "%'";
			}
			if (IsAudit != -1)
			{
				text = text + " AND A.IsAudit =" + IsAudit;
			}
			if (Operator.FormatToEmpty(SendTime1) != string.Empty)
			{
				text = text + " AND A.CreateTime>='" + Operator.FilterString(SendTime1) + "' ";
			}
			if (Operator.FormatToEmpty(SendTime2) != string.Empty)
			{
				text = text + " AND A.CreateTime<='" + Operator.FilterString(SendTime2) + "' ";
			}
			if (SubstationID != "-1")
			{
				text = text + " AND B.SubstationID = '" + SubstationID + "'";
			}
			text += "  ORDER BY A.CreateTime DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int UpdateAudit(string StrGuids)
		{
			string strSql = string.Empty;
			strSql = "UPDATE  ShopNum1_VideoComment SET IsAudit= 1 WHERE Guid in (" + StrGuids + ")";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int UpdateAuditNot(string StrGuids)
		{
			string strSql = string.Empty;
			strSql = "UPDATE  ShopNum1_VideoComment SET IsAudit= 2 WHERE Guid in (" + StrGuids + ")";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Delete(string guids)
		{
			string strSql = string.Empty;
			strSql = "delete from ShopNum1_VideoComment  WHERE Guid IN (" + guids + ") ";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable SearchByGuid(string guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT * from ShopNum1_VideoComment where Guid =" + guid + " ORDER BY CreateTime DESC";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable Search(string guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT * from ShopNum1_VideoComment where VideoGuid =" + guid + " ORDER BY CreateTime DESC";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetVideoCommentList(string guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT *   from ShopNum1_VideoComment   where   IsAudit=1 AND    VideoGuid ='" + guid + "'   ORDER BY CreateTime DESC";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetVideoCommentList(string guid, int isAudit)
		{
			string text = string.Empty;
			text = "SELECT *   from ShopNum1_VideoComment   where   VideoGuid ='" + guid + "' ";
			if (isAudit == 0 || isAudit == 1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					" AND IsAudit = ",
					isAudit,
					" "
				});
			}
			text += " ORDER BY CreateTime DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int Add(ShopNum1_VideoComment videoComment_Action)
		{
			string item = string.Empty;
			List<string> list = new List<string>();
			item = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_VideoComment( \tGuid\t, \tCreateTime\t, \tContent\t, \tMemLoginID\t, \tIsAudit\t, \tIsDeleted\t, \tVideoGuid\t ) VALUES (  '",
				videoComment_Action.Guid,
				"',  '",
				videoComment_Action.CreateTime,
				"',  '",
				Operator.FilterString(videoComment_Action.Content),
				"',  '",
				Operator.FilterString(videoComment_Action.MemLoginID),
				"',  ",
				Operator.FilterString(videoComment_Action.IsAudit),
				",  ",
				Operator.FilterString(videoComment_Action.IsDeleted),
				",  '",
				videoComment_Action.VideoGuid,
				"')"
			});
			list.Add(item);
			item = "UPDATE ShopNum1_Video SET CommentCount =CommentCount + 1 WHERE Guid='" + videoComment_Action.VideoGuid + "'";
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
		public DataSet GetPageVideoComment(string VideoGuid, string perpagenum, string current_page, string isreturcount)
		{
			string text = string.Empty;
			if (VideoGuid != "-1")
			{
				text = " VideoGuid = '" + Operator.FilterString(VideoGuid) + "'";
			}
			else
			{
				text = "1=1";
			}
			string[] array = new string[5];
			string[] array2 = new string[5];
			array[0] = "@perpagenum";
			array2[0] = perpagenum;
			array[1] = "@current_page";
			array2[1] = current_page;
			array[2] = "@columnnames";
			array2[2] = " * ";
			array[3] = "@searchname";
			array2[3] = text;
			array[4] = "@isreturcount";
			array2[4] = isreturcount;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_CommonPageVideoComment", array, array2);
		}
	}
}
