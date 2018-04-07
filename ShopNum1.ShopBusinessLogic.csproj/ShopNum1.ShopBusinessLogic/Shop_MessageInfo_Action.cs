using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace ShopNum1.ShopBusinessLogic
{
	public class Shop_MessageInfo_Action : IShop_MessageInfo_Action
	{
		public DataTable SearchReceive(string sendMemLoginID, string isRead, string title, string createTime1, string createTime2, string sendMemType, string receiveMemLoginID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("b.Title,");
			stringBuilder.Append("b.[Content],");
			stringBuilder.Append("b.CreateTime,");
			stringBuilder.Append("b.Type,");
			stringBuilder.Append("c.Name as SendMemberName,");
			stringBuilder.Append("a.* ");
			stringBuilder.Append("FROM ");
			stringBuilder.Append("ShopNum1_MemberMessage AS a,");
			stringBuilder.Append("ShopNum1_MessageInfo AS b, ");
			stringBuilder.Append("ShopNum1_Member AS c ");
			stringBuilder.Append("WHERE ");
			stringBuilder.Append("a.SendMemLoginID=c.MemLoginID ");
			stringBuilder.Append("And a.MessageInfoGuid = b.Guid ");
			stringBuilder.Append("AND ReceiveIsDeleted = 0 ");
			stringBuilder.Append("AND ReceiveMemLoginID = '" + receiveMemLoginID + "'");
			if (isRead != "-1")
			{
				stringBuilder.Append(" AND IsRead = " + isRead);
			}
			if (!string.IsNullOrEmpty(title))
			{
				stringBuilder.Append(" AND b.Title LIKE '%" + Operator.FilterString(title) + "%'");
			}
			if (!string.IsNullOrEmpty(createTime1))
			{
				stringBuilder.Append(" AND b.CreateTime >= '" + createTime1 + "'");
			}
			if (!string.IsNullOrEmpty(createTime2))
			{
				stringBuilder.Append(" b.AND CreateTime <= '" + createTime2 + "'");
			}
			if (!string.IsNullOrEmpty(sendMemLoginID))
			{
				stringBuilder.Append(" AND c.Name LIKE '%" + Operator.FilterString(sendMemLoginID) + "%'");
			}
			if (sendMemType != "-1")
			{
				stringBuilder.Append(" AND SendMemType = " + sendMemType);
			}
			stringBuilder.Append(" ORDER BY b.CreateTime DESC");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable SearchSend(string receiveMemLoginID, string isRead, string title, string createTime1, string createTime2, string receiveMemType, string sendMemLoginID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("b.Title,");
			stringBuilder.Append("b.[Content],");
			stringBuilder.Append("b.CreateTime,");
			stringBuilder.Append("[Type], ");
			stringBuilder.Append("c.Name as MemberName,");
			stringBuilder.Append("a.* ");
			stringBuilder.Append("FROM ");
			stringBuilder.Append("ShopNum1_MemberMessage AS a,");
			stringBuilder.Append("ShopNum1_MessageInfo AS b, ");
			stringBuilder.Append("ShopNum1_Member AS c ");
			stringBuilder.Append("WHERE ");
			stringBuilder.Append("a.MessageInfoGuid = b.Guid ");
			stringBuilder.Append("AND a.ReceiveMemLoginID=c.MemLoginID  ");
			stringBuilder.Append("AND SendIsDeleted = 0 ");
			stringBuilder.Append("AND SendMemLoginID = '" + sendMemLoginID + "'");
			if (isRead != "-1")
			{
				stringBuilder.Append(" AND IsRead = " + isRead);
			}
			if (title != "" && title != null)
			{
				stringBuilder.Append(" AND Title LIKE '%" + title + "%'");
			}
			if (createTime1 != "" && createTime1 != null)
			{
				stringBuilder.Append(" AND CreateTime >= '" + createTime1 + "'");
			}
			if (createTime2 != "" && createTime2 != null)
			{
				stringBuilder.Append(" AND CreateTime <= '" + createTime2 + "'");
			}
			if (receiveMemLoginID != "" && receiveMemLoginID != null)
			{
				stringBuilder.Append(" AND C.Name LIKE '%" + receiveMemLoginID + "%'");
			}
			if (receiveMemType != "-1")
			{
				stringBuilder.Append(" AND ReceiveMemType = " + receiveMemType);
			}
			stringBuilder.Append(" ORDER BY b.CreateTime DESC");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public int DeleteReceive(string guids)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("UPDATE ShopNum1_MemberMessage ");
			stringBuilder.Append("SET ReceiveIsDeleted = 1 ");
			stringBuilder.Append("WHERE Guid IN (" + guids + ")");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public int DeleteSend(string guids)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("UPDATE ShopNum1_MemberMessage ");
			stringBuilder.Append("SET SendIsDeleted = 1 ");
			stringBuilder.Append("WHERE Guid IN (" + guids + ")");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public int Add(ShopNum1_MessageInfo agentMessageInfo, List<string> receiveMemLoginID, string sendMemLoginID, string receiveMemType, string sendMemType)
		{
			List<string> list = new List<string>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("INSERT INTO ShopNum1_MessageInfo");
			stringBuilder.Append("(Guid,");
			stringBuilder.Append("[Title],");
			stringBuilder.Append("[CreateTime],");
			stringBuilder.Append("[Content], ");
			stringBuilder.Append("[Type]) ");
			stringBuilder.Append("VALUES ");
			stringBuilder.Append("('" + agentMessageInfo.Guid.ToString() + "',");
			stringBuilder.Append("'" + Operator.FilterString(agentMessageInfo.Title) + "',");
			stringBuilder.Append("'" + Operator.FilterString(agentMessageInfo.Content) + "',");
			stringBuilder.Append(agentMessageInfo.Type + ")");
			list.Add(stringBuilder.ToString());
			for (int i = 0; i < receiveMemLoginID.Count; i++)
			{
				stringBuilder.Length = 0;
				stringBuilder.Append("INSERT INTO ShopNum1_MemberMessage");
				stringBuilder.Append("(Guid,");
				stringBuilder.Append("MessageInfoGuid,");
				stringBuilder.Append("ReceiveMemLoginID,");
				stringBuilder.Append("ReceiveMemType,");
				stringBuilder.Append("SendMemType,");
				stringBuilder.Append("SendMemLoginID ) ");
				stringBuilder.Append("VALUES ");
				stringBuilder.Append("(newid(),");
				stringBuilder.Append("'" + agentMessageInfo.Guid.ToString() + "',");
				stringBuilder.Append("'" + receiveMemLoginID[i] + "',");
				stringBuilder.Append(receiveMemType + ",");
				stringBuilder.Append(sendMemType + ",");
				stringBuilder.Append("'" + sendMemLoginID + "')");
				list.Add(stringBuilder.ToString());
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
		public DataTable SelectByGuid(string guid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("b.Title,");
			stringBuilder.Append("b.[Content],");
			stringBuilder.Append("b.CreateTime,");
			stringBuilder.Append("b.Type,");
			stringBuilder.Append("c.Name as SendMemberName,");
			stringBuilder.Append("a.* ");
			stringBuilder.Append("FROM ");
			stringBuilder.Append("ShopNum1_MemberMessage AS a,");
			stringBuilder.Append("ShopNum1_MessageInfo AS b, ");
			stringBuilder.Append("ShopNum1_Member AS c ");
			stringBuilder.Append("WHERE ");
			stringBuilder.Append("a.SendMemLoginID=c.MemLoginID ");
			stringBuilder.Append(" and a.MessageInfoGuid = b.Guid ");
			stringBuilder.Append(" AND ");
			stringBuilder.Append(" b.Guid = '" + guid + "'");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public string GetMessageInfoGuid(string memberMessageGuid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT MessageInfoGuid FROM ShopNum1_MemberMessage WHERE Guid = " + memberMessageGuid);
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString()).Rows[0][0].ToString();
		}
		public void IsRead(string memberMessageGuid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(string.Concat(new string[]
			{
				"IF((SELECT COUNT(1) FROM ShopNum1_MemberMessage WHERE Guid = ",
				memberMessageGuid,
				") = 1) BEGIN UPDATE Agent_MemberMessage SET IsRead = 1 WHERE Guid = ",
				memberMessageGuid,
				" END"
			}));
			DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public DataTable SelectMemberByGuid(string guid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("ReceiveMemLoginID,");
			stringBuilder.Append("ReceiveMemType,");
			stringBuilder.Append("SendMemType,");
			stringBuilder.Append("SendMemLoginID,");
			stringBuilder.Append(" (select Name from ShopNum1_Member where ShopNum1_MemberMessage.SendMemLoginID=ShopNum1_Member.MemLoginID) as SendName ");
			stringBuilder.Append("FROM ");
			stringBuilder.Append("ShopNum1_MemberMessage ");
			stringBuilder.Append("WHERE ");
			stringBuilder.Append("Guid = " + guid);
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public int UpdateReadState(string guid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("UPDATE ShopNum1_MemberMessage ");
			stringBuilder.Append("SET IsRead = 1 ");
			stringBuilder.Append("WHERE Guid = '" + guid + "'");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
	}
}
