using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_Spec_Action
	{
		DataTable Search(string name);
		DataTable Search_Type_Spec(string strId);
		int Delete(string strguid);
		int Add(ShopNum1_Spec shopNum1_Spec, List<ShopNum1_SpecValue> listSpecValue);
		DataTable SearchName(string guids);
		int DeleteValue(string dguid);
		int Update(ShopNum1_Spec shopNum1_Spec, List<ShopNum1_SpecValue> listSpecValue);
		DataTable SpecDetailsGetByTbPropValue(string tbpropvalue);
		int GetMaxGuid();
		DataTable SearchByGuid(string guid);
		DataTable SearchNameByGuid(string strGuid);
		DataTable GetTbCid(string string_0);
		int AddTbCat(string string_0, string name, string CreateTime);
		DataTable SpecificationDetailsGetByTbPropValue(string tbpropvalue);
	}
}
