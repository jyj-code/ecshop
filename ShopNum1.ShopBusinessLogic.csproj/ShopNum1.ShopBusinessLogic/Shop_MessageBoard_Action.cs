using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.ShopBusinessLogic
{
	public class Shop_MessageBoard_Action : IShop_MessageBoard_Action
	{
		public DataTable SearchMessageBoardList(string replyuser, string isshow, string showcount, string messagetype)
		{
			string[] array = new string[4];
			string[] array2 = new string[4];
			array[0] = "@replyuser";
			array2[0] = replyuser;
			array[1] = "@isshow";
			array2[1] = isshow;
			array[2] = "@showcount";
			array2[2] = showcount;
			array[3] = "@messagetype";
			array2[3] = messagetype;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_SearchMessageBoardList", array, array2);
		}
		public DataTable SearchMessageBoard(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_SearchMessageBoard", array, array2);
		}
		public int MessageBoardReply(ShopNum1_Shop_MessageBoard messageBoard)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@guid";
			array2[0] = messageBoard.Guid.ToString();
			array[1] = "@replytime";
			array2[1] = messageBoard.ReplyTime.ToString();
			array[2] = "@replycontent";
			array2[2] = messageBoard.ReplyContent;
			return DatabaseExcetue.RunProcedure("Pro_Shop_MessageBoardReply", array, array2);
		}
		public int DeleteMessageBoard(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedure("Pro_Shop_DeleteMessageBoard", array, array2);
		}
		public int AddMemMessageBoard(ShopNum1_Shop_MessageBoard messageBoard)
		{
			string[] array = new string[6];
			string[] array2 = new string[6];
			array[0] = "@messagetype";
			array2[0] = messageBoard.MessageType.ToString();
			array[1] = "@tilte";
			array2[1] = messageBoard.Title;
			array[2] = "@content";
			array2[2] = messageBoard.Content;
			array[3] = "@memloginid";
			array2[3] = messageBoard.MemLoginID;
			array[4] = "@replyuser";
			array2[4] = messageBoard.ReplyUser;
			array[5] = "@isShow";
			array2[5] = messageBoard.IsShow.ToString();
			return DatabaseExcetue.RunProcedure("Pro_Shop_AddMemMessageBoard", array, array2);
		}
		public DataTable SearchPhoneContent(string guid, string memLoginID)
		{
			string text = string.Empty;
			text = "SELECT \tGuid\t, \tTitle\t, \tRemark\t, \tIsDeleted\t   FROM Agent_PhnoeContent where  1=1";
			if (Operator.FormatToEmpty(guid) != string.Empty && Operator.FormatToEmpty(guid) != "-1")
			{
				text = text + " AND Guid = '" + Operator.FilterString(guid) + "'";
			}
			text = text + " AND memLoginID ='" + memLoginID + "'";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int UpdateMessageBoardBymanage(string guid, string managereply, string manageid)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@guid";
			array2[0] = guid;
			array[1] = "@managereply";
			array2[1] = managereply;
			array[2] = "@manageid";
			array2[2] = manageid;
			return DatabaseExcetue.RunProcedure("Pro_Shop_UpdateMessageBoardBymanage", array, array2);
		}
		public DataSet SearchMessageBoardListNew(string shopid, string type, string ordertype, string sort, string perpagenum, string current_page, string isreturcount)
		{
			string text = string.Empty;
			if (!string.IsNullOrEmpty(type))
			{
				text = " AND A.MessageType='" + type + "'";
			}
			else
			{
				text = " AND 1=1";
			}
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@shopid";
			array2[0] = shopid;
			array[1] = "@columnnames";
			array2[1] = "  a.Guid,a.MessageType,a.Title,a.MemLoginID AS  MemberName,a.Content,a.SendTime,a.ReplyUser,a.ReplyTime,a.ReplyContent,a.ManageReply,a.ManageTime,a.ManageID,b.Name  ";
			array[2] = "@searchname";
			array2[2] = text;
			array[3] = "@ordertype";
			array2[3] = ordertype;
			array[4] = "@sort";
			array2[4] = sort;
			array[5] = "@perpagenum";
			array2[5] = perpagenum;
			array[6] = "@current_page";
			array2[6] = current_page;
			array[7] = "@isreturcount";
			array2[7] = isreturcount;
			return DatabaseExcetue.RunProcedureReturnDataSet("Pro_Shop_SearchMessageBoardListNew", array, array2);
		}
		public DataTable SelectMessageBoard_List(CommonPageModel commonModel)
		{
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@pagesize";
			array2[0] = commonModel.PageSize;
			array[1] = "@currentpage";
			array2[1] = commonModel.Currentpage;
			array[2] = "@columns";
			array2[2] = " * ";
			array[3] = "@tablename";
			array2[3] = commonModel.Tablename;
			array[4] = "@condition";
			array2[4] = commonModel.Condition;
			array[5] = "@ordercolumn";
			array2[5] = "SendTime";
			array[6] = "@sortvalue";
			array2[6] = "desc";
			array[7] = "@resultnum";
			array2[7] = commonModel.Resultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
		public DataTable SelectMyShopMessageBoard_List(CommonPageModel commonModel)
		{
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@pagesize";
			array2[0] = commonModel.PageSize;
			array[1] = "@currentpage";
			array2[1] = commonModel.Currentpage;
			array[2] = "@columns";
			array2[2] = " * ";
			array[3] = "@tablename";
			array2[3] = "ShopNum1_Shop_MessageBoard";
			array[4] = "@condition";
			array2[4] = commonModel.Condition;
			array[5] = "@ordercolumn";
			array2[5] = "SendTime";
			array[6] = "@sortvalue";
			array2[6] = "desc";
			array[7] = "@resultnum";
			array2[7] = commonModel.Resultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
	}
}
