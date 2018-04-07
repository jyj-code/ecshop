using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_DispatchRegion_Action
	{
		DataTable Search(int IsDeleted);
		int Add(ShopNum1_DispatchRegion dispatchRegion);
		int Delete(string guids);
		int Update(string guid, ShopNum1_DispatchRegion dispatchRegion);
		DataTable SearchtDispatchRegion(int fatherID, int isDeleted);
		DataTable GetDispatchRegionByID(string ID);
		DataTable GetDispatchRegionName();
		DataTable GetDispatchRegionName(string fatherID);
		DataTable GetDispatchRegionCode(string code);
		DataTable GetDispatchRegionName(string fatherID, string agentLoginID);
		int GetDispatchCount(int fatherID, int isDeleted);
	}
}
