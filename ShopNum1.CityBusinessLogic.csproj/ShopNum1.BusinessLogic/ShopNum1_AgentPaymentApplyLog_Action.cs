using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_AgentPaymentApplyLog_Action : IShopNum1_AgentPaymentApplyLog_Action
	{
		public int Add(ShopNum1_AgentPaymentApplyLog AgentPaymentApplyLog)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"insert  ShopNum1_AgentPaymentApplyLog( Guid,OperateType,OrderNumber,CurrentAdvancePayment,OperateMoney,Date,OperateStatus,Memo,UserMemo,MemLoginID,PaymentGuid,PaymentName,Bank,TrueName,Account,IsDeleted,ID,OrderStatus,SubstationID ) VALUES (  '",
				Operator.FilterString(AgentPaymentApplyLog.Guid),
				"',  '",
				Operator.FilterString(AgentPaymentApplyLog.OperateType),
				"',  '",
				Operator.FilterString(AgentPaymentApplyLog.OrderNumber),
				"',  '",
				Operator.FilterString(AgentPaymentApplyLog.CurrentAdvancePayment),
				"',  '",
				Operator.FilterString(AgentPaymentApplyLog.OperateMoney),
				"',  '",
				Operator.FilterString(AgentPaymentApplyLog.Date),
				"',  '",
				Operator.FilterString(AgentPaymentApplyLog.OperateStatus),
				"',  '",
				Operator.FilterString(AgentPaymentApplyLog.Memo),
				"',  '",
				Operator.FilterString(AgentPaymentApplyLog.UserMemo),
				"',  '",
				Operator.FilterString(AgentPaymentApplyLog.MemLoginID),
				"',  '",
				Operator.FilterString(AgentPaymentApplyLog.PaymentGuid),
				"',  '",
				Operator.FilterString(AgentPaymentApplyLog.PaymentName),
				"',  '",
				Operator.FilterString(AgentPaymentApplyLog.Bank),
				"',  '",
				Operator.FilterString(AgentPaymentApplyLog.TrueName),
				"',  '",
				Operator.FilterString(AgentPaymentApplyLog.Account),
				"',  '",
				Operator.FilterString(AgentPaymentApplyLog.IsDeleted),
				"',  '",
				Operator.FilterString(AgentPaymentApplyLog.ID),
				"',  '",
				Operator.FilterString(AgentPaymentApplyLog.OrderStatus),
				"',  '",
				Operator.FilterString(AgentPaymentApplyLog.SubstationID),
				"'  )"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Updata(ShopNum1_AgentPaymentApplyLog AgentPaymentApplyLog)
		{
			return 0;
		}
		public int Delete(string Guid)
		{
			string strSql = string.Empty;
			strSql = "DELETE FROM  ShopNum1_AgentPaymentApplyLog  WHERE  Guid IN (" + Guid + ")";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable Search(string SubstationID)
		{
			string text = string.Empty;
			text = "SELECT * FROM  ShopNum1_AgentPaymentApplyLog WHERE 0=0";
			if (Operator.FilterString(SubstationID) != "")
			{
				text = text + " AND  SubstationID='" + SubstationID + "' ";
			}
			text += "   order  by   Date  desc     ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchByGuid(string Guid)
		{
			string text = string.Empty;
			text = "SELECT * FROM  ShopNum1_AgentPaymentApplyLog WHERE 0=0";
			if (Operator.FilterString(Guid) != "")
			{
				text = text + " AND   Guid='" + Guid + "' ";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Search()
		{
			string text = string.Empty;
			text = "SELECT * FROM  ShopNum1_AgentPaymentApplyLog  WHERE 0=0";
			text += "   order  by   Date  desc     ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Search(string OrderNumber, string MemLoginID, string OperateStatus, string starttime, string endtime, string SubstationID)
		{
			string text = string.Empty;
			text = "SELECT * FROM    ShopNum1_AgentPaymentApplyLog   WHERE 0=0";
			if (Operator.FilterString(OrderNumber) != "")
			{
				text = text + " AND   OrderNumber='" + OrderNumber + "' ";
			}
			if (Operator.FilterString(MemLoginID) != "")
			{
				text = text + " AND    MemLoginID='" + MemLoginID + "' ";
			}
			if (OperateStatus != "-1")
			{
				text = text + " AND     OperateStatus='" + OperateStatus + "' ";
			}
			if (!string.IsNullOrEmpty(starttime))
			{
				text = text + " AND      Date  > '" + starttime + "' ";
			}
			if (!string.IsNullOrEmpty(endtime))
			{
				text = text + " AND      Date  < '" + endtime + "' ";
			}
			if (SubstationID != "-1")
			{
				text = text + " AND     SubstationID='" + SubstationID + "' ";
			}
			text += "   order  by     Date       desc     ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int UpdataOperateStatus(int OperateStatus, string Guid, string Memo)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"   UPDATE ShopNum1_AgentPaymentApplyLog  SET   OperateStatus='",
				OperateStatus,
				"',Memo='",
				Memo,
				"'  WHERE  Guid='",
				Guid,
				"'      "
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int UpdataCityAdvancePayment(decimal AdvancePayment, string SubstationID, int optype)
		{
			string strSql = string.Empty;
			if (optype == 0)
			{
				strSql = string.Concat(new object[]
				{
					"   UPDATE    ShopNum1_SubstationManage  SET   AdvancePayment=AdvancePayment-'",
					AdvancePayment,
					"'  WHERE    SubstationID='",
					SubstationID,
					"'    "
				});
			}
			else if (optype == 1)
			{
				strSql = string.Concat(new object[]
				{
					"   UPDATE    ShopNum1_SubstationManage  SET   AdvancePayment=AdvancePayment +'",
					AdvancePayment,
					"'  WHERE    SubstationID='",
					SubstationID,
					"'    "
				});
			}
			return DatabaseExcetue.RunNonQuery(strSql);
		}
	}
}
