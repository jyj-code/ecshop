using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_AttachMent_Action
	{
		DataTable Search(string AssociatedCategoryGuid);
		DataRow SearchAttachMent(string Guid);
		int Delete(string Guid);
		int Insert(ShopNum1_AttachMent shopNum1_AttachMent);
	}
}
