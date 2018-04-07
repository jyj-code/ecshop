using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_ExtendPageAddress_Action
	{
		DataTable GetArticlePageAddress(string guid);
		DataTable GetArticleCategoryPageAddress(string guid);
		DataTable GetProductPageAddress(string guid);
		DataTable GetProductCategoryPageAddress(string productCategoryID);
		DataTable GetHelpCategoryPageAddress(string guid);
		DataTable GetVideoPageAddress(string guid);
		DataTable GetVideoCategoryPageAddress(string guid);
		DataTable GetScorePageAddress(string guid);
		DataTable GetScoreNamePageAddress(string guid);
		DataTable GetScoreCategoryPageAddress(string productCategoryID);
	}
}
