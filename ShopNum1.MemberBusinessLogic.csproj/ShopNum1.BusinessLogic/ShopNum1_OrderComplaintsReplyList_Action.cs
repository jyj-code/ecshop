namespace ShopNum1.BusinessLogic
{
    using ShopNum1.Common;
    using ShopNum1.DataAccess;
    using ShopNum1.Interface;
    using ShopNum1MultiEntity;
    using System;
    using System.Data;
    using System.Text;

    public class ShopNum1_OrderComplaintsReplyList_Action : IShopNum1_OrderComplaintsReplyList_Action
    {
        public int Add(ShopNum1_OrderComplaint OrderComplaint)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[] { 
                "INSERT INTO ShopNum1_OrderComplaint( \tComplaintShop\t, \tOrderID\t, \tComplaintType\t, \tEvidence\t, \tEvidenceImage\t, \tComplaintTime\t, \tProcessingStatus\t, \tMemLoginID\t  ) VALUES (  '", Operator.FilterString(OrderComplaint.ComplaintShop), "',  '", Operator.FilterString(OrderComplaint.OrderID), "',  '", Operator.FilterString(OrderComplaint.ComplaintType), "',  '", Operator.FilterString(OrderComplaint.Evidence), "',  '", Operator.FilterString(OrderComplaint.EvidenceImage), "',  '", OrderComplaint.ComplaintTime, "', '", OrderComplaint.ProcessingStatus, "', '", OrderComplaint.MemLoginID, 
                "' )"
             }));
        }

        public int addReply(ShopNum1_OrderComplaint OrderComplaint)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("UPDATE ShopNum1_OrderComplaint  SET ");
            builder.Append("ProcessingTime='" + OrderComplaint.ProcessingTime + "',");
            builder.Append("ProcessingResults='" + Operator.FilterString(OrderComplaint.ProcessingResults) + "',");
            builder.Append("ProcessingStatus='" + Operator.FilterString(OrderComplaint.ProcessingStatus) + "',");
            builder.Append("OperateUser='" + Operator.FilterString(OrderComplaint.OperateUser) + "' ");
            builder.Append("WHERE ID=" + OrderComplaint.ID);
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public DataTable CheckIsOrderComplainByID(string string_0)
        {
            string[] paraName = new string[1];
            string[] paraValue = new string[1];
            paraName[0] = "@id";
            paraValue[0] = string_0;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_CheckIsOrderComplainByID", paraName, paraValue);
        }

        public int Delete(string ID)
        {
            return DatabaseExcetue.RunNonQuery("    DELETE     ShopNum1_OrderComplaint  WHERE    ID  IN (" + ID + ")    ");
        }

        public DataTable GetComplainListByComplainShop(string shopid)
        {
            string[] paraName = new string[1];
            string[] paraValue = new string[1];
            paraName[0] = "@shopid";
            paraValue[0] = shopid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetComplainListByComplainShop", paraName, paraValue);
        }

        public DataTable GetOrderComplainDetailByID(string string_0)
        {
            string[] paraName = new string[1];
            string[] paraValue = new string[1];
            paraName[0] = "@id";
            paraValue[0] = string_0;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetOrderComplainDetailByID", paraName, paraValue);
        }

        public DataTable Search(string memberLoginID)
        {
            string str = string.Empty;
            str = "SELECT \tID\t, \tOrderID\t, \tOrderGuid\t, \tComplaintType\t, \tComplaintShop\t, \tComplaintTime\t, \tProcessingTime\t, \tProcessingStatus\t, \tMemLoginID\t, \tProcessingResults\t, \tEvidenceImage\t, \tEvidence\t, \tIsAppeal\t, \tCustomerMessage\t, \tComplaintContent\t   FROM ShopNum1_OrderComplaint   WHERE  0=0";
            if (memberLoginID != string.Empty)
            {
                str = str + " AND MemLoginID='" + memberLoginID + "'";
            }
            return DatabaseExcetue.ReturnDataTable(str + "Order by ComplaintTime Desc");
        }

        public DataTable Search(string memLoginID, string type)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("ID,");
            builder.Append("OrderID,");
            builder.Append("ComplaintShop,");
            builder.Append("MemLoginID,");
            builder.Append("ComplaintType,");
            builder.Append("Evidence,");
            builder.Append("ComplaintContent,");
            builder.Append("ComplaintTime,");
            builder.Append("CustomerMessage,");
            builder.Append("ProcessingTime,");
            builder.Append("ProcessingStatus,");
            builder.Append("ProcessingResults ");
            builder.Append("FROM ShopNum1_OrderComplaint WHERE 1=1");
            if (string.IsNullOrEmpty(memLoginID))
            {
                builder.Append(" AND MemLoginID LIKE '%" + memLoginID + "%'");
            }
            if (type != "-1")
            {
                builder.Append(" AND ComplaintType ='" + type + " ' ");
            }
            builder.Append(" ORDER BY ComplaintTime DESC");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable SearchComplaint(string string_0)
        {
            string strSql = string.Empty;
            strSql = "SELECT  *  FROM ShopNum1_OrderComplaint   WHERE  0=0";
            if (string_0 != string.Empty)
            {
                strSql = strSql + " AND ID='" + string_0 + "'";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
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
            paraValue[3] = "ShopNum1_OrderComplaint";
            paraName[4] = "@condition";
            paraValue[4] = commonModel.Condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "ComplaintTime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = commonModel.Resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", paraName, paraValue);
        }

        public int UpdateOrderComplainInfoByID(string string_0, string appealimage, string appealcontent)
        {
            string[] paraName = new string[3];
            string[] paraValue = new string[3];
            paraName[0] = "@id";
            paraValue[0] = string_0;
            paraName[1] = "@appealimage";
            paraValue[1] = appealimage;
            paraName[2] = "@appealcontent";
            paraValue[2] = appealcontent;
            return DatabaseExcetue.RunProcedure("Pro_Shop_UpdateOrderComplainInfoByID", paraName, paraValue);
        }

        public int UpdateProcessingStatus(int ProcessingStatus, string ID)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[] { "    UPDATE    ShopNum1_OrderComplaint  SET  ProcessingStatus=", ProcessingStatus, "    WHERE  ID='", ID, "'     " }));
        }
    }
}

