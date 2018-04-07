using QQWry.NET;
using ShopNum1.BusinessLogic;
using ShopNum1.CityFactory;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Factory;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
public class ShopNum1MultiHttpModule : IHttpModule
{
	private QQWryLocator qqwryLocator_0 = new QQWryLocator(HttpContext.Current.Server.MapPath("~/App_Data/QQWry.Dat"));
	public void Dispose()
	{
	}
	public void Init(HttpApplication context)
	{
		//context.BeginRequest += new EventHandler(this.method_6);
		//context.PreSendRequestHeaders += new EventHandler(this.method_1);
		//context.EndRequest += new EventHandler(this.method_0);
	}
	private void method_0(object sender, EventArgs e)
	{
	}
	private void method_1(object sender, EventArgs e)
	{
		try
		{
			HttpApplication httpApplication = sender as HttpApplication;
			if (httpApplication != null && httpApplication.Request != null && httpApplication.Context != null && null != httpApplication.Context.Response)
			{
				NameValueCollection headers = httpApplication.Context.Response.Headers;
				if (null != headers)
				{
					headers.Remove("Server");
				}
			}
		}
		catch (Exception)
		{
		}
	}
	private void method_2(object sender, EventArgs e)
	{
		HttpContext context = ((HttpApplication)sender).Context;
		string url = "~/404.aspx";
		if (context.Request.QueryString != null)
		{
			for (int i = 0; i < context.Request.QueryString.Count; i++)
			{
				string text = context.Request.QueryString.Keys[i];
				string text2 = context.Request.QueryString[text];
				if (!this.method_3(text2) && text2.Length < 150)
				{
					context.Response.Redirect(url);
					context.Response.End();
					break;
				}
			}
		}
		if (context.Request.Form != null)
		{
			for (int i = 0; i < context.Request.Form.Count; i++)
			{
				string text = context.Request.Form.Keys[i];
				string text2 = context.Request.Form[i];
				if (!(text == "__VIEWSTATE") && (!this.method_3(text2) && text2.Length < 300))
				{
					context.Response.Redirect(url);
					context.Response.End();
					break;
				}
			}
		}
	}
	private bool method_3(string string_0)
	{
		bool result = true;
		if (string_0.Trim() != "")
		{
			string text = ConfigurationSettings.AppSettings["SQLChar"].ToString();
			string[] array = text.Split(new char[]
			{
				'|'
			});
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string value = array2[i];
				if (string_0.ToLower().IndexOf(value) >= 0)
				{
					result = false;
					break;
				}
			}
		}
		return result;
	}
	private void method_4()
	{
		string iPAddress = Globals.IPAddress;
		string text = this.method_5("http://ip.taobao.com/service/getIpInfo.php?ip=" + iPAddress);
		string pattern = ":\\d{1,100000000}";
		Regex regex = new Regex(pattern);
		text = regex.Replace(text, "");
		text = text.Replace("{\"code\",\"data\":", "").Replace("}}", "}");
		string valueFromJson = ShopNum1MultiHttpModule.GetValueFromJson(text, "region");
		string valueFromJson2 = ShopNum1MultiHttpModule.GetValueFromJson(text, "city");
		if (valueFromJson2 != "")
		{
			string text2 = DatabaseExcetue.ReturnString(string.Concat(new string[]
			{
				"SELECT top 1 name from(select A.Domainname from ShopNum1_SubstationManage A inner join shopnum1_region b on b.code=A.citycode where b.name like '%",
				valueFromJson,
				"%'union all select A.Domainname from ShopNum1_SubstationManage A inner join shopnum1_region b on b.code=A.citycode where b.name like '%",
				valueFromJson2,
				"%') as tab"
			}));
			if (text2 != "")
			{
				HttpContext.Current.Response.Redirect("http://" + text2 + ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf(".")));
			}
			else
			{
				string text3 = DatabaseExcetue.ReturnString("select A.Domainname from ShopNum1_SubstationManage A \r\ninner join shopnum1_region b on b.code=A.citycode and b.fatherid in(select id from shopnum1_region \r\nwhere name like '%" + valueFromJson2 + "%')");
				if (text3 != "")
				{
					HttpContext.Current.Response.Redirect("http://" + text3 + ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf(".")));
				}
				else
				{
					HttpContext.Current.Response.Redirect(ShopSettings.GetValue("DefaultMainCityUrl"));
				}
			}
		}
		else
		{
			HttpContext.Current.Response.Redirect(ShopSettings.GetValue("DefaultMainCityUrl"));
		}
	}
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
	private string method_5(string string_0)
	{
		WebClient webClient = new WebClient();
		Stream stream = webClient.OpenRead(string_0);
		StreamReader streamReader = new StreamReader(stream, Encoding.GetEncoding("utf-8"));
		string result = streamReader.ReadToEnd();
		stream.Close();
		return result;
	}
	private void method_6(object sender, EventArgs e)
	{
		HttpContext context = ((HttpApplication)sender).Context;
		string text = context.Request.Url.AbsoluteUri.ToLower();
		Regex regex = new Regex("^http://([a-z0-9-]{2,20}\\.)?([a-z0-9-]{1,40}\\.)?[a-z0-9-]{1,40}\\.[a-z]{2,3}(\\.[a-z]{2,3})?/(\\w{1,40}/)*(.{1,100}\\.(html|shtml|htm|aspx)(\\?.+)?)?$");
		context.Request.RawUrl.ToLower();
		string arg_4E_0 = context.Request.Url.Host;
		string arg_5A_0 = context.Request.Path;
		if (string.IsNullOrEmpty(ShopSettings.siteDomain))
		{
			context.RewritePath("~/Main/404.aspx");
		}
		else
		{
			string text2 = HttpContext.Current.Request.RawUrl.ToLower();
			if (text2.EndsWith(".xml"))
			{
				if (!text2.Contains("/fckeditor"))
				{
					context.RewritePath("~/Main/404.aspx");
				}
			}
			else
			{
				if ("www." + HttpContext.Current.Request.Url.Host.ToLower() == ShopSettings.siteDomain.ToLower())
				{
					context.Response.Status = "301 Moved Permanently";
					context.Response.AddHeader("Location", "http://" + ShopSettings.siteDomain);
				}
				string text3 = ShopSettings.siteDomain.Contains("http://") ? ShopSettings.siteDomain : ("http://" + ShopSettings.siteDomain);
				string iPAddress = Globals.IPAddress;
				if (ShopSettings.GetValue("SubstationCityMode") == "1" && HttpContext.Current.Request.Url.Host.ToLower() == ShopSettings.siteDomain.ToLower() && !HttpContext.Current.Request.Url.ToString().ToLower().Contains(ShopSettings.siteDomain.ToLower() + "/main/threelogin") && !HttpContext.Current.Request.Url.ToString().ToLower().Contains(ShopSettings.siteDomain.ToLower() + "/threelogin") && !HttpContext.Current.Request.Url.ToString().ToLower().Contains(ShopSettings.siteDomain.ToLower() + "/main/findpasswordsuccess") && !HttpContext.Current.Request.Url.ToString().ToLower().Contains(ShopSettings.siteDomain.ToLower() + "/findpasswordsuccess") && !HttpContext.Current.Request.Url.ToString().ToLower().Contains(ShopSettings.siteDomain.ToLower() + "/main/findbackpassword") && !HttpContext.Current.Request.Url.ToString().ToLower().Contains(ShopSettings.siteDomain.ToLower() + "/findbackpassword") && !HttpContext.Current.Request.Url.ToString().ToLower().Contains(ShopSettings.siteDomain.ToLower() + "/main/findpasswordfinal") && !HttpContext.Current.Request.Url.ToString().ToLower().Contains(ShopSettings.siteDomain.ToLower() + "/findpasswordfinal") && !HttpContext.Current.Request.Url.ToString().ToLower().Contains(ShopSettings.siteDomain.ToLower() + "/main/findpasswordfinaltel") && !HttpContext.Current.Request.Url.ToString().ToLower().Contains(ShopSettings.siteDomain.ToLower() + "/findpasswordfinaltel") && !HttpContext.Current.Request.Url.ToString().ToLower().Contains(ShopSettings.siteDomain.ToLower() + "/imagecode") && !HttpContext.Current.Request.Url.ToString().ToLower().Contains(ShopSettings.siteDomain.ToLower() + "/main/admin/") && !HttpContext.Current.Request.Url.ToString().ToLower().Contains(ShopSettings.siteDomain.ToLower() + "/main/agentadmin/") && !HttpContext.Current.Request.Url.ToString().ToLower().Contains(ShopSettings.siteDomain.ToLower() + "/login") && !HttpContext.Current.Request.Url.ToString().ToLower().Contains(ShopSettings.siteDomain.ToLower() + "/main/login") && !HttpContext.Current.Request.Url.ToString().ToLower().Contains(ShopSettings.siteDomain.ToLower() + "/main/memberregister") && !HttpContext.Current.Request.Url.ToString().ToLower().Contains(ShopSettings.siteDomain.ToLower() + "/memberregister") && !HttpContext.Current.Request.Url.ToString().ToLower().Contains(ShopSettings.siteDomain.ToLower() + "/main/member/") && !HttpContext.Current.Request.Url.ToString().ToLower().Contains(ShopSettings.siteDomain.ToLower() + "/shop/") && !HttpContext.Current.Request.Url.ToString().ToLower().Contains(ShopSettings.siteDomain.ToLower() + "/main/account/") && !HttpContext.Current.Request.Url.ToString().ToLower().Contains(ShopSettings.siteDomain.ToLower() + "/pagehander/") && !HttpContext.Current.Request.Url.ToString().ToLower().Contains(ShopSettings.siteDomain.ToLower() + "/api/") && !HttpContext.Current.Request.Url.ToString().ToLower().Contains(ShopSettings.siteDomain.ToLower() + "/city/") && !HttpContext.Current.Request.Url.ToString().ToLower().Contains(ShopSettings.siteDomain.ToLower() + "/imgupload/") && !HttpContext.Current.Request.Url.ToString().ToLower().Contains(ShopSettings.siteDomain.ToLower() + "/fileupload/") && !HttpContext.Current.Request.Url.ToString().ToLower().Contains(ShopSettings.siteDomain.ToLower() + "/settings/") && !HttpContext.Current.Request.Url.ToString().ToLower().Contains(ShopSettings.siteDomain.ToLower() + "/payreturn/") && !HttpContext.Current.Request.Url.ToString().ToLower().Contains(ShopSettings.siteDomain.ToLower() + "/settings/") && !HttpContext.Current.Request.Url.ToString().ToLower().Contains(ShopSettings.siteDomain.ToLower() + "/template/") && !HttpContext.Current.Request.Url.ToString().ToLower().Contains(ShopSettings.siteDomain.ToLower() + "/webConfig/") && !HttpContext.Current.Request.Url.ToString().ToLower().Contains(ShopSettings.siteDomain.ToLower() + "/main/api/") && !HttpContext.Current.Request.Url.ToString().ToLower().Contains(ShopSettings.siteDomain.ToLower() + "/main/js/") && !HttpContext.Current.Request.Url.ToString().ToLower().Contains(ShopSettings.siteDomain.ToLower() + "/main/second/") && !HttpContext.Current.Request.Url.ToString().ToLower().Contains(ShopSettings.siteDomain.ToLower() + "/log/") && !HttpContext.Current.Request.Url.ToString().ToLower().Contains(ShopSettings.siteDomain.ToLower() + "/js/") && !HttpContext.Current.Request.Url.ToString().ToLower().Contains(ShopSettings.siteDomain.ToLower() + "/app_code/") && !HttpContext.Current.Request.Url.ToString().ToLower().Contains(ShopSettings.siteDomain.ToLower() + "/kindeditor/") && !HttpContext.Current.Request.Url.ToString().ToLower().Contains(ShopSettings.siteDomain.ToLower() + "/substationerror"))
				{
					this.method_4();
				}
				if (text == text3 + "/default.aspx")
				{
					IPLocation iPLocation = this.qqwryLocator_0.Query(iPAddress);
					object agentDomainByAddressName = this.GetAgentDomainByAddressName(iPLocation.Country);
					if (agentDomainByAddressName == null)
					{
						context.RewritePath("~/Main/default.aspx");
						return;
					}
					context.Response.Status = "301 Moved Permanently";
					context.Response.AddHeader("Location", agentDomainByAddressName.ToString());
				}
				if (text.IndexOf("/install/install.aspx") == -1)
				{
					if (text.IndexOf("/404.aspx") != -1)
					{
						context.RewritePath("~/Main/404.aspx");
					}
					else if (text.IndexOf("/imgupload/") != -1 || text.IndexOf("/upload/") != -1)
					{
						context.Response.Write("<script> window.alert(\"执行操作非法！\");  window.location.href='" + GetPageName.RetUrl("default") + "'</script>");
						context.Response.End();
					}
					else
					{
						string path = "~/Main/404.aspx";
						if (text3.IndexOf("http://localhost") == -1 && regex.IsMatch(text) && text.Split(new char[]
						{
							'/'
						}).Length < 6 && text.IndexOf("/main/") == -1 && text.IndexOf("/admin/") == -1 && text.IndexOf("/fckeditor/") == -1 && text.IndexOf("/api/") == -1 && text.IndexOf("/payreturn/") == -1)
						{
							ShopNum1_PreventIp_Action shopNum1_PreventIp_Action = (ShopNum1_PreventIp_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_PreventIp_Action();
							if (!shopNum1_PreventIp_Action.CheckedUser(iPAddress, "0"))
							{
								context.RewritePath("~/Main/404.aspx");
							}
							else
							{
								if (HttpContext.Current.Request.Url.Host == ShopSettings.siteDomain.Replace("/", ""))
								{
									path = "~/Default.aspx";
								}
								if (text.IndexOf(ShopSettings.siteDomain) == -1 && HttpContext.Current.Request.Url.Host.Split(new char[]
								{
									'.'
								}).Length == 3 && text.IndexOf("http://www.") == -1)
								{
									path = this.method_8(text);
								}
								else if (HttpContext.Current.Request.Url.Host.Split(new char[]
								{
									'.'
								}).Length == 4 && text.IndexOf("http://www.") == -1)
								{
									path = this.method_9(text);
								}
								else if (text.IndexOf("http://www") != -1 || text.IndexOf(ShopSettings.siteDomain) != -1)
								{
									path = this.method_7(text);
								}
								context.RewritePath(path);
							}
						}
					}
				}
			}
		}
	}
	private string method_7(string string_0)
	{
		string_0 = string_0.Replace("http://", "");
		string host = HttpContext.Current.Request.Url.Host;
		string_0 = string_0.Substring(string_0.IndexOf('/') + 1);
		if (string_0 == "")
		{
			string_0 = "default.html";
		}
		string result;
		if (host == ShopSettings.siteDomain)
		{
			string text2;
			if (string_0.IndexOf('/') != -1)
			{
				string[] array = string_0.Split(new char[]
				{
					'/'
				});
				string text = array[0];
				switch (text)
				{
				case "categorylist":
					text2 = "~/Main/CategoryListSearch.aspx?code=" + array[1].Substring(0, array[1].IndexOf('.'));
					goto IL_2DC;
				case "supplylist":
					text2 = "~/Main/SupplyDemandListSearch.aspx?code=" + array[1].Substring(0, array[1].IndexOf('.'));
					goto IL_2DC;
				case "productlist":
					text2 = "~/Main/ProductListSearch.aspx?code=" + array[1].Substring(0, array[1].IndexOf('.'));
					goto IL_2DC;
				case "shoplist":
					text2 = "~/Main/ShopListSearch.aspx?code=" + array[1].Substring(0, array[1].IndexOf('.'));
					goto IL_2DC;
				case "allarticle":
					text2 = "~/Main/ArticleListSearch.aspx?code=" + array[1].Substring(0, array[1].IndexOf('.'));
					goto IL_2DC;
				case "articlelist":
					text2 = "~/Main/ArticleListSearch.aspx?ID=" + array[1].Substring(0, array[1].IndexOf('.'));
					goto IL_2DC;
				case "allbrandlist":
					text2 = "~/Main/AllBrandList.aspx?code=" + array[1].Substring(0, array[1].IndexOf('.'));
					goto IL_2DC;
				case "search_product":
					text2 = "~/Main/search_product.aspx?code=" + array[1].Substring(0, array[1].IndexOf('.'));
					goto IL_2DC;
				}
				text2 = "~/Main/" + array[0] + ".aspx?guid=" + array[1].Substring(0, array[1].IndexOf('.'));
			}
			else
			{
				string str = string_0.Substring(0, string_0.IndexOf('.'));
				text2 = "~/Main/" + str + ".aspx";
				if (string_0.IndexOf('?') != -1)
				{
					text2 = text2 + "?" + string_0.Substring(string_0.IndexOf('?') + 1);
				}
			}
			IL_2DC:
			result = text2;
		}
		else
		{
			DataTable dataTable = this.UrlWriteDoMain(host);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				string text3 = dataTable.Rows[0]["ShopID"].ToString();
				string text4 = dataTable.Rows[0]["MemberType"].ToString();
				string s = dataTable.Rows[0]["OpenTime"].ToString();
				string text = text4;
				if (text != null && text == "1")
				{
					result = "~/Main/404.aspx";
				}
				else
				{
					string text2 = "~/Shop/Shop/";
					string text5 = text2;
					text2 = string.Concat(new string[]
					{
						text5,
						DateTime.Parse(s).ToString("yyyy-MM-dd").Replace('-', '/'),
						"/",
						ShopSettings.GetValue("PersonShopUrl"),
						text3,
						"/"
					});
					if (string_0.IndexOf('/') != -1)
					{
						string[] array = string_0.Split(new char[]
						{
							'/'
						});
						text = array[0];
						if (text != null && text == "")
						{
							text2 = "";
						}
						else
						{
							text5 = text2;
							text2 = string.Concat(new string[]
							{
								text5,
								array[0],
								".aspx?guid=",
								array[1].Substring(0, array[1].IndexOf('.')),
								"&ShopID=",
								text3
							});
						}
					}
					else
					{
						string str = string_0.Substring(0, string_0.IndexOf('.'));
						text2 = text2 + str + ".aspx?ShopID=" + text3;
						if (string_0.IndexOf('?') != -1)
						{
							text2 = text2 + "&" + string_0.Substring(string_0.IndexOf('?') + 1);
						}
					}
					result = text2;
				}
			}
			else
			{
				result = "~/Main/NoPowerDomain.aspx";
			}
		}
		return result;
	}
	private string method_8(string string_0)
	{
		string_0 = string_0.Replace("http://", "");
		string_0 = string_0.Substring(string_0.IndexOf('/') + 1);
		if (string_0 == "")
		{
			string_0 = "default.html";
		}
		string text = string.Empty;
		if (string_0.StartsWith("articledetail/") || string_0.StartsWith("announcementdetail/") || string_0.StartsWith("helplist/") || string_0.StartsWith("videodetail/"))
		{
			string text2 = string_0.Substring(string_0.IndexOf('/') + 1);
			text = "&guid=" + text2.Substring(0, text2.IndexOf('.'));
		}
		else if (string_0.StartsWith("branddetail/"))
		{
			string text2 = string_0.Substring(string_0.IndexOf('/') + 1);
			text = "&brandguid=" + text2.Substring(0, text2.IndexOf('.'));
		}
		else if (string_0.StartsWith("articlelistsearch/"))
		{
			string text2 = string_0.Substring(string_0.IndexOf('/') + 1);
			text = "&ID=" + text2.Substring(0, text2.IndexOf('.'));
		}
		else if (string_0.StartsWith("spellbuylist/"))
		{
			string text2 = string_0.Substring(string_0.IndexOf('/') + 1);
			text = "&guid=" + text2.Substring(0, text2.IndexOf('.'));
		}
		string domainName = HttpContext.Current.Request.Url.Host.Split(new char[]
		{
			'.'
		})[0];
		ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
		string text3 = string.Empty;
		try
		{
			string substationIDByDomainName = shopNum1_SubstationManage_Action.GetSubstationIDByDomainName(domainName, 0);
			if (!string.IsNullOrEmpty(substationIDByDomainName))
			{
				text3 = substationIDByDomainName;
			}
			else
			{
				HttpContext.Current.Response.Redirect("http://" + ShopSettings.siteDomain + "/SubstationError.aspx");
			}
		}
		catch (Exception)
		{
			HttpContext.Current.Response.Redirect("http://" + ShopSettings.siteDomain + "/SubstationError.aspx");
		}
		string text4 = "~/City/" + text3 + "/";
		string text5 = string_0.Substring(0, string_0.IndexOf('.'));
		if (text5.StartsWith("articledetail/"))
		{
			text5 = "articledetail";
		}
		else if (text5.StartsWith("announcementdetail/"))
		{
			text5 = "announcementdetail";
		}
		else if (string_0.StartsWith("branddetail/"))
		{
			text5 = "branddetail";
		}
		else if (text5.StartsWith("articlelistsearch/"))
		{
			text5 = "articlelistsearch";
		}
		else if (text5.StartsWith("helplist/"))
		{
			text5 = "helplist";
		}
		else if (text5.StartsWith("videodetail/"))
		{
			text5 = "videodetail";
		}
		else if (text5.StartsWith("spellbuylist/"))
		{
			text5 = "spellbuylist";
		}
		string text6 = text4;
		text4 = string.Concat(new string[]
		{
			text6,
			text5,
			".aspx?SubstationID=",
			text3,
			text
		});
		if (string_0.IndexOf('?') != -1)
		{
			NameValueCollection queryString = HttpContext.Current.Request.QueryString;
			StringBuilder stringBuilder = new StringBuilder();
			string[] allKeys = queryString.AllKeys;
			for (int i = 0; i < allKeys.Length; i++)
			{
				if (allKeys[i] != "SubstationID")
				{
					stringBuilder.Append(allKeys[i] + "=" + HttpUtility.UrlEncode(Common.ReqStr(allKeys[i]), Encoding.GetEncoding("utf-8")) + "&");
				}
			}
			if (stringBuilder.ToString() != "")
			{
				stringBuilder.Remove(stringBuilder.Length - 1, 1);
				string_0 = stringBuilder.ToString();
			}
			text4 = text4 + "&" + string_0;
		}
		return text4;
	}
	private string method_9(string string_0)
	{
		string_0 = string_0.Replace("http://", "");
		string_0 = string_0.Substring(string_0.IndexOf('/') + 1);
		if (string_0 == "")
		{
			string_0 = "default.html";
		}
		ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = new ShopNum1_ShopInfoList_Action();
		string shopUrl = HttpContext.Current.Request.Url.Host.Split(new char[]
		{
			'.'
		})[0];
		DataTable shopOpenShow = shopNum1_ShopInfoList_Action.GetShopOpenShow(shopUrl);
		string result;
		string text2;
		if (shopOpenShow != null && shopOpenShow.Rows.Count > 0)
		{
			int num = Convert.ToInt32(shopOpenShow.Rows[0]["IsExpires"]);
			int num2 = Convert.ToInt32(shopOpenShow.Rows[0]["IsClose"]);
			string s = shopOpenShow.Rows[0]["OpenTime"].ToString();
			string text = shopOpenShow.Rows[0]["ShopID"].ToString();
			if (num2 == 1 || num == 1)
			{
				result = "~/main/ShopError.aspx";
				return result;
			}
			text2 = "~/Shop/Shop/";
			string text3 = text2;
			text2 = string.Concat(new string[]
			{
				text3,
				DateTime.Parse(s).ToString("yyyy-MM-dd").Replace('-', '/'),
				"/",
				ShopSettings.GetValue("PersonShopUrl"),
				text,
				"/"
			});
			string text4 = string.Concat(new string[]
			{
				"~/Shop/Shop/",
				DateTime.Parse(s).ToString("yyyy-MM-dd").Replace('-', '/'),
				"/",
				ShopSettings.GetValue("PersonShopUrl"),
				text
			});
			string path = HttpContext.Current.Server.MapPath(text4);
			if (!Directory.Exists(path))
			{
				result = "~/main/ShopNegation.aspx";
				return result;
			}
			string path2 = text4 + "/Themes/Skin_Default/Style";
			if (!Directory.Exists(HttpContext.Current.Server.MapPath(path2)))
			{
				result = "~/main/ShopNegation.aspx";
				return result;
			}
			if (string_0.IndexOf('/') != -1)
			{
				string[] array = string_0.Split(new char[]
				{
					'/'
				});
				string text5 = array[0];
				if (text5 != null && text5 == "")
				{
					text2 = "";
				}
				else
				{
					text3 = text2;
					text2 = string.Concat(new string[]
					{
						text3,
						array[0],
						".aspx?guid=",
						array[1].Substring(0, array[1].IndexOf('.')),
						"&ShopID=",
						text
					});
					if (string_0.IndexOf('?') != -1)
					{
						text2 = text2 + "&" + string_0.Substring(string_0.IndexOf('?') + 1);
					}
				}
			}
			else
			{
				string str = string_0.Substring(0, string_0.IndexOf('.'));
				text2 = text2 + str + ".aspx?ShopID=" + text;
				if (string_0.IndexOf('?') != -1)
				{
					text2 = text2 + "&" + string_0.Substring(string_0.IndexOf('?') + 1);
				}
			}
		}
		else
		{
			text2 = "~/Main/ShopNegation.aspx";
		}
		result = text2;
		return result;
	}
	private DataTable method_10(string string_0)
	{
		string[] array = new string[1];
		string[] array2 = new string[1];
		array[0] = "@ShopUrl";
		array2[0] = string_0;
		return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_UrlWriteShop", array, array2);
	}
	public DataTable UrlWriteDoMain(string domain)
	{
		string[] array = new string[1];
		string[] array2 = new string[1];
		array[0] = "@domain";
		array2[0] = domain;
		return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_UrlWriteShopDoMain", array, array2);
	}
	public object GetAgentDomainByAddressName(string address)
	{
		string[] array = new string[1];
		string[] array2 = new string[1];
		array[0] = "@addressname";
		array2[0] = address;
		return DatabaseExcetue.ReturnProcedureString("Pro_ShopNum1_WebSiteGetDomainByAddress", array, array2);
	}
}
