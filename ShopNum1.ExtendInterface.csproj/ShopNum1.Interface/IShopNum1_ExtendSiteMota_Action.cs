using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_ExtendSiteMota_Action
	{
		DataTable SearchMetoList(string pagename);
		DataTable SearchMetoList(string pagename, string path);
		DataTable SelectByName(string PageName, string path);
		int Add(string name, string title, string keywords, string string_0, string path);
		bool check(string PageName, string path);
		int edit(string name, string title, string keywords, string string_0, string path);
		int delete(string names, string path);
	}
}
