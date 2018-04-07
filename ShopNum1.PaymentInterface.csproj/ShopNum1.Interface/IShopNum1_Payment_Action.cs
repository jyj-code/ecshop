using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_Payment_Action
	{
		DataTable Search(int isDeleted);
		DataTable SearchMobile(int isDeleted);
		int UpdateMobile(ShopNum1_MobilePayment payment, string guid, int isDeleted);
		int DeleteMobile(string guids);
		DataTable Search();
		DataTable SearchPre();
		int Add(ShopNum1_Payment payment);
		int Delete(string guids);
		DataTable SearchPayInfo(string guid, int delete);
		int Update(ShopNum1_Payment payment, string guid, int isDeleted);
		string GetPaymentType(string guid);
		DataTable GetPaymentInfoByGuid(string guid);
		DataTable GetPaymentKey(string paymentType);
		string GetShopPayMentByGuid(string guid);
		int UpdataShopPayMentByGuid(string guid, string IsPayMentShop);
		int InsertPayRecord(ShopNum1_ThreePaymentRecord record);
		List<ShopNum1_ThreePaymentRecord> SelectPaymentRecords();
	}
}
