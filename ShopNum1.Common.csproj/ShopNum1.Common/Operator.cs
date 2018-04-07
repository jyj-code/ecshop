using System;
using System.Text.RegularExpressions;
namespace ShopNum1.Common
{
	public static class Operator
	{
		public static string FilterString(object strInput)
		{
			string text = "";
			try
			{
				if (strInput == null)
				{
					text = "";
				}
				else
				{
					text = strInput.ToString().Trim();
					text = Regex.Replace(text, "<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "<(.[^>]*)>", "", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "-->", "", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "<!--.*", "", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "<", "", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, ">", "", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "&(quot|#34);", "\"", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "&(amp|#38);", "&", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "&(lt|#60);", "<", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "&(gt|#62);", ">", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "&(iexcl|#161);", "¡", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "&(cent|#162);", "¢", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "&(pound|#163);", "£", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "&(copy|#169);", "©", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "&#(\\d+);", "", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "xp_cmdshell", "", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "insert", "", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "delete from", "", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "count''", "", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "drop table", "", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "truncate", "", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "asc", "", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "char", "", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "xp_cmdshell", "", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "exec master", "", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "net localgroup administrators", "", RegexOptions.IgnoreCase);
				}
			}
			catch
			{
				text = "";
			}
			return text;
		}
		public static string FilterStringUrl(object strInput)
		{
			string text = "";
			try
			{
				if (strInput == null)
				{
					text = "";
				}
				else
				{
					text = strInput.ToString().Trim();
					text = Regex.Replace(text, "<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "<(.[^>]*)>", "", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "-->", "", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "<!--.*", "", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "<", "", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, ">", "", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "&(quot|#34);", "\"", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "&(amp|#38);", "&", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "&(lt|#60);", "<", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "&(gt|#62);", ">", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "&(iexcl|#161);", "¡", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "&(cent|#162);", "¢", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "&(pound|#163);", "£", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "&(copy|#169);", "©", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "&#(\\d+);", "", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "xp_cmdshell", "", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "insert", "", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "delete from", "", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "count''", "", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "drop table", "", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "truncate", "", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "", "", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "char", "", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "xp_cmdshell", "", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "exec master", "", RegexOptions.IgnoreCase);
					text = Regex.Replace(text, "net localgroup administrators", "", RegexOptions.IgnoreCase);
					text = text.Replace("/", "%2f");
					text = text.Replace("'", "");
				}
			}
			catch
			{
				text = "";
			}
			return text;
		}
		public static string OperteString(string opstring, int leng)
		{
			string result;
			if (opstring.Length >= leng)
			{
				result = opstring.Substring(0, leng);
			}
			else
			{
				result = opstring;
			}
			return result;
		}
		public static string FilterDouhao(object strInput)
		{
			return strInput.ToString().Replace(",", ".");
		}
		public static int FilterInt(object strInput)
		{
			string text = "";
			try
			{
				if (strInput == null)
				{
					text = "";
				}
				else
				{
					text = strInput.ToString();
					text = text.Replace("'", "''");
				}
			}
			catch
			{
				text = "";
			}
			return Convert.ToInt32(text);
		}
		public static string Left(string string_0, int length)
		{
			string result;
			if (length >= string_0.Length)
			{
				result = string_0;
			}
			else
			{
				result = string_0.Substring(0, length);
			}
			return result;
		}
		public static string Right(string original, int length)
		{
			if (original == null)
			{
				throw new ArgumentNullException("original", "Right cannot be evaluated on a null string.");
			}
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length", length, "Length must not be negative.");
			}
			string result;
			if (original.Length == 0 || length == 0)
			{
				result = string.Empty;
			}
			else if (length >= original.Length)
			{
				result = original;
			}
			else
			{
				result = original.Substring(original.Length - length);
			}
			return result;
		}
		public static bool CheckNumeric(object Expression)
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
		public static bool CheckDouble(object Expression)
		{
			return Expression != null && Regex.IsMatch(Expression.ToString(), "^([0-9])[0-9]*(\\.\\w*)?$");
		}
		public static float StringToFloat(object strValue, float defValue)
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
		public static string FormatToEmpty(string string_0)
		{
			if (string_0 == "")
			{
				string_0 = string.Empty;
			}
			else if (string_0 == null)
			{
				string_0 = string.Empty;
			}
			else if (string_0 == "&nbsp;")
			{
				string_0 = string.Empty;
			}
			return string_0;
		}
		public static bool CheckNumericArray(string[] strNumber)
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
					if (!Operator.CheckNumeric(expression))
					{
						result = false;
						return result;
					}
				}
				result = true;
			}
			return result;
		}
		public static int StringToInt(object Expression, int defValue)
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
		public static bool StringToBool(object Expression, bool defValue)
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
	}
}
