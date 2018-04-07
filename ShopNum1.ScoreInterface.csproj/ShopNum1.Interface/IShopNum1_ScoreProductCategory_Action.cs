using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_ScoreProductCategory_Action
	{
		int Add(ShopNum1_ScoreProductCategory ScoreProductCategory);
		int Delete(string guids);
		DataTable GetDataInfo(int IsDeleted);
		int Update(ShopNum1_ScoreProductCategory ScoreProductCategory);
	}
}
