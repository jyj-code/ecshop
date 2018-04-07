using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_MMS_Action
	{
		int Add(ShopNum1_MMS email);
		int Delete(string guids);
		DataTable Search(string title, string typename, int isDeleted);
		DataTable GetEditInfo(string guid, int isDeleted);
		int Update(string guid, ShopNum1_MMS email);
		DataTable Search(int isDeleted);
		DataTable SearchMMSContent(string guid);
		int AddMMSGroupSend(ShopNum1_MMSGroupSend emailGroupSend);
		DataTable SearchMMSGroupSend(string emailtitle, string strtime1, string strtime2, string sendObjectMMS, int state, int istime);
		int Deleted(string guids);
		int Update(ShopNum1_MMSGroupSend emailGroupSend);
		DataTable GetMMSGroupSendInfo(string guid);
		DataTable SearchMemberGroup(int isDeleted);
		int DeleteMemberGroup(string guids);
		DataTable SearchMemberGroup(string guid);
		int Add(ShopNum1_MMSMemberGroup memberGroup, List<string> memberAssignGroup);
		int UpdateMemberAssignGroup(ShopNum1_MMSMemberGroup memberGroup, List<string> memberAssignGroup);
		DataTable SearchMemberAssignGroup(string guid);
		DataTable SearchByMemLoginID(string memLoginID);
	}
}
