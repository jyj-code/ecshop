using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_KeyWords_Action
	{
		int Add(ShopNum1_KeyWords shopnum1_keywords);
		int Delete(string guid);
		int Update(string guid, ShopNum1_KeyWords shopnum1_keywords);
		DataTable Search(string name, string count, int type, int ifshow, int isDelete);
		DataTable GetEditInfo(string guid);
		DataTable SearchName(int count, int type);
		DataTable CheckIsExist(string name, int type);
		int UpdateCount(string name, int type, int count);
	}
}
