namespace ShopNum1.BusinessLogic
{
    using ShopNum1.Common;
    using ShopNum1.DataAccess;
    using ShopNum1.Interface;
    using ShopNum1MultiEntity;
    using System;
    using System.Data;

    public class ShopNum1_MessageBoard_Action : IShopNum1_MessageBoard_Action
    {
        public int Add(ShopNum1_MessageBoard messageBoard)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[] { 
                "INSERT INTO ShopNum1_MessageBoard( \tGuid\t, \tMemLoginID\t, \tMessageType\t, \tTitle\t, \tContent\t, \tSendTime\t, \tIsReply\t, \tIsAudit\t, \tModifyUser, \tModifyTime\t, \tIsDeleted  ) VALUES (  '", messageBoard.Guid, "',  '", messageBoard.MemLoginID, "',  '", messageBoard.MessageType, "',  '", Operator.FilterString(messageBoard.Title), "',  '", Operator.FilterString(messageBoard.Content), "',  '", messageBoard.SendTime, "',  ", messageBoard.IsReply, ",  ", messageBoard.IsAudit, 
                ",  '", messageBoard.ModifyUser, "' , '", messageBoard.ModifyTime, "',  ", messageBoard.IsDeleted, " )"
             }));
        }

        public int AddMemberMessageBoard(ShopNum1_MessageBoard member_MessageBoard)
        {
            string[] paraName = new string[9];
            string[] paraValue = new string[9];
            paraName[0] = "@guid";
            paraValue[0] = member_MessageBoard.Guid.ToString();
            paraName[1] = "@messagetype";
            paraValue[1] = member_MessageBoard.MessageType.ToString();
            paraName[2] = "@tilte";
            paraValue[2] = member_MessageBoard.Title;
            paraName[3] = "@content";
            paraValue[3] = member_MessageBoard.Content;
            paraName[4] = "@repalyuser";
            paraValue[4] = member_MessageBoard.ReplyUser;
            paraName[5] = "@modifyuser";
            paraValue[5] = member_MessageBoard.ModifyUser;
            paraName[6] = "@modifytime";
            paraValue[6] = member_MessageBoard.ModifyTime.ToString();
            paraName[7] = "@IsAudit";
            paraValue[7] = member_MessageBoard.IsAudit.ToString();
            paraName[8] = "@memloginid";
            paraValue[8] = member_MessageBoard.MemLoginID;
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_AddMemMessageBoard", paraName, paraValue);
        }

        public int Delete(string guids)
        {
            return DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_MessageBoard WHERE Guid IN (" + guids + ")");
        }

        public int DeleteMemberMessageBoard(string guids)
        {
            return DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_MessageBoard WHERE Guid IN (" + guids + ")");
        }

        public DataTable GetMemloginIDAndIsAuditByGuid(string guid)
        {
            return DatabaseExcetue.ReturnDataTable("SELECT MemLoginID,IsAudit FROM ShopNum1_MessageBoard WHERE Guid='" + guid + "'");
        }

        public DataTable Search(string guid)
        {
            string strSql = string.Empty;
            strSql = "SELECT \tGuid\t, \tMemLoginID\t, \tMessageType\t, \tTitle\t, \tContent\t, \tSendTime\t, \tReplyUser\t, \tReplyTime\t, \tReplyContent\t, \tIsReply\t, \tIsAudit\t, \tModifyUser, \tModifyTime\t, \tIsDeleted    FROM ShopNum1_MessageBoard  WHERE 1=1";
            if ((Operator.FilterString(guid) != string.Empty) && (Operator.FilterString(guid) != "0"))
            {
                strSql = strSql + "And Guid=" + guid + " ";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable Search(string memLoginID, int isDeleted)
        {
            string str = string.Empty;
            str = "SELECT \tGuid\t, \tMemLoginID\t, \tMessageType\t, \tTitle\t, \tContent\t, \tSendTime\t, \tReplyUser\t, \tReplyTime\t, \tReplyContent\t, \tIsReply\t, \tIsAudit\t, \tModifyUser, \tModifyTime\t, \tIsDeleted   FROM ShopNum1_MessageBoard  WHERE 0=0 ";
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                str = str + " AND MemLoginID LIKE '%" + memLoginID + "%'";
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                str = string.Concat(new object[] { str, " AND IsDeleted=", isDeleted, " " });
            }
            return DatabaseExcetue.ReturnDataTable(str + " Order by SendTime Desc");
        }

        public DataTable Search(int isReply, int isAudit, int count)
        {
            string str = string.Empty;
            if (count > 0)
            {
                str = "SELECT top " + count;
            }
            else
            {
                str = "SELECT ";
            }
            str = str + "\tGuid\t, \tMemLoginID\t, \tMessageType\t, \tTitle\t, \tContent\t, \tSendTime\t, \tReplyUser\t, \tReplyTime\t, \tReplyContent\t, \tIsReply\t, \tIsAudit\t, \tModifyUser, \tModifyTime\t, \tIsDeleted   FROM ShopNum1_MessageBoard  WHERE IsDeleted = 0";
            if ((isReply == 0) || (isReply == 1))
            {
                str = string.Concat(new object[] { str, " AND IsReply=", isReply, " " });
            }
            if ((isAudit == 0) || (isAudit == 1))
            {
                str = string.Concat(new object[] { str, " AND IsAudit=", isAudit, " " });
            }
            return DatabaseExcetue.ReturnDataTable(str + "ORDER BY SendTime Desc");
        }

        public DataTable Search(string memLoginID, string sendTime1, string sendTime2, int isDeleted)
        {
            string str = string.Empty;
            str = "SELECT \tGuid\t, \tMemLoginID\t, \tMessageType\t, \tTitle\t, \tContent\t, \tSendTime\t, \tReplyUser\t, \tReplyTime\t, \tReplyContent\t, \tIsReply\t, \tIsAudit\t, \tModifyUser, \tModifyTime\t, \tIsDeleted   FROM ShopNum1_MessageBoard  WHERE 0=0 ";
            if ((Operator.FormatToEmpty(memLoginID) != string.Empty) && (Operator.FormatToEmpty(memLoginID) != "匿名"))
            {
                str = str + " AND MemLoginID LIKE '%" + memLoginID + "%'";
            }
            else if (Operator.FormatToEmpty(memLoginID) == "匿名")
            {
                str = str + " AND MemLoginID=''";
            }
            if (Operator.FormatToEmpty(sendTime1) != string.Empty)
            {
                str = str + " AND SendTime>='" + Operator.FilterString(sendTime1) + "' ";
            }
            if (Operator.FormatToEmpty(sendTime2) != string.Empty)
            {
                str = str + " AND SendTime<='" + Operator.FilterString(sendTime2) + "' ";
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                str = string.Concat(new object[] { str, " AND IsDeleted=", isDeleted, " " });
            }
            return DatabaseExcetue.ReturnDataTable(str + " Order by SendTime Desc");
        }

        public DataTable SearchMessage()
        {
            string strProcedureName = "Pro_ShopNum1_SearchMessage";
            return DatabaseExcetue.RunProcedureReturnDataTable(strProcedureName);
        }

        public int Update(ShopNum1_MessageBoard messageBoard)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[] { "UPDATE  ShopNum1_MessageBoard SET   ReplyUser\t='", messageBoard.ReplyUser, "', \tReplyTime\t='", messageBoard.ReplyTime, "',\tReplyContent ='", Operator.FilterString(messageBoard.ReplyContent), "',\tIsReply\t=", messageBoard.IsReply, ",\tModifyUser='", messageBoard.ModifyUser, "' ,\tModifyTime\t='", messageBoard.ModifyTime, "'  WHERE Guid='", messageBoard.Guid, "'" }));
        }

        public int UpdateAudit(string guids, int isAudit)
        {
            object obj2 = string.Concat(new object[] { "UPDATE  ShopNum1_MessageBoard SET  IsAudit\t=", isAudit, " WHERE Guid in (", guids, ")" });
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[] { obj2, "   UPDATE  ShopNum1_MessageBoard SET  IsAudit\t=", isAudit, " WHERE Guid in (", guids, ")" }));
        }

        public int UpdateMemberMessageBoard(ShopNum1_MessageBoard member_MessageBoard)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[] { "UPDATE  ShopNum1_MessageBoard SET   ReplyUser\t='", member_MessageBoard.ReplyUser, "', \tReplyTime\t='", member_MessageBoard.ReplyTime, "',\tReplayContent ='", Operator.FilterString(member_MessageBoard.ReplyContent), "',\tIsReply\t=", member_MessageBoard.IsReply, ",\tModifyUser='", member_MessageBoard.ModifyUser, "' ,\tModifyTime\t='", member_MessageBoard.ModifyTime, "'  WHERE Guid='", member_MessageBoard.Guid, "'" }));
        }
    }
}

