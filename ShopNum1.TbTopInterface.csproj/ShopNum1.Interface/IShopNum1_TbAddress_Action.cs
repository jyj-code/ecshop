using ShopNum1.TbLinq;
using System;
using System.Collections.Generic;
namespace ShopNum1.Interface
{
	public interface IShopNum1_TbAddress_Action
	{
		List<ShopNum1_TbAddress> GetAllProvince();
		List<ShopNum1_TbAddress> GetCitysByParent(int parent_Id);
		bool InsertTbAreas(ShopNum1_TbAddress tbAreas);
	}
}
