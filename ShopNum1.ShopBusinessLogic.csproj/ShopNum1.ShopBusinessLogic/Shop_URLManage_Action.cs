using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.ShopBusinessLogic
{
	public class Shop_URLManage_Action : IShop_URLManage_Action
	{
		public int AddURLManage(ShopNum1_ShopURLManage shopURLManage)
		{
			string[] array = new string[5];
			string[] array2 = new string[5];
			array[0] = "@Domain";
			array2[0] = shopURLManage.DoMain;
			array[1] = "@MemLoginID";
			array2[1] = shopURLManage.MemLoginID;
			array[2] = "@IsAudit";
			array2[2] = shopURLManage.IsAudit.ToString();
			array[3] = "@GoUrl";
			array2[3] = shopURLManage.GoUrl;
			array[4] = "@SiteNumber";
			array2[4] = shopURLManage.SiteNumber;
			return DatabaseExcetue.RunProcedure("Pro_Shop_AddURLManage", array, array2);
		}
		public DataTable GetUrlManage(string string_0)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@id";
			array2[0] = string_0;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetURLManage", array, array2);
		}
		public int UpdateURLManage(ShopNum1_ShopURLManage shopNum1_ShopURLManage)
		{
			string[] array = new string[4];
			string[] array2 = new string[4];
			array[0] = "@id";
			array2[0] = shopNum1_ShopURLManage.ID.ToString();
			array[1] = "@domain";
			array2[1] = shopNum1_ShopURLManage.DoMain;
			array[2] = "@isaudit";
			array2[2] = shopNum1_ShopURLManage.IsAudit.ToString();
			array[3] = "@SiteNumber";
			array2[3] = shopNum1_ShopURLManage.SiteNumber;
			return DatabaseExcetue.RunProcedure("Pro_Shop_UpdateURLManage", array, array2);
		}
		public int DeleteURLManage(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@id";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedure("Pro_Shop_DeleteURLManage", array, array2);
		}
		public DataTable GetUrlManageList(string memLoginID, string isaudit)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@MemLoginID";
			array2[0] = memLoginID;
			array[1] = "@isaudit";
			array2[1] = isaudit;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetURLManageList", array, array2);
		}
		public DataTable CheckURLManageByDoMain(string domain)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@domain";
			array2[0] = domain;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_CheckURLManageByDoMain", array, array2);
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
			array2[3] = "ShopNum1_ShopURLManage";
			array[4] = "@condition";
			array2[4] = commonModel.Condition;
			array[5] = "@ordercolumn";
			array2[5] = "AddTime";
			array[6] = "@sortvalue";
			array2[6] = "desc";
			array[7] = "@resultnum";
			array2[7] = commonModel.Resultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
		public DataTable GetEditInfo(string ID)
		{
			string strSql = string.Empty;
			strSql = "    SELECT * FROM ShopNum1_ShopURLManage  WHERE  ID  ='" + ID.Replace("'", "") + "'        ";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
	}
}
