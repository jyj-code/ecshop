using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_CategoryChecked_Action
	{
		DataTable Search(string strCode, string isAudit);
		int Update(string guids, string state);
		int Delete(string guids);
		DataTable GetList(string categoryID);
		string GetMemberID(string guid);
		int Update(ShopNum1_CategoryInfo shopNum1_CategoryInfo);
		DataTable GetCategoryNewList(string showCount);
		DataTable GetCategoryDetails(string guid);
		DataTable SearchByType(string code, string showCount);
		DataSet Search(string pageindex, string pagesize, string addresscode, string associatedcategoryguid, string createtime1, string createtime2, string keywords, string title);
		int Add(ShopNum1_CategoryInfo categoryInfo);
		DataTable EditCategoryInfo(string guid);
		DataTable Search(string MemberID);
		DataTable SearchCategoryInfo(string memloginid, string isaudit);
		int AddCategoryInfo(ShopNum1_CategoryInfo categoryInfo);
		int UpdateCategoryInfo(ShopNum1_CategoryInfo categoryInfo);
		DataTable GetCategoryByCode(string code);
		DataTable GetCategoryOnAndNext(string guid, string onCategoryName, string nextCategoryName);
		DataTable GetCategoryInfoMeto(string guid);
		DataTable Search(int fatherID, int isDeleted, string ShowCount);
		DataTable SearchByCategoryIDFrist(string CategoryCode);
		DataTable SearchByCategoryIDOther(string CategoryCode, string guid, string showCount);
		DataSet Search(string perpagenum, string current_page, string supplyName, string supplyCategoryCode, string supplyAddressCode, string ordername, string isreturcount);
	}
}
