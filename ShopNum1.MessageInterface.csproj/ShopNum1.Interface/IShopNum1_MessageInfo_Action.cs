using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_MessageInfo_Action
	{
		int Add(ShopNum1_MessageInfo messageInfo, List<string> usermessage);
		DataTable SearchSend(string loginID, string memLoginID, string startDate, string endDate, string title, string type, int isRead, int isDelete);
		DataTable SearchReceive(string loginID, string memLoginID, string startDate, string endDate, string title, string type, int isRead, int isReply, int isDelete);
		int DeleteSend(string guids);
		int DeleteReceive(string guids);
		DataTable Search(string guid);
		int Update(ShopNum1_MemberMessage memberMessage);
		DataTable SelectSysMsg_Detail(ShopNum1_MessageInfo shopNum1_MessageInfo);
		DataTable SelectSysMsg_List(CommonPageModel commonModel);
		int Update_SysMsgIsRead(string strGuid);
		int Delete_SysMsg(string strArray);
	}
}
