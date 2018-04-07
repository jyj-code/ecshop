using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_ScoreOrderInfo_Action : IShopNum1_ScoreOrderInfo_Action
	{
		public int Add(ShopNum1_ScoreOrderInfo ScoreOrderInfo, List<ShopNum1_ScoreOrderProduct> ScoreOrderProduct)
		{
			string item = string.Empty;
			string item2 = string.Empty;
			string item3 = string.Empty;
			List<string> list = new List<string>();
			item = string.Concat(new object[]
			{
				"insert ShopNum1_ScoreOrderInfo(  Guid, OrderNumber, MemLoginID, ShopMemLoginID, ShopName, OderStatus, Name, Email, Address, Postalcode, Tel, Mobile, UserMsg, TotalScore, CreateTime, ConfirmTime, ModifyUser, ModifyTime, SubstationID, IsDeleted ) VALUES (  '",
				Operator.FilterString(ScoreOrderInfo.Guid),
				"',  '",
				Operator.FilterString(ScoreOrderInfo.OrderNumber),
				"',  '",
				Operator.FilterString(ScoreOrderInfo.MemLoginID),
				"',  '",
				Operator.FilterString(ScoreOrderInfo.ShopMemLoginID),
				"',  '",
				Operator.FilterString(ScoreOrderInfo.ShopName),
				"',  '",
				Operator.FilterString(ScoreOrderInfo.OderStatus),
				"',  '",
				Operator.FilterString(ScoreOrderInfo.Name),
				"',  '",
				Operator.FilterString(ScoreOrderInfo.Email),
				"',  '",
				Operator.FilterString(ScoreOrderInfo.Address),
				"',  '",
				Operator.FilterString(ScoreOrderInfo.Postalcode),
				"',  '",
				Operator.FilterString(ScoreOrderInfo.Tel),
				"',  '",
				Operator.FilterString(ScoreOrderInfo.Mobile),
				"',  '",
				Operator.FilterString(ScoreOrderInfo.UserMsg),
				"',  '",
				Operator.FilterString(ScoreOrderInfo.TotalScore),
				"',  '",
				Operator.FilterString(ScoreOrderInfo.CreateTime),
				"',  '",
				Operator.FilterString(ScoreOrderInfo.ConfirmTime),
				"',  '",
				Operator.FilterString(ScoreOrderInfo.ModifyUser),
				"',  '",
				Operator.FilterString(ScoreOrderInfo.ModifyTime),
				"',  '",
				Operator.FilterString(ScoreOrderInfo.SubstationID),
				"',  ",
				ScoreOrderInfo.IsDeleted,
				" )"
			});
			list.Add(item);
			if (ScoreOrderProduct.Count > 0)
			{
				for (int i = 0; i < ScoreOrderProduct.Count; i++)
				{
					item2 = string.Concat(new string[]
					{
						"insert ShopNum1_ScoreOrderProduct(  Guid, OrderNumber, ProductGuid, Name, RepertoryNumber, BuyNumber, Score ) VALUES (  '",
						Operator.FilterString(ScoreOrderProduct[i].Guid),
						"',  '",
						Operator.FilterString(ScoreOrderProduct[i].OrderNumber),
						"',  '",
						Operator.FilterString(ScoreOrderProduct[i].ProductGuid),
						"',  '",
						Operator.FilterString(ScoreOrderProduct[i].Name),
						"',  '",
						Operator.FilterString(ScoreOrderProduct[i].RepertoryNumber),
						"',  '",
						Operator.FilterString(ScoreOrderProduct[i].BuyNumber),
						"',  '",
						Operator.FilterString(ScoreOrderProduct[i].Score),
						"' )"
					});
					list.Add(item2);
					item3 = string.Concat(new object[]
					{
						" update  ShopNum1_Shop_ScoreProduct set RepertoryCount=RepertoryCount-",
						ScoreOrderProduct[i].BuyNumber,
						",HaveSale=HaveSale+",
						ScoreOrderProduct[i].BuyNumber,
						" where GuId='",
						ScoreOrderProduct[i].ProductGuid,
						"'"
					});
					list.Add(item3);
				}
			}
			int result;
			try
			{
				DatabaseExcetue.RunTransactionSql(list);
				result = 1;
			}
			catch (Exception)
			{
				result = 0;
			}
			return result;
		}
		public int Delete(string guids)
		{
			string strSql = string.Empty;
			strSql = "   delete ShopNum1_ScoreOrderInfo where  Guid in (" + guids + ")  ";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int DeleteProduct(string guids)
		{
			string text = string.Empty;
			text += "   DELETE  ShopNum1_ScoreOrderProduct WHERE   OrderNumber     IN(  ";
			text = text + "   SELECT OrderNumber FROM ShopNum1_ScoreOrderInfo  WHERE  Guid='" + guids + "')  ";
			return DatabaseExcetue.RunNonQuery(text);
		}
		public int DeleteProductNew(string guids)
		{
			string text = string.Empty;
			text += "   DELETE  ShopNum1_ScoreOrderProduct WHERE   OrderNumber     IN(  ";
			text = text + "   SELECT OrderNumber FROM ShopNum1_ScoreOrderInfo  WHERE  Guid=" + guids + ")  ";
			return DatabaseExcetue.RunNonQuery(text);
		}
		public int DeleteByOrderNumber(string OrderNumber)
		{
			string strSql = string.Empty;
			strSql = "   delete ShopNum1_ScoreOrderInfo where  OrderNumber in (" + OrderNumber + ")  ";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetInfoByGuid(string guid)
		{
			string str = guid.Replace("'", "");
			string strSql = string.Empty;
			strSql = "   select  * from  ShopNum1_ScoreOrderInfo  where Guid ='" + str + "'   ";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetInfoByOrderNumber(string OrderNumber)
		{
			string strSql = string.Empty;
			strSql = "   select  * from  ShopNum1_ScoreOrderInfo  where OrderNumber ='" + OrderNumber + "'   ";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int Update(ShopNum1_ScoreOrderInfo ScoreOrderInfo)
		{
			throw new NotImplementedException();
		}
		public int UseUserScore(string MemLoginID, string Score)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"   update ShopNum1_Member  set  Score=Score-",
				Score,
				" where  MemLoginID='",
				MemLoginID,
				"' "
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int UseUserScoreAdd(string MemLoginID, string Score)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"   update ShopNum1_Member  set  Score=Score+",
				Score,
				" where  MemLoginID='",
				MemLoginID,
				"' "
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetInfoInManage(string strWhere)
		{
			string strSql = string.Empty;
			strSql = "   select  * from  ShopNum1_ScoreOrderInfo  where 1=1  " + strWhere + "   ";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetAdressNameByCode(string Code)
		{
			string strSql = string.Empty;
			strSql = "   select  * from  ShopNum1_Region  where   Code='" + Code + "'     ";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetProductByOrderNumber(string OrderNumber)
		{
			string text = string.Empty;
			text = "    select A.*,B.Name as ProductName,B.OriginalImge,B.MemLoginID as IsShopMemLoginID,B.RepertoryNumber,B.MarketPrice,B.Score as ProductScore  from ShopNum1_ScoreOrderProduct as A left join ShopNum1_Shop_ScoreProduct as B on A.ProductGuid=B.Guid     ";
			text += "   where 1=1 ";
			if (!string.IsNullOrEmpty(OrderNumber))
			{
				text = text + "   and   A.OrderNumber='" + OrderNumber + "' ";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int ChangeOderStatus(string Guid, string OderStatus)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"   update ShopNum1_ScoreOrderInfo  set   OderStatus=",
				OderStatus,
				",ConfirmTime='",
				DateTime.Now,
				"'   where  Guid='",
				Guid,
				"' "
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetOrder(string OrderNumber, int OderStatus, string MemLoginID, int IsDeleted)
		{
			string text = string.Empty;
			text = "    select * from   ShopNum1_ScoreOrderInfo where 1=1     ";
			if (!string.IsNullOrEmpty(OrderNumber))
			{
				text = text + "   and   OrderNumber='" + Operator.FilterString(OrderNumber) + "' ";
			}
			if (OderStatus == 1 || OderStatus == 0)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"   and   OderStatus='",
					OderStatus,
					"' "
				});
			}
			if (!string.IsNullOrEmpty(MemLoginID))
			{
				text = text + "   and   MemLoginID='" + MemLoginID + "' ";
			}
			if (IsDeleted == 0 || IsDeleted == 1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"   and   IsDeleted=",
					IsDeleted,
					" "
				});
			}
			text += "  order  by  CreateTime desc    ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetShopInfo(string MemLoginID)
		{
			string text = string.Empty;
			text = "   select A.*,B.Mobile as UserMobile,B.Email as UserEmail from ShopNum1_ShopInfo as A left join ShopNum1_Member as B     ";
			text += "   on A.MemLoginID=B.MemLoginID  ";
			text = text + "   where A.MemLoginID='" + MemLoginID + "'  ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetInfoAdmin(string OrderNumber, string Name, int OderStatus, string ShopMemLoginID)
		{
			string text = string.Empty;
			text = "   select  * from  ShopNum1_ScoreOrderInfo  where 1=1    ";
			if (!string.IsNullOrEmpty(OrderNumber))
			{
				text = text + " and   OrderNumber  ='" + OrderNumber + "'   ";
			}
			if (!string.IsNullOrEmpty(Name))
			{
				text = text + " and    Name  like '%" + Name + "%'   ";
			}
			if (OderStatus != -1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"   and     OderStatus=",
					OderStatus,
					"   "
				});
			}
			if (!string.IsNullOrEmpty(ShopMemLoginID))
			{
				text = text + "   and      ShopMemLoginID='" + ShopMemLoginID + "'   ";
			}
			text += "   order  by  CreateTime  desc     ";
			return DatabaseExcetue.ReturnDataTable(text);
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
			array2[2] = " * ";
			array[3] = "@tablename";
			array2[3] = "ShopNum1_ScoreOrderInfo";
			array[4] = "@condition";
			array2[4] = commonModel.Condition;
			array[5] = "@ordercolumn";
			array2[5] = "CreateTime";
			array[6] = "@sortvalue";
			array2[6] = "desc";
			array[7] = "@resultnum";
			array2[7] = commonModel.Resultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
	}
}
