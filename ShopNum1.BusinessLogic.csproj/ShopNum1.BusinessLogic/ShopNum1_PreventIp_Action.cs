using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
namespace ShopNum1.BusinessLogic
{
	public class ShopNum1_PreventIp_Action : IShopNum1_PreventIp_Action
	{
		public int Insert(ShopNum1_PreventIp shopNum1_PreventIp)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"INSERT INTO ShopNum1_PreventIp (Guid,StartIp,EndIp,Memo,LockPeople,StartTime,EndTime,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted ) values ('",
				shopNum1_PreventIp.Guid,
				"','",
				shopNum1_PreventIp.StartIp,
				"','",
				shopNum1_PreventIp.EndIp,
				"','",
				shopNum1_PreventIp.Memo,
				"','",
				shopNum1_PreventIp.LockPeople,
				"','",
				shopNum1_PreventIp.StartTime,
				"','",
				shopNum1_PreventIp.EndTime,
				"','",
				shopNum1_PreventIp.CreateUser,
				"','",
				shopNum1_PreventIp.CreateTime,
				"','",
				shopNum1_PreventIp.ModifyUser,
				"','",
				shopNum1_PreventIp.ModifyTime,
				"','",
				shopNum1_PreventIp.IsDeleted,
				"' )"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable Search()
		{
			string strSql = "select guid, StartIp ,EndIp,StartTime,EndTime,Memo,LockPeople,CreateUser,CreateTime,ModifyUser,ModifyTime from ShopNum1_PreventIp";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public int Delete(string guid)
		{
			string strSql = string.Format("delete ShopNum1_PreventIp where guid='" + guid.Replace("'", "") + "'", new object[0]);
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public int Update(ShopNum1_PreventIp shopNum1_PreventIp)
		{
			string strSql = string.Empty;
			strSql = string.Concat(new object[]
			{
				"UPDATE ShopNum1_PreventIp SET StartIp='",
				shopNum1_PreventIp.StartIp,
				"',EndIp='",
				shopNum1_PreventIp.EndIp,
				"',Memo='",
				shopNum1_PreventIp.Memo,
				"',LockPeople='",
				shopNum1_PreventIp.LockPeople,
				"',StartTime='",
				shopNum1_PreventIp.StartTime,
				"',EndTime='",
				shopNum1_PreventIp.EndTime,
				"',ModifyUser='",
				shopNum1_PreventIp.ModifyUser,
				"',ModifyTime='",
				shopNum1_PreventIp.ModifyTime,
				"'WHERE GUID='",
				shopNum1_PreventIp.Guid,
				"'"
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public DataTable GetEditInfo(string guid)
		{
			string strSql = "select guid, StartIp ,EndIp,StartTime,EndTime,Memo,LockPeople,CreateUser,CreateTime,ModifyUser,ModifyTime from ShopNum1_PreventIp where guid='" + guid.Replace("'", "") + "'";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public bool CheckedUser(string userIP, string Type)
		{
			bool result = true;
			DataTable dataTable = this.method_0(Type);
			foreach (DataRow dataRow in dataTable.Rows)
			{
				if (DateTime.Parse(dataRow["StartTime"].ToString()) <= DateTime.Now && DateTime.Now <= DateTime.Parse(dataRow["EndTime"].ToString()))
				{
					long num = this.DoGetIPValue(userIP);
					if (this.DoGetIPValue(dataRow["StartIp"].ToString()) <= num && num <= this.DoGetIPValue(dataRow["EndIp"].ToString()))
					{
						result = false;
					}
				}
			}
			return result;
		}
		private DataTable method_0(string string_0)
		{
			string strSql = "select guid, StartIp ,EndIp,StartTime,EndTime,Memo,LockPeople,CreateUser,CreateTime,ModifyUser,ModifyTime from ShopNum1_PreventIp where LockPeople='" + string_0 + "'";
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public long DoGetIPValue(string IP)
		{
			string[] array = IP.Split(new char[]
			{
				'.'
			});
			string text = string.Empty;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].Length == 1)
				{
					text = text + "00" + array[i];
				}
				if (array[i].Length == 2)
				{
					text = text + "0" + array[i];
				}
				if (array[i].Length == 3)
				{
					text += array[i];
				}
			}
			return Convert.ToInt64(text);
		}
	}
}
