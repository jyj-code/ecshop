using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_OrderProduct_Action
	{
		DataTable SelectOrderProductByGuIdorAll(string OrderGuId, string KeyWord);
		DataTable Search(string orderInfoGuid);
		string GetWeight(string guid);
		DataTable SearchOrderProduct(string ordernum, string productname, string shopname, string startdate, string enddate);
		DataTable SearchRankingSellHot(string ShowCount);
		DataTable GetOrderProductList(string guid);
		int UpdateOrderProductBuyNum(string guid, string buynumber, string productPrice);
		int UpdateOrderProductInfo(string guid, string buyprice, string groupprice, string buynumber);
		DataTable GetPackOrderShopInfo(string memloginid);
		int UpdateStock(string strOrderGuId);
		int UpdateReduceStock(string strOrderGuId);
		int UpdateReduceStock(string strOrderGuId, string strSaleType);
		DataTable GetNewSaleOrder(string strTopCount);
	}
}
