using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_ScoreModifyLog_Action : IShopNum1_ScoreModifyLog_Action
	{
		public int OperateScore(ShopNum1_ScoreModifyLog scoreModeLog)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_ScoreModifyLog( \tGuid\t, \tOperateType\t, \tCurrentScore\t, \tOperateScore\t, \tLastOperateScore\t, \tDate\t, \tMemo\t, \tMemLoginID\t, \tCreateUser\t, \tCreateTime\t, \tIsDeleted  ) VALUES (  '",
				scoreModeLog.Guid,
				"',  ",
				scoreModeLog.OperateType,
				",  ",
				scoreModeLog.CurrentScore,
				",  ",
				scoreModeLog.OperateScore,
				",  ",
				scoreModeLog.LastOperateScore,
				",  '",
				scoreModeLog.Date,
				"',  '",
				Operator.FilterString(scoreModeLog.Memo),
				"',  '",
				scoreModeLog.MemLoginID,
				"',  '",
				scoreModeLog.CreateUser,
				"', '",
				scoreModeLog.CreateTime,
				"',  ",
				scoreModeLog.IsDeleted,
				")"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable Search(string memLoginID, string date1, string date2, int operateType, int isDeleted)
		{
			string text = string.Empty;
			text = "SELECT \tGuid\t, \tOperateType\t, \tCurrentScore\t, \tOperateScore\t, \tLastOperateScore\t, \tDate\t, \tMemo\t, \tMemLoginID\t, \tCreateUser\t, \tCreateTime\t, \tIsDeleted   FROM ShopNum1_ScoreModifyLog   WHERE 0=0 ";
			if (Operator.FormatToEmpty(memLoginID) != string.Empty)
			{
				text = text + " AND MemLoginID ='" + memLoginID + "'";
			}
			if (operateType != -1)
			{
				text = text + " AND OperateType=" + operateType;
			}
			if (Operator.FormatToEmpty(date1) != string.Empty)
			{
				text = text + " AND Date>='" + Operator.FilterString(date1) + "' ";
			}
			if (Operator.FormatToEmpty(date2) != string.Empty)
			{
				text = text + " AND Date<='" + Operator.FilterString(date2) + "' ";
			}
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					"AND IsDeleted=",
					isDeleted,
					" "
				});
			}
			text += "ORDER BY  Date Desc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable Search(string memLoginID, int isDeleted)
		{
			string text = string.Empty;
			text = "SELECT Guid, OperateType\t,CurrentScore, OperateScore, LastOperateScore, Date, Memo, MemLoginID\t, CreateUser, CreateTime, IsDeleted   FROM ShopNum1_ScoreModifyLog   WHERE 0=0 ";
			if (Operator.FormatToEmpty(memLoginID) != string.Empty)
			{
				text = text + " AND MemLoginID ='" + memLoginID + "'";
			}
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					"AND IsDeleted=",
					isDeleted,
					" "
				});
			}
			text += "ORDER BY  Date Desc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int Delete(string guids)
		{
			string strSql = string.Empty;
			strSql = "  delete ShopNum1_ScoreModifyLog  where Guid='" + guids + "'  ";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetDataInfo(int IsDeleted)
		{
			string strSql = string.Empty;
			strSql = "   select * from  ShopNum1_ScoreModifyLog  where  IsDeleted='" + IsDeleted + "'  ORDER BY CreateTime DESC   ";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetDataInfo(int IsDeleted, string MemLoginID)
		{
			string text = string.Empty;
			text = "   select * from  ShopNum1_ScoreModifyLog  where  IsDeleted='" + IsDeleted + "'   ";
			if (!string.IsNullOrEmpty(MemLoginID))
			{
				text = text + "   and  MemLoginID='" + MemLoginID + "'   ";
			}
			text += "   ORDER BY CreateTime DESC    ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetDataInfoAdmin(string MemLoginID, int OperateType, string startTime, string endTime, int IsDeleted)
		{
			string text = string.Empty;
			text = "   select * from  ShopNum1_ScoreModifyLog  where  IsDeleted='" + IsDeleted + "'   ";
			if (!string.IsNullOrEmpty(MemLoginID))
			{
				text = text + "   and  MemLoginID='" + MemLoginID + "'   ";
			}
			if (OperateType != -1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					"   and  OperateType='",
					OperateType,
					"'   "
				});
			}
			if (!string.IsNullOrEmpty(startTime))
			{
				text = text + "   and  CreateTime >   '" + startTime + "'   ";
			}
			if (!string.IsNullOrEmpty(endTime))
			{
				text = text + "   and  CreateTime <   '" + endTime + "'   ";
			}
			text += "   order  by CreateTime desc     ";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable GetShopDataInfoByMemLoginID(string MemLoginID)
		{
			string strSql = string.Empty;
			strSql = "   select * from   ShopNum1_ShopInfo     where  MemLoginID='" + MemLoginID + "'   ";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable Select_List(CommonPageModel commonModel)
		{
			string[] array = new string[8];
			string[] array2 = new string[8];
			array[0] = "@pagesize";
			array2[0] = commonModel.PageSize;
			array[1] = "@currentpage";
			array2[1] = commonModel.Currentpage;
			array[2] = "@columns";
			array2[2] = "Guid, OperateType,CurrentScore,OperateScore,LastOperateScore,Date,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ";
			array[3] = "@tablename";
			array2[3] = "ShopNum1_ScoreModifyLog";
			array[4] = "@condition";
			array2[4] = commonModel.Condition;
			array[5] = "@ordercolumn";
			array2[5] = "CreateTime";
			array[6] = "@sortvalue";
			array2[6] = "desc";
			array[7] = "@resultnum";
			array2[7] = commonModel.Resultnum;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", array, array2);
		}
	}
}
