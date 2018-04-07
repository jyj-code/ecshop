using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_SurveyOption_Action
	{
		int Add(ShopNum1_SurveyOption shopnum1_surveyoption);
		DataTable Search(string name);
		int Delete(string guids);
	}
}
