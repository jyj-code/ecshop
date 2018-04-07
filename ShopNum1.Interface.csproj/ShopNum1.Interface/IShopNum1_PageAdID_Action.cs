using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_PageAdID_Action
	{
		DataTable Search(string pagename);
		DataTable SelectByID(string guid);
		int Add(PageAdID advertisement);
		int Update(PageAdID advertisement);
		int Delete(string guids);
		string GetNewDivID();
		int CheckDivID(string divid);
	}
}
