using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Text;
namespace ShopNum1.ShopBusinessLogic
{
	public class Shop_CategoryInfo_Action : IShop_CategoryInfo_Action
	{
		public DataTable Search(string commerceMemLoginID, string IsAudit)
		{
			string text = string.Empty;
			text = "SELECT \ta.Guid\t, \ta.Title\t, \ta.Type\t, \ta.Content\t, \ta.Keywords\t, \ta.ValidTime\t, \ta.CreateTime\t, \ta.Tel, \ta.Email\t, \ta.OtherContactWay\t, \ta.IsAudit\t, \ta.AssociatedCategoryGuid\t, \ta.AssociatedMemberID\t, \ta.IsAudit, \tb.Name\tFROM \tShopNum1_CategoryInfo as a, \tShopNum1_Category as b WHERE   a.AssociatedCategoryGuid =b.Code and a.AssociatedMemberID = '" + commerceMemLoginID + "'";
			if (IsAudit != "-1")
			{
				text = text + "and a.IsAudit = " + IsAudit;
			}
			text += "ORDER BY a.Guid DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int Delete(string guid)
		{
			string strSql = "DELETE FROM ShopNum1_CategoryInfo WHERE [Guid] in (" + guid + ")";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Insert(ShopNum1_CategoryInfo shopNum1_CategoryInfo)
		{
			string addressCode = this.GetAddressCode(shopNum1_CategoryInfo.AssociatedMemberID);
			string memberType = this.GetMemberType(shopNum1_CategoryInfo.AssociatedMemberID);
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("INSERT INTO ShopNum1_CategoryInfo(");
			stringBuilder.Append("Guid,");
			stringBuilder.Append("Title,");
			stringBuilder.Append("Type,");
			stringBuilder.Append("Content,");
			stringBuilder.Append("Keywords,");
			stringBuilder.Append("ValidTime,");
			stringBuilder.Append("CreateTime,");
			stringBuilder.Append("Tel,");
			stringBuilder.Append("Email,");
			stringBuilder.Append("OtherContactWay,");
			stringBuilder.Append("AssociatedCategoryGuid,");
			stringBuilder.Append("AssociatedCategoryName,");
			stringBuilder.Append("AddressCode,");
			stringBuilder.Append("AddressValue,");
			stringBuilder.Append("MemberType,");
			stringBuilder.Append("AssociatedMemberID)");
			stringBuilder.Append(" VALUES(");
			stringBuilder.Append("'" + shopNum1_CategoryInfo.Guid + "',");
			stringBuilder.Append("'" + shopNum1_CategoryInfo.Title + "',");
			stringBuilder.Append("'" + shopNum1_CategoryInfo.Type + "',");
			stringBuilder.Append("'" + shopNum1_CategoryInfo.Content + "',");
			stringBuilder.Append("'" + shopNum1_CategoryInfo.Keywords + "',");
			stringBuilder.Append("'" + shopNum1_CategoryInfo.ValidTime + "',");
			stringBuilder.Append("'" + DateTime.Now.ToString() + "',");
			stringBuilder.Append("'" + shopNum1_CategoryInfo.Tel + "',");
			stringBuilder.Append("'" + shopNum1_CategoryInfo.Email + "',");
			stringBuilder.Append("'" + shopNum1_CategoryInfo.OtherContactWay + "',");
			stringBuilder.Append(shopNum1_CategoryInfo.AssociatedCategoryGuid + ",");
			stringBuilder.Append(shopNum1_CategoryInfo.AssociatedCategoryName + ",");
			stringBuilder.Append("'" + addressCode + "',");
			stringBuilder.Append("'" + this.GetAddressValue(addressCode) + "',");
			stringBuilder.Append("'" + memberType + "',");
			stringBuilder.Append("'" + shopNum1_CategoryInfo.AssociatedMemberID + "')");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public int InsertAdd(ShopNum1_CategoryInfo shopNum1_CategoryInfo)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("INSERT INTO ShopNum1_CategoryInfo(");
			stringBuilder.Append("Guid,");
			stringBuilder.Append("Title,");
			stringBuilder.Append("Type,");
			stringBuilder.Append("Content,");
			stringBuilder.Append("Keywords,");
			stringBuilder.Append("Description,");
			stringBuilder.Append("ValidTime,");
			stringBuilder.Append("Tel,");
			stringBuilder.Append("IsAudit,");
			stringBuilder.Append("Email,");
			stringBuilder.Append("OtherContactWay,");
			stringBuilder.Append("AssociatedCategoryGuid,");
			stringBuilder.Append("AssociatedCategoryName,");
			stringBuilder.Append("AddressCode,");
			stringBuilder.Append("AddressValue,");
			stringBuilder.Append("AssociatedMemberID)");
			stringBuilder.Append(" VALUES(");
			stringBuilder.Append("'" + shopNum1_CategoryInfo.Guid + "',");
			stringBuilder.Append("'" + shopNum1_CategoryInfo.Title + "',");
			stringBuilder.Append("'" + shopNum1_CategoryInfo.Type + "',");
			stringBuilder.Append("'" + shopNum1_CategoryInfo.Content + "',");
			stringBuilder.Append("'" + shopNum1_CategoryInfo.Keywords + "',");
			stringBuilder.Append("'" + shopNum1_CategoryInfo.Description + "',");
			stringBuilder.Append("'" + shopNum1_CategoryInfo.ValidTime + "',");
			stringBuilder.Append("'" + shopNum1_CategoryInfo.Tel + "',");
			stringBuilder.Append(shopNum1_CategoryInfo.IsAudit + ",");
			stringBuilder.Append("'" + shopNum1_CategoryInfo.Email + "',");
			stringBuilder.Append("'" + shopNum1_CategoryInfo.OtherContactWay + "',");
			stringBuilder.Append("'" + shopNum1_CategoryInfo.AssociatedCategoryGuid + "',");
			stringBuilder.Append("'" + shopNum1_CategoryInfo.AssociatedCategoryName + "',");
			stringBuilder.Append("'" + shopNum1_CategoryInfo.AddressCode + "',");
			stringBuilder.Append("'" + shopNum1_CategoryInfo.AddressValue + "',");
			stringBuilder.Append("'" + shopNum1_CategoryInfo.AssociatedMemberID + "')");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public int Update(ShopNum1_CategoryInfo shopNum1_CategoryInfo)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("UPDATE ShopNum1_CategoryInfo");
			stringBuilder.Append(" SET ");
			stringBuilder.Append("Title = '" + shopNum1_CategoryInfo.Title + "',");
			stringBuilder.Append("Type = '" + shopNum1_CategoryInfo.Type + "',");
			stringBuilder.Append("Content = '" + shopNum1_CategoryInfo.Content + "',");
			stringBuilder.Append("Keywords = '" + shopNum1_CategoryInfo.Keywords + "',");
			stringBuilder.Append("Description = '" + shopNum1_CategoryInfo.Description + "',");
			stringBuilder.Append("ValidTime = '" + shopNum1_CategoryInfo.ValidTime + "',");
			stringBuilder.Append("AddressCode = '" + shopNum1_CategoryInfo.AddressCode + "',");
			stringBuilder.Append("AddressValue = '" + shopNum1_CategoryInfo.AddressValue + "',");
			stringBuilder.Append("Tel = '" + shopNum1_CategoryInfo.Tel + "',");
			stringBuilder.Append("IsAudit = " + shopNum1_CategoryInfo.IsAudit + ",");
			stringBuilder.Append("Email = '" + shopNum1_CategoryInfo.Email + "',");
			stringBuilder.Append("OtherContactWay = '" + shopNum1_CategoryInfo.OtherContactWay + "',");
			stringBuilder.Append("AssociatedCategoryName = '" + shopNum1_CategoryInfo.AssociatedCategoryName + "',");
			stringBuilder.Append("AssociatedCategoryGuid = '" + shopNum1_CategoryInfo.AssociatedCategoryGuid + "'");
			stringBuilder.Append(" WHERE ");
			stringBuilder.Append(" Guid = '" + shopNum1_CategoryInfo.Guid + "'");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public DataRow UpdateSearch(string guid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("a.Guid,");
			stringBuilder.Append("a.Title,");
			stringBuilder.Append("a.Type,");
			stringBuilder.Append("a.Content,");
			stringBuilder.Append("a.Keywords,");
			stringBuilder.Append("a.Description,");
			stringBuilder.Append("a.ValidTime,");
			stringBuilder.Append("a.CreateTime,");
			stringBuilder.Append("a.AssociatedMemberID,");
			stringBuilder.Append("a.AddressCode,");
			stringBuilder.Append("a.Tel,");
			stringBuilder.Append("a.Email,");
			stringBuilder.Append("a.OtherContactWay,");
			stringBuilder.Append("a.AssociatedCategoryGuid,");
			stringBuilder.Append("b.Name");
			stringBuilder.Append(" FROM ShopNum1_CategoryInfo as a,");
			stringBuilder.Append("ShopNum1_Category as b");
			stringBuilder.Append(" WHERE Guid = '" + guid + "'");
			stringBuilder.Append(" and a.AssociatedCategoryGuid = b.code");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString()).Rows[0];
		}
		public string GetAddressValue(string addressCode)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("AddressValue ");
			stringBuilder.Append("FROM ");
			stringBuilder.Append("ShopNum1_Member ");
			stringBuilder.Append("WHERE ");
			stringBuilder.Append("AddressCode = '" + addressCode + "'");
			if (DatabaseExcetue.ReturnDataTable(stringBuilder.ToString()).Rows.Count > 0)
			{
				return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString()).Rows[0][0].ToString();
			}
			return "-1";
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
			if (DatabaseExcetue.ReturnDataTable(stringBuilder.ToString()).Rows.Count > 0)
			{
				return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString()).Rows[0][0].ToString();
			}
			return "-1";
		}
		public string GetMemberType(string memLoginID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("MemberType ");
			stringBuilder.Append("FROM ");
			stringBuilder.Append("ShopNum1_Member ");
			stringBuilder.Append("WHERE ");
			stringBuilder.Append("MemLoginID = '" + memLoginID + "'");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString()).Rows[0][0].ToString();
		}
		public DataTable CategoryCommentList(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_CategoryCommentList", array, array2);
		}
		public DataTable CategoryInfoDetail(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_CategoryInfoDetail", array, array2);
		}
	}
}
