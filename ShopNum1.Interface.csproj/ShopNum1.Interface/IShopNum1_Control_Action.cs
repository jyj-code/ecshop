using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_Control_Action
	{
		DataTable Search(string PageName);
		DataTable GetEditInfo(string guid);
		int Delete(string guid);
		int Insert(ShopNum1_Control shopNum1_Control);
		int Update(ShopNum1_Control shopNum1_Control);
		DataTable GetControlGuid(string controlKey);
	}
}
