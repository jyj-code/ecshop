using ShopNum1.DataAccess;
using ShopNum1.Interface;
using System;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_GroupProduct_Action : IShopNum1_GroupProduct_Action
	{
		public DataTable SelectGroupByAId(string pagesize, string currentpage, string condition, string resultnum)
		{
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@pagesize";
			array2[0] = pagesize;
			array[1] = "@currentpage";
			array2[1] = currentpage;
			array[2] = "@columns";
			array2[2] = "*";
			array[3] = "@tablename";
			array2[3] = "select A.id,A.name,A.aid,a.productguid,a.groupcount,a.groupstock,a.groupprice,a.createtime,a.state,a.shopname,a.memloginid,a.groupimg,a.groupsmallimg,(select name from shopnum1_shop_product where guid=a.productguid)pname,(select shopid from shopnum1_shopinfo where memloginid=a.memloginid)shopid,b.name as aname,b.starttime,b.endtime from ShopNum1_Group_Product A \r\ninner join ShopNum1_Product_Activity B on A.aid=b.id";
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
		public int DeleteButch(string strId)
		{
			string strSql = "DELETE FROM ShopNum1_Group_Product WHERE Id in(" + strId + ")";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int UpdateGroupState(string strId, string strState)
		{
			string strSql = string.Concat(new string[]
			{
				"UPDATE ShopNum1_Group_Product SET State=",
				strState,
				" WHERE Id='",
				strId,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int UpdateGroupAState(string strId, string strState)
		{
			string strSql = string.Concat(new string[]
			{
				"UPDATE ShopNum1_Group_Product SET State=",
				strState,
				" WHERE AId='",
				strId,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable SelectGroupList(string pagesize, string currentpage, string condition, string resultnum, string strordercolumn, string strsortvalue)
		{
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@pagesize";
			array2[0] = pagesize;
			array[1] = "@currentpage";
			array2[1] = currentpage;
			array[2] = "@columns";
			array2[2] = "*";
			array[3] = "@tablename";
			array2[3] = "select top 500 A.id,A.SubstationID,A.aname,A.groupimg,a.groupprice,a.groupcount,a.groupstock,a.createtime,a.state,a.shopname,c.name,a.groupsmallimg,c.shopprice,c.productcategorycode,b.starttime,b.endtime,(select shopid from shopnum1_shopinfo where memloginid=a.memloginid)shopid,c.guid,(case when b.endtime<getdate() then '1' else '0' end) as tgstate from ShopNum1_Group_Product A inner join ShopNum1_Product_Activity B on B.id=A.Aid inner join \r\nShopNum1_Shop_Product C on C.Guid=A.productguid order by " + strordercolumn + " " + strsortvalue;
			array[4] = "@condition";
			array2[4] = condition;
			array[5] = "@ordercolumn";
			array2[5] = strordercolumn;
			array[6] = "@sortvalue";
			array2[6] = strsortvalue;
			array[7] = "@resultnum";
			array2[7] = resultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
		public DataTable GetGroupProductData(int start, int int_0)
		{
			string text = string.Empty;
			text += "   SELECT * FROM (select Name,GroupPrice,GroupImg,CreateTime,Id,MemLoginId,ShopName, ROW_NUMBER()     ";
			text += "   over(order by CreateTime  DESC) as rows from ShopNum1_Group_Product WHERE State=1    ";
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"   ) AS B WHERE  B.rows>=",
				start,
				" AND B.rows<=",
				int_0,
				"    "
			});
			return DatabaseExcetue.ReturnDataTable(text);
		}
	}
}
