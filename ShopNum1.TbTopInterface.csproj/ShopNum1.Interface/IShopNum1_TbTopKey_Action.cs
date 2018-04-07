using ShopNum1.TbLinq;
using System;
namespace ShopNum1.Interface
{
	public interface IShopNum1_TbTopKey_Action
	{
		bool AddTbTopKey(ShopNum1_TbTopKey tbtopkey);
		bool UpdateTopKey(ShopNum1_TbTopKey tbtopkey);
		ShopNum1_TbTopKey SearchTopKey(string memlogid);
		bool Delete(string memlogid);
	}
}
