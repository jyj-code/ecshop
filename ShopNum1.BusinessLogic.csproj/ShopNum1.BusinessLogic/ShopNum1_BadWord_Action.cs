using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Text;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_BadWord_Action : IShopNum1_BadWord_Action
	{
		public int Add(ShopNum1_BadWords shopNum1_BadWord)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("insert into ShopNum1_BadWords(");
			stringBuilder.Append(" CreateUser,");
			stringBuilder.Append(" find,");
			stringBuilder.Append(" replacement ");
			stringBuilder.Append(")");
			stringBuilder.Append(" values (");
			stringBuilder.Append("'" + shopNum1_BadWord.CreateUser + "',");
			stringBuilder.Append("'" + shopNum1_BadWord.find + "',");
			stringBuilder.Append("'" + shopNum1_BadWord.replacement + "'");
			stringBuilder.Append(")");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public int Updata(ShopNum1_BadWords shopNum1_BadWord)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update ShopNum1_BadWords set ");
			stringBuilder.Append("CreateUser='" + shopNum1_BadWord.CreateUser + "', ");
			stringBuilder.Append("find='" + shopNum1_BadWord.find + "', ");
			stringBuilder.Append("replacement='" + shopNum1_BadWord.replacement + "' ");
			stringBuilder.Append(" where id=" + shopNum1_BadWord.id + " ");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public DataTable Edit(int int_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT * FROM ShopNum1_BadWords WHERE ID=" + int_0);
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public int Delete(string string_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("DELETE FROM ShopNum1_BadWords WHERE ID IN(" + string_0 + ")");
			return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
		}
		public DataTable SearchByName(string name)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT * FROM ShopNum1_BadWords WHERE 0=0");
			if (Operator.FilterString(name) != "")
			{
				stringBuilder.Append(" AND find like '%" + name + "%'");
			}
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
		public DataTable CheckIsExists(string find, string replacement)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(string.Concat(new string[]
			{
				"SELECT COUNT(*) FROM ShopNum1_BadWords WHERE find='",
				find,
				"' AND replacement='",
				replacement,
				"'"
			}));
			return DatabaseExcetue.ReturnDataTable(stringBuilder.ToString());
		}
	}
}
