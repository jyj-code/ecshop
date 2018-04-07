using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_DefaultAdImg_Action
	{
		void ResetAd();
		bool Add(DefaultAdImg advertisement);
		bool Update(DefaultAdImg advertisement);
		bool Delete(string guids);
		DataTable GetDefaultAd();
		DataTable SelectByID(string guid);
	}
}
