using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_Announcement_Action
	{
		int Add(ShopNum1_Announcement announcement);
		int Delete(string guids);
		DataTable Search(string title, string creater, string startDate, string endDate, int isDeleted, string category);
		DataTable GetEditInfo(string guid, int isDeleted);
		int Update(string guid, ShopNum1_Announcement announcement);
		DataTable SearchTitle(int isDeleted);
		DataTable SearchTitle(int isDeleted, int count);
		DataTable GetAnnoucementMeto(string guid);
		DataTable GetAnnoucementNew(string showCount);
		DataTable GetAnnoucementList();
		DataTable GetAnnoucementDetails(string guid);
		DataTable GetAnnouncementOnAndNext(string guid, string onAnnouncementName, string nextAnnouncementName);
		DataTable GetShopAnnouncementNew(string showCount, string AnnouncementCategoryID);
	}
}
