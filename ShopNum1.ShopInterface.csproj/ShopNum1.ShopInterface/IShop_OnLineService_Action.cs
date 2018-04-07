using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.ShopInterface
{
	public interface IShop_OnLineService_Action
	{
		int AddOnLineService(ShopNum1_Shop_OnlineService onlineService);
		DataTable GetOnLineServiceList(string memloginid, string type, string isshow);
		DataTable GetOnLineService(string guid);
		int UpdateOnLineService(ShopNum1_Shop_OnlineService onlineService);
		int DeleteOnLineService(string guid);
		string GetPath();
		void LoadXml();
		DataTable Search(string name, string type, string strPath);
		string GetIsShowByID(string string_0);
		int Update(string[] string_0, string[] isshow, string strPath, string memloginid);
		int UpdateIsShow(string type, string shopid, string isshow);
		DataTable SelectOnLineService_List(CommonPageModel commonModel);
		int UpdateShopOnlinePhone(ShopNum1_Shop_OnlineService onlineService);
	}
}
