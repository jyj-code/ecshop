using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using System;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_AdminWelcome_Action : IShopNum1_AdminWelcome_Action
	{
		public string SearchAdminInfo(string strloginID, int isDeleted)
		{
			string text = string.Empty;
			text = "Select  LastLoginTime  from ShopNum1_User where 1=1";
			if (Operator.FormatToEmpty(strloginID) != string.Empty)
			{
				text = text + " And LoginId ='" + Operator.FilterString(strloginID) + "'";
			}
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = text + " And IsDeleted =" + isDeleted;
			}
			return DatabaseExcetue.ReturnDataTable(text).Rows[0][0].ToString();
		}
		public string SearchOrderForDispatch(string strOderStatus, string strShipmentStatus, string strPaymentStatus, int isDeleted)
		{
			string text = string.Empty;
			text = "select count(guid) from ShopNum1_OrderInfo  where 1=1";
			if (Operator.FilterString(strOderStatus) != string.Empty)
			{
				text = text + " And OderStatus='" + Operator.FilterString(strOderStatus) + "'";
			}
			if (Operator.FilterString(strShipmentStatus) != string.Empty)
			{
				text = text + " And ShipmentStatus='" + Operator.FilterString(strShipmentStatus) + "'";
			}
			if (Operator.FilterString(strPaymentStatus) != string.Empty)
			{
				text = text + " And PaymentStatus='" + Operator.FilterString(strPaymentStatus) + "'";
			}
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = text + " And IsDeleted=" + isDeleted;
			}
			return DatabaseExcetue.ReturnDataTable(text).Rows[0][0].ToString();
		}
		public string SearchOrderForDispatch(string strOderStatus, string strShipmentStatus, string strPaymentStatus, int isDeleted, string SubstationID)
		{
			string text = string.Empty;
			text = "select count(guid) from ShopNum1_OrderInfo  where 1=1";
			if (Operator.FilterString(strOderStatus) != string.Empty)
			{
				text = text + " And OderStatus='" + Operator.FilterString(strOderStatus) + "'";
			}
			if (Operator.FilterString(strShipmentStatus) != string.Empty)
			{
				text = text + " And ShipmentStatus='" + Operator.FilterString(strShipmentStatus) + "'";
			}
			if (Operator.FilterString(strPaymentStatus) != string.Empty)
			{
				text = text + " And PaymentStatus='" + Operator.FilterString(strPaymentStatus) + "'";
			}
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = text + " And IsDeleted=" + isDeleted;
			}
			if (SubstationID != "-1")
			{
				text = text + " And  SubstationID='" + SubstationID + "'";
			}
			return DatabaseExcetue.ReturnDataTable(text).Rows[0][0].ToString();
		}
		public string SearchOutOfStockRecordCount(int isReply, int isDeleted)
		{
			string text = string.Empty;
			text = "select count(Guid) from ShopNum1_OutOfStock  where 1=1";
			if (isReply == 0 || isReply == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" And IsReply=",
					isReply,
					" "
				});
			}
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" And IsDeleted=",
					isDeleted,
					" "
				});
			}
			return DatabaseExcetue.ReturnDataTable(text).Rows[0][0].ToString();
		}
		public string SearchProductCount(int isDeleted)
		{
			string text = string.Empty;
			text = "select count(Guid) from ShopNum1_Shop_Product  where 1=1";
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" And IsDeleted=",
					isDeleted,
					" "
				});
			}
			text += " And   IsAudit=1 ";
			return DatabaseExcetue.ReturnDataTable(text).Rows[0][0].ToString();
		}
		public string SearchProductCount(int isDeleted, string SubstationID)
		{
			string text = string.Empty;
			text = "select count(Guid) from ShopNum1_Shop_Product  where 1=1";
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" And IsDeleted=",
					isDeleted,
					" "
				});
			}
			if (SubstationID != "-1")
			{
				text = text + " And  SubstationID='" + SubstationID + "' ";
			}
			text += " And   IsAudit=1 ";
			return DatabaseExcetue.ReturnDataTable(text).Rows[0][0].ToString();
		}
		public string SearchAuditProductCount(int IsAudit, int isDeleted)
		{
			string text = string.Empty;
			text = "select count(Guid) from ShopNum1_Shop_Product  where 1=1";
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" And IsDeleted=",
					isDeleted,
					" "
				});
			}
			if (IsAudit == 0 || IsAudit == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" And IsAudit=",
					IsAudit,
					" "
				});
			}
			return DatabaseExcetue.ReturnDataTable(text).Rows[0][0].ToString();
		}
		public string SearchAuditProductCount(int IsAudit, int isDeleted, string SubstationID)
		{
			string text = string.Empty;
			text = "select count(Guid) from ShopNum1_Shop_Product  where 1=1";
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" And IsDeleted=",
					isDeleted,
					" "
				});
			}
			if (IsAudit == 0 || IsAudit == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" And IsAudit=",
					IsAudit,
					" "
				});
			}
			if (SubstationID != "-1")
			{
				text = text + " And  SubstationID='" + SubstationID + "' ";
			}
			return DatabaseExcetue.ReturnDataTable(text).Rows[0][0].ToString();
		}
		public string SearchArticleCommentCount(int isAudit, int isDeleted)
		{
			string text = string.Empty;
			text = "Select count(guid) from ShopNum1_ArticleComment  where 1=1";
			if (isAudit == 0 || isAudit == 1)
			{
				text = text + " And IsAudit =" + isAudit;
			}
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = text + " And IsDeleted =" + isDeleted;
			}
			return DatabaseExcetue.ReturnDataTable(text).Rows[0][0].ToString();
		}
		public string SearchMessageBoardCount(int isAudit, int isDeleted)
		{
			string text = string.Empty;
			text = "Select count(guid) from ShopNum1_MessageBoard  where 1=1";
			if (isAudit == 0 || isAudit == 1)
			{
				text = text + " And IsAudit =" + isAudit;
			}
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = text + " And IsDeleted =" + isDeleted;
			}
			return DatabaseExcetue.ReturnDataTable(text).Rows[0][0].ToString();
		}
		public string SearchMessageCount(int isRead, int isDeleted)
		{
			string text = string.Empty;
			text = "Select count(MessageInfoGuid) from ShopNum1_UserMessage  where 1=1";
			if (isRead == 0 || isRead == 1)
			{
				text = text + " And IsRead =" + isRead;
			}
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = text + " And IsDeleted =" + isDeleted;
			}
			return DatabaseExcetue.ReturnDataTable(text).Rows[0][0].ToString();
		}
		public string SearchProductCommentCount(int isAudit, int isDeleted)
		{
			string text = string.Empty;
			text = "Select count(guid) from ShopNum1_Shop_ProductComment  where 1=1";
			if (isAudit == 0 || isAudit == 1)
			{
				text = text + " And IsAudit =" + isAudit;
			}
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = text + " And IsDelete =" + isDeleted;
			}
			return DatabaseExcetue.ReturnDataTable(text).Rows[0][0].ToString();
		}
		public string SearchRecommendCount(string strBest, string strHot, string strRecommend, string strNew, int isDeleted)
		{
			string text = string.Empty;
			text = "Select count(guid) from ShopNum1_Shop_Product  where 1=1";
			if (Operator.FormatToEmpty(strBest) != string.Empty)
			{
				text = text + " And IsShopGood ='" + Operator.FilterString(strBest) + "'";
			}
			if (Operator.FormatToEmpty(strHot) != string.Empty)
			{
				text = text + " And IsShopHot ='" + Operator.FilterString(strHot) + "' and productstate=0";
			}
			if (Operator.FormatToEmpty(strRecommend) != string.Empty)
			{
				text = text + " And IsShopRecommend ='" + Operator.FilterString(strRecommend) + "'";
			}
			if (Operator.FormatToEmpty(strNew) != string.Empty)
			{
				text = text + " And IsShopNew ='" + Operator.FilterString(strNew) + "'";
			}
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = text + " And IsDeleted =" + isDeleted;
			}
			text += " And   IsAudit=1 ";
			return DatabaseExcetue.ReturnDataTable(text).Rows[0][0].ToString();
		}
		public string SearchRecommendCountNew(string strBest, string strHot, string strRecommend, string strNew, int isDeleted)
		{
			string text = string.Empty;
			text = "Select count(guid) from ShopNum1_Shop_Product  where 1=1";
			if (Operator.FormatToEmpty(strBest) != string.Empty)
			{
				text = text + " And IsShopGood ='" + Operator.FilterString(strBest) + "'";
			}
			if (Operator.FormatToEmpty(strHot) != string.Empty)
			{
				text = text + " And   IsSystemHot='" + Operator.FilterString(strHot) + "' and productstate=0";
			}
			if (Operator.FormatToEmpty(strRecommend) != string.Empty)
			{
				text = text + " And   IsSystemRecommend='" + Operator.FilterString(strRecommend) + "'";
			}
			if (Operator.FormatToEmpty(strNew) != string.Empty)
			{
				text = text + " And   IsNew='" + Operator.FilterString(strNew) + "'";
			}
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = text + " And IsDeleted =" + isDeleted;
			}
			text += " And   IsAudit=1 ";
			return DatabaseExcetue.ReturnDataTable(text).Rows[0][0].ToString();
		}
		public string SearchRecommendCount(string strBest, string strHot, string strRecommend, string strNew, int isDeleted, string SubstationID)
		{
			string text = string.Empty;
			text = "Select count(guid) from ShopNum1_Shop_Product  where 1=1";
			if (Operator.FormatToEmpty(strBest) != string.Empty)
			{
				text = text + " And IsShopGood ='" + Operator.FilterString(strBest) + "'";
			}
			if (Operator.FormatToEmpty(strHot) != string.Empty)
			{
				text = text + " And   IsHot='" + Operator.FilterString(strHot) + "' and productstate=0";
			}
			if (Operator.FormatToEmpty(strRecommend) != string.Empty)
			{
				text = text + " And  IsRecommend='" + Operator.FilterString(strRecommend) + "'";
			}
			if (Operator.FormatToEmpty(strNew) != string.Empty)
			{
				text = text + " And   IsNew='" + Operator.FilterString(strNew) + "'";
			}
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = text + " And IsDeleted =" + isDeleted;
			}
			if (SubstationID != "-1")
			{
				text = text + " And  SubstationID='" + SubstationID + "' ";
			}
			return DatabaseExcetue.ReturnDataTable(text).Rows[0][0].ToString();
		}
		public string SearchActivityProductCount(string strPanicBuy, string strSpellBuy, int isDeleted)
		{
			string text = string.Empty;
			text = "Select count(guid) from ShopNum1_Shop_Product  where 1=1";
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = text + " And IsDeleted =" + isDeleted;
			}
			else
			{
				text = text + " And ProductState =" + strPanicBuy;
			}
			return DatabaseExcetue.ReturnDataTable(text).Rows[0][0].ToString();
		}
		public string SearchActivityProductCount(string strPanicBuy, string strSpellBuy, int isDeleted, string SubstationID)
		{
			string text = string.Empty;
			text = "Select count(guid) from ShopNum1_Shop_Product  where 1=1";
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = text + " And IsDeleted =" + isDeleted;
			}
			else
			{
				text = text + " And ProductState =" + strPanicBuy;
			}
			if (SubstationID != "-1")
			{
				text = text + " And  SubstationID='" + SubstationID + "' ";
			}
			return DatabaseExcetue.ReturnDataTable(text).Rows[0][0].ToString();
		}
		public string SearchGroupProduct()
		{
			string strSql = string.Empty;
			strSql = "select *from ShopNum1_Group_Product A  INNER JOIN ShopNum1_Product_Activity B ON A.AID=B.Id where a.state=1";
			return DatabaseExcetue.ReturnDataTable(strSql).Rows.Count.ToString();
		}
		public string SearchRepertoryAlertCount(int isDeleted)
		{
			string text = string.Empty;
			text = "Select count(guid) from ShopNum1_Shop_Product  where 1=1";
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" And IsDeleted =",
					isDeleted,
					" and ( RepertoryCount < RepertoryAlertCount or RepertoryCount = RepertoryAlertCount) "
				});
			}
			return DatabaseExcetue.ReturnDataTable(text).Rows[0][0].ToString();
		}
		public string SearchSaleInfo(string strDispatchTime, int isDeleted)
		{
			string text = string.Empty;
			text = "Select sum(AlreadPayPrice) from ShopNum1_OrderInfo  where 1=1";
			if (Operator.FormatToEmpty(strDispatchTime) != string.Empty)
			{
				text += " And  DATEDIFF(day,DispatchTime,GETDATE())=0";
			}
			return DatabaseExcetue.ReturnDataTable(text).Rows[0][0].ToString();
		}
		public string SearchSaleInfo(string strDispatchTime, int isDeleted, string SubstationID)
		{
			string text = string.Empty;
			text = "Select sum(AlreadPayPrice) from ShopNum1_OrderInfo  where 1=1";
			if (Operator.FormatToEmpty(strDispatchTime) != string.Empty)
			{
				text += " And  DATEDIFF(day,DispatchTime,GETDATE())=0";
			}
			if (SubstationID != "-1")
			{
				text = text + " AND     SubstationID='" + SubstationID + "'   ";
			}
			return DatabaseExcetue.ReturnDataTable(text).Rows[0][0].ToString();
		}
		public string SearchSaleProductCount(string strDispatchTime, int isDeleted)
		{
			string text = string.Empty;
			text = "Select Count(BuyNumber) from ShopNum1_OrderProduct WHERE OrderInfoGuid IN (Select Guid from ShopNum1_OrderInfo  where 1=1";
			if (Operator.FormatToEmpty(strDispatchTime) != string.Empty)
			{
				text += " And  DATEDIFF(day,DispatchTime,GETDATE())=0";
			}
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = text + " And IsDeleted =" + isDeleted;
			}
			text += ")";
			return DatabaseExcetue.ReturnDataTable(text).Rows[0][0].ToString();
		}
		public string SearchRegisterMemberCount(string strRegDate, int isDeleted)
		{
			string text = string.Empty;
			text = "Select Count(guid) from ShopNum1_Member WHERE 1=1 ";
			if (Operator.FormatToEmpty(strRegDate) != string.Empty)
			{
				text += " And   DATEDIFF(day,RegeDate,GETDATE())=0";
			}
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = text + " And IsDeleted =" + isDeleted;
			}
			return DatabaseExcetue.ReturnDataTable(text).Rows[0][0].ToString();
		}
		public string SearchRegisterShopCount(int isAudit, string strApplyTime, int isDeleted)
		{
			string text = string.Empty;
			text = "Select Count(guid) from ShopNum1_ShopInfo WHERE 1=1 ";
			if (isAudit == 0 || isAudit == 1)
			{
				text = text + " And IsAudit =" + isAudit;
			}
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = text + " And IsDeleted =" + isDeleted;
			}
			return DatabaseExcetue.ReturnDataTable(text).Rows[0][0].ToString();
		}
		public string SearchRegisterShopCount(int isAudit, string strApplyTime, int isDeleted, string SubstationID)
		{
			string text = string.Empty;
			text = "Select Count(guid) from ShopNum1_ShopInfo WHERE 1=1 ";
			if (isAudit == 0 || isAudit == 1)
			{
				text = text + " And IsAudit =" + isAudit;
			}
			if (SubstationID != "-1")
			{
				text = text + " And   SubstationID ='" + SubstationID + "' ";
			}
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = text + " And IsDeleted =" + isDeleted;
			}
			return DatabaseExcetue.ReturnDataTable(text).Rows[0][0].ToString();
		}
		public string SearchAllMemberCount(int isDeleted)
		{
			string text = string.Empty;
			text = "Select Count(guid) from ShopNum1_Member WHERE 1=1 ";
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = text + " And IsDeleted =" + isDeleted;
			}
			return DatabaseExcetue.ReturnDataTable(text).Rows[0][0].ToString();
		}
		public string SearchAllShopCount(int isDeleted)
		{
			string text = string.Empty;
			text = "Select Count(guid) from ShopNum1_ShopInfo WHERE 1=1 ";
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = text + " And IsDeleted =" + isDeleted;
			}
			return DatabaseExcetue.ReturnDataTable(text).Rows[0][0].ToString();
		}
		public string SearchAllShopCount(int isDeleted, string SubstationID)
		{
			string text = string.Empty;
			text = "Select Count(guid) from ShopNum1_ShopInfo WHERE 1=1 ";
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = text + " And IsDeleted =" + isDeleted;
			}
			if (SubstationID != "-1")
			{
				text = text + " And  SubstationID ='" + SubstationID + "'";
			}
			return DatabaseExcetue.ReturnDataTable(text).Rows[0][0].ToString();
		}
		public string SearchOrderNowCount()
		{
			string text = string.Empty;
			text = "Select Count(guid) from ShopNum1_OrderInfo WHERE 1=1 ";
			text += " And   DATEDIFF(day,CreateTime,GETDATE())=0";
			text += " And IsDeleted =0";
			return DatabaseExcetue.ReturnDataTable(text).Rows[0][0].ToString();
		}
		public string SearchOrderNowCount(string SubstationID)
		{
			string text = string.Empty;
			text = "Select Count(guid) from ShopNum1_OrderInfo WHERE 1=1 ";
			text += " And   DATEDIFF(day,CreateTime,GETDATE())=0";
			text += " And IsDeleted =0";
			if (SubstationID != "-1")
			{
				text = text + " And  SubstationID ='" + SubstationID + "'";
			}
			return DatabaseExcetue.ReturnDataTable(text).Rows[0][0].ToString();
		}
		public string SearchShopNowCount()
		{
			string text = string.Empty;
			text = "Select Count(guid) from ShopNum1_ShopInfo WHERE 1=1 ";
			text += " And   DATEDIFF(day,OpenTime,GETDATE())=0";
			text += " And IsDeleted =0";
			return DatabaseExcetue.ReturnDataTable(text).Rows[0][0].ToString();
		}
		public string SearchShopNowCount(string SubstationID)
		{
			string text = string.Empty;
			text = "Select Count(guid) from ShopNum1_ShopInfo WHERE 1=1 ";
			text += " And   DATEDIFF(day,OpenTime,GETDATE())=0";
			text += " And IsDeleted =0";
			if (SubstationID != "-1")
			{
				text = text + " And  SubstationID ='" + SubstationID + "'";
			}
			return DatabaseExcetue.ReturnDataTable(text).Rows[0][0].ToString();
		}
		public string SearchProuductCheckedCount()
		{
			string strSql = string.Empty;
			strSql = "select count(Guid) from ShopNum1_Shop_Product  where IsDeleted=0 and IsAudit=0";
			return DatabaseExcetue.ReturnDataTable(strSql).Rows[0][0].ToString();
		}
		public string SearchMessageBoardCount()
		{
			string strSql = string.Empty;
			strSql = "select count(Guid) from ShopNum1_MessageBoard  where IsDeleted=0 and IsReply=0";
			return DatabaseExcetue.ReturnDataTable(strSql).Rows[0][0].ToString();
		}
		public string SearchProductCommentCount()
		{
			string strSql = string.Empty;
			strSql = "select count(Guid) from ShopNum1_Shop_ProductComment  where IsDeleted=0 and IsAudit=0";
			string result;
			try
			{
				result = DatabaseExcetue.ReturnDataTable(strSql).Rows[0][0].ToString();
			}
			catch (Exception)
			{
				result = "0";
			}
			return result;
		}
	}
}
