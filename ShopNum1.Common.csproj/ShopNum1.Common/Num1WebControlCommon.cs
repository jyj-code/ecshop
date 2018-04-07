using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
namespace ShopNum1.Common
{
	public class Num1WebControlCommon
	{
		public string AppendPage(Page currentPage, int Pagecount, int Pageindex)
		{
			StringBuilder stringBuilder = new StringBuilder();
			DataRow shopSettingRow = ShopSettings.ShopSettingRow;
			if (HttpContext.Current.Request.ApplicationPath.ToLower().IndexOf("/admin") != -1 || HttpContext.Current.Request.Path.ToLower().IndexOf("admin/") != -1)
			{
				stringBuilder.Append("<select id=\"selectPage\" name=\"selectPage\" lang=\"" + currentPage.Request.CurrentExecutionFilePath + "\">");
			}
			else if (bool.Parse(shopSettingRow["OverrideUrl"].ToString()))
			{
				stringBuilder.Append("<select id=\"selectPage\" name=\"selectPage\" lang=\"" + currentPage.Request.CurrentExecutionFilePath + "\">");
			}
			else
			{
				stringBuilder.Append("<select id=\"selectPage\" name=\"selectPage\" lang=\"" + currentPage.Request.CurrentExecutionFilePath + "\">");
			}
			for (int i = 1; i <= Pagecount; i++)
			{
				if (Pageindex == i)
				{
					stringBuilder.Append(string.Concat(new object[]
					{
						"<option value='",
						i,
						"' selected>",
						i,
						"</option>"
					}));
				}
				else
				{
					stringBuilder.Append(string.Concat(new object[]
					{
						"<option value='",
						i,
						"'>",
						i,
						"</option>"
					}));
				}
			}
			stringBuilder.Append("</select>");
			return stringBuilder.ToString();
		}
		public string AppendPage(Page currentPage, string guid, int Pagecount, int Pageindex)
		{
			StringBuilder stringBuilder = new StringBuilder();
			DataRow shopSettingRow = ShopSettings.ShopSettingRow;
			if (HttpContext.Current.Request.ApplicationPath.ToLower().IndexOf("/admin") != -1 || HttpContext.Current.Request.Path.ToLower().IndexOf("admin/") != -1)
			{
				stringBuilder.Append(string.Concat(new string[]
				{
					"<select id=\"selectPage\" name=\"selectPage\" onchange=\"window.location.href='",
					currentPage.Request.CurrentExecutionFilePath,
					"?guid=",
					guid,
					"&page='+ this.options[this.selectedIndex].value \">"
				}));
			}
			else if (bool.Parse(shopSettingRow["OverrideUrl"].ToString()))
			{
				stringBuilder.Append("<select id=\"selectPage\" name=\"selectPage\" onchange=\"window.location.href='" + GetPageName.GetPage("?guid=" + guid + "&page='+ this.options[this.selectedIndex].value") + "\">");
			}
			else
			{
				stringBuilder.Append(string.Concat(new string[]
				{
					"<select id=\"selectPage\" name=\"selectPage\" onchange=\"window.location..href='",
					currentPage.Request.CurrentExecutionFilePath,
					"?guid=",
					guid,
					"&page='+ this.options[this.selectedIndex].value \">"
				}));
			}
			for (int i = 1; i <= Pagecount; i++)
			{
				if (Pageindex == i)
				{
					stringBuilder.Append(string.Concat(new object[]
					{
						"<option value='",
						i,
						"' selected>",
						i,
						"</option>"
					}));
				}
				else
				{
					stringBuilder.Append(string.Concat(new object[]
					{
						"<option value='",
						i,
						"'>",
						i,
						"</option>"
					}));
				}
			}
			stringBuilder.Append("</select>");
			return stringBuilder.ToString();
		}
		public string AppendPage2(Page currentPage, int Pagecount, int Pageindex, string otherParam)
		{
			StringBuilder stringBuilder = new StringBuilder();
			DataRow shopSettingRow = ShopSettings.ShopSettingRow;
			if (HttpContext.Current.Request.ApplicationPath.ToLower().IndexOf("/admin") != -1 || HttpContext.Current.Request.Path.ToLower().IndexOf("admin/") != -1)
			{
				stringBuilder.Append(string.Concat(new string[]
				{
					"<select id=\"selectPage\" name=\"selectPage\" onchange=\"window.location='",
					currentPage.Request.CurrentExecutionFilePath,
					"?page='+ this.options[this.selectedIndex].value+'",
					otherParam,
					"' \">"
				}));
			}
			else if (bool.Parse(shopSettingRow["OverrideUrl"].ToString()))
			{
				stringBuilder.Append("<select id=\"selectPage\" name=\"selectPage\" onchange=\"window.location='" + GetPageName.GetPage("?page='+ this.options[this.selectedIndex].value+'" + otherParam) + "' \">");
			}
			else
			{
				stringBuilder.Append(string.Concat(new string[]
				{
					"<select id=\"selectPage\" name=\"selectPage\" onchange=\"window.location='",
					currentPage.Request.CurrentExecutionFilePath,
					"?page='+ this.options[this.selectedIndex].value+'",
					otherParam,
					"' \">"
				}));
			}
			for (int i = 1; i <= Pagecount; i++)
			{
				if (Pageindex == i)
				{
					stringBuilder.Append(string.Concat(new object[]
					{
						"<option value='",
						i,
						"' selected>",
						i,
						"</option>"
					}));
				}
				else
				{
					stringBuilder.Append(string.Concat(new object[]
					{
						"<option value='",
						i,
						"'>",
						i,
						"</option>"
					}));
				}
			}
			stringBuilder.Append("</select>");
			return stringBuilder.ToString();
		}
		public string AppendPage(Page currentPage, int Pagecount, int Pageindex, string otherParam)
		{
			StringBuilder stringBuilder = new StringBuilder();
			DataRow shopSettingRow = ShopSettings.ShopSettingRow;
			if (HttpContext.Current.Request.ApplicationPath.ToLower().IndexOf("/admin") != -1 || HttpContext.Current.Request.Path.ToLower().IndexOf("admin/") != -1)
			{
				stringBuilder.Append("<select id=\"selectPage\" name=\"selectPage\">");
			}
			else if (bool.Parse(shopSettingRow["OverrideUrl"].ToString()))
			{
				stringBuilder.Append("<select id=\"selectPage\" name=\"selectPage\">");
			}
			else
			{
				stringBuilder.Append("<select id=\"selectPage\" name=\"selectPage\">");
			}
			for (int i = 1; i <= Pagecount; i++)
			{
				if (Pageindex == i)
				{
					stringBuilder.Append(string.Concat(new object[]
					{
						"<option value='",
						i,
						"' selected>",
						i,
						"</option>"
					}));
				}
				else
				{
					stringBuilder.Append(string.Concat(new object[]
					{
						"<option value='",
						i,
						"'>",
						i,
						"</option>"
					}));
				}
			}
			stringBuilder.Append("</select>");
			return stringBuilder.ToString();
		}
		public string GetPageMessage(int pdsDataSoucreCount, int pageCount, int pageSize, int currentPage)
		{
			return string.Concat(new object[]
			{
				"共",
				pdsDataSoucreCount,
				"条记录，共",
				pageCount,
				"页，每页",
				pageSize,
				"条，第",
				currentPage,
				"页"
			});
		}
		public string AgentAppendPage(Page currentPage, int Pagecount, int Pageindex)
		{
			StringBuilder stringBuilder = new StringBuilder();
			DataRow shopSettingRow = ShopSettings.ShopSettingRow;
			if (HttpContext.Current.Request.ApplicationPath.ToLower().IndexOf("/admin") != -1)
			{
				stringBuilder.Append(string.Concat(new string[]
				{
					"<select id=\"selectPage\" name=\"selectPage\" onchange=\"window.location='",
					currentPage.Request.CurrentExecutionFilePath,
					"?AgentLoginID=",
					HttpContext.Current.Request.QueryString["AgentLoginID"],
					"&&page='+ this.options[this.selectedIndex].value \">"
				}));
			}
			else if (bool.Parse(shopSettingRow["OverrideUrl"].ToString()))
			{
				stringBuilder.Append("<select id=\"selectPage\" name=\"selectPage\" onchange=\"window.location='" + GetPageName.AgentGetPage("?page='+ this.options[this.selectedIndex].value") + "\">");
			}
			else
			{
				stringBuilder.Append(string.Concat(new string[]
				{
					"<select id=\"selectPage\" name=\"selectPage\" onchange=\"window.location='",
					currentPage.Request.CurrentExecutionFilePath,
					"?AgentLoginID=",
					HttpContext.Current.Request.QueryString["AgentLoginID"],
					"&&page='+ this.options[this.selectedIndex].value \">"
				}));
			}
			for (int i = 1; i <= Pagecount; i++)
			{
				if (Pageindex == i)
				{
					stringBuilder.Append(string.Concat(new object[]
					{
						"<option value='",
						i,
						"' selected>",
						i,
						"</option>"
					}));
				}
				else
				{
					stringBuilder.Append(string.Concat(new object[]
					{
						"<option value='",
						i,
						"'>",
						i,
						"</option>"
					}));
				}
			}
			stringBuilder.Append("</select>");
			return stringBuilder.ToString();
		}
		public string AgentAppendPage(Page currentPage, int Pagecount, int Pageindex, string otherParam)
		{
			StringBuilder stringBuilder = new StringBuilder();
			DataRow shopSettingRow = ShopSettings.ShopSettingRow;
			if (HttpContext.Current.Request.ApplicationPath.ToLower().IndexOf("/admin") != -1)
			{
				stringBuilder.Append(string.Concat(new string[]
				{
					"<select id=\"selectPage\" name=\"selectPage\" onchange=\"window.location='",
					currentPage.Request.CurrentExecutionFilePath,
					"?AgentLoginID=",
					HttpContext.Current.Request.QueryString["AgentLoginID"],
					"&&page='+ this.options[this.selectedIndex].value+'",
					otherParam,
					"' \">"
				}));
			}
			else if (bool.Parse(shopSettingRow["OverrideUrl"].ToString()))
			{
				stringBuilder.Append("<select id=\"selectPage\" name=\"selectPage\" onchange=\"window.location='" + GetPageName.AgentGetPage("?page='+ this.options[this.selectedIndex].value+'" + otherParam) + "' \">");
			}
			else
			{
				stringBuilder.Append(string.Concat(new string[]
				{
					"<select id=\"selectPage\" name=\"selectPage\" onchange=\"window.location='",
					currentPage.Request.CurrentExecutionFilePath,
					"?AgentLoginID=",
					HttpContext.Current.Request.QueryString["AgentLoginID"],
					"&&page='+ this.options[this.selectedIndex].value+'",
					otherParam,
					"' \">"
				}));
			}
			for (int i = 1; i <= Pagecount; i++)
			{
				if (Pageindex == i)
				{
					stringBuilder.Append(string.Concat(new object[]
					{
						"<option value='",
						i,
						"' selected>",
						i,
						"</option>"
					}));
				}
				else
				{
					stringBuilder.Append(string.Concat(new object[]
					{
						"<option value='",
						i,
						"'>",
						i,
						"</option>"
					}));
				}
			}
			stringBuilder.Append("</select>");
			return stringBuilder.ToString();
		}
		public string AppendPageVideo(string strUrl, int Pagecount, int Pageindex)
		{
			StringBuilder stringBuilder = new StringBuilder();
			DataRow arg_0B_0 = ShopSettings.ShopSettingRow;
			if (strUrl.ToLower().IndexOf("/admin") != -1 || strUrl.ToLower().IndexOf("admin/") != -1)
			{
				stringBuilder.Append("<select id=\"selectPage\" name=\"selectPage\" onchange=\"window.location.href='" + strUrl + "&page='+ this.options[this.selectedIndex].value \">");
			}
			else
			{
				stringBuilder.Append("<select id=\"selectPage\" name=\"selectPage\" onchange=\"window.location..href='" + strUrl + "&page='+ this.options[this.selectedIndex].value \">");
			}
			for (int i = 1; i <= Pagecount; i++)
			{
				if (Pageindex == i)
				{
					stringBuilder.Append(string.Concat(new object[]
					{
						"<option value='",
						i,
						"' selected>",
						i,
						"</option>"
					}));
				}
				else
				{
					stringBuilder.Append(string.Concat(new object[]
					{
						"<option value='",
						i,
						"'>",
						i,
						"</option>"
					}));
				}
			}
			stringBuilder.Append("</select>");
			return stringBuilder.ToString();
		}
	}
}
