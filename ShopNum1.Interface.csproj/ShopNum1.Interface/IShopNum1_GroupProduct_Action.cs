using System;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_GroupProduct_Action
	{
		DataTable SelectGroupByAId(string pagesize, string currentpage, string condition, string resultnum);
		int DeleteButch(string strId);
		int UpdateGroupState(string strId, string strState);
		int UpdateGroupAState(string strId, string strState);
		DataTable SelectGroupList(string pagesize, string currentpage, string condition, string resultnum, string strordercolumn, string strsortvalue);
		DataTable GetGroupProductData(int start, int int_0);
	}
}
