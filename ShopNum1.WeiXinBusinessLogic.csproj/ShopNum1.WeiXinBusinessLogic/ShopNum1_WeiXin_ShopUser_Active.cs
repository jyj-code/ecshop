using ShopNum1.DataAccess;
using ShopNum1.WeiXinInterface;
using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.WeiXinBusinessLogic
{
	public class ShopNum1_WeiXin_ShopUser_Active : IShopNum1_WeiXin_ShopUser_Active
	{
		public int AddWeiXinHao(ShopNum1_WeiXin_ShopUser ShopUser)
		{
			string text = "INSERT INTO ShopNum1_WeiXin_ShopUser(TwoDimensionalPic,WeiXinName,PublicNo,ShopLoginID,CreateTime,ModifyTime,ShopPic";
			text += ")";
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"VALUES('",
				ShopUser.TwoDimensionalPic,
				"','",
				ShopUser.WeiXinName,
				"','",
				ShopUser.PublicNo,
				"','",
				ShopUser.ShopLoginID,
				"','",
				ShopUser.CreateTime,
				"','",
				ShopUser.ModifyTime,
				"','",
				ShopUser.ShopPic,
				"')"
			});
			return DatabaseExcetue.RunNonQuery(text.ToString());
		}
		public int UpdateWeiXinHao(ShopNum1_WeiXin_ShopUser ShopUser)
		{
			string text = "UPDATE ShopNum1_WeiXin_ShopUser SET TwoDimensionalPic='" + ShopUser.TwoDimensionalPic + "',";
			text = text + "WeiXinName='" + ShopUser.WeiXinName + "',";
			text = text + "PublicNo='" + ShopUser.PublicNo + "',";
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"CreateTime='",
				ShopUser.CreateTime,
				"',"
			});
			obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"ModifyTime='",
				ShopUser.ModifyTime,
				"',"
			});
			text = text + "ShopPic='" + ShopUser.ShopPic + "'";
			text = text + " WHERE ShopLoginID='" + ShopUser.ShopLoginID + "'";
			return DatabaseExcetue.RunNonQuery(text.ToString());
		}
		public DataTable SelectWeiXinHao(string shoploginid)
		{
			string text = "SELECT * FROM ShopNum1_WeiXin_ShopUser  WHERE ShopLoginID='" + shoploginid + "'";
			return DatabaseExcetue.ReturnDataTable(text.ToString());
		}
		public DataTable SelectWeiXinStore(string pagesize, string pageid, string resultnum, string condition, string ordercolumn, string sortvalue)
		{
			string text = "select A.*,B.clickcount,B.shopreputation,B.ShopCategoryId,B.addresscode,B.OrderID,B.ShopName,\r\n(select sum(salenumber) from shopnum1_shop_product where memloginid=A.shoploginid)salenumber,B.Isweixin,B.isclose from ShopNum1_WeiXin_ShopUser A\r\n inner join ShopNum1_ShopInfo B ON B.memloginid=A.shoploginid ";
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@pagesize";
			array2[0] = pagesize;
			array[1] = "@currentpage";
			array2[1] = pageid;
			array[2] = "@columns";
			array2[2] = " TwoDimensionalPic,WeiXinName,PublicNo,ShopLoginID,ShopName,CreateTime,ModifyTime,clickcount,shopreputation,ShopCategoryId,addresscode,ShopPic,Isweixin,isclose ";
			array[3] = "@tablename";
			array2[3] = text;
			array[4] = "@condition";
			array2[4] = condition;
			array[5] = "@ordercolumn";
			array2[5] = ordercolumn;
			array[6] = "@sortvalue";
			array2[6] = sortvalue;
			array[7] = "@resultnum";
			array2[7] = resultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
	}
}
