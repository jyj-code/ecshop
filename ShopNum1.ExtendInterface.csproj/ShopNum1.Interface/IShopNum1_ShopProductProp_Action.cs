using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_ShopProductProp_Action
	{
		int GetMaxOrderId();
		bool Exists(int ID);
		int Add(ShopNum1_ShopProductProp model, List<ShopNum1_ShopProductPropValue> shopProductPropValue);
		DataTable Search_Type_Prop(string strId);
		DataTable SelectProByProductGuid(string strGuid);
		DataTable GetSearchListPropByCode(string Code);
		int Delete(string string_0);
		ShopNum1_ShopProductProp GetPropModelByID(int ID);
		ShopNum1_ShopProductProp ReaderBind(IDataReader dataReader);
	}
}
