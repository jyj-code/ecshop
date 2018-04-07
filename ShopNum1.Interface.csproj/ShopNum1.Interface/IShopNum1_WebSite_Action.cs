using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_WebSite_Action
	{
		bool Insert(ShopNum1_WebSite website);
		bool CheckAddressName(string addressname);
		bool Update(ShopNum1_WebSite website);
		int DeleteById(string string_0);
		DataTable GetAllSite();
		DataTable GetSiteByID(string ID);
		object GetDomainByAddressName(string address);
	}
}
