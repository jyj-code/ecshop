using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
namespace ShopNum1.Second
{
	public class JsonOperate
	{
		public static string GetValueFromJson(string strjson, string name)
		{
			JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
			Dictionary<string, object> dictionary = (Dictionary<string, object>)javaScriptSerializer.DeserializeObject(strjson);
			string result;
			try
			{
				object obj;
				dictionary.TryGetValue(name, out obj);
				result = obj.ToString();
			}
			catch
			{
				result = "";
			}
			return result;
		}
	}
}
