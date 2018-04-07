using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.ShopInterface
{
	public interface IShop_MessageBoard_Action
	{
		DataTable SearchMessageBoardList(string replyuser, string isshow, string showcount, string messagetype);
		DataSet SearchMessageBoardListNew(string shopid, string type, string ordertype, string sort, string perpagenum, string current_page, string isreturcount);
		DataTable SelectMessageBoard_List(CommonPageModel commonModel);
	}
}
