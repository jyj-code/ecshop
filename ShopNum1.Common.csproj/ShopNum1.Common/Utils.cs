using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Xml;

namespace ShopNum1.Common
{
    public class Utils
    {
        public const string ASSEMBLY_VERSION = "3.6.601";

        public const string ASSEMBLY_YEAR = "2011";

        private static Regex regex_0;

        public static Regex RegexFont;

        public readonly static Utils.VersionInfo AssemblyFileVersion;

        private static string string_0;

        private static string[] string_1;

        public static string[] Monthes
        {
            get
            {
                string[] strArrays = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
                return strArrays;
            }
        }

        static Utils()
        {
            Utils.regex_0 = new Regex("(\\r\\n)", RegexOptions.IgnoreCase);
            Utils.RegexFont = new Regex("<font color=\".*?\">([\\s\\S]+?)</font>", Utils.GetRegexCompiledOptions());
            Utils.AssemblyFileVersion = new Utils.VersionInfo();
            Utils.string_0 = string.Format("dnttemplateid_{0}_{1}_{2}", Utils.AssemblyFileVersion.FileMajorPart, Utils.AssemblyFileVersion.FileMinorPart, Utils.AssemblyFileVersion.FileBuildPart);
            string[] strArrays = new string[] { "MSIE", "Firefox", "Opera", "Netscape", "Safari", "Lynx", "Konqueror", "Mozilla" };
            Utils.string_1 = strArrays;
        }

        public Utils()
        {
        }

        public static string AdDeTime(int times)
        {
            DateTime now = DateTime.Now;
            now = now.AddMinutes((double)times);
            return now.ToString();
        }

