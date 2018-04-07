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
	public class ShopNum1_SupplyDemandComment_Action : IShopNum1_SupplyDemandComment_Action
	{
		public DataTable GetSupplyDemandCommentAll(string commentTitle, string SupplyDemandName, string SupplyDemandGuid, string createMember, string isAudit, string createTime1, string createTime2)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("a.Guid,");
			stringBuilder.Append("a.Title,");
			stringBuilder.Append("a.Content,");
			stringBuilder.Append("b.Title AS SupplyDemandTitle,");
			stringBuilder.Append("a.CreateMerber,");
			stringBuilder.Append("a.CreateTime,");
			stringBuilder.Append("a.IsAudit,");
			stringBuilder.Append("a.SupplyDemandGuid");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_SupplyDemandComment AS a,");
			stringBuilder.Append("ShopNum1_SupplyDemand AS b");
			stringBuilder.Append(" WHERE a.SupplyDemandGuid=b.ID");
			if (Operator.FormatToEmpty(commentTitle) != string.Empty)
			{
				stringBuilder.Append(" AND a.Title LIKE '%" + Operator.FilterString(commentTitle) + "%'");
			}
			if (Operator.FormatToEmpty(SupplyDemandName) != string.Empty)
			{
				stringBuilder.Append(" AND b.Title LIKE '%" + Operator.FilterString(SupplyDemandName) + "%'");
			}
			if (Operator.FormatToEmpty(SupplyDemandGuid) != string.Empty)
			{
				stringBuilder.Append(" AND a.Guid LIKE '%" + Operator.FilterString(SupplyDemandGuid) + "%'");
			}
			if (Operator.FormatToEmpty(createMember) != string.Empty)
			{
				stringBuilder.Append(" AND a.CreateMerber LIKE '%" + Operator.FilterString(createMember) + "%'");
			}
			if (Operator.FormatToEmpty(isAudit) != "-1")
			{
				if (Operator.FormatToEmpty(isAudit) == "-2")
				{
					stringBuilder.Append(" AND a.IsAudit IN (0,2)");
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
		public DataTable GetSupplyDemandCommentAll1(string commentTitle, string SupplyDemandName, string SupplyDemandGuid, string createMember, string isAudit, string createTime1, string createTime2, string SubstationID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("a.Guid,");
			stringBuilder.Append("a.Title,");
			stringBuilder.Append("a.Content,");
			stringBuilder.Append("b.Title AS SupplyDemandTitle,");
			stringBuilder.Append("b.SubstationID,");
			stringBuilder.Append("a.CreateMerber,");
			stringBuilder.Append("a.CreateTime,");
			stringBuilder.Append("a.IsAudit,");
			stringBuilder.Append("a.SupplyDemandGuid");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_SupplyDemandComment AS a,");
			stringBuilder.Append("ShopNum1_SupplyDemand AS b");
			stringBuilder.Append(" WHERE a.SupplyDemandGuid=b.ID");
			if (Operator.FormatToEmpty(commentTitle) != string.Empty)
			{
				stringBuilder.Append(" AND a.Title LIKE '%" + Operator.FilterString(commentTitle) + "%'");
			}
			if (Operator.FormatToEmpty(SupplyDemandName) != string.Empty)
			{
				stringBuilder.Append(" AND b.Title LIKE '%" + Operator.FilterString(SupplyDemandName) + "%'");
			}
			if (Operator.FormatToEmpty(SupplyDemandGuid) != string.Empty)
			{
				stringBuilder.Append(" AND a.Guid LIKE '%" + Operator.FilterString(SupplyDemandGuid) + "%'");
			}
			if (Operator.FormatToEmpty(createMember) != string.Empty)
			{
				stringBuilder.Append(" AND a.CreateMerber LIKE '%" + Operator.FilterString(createMember) + "%'");
			}
			if (SubstationID != "-1")
			{
				stringBuilder.Append(" AND b.SubstationID = '" + SubstationID + "'");
			}
			if (Operator.FormatToEmpty(isAudit) != "-1")
			{
				if (Operator.FormatToEmpty(isAudit) == "-2")
				{
					stringBuilder.Append(" AND a.IsAudit IN (0,2)");
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
		public DataTable SearchByGuid(string guid)
		{
			string text = "SELECT A.*,B.Title AS CommentTitle,B.Content AS ConmetContent FROM ShopNum1_SupplyDemandComment AS A LEFT JOIN ShopNum1_SupplyDemand AS B ON A.SupplyDemandGuid=B.ID WHERE A.guid=" + guid;
			return DatabaseExcetue.ReturnDataTable(text.ToString());
		}
		public int ReplySupplyDemandComment(string guid, string content)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"UPDATE ShopNum1_SupplyDemandComment SET Reply='",
				Operator.FormatToEmpty(content),
				"' WHERE Guid='",
				guid,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetSupplyDemandCommentAll(string commentTitle, string SupplyDemandName, string SupplyDemandGuid, string createMember, string isAudit, string createTime1, string createTime2, string createMerber)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("a.Guid,");
			stringBuilder.Append("a.Title,");
			stringBuilder.Append("a.CreateMerber,");
			stringBuilder.Append("a.CreateTime,");
			stringBuilder.Append("a.IsAudit");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_SupplyDemandComment AS a,");
			stringBuilder.Append("ShopNum1_SupplyDemand AS b");
			stringBuilder.Append(" WHERE a.SupplyDemandGuid=b.Guid");
			stringBuilder.Append(" AND a.CreateMerber='" + createMerber + "'");
			if (Operator.FormatToEmpty(commentTitle) != string.Empty)
			{
				stringBuilder.Append(" AND a.Title LIKE '%" + Operator.FilterString(commentTitle) + "%'");
			}
			if (Operator.FormatToEmpty(SupplyDemandName) != string.Empty)
			{
				stringBuilder.Append(" AND b.Title LIKE '%" + Operator.FilterString(SupplyDemandName) + "%'");
			}
			if (Operator.FormatToEmpty(SupplyDemandGuid) != string.Empty)
			{
				stringBuilder.Append(" AND a.Guid LIKE '%" + Operator.FilterString(SupplyDemandGuid) + "%'");
			}
			if (Operator.FormatToEmpty(createMember) != string.Empty)
			{
				stringBuilder.Append(" AND a.CreateMerber LIKE '%" + Operator.FilterString(createMember) + "%'");
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
		public int DeleteSupplyDemandComment(string guids)
		{
			List<string> list = new List<string>();
			string item = string.Empty;
			item = "delete from ShopNum1_SupplyDemandComment  WHERE [Guid] IN (" + guids + ") ";
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
		public int UpdateSupplyDemandCommentAudit(string guids, string state)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("UPDATE ");
			stringBuilder.Append("ShopNum1_SupplyDemandComment");
			stringBuilder.Append(" SET ");
			stringBuilder.Append("IsAudit = " + state);
			stringBuilder.Append(" WHERE ");
			stringBuilder.Append("[Guid] in(" + guids + ")");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public DataTable GetSupplyDemandCommentMemberID(string guid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT CreateMerber");
			stringBuilder.Append("FROM ShopNum1_SupplyDemandComment");
			stringBuilder.Append(" WHERE ");
			stringBuilder.Append("[Guid] = '" + guid + "'");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public string GetSupplyDemandGuid(string guid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("SupplyDemandGuid");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_SupplyDemandComment");
			stringBuilder.Append(" WHERE ");
			stringBuilder.Append("[Guid] =" + guid);
			return DatabaseExcetue.ReturnString(stringBuilder.ToString());
		}
		public DataTable GetSupplyDemandAssociatedMemberID(string guid)
		{
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetSupplyDemandAssociatedMemberID", "@ID", guid);
		}
		public int AddSupplyDemandComment(ShopNum1_SupplyDemandComment shopNum1_SupplyDemandComment)
		{
			string strProcedureName = "Pro_ShopNum1_SupplyDemandCommentAdd";
			return DatabaseExcetue.RunProcedure(strProcedureName, new string[]
			{
				"@Title",
				"@Content",
				"@CreateTime",
				"@CreateMerber",
				"@CreateIP",
				"@SupplyDemandGuid",
				"@AssociateMemberID",
				"@IsAudit"
			}, new string[]
			{
				shopNum1_SupplyDemandComment.Title,
				shopNum1_SupplyDemandComment.Content,
				Convert.ToString(shopNum1_SupplyDemandComment.CreateTime),
				shopNum1_SupplyDemandComment.CreateMerber,
				shopNum1_SupplyDemandComment.CreateIP,
				Convert.ToString(shopNum1_SupplyDemandComment.SupplyDemandGuid),
				Convert.ToString(shopNum1_SupplyDemandComment.AssociateMemberID),
				shopNum1_SupplyDemandComment.IsAudit.ToString()
			});
		}
		public DataTable GetSupplyDemandCommentList(string guid)
		{
			string strProcedureName = "Pro_ShopNum1_SupplyDemandCommentList";
			return DatabaseExcetue.RunProcedureReturnDataTable(strProcedureName, "@guid", guid);
		}
		public DataSet GetSupplyDemandCommentList(string perpagenum, string current_page, string guid, string ordername, string isreturcount)
		{
			string[] array = new string[6];
			string[] array2 = new string[6];
			array[0] = "@perpagenum";
			array2[0] = perpagenum;
			array[1] = "@current_page";
			array2[1] = current_page;
			array[2] = "@ColumnNames";
			array2[2] = " A.Guid,A.Title,A.[Content],A.CreateTime,A.CreateMerber,A.CreateIP ,B.Title AS SupplyDemandTitle,A.AssociateMemberID,A.Reply ";
			array[3] = "@ordername";
			array2[3] = "";
			array[4] = "@guid";
			array2[4] = guid;
			array[5] = "@isreturcount";
			array2[5] = isreturcount;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_MemberSupplyDemandComment1", array, array2);
		}
		public DataTable MemberSupplyDemandComment(string memberloginid, string commenttitle, string supplydemandname, string publishMemLoginID, string isaudit, string createtime1, string createtime2)
		{
			string[] array = new string[7];
			string[] array2 = new string[7];
			array[0] = "@memberloginid";
			array2[0] = memberloginid;
			array[1] = "@commenttitle";
			array2[1] = commenttitle;
			array[2] = "@supplydemandname";
			array2[2] = supplydemandname;
			array[3] = "@publishMemLoginID";
			array2[3] = publishMemLoginID;
			array[4] = "@isaudit";
			array2[4] = isaudit;
			array[5] = "@createtime1";
			array2[5] = createtime1;
			array[6] = "@createtime2";
			array2[6] = createtime2;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_MemberSupplyDemandComment", array, array2);
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
			array2[3] = "ShopNum1_SupplyDemandComment";
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
	}
}
