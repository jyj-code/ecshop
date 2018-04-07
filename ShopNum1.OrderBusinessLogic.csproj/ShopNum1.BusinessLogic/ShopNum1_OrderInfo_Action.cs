using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_OrderInfo_Action : IShopNum1_OrderInfo_Action
	{
		public int Add(ShopNum1_OrderInfo oderInfo, List<ShopNum1_OrderProduct> listOrderProduct)
		{
			List<string> list = new List<string>();
			string item = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_OrderOperateLog(Guid,OrderInfoGuid,CreateUser,OderStatus,ShipmentStatus,PaymentStatus,CurrentStateMsg,NextStateMsg,Memo,OperateDateTime,IsDeleted)VALUES('",
				oderInfo.Guid,
				"','",
				oderInfo.Guid,
				"','",
				oderInfo.MemLoginID,
				"','",
				oderInfo.OderStatus,
				"','",
				oderInfo.ShipmentStatus,
				"','",
				oderInfo.PaymentStatus,
				"','已经下单','等待付款','','",
				DateTime.Now.ToString(),
				"','0');"
			});
			list.Add(item);
			string item2 = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_OrderInfo( Guid,PayMentMemLoginID,MemLoginID,OrderNumber,TradeID,OderStatus,ShipmentStatus,PaymentStatus,Name,Email,Address,Postalcode,Tel,Mobile,ClientToSellerMsg,SellerToClientMsg,PaymentGuid,PaymentName,OutOfStockOperate,PackGuid,PackName,BlessCardGuid,BlessCardName,BlessCardContent,InvoiceTitle,InvoiceContent,ProductPrice,DispatchPrice,DispatchType,PaymentPrice,PackPrice,BlessCardPrice,AlreadPayPrice,SurplusPrice,UseScore,ScorePrice,ShouldPayPrice,FromAd,FromUrl,CreateTime,ConfirmTime,ShipmentNumber,BuyType,ActivityGuid,PayMemo,InvoiceType,InvoiceTax,Discount,Deposit,ShopID,ReceivedDays,IsMemdelay,ShopName,FeeType,RegionCode,JoinActiveType,ActvieContent,UsedFavourTicket,OrderType,RecommendCommision,IsMinus,identifycode,SubstationID ) VALUES ( '",
				oderInfo.Guid,
				"','",
				oderInfo.PayMentMemLoginID,
				"','",
				oderInfo.MemLoginID,
				"','",
				oderInfo.OrderNumber,
				"','",
				oderInfo.TradeID,
				"',",
				oderInfo.OderStatus,
				",",
				oderInfo.ShipmentStatus,
				",",
				oderInfo.PaymentStatus,
				",'",
				Operator.FilterString(oderInfo.Name),
				"','",
				Operator.FilterString(oderInfo.Email),
				"','",
				Operator.FilterString(oderInfo.Address),
				"','",
				Operator.FilterString(oderInfo.Postalcode),
				"','",
				Operator.FilterString(oderInfo.Tel),
				"','",
				Operator.FilterString(oderInfo.Mobile),
				"','",
				Operator.FilterString(oderInfo.ClientToSellerMsg),
				"','",
				Operator.FilterString(oderInfo.SellerToClientMsg),
				"','",
				oderInfo.PaymentGuid,
				"','",
				Operator.FilterString(oderInfo.PaymentName),
				"','",
				Operator.FilterString(oderInfo.OutOfStockOperate),
				"','",
				oderInfo.PackGuid,
				"','",
				Operator.FilterString(oderInfo.PackName),
				"','",
				oderInfo.BlessCardGuid,
				"','",
				Operator.FilterString(oderInfo.BlessCardName),
				"','",
				Operator.FilterString(oderInfo.BlessCardContent),
				"','",
				Operator.FilterString(oderInfo.InvoiceTitle),
				"','",
				Operator.FilterString(oderInfo.InvoiceContent),
				"',",
				oderInfo.ProductPrice,
				",",
				oderInfo.DispatchPrice,
				",",
				oderInfo.DispatchType,
				",",
				oderInfo.PaymentPrice,
				",",
				oderInfo.PackPrice,
				",",
				oderInfo.BlessCardPrice,
				",",
				oderInfo.AlreadPayPrice,
				",",
				oderInfo.SurplusPrice,
				",",
				oderInfo.UseScore,
				",",
				oderInfo.ScorePrice,
				",",
				oderInfo.ShouldPayPrice,
				",'",
				Operator.FilterString(oderInfo.FromAd),
				"','",
				Operator.FilterString(oderInfo.FromUrl),
				"','",
				Operator.FilterString(oderInfo.CreateTime),
				"','",
				oderInfo.ConfirmTime,
				"','",
				Operator.FilterString(oderInfo.ShipmentNumber),
				"','",
				Operator.FilterString(oderInfo.BuyType),
				"','",
				oderInfo.ActivityGuid,
				"','",
				Operator.FilterString(oderInfo.PayMemo),
				"','",
				Operator.FilterString(oderInfo.InvoiceType),
				"',",
				oderInfo.InvoiceTax,
				",",
				oderInfo.Discount,
				",",
				oderInfo.Deposit,
				",'",
				oderInfo.ShopID,
				"', ",
				oderInfo.ReceivedDays,
				", ",
				oderInfo.IsMemdelay,
				",'",
				oderInfo.ShopName,
				"',",
				oderInfo.FeeType,
				",'",
				oderInfo.RegionCode,
				"',",
				oderInfo.JoinActiveType,
				",'",
				oderInfo.ActvieContent,
				"','",
				oderInfo.UsedFavourTicket,
				"',",
				oderInfo.OrderType,
				",",
				oderInfo.RecommendCommision,
				",",
				oderInfo.IsMinus,
				",'",
				oderInfo.identifycode,
				"','",
				oderInfo.SubstationID,
				"');"
			});
			list.Add(item2);
			if (listOrderProduct.Count > 0)
			{
				list.Add("Update ShopNum1_Shop_Product set buycount=buycount+1 where guid='" + listOrderProduct[0].ProductGuid + "';");
				for (int i = 0; i < listOrderProduct.Count; i++)
				{
					string item3 = string.Concat(new object[]
					{
						"INSERT INTO ShopNum1_OrderProduct( Guid,OrderInfoGuid,ProductGuid,RepertoryNumber,BuyNumber,MarketPrice,ShopPrice,BuyPrice,Attributes,SpecificationName,SpecificationValue,IsShipment,IsReal,ExtensionAttriutes,GroupPrice,IsJoinActivity,DetailedSpecifications,MemLoginID,ShopID,CreateTime,ProductImg,OrderType,ProductName ) VALUES ( '",
						listOrderProduct[i].Guid,
						"','",
						oderInfo.Guid,
						"','",
						listOrderProduct[i].ProductGuid,
						"','",
						Operator.FilterString(listOrderProduct[i].RepertoryNumber),
						"',",
						listOrderProduct[i].BuyNumber,
						",",
						listOrderProduct[i].MarketPrice,
						",",
						listOrderProduct[i].ShopPrice,
						",",
						listOrderProduct[i].BuyPrice,
						",'",
						Operator.FilterString(listOrderProduct[i].Attributes),
						"','",
						Operator.FilterString(listOrderProduct[i].SpecificationName),
						"','",
						Operator.FilterString(listOrderProduct[i].SpecificationValue),
						"',",
						listOrderProduct[i].IsShipment,
						",",
						listOrderProduct[i].IsReal,
						",'",
						Operator.FilterString(listOrderProduct[i].ExtensionAttriutes),
						"',",
						listOrderProduct[i].GroupPrice,
						",",
						listOrderProduct[i].IsJoinActivity,
						",'",
						listOrderProduct[i].DetailedSpecifications,
						"','",
						listOrderProduct[i].MemLoginID,
						"','",
						listOrderProduct[i].ShopID,
						"','",
						listOrderProduct[i].CreateTime,
						"','",
						listOrderProduct[i].ProductImg,
						"','",
						listOrderProduct[i].OrderType,
						"','",
						listOrderProduct[i].ProductName,
						"');"
					});
					list.Add(item3);
					if (listOrderProduct[i].setStock == "0")
					{
						string item4 = string.Concat(new string[]
						{
							"UPDATE ShopNum1_Shop_Product SET RepertoryCount=RepertoryCount-",
							listOrderProduct[i].BuyNumber.ToString(),
							" WHERE Guid ='",
							listOrderProduct[i].ProductGuid.ToString(),
							"' And repertorycount>=",
							listOrderProduct[i].BuyNumber.ToString(),
							";"
						});
						list.Add(item4);
						string item5 = string.Concat(new string[]
						{
							"UPDATE ShopNum1_Group_Product SET groupstock=groupstock-",
							listOrderProduct[i].BuyNumber.ToString(),
							" WHERE productguid='",
							listOrderProduct[i].ProductGuid.ToString(),
							"' And groupstock>=",
							listOrderProduct[i].BuyNumber.ToString(),
							";"
						});
						list.Add(item5);
						string item6 = string.Concat(new string[]
						{
							"UPDATE ShopNum1_SpecProudct SET goodsstock=goodsstock-",
							listOrderProduct[i].BuyNumber.ToString(),
							" WHERE productguid='",
							listOrderProduct[i].ProductGuid.ToString(),
							"' And SpecDetail ='",
							listOrderProduct[i].SpecificationValue.ToString(),
							"' And goodsstock>=",
							listOrderProduct[i].BuyNumber.ToString(),
							";"
						});
						list.Add(item6);
					}
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
		public int Add(List<ShopNum1_OrderInfo> listoderinfo, List<ShopNum1_OrderProduct> listOrderProduct)
		{
			List<string> list = new List<string>();
			if (listoderinfo.Count > 0)
			{
				for (int i = 0; i < listoderinfo.Count; i++)
				{
					string item = string.Concat(new object[]
					{
						"INSERT INTO ShopNum1_OrderOperateLog(Guid,OrderInfoGuid,CreateUser,OderStatus,ShipmentStatus,PaymentStatus,CurrentStateMsg,NextStateMsg,Memo,OperateDateTime,IsDeleted)VALUES('",
						listoderinfo[i].Guid,
						"','",
						listoderinfo[i].Guid,
						"','",
						listoderinfo[i].MemLoginID,
						"','",
						listoderinfo[i].OderStatus,
						"','",
						listoderinfo[i].ShipmentStatus,
						"','",
						listoderinfo[i].PaymentStatus,
						"','已经下单','等待付款','','",
						DateTime.Now.ToString(),
						"','0');"
					});
					list.Add(item);
					string item2 = string.Concat(new object[]
					{
						"INSERT INTO ShopNum1_OrderInfo( Guid,PayMentMemLoginID,MemLoginID,OrderNumber,TradeID,OderStatus,ShipmentStatus,PaymentStatus,Name,Email,Address,Postalcode,Tel,Mobile,ClientToSellerMsg,SellerToClientMsg,PaymentGuid,PaymentName,OutOfStockOperate,PackGuid,PackName,BlessCardGuid,BlessCardName,BlessCardContent,InvoiceTitle,InvoiceContent,ProductPrice,DispatchPrice,DispatchType,PaymentPrice,PackPrice,BlessCardPrice,AlreadPayPrice,SurplusPrice,UseScore,ScorePrice,ShouldPayPrice,FromAd,FromUrl,CreateTime,ConfirmTime,ShipmentNumber,BuyType,ActivityGuid,PayMemo,InvoiceType,InvoiceTax,Discount,Deposit,ShopID,ReceivedDays,IsMemdelay,ShopName,FeeType,RegionCode,JoinActiveType,ActvieContent,UsedFavourTicket,OrderType,IsMinus,SubstationID ) VALUES ( '",
						listoderinfo[i].Guid,
						"','",
						Operator.FilterString(listoderinfo[i].PayMentMemLoginID),
						"','",
						Operator.FilterString(listoderinfo[i].MemLoginID),
						"','",
						listoderinfo[i].OrderNumber,
						"','",
						listoderinfo[i].TradeID,
						"',",
						listoderinfo[i].OderStatus,
						",",
						listoderinfo[i].ShipmentStatus,
						",",
						listoderinfo[i].PaymentStatus,
						",'",
						Operator.FilterString(listoderinfo[i].Name),
						"','",
						Operator.FilterString(listoderinfo[i].Email),
						"','",
						Operator.FilterString(listoderinfo[i].Address),
						"','",
						Operator.FilterString(listoderinfo[i].Postalcode),
						"','",
						Operator.FilterString(listoderinfo[i].Tel),
						"','",
						Operator.FilterString(listoderinfo[i].Mobile),
						"','",
						Operator.FilterString(listoderinfo[i].ClientToSellerMsg),
						"','",
						Operator.FilterString(listoderinfo[i].SellerToClientMsg),
						"','",
						listoderinfo[i].PaymentGuid,
						"','",
						Operator.FilterString(listoderinfo[i].PaymentName),
						"','",
						Operator.FilterString(listoderinfo[i].OutOfStockOperate),
						"','",
						listoderinfo[i].PackGuid,
						"','",
						Operator.FilterString(listoderinfo[i].PackName),
						"','",
						listoderinfo[i].BlessCardGuid,
						"','",
						Operator.FilterString(listoderinfo[i].BlessCardName),
						"','",
						Operator.FilterString(listoderinfo[i].BlessCardContent),
						"','",
						Operator.FilterString(listoderinfo[i].InvoiceTitle),
						"','",
						Operator.FilterString(listoderinfo[i].InvoiceContent),
						"',",
						listoderinfo[i].ProductPrice,
						",",
						listoderinfo[i].DispatchPrice,
						",",
						listoderinfo[i].DispatchType,
						",",
						listoderinfo[i].PaymentPrice,
						",",
						listoderinfo[i].PackPrice,
						",",
						listoderinfo[i].BlessCardPrice,
						",",
						listoderinfo[i].AlreadPayPrice,
						",",
						listoderinfo[i].SurplusPrice,
						",",
						listoderinfo[i].UseScore,
						",",
						listoderinfo[i].ScorePrice,
						",",
						listoderinfo[i].ShouldPayPrice,
						",'",
						Operator.FilterString(listoderinfo[i].FromAd),
						"','",
						Operator.FilterString(listoderinfo[i].FromUrl),
						"','",
						Operator.FilterString(listoderinfo[i].CreateTime),
						"','",
						listoderinfo[i].ConfirmTime,
						"','",
						Operator.FilterString(listoderinfo[i].ShipmentNumber),
						"','",
						Operator.FilterString(listoderinfo[i].BuyType),
						"','",
						listoderinfo[i].ActivityGuid,
						"','",
						Operator.FilterString(listoderinfo[i].PayMemo),
						"','",
						Operator.FilterString(listoderinfo[i].InvoiceType),
						"',",
						listoderinfo[i].InvoiceTax,
						",",
						listoderinfo[i].Discount,
						",",
						listoderinfo[i].Deposit,
						",'",
						listoderinfo[i].ShopID,
						"', ",
						listoderinfo[i].ReceivedDays,
						", ",
						listoderinfo[i].IsMemdelay,
						",'",
						listoderinfo[i].ShopName,
						"',",
						listoderinfo[i].FeeType,
						",'",
						listoderinfo[i].RegionCode,
						"',",
						listoderinfo[i].JoinActiveType,
						",'",
						listoderinfo[i].ActvieContent,
						"','",
						listoderinfo[i].UsedFavourTicket,
						"',",
						listoderinfo[i].OrderType,
						",",
						listoderinfo[i].IsMinus,
						",'",
						listoderinfo[i].SubstationID,
						"')"
					});
					list.Add(item2);
				}
			}
			if (listOrderProduct.Count > 0)
			{
				for (int j = 0; j < listOrderProduct.Count; j++)
				{
					string item3 = string.Concat(new object[]
					{
						"INSERT INTO ShopNum1_OrderProduct( Guid,OrderInfoGuid,ProductGuid,RepertoryNumber,BuyNumber,MarketPrice,ShopPrice,BuyPrice,Attributes,SpecificationName,SpecificationValue,IsShipment,IsReal,ExtensionAttriutes,GroupPrice,IsJoinActivity,DetailedSpecifications,MemLoginID,ShopID,CreateTime,ProductImg,OrderType,ProductName ) VALUES ( '",
						listOrderProduct[j].Guid,
						"','",
						listOrderProduct[j].OrderInfoGuid,
						"','",
						listOrderProduct[j].ProductGuid,
						"','",
						Operator.FilterString(listOrderProduct[j].RepertoryNumber),
						"',",
						listOrderProduct[j].BuyNumber,
						",",
						listOrderProduct[j].MarketPrice,
						",",
						listOrderProduct[j].ShopPrice,
						",",
						listOrderProduct[j].BuyPrice,
						",'",
						Operator.FilterString(listOrderProduct[j].Attributes),
						"','",
						Operator.FilterString(listOrderProduct[j].SpecificationName),
						"','",
						Operator.FilterString(listOrderProduct[j].SpecificationValue),
						"',",
						listOrderProduct[j].IsShipment,
						",",
						listOrderProduct[j].IsReal,
						",'",
						Operator.FilterString(listOrderProduct[j].ExtensionAttriutes),
						"',",
						listOrderProduct[j].GroupPrice,
						",",
						listOrderProduct[j].IsJoinActivity,
						",'",
						listOrderProduct[j].DetailedSpecifications,
						"','",
						listOrderProduct[j].MemLoginID,
						"','",
						listOrderProduct[j].ShopID,
						"','",
						listOrderProduct[j].CreateTime,
						"','",
						listOrderProduct[j].ProductImg,
						"','",
						listOrderProduct[j].OrderType,
						"','",
						listOrderProduct[j].ProductName,
						"')"
					});
					list.Add(item3);
					if (listOrderProduct[j].setStock == "0")
					{
						string item4 = string.Concat(new string[]
						{
							"UPDATE ShopNum1_Shop_Product SET RepertoryCount=RepertoryCount-",
							listOrderProduct[j].BuyNumber.ToString(),
							" WHERE Guid ='",
							listOrderProduct[j].ProductGuid.ToString(),
							"' And repertorycount>=",
							listOrderProduct[j].BuyNumber.ToString(),
							";"
						});
						list.Add(item4);
						string item5 = string.Concat(new string[]
						{
							"UPDATE ShopNum1_Group_Product SET groupstock=groupstock-",
							listOrderProduct[j].BuyNumber.ToString(),
							" WHERE productguid='",
							listOrderProduct[j].ProductGuid.ToString(),
							"' And groupstock>=",
							listOrderProduct[j].BuyNumber.ToString(),
							";"
						});
						list.Add(item5);
						string item6 = string.Concat(new string[]
						{
							"UPDATE ShopNum1_SpecProudct SET goodsstock=goodsstock-",
							listOrderProduct[j].BuyNumber.ToString(),
							" WHERE productguid='",
							listOrderProduct[j].ProductGuid.ToString(),
							"' And SpecDetail ='",
							listOrderProduct[j].SpecificationValue.ToString(),
							"' And goodsstock>=",
							listOrderProduct[j].BuyNumber.ToString(),
							";"
						});
						list.Add(item6);
					}
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
		public DataSet GetOrderDetail(string strOrderGuId, string strMemloginId, string strOrderType, string strIsShop)
		{
			string[] array = new string[4];
			string[] array2 = new string[4];
			array[0] = "@OrderGuId";
			array2[0] = strOrderGuId;
			array[1] = "@MemloginId";
			array2[1] = strMemloginId;
			array[2] = "@OrderType";
			array2[2] = strOrderType;
			array[3] = "@IsShop";
			array2[3] = strIsShop;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_Shop_GetOrderDetail", array, array2);
		}
		public DataTable SearchOrderInfoByGuid(string guids, string OrderType)
		{
			string text = string.Empty;
			text = "SELECT Guid,ShopID,ShopName,OrderType,MemLoginID,OrderNumber,OderStatus,ShipmentStatus,PaymentStatus,Name,Email,Address,Postalcode,Tel,Mobile,ClientToSellerMsg,SellerToClientMsg,PaymentGuid,PaymentName,OutOfStockOperate,PackGuid,PackName,BlessCardGuid,BlessCardName,BlessCardContent,InvoiceTitle,InvoiceContent,ProductPrice,DispatchPrice,PaymentPrice,PackPrice,BlessCardPrice,AlreadPayPrice,SurplusPrice,UseScore,ScorePrice,ShouldPayPrice,FromAd,FromUrl,CreateTime,ConfirmTime,PayTime,DispatchTime,ShipmentNumber,BuyType,ActivityGuid,PayMemo,InvoiceType,InvoiceTax,Discount,BuyIsDeleted  FROM ShopNum1_OrderInfo  WHERE 0=0 ";
			if (guids != "-1")
			{
				text = text + " AND Guid in (" + guids.Trim() + ") ";
			}
			if (OrderType != "-1")
			{
				text = text + " AND OrderType =" + OrderType + " ";
			}
			text += " ORDER BY CreateTime DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchStatus(string guid)
		{
			string text = string.Empty;
			text = "SELECT Guid,OderStatus,ShipmentStatus,PaymentStatus  FROM ShopNum1_OrderInfo  WHERE 0=0 ";
			if (guid != "-1")
			{
				text = text + " AND ordernumber='" + guid + "'";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchAddressByGuid(string guid)
		{
			string text = string.Empty;
			text = "SELECT Guid,Name,Email,Address,Postalcode,Tel,Mobile  FROM ShopNum1_OrderInfo  WHERE 0=0 ";
			if (guid != "-1")
			{
				text = string.Concat(new object[]
				{
					text,
					" AND Guid='",
					new Guid(guid),
					"'"
				});
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int UpdateAddressByGuid(string guid, string name, string email, string address, string postalcode, string string_0, string mobile)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"UPDATE  ShopNum1_OrderInfo SET Name='",
				Operator.FilterString(name),
				"', Email='",
				Operator.FilterString(email),
				"', Address='",
				Operator.FilterString(address),
				"',Postalcode='",
				Operator.FilterString(postalcode),
				"', Tel='",
				Operator.FilterString(string_0),
				"',Mobile='",
				Operator.FilterString(mobile),
				"' WHERE Guid='",
				guid,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable SearchOtherByGuid(string guid)
		{
			string text = string.Empty;
			text = "SELECT Guid,ClientToSellerMsg,SellerToClientMsg,BlessCardGuid,BlessCardName,BlessCardContent,InvoiceTitle,InvoiceContent,OutOfStockOperate,InvoiceType   FROM ShopNum1_OrderInfo  WHERE 0=0 ";
			if (guid != "-1")
			{
				text = string.Concat(new object[]
				{
					text,
					" AND Guid='",
					new Guid(guid),
					"'"
				});
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int UpdateOtherInfo(string guid, string blessCardPrice, string blessCardGuid, string blessCardName, string blessCardContent, string invoiceType, string invoic, string invoiceTitle, string invoiceContent, string clientToSellerMsg, string outOfStockOperate, string sellerToClientMsg)
		{
			DataTable dataTable = this.SearchPriceByGuid(guid);
			string text = dataTable.Rows[0]["ProductPrice"].ToString();
			string text2 = "(" + invoic + "/100)*" + text;
			text2 = this.ComputeInvoicePrice(text2);
			string text3 = string.Concat(new string[]
			{
				text,
				"-0.00+",
				text2,
				"+",
				dataTable.Rows[0]["DispatchPrice"].ToString(),
				"+",
				dataTable.Rows[0]["InsurePrice"].ToString(),
				"+",
				dataTable.Rows[0]["PaymentPrice"].ToString(),
				"+",
				dataTable.Rows[0]["PackPrice"].ToString(),
				"+",
				blessCardPrice
			});
			text3 = this.ComputeOderPrice(text3);
			string text4 = string.Concat(new string[]
			{
				text3,
				"-",
				dataTable.Rows[0]["AlreadPayPrice"].ToString(),
				"-",
				dataTable.Rows[0]["SurplusPrice"].ToString(),
				"-",
				dataTable.Rows[0]["ScorePrice"].ToString()
			});
			text4 = this.ComputeShouldPayPrice(text4);
			string strSql = string.Empty;
			if (blessCardGuid == string.Empty)
			{
				blessCardGuid = Guid.Empty.ToString();
			}
			strSql = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_OrderInfo SET BlessCardContent='",
				Operator.FilterString(blessCardContent),
				"', BlessCardGuid='",
				blessCardGuid,
				"', BlessCardName='",
				Operator.FilterString(blessCardName),
				"', InvoiceType='",
				Operator.FilterString(invoiceType),
				"', InvoiceTitle='",
				Operator.FilterString(invoiceTitle),
				"',InvoiceContent='",
				Operator.FilterString(invoiceContent),
				"', ClientToSellerMsg='",
				Operator.FilterString(clientToSellerMsg),
				"',OutOfStockOperate='",
				Operator.FilterString(outOfStockOperate),
				"',SellerToClientMsg='",
				Operator.FilterString(sellerToClientMsg),
				"',ProductPrice=",
				Convert.ToDecimal(text),
				",InvoiceTax=",
				Convert.ToDecimal(text2),
				",ShouldPayPrice=",
				Convert.ToDecimal(text4),
				",BlessCardPrice=",
				Convert.ToDecimal(blessCardPrice),
				"  WHERE Guid='",
				guid,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int UpdateOrderPrice(string guid, string productPrice, string dispatchPrice, string insurePrice, string paymentPrice, string packPrice, string blessCardPrice, string alreadPayPrice, string surplusPrice, string useScore, string scorePrice, string invoiceTax, string discount, string shouldPayPrice)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_OrderInfo SET ProductPrice=",
				Convert.ToDecimal(productPrice),
				", DispatchPrice=",
				Convert.ToDecimal(dispatchPrice),
				", InsurePrice=",
				Convert.ToDecimal(insurePrice),
				", PaymentPrice=",
				Convert.ToDecimal(paymentPrice),
				", PackPrice=",
				Convert.ToDecimal(packPrice),
				", BlessCardPrice=",
				Convert.ToDecimal(blessCardPrice),
				", AlreadPayPrice=",
				Convert.ToDecimal(alreadPayPrice),
				", SurplusPrice=",
				Convert.ToDecimal(surplusPrice),
				", UseScore=",
				Convert.ToInt32(useScore),
				", ScorePrice=",
				Convert.ToDecimal(scorePrice),
				", InvoiceTax=",
				Convert.ToDecimal(invoiceTax),
				",Discount=",
				Convert.ToDecimal(discount),
				",ShouldPayPrice=",
				Convert.ToDecimal(shouldPayPrice),
				" WHERE Guid='",
				guid,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable SearchPriceByGuid(string guid)
		{
			string text = string.Empty;
			text = "SELECT Guid,ProductPrice,DispatchPrice,PaymentPrice,PackPrice,BlessCardPrice,AlreadPayPrice,SurplusPrice,UseScore,ScorePrice,ShouldPayPrice,InvoiceTax,Discount,InvoiceType  FROM ShopNum1_OrderInfo  WHERE 0=0 ";
			if (guid != "-1")
			{
				text = string.Concat(new object[]
				{
					text,
					" AND Guid='",
					new Guid(guid),
					"'"
				});
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public string ComputeInvoicePrice(string invoiceTax)
		{
			string strSql = string.Empty;
			strSql = "SELECT " + invoiceTax + " AS InvoiceTax";
			return DatabaseExcetue.ReturnDataTable(strSql).Rows[0]["InvoiceTax"].ToString();
		}
		public string ComputeOderPrice(string orderPrice)
		{
			string strSql = string.Empty;
			strSql = "SELECT " + orderPrice + " AS OrderPrice";
			return DatabaseExcetue.ReturnDataTable(strSql).Rows[0]["OrderPrice"].ToString();
		}
		public string ComputeShouldPayPrice(string shouldPayPrice)
		{
			string strSql = string.Empty;
			strSql = "SELECT " + shouldPayPrice + " AS ShouldPayPrice";
			return DatabaseExcetue.ReturnDataTable(strSql).Rows[0]["ShouldPayPrice"].ToString();
		}
		public int UpdateDispatchInfo(string guid, string dispatchModeGuid, string dispatchModeName, string dispatchPrice, string insurePrice, string regionCode)
		{
			DataTable dataTable = this.SearchPriceByGuid(guid);
			string text = dataTable.Rows[0]["ProductPrice"].ToString();
			string text2 = string.Concat(new string[]
			{
				text,
				"-0.00+",
				dataTable.Rows[0]["InvoiceTax"].ToString(),
				"+",
				dispatchPrice,
				"+",
				insurePrice,
				"+",
				dataTable.Rows[0]["PaymentPrice"].ToString(),
				"+",
				dataTable.Rows[0]["PackPrice"].ToString(),
				"+",
				dataTable.Rows[0]["BlessCardPrice"].ToString()
			});
			text2 = this.ComputeOderPrice(text2);
			string text3 = string.Concat(new string[]
			{
				text2,
				"-",
				dataTable.Rows[0]["AlreadPayPrice"].ToString(),
				"-",
				dataTable.Rows[0]["SurplusPrice"].ToString(),
				"-",
				dataTable.Rows[0]["ScorePrice"].ToString()
			});
			text3 = this.ComputeShouldPayPrice(text3);
			string strSql = string.Empty;
			if (dispatchModeGuid == string.Empty)
			{
				dispatchModeGuid = Guid.Empty.ToString();
			}
			strSql = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_OrderInfo SET DispatchPrice=",
				Convert.ToDecimal(dispatchPrice),
				",ShouldPayPrice=",
				Convert.ToDecimal(text3),
				"RegionCode=",
				regionCode,
				" WHERE Guid='",
				guid,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int UpdatePaymentInfo(string guid, string paymentGuid, string paymentName, decimal pPrice, int ispercent)
		{
            //0m;
			DataTable dataTable = this.SearchPriceByGuid(guid);
			string text = dataTable.Rows[0]["ShouldPayPrice"].ToString();
			string strSql = string.Empty;
			if (paymentGuid == string.Empty)
			{
				paymentGuid = Guid.Empty.ToString();
			}
			strSql = string.Concat(new string[]
			{
				"UPDATE  ShopNum1_OrderInfo SET PaymentGuid='",
				paymentGuid,
				"', PaymentName='",
				Operator.FilterString(paymentName),
				"', PaymentPrice=0.00,ShouldPayPrice=",
				text,
				" WHERE Guid='",
				guid,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int UpdatePaymentInfo(string guid, string paymentGuid, string paymentName, decimal pPrice)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_OrderInfo SET PaymentGuid='",
				paymentGuid,
				"', PaymentName='",
				Operator.FilterString(paymentName),
				"', PaymentPrice=",
				pPrice,
				"  WHERE Guid='",
				guid,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int UpdateProduct(string guid, string productPrice, string shopSettingPath, List<ShopNum1_OrderProduct> listOrderProduct)
		{
			List<string> list = new List<string>();
			string item = string.Empty;
			item = "DELETE FROM ShopNum1_OrderProduct WHERE OrderInfoGuid='" + guid + "'";
			list.Add(item);
			if (listOrderProduct.Count > 0)
			{
				for (int i = 0; i < listOrderProduct.Count; i++)
				{
					string item2 = string.Concat(new object[]
					{
						"INSERT INTO ShopNum1_OrderProduct( Guid,OrderInfoGuid,ProductGuid,Name,RepertoryNumber,BuyNumber,MarketPrice,ShopPrice,BuyPrice,Attributes,IsShipment,IsReal,ExtensionAttriutes,IsJoinActivity,CreateTime ) VALUES ( '",
						listOrderProduct[i].Guid,
						"','",
						guid,
						"','",
						listOrderProduct[i].ProductGuid,
						"','",
						Operator.FilterString(listOrderProduct[i].Name),
						"','",
						Operator.FilterString(listOrderProduct[i].RepertoryNumber),
						"',",
						listOrderProduct[i].BuyNumber,
						",",
						listOrderProduct[i].MarketPrice,
						",",
						listOrderProduct[i].ShopPrice,
						",",
						listOrderProduct[i].BuyPrice,
						",'",
						Operator.FilterString(listOrderProduct[i].Attributes),
						"',",
						listOrderProduct[i].IsShipment,
						",",
						listOrderProduct[i].IsReal,
						",'",
						Operator.FilterString(listOrderProduct[i].ExtensionAttriutes),
						"',",
						listOrderProduct[i].IsJoinActivity,
						",'",
						listOrderProduct[i].CreateTime,
						"')"
					});
					list.Add(item2);
				}
			}
			DataTable dataTable = this.SearchPriceByGuid(guid);
			ShopSettings shopSettings = new ShopSettings();
			string str = "0.00";
			List<string> list2 = new List<string>();
			list2 = shopSettings.GetValueAllInvoice(shopSettingPath);
			for (int j = 0; j < list2.Count; j++)
			{
				string[] array = list2[j].Split(new char[]
				{
					'|'
				});
				if (array[0].ToString() == dataTable.Rows[0]["InvoiceType"].ToString())
				{
					str = array[1].ToString();
				}
			}
			string text = "(" + str + "/100)*" + productPrice;
			text = this.ComputeInvoicePrice(text);
			string text2 = string.Concat(new string[]
			{
				productPrice,
				"-0.00+",
				text,
				"+",
				dataTable.Rows[0]["DispatchPrice"].ToString(),
				"+",
				dataTable.Rows[0]["InsurePrice"].ToString(),
				"+",
				dataTable.Rows[0]["Paymentprice"].ToString(),
				"+",
				dataTable.Rows[0]["PackPrice"].ToString(),
				"+",
				dataTable.Rows[0]["BlessCardPrice"].ToString()
			});
			text2 = this.ComputeOderPrice(text2);
			string text3 = string.Concat(new string[]
			{
				text2,
				"-",
				dataTable.Rows[0]["AlreadPayPrice"].ToString(),
				"-",
				dataTable.Rows[0]["SurplusPrice"].ToString(),
				"-",
				dataTable.Rows[0]["ScorePrice"].ToString()
			});
			text3 = this.ComputeShouldPayPrice(text3);
			item = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_OrderInfo SET InvoiceTax=",
				Convert.ToDecimal(text),
				", ProductPrice=",
				Convert.ToDecimal(productPrice),
				",ShouldPayPrice=",
				Convert.ToDecimal(text3),
				" WHERE Guid='",
				guid,
				"'"
			});
			list.Add(item);
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
		public DataTable Search(string guid)
		{
			string text = string.Empty;
			text = "SELECT A.Guid,A.MemLoginID,A.OrderNumber,A.OderStatus,A.ShipmentStatus,A.PaymentStatus,A.Name,A.Email,A.Address,A.Postalcode,A.Tel,A.Mobile,A.ClientToSellerMsg,A.SellerToClientMsg,A.PaymentGuid,A.PaymentName,A.OutOfStockOperate,A.PackGuid,A.PackName,A.BlessCardGuid,A.BlessCardName,A.BlessCardContent,A.InvoiceTitle,A.InvoiceContent,A.ProductPrice,A.DispatchPrice,A.PaymentPrice,A.PackPrice,A.BlessCardPrice,A.AlreadPayPrice,A.SurplusPrice,A.UseScore,A.ScorePrice,A.ShouldPayPrice,A.FromAd,A.FromUrl,A.CreateTime,A.ConfirmTime,A.PayTime,A.DispatchType,A.DispatchTime,A.ShipmentNumber,A.BuyType,A.ActivityGuid,A.PayMemo,A.InvoiceType,A.InvoiceTax,A.Discount,A.Deposit,A.JoinActiveType,A.ActvieContent,A.UsedFavourTicket,A.IsDeleted,A.ShopID,A.ShopName,A.RegionCode,LogisticsCompanyCode,LogisticsCompany  FROM ShopNum1_OrderInfo AS A  WHERE 1=1 ";
			if (guid != "-1")
			{
				text = string.Concat(new object[]
				{
					text,
					" AND A.Guid='",
					new Guid(guid),
					"'"
				});
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Search1(string guid)
		{
			string text = string.Empty;
			text = "SELECT Guid,PayMentMemLoginID,Name,Email,Address,Postalcode,Tel,Mobile,RegionCode,OrderNumber,TradeID,OderStatus,CreateTime,PaymentStatus,ShipmentStatus,PaymentGuid,PaymentName,DispatchPrice,DispatchType,ProductPrice,PaymentPrice,ShouldPayPrice,IsDeleted,ShopID,ShopName,AlipayTradeId  FROM ShopNum1_OrderInfo  WHERE 0=0 ";
			if (guid != "-1")
			{
				text = text + " AND Guid='" + guid + "'";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchOrderPayInfo(string guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT A.Guid,A.Name,A.Email,A.Address,A.Postalcode,A.Tel,A.Mobile,A.RegionCode,A.OrderNumber,A.TradeID,A.OderStatus,A.CreateTime,A.PaymentStatus,A.ShipmentStatus,A.PaymentGuid,A.PaymentName,B.IsPercent,B.Charge,A.DispatchPrice,A.DispatchType,A.ProductPrice,A.PaymentPrice,A.ShouldPayPrice,A.IsDeleted,A.ShopID,A.ShopName  FROM ShopNum1_OrderInfo  AS A,ShopNum1_Payment AS B  WHERE A.PaymentGuid=B.Guid AND a.Guid =@guid";
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.ReturnDataTable(strSql, array, array2);
		}
		public DataTable SearchOrderPayInfo(string guid, string memLoginID)
		{
			string str = string.Empty;
			if (memLoginID.ToLower() == "admin")
			{
				str = "ShopNum1_Payment";
			}
			else
			{
				str = "ShopNum1_ShopPayment";
			}
			string strSql = string.Empty;
			strSql = "SELECT C.Email AS ShopEmail,C.Tel AS ShopTel,C.AddressValue AS ShopAddress,A.Guid,A.Name,A.Email,A.Address,A.Postalcode,A.Tel,A.Mobile,A.RegionCode,A.OrderNumber,A.TradeID,A.OderStatus,A.CreateTime,A.PayTime,A.DispatchTime,A.ReceiptTime,A.ReceivedDays,A.IsMemdelay,A.PaymentStatus,A.ShipmentStatus,A.PaymentGuid,A.PaymentName,B.IsPercent,B.Charge,A.DispatchPrice,A.DispatchType,A.ProductPrice,A.PaymentPrice,A.ShouldPayPrice,A.ClientToSellerMsg,A.SellerToClientMsg,A.IsDeleted,A.ShopID,A.FeeType,A.IsMinus,A.IsLogistics,A.LogisticsCompanyCode,A.ShipmentNumber,A.LogisticsCompany,A.ShopName  FROM ShopNum1_ShopInfo AS C, ShopNum1_OrderInfo  AS A left join " + str + " AS B on A.PaymentGuid=B.Guid WHERE a.Guid =@guid AND C.MemLoginID=A.ShopID";
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.ReturnDataTable(strSql, array, array2);
		}
		public DataTable SearchOrderShouldPrice(string guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT ShouldPayPrice,ShopID ,ProductPrice FROM ShopNum1_OrderInfo WHERE Guid =@guid";
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.ReturnDataTable(strSql, array, array2);
		}
		public DataTable GetGroupPriceTotalByOrderInfoGuid(string orderinfoguid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@orderinfoguid";
			array2[0] = orderinfoguid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetGroupPriceTotalByOrderInfoGuid", array, array2);
		}
		public DataTable SearchOrderSimpleProduct(string guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT A.ProductGuid,B.ThumbImage,A.MemLoginID,B.MemLoginID AS ShopMemLoginID,A.[ProductName],A.BuyPrice,A.BuyNumber,B.MinusFee,B.FeeType,C.DispatchPrice,C.IsMinus,C.DispatchType FROM ShopNum1_OrderProduct AS A, ShopNum1_Shop_Product AS B,ShopNum1_OrderInfo AS C WHERE A.ProductGuid=B.Guid AND A.OrderInfoGuid=C.Guid AND A.OrderInfoGuid=@guid";
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.ReturnDataTable(strSql, array, array2);
		}
		public DataTable SearchOrderSimpleProduct(string guid, string shopid)
		{
			string text = string.Empty;
			text = "SELECT b.ProductName, b.BuyPrice, b.BuyNumber   FROM ShopNum1_OrderInfo a,ShopNum1_OrderProduct b  WHERE a.Guid=b.OrderInfoGuid ";
			if (guid != "-1")
			{
				text = text + " AND a.Guid='" + guid + "'";
			}
			if (guid != string.Empty)
			{
				text = text + " AND a.ShopID= '" + shopid + "'";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int SetOderStatus1(string guid, int oderStatus, int paymentStatus, int shipmentStatus, DateTime confirmTime)
		{
			string text = string.Empty;
			text = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_OrderInfo SET OderStatus=",
				oderStatus,
				", PaymentStatus=",
				paymentStatus,
				", ShipmentStatus=",
				shipmentStatus
			});
			if (paymentStatus == 1 && shipmentStatus == 0)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					",PayTime='",
					confirmTime,
					"'"
				});
			}
			if (shipmentStatus == 1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					",DispatchTime='",
					confirmTime,
					"'"
				});
			}
			if (shipmentStatus == 2)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					",ReceiptTime='",
					confirmTime,
					"'"
				});
			}
			text = text + " WHERE Guid='" + guid + "'";
			return DatabaseExcetue.RunNonQuery(text);
		}
		public int SetPaymentStatus2(string guid, int oderStatus, int paymentStatus, int shipmentStatus, DateTime payTime, decimal alreadPayPrice, decimal shouldPayPrice)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_OrderInfo SET OderStatus=",
				oderStatus,
				", PaymentStatus=",
				paymentStatus,
				", ShipmentStatus=",
				shipmentStatus,
				",AlreadPayPrice=",
				alreadPayPrice,
				",ShouldPayPrice=",
				shouldPayPrice,
				", PayTime='",
				payTime,
				"' WHERE tradeid='",
				guid,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int SetPaymentStatus2(string guid, int oderStatus, int paymentStatus, int shipmentStatus, DateTime payTime, decimal alreadPayPrice, decimal shouldPayPrice, string strTrade_no)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_OrderInfo SET OderStatus=",
				oderStatus,
				", PaymentStatus=",
				paymentStatus,
				", ShipmentStatus=",
				shipmentStatus,
				",AlreadPayPrice=",
				alreadPayPrice,
				",ShouldPayPrice=",
				shouldPayPrice,
				", PayTime='",
				payTime,
				"',AlipayTradeId='",
				strTrade_no,
				"' WHERE TradeId='",
				guid,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int SetPaymentStatus0(string guid, int oderStatus, int paymentStatus, int shipmentStatus, decimal alreadPayPrice, decimal shouldPayPrice)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_OrderInfo  SET OderStatus=",
				oderStatus,
				", PaymentStatus=",
				paymentStatus,
				", ShipmentStatus=",
				shipmentStatus,
				",AlreadPayPrice=",
				alreadPayPrice,
				",ShouldPayPrice=",
				shouldPayPrice,
				"  WHERE Guid='",
				guid,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int SetShipmentStatus3(string guid, int oderStatus, int paymentStatus, int shipmentStatus)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_OrderInfo SET OderStatus=",
				oderStatus,
				", PaymentStatus=",
				paymentStatus,
				", ShipmentStatus=",
				shipmentStatus,
				" WHERE Guid='",
				guid,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int SetShipmentStatus1(string guid, int oderStatus, int paymentStatus, int shipmentStatus, DateTime dispatchTime, string shipmentNumber)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_OrderInfo SET OderStatus=",
				oderStatus,
				", PaymentStatus=",
				paymentStatus,
				", ShipmentStatus=",
				shipmentStatus,
				",DispatchTime='",
				dispatchTime,
				"',ShipmentNumber='",
				Operator.FilterString(shipmentNumber),
				"' WHERE Guid='",
				guid,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int SetShipmentStatus0(string guid, int oderStatus, int paymentStatus, int shipmentStatus, string shipmentNumber)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_OrderInfo SET OderStatus=",
				oderStatus,
				", PaymentStatus=",
				paymentStatus,
				", ShipmentStatus=",
				shipmentStatus,
				",ShipmentNumber='",
				Operator.FilterString(shipmentNumber),
				"' WHERE Guid='",
				guid,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int SetShipmentStatus2(string guid, int oderStatus, int paymentStatus, int shipmentStatus)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_OrderInfo SET OderStatus=",
				oderStatus,
				", PaymentStatus=",
				paymentStatus,
				", ShipmentStatus=",
				shipmentStatus,
				" WHERE Guid='",
				guid,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int SetOderStatus4(string guid, int oderStatus, int paymentStatus, int shipmentStatus, decimal alreadPayPrice, decimal shouldPayPrice, string shipmentNumber)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_OrderInfo SET OderStatus=",
				oderStatus,
				", PaymentStatus=",
				paymentStatus,
				", ShipmentStatus=",
				shipmentStatus,
				",AlreadPayPrice=",
				alreadPayPrice,
				",ShouldPayPrice=",
				shouldPayPrice,
				",ShipmentNumber='",
				Operator.FilterString(shipmentNumber),
				"' WHERE Guid='",
				guid,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int SetOderStatus2(string guid, int oderStatus, int paymentStatus, int shipmentStatus, decimal alreadPayPrice, decimal shouldPayPrice, string shipmentNumber)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_OrderInfo SET OderStatus=",
				oderStatus,
				", PaymentStatus=",
				paymentStatus,
				", ShipmentStatus=",
				shipmentStatus,
				",AlreadPayPrice=",
				alreadPayPrice,
				",ShouldPayPrice=",
				shouldPayPrice,
				",ShipmentNumber='",
				Operator.FilterString(shipmentNumber),
				"' WHERE Guid='",
				guid,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int SetOderStatus3(string guid, int oderStatus, int paymentStatus, int shipmentStatus, decimal alreadPayPrice, decimal shouldPayPrice, string shipmentNumber)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_OrderInfo SET OderStatus=",
				oderStatus,
				", PaymentStatus=",
				paymentStatus,
				", ShipmentStatus=",
				shipmentStatus,
				",AlreadPayPrice=",
				alreadPayPrice,
				",ShouldPayPrice=",
				shouldPayPrice,
				",ShipmentNumber='",
				Operator.FilterString(shipmentNumber),
				"' WHERE Guid='",
				guid,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Delete(string guid)
		{
			string item = string.Empty;
			List<string> list = new List<string>();
			item = "DELETE FROM ShopNum1_OrderInfo WHERE orderNumber IN (" + guid + ")";
			list.Add(item);
			item = "DELETE FROM ShopNum1_OrderProduct WHERE orderNumber IN (" + guid + ")";
			list.Add(item);
			item = "DELETE FROM ShopNum1_OrderOperateLog WHERE orderNumber IN (" + guid + ")";
			list.Add(item);
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
		public int UpdateDelete(string guid)
		{
			string item = string.Empty;
			List<string> list = new List<string>();
			item = "UPDATE ShopNum1_OrderInfo SET ISDELETED=1 WHERE Guid IN (" + guid + ")";
			list.Add(item);
			item = "UPDATE ShopNum1_OrderProduct SET ISDELETED=1 WHERE OrderInfoGuid IN (" + guid + ")";
			list.Add(item);
			item = "UPDATE ShopNum1_OrderOperateLog SET ISDELETED=1 WHERE OrderInfoGuid IN (" + guid + ")";
			list.Add(item);
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
		public int UserDelete(string guids)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guids";
			array2[0] = guids;
			return DatabaseExcetue.RunProcedure("Pro_ShopNum1_OrderInfoUserDel", array, array2);
		}
		public DataTable SearchOrder(string orderNumber)
		{
			string text = string.Empty;
			text = "SELECT OrderNumber,OderStatus,ShipmentStatus,PaymentStatus,Guid ,memloginID ,createtime ,PaymentName ,PayTime ,ShipmentNumber ,FromUrl ,InvoiceType ,InvoiceTitle ,InvoiceContent ,ClientToSellerMsg ,SellerToClientMsg ,Name ,Email ,Address, Postalcode ,Tel ,Mobile, InvoiceTax,DispatchPrice,PaymentPrice,AlreadPayPrice,SurplusPrice,ScorePrice,LogisticsCompanyCode,LogisticsCompany  FROM ShopNum1_OrderInfo  WHERE 0=0 ";
			if (Operator.FormatToEmpty(orderNumber) != string.Empty)
			{
				text = text + " AND OrderNumber='" + Operator.FilterString(orderNumber) + "'";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchShipmentStatus1(string dispatchTime)
		{
			string text = string.Empty;
			text = "SELECT OrderNumber,OderStatus,ShipmentStatus,PaymentStatus,ShipmentNumber, DispatchTime   FROM ShopNum1_OrderInfo  WHERE 0=0 AND  ShipmentStatus =1 ";
			if (Operator.FormatToEmpty(dispatchTime) != string.Empty)
			{
				text = text + " AND DispatchTime>='" + Operator.FilterString(dispatchTime) + "' ";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchByMemLoginID(string memLoginID, int type)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"SELECT Guid,MemLoginID,OrderNumber,OderStatus,ShipmentStatus,PaymentStatus,ClientToSellerMsg,SellerToClientMsg,PaymentGuid,PaymentName,OutOfStockOperate,ProductPrice,AlreadPayPrice,ShopID,SurplusPrice,UseScore,ScorePrice,ShouldPayPrice,CreateTime,ConfirmTime,PayTime,DispatchTime,ShipmentNumber,PayMemo,BuyIsDeleted  FROM ShopNum1_OrderInfo  WHERE  MemLoginID='",
				Operator.FilterString(memLoginID),
				"' AND BuyIsDeleted=0 AND OrderType=",
				type,
				" ORDER BY CreateTime DESC"
			});
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetAllStatus(string guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT OderStatus,ShipmentStatus,PaymentStatus,IsDeleted   FROM ShopNum1_OrderInfo  WHERE Guid ='" + guid + "'";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetOrderProductGuidAndByNumber(string orderNumber)
		{
			string strSql = string.Empty;
			strSql = "SELECT ProductGuid,BuyNumber  FROM ShopNum1_OrderProduct  WHERE OrderInfoGuid In (SELECT Guid FROM ShopNum1_OrderInfo Where OrderNumber ='" + Operator.FilterString(orderNumber) + "')";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable SearchOrderInfoByGuid(string guids)
		{
			string text = string.Empty;
			text = "SELECT Guid,MemLoginID,OrderNumber,OderStatus,PayMentMemLoginID,ShipmentStatus,PaymentStatus,Name,Email,Address,Postalcode,Tel,Mobile,ClientToSellerMsg,SellerToClientMsg,PaymentGuid,PaymentName,OutOfStockOperate,PackGuid,PackName,BlessCardGuid,BlessCardName,BlessCardContent,InvoiceTitle,InvoiceContent,ProductPrice,DispatchPrice,PaymentPrice,PackPrice,BlessCardPrice,AlreadPayPrice,SurplusPrice,UseScore,ScorePrice,ShouldPayPrice,FromAd,FromUrl,CreateTime,ConfirmTime,PayTime,DispatchTime,ShipmentNumber,BuyType,ActivityGuid,PayMemo,InvoiceType,InvoiceTax,BuyIsDeleted  FROM ShopNum1_OrderInfo  WHERE 0=0 ";
			if (guids != "-1")
			{
				text = text + " AND Guid in (" + guids.Trim() + ")";
			}
			text += " ORDER BY CreateTime DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int UpdateIsPayDeposit(string guid, string isPayDeposit)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"UPDATE  ShopNum1_OrderInfo SET IsPayDeposit=",
				isPayDeposit,
				" WHERE Guid='",
				guid,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public string GetOrderNumberByGuid(string guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT OrderNumber,Guid  FROM ShopNum1_OrderInfo  WHERE Guid='" + guid + "'";
			return DatabaseExcetue.ReturnDataTable(strSql).Rows[0]["OrderNumber"].ToString();
		}
		public DataTable SearchOrderInfo(string orderNumber)
		{
			string text = string.Empty;
			text = "SELECT Guid,MemLoginID,OrderNumber,OderStatus,ShipmentStatus,PaymentStatus,Name,Email,Address,Postalcode,Tel,Mobile,ClientToSellerMsg,SellerToClientMsg,PaymentGuid,PaymentName,OutOfStockOperate,PackGuid,PackName,BlessCardGuid,BlessCardName,BlessCardContent,InvoiceTitle,InvoiceContent,ProductPrice,DispatchPrice,PaymentPrice,PackPrice,BlessCardPrice,AlreadPayPrice,SurplusPrice,UseScore,ScorePrice,ShouldPayPrice,FromAd,FromUrl,CreateTime,ConfirmTime,PayTime,DispatchTime,ShipmentNumber,BuyType,ActivityGuid,PayMemo,InvoiceType,InvoiceTax,Discount,Deposit,IsDeleted,FeeType,TradeID,PayMentMemLoginID,IdentifyCode  FROM ShopNum1_OrderInfo  WHERE 0=0 ";
			text = text + " AND TradeId='" + orderNumber + "'";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchNewOrderByMemLoginID(string memloginID, string showcount)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"SELECT TOP  ",
				showcount,
				" Guid,MemLoginID,OrderNumber,OderStatus,ShipmentStatus,PaymentStatus,Name,Email,Address,Postalcode,Tel,Mobile,ClientToSellerMsg,SellerToClientMsg,PaymentGuid,PaymentName,OutOfStockOperate,PackGuid,PackName,BlessCardGuid,BlessCardName,BlessCardContent,InvoiceTitle,InvoiceContent,ProductPrice,DispatchPrice,PaymentPrice,PackPrice,BlessCardPrice,AlreadPayPrice,SurplusPrice,UseScore,ScorePrice,ShouldPayPrice,FromAd,FromUrl,CreateTime,ConfirmTime,PayTime,DispatchTime,ShipmentNumber,BuyType,ActivityGuid,PayMemo,InvoiceType,InvoiceTax,Discount,Deposit,IsDeleted  FROM ShopNum1_OrderInfo  WHERE MemLoginID='",
				memloginID,
				"' ORDER BY CreateTime DESC"
			});
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable OrderInfoApplyCheck(string OrderNumber)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@OrderNumber";
			array2[0] = OrderNumber;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_OrderInfoApplyCheck", array, array2);
		}
		public DataTable GetMemberBuyProductCount(string strmemberLoginID, string productguid)
		{
			string text = string.Empty;
			text = string.Concat(new string[]
			{
				"select isNull(count(a.guid),0) from  dbo.ShopNum1_OrderInfo  as a ,ShopNum1_OrderProduct as b  where a.Guid=b.OrderInfoGuid   and a.MemLoginID='",
				strmemberLoginID,
				"' and b.ProductGuid='",
				productguid,
				"'"
			});
			return DatabaseExcetue.ReturnDataTable(text.ToString());
		}
		public int BackNormalProudctRepertoryCount(string productguid, string buycount)
		{
			string strSql = string.Concat(new string[]
			{
				"UPDATE  dbo.ShopNum1_Product SET RepertoryCount=RepertoryCount+",
				buycount,
				" WHERE Guid='",
				productguid,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int BackSpecificationProudctRepertoryCount(string productguid, string detail, string buycount)
		{
			string strSql = string.Concat(new string[]
			{
				"UPDATE  dbo.ShopNum1_SpecificationProudct SET RepertoryCount=RepertoryCount+",
				buycount,
				" WHERE ProductGuid='",
				productguid,
				"' and Detail='",
				detail,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int BackUsedFavourTicket(string usercode, string memberloginid)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"update ShopNum1_MemberFavourTicket set LimitTimes=LimitTimes+1 where FavourTicketCode='",
				usercode,
				"'  and MemLoginID='",
				memberloginid,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int UpdateAddress(ShopNum1_OrderInfo orderInfo, string orderguid)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"UPDATE  ShopNum1_OrderInfo SET Name='",
				orderInfo.Name,
				"',Email='",
				orderInfo.Email,
				"',Address='",
				orderInfo.Address,
				"',Postalcode='",
				orderInfo.Postalcode,
				"',Tel='",
				orderInfo.Tel,
				"',Mobile='",
				orderInfo.Mobile,
				"',RegionCode='",
				orderInfo.RegionCode,
				"' WHERE Guid='",
				orderguid,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int UpdatePostFee(string postFee, string orderguid)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@DispatchPrice";
			array2[0] = postFee;
			array[1] = "@orderguid";
			array2[1] = orderguid;
			return DatabaseExcetue.RunProcedure("[Pro_ShopNum1_UpdateOrderDispatchPrice]", array, array2);
		}
		public DataTable SearchOrderProductByOrderGuid(string orderguid)
		{
			string text = string.Empty;
			text = "SELECT a.ProductGuid,a.Name,a.ShopID,a.MemLoginID,b.OriginalImage  FROM ShopNum1_OrderProduct as a,ShopNum1_Shop_Product as b  WHERE a.ProductGuid=b.Guid";
			if (orderguid != "-1")
			{
				text = text + " AND a.OrderInfoGuid in ('" + orderguid + "')";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetOrderCountByGuid(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_shop_GetOrderCountByGuid", array, array2);
		}
		public DataTable GetOrderCountByOrderNumber(string orderNumber)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@orderNumber";
			array2[0] = orderNumber;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_shop_GetOrderCountByOrderNumber", array, array2);
		}
		public DataTable GetProductTypeByOrderGuid(string guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT IsPanicBuy,IsSpellBuy FROM dbo.ShopNum1_Shop_Product WHERE Guid=(SELECT ProductGuid FROM ShopNum1_OrderProduct WHERE OrderInfoGuid='" + guid + "')";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataSet CheckOrderState(string ordernumber, string memloginid)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@ordernumber";
			array2[0] = ordernumber;
			array[1] = "@memloginid";
			array2[1] = memloginid;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_OrderInfoCheckOrderState", array, array2);
		}
		public DataSet CheckTradeState(string TradeID, string memloginid)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@TradeID";
			array2[0] = TradeID;
			array[1] = "@memloginid";
			array2[1] = memloginid;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_OrderInfoCheckMultOrderState", array, array2);
		}
		public DataSet SingleTradePayMent(string OrderNumber, string memloginid)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@OrderNumber";
			array2[0] = OrderNumber;
			array[1] = "@memloginid";
			array2[1] = memloginid;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_OrderInfoSingleTradePayMent", array, array2);
		}
		public DataTable GetOrderInfoByGuid(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetOrderInfoByGuid", array, array2);
		}
		public DataTable GetOrderInfoByMemloginID(string memloginid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@memloginid";
			array2[0] = memloginid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetOrderInfoByMemloginID", array, array2);
		}
		public DataTable GetOrderGuidAndTypeByOrderNum(string string_0)
		{
			string strSql = string.Empty;
			strSql = "SELECT OrderType,Guid FROM ShopNum1_OrderInfo WHERE OrderNumber='" + string_0 + "'";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataSet OrderInfoGetSimpleByTradeID(string tradeid, string memloginid)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@tradeid";
			array2[0] = tradeid;
			array[1] = "@memloginid";
			array2[1] = memloginid;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_OrderInfoGetSimpleByTradeID", array, array2);
		}
		public int AddOtherOrderInfo(ShopNum1_Shop_OtherOrderInfo shopNum1_Shop_OtherOrderInfo)
		{
			string[] array = new string[15];
			string[] array2 = new string[15];
			array[0] = "@guid";
			array2[0] = shopNum1_Shop_OtherOrderInfo.Guid.ToString();
			array[1] = "@tradeid";
			array2[1] = shopNum1_Shop_OtherOrderInfo.TradeID;
			array[2] = "@relevanceid";
			array2[2] = shopNum1_Shop_OtherOrderInfo.RelevanceID;
			array[3] = "@unitprice";
			array2[3] = shopNum1_Shop_OtherOrderInfo.UnitPrice.ToString();
			array[4] = "@buynumber";
			array2[4] = shopNum1_Shop_OtherOrderInfo.BuyNumber.ToString();
			array[5] = "@totalprice";
			array2[5] = shopNum1_Shop_OtherOrderInfo.TotalPrice.ToString();
			array[6] = "@memloginid";
			array2[6] = shopNum1_Shop_OtherOrderInfo.MemLoginID;
			array[7] = "@orderstatus";
			array2[7] = shopNum1_Shop_OtherOrderInfo.OrderStatus.ToString();
			array[8] = "@type";
			array2[8] = shopNum1_Shop_OtherOrderInfo.Type;
			array[9] = "@description";
			array2[9] = shopNum1_Shop_OtherOrderInfo.Description;
			array[10] = "@createtime";
			array2[10] = shopNum1_Shop_OtherOrderInfo.CreateTime.ToString();
			array[11] = "@paymentstatus";
			array2[11] = shopNum1_Shop_OtherOrderInfo.PaymentStatus.ToString();
			array[12] = "@Name";
			array2[12] = shopNum1_Shop_OtherOrderInfo.Name;
			array[13] = "@PaymentType";
			array2[13] = shopNum1_Shop_OtherOrderInfo.PaymentType.ToString();
			array[14] = "@PaymentName";
			array2[14] = shopNum1_Shop_OtherOrderInfo.PaymentName;
			return DatabaseExcetue.RunProcedure("Pro_Shop_AddOtherOrderInfo", array, array2);
		}
		public DataTable GetOtherOrderInfoByTradeID(string tradeid, string memloginid)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@tradeid";
			array2[0] = tradeid;
			array[1] = "@memloginid";
			array2[1] = memloginid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetOtherOrderInfoByTradeID", array, array2);
		}
		public DataTable GetOrderGuidByTradeIDAndMemloginid(string tradeid, string memloginid)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@tradeid";
			array2[0] = tradeid;
			array[1] = "@memloginid";
			array2[1] = memloginid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetOrderGuidByTradeIDAndMemloginid", array, array2);
		}
		public DataTable GetOrderGuidByOrderNumberAndMemloginid(string ordernumber, string memloginid)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@ordernumber";
			array2[0] = ordernumber;
			array[1] = "@memloginid";
			array2[1] = memloginid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetOrderGuidByOrderNumberAndMemloginid", array, array2);
		}
		public string GetShopIDByOrderGuid(string orderguid)
		{
			string strSql = string.Empty;
			strSql = "SELECT ShopID FROM ShopNum1_OrderInfo WHERE guid='" + orderguid + "'";
			return DatabaseExcetue.ReturnString(strSql);
		}
		public string GetPayMentMemLoginIDByOrderGuid(string orderguid)
		{
			string strSql = string.Empty;
			strSql = "SELECT PayMentMemLoginID FROM ShopNum1_OrderInfo WHERE guid='" + orderguid + "'";
			return DatabaseExcetue.ReturnString(strSql);
		}
		public DataTable Search(int isDeleted)
		{
			string text = string.Empty;
			text = "SELECT Guid,Name,Memo,Charge,IsPercent  FROM ShopNum1_Payment  WHERE 1=1 ";
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND IsDeleted=",
					isDeleted,
					" "
				});
			}
			text += "Order By OrderID Desc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchOrderInfoList(string shopid, string ordernumber, string memloginid, string oderstatus, string timebegin, string timeend, string PaymentTypeGuid)
		{
			string[] array = new string[7];
			string[] array2 = new string[7];
			array[0] = "@shopid";
			array2[0] = shopid;
			array[1] = "@ordernumber";
			array2[1] = ordernumber;
			array[2] = "@memloginid";
			array2[2] = memloginid;
			array[3] = "@oderstatus";
			array2[3] = oderstatus;
			array[4] = "@timebegin";
			array2[4] = timebegin;
			array[5] = "@timeend";
			array2[5] = timeend;
			array[6] = "@paymentGuid";
			array2[6] = PaymentTypeGuid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_SearchOrderInfoList", array, array2);
		}
		public DataTable SearchOrderInfoList(string shopid, string ordernumber, string memloginid, string oderstatus, string ordertype, string timebegin, string timeend, string PaymentTypeGuid)
		{
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@shopid";
			array2[0] = shopid;
			array[1] = "@ordernumber";
			array2[1] = ordernumber;
			array[2] = "@memloginid";
			array2[2] = memloginid;
			array[3] = "@oderstatus";
			array2[3] = oderstatus;
			array[4] = "@timebegin";
			array2[4] = timebegin;
			array[5] = "@timeend";
			array2[5] = timeend;
			array[6] = "@paymentGuid";
			array2[6] = PaymentTypeGuid;
			array[7] = "@ordertype";
			array2[7] = ordertype;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_SearchOrderInfoList2", array, array2);
		}
		public int DeleteOrderInfo(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedure("Pro_ShopNum1_DeleteOrderInfo", array, array2);
		}
		public DataTable GetOrderInfo(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetOrderInfo", array, array2);
		}
		public DataTable GetOrderInfo(string guid, string paymentmemloginid)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@guid";
			array2[0] = guid;
			array[1] = "@paymentmemloginid";
			array2[1] = paymentmemloginid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetOrderInfo", array, array2);
		}
		public int UpdateOrderInfoStatus(string guid, string statusname, string statusvalues)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@guid";
			array2[0] = guid;
			array[1] = "@statusname";
			array2[1] = statusname;
			array[2] = "@statusvalues";
			array2[2] = statusvalues;
			return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdateOrderInfoStatus", array, array2);
		}
		public int CancelOrder(string guid, string cancelreason, int oderstatus)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@guid";
			array2[0] = guid;
			array[1] = "@cancelreason";
			array2[1] = cancelreason;
			array[2] = "@oderstatus";
			array2[2] = oderstatus.ToString();
			return DatabaseExcetue.RunProcedure("Pro_ShopNum1_CancelOrder", array, array2);
		}
		public int UpdateOrderMessage(string guid, string message, string messagetype)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@guid";
			array2[0] = guid;
			array[1] = "@message";
			array2[1] = message;
			array[2] = "@messagetype";
			array2[2] = messagetype;
			return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdateOrderMessage", array, array2);
		}
		public DataSet getProductOrderRecord(string ProductGuid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@ProductGuid";
			array2[0] = ProductGuid;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_ProductOrderRecord", array, array2);
		}
		public DataSet getProductOrderRecord(string ProductGuid, string OderStatus)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@ProductGuid";
			array2[0] = ProductGuid;
			array[1] = "@OderStatus";
			array2[1] = OderStatus;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_ProductOrderRecord", array, array2);
		}
		public DataSet getProductOrderRecord(string productguid, string oderstatus, string memloginid)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@productguid";
			array2[0] = productguid;
			array[1] = "@oderstatus";
			array2[1] = oderstatus;
			array[2] = "@memloginid";
			array2[2] = memloginid;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_ProductOrderRecord", array, array2);
		}
		public DataSet SearchProductOrderRecord(string productguid, string memloginid)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@productguid";
			array2[0] = productguid;
			array[1] = "@memloginid";
			array2[1] = memloginid;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_SearchProductOrderRecord", array, array2);
		}
		public DataTable GetOrderInfoByGuidShop(string guid, string shopid)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@guid";
			array2[0] = guid;
			array[1] = "@shopid";
			array2[1] = shopid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetOrderInfoByGuidShop", array, array2);
		}
		public DataTable SearchOrderInfoByProductGuid(string productguid)
		{
			string text = string.Empty;
			text = "SELECT MemLoginID  FROM ShopNum1_OrderProduct  WHERE 0=0 ";
			if (productguid != "-1")
			{
				text = text + " AND ProductGuid in ('" + productguid + "')";
			}
			text += " ORDER BY CreateTime DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int AddOrderCode(ShopNum1_MemberActivate MemberActivate)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"insert into ShopNum1_MemberActivate([Guid],Phone,[key],MemberID,pwd ,Email,extireTime,isinvalid,type)Values('",
				MemberActivate.Guid,
				"','",
				MemberActivate.Phone,
				"','",
				MemberActivate.key,
				"','",
				MemberActivate.MemberID,
				"','",
				MemberActivate.pwd,
				"','",
				MemberActivate.Email,
				"','",
				MemberActivate.extireTime,
				"',",
				MemberActivate.isinvalid,
				",",
				MemberActivate.type,
				")"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetCode(string member, int isinvalid, string code)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"SELECT [key] from ShopNum1_MemberActivate Where MemberID='",
				member,
				"' And isinvalid=1 And [key]='",
				code,
				"'"
			});
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int AddOrder(ShopNum1_OrderInfo orderInfo)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"insert into ShopNum1_OrderInfo(Guid,Tel,Mobile,ClientToSellerMsg,SellerToClientMsg,PaymentGuid,PaymentName,OutOfStockOperate,InvoiceTitle,InvoiceContent,ProductPrice,DispatchPrice,DispatchType,PaymentPrice,AlreadPayPrice,SurplusPrice,UseScore,ScorePrice,ShouldPayPrice,FromAd,FromUrl,CreateTime,ConfirmTime,PayTime,DispatchTime,ShipmentNumber,BuyType,ActivityGuid,PayMemo,InvoiceType,InvoiceTax,Discount,Deposit,OrderType,IsDeleted,BuyIsDeleted,SellIsDeleted,ShopID,RegionCode,ShopName,JoinActiveType,ActvieContent,UsedFavourTicket,FeeType,CancelReason,EndTime,IsBuyComment,IsSellComment,ReceiptTime,MemLoginID,TradeID,OrderNumber,OderStatus,ShipmentStatus,PaymentStatus,refundStatus,Name,Email,Address,PackPrice,BlessCardPrice,PayMentMemLoginID,Postalcode)Values('",
				orderInfo.Guid,
				"','",
				orderInfo.Tel,
				"','",
				orderInfo.Mobile,
				"','",
				orderInfo.ClientToSellerMsg,
				"','",
				orderInfo.SellerToClientMsg,
				"','",
				orderInfo.PaymentGuid,
				"','",
				orderInfo.PaymentName,
				"','",
				orderInfo.OutOfStockOperate,
				"','",
				orderInfo.InvoiceTitle,
				"','",
				orderInfo.InvoiceContent,
				"','",
				orderInfo.ProductPrice,
				"','",
				orderInfo.DispatchPrice,
				"',",
				orderInfo.DispatchType,
				",'",
				orderInfo.PaymentPrice,
				"','",
				orderInfo.AlreadPayPrice,
				"','",
				orderInfo.SurplusPrice,
				"',",
				orderInfo.UseScore,
				",'",
				orderInfo.ScorePrice,
				"','",
				orderInfo.ShouldPayPrice,
				"','",
				orderInfo.FromAd,
				"','",
				orderInfo.FromUrl,
				"','",
				orderInfo.CreateTime,
				"','",
				orderInfo.ConfirmTime,
				"','",
				orderInfo.PayTime,
				"','",
				orderInfo.DispatchTime,
				"','",
				orderInfo.ShipmentNumber,
				"','",
				orderInfo.BuyType,
				"','",
				orderInfo.ActivityGuid,
				"','",
				orderInfo.PayMemo,
				"','",
				orderInfo.InvoiceType,
				"','",
				orderInfo.InvoiceTax,
				"','",
				orderInfo.Discount,
				"','",
				orderInfo.Deposit,
				"',",
				orderInfo.OrderType,
				",",
				orderInfo.IsDeleted,
				",",
				orderInfo.BuyIsDeleted,
				",",
				orderInfo.SellIsDeleted,
				",'",
				orderInfo.ShopID,
				"','",
				orderInfo.RegionCode,
				"','",
				orderInfo.ShopName,
				"',",
				orderInfo.JoinActiveType,
				",'",
				orderInfo.ActvieContent,
				"','",
				orderInfo.UsedFavourTicket,
				"',",
				orderInfo.FeeType,
				",'",
				orderInfo.CancelReason,
				"','",
				orderInfo.EndTime,
				"',",
				orderInfo.IsBuyComment,
				",",
				orderInfo.IsSellComment,
				",'",
				orderInfo.ReceiptTime,
				"','",
				orderInfo.MemLoginID,
				"','",
				orderInfo.TradeID,
				"','",
				orderInfo.OrderNumber,
				"',",
				orderInfo.OderStatus,
				",",
				orderInfo.ShipmentStatus,
				",",
				orderInfo.PaymentStatus,
				",",
				orderInfo.refundStatus,
				",'",
				orderInfo.Name,
				"','",
				orderInfo.Email,
				"','",
				orderInfo.Address,
				"',",
				orderInfo.PackPrice,
				",",
				orderInfo.BlessCardPrice,
				",'",
				orderInfo.PayMentMemLoginID,
				"','",
				orderInfo.Postalcode,
				"')"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetProductInfoAndOrderProductInfo(string guid, string shopid)
		{
			string strSql = string.Empty;
			strSql = "SELECT A.PayMentGuid,A.ShouldPayPrice,A.DispatchType,C.FeeTemplateID,C.FeeType,C.Post_fee,C.Express_fee,C.Ems_fee,B.BuyNumber FROM ShopNum1_OrderInfo AS A, ShopNum1_OrderProduct AS B,ShopNum1_Shop_Product AS C WHERE A.Guid=B.OrderInfoGuid AND B.ProductGuid=C.Guid AND B.OrderInfoGuid=@guid AND B.ShopID=@ShopID";
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@guid";
			array2[0] = guid;
			array[1] = "@ShopID";
			array2[1] = shopid;
			return DatabaseExcetue.ReturnDataTable(strSql, array, array2);
		}
		public DataTable GetOrderInfoAndProductInfo(string guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT A.BuyPrice,A.BuyNumber,B.MinusFee,B.FeeType,B.FeeTemplateID,B.Post_fee,B.Ems_fee,B.Express_fee FROM ShopNum1_OrderProduct AS A,ShopNum1_Shop_Product AS B WHERE A.ProductGuid=B.Guid AND A.OrderInfoGuid=@guid";
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.ReturnDataTable(strSql, array, array2);
		}
		public int UpdataOrderInfoIsMinus(ShopNum1_OrderInfo shopNum1_OrderInfo)
		{
			string strSql = string.Empty;
			strSql = "UPDATE ShopNum1_OrderInfo SET Name=@Name,Email=@Email,Address=@Address,Postalcode=@Postalcode,Tel=@Tel,Mobile=@Mobile,RegionCode=@RegionCode,IsMinus=@IsMinus,ShouldPayPrice=@ShouldPayPrice,DispatchType=@DispatchType,DispatchPrice=@DispatchPrice WHERE Guid=@Guid";
			string[] array = new string[12];
			string[] array2 = new string[12];
			array[0] = "@Name";
			array2[0] = shopNum1_OrderInfo.Name;
			array[1] = "@Email";
			array2[1] = shopNum1_OrderInfo.Email;
			array[2] = "@Address";
			array2[2] = shopNum1_OrderInfo.Address;
			array[3] = "@Postalcode";
			array2[3] = shopNum1_OrderInfo.Postalcode;
			array[4] = "@Tel";
			array2[4] = shopNum1_OrderInfo.Tel;
			array[5] = "@Mobile";
			array2[5] = shopNum1_OrderInfo.Mobile;
			array[6] = "@RegionCode";
			array2[6] = shopNum1_OrderInfo.RegionCode;
			array[7] = "@IsMinus";
			array2[7] = shopNum1_OrderInfo.IsMinus.ToString();
			array[8] = "@DispatchType";
			array2[8] = shopNum1_OrderInfo.DispatchType.ToString();
			array[9] = "@ShouldPayPrice";
			array2[9] = shopNum1_OrderInfo.ShouldPayPrice.ToString();
			array[10] = "@Guid";
			array2[10] = shopNum1_OrderInfo.Guid.ToString();
			array[11] = "@DispatchPrice";
			array2[11] = shopNum1_OrderInfo.DispatchPrice.ToString();
			return DatabaseExcetue.RunNonQuery(strSql, array, array2);
		}
		public int UpdateFeePriceByGuid(string dispatchprice, string ispercent, string guid, string IsMinus)
		{
			string[] array = new string[4];
			string[] array2 = new string[4];
			array[0] = "@dispatchprice";
			array2[0] = dispatchprice;
			array[1] = "@ispercent";
			array2[1] = ispercent;
			array[2] = "@guid";
			array2[2] = guid;
			array[3] = "@IsMinus";
			array2[3] = IsMinus;
			return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdateFeePriceByGuid", array, array2);
		}
		public int OrderInfoLogistics(string guid, string islogistics, string logisticscompany, string logisticscompanycode, string shipmentnumber)
		{
			string text = "0";
			if (ShopSettings.GetValue("DecreaseRepertory") == "1")
			{
				text = "1";
			}
			string[] array = new string[7];
			string[] array2 = new string[7];
			array[0] = "@guid";
			array2[0] = guid;
			array[1] = "@islogistics";
			array2[1] = islogistics;
			array[2] = "@logisticscompany";
			array2[2] = logisticscompany;
			array[3] = "@logisticscompanycode";
			array2[3] = logisticscompanycode;
			array[4] = "@shipmentnumber";
			array2[4] = shipmentnumber;
			array[5] = "@isDecreaseRepertory";
			array2[5] = text;
			array[6] = "@DispatchTime";
			array2[6] = DateTime.Now.ToString();
			return DatabaseExcetue.RunProcedure("Pro_Shop_OrderInfoLogistics", array, array2);
		}
		public int UpdateSaleNumAndRepertCtByOrderGuid(string OrderGuid)
		{
			List<string> list = new List<string>();
			string item = string.Empty;
			DataTable productGuidAndBuyNum = this.GetProductGuidAndBuyNum(OrderGuid);
			foreach (DataRow dataRow in productGuidAndBuyNum.Rows)
			{
				item = string.Concat(new object[]
				{
					"UPDATE dbo.ShopNum1_Shop_Product SET SaleNumber=SaleNumber+",
					dataRow["BuyNumber"],
					", RepertoryCount=RepertoryCount-",
					dataRow["BuyNumber"],
					" WHERE Guid='",
					dataRow["ProductGuid"],
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
		public DataTable GetProductGuidAndBuyNum(string orderGuid)
		{
			string strSql = "SELECT ProductGuid,BuyNumber FROM dbo.ShopNum1_OrderProduct WHERE OrderInfoGuid=@orderGuid";
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@orderGuid";
			array2[0] = orderGuid;
			return DatabaseExcetue.ReturnDataTable(strSql, array, array2);
		}
		public DataTable GetCommentInfoAndSaleNumber(string guid, string shopid, string datatime)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@guid";
			array2[0] = guid;
			array[1] = "@shopid";
			array2[1] = shopid;
			array[2] = "@datatime";
			array2[2] = datatime;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetCommentInfoAndSaleNumber", array, array2);
		}
		public DataTable GetOrderStatusAndNumberByGuid(string guids)
		{
			string text = string.Empty;
			text = "SELECT OrderNumber,OderStatus   FROM ShopNum1_OrderInfo  WHERE 0=0 ";
			if (guids != "-1")
			{
				text = text + " AND Guid in (" + guids.Trim() + ")";
			}
			text += " ORDER BY CreateTime DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int MemberDelete(string guids, string filedName, string filedvalue)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@guids";
			array2[0] = guids;
			array[1] = "@filedvalue";
			array2[1] = filedvalue;
			array[2] = "@filedName";
			array2[2] = filedName;
			return DatabaseExcetue.RunProcedure("Pro_ShopNum1_OrderInfoMemberDel", array, array2);
		}
		public DataTable SearchByMemLoginID(string productname, string orderstatus, string ordernumber, string timestart, string timeend, string shopid, string memLoginID, int type)
		{
			string text = string.Empty;
			text = "SELECT distinct A.Guid,A.MemLoginID,A.OrderNumber,A.OderStatus,A.ShipmentStatus,A.PaymentStatus,A.ClientToSellerMsg,A.SellerToClientMsg,A.PaymentGuid,A.PaymentName,A.OutOfStockOperate,A.ProductPrice,A.AlreadPayPrice,A.ShopID,A.SurplusPrice,A.UseScore,A.ScorePrice,A.ShouldPayPrice,A.CreateTime,A.ConfirmTime,A.PayTime,A.DispatchTime,A.ShipmentNumber,A.PayMemo,A.BuyIsDeleted  FROM ShopNum1_OrderInfo AS A ,ShopNum1_OrderProduct AS B  WHERE A.Guid=B.OrderInfoGuid AND A.BuyIsDeleted=0 ";
			if (productname != "-1")
			{
				text = text + " AND B.Name LIKE '" + productname + "%' ";
			}
			if (orderstatus != "-1")
			{
				text = text + " AND A.OderStatus=" + orderstatus + " ";
			}
			if (ordernumber != "-1")
			{
				text = text + " AND A.OrderNumber='" + ordernumber + "' ";
			}
			if (timestart != "")
			{
				text = text + " AND A.CreateTime>='" + timestart + "' ";
			}
			if (timeend != "")
			{
				text = text + " AND A.CreateTime<='" + timeend + "' ";
			}
			if (shopid != "-1")
			{
				text = text + " AND A.ShopID='" + shopid + "' ";
			}
			if (memLoginID != "-1")
			{
				text = text + " AND A.MemLoginID='" + memLoginID + "' ";
			}
			if (type != -1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					" AND A.OrderType=",
					type,
					" "
				});
			}
			text += " ORDER BY CreateTime DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int UpdataReceivedDays(string orderguid, string shopid, string ismember, string days)
		{
			string text = "UPDATE dbo.ShopNum1_OrderInfo SET ReceivedDays=ReceivedDays+" + days + " ";
			if (ismember == "1")
			{
				text += " , IsMemdelay=1 ";
			}
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				" WHERE Guid= '",
				orderguid,
				"' AND ShopID='",
				shopid,
				"' "
			});
			return DatabaseExcetue.RunNonQuery(text);
		}
		public int UpdataOrderInfoIsMinus(string IsMinus, string DispatchType, string ShouldPayPrice, string Guid, string DispatchPrice)
		{
			string strSql = string.Empty;
			strSql = "UPDATE ShopNum1_OrderInfo SET IsMinus=@IsMinus,ShouldPayPrice=@ShouldPayPrice,DispatchType=@DispatchType,DispatchPrice=@DispatchPrice WHERE Guid=@Guid";
			string[] array = new string[5];
			string[] array2 = new string[5];
			array[0] = "@IsMinus";
			array2[0] = IsMinus;
			array[1] = "@DispatchType";
			array2[1] = DispatchType;
			array[2] = "@ShouldPayPrice";
			array2[2] = ShouldPayPrice;
			array[3] = "@Guid";
			array2[3] = Guid;
			array[4] = "@DispatchPrice";
			array2[4] = DispatchPrice;
			return DatabaseExcetue.RunNonQuery(strSql, array, array2);
		}
		public DataTable GetRestoreOrderByMemLoginID(string memLoginID)
		{
			string text = string.Empty;
			text = "SELECT distinct A.Guid,A.MemLoginID,A.OrderNumber,A.OderStatus,A.ShipmentStatus,A.PaymentStatus,A.ClientToSellerMsg,A.SellerToClientMsg,A.PaymentGuid,A.PaymentName,A.OutOfStockOperate,A.ProductPrice,A.AlreadPayPrice,A.ShopID,A.SurplusPrice,A.UseScore,A.ScorePrice,A.ShouldPayPrice,A.CreateTime,A.ConfirmTime,A.PayTime,A.DispatchTime,A.ShipmentNumber,A.PayMemo,A.BuyIsDeleted  FROM ShopNum1_OrderInfo AS A  WHERE A.BuyIsDeleted=1 AND MemloginId='" + memLoginID + "' ";
			text += " ORDER BY CreateTime DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int SetWaitBuyerPay(string strOderStatus, string ShipmentStatus, string PaymentStatus, string strGuid)
		{
			string strSql = string.Concat(new string[]
			{
				"update ShopNum1_OrderInfo Set PaymentStatus =",
				PaymentStatus,
				",OderStatus=",
				strOderStatus,
				",ShipmentStatus=",
				ShipmentStatus,
				" where guid='",
				strGuid,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable Search(string orderNumber, string memLoginID, string name, string address, string postalcode, string string_0, string mobile, string email, decimal shouldPayPrice1, decimal shouldPayPrice2, string createTime1, string createTime2, int isDeleted, string shopID, string shopName, string orderStatus, string orderType, string paymentStatus, string shipmentStatus)
		{
			string text = string.Empty;
			text = "SELECT DISTINCT A.Guid,A.MemLoginID,A.OrderNumber,A.OderStatus,A.OrderType,A.ShipmentStatus,A.PaymentStatus,A.Name,A.Email,A.Address,A.Postalcode,A.Tel,A.Mobile,A.ClientToSellerMsg,A.SellerToClientMsg,A.PaymentGuid,A.PaymentName,A.OutOfStockOperate,A.PackGuid,A.PackName,A.BlessCardGuid,A.BlessCardName,A.BlessCardContent,A.InvoiceTitle,A.InvoiceContent,A.ProductPrice,A.DispatchPrice,A.PaymentPrice,A.PackPrice,A.BlessCardPrice,A.AlreadPayPrice,A.SurplusPrice,A.UseScore,A.ScorePrice,A.ShouldPayPrice,A.FromAd,A.FromUrl,A.CreateTime,A.ConfirmTime,A.PayTime,A.DispatchTime,A.ShipmentNumber,A.BuyType,A.ActivityGuid,A.PayMemo,A.InvoiceType,A.InvoiceTax,A.Discount,A.ShopID,A.ShopName,A.IsDeleted,B.IsPanicBuy,B.IsSpellBuy  FROM ShopNum1_OrderInfo AS A,ShopNum1_Shop_Product AS B,ShopNum1_OrderProduct AS C  WHERE A.Guid=C.OrderInfoGuid AND C.ProductGuid=B.Guid ";
			if (Operator.FormatToEmpty(orderNumber) != string.Empty)
			{
				text = text + " AND A.OrderNumber LIKE '%" + Operator.FilterString(orderNumber) + "%'";
			}
			if (Operator.FormatToEmpty(memLoginID) != string.Empty)
			{
				text = text + " AND A.MemLoginID LIKE '%" + Operator.FilterString(memLoginID) + "%'";
			}
			if (Operator.FormatToEmpty(name) != string.Empty)
			{
				text = text + " AND A.Name LIKE '%" + Operator.FilterString(name) + "%'";
			}
			if (Operator.FormatToEmpty(address) != string.Empty)
			{
				text = text + " AND A.Address LIKE '%" + Operator.FilterString(address) + "%'";
			}
			if (Operator.FormatToEmpty(postalcode) != string.Empty)
			{
				text = text + "AND A.Postalcode LIKE '%" + Operator.FilterString(postalcode) + "%'";
			}
			if (Operator.FormatToEmpty(string_0) != string.Empty)
			{
				text = text + " AND A.Tel LIKE '%" + Operator.FilterString(string_0) + "%'";
			}
			if (Operator.FormatToEmpty(mobile) != string.Empty)
			{
				text = text + " AND A.Mobile LIKE '%" + Operator.FilterString(mobile) + "%'";
			}
			if (Operator.FormatToEmpty(email) != string.Empty)
			{
				text = text + " AND A.Email LIKE '%" + Operator.FilterString(email) + "%'";
			}
			if (orderType != "-1")
			{
				text = text + " AND A.OrderType=" + orderType + " ";
			}
			if (orderStatus != "-1")
			{
				text = text + " AND A.OderStatus=" + orderStatus;
			}
			if (Operator.FormatToEmpty(createTime1) != string.Empty)
			{
				text = text + " AND A.CreateTime>='" + Operator.FilterString(createTime1) + "' ";
			}
			if (Operator.FormatToEmpty(createTime2) != string.Empty)
			{
				text = text + " AND A.CreateTime<='" + Operator.FilterString(createTime2) + "' ";
			}
			if (shouldPayPrice1 != 0m)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND A.ShouldPayPrice>='",
					shouldPayPrice1,
					"' "
				});
			}
			if (shouldPayPrice2 != 0m)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND A.ShouldPayPrice<='",
					shouldPayPrice2,
					"' "
				});
			}
			if (Operator.FormatToEmpty(shopID) != string.Empty)
			{
				text = text + " AND A.ShopID  Like'" + Operator.FilterString(shopID) + "' ";
			}
			if (Operator.FormatToEmpty(shopName) != string.Empty)
			{
				text = text + " AND A.ShopName  Like'" + Operator.FilterString(shopName) + "' ";
			}
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND A.IsDeleted=",
					isDeleted,
					" "
				});
			}
			if (paymentStatus != "-1")
			{
				text = text + " AND A.paymentStatus=" + paymentStatus + " ";
			}
			if (shipmentStatus != "-1")
			{
				text = text + " AND A.shipmentStatus=" + shipmentStatus + " ";
			}
			text += " ORDER BY A.CreateTime DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Search(string orderNumber, string memLoginID, string name, string address, string postalcode, string string_0, string mobile, string email, decimal shouldPayPrice1, decimal shouldPayPrice2, string createTime1, string createTime2, int isDeleted, string shopID, string shopName, string orderStatus, string orderType)
		{
			string text = string.Empty;
			text = "SELECT DISTINCT A.Guid,A.MemLoginID,A.OrderNumber,A.OderStatus,A.OrderType,A.ShipmentStatus,A.PaymentStatus,A.Name,A.Email,A.Address,A.Postalcode,A.Tel,A.Mobile,A.ClientToSellerMsg,A.SellerToClientMsg,A.PaymentGuid,A.PaymentName,A.OutOfStockOperate,A.PackGuid,A.PackName,A.BlessCardGuid,A.BlessCardName,A.BlessCardContent,A.InvoiceTitle,A.InvoiceContent,A.ProductPrice,A.DispatchPrice,A.PaymentPrice,A.PackPrice,A.BlessCardPrice,A.AlreadPayPrice,A.SurplusPrice,A.UseScore,A.ScorePrice,A.ShouldPayPrice,A.FromAd,A.FromUrl,A.CreateTime,A.ConfirmTime,A.PayTime,A.DispatchTime,A.ShipmentNumber,A.BuyType,A.ActivityGuid,A.PayMemo,A.InvoiceType,A.InvoiceTax,A.Discount,A.ShopID,A.ShopName,A.IsDeleted,B.IsPanicBuy,B.IsSpellBuy  FROM ShopNum1_OrderInfo AS A,ShopNum1_Shop_Product AS B,ShopNum1_OrderProduct AS C  WHERE A.Guid=C.OrderInfoGuid AND C.ProductGuid=B.Guid ";
			if (Operator.FormatToEmpty(orderNumber) != string.Empty)
			{
				text = text + " AND A.OrderNumber LIKE '%" + Operator.FilterString(orderNumber) + "%'";
			}
			if (Operator.FormatToEmpty(memLoginID) != string.Empty)
			{
				text = text + " AND A.MemLoginID LIKE '%" + Operator.FilterString(memLoginID) + "%'";
			}
			if (Operator.FormatToEmpty(name) != string.Empty)
			{
				text = text + " AND A.Name LIKE '%" + Operator.FilterString(name) + "%'";
			}
			if (Operator.FormatToEmpty(address) != string.Empty)
			{
				text = text + " AND A.Address LIKE '%" + Operator.FilterString(address) + "%'";
			}
			if (Operator.FormatToEmpty(postalcode) != string.Empty)
			{
				text = text + "AND A.Postalcode LIKE '%" + Operator.FilterString(postalcode) + "%'";
			}
			if (Operator.FormatToEmpty(string_0) != string.Empty)
			{
				text = text + " AND A.Tel LIKE '%" + Operator.FilterString(string_0) + "%'";
			}
			if (Operator.FormatToEmpty(mobile) != string.Empty)
			{
				text = text + " AND A.Mobile LIKE '%" + Operator.FilterString(mobile) + "%'";
			}
			if (Operator.FormatToEmpty(email) != string.Empty)
			{
				text = text + " AND A.Email LIKE '%" + Operator.FilterString(email) + "%'";
			}
			if (orderType != "-1")
			{
				text = text + " AND A.OrderType=" + orderType + " ";
			}
			if (orderStatus != "-1")
			{
				text = text + " AND A.OderStatus=" + orderStatus;
			}
			if (Operator.FormatToEmpty(createTime1) != string.Empty)
			{
				text = text + " AND A.CreateTime>='" + Operator.FilterString(createTime1) + "' ";
			}
			if (Operator.FormatToEmpty(createTime2) != string.Empty)
			{
				text = text + " AND A.CreateTime<='" + Operator.FilterString(createTime2) + "' ";
			}
			if (shouldPayPrice1 != 0m)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND A.ShouldPayPrice>='",
					shouldPayPrice1,
					"' "
				});
			}
			if (shouldPayPrice2 != 0m)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND A.ShouldPayPrice<='",
					shouldPayPrice2,
					"' "
				});
			}
			if (Operator.FormatToEmpty(shopID) != string.Empty)
			{
				text = text + " AND A.ShopID  Like'" + Operator.FilterString(shopID) + "' ";
			}
			if (Operator.FormatToEmpty(shopName) != string.Empty)
			{
				text = text + " AND A.ShopName  Like'" + Operator.FilterString(shopName) + "' ";
			}
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND A.IsDeleted=",
					isDeleted,
					" "
				});
			}
			text += " ORDER BY A.CreateTime DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SelectList(string strcondition)
		{
			string strSql = "select * from ShopNum1_OrderInfo where  1=1  " + strcondition;
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable SelectList(string pagesize, string currentpage, string condition, string resultnum, string strOrderColumn, string strSortV)
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
			array2[3] = "ShopNum1_OrderInfo";
			array[4] = "@condition";
			array2[4] = condition;
			array[5] = "@ordercolumn";
			array2[5] = strOrderColumn;
			array[6] = "@sortvalue";
			array2[6] = strSortV;
			array[7] = "@resultnum";
			array2[7] = resultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
		public int UpdateOrderInfoStatus_tenpay(string guid, string statusname, string statusvalues)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@guid";
			array2[0] = guid;
			array[1] = "@statusname";
			array2[1] = statusname;
			array[2] = "@statusvalues";
			array2[2] = statusvalues;
			return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdateOrderInfoStatus_tenpay", array, array2);
		}
		public int UpdateByConfirmPay(string strordernum, string strname)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@ordernum";
			array2[0] = strordernum;
			array[1] = "@name";
			array2[1] = strname;
			return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdateByConfirmPay", array, array2);
		}
		public string SearchOrderInfoByOrderId(string strorderId, string strcolumn)
		{
			string text = "select " + strcolumn + " from ShopNum1_OrderInfo where 1=1";
			if (strorderId != "")
			{
				text = text + " and guid='" + strorderId + "'";
			}
			return DatabaseExcetue.ReturnString(text);
		}
		public DataTable SearchOrderInfoByOrdernum(string ordernum, string orderType)
		{
			string text = string.Empty;
			text = "SELECT Guid,ShopID,ShopName,OrderType,MemLoginID,OrderNumber,OderStatus,ShipmentStatus,PaymentStatus,Name,Email,Address,Postalcode,Tel,Mobile,ClientToSellerMsg,SellerToClientMsg,PaymentGuid,PaymentName,OutOfStockOperate,PackGuid,PackName,BlessCardGuid,BlessCardName,BlessCardContent,InvoiceTitle,InvoiceContent,ProductPrice,DispatchPrice,PaymentPrice,PackPrice,BlessCardPrice,AlreadPayPrice,SurplusPrice,UseScore,ScorePrice,ShouldPayPrice,FromAd,FromUrl,CreateTime,ConfirmTime,PayTime,DispatchTime,ShipmentNumber,BuyType,ActivityGuid,PayMemo,InvoiceType,InvoiceTax,Discount,BuyIsDeleted  FROM ShopNum1_OrderInfo  WHERE 0=0 ";
			if (ordernum != "-1")
			{
				text = text + " AND OrderNumber in (" + ordernum.Trim() + ") ";
			}
			if (orderType == "-2")
			{
				text += " AND feetype=2 ";
			}
			else if (orderType != "-1")
			{
				text = text + " AND OrderType =" + orderType + " ";
			}
			text += " ORDER BY CreateTime DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int DeleteOrderInfoByOrdernum(string ordernum, int Type, string memloginId)
		{
			string text = "update ShopNum1_OrderInfo set BuyIsDeleted=1 where OrderNumber in (" + ordernum.Trim() + ") ";
			if (memloginId != "admin")
			{
				if (Type == 1)
				{
					text = text + " and memloginId='" + memloginId + "'";
				}
				else
				{
					text = text + " and shopid='" + memloginId + "'";
				}
			}
			return DatabaseExcetue.RunNonQuery(text);
		}
		public int DeleteOrderInfoByAdminOrdernum(string ordernum, int Type, string memloginId)
		{
			string text = "delete from ShopNum1_OrderInfo where OrderNumber in (" + ordernum.Trim() + ") ";
			if (memloginId != "admin")
			{
				if (Type == 1)
				{
					text = text + " and memloginId='" + memloginId + "'";
				}
				else
				{
					text = text + " and shopid='" + memloginId + "'";
				}
			}
			return DatabaseExcetue.RunNonQuery(text);
		}
		public DataTable SelectOrderList(string pagesize, string currentpage, string condition, string resultnum, string strProName)
		{
			string text = "SELECT (SELECT top 1 refundstatus FROM shopnum1_refund where productguid=A.guid) as vrefund,(SELECT top 1 refundtype FROM shopnum1_refund where productguid=A.guid) as refundtype,A.Guid,A.shouldpayprice,A.memloginid,A.ordernumber,A.oderstatus,A.shipmentstatus,";
			text += "A.paymentstatus,A.refundstatus,A.ordertype,A.shopid,A.shopname,A.createtime,A.paymentname,A.BuyIsDeleted,A.dispatchprice,(select top 1 id from ShopNum1_OrderComplaint where orderid=A.ordernumber)as ocid,a.IsBuyComment,a.FeeType ";
			text += " FROM shopnum1_orderinfo A where 1=1 ";
			if (strProName.Trim() != "")
			{
				text = text + " and GuId in(select orderinfoguid from shopnum1_orderproduct where productname like '%" + strProName + "%')";
			}
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
			array2[5] = "createtime";
			array[6] = "@sortvalue";
			array2[6] = "desc";
			array[7] = "@resultnum";
			array2[7] = resultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
		public int UpdateOrderState(string strOrderGuId, string MemlogInId, string strOrderState, string strShipState, string strPayState, string strRefundState, string strIsShop)
		{
			string text = "UPDATE Shopnum1_orderinfo SET ";
			if (strOrderState != "")
			{
				text = text + "oderstatus='" + strOrderState + "',";
			}
			if (strShipState != "")
			{
				text = text + "ShipmentStatus='" + strShipState + "',";
			}
			if (strPayState != "")
			{
				text = text + "PaymentStatus='" + strPayState + "',";
			}
			if (strRefundState != "")
			{
				text = text + "refundstatus='" + strRefundState + "',";
			}
			text = text + "guid=guid where GuId='" + strOrderGuId + "'";
			if (strIsShop == "1")
			{
				text = text + " and ShopId='" + MemlogInId + "'";
			}
			else
			{
				text = text + " and MemloginId='" + MemlogInId + "'";
			}
			return DatabaseExcetue.RunNonQuery(text);
		}
		public DataTable GetOrderGuIdByTradeId(string strTradeid)
		{
			string strSql = "select A.guid,ordernumber,feeType,IdentifyCode,Mobile,A.MemloginId,B.ProductName,B.BuyNumber,A.ShopID from ShopNum1_orderinfo A inner join ShopNum1_orderProduct B on B.orderinfoguid=A.guid where tradeid='" + strTradeid + "'";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int UpdateOrderPrice(string strOrderNumber, string strMemloginId, string strNewPrice)
		{
			string strSql = string.Concat(new string[]
			{
				"UPDATE ShopNum1_orderinfo SET shouldpayPrice='",
				strNewPrice,
				"' where ordernumber='",
				strOrderNumber,
				"' and shopid='",
				strMemloginId,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int GetOrderIdentifyCodeIsEqual(string strOrderNumber, string strIdentifyCode)
		{
			string strSql = string.Concat(new string[]
			{
				"SELECT COUNT(0) FROM ShopNum1_OrderInfo WHERE OrderNumber='",
				strOrderNumber,
				"' AND IdentifyCode='",
				Operator.FilterString(strIdentifyCode),
				"'"
			});
			return (DatabaseExcetue.ReturnDataTable(strSql).Rows.Count > 0) ? 1 : 0;
		}
		public int UpdateCancelOrderInfo(string strCanDate)
		{
			string strSql = "select createtime,guid from shopnum1_orderinfo  where oderstatus=0 and isdeleted=0";
			DataTable dataTable = DatabaseExcetue.ReturnDataTable(strSql);
			int result;
			if (dataTable.Rows.Count > 0)
			{
				List<string> list = new List<string>();
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					if (Convert.ToDateTime(dataTable.Rows[i]["createtime"]).AddDays(double.Parse(strCanDate)) <= DateTime.Now)
					{
						string str = dataTable.Rows[i]["guid"].ToString();
						string strSql2 = "select productguid,buynumber,specificationvalue,attributes from shopnum1_orderproduct where orderinfoGuId='" + str + "' ";
						DataTable dataTable2 = DatabaseExcetue.ReturnDataTable(strSql2);
						if (dataTable2.Rows.Count > 0)
						{
							for (int j = 0; j < dataTable2.Rows.Count; j++)
							{
								if (dataTable2.Rows[j]["attributes"].ToString() == "1")
								{
									list.Add(string.Concat(new object[]
									{
										"UPDATE ShopNum1_Shop_Product SET RepertoryCount=RepertoryCount+",
										dataTable2.Rows[j]["buynumber"],
										" WHERE Guid ='",
										dataTable2.Rows[j]["productguid"],
										"';"
									}));
									list.Add(string.Concat(new object[]
									{
										"UPDATE ShopNum1_SpecProudct SET goodsstock=goodsstock+",
										dataTable2.Rows[j]["buynumber"],
										" WHERE  SpecDetail ='",
										dataTable2.Rows[j]["specificationvalue"],
										"';"
									}));
								}
								list.Add(string.Concat(new object[]
								{
									"UPDATE ShopNum1_Group_Product SET groupstock=groupstock+",
									dataTable2.Rows[j]["buynumber"],
									" WHERE productguid='",
									dataTable2.Rows[j]["productguid"],
									"';"
								}));
							}
						}
					}
				}
				try
				{
					DatabaseExcetue.RunTransactionSql(list);
					result = 1;
					return result;
				}
				catch
				{
					result = 0;
					return result;
				}
			}
			result = 0;
			return result;
		}
		public string GetCode(string strOrderGuId)
		{
			string strSql = "select IdentifyCode from shopnum1_orderinfo where guid='" + strOrderGuId + "'";
			return DatabaseExcetue.ReturnString(strSql);
		}
		public DataTable GetLifeOrderCount(string strMemLoginID)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@MemLoginID";
			array2[0] = strMemLoginID;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_GetLifeOrderCount_YueTao", array, array2);
		}
		public DataTable GetOrderInfoByCode(string strMemLoginID, string strCode)
		{
			string[] array = new string[2];
			string[] array2 = new string[2];
			array[0] = "@MemLoginID";
			array2[0] = strMemLoginID;
			array[1] = "@LifeCode";
			array2[1] = strCode;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_GetOrderInfoByCode_YueTao", array, array2);
		}
		public DataTable SelectOrderListNew(string pagesize, string currentpage, string condition, string resultnum, string strProName)
		{
			string text = "   SELECT A.* FROM ShopNum1_OrderInfo AS A LEFT JOIN ShopNum1_ShopInfo AS B      ";
			text += "   on A.ShopID=B.MemLoginID  ";
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
			array2[5] = "createtime";
			array[6] = "@sortvalue";
			array2[6] = "desc";
			array[7] = "@resultnum";
			array2[7] = resultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
		public DataTable GetPrintOrderNumbersByShopID(string shopID)
		{
			DataTable result = new DataTable();
			try
			{
				string strSql = " SELECT  orderNumber  FROM    ShopNum1_OrderInfo   WHERE   ShopID = @shopid AND IsLogistics = 1  AND LogisticsCompanyCode IS NOT NULL AND ShipmentStatus = 1";
				string[] paraName = new string[]
				{
					"@shopid"
				};
				string[] paraValue = new string[]
				{
					shopID
				};
				result = DatabaseExcetue.ReturnDataTable(strSql, paraName, paraValue);
			}
			catch (Exception)
			{
			}
			return result;
		}
	}
}
