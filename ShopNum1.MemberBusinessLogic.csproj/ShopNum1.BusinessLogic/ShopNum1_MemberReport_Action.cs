namespace ShopNum1.BusinessLogic
{
    using ShopNum1.Common;
    using ShopNum1.DataAccess;
    using ShopNum1.Interface;
    using ShopNum1MultiEntity;
    using System;
    using System.Data;
    using System.Text;

    public class ShopNum1_MemberReport_Action : IShopNum1_MemberReport_Action
    {
        public int Add(ShopNum1_MemberReport MemberReport)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[] { "INSERT INTO ShopNum1_MemberReport( \tProductUrl\t, \tReportType\t, \tReportShop\t, \tEvidence\t, \tEvidenceImage\t, \tReportTime\t, \tMemLoginID\t  ) VALUES (  '", MemberReport.ProductUrl, "',  '", MemberReport.ReportType, "',  '", MemberReport.ReportShop, "',  '", MemberReport.Evidence, "',  '", MemberReport.EvidenceImage, "',  '", MemberReport.ReportTime, "', '", MemberReport.MemLoginID, "' )" }));
        }

        public int addReply(ShopNum1_MemberReport MemberReport)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("UPDATE ShopNum1_MemberReport  SET ");
            builder.Append("ProcessingTime='" + MemberReport.ProcessingTime + "',");
            builder.Append("ProcessingResults='" + Operator.FilterString(MemberReport.ProcessingResults) + "',");
            builder.Append("ProcessingStatus='" + Operator.FilterString(MemberReport.ProcessingStatus) + "',");
            builder.Append("OperateUser='" + Operator.FilterString(MemberReport.OperateUser) + "' ");
            builder.Append("WHERE ID=" + MemberReport.ID);
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public DataTable CheckIsComplainByID(string string_0)
        {
            string[] paraName = new string[1];
            string[] paraValue = new string[1];
            paraName[0] = "@id";
            paraValue[0] = string_0;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_CheckIsComplainByID", paraName, paraValue);
        }

        public int Delete(string string_0)
        {
            return DatabaseExcetue.RunNonQuery("   DELETE  ShopNum1_MemberReport  WHERE  ID IN (" + string_0 + ")   ");
        }

        public DataTable GetComplaintsManagement(string guid)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT  ");
            builder.Append("ID, ");
            builder.Append("ShopProductID, ");
            builder.Append("ProductUrl, ");
            builder.Append("ReportShop, ");
            builder.Append("MemLoginID, ");
            builder.Append("ReportType, ");
            builder.Append("Evidence, ");
            builder.Append("EvidenceImage, ");
            builder.Append("ComplaintContent, ");
            builder.Append("ComplaintImage, ");
            builder.Append("ComplaintTime, ");
            builder.Append("ReportTime, ");
            builder.Append("CustomerMessage, ");
            builder.Append("ProcessingTime, ");
            builder.Append("ProcessingStatus, ");
            builder.Append("ProcessingResults ");
            builder.Append("FROM ShopNum1_MemberReport ");
            builder.Append(" WHERE ID =" + guid);
            builder.Append(" ORDER BY ReportTime DESC");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable GetReportDetailByID(string string_0)
        {
            string[] paraName = new string[1];
            string[] paraValue = new string[1];
            paraName[0] = "@id";
            paraValue[0] = string_0;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetReportDetailByID", paraName, paraValue);
        }

        public DataTable GetReportListByReportShop(string shopid)
        {
            string[] paraName = new string[1];
            string[] paraValue = new string[1];
            paraName[0] = "@shopid";
            paraValue[0] = shopid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetReportListByReportShop", paraName, paraValue);
        }

        public DataTable Search(string memLoginID)
        {
            string str = string.Empty;
            str = "SELECT \tID\t, \tReportShop\t, \tReportType\t, \tReportTime\t   FROM ShopNum1_MemberReport   WHERE  0=0";
            if (memLoginID != string.Empty)
            {
                str = str + " AND MemLoginID='" + memLoginID + "'";
            }
            return DatabaseExcetue.ReturnDataTable(str + "Order by ReportTime Desc");
        }

        public DataTable Search(string memLoginID, string type)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("ID,");
            builder.Append("ShopProductID,");
            builder.Append("ReportShop,");
            builder.Append("MemLoginID,");
            builder.Append("ReportType,");
            builder.Append("Evidence,");
            builder.Append("ComplaintContent,");
            builder.Append("ReportTime,");
            builder.Append("CustomerMessage,");
            builder.Append("ProcessingTime,");
            builder.Append("ProcessingStatus,");
            builder.Append("ProcessingResults ");
            builder.Append("FROM ShopNum1_MemberReport WHERE 1=1");
            if (string.IsNullOrEmpty(memLoginID))
            {
                builder.Append(" AND MemLoginID LIKE '%" + memLoginID + "%'");
            }
            if (type != "-1")
            {
                builder.Append(" AND ReportType ='" + type + " ' ");
            }
            builder.Append(" ORDER BY ReportTime DESC");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable SearchReport(string string_0)
        {
            string strSql = string.Empty;
            strSql = "SELECT  *  FROM ShopNum1_MemberReport   WHERE  0=0";
            if (string_0 != string.Empty)
            {
                strSql = strSql + " AND ID='" + string_0 + "'";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public bool SearchReportName(string name)
        {
            string strSql = string.Empty;
            strSql = "SELECT  count(*) AS NUM  FROM ShopNum1_ShopInfo   WHERE  0=0";
            if (name != string.Empty)
            {
                strSql = strSql + " AND MemLoginID='" + name + "'";
            }
            DataTable table = DatabaseExcetue.ReturnDataTable(strSql);
            if ((table != null) && (table.Rows.Count > 0))
            {
                if (int.Parse(table.Rows[0]["NUM"].ToString()) != 1)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        public bool SearchReportProduct(string product, string name)
        {
            string strSql = string.Empty;
            strSql = "SELECT  Guid  FROM ShopNum1_Shop_Product   WHERE  0=0";
            if (product != string.Empty)
            {
                strSql = strSql + " AND Guid='" + product + "'";
            }
            if (name != string.Empty)
            {
                strSql = strSql + " AND MemLoginID='" + name + "'";
            }
            return (DatabaseExcetue.ReturnDataTable(strSql).Rows.Count > 0);
        }

        public DataTable Select_List(CommonPageModel commonModel)
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
            paraValue[3] = "ShopNum1_MemberReport";
            paraName[4] = "@condition";
            paraValue[4] = commonModel.Condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "ReportTime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = commonModel.Resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", paraName, paraValue);
        }

        public int UpdateComplainInfoByID(string string_0, string complainimage, string complaintcontent)
        {
            string[] paraName = new string[3];
            string[] paraValue = new string[3];
            paraName[0] = "@id";
            paraValue[0] = string_0;
            paraName[1] = "@complainimage";
            paraValue[1] = complainimage;
            paraName[2] = "@complaintcontent";
            paraValue[2] = complaintcontent;
            return DatabaseExcetue.RunProcedure("Pro_Shop_UpdateComplainInfoByID", paraName, paraValue);
        }

        public int UpdateProcessingStatus(string string_0, int ProcessingStatus)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[] { "   UPDATE   ShopNum1_MemberReport  SET   ProcessingStatus=", ProcessingStatus, "     WHERE  ID ='", string_0, "'   " }));
        }
    }
}

