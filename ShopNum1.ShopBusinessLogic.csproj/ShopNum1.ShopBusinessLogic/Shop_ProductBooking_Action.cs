using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.ShopBusinessLogic
{
	public class Shop_ProductBooking_Action : IShop_ProductBooking_Action
	{
		public int AddProductBooking(ShopNum1_Shop_ProductBooking productBooking)
		{
			string[] array = new string[11];
			string[] array2 = new string[11];
			array[0] = "@name";
			array2[0] = productBooking.Name;
			array[1] = "@email";
			array2[1] = productBooking.Email;
			array[2] = "@address";
			array2[2] = productBooking.Address;
			array[3] = "@postalcode";
			array2[3] = productBooking.Postalcode;
			array[4] = "@tel";
			array2[4] = productBooking.Tel;
			array[5] = "@mobile";
			array2[5] = productBooking.Mobile;
			array[6] = "@senddate";
			array2[6] = productBooking.SendDate.ToString();
			array[7] = "@rank";
			array2[7] = productBooking.Rank;
			array[8] = "@isaudit";
			array2[8] = productBooking.IsAudit.ToString();
			array[9] = "@memloginid";
			array2[9] = productBooking.MemLoginID;
			array[10] = "@shopid";
			array2[10] = productBooking.ShopID;
			return DatabaseExcetue.RunProcedure("Pro_Shop_AddProductBooking", array, array2);
		}
		public int DeleteProductBooking(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedure("Pro_Shop_DeleteProductBooking", array, array2);
		}
		public DataTable GetProductBooking(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetProductBooking", array, array2);
		}
		public int UpdateProductBooking(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedure("Pro_Shop_UpdateProductBooking", array, array2);
		}
		public DataTable SelectProductBookingList(string shopid, string name, string isaudit, string productname)
		{
			string[] array = new string[4];
			string[] array2 = new string[4];
			array[0] = "@shopid";
			array2[0] = shopid;
			array[1] = "@name";
			array2[1] = name;
			array[2] = "@isaudit";
			array2[2] = isaudit;
			array[3] = "@productname";
			array2[3] = productname;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_SelectProductBookingList", array, array2);
		}
		public DataTable SelectProductBook_List(CommonPageModel commonModel)
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
			array2[3] = commonModel.Tablename;
			array[4] = "@condition";
			array2[4] = commonModel.Condition;
			array[5] = "@ordercolumn";
			array2[5] = "SendDate";
			array[6] = "@sortvalue";
			array2[6] = "desc";
			array[7] = "@resultnum";
			array2[7] = commonModel.Resultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
	}
}
