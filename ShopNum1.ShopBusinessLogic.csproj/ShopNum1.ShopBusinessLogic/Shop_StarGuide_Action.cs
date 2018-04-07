using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.ShopBusinessLogic
{
	public class Shop_StarGuide_Action : IShop_StarGuide_Action
	{
		public int AddStarGuide(ShopNum1_Shop_StarGuide starGuide)
		{
			string[] array = new string[5];
			string[] array2 = new string[5];
			array[0] = "@name";
			array2[0] = starGuide.Name;
			array[1] = "@imagepath";
			array2[1] = starGuide.ImagePath;
			array[2] = "@orderid";
			array2[2] = starGuide.OrderID.ToString();
			array[3] = "@remark";
			array2[3] = starGuide.Remark;
			array[4] = "@memloginid";
			array2[4] = starGuide.MemLoginID;
			return DatabaseExcetue.RunProcedure("Pro_Shop_AddStarGuide", array, array2);
		}
		public DataTable GetStarGuide(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetStarGuide", array, array2);
		}
		public int UpdateStarGuide(ShopNum1_Shop_StarGuide starGuide)
		{
			string[] array = new string[5];
			string[] array2 = new string[5];
			array[0] = "@guid";
			array2[0] = starGuide.Guid.ToString();
			array[1] = "@name";
			array2[1] = starGuide.Name;
			array[2] = "@imagepath";
			array2[2] = starGuide.ImagePath;
			array[3] = "@orderid";
			array2[3] = starGuide.OrderID.ToString();
			array[4] = "@remark";
			array2[4] = starGuide.Remark;
			return DatabaseExcetue.RunProcedure("Pro_Shop_UpdateStarGuide", array, array2);
		}
		public int DeleteStarGuide(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedure("Pro_Shop_DeleteStarGuide", array, array2);
		}
		public DataTable GetStarGuideList(string memloginid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@memloginid";
			array2[0] = memloginid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetStarGuideList", array, array2);
		}
	}
}
