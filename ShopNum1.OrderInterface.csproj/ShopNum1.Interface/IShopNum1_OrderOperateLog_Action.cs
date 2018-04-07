using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_OrderOperateLog_Action
	{
		DataTable Search(string orderInfoGuid);
		int Add(ShopNum1_OrderOperateLog orderOperateLog);
	}
}
