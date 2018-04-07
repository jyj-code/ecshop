namespace ShopNum1.BusinessLogic
{
    using ShopNum1.Common;
    using ShopNum1.DataAccess;
    using ShopNum1.Interface;
    using ShopNum1MultiEntity;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Text;

    public class ShopNum1_Member_Action : IShopNum1_Member_Action
    {
        public int Add(ShopNum1_Member member)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[] { 
                "INSERT INTO ShopNum1_Member( \tGuid\t, \tName\t, \tMemLoginID\t, \tEmail\t, \tMobile\t, \tPwd\t, \tIsForbid\t, \tMemberType\t, \tAddressCode\t, \tAddressValue\t, \tRegeDate\t, \tLoginDate\t, \tMemberRank\t, \tScore\t, \tLastLoginIP\t, \tLoginTime\t, \tAdvancePayment\t, \tLockAdvancePayment\t, \tLockSocre\t, \tCostMoney\t,\tIsMailActivation\t,  IsMobileActivation ,   IsEmailActivation ,  MemberRankGuid ,  PromotionMemLoginID  ) VALUES (  '", member.Guid, "',  '", Operator.FilterString(member.Name), "',  '", member.MemLoginID, "',  '", Operator.FilterString(member.Email), "',  '", Operator.FilterString(member.Mobile), "',  '", Operator.FilterString(member.Pwd), "',  ", member.IsForbid, ", '", member.MemberType, 
                "',  '", Operator.FilterString(member.AddressCode), "',  '", Operator.FilterString(member.AddressValue), "',  '", member.RegeDate, "',  '", member.LoginDate, "',  '", member.MemberRank, "',  '", member.Score, "',  '", member.LastLoginIP, "',  '", member.LoginTime, 
                "',  '", member.AdvancePayment, "',  '", member.LockAdvancePayment, "',  '", member.LockSocre, "',  '", member.CostMoney, "',  '", member.IsMailActivation, "',  '", member.IsMobileActivation, "', '", member.IsEmailActivation, "', '", member.MemberRankGuid, 
                "', '", member.PromotionMemLoginID, "')"
             }));
        }

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

        public int AddByAdmin(ShopNum1_Member Member)
        {
            string[] paraName = new string[0x20];
            string[] paraValue = new string[0x20];
            paraName[0] = "@Name";
            paraValue[0] = Member.Name.ToString();
            paraName[1] = "@Sex";
            paraValue[1] = Member.Sex.ToString();
            paraName[2] = "@Photo";
            paraValue[2] = Member.Photo.ToString();
            paraName[3] = "@QQ";
            paraValue[3] = Member.QQ.ToString();
            paraName[4] = "@AddressValue";
            paraValue[4] = Member.AddressValue.ToString();
            paraName[5] = "@Fax";
            paraValue[5] = Member.Fax.ToString();
            paraName[6] = "@WebSite";
            paraValue[6] = Member.WebSite.ToString();
            paraName[7] = "@Mobile";
            paraValue[7] = Member.Mobile.ToString();
            paraName[8] = "@modifyUser";
            paraValue[8] = Member.ModifyUser.ToString();
            paraName[9] = "@modifyTime";
            paraValue[9] = Member.ModifyTime.ToString();
            paraName[10] = "@MemLoginID";
            paraValue[10] = Member.MemLoginID.ToString();
            paraName[11] = "@AddressCode";
            paraValue[11] = Member.AddressCode.ToString();
            paraName[12] = "@Vocation";
            paraValue[12] = Member.Vocation.ToString();
            paraName[13] = "@Postalcode";
            paraValue[13] = Member.Postalcode.ToString();
            paraName[14] = "@CostMoney";
            paraValue[14] = Member.CostMoney.ToString();
            paraName[15] = "@Birthday";
            paraValue[15] = Member.Birthday.ToString();
            paraName[0x10] = "@MemberRank";
            paraValue[0x10] = Member.MemberRank.ToString();
            paraName[0x11] = "@IsMailActivation";
            paraValue[0x11] = Member.IsMailActivation.ToString();
            paraName[0x12] = "@RegeDate";
            paraValue[0x12] = Member.RegeDate.ToString();
            paraName[0x13] = "@LoginTime";
            paraValue[0x13] = Member.LoginTime.ToString();
            paraName[20] = "@Tel";
            paraValue[20] = Member.Tel.ToString();
            paraName[0x15] = "@LockAdvancePayment";
            paraValue[0x15] = Member.LockAdvancePayment.ToString();
            paraName[0x16] = "@IsForbid";
            paraValue[0x16] = Member.IsForbid.ToString();
            paraName[0x17] = "@email";
            paraValue[0x17] = Member.Email.ToString();
            paraName[0x18] = "@IdentityCard";
            paraValue[0x18] = Member.IdentityCard.ToString();
            paraName[0x19] = "@AdvancePayment";
            paraValue[0x19] = Member.AdvancePayment.ToString();
            paraName[0x1a] = "@LockSocre";
            paraValue[0x1a] = Member.LockSocre.ToString();
            paraName[0x1b] = "@Pwd";
            paraValue[0x1b] = Member.Pwd.ToString();
            paraName[0x1c] = "@PayPwd";
            paraValue[0x1c] = Member.PayPwd.ToString();
            paraName[0x1d] = "@Area";
            paraValue[0x1d] = Member.Area.ToString();
            paraName[30] = "@MemberType";
            paraValue[30] = Member.MemberType.ToString();
            paraName[0x1f] = "@MemberRankGuid";
            paraValue[0x1f] = Member.MemberRankGuid.ToString();
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_AddMemberInfoByAdmin", paraName, paraValue);
        }

        public int AddSignin(ShopNum1_SignIn signIn)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[] { "Insert into ShopNum1_SignIn values('", signIn.guid, "','", signIn.CreateTime, "','", signIn.MemLoginID, "')" }));
        }

        public int CategoryAdPay(string memLoginID, decimal shouldPay, decimal advancePayment, string tradeID)
        {
            List<string> sqlList = new List<string>();
            string item = string.Empty;
            item = string.Concat(new object[] { "UPDATE  ShopNum1_CategoryAdPayMent SET IsPayMent=", 1, ", IsEffective=", 1, ", PayMentTime='", DateTime.Now, "'  WHERE TradeID='", tradeID, "' AND  MemLoginID='", memLoginID, "'" });
            sqlList.Add(item);
            decimal num = advancePayment - shouldPay;
            if (num < 0M)
            {
                return 0;
            }
            item = string.Concat(new object[] { "UPDATE  ShopNum1_Member SET AdvancePayment\t=", num, " WHERE MemLoginID='", memLoginID, "'" });
            sqlList.Add(item);
            this.UpdateCostMoney(memLoginID, shouldPay);
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

        public int CheckBindMobile(string Mobile, string memloginid)
        {
            string strSql = string.Empty;
            strSql = "SELECT Mobile FROM ShopNum1_Member WHERE Mobile ='" + Mobile + "'";
            if (memloginid != "")
            {
                object obj2 = strSql + " AND MemLoginID='" + memloginid + "'";
                strSql = string.Concat(new object[] { obj2, " AND IsMobileActivation='", 0, "'" });
            }
            DataTable table = DatabaseExcetue.ReturnDataTable(strSql);
            if (table == null)
            {
                return 0;
            }
            return table.Rows.Count;
        }

        public int CheckEmail(string email, string memloginid)
        {
            string str = string.Empty + "   SELECT  Email,Mobile  FROM  ShopNum1_Member  WHERE  1=1    ";
            if (memloginid != "")
            {
                object obj2 = str + "    AND  MemLoginID='" + memloginid + "'    ";
                str = string.Concat(new object[] { obj2, "    AND  IsEmailActivation='", 0, "'    " });
            }
            if (DatabaseExcetue.ReturnDataTable(str + "    AND  Email='" + email + "'    ").Rows.Count > 0)
            {
                return 1;
            }
            return 0;
        }

        public DataTable CheckIsForbid(string MemLoginID)
        {
            return DatabaseExcetue.ReturnDataTable("select IsForbid from ShopNum1_Member  where MemLoginID='" + MemLoginID + "' AND IsDeleted =0");
        }

        public int CheckmemEmail(string Email)
        {
            string strProcedureName = "Pro_ShopNum1_CheckMemEmail";
            string[] paraName = new string[1];
            string[] paraValue = new string[1];
            paraName[0] = "@Email";
            paraValue[0] = Email;
            DataTable table = DatabaseExcetue.RunProcedureReturnDataTable(strProcedureName, paraName, paraValue);
            if ((table == null) || (table.Rows.Count <= 0))
            {
                return 0;
            }
            return table.Rows.Count;
        }

        public int CheckMemEmail(string Email)
        {
            string strProcedureName = "Pro_ShopNum1_CheckMemEmail";
            string[] paraName = new string[1];
            string[] paraValue = new string[1];
            paraName[0] = "@Email";
            paraValue[0] = Email;
            DataTable table = DatabaseExcetue.RunProcedureReturnDataTable(strProcedureName, paraName, paraValue);
            if (table == null)
            {
                return 0;
            }
            return table.Rows.Count;
        }

        public DataTable CheckMemEmailByEmail(string Email)
        {
            string strSql = string.Empty;
            strSql = "SELECT Email,MemLoginID FROM ShopNum1_Member WHERE  1=1 ";
            if (Email != "")
            {
                strSql = strSql + "  and Email ='" + Email + "'";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public int CheckmemLoginID(string memLoginID)
        {
            string strProcedureName = "Pro_ShopNum1_CheckmemLoginID";
            string[] paraName = new string[1];
            string[] paraValue = new string[1];
            paraName[0] = "@memLoginID";
            paraValue[0] = memLoginID;
            DataTable table = DatabaseExcetue.RunProcedureReturnDataTable(strProcedureName, paraName, paraValue);
            if (table == null)
            {
                return 0;
            }
            return table.Rows.Count;
        }

        public DataTable CheckMemMobileByMobile(string Mobile)
        {
            string strSql = string.Empty;
            strSql = " SELECT Mobile,MemLoginID FROM ShopNum1_Member  where 1=1";
            if (Mobile != "")
            {
                strSql = strSql + "  and  Mobile ='" + Mobile + "'";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public int CheckMemMobileByMobile1(string Mobile)
        {
            string strSql = string.Empty;
            strSql = "SELECT MemLoginID, Pwd,Mobile FROM ShopNum1_Member  WHERE  1=1 ";
            if (Mobile != "")
            {
                strSql = strSql + "  and Mobile ='" + Mobile + "'";
            }
            if (DatabaseExcetue.ReturnDataTable(strSql).Rows.Count > 0)
            {
                return 1;
            }
            return 0;
        }

        public int CheckMobile(string Mobile)
        {
            DataTable table = DatabaseExcetue.ReturnDataTable("select Mobile from ShopNum1_Member where Mobile ='" + Mobile + "'");
            if ((table == null) || (table.Rows.Count <= 0))
            {
                return 0;
            }
            return table.Rows.Count;
        }

        public int CheckPassword(string memLoginID, string pwd)
        {
            return DatabaseExcetue.ReturnDataTable("SELECT  Guid, MemLoginID,  Pwd  FROM ShopNum1_Member  WHERE MemLoginID = '" + memLoginID + "'AND Pwd='" + Operator.FilterString(pwd) + "' ").Rows.Count;
        }

        public DataTable CheckSafeRank(string MemLoginID, string where)
        {
            return DatabaseExcetue.ReturnDataTable("SELECT MemLoginID,IsMobileActivation,IsEmailActivation FROM ShopNum1_Member WHERE MemLoginID ='" + MemLoginID + "' AND        ( IsMobileActivation =1  " + where + "    IsEmailActivation=1 )");
        }

        public DataTable CheckSignin(string strMemLoginID, string dayTime)
        {
            return DatabaseExcetue.ReturnDataTable("select count(1) as count from ShopNum1_SignIn where convert(varchar,createTime,120)  like '" + dayTime + "%' and MemLoginID ='" + strMemLoginID + "'");
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

        public int Delete(string guids)
        {
            string item = string.Empty;
            List<string> sqlList = new List<string>();
            item = "DELETE ShopNum1_Member WHERE guid IN (" + guids + ")";
            sqlList.Add(item);
            string str2 = string.Empty;
            string[] strArray = guids.Split(new char[] { ',' });
            for (int i = 0; i < strArray.Length; i++)
            {
                if (str2 == string.Empty)
                {
                    str2 = "'" + this.GetMemLoginIDByGuid(strArray[i].ToString()) + "'";
                }
                else
                {
                    str2 = str2 + ",'" + this.GetMemLoginIDByGuid(strArray[i].ToString()) + "'";
                }
            }
            sqlList.Add("DELETE ShopNum1_SecondUser where MemLogID in (" + str2 + ")");
            item = "DELETE ShopNum1_MemberProductCollect  WHERE MemLoginID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_MemberShopCollect  WHERE MemLoginID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_Address WHERE MemLoginID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_Shop_ProductComment  WHERE MemLoginID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_SupplyDemandComment  WHERE CreateMerber IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_Shop_ProductComment  WHERE MemLoginID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_SupplyDemand  WHERE MemberID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_CategoryInfo  WHERE AssociatedMemberID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_Shop_VideoComment  WHERE MemLoginID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_ArticleComment  WHERE MemLoginID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_Shop_NewsComment  WHERE MemLoginID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_Shop_MessageBoard  WHERE MemLoginID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_AdvancePaymentModifyLog WHERE MemLoginID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_AdvancePaymentFreezeLog WHERE MemLoginID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_ScoreModifyLog  WHERE MemLoginID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_ScoreFreezeLog WHERE MemLoginID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_RankScoreModifyLog WHERE MemLoginID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_AdvancePaymentApplyLog WHERE MemLoginID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_MemberAssignGroup WHERE MemLoginID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_ArticleComment WHERE MemLoginID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_MessageInfo WHERE MemLoginID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_UserMessage WHERE SendID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_OrderInfo WHERE MemLoginID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_OrderComplaint WHERE MemLoginID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_MemberReport WHERE MemLoginID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_Shop_ProductBooking WHERE MemLoginID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_Shop_Cart WHERE MemLoginID IN (" + str2 + ")";
            item = "DELETE ShopNum1_ShopProduct_Browse WHERE MemLoginID IN (" + str2 + ")";
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

        public int DeleteMemberActivate(string strMobile)
        {
            return DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_MemberActivate WHERE Phone = '" + Operator.FilterString(strMobile) + "' AND Isinvalid=0 AND type=1");
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

        public int DeleteRealName(string strGuId)
        {
            return DatabaseExcetue.RunNonQuery(string.Format("update ShopNum1_Member set IdentificationIsAudit=Null where guid=" + strGuId, new object[0]));
        }

        public DataTable FindPwdEamil(string MemLoginID, string Email)
        {
            return DatabaseExcetue.ReturnDataTable("select MemLoginID,Pwd  from ShopNum1_Member where MemLoginID ='" + MemLoginID + "' and Email ='" + Email + "'");
        }

        public DataTable GetAdvancePayment(string MemLoginID)
        {
            return DatabaseExcetue.ReturnDataTable((string.Empty + "   SELECT AdvancePayment,Email,Mobile  FROM  ShopNum1_Member  WHERE 1=1        ") + "    AND  MemLoginID='" + MemLoginID + "'    ");
        }

        public DataTable GetAllAdvancePayment(int type)
        {
            string strSql = string.Empty;
            switch (type)
            {
                case -1:
                    strSql = "   SELECT   SUM(AdvancePayment)    FROM ShopNum1_Member    ";
                    break;

                case 0:
                    strSql = "   SELECT   SUM(AdvancePayment)    FROM ShopNum1_Member WHERE MemberType=1   ";
                    break;

                case 1:
                    strSql = "   SELECT   SUM(AdvancePayment)    FROM ShopNum1_Member WHERE MemberType=2      ";
                    break;
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable GetAllShopInfoByGuid(string guids)
        {
            return DatabaseExcetue.ReturnDataTable("select *  from ShopNum1_Member  where  Guid IN(" + guids + ")");
        }

        public decimal GetCostMoney(string memLoginID)
        {
            return Convert.ToDecimal(DatabaseExcetue.ReturnDataTable(" SELECT  CostMoney  FROM ShopNum1_Member  WHERE MemLoginID='" + memLoginID + "'").Rows[0]["CostMoney"].ToString());
        }

        public string GetCurrentMemberRankGuid(string memLoginID)
        {
            return DatabaseExcetue.ReturnDataTable(" SELECT  MemberRankGuid  FROM ShopNum1_Member  WHERE MemLoginID='" + memLoginID + "'").Rows[0]["MemberRankGuid"].ToString();
        }

        public DataTable GetMemberAccount(string MemberLogin)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(" SELECT * from ShopNum1_Member ");
            builder.Append(" WHERE MemLoginID ='" + MemberLogin + "'");
            DataTable table = DatabaseExcetue.ReturnDataTable(builder.ToString());
            table.Columns.Add("buyOrder", typeof(int));
            table.Columns.Add("shopOrder", typeof(int));
            if (table.Rows.Count > 0)
            {
                StringBuilder builder2 = new StringBuilder();
                builder2.Append(string.Concat(new object[] { " SELECT Count(*) buyOrder FROM  ShopNum1_OrderInfo WHERE MemLoginID='", MemberLogin, "' and confirmtime>='", DateTime.Now.AddMonths(-1), "' " }));
                int num = 0;
                num = Convert.ToInt32(DatabaseExcetue.ReturnDataTable(builder2.ToString()).Rows[0][0].ToString());
                StringBuilder builder3 = new StringBuilder();
                builder3.Append(string.Concat(new object[] { " SELECT Count(*) shopOrder FROM  ShopNum1_OrderInfo WHERE ShopID='", MemberLogin, "' and confirmtime>='", DateTime.Now.AddMonths(-1), "' " }));
                int num2 = 0;
                num2 = Convert.ToInt32(DatabaseExcetue.ReturnDataTable(builder3.ToString()).Rows[0][0].ToString());
                table.Rows[0]["buyOrder"] = num;
                table.Rows[0]["shopOrder"] = num2;
                return table;
            }
            return table;
        }

        public int GetMemberCountByCode(string code, string isother)
        {
            string[] paraName = new string[2];
            string[] paraValue = new string[2];
            paraName[0] = "@code";
            paraValue[0] = code;
            paraName[1] = "@isother";
            paraValue[1] = isother;
            return Convert.ToInt32(DatabaseExcetue.ReturnProcedureString("Pro_ShopNum1_MemberGetMemberCountByCode", paraName, paraValue));
        }

        public DataTable GetMemberIdentificationInfo(string member)
        {
            string[] paraName = new string[1];
            string[] paraValue = new string[1];
            paraName[0] = "@memloginid";
            paraValue[0] = member;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetMemberIdentificationInfo", paraName, paraValue);
        }

        public DataTable GetMemberInfoByGuID(string strGuId)
        {
            return DatabaseExcetue.ReturnDataTable("select A.MemLoginID,A.Email,B.ShopID,B.IsAudit,b.tel,b.Phone,a.tel as mobile FROM ShopNum1_ShopInfo AS B,ShopNum1_Member AS A WHERE A.MemLoginID=B.MemLoginID AND B.guid='" + strGuId + "'");
        }

        public DataTable GetMemberInfoByMemLoginID(string memLoignID)
        {
            return DatabaseExcetue.ReturnDataTable("select A.MemLoginID,A.Email,B.ShopID,B.IsAudit FROM ShopNum1_ShopInfo AS B,ShopNum1_Member AS A WHERE A.MemLoginID=B.MemLoginID AND A.MemLoginID='" + memLoignID + "'");
        }

        public DataTable GetMemberPassWord(string loginID, string pwd)
        {
            string[] paraName = new string[2];
            string[] paraValue = new string[2];
            paraName[0] = "@memLoginID";
            paraName[1] = "@pwd";
            paraValue[0] = loginID;
            paraValue[1] = pwd;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetMemberPassWord", paraName, paraValue);
        }

        public decimal GetMemberPriceByGuid(string ProudctGuid, string MemLoginID)
        {
            string strSql = string.Empty;
            string[] paraName = new string[2];
            string[] paraValue = new string[2];
            paraName[0] = "@ProudctGuid";
            paraValue[0] = ProudctGuid;
            paraName[1] = "@MemLoginID";
            paraValue[1] = MemLoginID;
            strSql = "select price from ShopNum1_ProductMemberRankPrice where MemberRankGuid=(select guid from ShopNum1_MemberRank where minScore<(select MemberRank from ShopNum1_Member where MemLoginID=@MemLoginID) and maxScore>= (select MemberRank from ShopNum1_Member where MemLoginID=@MemLoginID)) and ProudctGuid=@ProudctGuid";
            object obj2 = DatabaseExcetue.ReturnObject(strSql, paraName, paraValue);
            decimal num = 0.0M;
            if ((obj2 != null) && (obj2 != DBNull.Value))
            {
                num = (decimal)obj2;
            }
            return num;
        }

        public DataTable GetMemberQuery(string memLoginID)
        {
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetMemberQuery", "@memLoginID", memLoginID);
        }

        public DataTable GetMemInfo(string strMemberId)
        {
            return DatabaseExcetue.ReturnDataTable("  SELECT * FROM  ShopNum1_Member WHERE memLoginID='" + strMemberId + "'");
        }

        public DataTable GetMemInfoByMemberloginId(string memberloginid)
        {
            string[] paraName = new string[1];
            string[] paraValue = new string[1];
            paraName[0] = "@memberloginid";
            paraValue[0] = memberloginid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetMemInfoByMemLoginId", paraName, paraValue);
        }

        public string GetMemLoginIDByGuid(string guid)
        {
            DataTable table = DatabaseExcetue.ReturnDataTable("SELECT MemLoginID FROM ShopNum1_Member WHERE Guid=" + guid);
            if ((table != null) && (table.Rows.Count > 0))
            {
                return table.Rows[0]["MemLoginID"].ToString();
            }
            return "";
        }

        public DataTable GetMemTypeByGuid(string guids)
        {
            return DatabaseExcetue.ReturnDataTable("SELECT MemberType FROM ShopNum1_Member WHERE guid IN (" + guids + ")");
        }

        public string GetMemTypeByMemberId(string strMemberId)
        {
            return DatabaseExcetue.ReturnString("SELECT MemberType FROM ShopNum1_Member WHERE memloginID='" + strMemberId + "'");
        }

        public string GetMemTypeByMemLoginID(string memloginID)
        {
            return DatabaseExcetue.ReturnDataTable("SELECT MemberType FROM ShopNum1_Member WHERE MemLoginID='" + memloginID + "'").Rows[0][0].ToString();
        }

        public DataTable GetPaymentType(int IsShopUse)
        {
            string str = string.Empty;
            str = "   SELECT * FROM  ShopNum1_PaymentType  WHERE 1=1        ";
            if (IsShopUse != -1)
            {
                object obj2 = str;
                str = string.Concat(new object[] { obj2, "   AND  IsShopUse=", IsShopUse, "   " });
            }
            return DatabaseExcetue.ReturnDataTable(str + "    ORDER  BY  OrderID  ASC     ");
        }

        public string GetPayPwd(string memLoginID)
        {
            string strSql = string.Empty;
            strSql = "SELECT Guid, PayPwd\t  FROM ShopNum1_Member   WHERE  MemLoginID =@MemLoginID";
            string[] paraName = new string[1];
            string[] paraValue = new string[1];
            paraName[0] = "@MemLoginID";
            paraValue[0] = memLoginID;
            return DatabaseExcetue.ReturnDataTable(strSql, paraName, paraValue).Rows[0]["PayPwd"].ToString();
        }

        public DataTable LoginByEmail(string email, string pwd)
        {
            string[] paraName = new string[2];
            string[] paraValue = new string[2];
            paraName[0] = "@email";
            paraName[1] = "@pwd";
            paraValue[0] = email;
            paraValue[1] = pwd;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_LoginByEmail", paraName, paraValue);
        }

        public DataTable LoginByMobile(string mobile, string pwd)
        {
            string[] paraName = new string[2];
            string[] paraValue = new string[2];
            paraName[0] = "@mobile";
            paraName[1] = "@pwd";
            paraValue[0] = mobile;
            paraValue[1] = pwd;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_LoginByMobile", paraName, paraValue);
        }

        public DataTable MemberCreditRankSearch(string memberrank)
        {
            string[] paraName = new string[1];
            string[] paraValue = new string[1];
            paraName[0] = "@memberrank";
            paraValue[0] = memberrank;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_MemberCreditRankSearch", paraName, paraValue);
        }

        public DataTable MemberFindPwdPro(string email)
        {
            string[] paraName = new string[1];
            string[] paraValue = new string[1];
            paraName[0] = "@email";
            paraValue[0] = email;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_MemberFindPwd", paraName, paraValue);
        }

        public DataTable MemberFindPwdPro(string email, string question)
        {
            string[] paraName = new string[2];
            string[] paraValue = new string[2];
            paraName[0] = "@email";
            paraValue[0] = email;
            paraName[1] = "@question";
            paraValue[1] = question;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_MemberFindPwd", paraName, paraValue);
        }

        public int OtherOrderIDPay(string memLoginID, decimal shouldPay, decimal advancePayment, string tradeID)
        {
            List<string> sqlList = new List<string>();
            string item = string.Empty;
            item = string.Concat(new object[] { "UPDATE  ShopNum1_Shop_OtherOrderInfo SET OrderStatus=", 1, ", PaymentStatus=", 1, ", PaymentTime='", DateTime.Now, "', ModifyTime='", DateTime.Now, "' WHERE TradeID='", tradeID, "' AND  MemLoginID='", memLoginID, "'" });
            sqlList.Add(item);
            decimal num = advancePayment - shouldPay;
            if (num < 0M)
            {
                return 0;
            }
            item = string.Concat(new object[] { "UPDATE  ShopNum1_Member SET AdvancePayment\t=", num, " WHERE MemLoginID='", memLoginID, "'" });
            sqlList.Add(item);
            this.UpdateCostMoney(memLoginID, shouldPay);
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

        public int PreDepositsPay(string memLoginID, decimal shouldPay, decimal advancePayment, string tradeID, string IsAllPay)
        {
            List<string> sqlList = new List<string>();
            string item = string.Empty;
            item = string.Concat(new object[] { "UPDATE  ShopNum1_OrderInfo SET OderStatus=", 1, ", PaymentStatus=", 1, ", ShipmentStatus=", 0, ",AlreadPayPrice=", shouldPay, ",PayTime='", DateTime.Now, "' WHERE MemLoginID='", memLoginID, "'" });
            if (IsAllPay == "1")
            {
                item = item + " AND TradeID='" + tradeID + "'";
            }
            if (IsAllPay == "0")
            {
                item = item + " AND OrderNumber='" + tradeID + "'";
            }
            sqlList.Add(item);
            decimal num = advancePayment - shouldPay;
            if (num < 0M)
            {
                return 0;
            }
            item = string.Concat(new object[] { "UPDATE  ShopNum1_Member SET AdvancePayment\t=", num, " WHERE MemLoginID='", memLoginID, "'" });
            sqlList.Add(item);
            this.UpdateCostMoney(memLoginID, shouldPay);
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

        public int RefundUpdateAdvancePayment(string memloginid, string shopid, decimal payprice, decimal shopAdvancePayment, string orderguid, string productguid, int status)
        {
            List<string> sqlList = new List<string>();
            string item = string.Empty;
            item = string.Concat(new object[] { "UPDATE  ShopNum1_Member SET AdvancePayment\t=AdvancePayment+", payprice, " WHERE MemLoginID='", memloginid, "'" });
            sqlList.Add(item);
            decimal num = shopAdvancePayment - payprice;
            if (num < 0M)
            {
                return 0;
            }
            item = string.Concat(new object[] { "UPDATE  ShopNum1_Member SET AdvancePayment\t=AdvancePayment-", payprice, " WHERE MemLoginID='", shopid, "'" });
            sqlList.Add(item);
            item = string.Concat(new object[] { "UPDATE ShopNum1_Refund SET RefundStatus=", status, " WHERE OrderID='", orderguid, "' AND ProductGuid='", productguid, "' AND ShopID='", shopid, "'" });
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

        public int RefundUpdateAdvancePaymentMem(string memloginid, decimal payprice)
        {
            new List<string>();
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[] { "UPDATE  ShopNum1_Member SET AdvancePayment\t=AdvancePayment+", payprice, " WHERE MemLoginID='", memloginid, "'" }));
        }

        public DataTable Search(string memLoginID)
        {
            string strSql = string.Empty;
            strSql = "SELECT \tGuid\t, \tMemLoginID\t, \tName\t, \tEmail\t, \tSex\t, \tBirthday\t, \tCreditMoney\t, \tPhoto\t, \tRealName\t, \tArea\t, \tVocation\t, \tAddress\t, \tPostalcode\t, \tMobile\t, \tFax\t, \tQQ\t, \tWebSite\t, \tQuestion\t, \tAnswer\t, \tRegDate\t, \tLastLoginDate\t, \tLastLoginIP\t, \tLoginTime\t, \tAdvancePayment\t, \tIsForbid\t, \tCreateTime  , \tModifyUser , \tModifyTime\t, \tIsDeleted    FROM ShopNum1_Member  WHERE 0=0 ";
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                strSql = strSql + " AND MemLoginID LIKE '%" + memLoginID + "%'";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable Search(string guid, int isDeleted)
        {
            return DatabaseExcetue.ReturnDataTable(string.Concat(new object[] { "SELECT \tGuid\t, \tMemLoginID\t,    MemberType,\tEmail\t, \tPwd\t, \tPayPwd\t, \tSex\t, \tAge\t, \tBirthday\t, \tCreditMoney\t, \tPhoto\t, \tRealName\t, \tArea\t, \tVocation\t, \tAddress\t, \tPostalcode\t, \tOfficeTel\t, \tHomeTel\t, \tMobile\t, \tFax\t, \tQQ\t, \tMsn\t, \tCardType\t, \tCardNum\t, \tWebSite\t, \tQuestion\t, \tAnswer\t, \tRegDate\t, \tLastLoginDate\t, \tLastLoginIP\t, \tLoginTime\t, \tIsForbid\t, \tCreateTime\t, \tModifyUser, \tModifyTime\t, \tIsDeleted IsAudit  FROM ShopNum1_Member   WHERE IsDeleted = ", isDeleted, " AND Guid = ", guid }));
        }

        public DataTable Search(string MemLoginID, string ZfbCode, string RealName, string IdentityCard, string ApplyDate1, string ApplyDate2, string IsAudit)
        {
            string str = string.Empty;
            str = "SELECT \tGuid\t, \tMemLoginID\t,    MemberType,\tRealName\t, \tLastLoginDate\t, \tAdvancePayment\t, \tScore , \tMemberRank , \tAlipayNumber , \tIdentificationTime , \tIdentityCard   FROM ShopNum1_Member   WHERE IsDeleted 0=0 ";
            if (MemLoginID != string.Empty)
            {
                str = str + " AND MemLoginID='" + MemLoginID + "' ";
            }
            if (Operator.FormatToEmpty(ZfbCode) != string.Empty)
            {
                str = str + " AND AlipayNumber='" + ZfbCode + "' ";
            }
            if (Operator.FormatToEmpty(RealName) != string.Empty)
            {
                str = str + " AND RealName='" + RealName + "' ";
            }
            if (Operator.FormatToEmpty(IdentityCard) != string.Empty)
            {
                str = str + " AND IdentityCard='" + IdentityCard + "' ";
            }
            if (Operator.FormatToEmpty(ApplyDate1) != string.Empty)
            {
                str = str + " AND IdentificationTime >='" + ApplyDate1 + "' ";
            }
            if (Operator.FormatToEmpty(ApplyDate2) != string.Empty)
            {
                str = str + " AND IdentificationTime <='" + ApplyDate2 + "' ";
            }
            if (Operator.FormatToEmpty(IsAudit) != string.Empty)
            {
                str = str + " AND IsAudit=" + IsAudit + " ";
            }
            return DatabaseExcetue.ReturnDataTable(str + " ORDER BY IdentificationTime");
        }

        public DataTable Search1(string memLoginID, string name, string email, string regDate1, string regDate2, int sex, int isForbid, string AreaCode, string MemberType, string MemberRank, string CreditMoney, string Mobile)
        {
            string str = string.Empty;
            str = "SELECT \tGuid\t, \tMemberType, \tMemLoginID,    MemberRank,   Score,   Name,\tSex ,\tAddressValue\t, \tAddressCode\t, \tAddress\t, \tAdvancePayment\t, \tEmail\t,    Mobile,\tCreditMoney\t, \tRegeDate\t, \tMemberRank\t, \tMemberRankGuid\t, \tLoginDate\t, \tPromotionMemLoginID\t, \tIsForbid\t   FROM ShopNum1_Member  where 1=1 ";
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                str = str + " AND MemLoginID LIKE '%" + memLoginID + "%'";
            }
            if (Operator.FormatToEmpty(name) != string.Empty)
            {
                str = str + " AND Name LIKE '%" + Operator.FilterString(name) + "%'";
            }
            if (Operator.FormatToEmpty(email) != string.Empty)
            {
                str = str + " AND Email LIKE '%" + Operator.FilterString(email) + "%'";
            }
            if ((isForbid == 0) || (isForbid == 1))
            {
                str = string.Concat(new object[] { str, " AND IsForbid=", isForbid, " " });
            }
            if (((sex == 0) || (sex == 1)) || (sex == 2))
            {
                str = string.Concat(new object[] { str, " AND Sex='", sex, "', " });
            }
            if ((Operator.FormatToEmpty(AreaCode) != string.Empty) && (Operator.FormatToEmpty(AreaCode) != "0"))
            {
                str = str + " AND AddressCode like '" + Operator.FilterString(AreaCode) + "%'";
            }
            if (Operator.FormatToEmpty(regDate1) != string.Empty)
            {
                str = str + " AND RegeDate>='" + Operator.FilterString(regDate1) + "' ";
            }
            if (Operator.FormatToEmpty(regDate2) != string.Empty)
            {
                str = str + " AND RegeDate<='" + Operator.FilterString(regDate2) + "' ";
            }
            if (Operator.FormatToEmpty(MemberType) != "-1")
            {
                str = str + " AND MemberType =" + MemberType + " ";
            }
            if (Operator.FormatToEmpty(MemberRank) != "-1")
            {
                str = str + " AND MemberRank  BETWEEN " + MemberRank.Split(new char[] { '/' })[0] + " AND " + MemberRank.Split(new char[] { '/' })[1] + " ";
            }
            if (Operator.FormatToEmpty(CreditMoney) != string.Empty)
            {
                str = str + " AND CreditMoney = " + CreditMoney + " ";
            }
            if (Operator.FormatToEmpty(Mobile) != string.Empty)
            {
                str = str + " AND Mobile  like  '%" + Mobile + "%' ";
            }
            return DatabaseExcetue.ReturnDataTable(str + " Order by RegeDate Desc");
        }

        public DataTable SearchAdvancePayment(string MemLoginID)
        {
            string str = string.Empty;
            str = "   SELECT   MemLoginID,AdvancePayment,LockAdvancePayment,Name FROM ShopNum1_Member   ";
            if (!string.IsNullOrEmpty(MemLoginID))
            {
                str = str + "    WHERE  MemLoginID='" + MemLoginID + "'  ";
            }
            return DatabaseExcetue.ReturnDataTable(str + "    ORDER BY   AdvancePayment    DESC      ");
        }

        public DataTable SearchAgentByAreacode(string areacode, string showcount)
        {
            string str = "";
            if (!(string.IsNullOrEmpty(showcount) || !(showcount != "-1")))
            {
                str = " top " + showcount;
            }
            StringBuilder builder = new StringBuilder();
            builder.Append("select " + str + " * from  ");
            builder.Append("( ");
            builder.Append("select '' MemLoginID,'' RealName,Code as areacodet,name ,'0' as shopid from shopnum1_region where code='" + Operator.FilterString(areacode) + "' ");
            builder.Append("union all ");
            builder.Append("select * from ");
            builder.Append("( ");
            builder.Append("select MemLoginID,ShopName,AddressCode as areacodet,a.addressvalue AS name,shopid  from dbo.ShopNum1_ShopInfo A ");
            builder.Append("left join dbo.shopnum1_region b on a.AddressCode=b.code ");
            builder.Append("where a.IsAudit=1 and dbo.fun_ShopMap_AddressCode(a.AddressCode) like '" + Operator.FilterString(areacode) + "%' ");
            builder.Append(")aa ");
            builder.Append(")aa ");
            builder.Append("order by areacodet asc ");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable SearchAgentByAreacodeProp(string areacode, string showcount)
        {
            string[] paraName = new string[2];
            string[] paraValue = new string[2];
            paraName[0] = "@topShow";
            if (showcount == null)
            {
                showcount = "500";
            }
            paraValue[0] = showcount;
            paraName[1] = "@AreaCode";
            paraValue[1] = areacode;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_GetAddressCodeShow", paraName, paraValue);
        }

        public DataTable SearchAgentByAreacodeProp(string areacode, string showcount, string SubstationID)
        {
            string[] paraName = new string[3];
            string[] paraValue = new string[3];
            paraName[0] = "@topShow";
            if (showcount == null)
            {
                showcount = "500";
            }
            paraValue[0] = showcount;
            paraName[1] = "@AreaCode";
            paraValue[1] = areacode;
            paraName[2] = "@SubstationID";
            paraValue[2] = SubstationID;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_GetAddressCodeShow1", paraName, paraValue);
        }

        public DataTable SearchAgentCountOfAreacode()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(*)agentcount,Level1code from(");
            builder.Append("select substring(AddressCode,0,4)Level1code from dbo.ShopNum1_ShopInfo where IsAudit=1 ");
            builder.Append(")a where Level1code is not null and Level1code!='-1' and Level1code!=''   group by  Level1code");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable SearchAgentCountOfAreacode(string SubstationID)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select count(*)agentcount,Level1code from(");
            builder.Append("select substring(AddressCode,0,4)Level1code from dbo.ShopNum1_ShopInfo where IsAudit=1   and    SubstationID='" + SubstationID + "'    ");
            builder.Append(")a where Level1code is not null and Level1code!='-1' and Level1code!=''   group by  Level1code");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable SearchByMemLoginID(string memLoginID)
        {
            string strSql = string.Empty;
            strSql = "SELECT Guid\t, MemLoginID\t, MemberType , Photo,AdvancePayment,Email,LoginTime,LockAdvancePayment,Name ,RealName  FROM ShopNum1_Member    WHERE 0=0 ";
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                strSql = strSql + " AND MemLoginID = '" + memLoginID + "'";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SearchInfoByGuid(string guid)
        {
            return DatabaseExcetue.ReturnDataTable("SELECT  MemLoginID, Name, AdvancePayment, LockAdvancePayment  FROM ShopNum1_Member  WHERE Guid =" + guid);
        }

        public DataTable SearchIsAudit(string MemLoginID, string RealName, string IdentityCard, string StartTime, string EndTime, string IdentificationIsAudit)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ");
            builder.Append("Guid,IdentificationIsAudit,IdentityCard,MemLoginID,RealName,IdentificationTime ");
            builder.Append("from ");
            builder.Append("ShopNum1_Member");
            builder.Append(" where 1=1");
            if (Operator.FormatToEmpty(IdentityCard) != string.Empty)
            {
                builder.Append(" AND IdentityCard LIKE '%" + Operator.FilterString(IdentityCard) + "%'");
            }
            if (Operator.FormatToEmpty(RealName) != string.Empty)
            {
                builder.Append(" AND RealName LIKE '%" + Operator.FilterString(RealName) + "%'");
            }
            if (Operator.FormatToEmpty(MemLoginID) != string.Empty)
            {
                builder.Append(" AND MemLoginID = '" + Operator.FilterString(MemLoginID) + "'");
            }
            if (Operator.FormatToEmpty(IdentificationIsAudit) == "-2")
            {
                builder.Append(" AND IdentificationIsAudit in (0,2)");
            }
            else
            {
                builder.Append(" AND IdentificationIsAudit = " + IdentificationIsAudit);
            }
            if (Operator.FormatToEmpty(StartTime) != string.Empty)
            {
                builder.Append(" AND IdentificationTime>='" + StartTime + "' ");
            }
            if (Operator.FormatToEmpty(EndTime) != string.Empty)
            {
                builder.Append(" AND IdentificationTime<='" + EndTime + "' ");
            }
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable SearchMember(int isDeleted)
        {
            string strSql = string.Empty;
            strSql = "SELECT \tGuid\t, \tMemLoginID\t, \tEmail\t ,   Mobile\t ,   Tel     FROM ShopNum1_Member  WHERE 0=0 ";
            if (isDeleted == 0)
            {
                strSql = string.Concat(new object[] { strSql, " AND IsDeleted =", isDeleted, " " });
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SearchMemberAssignGroup(string guid)
        {
            return DatabaseExcetue.ReturnDataTable("SELECT  A.Guid, A.MemLoginID,  B.Name, B.Email, A.MemberGroupGuid  FROM ShopNum1_MemberAssignGroup as A,  ShopNum1_Member as B WHERE  A.MemLoginID=B.MemLoginID and  A.MemberGroupGuid = '" + guid + "'");
        }

        public DataTable SearchMemberByMemberRank(string guid)
        {
            string strSql = string.Empty;
            strSql = "SELECT \tGuid\t, \tName, \tMemLoginID, \tEmail,   Mobile  FROM ShopNum1_Member  where IsDeleted=0 AND IsForbid=0";
            if (Operator.FormatToEmpty(guid) != string.Empty)
            {
                strSql = strSql + " AND MemberRank BETWEEN " + guid.Split(new char[] { '/' })[0] + " AND " + guid.Split(new char[] { '/' })[1] + " ";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SearchMemberCookieInfo(string memLoginID)
        {
            return DatabaseExcetue.ReturnDataTable(" SELECT  MemLoginID,IdentificationIsAudit,IdentityCard,AuditFailedReason,RealName FROM ShopNum1_Member  WHERE MemLoginID='" + Operator.FilterString(memLoginID) + "'");
        }

        public DataTable SearchMemberGetPromentionMembers(string memberloginid, string ispromentiontop)
        {
            string[] paraName = new string[3];
            string[] paraValue = new string[3];
            paraName[0] = "@memberloginid";
            paraValue[0] = memberloginid;
            paraName[1] = "@strwhere";
            paraValue[1] = "1=1";
            paraName[2] = "@ispromentiontop";
            paraValue[2] = ispromentiontop;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_MemberGetPromentionMembers", paraName, paraValue);
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
            if ((Operator.FormatToEmpty(guid) != string.Empty) && (Operator.FormatToEmpty(guid) != "-1"))
            {
                strSql = strSql + " AND Guid = '" + str2 + "'";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SearchMemberInfoByGuid(string Guid)
        {
            return DatabaseExcetue.ReturnDataTable("select MemLoginID,RealName,IdentityCard,IdentificationTime,IdentityCardImg,IdentityCardBackImg,IdentificationIsAudit,auditfailedreason from ShopNum1_Member  where Guid='" + Operator.FilterString(Guid) + "'");
        }

        public DataTable SearchMemberName(string memLoginID, string realName, int Type)
        {
            string strSql = string.Empty;
            strSql = "SELECT  Guid,  MemLoginID, Email,  RealName,tel FROM ShopNum1_Member   WHERE  1=1";
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                strSql = strSql + " AND MemLoginID LIKE '%" + memLoginID + "%'";
            }
            if (Operator.FormatToEmpty(realName) != string.Empty)
            {
                strSql = strSql + " AND RealName LIKE '%" + Operator.FilterString(realName) + "%'";
            }
            if (Type != -1)
            {
                strSql = strSql + " AND MemberType = " + Type;
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SearchMemberName(string memLoginID, string realName, string memberRankGuid)
        {
            string strSql = string.Empty;
            strSql = "SELECT  Guid,  MemLoginID, Name,tel,email FROM ShopNum1_Member   WHERE  1=1";
            if (Operator.FormatToEmpty(memberRankGuid) != "-1")
            {
                strSql = strSql + " AND MemberType = '" + Operator.FilterString(memberRankGuid) + "'";
            }
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                strSql = strSql + " AND MemLoginID LIKE '%" + memLoginID + "%'";
            }
            if (Operator.FormatToEmpty(realName) != string.Empty)
            {
                strSql = strSql + " AND realname LIKE '%" + Operator.FilterString(realName) + "%'";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SearchMemberNameEmail(string memLoginID, string Type)
        {
            string strSql = string.Empty;
            strSql = "SELECT  Guid,  MemLoginID, Email,  RealName FROM ShopNum1_Member   WHERE  1=1";
            if (Operator.FormatToEmpty(memLoginID) != "-1")
            {
                strSql = strSql + " AND MemLoginID =" + memLoginID;
            }
            if (Operator.FormatToEmpty(Type) != "-1")
            {
                strSql = strSql + " AND MemberType = " + Operator.FilterString(Type);
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SearchMemberRank(int isDeleted)
        {
            string strSql = string.Empty;
            strSql = "SELECT \tGuid\t, \tName ,  minScore, maxScore  FROM ShopNum1_MemberRank  WHERE 0=0 ";
            if (isDeleted == 0)
            {
                strSql = string.Concat(new object[] { strSql, " AND IsDeleted =", isDeleted, " " });
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SearchPassMemberInfo(string MemLoginID, string RealName, string IdentityCard, string StartTime, string EndTime)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("select ");
            builder.Append("Guid,IdentificationIsAudit,IdentityCard,MemLoginID,RealName,IdentificationTime ");
            builder.Append("from ");
            builder.Append("ShopNum1_Member");
            builder.Append(" where IdentificationIsAudit is not null");
            if (Operator.FormatToEmpty(IdentityCard) != string.Empty)
            {
                builder.Append(" AND IdentityCard LIKE '%" + Operator.FilterString(IdentityCard) + "%'");
            }
            if (Operator.FormatToEmpty(RealName) != string.Empty)
            {
                builder.Append(" AND RealName LIKE '%" + Operator.FilterString(RealName) + "%'");
            }
            if (Operator.FormatToEmpty(MemLoginID) != string.Empty)
            {
                builder.Append(" AND MemLoginID LIKE '%" + Operator.FilterString(MemLoginID) + "%'");
            }
            if (Operator.FormatToEmpty(StartTime) != string.Empty)
            {
                builder.Append(" AND IdentificationTime>='" + StartTime + "' ");
            }
            if (Operator.FormatToEmpty(EndTime) != string.Empty)
            {
                builder.Append(" AND IdentificationTime<='" + EndTime + "' ");
            }
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
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

        public DataTable SearchWelcomeBaseInfo(string memLoginID)
        {
            return DatabaseExcetue.ReturnDataTable("SELECT * FROM ShopNum1_Member  WHERE MemLoginID='" + memLoginID + "'");
        }

        public DataTable SelectMember_List(CommonPageModel commonModel)
        {
            string[] paraName = new string[8];
            string[] paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = commonModel.PageSize;
            paraName[1] = "@currentpage";
            paraValue[1] = commonModel.Currentpage;
            paraName[2] = "@columns";
            paraValue[2] = " * ";
            paraName[3] = "@tablename";
            paraValue[3] = "ShopNum1_Member";
            paraName[4] = "@condition";
            paraValue[4] = commonModel.Condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "RegDate";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = commonModel.Resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", paraName, paraValue);
        }

        public DataTable SelectRecommendCommision_List(CommonPageModel commonModel)
        {
            string[] paraName = new string[8];
            string[] paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = commonModel.PageSize;
            paraName[1] = "@currentpage";
            paraValue[1] = commonModel.Currentpage;
            paraName[2] = "@columns";
            paraValue[2] = " * ";
            paraName[3] = "@tablename";
            paraValue[3] = commonModel.Tablename;
            paraName[4] = "@condition";
            paraValue[4] = commonModel.Condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "ReceiptTime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = commonModel.Resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", paraName, paraValue);
        }

        public int Transfer(string transferMember, string toTransferMember, string money)
        {
            DataTable table = this.SearchByMemLoginID(transferMember);
            if ((table != null) && (table.Rows.Count > 0))
            {
                if (Convert.ToDecimal(table.Rows[0]["AdvancePayment"].ToString()) >= Convert.ToDecimal(money))
                {
                    List<string> sqlList = new List<string>();
                    string item = "UPDATE ShopNum1_Member SET AdvancePayment=AdvancePayment-" + money + " WHERE MemLoginID='" + transferMember + "'";
                    sqlList.Add(item);
                    item = "UPDATE ShopNum1_Member SET AdvancePayment=AdvancePayment+" + money + " WHERE MemLoginID='" + toTransferMember + "'";
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
                return -1;
            }
            return 0;
        }

        public int UpdataIsMobileActivation(string MemLoginID, string Mobile)
        {
            string[] paraName = new string[2];
            string[] paraValue = new string[2];
            paraName[0] = "@memLoginID";
            paraValue[0] = MemLoginID;
            paraName[1] = "@Mobile";
            paraValue[1] = Mobile;
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_IsMobileActivation", paraName, paraValue);
        }

        public int UpdataMemberIdentificationInfo(ShopNum1_Member shopNum1_Member)
        {
            string[] paraName = new string[6];
            string[] paraValue = new string[6];
            paraName[0] = "@memloginid";
            paraValue[0] = shopNum1_Member.MemLoginID;
            paraName[1] = "@realname";
            paraValue[1] = shopNum1_Member.RealName;
            paraName[2] = "@identitycard";
            paraValue[2] = shopNum1_Member.IdentityCard;
            paraName[3] = "@identitycardimg";
            paraValue[3] = shopNum1_Member.IdentityCardImg;
            paraName[4] = "@identificationisaudit";
            paraValue[4] = shopNum1_Member.IdentificationIsAudit.ToString();
            paraName[5] = "@identificationtime";
            paraValue[5] = shopNum1_Member.IdentificationTime.ToString();
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdataMemberIdentificationInfo", paraName, paraValue);
        }

        public int Update(ShopNum1_Member Member)
        {
            string[] paraName = new string[0x17];
            string[] paraValue = new string[0x17];
            paraName[0] = "@Name";
            paraValue[0] = Member.Name.ToString();
            paraName[1] = "@Sex";
            paraValue[1] = Member.Sex.ToString();
            paraName[2] = "@Photo";
            paraValue[2] = Member.Photo.ToString();
            paraName[3] = "@QQ";
            paraValue[3] = Member.QQ.ToString();
            paraName[4] = "@AddressValue";
            paraValue[4] = Member.AddressValue.ToString();
            paraName[5] = "@Fax";
            paraValue[5] = Member.Fax.ToString();
            paraName[6] = "@WebSite";
            paraValue[6] = Member.WebSite.ToString();
            paraName[7] = "@Mobile";
            paraValue[7] = Member.Mobile.ToString();
            paraName[8] = "@modifyUser";
            paraValue[8] = Member.ModifyUser.ToString();
            paraName[9] = "@modifyTime";
            paraValue[9] = Member.ModifyTime.ToString();
            paraName[10] = "@MemLoginID";
            paraValue[10] = Member.MemLoginID.ToString();
            paraName[11] = "@AddressCode";
            paraValue[11] = Member.AddressCode.ToString();
            paraName[12] = "@Vocation";
            paraValue[12] = Member.Vocation.ToString();
            paraName[13] = "@Postalcode";
            paraValue[13] = Member.Postalcode.ToString();
            paraName[14] = "@LastLoginIP";
            paraValue[14] = Member.LastLoginIP.ToString();
            paraName[15] = "@Birthday";
            paraValue[15] = Member.Birthday.ToString();
            paraName[0x10] = "@Address";
            paraValue[0x10] = Member.Address.ToString();
            paraName[0x11] = "@Area";
            paraValue[0x11] = Member.Area.ToString();
            paraName[0x12] = "@Pwd";
            paraValue[0x12] = Member.Pwd.ToString();
            paraName[0x13] = "@PayPwd";
            paraValue[0x13] = Member.PayPwd.ToString();
            paraName[20] = "@Tel";
            paraValue[20] = Member.Tel.ToString();
            paraName[0x15] = "@RealName";
            paraValue[0x15] = Member.RealName.ToString();
            paraName[0x16] = "@Email";
            paraValue[0x16] = Member.Email.ToString();
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdateMember", paraName, paraValue);
        }

        public int UpdateAdvancePayment(int type, string memberloginid, decimal payprice)
        {
            string[] paraName = new string[3];
            string[] paraValue = new string[3];
            paraName[0] = "@type";
            paraValue[0] = type.ToString();
            paraName[1] = "@memberloginid";
            paraValue[1] = memberloginid;
            paraName[2] = "@payprice";
            paraValue[2] = payprice.ToString();
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_PayAdvancePayment", paraName, paraValue);
        }

        public int UpdateCostMoney(string memLoginID, decimal costMoney)
        {
            string strSql = string.Empty;
            strSql = "UPDATE  ShopNum1_Member SET CostMoney=CostMoney+@CostMoney WHERE MemLoginID=@MemLoginID";
            string[] paraName = new string[2];
            string[] paraValue = new string[2];
            paraName[0] = "@CostMoney";
            paraValue[0] = costMoney.ToString();
            paraName[1] = "@MemLoginID";
            paraValue[1] = memLoginID;
            return DatabaseExcetue.RunNonQuery(strSql, paraName, paraValue);
        }

        public int UpdateemLoginTypeByMemLoginID(string Guid, int IsForbid)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[] { "UPDATE  ShopNum1_Member SET IsForbid=", IsForbid, " where Guid=", Guid }));
        }

        public int UpdateIdentificationIsAudit(string Guid, string IdentificationIsAudit, string strAuditFailedReason)
        {
            return DatabaseExcetue.RunNonQuery("update ShopNum1_Member set IdentificationIsAudit=" + Operator.FilterString(IdentificationIsAudit) + ",AuditFailedReason='" + Operator.FilterString(strAuditFailedReason) + "' where Guid in('" + Guid + "')");
        }

        public int UpdateIdentificationIsAudit(string Guid, string IdentificationIsAudit, string strAuditFailedReason, string memLoginID)
        {
            List<string> sqlList = new List<string>();
            string item = string.Empty;
            item = "update ShopNum1_Member set IdentificationIsAudit=" + IdentificationIsAudit + ",AuditFailedReason='" + strAuditFailedReason + "' where Guid in('" + Guid + "')";
            sqlList.Add(item);
            item = "update ShopNum1_ShopInfo set IdentityIsAudit=" + IdentificationIsAudit + " where MemLoginID in ('" + memLoginID + "')";
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

        public int UpdateLoginTime(string memloginid, string lastloginip)
        {
            string[] paraName = new string[2];
            string[] paraValue = new string[2];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            paraName[1] = "@lastloginip";
            paraValue[1] = lastloginip;
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdateLoginTime", paraName, paraValue);
        }

        public int UpdateMember(string RealName, string Name, string memLoginID)
        {
            return DatabaseExcetue.RunNonQuery("UPDATE  ShopNum1_Member SET RealName\t='" + RealName + "', \tName='" + Name + "'  WHERE MemLoginID='" + memLoginID + "'");
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

        public int UpdateMemberRealNameByMemberLoginID(string RealName, string MemLoginID)
        {
            string strSql = string.Empty;
            string[] paraName = new string[2];
            string[] paraValue = new string[2];
            paraName[0] = "@RealName";
            paraValue[0] = RealName;
            paraName[1] = "@MemLoginID";
            paraValue[1] = MemLoginID;
            strSql = "UPDATE ShopNum1_Member  SET RealName=@RealName where MemLoginID=@MemLoginID";
            return DatabaseExcetue.RunNonQuery(strSql, paraName, paraValue);
        }

        public int UpdateMemberScore(string memloginID, int rankscore, int score)
        {
            string[] paraName = new string[3];
            string[] paraValue = new string[3];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginID;
            paraName[1] = "@rankscore";
            paraValue[1] = rankscore.ToString();
            paraName[2] = "@score";
            paraValue[2] = score.ToString();
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdateMemberScore", paraName, paraValue);
        }

        public int UpdateMemberType(string guids, int memberType)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[] { "UPDATE ShopNum1_Member SET MemberType=", memberType, " WHERE MemLoginID in(select MemLoginID from dbo.ShopNum1_ShopInfo where Guid in(", guids, "))" }));
        }

        public int UpdateMemInfo(string strMemberId, ShopNum1_Member Member)
        {
            string[] paraName = new string[10];
            string[] paraValue = new string[10];
            paraName[0] = "@RealName";
            paraValue[0] = Member.RealName.ToString();
            paraName[1] = "@Sex";
            paraValue[1] = Member.Sex.ToString();
            paraName[2] = "@Email";
            paraValue[2] = Member.Email.ToString();
            paraName[3] = "@QQ";
            paraValue[3] = Member.QQ.ToString();
            paraName[4] = "@MemLoginID";
            paraValue[4] = strMemberId;
            paraName[5] = "@Tel";
            paraValue[5] = Member.Tel.ToString();
            paraName[6] = "@Name";
            paraValue[6] = Member.Name.ToString();
            paraName[7] = "@Mobile";
            paraValue[7] = Member.Mobile.ToString();
            paraName[8] = "@modifyUser";
            paraValue[8] = Member.ModifyUser.ToString();
            paraName[9] = "@modifyTime";
            paraValue[9] = Member.ModifyTime.ToString();
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdateMemInfo", paraName, paraValue);
        }

        public int UpdateMemInfoDetail(string strMemberId, ShopNum1_Member Member)
        {
            string[] paraName = new string[12];
            string[] paraValue = new string[12];
            paraName[0] = "@Postalcode";
            paraValue[0] = Member.Postalcode.ToString();
            paraName[1] = "@Area";
            paraValue[1] = Member.Area.ToString();
            paraName[2] = "@Vocation";
            paraValue[2] = Member.Vocation.ToString();
            paraName[3] = "@Address";
            paraValue[3] = Member.Address.ToString();
            paraName[4] = "@Birthday";
            paraValue[4] = Member.Birthday.ToString();
            paraName[5] = "@MemLoginID";
            paraValue[5] = strMemberId;
            paraName[6] = "@AddressCode";
            paraValue[6] = Member.AddressCode.ToString();
            paraName[7] = "@AddressValue";
            paraValue[7] = Member.AddressValue.ToString();
            paraName[8] = "@Fax";
            paraValue[8] = Member.Fax.ToString();
            paraName[9] = "@WebSite";
            paraValue[9] = Member.WebSite.ToString();
            paraName[10] = "@modifyUser";
            paraValue[10] = Member.ModifyUser.ToString();
            paraName[11] = "@modifyTime";
            paraValue[11] = Member.ModifyTime.ToString();
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdateMemInfoDetil", paraName, paraValue);
        }

        public int UpdatePayPwd(string MemberLogin, string PayPwd)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(" UPDATE ShopNum1_Member ");
            builder.Append(" SET PayPwd = '" + PayPwd + "'");
            builder.Append(" WHERE MemLoginID ='" + MemberLogin + "'");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public int UpdatePayPwd(string memLoginID, string oldPayPwd, string newPayPwd)
        {
            if (DatabaseExcetue.ReturnDataTable("SELECT Guid, PayPwd\t  FROM ShopNum1_Member   WHERE  MemLoginID = '" + memLoginID + "'").Rows[0]["PayPwd"].ToString() == oldPayPwd)
            {
                return DatabaseExcetue.RunNonQuery("UPDATE  ShopNum1_Member SET \tPayPwd\t='" + newPayPwd + "' WHERE MemLoginID='" + memLoginID + "'");
            }
            return -2;
        }

        public int UpdatePhoto(string MemLoginID, string Photo)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(" UPDATE ShopNum1_Member ");
            builder.Append(" SET Photo = '" + Photo + "'");
            builder.Append(" WHERE MemLoginID ='" + MemLoginID + "'");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public int UpdatePwd(string memLoginID, string newPwd)
        {
            return DatabaseExcetue.RunNonQuery("UPDATE  ShopNum1_Member SET \tPwd\t='" + newPwd + "'  WHERE MemLoginID='" + memLoginID + "'");
        }

        public int UpdatePwd(string memLoginID, string oldPwd, string newPwd)
        {
            if (DatabaseExcetue.ReturnDataTable("SELECT Guid, Pwd  FROM ShopNum1_Member   WHERE  MemLoginID = '" + memLoginID + "'").Rows[0]["Pwd"].ToString() == oldPwd)
            {
                return DatabaseExcetue.RunNonQuery("UPDATE  ShopNum1_Member SET \tPwd\t='" + newPwd + "'  WHERE MemLoginID='" + memLoginID + "'");
            }
            return -2;
        }

        public int UpdateScore(ShopNum1_Member member)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[] { "UPDATE  ShopNum1_Member SET Score\t=", member.Score, ", \tMemberRank\t=", member.MemberRank, " WHERE MemLoginID='", member.MemLoginID, "'" }));
        }

        public int UpdateScore(string Score, string MemberRank, string CreditScore, string MemLoginID)
        {
            return DatabaseExcetue.RunNonQuery("UPDATE  ShopNum1_Member SET Score\t=Score+ " + Score + ", \tMemberRank\t=MemberRank+ " + MemberRank + ",\tCreditScore\t=CreditScore+ " + CreditScore + "  WHERE MemLoginID='" + MemLoginID + "'");
        }

        public int UpdtateMemberAdvancePayment(string memloginid, string ChangeAdvancPayment)
        {
            string strSql = string.Empty;
            string[] paraName = new string[2];
            string[] paraValue = new string[2];
            paraName[0] = "@MemLoginID";
            paraValue[0] = memloginid;
            paraName[1] = "@advancepayment";
            paraValue[1] = ChangeAdvancPayment;
            strSql = "UPDATE ShopNum1_Member SET   AdvancePayment+=@advancepayment where MemLoginID=@MemLoginID";
            return DatabaseExcetue.RunNonQuery(strSql, paraName, paraValue);
        }

        public int UploadingCardPic(string MemLoginID, string IdentityCardImg, string IdentityCard, string RealName, string IdentificationTime)
        {
            string strSql = string.Empty;
            string[] paraName = new string[5];
            string[] paraValue = new string[5];
            paraName[0] = "@MemLoginID";
            paraValue[0] = MemLoginID;
            paraName[1] = "@IdentityCardImg";
            paraValue[1] = IdentityCardImg;
            paraName[2] = "@IdentityCard";
            paraValue[2] = IdentityCard;
            paraName[3] = "@RealName";
            paraValue[3] = RealName;
            paraName[4] = "@IdentificationTime";
            paraValue[4] = IdentificationTime.ToString();
            strSql = "update ShopNum1_Member SET IdentityCardImg=@IdentityCardImg,IdentificationIsAudit=2,IdentityCard=@IdentityCard,RealName=@RealName,IdentificationTime=@IdentificationTime where MemLoginID=@MemLoginID";
            return DatabaseExcetue.RunNonQuery(strSql, paraName, paraValue);
        }

        public int UploadingCardPic(string MemLoginID, string IdentityCardImg, string IdentityCardBackImg, string IdentityCard, string RealName, string IdentificationTime)
        {
            string strSql = string.Empty;
            string[] paraName = new string[6];
            string[] paraValue = new string[6];
            paraName[0] = "@MemLoginID";
            paraValue[0] = MemLoginID;
            paraName[1] = "@IdentityCardImg";
            paraValue[1] = IdentityCardImg;
            paraName[2] = "@IdentityCardBackImg";
            paraValue[2] = IdentityCardBackImg;
            paraName[3] = "@IdentityCard";
            paraValue[3] = IdentityCard;
            paraName[4] = "@RealName";
            paraValue[4] = RealName;
            paraName[5] = "@IdentificationTime";
            paraValue[5] = IdentificationTime.ToString();
            strSql = "update ShopNum1_Member SET IdentityCardImg=@IdentityCardImg,IdentityCardBackImg=@IdentityCardBackImg,IdentificationIsAudit=0,IdentityCard=@IdentityCard,RealName=@RealName,IdentificationTime=@IdentificationTime where MemLoginID=@MemLoginID";
            return DatabaseExcetue.RunNonQuery(strSql, paraName, paraValue);
        }
    }
}
