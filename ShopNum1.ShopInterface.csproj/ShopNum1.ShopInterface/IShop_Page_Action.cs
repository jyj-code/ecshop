using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.ShopInterface
{
	public interface IShop_Page_Action
	{
		DataTable GetLeftMenu(string agentLoginID, string userGuid);
		DataTable Search(int IsDeleted, string agentLoginID);
		DataTable Search(int oneID, int twoID, int pageType, string name, string pagePath, int isDeleted, string agentLoginID);
		DataTable Search(string guid, int isDeleted, string agentLoginID);
		DataTable GetOnePage(int isDeleted, string agentLoginID);
		DataTable GetOnePage(string guid, int isDeleted);
		DataTable GetTwopage(int oneID, int isDeleted, string agentLoginID);
		DataTable GetTwopage(string guid, int oneID, int isDeleted);
		DataTable GetTopPage(int isDeleted, string agentLoginID);
		int Add(ShopNum1_Page page);
		int RetrunMaxTwoID(int oneID, string agentLoginID);
		int RetrunMaxThreeID(int oneID, int twoID, string agentLoginID);
		DataTable MetaGetPage(string guid);
	}
}
