using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_MMS_Action : IShopNum1_MMS_Action
	{
		public int Add(ShopNum1_MMS email)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_MMS( Guid, TypeName, Title, Remark, Description, CreateUser, CreateTime, ModifyUser, ModifyTime,  IsDeleted ) VALUES (  '",
				email.Guid,
				"',  '",
				Operator.FilterString(email.TypeName),
				"',  '",
				Operator.FilterString(email.Title),
				"',  '",
				email.Remark,
				"',  '",
				Operator.FilterString(email.Description),
				"',  '",
				email.CreateUser,
				"', '",
				email.CreateTime,
				"',  '",
				email.ModifyUser,
				"' , '",
				email.ModifyTime,
				"',  ",
				email.IsDeleted,
				")"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Delete(string guids)
		{
			string strSql = string.Empty;
			strSql = "DELETE FROM ShopNum1_MMS WHERE  Guid in ( " + guids + " )";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetEditInfo(string guid, int isDeleted)
		{
			string text = string.Empty;
			text = "select Guid,TypeName,Title,Remark,Description,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted from ShopNum1_MMS where Guid=" + guid;
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND IsDeleted=",
					isDeleted,
					" "
				});
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Search(string title, string typename, int isDeleted)
		{
			string text = string.Empty;
			text = "SELECT \tA.Guid\t, \tA.Title\t, \tA.Remark\t, \tA.Description\t, \tA.CreateUser\t, \tA.CreateTime\t, \tA.ModifyUser\t, \tA.ModifyTime\t, \tA.IsDeleted\t   FROM ShopNum1_MMS A  WHERE 0=0 ";
			if (Operator.FormatToEmpty(title) != string.Empty)
			{
				text = text + " AND A.Title Like '%" + Operator.FilterString(title) + "%'";
			}
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND A.IsDeleted=",
					isDeleted,
					" "
				});
			}
			text += "Order by A.CreateTime Desc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int Update(string guid, ShopNum1_MMS email)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_MMS SET  TypeName='",
				Operator.FilterString(email.TypeName),
				"', Title='",
				Operator.FilterString(email.Title),
				"', Remark='",
				email.Remark,
				"', Description='",
				Operator.FilterString(email.Description),
				"', ModifyUser='",
				email.ModifyUser,
				"', ModifyTime='",
				email.ModifyTime,
				"'WHERE Guid=",
				guid
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable Search(int isDeleted)
		{
			string text = string.Empty;
			text = "SELECT \tGuid\t, \tTitle\t, \tRemark\t, \tIsDeleted\t   FROM ShopNum1_MMS where  1=1";
			if (isDeleted == 0)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND IsDeleted=",
					isDeleted,
					" "
				});
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchMMSContent(string guid)
		{
			string text = string.Empty;
			text = "SELECT \tGuid\t, \tTitle\t, \tRemark\t, \tIsDeleted\t   FROM ShopNum1_MMS where  1=1";
			if (Operator.FormatToEmpty(guid) != string.Empty && Operator.FormatToEmpty(guid) != "-1")
			{
				text = text + " AND Guid = '" + Operator.FilterString(guid) + "'";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int AddMMSGroupSend(ShopNum1_MMSGroupSend MMSGroupSend)
		{
			List<string> list = new List<string>();
			string item = string.Empty;
			item = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_MMSGroupSend( Guid, SendObject, SendObjectMMS, MMSTitle, State, CreateTime, IsTime, TimeSendTime, MMSGuid  ) VALUES (  '",
				MMSGroupSend.Guid,
				"',  '",
				Operator.FilterString(MMSGroupSend.SendObject),
				"',  '",
				Operator.FilterString(MMSGroupSend.SendObjectMMS),
				"',  '",
				Operator.FilterString(MMSGroupSend.MMSTitle),
				"',  '",
				Operator.FilterString(MMSGroupSend.State),
				"',  '",
				Convert.ToDateTime(MMSGroupSend.CreateTime).ToString("yyyy-MM-dd HH:mm:ss"),
				"', '",
				MMSGroupSend.IsTime,
				"',  '",
				Convert.ToDateTime(MMSGroupSend.CreateTime).ToString("yyyy-MM-dd HH:mm:ss"),
				"' , '",
				MMSGroupSend.MMSGuid,
				"' )"
			});
			list.Add(item);
			string text = Guid.NewGuid().ToString();
			item = string.Concat(new string[]
			{
				"INSERT INTO ShopNum1_MessageInfo( Guid,Title,Type,MemLoginID,Content,sendtime,OperateUser,IsDeleted  ) VALUES (  '",
				text,
				"',  '",
				Operator.FilterString(MMSGroupSend.MMSTitle),
				"',  '1',  '",
				MMSGroupSend.SendObject.Split(new char[]
				{
					'-'
				})[0],
				"',  '",
				Operator.FilterString(MMSGroupSend.SendObjectMMS),
				"',  '",
				Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss"),
				"' , 'admin' , '0')"
			});
			list.Add(item);
			item = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_UserMessage(  Guid ,  ReceiveID ,  SendID,  IsRead, SendTime,  IsDeleted,  MessageInfoGuid,  SendIsDeleted,  ReceiveIsDeleted  ) VALUES (  '",
				Guid.NewGuid(),
				"',  '",
				MMSGroupSend.SendObject.Split(new char[]
				{
					'-'
				})[0],
				"',  'admin',  ",
				0,
				",  '",
				Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss"),
				"',  ",
				0,
				",  '",
				text,
				"',  ",
				0,
				",  ",
				0,
				" )"
			});
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
		public DataTable SearchMMSGroupSend(string mmstitle, string strtime1, string strtime2, string sendObjectMMS, int state, int istime)
		{
			string text = string.Empty;
			text = "SELECT \tGuid\t, \tSendObject\t, \tSendObjectMMS\t, \tMMSTitle\t, \tState\t, \tCreateTime\t, \tTimeSendTime\t, \tMMSGuid,\t \tIsTime\t   FROM ShopNum1_MMSGroupSend where  1=1";
			if (Operator.FormatToEmpty(mmstitle) != string.Empty)
			{
				text = text + " AND MMSTitle like '%" + Operator.FilterString(mmstitle) + "%'";
			}
			if (Operator.FormatToEmpty(strtime1) != string.Empty)
			{
				text = text + " AND CreateTime>='" + Operator.FilterString(strtime1) + "' ";
			}
			if (Operator.FormatToEmpty(strtime2) != string.Empty)
			{
				text = text + " AND CreateTime<='" + Operator.FilterString(strtime2) + "' ";
			}
			if (Operator.FormatToEmpty(sendObjectMMS) != string.Empty)
			{
				text = text + " AND SendObject like  '%" + Operator.FilterString(sendObjectMMS) + "%'";
			}
			if (state == 0 || state == 1 || state == 2)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND State =",
					state,
					" "
				});
			}
			if (istime == 0)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND IsTime =",
					istime,
					" "
				});
			}
			text += "Order By CreateTime Desc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int Deleted(string guids)
		{
			string strSql = string.Empty;
			strSql = "DELETE FROM ShopNum1_MMSGroupSend WHERE  Guid in ( " + guids + " )";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Update(ShopNum1_MMSGroupSend mMSGroupSend)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"Update  ShopNum1_MMSGroupSend  set  State=",
				mMSGroupSend.State,
				"  FROM ShopNum1_MMSGroupSend WHERE  Guid ='",
				mMSGroupSend.Guid,
				" '"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetMMSGroupSendInfo(string guid)
		{
			string strSql = string.Empty;
			strSql = "select SendObjectMMS,MMSTitle,sendobjectmms,SendObject from ShopNum1_MMSGroupSend where guid='" + guid + "'";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable SearchMemberGroup(int isDeleted)
		{
			string text = string.Empty;
			text = "SELECT \tGuid\t, \tName,  Description   FROM ShopNum1_MMSMemberGroup  WHERE 0=0 ";
			if (isDeleted == 0)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND IsDeleted =",
					isDeleted,
					" "
				});
			}
			text += "Order By CreateTime Desc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int DeleteMemberGroup(string guids)
		{
			List<string> list = new List<string>();
			string item = string.Empty;
			item = "DELETE FROM ShopNum1_MMSMemberAssignGroup  WHERE  MemberGroupGuid IN (" + guids + ")";
			list.Add(item);
			item = "DELETE FROM ShopNum1_MMSMemberGroup  WHERE  Guid IN (" + guids + ")";
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
		public DataTable SearchMemberGroup(string guid)
		{
			string text = string.Empty;
			string str = guid.Replace("'", "");
			text = "SELECT  Guid, Name,  Description\t FROM ShopNum1_MMSMemberGroup  where 1=1";
			if (Operator.FormatToEmpty(guid) != string.Empty && Operator.FormatToEmpty(guid) != "0")
			{
				text = text + " AND Guid = '" + str + "'";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int Add(ShopNum1_MMSMemberGroup memberGroup, List<string> memberAssignGroup)
		{
			List<string> list = new List<string>();
			string item = string.Empty;
			item = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_MMSMemberGroup(   Guid,  Name,  Description,  CreateUser,  CreateTime,  ModifyUser,  ModifyTime,  IsDeleted ) VALUES (  '",
				memberGroup.Guid,
				"', '",
				memberGroup.Name,
				"', '",
				memberGroup.Description,
				"', '",
				memberGroup.CreateUser,
				"', '",
				memberGroup.CreateTime,
				"', '",
				memberGroup.ModifyUser,
				"', '",
				memberGroup.ModifyTime,
				"', ",
				memberGroup.IsDeleted,
				")"
			});
			list.Add(item);
			if (memberAssignGroup.Count > 0)
			{
				for (int i = 0; i < memberAssignGroup.Count; i++)
				{
					item = string.Concat(new object[]
					{
						"INSERT INTO ShopNum1_MMSMemberAssignGroup(   Guid,  MemLoginID,  MemberGroupGuid,  CreateUser,  CreateTime ) VALUES (  '",
						Guid.NewGuid(),
						"', '",
						memberAssignGroup[i],
						"', '",
						memberGroup.Guid,
						"', '",
						memberGroup.CreateUser,
						"', '",
						memberGroup.CreateTime,
						"')"
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
		public int UpdateMemberAssignGroup(ShopNum1_MMSMemberGroup memberGroup, List<string> memberAssignGroup)
		{
			List<string> list = new List<string>();
			string item = string.Empty;
			item = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_MMSMemberGroup SET  Name ='",
				memberGroup.Name,
				"', Description ='",
				memberGroup.Description,
				"', CreateUser ='",
				memberGroup.ModifyUser,
				"', CreateTime ='",
				memberGroup.ModifyTime,
				"'WHERE Guid='",
				memberGroup.Guid,
				"'"
			});
			list.Add(item);
			item = "Delete from ShopNum1_MMSMemberAssignGroup where MemberGroupGuid='" + memberGroup.Guid + "'";
			list.Add(item);
			if (memberAssignGroup.Count > 0)
			{
				for (int i = 0; i < memberAssignGroup.Count; i++)
				{
					item = string.Concat(new object[]
					{
						"INSERT INTO ShopNum1_MMSMemberAssignGroup(   Guid,  MemLoginID,  MemberGroupGuid,  CreateUser,  CreateTime ) VALUES (  '",
						Guid.NewGuid(),
						"', '",
						memberAssignGroup[i],
						"', '",
						memberGroup.Guid,
						"', '",
						memberGroup.ModifyUser,
						"', '",
						memberGroup.ModifyTime,
						"')"
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
		public DataTable SearchMemberAssignGroup(string guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT  A.Guid, A.MemLoginID,  B.Name, B.Email, B.Tel, B.Mobile, A.MemberGroupGuid  FROM ShopNum1_MMSMemberAssignGroup A,  ShopNum1_Member B WHERE  A.MemLoginID=B.MemLoginID and  A.MemberGroupGuid = '" + guid + "'";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable SearchByMemLoginID(string memLoginID)
		{
			string text = string.Empty;
			text = "SELECT Guid\t, MemLoginID\t, AdvancePayment,Email,LoginTime,Name,Score  FROM ShopNum1_Member    WHERE 0=0 ";
			if (Operator.FormatToEmpty(memLoginID) != string.Empty)
			{
				text = text + " AND MemLoginID = '" + Operator.FilterString(memLoginID) + "'";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
	}
}
