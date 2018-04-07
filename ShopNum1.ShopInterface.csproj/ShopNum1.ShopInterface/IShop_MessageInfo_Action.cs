using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.ShopInterface
{
	public interface IShop_MessageInfo_Action
	{
		DataTable SearchReceive(string sendMemLoginID, string isRead, string title, string createTime1, string createTime2, string sendMemType, string receiveMemLoginID);
		int DeleteReceive(string guids);
		void IsRead(string memberMessageGuid);
		DataTable SearchSend(string receiveIsDeleted, string isRead, string title, string createTime1, string createTime2, string receiveMemType, string sendMemLoginID);
		int DeleteSend(string guids);
		int Add(ShopNum1_MessageInfo agentMessageInfo, List<string> receiveMemLoginID, string sendMemLoginID, string receiveMemType, string sendMemType);
		DataTable SelectByGuid(string guid);
		string GetMessageInfoGuid(string memberMessageGuid);
		DataTable SelectMemberByGuid(string guid);
		int UpdateReadState(string guid);
	}
}
