using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_OnLineService_Action
	{
		int Add(ShopNum1_OnlineService onlineservice);
		DataTable GetOnlineServiceInfo(int Deleted);
		int Update(string guid, ShopNum1_OnlineService onlineservice);
		int Delete(string guids);
		DataTable GetEditInfo(string guid, int isDeleted);
		DataSet GetOnlineService(string showcountqq, string showcountmsn);
		string GetPath();
		void LoadXml();
		DataTable Search(string name, string type);
		string GetIsShowByID(string string_0);
		int Update(string[] string_0, string[] isshow);
		int UpdateIsShow(string type, string isshow);
	}
}
