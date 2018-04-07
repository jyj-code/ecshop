using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_Page_Action
	{
		DataTable Search(int IsDeleted);
		DataTable Search(int oneID, int twoID, int pageType, string name, string pagePath, int isDeleted);
		DataTable Search(string guid, int isDeleted);
		DataTable GetOnePage(int isDeleted);
		DataTable GetOnePage(string guid, int isDeleted);
		DataTable GetTwopage(int oneID, int isDeleted);
		DataTable GetTwopage(string guid, int oneID, int isDeleted);
		DataTable GetTopPage(int isDeleted);
		int Add(ShopNum1_Page page);
		int RetrunMaxTwoID(int oneID);
		int RetrunMaxThreeID(int oneID, int twoID);
		DataTable GetOnePageBySuper(int isDeleted);
		DataTable GetTwopageBySupper(int oneID, int isDeleted);
		int DelPageBySuper(string pageguid);
		int Update(ShopNum1_Page page);
	}
}
