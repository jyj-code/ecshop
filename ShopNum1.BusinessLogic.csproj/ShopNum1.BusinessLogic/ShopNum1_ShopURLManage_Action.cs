using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Text;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_ShopURLManage_Action : IShopNum1_ShopURLManage_Action
	{
		public int Operate(ShopNum1_ShopURLManage shopNum1_ShopURLManage)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT * FROM ShopNum1_ShopURLManage WHERE Title = '" + shopNum1_ShopURLManage.Title + "'");
			int result;
			if (DatabaseExcetue.ReturnDataTable(stringBuilder.ToString()).Rows.Count > 0)
			{
				result = this.Update(shopNum1_ShopURLManage);
			}
			else
			{
				result = this.Add(shopNum1_ShopURLManage);
			}
			return result;
		}
		public int Add(ShopNum1_ShopURLManage shopNum1_ShopURLManage)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("INSERT INTO ShopNum1_ShopURLManage(DoMain,");
			stringBuilder.Append("SiteNumber,");
			stringBuilder.Append("MemLoginID,");
			stringBuilder.Append("GoUrl)");
			stringBuilder.Append("VALUES('" + Operator.FilterString(shopNum1_ShopURLManage.DoMain) + "',");
			stringBuilder.Append("'" + Operator.FilterString(shopNum1_ShopURLManage.SiteNumber) + "',");
			stringBuilder.Append("'" + shopNum1_ShopURLManage.MemLoginID + "',");
			stringBuilder.Append("'" + shopNum1_ShopURLManage.GoUrl + "')");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public int Update(ShopNum1_ShopURLManage shopNum1_ShopURLManage)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("UPDATE ShopNum1_ShopURLManage SET DoMain = '" + shopNum1_ShopURLManage.DoMain + "',");
			stringBuilder.Append("GoUrl = '" + shopNum1_ShopURLManage.GoUrl + "'");
			stringBuilder.Append("GoUrl = '" + shopNum1_ShopURLManage.SiteNumber + "'");
			stringBuilder.Append(" WHERE Title = '" + shopNum1_ShopURLManage.Title + "'");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public int UpdateIsAudit(string strID, string isAudit)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("UPDATE ShopNum1_ShopURLManage SET ");
			stringBuilder.Append("IsAudit = " + isAudit);
			stringBuilder.Append(" WHERE ID IN (" + strID + ")");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public DataTable UpdateSearch(string agentID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT * FROM ShopNum1_ShopURLManage WHERE Title = '" + agentID + "'");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable Search(string MemLoginID, string isAudit)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT * FROM ShopNum1_ShopURLManage WHERE 0=0");
			if (Operator.FormatToEmpty(MemLoginID) != string.Empty)
			{
				stringBuilder.Append(" AND  MemLoginID = '" + MemLoginID + "'");
			}
			if (isAudit != "-1")
			{
				if (isAudit == "-2")
				{
					stringBuilder.Append(" AND  IsAudit IN (0,2) ");
				}
				else
				{
					stringBuilder.Append(" AND  IsAudit = " + isAudit);
				}
			}
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable Search(string MemLoginID, string isAudit, string SubstationID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("  SELECT A.*,B.SubstationID  FROM  ShopNum1_ShopURLManage AS A LEFT JOIN ShopNum1_ShopInfo AS B    ");
			stringBuilder.Append("  ON A.MemLoginID=B.MemLoginID WHERE 1=1     ");
			if (Operator.FormatToEmpty(MemLoginID) != string.Empty)
			{
				stringBuilder.Append(" AND  A.MemLoginID = '" + MemLoginID + "'");
			}
			if (isAudit != "-1")
			{
				if (isAudit == "-2")
				{
					stringBuilder.Append(" AND  A.IsAudit IN (0,2) ");
				}
				else
				{
					stringBuilder.Append(" AND  A.IsAudit = " + isAudit);
				}
			}
			if (SubstationID != "-1")
			{
				stringBuilder.Append(" AND    B.SubstationID='" + SubstationID + "'     ");
			}
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable Search(string shopLoginId)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT * FROM ShopNum1_ShopURLManage WHERE 0=0");
			if (Operator.FormatToEmpty(shopLoginId) != string.Empty)
			{
				stringBuilder.Append(" AND  Title like '%" + shopLoginId + "%'");
			}
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable CheckDoMain(string strDoMain)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT * FROM ShopNum1_ShopURLManage WHERE DoMain = '" + strDoMain + "'");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public int Delete(string strID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("DELETE FROM ShopNum1_ShopURLManage WHERE ID in (" + strID + ")");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public DataTable GetEditInfo(string strID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT * FROM ShopNum1_ShopURLManage WHERE ID = " + strID);
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public int Update(string strID, string strDoMain, string siteNumber)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("UPDATE ShopNum1_ShopURLManage SET DoMain = '" + Operator.FilterString(strDoMain) + "',");
			stringBuilder.Append(" IsAudit = 0,");
			stringBuilder.Append(" SiteNumber = '" + Operator.FilterString(siteNumber) + "'");
			stringBuilder.Append(" WHERE ID = " + strID);
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public DataTable GetShopLoginID(string guids)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT * FROM ShopNum1_Member WHERE Guid = '" + guids + "'");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable GetShopValidity(string shopid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT * FROM ShopNum1_Member WHERE MemLoginID = '" + shopid + "'");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable SearchByID(string string_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT * FROM ShopNum1_ShopURLManage WHERE 0=0");
			if (Operator.FormatToEmpty(string_0) != string.Empty)
			{
				stringBuilder.Append(" AND  ID in(" + string_0 + ")");
			}
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable SelectGoUrl(string domain)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT * FROM ShopNum1_ShopURLManage WHERE DoMain = '" + domain + "' AND IsAudit=1");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable UrlWriteShopDoMain(string domain)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@domain";
			array2[0] = domain;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_UrlWriteShopDoMain", array, array2);
		}
	}
}
