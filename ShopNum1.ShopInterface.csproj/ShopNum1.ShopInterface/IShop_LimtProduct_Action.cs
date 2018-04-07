using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.ShopInterface
{
	public interface IShop_LimtProduct_Action
	{
		DataTable GetLimtProdcut(string pagesize, string currentpage, string condition, string resultnum, string strLid);
		int AddLimitProduct(ShopNum1_Limt_Product shopNum1_Limt_Product);
		DataTable SelectLimtProdcut(string pagesize, string currentpage, string condition, string resultnum);
		int UpdateDisCount(string strDisCount, string strId);
		int DeleteLimitProduct(string strId);
		int UpdateLimitProductStae(string strId, string strState);
	}
}
