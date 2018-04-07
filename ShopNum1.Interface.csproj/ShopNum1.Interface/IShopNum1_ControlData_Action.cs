using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_ControlData_Action
	{
		DataTable Search(string guid);
		DataTable GetEditInfo(string guid);
		int Delete(string guid);
		int Insert(ShopNum1_ControlData shopNum1_ControlData);
		int Update(ShopNum1_ControlData shopNum1_ControlData);
		DataTable GetControlDataList(string controlGuid, string groupID);
	}
}
