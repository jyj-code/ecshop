namespace ShopNum1.BusinessLogic
{
    using ShopNum1.Common;
    using ShopNum1.DataAccess;
    using ShopNum1.Interface;
    using ShopNum1MultiEntity;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class ShopNum1_AdvancePaymentApplyLog_Action : IShopNum1_AdvancePaymentApplyLog_Action
    {
        public int ApplyOperateMoney(ShopNum1_AdvancePaymentApplyLog advancePaymentApplyLog)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[] { 
                "INSERT INTO ShopNum1_AdvancePaymentApplyLog( Guid, OperateType\t,CurrentAdvancePayment\t,OperateMoney,OperateStatus,Date,Memo,MemLoginID,PaymentGuid,PaymentName,Bank,TrueName,Account,IsDeleted,  OrderNumber,ID  ) VALUES (  '", advancePaymentApplyLog.Guid, "',  ", advancePaymentApplyLog.OperateType, ",  ", advancePaymentApplyLog.CurrentAdvancePayment, ",  ", advancePaymentApplyLog.OperateMoney, ",  ", advancePaymentApplyLog.OperateStatus, ",  '", advancePaymentApplyLog.Date, "',  '", Operator.FilterString(advancePaymentApplyLog.Memo), "',  '", advancePaymentApplyLog.MemLoginID, 
                "',  '", advancePaymentApplyLog.PaymentGuid, "',  '", Operator.FilterString(advancePaymentApplyLog.PaymentName), "',  '", Operator.FilterString(advancePaymentApplyLog.Bank), "',  '", Operator.FilterString(advancePaymentApplyLog.TrueName), "',  '", advancePaymentApplyLog.Account, "',  '", advancePaymentApplyLog.IsDeleted, "', '", Operator.FilterString(advancePaymentApplyLog.OrderNumber), "',  ", advancePaymentApplyLog.ID, 
                ")"
             }));
        }

        public int ChangeApplyLogStatus(int operateStatus, string strOrderNumber)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[] { "UPDATE  ShopNum1_AdvancePaymentApplyLog SET  OperateStatus =", operateStatus, " WHERE ordernumber ='", Operator.FilterString(strOrderNumber), "'" }));
        }

        public int ChangeLogStatus(int operateStatus, string Guid)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[] { "UPDATE  ShopNum1_AdvancePaymentApplyLog SET  OperateStatus =", operateStatus, " WHERE  Guid ='", Operator.FilterString(Guid), "'" }));
        }

        public int ChangeLogStatusNew(int operateStatus, string Guid, string UserMemo)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[] { "UPDATE  ShopNum1_AdvancePaymentApplyLog SET   UserMemo ='", UserMemo, "', OperateStatus =", operateStatus, " WHERE  Guid ='", Operator.FilterString(Guid), "'" }));
        }

        public int ChangeOperateStatus(string userMemo, int operateStatus, string guid)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[] { "UPDATE  ShopNum1_AdvancePaymentApplyLog SET  UserMemo ='", Operator.FilterString(userMemo), "', OperateStatus =", operateStatus, " WHERE Guid ='", Operator.FilterString(guid), "'" }));
        }

        public int Delete(string guids)
        {
            return DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_AdvancePaymentApplyLog  WHERE  Guid IN(" + guids + ")");
        }

        public DataTable Search(string guid)
        {
            string strSql = string.Empty;
            strSql = "SELECT Guid,OperateType\t,CurrentAdvancePayment\t,OperateMoney,Date,OperateStatus,Memo,UserMemo,Bank,Account,TrueName,MemLoginID\t,PaymentGuid,PaymentName,IsDeleted   FROM ShopNum1_AdvancePaymentApplyLog ";
            if (guid != string.Empty)
            {
                strSql = strSql + " WHERE Guid='" + Operator.FilterString(guid) + "'";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable Search(string memLoginID, string date1, string date2, int operateType, int operateStatus, int isDeleted)
        {
            string str = string.Empty;
            str = "SELECT Guid,OrderNumber\t,OperateType\t,CurrentAdvancePayment\t,OperateMoney,Date,OperateStatus,Memo,UserMemo,MemLoginID\t,PaymentGuid,PaymentName,IsDeleted   FROM ShopNum1_AdvancePaymentApplyLog   WHERE 0=0 ";
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                str = str + " AND MemLoginID ='" + memLoginID + "'";
            }
            if (operateType != -1)
            {
                str = str + " AND OperateType=" + operateType;
            }
            if (operateStatus != -1)
            {
                str = str + " AND OperateStatus=" + operateStatus;
            }
            if (Operator.FormatToEmpty(date1) != string.Empty)
            {
                str = str + " AND Date>='" + Operator.FilterString(date1) + "' ";
            }
            if (Operator.FormatToEmpty(date2) != string.Empty)
            {
                str = str + " AND Date<='" + Operator.FilterString(date2) + "' ";
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                str = string.Concat(new object[] { str, "AND IsDeleted=", isDeleted, " " });
            }
            return DatabaseExcetue.ReturnDataTable(str + "ORDER BY  Date Desc");
        }

        public DataTable Search(string OrderNumber, string memLoginID, string date1, string date2, int operateType, int operateStatus, int isDeleted)
        {
            string str = string.Empty;
            str = "SELECT Guid,OrderNumber\t,OperateType\t,CurrentAdvancePayment\t,OperateMoney,Date,OperateStatus,Memo,UserMemo,MemLoginID\t,PaymentGuid,PaymentName,IsDeleted   FROM ShopNum1_AdvancePaymentApplyLog   WHERE 0=0 ";
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                str = str + " AND MemLoginID ='" + memLoginID + "'";
            }
            if (!string.IsNullOrEmpty(OrderNumber))
            {
                str = str + " AND     OrderNumber='" + OrderNumber + "'";
            }
            if (operateType != -1)
            {
                str = str + " AND OperateType=" + operateType;
            }
            if (operateStatus != -1)
            {
                str = str + " AND OperateStatus=" + operateStatus;
            }
            if (Operator.FormatToEmpty(date1) != string.Empty)
            {
                str = str + " AND Date>='" + Operator.FilterString(date1) + "' ";
            }
            if (Operator.FormatToEmpty(date2) != string.Empty)
            {
                str = str + " AND Date<='" + Operator.FilterString(date2) + "' ";
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                str = string.Concat(new object[] { str, "AND IsDeleted=", isDeleted, " " });
            }
            return DatabaseExcetue.ReturnDataTable(str + "ORDER BY  Date Desc");
        }

        public DataTable SelectAdvPayment_List(CommonPageModel commonModel)
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
            paraValue[5] = "Date";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = commonModel.Resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", paraName, paraValue);
        }

        public DataTable SelectOperateMoney(string memberid, string operatetype, string datetime1, string datetime2, string ordernumber, string hidbank, string bank)
        {
            string strSql = string.Empty;
            strSql = " SELECT * FROM ShopNum1_AdvancePaymentApplyLog ";
            strSql = strSql + " WHERE 1=1 and OperateType ='" + operatetype + "'";
            if (Operator.FormatToEmpty(memberid) != string.Empty)
            {
                strSql = strSql + " AND MemLoginID='" + Operator.FilterString(memberid) + "' ";
            }
            if (Operator.FormatToEmpty(datetime1) != string.Empty)
            {
                strSql = strSql + " AND Date>='" + Operator.FilterString(datetime1) + "' ";
            }
            if (Operator.FormatToEmpty(datetime2) != string.Empty)
            {
                strSql = strSql + " AND Date<(SELECT CONVERT(varchar(11),dateadd(day,1,' " + Operator.FilterString(datetime2) + "'),120)  as  a)  ";
            }
            if (Operator.FormatToEmpty(ordernumber) != string.Empty)
            {
                strSql = strSql + " AND OrderNumber='" + ordernumber + "'";
            }
            if (Operator.FormatToEmpty(operatetype) != string.Empty)
            {
                if (operatetype == "0")
                {
                    if ((Operator.FormatToEmpty(hidbank) != string.Empty) && (hidbank != "-1"))
                    {
                        if (hidbank == "1")
                        {
                            if (Operator.FormatToEmpty(bank) != string.Empty)
                            {
                                strSql = strSql + " AND Bank='" + bank + "'";
                            }
                        }
                        else
                        {
                            strSql = strSql + " AND Bank='" + hidbank + "'";
                        }
                    }
                }
                else if ((Operator.FormatToEmpty(hidbank) != string.Empty) && (Operator.FormatToEmpty(hidbank) != "-1"))
                {
                    strSql = strSql + " AND PaymentGuid='" + hidbank + "'";
                }
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public int Update(string guid, string memLoginID, string operateType, decimal operateMoney, int operateStatus, string userMemo, ShopNum1_AdvancePaymentModifyLog advancePaymentModifyLog)
        {
            string item = string.Empty;
            List<string> sqlList = new List<string>();
            item = string.Concat(new object[] { "UPDATE  ShopNum1_AdvancePaymentApplyLog SET  UserMemo ='", Operator.FilterString(userMemo), "', OperateStatus =", operateStatus, " WHERE Guid ='", Operator.FilterString(guid), "'" });
            sqlList.Add(item);
            if (operateStatus == 1)
            {
                if (operateType == "1")
                {
                    item = string.Concat(new object[] { "UPDATE ShopNum1_Member SET  AdvancePayment =AdvancePayment +", operateMoney, " Where  MemLoginID='", memLoginID, "'" });
                    sqlList.Add(item);
                }
                else if (operateType == "0")
                {
                    item = string.Concat(new object[] { "UPDATE ShopNum1_Member SET  AdvancePayment = AdvancePayment-", operateMoney, " Where  MemLoginID='", memLoginID, "'" });
                    sqlList.Add(item);
                }
                item = string.Concat(new object[] { 
                    "INSERT INTO ShopNum1_AdvancePaymentModifyLog( \tGuid\t, \tOperateType\t, \tCurrentAdvancePayment\t, \tOperateMoney\t, \tLastOperateMoney\t, \tDate\t, \tMemo\t, \tMemLoginID\t, \tCreateUser\t, \tCreateTime\t, \tIsDeleted  ) VALUES (  '", advancePaymentModifyLog.Guid, "',  ", advancePaymentModifyLog.OperateType, ",  ", advancePaymentModifyLog.CurrentAdvancePayment, ",  ", advancePaymentModifyLog.OperateMoney, ",  ", advancePaymentModifyLog.LastOperateMoney, ",  '", advancePaymentModifyLog.Date, "',  '", Operator.FilterString(advancePaymentModifyLog.Memo), "',  '", advancePaymentModifyLog.MemLoginID, 
                    "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '", advancePaymentModifyLog.CreateTime, "',  ", advancePaymentModifyLog.IsDeleted, ")"
                 });
                sqlList.Add(item);
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

        public int Update_Update(string guid, string memLoginID, string operateType, decimal operateMoney, int operateStatus, string userMemo, ShopNum1_AdvancePaymentModifyLog advancePaymentModifyLog, string AdminID)
        {
            string item = string.Empty;
            List<string> sqlList = new List<string>();
            item = string.Concat(new object[] { "UPDATE  ShopNum1_AdvancePaymentApplyLog SET  UserMemo ='", Operator.FilterString(userMemo), "', OperateStatus =", operateStatus, " WHERE Guid ='", Operator.FilterString(guid), "'" });
            sqlList.Add(item);
            if (operateStatus == 1)
            {
                if ((!(operateType == "0") && (operateType == "1")) && (ShopNum1.Common.Common.GetNameById("OperateStatus", "ShopNum1_AdvancePaymentApplyLog", " and Guid ='" + Operator.FilterString(guid) + "'") == "0"))
                {
                    item = string.Concat(new object[] { "UPDATE ShopNum1_Member SET  AdvancePayment = AdvancePayment+", operateMoney, " Where  MemLoginID='", memLoginID, "'" });
                    sqlList.Add(item);
                    item = string.Concat(new object[] { 
                        "INSERT INTO ShopNum1_AdvancePaymentModifyLog( \tGuid\t, \tOperateType\t, \tCurrentAdvancePayment\t, \tOperateMoney\t, \tLastOperateMoney\t, \tDate\t, \tMemo\t, \tMemLoginID\t, \tCreateUser\t, \tCreateTime\t, \tIsDeleted  ) VALUES (  '", advancePaymentModifyLog.Guid, "',  ", advancePaymentModifyLog.OperateType, ",  ", advancePaymentModifyLog.CurrentAdvancePayment, ",  ", advancePaymentModifyLog.OperateMoney, ",  ", advancePaymentModifyLog.LastOperateMoney, ",  '", advancePaymentModifyLog.Date, "',  '", Operator.FilterString(advancePaymentModifyLog.Memo), "',  '", advancePaymentModifyLog.MemLoginID, 
                        "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '", advancePaymentModifyLog.CreateTime, "',  ", advancePaymentModifyLog.IsDeleted, ")"
                     });
                    sqlList.Add(item);
                }
            }
            else if (operateStatus == 2)
            {
                if (operateType == "0")
                {
                    DataTable table = new ShopNum1_Member_Action().SearchByMemLoginID(memLoginID);
                    if ((table != null) && (table.Rows.Count > 0))
                    {
                        ShopNum1_AdvancePaymentFreezeLog advancePaymentFreezeLog = new ShopNum1_AdvancePaymentFreezeLog {
                            Guid = Guid.NewGuid(),
                            OperateType = 1,
                            OperateMoney = Convert.ToDecimal(operateMoney),
                            LastOperateMoney = Convert.ToDecimal(table.Rows[0]["LockAdvancePayment"].ToString()) - Convert.ToDecimal(operateMoney),
                            CurrentAdvancePayment = Convert.ToDecimal(table.Rows[0]["AdvancePayment"].ToString()) + Convert.ToDecimal(operateMoney),
                            Date = DateTime.Now,
                            Memo = "拒绝提现返还冻结金额",
                            MemLoginID = memLoginID,
                            CreateUser = AdminID,
                            CreateTime = DateTime.Now.ToString(),
                            IsDeleted = 0
                        };
                        new ShopNum1_AdvancePaymentFreezeLog_Action().OperateMoney(advancePaymentFreezeLog, Convert.ToDecimal(table.Rows[0]["AdvancePayment"].ToString()) + Convert.ToDecimal(operateMoney));
                    }
                }
                else if (!(operateType == "1"))
                {
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
    }
}

