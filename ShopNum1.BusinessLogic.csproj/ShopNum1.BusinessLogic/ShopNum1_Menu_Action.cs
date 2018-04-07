using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_Menu_Action : IShopNum1_Menu_Action
	{
		public int Add(ShopNum1_Menu shopnum1_menu)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_Menu( Guid, Name, Code, OrderID, TypeCode, State, CreateUser, CreateTime, ModifyUser, ModifyTime,  IsDeleted ) VALUES (  '",
				shopnum1_menu.Guid,
				"',  '",
				Operator.FilterString(shopnum1_menu.Name),
				"',  '",
				Operator.FilterString(shopnum1_menu.Code),
				"',  ",
				shopnum1_menu.OrderID,
				",  '",
				Operator.FilterString(shopnum1_menu.TypeCode),
				"',  ",
				shopnum1_menu.State,
				",  '",
				shopnum1_menu.CreateUser,
				"', '",
				shopnum1_menu.CreateTime,
				"',  '",
				shopnum1_menu.ModifyUser,
				"' , '",
				shopnum1_menu.ModifyTime,
				"',  ",
				shopnum1_menu.IsDeleted,
				")"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetMenuInfo()
		{
			string strSql = string.Empty;
			strSql = "select typename as name ,typecode as code from ShopNum1_MenuType ";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int Update(string guid, ShopNum1_Menu shopnum1_menu)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE  ShopNum1_Menu SET  Name='",
				Operator.FilterString(shopnum1_menu.Name),
				"', Code='",
				Operator.FilterString(shopnum1_menu.Code),
				"', OrderID=",
				shopnum1_menu.OrderID,
				", Typecode='",
				Operator.FilterString(shopnum1_menu.TypeCode),
				"', State=",
				shopnum1_menu.State,
				", ModifyUser='",
				shopnum1_menu.ModifyUser,
				"', ModifyTime='",
				shopnum1_menu.ModifyTime,
				"'WHERE Guid=",
				guid
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable Search(string name, int state, string typecode)
		{
			string text = string.Empty;
			text = "SELECT A.Guid, A.Name, A.Code,A.OrderID,B.TypeName,A.State FROM ShopNum1_Menu A left join ShopNum1_MenuType B on A.TypeCode=B.TypeCode Where 0=0";
			if (Operator.FormatToEmpty(name) != string.Empty)
			{
				text = text + " AND A.Name LIKE '%" + Operator.FilterString(name) + "%'";
			}
			if (state != -1)
			{
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					" AND A.state LIKE '%",
					state,
					"%'"
				});
			}
			if (typecode != "-1")
			{
				text = text + " AND a.TypeCode LIKE '%" + Operator.FilterString(typecode) + "%'";
			}
			text += "Order By OrderID Desc";
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public int Delete(string guids)
		{
			string strSql = string.Empty;
			strSql = "select state from ShopNum1_Menu where guid in (" + guids + ")";
			DataTable dataTable = DatabaseExcetue.ReturnDataTable(strSql);
			int result;
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				if (dataTable.Rows[i]["state"].ToString() == "0")
				{
					result = -1;
					return result;
				}
			}
			strSql = "delete from ShopNum1_Menu  WHERE Guid IN (" + guids + ") ";
			result = DatabaseExcetue.RunNonQuery(strSql);
			return result;
		}
		public DataTable GetEditInfo(string guid)
		{
			string strSql = string.Empty;
			strSql = "SELECT  Name, Code,OrderID,TypeCode,State,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted FROM ShopNum1_Menu where guid=" + guid;
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable Search(string type)
		{
			string strSql = string.Empty;
			strSql = "select name,code from ShopNum1_Menu where TypeCode='" + Operator.FilterString(type) + "'";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
	}
}
