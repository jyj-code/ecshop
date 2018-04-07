using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_Email_Action : IShopNum1_Email_Action
	{
		public int Add(ShopNum1_Email email)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_Email( Guid, TypeName, Title, Remark, Description, CreateUser, CreateTime, ModifyUser, ModifyTime, IsDeleted  ) VALUES (  '",
				email.Guid,
				"',  '",
				Operator.FilterString(email.TypeName),
				"',  '",
				Operator.FilterString(email.Title),
				"',  '",
				Operator.FilterString(email.Remark),
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
				" )"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Delete(string guids)
		{
			string strSql = string.Empty;
			strSql = "DELETE FROM ShopNum1_Email WHERE  Guid in ( " + guids + " )";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetEditInfo(string guid, int isDeleted)
		{
			string text = string.Empty;
			text = "select Guid,TypeName,Title,Remark,Description,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted from ShopNum1_Email where Guid=" + guid;
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
			text = "SELECT \tA.Guid\t, \tA.Title\t, \tA.Remark\t, \tA.Description\t, \tA.CreateUser\t, \tA.CreateTime\t, \tA.ModifyUser\t, \tA.ModifyTime\t, \tA.IsDeleted\t   FROM ShopNum1_Email A WHERE 0=0 ";
			if (Operator.FormatToEmpty(title) != string.Empty)
			{
				text = text + " AND A.Title Like '%" + Operator.FilterString(title) + "%'";
			}
			if (!(Operator.FormatToEmpty(typename) != "-1"))
			{
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
			text += " order by A.ModifyTime desc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int Update(string guid, ShopNum1_Email email)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_Email SET  TypeName='",
				Operator.FilterString(email.TypeName),
				"', Title='",
				Operator.FilterString(email.Title),
				"', Remark='",
				Operator.FilterString(email.Remark),
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
			text = "SELECT \tGuid\t, \tTitle\t, \tRemark\t, \tIsDeleted\t   FROM ShopNum1_Email where  1=1";
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
		public DataTable SearchEmailContent(string guid)
		{
			string text = string.Empty;
			text = "SELECT \tGuid\t, \tTitle\t, \tRemark\t, \tIsDeleted\t   FROM ShopNum1_Email where  1=1";
			if (Operator.FormatToEmpty(guid) != string.Empty && Operator.FormatToEmpty(guid) != "-1")
			{
				text = text + " AND Guid = '" + Operator.FilterString(guid) + "'";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int AddEmailGroupSend(ShopNum1_EmailGroupSend emailGroupSend)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_EmailGroupSend(  Guid,  SendObject,  SendObjectEmail,  EmailTitle,  State,  EmailGuid,  CreateTime  ) VALUES (  '",
				emailGroupSend.Guid,
				"',  '",
				emailGroupSend.SendObject,
				"',  '",
				emailGroupSend.SendObjectEmail,
				"',  '",
				Operator.FilterString(emailGroupSend.EmailTitle),
				"',  ",
				emailGroupSend.State,
				",  '",
				emailGroupSend.EmailGuid,
				"',  '",
				emailGroupSend.CreateTime,
				"' )"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable SearchEmailGroupSend(string emailtitle, string strtime1, string strtime2, string sendObjectEmail, int state, int istime)
		{
			string text = string.Empty;
			text = "SELECT \tGuid\t, \tSendObject\t, \tSendObjectEmail\t, \tEmailTitle\t, \tState\t, \tCreateTime\t, \tTimeSendTime\t, \tEmailGuid,\t \tIsTime    FROM ShopNum1_EmailGroupSend where  1=1";
			if (Operator.FormatToEmpty(emailtitle) != string.Empty)
			{
				text = text + " AND EmailTitle like '%" + Operator.FilterString(emailtitle) + "%'";
			}
			if (Operator.FormatToEmpty(strtime1) != string.Empty)
			{
				text = text + " AND CreateTime>='" + Operator.FilterString(strtime1) + "' ";
			}
			if (Operator.FormatToEmpty(strtime2) != string.Empty)
			{
				text = text + " AND CreateTime<='" + Operator.FilterString(strtime2) + "' ";
			}
			if (Operator.FormatToEmpty(sendObjectEmail) != string.Empty)
			{
				text = text + " AND SendObject like  '%" + Operator.FilterString(sendObjectEmail) + "%'";
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
			strSql = "DELETE FROM ShopNum1_EmailGroupSend WHERE  Guid in ( " + guids + " )";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Update(ShopNum1_EmailGroupSend emailGroupSend)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"Update  ShopNum1_EmailGroupSend  set  State=",
				emailGroupSend.State,
				"  WHERE  Guid ='",
				emailGroupSend.Guid,
				" '"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetEmailGroupSendInfo(string guid)
		{
			string text = string.Empty;
			text = "select  A.SendObjectEmail,  A.SendObject,  A.EmailTitle from ShopNum1_EmailGroupSend A where 1=1";
			if (Operator.FormatToEmpty(guid) != string.Empty)
			{
				text = text + " AND A.Guid ='" + guid + "' ";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchMemberGroup(int isDeleted)
		{
			string text = string.Empty;
			text = "SELECT \tGuid\t, \tName,  Description   FROM ShopNum1_MemberGroup  WHERE 0=0 ";
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
		public DataTable SearchMemberGroup(string guid)
		{
			string text = string.Empty;
			string str = guid.Replace("'", "");
			text = "SELECT  Guid, Name,  Description\t FROM ShopNum1_MemberGroup  where 1=1";
			if (Operator.FormatToEmpty(guid) != string.Empty && Operator.FormatToEmpty(guid) != "0")
			{
				text = text + " AND Guid = '" + str + "'";
			}
			return DatabaseExcetue.ReturnDataTable(text);
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
		public DataTable SearchEmailMemberAssignGroup(string guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT  A.Guid, A.MemLoginID,  B.Name, B.Email, B.Tel, A.MemberGroupGuid  FROM ShopNum1_MemberAssignGroup A,  ShopNum1_Member B WHERE  A.MemLoginID=B.MemLoginID and  A.MemberGroupGuid = '" + guid + "'";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int Email_Group_Add(ShopNum1_MemberGroup memberGroup, List<string> EmailmemberAssignGroup)
		{
			List<string> list = new List<string>();
			string item = string.Empty;
			item = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_MemberGroup(   Guid,  Name,  Description,  CreateUser,  CreateTime,  ModifyUser,  ModifyTime,  IsDeleted ) VALUES (  '",
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
			if (EmailmemberAssignGroup.Count > 0)
			{
				for (int i = 0; i < EmailmemberAssignGroup.Count; i++)
				{
					item = string.Concat(new object[]
					{
						"INSERT INTO ShopNum1_MemberAssignGroup(   Guid,  MemLoginID,  MemberGroupGuid,  CreateUser,  CreateTime ) VALUES (  '",
						Guid.NewGuid(),
						"', '",
						EmailmemberAssignGroup[i],
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
		public int UpdateEmailMemberAssignGroup(ShopNum1_MemberGroup memberGroup, List<string> memberAssignGroup)
		{
			List<string> list = new List<string>();
			string item = string.Empty;
			item = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_MemberGroup SET  Name ='",
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
			item = "Delete from ShopNum1_MemberAssignGroup where MemberGroupGuid='" + memberGroup.Guid + "'";
			list.Add(item);
			if (memberAssignGroup.Count > 0)
			{
				for (int i = 0; i < memberAssignGroup.Count; i++)
				{
					item = string.Concat(new object[]
					{
						"INSERT INTO ShopNum1_MemberAssignGroup(   Guid,  MemLoginID,  MemberGroupGuid,  CreateUser,  CreateTime ) VALUES (  '",
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
		public int DeleteMemberGroup(string guids)
		{
			List<string> list = new List<string>();
			string item = string.Empty;
			item = "DELETE FROM ShopNum1_MemberAssignGroup  WHERE  MemberGroupGuid IN (" + guids + ")";
			list.Add(item);
			item = "DELETE FROM ShopNum1_MemberGroup  WHERE  Guid IN (" + guids + ")";
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
	}
}
