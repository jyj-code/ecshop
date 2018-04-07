using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_City_Action
	{
		DataTable Search(int isDeleted);
		DataTable Search(int fatherID, int isDeleted);
		int Add(ShopNum1_City city);
		int Delete(string string_0);
		int Update(ShopNum1_City city);
		DataTable SearchInfoByID(string strID);
		DataTable GetProductCategoryMeto(string strID);
		DataTable Search(int fatherID, int isDeleted, int count);
		DataTable Search2(int fatherID, int isDeleted);
		DataTable Search2(string showCount, int fatherID, int isDeleted);
		string GetNameByID(int int_0);
		DataTable GetTableByID(int int_0);
		DataTable GetCategoryByParam(string param);
		DataTable CheckIsChilds(string Field, string TableName, string ID);
		string GetCodeBylevel(int level, int fatherID);
		string GetCfCode();
		string GetCsCode(string AddressCode);
		string GetCtCode(string AddressCode);
		string GetCmCode(string AddressCode);
		DataTable SearchHotCity(string showCount);
		DataTable SearchCityLetter();
		DataTable SearchCityByLetter(string Letter);
		DataTable IsHost(string string_0);
		DataTable GetDispatchRegionName(string AddressCode);
	}
}
