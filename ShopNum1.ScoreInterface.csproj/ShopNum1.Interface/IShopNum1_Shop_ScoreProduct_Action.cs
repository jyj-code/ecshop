using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_Shop_ScoreProduct_Action
	{
		int Add(ShopNum1_Shop_ScoreProduct ScoreProductNew);
		int Delete(string guids);
		DataTable GetInfoByGuid(string guid);
		int Update(ShopNum1_Shop_ScoreProduct ScoreProductNew);
	}
}
