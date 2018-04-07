using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Text;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_WebSite_Action : IShopNum1_WebSite_Action
	{
		public bool Insert(ShopNum1_WebSite website)
		{
			string[] array = new string[4];
			string[] array2 = new string[4];
			array[0] = "@addressName";
			array2[0] = website.addressName;
			array[1] = "@addressCode";
			array2[1] = website.addressCode;
			array[2] = "@domain";
			array2[2] = website.domain;
			array[3] = "@isAvailable";
			array2[3] = website.isAvailable.ToString();
			int num = DatabaseExcetue.RunProcedure("[Pro_ShopNum1_WebSiteInsert]", array, array2);
			return num > 0;
		}
		public bool CheckAddressName(string addressname)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@addressname";
			array2[0] = addressname;
			object obj = DatabaseExcetue.ReturnProcedureString("Pro_ShopNum1_WebSiteCheckAddressName", array, array2);
			return obj != null && Convert.ToInt32(obj) >= 1;
		}
		public bool Update(ShopNum1_WebSite website)
		{
			string[] array = new string[5];
			string[] array2 = new string[5];
			array[0] = "@id";
			array2[0] = website.ID.ToString();
			array[1] = "@addressname";
			array2[1] = website.addressName;
			array[2] = "@addresscode";
			array2[2] = website.addressCode;
			array[3] = "@domain";
			array2[3] = website.domain;
			array[4] = "@isavailable";
			array2[4] = website.isAvailable.ToString();
			int num = DatabaseExcetue.RunProcedure("[Pro_ShopNum1_WebSiteUpdate]", array, array2);
			return num > 0;
		}
		public int DeleteById(string string_0)
		{
			string strSql = string.Empty;
			strSql = "delete from ShopNum1_WebSite  WHERE ID IN (" + string_0 + ") ";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable WebSiteGet(string addressCode)
		{
			string text = string.Empty;
			text = "SELECT * FROM dbo.ShopNum1_WebSite WHERE 0=0";
			if (addressCode.Trim() != "-1")
			{
				text = text + " AND addressCode='" + addressCode + "'";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetList(string categoryID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("[ID],");
			stringBuilder.Append("[Name],");
			stringBuilder.Append("[code]");
			stringBuilder.Append(" FROM ");
			stringBuilder.Append("ShopNum1_Region");
			stringBuilder.Append(" WHERE FatherID=" + categoryID);
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable GetSiteByID(string ID)
		{
			string strSql = string.Empty;
			if (ID == "0")
			{
				strSql = "SELECT * FROM dbo.ShopNum1_WebSite ";
			}
			else
			{
				strSql = "SELECT *FROM dbo.ShopNum1_WebSite WHERE ID=" + ID;
			}
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public object GetDomainByAddressName(string address)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@addressname";
			array2[0] = address;
			return DatabaseExcetue.ReturnProcedureString("Pro_ShopNum1_WebSiteGetDomainByAddress", array, array2);
		}
		public DataTable GetAllSite()
		{
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_WebSiteGet");
		}
	}
}
