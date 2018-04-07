using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_VideoCategory_Action
	{
		int GetMaxID();
		DataTable Search(int isDeleted);
		DataTable Search(int fatherID, int isDeleted);
		int Add(ShopNum1_VideoCategory productCategory);
		int Update(ShopNum1_VideoCategory productCategory);
		int Delete(string string_0);
		DataTable SearchInfoByID(string strID);
		DataTable Search(int fatherID, int isDeleted, int count);
		DataTable Search2(int fatherID, int isDeleted);
	}
}
