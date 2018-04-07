using ShopNum1.WeiXinCommon.model;
using System;
using System.Data;
namespace ShopNum1.WeiXinInterface
{
	public interface IShopNum1_Weixin_ShopMember_Active
	{
		bool AddWeiXinMember(string ShopMemLoginID, string UsrWeiXinID, string ShopWeiXinId, UserModel usermdl);
		DataTable GetShopMemByShopOwner(string shopowner);
		DataTable SelectActivity(string pagesize, string currentpage, string condition, string resultnum);
		bool ChangeVipGroup(string shopowner, string vips, int group);
	}
}
