using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Text;
namespace ShopNum1.ShopBusinessLogic
{
	public class Shop_SupplyDemand_Action : IShop_SupplyDemand_Action
	{
		public DataTable Search(string commerceMemLoginID, string IsAudit)
		{
			string text = string.Empty;
			text = "SELECT \ta.Guid\t, \ta.Title\t, \ta.Content\t, \ta.TradeType\t, \ta.Description\t, \ta.Keywords\t, \ta.ReleaseTime\t, \ta.ValidTime\t, \ta.OrderID\t, \ta.Image\t, \ta.ShopNum1OrderID\t, \ta.AssociatedCategoryGuid\t, \ta.AssociatedMemberID\t, \ta.IsAudit, \tb.Name \tFROM \tShopNum1_SupplyDemand as a, \tShopNum1_SupplyDemandCategory  as b WHERE   a.AssociatedCategoryGuid = b.Code and a.AssociatedMemberID = '" + commerceMemLoginID + "'";
			if (IsAudit != "-1")
			{
				text = text + "and a.IsAudit = " + IsAudit;
			}
			text += "ORDER BY a.Guid DESC ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataRow UpdateSearch(string guid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("  *   ");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_SupplyDemand");
			stringBuilder.Append(" WHERE ");
			stringBuilder.Append(" ID = '" + guid + "'");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString()).Rows[0];
		}
		public int Delete(string guid)
		{
			string strSql = "DELETE FROM ShopNum1_SupplyDemand WHERE ID in(" + guid + ")";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public string GetAddressValue(string shopid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("AddressValue ");
			stringBuilder.Append("FROM ");
			stringBuilder.Append("ShopNum1_Member ");
			stringBuilder.Append("WHERE ");
			stringBuilder.Append("MemLoginID = '" + shopid + "'");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString()).Rows[0][0].ToString();
		}
		public string GetAddressCode(string commerceMemLoginID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("AddressCode ");
			stringBuilder.Append("FROM ");
			stringBuilder.Append("ShopNum1_Member ");
			stringBuilder.Append("WHERE ");
			stringBuilder.Append("MemLoginID = '" + commerceMemLoginID + "'");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString()).Rows[0][0].ToString();
		}
		public int SupplyDemandCommentAdd(ShopNum1_SupplyDemandComment supplyDemandComment)
		{
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@title";
			array2[0] = supplyDemandComment.Title;
			array[1] = "@content";
			array2[1] = supplyDemandComment.Content;
			array[2] = "@createtime";
			array2[2] = supplyDemandComment.CreateTime.ToString();
			array[3] = "@createmerber";
			array2[3] = supplyDemandComment.CreateMerber;
			array[4] = "@createip";
			array2[4] = supplyDemandComment.CreateIP;
			array[5] = "@supplydemandguid";
			array2[5] = supplyDemandComment.SupplyDemandGuid.ToString();
			array[6] = "@associatememberid";
			array2[6] = supplyDemandComment.AssociateMemberID;
			array[7] = "@isaudit";
			array2[7] = supplyDemandComment.IsAudit.ToString();
			return DatabaseExcetue.RunProcedure("Pro_ShopNum1_SupplyDemandCommentAdd", array, array2);
		}
		public DataTable SupplyDemandCommentList(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SupplyDemandCommentList", array, array2);
		}
		public DataTable SupplyDemandDetail(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SupplyDemandDetail", array, array2);
		}
		public DataTable GetSupplyDemandMeto(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetSupplyDemandMeto", array, array2);
		}
	}
}
