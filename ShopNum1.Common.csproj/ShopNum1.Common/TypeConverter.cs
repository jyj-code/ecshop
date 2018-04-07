using System;
using System.Text.RegularExpressions;
namespace ShopNum1.Common
{
	public class TypeConverter
	{
		public static bool StrToBool(object expression, bool defValue)
		{
			bool result;
			if (expression != null)
			{
				result = TypeConverter.StrToBool(expression, defValue);
			}
			else
			{
				result = defValue;
			}
			return result;
		}
		public static bool StrToBool(string expression, bool defValue)
		{
			bool result;
			if (expression != null)
			{
				if (string.Compare(expression, "true", true) == 0)
				{
					result = true;
					return result;
				}
				if (string.Compare(expression, "false", true) == 0)
				{
					result = false;
					return result;
				}
			}
			result = defValue;
			return result;
		}
		public static int ObjectToInt(object expression)
		{
			return TypeConverter.ObjectToInt(expression, 0);
		}
		public static int ObjectToInt(object expression, int defValue)
		{
			int result;
			if (expression != null)
			{
				result = TypeConverter.StrToInt(expression.ToString(), defValue);
			}
			else
			{
				result = defValue;
			}
			return result;
		}
		public static int StrToInt(string string_0)
		{
			return TypeConverter.StrToInt(string_0, 0);
		}
		public static int StrToInt(string string_0, int defValue)
		{
			int result;
			int num;
			if (string.IsNullOrEmpty(string_0) || string_0.Trim().Length >= 11 || !Regex.IsMatch(string_0.Trim(), "^([-]|[0-9])[0-9]*(\\.\\w*)?$"))
			{
				result = defValue;
			}
			else if (int.TryParse(string_0, out num))
			{
				result = num;
			}
			else
			{
				result = Convert.ToInt32(TypeConverter.StrToFloat(string_0, (float)defValue));
			}
			return result;
		}
		public static float StrToFloat(object strValue, float defValue)
		{
			float result;
			if (strValue == null)
			{
				result = defValue;
			}
			else
			{
				result = TypeConverter.StrToFloat(strValue.ToString(), defValue);
			}
			return result;
		}
		public static float ObjectToFloat(object strValue, float defValue)
		{
			float result;
			if (strValue == null)
			{
				result = defValue;
			}
			else
			{
				result = TypeConverter.StrToFloat(strValue.ToString(), defValue);
			}
			return result;
		}
		public static float ObjectToFloat(object strValue)
		{
			return TypeConverter.ObjectToFloat(strValue.ToString(), 0f);
		}
		public static float StrToFloat(string strValue)
		{
			float result;
			if (strValue == null)
			{
				result = 0f;
			}
			else
			{
				result = TypeConverter.StrToFloat(strValue.ToString(), 0f);
			}
			return result;
		}
		public static float StrToFloat(string strValue, float defValue)
		{
			float result;
			if (strValue == null || strValue.Length > 10)
			{
				result = defValue;
			}
			else
			{
				float num = defValue;
				if (strValue != null && Regex.IsMatch(strValue, "^([-]|[0-9])[0-9]*(\\.\\w*)?$"))
				{
					float.TryParse(strValue, out num);
				}
				result = num;
			}
			return result;
		}
		public static DateTime StrToDateTime(string string_0, DateTime defValue)
		{
			DateTime dateTime;
			DateTime result;
			if (!string.IsNullOrEmpty(string_0) && DateTime.TryParse(string_0, out dateTime))
			{
				result = dateTime;
			}
			else
			{
				result = defValue;
			}
			return result;
		}
		public static DateTime StrToDateTime(string string_0)
		{
			return TypeConverter.StrToDateTime(string_0, DateTime.Now);
		}
		public static DateTime ObjectToDateTime(object object_0)
		{
			return TypeConverter.StrToDateTime(object_0.ToString());
		}
		public static DateTime ObjectToDateTime(object object_0, DateTime defValue)
		{
			return TypeConverter.StrToDateTime(object_0.ToString(), defValue);
		}
		public static int[] StringToIntArray(string idList)
		{
			return TypeConverter.StringToIntArray(idList, -1);
		}
		public static int[] StringToIntArray(string idList, int defValue)
		{
			int[] result;
			if (string.IsNullOrEmpty(idList))
			{
				result = null;
			}
			else
			{
				string[] array = Utils.SplitString(idList, ",");
				int[] array2 = new int[array.Length];
				for (int i = 0; i < array.Length; i++)
				{
					array2[i] = TypeConverter.StrToInt(array[i], defValue);
				}
				result = array2;
			}
			return result;
		}
	}
}
