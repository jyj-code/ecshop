using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_MemberMessage_Action
	{
		DataTable SelectMsg(ShopNum1_MemberMessage shopNum1_MemberMessage);
		DataTable SelectMsg_List(CommonPageModel commonModel);
		int Add_MemberMsg(ShopNum1_MemberMessage shopNum1_MemberMessage);
		int Update_MsgIsRead(string strGuid);
		int Delete_Msg(string strArray);
	}
}
