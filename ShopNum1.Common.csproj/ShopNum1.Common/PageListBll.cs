using System;
using System.Text;
using System.Web;
namespace ShopNum1.Common
{
	public class PageListBll
	{
		private string string_0 = "?PageID={0}";
		private string string_1 = "";
		private string string_2 = "<<";
		private string string_3 = "<上一页";
		private string string_4 = "下一页>";
		private string string_5 = ">>";
		private int int_0 = 10;
		private bool bool_0 = true;
		private bool bool_1 = true;
		private bool bool_2 = true;
		private bool bool_3 = true;
		private bool bool_4 = true;
		private bool bool_5 = true;
		public string PageName
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
			}
		}
		public string FirstPageText
		{
			get
			{
				return this.string_2;
			}
			set
			{
				this.string_2 = value;
			}
		}
		public string PrevPageText
		{
			get
			{
				return this.string_3;
			}
			set
			{
				this.string_3 = value;
			}
		}
		public string NextPageText
		{
			get
			{
				return this.string_4;
			}
			set
			{
				this.string_4 = value;
			}
		}
		public string LastPageText
		{
			get
			{
				return this.string_5;
			}
			set
			{
				this.string_5 = value;
			}
		}
		public int NumericButtonCount
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
			}
		}
		public bool ShowNoRecordInfo
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
			}
		}
		public bool ShowPageIndex
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				this.bool_1 = value;
			}
		}
		public bool ShowPageCount
		{
			get
			{
				return this.bool_2;
			}
			set
			{
				this.bool_2 = value;
			}
		}
		public bool ShowRecordCount
		{
			get
			{
				return this.bool_3;
			}
			set
			{
				this.bool_3 = value;
			}
		}
		public bool ShowPageListButton
		{
			get
			{
				return this.bool_4;
			}
			set
			{
				this.bool_4 = value;
			}
		}
		public bool ShowNumListButton
		{
			get
			{
				return this.bool_5;
			}
			set
			{
				this.bool_5 = value;
			}
		}
		public PageListBll()
		{
			for (int i = 0; i < HttpContext.Current.Request.QueryString.Count; i++)
			{
				if (HttpContext.Current.Request.Params.Keys[i].ToString().ToLower() != "pageid")
				{
					string text = this.string_1;
					this.string_1 = string.Concat(new string[]
					{
						text,
						HttpContext.Current.Request.Params.Keys[i].ToString(),
						"=",
						HttpUtility.UrlEncode(HttpContext.Current.Request.Params[HttpContext.Current.Request.Params.Keys[i]].ToString()),
						"&"
					});
				}
			}
			this.PageName = "?" + this.string_1 + "PageID={0}";
		}
		public PageListBll(string pname, bool isHttpPost)
		{
			string str = string.Empty;
			if (pname.IndexOf(".aspx") != -1)
			{
				str = "http://" + HttpContext.Current.Request.Url.Host + "/" + pname;
			}
			else
			{
				str = string.Concat(new string[]
				{
					"http://",
					HttpContext.Current.Request.Url.Host,
					"/",
					pname,
					ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx"
				});
			}
			for (int i = 0; i < HttpContext.Current.Request.QueryString.Count; i++)
			{
				if (HttpContext.Current.Request.Params.Keys[i] != null && HttpContext.Current.Request.Params.Keys[i].ToString().ToLower() != "pageid" && HttpContext.Current.Request.Params.Keys[i].ToString().ToLower() != "shopid" && HttpContext.Current.Request.Params[HttpContext.Current.Request.Params.Keys[i]] != null)
				{
					string text = this.string_1;
					this.string_1 = string.Concat(new string[]
					{
						text,
						HttpContext.Current.Request.Params.Keys[i].ToString(),
						"=",
						HttpUtility.UrlEncode(HttpContext.Current.Request.Params[HttpContext.Current.Request.Params.Keys[i]].ToString()),
						"&"
					});
				}
			}
			if (isHttpPost)
			{
				this.PageName = str + "?" + this.string_1 + "PageID={0}";
			}
			else
			{
				this.PageName = "?" + this.string_1 + "PageID={0}";
			}
		}
		public PageListBll(string pname, bool isHttpPost, string type)
		{
			string str = string.Empty;
			if (type == "1")
			{
				str = string.Concat(new string[]
				{
					"http://",
					HttpContext.Current.Request.Url.Host,
					"/",
					pname,
					ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx"
				});
			}
			if (type == "2")
			{
				str = string.Concat(new string[]
				{
					"http://",
					HttpContext.Current.Request.Url.Host,
					"/",
					pname,
					".aspx"
				});
			}
			for (int i = 0; i < HttpContext.Current.Request.QueryString.Count; i++)
			{
				if (HttpContext.Current.Request.Params.Keys[i] != null && HttpContext.Current.Request.Params.Keys[i].ToString().ToLower() != "pageid" && HttpContext.Current.Request.Params.Keys[i].ToString().ToLower() != "shopid" && HttpContext.Current.Request.Params[HttpContext.Current.Request.Params.Keys[i]] != null)
				{
					string text = this.string_1;
					this.string_1 = string.Concat(new string[]
					{
						text,
						HttpContext.Current.Request.Params.Keys[i].ToString(),
						"=",
						HttpUtility.UrlEncode(HttpContext.Current.Request.Params[HttpContext.Current.Request.Params.Keys[i]].ToString()),
						"&"
					});
				}
			}
			if (isHttpPost)
			{
				this.PageName = str + "?" + this.string_1 + "PageID={0}";
			}
			else
			{
				this.PageName = "?" + this.string_1 + "PageID={0}";
			}
		}
		public string GetPageList(PageList1 pageList1_0)
		{
			StringBuilder stringBuilder = new StringBuilder("");
			string result;
			if (pageList1_0.RecordCount == 0)
			{
				if (this.ShowNoRecordInfo)
				{
					stringBuilder.Append("<div class=\"PageInfo\" align=\"left\">\r");
					if (this.ShowPageIndex)
					{
						stringBuilder.Append("第<b>1</b>页&nbsp;");
					}
					if (this.ShowPageCount)
					{
						stringBuilder.Append("&nbsp;共<b>1</b>页");
					}
					if (this.ShowRecordCount)
					{
						stringBuilder.Append("&nbsp;&nbsp;Record <b>0</b>");
					}
					if (this.ShowPageListButton)
					{
						stringBuilder.Append(string.Format("&nbsp;&nbsp;&nbsp;&nbsp;{0}&nbsp;&nbsp;", this.FirstPageText));
						stringBuilder.Append(string.Format("&nbsp;&nbsp;{0}&nbsp;&nbsp;", this.PrevPageText));
						stringBuilder.Append(string.Format("&nbsp;&nbsp;{0}&nbsp;&nbsp;", this.NextPageText));
						stringBuilder.Append(string.Format("&nbsp;&nbsp;{0}", this.LastPageText));
					}
					stringBuilder.Append("\r</div>");
				}
				result = stringBuilder.ToString();
			}
			else
			{
				pageList1_0.PageCount = pageList1_0.RecordCount / pageList1_0.PageSize;
				if ((double)pageList1_0.PageCount < (double)pageList1_0.RecordCount / (double)pageList1_0.PageSize)
				{
					pageList1_0.PageCount++;
				}
				stringBuilder.Append("<div class=\"PageInfo\" align=\"left\">\r");
				if (this.ShowPageIndex)
				{
					if (pageList1_0.PageID == 0)
					{
						stringBuilder.Append("第<b>" + (pageList1_0.PageID + 1).ToString() + "</b>页&nbsp;");
					}
					else
					{
						stringBuilder.Append("第<b>" + pageList1_0.PageID.ToString() + "</b>页&nbsp;");
					}
				}
				if (this.ShowPageCount)
				{
					stringBuilder.Append("&nbsp;共<b>" + pageList1_0.PageCount + "</b>页");
				}
				if (this.ShowRecordCount)
				{
					stringBuilder.Append("&nbsp;&nbsp;共<b>" + pageList1_0.RecordCount.ToString() + "</b>条数据");
				}
				if (this.ShowPageListButton)
				{
					if (pageList1_0.PageID == 1)
					{
						stringBuilder.Append(string.Format("&nbsp;&nbsp;&nbsp;&nbsp;{0}&nbsp;", this.FirstPageText));
					}
					else
					{
						stringBuilder.Append(string.Format("&nbsp;&nbsp;&nbsp;&nbsp;<a  onclick='PageClick(" + 1 + ")' href=\"javascript:void(0)\">{0}</a>&nbsp;", this.FirstPageText));
					}
					if (pageList1_0.PageID == 1)
					{
						stringBuilder.Append(string.Format("&nbsp;{0}&nbsp;", this.PrevPageText));
					}
					else
					{
						stringBuilder.Append(string.Format("&nbsp;<a  onclick='PageClick(" + (pageList1_0.PageID - 1).ToString() + ")' href=\"javascript:void(0)\">{0}</a>&nbsp;", this.PrevPageText));
					}
				}
				if (this.ShowNumListButton)
				{
					stringBuilder.Append("&nbsp;&nbsp;<span class=\"PageNumButton\"> ");
					int num = pageList1_0.PageID - this.NumericButtonCount / 2;
					if (num < 1)
					{
						num = 1;
					}
					int num2 = num;
					while (num2 < num + this.NumericButtonCount && num2 <= pageList1_0.PageCount)
					{
						if (num2 == pageList1_0.PageID)
						{
							stringBuilder.Append("&nbsp;<label class=\"PageIndex\">" + num2.ToString() + "</label>&nbsp;");
						}
						else
						{
							stringBuilder.Append(string.Concat(new object[]
							{
								"&nbsp;<a  onclick='PageClick(",
								num2,
								")' href=\"javascript:void(0)\">",
								num2.ToString(),
								"</a>&nbsp;"
							}));
						}
						num2++;
					}
					stringBuilder.Append("</span>");
				}
				if (this.ShowPageListButton)
				{
					if (pageList1_0.PageID == pageList1_0.PageCount)
					{
						stringBuilder.Append(string.Format("&nbsp;{0}&nbsp;", this.NextPageText));
					}
					else
					{
						stringBuilder.Append(string.Format("&nbsp;<a onclick='PageClick(" + (pageList1_0.PageID + 1).ToString() + ")' href=\"javascript:void(0)\">{0}</a>&nbsp;", this.NextPageText));
					}
					if (pageList1_0.PageID == pageList1_0.PageCount)
					{
						stringBuilder.Append(string.Format("&nbsp;{0}", this.LastPageText));
					}
					else
					{
						stringBuilder.Append(string.Format("&nbsp;<a  onclick='PageClick(" + pageList1_0.PageCount.ToString() + ")' href=\"javascript:void(0)\">{0}</a>", this.LastPageText));
					}
				}
				stringBuilder.Append("\r<input id=\"pageid\" name=\"pageid\" value=\"0\" type=\"hidden\" />");
				stringBuilder.Append("\r</div>");
				result = stringBuilder.ToString();
			}
			return result;
		}
		public string GetPageListVk(PageList1 pageList1_0)
		{
			StringBuilder stringBuilder = new StringBuilder("");
			string result;
			if (pageList1_0.RecordCount == 0)
			{
				if (this.ShowNoRecordInfo)
				{
					stringBuilder.Append("<div class=\"black2\">\r");
					if (this.ShowPageListButton)
					{
						stringBuilder.Append(" <span class=\"disabled\">< </span>");
						stringBuilder.Append("<span class=\"current\">0</span>");
						stringBuilder.Append(" <span class=\"disabled\"> > </span>");
					}
					stringBuilder.Append("\r</div>");
				}
				result = stringBuilder.ToString();
			}
			else
			{
				pageList1_0.PageCount = pageList1_0.RecordCount / pageList1_0.PageSize;
				if ((double)pageList1_0.PageCount < (double)pageList1_0.RecordCount / (double)pageList1_0.PageSize)
				{
					pageList1_0.PageCount++;
				}
				stringBuilder.Append("<div class=\"black2\">\r");
				if (this.ShowPageIndex)
				{
					stringBuilder.Append("第<b>" + pageList1_0.PageID.ToString() + "</b>页&nbsp;");
				}
				if (this.ShowPageCount)
				{
					stringBuilder.Append("&nbsp;共<b>" + pageList1_0.PageCount + "</b>页");
				}
				if (this.ShowRecordCount)
				{
					stringBuilder.Append("&nbsp;&nbsp;共<b>" + pageList1_0.RecordCount.ToString() + "</b>条数据");
				}
				if (pageList1_0.PageID < 0)
				{
					pageList1_0.PageID = 0;
				}
				if (pageList1_0.PageID > pageList1_0.PageCount)
				{
					pageList1_0.PageID = pageList1_0.PageCount;
				}
				if (this.ShowPageListButton)
				{
					if (pageList1_0.PageID == 1)
					{
						stringBuilder.Append("<span class=\"disabled\">" + this.PrevPageText + "</span>");
					}
					else
					{
						stringBuilder.Append(string.Format("<a  class=\"PrevPage\" href=\"" + string.Format(this.PageName, pageList1_0.PageID - 1) + "\">{0}</a>", this.PrevPageText));
					}
				}
				if (this.ShowNumListButton)
				{
					int num = 1;
					if (pageList1_0.PageCount < 5)
					{
						for (int i = num; i <= pageList1_0.PageCount; i++)
						{
							if (i == pageList1_0.PageID)
							{
								stringBuilder.Append("<span class=\"current\">" + i.ToString() + "</span>");
							}
							else
							{
								stringBuilder.Append(string.Concat(new string[]
								{
									"<a href=\"",
									string.Format(this.PageName, i),
									"\">",
									i.ToString(),
									"</a>"
								}));
							}
						}
					}
					else if (pageList1_0.PageID < 5)
					{
						int num2 = pageList1_0.PageID + 2;
						if (num2 > pageList1_0.PageCount - 1)
						{
							num2 = pageList1_0.PageCount - 1;
						}
						for (int i = num; i <= num2; i++)
						{
							if (i == pageList1_0.PageID)
							{
								stringBuilder.Append("<span class=\"current\">" + i.ToString() + "</span>");
							}
							else
							{
								stringBuilder.Append(string.Concat(new string[]
								{
									"<a href=\"",
									string.Format(this.PageName, i),
									"\">",
									i.ToString(),
									"</a>"
								}));
							}
						}
						stringBuilder.Append("<span class=\"diandian\">...</span>");
						stringBuilder.Append(string.Concat(new object[]
						{
							"<a href=\"",
							string.Format(this.PageName, pageList1_0.PageCount),
							"\">",
							pageList1_0.PageCount,
							"</a>"
						}));
					}
					else
					{
						stringBuilder.Append(string.Concat(new object[]
						{
							"<a href=\"",
							string.Format(this.PageName, 1),
							"\">",
							1,
							"</a>"
						}));
						stringBuilder.Append("<span class=\"diandian\">...</span>");
						if (pageList1_0.PageID > pageList1_0.PageCount)
						{
							pageList1_0.PageID = pageList1_0.PageCount;
						}
						if (pageList1_0.PageID + 3 > pageList1_0.PageCount)
						{
							for (int j = pageList1_0.PageID - 2; j <= pageList1_0.PageCount; j++)
							{
								if (j == pageList1_0.PageID)
								{
									stringBuilder.Append("<span class=\"current\">" + j.ToString() + "</span>");
								}
								else
								{
									stringBuilder.Append(string.Concat(new string[]
									{
										"<a href=\"",
										string.Format(this.PageName, j),
										"\">",
										j.ToString(),
										"</a>"
									}));
								}
							}
						}
						else
						{
							for (int j = pageList1_0.PageID - 2; j <= pageList1_0.PageID + 2; j++)
							{
								if (j == pageList1_0.PageID)
								{
									stringBuilder.Append("<span class=\"current\">" + j.ToString() + "</span>");
								}
								else
								{
									stringBuilder.Append(string.Concat(new string[]
									{
										"<a href=\"",
										string.Format(this.PageName, j),
										"\">",
										j.ToString(),
										"</a>"
									}));
								}
							}
							stringBuilder.Append("<span  class=\"diandian\">...</span>");
							stringBuilder.Append(string.Concat(new object[]
							{
								"<a href=\"",
								string.Format(this.PageName, pageList1_0.PageCount),
								"\">",
								pageList1_0.PageCount,
								"</a>"
							}));
						}
					}
				}
				if (this.ShowPageListButton)
				{
					if (pageList1_0.PageID == pageList1_0.PageCount)
					{
						stringBuilder.Append("<span class=\"disabled\">" + this.NextPageText + "</span>");
					}
					else
					{
						stringBuilder.Append(string.Format("<a class=\"nextpage\" href=\"" + string.Format(this.PageName, pageList1_0.PageID + 1) + "\">{0}</a>", this.NextPageText));
					}
				}
				stringBuilder.Append("\r</div>");
				result = stringBuilder.ToString();
			}
			return result;
		}
		public string GetPageListNextPrev(PageList1 pageList1_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("<span class=\"page_2\">");
			pageList1_0.PageCount = pageList1_0.RecordCount / pageList1_0.PageSize;
			string result;
			if (pageList1_0.RecordCount == 0 || pageList1_0.PageCount == 0)
			{
				result = "";
			}
			else
			{
				if ((double)pageList1_0.PageCount < (double)pageList1_0.RecordCount / (double)pageList1_0.PageSize)
				{
					pageList1_0.PageCount++;
				}
				if (pageList1_0.PageID < 0)
				{
					pageList1_0.PageID = 0;
				}
				if (pageList1_0.PageID > pageList1_0.PageCount)
				{
					pageList1_0.PageID = pageList1_0.PageCount;
				}
				if (pageList1_0.PageID != 1)
				{
					stringBuilder.Append(string.Format("<a  class=\"afy1\" href=\"" + string.Format(this.PageName, 1) + "\">{0}</a>", "首页"));
					stringBuilder.Append(string.Format("<a  class=\"afy1\" href=\"" + string.Format(this.PageName, pageList1_0.PageID - 1) + "\">{0}</a>", "上一页"));
				}
				if (pageList1_0.PageID != pageList1_0.PageCount && pageList1_0.PageID != 1)
				{
					stringBuilder.Append(string.Format("<a  class=\"afy1\" href=\"" + string.Format(this.PageName, pageList1_0.PageID - 1) + "\">{0}</a>", "下一页"));
					stringBuilder.Append(string.Format("<a  class=\"afy1\" href=\"" + string.Format(this.PageName, pageList1_0.PageCount) + "\">{0}</a>", "末页"));
				}
				stringBuilder.Append("</span>");
				result = stringBuilder.ToString();
			}
			return result;
		}
		public string GetPageListNew(PageList1 pageList1_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("<span class=\"page_1\">");
			pageList1_0.PageCount = pageList1_0.RecordCount / pageList1_0.PageSize;
			string result;
			if (pageList1_0.RecordCount == 0 || pageList1_0.PageCount == 0)
			{
				result = "";
			}
			else
			{
				if ((double)pageList1_0.PageCount < (double)pageList1_0.RecordCount / (double)pageList1_0.PageSize)
				{
					pageList1_0.PageCount++;
				}
				if (pageList1_0.PageID < 0)
				{
					pageList1_0.PageID = 0;
				}
				if (pageList1_0.PageID > pageList1_0.PageCount)
				{
					pageList1_0.PageID = pageList1_0.PageCount;
				}
				if (pageList1_0.PageID != 1)
				{
					stringBuilder.Append(string.Format("<a  class=\"afy1\" href=\"" + string.Format(this.PageName, pageList1_0.PageID - 1) + "\">{0}</a>", "<img src=\"images/fyxiangmu_l.gif\" width=\"6\" height=\"9\"  border=\"0\"/>"));
				}
				int num = 1;
				if (pageList1_0.PageCount < 5)
				{
					for (int i = num; i <= pageList1_0.PageCount; i++)
					{
						if (i == pageList1_0.PageID)
						{
							stringBuilder.Append("<a class=\"afy011\" href=\"javascript:void(0)\">" + i.ToString() + "</a>");
						}
						else
						{
							stringBuilder.Append(string.Concat(new string[]
							{
								"<a href=\"",
								string.Format(this.PageName, i),
								"\" class=\"afy\">",
								i.ToString(),
								"</a>"
							}));
						}
					}
				}
				else if (pageList1_0.PageID < 5)
				{
					int num2 = pageList1_0.PageID + 2;
					if (num2 > pageList1_0.PageCount - 1)
					{
						num2 = pageList1_0.PageCount - 1;
					}
					for (int i = num; i <= num2; i++)
					{
						if (i == pageList1_0.PageID)
						{
							stringBuilder.Append("<a href=\"javascript:void(0)\" class=\"afy011\">" + i.ToString() + "</a>");
						}
						else
						{
							stringBuilder.Append(string.Concat(new string[]
							{
								"<a href=\"",
								string.Format(this.PageName, i),
								"\" class=\"afy\">",
								i.ToString(),
								"</a>"
							}));
						}
					}
					stringBuilder.Append("<span  class=\"diandian\">...</span>");
					stringBuilder.Append(string.Concat(new object[]
					{
						"<a href=\"",
						string.Format(this.PageName, pageList1_0.PageCount),
						"\" class=\"afy\">",
						pageList1_0.PageCount,
						"</a>"
					}));
				}
				else
				{
					stringBuilder.Append(string.Concat(new object[]
					{
						"<a href=\"",
						string.Format(this.PageName, 1),
						"\" class=\"afy\">",
						1,
						"</a>"
					}));
					stringBuilder.Append("<span class=\"diandian\">...</span>");
					if (pageList1_0.PageID > pageList1_0.PageCount)
					{
						pageList1_0.PageID = pageList1_0.PageCount;
					}
					if (pageList1_0.PageID + 3 > pageList1_0.PageCount)
					{
						for (int j = pageList1_0.PageID - 2; j <= pageList1_0.PageCount; j++)
						{
							if (j == pageList1_0.PageID)
							{
								stringBuilder.Append("<a  href=\"javascript:void(0)\" class=\"afy011\">" + j.ToString() + "</a>");
							}
							else
							{
								stringBuilder.Append(string.Concat(new string[]
								{
									"<a href=\"",
									string.Format(this.PageName, j),
									"\" class=\"afy\">",
									j.ToString(),
									"</a>"
								}));
							}
						}
					}
					else
					{
						for (int j = pageList1_0.PageID - 2; j <= pageList1_0.PageID + 2; j++)
						{
							if (j == pageList1_0.PageID)
							{
								stringBuilder.Append("<a class=\"afy011\" href=\"javascript:void(0)\" >" + j.ToString() + "</a>");
							}
							else
							{
								stringBuilder.Append(string.Concat(new string[]
								{
									"<a href=\"",
									string.Format(this.PageName, j),
									"\" class=\"afy\">",
									j.ToString(),
									"</a>"
								}));
							}
						}
						stringBuilder.Append("<span  class=\"diandian\">...</span>");
						stringBuilder.Append(string.Concat(new object[]
						{
							"<a href=\"",
							string.Format(this.PageName, pageList1_0.PageCount),
							"\" class=\"afy\">",
							pageList1_0.PageCount,
							"</a>"
						}));
					}
				}
				if (pageList1_0.PageID != pageList1_0.PageCount)
				{
					stringBuilder.Append(string.Format("<a class=\"afy1\" href=\"" + string.Format(this.PageName, pageList1_0.PageID + 1) + "\">{0}</a>", "<img src=\"images/fyxiangmu.gif\" width=\"6\" height=\"9\"  border=\"0\"/>"));
				}
				stringBuilder.Append("</span>");
				stringBuilder.Append(string.Concat(new object[]
				{
					"<span class=\"spanfy page_2\">&nbsp;共<b>",
					pageList1_0.PageCount,
					"</b>页&nbsp;到第</span><span class=\"page_3\"><input type=\"text\" name=\"searchpage\" id=\"txtIndex\" class=\"xwb\" value=\"",
					pageList1_0.PageID,
					"\" /></span><span class=\"page_4\"> 页 </span>"
				}));
				stringBuilder.Append("<span class=\"page_5\"><div class=\"qudbtn\"><a href=\"javascript:void(0)\" onclick=\"ontoPage(this)\"/>确定</a></div></span>");
				result = stringBuilder.ToString();
			}
			return result;
		}
		public string GetPageListNewManage(PageList1 pageList1_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			pageList1_0.PageCount = pageList1_0.RecordCount / pageList1_0.PageSize;
			string result;
			if (pageList1_0.RecordCount == 0 || pageList1_0.PageCount == 0)
			{
				result = "";
			}
			else
			{
				if ((double)pageList1_0.PageCount < (double)pageList1_0.RecordCount / (double)pageList1_0.PageSize)
				{
					pageList1_0.PageCount++;
				}
				if (pageList1_0.PageID < 0)
				{
					pageList1_0.PageID = 0;
				}
				if (pageList1_0.PageID > pageList1_0.PageCount)
				{
					pageList1_0.PageID = pageList1_0.PageCount;
				}
				stringBuilder.Append("<span style=\"padding-right: 10px;\">第<font>" + pageList1_0.PageID + "</font>页&nbsp;&nbsp;");
				if (pageList1_0.PageID == pageList1_0.PageCount)
				{
					stringBuilder.Append("当前页共<font>" + (pageList1_0.RecordCount - (pageList1_0.PageID - 1) * pageList1_0.PageSize).ToString() + "</font>条数据");
				}
				else
				{
					stringBuilder.Append("当前页共<font>" + pageList1_0.PageSize + "</font>条数据");
				}
				stringBuilder.Append("&nbsp;&nbsp;共<font class=\"pagecount\">" + pageList1_0.PageCount + "</font>页</span>");
				if (pageList1_0.PageID != 1)
				{
					stringBuilder.Append(string.Format("<a  style=\"text-decoration:none;\" href=\"" + string.Format(this.PageName, 1) + "\">{0}</a>", "<<"));
					stringBuilder.Append(string.Format("<a  class=\"gred_prev\" style=\"text-decoration:none;\" href=\"" + string.Format(this.PageName, pageList1_0.PageID - 1) + "\">{0}</a>", "<<上一页"));
				}
				int num = 1;
				if (pageList1_0.PageCount < 5)
				{
					for (int i = num; i <= pageList1_0.PageCount; i++)
					{
						if (i == pageList1_0.PageID)
						{
							stringBuilder.Append("<span class=\"cur\">" + i.ToString() + "</span>");
						}
						else
						{
							stringBuilder.Append(string.Concat(new string[]
							{
								"<a href=\"",
								string.Format(this.PageName, i),
								"\">",
								i.ToString(),
								"</a>"
							}));
						}
					}
				}
				else if (pageList1_0.PageID < 5)
				{
					int num2 = pageList1_0.PageID + 2;
					if (num2 > pageList1_0.PageCount - 1)
					{
						num2 = pageList1_0.PageCount - 1;
					}
					for (int i = num; i <= num2; i++)
					{
						if (i == pageList1_0.PageID)
						{
							stringBuilder.Append("<span class=\"cur\">" + i.ToString() + "</span>");
						}
						else
						{
							stringBuilder.Append(string.Concat(new string[]
							{
								"<a href=\"",
								string.Format(this.PageName, i),
								"\">",
								i.ToString(),
								"</a>"
							}));
						}
					}
					stringBuilder.Append("<span  class=\"diandian\">...</span>");
				}
				else
				{
					stringBuilder.Append("<span  class=\"diandian\">...</span>");
					if (pageList1_0.PageID > pageList1_0.PageCount)
					{
						pageList1_0.PageID = pageList1_0.PageCount;
					}
					if (pageList1_0.PageID + 3 > pageList1_0.PageCount)
					{
						for (int j = pageList1_0.PageID - 2; j <= pageList1_0.PageCount; j++)
						{
							if (j == pageList1_0.PageID)
							{
								stringBuilder.Append("<span class=\"cur\">" + j.ToString() + "</span>");
							}
							else
							{
								stringBuilder.Append(string.Concat(new string[]
								{
									"<a href=\"",
									string.Format(this.PageName, j),
									"\">",
									j.ToString(),
									"</a>"
								}));
							}
						}
					}
					else
					{
						for (int j = pageList1_0.PageID - 2; j <= pageList1_0.PageID + 2; j++)
						{
							if (j == pageList1_0.PageID)
							{
								stringBuilder.Append("<a class=\"cur\" href=\"javascript:void(0)\" >" + j.ToString() + "</a>");
							}
							else
							{
								stringBuilder.Append(string.Concat(new string[]
								{
									"<a href=\"",
									string.Format(this.PageName, j),
									"\">",
									j.ToString(),
									"</a>"
								}));
							}
						}
						stringBuilder.Append("<span  class=\"diandian\">...</span>");
					}
				}
				if (pageList1_0.PageID != pageList1_0.PageCount)
				{
					stringBuilder.Append(string.Format("<a class=\"gred_prev\" href=\"" + string.Format(this.PageName, pageList1_0.PageID + 1) + "\">{0}</a>", "下一页>>"));
					stringBuilder.Append(string.Format("<a href=\"" + string.Format(this.PageName, pageList1_0.PageCount) + "\">{0}</a>", ">>"));
				}
				stringBuilder.Append("到第<input type=\"text\" style=\"width:35px;\" onkeyup=\"NumTxt_Int(this)\" name=\"vjpage\" value=\"" + pageList1_0.PageID + "\">页<input class=\"quedbtn\" type=\"button\" value=\"确定\" name=\"surepage\">");
				result = stringBuilder.ToString();
			}
			return result;
		}
	}
}
