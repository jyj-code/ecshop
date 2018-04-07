using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_Email_Action
	{
		int Add(ShopNum1_Email email);
		int Delete(string guids);
		DataTable GetEditInfo(string guid, int isDeleted);
		DataTable Search(string title, string typename, int isDeleted);
		int Update(string guid, ShopNum1_Email email);
		DataTable Search(int isDeleted);
		DataTable SearchEmailContent(string guid);
		int AddEmailGroupSend(ShopNum1_EmailGroupSend emailGroupSend);
		DataTable SearchEmailGroupSend(string emailtitle, string strtime1, string strtime2, string sendObjectEmail, int state, int istime);
		int Deleted(string guids);
		int Update(ShopNum1_EmailGroupSend emailGroupSend);
		DataTable GetEmailGroupSendInfo(string guid);
		DataTable SearchEmailMemberAssignGroup(string guid);
		int Email_Group_Add(ShopNum1_MemberGroup memberGroup, List<string> EmailmemberAssignGroup);
		int UpdateEmailMemberAssignGroup(ShopNum1_MemberGroup memberGroup, List<string> memberAssignGroup);
		DataTable SearchMemberGroup(int isDeleted);
		DataTable SearchMemberGroup(string guid);
		DataTable SearchByMemLoginID(string memLoginID);
		int DeleteMemberGroup(string guids);
	}
}
