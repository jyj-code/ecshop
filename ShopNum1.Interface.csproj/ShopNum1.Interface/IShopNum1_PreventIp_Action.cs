using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_PreventIp_Action
	{
		DataTable Search();
		int Insert(ShopNum1_PreventIp shopNum1_PreventIp);
		int Delete(string guid);
		int Update(ShopNum1_PreventIp shopNum1_PreventIp);
		DataTable GetEditInfo(string guid);
		bool CheckedUser(string userIP, string Type);
	}
}
