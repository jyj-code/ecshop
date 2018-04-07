using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_Activity_Action
	{
		int AddActivity(ShopNum1_Product_Activity ShopNum1_Activity);
		int UpdateActivity(ShopNum1_Product_Activity ShopNum1_Activity);
		DataTable SelectActivity(string pagesize, string currentpage, string condition, string resultnum);
		int CloseActivity(string strId);
		int DeleteActivity(string strId);
		DataTable GetProductActivity();
		int AddThemeActivty(ShopNum1_ThemeActivity shopNum1_ThemeActivity);
		int UpdateThemeActivty(ShopNum1_ThemeActivity shopNum1_ThemeActivity);
		DataTable GetThemeActivtyByGuid(string Guid);
		DataTable SelectThemeActivty(string pagesize, string currentpage, string condition, string resultnum);
		DataTable GetThemeActivty();
		int DeleteThemeActivty(string guid);
		DataTable SelectThemeActivtyProduct(string pagesize, string currentpage, string condition, string resultnum);
		int DeleteThemeActivtyProduct(string Guid);
		int UpdateThemeProductIsAudit(string Guid, string IsAudit);
		int AddThemeProduct(ShopNum1_ThemeActivityProduct shopNum1_ThemeActivityProduct);
		DataTable SelectShopThemeActivty(string pagesize, string currentpage, string condition, string resultnum);
		DataTable SelectThemeProductByGuid(string pagesize, string currentpage, string condition, string resultnum);
		DataTable SelectProductByThemeGuid(string themeGuid);
		DataTable GetActivityById(string strMemloginId, string strLid);
		int UpdateActivityState(string strId, string strState);
	}
}
