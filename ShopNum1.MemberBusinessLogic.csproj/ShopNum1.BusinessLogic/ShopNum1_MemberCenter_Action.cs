namespace ShopNum1.BusinessLogic
{
    using ShopNum1.Common;
    using ShopNum1.DataAccess;
    using ShopNum1.Interface;
    using ShopNum1MultiEntity;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class ShopNum1_MemberCenter_Action : IShopNum1_MemberCenter_Action
    {
        public int Add(ShopNum1_MemberGroup memberGroup, List<string> memberAssignGroup)
        {
            List<string> sqlList = new List<string>();
            string item = string.Empty;
            item = string.Concat(new object[] { 
                "INSERT INTO ShopNum1_MemberGroup(   Guid,  Name,  Description,  CreateUser,  CreateTime,  ModifyUser,  ModifyTime,  IsDeleted ) VALUES (  '", memberGroup.Guid, "', '", memberGroup.Name, "', '", memberGroup.Description, "', '", memberGroup.CreateUser, "', '", memberGroup.CreateTime, "', '", memberGroup.ModifyUser, "', '", memberGroup.ModifyTime, "', ", memberGroup.IsDeleted, 
                ")"
             });
            sqlList.Add(item);
            if (memberAssignGroup.Count > 0)
            {
                for (int i = 0; i < memberAssignGroup.Count; i++)
                {
                    item = string.Concat(new object[] { "INSERT INTO ShopNum1_MemberAssignGroup(   Guid,  MemLoginID,  MemberGroupGuid,  CreateUser,  CreateTime ) VALUES (  '", Guid.NewGuid(), "', '", memberAssignGroup[i], "', '", memberGroup.Guid, "', '", memberGroup.CreateUser, "', '", memberGroup.CreateTime, "')" });
                    sqlList.Add(item);
                }
            }
            try
            {
                DatabaseExcetue.RunTransactionSql(sqlList);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public bool CheckEmailUserRepaeat(string userId, string email)
        {
            string[] paraName = new string[2];
            string[] paraValue = new string[2];
            paraName[0] = "@email";
            paraValue[0] = email;
            paraName[1] = "@memloginid";
            paraValue[1] = userId;
            return (Convert.ToInt32(DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_MemberCheckRepeat", paraName, paraValue).Rows[0]["TotalCount"]) > 0);
        }

        public DataTable CheckIsAgent(string memberloginID)
        {
            return DatabaseExcetue.ReturnDataTable("SELECT MemLoginID,IsAgentID FROM dbo.ShopNum1_Member WHERE MemLoginID='" + memberloginID + "'");
        }

        public int CheckPassword(string memLoginID, string string_0)
        {
            return DatabaseExcetue.ReturnDataTable("SELECT  Guid, MemLoginID,  Pwd  FROM ShopNum1_Member  WHERE MemLoginID = '" + memLoginID + "'AND Pwd='" + Operator.FilterString(string_0) + "' ").Rows.Count;
        }

        public string CompareMemberRankGuid(string memberRankGuid1, string memberRankGuid2)
        {
            string strSql = string.Empty;
            strSql = "SELECT \tGuid, \tScore    FROM ShopNum1_MemberRank ORDER BY Score ASC ";
            DataTable table = DatabaseExcetue.ReturnDataTable(strSql);
            int num = -1;
            int num2 = -1;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (memberRankGuid1 == table.Rows[i]["Guid"].ToString())
                {
                    num = i;
                }
                if (memberRankGuid2 == table.Rows[i]["Guid"].ToString())
                {
                    num2 = i;
                }
            }
            if (num >= num2)
            {
                return memberRankGuid1;
            }
            return memberRankGuid2;
        }

        public int DeleteMemberGroup(string guids)
        {
            List<string> sqlList = new List<string>();
            string item = string.Empty;
            item = "DELETE FROM ShopNum1_MemberAssignGroup  WHERE  MemberGroupGuid IN (" + guids + ")";
            sqlList.Add(item);
            item = "DELETE FROM ShopNum1_MemberGroup  WHERE  Guid IN (" + guids + ")";
            sqlList.Add(item);
            try
            {
                DatabaseExcetue.RunTransactionSql(sqlList);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public decimal GetCostMoney(string memLoginID)
        {
            return Convert.ToDecimal(DatabaseExcetue.ReturnDataTable(" SELECT  CostMoney  FROM ShopNum1_Member  WHERE MemLoginID='" + memLoginID + "'").Rows[0]["CostMoney"].ToString());
        }

        public string GetCurrentMemberRankGuid(string memLoginID)
        {
            return DatabaseExcetue.ReturnDataTable(" SELECT  MemberRankGuid  FROM ShopNum1_Member  WHERE MemLoginID='" + memLoginID + "'").Rows[0]["MemberRankGuid"].ToString();
        }

        public string GetPayPwd(string memLoginID)
        {
            return DatabaseExcetue.ReturnDataTable("SELECT Guid, PayPwd\t  FROM ShopNum1_Member   WHERE  MemLoginID = '" + memLoginID + "'").Rows[0]["PayPwd"].ToString();
        }

        public DataTable MemberCheckScore(string memloginid, string score)
        {
            return DatabaseExcetue.ReturnDataTable("SELECT 1 FROM dbo.ShopNum1_Member WHERE MemLoginID='" + memloginid + "' AND Score>=" + score);
        }

        public DataTable MemberFavourTicketCode(string memberLoginID, string FavourTicketCode)
        {
            return DatabaseExcetue.ReturnDataTable("SELECT [FavourTicketCode] ,[Guid],[Name],[MinimalCost],[StartDate],[EndDate],[FaceValue],[LimitTimes],[CreateUser],[CreateTime],[ModifyUser],[ModifyTime],[IsDeleted],[MemLoginID] FROM [dbo].[ShopNum1_MemberFavourTicket] WHERE MemLoginID='" + memberLoginID + "' and FavourTicketCode='" + FavourTicketCode + "'");
        }

        public DataTable MemberFindPwdPro(string question, string emial)
        {
            string str = string.Empty;
            str = "select  MemLoginID,Pwd ,Answer from ShopNum1_Member where 1=1";
            return DatabaseExcetue.ReturnDataTable(str + " And Question= '" + question + "' and  Email= '" + emial + "' ");
        }

        public int ReduceMemberFavourTichet(string memberLoginID, string FavourTicketCode)
        {
            return DatabaseExcetue.RunNonQuery(" update dbo.ShopNum1_MemberFavourTicket set LimitTimes=LimitTimes-1 where FavourTicketCode='" + FavourTicketCode + "' and MemLoginID='" + memberLoginID + "'");
        }

        public DataTable Search(string memLoginID)
        {
            string strSql = string.Empty;
            strSql = "SELECT \tA.Guid\t, \tA.MemLoginID\t, \tB.Name\t, \tA.Email\t, \tA.Sex\t, \tA.Age\t, \tA.Birthday\t, \tA.CreditMoney\t, \tA.Photo\t, \tA.RealName\t, \tA.Area\t, \tA.Vocation\t, \tA.Address\t, \tA.Postalcode\t, \tA.OfficeTel\t, \tA.HomeTel\t, \tA.Mobile\t, \tA.Fax\t, \tA.QQ\t, \tA.Msn\t, \tCardType\t, \tCardNum\t, \tA.WebSite\t, \tA.Question\t, \tA.Answer\t, \tA.RegDate\t, \tA.LastLoginDate\t, \tA.LastLoginIP\t, \tA.LoginTime\t, \tA.AdvancePayment\t, \tA.Score AS Score, \tA.RankScore\t, \tA.LockAdvancePayment\t, \tA.LockSocre\t, \tA.CostMoney\t, \tA.MemberRankGuid\t, \tA.TradeCount\t, \tA.IsForbid\t, \tA.CreateUser  , \tA.CreateTime  , \tA.ModifyUser , \tA.ModifyTime\t, \tA.IsDeleted    FROM ShopNum1_Member AS A LEFT JOIN  ShopNum1_MemberRank AS B ON  A.MemberRankGuid = B.Guid  WHERE 0=0 ";
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                strSql = strSql + " AND A.MemLoginID LIKE '%" + memLoginID + "%'";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable Search(string guid, int isDeleted)
        {
            return DatabaseExcetue.ReturnDataTable(string.Concat(new object[] { "SELECT \tGuid\t, \tMemLoginID\t, \tEmail\t, \tPwd\t, \tPayPwd\t, \tSex\t, \tAge\t, \tBirthday\t, \tCreditMoney\t, \tPhoto\t, \tRealName\t, \tArea\t, \tVocation\t, \tAddress\t, \tPostalcode\t, \tOfficeTel\t, \tHomeTel\t, \tMobile\t, \tFax\t, \tQQ\t, \tMsn\t, \tCardType\t, \tCardNum\t, \tWebSite\t, \tQuestion\t, \tAnswer\t, \tRegDate\t, \tLastLoginDate\t, \tLastLoginIP\t, \tLoginTime\t, \tAdvancePayment\t, \tScore\t, \tRankScore\t, \tLockAdvancePayment\t, \tLockSocre\t, \tCostMoney\t, \tMemberRankGuid\t, \tTradeCount\t, \tIsForbid\t, \tCreateUser, \tCreateTime\t, \tModifyUser, \tModifyTime\t,     AgentMemberRankGuid,\tIsDeleted   FROM ShopNum1_Member   WHERE IsDeleted = ", isDeleted, " AND Guid = ", guid }));
        }

        public DataTable Search(string memLoginID, string realName, string email, string regDate1, string regDate2, decimal creditMoney1, decimal creditMoney2, int score1, int score2, int int_0, int isForbid, string memberRankGuid, int isDeleted, string agentID)
        {
            string str = string.Empty;
            str = "SELECT\tA.Guid\t, \tA.MemLoginID\t, \tB.Name\t, \tA.Email\t, \tA.Sex\t, \tA.Age\t, \tA.Birthday\t, \tA.CreditMoney\t, \tA.Photo\t, \tA.RealName\t, \tA.Area\t, \tA.Vocation\t, \tA.Address\t, \tA.Postalcode\t, \tA.OfficeTel\t, \tA.HomeTel\t, \tA.Mobile\t, \tA.Fax\t, \tA.QQ\t, \tA.Msn\t, \tCardType\t, \tCardNum\t, \tA.WebSite\t, \tA.Question\t, \tA.Answer\t, \tA.RegDate\t, \tA.LastLoginDate\t, \tA.LastLoginIP\t, \tA.LoginTime\t, \tA.AdvancePayment\t, \tA.Score AS Score, \tA.RankScore\t, \tA.LockAdvancePayment\t, \tA.LockSocre\t, \tA.CostMoney\t, \tA.MemberRankGuid\t, \tA.TradeCount\t, \tA.IsForbid\t, \tA.CreateUser  , \tA.CreateTime  , \tA.ModifyUser , \tA.ModifyTime\t, \tA.AgentID\t, \tA.IsDeleted    FROM ShopNum1_Member AS A LEFT JOIN  ShopNum1_MemberRank AS B ON  A.MemberRankGuid = B.Guid  WHERE A.IsAgentID=0 ";
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                str = str + " AND A.MemLoginID LIKE '%" + memLoginID + "%'";
            }
            if (Operator.FormatToEmpty(realName) != string.Empty)
            {
                str = str + " AND A.RealName LIKE '%" + Operator.FilterString(realName) + "%'";
            }
            if (Operator.FormatToEmpty(email) != string.Empty)
            {
                str = str + " AND A.Email LIKE '%" + Operator.FilterString(email) + "%'";
            }
            if (memberRankGuid != "-1")
            {
                str = string.Concat(new object[] { str, " AND A.MemberRankGuid='", new Guid(memberRankGuid), "'" });
            }
            if ((isForbid == 0) || (isForbid == 1))
            {
                str = string.Concat(new object[] { str, " AND A.IsForbid=", isForbid, " " });
            }
            if (((int_0 == 0) || (int_0 == 1)) || (int_0 == 2))
            {
                str = string.Concat(new object[] { str, " AND A.Sex=", int_0, " " });
            }
            if (creditMoney1 != 0M)
            {
                str = string.Concat(new object[] { str, " AND A.CreditMoney>=", creditMoney1, " " });
            }
            if (creditMoney2 != 0M)
            {
                str = string.Concat(new object[] { str, " AND A.CreditMoney<=", creditMoney2, " " });
            }
            if (score1 != 0)
            {
                str = string.Concat(new object[] { str, " AND A.Score>=", score1, " " });
            }
            if (score2 != 0)
            {
                str = string.Concat(new object[] { str, " AND A.Score<=", score2, " " });
            }
            if (Operator.FormatToEmpty(regDate1) != string.Empty)
            {
                str = str + " AND A.RegDate>='" + Operator.FilterString(regDate1) + "' ";
            }
            if (Operator.FormatToEmpty(regDate2) != string.Empty)
            {
                str = str + " AND A.RegDate<='" + Operator.FilterString(regDate2) + "' ";
            }
            if (Operator.FormatToEmpty(agentID) != string.Empty)
            {
                str = str + " AND A.agentID LIKE '%" + Operator.FilterString(agentID) + "%' ";
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                str = string.Concat(new object[] { str, " AND A.IsDeleted=", isDeleted, " " });
            }
            return DatabaseExcetue.ReturnDataTable(str + "Order by A.CreateTime Desc");
        }

        public DataTable SearchBookMember(int state, int isDeleted)
        {
            string strSql = string.Empty;
            strSql = "SELECT \tGuid\t, \tEmailAddress  FROM ShopNum1_EmailBook  WHERE 0=0 ";
            if (isDeleted == 0)
            {
                strSql = string.Concat(new object[] { strSql, " AND IsDeleted =", isDeleted, " " });
            }
            if (state == 1)
            {
                strSql = string.Concat(new object[] { strSql, " AND state =", state, " " });
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SearchByMemLoginID(string memLoginID)
        {
            string strSql = string.Empty;
            strSql = "SELECT Guid\t, MemLoginID\t, AdvancePayment,Email,LoginTime,RealName,Mobile, RegDate,Score  FROM ShopNum1_Member    WHERE 0=0 ";
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                strSql = strSql + " AND MemLoginID = '" + memLoginID + "'";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SearchCurentScoreOrPrice(string memLoginID)
        {
            return DatabaseExcetue.ReturnDataTable("SELECT AdvancePayment,Score,RankScore,LockAdvancePayment,LockSocre FROM ShopNum1_Member  WHERE MemLoginID='" + memLoginID + "'");
        }

        public DataTable SearchInfoByGuid(string guid)
        {
            return DatabaseExcetue.ReturnDataTable("SELECT  MemLoginID, RealName, Score, AdvancePayment, RankScore, LockAdvancePayment, LockSocre, CostMoney,  TradeCount FROM ShopNum1_Member WHERE Guid =" + guid);
        }

        public DataTable SearchMember(int isDeleted)
        {
            string strSql = string.Empty;
            strSql = "SELECT \tGuid\t, \tMemLoginID\t, \tMobile\t, \tEmail\t  FROM ShopNum1_Member  WHERE 0=0 ";
            if (isDeleted == 0)
            {
                strSql = string.Concat(new object[] { strSql, " AND IsDeleted =", isDeleted, " " });
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SearchMemberAssignGroup(string guid)
        {
            return DatabaseExcetue.ReturnDataTable("SELECT  A.Guid, A.MemLoginID,  B.RealName, B.Email, B.Mobile, A.MemberGroupGuid  FROM ShopNum1_MemberAssignGroup A,  ShopNum1_Member B WHERE  A.MemLoginID=B.MemLoginID and  A.MemberGroupGuid = '" + guid + "'");
        }

        public DataTable SearchMemberByMemberRank(string guid)
        {
            string str = string.Empty;
            str = "SELECT \tA.Guid\t, \tA.Name, \tB.MemLoginID, \tB.Mobile, \tB.Email   FROM (SELECT Guid,Name FROM ShopNum1_MemberRank  WHERE 1=1 ";
            if (Operator.FormatToEmpty(guid) != string.Empty)
            {
                str = str + " AND Guid = '" + Operator.FilterString(guid) + "'";
            }
            return DatabaseExcetue.ReturnDataTable(str + ") A,ShopNum1_Member B  WHERE A.Guid=B.MemberRankGuid ");
        }

        public DataTable SearchMemberCookieInfo(string memLoginID)
        {
            return DatabaseExcetue.ReturnDataTable(" SELECT  Guid, MemLoginID, IsForbid, IsAgentID,AgentValidity, MemberRankGuid  FROM ShopNum1_Member  WHERE MemLoginID='" + memLoginID + "'");
        }

        public DataTable SearchMemberFavourTicket(string memLoginID, int isDeleted)
        {
            string str = string.Empty;
            str = "SELECT  Name , MinimalCost , StartDate , EndDate , FaceValue , LimitTimes , MemLoginID , FavourTicketCode  from ShopNum1_MemberFavourTicket where 1=1";
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                str = str + " And MemLoginID= '" + memLoginID + "'";
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                str = str + " And IsDeleted= " + isDeleted;
            }
            return DatabaseExcetue.ReturnDataTable(str + " Order by CreateTime  Desc");
        }

        public DataTable SearchMemberGroup(int isDeleted)
        {
            string str = string.Empty;
            str = "SELECT \tGuid\t, \tName,  Description   FROM ShopNum1_MemberGroup  WHERE 0=0 ";
            if (isDeleted == 0)
            {
                str = string.Concat(new object[] { str, " AND IsDeleted =", isDeleted, " " });
            }
            return DatabaseExcetue.ReturnDataTable(str + "Order By CreateTime Desc");
        }

        public DataTable SearchMemberGroup(string guid)
        {
            string strSql = string.Empty;
            string str2 = guid.Replace("'", "");
            strSql = "SELECT  Guid, Name,  Description\t FROM ShopNum1_MemberGroup  where 1=1";
            if ((Operator.FormatToEmpty(guid) != string.Empty) && (Operator.FormatToEmpty(guid) != "0"))
            {
                strSql = strSql + " AND Guid = '" + str2 + "'";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SearchMemberName(string memLoginID, string realName, string memberRankGuid)
        {
            string strSql = string.Empty;
            strSql = "SELECT  Guid,  MemLoginID, RealName FROM ShopNum1_Member   WHERE  1=1";
            if (Operator.FormatToEmpty(memberRankGuid) != "-1")
            {
                strSql = strSql + " AND MemberRankGuid = '" + Operator.FilterString(memberRankGuid) + "'";
            }
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                strSql = strSql + " AND MemLoginID LIKE '%" + memLoginID + "%'";
            }
            if (Operator.FormatToEmpty(realName) != string.Empty)
            {
                strSql = strSql + " AND RealName LIKE '%" + Operator.FilterString(realName) + "%'";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SearchMemberRank(int isDeleted)
        {
            string strSql = string.Empty;
            strSql = "SELECT \tGuid\t, \tName   FROM ShopNum1_MemberRank  WHERE  IsAgent=0 AND AgentID IS NULL ";
            if (isDeleted == 0)
            {
                strSql = string.Concat(new object[] { strSql, " AND IsDeleted =", isDeleted, " " });
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SearchPasswordByInfo(string question, string answer, string email, int isDeleted)
        {
            string strSql = string.Empty;
            strSql = "select  MemLoginID,Pwd  from ShopNum1_Member where 1=1";
            if ((((Operator.FormatToEmpty(question) != string.Empty) && (Operator.FormatToEmpty(answer) != string.Empty)) && (Operator.FormatToEmpty(email) != string.Empty)) && ((isDeleted == 0) || (isDeleted == 1)))
            {
                strSql = string.Concat(new object[] { strSql, " And Question= '", question, "' and Answer= '", answer, "' and  Email= '", email, "' and IsDeleted= ", isDeleted, " " });
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SearchReport(string guids)
        {
            return DatabaseExcetue.ReturnDataTable("SELECT \tA.Guid\t, \tA.MemLoginID\t, \tB.Name\t, \tA.Email\t, \tA.Sex\t, \tA.Age\t, \tA.Birthday\t, \tA.CreditMoney\t, \tA.Photo\t, \tA.RealName\t, \tA.Area\t, \tA.Vocation\t, \tA.Address\t, \tA.Postalcode\t, \tA.OfficeTel\t, \tA.HomeTel\t, \tA.Mobile\t, \tA.Fax\t, \tA.QQ\t, \tA.Msn\t, \tCardType\t, \tCardNum\t, \tA.WebSite\t, \tA.Question\t, \tA.Answer\t, \tA.RegDate\t, \tA.LastLoginDate\t, \tA.LastLoginIP\t, \tA.LoginTime\t, \tA.AdvancePayment\t, \tA.Score AS Score, \tA.RankScore\t, \tA.LockAdvancePayment\t, \tA.LockSocre\t, \tA.CostMoney\t, \tA.MemberRankGuid\t, \tA.TradeCount\t, \tA.IsForbid\t, \tA.CreateUser  , \tA.CreateTime  , \tA.ModifyUser , \tA.ModifyTime\t, \tA.AgentID\t, \tA.IsDeleted    FROM ShopNum1_Member AS A LEFT JOIN  ShopNum1_MemberRank AS B ON  A.MemberRankGuid = B.Guid  WHERE A.Guid in (" + guids + ") Order by A.CreateTime Desc");
        }

        public DataTable SearchWelcomeBaseInfo(string memLoginID)
        {
            return DatabaseExcetue.ReturnDataTable("SELECT MemLoginID,LastLoginDate,LastLoginIP,LoginTime,AdvancePayment,MemberRankGuid,Score FROM ShopNum1_Member  WHERE MemLoginID='" + memLoginID + "'");
        }

        public int UpdateMemberAssignGroup(ShopNum1_MemberGroup memberGroup, List<string> memberAssignGroup)
        {
            List<string> sqlList = new List<string>();
            string item = string.Empty;
            item = string.Concat(new object[] { "UPDATE  ShopNum1_MemberGroup SET  Name ='", memberGroup.Name, "', Description ='", memberGroup.Description, "', CreateUser ='", memberGroup.ModifyUser, "', CreateTime ='", memberGroup.ModifyTime, "'WHERE Guid='", memberGroup.Guid, "'" });
            sqlList.Add(item);
            item = "Delete from ShopNum1_MemberAssignGroup where MemberGroupGuid='" + memberGroup.Guid + "'";
            sqlList.Add(item);
            if (memberAssignGroup.Count > 0)
            {
                for (int i = 0; i < memberAssignGroup.Count; i++)
                {
                    item = string.Concat(new object[] { "INSERT INTO ShopNum1_MemberAssignGroup(   Guid,  MemLoginID,  MemberGroupGuid,  CreateUser,  CreateTime ) VALUES (  '", Guid.NewGuid(), "', '", memberAssignGroup[i], "', '", memberGroup.Guid, "', '", memberGroup.ModifyUser, "', '", memberGroup.ModifyTime, "')" });
                    sqlList.Add(item);
                }
            }
            try
            {
                DatabaseExcetue.RunTransactionSql(sqlList);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int UpdatePayPwd(string memLoginID, string oldPayPwd, string newPayPwd)
        {
            if (DatabaseExcetue.ReturnDataTable("SELECT Guid, PayPwd\t  FROM ShopNum1_Member   WHERE  MemLoginID = '" + memLoginID + "'").Rows[0]["PayPwd"].ToString() == oldPayPwd)
            {
                return DatabaseExcetue.RunNonQuery("UPDATE  ShopNum1_Member SET \tPayPwd\t='" + newPayPwd + "' WHERE MemLoginID='" + memLoginID + "'");
            }
            return -2;
        }

        public int UpdatePwd(string memLoginID, string oldPwd, string newPwd)
        {
            if (DatabaseExcetue.ReturnDataTable("SELECT Guid, Pwd  FROM ShopNum1_Member   WHERE  MemLoginID = '" + memLoginID + "'").Rows[0]["Pwd"].ToString() == oldPwd)
            {
                return DatabaseExcetue.RunNonQuery("UPDATE  ShopNum1_Member SET \tPwd\t='" + newPwd + "'  WHERE MemLoginID='" + memLoginID + "'");
            }
            return -2;
        }
    }
}

