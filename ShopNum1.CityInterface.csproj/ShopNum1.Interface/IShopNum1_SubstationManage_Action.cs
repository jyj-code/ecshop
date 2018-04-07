using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_SubstationManage_Action
	{
		int Add(ShopNum1_SubstationManage SubstationManage);
		int Updata(ShopNum1_SubstationManage SubstationManage);
		int Delete(string string_0);
		DataTable Search();
	}
}
