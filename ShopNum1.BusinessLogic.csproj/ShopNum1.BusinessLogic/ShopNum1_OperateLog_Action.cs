using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Text;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_OperateLog_Action : IShopNum1_OperateLog_Action
	{
		public int Add(ShopNum1_OperateLog shopNum1_operateLog)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("INSERT INTO ShopNum1_OperateLog(");
			stringBuilder.Append("[Guid],");
			stringBuilder.Append("Record,");
			stringBuilder.Append("OperatorID,");
			stringBuilder.Append("IP,");
			stringBuilder.Append("PageName,");
			stringBuilder.Append("Date)");
			stringBuilder.Append(" VALUES(");
			stringBuilder.Append("'" + Guid.NewGuid() + "',");
			stringBuilder.Append("'" + Operator.FilterString(shopNum1_operateLog.Record) + "',");
			stringBuilder.Append("'" + shopNum1_operateLog.OperatorID + "',");
			stringBuilder.Append("'" + shopNum1_operateLog.IP + "',");
			stringBuilder.Append("'" + shopNum1_operateLog.PageName + "',");
			stringBuilder.Append("'" + shopNum1_operateLog.Date.ToString() + "'");
			stringBuilder.Append(")");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public int Delete(string guids)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("DELETE FROM ShopNum1_OperateLog WHERE [Guid] in (" + guids + ")");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public int DeleteAll(string startDate, string endDate)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(string.Concat(new string[]
			{
				"DELETE FROM ShopNum1_OperateLog WHERE Date >='",
				startDate,
				"' AND Date<='",
				endDate,
				"'"
			}));
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public DataTable Search(string operatorID, string IP, string StartDate, string EndDate)
		{
			bool flag = true;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT ");
			stringBuilder.Append("[Guid],");
			stringBuilder.Append("Record,");
			stringBuilder.Append("OperatorID,");
			stringBuilder.Append("IP,");
			stringBuilder.Append("PageName,");
			stringBuilder.Append("Date");
			stringBuilder.Append(" FROM ShopNum1_OperateLog");
			if (operatorID != null && operatorID != "")
			{
				stringBuilder.Append(" WHERE OperatorID = '" + Operator.FilterString(operatorID) + "'");
				flag = false;
			}
			if (StartDate != null && StartDate != "")
			{
				if (!flag)
				{
					stringBuilder.Append(" AND");
				}
				else
				{
					stringBuilder.Append(" WHERE");
				}
				stringBuilder.Append(" Date >= '" + StartDate + "'");
				flag = false;
			}
			if (EndDate != null && EndDate != "")
			{
				if (!flag)
				{
					stringBuilder.Append(" AND");
				}
				else
				{
					stringBuilder.Append(" WHERE");
				}
				stringBuilder.Append(" Date <= '" + EndDate + "'");
				flag = false;
			}
			if (IP != null && IP != "")
			{
				if (!flag)
				{
					stringBuilder.Append(" AND");
				}
				else
				{
					stringBuilder.Append(" WHERE");
				}
				stringBuilder.Append(" IP LIKE '%" + Operator.FilterString(IP) + "%'");
			}
			stringBuilder.Append(" ORDER BY Date DESC");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
	}
}
