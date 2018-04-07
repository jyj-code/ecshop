using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
namespace ShopNum1.WeiXinCommon
{
	public class StringHelper
	{
		public static List<T> ReturnListFromJson<T>(string strJson) where T : class
		{
			JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
			return javaScriptSerializer.Deserialize<List<T>>(strJson);
		}
		public static T ReturnModelFromJson<T>(string strJson) where T : class
		{
			JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
			return javaScriptSerializer.Deserialize<T>(strJson);
		}
		public static string ReturnJson(object object_0)
		{
			JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
			return javaScriptSerializer.Serialize(object_0);
		}
		public static string RemoveLast(string string_0)
		{
			return string_0 = ((!string.IsNullOrEmpty(string_0)) ? string_0.Remove(string_0.Length - 1, 1) : string_0);
		}
	}
}
