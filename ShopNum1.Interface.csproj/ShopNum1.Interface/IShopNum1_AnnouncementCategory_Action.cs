using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_AnnouncementCategory_Action
	{
		int GetMaxID();
		DataTable Search(int isDeleted);
		DataTable Search(int fatherID, int isDeleted);
		int Add(ShopNum1_AnnouncementCategory AnnouncementCategory);
		int Update(ShopNum1_AnnouncementCategory AnnouncementCategory);
		int Delete(string string_0);
		DataTable GetEditInfo(string strID);
		DataTable GetAnnouncementCategoryMeto(string strID);
		string GetNameByID(int int_0);
		DataTable SearchShow(int fatherID, int isDeleted);
		DataTable GetAnnouncementCategory(string FatherId);
		DataTable SearchID(int int_0);
	}
}
