using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Text;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_OrdeComplaints_Action : IShopNum1_OrdeComplaints_Action
	{
		public DataTable GetOrderComplaints(string ComplaintShop, string type)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("ID,");
			stringBuilder.Append("OrderID,");
			stringBuilder.Append("ComplaintTime,");
			stringBuilder.Append("OrderGuid,");
			stringBuilder.Append("MemLoginID,");
			stringBuilder.Append("ProcessingTime,");
			stringBuilder.Append("ProcessingStatus,");
			stringBuilder.Append("ProcessingResults,");
			stringBuilder.Append("ComplaintType,");
			stringBuilder.Append("Evidence,");
			stringBuilder.Append("CustomerMessage,");
			stringBuilder.Append(" ComplaintContent, ");
			stringBuilder.Append("ComplaintShop ");
			stringBuilder.Append("FROM ShopNum1_OrderComplaint WHERE 1=1");
			if (Operator.FormatToEmpty(ComplaintShop) != null)
			{
				stringBuilder.Append(" AND ComplaintShop LIKE '%" + ComplaintShop + "%'");
			}
			if (type != "-1")
			{
				stringBuilder.Append(" AND ComplaintType ='" + type + "'");
			}
			stringBuilder.Append(" ORDER BY ComplaintTime DESC");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable GetOrderComplaints(string ComplaintShop, string type, string OrderID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("ID,");
			stringBuilder.Append("OrderID,");
			stringBuilder.Append("ComplaintTime,");
			stringBuilder.Append("OrderGuid,");
			stringBuilder.Append("MemLoginID,");
			stringBuilder.Append("ProcessingTime,");
			stringBuilder.Append("ProcessingStatus,");
			stringBuilder.Append("ProcessingResults,");
			stringBuilder.Append("ComplaintType,");
			stringBuilder.Append("Evidence,");
			stringBuilder.Append("CustomerMessage,");
			stringBuilder.Append(" ComplaintContent, ");
			stringBuilder.Append("ComplaintShop ");
			stringBuilder.Append("FROM ShopNum1_OrderComplaint WHERE 1=1");
			if (Operator.FormatToEmpty(ComplaintShop) != null)
			{
				stringBuilder.Append(" AND ComplaintShop LIKE '%" + ComplaintShop + "%'");
			}
			if (type != "-1")
			{
				stringBuilder.Append(" AND ComplaintType ='" + type + "'");
			}
			if (!string.IsNullOrEmpty(OrderID))
			{
				stringBuilder.Append(" AND    OrderID='" + OrderID + "'");
			}
			stringBuilder.Append(" ORDER BY ComplaintTime DESC");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public int CancelComplaints(string guid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("UPDATE ShopNum1_OrdeComplaints SET ");
			stringBuilder.Append("ProcessingState=4,");
			stringBuilder.Append("ProcessingResult='取消投诉', ");
			stringBuilder.Append("ProcessingResult='" + DateTime.Now.ToString() + "' ");
			stringBuilder.Append(" WHERE Guid=" + guid);
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public int ComplaintsResult(string guid, string resultes)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("UPDATE ShopNum1_OrdeComplaints SET ");
			stringBuilder.Append("ProcessingState=3,");
			stringBuilder.Append("ProcessingResult='" + Operator.FilterString(resultes) + "', ");
			stringBuilder.Append("ProcessingTime='" + DateTime.Now.ToString() + "' ");
			stringBuilder.Append(" WHERE Guid=" + guid);
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public int Delete(string string_0)
		{
			string text = "delete from  ShopNum1_OrderComplaint where ID IN (" + string_0 + ")";
			return DatabaseExcetue.RunNonQuery(text.ToString());
		}
		public int addReply(ShopNum1_OrderComplaint OrderComplaint)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("UPDATE   ShopNum1_OrderComplaint      SET ");
			stringBuilder.Append("ProcessingTime='" + Convert.ToDateTime(OrderComplaint.ProcessingTime).ToString("yyyy-MM-dd HH:mm:ss") + "',");
			stringBuilder.Append("ProcessingResults='" + Operator.FilterString(OrderComplaint.ProcessingResults) + "', ");
			stringBuilder.Append("ProcessingStatus='" + OrderComplaint.ProcessingStatus + "',");
			stringBuilder.Append("OperateUser='" + OrderComplaint.OperateUser + "' ");
			stringBuilder.Append(" WHERE ID='" + OrderComplaint.ID + "'");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public int AddOrderComplaints(string orderguid, string complaintsnum, string orderid, string shopid, string memloginid, string reporttype, string evidence)
		{
			string[] array = new string[7];
			string[] array2 = new string[7];
			array[0] = "@orderguid";
			array2[0] = orderguid;
			array[1] = "@complaintsnum";
			array2[1] = complaintsnum;
			array[2] = "@orderid";
			array2[2] = orderid;
			array[3] = "@shopid";
			array2[3] = shopid;
			array[4] = "@memloginid";
			array2[4] = memloginid;
			array[5] = "@reporttype";
			array2[5] = reporttype;
			array[6] = "@evidence";
			array2[6] = evidence;
			return DatabaseExcetue.RunProcedure("Pro_ShopNum1_AddOrderComplaints", array, array2);
		}
		public DataTable GetOrderComplaintsDetails(string guid)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@guid";
			array2[0] = guid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetOrderComplaintsDetails", array, array2);
		}
		public DataTable Search(string memloginid, string type, string state)
		{
			string[] array = new string[3];
			string[] array2 = new string[3];
			array[0] = "@type";
			array2[0] = type;
			array[1] = "@state";
			array2[1] = state;
			array[2] = "@memloginid";
			array2[2] = memloginid;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchOrderComplaints", array, array2);
		}
	}
}
