using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.ShopInterface
{
	public interface IShop_CouponType_Action
	{
		int Add(ShopNum1_Shop_CouponType ShopNum1_Shop_CouponType);
		int Update(ShopNum1_Shop_CouponType ShopNum1_Shop_CouponType);
		DataTable search(int int_0, int isshow);
		int Delete(string ID);
	}
}
