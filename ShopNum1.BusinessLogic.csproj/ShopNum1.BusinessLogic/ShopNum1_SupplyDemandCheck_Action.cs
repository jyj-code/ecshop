using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Text;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_SupplyDemandCheck_Action : IShopNum1_SupplyDemandCheck_Action
	{
		private static DataTable dataTable_0 = null;
		public static DataTable SupplyDemandCategoryTable
		{
			get
			{
				if (ShopNum1_SupplyDemandCheck_Action.dataTable_0 == null)
				{
					string strSql = "SELECT ID,[Name],[Code],OrderID,FatherID FROM ShopNum1_SupplyDemandCategory WHERE IsDeleted=0 and IsShow=1 ORDER BY OrderID ASC";
					ShopNum1_SupplyDemandCheck_Action.dataTable_0 = DatabaseExcetue.ReturnDataTable(strSql);
				}
				return ShopNum1_SupplyDemandCheck_Action.dataTable_0;
			}
			set
			{
				ShopNum1_SupplyDemandCheck_Action.dataTable_0 = null;
			}
		}
		public DataTable Search(string code, string associatedMemberID, string isAudit)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("a.ID,");
			stringBuilder.Append("a.Title,");
			stringBuilder.Append("a.MemberID,");
			stringBuilder.Append("a.CategoryName,");
			stringBuilder.Append("a.TradeType,");
			stringBuilder.Append("a.Description,");
			stringBuilder.Append("a.Keywords,");
			stringBuilder.Append("a.ValidTime,");
			stringBuilder.Append("a.IsAudit,");
			stringBuilder.Append("a.OrderID,");
			stringBuilder.Append("b.Name");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_SupplyDemand as a,");
			stringBuilder.Append("ShopNum1_SupplyDemandCategory as b");
			stringBuilder.Append(" WHERE A.CategoryCode=B.Code ");
			if (!string.IsNullOrEmpty(associatedMemberID))
			{
				stringBuilder.Append(" AND a.MemberID= '" + associatedMemberID + "'");
			}
			if (Operator.FormatToEmpty(code) != "-1")
			{
				stringBuilder.Append(" AND  a.CategoryCode LIKE '" + code + "%'");
			}
			if (Operator.FormatToEmpty(isAudit) != "-1")
			{
				if (Operator.FormatToEmpty(isAudit) == "-2")
				{
					stringBuilder.Append(" AND a.IsAudit IN (0,2) ");
				}
				else
				{
					stringBuilder.Append(" AND a.IsAudit =" + isAudit);
				}
			}
			stringBuilder.Append(" ORDER BY a.ReleaseTime DESC");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable SearchNew(string code, string associatedMemberID, string isAudit, string SubstationID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("a.ID,");
			stringBuilder.Append("a.Title,");
			stringBuilder.Append("a.MemberID,");
			stringBuilder.Append("a.CategoryName,");
			stringBuilder.Append("a.TradeType,");
			stringBuilder.Append("a.Description,");
			stringBuilder.Append("a.Keywords,");
			stringBuilder.Append("a.ValidTime,");
			stringBuilder.Append("a.IsAudit,");
			stringBuilder.Append("a.OrderID,");
			stringBuilder.Append("b.Name");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_SupplyDemand as a,");
			stringBuilder.Append("ShopNum1_SupplyDemandCategory as b");
			stringBuilder.Append(" WHERE A.CategoryCode=B.Code ");
			if (!string.IsNullOrEmpty(associatedMemberID))
			{
				stringBuilder.Append(" AND a.MemberID= '" + associatedMemberID + "'");
			}
			if (Operator.FormatToEmpty(code) != "-1")
			{
				stringBuilder.Append(" AND  a.CategoryCode LIKE '" + code + "%'");
			}
			if (Operator.FormatToEmpty(isAudit) != "-1")
			{
				if (Operator.FormatToEmpty(isAudit) == "-2")
				{
					stringBuilder.Append(" AND a.IsAudit IN (0,2) ");
				}
				else
				{
					stringBuilder.Append(" AND a.IsAudit =" + isAudit);
				}
			}
			if (SubstationID != "-1")
			{
				stringBuilder.Append(" AND a.SubstationID ='" + SubstationID + "' ");
			}
			stringBuilder.Append(" ORDER BY a.ReleaseTime DESC");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable Search(string code, string associatedMemberID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("a.ID,");
			stringBuilder.Append("a.Title,");
			stringBuilder.Append("a.MemberID,");
			stringBuilder.Append("a.CategoryName,");
			stringBuilder.Append("a.TradeType,");
			stringBuilder.Append("a.Description,");
			stringBuilder.Append("a.Keywords,");
			stringBuilder.Append("a.ValidTime,");
			stringBuilder.Append("a.IsAudit,");
			stringBuilder.Append("a.OrderID,");
			stringBuilder.Append("b.Name");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_SupplyDemand as a,");
			stringBuilder.Append("ShopNum1_SupplyDemandCategory as b");
			stringBuilder.Append(" WHERE A.CategoryCode=B.Code ");
			if (!string.IsNullOrEmpty(associatedMemberID))
			{
				stringBuilder.Append(" AND a.MemberID= '" + associatedMemberID + "'");
			}
			if (Operator.FormatToEmpty(code) != "-1")
			{
				stringBuilder.Append(" AND  a.CategoryCode LIKE '" + code + "%'");
			}
			stringBuilder.Append(" AND a.IsAudit in (0,1,2)");
			stringBuilder.Append(" ORDER BY a.ReleaseTime DESC");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable Search(string code, string associatedMemberID, string MemberID, int TradeType, string SubstationID, string Audit)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("a.ID,");
			stringBuilder.Append("a.Title,");
			stringBuilder.Append("a.MemberID,");
			stringBuilder.Append("a.CategoryName,");
			stringBuilder.Append("a.TradeType,");
			stringBuilder.Append("a.Description,");
			stringBuilder.Append("a.Keywords,");
			stringBuilder.Append("a.ValidTime,");
			stringBuilder.Append("a.IsAudit,");
			stringBuilder.Append("a.OrderID,");
			stringBuilder.Append("a.SubstationID,");
			stringBuilder.Append("b.Name");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_SupplyDemand as a,");
			stringBuilder.Append("ShopNum1_SupplyDemandCategory as b");
			stringBuilder.Append(" WHERE A.CategoryCode=B.Code ");
			if (!string.IsNullOrEmpty(associatedMemberID))
			{
				stringBuilder.Append(" AND a.MemberID= '" + associatedMemberID + "'");
			}
			if (Operator.FormatToEmpty(code) != "-1")
			{
				stringBuilder.Append(" AND  a.CategoryCode LIKE '" + code + "%'");
			}
			if (!string.IsNullOrEmpty(MemberID))
			{
				stringBuilder.Append(" AND a.MemberID  LIKE   '%" + MemberID + "%'");
			}
			if (TradeType != -1)
			{
				stringBuilder.Append(" AND a.TradeType  =   '" + TradeType + "'");
			}
			if (SubstationID != "-1")
			{
				stringBuilder.Append(" AND a.SubstationID ='" + SubstationID + "' ");
			}
			if (Operator.FormatToEmpty(Audit) != "-1")
			{
				if (Operator.FormatToEmpty(Audit) == "0")
				{
					stringBuilder.Append(" AND a.IsAudit='0'");
				}
				else
				{
					stringBuilder.Append(" AND a.IsAudit IN (0,2) ");
				}
			}
			stringBuilder.Append(" ORDER BY a.ReleaseTime DESC");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable Search(string code, string associatedMemberID, string MemberID, int TradeType, string SubstationID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("a.ID,");
			stringBuilder.Append("a.Title,");
			stringBuilder.Append("a.MemberID,");
			stringBuilder.Append("a.CategoryName,");
			stringBuilder.Append("a.TradeType,");
			stringBuilder.Append("a.Description,");
			stringBuilder.Append("a.Keywords,");
			stringBuilder.Append("a.ValidTime,");
			stringBuilder.Append("a.IsAudit,");
			stringBuilder.Append("a.OrderID,");
			stringBuilder.Append("a.SubstationID,");
			stringBuilder.Append("b.Name");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_SupplyDemand as a,");
			stringBuilder.Append("ShopNum1_SupplyDemandCategory as b");
			stringBuilder.Append(" WHERE A.CategoryCode=B.Code ");
			if (!string.IsNullOrEmpty(associatedMemberID))
			{
				stringBuilder.Append(" AND a.MemberID= '" + associatedMemberID + "'");
			}
			if (Operator.FormatToEmpty(code) != "-1")
			{
				stringBuilder.Append(" AND  a.CategoryCode LIKE '" + code + "%'");
			}
			if (!string.IsNullOrEmpty(MemberID))
			{
				stringBuilder.Append(" AND a.MemberID  LIKE   '%" + MemberID + "%'");
			}
			if (TradeType != -1)
			{
				stringBuilder.Append(" AND a.TradeType  =   '" + TradeType + "'");
			}
			if (SubstationID != "-1")
			{
				stringBuilder.Append(" AND  a.SubstationID  =   '" + SubstationID + "'");
			}
			stringBuilder.Append(" AND a.IsAudit in (0,1,2)");
			stringBuilder.Append(" ORDER BY a.ReleaseTime DESC");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable Search1(string code, string associatedMemberID, int IsAudit)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("a.ID,");
			stringBuilder.Append("a.Title,");
			stringBuilder.Append("a.MemberID,");
			stringBuilder.Append("a.CategoryName,");
			stringBuilder.Append("a.TradeType,");
			stringBuilder.Append("a.Description,");
			stringBuilder.Append("a.Keywords,");
			stringBuilder.Append("a.ValidTime,");
			stringBuilder.Append("a.IsAudit,");
			stringBuilder.Append("a.OrderID,");
			stringBuilder.Append("b.Name");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_SupplyDemand as a,");
			stringBuilder.Append("ShopNum1_SupplyDemandCategory as b");
			stringBuilder.Append(" WHERE A.CategoryCode=B.Code ");
			if (!string.IsNullOrEmpty(associatedMemberID))
			{
				stringBuilder.Append(" AND a.MemberID= '" + associatedMemberID + "'");
			}
			if (Operator.FormatToEmpty(code) != "-1")
			{
				stringBuilder.Append(" AND  a.CategoryCode LIKE '" + code + "%'");
			}
			if (IsAudit == 0)
			{
				stringBuilder.Append(" AND a.IsAudit=0");
			}
			else
			{
				stringBuilder.Append(" AND a.IsAudit in (0,1,2)");
			}
			stringBuilder.Append(" ORDER BY a.ReleaseTime DESC");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable SearchList(string codes, string associatedMemberIDs, string titles, string types, string startTimes, string endtimes, string isAudits)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("a.ID,");
			stringBuilder.Append("a.Title,");
			stringBuilder.Append("a.MemberID,");
			stringBuilder.Append("a.TradeType,");
			stringBuilder.Append("a.Description,");
			stringBuilder.Append("a.Keywords,");
			stringBuilder.Append("a.ReleaseTime,");
			stringBuilder.Append("a.ValidTime,");
			stringBuilder.Append("a.IsAudit,");
			stringBuilder.Append("a.OrderID,");
			stringBuilder.Append("a.CategoryName,");
			stringBuilder.Append("a.SubstationID,");
			stringBuilder.Append("b.Name");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_SupplyDemand as a,");
			stringBuilder.Append("ShopNum1_SupplyDemandCategory as b");
			stringBuilder.Append(" WHERE A.CategoryCode=B.Code ");
			if (Operator.FormatToEmpty(associatedMemberIDs) != "-1")
			{
				stringBuilder.Append(" AND a.MemberID= '" + associatedMemberIDs + "'");
			}
			if (Operator.FormatToEmpty(codes) != "-1")
			{
				stringBuilder.Append(" AND  a.CategoryCode LIKE '" + codes + "%'");
			}
			if (Operator.FormatToEmpty(titles) != "-1")
			{
				stringBuilder.Append(" AND a.Title LIKE '%" + titles + "%'");
			}
			if (Operator.FormatToEmpty(types) != "-1")
			{
				stringBuilder.Append(" AND a.TradeType= " + types + " ");
			}
			if (Operator.FormatToEmpty(startTimes) != string.Empty)
			{
				stringBuilder.Append(" AND substring(a.ValidTime,0,10) >= '" + Operator.FilterString(startTimes) + "'");
			}
			if (Operator.FormatToEmpty(endtimes) != string.Empty)
			{
				stringBuilder.Append(" AND substring(a.ValidTime,0,10) <= '" + Operator.FilterString(endtimes) + "'");
			}
			stringBuilder.Append(" AND a.IsAudit =3");
			stringBuilder.Append(" ORDER BY a.OrderID DESC");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable SearchList(string codes, string associatedMemberIDs, string titles, string types, string startTimes, string endtimes, string isAudits, string SubstationID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("a.ID,");
			stringBuilder.Append("a.Title,");
			stringBuilder.Append("a.MemberID,");
			stringBuilder.Append("a.TradeType,");
			stringBuilder.Append("a.Description,");
			stringBuilder.Append("a.Keywords,");
			stringBuilder.Append("a.ReleaseTime,");
			stringBuilder.Append("a.ValidTime,");
			stringBuilder.Append("a.IsAudit,");
			stringBuilder.Append("a.OrderID,");
			stringBuilder.Append("a.SubstationID,");
			stringBuilder.Append("a.CategoryName,");
			stringBuilder.Append("b.Name");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_SupplyDemand as a,");
			stringBuilder.Append("ShopNum1_SupplyDemandCategory as b");
			stringBuilder.Append(" WHERE A.CategoryCode=B.Code ");
			if (Operator.FormatToEmpty(associatedMemberIDs) != "-1")
			{
				stringBuilder.Append(" AND a.MemberID= '" + associatedMemberIDs + "'");
			}
			if (Operator.FormatToEmpty(codes) != "-1")
			{
				stringBuilder.Append(" AND  a.CategoryCode LIKE '" + codes + "%'");
			}
			if (Operator.FormatToEmpty(titles) != "-1")
			{
				stringBuilder.Append(" AND a.Title LIKE '%" + titles + "%'");
			}
			if (Operator.FormatToEmpty(types) != "-1")
			{
				stringBuilder.Append(" AND a.TradeType= " + types + " ");
			}
			if (Operator.FormatToEmpty(startTimes) != string.Empty)
			{
				stringBuilder.Append(" AND substring(a.ValidTime,0,10) >= '" + Operator.FilterString(startTimes) + "'");
			}
			if (Operator.FormatToEmpty(endtimes) != string.Empty)
			{
				stringBuilder.Append(" AND substring(a.ValidTime,0,10) <= '" + Operator.FilterString(endtimes) + "'");
			}
			if (SubstationID != "-1")
			{
				stringBuilder.Append(" AND a.SubstationID = '" + SubstationID + "'");
			}
			stringBuilder.Append(" AND a.IsAudit =3");
			stringBuilder.Append(" ORDER BY a.OrderID DESC");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public int Update(string guids, string state)
		{
			ShopNum1_SupplyDemandCheck_Action.SupplyDemandCategoryTable = null;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("UPDATE ");
			stringBuilder.Append("ShopNum1_SupplyDemand");
			stringBuilder.Append(" SET ");
			stringBuilder.Append("IsAudit = " + state);
			stringBuilder.Append(" WHERE ");
			stringBuilder.Append("[ID] in (" + guids + ")");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public int Delete(string guids)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("DELETE ");
			stringBuilder.Append("FROM ");
			stringBuilder.Append("ShopNum1_SupplyDemand ");
			stringBuilder.Append("WHERE ");
			stringBuilder.Append("[ID] IN ");
			stringBuilder.Append("(" + guids + ") ");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public DataRow UpdateSearch(string guid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("Guid,");
			stringBuilder.Append("Title,");
			stringBuilder.Append("Content,");
			stringBuilder.Append("TradeType,");
			stringBuilder.Append("Description,");
			stringBuilder.Append("ReleaseTime,");
			stringBuilder.Append("Image,");
			stringBuilder.Append("Keywords,");
			stringBuilder.Append("ValidTime,");
			stringBuilder.Append("OrderID,");
			stringBuilder.Append("China315OrderID,");
			stringBuilder.Append("AssociatedCategoryGuid,");
			stringBuilder.Append("AssociatedMemberID,");
			stringBuilder.Append("IsAudit");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_SupplyDemand");
			stringBuilder.Append(" WHERE ");
			stringBuilder.Append(" Guid = " + guid);
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString()).Rows[0];
		}
		public DataTable GetList(string categoryID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("[ID],");
			stringBuilder.Append("[Name],");
			stringBuilder.Append("[code]");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_SupplyDemandCategory ");
			stringBuilder.Append(" WHERE fatherID=" + categoryID);
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public string GetMemberID(string guid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select AssociatedMemberID from  dbo.ShopNum1_SupplyDemand where guid=" + guid);
			return DatabaseExcetue.ReturnString(stringBuilder.ToString());
		}
		public DataSet SearchSupply(string perpagenum, string current_page, string supplyName, string supplyCategoryCode, string supplyAddressCode, string ordername, string isreturcount)
		{
			string text = string.Empty;
			if (supplyCategoryCode != "-1")
			{
				text = " AND A.CategoryCode like '" + Operator.FilterString(supplyCategoryCode) + "%'";
			}
			if (supplyName != "-1" && !string.IsNullOrEmpty(supplyName))
			{
				text = text + " AND A.Title LIKE '%" + Operator.FilterString(supplyName) + "%'";
			}
			if (supplyAddressCode != "-1" && supplyAddressCode != "000")
			{
				text = text + " AND A.AddressCode LIKE  '" + Operator.FilterString(supplyAddressCode) + "%'";
			}
			string[] array = new string[7];
			string[] array2 = new string[7];
			array[0] = "@perpagenum";
			array2[0] = perpagenum;
			array[1] = "@current_page";
			array2[1] = current_page;
			array[2] = "@ColumnNames";
			array2[2] = " A.ID,A.Title,A.Content,A.Description,A.Keywords,A.ReleaseTime,A.ValidTime,A.CategoryCode,A.AddressCode,A.AddressValue,A.CategoryName,A.Image,A.MemberID ";
			array[3] = "@OrderName";
			array2[3] = ordername;
			array[4] = "@searchName";
			array2[4] = text;
			array[5] = "@sDesc";
			array2[5] = "";
			array[6] = "@isReturCount";
			array2[6] = isreturcount;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_SupplySearchList", array, array2);
		}
		public DataSet SearchSupply(string perpagenum, string current_page, string supplyName, string supplyCategoryCode, string supplyAddressCode, string ordername, string isreturcount, string SubstationID)
		{
			string text = string.Empty;
			if (supplyCategoryCode != "-1")
			{
				text = " AND A.CategoryCode like '" + Operator.FilterString(supplyCategoryCode) + "%'";
			}
			if (supplyName != "-1" && !string.IsNullOrEmpty(supplyName))
			{
				text = text + " AND A.Title LIKE '%" + Operator.FilterString(supplyName) + "%'";
			}
			if (supplyAddressCode != "-1" && supplyAddressCode != "000")
			{
				text = text + " AND A.AddressCode LIKE  '" + Operator.FilterString(supplyAddressCode) + "%'";
			}
			if (SubstationID != "-1")
			{
				text = text + " AND A.SubstationID = '" + SubstationID + "'";
			}
			string[] array = new string[7];
			string[] array2 = new string[7];
			array[0] = "@perpagenum";
			array2[0] = perpagenum;
			array[1] = "@current_page";
			array2[1] = current_page;
			array[2] = "@ColumnNames";
			array2[2] = " A.ID,A.Title,A.Content,A.Description,A.Keywords,A.ReleaseTime,A.ValidTime,A.CategoryCode,A.AddressCode,A.AddressValue,A.CategoryName,A.Image,A.MemberID ";
			array[3] = "@OrderName";
			array2[3] = ordername;
			array[4] = "@searchName";
			array2[4] = text;
			array[5] = "@sDesc";
			array2[5] = "";
			array[6] = "@isReturCount";
			array2[6] = isreturcount;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_SupplySearchList", array, array2);
		}
		public DataTable GetSupplyDemandNewList(string guid, string showCount, string tradeType)
		{
			string strProcedureName = "Pro_ShopNum1_GetSupplyDemandList";
			return DatabaseExcetue.RunProcedureReturnDataTable(strProcedureName, new string[]
			{
				"@guid",
				"@showCount",
				"@tradeType"
			}, new string[]
			{
				guid,
				showCount,
				tradeType
			});
		}
		public DataTable GetSupplyDemandDetail(string guid)
		{
			string strProcedureName = "[Pro_ShopNum1_GetSupplyDemandDetail]";
			return DatabaseExcetue.RunProcedureReturnDataTable(strProcedureName, "@Guid", guid);
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
		public DataTable SearchByType(string code, string showcount)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@code";
			array2[0] = code;
			array[1] = "@showcount";
			array2[1] = showcount;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetSupplyDemandByType", array, array2);
		}
		public DataTable GetTitleByCodeRecommend(string code, string cout)
		{
			DateTime arg_05_0 = DateTime.Now;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("top (" + cout + ")  ");
			stringBuilder.Append("[Title], ");
			stringBuilder.Append("[Guid] ");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_SupplyDemand ");
			stringBuilder.Append(" WHERE AssociatedCategoryGuid like  '" + code + "%' ");
			stringBuilder.Append("AND IsRecommend = 1");
			stringBuilder.Append("AND IsAudit = 1 ");
			stringBuilder.Append("AND SUBSTRING(ValidTime,0,CHARINDEX('/',ValidTime)) > GETDATE()");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable GetTitleByCodeTrade(int TradeType, string code, string cout)
		{
			DateTime arg_05_0 = DateTime.Now;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("top (" + cout + ")  ");
			stringBuilder.Append("[Title], ");
			stringBuilder.Append("[Guid] ");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_SupplyDemand ");
			stringBuilder.Append(" WHERE AssociatedCategoryGuid like  '" + code + "%' ");
			stringBuilder.Append("AND TradeType = " + TradeType + " ");
			stringBuilder.Append("AND IsAudit = 1 ");
			stringBuilder.Append("AND SUBSTRING(ValidTime,0,CHARINDEX('/',ValidTime)) > GETDATE()");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable GetSupplyDemandDetailOnAndNext(string guid, string onSupplyDemandName, string nextSupplyDemandName)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("DECLARE @ReleaseTime datetime ");
			stringBuilder.Append("SELECT @ReleaseTime = ReleaseTime FROM ShopNum1_SupplyDemand ");
			stringBuilder.Append("WHERE ID = '" + guid + "' ");
			stringBuilder.Append("SELECT * FROM(");
			stringBuilder.Append("SELECT TOP 1 ID,Title,'" + onSupplyDemandName + "' as [Name] FROM ShopNum1_SupplyDemand ");
			stringBuilder.Append("WHERE ReleaseTime < @ReleaseTime ");
			stringBuilder.Append("ORDER BY ReleaseTime DESC");
			stringBuilder.Append(") as a ");
			stringBuilder.Append("UNION ");
			stringBuilder.Append("SELECT * FROM(");
			stringBuilder.Append("SELECT TOP 1 ID,Title,'" + nextSupplyDemandName + "' as [Name] FROM ShopNum1_SupplyDemand ");
			stringBuilder.Append("WHERE ReleaseTime > @ReleaseTime ");
			stringBuilder.Append("ORDER BY ReleaseTime ASC ");
			stringBuilder.Append(") as b");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable GetSupplyDemandNewList(string showcount)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@showcount";
			array2[0] = showcount;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetSupplyDemandNewList", array, array2);
		}
		public DataTable GetSupplyDemandRecommendList(string showcount, string TradeType)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@showcount";
			array2[0] = showcount;
			array[1] = "@TradeType";
			array2[1] = TradeType;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetSupplyDemandRecommendList", array, array2);
		}
		public DataTable Search(int fatherID, int isDeleted, string ShowCount)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"SELECT TOP  ",
				ShowCount,
				"\t[ID]\t, \tName\t, \tKeywords\t, \tDescription\t, \tOrderID\t, \tIsShow\t, \tCategoryLevel\t, \tFatherID\t, \tFamily\t, \tCode\t, \tCreateUser\t, \tCreateTime\t, \tModifyUser\t, \tModifyTime\t, \tIsDeleted  FROM ShopNum1_SupplyDemandCategory  WHERE  FatherID =",
				fatherID,
				" AND  IsDeleted =",
				isDeleted,
				" ORDER BY OrderID ASC"
			});
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable SearchByCategoryIDFrist(string CategoryCode)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT  TOP 1 ID,Title,Description,Content,TradeType,Image FROM ShopNum1_SupplyDemand where CategoryCode like  '" + CategoryCode + "%'");
			stringBuilder.Append("AND IsAudit = 3 ");
			stringBuilder.Append("AND ValidTime >= GETDATE()");
			stringBuilder.Append(" ORDER BY ReleaseTime DESC");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable SearchByCategoryIDFrist(string CategoryCode, string SubstationID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT  TOP 1 ID,Title,Description,Content,TradeType,Image FROM ShopNum1_SupplyDemand where CategoryCode like  '" + CategoryCode + "%'");
			stringBuilder.Append("AND IsAudit = 3 ");
			stringBuilder.Append("AND ValidTime >= GETDATE()");
			if (SubstationID != "-1")
			{
				stringBuilder.Append("  AND  SubstationID='" + SubstationID + "' ");
			}
			stringBuilder.Append(" ORDER BY ReleaseTime DESC");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable SearchByCategoryIDOther(string CategoryCode, string guid, string showCount)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT TOP " + showCount + " ID,Title,TradeType,Description,Content,Image, ReleaseTime ");
			stringBuilder.Append(" FROM ShopNum1_SupplyDemand ");
			stringBuilder.Append(" where CategoryCode like  '" + CategoryCode + "%'");
			stringBuilder.Append("AND IsAudit = 3  AND ValidTime >= GETDATE()   ");
			stringBuilder.Append(" ORDER BY ShopNum1_SupplyDemand.ReleaseTime DESC");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable SearchByCategoryIDOther(string CategoryCode, string guid, string showCount, string SubstationID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT TOP " + showCount + " ID,Title,TradeType,Description,Content,Image, ReleaseTime ");
			stringBuilder.Append(" FROM ShopNum1_SupplyDemand ");
			stringBuilder.Append(" where CategoryCode like  '" + CategoryCode + "%'");
			stringBuilder.Append("   AND IsAudit = 3  AND ValidTime >= GETDATE()   ");
			if (SubstationID != "-1")
			{
				stringBuilder.Append("AND   SubstationID='" + SubstationID + "' ");
			}
			stringBuilder.Append(" ORDER BY ShopNum1_SupplyDemand.ReleaseTime DESC");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public int Add(ShopNum1_SupplyDemand SupplyDemand)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_SupplyDemand( Title, Content, TradeType,Description, Keywords, ReleaseTime, ValidTime, OrderID, IsAudit, Image, AddressCode, AddressValue, IsRecommend, Tel, Email, OtherContactWay, ContactName, CategoryCode, CategoryName, SubstationID,  MemberID  ) VALUES (  '",
				Operator.FilterString(SupplyDemand.Title),
				"',  '",
				SupplyDemand.Content,
				"',  '",
				SupplyDemand.TradeType,
				"',  '",
				Operator.FilterString(SupplyDemand.Description),
				"',  '",
				Operator.FilterString(SupplyDemand.Keywords),
				"',  '",
				Operator.FilterString(SupplyDemand.ReleaseTime),
				"',  '",
				Operator.FilterString(SupplyDemand.ValidTime),
				"',  '",
				SupplyDemand.OrderID,
				"',  '",
				SupplyDemand.IsAudit,
				"',  '",
				SupplyDemand.Image,
				"',  '",
				SupplyDemand.AddressCode,
				"',  '",
				SupplyDemand.AddressValue,
				"',  '",
				Operator.FilterString(SupplyDemand.IsRecommend),
				"',  '",
				Operator.FilterString(SupplyDemand.Tel),
				"',  '",
				Operator.FilterString(SupplyDemand.Email),
				"',  '",
				Operator.FilterString(SupplyDemand.OtherContactWay),
				"',  '",
				Operator.FilterString(SupplyDemand.ContactName),
				"',  '",
				Operator.FilterString(SupplyDemand.CategoryCode),
				"',  '",
				SupplyDemand.CategoryName,
				"',  '",
				SupplyDemand.SubstationID,
				"',  '",
				SupplyDemand.MemberID,
				"' )"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
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
			array2[3] = "ShopNum1_SupplyDemand";
			array[4] = "@condition";
			array2[4] = commonModel.Condition;
			array[5] = "@ordercolumn";
			array2[5] = "ReleaseTime";
			array[6] = "@sortvalue";
			array2[6] = "desc";
			array[7] = "@resultnum";
			array2[7] = commonModel.Resultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
		public DataTable SearchByID(string ID)
		{
			string text = string.Empty;
			text = text + "     SELECT *  FROM  ShopNum1_SupplyDemand  WHERE  ID='" + ID + "'     ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int Update(ShopNum1_SupplyDemand SupplyDemand)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("UPDATE ");
			stringBuilder.Append("ShopNum1_SupplyDemand");
			stringBuilder.Append(" SET ");
			stringBuilder.Append("Title = '" + Operator.FilterString(SupplyDemand.Title) + "',");
			stringBuilder.Append("Content = '" + SupplyDemand.Content + "',");
			stringBuilder.Append("TradeType = '" + Operator.FilterString(SupplyDemand.TradeType) + "',");
			stringBuilder.Append("Description = '" + Operator.FilterString(SupplyDemand.Description) + "',");
			stringBuilder.Append("Keywords = '" + Operator.FilterString(SupplyDemand.Keywords) + "',");
			stringBuilder.Append("ValidTime = '" + Operator.FilterString(SupplyDemand.ValidTime) + "',");
			stringBuilder.Append("Image = '" + SupplyDemand.Image + "',");
			stringBuilder.Append("AddressCode = '" + Operator.FilterString(SupplyDemand.AddressCode) + "',");
			stringBuilder.Append("AddressValue = '" + SupplyDemand.AddressValue + "',");
			stringBuilder.Append("Tel = '" + Operator.FilterString(SupplyDemand.Tel) + "',");
			stringBuilder.Append("Email = '" + Operator.FilterString(SupplyDemand.Email) + "',");
			stringBuilder.Append("OtherContactWay = '" + Operator.FilterString(SupplyDemand.OtherContactWay) + "',");
			stringBuilder.Append("ContactName = '" + Operator.FilterString(SupplyDemand.ContactName) + "',");
			stringBuilder.Append("CategoryCode = '" + SupplyDemand.CategoryCode + "',");
			stringBuilder.Append("CategoryName = '" + SupplyDemand.CategoryName + "'");
			stringBuilder.Append(" WHERE ");
			stringBuilder.Append("[ID] =  '" + SupplyDemand.ID + "'   ");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public int UpdateIsAudit(string ID, int IsAudit)
		{
			string text = string.Empty;
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"     UPDATE   ShopNum1_SupplyDemand    SET   IsAudit=",
				IsAudit,
				"     WHERE  ID='",
				ID,
				"'     "
			});
			return DatabaseExcetue.RunNonQuery(text);
		}
	}
}
