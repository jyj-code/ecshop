using ShopNum1.DataAccess;
using ShopNum1.ExtendedCommon;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
namespace ShopNum1.Common
{
	public static class Common
	{
		public static int ReturnMaxID(string columnName, string ShopID, string ShopIDValue, string tableName)
		{
			return DatabaseExcetue.ReturnMaxID(columnName, ShopID, ShopIDValue, tableName);
		}
		public static int ReturnMaxID(string columnName, string tableName)
		{
			return DatabaseExcetue.ReturnMaxID(columnName, tableName);
		}
		public static bool ReturnExist(string strcolumnName, string strtableName, string strcondition)
		{
			bool result;
			try
			{
				string strSql = string.Concat(new string[]
				{
					"select ",
					strcolumnName,
					" from ",
					strtableName,
					" where 1=1 ",
					strcondition
				});
				if (DatabaseExcetue.ReturnString(strSql) != "0" && DatabaseExcetue.ReturnString(strSql) != "")
				{
					result = true;
				}
				else
				{
					result = false;
				}
			}
			catch
			{
				result = false;
			}
			return result;
		}
		public static string cut(object object_0, int int_0)
		{
			string result;
			if (object_0.ToString().Length >= int_0)
			{
				result = object_0.ToString().Substring(0, int_0);
			}
			else
			{
				result = object_0.ToString();
			}
			return result;
		}
		public static string Serialize(object object_0)
		{
			string result;
			try
			{
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				MemoryStream memoryStream = new MemoryStream();
				binaryFormatter.Serialize(memoryStream, object_0);
				byte[] array = memoryStream.ToArray();
				result = Convert.ToBase64String(array, 0, array.Length);
			}
			catch
			{
				result = "";
			}
			return result;
		}
		public static object Deserialize(string string_0)
		{
			object result;
			try
			{
				byte[] buffer = Convert.FromBase64String(string_0);
				MemoryStream serializationStream = new MemoryStream(buffer);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				result = binaryFormatter.Deserialize(serializationStream);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}
		public static bool CheckInertSql(string string_0)
		{
			string text = ConfigurationManager.AppSettings["SQLChar"].ToString();
			string[] array = text.Split(new char[]
			{
				'|'
			});
			bool result = false;
			for (int i = 0; i < array.Length; i++)
			{
				if (string_0.Trim().ToLower().IndexOf(array[i].ToString().ToLower()) != -1 || string_0.Trim().ToLower().StartsWith(array[i].Trim()))
				{
					result = true;
				}
			}
			return result;
		}
		public static string GetCopyright()
		{
			string text = " Powered by ShopNum1";
			ControlCheck controlCheck = new ControlCheck();
			HttpContext arg_11_0 = HttpContext.Current;
			string domain = ConfigurationManager.AppSettings["DoMain"].ToString().Trim();
			int num = controlCheck.CheckCopyright(domain);
			string result;
			if (num == 2 || ShopSettings.GetValue("Power") == "shopnum1")
			{
				result = "";
			}
			else
			{
				result = text;
			}
			return result;
		}
		public static string GetNameById(string strColumn, string strTab, string strCondition)
		{
			string strSql = string.Concat(new string[]
			{
				"select ",
				strColumn,
				" from ",
				strTab,
				" where 1=1 ",
				strCondition
			});
			return DatabaseExcetue.ReturnString(strSql);
		}
		public static DataTable GetTableById(string strColumn, string strTab, string strCondition)
		{
			string strSql = string.Concat(new string[]
			{
				"select ",
				strColumn,
				" from ",
				strTab,
				" where 1=1 ",
				strCondition
			});
			return DatabaseExcetue.ReturnDataTable(strSql);
		}
		public static int UpdateInfo(string strColumn, string strTab, string strCondition)
		{
			string strSql = string.Concat(new string[]
			{
				"update ",
				strTab,
				" set ",
				strColumn,
				" where 1=1 ",
				strCondition
			});
			return DatabaseExcetue.RunNonQuery(strSql);
		}
		public static string ReqStr(string string_0)
		{
			string result;
			if (HttpContext.Current.Request.QueryString[string_0] != null)
			{
				result = Common.cut(Operator.FilterStringUrl(HttpContext.Current.Request.QueryString[string_0].ToString()), 200);
			}
			else
			{
				result = "";
			}
			return result;
		}
		public static bool CheckImgType(string[] strArry, string strExt)
		{
			bool result;
			for (int i = 0; i < strArry.Length; i++)
			{
				if (strArry[i] == strExt)
				{
					result = true;
					return result;
				}
			}
			result = false;
			return result;
		}
		public static string SetShopCommentTxt(string strScore)
		{
			string result;
			if (strScore != null)
			{
				if (strScore == "5")
				{
					result = "<img src='/ImgUpload/gds_dp.png' alt='好评'/>";
					return result;
				}
				if (strScore == "3")
				{
					result = "<img src='/ImgUpload/gds_dp1.png' alt='中评'/>";
					return result;
				}
				if (strScore == "1")
				{
					result = "<img src='/ImgUpload/gds_dp2.png' alt='差评'/>";
					return result;
				}
			}
			result = "<img src='/ImgUpload/gds_dp2.png' alt='差评'/>";
			return result;
		}
	}
}
