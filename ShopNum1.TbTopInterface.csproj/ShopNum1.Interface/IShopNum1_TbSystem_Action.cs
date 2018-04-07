using ShopNum1.TbLinq;
using System;
namespace ShopNum1.Interface
{
	public interface IShopNum1_TbSystem_Action
	{
		bool InsertTbSystem(string memglogid, string shopname);
		bool UpdateTbSystem(ShopNum1_TbSystem tbSystem);
		ShopNum1_TbSystem GetTbSysem(string memlogid, string shopname);
		bool Remove(string memlogid);
		bool CheckTbUserBind(string tbShopName, string memlogid, out string shopName);
	}
}
