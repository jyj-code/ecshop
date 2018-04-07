using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_Cart_Action : IShopNum1_Cart_Action
	{
		public int Add(ShopNum1_Shop_Cart cart)
		{
			string strSql = string.Empty;
			DataTable dataTable = this.CheckCartProduct(cart.MemLoginID, cart.ProductGuid.ToString(), cart.Attributes, 0, cart.SpecificationValue);
			if (dataTable.Rows.Count > 0)
			{
				int num = Convert.ToInt32(dataTable.Rows[0]["BuyNumber"]);
				int num2 = num + cart.BuyNumber;
				strSql = string.Concat(new object[]
				{
					"UPDATE  ShopNum1_Shop_Cart SET  BuyNumber=",
					num2,
					", BuyPrice=",
					cart.BuyPrice,
					" WHERE MemLoginID='",
					cart.MemLoginID,
					"' AND ProductGuid='",
					cart.ProductGuid,
					"'"
				});
			}
			else
			{
				strSql = string.Concat(new object[]
				{
					"INSERT INTO ShopNum1_Shop_Cart( Guid,MemLoginID,ProductGuid,Name,RepertoryNumber,BuyNumber,MarketPrice,ShopPrice,BuyPrice,Attributes,SpecificationName,SpecificationValue,IsShipment,IsReal,ExtensionAttriutes,ParentGuid,IsJoinActivity,CartType,IsPresent,CreateTime,DetailedSpecifications ) VALUES (  '",
					cart.Guid,
					"',  '",
					cart.MemLoginID,
					"',  '",
					cart.ProductGuid,
					"',  '",
					cart.Name,
					"',  '",
					cart.RepertoryNumber,
					"',  ",
					cart.BuyNumber,
					",  ",
					cart.MarketPrice,
					",  ",
					cart.ShopPrice,
					",  ",
					cart.BuyPrice,
					",  '",
					cart.Attributes,
					"',  '",
					Operator.FormatToEmpty(cart.SpecificationName),
					"',  '",
					Operator.FormatToEmpty(cart.SpecificationValue),
					"',  ",
					cart.IsShipment,
					",  ",
					cart.IsReal,
					",  '",
					cart.ExtensionAttriutes,
					"',  '",
					cart.ParentGuid,
					"',  ",
					cart.IsJoinActivity,
					",  ",
					cart.CartType,
					",  ",
					cart.IsPresent,
					",  '",
					cart.CreateTime,
					"', '",
					cart.DetailedSpecifications,
					"')"
				});
			}
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int AddCart(ShopNum1_Shop_Cart shopcart)
		{
			string strSql = string.Empty;
			DataTable dataTable;
			int num;
			if (shopcart.IsPresent == 0)
			{
				dataTable = this.CheckCartProduct(shopcart.MemLoginID, shopcart.ProductGuid.ToString(), shopcart.Attributes, 0, shopcart.SpecificationValue);
				num = 0;
			}
			else
			{
				dataTable = this.CheckCartProduct(shopcart.MemLoginID, shopcart.ProductGuid.ToString(), shopcart.Attributes, 1, shopcart.SpecificationValue);
				num = 1;
			}
			if (dataTable.Rows.Count > 0)
			{
				int num2 = Convert.ToInt32(dataTable.Rows[0]["BuyNumber"]);
				int num3 = num2 + shopcart.BuyNumber;
				strSql = string.Concat(new object[]
				{
					"UPDATE  ShopNum1_Shop_Cart SET  BuyNumber=",
					num3,
					", BuyPrice=",
					shopcart.BuyPrice,
					" WHERE MemLoginID='",
					shopcart.MemLoginID,
					"' AND ProductGuid='",
					shopcart.ProductGuid,
					"' AND IsPresent=",
					num,
					"   AND SpecificationValue='",
					shopcart.SpecificationValue,
					"'    "
				});
			}
			else
			{
				strSql = string.Concat(new object[]
				{
					"INSERT INTO ShopNum1_Shop_Cart( Guid,MemLoginID,ProductGuid,OriginalImge,Name,RepertoryNumber,BuyNumber,MarketPrice,ShopPrice,BuyPrice,Attributes,SpecificationName,SpecificationValue,IsShipment,IsReal,ExtensionAttriutes,shopcart.DetailedSpecifications ,IsJoinActivity,CartType,IsPresent,CreateTime,ShopID,SellName,FeeType,Post_fee,Express_fee,Ems_fee   ) VALUES (  '",
					shopcart.Guid,
					"',  '",
					shopcart.MemLoginID,
					"',  '",
					shopcart.ProductGuid,
					"',  '",
					shopcart.OriginalImge,
					"',  '",
					Operator.FormatToEmpty(shopcart.Name),
					"',  '",
					shopcart.RepertoryNumber,
					"',  ",
					shopcart.BuyNumber,
					",  ",
					shopcart.MarketPrice,
					",  ",
					shopcart.ShopPrice,
					",  ",
					shopcart.BuyPrice,
					",  '",
					Operator.FormatToEmpty(shopcart.Attributes),
					"',  '",
					Operator.FormatToEmpty(shopcart.SpecificationName),
					"',  '",
					Operator.FormatToEmpty(shopcart.SpecificationValue),
					"',  ",
					shopcart.IsShipment,
					",  ",
					shopcart.IsReal,
					",  '",
					Operator.FormatToEmpty(shopcart.ExtensionAttriutes),
					"',  '",
					Operator.FormatToEmpty(shopcart.DetailedSpecifications),
					"',  ",
					shopcart.IsJoinActivity,
					",  ",
					shopcart.CartType,
					",  ",
					shopcart.IsPresent,
					",  '",
					shopcart.CreateTime,
					"', '",
					shopcart.ShopID,
					"', '",
					shopcart.SellName,
					"', ",
					shopcart.FeeType,
					",  ",
					shopcart.Post_fee,
					",  ",
					shopcart.Express_fee,
					",  ",
					shopcart.Ems_fee,
					" )"
				});
			}
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable CheckCartProduct(string memLoginID, string productGuid, string attributes, int isPresent, string guige)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"SELECT BuyPrice,BuyNumber,IsPresent FROM ShopNum1_Shop_Cart  WHERE MemLoginID='",
				memLoginID,
				"' AND ProductGuid = '",
				productGuid,
				"' AND  IsPresent=",
				isPresent,
				"  and  SpecificationValue='",
				guige,
				"'  "
			});
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable SearchByMemLoginID(string memLoginID)
		{
			string text = string.Empty;
			text = "SELECT Guid,MemLoginID,ProductGuid,OriginalImge,Name,RepertoryNumber,BuyNumber,MarketPrice,ShopPrice,BuyPrice,Attributes,IsShipment,IsReal,ShopID,SellName,ExtensionAttriutes,ParentGuid,IsJoinActivity,CartType,IsPresent,FeeType,Post_fee,Express_fee,Ems_fee,DetailedSpecifications, CreateTime FROM ShopNum1_Shop_Cart  WHERE 0 =0 ";
			if (Operator.FormatToEmpty(memLoginID) != string.Empty)
			{
				text = text + " AND MemLoginID='" + memLoginID + "'";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetGroupPriceByProductGuid(string productguid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@productguid";
			array2[0] = productguid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetGroupPriceByProductGuid", array, array2);
		}
		public DataTable SearchByMemLoginID(string memLoginID, string SellName)
		{
			string text = string.Empty;
			text = "SELECT Guid,MemLoginID,ProductGuid,OriginalImge,Name,RepertoryNumber,BuyNumber,MarketPrice,ShopPrice,BuyPrice,Attributes,IsShipment,IsReal,ShopID,SellName,ExtensionAttriutes,ParentGuid,IsJoinActivity,CartType,IsPresent,FeeType,Post_fee,Express_fee,Ems_fee,DetailedSpecifications, CreateTime FROM ShopNum1_Shop_Cart  WHERE 0 =0 ";
			if (Operator.FormatToEmpty(memLoginID) != string.Empty)
			{
				text = text + " AND MemLoginID='" + memLoginID + "'";
			}
			if (Operator.FormatToEmpty(SellName) != string.Empty)
			{
				text = text + " AND SellName='" + SellName + "'";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchByMemLoginIDAndShopID(string memLoginID, string ShopID)
		{
			string text = string.Empty;
			text = "SELECT Guid,MemLoginID,ProductGuid,OriginalImge,Name,RepertoryNumber,BuyNumber,MarketPrice,ShopPrice,BuyPrice,Attributes,SpecificationName,SpecificationValue,IsShipment,IsReal,ShopID,SellName,ExtensionAttriutes,ParentGuid,IsJoinActivity,CartType,IsPresent,FeeType,Post_fee,Express_fee,Ems_fee,DetailedSpecifications, CreateTime FROM ShopNum1_Shop_Cart  WHERE 0 =0 ";
			if (Operator.FormatToEmpty(memLoginID) != string.Empty)
			{
				text = text + " AND MemLoginID='" + memLoginID + "'";
			}
			if (Operator.FormatToEmpty(ShopID) != string.Empty)
			{
				text = text + " AND ShopID='" + ShopID + "'";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchBuyPriceByMemLoginID(string memLoginID)
		{
			string text = string.Empty;
			text = "SELECT BuyNumber,BuyPrice   FROM ShopNum1_Shop_Cart  WHERE 0 =0 ";
			if (Operator.FormatToEmpty(memLoginID) != string.Empty)
			{
				text = text + " AND MemLoginID='" + memLoginID + "'";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchByMemLoginID(string memLoginID, int cartType)
		{
			string text = string.Empty;
			text = "SELECT Guid,MemLoginID,ShopID,ProductGuid,OriginalImge,Name,RepertoryNumber,BuyNumber,MarketPrice,ShopPrice,BuyPrice,Attributes,IsShipment,IsReal,ExtensionAttriutes,ParentGuid,IsJoinActivity,CartType,IsPresent,DetailedSpecifications, CreateTime FROM ShopNum1_Shop_Cart  WHERE 0 =0 ";
			if (Operator.FormatToEmpty(memLoginID) != string.Empty)
			{
				text = text + " AND MemLoginID='" + memLoginID + "'";
			}
			text = text + " AND CartType=" + cartType;
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int Delete(string guids)
		{
			string strSql = string.Empty;
			strSql = "DELETE FROM ShopNum1_Shop_Cart  WHERE  Guid IN(" + guids + ")";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int DeleteByMemLoginID(string memLoginID)
		{
			string strSql = string.Empty;
			strSql = "DELETE FROM ShopNum1_Shop_Cart  WHERE  MemLoginID ='" + memLoginID + "'";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Update(List<ShopNum1_Shop_Cart> listCart)
		{
			string item = string.Empty;
			List<string> list = new List<string>();
			foreach (ShopNum1_Shop_Cart current in listCart)
			{
				item = string.Concat(new object[]
				{
					"UPDATE  ShopNum1_Shop_Cart SET  BuyNumber=",
					current.BuyNumber,
					", BuyPrice=",
					current.BuyPrice,
					" WHERE Guid='",
					current.Guid,
					"'"
				});
				list.Add(item);
			}
			int result;
			try
			{
				DatabaseExcetue.RunTransactionSql(list);
				result = 1;
			}
			catch
			{
				result = 0;
			}
			return result;
		}
		public int GetProductCount(string memLoginID, string productGuid)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"SELECT BuyNumber FROM ShopNum1_Shop_Cart  WHERE MemLoginID='",
				memLoginID,
				"' AND ProductGuid = '",
				productGuid,
				"'"
			});
			return Convert.ToInt32(DatabaseExcetue.ReturnDataTable(strSql).Rows[0]["BuyNumber"].ToString());
		}
		public DataTable SearchByShopMemID(string memLoginID, string shopName)
		{
			string text = string.Empty;
			text = "SELECT A.Guid,A.MemLoginID,A.ProductGuid,A.OriginalImge,A.Name,A.RepertoryNumber,A.BuyNumber,A.MarketPrice,A.ShopPrice,A.BuyPrice,A.Attributes,A.SpecificationName,A.SpecificationValue,A.IsShipment,A.IsReal,A.ShopID,A.SellName,A.ExtensionAttriutes,A.ParentGuid,A.IsJoinActivity,A.CartType,A.IsPresent,A.FeeType,B.MinusFee,B.repertorycount,A.Post_fee,A.Express_fee,A.Ems_fee,A.DetailedSpecifications, (select top 1 goodsstock from ShopNum1_SpecProudct where specdetail=A.specificationValue and productguid=A.productguid)specCount,A.CreateTime FROM ShopNum1_Shop_Cart AS A LEFT JOIN ShopNum1_Shop_Product AS B ON A.ProductGuid=B.Guid  WHERE B.isAudit=1 and b.isSell=1 and b.IsSaled=1 and b.isdeleted=0 ";
			if (Operator.FormatToEmpty(memLoginID) != string.Empty)
			{
				text = text + " AND A.MemLoginID='" + memLoginID + "'";
			}
			if (Operator.FormatToEmpty(shopName) != string.Empty)
			{
				text = text + " AND A.ShopID='" + shopName + "'";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetProductInfoByCartProductGuid(string MemloginID, string ShopID, string CartGuID)
		{
			string text = string.Empty;
			text = "SELECT A.FeeType,A.FeeTemplateID,A.Post_fee,A.Express_fee,A.Ems_fee,B.BuyNumber FROM ShopNum1_Shop_Cart AS B ";
			text += " Inner JOIN ShopNum1_Shop_Product AS A ON A.Guid=B.ProductGuid WHERE A.isAudit=1 and A.isSell=1 and A.IsSaled=1 and A.isdeleted=0 ";
			text += "And B.MemLoginID='{0}' AND B.ShopID='{1}' AND b.guid in ({2}) ";
			text = string.Format(text, MemloginID, ShopID, CartGuID);
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchShopByMemLoginID(string memLoginID)
		{
			string strSql = string.Empty;
			strSql = "SELECT distinct A.ShopID,B.ShopName as sellname,B.Tel,B.shopid MemLoginID FROM ShopNum1_Shop_Cart A LEFT JOIN ShopNum1_ShopInfo AS B ON A.ShopID=B.MemLoginID WHERE 0 =0 AND A.MemLoginID = @MemLoginID and sellname!='' and productguid in(select guid from shopnum1_shop_product where isAudit=1 and isSell=1 and IsSaled=1 and isdeleted=0 ) ";
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@MemLoginID";
			array2[0] = memLoginID;
			return DatabaseExcetue.ReturnDataTable(strSql, array, array2);
		}
		public DataTable SearchByPostPrice(string memLoginID, string shopName)
		{
			string text = string.Empty;
			text = "SELECT sum(Post_fee) Post_fee,sum(Express_fee) Express_fee,sum(Ems_fee) Ems_fee FROM ShopNum1_Shop_Cart  WHERE 0 =0 ";
			if (Operator.FormatToEmpty(memLoginID) != string.Empty)
			{
				text = text + " AND MemLoginID='" + memLoginID + "'";
			}
			if (Operator.FormatToEmpty(shopName) != string.Empty)
			{
				text = text + " AND ShopID='" + shopName + "'";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int GetMemCartCount(string memLoginID)
		{
			string strSql = "SELECT count(BuyNumber) AS AllCount FROM  ShopNum1_Shop_Cart WHERE  MemLoginID=@MemLoginID";
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@MemLoginID";
			array2[0] = memLoginID;
			object obj = DatabaseExcetue.ReturnObject(strSql, array, array2);
			int result;
			if (object.Equals(obj, null) || object.Equals(obj, DBNull.Value))
			{
				result = 0;
			}
			else
			{
				result = int.Parse(obj.ToString());
			}
			return result;
		}
		public int AddOrder(List<ShopNum1_Shop_Cart> cart)
		{
			List<string> list = new List<string>();
			foreach (ShopNum1_Shop_Cart current in cart)
			{
				string item = string.Empty;
				DataTable dataTable = this.CheckCartProduct(current.MemLoginID, current.ProductGuid.ToString(), current.Attributes, 0, current.SpecificationValue);
				if (dataTable.Rows.Count > 0)
				{
					int num = Convert.ToInt32(dataTable.Rows[0]["BuyNumber"]);
					int num2 = num + current.BuyNumber;
					item = string.Concat(new object[]
					{
						"UPDATE  ShopNum1_Shop_Cart SET  BuyNumber=",
						num2,
						", BuyPrice=",
						current.BuyPrice,
						" WHERE MemLoginID='",
						current.MemLoginID,
						"' AND ProductGuid='",
						current.ProductGuid,
						"'"
					});
				}
				else
				{
					item = string.Concat(new object[]
					{
						"INSERT INTO ShopNum1_Shop_Cart( Guid,MemLoginID,ProductGuid,Name,RepertoryNumber,BuyNumber,MarketPrice,ShopPrice,BuyPrice,IsShipment,IsReal,ExtensionAttriutes,ParentGuid,IsJoinActivity,CartType,IsPresent,CreateTime,DetailedSpecifications ,ShopID,SellName,FeeType,Post_fee,Express_fee,Ems_fee   ) VALUES (  '",
						current.Guid,
						"',  '",
						current.MemLoginID,
						"',  '",
						current.ProductGuid,
						"',  '",
						current.Name,
						"',  '",
						current.RepertoryNumber,
						"',  ",
						current.BuyNumber,
						",  ",
						current.MarketPrice,
						",  ",
						current.ShopPrice,
						",  ",
						current.BuyPrice,
						",  ",
						current.IsShipment,
						",  ",
						current.IsReal,
						",  '",
						current.ExtensionAttriutes,
						"',  '",
						current.ParentGuid,
						"',  ",
						current.IsJoinActivity,
						",  ",
						current.CartType,
						",  ",
						current.IsPresent,
						",  '",
						current.CreateTime,
						"', '",
						current.DetailedSpecifications,
						"', '",
						current.ShopID,
						"', '",
						current.SellName,
						"', ",
						current.FeeType,
						",  ",
						current.Post_fee,
						",  ",
						current.Express_fee,
						",  ",
						current.Ems_fee,
						" )"
					});
				}
				list.Add(item);
			}
			int result;
			try
			{
				DatabaseExcetue.RunTransactionSql(list);
				result = 1;
			}
			catch
			{
				result = 0;
			}
			return result;
		}
		public DataTable SearchByMemLoginIDShopID(string memLoginID, string Shopid)
		{
			string text = string.Empty;
			text = "SELECT Guid,MemLoginID,ProductGuid,OriginalImge,Name,RepertoryNumber,BuyNumber,MarketPrice,ShopPrice,BuyPrice,Attributes,IsShipment,IsReal,ShopID,SellName,ExtensionAttriutes,ParentGuid,IsJoinActivity,CartType,IsPresent,FeeType,Post_fee,Express_fee,Ems_fee,DetailedSpecifications, CreateTime FROM ShopNum1_Shop_Cart  WHERE 0 =0 ";
			if (Operator.FormatToEmpty(memLoginID) != string.Empty)
			{
				text = text + " AND MemLoginID='" + memLoginID + "'";
			}
			if (Operator.FormatToEmpty(Shopid) != string.Empty)
			{
				text = text + " AND ShopID='" + Shopid + "'";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int UpdateCar(List<ShopNum1_Shop_Cart> listCart)
		{
			string item = string.Empty;
			List<string> list = new List<string>();
			foreach (ShopNum1_Shop_Cart current in listCart)
			{
				item = string.Concat(new object[]
				{
					"UPDATE  ShopNum1_Shop_Cart SET  BuyNumber=",
					current.BuyNumber,
					", ShopPrice=",
					current.ShopPrice,
					" WHERE Guid='",
					current.Guid,
					"'"
				});
				list.Add(item);
			}
			int result;
			try
			{
				DatabaseExcetue.RunTransactionSql(list);
				result = 1;
			}
			catch
			{
				result = 0;
			}
			return result;
		}
		public DataTable CheckMemberLoginID(string memLoginID)
		{
			string strSql = string.Empty;
			strSql = "select MemLoginID from ShopNum1_Member where MemLoginID='" + memLoginID + "' And IsDeleted =0";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable CheckRepertoryCount(string guid)
		{
			string strSql = string.Empty;
			strSql = "select A.BuyNumber, B.RepertoryCount from ShopNum1_Shop_Cart AS A left join ShopNum1_Shop_Product AS B on A.ProductGuid=B.guid Where A.guid='" + guid + "'";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable SearchShopByMemLoginID(string memLoginID, string guids)
		{
			string text = string.Empty;
			text = "SELECT DISTINCT A.ShopID,B.ShopRank,B.ShopName as SellName,B.Tel FROM ShopNum1_Shop_Cart AS A LEFT JOIN ShopNum1_ShopInfo AS B ON A.ShopID=B.MemLoginID  WHERE 0 =0 AND A.MemLoginID='" + memLoginID + "' and sellName!=''";
			if (guids != string.Empty)
			{
				text = text + " AND A.guid IN(" + guids + ")";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchByShopMemID(string memLoginID, string shopName, string guids)
		{
			string text = string.Empty;
			text = "SELECT A.Guid,A.MemLoginID,A.ProductGuid,A.OriginalImge,A.Name,A.RepertoryNumber,A.BuyNumber,A.MarketPrice,A.ShopPrice,A.BuyPrice,A.Attributes,A.SpecificationName,A.SpecificationValue,A.IsShipment,A.IsReal,A.ShopID,A.SellName,A.ExtensionAttriutes,A.ParentGuid,A.IsJoinActivity,A.CartType,A.IsPresent,A.FeeType,B.MinusFee,A.Post_fee,A.Express_fee,A.Ems_fee,A.DetailedSpecifications, A.CreateTime FROM ShopNum1_Shop_Cart AS A Inner JOIN ShopNum1_Shop_Product AS B ON A.ProductGuid=B.Guid WHERE  B.isAudit=1 and B.isSell=1 and B.IsSaled=1 and B.isdeleted=0";
			if (Operator.FormatToEmpty(memLoginID) != string.Empty)
			{
				text = text + " AND A.MemLoginID='" + memLoginID + "'";
			}
			if (Operator.FormatToEmpty(shopName) != string.Empty)
			{
				text = text + " AND A.ShopID='" + shopName + "'";
			}
			if (Operator.FormatToEmpty(guids) != string.Empty)
			{
				text = text + " AND A.Guid IN(" + guids + ")";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchByMemLoginIDAndShopID(string memLoginID, string ShopID, string guids)
		{
			string text = string.Empty;
			text = "SELECT Guid,MemLoginID,ProductGuid,OriginalImge,Name,RepertoryNumber,BuyNumber,MarketPrice,ShopPrice,BuyPrice,Attributes,SpecificationName,SpecificationValue,IsShipment,IsReal,ShopID,SellName,ExtensionAttriutes,ParentGuid,IsJoinActivity,CartType,IsPresent,FeeType,Post_fee,Express_fee,Ems_fee,DetailedSpecifications, CreateTime FROM ShopNum1_Shop_Cart  WHERE 0 =0 ";
			if (Operator.FormatToEmpty(memLoginID) != string.Empty)
			{
				text = text + " AND MemLoginID='" + memLoginID + "'";
			}
			if (Operator.FormatToEmpty(ShopID) != string.Empty)
			{
				text = text + " AND ShopID='" + ShopID + "'";
			}
			if (Operator.FormatToEmpty(guids) != string.Empty)
			{
				text = text + " AND Guid IN(" + guids + ")";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int DeleteByMemLoginID(string memLoginID, string guids)
		{
			string text = string.Empty;
			text = "DELETE FROM ShopNum1_Shop_Cart  WHERE  MemLoginID ='" + memLoginID + "'";
			if (guids != string.Empty)
			{
				text = text + " AND Guid IN(" + guids + ")";
			}
			return DatabaseExcetue.RunNonQuery(text);
		}
		public DataTable GetInfoByGuid(string guid)
		{
			string text = string.Empty;
			text = "select *   FROM ShopNum1_Shop_Cart  WHERE  1 =1 ";
			if (!string.IsNullOrEmpty(guid))
			{
				text = text + " AND Guid ='" + guid + "'";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
	}
}
