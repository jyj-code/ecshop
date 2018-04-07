using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.ShopInterface
{
	public interface IShop_News_Action
	{
		int AddNews(ShopNum1_Shop_News shop_News);
		DataTable GetNewsList(string memloginid, string isshow);
		DataTable GetNews(string guid);
		DataTable GetNewsByGuidAndMemLoginID(string guid, string memloginid);
		int UpdateNews(ShopNum1_Shop_News shop_News);
		int DeleteNews(string guid);
		DataTable GetShopMetaByNewsguid(string guid);
		DataTable MetaGetNews(string memloginid, string guid);
		DataTable GetShopArticleDetailMeto(string guid);
		DataTable GetCountNewsByMemLoginID(string memloginid);
		DataSet SearchNewsListNew(string memloginid, string newscategoryguid, string ordertype, string sort, string perpagenum, string current_page, string isreturcount);
	}
}