        public static bool BackupFile(string sourceFileName, string destFileName, bool overwrite)
        {
            bool flag;
            if (!File.Exists(sourceFileName))
            {
                throw new FileNotFoundException(string.Concat(sourceFileName, "文件不存在！"));
            }
            if ((overwrite ? true : !File.Exists(destFileName)))
            {
                try
                {
                    File.Copy(sourceFileName, destFileName, true);
                    flag = true;
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            else
            {
                flag = false;
            }
            return flag;
        }

        public static bool BackupFile(string sourceFileName, string destFileName)
        {
            return Utils.BackupFile(sourceFileName, destFileName, true);
        }

        public static bool CheckColorValue(string color)
        {
            bool flag;
            if (!Utils.StrIsNullOrEmpty(color))
            {
                color = color.Trim().Trim(new char[] { '#' });
                if ((color.Length == 3 ? true : color.Length == 6))
                {
                    flag = (Regex.IsMatch(color, "[^0-9a-f]", RegexOptions.IgnoreCase) ? false : true);
                }
                else
                {
                    flag = false;
                }
            }
            else
            {
                flag = false;
            }
            return flag;
        }

        public static string ChkSQL(string string_2)
        {
            return (string_2 == null ? "" : string_2.Replace("'", "''"));
        }

        public static string CleanInput(string strIn)
        {
            return Regex.Replace(strIn.Trim(), "[^\\w\\.@-]", "");
        }

        public static string ClearBR(string string_2)
        {
            Match i = null;
            for (i = Utils.regex_0.Match(string_2); i.Success; i = i.NextMatch())
            {
                string_2 = string_2.Replace(i.Groups[0].ToString(), "");
            }
            return string_2;
        }

        public static string ClearLastChar(string string_2)
        {
            return (string_2 == "" ? "" : string_2.Substring(0, string_2.Length - 1));
        }

        public static string ClearUBB(string sDetail)
        {
            return Regex.Replace(sDetail, "\\[[^\\]]*?\\]", string.Empty, RegexOptions.IgnoreCase);
        }

        public static string ConvertSimpleFileName(string fullname, string repstring, int leftnum, int rightnum, int charnum)
        {
            string str;
            string str1 = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string fileExtName = Utils.GetFileExtName(fullname);
            if (!Utils.StrIsNullOrEmpty(fileExtName))
            {
                int length = 0;
                int num = 0;
                num = fullname.LastIndexOf('.');
                str4 = fullname.Substring(0, num);
                length = str4.Length;
                if (num <= charnum)
                {
                    str1 = fullname;
                }
                else
                {
                    str2 = str4.Substring(0, leftnum);
                    str3 = str4.Substring(length - rightnum, rightnum);
                    if ((repstring == "" ? false : repstring != null))
                    {
                        string[] strArrays = new string[] { str2, repstring, str3, ".", fileExtName };
                        str1 = string.Concat(strArrays);
                    }
                    else
                    {
                        str1 = string.Concat(str2, str3, ".", fileExtName);
                    }
                }
                str = str1;
            }
            else
            {
                str = fullname;
            }
            return str;
        }

        public static double ConvertToUnixTimestamp(DateTime date)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Math.Floor((date - dateTime).TotalSeconds);
        }

        public static bool CreateDir(string name)
        {
            return Utils.MakeSureDirectoryPathExists(name);
        }

        public static string CutString(string string_2, int startIndex, int length)
        {
            string str;
            if (startIndex >= 0)
            {
                if (length < 0)
                {
                    length = length * -1;
                    if (startIndex - length >= 0)
                    {
                        startIndex = startIndex - length;
                    }
                    else
                    {
                        length = startIndex;
                        startIndex = 0;
                    }
                }
                if (startIndex <= string_2.Length)
                {
                    if (string_2.Length - startIndex < length)
                    {
                        length = string_2.Length - startIndex;
                    }
                    str = string_2.Substring(startIndex, length);
                    return str;
                }
                str = "";
                return str;
            }
            else if (length >= 0)
            {
                if (length + startIndex > 0)
                {
                    length = length + startIndex;
                    startIndex = 0;
                    if (string_2.Length - startIndex < length)
                    {
                        length = string_2.Length - startIndex;
                    }
                    str = string_2.Substring(startIndex, length);
                    return str;
                }
                str = "";
                return str;
            }
            else
            {
                str = "";
                return str;
            }
            if (string_2.Length - startIndex < length)
            {
                length = string_2.Length - startIndex;
            }
            str = string_2.Substring(startIndex, length);
            return str;
        }

        public static string CutString(string string_2, int startIndex)
        {
            return Utils.CutString(string_2, startIndex, string_2.Length);
        }

        public static StringBuilder DataTableToJson(DataTable dataTable_0, bool dt_dispose)
        {
            object obj;
            object[] objArray;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[\r\n");
            string[] strArrays = new string[dataTable_0.Columns.Count];
            int num = 0;
            string str = "{{";
            string lower = "";
            foreach (DataColumn column in dataTable_0.Columns)
            {
                strArrays[num] = column.Caption.ToLower().Trim();
                str = string.Concat(str, "'", column.Caption.ToLower().Trim(), "':");
                lower = column.DataType.ToString().Trim().ToLower();
                if ((lower.IndexOf("int") > 0 || lower.IndexOf("deci") > 0 || lower.IndexOf("floa") > 0 || lower.IndexOf("doub") > 0 ? false : lower.IndexOf("bool") <= 0))
                {
                    obj = str;
                    objArray = new object[] { obj, "'{", num, "}'" };
                    str = string.Concat(objArray);
                }
                else
                {
                    obj = str;
                    objArray = new object[] { obj, "{", num, "}" };
                    str = string.Concat(objArray);
                }
                str = string.Concat(str, ",");
                num++;
            }
            if (str.EndsWith(","))
            {
                str = str.Substring(0, str.Length - 1);
            }
            str = string.Concat(str, "}},");
            num = 0;
            object[] objArray1 = new object[(int)strArrays.Length];
            foreach (DataRow row in dataTable_0.Rows)
            {
                string[] strArrays1 = strArrays;
                for (int i = 0; i < (int)strArrays1.Length; i++)
                {
                    objArray1[num] = row[strArrays[num]].ToString().Trim().Replace("\\", "\\\\").Replace("'", "\\'");
                    string str1 = objArray1[num].ToString();
                    if (str1 != null)
                    {
                        if (str1 == "True")
                        {
                            objArray1[num] = "true";
                        }
                        else if (str1 == "False")
                        {
                            objArray1[num] = "false";
                        }
                    }
                    num++;
                }
                num = 0;
                stringBuilder.Append(string.Format(str, objArray1));
            }
            if (stringBuilder.ToString().EndsWith(","))
            {
                stringBuilder.Remove(stringBuilder.Length - 1, 1);
            }
            if (dt_dispose)
            {
                dataTable_0.Dispose();
            }
            return stringBuilder.Append("\r\n];");
        }

        public static StringBuilder DataTableToJSON(DataTable dataTable_0)
        {
            return Utils.DataTableToJson(dataTable_0, true);
        }

        public static string[] DistinctStringArray(string[] strArray, int maxElementLength)
        {
            Hashtable hashtables = new Hashtable();
            string[] strArrays = strArray;
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string str = strArrays[i];
                string str1 = str;
                if ((maxElementLength <= 0 ? false : str1.Length > maxElementLength))
                {
                    str1 = str1.Substring(0, maxElementLength);
                }
                hashtables[str1.Trim()] = str;
            }
            string[] strArrays1 = new string[hashtables.Count];
            hashtables.Keys.CopyTo(strArrays1, 0);
            return strArrays1;
        }

        public static string[] DistinctStringArray(string[] strArray)
        {
            return Utils.DistinctStringArray(strArray, 0);
        }

        public static string EncodeHtml(string strHtml)
        {
            string str;
            if (strHtml == "")
            {
                str = "";
            }
            else
            {
                strHtml = strHtml.Replace(",", "&def");
                strHtml = strHtml.Replace("'", "&dot");
                strHtml = strHtml.Replace(";", "&dec");
                str = strHtml;
            }
            return str;
        }

        public static bool FileExists(string filename)
        {
            return File.Exists(filename);
        }

        public static string[] FindNoUTF8File(string Path)
        {
            StringBuilder stringBuilder = new StringBuilder();
            FileInfo[] files = (new DirectoryInfo(Path)).GetFiles();
            for (int i = 0; i < (int)files.Length; i++)
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

        public static string FormatBytesStr(int bytes)
        {
            double num;
            string str;
            if (bytes > 1073741824)
            {
                num = (double)(bytes / 1073741824);
                str = string.Concat(num.ToString("0"), "G");
            }
            else if (bytes > 1048576)
            {
                num = (double)(bytes / 1048576);
                str = string.Concat(num.ToString("0"), "M");
            }
            else if (bytes <= 1024)
            {
                str = string.Concat(bytes.ToString(), "Bytes");
            }
            else
            {
                num = (double)(bytes / 1024);
                str = string.Concat(num.ToString("0"), "K");
            }
            return str;
        }

        public static string FormatDate(int date, bool chnType)
        {
            string[] strArrays;
            string str;
            string str1 = date.ToString();
            if (!(date <= 0 ? false : str1.Length == 8))
            {
                str = str1;
            }
            else if (!chnType)
            {
                strArrays = new string[] { str1.Substring(0, 4), "-", str1.Substring(4, 2), "-", str1.Substring(6) };
                str = string.Concat(strArrays);
            }
            else
            {
                strArrays = new string[] { str1.Substring(0, 4), "年", str1.Substring(4, 2), "月", str1.Substring(6), "日" };
                str = string.Concat(strArrays);
            }
            return str;
        }

        public static string FormatDate(int date)
        {
            return Utils.FormatDate(date, false);
        }

        public static string GetAjaxPageNumbers(int curPage, int countPage, string callback, int extendPage)
        {
            string str = "page";
            int num = 1;
            int num1 = 1;
            string str1 = string.Concat("<a href=\"###\" onclick=\"", string.Format(callback, string.Concat("&", str, "=1")));
            object[] objArray = new object[] { "&", str, "=", countPage };
            string str2 = string.Concat("<a href=\"###\" onclick=\"", string.Format(callback, string.Concat(objArray)));
            str1 = string.Concat(str1, "\">&laquo;</a>");
            str2 = string.Concat(str2, "\">&raquo;</a>");
            if (countPage < 1)
            {
                countPage = 1;
            }
            if (extendPage < 3)
            {
                extendPage = 2;
            }
            if (countPage <= extendPage)
            {
                num = 1;
                num1 = countPage;
                str1 = "";
                str2 = "";
            }
            else if (curPage - extendPage / 2 <= 0)
            {
                num1 = extendPage;
                str1 = "";
            }
            else if (curPage + extendPage / 2 >= countPage)
            {
                num1 = countPage;
                num = num1 - extendPage + 1;
                str2 = "";
            }
            else
            {
                num = curPage - extendPage / 2;
                num1 = num + extendPage - 1;
            }
            StringBuilder stringBuilder = new StringBuilder("");
            stringBuilder.Append(str1);
            for (int i = num; i <= num1; i++)
            {
                if (i != curPage)
                {
                    stringBuilder.Append("<a href=\"###\" onclick=\"");
                    stringBuilder.Append(string.Format(callback, string.Concat(str, "=", i)));
                    stringBuilder.Append("\">");
                    stringBuilder.Append(i);
                    stringBuilder.Append("</a>");
                }
                else
                {
                    stringBuilder.Append("<span>");
                    stringBuilder.Append(i);
                    stringBuilder.Append("</span>");
                }
            }
            stringBuilder.Append(str2);
            return stringBuilder.ToString();
        }

        public static string GetAssemblyCopyright()
        {
            return Utils.AssemblyFileVersion.LegalCopyright;
        }

        public static string GetAssemblyProductName()
        {
            return Utils.AssemblyFileVersion.ProductName;
        }

        public static string GetAssemblyVersion()
        {
            string str = string.Format("{0}.{1}.{2}", Utils.AssemblyFileVersion.FileMajorPart, Utils.AssemblyFileVersion.FileMinorPart, Utils.AssemblyFileVersion.FileBuildPart);
            return str;
        }

        public static string GetClientBrower()
        {
            string str;
            string item = HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"];
            if (!string.IsNullOrEmpty(item))
            {
                string[] string1 = Utils.string_1;
                int num = 0;
                while (num < (int)string1.Length)
                {
                    string str1 = string1[num];
                    if (item.Contains(str1))
                    {
                        str = str1;
                        return str;
                    }
                    else
                    {
                        num++;
                    }
                }
            }
            str = "Other";
            return str;
        }

        public static string GetClientOS()
        {
            string str;
            string empty = string.Empty;
            string item = HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"];
            if (item != null)
            {
                if (item.IndexOf("Win") > -1)
                {
                    empty = "Windows";
                }
                else if (item.IndexOf("Mac") > -1)
                {
                    empty = "Mac";
                }
                else if (item.IndexOf("Linux") > -1)
                {
                    empty = "Linux";
                }
                else if (item.IndexOf("FreeBSD") > -1)
                {
                    empty = "FreeBSD";
                }
                else if (item.IndexOf("SunOS") > -1)
                {
                    empty = "SunOS";
                }
                else if (item.IndexOf("OS/2") > -1)
                {
                    empty = "OS/2";
                }
                else if (item.IndexOf("AIX") <= -1)
                {
                    empty = (!Regex.IsMatch(item, "(Bot|Crawl|Spider)") ? "Other" : "Spiders");
                }
                else
                {
                    empty = "AIX";
                }
                str = empty;
            }
            else
            {
                str = "Other";
            }
            return str;
        }

        public static string GetCookie(string strName)
        {
            string str;
            str = ((HttpContext.Current.Request.Cookies == null ? true : HttpContext.Current.Request.Cookies[strName] == null) ? "" : HttpContext.Current.Request.Cookies[strName].Value.ToString());
            return str;
        }

        public static string GetCookie(string strName, string string_2)
        {
            string str;
            str = ((HttpContext.Current.Request.Cookies == null || HttpContext.Current.Request.Cookies[strName] == null ? true : HttpContext.Current.Request.Cookies[strName][string_2] == null) ? "" : HttpContext.Current.Request.Cookies[strName][string_2].ToString());
            return str;
        }

        public static string GetDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }

        public static string GetDate(string datetimestr, string replacestr)
        {
            string str;
            if (datetimestr == null)
            {
                str = replacestr;
            }
            else if (!datetimestr.Equals(""))
            {
                try
                {
                    DateTime dateTime = Convert.ToDateTime(datetimestr);
                    datetimestr = dateTime.ToString("yyyy-MM-dd").Replace("1900-01-01", replacestr);
                }
                catch
                {
                    str = replacestr;
                    return str;
                }
                str = datetimestr;
            }
            else
            {
                str = replacestr;
            }
            return str;
        }

        public static string GetDateTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static string GetDateTime(int relativeday)
        {
            DateTime now = DateTime.Now;
            now = now.AddDays((double)relativeday);
            return now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static string GetDateTimeF()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fffffff");
        }

        public static string GetEmailHostName(string strEmail)
        {
            string str;
            str = (strEmail.IndexOf("@") >= 0 ? strEmail.Substring(strEmail.LastIndexOf("@")).ToLower() : "");
            return str;
        }

        public static T GetEnum<T>(string value, T defValue)
        {
            T t;
            try
            {
                t = (T)Enum.Parse(typeof(T), value, true);
            }
            catch (ArgumentException argumentException)
            {
                t = defValue;
            }
            return t;
        }

        public static string GetFileExtName(string fileName)
        {
            string str;
            if ((Utils.StrIsNullOrEmpty(fileName) ? false : fileName.IndexOf('.') > 0))
            {
                fileName = fileName.ToLower().Trim();
                str = fileName.Substring(fileName.LastIndexOf('.'), fileName.Length - fileName.LastIndexOf('.'));
            }
            else
            {
                str = "";
            }
            return str;
        }

        public static string GetFilename(string string_2)
        {
            string str;
            if (string_2 != null)
            {
                char[] chrArray = new char[] { '/' };
                string[] strArrays = string_2.Split(chrArray);
                string str1 = strArrays[(int)strArrays.Length - 1];
                chrArray = new char[] { '?' };
                str = str1.Split(chrArray)[0];
            }
            else
            {
                str = "";
            }
            return str;
        }

        public static string GetHttpWebResponse(string string_2)
        {
            return Utils.GetHttpWebResponse(string_2, string.Empty);
        }

        public static string GetHttpWebResponse(string string_2, string postData)
        {
            string end;
            HttpWebRequest length = (HttpWebRequest)WebRequest.Create(string_2);
            length.Method = "POST";
            length.ContentType = "application/x-www-form-urlencoded";
            length.ContentLength = (long)postData.Length;
            length.Timeout = 20000;
            HttpWebResponse response = null;
            try
            {
                StreamWriter streamWriter = new StreamWriter(length.GetRequestStream());
                streamWriter.Write(postData);
                if (streamWriter != null)
                {
                    streamWriter.Close();
                }
                response = (HttpWebResponse)length.GetResponse();
                StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                try
                {
                    end = streamReader.ReadToEnd();
                }
                finally
                {
                    if (streamReader != null)
                    {
                        ((IDisposable)streamReader).Dispose();
                    }
                }
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
            }
            return end;
        }

        public static int GetInArrayID(string strSearch, string[] stringArray, bool caseInsensetive)
        {
            int num;
            int num1 = 0;
            while (true)
            {
                if (num1 < (int)stringArray.Length)
                {
                    if (caseInsensetive)
                    {
                        if (strSearch.ToLower() == stringArray[num1].ToLower())
                        {
                            num = num1;
                            break;
                        }
                    }
                    else if (strSearch == stringArray[num1])
                    {
                        num = num1;
                        break;
                    }
                    num1++;
                }
                else
                {
                    num = -1;
                    break;
                }
            }
            return num;
        }

        public static int GetInArrayID(string strSearch, string[] stringArray)
        {
            return Utils.GetInArrayID(strSearch, stringArray, true);
        }

        public static string GetMapPath(string strPath)
        {
            string str;
            if (HttpContext.Current == null)
            {
                strPath = strPath.Replace("/", "\\");
                if (strPath.StartsWith("\\"))
                {
                    strPath = strPath.Substring(strPath.IndexOf('\\', 1)).TrimStart(new char[] { '\\' });
                }
                str = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
            }
            else
            {
                str = HttpContext.Current.Server.MapPath(strPath);
            }
            return str;
        }

        public static string GetPageNumbers(int curPage, int countPage, string string_2, int extendPage)
        {
            return Utils.GetPageNumbers(curPage, countPage, string_2, extendPage, "page");
        }

        public static string GetPageNumbers(int curPage, int countPage, string string_2, int extendPage, string pagetag)
        {
            return Utils.GetPageNumbers(curPage, countPage, string_2, extendPage, pagetag, null);
        }

        public static string GetPageNumbers(int curPage, int countPage, string string_2, int extendPage, string pagetag, string anchor)
        {
            if (pagetag == "")
            {
                pagetag = "page";
            }
            int num = 1;
            int num1 = 1;
            if (string_2.IndexOf("?") <= 0)
            {
                string_2 = string.Concat(string_2, "?");
            }
            else
            {
                string_2 = string.Concat(string_2, "&");
            }
            string[] string2 = new string[] { "<a href=\"", string_2, "&", pagetag, "=1" };
            string str = string.Concat(string2);
            object[] objArray = new object[] { "<a href=\"", string_2, "&", pagetag, "=", countPage };
            string str1 = string.Concat(objArray);
            if (anchor != null)
            {
                str = string.Concat(str, anchor);
                str1 = string.Concat(str1, anchor);
            }
            str = string.Concat(str, "\">&laquo;</a>");
            str1 = string.Concat(str1, "\">&raquo;</a>");
            if (countPage < 1)
            {
                countPage = 1;
            }
            if (extendPage < 3)
            {
                extendPage = 2;
            }
            if (countPage <= extendPage)
            {
                num = 1;
                num1 = countPage;
                str = "";
                str1 = "";
            }
            else if (curPage - extendPage / 2 <= 0)
            {
                num1 = extendPage;
                str = "";
            }
            else if (curPage + extendPage / 2 >= countPage)
            {
                num1 = countPage;
                num = num1 - extendPage + 1;
                str1 = "";
            }
            else
            {
                num = curPage - extendPage / 2;
                num1 = num + extendPage - 1;
            }
            StringBuilder stringBuilder = new StringBuilder("");
            stringBuilder.Append(str);
            for (int i = num; i <= num1; i++)
            {
                if (i != curPage)
                {
                    stringBuilder.Append("<a href=\"");
                    stringBuilder.Append(string_2);
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
                else
                {
                    stringBuilder.Append("<span>");
                    stringBuilder.Append(i);
                    stringBuilder.Append("</span>");
                }
            }
            stringBuilder.Append(str1);
            return stringBuilder.ToString();
        }

        public static string GetRealIP()
        {
            return ShopNum1Request.GetIP();
        }

        public static RegexOptions GetRegexCompiledOptions()
        {
            return RegexOptions.None;
        }

        public static string GetRootUrl(string forumPath)
        {
            int port = HttpContext.Current.Request.Url.Port;
            object[] scheme = new object[] { HttpContext.Current.Request.Url.Scheme, HttpContext.Current.Request.Url.Host.ToString(), null, null };
            scheme[2] = (port == 80 || port == 0 ? "" : string.Concat(":", port));
            scheme[3] = forumPath;
            return string.Format("{0}://{1}{2}{3}", scheme);
        }

        public static string GetSourceTextByUrl(string string_2)
        {
            string end;
            try
            {
                WebRequest webRequest = WebRequest.Create(string_2);
                webRequest.Timeout = 20000;
                WebResponse response = webRequest.GetResponse();
                end = (new StreamReader(response.GetResponseStream())).ReadToEnd();
            }
            catch
            {
                end = "";
            }
            return end;
        }

        public static string GetSpacesString(int spacesCount)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < spacesCount; i++)
            {
                stringBuilder.Append(" &nbsp;&nbsp;");
            }
            return stringBuilder.ToString();
        }

