using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_ZtcApply_Action
	{
		int Add(ShopNum1_ZtcApply ZtcApply);
		int Delete(string guids);
		DataTable GetInfoByGuid(string guid);
		DataTable Search(int IsDeleted);
	}
}
