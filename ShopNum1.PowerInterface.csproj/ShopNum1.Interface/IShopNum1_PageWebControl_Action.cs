using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_PageWebControl_Action
	{
		DataTable Search(string pageGuid, string guid, int isDeleted);
		int Add(ShopNum1_PageWebControl pageWebControl);
		int Update(ShopNum1_PageWebControl pageWebControl);
		int Delete(string guids);
	}
}
