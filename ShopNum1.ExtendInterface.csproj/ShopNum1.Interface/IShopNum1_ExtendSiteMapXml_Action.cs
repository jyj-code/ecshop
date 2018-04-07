using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_ExtendSiteMapXml_Action
	{
		DataTable SearchProductCategoryID();
		DataTable SearchArticleCategoryID();
		DataTable SearchArticle();
		DataTable SearchSupplyDemandCatagoryCode();
		DataTable SearchSupplyDemandDetail();
		DataTable SearchCategoryInfoCatagoryCode();
		DataTable SearchCategoryInfoDetail();
	}
}
