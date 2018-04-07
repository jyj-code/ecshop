namespace ShopNum1.BusinessLogic
{
    using ShopNum1.Common;
    using ShopNum1.DataAccess;
    using ShopNum1.Interface;
    using ShopNum1MultiEntity;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class ShopNum1_AdvancePaymentModifyLog_Action : IShopNum1_AdvancePaymentModifyLog_Action
    {
        public int ChangeOperateStatus(string ID, int OperateStatus)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[] { "   UPDATE  ShopNum1_AdvancePaymentApplyLog  SET  OperateStatus =", OperateStatus, "  WHERE  ID='", ID, "'   " }));
        }

        public DataTable GetAdvancePaymentModifyLog(string ID)
        {
            return DatabaseExcetue.ReturnDataTable(("select * from ShopNum1_AdvancePaymentApplyLog where ID=" + ID).ToString());
        }

        public int OperateMoney(ShopNum1_AdvancePaymentModifyLog advancePaymentModifyLog)
        {
            string item = string.Empty;
            List<string> sqlList = new List<string>();
            item = string.Concat(new object[] { 
                "INSERT INTO ShopNum1_AdvancePaymentModifyLog( \tGuid\t, \tOperateType\t, \tCurrentAdvancePayment\t, \tOperateMoney\t, \tLastOperateMoney\t, \tDate\t, \tMemo\t, \tMemLoginID\t, \tCreateUser\t, \tCreateTime\t,    OrderNumber ,\tIsDeleted  ) VALUES (  '", advancePaymentModifyLog.Guid, "',  ", advancePaymentModifyLog.OperateType, ",  ", advancePaymentModifyLog.CurrentAdvancePayment, ",  ", advancePaymentModifyLog.OperateMoney, ",  ", advancePaymentModifyLog.LastOperateMoney, ",  '", advancePaymentModifyLog.Date, "',  '", Operator.FilterString(advancePaymentModifyLog.Memo), "',  '", advancePaymentModifyLog.MemLoginID, 
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '", advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ", advancePaymentModifyLog.IsDeleted, ")"
             });
            sqlList.Add(item);
            item = string.Concat(new object[] { "UPDATE ShopNum1_Member SET  AdvancePayment =", advancePaymentModifyLog.LastOperateMoney, " WHERE  MemLoginID ='", advancePaymentModifyLog.MemLoginID, "'" });
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

        public DataTable Search(string memLoginID, string date1, string date2, int operateType, int isDeleted)
        {
            string str = string.Empty;
            str = "SELECT \tGuid\t, \tOperateType\t, \tCurrentAdvancePayment\t, \tOperateMoney\t, \tLastOperateMoney\t, \tDate\t, \tMemo\t, \tMemLoginID\t, \tCreateUser\t, \tCreateTime\t, \tIsDeleted   FROM ShopNum1_AdvancePaymentModifyLog   WHERE 0=0 ";
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                str = str + " AND MemLoginID ='" + memLoginID + "'";
            }
            if (operateType != -1)
            {
                str = str + " AND OperateType=" + operateType;
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

        public DataTable SelectAdvPaymentModifyLog_List(CommonPageModel commonModel)
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

        public DataTable SelectOperateMoney(string memberid, string operatetype, string datetime1, string datetime2, string ordernumber)
        {
            string strSql = string.Empty;
            strSql = " SELECT * FROM ShopNum1_AdvancePaymentModifyLog ";
            strSql = strSql + " WHERE 1=1 ";
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
                strSql = strSql + " AND Date<='" + Operator.FilterString(datetime2) + "' ";
            }
            if (Operator.FormatToEmpty(ordernumber) != string.Empty)
            {
                strSql = strSql + " AND OrderNumber='" + ordernumber + "'";
            }
            if ((Operator.FormatToEmpty(operatetype) != string.Empty) && (Operator.FormatToEmpty(operatetype) != "-1"))
            {
                strSql = strSql + " AND operatetype='" + operatetype + "'";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }
    }
}

