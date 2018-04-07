using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_ComplaintsManagement_Action
	{
		DataTable Search(string memLoginID, string type);
		DataTable GetShopNum1_ComplaintsReply(string guid);
		int ComplaintsResult(string guid, string resultes);
		int Delete(string guid);
		int DeleteReport(string ID);
		int AddComplaintsManagement(string productguid, string shopid, string memloginid, string reporttype, string evidence, string remark);
		DataTable GetComplaintsManagement(string memloginid, string type);
		DataSet GetComplaintsManagementDetail(string guid);
		DataTable GetProductNamebyguid(string guid);
	}
}
