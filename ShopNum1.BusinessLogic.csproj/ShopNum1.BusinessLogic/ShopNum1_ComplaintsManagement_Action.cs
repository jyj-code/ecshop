using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_ComplaintsManagement_Action : IShopNum1_ComplaintsManagement_Action
	{
		public DataTable GetShopNum1_ComplaintsReply(string guid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("Guid,");
			stringBuilder.Append("ReplayContent,");
			stringBuilder.Append("RepalyTime ");
			stringBuilder.Append("FROM ShopNum1_ComplaintsReply ");
			stringBuilder.Append(" WHERE ComplaintsManagementGuid =" + guid);
			stringBuilder.Append(" ORDER BY RepalyTime DESC");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable Search(string memLoginID, string type)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("ID,");
			stringBuilder.Append("ShopProductID,");
			stringBuilder.Append("ReportShop,");
			stringBuilder.Append("MemLoginID,");
			stringBuilder.Append("ReportType,");
			stringBuilder.Append("Evidence,");
			stringBuilder.Append("ComplaintContent,");
			stringBuilder.Append("ReportTime,");
			stringBuilder.Append("CustomerMessage,");
			stringBuilder.Append("ProcessingTime,");
			stringBuilder.Append("ProcessingStatus,");
			stringBuilder.Append("ProcessingResults ");
			stringBuilder.Append("FROM ShopNum1_MemberReport WHERE 1=1");
			if (!string.IsNullOrEmpty(memLoginID))
			{
				stringBuilder.Append(" AND MemLoginID LIKE '%" + memLoginID + "%'");
			}
			if (type != "-1")
			{
				stringBuilder.Append(" AND ReportType ='" + type + " ' ");
			}
			stringBuilder.Append(" ORDER BY ReportTime DESC");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public int ComplaintsResult(string guid, string resultes)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("UPDATE ShopNum1_ComplaintsManagement SET ");
			stringBuilder.Append("ProcessingState=1,");
			stringBuilder.Append("ProcessingResult='" + Operator.FilterString(resultes) + "' ");
			stringBuilder.Append(" WHERE Guid=" + guid);
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public int Delete(string guid)
		{
			List<string> list = new List<string>();
			string item = "delete form  dbo.ShopNum1_ComplaintsManagement where guid in(" + guid + ")";
			string item2 = "delete form  dbo.ShopNum1_ComplaintsReply where ComplaintsManagementGuid in(" + guid + ")";
			list.Add(item);
			list.Add(item2);
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
		public int DeleteReport(string ID)
		{
			List<string> list = new List<string>();
			string item = "delete from  ShopNum1_MemberReport where ID IN (" + ID + ")";
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
		public int AddComplaintsManagement(string productguid, string shopid, string memloginid, string reporttype, string evidence, string remark)
		{
			string[] array = new string[6];
			string[] array2 = new string[6];
			array[0] = "@productguid";
			array2[0] = productguid;
			array[1] = "@shopid";
			array2[1] = shopid;
			array[2] = "@memloginid";
			array2[2] = memloginid;
			array[3] = "@reporttype";
			array2[3] = reporttype;
			array[4] = "@evidence";
			array2[4] = evidence;
			array[5] = "@remark";
			array2[5] = remark;
			return DatabaseExcetue.RunProcedure("Pro_ShopNum1_AddComplaintsManagement", array, array2);
		}
		public DataTable GetComplaintsManagement(string memloginid, string type)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@memloginid";
			array2[0] = memloginid;
			array[1] = "@type";
			array2[1] = type;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetComplaintsManagement", array, array2);
		}
		public DataSet GetComplaintsManagementDetail(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_GetComplaintsManagementDetail", array, array2);
		}
		public DataTable GetProductNamebyguid(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetProductNamebyguid", array, array2);
		}
	}
}
