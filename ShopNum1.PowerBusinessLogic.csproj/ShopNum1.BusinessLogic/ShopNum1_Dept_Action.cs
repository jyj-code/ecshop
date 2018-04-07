using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_Dept_Action : IShopNum1_Dept_Action
	{
		public DataTable Search(int isDeleted)
		{
			string strSql = string.Empty;
			strSql = "SELECT Guid, Name, ShortName, CreateUser, CreateTime, ModifyUser, ModifyTime, IsDeleted FROM ShopNum1_Dept WHERE (IsDeleted = " + isDeleted + ") Order by CreateTime Desc";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable Search(string deptGuid, int isDeleted)
		{
			string text = string.Empty;
			text = "SELECT Guid, Name, ShortName, CreateUser, CreateTime, ModifyUser, ModifyTime, IsDeleted FROM ShopNum1_Dept WHERE 0=0";
			if (deptGuid != string.Empty && deptGuid != "-1")
			{
				text = text + " AND Guid=" + deptGuid;
			}
			if (isDeleted == 0 || isDeleted == 1)
			{
				text = string.Concat(new object[]
				{
					text,
					" AND IsDeleted=",
					isDeleted,
					" "
				});
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int Add(ShopNum1_Dept dept)
		{
			string strSql = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_Dept( Guid,  Name, ShortName, CreateUser, CreateTime, ModifyUser, ModifyTime,  IsDeleted ) VALUES (  '",
				dept.Guid,
				"',  '",
				Operator.FilterString(dept.Name),
				"',  '",
				Operator.FilterString(dept.ShortName),
				"',  '",
				dept.CreateUser,
				"', '",
				dept.CreateTime,
				"',  '",
				dept.ModifyUser,
				"' , '",
				dept.ModifyTime,
				"',  ",
				dept.IsDeleted,
				")"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Add(ShopNum1_Dept dept, string userguids)
		{
			string item = string.Empty;
			List<string> list = new List<string>();
			item = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_Dept( Guid,  Name, ShortName, CreateUser, CreateTime, ModifyUser, ModifyTime,  IsDeleted ) VALUES (  '",
				dept.Guid,
				"',  '",
				Operator.FilterString(dept.Name),
				"',  '",
				Operator.FilterString(dept.ShortName),
				"',  '",
				dept.CreateUser,
				"', '",
				dept.CreateTime,
				"',  '",
				dept.ModifyUser,
				"' , '",
				dept.ModifyTime,
				"',  ",
				dept.IsDeleted,
				")"
			});
			list.Add(item);
			item = string.Concat(new object[]
			{
				"UPDATE ShopNum1_User SET        DeptGuid = '",
				dept.Guid,
				"' WHERE Guid IN (",
				userguids,
				")"
			});
			list.Add(item);
			int result;
			try
			{
				DatabaseExcetue.RunTransactionSql(list);
				result = 1;
			}
			catch
			{
				result = 0;
			}
			return result;
		}
		public int Delete(string guids)
		{
			string item = string.Empty;
			List<string> list = new List<string>();
			item = string.Concat(new object[]
			{
				"UPDATE ShopNum1_User SET        DeptGuid = '",
				Guid.Empty,
				"' WHERE DeptGuid IN (",
				guids,
				")"
			});
			list.Add(item);
			item = "DELETE FROM ShopNum1_Dept WHERE Guid IN (" + guids + ")";
			list.Add(item);
			int result;
			try
			{
				DatabaseExcetue.RunTransactionSql(list);
				result = 1;
			}
			catch
			{
				result = 0;
			}
			return result;
		}
		public int Update(ShopNum1_Dept dept, List<string> strUserList)
		{
			string item = string.Empty;
			List<string> list = new List<string>();
			item = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_Dept SET  Name='",
				Operator.FilterString(dept.Name),
				"', ShortName='",
				Operator.FilterString(dept.ShortName),
				"', ModifyUser='",
				dept.ModifyUser,
				"', ModifyTime='",
				dept.ModifyTime,
				"' WHERE Guid='",
				dept.Guid,
				"'"
			});
			list.Add(item);
			item = string.Concat(new object[]
			{
				"UPDATE ShopNum1_User SET DeptGuid='",
				Guid.Empty,
				"', ModifyUser='",
				dept.ModifyUser,
				"', ModifyTime='",
				dept.ModifyTime,
				"' WHERE  DeptGuid='",
				dept.Guid,
				"'"
			});
			list.Add(item);
			for (int i = 0; i < strUserList.Count; i++)
			{
				string item2 = string.Empty;
				item2 = string.Concat(new object[]
				{
					"UPDATE ShopNum1_User SET DeptGuid='",
					dept.Guid,
					"', ModifyUser='",
					dept.ModifyUser,
					"', ModifyTime='",
					dept.ModifyTime,
					"' WHERE  Guid='",
					strUserList[i],
					"'"
				});
				list.Add(item2);
			}
			int result;
			try
			{
				DatabaseExcetue.RunTransactionSql(list);
				result = 1;
			}
			catch
			{
				result = 0;
			}
			return result;
		}
	}
}
