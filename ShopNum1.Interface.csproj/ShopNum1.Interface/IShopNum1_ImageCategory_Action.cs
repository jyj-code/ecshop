using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_ImageCategory_Action
	{
		DataTable Search(int fatherid);
		int Delete(string string_0);
		int Insert(string name, string description, string categoryLevel, string fatherID, string family, string user);
		int Update(string guid, string name, string description, string categoryLevel, string fatherID, string family, string user);
		DataTable SearchInfoByID(string strID);
		DataTable ImageCategoryGetAllByFatherID(string fatherid);
		int DeleteType(string strId);
	}
}