        public static string GetStandardDate(string fDate)
        {
            return Utils.GetStandardDateTime(fDate, "yyyy-MM-dd");
        }

        public static string GetStandardDateTime(string fDateTime, string formatStr)
        {
            string str;
            if (fDateTime != "0000-0-0 0:00:00")
            {
                DateTime dateTime = new DateTime(1900, 1, 1, 0, 0, 0, 0);
                str = (!DateTime.TryParse(fDateTime, out dateTime) ? "N/A" : dateTime.ToString(formatStr));
            }
            else
            {
                str = fDateTime;
            }
            return str;
        }

        public static string GetStandardDateTime(string fDateTime)
        {
            return Utils.GetStandardDateTime(fDateTime, "yyyy-MM-dd HH:mm:ss");
        }

        public static string GetStaticPageNumbers(int curPage, int countPage, string string_2, string expname, int extendPage)
        {
            return Utils.GetStaticPageNumbers(curPage, countPage, string_2, expname, extendPage, 0);
        }

        public static string GetStaticPageNumbers(int curPage, int countPage, string string_2, string expname, int extendPage, int forumrewrite)
        {
            int num = 1;
            int num1 = 1;
            string[] string2 = new string[] { "<a href=\"", string_2, "-1", expname, "\">&laquo;</a>" };
            string str = string.Concat(string2);
            object[] objArray = new object[] { "<a href=\"", string_2, "-", countPage, expname, "\">&raquo;</a>" };
            string str1 = string.Concat(objArray);
            if (forumrewrite == 1)
            {
                string2 = new string[] { "<a href=\"", string_2, "/1/list", expname, "\">&laquo;</a>" };
                str = string.Concat(string2);
                objArray = new object[] { "<a href=\"", string_2, "/", countPage, "/list", expname, "\">&raquo;</a>" };
                str1 = string.Concat(objArray);
            }
            if (forumrewrite == 2)
            {
                str = string.Concat("<a href=\"", string_2, "/\">&laquo;</a>");
                objArray = new object[] { "<a href=\"", string_2, "/", countPage, "/\">&raquo;</a>" };
                str1 = string.Concat(objArray);
            }
            if (countPage < 1)
            {
                countPage = 1;
            }
            if (extendPage < 3)
            {
                extendPage = 2;
            }
            if (countPage <= extendPage)
            {
                num = 1;
                num1 = countPage;
                str = "";
                str1 = "";
            }
            else if (curPage - extendPage / 2 <= 0)
            {
                num1 = extendPage;
                str = "";
            }
            else if (curPage + extendPage / 2 >= countPage)
            {
                num1 = countPage;
                num = num1 - extendPage + 1;
                str1 = "";
            }
            else
            {
                num = curPage - extendPage / 2;
                num1 = num + extendPage - 1;
            }
            StringBuilder stringBuilder = new StringBuilder("");
            stringBuilder.Append(str);
            for (int i = num; i <= num1; i++)
            {
                if (i != curPage)
                {
                    stringBuilder.Append("<a href=\"");
                    if (forumrewrite == 1)
                    {
                        stringBuilder.Append(string_2);
                        if (i != 1)
                        {
                            stringBuilder.Append("/");
                            stringBuilder.Append(i);
                        }
                        stringBuilder.Append("/list");
                        stringBuilder.Append(expname);
                    }
                    else if (forumrewrite != 2)
                    {
                        stringBuilder.Append(string_2);
                        if (i != 1)
                        {
                            stringBuilder.Append("-");
                            stringBuilder.Append(i);
                        }
                        stringBuilder.Append(expname);
                    }
                    else
                    {
                        stringBuilder.Append(string_2);
                        stringBuilder.Append("/");
                        if (i != 1)
                        {
                            stringBuilder.Append(i);
                            stringBuilder.Append("/");
                        }
                    }
                    stringBuilder.Append("\">");
                    stringBuilder.Append(i);
                    stringBuilder.Append("</a>");
                }
                else
                {
                    stringBuilder.Append("<span>");
                    stringBuilder.Append(i);
                    stringBuilder.Append("</span>");
                }
            }
            stringBuilder.Append(str1);
            return stringBuilder.ToString();
        }

