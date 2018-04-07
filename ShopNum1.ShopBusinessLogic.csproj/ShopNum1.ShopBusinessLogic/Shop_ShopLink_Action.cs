using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.ShopBusinessLogic
{
	public class Shop_ShopLink_Action : IShop_ShopLink_Action
	{
		public int Add(ShopNum1_Shop_Link shopNum1_Shop_Link)
		{
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@guid";
			array2[0] = shopNum1_Shop_Link.Guid.ToString();
			array[1] = "@shopname";
			array2[1] = shopNum1_Shop_Link.ShopName;
			array[2] = "@shopurl";
			array2[2] = shopNum1_Shop_Link.ShopUrl;
			array[3] = "@shopmemloginid";
			array2[3] = shopNum1_Shop_Link.ShopMemLoginID;
			array[4] = "@memloginid";
			array2[4] = shopNum1_Shop_Link.MemLoginID;
			array[5] = "@note";
			array2[5] = shopNum1_Shop_Link.Note;
			array[6] = "@isshow";
			array2[6] = shopNum1_Shop_Link.IsShow.ToString();
			array[7] = "@createtime";
			array2[7] = shopNum1_Shop_Link.CreateTime.ToString();
			return DatabaseExcetue.RunProcedure("Pro_AddShop_ShopLink", array, array2);
		}
		public DataTable Edit(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_EditShop_ShopLink", array, array2);
		}
		public int Updata(ShopNum1_Shop_Link shopNum1_Shop_Link)
		{
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@guid";
			array2[0] = shopNum1_Shop_Link.Guid.ToString();
			array[1] = "@shopname";
			array2[1] = shopNum1_Shop_Link.ShopName;
			array[2] = "@shopurl";
			array2[2] = shopNum1_Shop_Link.ShopUrl;
			array[3] = "@shopmemloginid";
			array2[3] = shopNum1_Shop_Link.ShopMemLoginID;
			array[4] = "@memloginid";
			array2[4] = shopNum1_Shop_Link.MemLoginID;
			array[5] = "@note";
			array2[5] = shopNum1_Shop_Link.Note;
			array[6] = "@isshow";
			array2[6] = shopNum1_Shop_Link.IsShow.ToString();
			array[7] = "@modifytime";
			array2[7] = shopNum1_Shop_Link.ModifyTime.ToString();
			return DatabaseExcetue.RunProcedure("Pro_UpdataShop_ShopLink", array, array2);
		}
		public int Delete(string guids)
		{
			string strSql = string.Empty;
			strSql = "delete from dbo.ShopNum1_Shop_Link where guid in(" + guids + ")";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable Search(string showCount)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@showCount";
			array2[0] = showCount;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_SerachShop_ShopLink", array, array2);
		}
		public DataTable GetAllShopMemLoginID()
		{
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetAllShopMemLoginID");
		}
		public DataTable CheckMemLoginID(string memLoginID)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@memLoginID";
			array2[0] = memLoginID;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_CheckShopMemLoginID", array, array2);
		}
		public DataTable Show(string MemLoginID, string showCount)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@showCount";
			array2[0] = showCount;
			array[1] = "@memLoginID";
			array2[1] = MemLoginID;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_ShopLinkShow", array, array2);
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
			array2[2] = " *,(select shopurl from shopnum1_shopinfo where memloginid=ShopNum1_Shop_Link.ShopMemLoginID)vshopurl ";
			array[3] = "@tablename";
			array2[3] = "ShopNum1_Shop_Link";
			array[4] = "@condition";
			array2[4] = commonModel.Condition;
			array[5] = "@ordercolumn";
			array2[5] = "ModifyTime";
			array[6] = "@sortvalue";
			array2[6] = "desc";
			array[7] = "@resultnum";
			array2[7] = commonModel.Resultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
	}
}
