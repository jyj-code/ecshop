using ShopNum1.DataAccess;
using ShopNum1.Interface;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_OrderProduct_Action : IShopNum1_OrderProduct_Action
	{
		public DataTable SelectOrderProductByGuIdorAll(string OrderGuId, string KeyWord)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@OrderGuId";
			array2[0] = OrderGuId;
			array[1] = "@KeyWord";
			array2[1] = KeyWord;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetOrderProductByGuIdorAll", array, array2);
		}
		public DataTable Search(string orderInfoGuid)
		{
			string text = string.Empty;
			text = "SELECT A.Guid,A.OrderInfoGuid,A.ProductGuid,A.Name,A.RepertoryNumber,A.BuyNumber,A.MarketPrice,A.ShopPrice,A.BuyPrice,A.Attributes,A.IsShipment,A.IsReal,A.ExtensionAttriutes,A.IsJoinActivity,A.CreateTime,B.PanicPrice,B.SpellPrice,B.GroupPrice,B.memloginid  FROM ShopNum1_OrderProduct AS A,ShopNum1_Shop_Product AS B  WHERE A.ProductGuid=B.Guid ";
			if (orderInfoGuid != "-1")
			{
				text = string.Concat(new object[]
				{
					text,
					" AND A.OrderInfoGuid='",
					new Guid(orderInfoGuid),
					"'"
				});
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public string GetWeight(string guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT Weight FROM ShopNum1_Product WHERE Guid='" + guid + "'";
			string result;
			if (DatabaseExcetue.ReturnDataTable(strSql).Rows.Count > 0)
			{
				result = DatabaseExcetue.ReturnDataTable(strSql).Rows[0]["Weight"].ToString();
			}
			else
			{
				result = "0.00";
			}
			return result;
		}
		public DataTable SearchOrderProduct(string ordernum, string productname, string shopname, string startdate, string enddate)
		{
			string[] array = new string[5];
			string[] array2 = new string[5];
			array[0] = "@ordernum";
			array2[0] = ordernum;
			array[1] = "@pname";
			array2[1] = productname;
			array[2] = "@shopname";
			array2[2] = shopname;
			array[3] = "@startdate";
			array2[3] = startdate;
			array[4] = "@enddate";
			array2[4] = enddate;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchOrderProduct", array, array2);
		}
		public DataTable SearchOrderProduct(string ordernum, string productname, string shopname, string startdate, string enddate, string SubstationID)
		{
			string[] array = new string[6];
			string[] array2 = new string[6];
			array[0] = "@ordernum";
			array2[0] = ordernum;
			array[1] = "@pname";
			array2[1] = productname;
			array[2] = "@shopname";
			array2[2] = shopname;
			array[3] = "@SubstationID";
			array2[3] = SubstationID;
			array[4] = "@startdate";
			array2[4] = startdate;
			array[5] = "@enddate";
			array2[5] = enddate;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchOrderProduct1", array, array2);
		}
		public DataTable SearchRankingSellHot(string ShowCount)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@ShowCount";
			array2[0] = ShowCount;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_SearchRankingSellHot", array, array2);
		}
		public DataTable GetOrderProductList(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetOrderProductList", array, array2);
		}
		public int UpdateOrderProductBuyNum(string guid, string buynumber, string productPrice)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@guid";
			array2[0] = guid;
			array[1] = "@buynumber";
			array2[1] = buynumber;
			array[2] = "@BuyPrice";
			array2[2] = productPrice;
			return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdateOrderProductBuyNum", array, array2);
		}
		public int UpdateOrderProductInfo(string guid, string buyprice, string groupprice, string buynumber)
		{
			string[] array = new string[4];
			string[] array2 = new string[4];
			array[0] = "@guid";
			array2[0] = guid;
			array[1] = "@buyprice";
			array2[1] = buyprice;
			array[2] = "@groupprice";
			array2[2] = groupprice;
			array[3] = "@buynumber";
			array2[3] = buynumber;
			return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdateOrderProductInfo", array, array2);
		}
		public DataTable GetPackOrderShopInfo(string memloginid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@memloginid";
			array2[0] = memloginid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetPackShopInfo", array, array2);
		}
		public int UpdateStock(string strOrderGuId)
		{
			List<string> list = new List<string>();
			string strSql = "select productguid,buynumber,specificationvalue,attributes from shopnum1_orderproduct where orderinfoGuId='" + strOrderGuId + "' ";
			DataTable dataTable = DatabaseExcetue.ReturnDataTable(strSql);
			if (dataTable.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					list.Add(string.Concat(new object[]
					{
						"UPDATE ShopNum1_Shop_Product SET salenumber=salenumber+",
						dataTable.Rows[i]["buynumber"],
						" WHERE  Guid ='",
						dataTable.Rows[i]["productguid"],
						"';"
					}));
					list.Add(string.Concat(new object[]
					{
						"UPDATE ShopNum1_Group_Product SET groupcount=groupcount+",
						dataTable.Rows[i]["buynumber"],
						" WHERE productguid='",
						dataTable.Rows[i]["productguid"],
						"' and state=1;"
					}));
				}
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
		public int UpdateReduceStock(string strOrderGuId)
		{
			List<string> list = new List<string>();
			string strSql = "select productguid,buynumber,specificationvalue,attributes from shopnum1_orderproduct where orderinfoGuId='" + strOrderGuId + "' ";
			DataTable dataTable = DatabaseExcetue.ReturnDataTable(strSql);
			if (dataTable.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					if (dataTable.Rows[i]["attributes"].ToString() == "0")
					{
						list.Add(string.Concat(new object[]
						{
							"UPDATE ShopNum1_Shop_Product SET RepertoryCount=RepertoryCount+",
							dataTable.Rows[i]["buynumber"],
							" WHERE Guid ='",
							dataTable.Rows[i]["productguid"],
							"';"
						}));
						list.Add(string.Concat(new object[]
						{
							"UPDATE ShopNum1_SpecProudct SET goodsstock=goodsstock+",
							dataTable.Rows[i]["buynumber"],
							" WHERE  SpecDetail ='",
							dataTable.Rows[i]["specificationvalue"],
							"';"
						}));
						list.Add(string.Concat(new object[]
						{
							"UPDATE ShopNum1_Shop_Product SET salenumber=salenumber-",
							dataTable.Rows[i]["buynumber"],
							" WHERE  Guid ='",
							dataTable.Rows[i]["productguid"],
							"';"
						}));
					}
					list.Add(string.Concat(new object[]
					{
						"UPDATE ShopNum1_Group_Product SET groupstock=groupstock+",
						dataTable.Rows[i]["buynumber"],
						" WHERE productguid='",
						dataTable.Rows[i]["productguid"],
						"';"
					}));
				}
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
		public int UpdateReduceStock(string strOrderGuId, string strSaleType)
		{
			List<string> list = new List<string>();
			string strSql = "select productguid,buynumber,specificationvalue,attributes,b.oderstatus from shopnum1_orderproduct A inner Join ShopNum1_Orderinfo B on B.guid=A.orderinfoGuId  where orderinfoGuId='" + strOrderGuId + "' ";
			DataTable dataTable = DatabaseExcetue.ReturnDataTable(strSql);
			if (dataTable.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					if (dataTable.Rows[i]["attributes"].ToString() == "0")
					{
						list.Add(string.Concat(new object[]
						{
							"UPDATE ShopNum1_Shop_Product SET RepertoryCount=RepertoryCount+",
							dataTable.Rows[i]["buynumber"],
							" WHERE Guid ='",
							dataTable.Rows[i]["productguid"],
							"';"
						}));
						list.Add(string.Concat(new object[]
						{
							"UPDATE ShopNum1_SpecProudct SET goodsstock=goodsstock+",
							dataTable.Rows[i]["buynumber"],
							" WHERE  SpecDetail ='",
							dataTable.Rows[i]["specificationvalue"],
							"';"
						}));
						if (strSaleType == "1")
						{
							list.Add(string.Concat(new object[]
							{
								"UPDATE ShopNum1_Shop_Product SET salenumber=salenumber-",
								dataTable.Rows[i]["buynumber"],
								" WHERE  Guid ='",
								dataTable.Rows[i]["productguid"],
								"';"
							}));
						}
					}
					list.Add(string.Concat(new object[]
					{
						"UPDATE ShopNum1_Group_Product SET groupstock=groupstock+",
						dataTable.Rows[i]["buynumber"],
						" WHERE productguid='",
						dataTable.Rows[i]["productguid"],
						"';"
					}));
				}
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
		public DataTable GetNewSaleOrder(string strTopCount)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@top";
			array2[0] = strTopCount;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_GetNewSaleOrder", array, array2);
		}
	}
}
