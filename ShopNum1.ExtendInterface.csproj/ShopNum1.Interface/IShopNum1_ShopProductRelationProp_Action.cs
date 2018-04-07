using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_ShopProductRelationProp_Action
	{
		int GetMaxId();
		bool Exists(int ID);
		int Add(ShopNum1_ShopProductRelationProp model);
		int Add(List<ShopNum1_ShopProductRelationProp> RelationProps);
		void Update(ShopNum1_ShopProductRelationProp model);
		void Delete(int ID);
		void Delete(Guid guid);
		ShopNum1_ShopProductRelationProp GetModel(int ID);
		DataSet GetList(string strWhere);
		List<ShopNum1_ShopProductRelationProp> GetListArray(string strWhere);
		List<ShopNum1_ShopProductRelationProp> GetListArray(string guid, string PropID, string Memlogid);
		ShopNum1_ShopProductRelationProp ReaderBind(IDataReader dataReader);
		DataTable GetProductPropNameAndID(string guid, string memlogid);
		DataTable GetProductPropValue(string propid, string prodguid);
	}
}
