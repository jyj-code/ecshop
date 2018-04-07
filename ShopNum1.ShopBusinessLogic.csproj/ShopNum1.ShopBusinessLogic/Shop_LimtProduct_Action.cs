using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.ShopBusinessLogic
{
	public class Shop_LimtProduct_Action : IShop_LimtProduct_Action
	{
		public DataTable GetLimtProdcut(string pagesize, string currentpage, string condition, string resultnum, string strLid)
		{
			string text = "select starttime,guid,name,originalImage,smallimage,shopprice,(select top 1 id from ShopNum1_Limt_Product where ProductGuid=t.guid and state=1)isget,memloginid,ProductState from shopnum1_shop_product as t where issell=1 and issaled=1 and isaudit=1";
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@pagesize";
			array2[0] = pagesize;
			array[1] = "@currentpage";
			array2[1] = currentpage;
			array[2] = "@columns";
			array2[2] = "*";
			array[3] = "@tablename";
			array2[3] = text;
			array[4] = "@condition";
			array2[4] = condition;
			array[5] = "@ordercolumn";
			array2[5] = "starttime";
			array[6] = "@sortvalue";
			array2[6] = "desc";
			array[7] = "@resultnum";
			array2[7] = resultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
		public int AddLimitProduct(ShopNum1_Limt_Product shopNum1_Limt_Product)
		{
			string text = "INSERT INTO ShopNum1_Limt_Product(ProductGuid,Lid,Discount,ShopName,MemloginID)";
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"VALUES('",
				shopNum1_Limt_Product.ProductGuid,
				"','",
				shopNum1_Limt_Product.Lid,
				"',"
			});
			object obj2 = text;
			text = string.Concat(new object[]
			{
				obj2,
				"'",
				shopNum1_Limt_Product.DisCount,
				"','",
				shopNum1_Limt_Product.ShopName,
				"','",
				shopNum1_Limt_Product.MemLoginId,
				"');"
			});
			return DatabaseExcetue.RunNonQuery(text);
		}
		public DataTable SelectLimtProdcut(string pagesize, string currentpage, string condition, string resultnum)
		{
			string text = "SELECT b.guid,A.id,name,originalImage,smallimage,shopprice,discount,lid,state,A.memloginid FROM ShopNum1_Limt_Product A \r\nINNER JOIN ShopNum1_shop_product B on a.productguid=b.guid WHERE B.starttime<getdate() AND issell=1";
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@pagesize";
			array2[0] = pagesize;
			array[1] = "@currentpage";
			array2[1] = currentpage;
			array[2] = "@columns";
			array2[2] = "*";
			array[3] = "@tablename";
			array2[3] = text;
			array[4] = "@condition";
			array2[4] = condition;
			array[5] = "@ordercolumn";
			array2[5] = "id";
			array[6] = "@sortvalue";
			array2[6] = "desc";
			array[7] = "@resultnum";
			array2[7] = resultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
		public int UpdateDisCount(string strDisCount, string strId)
		{
			string strSql = string.Concat(new string[]
			{
				"UPDATE ShopNum1_Limt_Product SET DISCOUNT='",
				strDisCount,
				"' WHERE Id='",
				strId,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int DeleteLimitProduct(string strId)
		{
			string strSql = "DELETE FROM ShopNum1_Limt_Product WHERE ID='" + strId + "'";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int UpdateLimitProductStae(string strId, string strState)
		{
			string strSql = string.Concat(new string[]
			{
				"UPDATE ShopNum1_Limt_Product SET state='",
				strState,
				"' WHERE Id='",
				strId,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
	}
}
