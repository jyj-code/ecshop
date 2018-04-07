using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_Cart_Action
	{
		int Add(ShopNum1_Shop_Cart cart);
		int AddCart(ShopNum1_Shop_Cart shopcart);
		DataTable CheckCartProduct(string memLoginID, string productGuid, string attributes, int isPresent, string guige);
		DataTable SearchByMemLoginID(string memLoginID);
		DataTable SearchByMemLoginID(string memLoginID, string SellName);
		DataTable SearchBuyPriceByMemLoginID(string memLoginID);
		DataTable SearchByMemLoginID(string memLoginID, int cartType);
		int Update(List<ShopNum1_Shop_Cart> listCart);
		int Delete(string guids);
		int DeleteByMemLoginID(string memLoginID);
		int GetProductCount(string memLoginID, string productGuid);
		DataTable SearchByShopMemID(string memLoginID, string shopName);
		DataTable SearchShopByMemLoginID(string memLoginID);
		DataTable SearchByPostPrice(string memLoginID, string shopName);
		int GetMemCartCount(string memLoginID);
		DataTable SearchByMemLoginIDShopID(string memLoginID, string Shopid);
		int AddOrder(List<ShopNum1_Shop_Cart> cart);
		int UpdateCar(List<ShopNum1_Shop_Cart> listCart);
		DataTable CheckMemberLoginID(string memLoginID);
		DataTable CheckRepertoryCount(string guid);
		DataTable GetProductInfoByCartProductGuid(string MemloginID, string ShopID, string ProGuID);
		DataTable SearchByMemLoginIDAndShopID(string memLoginID, string ShopID);
		DataTable GetGroupPriceByProductGuid(string productguid);
		DataTable SearchShopByMemLoginID(string memLoginID, string guids);
		DataTable SearchByShopMemID(string memLoginID, string shopName, string guids);
		DataTable SearchByMemLoginIDAndShopID(string memLoginID, string ShopID, string guids);
		int DeleteByMemLoginID(string memLoginID, string guids);
		DataTable GetInfoByGuid(string guid);
	}
}
