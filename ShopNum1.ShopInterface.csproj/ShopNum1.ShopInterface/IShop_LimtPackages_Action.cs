using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.ShopInterface
{
	public interface IShop_LimtPackages_Action
	{
		int AddLimtPackage(ShopNum1_Limt_Package shopNum1__Limt_Package);
		DataTable SelectLimtPackage(string pagesize, string currentpage, string condition, string resultnum);
		string ReturnDate(string MemloginId);
		DataTable SelectLastPack(string MemloginId);
		int DeletePackById(string MemloginId, string strAid);
	}
}
