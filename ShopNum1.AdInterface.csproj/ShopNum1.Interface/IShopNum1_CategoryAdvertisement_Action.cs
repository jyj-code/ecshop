using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_CategoryAdvertisement_Action
	{
		int Add(ShopNum1_CategoryAdvertisement shopNum1_CategoryAdvertisement);
		int Updata(ShopNum1_CategoryAdvertisement shopNum1_CategoryAdvertisement);
		int Delete(string string_0);
		DataTable Search(string AdName, string CategoryType, string CategoryID, string AdCode, string AdIShow, string AdIsBuy);
		DataTable Search(string string_0);
		string GetFatherIDByID(string string_0);
		DataTable GetPriceAndID(string categorytype, string categoryid, string categorycode);
	}
}