        public static int GetStringLength(string string_2)
        {
            return (int)Encoding.Default.GetBytes(string_2).Length;
        }

        public static string GetSubString(string p_SrcString, int p_Length, string p_TailString)
        {
            return Utils.GetSubString(p_SrcString, 0, p_Length, p_TailString);
        }

        public static string GetSubString(string p_SrcString, int p_StartIndex, int p_Length, string p_TailString)
        {
            string str;
            bool flag;
            string pSrcString = p_SrcString;
            byte[] bytes = Encoding.UTF8.GetBytes(p_SrcString);
            char[] chars = Encoding.UTF8.GetChars(bytes);
            int num = 0;
            while (true)
            {
                if (num < (int)chars.Length)
                {
                    char chr = chars[num];
                    if (chr <= '\u0800' || chr >= '\u4E00')
                    {
                        flag = (chr <= '\uAC00' ? true : chr >= '\uD7A3');
                    }
                    else
                    {
                        flag = false;
                    }
                    if (flag)
                    {
                        num++;
                    }
                    else if (p_StartIndex < p_SrcString.Length)
                    {
                        str = p_SrcString.Substring(p_StartIndex, (p_Length + p_StartIndex > p_SrcString.Length ? p_SrcString.Length - p_StartIndex : p_Length));
                        break;
                    }
                    else
                    {
                        str = "";
                        break;
                    }
                }
                else
                {
                    if (p_Length >= 0)
                    {
                        byte[] numArray = Encoding.Default.GetBytes(p_SrcString);
                        if ((int)numArray.Length > p_StartIndex)
                        {
                            int length = (int)numArray.Length;
                            if ((int)numArray.Length <= p_StartIndex + p_Length)
                            {
                                p_Length = (int)numArray.Length - p_StartIndex;
                                p_TailString = "";
                            }
                            else
                            {
                                length = p_Length + p_StartIndex;
                            }
                            int pLength = p_Length;
                            int[] numArray1 = new int[p_Length];
                            byte[] numArray2 = null;
                            int num1 = 0;
                            for (int i = p_StartIndex; i < length; i++)
                            {
                                if (numArray[i] <= 127)
                                {
                                    num1 = 0;
                                }
                                else
                                {
                                    num1++;
                                    if (num1 == 3)
                                    {
                                        num1 = 1;
                                    }
                                }
                                numArray1[i] = num1;
                            }
                            if ((numArray[length - 1] <= 127 ? false : numArray1[p_Length - 1] == 1))
                            {
                                pLength = p_Length + 1;
                            }
                            numArray2 = new byte[pLength];
                            Array.Copy(numArray, p_StartIndex, numArray2, 0, pLength);
                            pSrcString = Encoding.Default.GetString(numArray2);
                            pSrcString = string.Concat(pSrcString, p_TailString);
                        }
                    }
                    str = pSrcString;
                    break;
                }
            }
            return str;
        }

