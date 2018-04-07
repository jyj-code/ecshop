using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_HelpType_Action
	{
		int Add(ShopNum1_HelpType shopNum1_HelpType);
		int Delete(string guids);
		int update(ShopNum1_HelpType shopNum1_HelpType);
		DataTable Search(string name);
		DataTable GetEditInfo(string guid);
		DataTable GetList();
		DataTable Search(string IsDeleted, int showCount);
	}
}
