using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using ShopNum1.Encryption;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
namespace ShopNum1.DataAccess
{
	public class DatabaseExcetue
	{
		private static string string_0 = string.Empty;
		private static string string_1 = string.Empty;
		public static SqlDatabase GetSqlDatabase()
		{
			return new SqlDatabase(DatabaseExcetue.GetConnstring());
		}
		public static string GetConnstring()
		{
			if (DatabaseExcetue.string_0 == string.Empty || DatabaseExcetue.string_1 == string.Empty)
			{
				DatabaseExcetue.string_0 = ConfigurationSettings.AppSettings["IsConnectionEncrypt"];
				if (DatabaseExcetue.string_0 == "1")
				{
					DatabaseExcetue.string_1 = DESEncrypt.Decrypt(ConfigurationManager.ConnectionStrings["ConnectionEncryptString"].ConnectionString);
				}
				else
				{
					DatabaseExcetue.string_1 = ConfigurationManager.ConnectionStrings["Connection String"].ConnectionString;
				}
			}
			return DatabaseExcetue.string_1;
		}
		public static DataTable ReturnDataTable(string strSql)
		{
			SqlDatabase sqlDatabase = DatabaseExcetue.GetSqlDatabase();
			DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(strSql);
			DataTable result = null;
			try
			{
				result = sqlDatabase.ExecuteDataSet(sqlStringCommand).Tables[0];
			}
			catch (Exception exception_)
			{
				DatabaseExcetue.smethod_2(exception_);
			}
			return result;
		}
		public static DataTable ReturnDataTable(string strSql, string[] paraName, string[] paraValue)
		{
			SqlDatabase sqlDatabase = DatabaseExcetue.GetSqlDatabase();
			DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(strSql);
			DbParameter[] parms = DatabaseExcetue.smethod_0(sqlStringCommand, paraName, paraValue);
			DatabaseExcetue.BuildDBParameter(sqlDatabase, sqlStringCommand, parms);
			DataTable result = null;
			try
			{
				result = sqlDatabase.ExecuteDataSet(sqlStringCommand).Tables[0];
			}
			catch (Exception exception_)
			{
				DatabaseExcetue.smethod_2(exception_);
			}
			return result;
		}
		public static DataSet ReturnDataSet(string strSql)
		{
			SqlDatabase sqlDatabase = DatabaseExcetue.GetSqlDatabase();
			DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(strSql);
			try
			{
				return sqlDatabase.ExecuteDataSet(sqlStringCommand);
			}
			catch (Exception exception_)
			{
				DatabaseExcetue.smethod_2(exception_);
			}
			return null;
		}
		public static int RunNonQuery(string strSql)
		{
			SqlDatabase sqlDatabase = DatabaseExcetue.GetSqlDatabase();
			DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(strSql);
			int result;
			try
			{
				result = sqlDatabase.ExecuteNonQuery(sqlStringCommand);
			}
			catch (Exception exception_)
			{
				DatabaseExcetue.smethod_2(exception_);
				result = 1;
			}
			return result;
		}
		public static int RunNonQuery(string strSql, string[] paraName, string[] paraValue)
		{
			SqlDatabase sqlDatabase = DatabaseExcetue.GetSqlDatabase();
			DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(strSql);
			DbParameter[] parms = DatabaseExcetue.smethod_0(sqlStringCommand, paraName, paraValue);
			DatabaseExcetue.BuildDBParameter(sqlDatabase, sqlStringCommand, parms);
			int result;
			try
			{
				result = sqlDatabase.ExecuteNonQuery(sqlStringCommand);
			}
			catch (Exception exception_)
			{
				DatabaseExcetue.smethod_2(exception_);
				result = 0;
			}
			return result;
		}
		public static int RunSqlByTime(string strSql, int time, string[] paraName, string[] paraValue)
		{
			SqlDatabase sqlDatabase = DatabaseExcetue.GetSqlDatabase();
			DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(strSql);
			sqlStringCommand.CommandTimeout = time;
			DbParameter[] parms = DatabaseExcetue.smethod_0(sqlStringCommand, paraName, paraValue);
			DatabaseExcetue.BuildDBParameter(sqlDatabase, sqlStringCommand, parms);
			int result;
			try
			{
				result = sqlDatabase.ExecuteNonQuery(sqlStringCommand);
			}
			catch (Exception exception_)
			{
				DatabaseExcetue.smethod_2(exception_);
				result = 1;
			}
			return result;
		}
		public static int RunSqlByTime(string strSql, int time)
		{
			SqlDatabase sqlDatabase = DatabaseExcetue.GetSqlDatabase();
			DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(strSql);
			sqlStringCommand.CommandTimeout = time;
			int result;
			try
			{
				result = sqlDatabase.ExecuteNonQuery(sqlStringCommand);
			}
			catch (Exception exception_)
			{
				DatabaseExcetue.smethod_2(exception_);
				result = 1;
			}
			return result;
		}
		public static int ReturnMaxID(string FieldName, string TableName)
		{
			SqlDatabase sqlDatabase = DatabaseExcetue.GetSqlDatabase();
			DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand("SELECT MAX([" + FieldName + "]) FROM " + TableName);
			DataTable dataTable = null;
			try
			{
				dataTable = sqlDatabase.ExecuteDataSet(sqlStringCommand).Tables[0];
			}
			catch (Exception exception_)
			{
				DatabaseExcetue.smethod_2(exception_);
			}
			if (dataTable.Rows.Count < 1)
			{
				return 0;
			}
			if (dataTable.Rows[0][0].ToString() != "")
			{
				return int.Parse(dataTable.Rows[0][0].ToString());
			}
			return 0;
		}
		public static int ReturnMaxID(string columnName, string shopID, string shopIDValue, string tableName)
		{
			SqlDatabase sqlDatabase = DatabaseExcetue.GetSqlDatabase();
			DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand("SELECT MAX([" + columnName + "]) FROM " + tableName);
			DataTable dataTable = null;
			try
			{
				dataTable = sqlDatabase.ExecuteDataSet(sqlStringCommand).Tables[0];
			}
			catch (Exception exception_)
			{
				DatabaseExcetue.smethod_2(exception_);
			}
			if (dataTable.Rows.Count < 1)
			{
				return 0;
			}
			if (dataTable.Rows[0][0].ToString() != "")
			{
				return int.Parse(dataTable.Rows[0][0].ToString());
			}
			return 0;
		}
		public static string ReturnString(string strSql)
		{
			SqlDatabase sqlDatabase = DatabaseExcetue.GetSqlDatabase();
			DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(strSql);
			DataTable dataTable = null;
			try
			{
				dataTable = sqlDatabase.ExecuteDataSet(sqlStringCommand).Tables[0];
			}
			catch (Exception exception_)
			{
				DatabaseExcetue.smethod_2(exception_);
			}
			if (dataTable != null && dataTable.Rows.Count != 0)
			{
				return dataTable.Rows[0][0].ToString();
			}
			return "";
		}
		public static object ReturnObject(string strSql, string[] paraName, string[] paraValue)
		{
			SqlDatabase sqlDatabase = DatabaseExcetue.GetSqlDatabase();
			DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(strSql);
			DbParameter[] parms = DatabaseExcetue.smethod_0(sqlStringCommand, paraName, paraValue);
			DatabaseExcetue.BuildDBParameter(sqlDatabase, sqlStringCommand, parms);
			return sqlDatabase.ExecuteScalar(sqlStringCommand);
		}
		public static object ReturnObject(string strSql)
		{
			SqlDatabase sqlDatabase = DatabaseExcetue.GetSqlDatabase();
			DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(strSql);
			return sqlDatabase.ExecuteScalar(sqlStringCommand);
		}
		public static bool CheckExists(string strSql, string[] paraName, string[] paraValue)
		{
			SqlDatabase sqlDatabase = DatabaseExcetue.GetSqlDatabase();
			DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(strSql);
			DbParameter[] parms = DatabaseExcetue.smethod_0(sqlStringCommand, paraName, paraValue);
			DatabaseExcetue.BuildDBParameter(sqlDatabase, sqlStringCommand, parms);
			object obj = sqlDatabase.ExecuteScalar(sqlStringCommand);
			int result;
			if (!object.Equals(obj, null) && !object.Equals(obj, DBNull.Value))
			{
				result = int.Parse(obj.ToString());
			}
			else
			{
				result = 0;
			}
			return result != 0;
		}
		public static bool CheckExists(string strSql)
		{
			SqlDatabase sqlDatabase = DatabaseExcetue.GetSqlDatabase();
			DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(strSql);
			object obj = sqlDatabase.ExecuteScalar(sqlStringCommand);
			int result;
			if (!object.Equals(obj, null) && !object.Equals(obj, DBNull.Value))
			{
				result = int.Parse(obj.ToString());
			}
			else
			{
				result = 0;
			}
			return result != 0;
		}
		public static bool CheckExists(string strSql, params DbParameter[] parms)
		{
			SqlDatabase sqlDatabase = DatabaseExcetue.GetSqlDatabase();
			DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(strSql);
			DatabaseExcetue.BuildDBParameter(sqlDatabase, sqlStringCommand, parms);
			object obj = sqlDatabase.ExecuteScalar(sqlStringCommand);
			int result;
			if (!object.Equals(obj, null) && !object.Equals(obj, DBNull.Value))
			{
				result = int.Parse(obj.ToString());
			}
			else
			{
				result = 0;
			}
			return result != 0;
		}
		public static void BuildDBParameter(SqlDatabase sqlDatabase_0, DbCommand dbCommand, params DbParameter[] parms)
		{
			for (int i = 0; i < parms.Length; i++)
			{
				DbParameter dbParameter = parms[i];
				sqlDatabase_0.AddInParameter(dbCommand, dbParameter.ParameterName, dbParameter.DbType, dbParameter.Value);
			}
		}
		public static DataSet RunProcedureReturnDataSet(string strProcedureName, string[] paraName, string[] paraValue)
		{
			SqlDatabase sqlDatabase = DatabaseExcetue.GetSqlDatabase();
			DbCommand storedProcCommand = sqlDatabase.GetStoredProcCommand(strProcedureName);
			DbParameter[] parms = DatabaseExcetue.smethod_0(storedProcCommand, paraName, paraValue);
			DatabaseExcetue.BuildDBParameter(sqlDatabase, storedProcCommand, parms);
			return sqlDatabase.ExecuteDataSet(storedProcCommand);
		}
		public static DataTable RunProcedureReturnDataTable(string strProcedureName)
		{
			SqlDatabase sqlDatabase = DatabaseExcetue.GetSqlDatabase();
			DbCommand storedProcCommand = sqlDatabase.GetStoredProcCommand(strProcedureName);
			DataSet dataSet = sqlDatabase.ExecuteDataSet(storedProcCommand);
			return dataSet.Tables[0];
		}
		public static DataTable RunProcedureReturnDataTable(string strProcedureName, string paraName, string paraValue)
		{
			SqlDatabase sqlDatabase = DatabaseExcetue.GetSqlDatabase();
			DbCommand storedProcCommand = sqlDatabase.GetStoredProcCommand(strProcedureName);
			DbParameter dbParameter = DatabaseExcetue.smethod_1(storedProcCommand, paraName, paraValue);
			sqlDatabase.AddInParameter(storedProcCommand, dbParameter.ParameterName, dbParameter.DbType, dbParameter.Value);
			DataSet dataSet = sqlDatabase.ExecuteDataSet(storedProcCommand);
			return dataSet.Tables[0];
		}
		public static DataTable RunProcedureReturnDataTable(string strProcedureName, string[] paraName, string[] paraValue)
		{
			SqlDatabase sqlDatabase = DatabaseExcetue.GetSqlDatabase();
			DbCommand storedProcCommand = sqlDatabase.GetStoredProcCommand(strProcedureName);
			DbParameter[] parms = DatabaseExcetue.smethod_0(storedProcCommand, paraName, paraValue);
			DatabaseExcetue.BuildDBParameter(sqlDatabase, storedProcCommand, parms);
			DataSet dataSet = sqlDatabase.ExecuteDataSet(storedProcCommand);
			return dataSet.Tables[0];
		}
		public static int RunProcedure(string strProcedureName)
		{
			SqlDatabase sqlDatabase = DatabaseExcetue.GetSqlDatabase();
			DbCommand storedProcCommand = sqlDatabase.GetStoredProcCommand(strProcedureName);
			return sqlDatabase.ExecuteNonQuery(storedProcCommand);
		}
		public static object RunProcedure(string strProcedureName, DbParameter[] inParameters, DbParameter outParameter, int rowsAffected)
		{
			SqlDatabase sqlDatabase = DatabaseExcetue.GetSqlDatabase();
			DbCommand storedProcCommand = sqlDatabase.GetStoredProcCommand(strProcedureName);
			DatabaseExcetue.BuildDBParameter(sqlDatabase, storedProcCommand, inParameters);
			sqlDatabase.AddOutParameter(storedProcCommand, outParameter.ParameterName, outParameter.DbType, outParameter.Size);
			rowsAffected = sqlDatabase.ExecuteNonQuery(storedProcCommand);
			return sqlDatabase.GetParameterValue(storedProcCommand, "@" + outParameter.ParameterName);
		}
		public static object ReturnProcedureString(string strProcedureName, string[] paraName, string[] paraValue)
		{
			SqlDatabase sqlDatabase = DatabaseExcetue.GetSqlDatabase();
			DbCommand storedProcCommand = sqlDatabase.GetStoredProcCommand(strProcedureName);
			DbParameter[] parms = DatabaseExcetue.smethod_0(storedProcCommand, paraName, paraValue);
			DatabaseExcetue.BuildDBParameter(sqlDatabase, storedProcCommand, parms);
			return sqlDatabase.ExecuteScalar(storedProcCommand);
		}
		public static int RunProcedure(string strProcedureName, string[] paraName, string[] paraValue)
		{
			SqlDatabase sqlDatabase = DatabaseExcetue.GetSqlDatabase();
			DbCommand storedProcCommand = sqlDatabase.GetStoredProcCommand(strProcedureName);
			DbParameter[] parms = DatabaseExcetue.smethod_0(storedProcCommand, paraName, paraValue);
			DatabaseExcetue.BuildDBParameter(sqlDatabase, storedProcCommand, parms);
			return sqlDatabase.ExecuteNonQuery(storedProcCommand);
		}
		private static DbParameter[] smethod_0(DbCommand dbCommand_0, string[] string_2, string[] string_3)
		{
			DbParameter[] array = new DbParameter[string_2.Length];
			for (int i = 0; i < string_2.Length; i++)
			{
				DbParameter dbParameter = dbCommand_0.CreateParameter();
				dbParameter.ParameterName = string_2[i];
				dbParameter.Value = string_3[i];
				array[i] = dbParameter;
			}
			return array;
		}
		private static DbParameter smethod_1(DbCommand dbCommand_0, string string_2, string string_3)
		{
			DbParameter dbParameter = dbCommand_0.CreateParameter();
			dbParameter.ParameterName = string_2;
			dbParameter.Value = string_3;
			return dbParameter;
		}
		public static int RunProcedure(string strProcedureName, string paraName, string paraValue)
		{
			SqlDatabase sqlDatabase = DatabaseExcetue.GetSqlDatabase();
			DbCommand storedProcCommand = sqlDatabase.GetStoredProcCommand(strProcedureName);
			DbParameter dbParameter = DatabaseExcetue.smethod_1(storedProcCommand, paraName, paraValue);
			sqlDatabase.AddInParameter(storedProcCommand, dbParameter.ParameterName, dbParameter.DbType, dbParameter.Value);
			return sqlDatabase.ExecuteNonQuery(storedProcCommand);
		}
		public static SqlDataReader RunProcedure(string strProcedureName, IDataParameter[] parameters)
		{
			SqlDatabase sqlDatabase = DatabaseExcetue.GetSqlDatabase();
			DbCommand storedProcCommand = sqlDatabase.GetStoredProcCommand(strProcedureName, parameters);
			return (SqlDataReader)sqlDatabase.ExecuteReader(storedProcCommand);
		}
		public static void RunTransactionSql(DataTable sqlList)
		{
			SqlDatabase sqlDatabase = DatabaseExcetue.GetSqlDatabase();
			using (DbConnection dbConnection = sqlDatabase.CreateConnection())
			{
				dbConnection.Open();
				DbTransaction dbTransaction = dbConnection.BeginTransaction();
				try
				{
					for (int i = 0; i < sqlList.Rows.Count; i++)
					{
						DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(sqlList.Rows[i][0].ToString());
						sqlDatabase.ExecuteNonQuery(sqlStringCommand);
					}
					dbTransaction.Commit();
				}
				catch (Exception exception_)
				{
					DatabaseExcetue.smethod_2(exception_);
					dbTransaction.Rollback();
				}
			}
		}
		public static void RunTransactionSql(ArrayList sqlList)
		{
			SqlDatabase sqlDatabase = DatabaseExcetue.GetSqlDatabase();
			using (DbConnection dbConnection = sqlDatabase.CreateConnection())
			{
				dbConnection.Open();
				DbTransaction dbTransaction = dbConnection.BeginTransaction();
				try
				{
					for (int i = 0; i < sqlList.Count; i++)
					{
						string text = sqlList[i].ToString();
						if (text.Trim().Length > 1)
						{
							DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(text);
							sqlDatabase.ExecuteNonQuery(sqlStringCommand);
						}
					}
					dbTransaction.Commit();
				}
				catch (Exception exception_)
				{
					DatabaseExcetue.smethod_2(exception_);
					dbTransaction.Rollback();
				}
				finally
				{
					dbConnection.Close();
				}
			}
		}
		public static void RunTransactionSql(Hashtable sqlList)
		{
			SqlDatabase sqlDatabase = DatabaseExcetue.GetSqlDatabase();
			using (DbConnection dbConnection = sqlDatabase.CreateConnection())
			{
				dbConnection.Open();
				DbTransaction dbTransaction = dbConnection.BeginTransaction();
				try
				{
					foreach (DictionaryEntry dictionaryEntry in sqlList)
					{
						string text = dictionaryEntry.Key.ToString();
						DbParameter[] parms = (DbParameter[])dictionaryEntry.Value;
						if (text.Trim().Length > 1)
						{
							DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(text);
							DatabaseExcetue.BuildDBParameter(sqlDatabase, sqlStringCommand, parms);
							sqlDatabase.ExecuteNonQuery(sqlStringCommand);
						}
					}
					dbTransaction.Commit();
				}
				catch (Exception exception_)
				{
					DatabaseExcetue.smethod_2(exception_);
					dbTransaction.Rollback();
				}
				finally
				{
					dbConnection.Close();
				}
			}
		}
		public static void RunTransactionSql(List<string> sqlList)
		{
			SqlDatabase sqlDatabase = DatabaseExcetue.GetSqlDatabase();
			using (DbConnection dbConnection = sqlDatabase.CreateConnection())
			{
				dbConnection.Open();
				DbTransaction dbTransaction = dbConnection.BeginTransaction();
				try
				{
					foreach (string current in sqlList)
					{
						DbCommand sqlStringCommand = sqlDatabase.GetSqlStringCommand(current);
						sqlDatabase.ExecuteNonQuery(sqlStringCommand);
					}
					dbTransaction.Commit();
				}
				catch (Exception exception_)
				{
					DatabaseExcetue.smethod_2(exception_);
					dbTransaction.Rollback();
				}
				finally
				{
					dbConnection.Close();
				}
			}
		}
        /// <summary>
        /// ´íÎó¼ÇÂ¼
        /// </summary>
        /// <param name="exception_0"></param>
		private static void smethod_2(Exception exception_0)
		{
			//string text = HttpContext.Current.Request.Url.ToString();
			//string source = exception_0.Source;
			//string message = exception_0.Message;
			//string stackTrace = exception_0.StackTrace;
			//string text2 = HttpContext.Current.Request.ServerVariables["SERVER_NAME"].ToString();
			//DatabaseExcetue.smethod_3(string.Concat(new string[]
			//{
			//	"http://www.shopnum1.com/ShopNum1ErrorGetMall/ErrorEet.aspx?FKshopnum1ERRORABC=FKshopnum1ERROR&OffendingUrl=",
			//	text,
			//	"&ErrorSouce= ",
			//	source,
			//	" &Message=",
			//	message,
			//	"&StackTrace= ",
			//	stackTrace,
			//	"&MainDomain=",
			//	text2
			//}));
		}
		private static string smethod_3(string string_2)
		{
			string result = string.Empty;
			Encoding encoding = Encoding.GetEncoding("utf-8");
			WebRequest webRequest = WebRequest.Create(string_2);
			try
			{
				WebResponse response = webRequest.GetResponse();
				StreamReader streamReader = new StreamReader(response.GetResponseStream(), encoding);
				result = streamReader.ReadToEnd();
			}
			catch (Exception)
			{
				result = "";
			}
			return result;
		}
	}
}
