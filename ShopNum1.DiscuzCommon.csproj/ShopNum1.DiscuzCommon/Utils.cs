using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
namespace ShopNum1.DiscuzCommon
{
	public class Utils
	{
		private static Regex regex_0 = new Regex("(\\r\\n)", RegexOptions.IgnoreCase);
		public static Regex RegexFont = new Regex("<font color=\".*?\">([\\s\\S]+?)</font>", Utils.GetRegexCompiledOptions());
		private static FileVersionInfo fileVersionInfo_0 = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
		private static string string_0 = string.Format("dnttemplateid_{0}_{1}_{2}", Utils.fileVersionInfo_0.FileMajorPart, Utils.fileVersionInfo_0.FileMinorPart, Utils.fileVersionInfo_0.FileBuildPart);
		public static string[] Monthes
		{
			get
			{
				return new string[]
				{
					"January",
					"February",
					"March",
					"April",
					"May",
					"June",
					"July",
					"August",
					"September",
					"October",
					"November",
					"December"
				};
			}
		}
		public static RegexOptions GetRegexCompiledOptions()
		{
			return RegexOptions.None;
		}
		public static int GetStringLength(string string_1)
		{
			return Encoding.Default.GetBytes(string_1).Length;
		}
		public static bool IsCompriseStr(string string_1, string stringarray, string strsplit)
		{
			bool result;
			if (stringarray == "" || stringarray == null)
			{
				result = false;
			}
			else
			{
				string_1 = string_1.ToLower();
				string[] array = Utils.SplitString(stringarray.ToLower(), strsplit);
				for (int i = 0; i < array.Length; i++)
				{
					if (string_1.IndexOf(array[i]) > -1)
					{
						result = true;
						return result;
					}
				}
				result = false;
			}
			return result;
		}
		public static int GetInArrayID(string strSearch, string[] stringArray, bool caseInsensetive)
		{
			int result;
			for (int i = 0; i < stringArray.Length; i++)
			{
				if (caseInsensetive)
				{
					if (strSearch.ToLower() == stringArray[i].ToLower())
					{
						result = i;
						return result;
					}
				}
				else if (strSearch == stringArray[i])
				{
					result = i;
					return result;
				}
			}
			result = -1;
			return result;
		}
		public static int GetInArrayID(string strSearch, string[] stringArray)
		{
			return Utils.GetInArrayID(strSearch, stringArray, true);
		}
		public static bool InArray(string strSearch, string[] stringArray, bool caseInsensetive)
		{
			return Utils.GetInArrayID(strSearch, stringArray, caseInsensetive) >= 0;
		}
		public static bool InArray(string string_1, string[] stringarray)
		{
			return Utils.InArray(string_1, stringarray, false);
		}
		public static bool InArray(string string_1, string stringarray)
		{
			return Utils.InArray(string_1, Utils.SplitString(stringarray, ","), false);
		}
		public static bool InArray(string string_1, string stringarray, string strsplit)
		{
			return Utils.InArray(string_1, Utils.SplitString(stringarray, strsplit), false);
		}
		public static bool InArray(string string_1, string stringarray, string strsplit, bool caseInsensetive)
		{
			return Utils.InArray(string_1, Utils.SplitString(stringarray, strsplit), caseInsensetive);
		}
		public static string RTrim(string string_1)
		{
			for (int i = string_1.Length; i >= 0; i--)
			{
				if (string_1[i].Equals(" ") || string_1[i].Equals("\r") || string_1[i].Equals("\n"))
				{
					string_1.Remove(i, 1);
				}
			}
			return string_1;
		}
		public static string ClearBR(string string_1)
		{
			Match match = Utils.regex_0.Match(string_1);
			while (match.Success)
			{
				string_1 = string_1.Replace(match.Groups[0].ToString(), "");
				match = match.NextMatch();
			}
			return string_1;
		}
		public static string CutString(string string_1, int startIndex, int length)
		{
			string result;
			if (startIndex >= 0)
			{
				if (length < 0)
				{
					length *= -1;
					if (startIndex - length < 0)
					{
						length = startIndex;
						startIndex = 0;
					}
					else
					{
						startIndex -= length;
					}
				}
				if (startIndex > string_1.Length)
				{
					result = "";
					return result;
				}
			}
			else
			{
				if (length < 0)
				{
					result = "";
					return result;
				}
				if (length + startIndex <= 0)
				{
					result = "";
					return result;
				}
				length += startIndex;
				startIndex = 0;
			}
			if (string_1.Length - startIndex < length)
			{
				length = string_1.Length - startIndex;
			}
			result = string_1.Substring(startIndex, length);
			return result;
		}
		public static string CutString(string string_1, int startIndex)
		{
			return Utils.CutString(string_1, startIndex, string_1.Length);
		}
		public static string GetMapPath(string strPath)
		{
			string result;
			if (HttpContext.Current != null)
			{
				result = HttpContext.Current.Server.MapPath(strPath);
			}
			else
			{
				result = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
			}
			return result;
		}
		public static bool FileExists(string filename)
		{
			return File.Exists(filename);
		}
		public static void ResponseFile(string filepath, string filename, string filetype)
		{
			Stream stream = null;
			byte[] buffer = new byte[10000];
			try
			{
				stream = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
				long num = stream.Length;
				HttpContext.Current.Response.ContentType = filetype;
				HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + Utils.UrlEncode(filename.Trim()).Replace("+", " "));
				while (num > 0L)
				{
					if (HttpContext.Current.Response.IsClientConnected)
					{
						int num2 = stream.Read(buffer, 0, 10000);
						HttpContext.Current.Response.OutputStream.Write(buffer, 0, num2);
						HttpContext.Current.Response.Flush();
						buffer = new byte[10000];
						num -= (long)num2;
					}
					else
					{
						num = -1L;
					}
				}
			}
			catch (Exception ex)
			{
				HttpContext.Current.Response.Write("Error : " + ex.Message);
			}
			finally
			{
				if (stream != null)
				{
					stream.Close();
				}
			}
			HttpContext.Current.Response.End();
		}
		public static bool IsImgFilename(string filename)
		{
			filename = filename.Trim();
			bool result;
			if (filename.EndsWith(".") || filename.IndexOf(".") == -1)
			{
				result = false;
			}
			else
			{
				string a = filename.Substring(filename.LastIndexOf(".") + 1).ToLower();
				result = (a == "jpg" || a == "jpeg" || a == "png" || a == "bmp" || a == "gif");
			}
			return result;
		}
		public static string IntToStr(int intValue)
		{
			return Convert.ToString(intValue);
		}
		public static string MD5(string string_1)
		{
			byte[] array = Encoding.Default.GetBytes(string_1);
			array = new MD5CryptoServiceProvider().ComputeHash(array);
			string text = "";
			for (int i = 0; i < array.Length; i++)
			{
				text += array[i].ToString("x").PadLeft(2, '0');
			}
			return text;
		}
		public static string SHA256(string string_1)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(string_1);
			SHA256Managed sHA256Managed = new SHA256Managed();
			byte[] inArray = sHA256Managed.ComputeHash(bytes);
			return Convert.ToBase64String(inArray);
		}
		public static string GetSubString(string p_SrcString, int p_Length, string p_TailString)
		{
			return Utils.GetSubString(p_SrcString, 0, p_Length, p_TailString);
		}
		public static string GetSubString(string p_SrcString, int p_StartIndex, int p_Length, string p_TailString)
		{
			string text = p_SrcString;
			string result;
			if (Regex.IsMatch(p_SrcString, "[ࠀ-一]+") || Regex.IsMatch(p_SrcString, "[가-힣]+"))
			{
				if (p_StartIndex >= p_SrcString.Length)
				{
					result = "";
				}
				else
				{
					result = p_SrcString.Substring(p_StartIndex, (p_Length + p_StartIndex > p_SrcString.Length) ? (p_SrcString.Length - p_StartIndex) : p_Length);
				}
			}
			else
			{
				if (p_Length >= 0)
				{
					byte[] bytes = Encoding.Default.GetBytes(p_SrcString);
					if (bytes.Length > p_StartIndex)
					{
						int num = bytes.Length;
						if (bytes.Length > p_StartIndex + p_Length)
						{
							num = p_Length + p_StartIndex;
						}
						else
						{
							p_Length = bytes.Length - p_StartIndex;
							p_TailString = "";
						}
						int num2 = p_Length;
						int[] array = new int[p_Length];
						int num3 = 0;
						for (int i = p_StartIndex; i < num; i++)
						{
							if (bytes[i] > 127)
							{
								num3++;
								if (num3 == 3)
								{
									num3 = 1;
								}
							}
							else
							{
								num3 = 0;
							}
							array[i] = num3;
						}
						if (bytes[num - 1] > 127 && array[p_Length - 1] == 1)
						{
							num2 = p_Length + 1;
						}
						byte[] array2 = new byte[num2];
						Array.Copy(bytes, p_StartIndex, array2, 0, num2);
						text = Encoding.Default.GetString(array2);
						text += p_TailString;
					}
				}
				result = text;
			}
			return result;
		}
		public static string ReplaceString(string SourceString, string SearchString, string ReplaceString, bool IsCaseInsensetive)
		{
			return Regex.Replace(SourceString, Regex.Escape(SearchString), ReplaceString, IsCaseInsensetive ? RegexOptions.IgnoreCase : RegexOptions.None);
		}
		public static string Spaces(int nSpaces)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < nSpaces; i++)
			{
				stringBuilder.Append(" &nbsp;&nbsp;");
			}
			return stringBuilder.ToString();
		}
		public static bool IsValidEmail(string strEmail)
		{
			return Regex.IsMatch(strEmail, "^([\\w-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([\\w-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$");
		}
		public static bool IsValidDoEmail(string strEmail)
		{
			return Regex.IsMatch(strEmail, "^@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([\\w-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$");
		}
		public static bool IsURL(string strUrl)
		{
			return Regex.IsMatch(strUrl, "^(http|https)\\://([a-zA-Z0-9\\.\\-]+(\\:[a-zA-Z0-9\\.&%\\$\\-]+)*@)*((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|localhost|([a-zA-Z0-9\\-]+\\.)*[a-zA-Z0-9\\-]+\\.(com|edu|gov|int|mil|net|org|biz|arpa|info|name|pro|aero|coop|museum|[a-zA-Z]{1,10}))(\\:[0-9]+)*(/($|[a-zA-Z0-9\\.\\,\\?\\'\\\\\\+&%\\$#\\=~_\\-]+))*$");
		}
		public static string GetEmailHostName(string strEmail)
		{
			string result;
			if (strEmail.IndexOf("@") < 0)
			{
				result = "";
			}
			else
			{
				result = strEmail.Substring(strEmail.LastIndexOf("@")).ToLower();
			}
			return result;
		}
		public static bool IsBase64String(string string_1)
		{
			return Regex.IsMatch(string_1, "[A-Za-z0-9\\+\\/\\=]");
		}
		public static bool IsSafeSqlString(string string_1)
		{
			return !Regex.IsMatch(string_1, "[-|;|,|\\/|\\(|\\)|\\[|\\]|\\}|\\{|%|@|\\*|!|\\']");
		}
		public static bool IsSafeUserInfoString(string string_1)
		{
			return !Regex.IsMatch(string_1, "^\\s*$|^c:\\\\con\\\\con$|[%,\\*\"\\s\\t\\<\\>\\&]|游客|^Guest");
		}
		public static string CleanInput(string strIn)
		{
			return Regex.Replace(strIn.Trim(), "[^\\w\\.@-]", "");
		}
		public static string GetFilename(string string_1)
		{
			string result;
			if (string_1 == null)
			{
				result = "";
			}
			else
			{
				string[] array = string_1.Split(new char[]
				{
					'/'
				});
				result = array[array.Length - 1].Split(new char[]
				{
					'?'
				})[0];
			}
			return result;
		}
		public static string StrFormat(string string_1)
		{
			string result;
			if (string_1 == null)
			{
				result = "";
			}
			else
			{
				string_1 = string_1.Replace("\r\n", "<br />");
				string_1 = string_1.Replace("\n", "<br />");
				result = string_1;
			}
			return result;
		}
		public static string GetDate()
		{
			return DateTime.Now.ToString("yyyy-MM-dd");
		}
		public static string GetDate(string datetimestr, string replacestr)
		{
			string result;
			if (datetimestr == null)
			{
				result = replacestr;
			}
			else if (datetimestr.Equals(""))
			{
				result = replacestr;
			}
			else
			{
				try
				{
					datetimestr = Convert.ToDateTime(datetimestr).ToString("yyyy-MM-dd").Replace("1900-01-01", replacestr);
				}
				catch
				{
					result = replacestr;
					return result;
				}
				result = datetimestr;
			}
			return result;
		}
		public static string GetTime()
		{
			return DateTime.Now.ToString("HH:mm:ss");
		}
		public static string GetDateTime()
		{
			return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
		}
		public static string GetDateTime(int relativeday)
		{
			return DateTime.Now.AddDays((double)relativeday).ToString("yyyy-MM-dd HH:mm:ss");
		}
		public static string GetDateTimeF()
		{
			return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fffffff");
		}
		public static string GetStandardDateTime(string fDateTime, string formatStr)
		{
			string result;
			if (fDateTime == "0000-0-0 0:00:00")
			{
				result = fDateTime;
			}
			else
			{
				result = Convert.ToDateTime(fDateTime).ToString(formatStr);
			}
			return result;
		}
		public static string GetStandardDateTime(string fDateTime)
		{
			return Utils.GetStandardDateTime(fDateTime, "yyyy-MM-dd HH:mm:ss");
		}
		public static bool IsTime(string timeval)
		{
			return Regex.IsMatch(timeval, "^((([0-1]?[0-9])|(2[0-3])):([0-5]?[0-9])(:[0-5]?[0-9])?)$");
		}
		public static string GetRealIP()
		{
			return DNTRequest.GetIP();
		}
		public static string mashSQL(string string_1)
		{
			string result;
			if (string_1 == null)
			{
				result = "";
			}
			else
			{
				string_1 = string_1.Replace("'", "'");
				result = string_1;
			}
			return result;
		}
		public static string ChkSQL(string string_1)
		{
			string result;
			if (string_1 == null)
			{
				result = "";
			}
			else
			{
				string_1 = string_1.Replace("'", "''");
				result = string_1;
			}
			return result;
		}
		public void transHtml(string path, string outpath)
		{
			Page page = new Page();
			StringWriter stringWriter = new StringWriter();
			page.Server.Execute(path, stringWriter);
			FileStream fileStream;
			if (File.Exists(page.Server.MapPath("") + "\\" + outpath))
			{
				File.Delete(page.Server.MapPath("") + "\\" + outpath);
				fileStream = File.Create(page.Server.MapPath("") + "\\" + outpath);
			}
			else
			{
				fileStream = File.Create(page.Server.MapPath("") + "\\" + outpath);
			}
			byte[] bytes = Encoding.Default.GetBytes(stringWriter.ToString());
			fileStream.Write(bytes, 0, bytes.Length);
			fileStream.Close();
		}
		public static string ToSChinese(string string_1)
		{
			return Strings.StrConv(string_1, VbStrConv.SimplifiedChinese, 0);
		}
		public static string ToTChinese(string string_1)
		{
			return Strings.StrConv(string_1, VbStrConv.TraditionalChinese, 0);
		}
		public static string[] SplitString(string strContent, string strSplit)
		{
			string[] result;
			if (strContent.IndexOf(strSplit) < 0)
			{
				string[] array = new string[]
				{
					strContent
				};
				result = array;
			}
			else
			{
				result = Regex.Split(strContent, Regex.Escape(strSplit), RegexOptions.IgnoreCase);
			}
			return result;
		}
		public static string[] SplitString(string strContent, string strSplit, int p_3)
		{
			string[] array = new string[p_3];
			string[] array2 = Utils.SplitString(strContent, strSplit);
			for (int i = 0; i < p_3; i++)
			{
				if (i < array2.Length)
				{
					array[i] = array2[i];
				}
				else
				{
					array[i] = string.Empty;
				}
			}
			return array;
		}
		public static string EncodeHtml(string strHtml)
		{
			string result;
			if (strHtml != "")
			{
				strHtml = strHtml.Replace(",", "&def");
				strHtml = strHtml.Replace("'", "&dot");
				strHtml = strHtml.Replace(";", "&dec");
				result = strHtml;
			}
			else
			{
				result = "";
			}
			return result;
		}
		public static string StrFilter(string string_1, string bantext)
		{
			string[] array = Utils.SplitString(bantext, "\r\n");
			for (int i = 0; i < array.Length; i++)
			{
				string oldValue = array[i].Substring(0, array[i].IndexOf("="));
				string newValue = array[i].Substring(array[i].IndexOf("=") + 1);
				string_1 = string_1.Replace(oldValue, newValue);
			}
			return string_1;
		}
		public static string GetStaticPageNumbers(int curPage, int countPage, string string_1, string expname, int extendPage)
		{
			int num = 1;
			string value = string.Concat(new string[]
			{
				"<a href=\"",
				string_1,
				"-1",
				expname,
				"\">&laquo;</a>"
			});
			string value2 = string.Concat(new object[]
			{
				"<a href=\"",
				string_1,
				"-",
				countPage,
				expname,
				"\">&raquo;</a>"
			});
			if (countPage < 1)
			{
				countPage = 1;
			}
			if (extendPage < 3)
			{
				extendPage = 2;
			}
			int num2;
			if (countPage > extendPage)
			{
				if (curPage - extendPage / 2 > 0)
				{
					if (curPage + extendPage / 2 < countPage)
					{
						num = curPage - extendPage / 2;
						num2 = num + extendPage - 1;
					}
					else
					{
						num2 = countPage;
						num = num2 - extendPage + 1;
						value2 = "";
					}
				}
				else
				{
					num2 = extendPage;
					value = "";
				}
			}
			else
			{
				num = 1;
				num2 = countPage;
				value = "";
				value2 = "";
			}
			StringBuilder stringBuilder = new StringBuilder("");
			stringBuilder.Append(value);
			for (int i = num; i <= num2; i++)
			{
				if (i == curPage)
				{
					stringBuilder.Append("<span>");
					stringBuilder.Append(i);
					stringBuilder.Append("</span>");
				}
				else
				{
					stringBuilder.Append("<a href=\"");
					stringBuilder.Append(string_1);
					stringBuilder.Append("-");
					stringBuilder.Append(i);
					stringBuilder.Append(expname);
					stringBuilder.Append("\">");
					stringBuilder.Append(i);
					stringBuilder.Append("</a>");
				}
			}
			stringBuilder.Append(value2);
			return stringBuilder.ToString();
		}
		public static string GetPostPageNumbers(int countPage, string string_1, string expname, int extendPage)
		{
			int num = 1;
			int num2 = 1;
			string value = string.Concat(new string[]
			{
				"<a href=\"",
				string_1,
				"-1",
				expname,
				"\">&laquo;</a>"
			});
			string value2 = string.Concat(new object[]
			{
				"<a href=\"",
				string_1,
				"-",
				countPage,
				expname,
				"\">&raquo;</a>"
			});
			if (countPage < 1)
			{
				countPage = 1;
			}
			if (extendPage < 3)
			{
				extendPage = 2;
			}
			int num3;
			if (countPage > extendPage)
			{
				if (num2 - extendPage / 2 > 0)
				{
					if (num2 + extendPage / 2 < countPage)
					{
						num = num2 - extendPage / 2;
						num3 = num + extendPage - 1;
					}
					else
					{
						num3 = countPage;
						num = num3 - extendPage + 1;
						value2 = "";
					}
				}
				else
				{
					num3 = extendPage;
					value = "";
				}
			}
			else
			{
				num = 1;
				num3 = countPage;
				value = "";
				value2 = "";
			}
			StringBuilder stringBuilder = new StringBuilder("");
			stringBuilder.Append(value);
			for (int i = num; i <= num3; i++)
			{
				stringBuilder.Append("<a href=\"");
				stringBuilder.Append(string_1);
				stringBuilder.Append("-");
				stringBuilder.Append(i);
				stringBuilder.Append(expname);
				stringBuilder.Append("\">");
				stringBuilder.Append(i);
				stringBuilder.Append("</a>");
			}
			stringBuilder.Append(value2);
			return stringBuilder.ToString();
		}
		public static string GetPageNumbers(int curPage, int countPage, string string_1, int extendPage)
		{
			return Utils.GetPageNumbers(curPage, countPage, string_1, extendPage, "page");
		}
		public static string GetPageNumbers(int curPage, int countPage, string string_1, int extendPage, string pagetag)
		{
			return Utils.GetPageNumbers(curPage, countPage, string_1, extendPage, pagetag, null);
		}
		public static string GetPageNumbers(int curPage, int countPage, string string_1, int extendPage, string pagetag, string anchor)
		{
			if (pagetag == "")
			{
				pagetag = "page";
			}
			int num = 1;
			if (string_1.IndexOf("?") > 0)
			{
				string_1 += "&";
			}
			else
			{
				string_1 += "?";
			}
			string text = string.Concat(new string[]
			{
				"<a href=\"",
				string_1,
				"&",
				pagetag,
				"=1"
			});
			string text2 = string.Concat(new object[]
			{
				"<a href=\"",
				string_1,
				"&",
				pagetag,
				"=",
				countPage
			});
			if (anchor != null)
			{
				text += anchor;
				text2 += anchor;
			}
			text += "\">&laquo;</a>";
			text2 += "\">&raquo;</a>";
			if (countPage < 1)
			{
				countPage = 1;
			}
			if (extendPage < 3)
			{
				extendPage = 2;
			}
			int num2;
			if (countPage > extendPage)
			{
				if (curPage - extendPage / 2 > 0)
				{
					if (curPage + extendPage / 2 < countPage)
					{
						num = curPage - extendPage / 2;
						num2 = num + extendPage - 1;
					}
					else
					{
						num2 = countPage;
						num = num2 - extendPage + 1;
						text2 = "";
					}
				}
				else
				{
					num2 = extendPage;
					text = "";
				}
			}
			else
			{
				num = 1;
				num2 = countPage;
				text = "";
				text2 = "";
			}
			StringBuilder stringBuilder = new StringBuilder("");
			stringBuilder.Append(text);
			for (int i = num; i <= num2; i++)
			{
				if (i == curPage)
				{
					stringBuilder.Append("<span>");
					stringBuilder.Append(i);
					stringBuilder.Append("</span>");
				}
				else
				{
					stringBuilder.Append("<a href=\"");
					stringBuilder.Append(string_1);
					stringBuilder.Append(pagetag);
					stringBuilder.Append("=");
					stringBuilder.Append(i);
					if (anchor != null)
					{
						stringBuilder.Append(anchor);
					}
					stringBuilder.Append("\">");
					stringBuilder.Append(i);
					stringBuilder.Append("</a>");
				}
			}
			stringBuilder.Append(text2);
			return stringBuilder.ToString();
		}
		public static string HtmlEncode(string string_1)
		{
			return HttpUtility.HtmlEncode(string_1);
		}
		public static string HtmlDecode(string string_1)
		{
			return HttpUtility.HtmlDecode(string_1);
		}
		public static string UrlEncode(string string_1)
		{
			return HttpUtility.UrlEncode(string_1);
		}
		public static string UrlDecode(string string_1)
		{
			return HttpUtility.UrlDecode(string_1);
		}
		public static string[] FindNoUTF8File(string Path)
		{
			StringBuilder stringBuilder = new StringBuilder();
			DirectoryInfo directoryInfo = new DirectoryInfo(Path);
			FileInfo[] files = directoryInfo.GetFiles();
			for (int i = 0; i < files.Length; i++)
			{
				if (files[i].Extension.ToLower().Equals(".htm"))
				{
					FileStream fileStream = new FileStream(files[i].FullName, FileMode.Open, FileAccess.Read);
					bool flag = Utils.smethod_0(fileStream);
					fileStream.Close();
					if (!flag)
					{
						stringBuilder.Append(files[i].FullName);
						stringBuilder.Append("\r\n");
					}
				}
			}
			return Utils.SplitString(stringBuilder.ToString(), "\r\n");
		}
		private static bool smethod_0(FileStream fileStream_0)
		{
			bool flag = true;
			long length = fileStream_0.Length;
			byte b = 0;
			int num = 0;
			bool result;
			while ((long)num < length)
			{
				byte b2 = (byte)fileStream_0.ReadByte();
				if ((b2 & 128) != 0)
				{
					flag = false;
				}
				if (b == 0)
				{
					if (b2 >= 128)
					{
						do
						{
							b2 = (byte)(b2 << 1);
							b += 1;
						}
						while ((b2 & 128) != 0);
						b -= 1;
						if (b == 0)
						{
							result = false;
							return result;
						}
					}
				}
				else
				{
					if ((b2 & 192) != 128)
					{
						result = false;
						return result;
					}
					b -= 1;
				}
				num++;
			}
			result = (b <= 0 && !flag);
			return result;
		}
		public static string FormatBytesStr(int bytes)
		{
			string result;
			if (bytes > 1073741824)
			{
				result = ((double)(bytes / 1073741824)).ToString("0") + "G";
			}
			else if (bytes > 1048576)
			{
				result = ((double)(bytes / 1048576)).ToString("0") + "M";
			}
			else if (bytes > 1024)
			{
				result = ((double)(bytes / 1024)).ToString("0") + "K";
			}
			else
			{
				result = bytes.ToString() + "Bytes";
			}
			return result;
		}
		public static int SafeInt32(object objNum)
		{
			int result;
			if (objNum == null)
			{
				result = 0;
			}
			else
			{
				string text = objNum.ToString();
				if (Utils.IsNumeric(text))
				{
					if (text.ToString().Length > 9)
					{
						if (text.StartsWith("-"))
						{
							result = -2147483648;
						}
						else
						{
							result = 2147483647;
						}
					}
					else
					{
						result = int.Parse(text);
					}
				}
				else
				{
					result = 0;
				}
			}
			return result;
		}
		public static int StrDateDiffSeconds(string Time, int Sec)
		{
			TimeSpan timeSpan = DateTime.Now - DateTime.Parse(Time).AddSeconds((double)Sec);
			int result;
			if (timeSpan.TotalSeconds > 2147483647.0)
			{
				result = 2147483647;
			}
			else if (timeSpan.TotalSeconds < -2147483648.0)
			{
				result = -2147483648;
			}
			else
			{
				result = (int)timeSpan.TotalSeconds;
			}
			return result;
		}
		public static int StrDateDiffMinutes(string time, int minutes)
		{
			int result;
			if (time == "" || time == null)
			{
				result = 1;
			}
			else
			{
				TimeSpan timeSpan = DateTime.Now - DateTime.Parse(time).AddMinutes((double)minutes);
				if (timeSpan.TotalMinutes > 2147483647.0)
				{
					result = 2147483647;
				}
				else if (timeSpan.TotalMinutes < -2147483648.0)
				{
					result = -2147483648;
				}
				else
				{
					result = (int)timeSpan.TotalMinutes;
				}
			}
			return result;
		}
		public static int StrDateDiffHours(string time, int hours)
		{
			int result;
			if (time == "" || time == null)
			{
				result = 1;
			}
			else
			{
				TimeSpan timeSpan = DateTime.Now - DateTime.Parse(time).AddHours((double)hours);
				if (timeSpan.TotalHours > 2147483647.0)
				{
					result = 2147483647;
				}
				else if (timeSpan.TotalHours < -2147483648.0)
				{
					result = -2147483648;
				}
				else
				{
					result = (int)timeSpan.TotalHours;
				}
			}
			return result;
		}
		public static bool CreateDir(string name)
		{
			return Utils.MakeSureDirectoryPathExists(name);
		}
		public static string ReplaceStrToScript(string string_1)
		{
			string_1 = string_1.Replace("\\", "\\\\");
			string_1 = string_1.Replace("'", "\\'");
			string_1 = string_1.Replace("\"", "\\\"");
			return string_1;
		}
		public static bool IsIP(string string_1)
		{
			return Regex.IsMatch(string_1, "^((2[0-4]\\d|25[0-5]|[01]?\\d\\d?)\\.){3}(2[0-4]\\d|25[0-5]|[01]?\\d\\d?)$");
		}
		public static bool IsIPSect(string string_1)
		{
			return Regex.IsMatch(string_1, "^((2[0-4]\\d|25[0-5]|[01]?\\d\\d?)\\.){2}((2[0-4]\\d|25[0-5]|[01]?\\d\\d?|\\*)\\.)(2[0-4]\\d|25[0-5]|[01]?\\d\\d?|\\*)$");
		}
		public static bool InIPArray(string string_1, string[] iparray)
		{
			string[] array = Utils.SplitString(string_1, ".");
			int i = 0;
			bool result;
			while (i < iparray.Length)
			{
				string[] array2 = Utils.SplitString(iparray[i], ".");
				int num = 0;
				for (int j = 0; j < array2.Length; j++)
				{
					if (array2[j] == "*")
					{
						result = true;
						return result;
					}
					if (array.Length <= j || !(array2[j] == array[j]))
					{
						break;
					}
					num++;
				}
				if (num != 4)
				{
					i++;
					continue;
				}
				result = true;
				return result;
			}
			result = false;
			return result;
		}
		public static string GetAssemblyVersion()
		{
			return string.Format("{0}.{1}.{2}", Utils.fileVersionInfo_0.FileMajorPart, Utils.fileVersionInfo_0.FileMinorPart, Utils.fileVersionInfo_0.FileBuildPart);
		}
		public static string GetAssemblyProductName()
		{
			return Utils.fileVersionInfo_0.ProductName;
		}
		public static string GetAssemblyCopyright()
		{
			return Utils.fileVersionInfo_0.LegalCopyright;
		}
		[DllImport("dbgHelp", SetLastError = true)]
		private static extern bool MakeSureDirectoryPathExists(string string_1);
		public static void WriteCookie(string strName, string strValue)
		{
			HttpCookie httpCookie = HttpContext.Current.Request.Cookies[strName];
			if (httpCookie == null)
			{
				httpCookie = new HttpCookie(strName);
			}
			httpCookie.Value = strValue;
			HttpContext.Current.Response.AppendCookie(httpCookie);
		}
		public static void WriteCookie(string strName, string strValue, int expires)
		{
			HttpCookie httpCookie = HttpContext.Current.Request.Cookies[strName];
			if (httpCookie == null)
			{
				httpCookie = new HttpCookie(strName);
			}
			httpCookie.Value = strValue;
			httpCookie.Expires = DateTime.Now.AddMinutes((double)expires);
			HttpContext.Current.Response.AppendCookie(httpCookie);
		}
		public static string GetCookie(string strName)
		{
			string result;
			if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[strName] != null)
			{
				result = HttpContext.Current.Request.Cookies[strName].Value.ToString();
			}
			else
			{
				result = "";
			}
			return result;
		}
		public static string GetTrueForumPath()
		{
			string text = HttpContext.Current.Request.Path;
			if (text.LastIndexOf("/") != text.IndexOf("/"))
			{
				text = text.Substring(text.IndexOf("/"), text.LastIndexOf("/") + 1);
			}
			else
			{
				text = "/";
			}
			return text;
		}
		public static bool IsDateString(string string_1)
		{
			return Regex.IsMatch(string_1, "(\\d{4})-(\\d{1,2})-(\\d{1,2})");
		}
		public static string RemoveHtml(string content)
		{
			string pattern = "<[^>]*>";
			return Regex.Replace(content, pattern, string.Empty, RegexOptions.IgnoreCase);
		}
		public static string RemoveUnsafeHtml(string content)
		{
			content = Regex.Replace(content, "(\\<|\\s+)o([a-z]+\\s?=)", "$1$2", RegexOptions.IgnoreCase);
			content = Regex.Replace(content, "(script|frame|form|meta|behavior|style)([\\s|:|>])+", "$1.$2", RegexOptions.IgnoreCase);
			return content;
		}
		public static string RemoveFontTag(string title)
		{
			Match match = Utils.RegexFont.Match(title);
			string result;
			if (match.Success)
			{
				result = match.Groups[1].Value;
			}
			else
			{
				result = title;
			}
			return result;
		}
		public static bool IsNumeric(object Expression)
		{
			return TypeParse.IsNumeric(Expression);
		}
		public static string GetTextFromHTML(string HTML)
		{
			Regex regex = new Regex("</?(?!br|/?p|img)[^>]*>", RegexOptions.IgnoreCase);
			return regex.Replace(HTML, "");
		}
		public static bool IsDouble(object Expression)
		{
			return TypeParse.IsDouble(Expression);
		}
		public static bool StrToBool(object Expression, bool defValue)
		{
			return TypeParse.StrToBool(Expression, defValue);
		}
		public static int StrToInt(object Expression, int defValue)
		{
			return TypeParse.StrToInt(Expression, defValue);
		}
		public static float StrToFloat(object strValue, float defValue)
		{
			return TypeParse.StrToFloat(strValue, defValue);
		}
		public static bool IsNumericArray(string[] strNumber)
		{
			return TypeParse.IsNumericArray(strNumber);
		}
		public static string AdDeTime(int times)
		{
			return DateTime.Now.AddMinutes((double)times).ToString();
		}
		public static bool IsInt(string string_1)
		{
			return Regex.IsMatch(string_1, "^[0-9]*$");
		}
		public static bool IsRuleTip(Hashtable NewHash, string ruletype, out string string_1)
		{
			string_1 = "";
			bool result;
			foreach (DictionaryEntry dictionaryEntry in NewHash)
			{
				try
				{
					string[] array = Utils.SplitString(dictionaryEntry.Value.ToString(), "\r\n");
					string[] array2 = array;
					for (int i = 0; i < array2.Length; i++)
					{
						string text = array2[i];
						if (text != "")
						{
							string text2 = ruletype.Trim().ToLower();
							if (text2 != null)
							{
								if (!(text2 == "email"))
								{
									if (!(text2 == "ip"))
									{
										if (text2 == "timesect")
										{
											string[] array3 = text.Split(new char[]
											{
												'-'
											});
											if (!Utils.IsTime(array3[1].ToString()) || !Utils.IsTime(array3[0].ToString()))
											{
												throw new Exception();
											}
										}
									}
									else if (!Utils.IsIPSect(text.ToString()))
									{
										throw new Exception();
									}
								}
								else if (!Utils.IsValidDoEmail(text.ToString()))
								{
									throw new Exception();
								}
							}
						}
					}
				}
				catch
				{
					string_1 = dictionaryEntry.Key.ToString();
					result = false;
					return result;
				}
			}
			result = true;
			return result;
		}
		public static string ClearLastChar(string string_1)
		{
			string result;
			if (string_1 == "")
			{
				result = "";
			}
			else
			{
				result = string_1.Substring(0, string_1.Length - 1);
			}
			return result;
		}
		public static bool BackupFile(string sourceFileName, string destFileName, bool overwrite)
		{
			if (!File.Exists(sourceFileName))
			{
				throw new FileNotFoundException(sourceFileName + "文件不存在！");
			}
			bool result;
			if (!overwrite && File.Exists(destFileName))
			{
				result = false;
			}
			else
			{
				try
				{
					File.Copy(sourceFileName, destFileName, true);
					result = true;
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
			return result;
		}
		public static bool BackupFile(string sourceFileName, string destFileName)
		{
			return Utils.BackupFile(sourceFileName, destFileName, true);
		}
		public static bool RestoreFile(string backupFileName, string targetFileName, string backupTargetFileName)
		{
			try
			{
				if (!File.Exists(backupFileName))
				{
					throw new FileNotFoundException(backupFileName + "文件不存在！");
				}
				if (backupTargetFileName != null)
				{
					if (!File.Exists(targetFileName))
					{
						throw new FileNotFoundException(targetFileName + "文件不存在！无法备份此文件！");
					}
					File.Copy(targetFileName, backupTargetFileName, true);
				}
				File.Delete(targetFileName);
				File.Copy(backupFileName, targetFileName);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return true;
		}
		public static bool RestoreFile(string backupFileName, string targetFileName)
		{
			return Utils.RestoreFile(backupFileName, targetFileName, null);
		}
		public static string GetTemplateCookieName()
		{
			return Utils.string_0;
		}
		public static string SBCCaseToNumberic(string SBCCase)
		{

            char[] charArray = SBCCase.ToCharArray();
            for (int i = 0; i < (int)charArray.Length; i++)
            {
                byte[] bytes = Encoding.Unicode.GetBytes(charArray, i, 1);
                if ((int)bytes.Length == 2 && bytes[1] == 255)
                {
                    bytes[0] = (byte)(bytes[0] + 32);
                    bytes[1] = 0;
                    charArray[i] = Encoding.Unicode.GetChars(bytes)[0];
                }
            }
            return new string(charArray);
		}
		public static Color ToColor(string color)
		{
			color = color.TrimStart(new char[]
			{
				'#'
			});
			color = Regex.Replace(color.ToLower(), "[g-zG-Z]", "");
			int length = color.Length;
			Color result;
			if (length != 3)
			{
				if (length != 6)
				{
					result = Color.FromName(color);
				}
				else
				{
					char[] array = color.ToCharArray();
					int red = Convert.ToInt32(array[0].ToString() + array[1].ToString(), 16);
					int green = Convert.ToInt32(array[2].ToString() + array[3].ToString(), 16);
					int blue = Convert.ToInt32(array[4].ToString() + array[5].ToString(), 16);
					result = Color.FromArgb(red, green, blue);
				}
			}
			else
			{
				char[] array = color.ToCharArray();
				int red = Convert.ToInt32(array[0].ToString() + array[0].ToString(), 16);
				int green = Convert.ToInt32(array[1].ToString() + array[1].ToString(), 16);
				int blue = Convert.ToInt32(array[2].ToString() + array[2].ToString(), 16);
				result = Color.FromArgb(red, green, blue);
			}
			return result;
		}
	}
}
