using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_ArticleCategory_Action
	{
		int GetMaxID();
		DataTable Search(int isDeleted);
		DataTable Search(int fatherID, int isDeleted);
		int Add(ShopNum1_ArticleCategory articleCategory);
		int Update(ShopNum1_ArticleCategory articleCategory);
		int Delete(string string_0);
		DataTable GetEditInfo(string strID);
		DataTable GetArticleCategoryMeto(string strID);
		string GetNameByID(int int_0);
		DataTable SearchShow(int fatherID, int isDeleted);
		DataTable GetArticleCategory(string FatherId);
		DataTable SearchID(int int_0);
		DataTable GetArticleInfoByID(string string_0);
		DataTable SearchByFatherID(string fatherID, string showcount, string isDeleted);
	}
}
