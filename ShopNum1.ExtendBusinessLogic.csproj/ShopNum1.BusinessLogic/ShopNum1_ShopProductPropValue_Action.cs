using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_ShopProductPropValue_Action : IShopNum1_ShopProductPropValue_Action
	{
		public int GetMaxOrderId()
		{
			string commandText = "select max(OrderID)+1 from ShopNum1_ShopProductPropValue";
			SqlDatabase sqlDatabase = DatabaseExcetue.GetSqlDatabase();
			object obj = sqlDatabase.ExecuteScalar(CommandType.Text, commandText);
			int result;
			if (obj != null && obj != DBNull.Value)
			{
				result = int.Parse(obj.ToString());
			}
			else
			{
				result = 1;
			}
			return result;
		}
		public bool Exists(int ID)
		{
			SqlDatabase sqlDatabase = DatabaseExcetue.GetSqlDatabase();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select count(1) from ShopNum1_ShopProductPropValue where ID=@ID ");
			DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(stringBuilder.ToString());
			sqlDatabase.AddInParameter(sqlStringCommand, "ID", DbType.Int32, ID);
			object obj = sqlDatabase.ExecuteScalar(sqlStringCommand);
			int num;
			if (object.Equals(obj, null) || object.Equals(obj, DBNull.Value))
			{
				num = 0;
			}
			else
			{
				num = int.Parse(obj.ToString());
			}
			return num != 0;
		}
		public int Update(List<ShopNum1_ShopProductPropValue> ShopProductPropValue)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update ShopNum1_ShopProductPropValue set ");
			stringBuilder.Append("PropId=@PropId,");
			stringBuilder.Append("Name=@Name,");
			stringBuilder.Append("OrderID=@OrderID");
			stringBuilder.Append(" where ID=@ID ");
			Database sqlDatabase = DatabaseExcetue.GetSqlDatabase();
			DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(stringBuilder.ToString());
			int num = 0;
			foreach (ShopNum1_ShopProductPropValue current in ShopProductPropValue)
			{
				sqlDatabase.AddInParameter(sqlStringCommand, "ID", DbType.Int32, current.ID);
				sqlDatabase.AddInParameter(sqlStringCommand, "PropId", DbType.Int32, current.PropId);
				sqlDatabase.AddInParameter(sqlStringCommand, "Name", DbType.String, current.Name);
				sqlDatabase.AddInParameter(sqlStringCommand, "OrderID", DbType.Int32, current.OrderID);
				object obj = sqlDatabase.ExecuteScalar(sqlStringCommand);
				if (!int.TryParse(obj.ToString(), out num))
				{
					num++;
				}
			}
			return num;
		}
		public DataTable GetPropValuesByPropID(string string_0)
		{
			string strSql = string.Empty;
			strSql = string.Format("SELECT ID,Name,orderid FROM ShopNum1_ShopProductPropValue WHERE PropId={0} order by orderid asc", string_0);
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable BindProductProp(string Code)
		{
			string strSql = string.Empty;
			strSql = "SELECT ID,PropName FROM ShopNum1_ShopProductProp";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable BindProductPropValue(string PropId)
		{
			string text = string.Empty;
			text = "SELECT ID,Name,PropID FROM ShopNum1_ShopProductPropValue WHERE 1=1 And Id in(select PropValueID from ShopNum1_ShopProRelateProp) ";
			if (PropId != "")
			{
				text = text + " And  PropId=" + PropId;
			}
			return DatabaseExcetue.ReturnDataTable(text);
		}
		public DataTable dt_SubProp(string strProId, string strPid)
		{
			DataTable result;
			try
			{
				strPid = ((strPid == "" || strPid == "0" || strPid.Length != 36) ? "null" : ("'" + strPid + "'"));
				string strSql = string.Concat(new string[]
				{
					"SELECT id,PropId,name,(SELECT top 1 InputValue FROM ShopNum1_ShopProRelateProp WHERE PropValueID=t.id and productguid=",
					strPid,
					")iv,(SELECT TOP 1 'true' FROM ShopNum1_ShopProRelateProp WHERE PropValueID=t.id and productguid=",
					strPid,
					")vcheck FROM ShopNum1_ShopProductPropValue t where PropId='",
					strProId,
					"' ORDER BY orderid asc"
				});
				result = DatabaseExcetue.ReturnDataTable(strSql);
			}
			catch
			{
				string strSql = "SELECT id,PropId,name,''iv,''vcheck FROM ShopNum1_ShopProductPropValue t WHERE PropId='" + strProId + "' ORDER BY OrderId ASC";
				result = DatabaseExcetue.ReturnDataTable(strSql);
			}
			return result;
		}
		public string GetPropValue(string strID)
		{
			string strSql = "select name from ShopNum1_ShopProductPropValue where id='" + strID + "'";
			return DatabaseExcetue.ReturnString(strSql);
		}
		public int DeleteShopPropValue(string strId)
		{
			string strSql = "Delete from ShopNum1_ShopProductPropValue where id='" + strId + "'";
			return DatabaseExcetue.RunNonQuery(strSql);
		}
	}
}
