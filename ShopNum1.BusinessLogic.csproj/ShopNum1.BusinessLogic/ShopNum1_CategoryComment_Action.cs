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
	public class ShopNum1_CategoryComment_Action : IShopNum1_CategoryComment_Action
	{
		public DataTable GetCategoryCommentAll(string commentTitle, string CategoryTitle, string CategoryInfoGuid, string createMember, string isAudit, string createTime1, string createTime2)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("a.Guid,");
			stringBuilder.Append("a.Title,");
			stringBuilder.Append("a.CreateMember,");
			stringBuilder.Append("a.CreateTime,");
			stringBuilder.Append("b.Guid as id,");
			stringBuilder.Append("a.IsAudit");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_CategoryComment AS a,");
			stringBuilder.Append("ShopNum1_CategoryInfo AS b");
			stringBuilder.Append(" WHERE a.CategoryInfoGuid=b.Guid");
			if (Operator.FormatToEmpty(commentTitle) != string.Empty)
			{
				stringBuilder.Append(" AND a.Title LIKE '%" + Operator.FilterString(commentTitle) + "%'");
			}
			if (Operator.FormatToEmpty(CategoryTitle) != string.Empty)
			{
				stringBuilder.Append(" AND b.Title LIKE '%" + Operator.FilterString(CategoryTitle) + "%'");
			}
			if (Operator.FormatToEmpty(CategoryInfoGuid) != string.Empty)
			{
				stringBuilder.Append(" AND a.Guid LIKE '%" + Operator.FilterString(CategoryInfoGuid) + "%'");
			}
			if (Operator.FormatToEmpty(createMember) != string.Empty)
			{
				stringBuilder.Append(" AND a.CreateMember LIKE '%" + Operator.FilterString(createMember) + "%'");
			}
			if (Operator.FormatToEmpty(isAudit) != "-1")
			{
				if (Operator.FormatToEmpty(isAudit) == "-2")
				{
					stringBuilder.Append(" AND a.IsAudit in(0,2)");
				}
				else
				{
					stringBuilder.Append(" AND a.IsAudit LIKE '%" + isAudit + "%'");
				}
			}
			if (Operator.FormatToEmpty(createTime1) != string.Empty)
			{
				stringBuilder.Append(" AND a.CreateTime>='" + createTime1 + "' ");
			}
			if (Operator.FormatToEmpty(createTime2) != string.Empty)
			{
				stringBuilder.Append(" AND a.CreateTime<='" + createTime2 + "' ");
			}
			stringBuilder.Append(" ORDER BY a.CreateTime DESC");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable GetCategoryCommentAll(string commentTitle, string CategoryTitle, string CategoryInfoGuid, string createMember, string isAudit, string createTime1, string createTime2, string CreateMember)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("a.Guid,");
			stringBuilder.Append("a.Title,");
			stringBuilder.Append("a.CreateMember,");
			stringBuilder.Append("a.CreateTime,");
			stringBuilder.Append("a.IsAudit");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_CategoryComment AS a,");
			stringBuilder.Append("ShopNum1_CategoryInfo AS b");
			stringBuilder.Append(" WHERE a.CategoryInfoGuid=b.Guid");
			stringBuilder.Append(" AND a.CreateMember='" + CreateMember + "'");
			if (Operator.FormatToEmpty(commentTitle) != string.Empty)
			{
				stringBuilder.Append(" AND a.Title LIKE '%" + Operator.FilterString(commentTitle) + "%'");
			}
			if (Operator.FormatToEmpty(CategoryTitle) != string.Empty)
			{
				stringBuilder.Append(" AND b.Title LIKE '%" + Operator.FilterString(CategoryTitle) + "%'");
			}
			if (Operator.FormatToEmpty(CategoryInfoGuid) != string.Empty)
			{
				stringBuilder.Append(" AND a.Guid LIKE '%" + Operator.FilterString(CategoryInfoGuid) + "%'");
			}
			if (Operator.FormatToEmpty(createMember) != string.Empty)
			{
				stringBuilder.Append(" AND a.CreateMember LIKE '%" + Operator.FilterString(createMember) + "%'");
			}
			if (Operator.FormatToEmpty(isAudit) != "-1")
			{
				stringBuilder.Append(" AND a.IsAudit LIKE '%" + isAudit + "%'");
			}
			if (Operator.FormatToEmpty(createTime1) != string.Empty)
			{
				stringBuilder.Append(" AND a.CreateTime>='" + createTime1 + "' ");
			}
			if (Operator.FormatToEmpty(createTime2) != string.Empty)
			{
				stringBuilder.Append(" AND a.CreateTime<='" + createTime2 + "' ");
			}
			stringBuilder.Append(" ORDER BY a.CreateTime DESC");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public int DeleteCategoryComment(string guids)
		{
			List<string> list = new List<string>();
			string item = string.Empty;
			item = "DELETE FROM ShopNum1_CategoryComment  WHERE [Guid] IN (" + guids + ") ";
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
		public int UpdateCategoryCommentAudit(string guids, string state)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("UPDATE ");
			stringBuilder.Append("ShopNum1_CategoryComment");
			stringBuilder.Append(" SET ");
			stringBuilder.Append("IsAudit = " + state);
			stringBuilder.Append(" WHERE ");
			stringBuilder.Append("[Guid] in (" + guids + ")");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public string GetCategoryGuid(string guid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("CategoryInfoGuid");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_CategoryComment");
			stringBuilder.Append(" WHERE ");
			stringBuilder.Append("[Guid] =" + guid);
			return DatabaseExcetue.ReturnString(stringBuilder.ToString());
		}
		public DataTable GetCateGoryAssociatedMemberID(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetCateGoryAssociatedMemberID", array, array2);
		}
		public int Add(ShopNum1_CategoryComment categoryComment)
		{
			string strProcedureName = "Pro_ShopNum1_AddCategoryComment";
			return DatabaseExcetue.RunProcedure(strProcedureName, new string[]
			{
				"@Title",
				"@Content",
				"@CreateTime",
				"@CreateMember",
				"@CreateIP",
				"@CategoryInfoGuid",
				"@AssociatedMemberID",
				"@IsAudit"
			}, new string[]
			{
				categoryComment.Title,
				categoryComment.Content,
				Convert.ToString(categoryComment.CreateTime),
				categoryComment.CreateMember,
				categoryComment.CreateIP,
				Convert.ToString(categoryComment.CategoryInfoGuid),
				categoryComment.AssociatedMemberID,
				categoryComment.IsAudit.ToString()
			});
		}
		public DataTable GetCommentList(string guid)
		{
			string strProcedureName = "Pro_ShopNum1_CategoryCommentList";
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@Guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable(strProcedureName, array, array2);
		}
		public DataSet GetCommentList(string perpagenum, string current_page, string guid, string ordername, string isreturcount)
		{
			string[] array = new string[6];
			string[] array2 = new string[6];
			array[0] = "@perpagenum";
			array2[0] = perpagenum;
			array[1] = "@current_page";
			array2[1] = current_page;
			array[2] = "@ColumnNames";
			array2[2] = " A.Guid,A.Title,A.[Content],A.CreateTime,A.CreateMember,A.CreateIP ,A.Reply ";
			array[3] = "@ordername";
			array2[3] = "";
			array[4] = "@guid";
			array2[4] = guid;
			array[5] = "@isreturcount";
			array2[5] = isreturcount;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_MemberCategoryComment1", array, array2);
		}
		public DataTable MemberCategoryComment(string memberloginid, string commenttitle, string categorytitle, string CategoryInfoMerberID, string isaudit, string createtime1, string createtime2)
		{
			string[] array = new string[7];
			string[] array2 = new string[7];
			array[0] = "@memberloginid";
			array2[0] = memberloginid;
			array[1] = "@commenttitle";
			array2[1] = commenttitle;
			array[2] = "@categorytitle";
			array2[2] = categorytitle;
			array[3] = "@categoryInfoMerberID";
			array2[3] = CategoryInfoMerberID;
			array[4] = "@isaudit";
			array2[4] = isaudit;
			array[5] = "@createtime1";
			array2[5] = createtime1;
			array[6] = "@createtime2";
			array2[6] = createtime2;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_MemberCategoryComment", array, array2);
		}
		public DataTable GetCategoryCommentByGuid(string guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT A.*,B.[Content] AS CategoryInfo FROM ShopNum1_CategoryComment AS A,dbo.ShopNum1_CategoryInfo AS B WHERE A.CategoryInfoGuid=B.Guid AND A.Guid=" + guid;
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int CategoryCommentReply(string guid, string content)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"UPDATE ShopNum1_CategoryComment SET Reply='",
				Operator.FormatToEmpty(content),
				"' WHERE Guid='",
				guid,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
	}
}
