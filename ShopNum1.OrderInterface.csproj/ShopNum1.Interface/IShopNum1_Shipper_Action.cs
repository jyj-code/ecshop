using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_Shipper_Action
	{
		DataTable Search();
		DataTable GetEditInfo(string guid);
		int Delete(string guid);
		int Insert(ShopNum1_Shipper shopNum1_Shipper);
		int Update(ShopNum1_Shipper shopNum1_Shipper);
		DataTable Search(string condititon);
	}
}
