using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.Interface
{
	public interface IShopNum1_Dept_Action
	{
		DataTable Search(int IsDeleted);
		DataTable Search(string deptGuid, int IsDeleted);
		int Add(ShopNum1_Dept dept);
		int Add(ShopNum1_Dept dept, string userGuid);
		int Update(ShopNum1_Dept dept, List<string> strUserList);
		int Delete(string guids);
	}
}
