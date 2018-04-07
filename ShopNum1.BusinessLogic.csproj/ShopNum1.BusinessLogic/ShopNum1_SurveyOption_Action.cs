using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_SurveyOption_Action : IShopNum1_SurveyOption_Action
	{
		public DataTable Search(string guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT Guid, Name, Count from ShopNum1_SurveyOption Where SurveyGuid= " + guid + " ORDER BY Count DESC";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int Delete(string guids)
		{
			string strSql = string.Empty;
			strSql = "delete from ShopNum1_SurveyOption where guid in (" + guids + ")";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Add(ShopNum1_SurveyOption shopNum1_surveyoption)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"insert ShopNum1_SurveyOption(guid,surveyguid,name,count) values('",
				shopNum1_surveyoption.Guid,
				"',",
				shopNum1_surveyoption.SurveyGuid,
				",'",
				Operator.FilterString(shopNum1_surveyoption.Name),
				"','0')"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
	}
}
