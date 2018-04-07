using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_Help_Action
	{
		int Add(ShopNum1_Help shopNum1_Help);
		int Update(ShopNum1_Help shopNum1_Help);
		DataTable Search(string title, string type);
		int Delete(string guids);
		DataTable GetEditInfo(string guid);
		DataTable Search(string helpTypeGuid, int isDeleted);
		DataTable Search(string helpTypeGuid, int showCount, int isDeleted);
		DataTable SearchRemark(string guid, int isDeleted);
		DataTable GetHelpMeto(string guid);
		DataSet Search(string productName, string ordername, string soft, string perpagenum, string current_page, string isreturcount);
	}
}
