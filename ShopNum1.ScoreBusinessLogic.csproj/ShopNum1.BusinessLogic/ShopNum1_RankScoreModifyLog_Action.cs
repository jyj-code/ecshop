using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_RankScoreModifyLog_Action : IShopNum1_RankScoreModifyLog_Action
	{
		public int OperateScore(ShopNum1_RankScoreModifyLog rankScoreModifyLog)
		{
			string item = string.Empty;
			List<string> list = new List<string>();
			item = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_RankScoreModifyLog( \tGuid\t, \tOperateType\t, \tCurrentScore\t, \tOperateScore\t, \tLastOperateScore\t, \tDate\t, \tMemo\t, \tMemLoginID\t, \tCreateUser\t, \tCreateTime\t, \tIsDeleted  ) VALUES (  '",
				rankScoreModifyLog.Guid,
				"',  ",
				rankScoreModifyLog.OperateType,
				",  ",
				rankScoreModifyLog.CurrentScore,
				",  ",
				rankScoreModifyLog.OperateScore,
				",  ",
				rankScoreModifyLog.LastOperateScore,
				",  '",
				rankScoreModifyLog.Date,
				"',  '",
				Operator.FilterString(rankScoreModifyLog.Memo),
				"',  '",
				rankScoreModifyLog.MemLoginID,
				"',  '",
				rankScoreModifyLog.CreateUser,
				"', '",
				rankScoreModifyLog.CreateTime,
				"',  ",
				rankScoreModifyLog.IsDeleted,
				")"
			});
			list.Add(item);
			int result;
			try
			{
				DatabaseExcetue.RunTransactionSql(list);
				ShopNum1_MemberRank_Action shopNum1_MemberRank_Action = (ShopNum1_MemberRank_Action)LogicFactory.CreateShopNum1_MemberRank_Action();
				DataTable dataTable = shopNum1_MemberRank_Action.SearchNameByScore(Convert.ToInt32(rankScoreModifyLog.LastOperateScore));
				string text = "";
				if (dataTable != null && dataTable.Rows.Count > 0)
				{
					text = dataTable.Rows[0]["Guid"].ToString();
				}
				if (!string.IsNullOrEmpty(text))
				{
					this.ChangeMemberRankGuid(rankScoreModifyLog.MemLoginID, text);
				}
				result = 1;
			}
			catch
			{
				result = 0;
			}
			return result;
		}
		public string GetMemberRankGuidByRankScore(int rankScore)
		{
			string strSql = string.Empty;
			string result = string.Empty;
			strSql = "SELECT \tGuid, \tName, \tScore, \tPayoutCount, \tPayoutMoney   FROM ShopNum1_MemberRank WHERE agentid is null and isagent=0 ORDER BY Score ASC ";
			DataTable dataTable = DatabaseExcetue.ReturnDataTable(strSql);
			int i = 0;
			while (i < dataTable.Rows.Count)
			{
				if (rankScore >= Convert.ToInt32(dataTable.Rows[i]["Score"]))
				{
					if (rankScore != Convert.ToInt32(dataTable.Rows[i]["Score"]))
					{
						if (rankScore > Convert.ToInt32(dataTable.Rows[i]["Score"]))
						{
							result = dataTable.Rows[i]["Guid"].ToString();
						}
						i++;
						continue;
					}
					result = dataTable.Rows[i]["Guid"].ToString();
				}
				else if (i == 0)
				{
					result = dataTable.Rows[0]["Guid"].ToString();
				}
				else
				{
					result = dataTable.Rows[i - 1]["Guid"].ToString();
				}
				return result;
			}
			return result;
		}
		public string GetMemberRankGuidByCostMoney(decimal costMoney)
		{
			string strSql = string.Empty;
			string result = string.Empty;
			strSql = "SELECT \tGuid, \tName, \tScore, \tPayoutCount, \tPayoutMoney   FROM ShopNum1_MemberRank WHERE agentid is null and isagent=0 ORDER BY PayoutMoney ASC ";
			DataTable dataTable = DatabaseExcetue.ReturnDataTable(strSql);
			int i = 0;
			while (i < dataTable.Rows.Count)
			{
				if (!(costMoney < Convert.ToDecimal(dataTable.Rows[i]["PayoutMoney"])))
				{
					if (!(costMoney == Convert.ToDecimal(dataTable.Rows[i]["PayoutMoney"])))
					{
						if (costMoney > Convert.ToDecimal(dataTable.Rows[i]["PayoutMoney"]))
						{
							result = dataTable.Rows[i]["Guid"].ToString();
						}
						i++;
						continue;
					}
					result = dataTable.Rows[i]["Guid"].ToString();
				}
				else if (i == 0)
				{
					result = dataTable.Rows[0]["Guid"].ToString();
				}
				else
				{
					result = dataTable.Rows[i - 1]["Guid"].ToString();
				}
				return result;
			}
			return result;
		}
		public string GetMemberRankGuidByTradeCount(int tradeCount)
		{
			string strSql = string.Empty;
			string result = string.Empty;
			strSql = "SELECT \tGuid, \tName, \tScore, \tPayoutCount, \tPayoutMoney   FROM ShopNum1_MemberRank ORDER BY PayoutCount ASC ";
			DataTable dataTable = DatabaseExcetue.ReturnDataTable(strSql);
			int i = 0;
			while (i < dataTable.Rows.Count)
			{
				if (tradeCount >= Convert.ToInt32(dataTable.Rows[i]["PayoutCount"]))
				{
					if (tradeCount != Convert.ToInt32(dataTable.Rows[i]["PayoutCount"]))
					{
						if (tradeCount > Convert.ToInt32(dataTable.Rows[i]["PayoutCount"]))
						{
							result = dataTable.Rows[i]["Guid"].ToString();
						}
						i++;
						continue;
					}
					result = dataTable.Rows[i]["Guid"].ToString();
				}
				else if (i == 0)
				{
					result = dataTable.Rows[0]["Guid"].ToString();
				}
				else
				{
					result = dataTable.Rows[i - 1]["Guid"].ToString();
				}
				return result;
			}
			return result;
		}
		public DataTable Search(string memLoginID, string date1, string date2, int operateType, int isDeleted)
		{
			string text = string.Empty;
			text = "SELECT \tGuid\t, \tOperateType\t, \tCurrentScore\t, \tOperateScore\t, \tLastOperateScore\t, \tDate\t, \tMemo\t, \tMemLoginID\t, \tCreateUser\t, \tCreateTime\t, \tIsDeleted   FROM ShopNum1_RankScoreModifyLog   WHERE 0=0 ";
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
			text = "SELECT Guid, OperateType\t, CurrentScore, OperateScore, LastOperateScore, Date, Memo, MemLoginID\t, CreateUser, CreateTime, IsDeleted   FROM ShopNum1_RankScoreModifyLog   WHERE 0=0 ";
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
		public DataTable GetDataInfoAdmin(string MemLoginID, int OperateType, string startTime, string endTime, int IsDeleted)
		{
			string text = string.Empty;
			text = "   select * from  ShopNum1_RankScoreModifyLog  where  IsDeleted='" + IsDeleted + "'   ";
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
			text += "   order  by  CreateTime   desc     ";
			return DatabaseExcetue.ReturnDataTable(text);
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
			array2[2] = " Guid,OperateType,CurrentScore,OperateScore,LastOperateScore,Date,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ";
			array[3] = "@tablename";
			array2[3] = "ShopNum1_RankScoreModifyLog";
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
		public int ChangeMemberRankGuid(string MemLoginID, string MemberRankGuid)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new string[]
			{
				"   UPDATE  ShopNum1_Member  SET  MemberRankGuid='",
				MemberRankGuid,
				"'   WHERE   MemLoginID='",
				MemLoginID,
				"'    "
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
	}
}
