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
	public class ShopNum1_ShopProductProp_Action : IShopNum1_ShopProductProp_Action
	{
		public int GetMaxOrderId()
		{
			string strSql = "select max(id) from ShopNum1_ShopProductProp";
			object obj = DatabaseExcetue.ReturnObject(strSql);
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
		public ShopNum1_ShopProductProp GetPropModelByID(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select ID,PropName,ShowType,IsImport,Content,OrderID from ShopNum1_ShopProductProp ");
			stringBuilder.Append(" where ID=@ID ");
			SqlDatabase sqlDatabase = DatabaseExcetue.GetSqlDatabase();
			DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(stringBuilder.ToString());
			sqlDatabase.AddInParameter(sqlStringCommand, "ID", DbType.Int32, ID);
			ShopNum1_ShopProductProp result = null;
			using (IDataReader dataReader = sqlDatabase.ExecuteReader(sqlStringCommand))
			{
				if (dataReader.Read())
				{
					result = this.ReaderBind(dataReader);
				}
			}
			return result;
		}
		public ShopNum1_ShopProductProp ReaderBind(IDataReader dataReader)
		{
			ShopNum1_ShopProductProp shopNum1_ShopProductProp = new ShopNum1_ShopProductProp();
			object obj = dataReader["ID"];
			if (obj != null && obj != DBNull.Value)
			{
				shopNum1_ShopProductProp.ID = (int)obj;
			}
			shopNum1_ShopProductProp.PropName = dataReader["PropName"].ToString();
			obj = dataReader["ShowType"];
			if (obj != null && obj != DBNull.Value)
			{
				shopNum1_ShopProductProp.ShowType = (byte)obj;
			}
			obj = dataReader["IsImport"];
			if (obj != null && obj != DBNull.Value)
			{
				shopNum1_ShopProductProp.IsImport = (bool)obj;
			}
			shopNum1_ShopProductProp.Content = dataReader["Content"].ToString();
			obj = dataReader["OrderID"];
			if (obj != null && obj != DBNull.Value)
			{
				shopNum1_ShopProductProp.OrderID = (int)obj;
			}
			return shopNum1_ShopProductProp;
		}
		public bool Exists(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select count(1) from ShopNum1_ShopProductProp where ID=@ID ");
			SqlDatabase sqlDatabase = DatabaseExcetue.GetSqlDatabase();
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
		public int Add(ShopNum1_ShopProductProp model, List<ShopNum1_ShopProductPropValue> shopProductPropValues)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("insert into ShopNum1_ShopProductProp(");
			stringBuilder.Append("PropName,ShowType,IsImport,Content,OrderID)");
			stringBuilder.Append(" values (");
			stringBuilder.Append("@PropName,@ShowType,@IsImport,@Content,@OrderID)");
			SqlDatabase sqlDatabase = DatabaseExcetue.GetSqlDatabase();
			DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(stringBuilder.ToString());
			sqlDatabase.AddInParameter(sqlStringCommand, "PropName", DbType.String, model.PropName);
			sqlDatabase.AddInParameter(sqlStringCommand, "ShowType", DbType.Byte, model.ShowType);
			sqlDatabase.AddInParameter(sqlStringCommand, "IsImport", DbType.Boolean, model.IsImport);
			sqlDatabase.AddInParameter(sqlStringCommand, "Content", DbType.String, model.Content);
			sqlDatabase.AddInParameter(sqlStringCommand, "OrderID", DbType.Int32, model.OrderID);
			int num = sqlDatabase.ExecuteNonQuery(sqlStringCommand);
			int result;
			if (num <= 0)
			{
				result = 0;
			}
			else if (shopProductPropValues.Count == 0)
			{
				result = 1;
			}
			else
			{
				int maxOrderId = this.GetMaxOrderId();
				StringBuilder stringBuilder2 = new StringBuilder();
				stringBuilder2.Append("insert into ShopNum1_ShopProductPropValue(");
				stringBuilder2.Append("PropId,Name,OrderID)");
				stringBuilder2.Append(" values (");
				stringBuilder2.Append("@PropId,@Name,@OrderID)");
				stringBuilder2.Append(";select @@IDENTITY");
				int num2 = 0;
				foreach (ShopNum1_ShopProductPropValue current in shopProductPropValues)
				{
					sqlStringCommand = sqlDatabase.GetSqlStringCommand(stringBuilder2.ToString());
					sqlDatabase.AddInParameter(sqlStringCommand, "PropId", DbType.Int32, maxOrderId);
					sqlDatabase.AddInParameter(sqlStringCommand, "Name", DbType.String, current.Name);
					sqlDatabase.AddInParameter(sqlStringCommand, "OrderID", DbType.Int32, current.OrderID);
					object obj = sqlDatabase.ExecuteScalar(sqlStringCommand);
					if (!int.TryParse(obj.ToString(), out num2))
					{
						num2++;
					}
				}
				result = num2;
			}
			return result;
		}
		public int Update(ShopNum1_ShopProductProp PropModel, List<ShopNum1_ShopProductPropValue> shopProductPropValues)
		{
			string text = string.Empty;
			string text2 = string.Empty;
			List<string> list = new List<string>();
			text = "update ShopNum1_ShopProductProp set\r\n            PropName='{0}',Content='{1}',ShowType={2},OrderID={3} where id={4}";
			text = string.Format(text, new object[]
			{
				PropModel.PropName,
				PropModel.Content,
				PropModel.ShowType,
				PropModel.OrderID,
				PropModel.ID.ToString()
			});
			list.Add(text);
			if (PropModel.ShowType == Convert.ToByte(4))
			{
				list.Add("delete from ShopNum1_ShopProductPropValue where propid='" + PropModel.ID + "'");
			}
			if (shopProductPropValues != null && shopProductPropValues.Count > 0)
			{
				for (int i = 0; i < shopProductPropValues.Count; i++)
				{
					if (shopProductPropValues[i].ID == 0)
					{
						text2 = "insert into ShopNum1_ShopProductPropValue(PropId,Name,orderid) values({0},'{1}','{2}')";
						text2 = string.Format(text2, shopProductPropValues[i].PropId, shopProductPropValues[i].Name, shopProductPropValues[i].OrderID);
					}
					else
					{
						text2 = "update ShopNum1_ShopProductPropValue set orderid='{0}', Name='{1}' where id={2}";
						text2 = string.Format(text2, shopProductPropValues[i].OrderID, shopProductPropValues[i].Name, shopProductPropValues[i].ID);
					}
					list.Add(text2);
				}
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
		public int Delete(string string_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("delete from ShopNum1_ShopProductProp ");
			stringBuilder.Append(" where ID IN(" + string_0 + ") ");
			SqlDatabase sqlDatabase = DatabaseExcetue.GetSqlDatabase();
			DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(stringBuilder.ToString());
			int num = sqlDatabase.ExecuteNonQuery(sqlStringCommand);
			string strSql = string.Empty;
			strSql = "DELETE FROM ShopNum1_ShopProductPropValue WHERE PropId IN(" + string_0 + ")";
			int num2 = DatabaseExcetue.RunNonQuery(strSql);
			return num + num2;
		}
		public DataTable GetPropByProductCategory(string name)
		{
			string strSql = string.Empty;
			if (name != null)
			{
				strSql = "select ID,PropName,ShowType,IsImport,Content,OrderID,[dbo].[fun_Propstr](id) propDetail FROM ShopNum1_ShopProductProp  where PropName='" + name.Trim().ToString() + "'";
			}
			else
			{
				strSql = " select ID,PropName,ShowType,IsImport,Content,OrderID,[dbo].[fun_Propstr](id) propDetail FROM ShopNum1_ShopProductProp  where 1=1 ";
			}
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable Search_Type_Prop(string strId)
		{
			string strSql = " select ID,PropName,[dbo].[fun_Propstr](id) propDetail,(select top 1 typeid from ShopNum1_TypeProp where typeid='" + strId + "' and propid=t.id)ischeck,ShowType FROM ShopNum1_ShopProductProp as t where 1=1 ";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable dt_GetPro(string strID)
		{
			string strSql = "SELECT ID,PropName,showType FROM ShopNum1_ShopProductProp where id in(select propid from ShopNum1_TypeProp where typeid='" + strID + "')";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable SelectProByProductGuid(string strGuid)
		{
			string strSql = "select PropName,ID,showType from ShopNum1_ShopProductProp where id in (select propid from ShopNum1_ShopProRelateProp where productguid='" + strGuid + "') order by orderid asc";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public DataTable GetSearchListPropByCode(string Code)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@productcode";
			array2[0] = Code;
			return DatabaseExcetue.RunProcedureReturnDataTable("Pro_GetSearchListPropByCode", array, array2);
		}
	}
}
