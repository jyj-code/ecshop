using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.WeiXinInterface
{
	public interface IShopNum1_Weixin_ShopConfig_Active
	{
		bool Add(List<ShopNum1_Weixin_ShopConfig> configlist, string shopid);
		DataTable Get_Config(string shopid);
	}
}