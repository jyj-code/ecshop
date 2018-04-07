using ShopNum1.DataAccess;
using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.ShopBusinessLogic
{
	public class Shop_GroupProduct_Action
	{
		public int AddGroupProduct(ShopNum1_Group_Product Shop_GroupProduct)
		{
			string text = "INSERT INTO ShopNum1_Group_Product(Aid,Aname,Name,ProductGuId,GroupPrice,GroupImg,GroupSmallImg,GroupStock,VirtualNum,LimitNum,Introduce,ShopName,MemLoginId,CreateTime,SubstationID";
			if (Shop_GroupProduct.State.HasValue)
			{
				text += ",state";
			}
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				")VALUES('",
				Shop_GroupProduct.Aid,
				"','",
				Shop_GroupProduct.Aname,
				"','",
				Shop_GroupProduct.Name,
				"','",
				Shop_GroupProduct.ProductGuId,
				"',"
			});
			object obj2 = text;
			text = string.Concat(new object[]
			{
				obj2,
				"'",
				Shop_GroupProduct.GroupPrice,
				"','",
				Shop_GroupProduct.GroupImg,
				"','",
				Shop_GroupProduct.GroupSmallImg,
				"',"
			});
			object obj3 = text;
			text = string.Concat(new object[]
			{
				obj3,
				"'",
				Shop_GroupProduct.GroupStock,
				"','",
				Shop_GroupProduct.VirtualNum,
				"','",
				Shop_GroupProduct.LimitNum,
				"',"
			});
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"'",
				Shop_GroupProduct.Introduce,
				"','",
				Shop_GroupProduct.ShopName,
				"','",
				Shop_GroupProduct.MemLoginId,
				"','",
				DateTime.Now.ToString(),
				"','",
				Shop_GroupProduct.SubstationID,
				"'"
			});
			if (Shop_GroupProduct.State.HasValue)
			{
				object obj4 = text;
				text = string.Concat(new object[]
				{
					obj4,
					",'",
					Shop_GroupProduct.State,
					"'"
				});
			}
			text += ");";
			return DatabaseExcetue.RunNonQuery(text);
		}
		public int UpdateGroupProduct(ShopNum1_Group_Product Shop_GroupProduct)
		{
			string text = string.Concat(new object[]
			{
				"UPDATE ShopNum1_Group_Product set Aid='",
				Shop_GroupProduct.Aid,
				"',Aname='",
				Shop_GroupProduct.Aname,
				"',ProductGuId='",
				Shop_GroupProduct.ProductGuId,
				"',Name='",
				Shop_GroupProduct.Name,
				"',GroupPrice='",
				Shop_GroupProduct.GroupPrice,
				"',SubstationID='",
				Shop_GroupProduct.SubstationID,
				"',"
			});
			if (Shop_GroupProduct.GroupImg != null)
			{
				text = text + "GroupImg='" + Shop_GroupProduct.GroupImg + "',";
			}
			if (Shop_GroupProduct.GroupSmallImg != null)
			{
				text = text + "GroupSmallImg='" + Shop_GroupProduct.GroupSmallImg + "',";
			}
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				"State='",
				Shop_GroupProduct.State,
				"',GroupStock='",
				Shop_GroupProduct.GroupStock,
				"',VirtualNum='",
				Shop_GroupProduct.VirtualNum,
				"',LimitNum='",
				Shop_GroupProduct.LimitNum,
				"',Introduce='",
				Shop_GroupProduct.Introduce,
				"' where id='",
				Shop_GroupProduct.Id,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(text);
		}
		public int DeleteGroupProduct(string strId, string strMemloginId)
		{
			string text = "DELETE FROM ShopNum1_Group_Product WHERE Id='" + strId + "' ";
			if (strMemloginId != "")
			{
				text = text + " and memloginId='" + strMemloginId + "'";
			}
			return DatabaseExcetue.RunNonQuery(text);
		}
		public DataTable SelectActivity(string pagesize, string currentpage, string condition, string resultnum)
		{
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@pagesize";
			array2[0] = pagesize;
			array[1] = "@currentpage";
			array2[1] = currentpage;
			array[2] = "@columns";
			array2[2] = "id,Name,GroupSmallImg,GroupCount,State,Aname,MemloginId,ProductGuId";
			array[3] = "@tablename";
			array2[3] = "ShopNum1_Group_Product";
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
		public DataTable GetProduct(int topnumber, string ProductSeriesCode, string Name, string MemLoginID)
		{
			string text = string.Empty;
			text = "   SELECT  top  " + topnumber + "    Guid ,Name  from    ShopNum1_Shop_Product      where  1=1   ";
			if (ProductSeriesCode != "0")
			{
				text = text + "    and   ProductSeriesCode like  '%" + ProductSeriesCode + "%'   ";
			}
			if (Name != "")
			{
				text = text + " and Name like '%" + Name + "%'";
			}
			text = text + " and isdeleted=0 and issell=1 and isaudit=1 and issaled=1 AND productstate=0 and memloginID='" + MemLoginID + "' and repertorycount>0 and guid not in (select productguid from ShopNum1_Limt_Product where state=1)";
			text += "   order  by   modifytime  desc     ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetProductById(string GuId, string MemLoginID)
		{
			string text = "   SELECT  shopprice,repertorycount,name from   ShopNum1_Shop_Product  where  1=1   ";
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"  and memloginID='",
				MemLoginID,
				"' and guid='",
				GuId,
				"'  "
			});
			text += "  and isdeleted=0 and issell=1 and isaudit=1  order  by   modifytime  desc     ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetGroupProductById(string strId, string strMemloginId)
		{
			string strSql = string.Concat(new string[]
			{
				"SELECT *,(select repertorycount from shopnum1_shop_product where guid=t.productguid)repc FROM ShopNum1_Group_Product as t WHERE ID='",
				strId,
				"' AND MemLoginId='",
				strMemloginId,
				"'"
			});
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetGroupProductDetial(string strId)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@Id";
			array2[0] = strId;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GroupDetail", array, array2);
		}
		public DataTable SelectGroupProduct(string pagesize, string currentpage, string condition, string resultnum, string sortvalue, string ordercolumn)
		{
			string text = "select v.id,v.Name,GroupSmallImg,GroupImg,GroupCount,createtime,visitcount,v.shopname,v.MemLoginId,\r\nv.State,Aname,(select shopprice from shopnum1_shop_product where guid=v.productguid)shopprice,groupprice,Aid from ShopNum1_Group_Product as v inner join ShopNum1_Product_Activity B on B.id=v.Aid   ";
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
			array2[5] = ordercolumn;
			array[6] = "@sortvalue";
			array2[6] = sortvalue;
			array[7] = "@resultnum";
			array2[7] = resultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
	}
}
