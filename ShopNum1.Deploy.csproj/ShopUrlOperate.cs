using QQWry.NET;
using ShopNum1.BusinessLogic;
using ShopNum1.CityFactory;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Factory;
using ShopNum1.Interface;
using System;
using System.Data;
using System.Web;
public static class ShopUrlOperate
{
	private static readonly IShopNum1_ShopInfoList_Action ishopNum1_ShopInfoList_Action_0 = ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
	public static string GetShopURLByShopID(string shopID)
	{
		shopID = shopID.Replace(ShopSettings.GetValue("PersonShopUrl"), "");
		return ShopUrlOperate.ishopNum1_ShopInfoList_Action_0.GetShopURLByShopID(shopID);
	}
	public static string shopDetailHrefNew(string Guid, string MemLoginID, string string_0)
	{
		DataTable shopIDByMemLoginID = ShopUrlOperate.ishopNum1_ShopInfoList_Action_0.GetShopIDByMemLoginID(MemLoginID);
		string result;
		if (shopIDByMemLoginID == null || shopIDByMemLoginID.Rows.Count == 0)
		{
			result = "";
		}
		else
		{
			ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
			string text = "public";
			try
			{
				text = shopNum1_SubstationManage_Action.GetDomainNameByShopMemLoginID(MemLoginID).Rows[0][0].ToString();
			}
			catch (Exception)
			{
				text = "public";
			}
			string text2 = shopIDByMemLoginID.Rows[0]["ShopUrl"].ToString();
			string text3 = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
			if (ShopSettings.IsOverrideUrl)
			{
				result = string.Concat(new string[]
				{
					"http://",
					text2,
					".",
					text,
					text3,
					"/",
					string_0,
					"/",
					Guid,
					ShopSettings.overrideUrlName
				});
			}
			else
			{
				result = string.Concat(new string[]
				{
					"http://",
					text2,
					".",
					text,
					text3,
					"/",
					string_0,
					"/",
					Guid,
					".aspx"
				});
			}
		}
		return result;
	}
	public static string GetFenUrlByDomainName(string DomainName)
	{
		string str = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
		return "http://" + DomainName + str;
	}
	public static string shopDetailHrefByShopIDNew(string Guid, string ShopID, string string_0)
	{
		string shopURLByShopID = ShopUrlOperate.GetShopURLByShopID(ShopID);
		ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
		DataTable domainNameByShopID = shopNum1_SubstationManage_Action.GetDomainNameByShopID(ShopID);
		string text = "public";
		if (domainNameByShopID != null && domainNameByShopID.Rows.Count > 0)
		{
			text = domainNameByShopID.Rows[0][0].ToString();
		}
		string text2 = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
		string result;
		if (ShopSettings.IsOverrideUrl)
		{
			result = string.Concat(new string[]
			{
				"http://",
				shopURLByShopID,
				".",
				text,
				text2,
				"/",
				string_0,
				"/",
				Guid,
				ShopSettings.overrideUrlName
			});
		}
		else
		{
			result = string.Concat(new string[]
			{
				"http://",
				shopURLByShopID,
				".",
				text,
				text2,
				"/",
				string_0,
				"/",
				Guid,
				".aspx"
			});
		}
		return result;
	}
	public static string GetShopUrl(string ShopID)
	{
		string shopURLByShopID = ShopUrlOperate.GetShopURLByShopID(ShopID);
		ShopID = ShopID.Replace(ShopSettings.GetValue("PersonShopUrl"), "");
		string str = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
		return "http://" + shopURLByShopID + str;
	}
	public static string GetShopUrlNew(string ShopID)
	{
		string shopURLByShopID = ShopUrlOperate.GetShopURLByShopID(ShopID);
		ShopID = ShopID.Replace("shop", "");
		string text = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
		ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
		string text2 = string.Empty;
		try
		{
			text2 = shopNum1_ShopInfoList_Action.GetShopYuMingByShopID(ShopID);
		}
		catch (Exception)
		{
			text2 = "public";
		}
		return string.Concat(new string[]
		{
			"http://",
			shopURLByShopID,
			".",
			text2,
			text
		});
	}
	public static string GetShopLoginGoBack()
	{
		string text = ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx";
		string s = "http://" + HttpContext.Current.Request.Url.Host + HttpContext.Current.Request.RawUrl;
		return string.Concat(new string[]
		{
			"http://",
			ShopSettings.siteDomain,
			"/Login",
			text,
			"?goback=",
			HttpContext.Current.Server.UrlEncode(s)
		});
	}
	public static string GetShopUrl(string ShopID, string string_0)
	{
		string shopURLByShopID = ShopUrlOperate.GetShopURLByShopID(ShopID);
		string text = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
		string result;
		if (ShopSettings.IsOverrideUrl)
		{
			result = string.Concat(new string[]
			{
				"http://",
				shopURLByShopID,
				text,
				"/",
				string_0,
				ShopSettings.overrideUrlName
			});
		}
		else
		{
			result = string.Concat(new string[]
			{
				"http://",
				shopURLByShopID,
				text,
				"/",
				string_0,
				".aspx"
			});
		}
		return result;
	}
	public static string GetShopDomainByUrl(string shopUrl)
	{
		string str = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
		string result;
		if (ShopSettings.IsOverrideUrl)
		{
			result = "http://" + shopUrl + str;
		}
		else
		{
			result = "http://" + shopUrl + str;
		}
		return result;
	}
	public static string shopHref(string Guid, string MemLoginID)
	{
		DataTable shopIDByMemLoginID = ShopUrlOperate.ishopNum1_ShopInfoList_Action_0.GetShopIDByMemLoginID(MemLoginID);
		string result;
		if (shopIDByMemLoginID == null || shopIDByMemLoginID.Rows.Count == 0)
		{
			result = "";
		}
		else
		{
			string shopID = shopIDByMemLoginID.Rows[0]["ShopID"].ToString();
			string shopURLByShopID = ShopUrlOperate.GetShopURLByShopID(shopID);
			string text = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
			string text2 = "all";
			string text3 = "public";
			ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
			DataTable substationByShopInfo = shopNum1_SubstationManage_Action.GetSubstationByShopInfo(MemLoginID);
			if (substationByShopInfo != null && substationByShopInfo.Rows.Count > 0)
			{
				text2 = substationByShopInfo.Rows[0]["SubstationID"].ToString();
			}
			if (text2 != "all")
			{
				text3 = shopNum1_SubstationManage_Action.GetDomainNameBySubstationID(text2);
			}
			if (ShopSettings.IsOverrideUrl)
			{
				result = string.Concat(new string[]
				{
					"http://",
					shopURLByShopID,
					".",
					text3,
					text,
					"/ProductDetail/",
					Guid,
					ShopSettings.overrideUrlName
				});
			}
			else
			{
				result = string.Concat(new string[]
				{
					"http://",
					shopURLByShopID,
					".",
					text3,
					text,
					"/ProductDetail/",
					Guid,
					".aspx"
				});
			}
		}
		return result;
	}
	public static string shopHrefNew(string Guid, string MemLoginID)
	{
		DataTable shopIDByMemLoginID = ShopUrlOperate.ishopNum1_ShopInfoList_Action_0.GetShopIDByMemLoginID(MemLoginID);
		string result;
		if (shopIDByMemLoginID == null || shopIDByMemLoginID.Rows.Count == 0)
		{
			result = "";
		}
		else
		{
			string shopID = shopIDByMemLoginID.Rows[0]["ShopID"].ToString();
			string shopURLByShopID = ShopUrlOperate.GetShopURLByShopID(shopID);
			string text = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
			string text2 = "all";
			string text3 = "public";
			ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
			DataTable substationByShopInfo = shopNum1_SubstationManage_Action.GetSubstationByShopInfo(MemLoginID);
			if (substationByShopInfo != null && substationByShopInfo.Rows.Count > 0)
			{
				text2 = substationByShopInfo.Rows[0]["SubstationID"].ToString();
			}
			if (text2 != "all")
			{
				text3 = shopNum1_SubstationManage_Action.GetDomainNameBySubstationID(text2);
			}
			if (ShopSettings.IsOverrideUrl)
			{
				result = string.Concat(new string[]
				{
					"http://",
					shopURLByShopID,
					".",
					text3,
					text,
					"/ProductDetail/",
					Guid,
					ShopSettings.overrideUrlName
				});
			}
			else
			{
				result = string.Concat(new string[]
				{
					"http://",
					shopURLByShopID,
					".",
					text3,
					text,
					"/ProductDetail/",
					Guid,
					".aspx"
				});
			}
		}
		return result;
	}
	public static string GetShopProductHref(string Guid, string shopurl)
	{
		string text = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
		string result;
		if (ShopSettings.IsOverrideUrl)
		{
			result = string.Concat(new string[]
			{
				"http://",
				shopurl,
				text,
				"/ProductDetail/",
				Guid,
				ShopSettings.overrideUrlName
			});
		}
		else
		{
			result = string.Concat(new string[]
			{
				"http://",
				shopurl,
				text,
				"/ProductDetail/",
				Guid,
				".aspx"
			});
		}
		return result;
	}
	public static string ShopProductImg(string imgurl, string MemLoginID)
	{
		string result;
		if (imgurl == string.Empty || imgurl == null)
		{
			result = "";
		}
		else
		{
			DataTable shopIDByMemLoginID = ShopUrlOperate.ishopNum1_ShopInfoList_Action_0.GetShopIDByMemLoginID(MemLoginID);
			if (shopIDByMemLoginID == null || shopIDByMemLoginID.Rows.Count == 0)
			{
				result = "";
			}
			else
			{
				string shopID = shopIDByMemLoginID.Rows[0]["ShopID"].ToString();
				string shopURLByShopID = ShopUrlOperate.GetShopURLByShopID(shopID);
				string text = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
				result = string.Concat(new string[]
				{
					"http://",
					shopURLByShopID,
					text,
					"/",
					imgurl.Substring(1)
				});
			}
		}
		return result;
	}
	public static string GetShopProductImgByUrl(string imgurl, string shopurl)
	{
		string result;
		if (imgurl == string.Empty || imgurl == null)
		{
			result = "";
		}
		else
		{
			string text = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
			result = string.Concat(new string[]
			{
				"http://",
				shopurl,
				text,
				"/",
				imgurl.Substring(1)
			});
		}
		return result;
	}
	public static string shopDetailHref(string Guid, string MemLoginID, string string_0)
	{
		string result;
		if (ShopSettings.GetValue("isCity") == "0")
		{
			DataTable shopIDByMemLoginID = ShopUrlOperate.ishopNum1_ShopInfoList_Action_0.GetShopIDByMemLoginID(MemLoginID);
			if (shopIDByMemLoginID == null || shopIDByMemLoginID.Rows.Count == 0)
			{
				result = "";
			}
			else
			{
				string text = shopIDByMemLoginID.Rows[0]["ShopUrl"].ToString();
				string text2 = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
				if (ShopSettings.IsOverrideUrl)
				{
					result = string.Concat(new string[]
					{
						"http://",
						text,
						text2,
						"/",
						string_0,
						"/",
						Guid,
						ShopSettings.overrideUrlName
					});
				}
				else
				{
					result = string.Concat(new string[]
					{
						"http://",
						text,
						text2,
						"/",
						string_0,
						"/",
						Guid,
						".aspx"
					});
				}
			}
		}
		else
		{
			DataTable shopIDByMemLoginID = ShopUrlOperate.ishopNum1_ShopInfoList_Action_0.GetShopIDByMemLoginID(MemLoginID);
			if (shopIDByMemLoginID == null || shopIDByMemLoginID.Rows.Count == 0)
			{
				result = "";
			}
			else
			{
				ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
				string text3 = "public";
				try
				{
					text3 = shopNum1_SubstationManage_Action.GetDomainNameByShopMemLoginID(MemLoginID).Rows[0][0].ToString();
				}
				catch (Exception)
				{
					text3 = "public";
				}
				string text = shopIDByMemLoginID.Rows[0]["ShopUrl"].ToString();
				string text2 = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
				if (ShopSettings.IsOverrideUrl)
				{
					result = string.Concat(new string[]
					{
						"http://",
						text,
						".",
						text3,
						text2,
						"/",
						string_0,
						"/",
						Guid,
						ShopSettings.overrideUrlName
					});
				}
				else
				{
					result = string.Concat(new string[]
					{
						"http://",
						text,
						".",
						text3,
						text2,
						"/",
						string_0,
						"/",
						Guid,
						".aspx"
					});
				}
			}
		}
		return result;
	}
	public static string shopDetailHrefByShopID(string Guid, string ShopID, string string_0)
	{
		string shopURLByShopID = ShopUrlOperate.GetShopURLByShopID(ShopID);
		string text = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
		string result;
		if (ShopSettings.IsOverrideUrl)
		{
			result = string.Concat(new string[]
			{
				"http://",
				shopURLByShopID,
				text,
				"/",
				string_0,
				"/",
				Guid,
				ShopSettings.overrideUrlName
			});
		}
		else
		{
			result = string.Concat(new string[]
			{
				"http://",
				shopURLByShopID,
				text,
				"/",
				string_0,
				"/",
				Guid,
				".aspx"
			});
		}
		return result;
	}
	public static string RedirectProductDetailByShopID(string Guid, string ShopID, string isSpell, string isPanic)
	{
		string shopURLByShopID = ShopUrlOperate.GetShopURLByShopID(ShopID);
		string text = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
		string result;
		if (ShopSettings.IsOverrideUrl)
		{
			if (isSpell == "1")
			{
				result = string.Concat(new string[]
				{
					"http://",
					shopURLByShopID,
					text,
					"/ProductIsSpell_Detail/",
					Guid,
					ShopSettings.overrideUrlName
				});
			}
			else if (isPanic == "1")
			{
				result = string.Concat(new string[]
				{
					"http://",
					shopURLByShopID,
					text,
					"/ProductIsPanic_Detail/",
					Guid,
					ShopSettings.overrideUrlName
				});
			}
			else
			{
				result = string.Concat(new string[]
				{
					"http://",
					shopURLByShopID,
					text,
					"/ProductDetail/",
					Guid,
					ShopSettings.overrideUrlName
				});
			}
		}
		else if (isSpell == "1")
		{
			result = string.Concat(new string[]
			{
				"http://",
				shopURLByShopID,
				text,
				"/ProductIsSpell_Detail/",
				Guid,
				".aspx"
			});
		}
		else if (isPanic == "1")
		{
			result = string.Concat(new string[]
			{
				"http://",
				shopURLByShopID,
				text,
				"/ProductIsPanic_Detail/",
				Guid,
				".aspx"
			});
		}
		else
		{
			result = string.Concat(new string[]
			{
				"http://",
				shopURLByShopID,
				text,
				"/ProductDetail/",
				Guid,
				".aspx"
			});
		}
		return result;
	}
	public static string RedirectProductDetailByMemloginID(string Guid, string memloginId, string isSpell, string isPanic)
	{
		DataTable shopIDByMemLoginID = ShopUrlOperate.ishopNum1_ShopInfoList_Action_0.GetShopIDByMemLoginID(memloginId);
		string result;
		if (shopIDByMemLoginID == null || shopIDByMemLoginID.Rows.Count == 0)
		{
			result = "";
		}
		else
		{
			string text = shopIDByMemLoginID.Rows[0]["ShopUrl"].ToString();
			string text2 = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
			if (ShopSettings.IsOverrideUrl)
			{
				if (isSpell == "1")
				{
					result = string.Concat(new string[]
					{
						"http://",
						text,
						text2,
						"/ProductIsSpell_Detail/",
						Guid,
						ShopSettings.overrideUrlName
					});
				}
				else if (isPanic == "1")
				{
					result = string.Concat(new string[]
					{
						"http://",
						text,
						text2,
						"/ProductIsPanic_Detail/",
						Guid,
						ShopSettings.overrideUrlName
					});
				}
				else
				{
					result = string.Concat(new string[]
					{
						"http://",
						text,
						text2,
						"/ProductDetail/",
						Guid,
						ShopSettings.overrideUrlName
					});
				}
			}
			else if (isSpell == "1")
			{
				result = string.Concat(new string[]
				{
					"http://",
					text,
					text2,
					"/ProductIsSpell_Detail/",
					Guid,
					".aspx"
				});
			}
			else if (isPanic == "1")
			{
				result = string.Concat(new string[]
				{
					"http://",
					text,
					text2,
					"/ProductIsPanic_Detail/",
					Guid,
					".aspx"
				});
			}
			else
			{
				result = string.Concat(new string[]
				{
					"http://",
					text,
					text2,
					"/ProductDetail/",
					Guid,
					".aspx"
				});
			}
		}
		return result;
	}
	public static string RedirectProductDetailByMemloginIDNew(string Guid, string memloginId, string isSpell, string isPanic)
	{
		string text = "all";
		string text2 = "public";
		ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
		DataTable substationByShopInfo = shopNum1_SubstationManage_Action.GetSubstationByShopInfo(memloginId);
		if (substationByShopInfo != null && substationByShopInfo.Rows.Count > 0)
		{
			text = substationByShopInfo.Rows[0]["SubstationID"].ToString();
		}
		if (text != "all")
		{
			text2 = shopNum1_SubstationManage_Action.GetDomainNameBySubstationID(text);
		}
		DataTable shopIDByMemLoginID = ShopUrlOperate.ishopNum1_ShopInfoList_Action_0.GetShopIDByMemLoginID(memloginId);
		string result;
		if (shopIDByMemLoginID == null || shopIDByMemLoginID.Rows.Count == 0)
		{
			result = "";
		}
		else
		{
			string text3 = shopIDByMemLoginID.Rows[0]["ShopUrl"].ToString();
			string text4 = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
			if (ShopSettings.IsOverrideUrl)
			{
				if (isSpell == "1")
				{
					result = string.Concat(new string[]
					{
						"http://",
						text3,
						".",
						text2,
						text4,
						"/ProductIsSpell_Detail/",
						Guid,
						ShopSettings.overrideUrlName
					});
				}
				else if (isPanic == "1")
				{
					result = string.Concat(new string[]
					{
						"http://",
						text3,
						".",
						text2,
						text4,
						"/ProductIsPanic_Detail/",
						Guid,
						ShopSettings.overrideUrlName
					});
				}
				else
				{
					result = string.Concat(new string[]
					{
						"http://",
						text3,
						".",
						text2,
						text4,
						"/ProductDetail/",
						Guid,
						ShopSettings.overrideUrlName
					});
				}
			}
			else if (isSpell == "1")
			{
				result = string.Concat(new string[]
				{
					"http://",
					text3,
					".",
					text2,
					text4,
					"/ProductIsSpell_Detail/",
					Guid,
					".aspx"
				});
			}
			else if (isPanic == "1")
			{
				result = string.Concat(new string[]
				{
					"http://",
					text3,
					".",
					text2,
					text4,
					"/ProductIsPanic_Detail/",
					Guid,
					".aspx"
				});
			}
			else
			{
				result = string.Concat(new string[]
				{
					"http://",
					text3,
					".",
					text2,
					text4,
					"/ProductDetail/",
					Guid,
					".aspx"
				});
			}
		}
		return result;
	}
	public static string GetRedirectProductDetailByShopUrl(string Guid, string ShopUrl, string isSpell, string isPanic)
	{
		string text = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
		string result;
		if (ShopSettings.IsOverrideUrl)
		{
			if (isSpell == "1")
			{
				result = string.Concat(new string[]
				{
					"http://",
					ShopUrl,
					text,
					"/ProductIsSpell_Detail/",
					Guid,
					ShopSettings.overrideUrlName
				});
			}
			else if (isPanic == "1")
			{
				result = string.Concat(new string[]
				{
					"http://",
					ShopUrl,
					text,
					"/ProductIsPanic_Detail/",
					Guid,
					ShopSettings.overrideUrlName
				});
			}
			else
			{
				result = string.Concat(new string[]
				{
					"http://",
					ShopUrl,
					text,
					"/ProductDetail/",
					Guid,
					ShopSettings.overrideUrlName
				});
			}
		}
		else if (isSpell == "1")
		{
			result = string.Concat(new string[]
			{
				"http://",
				ShopUrl,
				text,
				"/ProductIsSpell_Detail/",
				Guid,
				".aspx"
			});
		}
		else if (isPanic == "1")
		{
			result = string.Concat(new string[]
			{
				"http://",
				ShopUrl,
				text,
				"/ProductIsPanic_Detail/",
				Guid,
				".aspx"
			});
		}
		else
		{
			result = string.Concat(new string[]
			{
				"http://",
				ShopUrl,
				text,
				"/ProductDetail/",
				Guid,
				".aspx"
			});
		}
		return result;
	}
	public static string shopHref(string MemLoginID)
	{
		DataTable shopIDByMemLoginID = ShopUrlOperate.ishopNum1_ShopInfoList_Action_0.GetShopIDByMemLoginID(MemLoginID);
		string str = string.Empty;
		string str2 = string.Empty;
		if (shopIDByMemLoginID.Rows.Count > 0)
		{
			str = shopIDByMemLoginID.Rows[0]["ShopUrl"].ToString();
			str2 = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
		}
		return "http://" + str + str2;
	}
	public static string shopHrefNew(string MemLoginID)
	{
		string text = "all";
		string text2 = "public";
		ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
		DataTable substationByShopInfo = shopNum1_SubstationManage_Action.GetSubstationByShopInfo(MemLoginID);
		if (substationByShopInfo != null && substationByShopInfo.Rows.Count > 0)
		{
			text = substationByShopInfo.Rows[0]["SubstationID"].ToString();
		}
		if (text != "all")
		{
			text2 = shopNum1_SubstationManage_Action.GetDomainNameBySubstationID(text);
		}
		DataTable shopIDByMemLoginID = ShopUrlOperate.ishopNum1_ShopInfoList_Action_0.GetShopIDByMemLoginID(MemLoginID);
		string text3 = string.Empty;
		string text4 = string.Empty;
		if (shopIDByMemLoginID.Rows.Count > 0)
		{
			text3 = shopIDByMemLoginID.Rows[0]["ShopUrl"].ToString();
			text4 = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
		}
		return string.Concat(new string[]
		{
			"http://",
			text3,
			".",
			text2,
			text4
		});
	}
	public static string GetShopMessageBoardUrl(string ShopID)
	{
		string shopURLByShopID = ShopUrlOperate.GetShopURLByShopID(ShopID);
		string text = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
		string result;
		if (ShopSettings.IsOverrideUrl)
		{
			result = string.Concat(new string[]
			{
				"http://",
				shopURLByShopID,
				text,
				"/ShopMessageBoard",
				ShopSettings.overrideUrlName
			});
		}
		else
		{
			result = "http://" + shopURLByShopID + text + "/ShopMessageBoard.aspx";
		}
		return result;
	}
	public static string GetShopCommentUrl(string ShopID)
	{
		string shopURLByShopID = ShopUrlOperate.GetShopURLByShopID(ShopID);
		string text = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
		string result;
		if (ShopSettings.IsOverrideUrl)
		{
			result = string.Concat(new string[]
			{
				"http://",
				shopURLByShopID,
				text,
				"/ShopComment",
				ShopSettings.overrideUrlName
			});
		}
		else
		{
			result = "http://" + shopURLByShopID + text + "/ShopComment.aspx";
		}
		return result;
	}
	public static string RetUrl(string pagename)
	{
		return string.Concat(new string[]
		{
			"http://",
			ShopSettings.siteDomain,
			"/",
			pagename,
			ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx"
		});
	}
	public static string RetUrlNew(string pagename)
	{
		return string.Concat(new string[]
		{
			"http://",
			HttpContext.Current.Request.Url.Host,
			"/",
			pagename,
			ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx"
		});
	}
	public static string RetUrlAspx(string pagename)
	{
		return "http://" + ShopSettings.siteDomain + "/" + pagename;
	}
	public static string RetShopadminUrl(string pagename)
	{
		return string.Concat(new string[]
		{
			"http://",
			ShopSettings.siteDomain,
			"/shop/shopadmin/",
			pagename,
			".aspx"
		});
	}
	public static string RetMemberUrl(string pagename)
	{
		return string.Concat(new string[]
		{
			"http://",
			ShopSettings.siteDomain,
			"/main/Member/",
			pagename,
			".aspx"
		});
	}
	public static string RetUrl(string pagename, object value)
	{
		string result;
		if (ShopSettings.IsOverrideUrl)
		{
			result = string.Concat(new string[]
			{
				"http://",
				ShopSettings.siteDomain,
				"/",
				pagename,
				"/",
				value.ToString(),
				ShopSettings.overrideUrlName
			});
		}
		else
		{
			result = string.Concat(new string[]
			{
				"http://",
				ShopSettings.siteDomain,
				"/",
				pagename,
				"/",
				value.ToString(),
				".aspx"
			});
		}
		return result;
	}
	public static string RetUrlNew(string pagename, object value)
	{
		string result;
		if (ShopSettings.IsOverrideUrl)
		{
			result = string.Concat(new string[]
			{
				"http://",
				HttpContext.Current.Request.Url.Host,
				"/",
				pagename,
				"/",
				value.ToString(),
				ShopSettings.overrideUrlName
			});
		}
		else
		{
			result = string.Concat(new string[]
			{
				"http://",
				HttpContext.Current.Request.Url.Host,
				"/",
				pagename,
				"/",
				value.ToString(),
				".aspx"
			});
		}
		return result;
	}
	public static string RetUrl(string pagename, object value, string args)
	{
		string result;
		if (ShopSettings.IsOverrideUrl)
		{
			result = string.Concat(new string[]
			{
				"http://",
				ShopSettings.siteDomain,
				"/",
				pagename,
				"/",
				value.ToString(),
				ShopSettings.overrideUrlName
			});
		}
		else
		{
			result = string.Concat(new string[]
			{
				"http://",
				ShopSettings.siteDomain,
				"/",
				pagename,
				"/",
				value.ToString(),
				".aspx"
			});
		}
		return result;
	}
	public static string RetUrlNew(string pagename, object value, string args)
	{
		string result;
		if (ShopSettings.IsOverrideUrl)
		{
			result = string.Concat(new string[]
			{
				"http://",
				HttpContext.Current.Request.Url.Host,
				"/",
				pagename,
				"/",
				value.ToString(),
				ShopSettings.overrideUrlName
			});
		}
		else
		{
			result = string.Concat(new string[]
			{
				"http://",
				HttpContext.Current.Request.Url.Host,
				"/",
				pagename,
				"/",
				value.ToString(),
				".aspx"
			});
		}
		return result;
	}
	public static string RetUrl(string pagename, string value, string args)
	{
		string text = string.Concat(new string[]
		{
			"http://",
			ShopSettings.siteDomain,
			"/",
			pagename,
			ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx"
		});
		if (args != null)
		{
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"?",
				args,
				"=",
				value
			});
		}
		return text;
	}
	public static string RetUrlNew1(string pagename, string value, string args)
	{
		string text = string.Concat(new string[]
		{
			"http://",
			HttpContext.Current.Request.Url.Host,
			"/",
			pagename,
			ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx"
		});
		if (args != null)
		{
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"?",
				args,
				"=",
				value
			});
		}
		return text;
	}
	public static string ProductSearch(string search, object name)
	{
		string result;
		if (ShopSettings.IsOverrideUrl)
		{
			result = string.Concat(new string[]
			{
				"http://",
				ShopSettings.siteDomain,
				"/Search_productlist",
				ShopSettings.overrideUrlName,
				"?Search=",
				search,
				"&Name=",
				name.ToString()
			});
		}
		else
		{
			result = string.Concat(new string[]
			{
				"http://",
				ShopSettings.siteDomain,
				"/Search_productlist.aspx?Search=",
				search,
				"&Name=",
				name.ToString()
			});
		}
		return result;
	}
	public static string GetSiteDomain()
	{
		return "http://" + ShopSettings.siteDomain;
	}
	public static string RetShopUrl(string pagename)
	{
		return string.Concat(new string[]
		{
			"http://",
			HttpContext.Current.Request.Url.Host,
			"/",
			pagename,
			ShopSettings.overrideUrlName
		});
	}
	public static string RetShopUrl(string pagename, object value)
	{
		return string.Concat(new string[]
		{
			"http://",
			HttpContext.Current.Request.Url.Host,
			"/",
			pagename,
			"/",
			value.ToString(),
			ShopSettings.overrideUrlName
		});
	}
	public static string RetShopUrl(string pagename, object value, string args)
	{
		return string.Concat(new string[]
		{
			"http://",
			HttpContext.Current.Request.Url.Host,
			"/",
			pagename,
			ShopSettings.overrideUrlName,
			"?",
			args,
			"=",
			value.ToString()
		});
	}
	public static string GetUserCity()
	{
		QQWryLocator qQWryLocator = new QQWryLocator(HttpContext.Current.Server.MapPath("~/App_Data/QQWry.Dat"));
		string iPAddress = Globals.IPAddress;
		IPLocation iPLocation = qQWryLocator.Query(iPAddress);
		return iPLocation.Country;
	}
	public static string GetShopPath()
	{
		string host = HttpContext.Current.Request.Url.Host;
		string text = host.Split(new char[]
		{
			'.'
		})[0];
		string text2 = HttpContext.Current.Request.Url.AbsoluteUri.ToLower();
		string text3 = string.Empty;
		if (text2.IndexOf("http://www") == -1)
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@ShopUrl";
			array2[0] = text;
			DataTable dataTable = DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_UrlWriteShop", array, array2);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				string s = dataTable.Rows[0]["OpenTime"].ToString();
				string text4 = dataTable.Rows[0]["ShopID"].ToString();
				text3 = "~/Shop/Shop/";
				string text5 = text3;
				text3 = string.Concat(new string[]
				{
					text5,
					DateTime.Parse(s).ToString("yyyy-MM-dd").Replace('-', '/'),
					"/",
					ShopSettings.GetValue("PersonShopUrl"),
					text4,
					"/"
				});
			}
		}
		else
		{
			string[] array = new string[1];
			string[] array2 = new string[1];
			array[0] = "@domain";
			array2[0] = host;
			DataTable dataTable2 = DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_UrlWriteShopDoMain", array, array2);
			if (dataTable2 != null && dataTable2.Rows.Count > 0)
			{
				string text4 = dataTable2.Rows[0]["ShopID"].ToString();
				string s = dataTable2.Rows[0]["OpenTime"].ToString();
				text3 = "~/Shop/Shop/";
				string text5 = text3;
				text3 = string.Concat(new string[]
				{
					text5,
					DateTime.Parse(s).ToString("yyyy-MM-dd").Replace('-', '/'),
					"/",
					ShopSettings.GetValue("PersonShopUrl"),
					text4,
					"/"
				});
			}
		}
		return text3;
	}
	public static string RetMultiUrl(string pagename, object pvalue)
	{
		string text = string.Concat(new string[]
		{
			"http://",
			ShopSettings.siteDomain,
			"/",
			pagename,
			ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx"
		});
		if (pvalue != null)
		{
			text = text + "?" + pvalue.ToString();
		}
		return text;
	}
	public static string RetMultiUrlNew(string pagename, object pvalue)
	{
		string text = string.Concat(new string[]
		{
			"http://",
			HttpContext.Current.Request.Url.Host,
			"/",
			pagename,
			ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx"
		});
		if (pvalue != null)
		{
			text = text + "?" + pvalue.ToString();
		}
		return text;
	}
	public static string GetDeShopUrl(string ShopCode)
	{
		string shopURLByShopCode = ShopUrlOperate.GetShopURLByShopCode(ShopCode);
		ShopCode = ShopCode.Replace(ShopSettings.GetValue("PersonShopUrl"), "");
		string str = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
		string result;
		if (shopURLByShopCode == "")
		{
			result = "javascript:void(0)";
		}
		else
		{
			result = "http://" + shopURLByShopCode + str;
		}
		return result;
	}
	public static string GetShopURLByShopCode(string shopCode)
	{
		shopCode = shopCode.Replace(ShopSettings.GetValue("PersonShopUrl"), "");
		return ShopUrlOperate.ishopNum1_ShopInfoList_Action_0.GetShopURLByAddressCode(shopCode);
	}
	public static string RetUrlForSearch(string pagename, string value, string args)
	{
		string str = "http://" + HttpContext.Current.Request.Url.Host + HttpContext.Current.Request.Url.AbsolutePath;
		string text = HttpContext.Current.Request.Url.Query;
		if (string.IsNullOrEmpty(text))
		{
			str += string.Format("?{0}={1}", args, value);
		}
		else
		{
			string text2 = string.Empty;
			if (text.IndexOf('&') != -1)
			{
				string[] array = text.Split(new char[]
				{
					'&'
				});
				if (array.Length == 2)
				{
					if (text.StartsWith("?search"))
					{
						text2 = array[1];
					}
					else
					{
						text2 = array[0];
					}
				}
				else
				{
					text2 = text;
				}
			}
			else
			{
				text2 = text;
			}
			text = text2;
			text = "&" + text.Substring(1);
			if (text.IndexOf("&" + args) == -1)
			{
				text += string.Format("&{0}={1}", args, value);
			}
			else
			{
				int num = text.IndexOf("&" + args);
				string str2 = text.Substring(0, num + 1);
				text = str2 + args + "=" + value;
			}
			text = "?" + text.TrimStart(new char[]
			{
				'&'
			});
		}
		return str + text;
	}
	public static string RetUrlForSearch(string string_0, string urlCanshu, string value, string args)
	{
		string text = string_0;
		if (text.IndexOf(args) == -1)
		{
			if (urlCanshu == null || urlCanshu == "")
			{
				if (args != null)
				{
					string text2 = text;
					text = string.Concat(new string[]
					{
						text2,
						"?",
						args,
						"=",
						value
					});
				}
			}
			else if (args != null)
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					"&",
					args,
					"=",
					value
				});
			}
		}
		else
		{
			int length = text.IndexOf(args);
			string str = text.Substring(0, length);
			text = str + args + "=" + value;
		}
		return text;
	}
	public static object GetShopUrl(object object_0)
	{
		throw new NotImplementedException();
	}
	public static string GetOverrideUrlName()
	{
		string result;
		if (ShopSettings.IsOverrideUrl)
		{
			result = ShopSettings.overrideUrlName;
		}
		else
		{
			result = ".aspx";
		}
		return result;
	}
}
