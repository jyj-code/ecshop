using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace ShopNum1.Common
{
	public class SqlDB
	{
		private SqlConnection sqlConnection_0;
		public SqlDB()
		{
			this.sqlConnection_0 = new SqlConnection();
			this.sqlConnection_0.ConnectionString = ConfigurationManager.ConnectionStrings["Connection String"].ConnectionString;
		}
		public SqlDB(string StrConnection)
		{
			this.sqlConnection_0 = new SqlConnection();
			this.sqlConnection_0.ConnectionString = StrConnection;
		}
		private void method_0()
		{
			try
			{
				if (this.sqlConnection_0.State != ConnectionState.Open)
				{
					this.sqlConnection_0.Open();
				}
			}
			catch (Exception ex)
			{
				throw new Exception("打开数据库失败：" + ex.Message);
			}
		}
		private void method_1()
		{
			try
			{
				if (this.sqlConnection_0.State != ConnectionState.Closed)
				{
					this.sqlConnection_0.Close();
				}
			}
			catch (Exception ex)
			{
				throw new Exception("关闭数据库失败：" + ex.Message);
			}
		}
		private SqlCommand method_2(string string_0, CommandType commandType_0, SqlParameter[] sqlParameter_0)
		{
			SqlCommand sqlCommand = new SqlCommand(string_0, this.sqlConnection_0);
			sqlCommand.CommandType = commandType_0;
			if (sqlParameter_0 != null)
			{
				for (int i = 0; i < sqlParameter_0.Length; i++)
				{
					sqlCommand.Parameters.Add(sqlParameter_0[i]);
				}
			}
			return sqlCommand;
		}
		public SqlParameter[] GetParameter(string[] paraname, string[] paravalue)
		{
			SqlParameter[] array = new SqlParameter[paraname.Length];
			for (int i = 0; i < paraname.Length; i++)
			{
				array[i] = new SqlParameter(paraname[i], paravalue[i]);
			}
			return array;
		}
		public DataSet ExecuteDataSetByText(string SelectCommand)
		{
			DataSet dataSet = new DataSet();
			SqlCommand selectCommand = this.method_2(SelectCommand, CommandType.Text, null);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet);
			return dataSet;
		}
		public DataSet ExecuteDataSetyByProc(string ProcName, SqlParameter[] ParaList)
		{
			DataSet dataSet = new DataSet();
			SqlCommand selectCommand = this.method_2(ProcName, CommandType.StoredProcedure, ParaList);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet);
			return dataSet;
		}
		public DataSet ExecuteDataSetyByProc(string ProcName, string[] paraname, string[] paravalue)
		{
			DataSet dataSet = new DataSet();
			SqlCommand selectCommand = this.method_2(ProcName, CommandType.StoredProcedure, this.GetParameter(paraname, paravalue));
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet);
			return dataSet;
		}
		public DataSet ExecuteDataSetyByProc(string ProcName, string paraname, string paravalue)
		{
			string[] paraname2 = new string[]
			{
				paraname
			};
			string[] paravalue2 = new string[]
			{
				paravalue
			};
			DataSet dataSet = new DataSet();
			SqlCommand selectCommand = this.method_2(ProcName, CommandType.StoredProcedure, this.GetParameter(paraname2, paravalue2));
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet);
			return dataSet;
		}
		public DataTable ExecuteDataTableByText(string SelectCommand)
		{
			DataSet dataSet = new DataSet();
			SqlCommand selectCommand = this.method_2(SelectCommand, CommandType.Text, null);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet);
			return dataSet.Tables[0];
		}
		public DataTable ExecuteDataTableyByProc(string ProcName, SqlParameter[] ParaList)
		{
			DataSet dataSet = new DataSet();
			SqlCommand selectCommand = this.method_2(ProcName, CommandType.StoredProcedure, ParaList);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet);
			return dataSet.Tables[0];
		}
		public DataTable ExecuteDataTableyByProc(string ProcName, string[] paraname, string[] paravalue)
		{
			DataSet dataSet = new DataSet();
			SqlCommand selectCommand = this.method_2(ProcName, CommandType.StoredProcedure, this.GetParameter(paraname, paravalue));
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet);
			return dataSet.Tables[0];
		}
		public DataTable ExecuteDataTableyByProc(string ProcName, string paraname, string paravalue)
		{
			string[] paraname2 = new string[]
			{
				paraname
			};
			string[] paravalue2 = new string[]
			{
				paravalue
			};
			DataSet dataSet = new DataSet();
			SqlCommand selectCommand = this.method_2(ProcName, CommandType.StoredProcedure, this.GetParameter(paraname2, paravalue2));
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet);
			return dataSet.Tables[0];
		}
		public SqlDataReader ExecuteReaderByText(string SelectCommand)
		{
			SqlCommand sqlCommand = this.method_2(SelectCommand, CommandType.Text, null);
			this.method_0();
			return sqlCommand.ExecuteReader();
		}
		public SqlDataReader ExecuteReaderByProc(string ProcName, SqlParameter[] ParaList)
		{
			SqlCommand sqlCommand = this.method_2(ProcName, CommandType.StoredProcedure, ParaList);
			this.method_0();
			return sqlCommand.ExecuteReader();
		}
		public SqlDataReader ExecuteReaderByProc(string ProcName, string[] paraname, string[] paravalue)
		{
			SqlCommand sqlCommand = this.method_2(ProcName, CommandType.StoredProcedure, this.GetParameter(paraname, paravalue));
			this.method_0();
			return sqlCommand.ExecuteReader();
		}
		public object ExecuteScalarByText(string SelectCommand)
		{
			SqlCommand sqlCommand = this.method_2(SelectCommand, CommandType.Text, null);
			this.method_0();
			object result = sqlCommand.ExecuteScalar();
			this.method_1();
			return result;
		}
		public object ExecuteScalarByProc(string ProcName, SqlParameter[] ParaList)
		{
			SqlCommand sqlCommand = this.method_2(ProcName, CommandType.StoredProcedure, ParaList);
			this.method_0();
			object result = sqlCommand.ExecuteScalar();
			this.method_1();
			return result;
		}
		public object ExecuteScalarByProc(string ProcName, string[] paraname, string[] paravalue)
		{
			SqlCommand sqlCommand = this.method_2(ProcName, CommandType.StoredProcedure, this.GetParameter(paraname, paravalue));
			this.method_0();
			object result = sqlCommand.ExecuteScalar();
			this.method_1();
			return result;
		}
		public int ExecuteNonQueryByText(string CommandText)
		{
			SqlCommand sqlCommand = this.method_2(CommandText, CommandType.Text, null);
			this.method_0();
			int result = sqlCommand.ExecuteNonQuery();
			this.method_1();
			return result;
		}
		public int ExecuteNonQueryByProc(string ProcName, SqlParameter[] ParaList)
		{
			SqlCommand sqlCommand = this.method_2(ProcName, CommandType.StoredProcedure, ParaList);
			this.method_0();
			int result = sqlCommand.ExecuteNonQuery();
			this.method_1();
			return result;
		}
		public int ExecuteNonQueryByProc(string ProcName, string[] paraname, string[] paravalue)
		{
			SqlCommand sqlCommand = this.method_2(ProcName, CommandType.StoredProcedure, this.GetParameter(paraname, paravalue));
			this.method_0();
			int result = sqlCommand.ExecuteNonQuery();
			this.method_1();
			return result;
		}
		public int ExecuteNonQueryByProc(string ProcName, string paraname, string paravalue)
		{
			string[] paraname2 = new string[]
			{
				paraname
			};
			string[] paravalue2 = new string[]
			{
				paravalue
			};
			SqlCommand sqlCommand = this.method_2(ProcName, CommandType.StoredProcedure, this.GetParameter(paraname2, paravalue2));
			this.method_0();
			int result = sqlCommand.ExecuteNonQuery();
			this.method_1();
			return result;
		}
	}
}
