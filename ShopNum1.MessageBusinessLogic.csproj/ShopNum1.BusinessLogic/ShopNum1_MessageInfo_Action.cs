using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_MessageInfo_Action : IShopNum1_MessageInfo_Action
	{
		public int Add(ShopNum1_MessageInfo messageInfo, List<string> usermessage)
		{
			List<string> list = new List<string>();
			string item = string.Empty;
			item = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_MessageInfo( Guid,Title,Type,Content,sendtime,IsDeleted  ) VALUES (  '",
				messageInfo.Guid,
				"',  '",
				Operator.FilterString(messageInfo.Title),
				"',  '",
				messageInfo.Type,
				"',  '",
				Operator.FilterString(messageInfo.Content),
				"',  '",
				messageInfo.SendTime,
				"',  ",
				messageInfo.IsDeleted,
				" )"
			});
			list.Add(item);
			if (usermessage.Count > 0)
			{
				for (int i = 0; i < usermessage.Count; i++)
				{
					item = string.Concat(new object[]
					{
						"INSERT INTO ShopNum1_UserMessage(  Guid ,  ReceiveID ,  SendID,  IsRead, SendTime,  IsDeleted,  MessageInfoGuid,  SendIsDeleted,  ReceiveIsDeleted  ) VALUES (  '",
						Guid.NewGuid(),
						"',  '",
						usermessage[i],
						"',  '",
						messageInfo.MemLoginID,
						"',  ",
						0,
						",  '",
						messageInfo.SendTime,
						"',  ",
						0,
						",  '",
						messageInfo.Guid,
						"',  ",
						0,
						",  ",
						0,
						" )"
					});
					list.Add(item);
				}
			}
			int result;
			try
			{
				DatabaseExcetue.RunTransactionSql(list);
				result = 1;
			}
			catch
			{
				result = 0;
			}
			return result;
		}
		public DataTable SearchSend(string SendID, string ReceiveID, string startDate, string endDate, string title, string type, int isRead, int isDelete)
		{
			string text = string.Empty;
			text = "select A.Guid,B.Title,A.SendID,A.ReceiveID,B.sendtime as createtime,B.Content,B.Type, A.ReplyTime, A.ReplyContent, A.IsRead From  ShopNum1_UserMessage A,ShopNum1_MessageInfo B Where  A.MessageInfoGuid=B.GUID";
			if (Operator.FormatToEmpty(SendID) != string.Empty)
			{
				text = text + " AND A.SendID LIKE '%" + Operator.FilterString(SendID) + "%'";
			}
			if (Operator.FormatToEmpty(ReceiveID) != string.Empty)
			{
				text = text + " AND A.ReceiveID LIKE '%" + Operator.FilterString(ReceiveID) + "%'";
			}
			if (Operator.FormatToEmpty(startDate) != string.Empty)
			{
				text = text + " AND B.sendtime>='" + Operator.FilterString(startDate) + "'";
			}
			if (Operator.FormatToEmpty(endDate) != string.Empty)
			{
				text = text + " AND B.sendtime<='" + Operator.FilterString(endDate) + "' ";
			}
			if (title != "")
			{
				text = text + " AND B.Title LIKE '%" + Operator.FilterString(title) + "%'";
			}
			if (type != "-1")
			{
				text = text + " AND B.Type ='" + Operator.FilterString(type) + "' ";
			}
			if (isRead != -1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					" AND A.IsRead =",
					isRead,
					" "
				});
			}
			if (isDelete == 0 || isDelete == 1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					" AND A.IsDeleted =",
					isDelete,
					" "
				});
			}
			text += " Order by A.SendTime Desc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchReceive(string SendID, string ReceiveID, string startDate, string endDate, string title, string type, int isRead, int isReply, int isDelete)
		{
			string text = string.Empty;
			text = "select A.Guid,B.Title,A.SendID,A.ReceiveID,B.SendTime,B.Content,B.Type, A.ReplyTime,A.ReplyContent,A.IsRead From  ShopNum1_UserMessage A, ShopNum1_MessageInfo B Where a.MessageInfoGuid=b.GUID";
			if (Operator.FormatToEmpty(SendID) != string.Empty)
			{
				text = text + " AND A.SendID LIKE '%" + Operator.FilterString(SendID) + "%'";
			}
			if (Operator.FormatToEmpty(ReceiveID) != string.Empty)
			{
				text = text + " AND A.ReceiveID LIKE '%" + Operator.FilterString(ReceiveID) + "%'";
			}
			if (Operator.FormatToEmpty(startDate) != string.Empty)
			{
				text = text + " AND A.SendTime>='" + Operator.FilterString(startDate) + "' ";
			}
			if (Operator.FormatToEmpty(endDate) != string.Empty)
			{
				text = text + " AND A.SendTime<='" + Operator.FilterString(endDate) + "' ";
			}
			if (Operator.FormatToEmpty(title) != string.Empty)
			{
				text = text + " AND B.Title LIKE '%" + Operator.FilterString(title) + "%'";
			}
			if (type != "-1")
			{
				text = text + " AND B.Type ='" + Operator.FilterString(type) + "' ";
			}
			if (isRead != -1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					" AND A.IsRead =",
					isRead,
					" "
				});
			}
			if (isReply == 0)
			{
				text += " AND A.ReplyTime is null";
			}
			if (isReply == 1)
			{
				text += " AND A.ReplyTime is not null";
			}
			if (isDelete == 0 || isDelete == 1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					" AND A.IsDeleted =",
					isDelete,
					" "
				});
			}
			text += " Order by A.SendTime Desc ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int DeleteSend(string guids)
		{
			List<string> list = new List<string>();
			string item = string.Empty;
			string strSql = "select count(*) as ItmeCount from ShopNum1_UserMessage where MessageInfoGuid  in (select MessageInfoGuid from ShopNum1_UserMessage where guid in (" + guids + "))";
			int num = Convert.ToInt32(DatabaseExcetue.ReturnDataTable(strSql).Rows[0]["ItmeCount"].ToString());
			if (num > 1)
			{
				item = "delete from ShopNum1_UserMessage where guid in (" + guids + ")";
				list.Add(item);
			}
			else
			{
				item = "delete from ShopNum1_MessageInfo where guid in  (select MessageInfoGuid from ShopNum1_UserMessage where guid in (" + guids + "))";
				list.Add(item);
				item = "delete from ShopNum1_UserMessage where guid in (" + guids + ")";
				list.Add(item);
			}
			int result;
			try
			{
				DatabaseExcetue.RunTransactionSql(list);
				result = 1;
			}
			catch
			{
				result = 0;
			}
			return result;
		}
		public int DeleteReceive(string guids)
		{
			string item = string.Empty;
			List<string> list = new List<string>();
			item = "delete from ShopNum1_MessageInfo where guid in  (select MessageInfoGuid from ShopNum1_UserMessage where guid in (" + guids + "))";
			list.Add(item);
			item = "delete from ShopNum1_UserMessage  WHERE Guid IN (" + guids + ") ";
			list.Add(item);
			int result;
			try
			{
				DatabaseExcetue.RunTransactionSql(list);
				result = 1;
			}
			catch
			{
				result = 0;
			}
			return result;
		}
		public DataTable Search(string guid)
		{
			string strSql = string.Empty;
			strSql = "select A.Guid,B.Title,A.SendID,A.ReceiveID,B.SendTime as SendTime,B.Content,A.ReplyContent,A.ReplyTime,B.Type, A.IsRead From  ShopNum1_UserMessage A, ShopNum1_MessageInfo B Where a.MessageInfoGuid=b.GUID  and a.Guid=" + guid + " ";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int Update(ShopNum1_MemberMessage memberMessage)
		{
			string strSql = string.Empty;
			strSql = "UPDATE  ShopNum1_UserMessage SET WHERE Guid='" + memberMessage.Guid + "' ";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable SelectSysMsg_Detail(ShopNum1_MessageInfo shopNum1_MessageInfo)
		{
			string text = "SELECT * FROM ShopNum1_MessageInfo where IsDeleted=0 ";
			Guid arg_0C_0 = shopNum1_MessageInfo.Guid;
			if (shopNum1_MessageInfo.Guid != new Guid("00000000-0000-0000-0000-000000000000"))
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					" and Guid='",
					shopNum1_MessageInfo.Guid,
					"'"
				});
			}
			text += " order by sendtime desc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SelectSysMsg_List(CommonPageModel commonModel)
		{
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@pagesize";
			array2[0] = commonModel.PageSize;
			array[1] = "@currentpage";
			array2[1] = commonModel.Currentpage;
			array[2] = "@columns";
			array2[2] = "Guid,isread,sendtime,title";
			array[3] = "@tablename";
			array2[3] = "ShopNum1_MessageInfo";
			array[4] = "@condition";
			array2[4] = commonModel.Condition;
			array[5] = "@ordercolumn";
			array2[5] = "sendtime";
			array[6] = "@sortvalue";
			array2[6] = "desc";
			array[7] = "@resultnum";
			array2[7] = commonModel.Resultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
		public int Update_SysMsgIsRead(string strGuid)
		{
			string strSql = "update ShopNum1_MessageInfo set isread=1 where guid='" + strGuid + "'";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Delete_SysMsg(string strArray)
		{
			string strSql = "update ShopNum1_MessageInfo set isdeleted=1 where guid in (" + strArray + ")";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable SelectSysUserMsg_List(CommonPageModel commonModel)
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
			array2[3] = "ShopNum1_UserMessage";
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
		public DataTable Get_SysMsgTitle(string strGuid)
		{
			string strSql = "SELECT  Title FROM     ShopNum1_MessageInfo     where Guid='" + strGuid + "'";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int Update_SysUserMsgIsRead(string strGuid)
		{
			string strSql = "update ShopNum1_UserMessage set IsRead=1 where Guid='" + strGuid + "'";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
	}
}
