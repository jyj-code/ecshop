using ShopNum1.TbLinq;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_TbSellCat_Action
	{
		bool InsertSellCat(ShopNum1_TbSellCat sellCat);
		bool UpdateSellCat(ShopNum1_TbSellCat sellCat);
		DataTable GetSellCat(decimal siteCid);
		DataTable GetAllCidByShopName(string shopName, string memlogid);
		bool DeleteSellCat(string shopname, string memlogid, decimal decimal_0, decimal sitecid);
		decimal CheckSellCatByTb(string shopname, string string_0, string MemloginId);
	}
}
