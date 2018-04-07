using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_SurveyTheme_Action : IShopNum1_SurveyTheme_Action
	{
		public int Add(ShopNum1_SurveyTheme shopNum1_SurveyTheme)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"insert shopNum1_SurveyTheme(Guid,Title,StartTime,EndTime,SimplyOrMultiCheck) values('",
				shopNum1_SurveyTheme.Guid,
				"','",
				shopNum1_SurveyTheme.Title,
				"','",
				shopNum1_SurveyTheme.StartTime,
				"','",
				shopNum1_SurveyTheme.EndTime,
				"',",
				shopNum1_SurveyTheme.SimplyOrMultiCheck,
				")"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetEditInfo(string guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT  Title, StartTime, EndTime, SimplyOrMultiCheck FROM shopNum1_SurveyTheme Where Guid=" + guid;
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int Update(string guid, ShopNum1_SurveyTheme shopNum1_SurveyTheme)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"update shopNum1_SurveyTheme set Title='",
				Operator.FilterString(shopNum1_SurveyTheme.Title),
				"',StartTime='",
				shopNum1_SurveyTheme.StartTime,
				"',EndTime='",
				shopNum1_SurveyTheme.EndTime,
				"',SimplyOrMultiCheck=",
				shopNum1_SurveyTheme.SimplyOrMultiCheck,
				" where Guid=",
				guid
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Delete(string guids)
		{
			string strSql = string.Empty;
			strSql = "DELETE FROM shopNum1_SurveyTheme WHERE Guid IN (" + guids + ")";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable Search(string name)
		{
			string text = string.Empty;
			text = "SELECT Guid, Title, StartTime, EndTime, Count from ShopNum1_SurveyTheme Where 0=0";
			if (name != string.Empty)
			{
				text = text + " AND Title LIKE '%" + Operator.FilterString(name) + "%'";
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable SearchFirst(string startTime, string endTime)
		{
			string text = string.Empty;
			text = "SELECT top 1 Guid, Title, StartTime,SimplyOrMultiCheck,EndTime,Count from ShopNum1_SurveyTheme Where 0=0 ";
			if (Operator.FormatToEmpty(startTime.ToString()) != string.Empty)
			{
				text = text + " AND StartTime<='" + Operator.FilterString(startTime) + "' ";
			}
			if (Operator.FormatToEmpty(endTime.ToString()) != string.Empty)
			{
				text = text + " AND EndTime>='" + Operator.FilterString(endTime) + "' ";
			}
			text += "ORDER BY  StartTime DESC";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int GetMaxCount(string surveyGuid)
		{
			string strSql = string.Empty;
			strSql = "SELECT Count FROM ShopNum1_SurveyTheme WHERE Guid='" + surveyGuid + "' ";
			return Convert.ToInt32(DatabaseExcetue.ReturnDataTable(strSql).Rows[0]["Count"].ToString());
		}
		public int GetSurveyOptionMaxCount(string surveyOptionGuid)
		{
			string strSql = string.Empty;
			strSql = "SELECT Count FROM ShopNum1_SurveyOption WHERE Guid='" + surveyOptionGuid + "' ";
			return Convert.ToInt32(DatabaseExcetue.ReturnDataTable(strSql).Rows[0]["Count"].ToString());
		}
		public int SurveyAdd(string surveyGuid, string surveyOptionGuid)
		{
			string item = string.Empty;
			List<string> list = new List<string>();
			item = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_SurveyTheme SET \t Count =",
				Convert.ToInt32(this.GetMaxCount(surveyGuid) + 1),
				" WHERE Guid='",
				surveyGuid,
				"'"
			});
			list.Add(item);
			item = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_SurveyOption SET \t Count =",
				Convert.ToInt32(this.GetSurveyOptionMaxCount(surveyOptionGuid) + 1),
				" WHERE Guid='",
				surveyOptionGuid,
				"'"
			});
			list.Add(item);
			int result;
			try
			{
				DatabaseExcetue.RunTransactionSql(list);
				result = 1;
			}
			catch
			{
				result = 0;
			}
			return result;
		}
		public DataTable SearchSurveyOption(string surveyGuid)
		{
			string strSql = string.Empty;
			strSql = "SELECT A.Name,A.Count,A.SurveyGuid,B.Count AS AllCount,B.Title  FROM  ShopNum1_SurveyOption AS A,ShopNum1_SurveyTheme AS B WHERE  A. SurveyGuid = B.Guid AND A. SurveyGuid='" + surveyGuid + "' ";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
	}
}
