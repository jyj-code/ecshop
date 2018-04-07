using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.ShopBusinessLogic
{
	public class Shop_NewsCategory_Action : IShop_NewsCategory_Action
	{
		public int AddNewsCategory(ShopNum1_Shop_NewsCategory shop_NewsCategory)
		{
			string[] array = new string[6];
			string[] array2 = new string[6];
			array[0] = "@name";
			array2[0] = shop_NewsCategory.Name;
			array[1] = "@keywords";
			array2[1] = shop_NewsCategory.Keywords;
			array[2] = "@description";
			array2[2] = shop_NewsCategory.Description;
			array[3] = "@orderid";
			array2[3] = shop_NewsCategory.OrderID.ToString();
			array[4] = "@isshow";
			array2[4] = shop_NewsCategory.IsShow.ToString();
			array[5] = "@memloginid";
			array2[5] = shop_NewsCategory.MemLoginID;
			return DatabaseExcetue.RunProcedure("Pro_Shop_AddNewsCategory", array, array2);
		}
		public DataTable GetNewsCategoryList(string memloginid, string isshow)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@memloginid";
			array2[0] = memloginid;
			array[1] = "@isshow";
			array2[1] = isshow;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetNewsCategoryList", array, array2);
		}
		public int UpdateNewsCategory(ShopNum1_Shop_NewsCategory shop_NewsCategory)
		{
			string[] array = new string[6];
			string[] array2 = new string[6];
			array[0] = "@guid";
			array2[0] = shop_NewsCategory.Guid.ToString();
			array[1] = "@name";
			array2[1] = shop_NewsCategory.Name;
			array[2] = "@keywords";
			array2[2] = shop_NewsCategory.Keywords;
			array[3] = "@description";
			array2[3] = shop_NewsCategory.Description;
			array[4] = "@orderid";
			array2[4] = shop_NewsCategory.OrderID.ToString();
			array[5] = "@isshow";
			array2[5] = shop_NewsCategory.IsShow.ToString();
			return DatabaseExcetue.RunProcedure("Pro_Shop_UpdateNewsCategory", array, array2);
		}
		public int DeleteNewsCategory(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedure("Pro_Shop_DeleteNewsCategory", array, array2);
		}
		public DataTable GetNewsCategory(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetNewsCategory", array, array2);
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
			array2[3] = "ShopNum1_Shop_NewsCategory";
			array[4] = "@condition";
			array2[4] = commonModel.Condition;
			array[5] = "@ordercolumn";
			array2[5] = "OrderID";
			array[6] = "@sortvalue";
			array2[6] = "desc";
			array[7] = "@resultnum";
			array2[7] = commonModel.Resultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
	}
}