        public static string GetTemplateCookieName()
        {
            return Utils.string_0;
        }

        public static string GetTextFromHTML(string HTML)
        {
            return (new Regex("</?(?!br|/?p|img)[^>]*>", RegexOptions.IgnoreCase)).Replace(HTML, "");
        }

        public static string GetTime()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }

        public static string GetTrueForumPath()
        {
            string path = HttpContext.Current.Request.Path;
            path = (path.LastIndexOf("/") == path.IndexOf("/") ? "/" : path.Substring(path.IndexOf("/"), path.LastIndexOf("/") + 1));
            return path;
        }

        public static string GetUnicodeSubString(string string_2, int int_0, string p_TailString)
        {
            string_2 = string_2.TrimEnd(new char[0]);
            string empty = string.Empty;
            int byteCount = Encoding.Default.GetByteCount(string_2);
            int length = string_2.Length;
            int num = 0;
            int num1 = 0;
            if (byteCount <= int_0)
            {
                empty = string_2;
            }
            else
            {
                int num2 = 0;
                while (true)
                {
                    if (num2 < length)
                    {
                        num = (Convert.ToInt32(string_2.ToCharArray()[num2]) <= 255 ? num + 1 : num + 2);
                        if (num > int_0)
                        {
                            num1 = num2;
                            break;
                        }
                        else if (num == int_0)
                        {
                            num1 = num2 + 1;
                            break;
                        }
                        else
                        {
                            num2++;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                if (num1 >= 0)
                {
                    empty = string.Concat(string_2.Substring(0, num1), p_TailString);
                }
            }
            return empty;
        }

        public static string HtmlDecode(string string_2)
        {
            return HttpUtility.HtmlDecode(string_2);
        }

        public static string HtmlEncode(string string_2)
        {
            return HttpUtility.HtmlEncode(string_2);
        }

        public static bool InArray(string strSearch, string[] stringArray, bool caseInsensetive)
        {
            return Utils.GetInArrayID(strSearch, stringArray, caseInsensetive) >= 0;
        }

        public static bool InArray(string string_2, string[] stringarray)
        {
            return Utils.InArray(string_2, stringarray, false);
        }

        public static bool InArray(string string_2, string stringarray)
        {
            return Utils.InArray(string_2, Utils.SplitString(stringarray, ","), false);
        }

        public static bool InArray(string string_2, string stringarray, string strsplit)
        {
            return Utils.InArray(string_2, Utils.SplitString(stringarray, strsplit), false);
        }

        public static bool InArray(string string_2, string stringarray, string strsplit, bool caseInsensetive)
        {
            return Utils.InArray(string_2, Utils.SplitString(stringarray, strsplit), caseInsensetive);
        }

        public static bool InIPArray(string string_2, string[] iparray)
        {
            bool flag;
            string[] strArrays = Utils.SplitString(string_2, ".");
            int num = 0;
            while (true)
            {
                if (num < (int)iparray.Length)
                {
                    string[] strArrays1 = Utils.SplitString(iparray[num], ".");
                    int num1 = 0;
                    int num2 = 0;
                    while (num2 < (int)strArrays1.Length)
                    {
                        if (strArrays1[num2] == "*")
                        {
                            flag = true;
                            return flag;
                        }
                        else
                        {
                            if ((int)strArrays.Length <= num2 || !(strArrays1[num2] == strArrays[num2]))
                            {
                                break;
                            }
                            num1++;
                            num2++;
                        }
                    }
                    if (num1 == 4)
                    {
                        flag = true;
                        break;
                    }
                    else
                    {
                        num++;
                    }
                }
                else
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }

        public static string IntToStr(int intValue)
        {
            return Convert.ToString(intValue);
        }

        public static bool IsBase64String(string string_2)
        {
            return Regex.IsMatch(string_2, "[A-Za-z0-9\\+\\/\\=]");
        }

        public static bool IsCompriseStr(string string_2, string stringarray, string strsplit)
        {
            bool flag;
            if (!Utils.StrIsNullOrEmpty(stringarray))
            {
                string_2 = string_2.ToLower();
                string[] strArrays = Utils.SplitString(stringarray.ToLower(), strsplit);
                int num = 0;
                while (num < (int)strArrays.Length)
                {
                    if (string_2.IndexOf(strArrays[num]) > -1)
                    {
                        flag = true;
                        return flag;
                    }
                    else
                    {
                        num++;
                    }
                }
                flag = false;
            }
            else
            {
                flag = false;
            }
            return flag;
        }

        public static bool IsDateString(string string_2)
        {
            return Regex.IsMatch(string_2, "(\\d{4})-(\\d{1,2})-(\\d{1,2})");
        }

        public static bool IsDouble(object Expression)
        {
            return Validator.IsDouble(Expression);
        }

        public static bool IsIE()
        {
            return HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"].IndexOf("MSIE") >= 0;
        }

        public static bool IsImgFilename(string filename)
        {
            bool flag;
            filename = filename.Trim();
            if ((filename.EndsWith(".") ? false : filename.IndexOf(".") != -1))
            {
                string lower = filename.Substring(filename.LastIndexOf(".") + 1).ToLower();
                flag = (lower == "jpg" || lower == "jpeg" || lower == "png" || lower == "bmp" ? true : lower == "gif");
            }
            else
            {
                flag = false;
            }
            return flag;
        }

        public static bool IsInt(string string_2)
        {
            return Regex.IsMatch(string_2, "^[0-9]*$");
        }

        public static bool IsIP(string string_2)
        {
            return Regex.IsMatch(string_2, "^((2[0-4]\\d|25[0-5]|[01]?\\d\\d?)\\.){3}(2[0-4]\\d|25[0-5]|[01]?\\d\\d?)$");
        }

        public static bool IsIPSect(string string_2)
        {
            return Regex.IsMatch(string_2, "^((2[0-4]\\d|25[0-5]|[01]?\\d\\d?)\\.){2}((2[0-4]\\d|25[0-5]|[01]?\\d\\d?|\\*)\\.)(2[0-4]\\d|25[0-5]|[01]?\\d\\d?|\\*)$");
        }

        public static bool IsNumeric(object Expression)
        {
            return Validator.IsNumeric(Expression);
        }

        public static bool IsNumericArray(string[] strNumber)
        {
            return Validator.IsNumericArray(strNumber);
        }

        public static bool IsNumericList(string numList)
        {
            bool flag;
            if (!Utils.StrIsNullOrEmpty(numList))
            {
                char[] chrArray = new char[] { ',' };
                flag = Utils.IsNumericArray(numList.Split(chrArray));
            }
            else
            {
                flag = false;
            }
            return flag;
        }

        public static bool IsRuleTip(Hashtable NewHash, string ruletype, out string string_2)
        {
            bool flag;
            string_2 = "";
            foreach (DictionaryEntry newHash in NewHash)
            {
                try
                {
                    string[] strArrays = Utils.SplitString(newHash.Value.ToString(), "\r\n");
                    string[] strArrays1 = strArrays;
                    for (int i = 0; i < (int)strArrays1.Length; i++)
                    {
                        string str = strArrays1[i];
                        if (str != "")
                        {
                            string lower = ruletype.Trim().ToLower();
                            if (lower != null)
                            {
                                if (lower == "email")
                                {
                                    if (!Utils.IsValidDoEmail(str.ToString()))
                                    {
                                        throw new Exception();
                                    }
                                }
                                else if (lower != "ip")
                                {
                                    if (lower == "timesect")
                                    {
                                        string[] strArrays2 = str.Split(new char[] { '-' });
                                        if ((!Utils.IsTime(strArrays2[1].ToString()) ? true : !Utils.IsTime(strArrays2[0].ToString())))
                                        {
                                            throw new Exception();
                                        }
                                    }
                                }
                                else if (!Utils.IsIPSect(str.ToString()))
                                {
                                    throw new Exception();
                                }
                            }
                        }
                    }
                }
                catch
                {
                    string_2 = newHash.Key.ToString();
                    flag = false;
                    return flag;
                }
            }
            flag = true;
            return flag;
        }

        public static bool IsSafeSqlString(string string_2)
        {
            return !Regex.IsMatch(string_2, "[-|;|,|\\/|\\(|\\)|\\[|\\]|\\}|\\{|%|@|\\*|!|\\']");
        }

        public static bool IsSafeUserInfoString(string string_2)
        {
            return !Regex.IsMatch(string_2, "^\\s*$|^c:\\\\con\\\\con$|[%,\\*\"\\s\\t\\<\\>\\&]|游客|^Guest");
        }

        public static bool IsTime(string timeval)
        {
            return Regex.IsMatch(timeval, "^((([0-1]?[0-9])|(2[0-3])):([0-5]?[0-9])(:[0-5]?[0-9])?)$");
        }

        public static bool IsURL(string strUrl)
        {
            return Regex.IsMatch(strUrl, "^(http|https)\\://([a-zA-Z0-9\\.\\-]+(\\:[a-zA-Z0-9\\.&%\\$\\-]+)*@)*((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|localhost|([a-zA-Z0-9\\-]+\\.)*[a-zA-Z0-9\\-]+\\.(com|edu|gov|int|mil|net|org|biz|arpa|info|name|pro|aero|coop|museum|[a-zA-Z]{1,10}))(\\:[0-9]+)*(/($|[a-zA-Z0-9\\.\\,\\?\\'\\\\\\+&%\\$#\\=~_\\-]+))*$");
        }

        public static bool IsValidDoEmail(string strEmail)
        {
            return Regex.IsMatch(strEmail, "^@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([\\w-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$");
        }

        public static bool IsValidEmail(string strEmail)
        {
            return Regex.IsMatch(strEmail, "^[\\w\\.]+([-]\\w+)*@[A-Za-z0-9-_]+[\\.][A-Za-z0-9-_]");
        }

        public static string JsonCharFilter(string sourceStr)
        {
            sourceStr = sourceStr.Replace("\\", "\\\\");
            sourceStr = sourceStr.Replace("\b", "\\\b");
            sourceStr = sourceStr.Replace("\t", "\\\t");
            sourceStr = sourceStr.Replace("\n", "\\\n");
            sourceStr = sourceStr.Replace("\n", "\\\n");
            sourceStr = sourceStr.Replace("\f", "\\\f");
            sourceStr = sourceStr.Replace("\r", "\\\r");
            return sourceStr.Replace("\"", "\\\"");
        }

        [DllImport("dbgHelp", CharSet = CharSet.None, ExactSpelling = false, SetLastError = true)]
        private static extern bool MakeSureDirectoryPathExists(string string_2);

        public static string mashSQL(string string_2)
        {
            return (string_2 == null ? "" : string_2.Replace("'", "'"));
        }

        public static string MD5(string string_2)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(string_2);
            bytes = (new MD5CryptoServiceProvider()).ComputeHash(bytes);
            string str = "";
            for (int i = 0; i < (int)bytes.Length; i++)
            {
                str = string.Concat(str, bytes[i].ToString("x").PadLeft(2, '0'));
            }
            return str;
        }

        public static string MergeString(string source, string target)
        {
            return Utils.MergeString(source, target, ",");
        }

        public static string MergeString(string source, string target, string mergechar)
        {
            if (!Utils.StrIsNullOrEmpty(target))
            {
                target = string.Concat(target, mergechar, source);
            }
            else
            {
                target = source;
            }
            return target;
        }

        public static string[] PadStringArray(string[] strArray, int minLength, int maxLength)
        {
            int i;
            if (minLength > maxLength)
            {
                int num = maxLength;
                maxLength = minLength;
                minLength = num;
            }
            int num1 = 0;
            for (i = 0; i < (int)strArray.Length; i++)
            {
                if ((minLength <= -1 ? true : strArray[i].Length >= minLength))
                {
                    if (strArray[i].Length > maxLength)
                    {
                        strArray[i] = strArray[i].Substring(0, maxLength);
                    }
                    num1++;
                }
                else
                {
                    strArray[i] = null;
                }
            }
            string[] strArrays = new string[num1];
            i = 0;
            int num2 = 0;
            while (true)
            {
                if ((i >= (int)strArray.Length ? true : num2 >= (int)strArrays.Length))
                {
                    break;
                }
                if ((strArray[i] == null ? false : strArray[i] != string.Empty))
                {
                    strArrays[num2] = strArray[i];
                    num2++;
                }
                i++;
            }
            return strArrays;
        }

        public static string RemoveFontTag(string title)
        {
            string str;
            Match match = Utils.RegexFont.Match(title);
            str = (!match.Success ? title : match.Groups[1].Value);
            return str;
        }

        public static string RemoveHtml(string content)
        {
            return Regex.Replace(content, "<[^>]*>", string.Empty, RegexOptions.IgnoreCase);
        }

        public static string RemoveUnsafeHtml(string content)
        {
            content = Regex.Replace(content, "(\\<|\\s+)o([a-z]+\\s?=)", "$1$2", RegexOptions.IgnoreCase);
            content = Regex.Replace(content, "(script|frame|form|meta|behavior|style)([\\s|:|>])+", "$1.$2", RegexOptions.IgnoreCase);
            return content;
        }

        public static string ReplaceString(string SourceString, string SearchString, string ReplaceString, bool IsCaseInsensetive)
        {
            return Regex.Replace(SourceString, Regex.Escape(SearchString), ReplaceString, (IsCaseInsensetive ? RegexOptions.IgnoreCase : RegexOptions.None));
        }

        public static string ReplaceStrToScript(string string_2)
        {
            string str = string_2.Replace("\\", "\\\\").Replace("'", "\\'").Replace("\"", "\\\"");
            return str;
        }

        public static void ResponseFile(string filepath, string filename, string filetype)
        {
            Stream fileStream = null;
            byte[] numArray = new byte[10000];
            try
            {
                try
                {
                    fileStream = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    long length = fileStream.Length;
                    HttpContext.Current.Response.ContentType = filetype;
                    if (HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"].IndexOf("MSIE") <= -1)
                    {
                        HttpContext.Current.Response.AddHeader("Content-Disposition", string.Concat("attachment;filename=", filename.Trim()));
                    }
                    else
                    {
                        HttpContext.Current.Response.AddHeader("Content-Disposition", string.Concat("attachment;filename=", Utils.UrlEncode(filename.Trim()).Replace("+", " ")));
                    }
                    while (length > 0L)
                    {
                        if (!HttpContext.Current.Response.IsClientConnected)
                        {
                            length = -1L;
                        }
                        else
                        {
                            int num = fileStream.Read(numArray, 0, 10000);
                            HttpContext.Current.Response.OutputStream.Write(numArray, 0, num);
                            HttpContext.Current.Response.Flush();
                            numArray = new byte[10000];
                            length = length - (long)num;
                        }
                    }
                }
                catch (Exception exception1)
                {
                    Exception exception = exception1;
                    HttpContext.Current.Response.Write(string.Concat("Error : ", exception.Message));
                }
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }
            HttpContext.Current.Response.End();
        }

        public static void RestartIISProcess()
        {
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(Utils.GetMapPath("~/web.config"));
                XmlTextWriter xmlTextWriter = new XmlTextWriter(Utils.GetMapPath("~/web.config"), null)
                {
                    Formatting = Formatting.Indented
                };
                xmlDocument.WriteTo(xmlTextWriter);
                xmlTextWriter.Flush();
                xmlTextWriter.Close();
            }
            catch
            {
            }
        }

        public static bool RestoreFile(string backupFileName, string targetFileName, string backupTargetFileName)
        {
            try
            {
                if (!File.Exists(backupFileName))
                {
                    throw new FileNotFoundException(string.Concat(backupFileName, "文件不存在！"));
                }
                if (backupTargetFileName != null)
                {
                    if (!File.Exists(targetFileName))
                    {
                        throw new FileNotFoundException(string.Concat(targetFileName, "文件不存在！无法备份此文件！"));
                    }
                    File.Copy(targetFileName, backupTargetFileName, true);
                }
                File.Delete(targetFileName);
                File.Copy(backupFileName, targetFileName);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return true;
        }

        public static bool RestoreFile(string backupFileName, string targetFileName)
        {
            return Utils.RestoreFile(backupFileName, targetFileName, null);
        }

        public static string RTrim(string string_2)
        {
            for (int i = string_2.Length; i >= 0; i--)
            {
                if ((string_2[i].Equals(" ") || string_2[i].Equals("\r") ? true : string_2[i].Equals("\n")))
                {
                    string_2.Remove(i, 1);
                }
            }
            return string_2;
        }

        public static int SafeInt32(object objNum)
        {
            int num;
            if (objNum != null)
            {
                string str = objNum.ToString();
                if (!Utils.IsNumeric(str))
                {
                    num = 0;
                }
                else if (str.ToString().Length <= 9)
                {
                    num = int.Parse(str);
                }
                else
                {
                    num = (!str.StartsWith("-") ? 2147483647 : -2147483648);
                }
            }
            else
            {
                num = 0;
            }
            return num;
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

        public static string SHA256(string string_2)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(string_2);
            return Convert.ToBase64String((new SHA256Managed()).ComputeHash(bytes));
        }

        private static bool smethod_0(FileStream fileStream_0)
        {
            bool flag;
            bool flag1 = true;
            long length = fileStream_0.Length;
            byte num = 0;
            int num1 = 0;
            while (true)
            {
                if ((long)num1 < length)
                {
                    byte num2 = (byte)fileStream_0.ReadByte();
                    if ((num2 & 128) != 0)
                    {
                        flag1 = false;
                    }
                    if (num == 0)
                    {
                        if (num2 >= 128)
                        {
                            do
                            {
                                num2 = (byte)(num2 << 1);
                                num = (byte)(num + 1);
                            }
                            while ((num2 & 128) != 0);
                            num = (byte)(num - 1);
                            if (num == 0)
                            {
                                flag = false;
                                break;
                            }
                        }
                    }
                    else if ((num2 & 192) != 128)
                    {
                        flag = false;
                        break;
                    }
                    else
                    {
                        num = (byte)(num - 1);
                    }
                    num1++;
                }
                else if (num > 0)
                {
                    flag = false;
                    break;
                }
                else if (!flag1)
                {
                    flag = true;
                    break;
                }
                else
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }

        public static string[] SplitString(string strContent, string strSplit)
        {
            string[] strArrays;
            if (Utils.StrIsNullOrEmpty(strContent))
            {
                strArrays = new string[0];
            }
            else
            {
                strArrays = (strContent.IndexOf(strSplit) >= 0 ? Regex.Split(strContent, Regex.Escape(strSplit), RegexOptions.IgnoreCase) : new string[] { strContent });
            }
            return strArrays;
        }

        public static string[] SplitString(string strContent, string strSplit, int count)
        {
            string[] empty = new string[count];
            string[] strArrays = Utils.SplitString(strContent, strSplit);
            for (int i = 0; i < count; i++)
            {
                if (i >= (int)strArrays.Length)
                {
                    empty[i] = string.Empty;
                }
                else
                {
                    empty[i] = strArrays[i];
                }
            }
            return empty;
        }

        public static string[] SplitString(string strContent, string strSplit, bool ignoreRepeatItem, int maxElementLength)
        {
            string[] strArrays = Utils.SplitString(strContent, strSplit);
            return (ignoreRepeatItem ? Utils.DistinctStringArray(strArrays, maxElementLength) : strArrays);
        }

        public static string[] SplitString(string strContent, string strSplit, bool ignoreRepeatItem, int minElementLength, int maxElementLength)
        {
            string[] strArrays = Utils.SplitString(strContent, strSplit);
            if (ignoreRepeatItem)
            {
                strArrays = Utils.DistinctStringArray(strArrays);
            }
            return Utils.PadStringArray(strArrays, minElementLength, maxElementLength);
        }

        public static string[] SplitString(string strContent, string strSplit, bool ignoreRepeatItem)
        {
            return Utils.SplitString(strContent, strSplit, ignoreRepeatItem, 0);
        }

        public static int StrDateDiffHours(string time, int hours)
        {
            int num;
            if (!Utils.StrIsNullOrEmpty(time))
            {
                DateTime dateTime = TypeConverter.StrToDateTime(time, DateTime.Parse("1900-01-01"));
                if (dateTime.ToString("yyyy-MM-dd") != "1900-01-01")
                {
                    TimeSpan now = DateTime.Now - dateTime.AddHours((double)hours);
                    if (now.TotalHours <= 2147483647)
                    {
                        num = (now.TotalHours >= -2147483648 ? (int)now.TotalHours : -2147483648);
                    }
                    else
                    {
                        num = 2147483647;
                    }
                }
                else
                {
                    num = 1;
                }
            }
            else
            {
                num = 1;
            }
            return num;
        }

        public static int StrDateDiffMinutes(string time, int minutes)
        {
            int num;
            if (!Utils.StrIsNullOrEmpty(time))
            {
                DateTime dateTime = TypeConverter.StrToDateTime(time, DateTime.Parse("1900-01-01"));
                if (dateTime.ToString("yyyy-MM-dd") != "1900-01-01")
                {
                    TimeSpan now = DateTime.Now - dateTime.AddMinutes((double)minutes);
                    if (now.TotalMinutes <= 2147483647)
                    {
                        num = (now.TotalMinutes >= -2147483648 ? (int)now.TotalMinutes : -2147483648);
                    }
                    else
                    {
                        num = 2147483647;
                    }
                }
                else
                {
                    num = 1;
                }
            }
            else
            {
                num = 1;
            }
            return num;
        }

        public static int StrDateDiffSeconds(string time, int Sec)
        {
            int num;
            if (!Utils.StrIsNullOrEmpty(time))
            {
                DateTime dateTime = TypeConverter.StrToDateTime(time, DateTime.Parse("1900-01-01"));
                if (dateTime.ToString("yyyy-MM-dd") != "1900-01-01")
                {
                    TimeSpan now = DateTime.Now - dateTime.AddSeconds((double)Sec);
                    if (now.TotalSeconds <= 2147483647)
                    {
                        num = (now.TotalSeconds >= -2147483648 ? (int)now.TotalSeconds : -2147483648);
                    }
                    else
                    {
                        num = 2147483647;
                    }
                }
                else
                {
                    num = 1;
                }
            }
            else
            {
                num = 1;
            }
            return num;
        }

        public static string StrFilter(string string_2, string bantext)
        {
            string str = "";
            string str1 = "";
            string[] strArrays = Utils.SplitString(bantext, "\r\n");
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                str = strArrays[i].Substring(0, strArrays[i].IndexOf("="));
                str1 = strArrays[i].Substring(strArrays[i].IndexOf("=") + 1);
                string_2 = string_2.Replace(str, str1);
            }
            return string_2;
        }

        public static string StrFormat(string string_2)
        {
            string string2;
            if (string_2 != null)
            {
                string_2 = string_2.Replace("\r\n", "<br />");
                string_2 = string_2.Replace("\n", "<br />");
                string2 = string_2;
            }
            else
            {
                string2 = "";
            }
            return string2;
        }

        public static bool StrIsNullOrEmpty(string string_2)
        {
            return ((string_2 == null ? false : !(string_2.Trim() == string.Empty)) ? false : true);
        }

        public static bool StrToBool(object expression, bool defValue)
        {
            return TypeConverter.StrToBool(expression, defValue);
        }

        public static bool StrToBool(string expression, bool defValue)
        {
            return TypeConverter.StrToBool(expression, defValue);
        }

        public static float StrToFloat(object strValue, float defValue)
        {
            return TypeConverter.StrToFloat(strValue, defValue);
        }

        public static float StrToFloat(string strValue, float defValue)
        {
            return TypeConverter.StrToFloat(strValue, defValue);
        }

        public static int StrToInt(object expression, int defValue)
        {
            return TypeConverter.ObjectToInt(expression, defValue);
        }

        public static int StrToInt(string expression, int defValue)
        {
            return TypeConverter.StrToInt(expression, defValue);
        }

        public static Color ToColor(string color)
        {
            char[] charArray;
            int num;
            int num1;
            Color color1;
            int num2 = 0;
            color = color.TrimStart(new char[] { '#' });
            color = Regex.Replace(color.ToLower(), "[g-zG-Z]", "");
            int length = color.Length;
            if (length == 3)
            {
                charArray = color.ToCharArray();
                num = Convert.ToInt32(string.Concat(charArray[0].ToString(), charArray[0].ToString()), 16);
                num1 = Convert.ToInt32(string.Concat(charArray[1].ToString(), charArray[1].ToString()), 16);
                num2 = Convert.ToInt32(string.Concat(charArray[2].ToString(), charArray[2].ToString()), 16);
                color1 = Color.FromArgb(num, num1, num2);
            }
            else if (length == 6)
            {
                charArray = color.ToCharArray();
                num = Convert.ToInt32(string.Concat(charArray[0].ToString(), charArray[1].ToString()), 16);
                num1 = Convert.ToInt32(string.Concat(charArray[2].ToString(), charArray[3].ToString()), 16);
                num2 = Convert.ToInt32(string.Concat(charArray[4].ToString(), charArray[5].ToString()), 16);
                color1 = Color.FromArgb(num, num1, num2);
            }
            else
            {
                color1 = Color.FromName(color);
            }
            return color1;
        }

        public static string ToSChinese(string string_2)
        {
            return Strings.StrConv(string_2, VbStrConv.SimplifiedChinese, 0);
        }

        public static string ToTChinese(string string_2)
        {
            return Strings.StrConv(string_2, VbStrConv.TraditionalChinese, 0);
        }

        public void transHtml(string path, string outpath)
        {
            FileStream fileStream;
            Page page = new Page();
            StringWriter stringWriter = new StringWriter();
            page.Server.Execute(path, stringWriter);
            if (!File.Exists(string.Concat(page.Server.MapPath(""), "\\", outpath)))
            {
                fileStream = File.Create(string.Concat(page.Server.MapPath(""), "\\", outpath));
            }
            else
            {
                File.Delete(string.Concat(page.Server.MapPath(""), "\\", outpath));
                fileStream = File.Create(string.Concat(page.Server.MapPath(""), "\\", outpath));
            }
            byte[] bytes = Encoding.Default.GetBytes(stringWriter.ToString());
            fileStream.Write(bytes, 0, (int)bytes.Length);
            fileStream.Close();
        }

        public static string UrlDecode(string string_2)
        {
            return HttpUtility.UrlDecode(string_2);
        }

        public static string UrlEncode(string string_2)
        {
            return HttpUtility.UrlEncode(string_2);
        }

        public static void WriteCookie(string strName, string strValue)
        {
            HttpCookie item = HttpContext.Current.Request.Cookies[strName];
            if (item == null)
            {
                item = new HttpCookie(strName);
            }
            item.Value = strValue;
            HttpContext.Current.Response.AppendCookie(item);
        }

        public static void WriteCookie(string strName, string string_2, string strValue)
        {
            HttpCookie item = HttpContext.Current.Request.Cookies[strName];
            if (item == null)
            {
                item = new HttpCookie(strName);
            }
            item[string_2] = strValue;
            HttpContext.Current.Response.AppendCookie(item);
        }

        public static void WriteCookie(string strName, string strValue, int expires)
        {
            HttpCookie item = HttpContext.Current.Request.Cookies[strName];
            if (item == null)
            {
                item = new HttpCookie(strName);
            }
            item.Value = strValue;
            item.Expires = DateTime.Now.AddMinutes((double)expires);
            HttpContext.Current.Response.AppendCookie(item);
        }

        public class VersionInfo
        {
            public int FileBuildPart
            {
                get
                {
                    return 601;
                }
            }

            public int FileMajorPart
            {
                get
                {
                    return 3;
                }
            }

            public int FileMinorPart
            {
                get
                {
                    return 6;
                }
            }

            public string LegalCopyright
            {
                get
                {
                    return "2011, ShopNum1 Inc.";
                }
            }

            public string ProductName
            {
                get
                {
                    return "ShopNum1";
                }
            }

            public VersionInfo()
            {
            }
        }
    }
}