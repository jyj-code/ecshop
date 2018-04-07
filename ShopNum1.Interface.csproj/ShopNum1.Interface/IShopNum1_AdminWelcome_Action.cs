using System;
namespace ShopNum1.Interface
{
	public interface IShopNum1_AdminWelcome_Action
	{
		string SearchAdminInfo(string strloginID, int isDeleted);
		string SearchOrderForDispatch(string strOderStatus, string strShipmentStatus, string strPaymentStatus, int isDeleted);
		string SearchOutOfStockRecordCount(int isReply, int isDeleted);
		string SearchProductCount(int isDeleted);
		string SearchAuditProductCount(int IsAudit, int isDeleted);
		string SearchRepertoryAlertCount(int isDeleted);
		string SearchRecommendCount(string strBest, string strHot, string strRecommend, string strNew, int isDeleted);
		string SearchActivityProductCount(string strPanicBuy, string strSpellBuy, int isDeleted);
		string SearchGroupProduct();
		string SearchMessageBoardCount(int isAudit, int isDeleted);
		string SearchMessageCount(int isRead, int isDeleted);
		string SearchArticleCommentCount(int isAudit, int isDeleted);
		string SearchProductCommentCount(int isAudit, int isDeleted);
		string SearchSaleInfo(string strDispatchTime, int isDeleted);
		string SearchSaleProductCount(string strDispatchTime, int isDeleted);
		string SearchRegisterMemberCount(string strRegDate, int isDeleted);
		string SearchRegisterShopCount(int isAudit, string strApplyTime, int isDeleted);
		string SearchAllMemberCount(int isDeleted);
		string SearchAllShopCount(int isDeleted);
		string SearchOrderNowCount();
		string SearchShopNowCount();
		string SearchProuductCheckedCount();
		string SearchMessageBoardCount();
		string SearchProductCommentCount();
	}
}
