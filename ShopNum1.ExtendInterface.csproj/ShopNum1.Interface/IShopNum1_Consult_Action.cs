using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_Consult_Action
	{
		int Add();
		DataTable Search(string guid, int IsDeleted, int IsReply);
		DataTable Search(string ProductName, int IsReply, string ConsultPeople, string SendTime1, string SendTime2);
		int Delete(string guids);
		DataTable SearchByGuid(string guid);
		DataTable Search(string MemLoginID, int IsDelete);
		DataTable SearchByConsultGuid(string guid);
	}
}
