using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_AttachMentCategory_Action
	{
		DataTable Search();
		int Delete(string guid);
		DataRow EditShow(string guid);
		int Update(ShopNum1_AttachMentCateGory shopNum1_AttachMentCateGory);
		int Insert(ShopNum1_AttachMentCateGory shopNum1_AttachMentCateGory);
	}
}
