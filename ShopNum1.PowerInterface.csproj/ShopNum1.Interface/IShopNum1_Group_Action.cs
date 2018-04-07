using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_Group_Action
	{
		int Add(ShopNum1_Group group, List<string> pageList, List<string> userList, List<ShopNum1_GroupPageWebControl> groupPageWebControlList);
		int Add(ShopNum1_Group group);
		DataTable Search(int IsDeleted);
		DataTable GetGroupByGuid(string guid, int IsDeleted);
		DataTable GetGroupByGuid(string GroupGuid);
		DataTable GetPageByGroupGuid(string guid, int IsDeleted);
		DataTable GetUserByGroupGuid(string guid, int IsDeleted);
		DataTable GetPageWebControlByGroupGuidPageGuid(string groupGuid, string pageGuid, int IsDeleted);
		DataTable GetPageWebControlByPageGuid(string pageGuid, int isDeleted);
		DataTable GetPageWebControlByGuid(string guid, int isDeleted);
		int CheckOperatePage(string userGuid, string pageName);
		DataTable GetOperateControl(string userGuid, string pageName);
		int Delete(string guids);
		int Update(ShopNum1_Group group, List<string> pageList, List<string> userList, List<ShopNum1_GroupPageWebControl> groupPageWebControlList);
		int CheckShotName(string shortName);
		int Add(List<ShopNum1_GroupPage> strPagelList);
	}
}
