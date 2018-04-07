using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_BadWord_Action
	{
		int Add(ShopNum1_BadWords shopNum1_BadWord);
		int Updata(ShopNum1_BadWords shopNum1_BadWord);
		DataTable Edit(int int_0);
		int Delete(string string_0);
		DataTable SearchByName(string name);
		DataTable CheckIsExists(string find, string replacement);
	}
}
