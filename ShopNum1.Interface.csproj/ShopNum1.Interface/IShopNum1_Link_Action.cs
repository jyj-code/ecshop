using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_Link_Action
	{
		int Add(ShopNum1_Link Service_Link);
		DataTable GetEditInfo(string guid);
		DataTable Search(string name, int isShow);
		DataTable Search(int isDeleted);
		int Delete(string guids);
		int Update(string guid, ShopNum1_Link Service_Link);
		DataTable GetLink();
		DataTable GetLinkListImage(string showCount);
		DataTable CheckIsDuplication(string link);
	}
}
