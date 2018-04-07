using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_OrdeComplaints_Action
	{
		DataTable GetOrderComplaints(string ComplaintShop, string type);
		int ComplaintsResult(string guid, string resultes);
		int Delete(string string_0);
		int CancelComplaints(string guid);
		int AddOrderComplaints(string orderguid, string complaintsnum, string orderid, string shopid, string memloginid, string reporttype, string evidence);
		DataTable GetOrderComplaintsDetails(string guid);
		DataTable Search(string memLoginID, string type, string State);
	}
}
