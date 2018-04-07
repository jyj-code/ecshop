using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_ScoreOrderInfo_Action
	{
		int Add(ShopNum1_ScoreOrderInfo ScoreOrderInfo, List<ShopNum1_ScoreOrderProduct> ScoreOrderProduct);
		int Delete(string guids);
		DataTable GetInfoByGuid(string guid);
		int Update(ShopNum1_ScoreOrderInfo ScoreOrderInfo);
	}
}