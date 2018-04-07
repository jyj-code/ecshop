using System;
namespace ShopNum1.ShopInterface
{
	public interface IShop_Common_Action
	{
		int ReturnMaxID(string orderID, string tableName);
		int ReturnMaxID(string columnName, string shopID, string shopIDValue, string tableName);
		int ReturnMaxIDByMemLoginID(string MemLoginID);
		string ComputeDispatchPrice(string formula);
		string ComputeOderPrice(string orderPrice);
		string ComputeInvoicePrice(string invoiceTax);
		string ComputeDiscountPrice(string discount);
	}
}
