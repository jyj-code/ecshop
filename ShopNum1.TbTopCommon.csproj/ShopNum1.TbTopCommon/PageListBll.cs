using System;
using System.Text;
using System.Web;
namespace ShopNum1.TbTopCommon
{
	public class PageListBll
	{
		private string string_0 = "?PageID={0}";
		private string string_1 = "";
		private string string_2 = "<<";
		private string string_3 = "<";
		private string string_4 = ">";
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
		public PageListBll(string pageHref)
		{
			this.PageName = pageHref;
		}
		public string GetPageList(PageList pageList_0)
		{
			StringBuilder stringBuilder = new StringBuilder("");
			string result;
			if (pageList_0.RecordCount == 0)
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
						stringBuilder.Append("&nbsp;Record <b>0</b>");
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
				pageList_0.PageCount = pageList_0.RecordCount / pageList_0.PageSize;
				if ((double)pageList_0.PageCount < (double)pageList_0.RecordCount / (double)pageList_0.PageSize)
				{
					pageList_0.PageCount++;
				}
				stringBuilder.Append("<div class=\"PageInfo\" align=\"left\">\r");
				if (this.ShowPageIndex)
				{
					if (pageList_0.PageID == 0)
					{
						stringBuilder.Append("第<b>" + (pageList_0.PageID + 1).ToString() + "</b>页&nbsp;");
					}
					else
					{
						stringBuilder.Append("第<b>" + pageList_0.PageID.ToString() + "</b>页&nbsp;");
					}
				}
				if (this.ShowPageCount)
				{
					stringBuilder.Append("&nbsp;共<b>" + pageList_0.PageCount + "</b>页");
				}
				if (this.ShowRecordCount)
				{
					stringBuilder.Append("&nbsp;&nbsp;共<b>" + pageList_0.RecordCount.ToString() + "</b>条数据");
				}
				if (this.ShowPageListButton)
				{
					if (pageList_0.PageID == 1)
					{
						stringBuilder.Append(string.Format("&nbsp;&nbsp;&nbsp;&nbsp;{0}&nbsp;", this.FirstPageText));
					}
					else
					{
						stringBuilder.Append(string.Format("&nbsp;&nbsp;&nbsp;&nbsp;<a  onclick='PageClick(" + 1 + ")' href=\"javascript:void(0)\">{0}</a>&nbsp;", this.FirstPageText));
					}
					if (pageList_0.PageID == 1)
					{
						stringBuilder.Append(string.Format("&nbsp;{0}&nbsp;", this.PrevPageText));
					}
					else
					{
						stringBuilder.Append(string.Format("&nbsp;<a  onclick='PageClick(" + (pageList_0.PageID - 1).ToString() + ")' href=\"javascript:void(0)\">{0}</a>&nbsp;", this.PrevPageText));
					}
				}
				if (this.ShowNumListButton)
				{
					stringBuilder.Append("&nbsp;&nbsp;<span class=\"PageNumButton\"> ");
					int num = pageList_0.PageID - this.NumericButtonCount / 2;
					if (num < 1)
					{
						num = 1;
					}
					int num2 = num;
					while (num2 < num + this.NumericButtonCount && num2 <= pageList_0.PageCount)
					{
						if (num2 == pageList_0.PageID)
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
					if (pageList_0.PageID == pageList_0.PageCount)
					{
						stringBuilder.Append(string.Format("&nbsp;{0}&nbsp;", this.NextPageText));
					}
					else
					{
						stringBuilder.Append(string.Format("&nbsp;<a onclick='PageClick(" + (pageList_0.PageID + 1).ToString() + ")' href=\"javascript:void(0)\">{0}</a>&nbsp;", this.NextPageText));
					}
					if (pageList_0.PageID == pageList_0.PageCount)
					{
						stringBuilder.Append(string.Format("&nbsp;{0}", this.LastPageText));
					}
					else
					{
						stringBuilder.Append(string.Format("&nbsp;<a  onclick='PageClick(" + pageList_0.PageCount.ToString() + ")' href=\"javascript:void(0)\">{0}</a>", this.LastPageText));
					}
				}
				stringBuilder.Append("\r<input id=\"pageid\" name=\"pageid\" value=\"0\" type=\"hidden\" />");
				stringBuilder.Append("\r</div>");
				result = stringBuilder.ToString();
			}
			return result;
		}
	}
}
