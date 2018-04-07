using System;
using System.Text.RegularExpressions;
namespace ShopNum1.DiscuzCommon
{
	public class TypeParse
	{
		public static bool IsNumeric(object Expression)
		{
			bool result;
			if (Expression != null)
			{
				string text = Expression.ToString();
				if (text.Length > 0 && text.Length <= 11 && Regex.IsMatch(text, "^[-]?[0-9]*[.]?[0-9]*$") && (text.Length < 10 || (text.Length == 10 && text[0] == '1') || (text.Length == 11 && text[0] == '-' && text[1] == '1')))
				{
					result = true;
					return result;
				}
			}
			result = false;
			return result;
		}
		public static bool IsDouble(object Expression)
		{
			return Expression != null && Regex.IsMatch(Expression.ToString(), "^([0-9])[0-9]*(\\.\\w*)?$");
		}
		public static bool StrToBool(object Expression, bool defValue)
		{
			bool result;
			if (Expression != null)
			{
				if (string.Compare(Expression.ToString(), "true", true) == 0)
				{
					result = true;
					return result;
				}
				if (string.Compare(Expression.ToString(), "false", true) == 0)
				{
					result = false;
					return result;
				}
			}
			result = defValue;
			return result;
		}
		public static int StrToInt(object Expression, int defValue)
		{
			int result;
			if (Expression != null)
			{
				string text = Expression.ToString();
				if (text.Length > 0 && text.Length <= 11 && Regex.IsMatch(text, "^[-]?[0-9]*$") && (text.Length < 10 || (text.Length == 10 && text[0] == '1') || (text.Length == 11 && text[0] == '-' && text[1] == '1')))
				{
					result = Convert.ToInt32(text);
					return result;
				}
			}
			result = defValue;
			return result;
		}
		public static float StrToFloat(object strValue, float defValue)
		{
			float result;
			if (strValue == null || strValue.ToString().Length > 10)
			{
				result = defValue;
			}
			else
			{
				float num = defValue;
				if (strValue != null && Regex.IsMatch(strValue.ToString(), "^([-]|[0-9])[0-9]*(\\.\\w*)?$"))
				{
					num = Convert.ToSingle(strValue);
				}
				result = num;
			}
			return result;
		}
		public static bool IsNumericArray(string[] strNumber)
		{
			bool result;
			if (strNumber == null)
			{
				result = false;
			}
			else if (strNumber.Length < 1)
			{
				result = false;
			}
			else
			{
				for (int i = 0; i < strNumber.Length; i++)
				{
					string expression = strNumber[i];
					if (!TypeParse.IsNumeric(expression))
					{
						result = false;
						return result;
					}
				}
				result = true;
			}
			return result;
		}
	}
}
