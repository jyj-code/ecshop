using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_Article_Action
	{
		DataTable Search(string title, string publisher, int articlecategoryid, string startdate, string enddate, int isshow, int ishot, int isrecommand, int ishead, int isallowcomment, int isDeleted);
		DataTable GetEditInfo(string guid);
		DataTable GetRelatedArticleInfo(string guid);
		DataTable GetArticleCategoryInfo(int isDeleted);
		DataTable GetRelatedProductInfo(string guid);
		DataTable GetProductCategoryInfo(int isDeleted);
		int Add(ShopNum1_Article article, List<string> strRelateArticleList, List<string> strRelateProductList);
		int Update(ShopNum1_Article article, List<string> strRelateArticleList, List<string> strRelateProductList);
		int Delete(string guids);
		DataTable Search(string Title, int articleCategoryID);
		DataTable SearchByArticleCategoryID(int articleCategoryID);
		DataTable SearchByArticleCategoryID(int articleCategoryID, int showCount);
		string GetNameByGuid(string guid);
		DataTable SearchNewArticle(int count);
		DataTable SearchArticleRelatedArticle(string guid, int count);
		DataTable SearchArticle(string title);
		DataTable GetArticleMeto(string guid);
		DataTable GetArticleIsHotorIsRecommend(string showCount, string categoryID, string type);
		DataTable SearchByCategoryIDFrist(int articleCategoryID);
		DataTable SearchByCategoryIDOther(int articleCategoryID, string guid, string showCount);
		DataTable GetChildCategory(string showcount, string fatherId);
		DataTable GetArticleOnAndNext(string guid, string onArticleName, string nextArticleName);
		DataTable GetTitleByID(string ID, string type, string ShowCount);
		DataTable SearchArticleList(string guid, int articleCategoryID);
		DataTable SearchArticleList(string guid, int articleCategoryID, int count);
		DataTable SearchArticle(string articlename, string articlecode, string pageindex, string pagesize, string isreturcount);
		int UpdateClickCount(string guid);
	}
}
