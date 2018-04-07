using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.ShopInterface
{
	public interface IShop_Coupon_Action
	{
		int Add(ShopNum1_Shop_Coupon ShopNum1_Shop_Coupon);
		int UpdateCoupon(ShopNum1_Shop_Coupon ShopNum1_Shop_Coupon);
		DataTable SearchCoupon(string name, string type, string isshow, string starttime1, string starttime2, string endtime1, string endtime2, string memloginid);
		int Delete(string ID);
		DataTable GetCouponInfoById(string guid);
		DataTable SearchCouponInfo(string name, string type, string isshow, string starttime1, string starttime2, string endtime1, string endtime2, string shopid, string adresscode);
		int UpdateAudit(string field, string value, string guids);
		DataTable SearchCouponByGuid(string guid, string shopid);
		DataTable SearchCouponByMemloginID(string showcount, string memloginid);
		int UpdateBrowserCount(string guid);
		DataSet SearchCouponByCategory(string category, string pagesize, string current_page);
		DataTable GetCouponTitleByAdressCode(string adresscode, string showcount);
		DataTable GetCouponTitleByBrowserCount(string showcount);
		int UpdataDownloadCountByGuid(string guid, string count);
		DataTable SearchCouponByType(string category, string addcode, string ordername, string sDesc, string pagesize, string current_page, string isReturCount);
		DataSet SearchCouponByMemloginID(string shopid, string ordertype, string sort, string perpagenum, string current_page, string isreturcount);
	}
}
