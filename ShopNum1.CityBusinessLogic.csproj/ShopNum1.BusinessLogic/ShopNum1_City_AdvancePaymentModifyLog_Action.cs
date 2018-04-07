using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_City_AdvancePaymentModifyLog_Action : IShopNum1_City_AdvancePaymentModifyLog_Action
	{
		public int Add(ShopNum1_City_AdvancePaymentModifyLog City_AdvancePaymentModifyLog)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"insert  ShopNum1_City_AdvancePaymentModifyLog( Guid,OperateType,CurrentAdvancePayment,OperateMoney,LastOperateMoney,Date,Memo,SubstationID,CreateUser,CreateTime,IsDeleted,UserMemo,IsMainAdmin,OrderNumber ) VALUES (  '",
				City_AdvancePaymentModifyLog.Guid,
				"',  '",
				Operator.FilterString(City_AdvancePaymentModifyLog.OperateType),
				"',  '",
				Operator.FilterString(City_AdvancePaymentModifyLog.CurrentAdvancePayment),
				"',  '",
				Operator.FilterString(City_AdvancePaymentModifyLog.OperateMoney),
				"',  '",
				Operator.FilterString(City_AdvancePaymentModifyLog.LastOperateMoney),
				"',  '",
				Operator.FilterString(City_AdvancePaymentModifyLog.Date),
				"',  '",
				Operator.FilterString(City_AdvancePaymentModifyLog.Memo),
				"',  '",
				Operator.FilterString(City_AdvancePaymentModifyLog.SubstationID),
				"',  '",
				Operator.FilterString(City_AdvancePaymentModifyLog.CreateUser),
				"',  '",
				Operator.FilterString(City_AdvancePaymentModifyLog.CreateTime),
				"',  '",
				Operator.FilterString(City_AdvancePaymentModifyLog.IsDeleted),
				"',  '",
				Operator.FilterString(City_AdvancePaymentModifyLog.UserMemo),
				"',  '",
				Operator.FilterString(City_AdvancePaymentModifyLog.IsMainAdmin),
				"',  '",
				Operator.FilterString(City_AdvancePaymentModifyLog.OrderNumber),
				"'    )"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Updata(ShopNum1_City_AdvancePaymentModifyLog City_AdvancePaymentModifyLog)
		{
			return -1;
		}
		public int Delete(string Guid)
		{
			string strSql = string.Empty;
			strSql = "DELETE FROM  ShopNum1_City_AdvancePaymentModifyLog  WHERE   Guid    IN (" + Guid + ")";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable Search()
		{
			string strSql = string.Empty;
			strSql = "SELECT  *  FROM    ShopNum1_City_AdvancePaymentModifyLog     WHERE 0=0";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public decimal SearchAdvancePaymentBySubstationID(string SubstationID)
		{
			string strSql = string.Empty;
			strSql = "SELECT   AdvancePayment      FROM     ShopNum1_SubstationManage   WHERE    SubstationID='" + SubstationID + "'          ";
			DataTable dataTable = DatabaseExcetue.ReturnDataTable(strSql);
			decimal result;
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				result = Convert.ToDecimal(dataTable.Rows[0][0].ToString());
			}
			else
			{
				result = 0m;
			}
			return result;
		}
		public int UpdateSubstationAdvancePayment(decimal AdvancePayment, string SubstationID, int type)
		{
			string strSql = string.Empty;
			int result;
			if (type == 0)
			{
				strSql = string.Concat(new string[]
				{
					"      update     ShopNum1_SubstationManage   set     AdvancePayment=AdvancePayment-",
					AdvancePayment.ToString(),
					"      WHERE    SubstationID='",
					SubstationID,
					"'            "
				});
			}
			else
			{
				if (type != 1)
				{
					result = 0;
					return result;
				}
				strSql = string.Concat(new string[]
				{
					"      update     ShopNum1_SubstationManage   set     AdvancePayment=AdvancePayment+",
					AdvancePayment.ToString(),
					"      WHERE    SubstationID='",
					SubstationID,
					"'            "
				});
			}
			result = DatabaseExcetue.RunNonQuery(strSql);
			return result;
		}
		public DataTable Search(int OperateType, string SubstationID, int IsMainAdmin, string OrderNumber, string startDate, string endDate)
		{
			string text = string.Empty;
			text = "SELECT  *  FROM    ShopNum1_City_AdvancePaymentModifyLog     WHERE 0=0";
			if (OperateType != -1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"     AND     OperateType='",
					OperateType,
					"'       "
				});
			}
			if (SubstationID != "-1")
			{
				text = text + "     AND      SubstationID='" + SubstationID + "'       ";
			}
			if (IsMainAdmin != -1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"     AND       IsMainAdmin='",
					IsMainAdmin,
					"'       "
				});
			}
			if (!string.IsNullOrEmpty(OrderNumber))
			{
				text = text + "     AND        OrderNumber='" + OrderNumber + "'       ";
			}
			if (!string.IsNullOrEmpty(startDate))
			{
				text = text + "     AND         Date>'" + startDate + "'       ";
			}
			if (!string.IsNullOrEmpty(startDate))
			{
				text = text + "     AND         Date<'" + endDate + "'       ";
			}
			text += "      ORDER  BY   Date  DESC        ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
	}
}
