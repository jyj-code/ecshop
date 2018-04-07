using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.ShopInterface
{
	public interface IShop_Ensure_Action
	{
		DataTable GetShopEnsureList(string name);
		int Add(ShopNum1_ShopEnsure shopNum1_ShopEnsure);
		int Updata(ShopNum1_ShopEnsure shopNum1_ShopEnsure);
		int Del(string string_0);
		DataTable SearchEnsureApply_List(string name, string isAudit, string shopid);
		int UpdataIsAuditByGuid(string guid, int isAudit);
		DataTable SearchShopEnsureListNew(string memberLoginID);
		DataTable GetShopEnsure(int int_0);
		int UpdateShopEnsureList(string memloginid, string ensureid);
		DataTable GetShopEnsureListNew(string shopid);
		DataTable GetShopapplyEnsureList(string shopid);
		int ApplyShopEnsure(ShopNum1_Shop_ApplyEnsure applyEnsure);
		DataTable GetCheckedShopEnsureList(string ensureid, string shopid);
		int DelShopEnsureList(string guid);
		DataTable SearchEnsureApply(string shopid);
		int UpdataEnsurePayStatusByGuid(string guid);
		DataTable GetShopEnsureListByMemberLoginID(string memloginid);
		int CheckIsPayMentByID(string guid);
		int UpdataEnsurePayMentByGuid(string guid, string PayMentType, string PayMentName);
		DataTable GetShopapplyEnsure(string shopid);
		DataTable GetShopNotApplyEnsure(string shopid);
		DataTable GetShopapplyNoRegShopEnsureList(string shopid);
		DataTable GetEnsureMoney(Guid guid);
	}
}
