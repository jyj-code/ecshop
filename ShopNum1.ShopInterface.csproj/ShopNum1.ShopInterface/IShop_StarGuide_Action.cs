using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.ShopInterface
{
	public interface IShop_StarGuide_Action
	{
		int AddStarGuide(ShopNum1_Shop_StarGuide starGuide);
		DataTable GetStarGuide(string guid);
		int UpdateStarGuide(ShopNum1_Shop_StarGuide starGuide);
		int DeleteStarGuide(string guid);
	}
}
