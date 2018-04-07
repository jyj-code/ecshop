using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_OrderExpress_Action
	{
		DataTable Search();
		DataTable SearchByIsDefault();
		int Edit(string name, int IsDefault, string hidden, string imgPath, string guid);
		int Delete(string guid);
		int Add(string guid, string name, int isDefault, string hidden, string imgPath, string string_0);
		DataTable SearchByLogisticsID(string string_0);
	}
}
