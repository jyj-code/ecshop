using System;
using System.Web.Script.Serialization;
public class JsonHelper
{
	public static string ObjToJson(object data)
	{
		JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
		return javaScriptSerializer.Serialize(data);
	}
}
