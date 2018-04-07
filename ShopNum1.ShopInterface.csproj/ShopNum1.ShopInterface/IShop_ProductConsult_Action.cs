using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.ShopInterface
{
	public interface IShop_ProductConsult_Action
	{
		DataTable Search(string guid, int IsDeleted, int IsReply, string ShopID);
		int Add(ShopNum1_ShopProductConsult ProductConsult);
		DataTable Search(string ProductName, string IsAudit, string IsReply, string ConsultPeople, string SendTime1, string SendTime2, string ShopID);
		int DeleteByProductGuid(string guids);
		int DeleteByGuid(string guids);
		int Update(ShopNum1_ShopProductConsult ProductConsult);
		DataTable SearchByGuid(string guid);
		DataTable Search(string MemLoginID, int IsDelete, string ShopID);
	}
}
