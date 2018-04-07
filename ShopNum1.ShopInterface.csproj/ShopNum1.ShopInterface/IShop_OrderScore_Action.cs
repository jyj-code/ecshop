using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.ShopInterface
{
	public interface IShop_OrderScore_Action
	{
		DataTable GetOrderScoreOrder(string orderinfoguid);
		int AddOrderScore(ShopNum1_OrderScore orderScore);
		int UpdateOrderScoreState(string orderinfoguid, string isfinished);
		int UpdateIntegral(string memloginid, string shopid, string score);
		int AddMemIntegralLog(string memloginid, string score, string remark);
	}
}
