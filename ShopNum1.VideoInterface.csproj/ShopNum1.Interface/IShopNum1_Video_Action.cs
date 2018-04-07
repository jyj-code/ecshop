using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_Video_Action
	{
		int Add(ShopNum1_Video news);
		int Delete(string guids);
		DataTable GetVideoAll(string title, string CategoryCode, string publisher, int IsRecommend, string time1, string time2, int isDeleted);
		int UpDateVideo(string guid, ShopNum1_Video news);
		DataTable GetVideoByGuid(string guid);
		DataTable GetVideoList(int showcount, string isrecommend);
		DataTable GetVideoHotList(int showcount);
		DataTable GetVideoDetail(string guid);
		DataTable GetVideoRelativelyList(string guid, int showcount);
		DataTable SearchVideoList(string keyword, string string_0);
	}
}
