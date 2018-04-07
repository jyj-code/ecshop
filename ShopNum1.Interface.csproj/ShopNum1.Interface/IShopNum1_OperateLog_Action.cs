using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_OperateLog_Action
	{
		DataTable Search(string operatorID, string IP, string StartDate, string EndDate);
		int Add(ShopNum1_OperateLog shopNum1_operateLog);
		int DeleteAll(string startDate, string endDate);
		int Delete(string guids);
	}
}
