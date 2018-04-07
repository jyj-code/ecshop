using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.ShopInterface
{
	public interface IShop_Video_Action
	{
		int AddVideoInfo(ShopNum1_Shop_Video shop_Video);
		DataTable GetVideoInfo(string guid);
		DataTable GetVideoInfoByGuidAndMemLoginID(string guid, string memloginid);
		int UpdateVideoInfo(ShopNum1_Shop_Video shop_Video);
		int DeleteVideoInfo(string guid);
		DataTable SearchVideoList(string shopid, string categoryguid, string showcount, string title, string order);
		DataTable MetaGetVideo(string memloginid, string guid);
		DataTable GetShopVedioDetailMeto(string guid);
		DataTable GetCountVedioByMemLoginID(string memloginid);
		DataSet SearchVideoListNew(string shopid, string ordertype, string sort, string perpagenum, string current_page, string isreturcount);
	}
}
