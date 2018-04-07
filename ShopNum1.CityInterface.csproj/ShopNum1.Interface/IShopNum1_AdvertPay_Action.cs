using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_AdvertPay_Action
	{
		int Add(ShopNum1_AdvertPay AdvertPay);
		int Updata(ShopNum1_AdvertPay AdvertPay);
		int Delete(string string_0);
		DataTable Search();
	}
}
