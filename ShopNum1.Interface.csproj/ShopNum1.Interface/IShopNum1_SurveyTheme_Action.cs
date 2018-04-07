using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_SurveyTheme_Action
	{
		int Add(ShopNum1_SurveyTheme shopNum1_SurveyTheme);
		int Delete(string guids);
		int Update(string guid, ShopNum1_SurveyTheme shopnum1_surveytheme);
		DataTable GetEditInfo(string guid);
		DataTable Search(string name);
		DataTable SearchFirst(string startTime, string endTime);
		int GetMaxCount(string surveyGuid);
		int GetSurveyOptionMaxCount(string surveyOptionGuid);
		int SurveyAdd(string surveyGuid, string surveyOptionGuid);
		DataTable SearchSurveyOption(string surveyGuid);
	}
}
