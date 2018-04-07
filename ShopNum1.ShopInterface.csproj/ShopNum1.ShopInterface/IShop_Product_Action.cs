using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.ShopInterface
{
	public interface IShop_Product_Action
	{
		DataTable GetShopProductEdit(string guid);
		DataTable AutoSearchProductName(string keyword);
		DataTable AutoSearchShopName(string keyword);
		DataTable AutoSearchProductName(string keyword, string type);
		DataTable AutoSearchShopName(string keyword, string type);
		DataTable AutoSearchSupplyName(string keyword);
		DataTable GetShopProduct(string name, string productnum, string issaled, string beginprice, string endprice, string producttype, string productseriescode, string productcategorycode, string memloginid, string isAudit);
		DataTable GetIsProduct(string isnew, string ishot, string ispromotion, string showcount, string ordertype, string shopid, string sort);
		DataTable GetIsProduct(string isnew, string ishot, string ispromotion, string ispanicbuy, string isspellbuy, string showcount, string ordertype, string shopid);
		DataTable GetIsProductAndRecommend(string isnew, string ishot, string ispromotion, string IsShopRecommend, string ispanicbuy, string isspellbuy, string showcount, string ordertype, string shopid);
		DataTable GetProductDetail(string guid);
		DataSet GetProductInfoByGuidAndMemLoginID(string guid, string memloginid);
		DataTable GetSpellInfoMeta(string shopid, string guid);
		int UpdateProductSaled(string guids, string isSaled);
		int AddShopProduct(ShopNum1_Shop_Product shop_Product);
		int UpdateShopProduct(ShopNum1_Shop_Product shop_Product);
		DataTable GetSaleRankingProduct(string showcount, string shopid);
		DataTable SearchProductList(string memloginid, string kwyword, string pricestart, string priceend, string code, string sortstyle);
		DataTable GetShopMetaByGuid(string guid);
		DataTable GetProductDetailMeta(string guid);
		DataTable GetProductBrandAndOrderIdByCode(string code);
		DataTable GetProductCategoryNameByCode(string code);
		int UpdateSaleNumberByOrderGuid(string OrderGuidguid, string strSaleNumber);
		int UpdateClickCountByGuid(string guid);
		DataTable GetShopProductDetailMeto(string guid);
		DataTable GetCollectRankingProduct(string showcount, string shopid);
		DataSet GetIsProductNew(string isnew, string ishot, string ispromotion, string ordertype, string shopid, string sort, string perpagenum, string current_page, string isreturcount);
		DataSet GetIsProductNew(string isnew, string ishot, string ispromotion, string ispanicbuy, string isspellbuy, string ordertype, string shopid, string sort, string perpagenum, string current_page, string isreturcount);
		DataSet GetIsProductNewProductState(string isnew, string ishot, string ispromotion, string ispanicbuy, string isspellbuy, string ordertype, string shopid, string sort, string perpagenum, string current_page, string isreturcount);
		DataSet GetIsProductNewAndRecommend(string isnew, string ishot, string ispromotion, string IsShopRecommend, string ordertype, string shopid, string sort, string perpagenum, string current_page, string isreturcount);
		DataTable GetPanicList(string showcount, string ordertype, string shopid);
		DataSet SearchProductListNew(string memloginid, string kwyword, string pricestart, string priceend, string code, string ordertype, string sort, string perpagenum, string current_page, string isreturcount);
		int DeleteById(string strId);
		DataTable GetShopproductCatetoryByCode(string code, string memloginid);
		DataTable CheckMenberBuyProduct(string guid, string memberid);
		DataTable GetPanicInfoMeta(string shopid, string guid);
		DataTable GetSpellListFor(string shopid, string showcount, string ischeck);
		DataTable GetSpellInfo(string shopid, string guid);
		DataTable GetSpellList(string showcount, string ordertype, string shopid);
		DataSet GetPanicInfo(string shopid, string guid);
		DataTable GetPanicBuyList(string shopid, string showcount, string productguid);
		int DeleteShopProduct(string guid, string memloginid);
		string CheckSpellPanicProduct(string memberid, string type);
		DataTable GetShopName(string memberID);
		DataTable GetShopCategroy(string memloginid);
		DataTable SearchProductShopByGuid(string productguid);
		int GetLimitBuyCount(string guid);
		DataTable GetTemplateFee(string strGuId);
	}
}
