using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.ShopBusinessLogic
{
	public class Shop_Collect_Action : IShop_Collect_Action
	{
		public int AddProductCollect(string memloginid, string productguid, string shopID, string isAttention, string shopPrice, string productName, string sellLoginID)
		{
			string[] array = new string[7];
			string[] array2 = new string[7];
			array[0] = "@memloginid";
			array2[0] = memloginid;
			array[1] = "@productguid";
			array2[1] = productguid;
			array[2] = "@shopID";
			array2[2] = shopID;
			array[3] = "@isAttention";
			array2[3] = isAttention;
			array[4] = "@shopPrice";
			array2[4] = shopPrice;
			array[5] = "@productName";
			array2[5] = productName;
			array[6] = "@sellLoginID";
			array2[6] = sellLoginID;
			return DatabaseExcetue.RunProcedure("Pro_ShopNum1_AddProductCollect", array, array2);
		}
		public int AddShopCollect(string memloginid, string shopid)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@memloginid";
			array2[0] = memloginid;
			array[1] = "@shopid";
			array2[1] = shopid;
			return DatabaseExcetue.RunProcedure("Pro_ShopNum1_AddShopCollect", array, array2);
		}
		public int ProductCollectNum(string guid)
		{
			string strSql = string.Empty;
			strSql = "UPDATE  ShopNum1_Shop_Product SET  CollectCount=CollectCount+1  WHERE Guid='" + guid + "' ";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int ShopCollectNum(string memLoginID)
		{
			string strSql = string.Empty;
			strSql = "UPDATE  ShopNum1_ShopInfo SET  CollectCount=CollectCount+1  WHERE MemLoginID='" + memLoginID + "' ";
			return DatabaseExcetue.RunNonQuery(strSql);
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
			array2[2] = " Guid,MemLoginID,ShopID,CollectTime ";
			array[3] = "@tablename";
			array2[3] = "ShopNum1_ShopCollect";
			array[4] = "@condition";
			array2[4] = commonModel.Condition;
			array[5] = "@ordercolumn";
			array2[5] = "CollectTime";
			array[6] = "@sortvalue";
			array2[6] = "desc";
			array[7] = "@resultnum";
			array2[7] = commonModel.Resultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
		public DataTable Select_ListMemberProductCollect(CommonPageModel commonModel)
		{
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@pagesize";
			array2[0] = commonModel.PageSize;
			array[1] = "@currentpage";
			array2[1] = commonModel.Currentpage;
			array[2] = "@columns";
			array2[2] = " Guid,ProductName,ProductGuid,ShopPrice,ShopID,MemLoginID,CollectTime,IsAttention,IsDeleted,SellLoginID ";
			array[3] = "@tablename";
			array2[3] = "ShopNum1_MemberProductCollect";
			array[4] = "@condition";
			array2[4] = commonModel.Condition;
			array[5] = "@ordercolumn";
			array2[5] = "CollectTime";
			array[6] = "@sortvalue";
			array2[6] = "desc";
			array[7] = "@resultnum";
			array2[7] = commonModel.Resultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
	}
}
