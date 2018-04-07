using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_CategoryAdID_Action
	{
		int Add(ShopNum1_CategoryAdID shopNum1_CategoryAdID);
		int Updata(ShopNum1_CategoryAdID shopNum1_CategoryAdID);
		int Delete(string string_0);
		DataTable Search(string name, string adID);
	}
}
