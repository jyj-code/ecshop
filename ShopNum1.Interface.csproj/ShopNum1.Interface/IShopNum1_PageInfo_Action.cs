using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_PageInfo_Action
	{
		string GetPath();
		void LoadXml();
		DataTable Search(string pagename);
		DataTable SelectByID(string guid);
		int Add(PageInfo pageInfo);
		int Update(PageInfo pageInfo);
		int Delete(string guids);
	}
}
