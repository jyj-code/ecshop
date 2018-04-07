using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_ShopProductPropValue_Action
	{
		int GetMaxOrderId();
		bool Exists(int ID);
		DataTable GetPropValuesByPropID(string string_0);
		DataTable BindProductProp(string Code);
		string GetPropValue(string strID);
		int DeleteShopPropValue(string strId);
	}
}
