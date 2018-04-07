using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Text;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_Logistic_Action : IShopNum1_Logistic_Action
	{
		public bool Exists(string code)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select count(1) from ShopNum1_Logistics");
			stringBuilder.Append(" where ValueCode='" + code + "'");
			string s = DatabaseExcetue.ReturnString(stringBuilder.ToString());
			return int.Parse(s) == 0;
		}
		public int Add(ShopNum1_Logistic shopNum1_Logistic)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("insert into ShopNum1_Logistics(");
			stringBuilder.Append("Name,ValueCode,Description,IsShow");
			stringBuilder.Append(")");
			stringBuilder.Append(" values (");
			stringBuilder.Append("'" + shopNum1_Logistic.Name + "',");
			stringBuilder.Append("'" + shopNum1_Logistic.ValueCode + "',");
			stringBuilder.Append("'" + shopNum1_Logistic.Description + "',");
			stringBuilder.Append(" " + shopNum1_Logistic.IsShow + " ");
			stringBuilder.Append(")");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public int Update(ShopNum1_Logistic shopNum1_Logistic)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update ShopNum1_Logistics set ");
			stringBuilder.Append("Name='" + shopNum1_Logistic.Name + "',");
			stringBuilder.Append("ValueCode='" + shopNum1_Logistic.ValueCode + "',");
			stringBuilder.Append("Description='" + shopNum1_Logistic.Description + "',");
			stringBuilder.Append("IsShow= " + shopNum1_Logistic.IsShow + " ");
			stringBuilder.Append(" where ID=" + shopNum1_Logistic.ID);
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public int Delete(string string_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("delete from ShopNum1_Logistics ");
			stringBuilder.Append(" where ID IN(" + string_0 + ")");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public DataTable GetLogistic(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select   ");
			stringBuilder.Append(" ID,Name,ValueCode,Description,IsShow ");
			stringBuilder.Append(" from ShopNum1_Logistics ");
			if (ID != -1)
			{
				stringBuilder.Append(" where ID=" + ID);
			}
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable GetLogistic(string name)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select   ");
			stringBuilder.Append(" ID,Name,ValueCode,Description,IsShow ");
			stringBuilder.Append(" from ShopNum1_Logistics where 0=0 ");
			if (name != "-1")
			{
				stringBuilder.Append(" AND [Name] like '%" + name + "%'");
			}
			stringBuilder.Append(" ORDER BY ID DESC");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable Search(int isshow)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select   ");
			stringBuilder.Append(" Name,ValueCode ");
			stringBuilder.Append(" from ShopNum1_Logistics where 0=0 ");
			if (isshow != -1)
			{
				stringBuilder.Append(" AND IsShow=" + isshow + " ");
			}
			stringBuilder.Append(" ORDER BY ID DESC");
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
	}
}
