using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_Logistic_Action
	{
		bool Exists(string code);
		int Add(ShopNum1_Logistic shopNum1_Logistic);
		int Update(ShopNum1_Logistic shopNum1_Logistic);
		int Delete(string string_0);
		DataTable GetLogistic(int ID);
		DataTable GetLogistic(string name);
		DataTable Search(int isshow);
	}
}
