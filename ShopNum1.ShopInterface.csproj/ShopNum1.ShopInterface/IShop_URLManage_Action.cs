using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.ShopInterface
{
	public interface IShop_URLManage_Action
	{
		int AddURLManage(ShopNum1_ShopURLManage shopNum1_ShopURLManage);
		DataTable GetUrlManage(string string_0);
		int UpdateURLManage(ShopNum1_ShopURLManage shopNum1_ShopURLManage);
		int DeleteURLManage(string guid);
		DataTable GetUrlManageList(string loginid, string isaudit);
		DataTable CheckURLManageByDoMain(string domain);
	}
}
