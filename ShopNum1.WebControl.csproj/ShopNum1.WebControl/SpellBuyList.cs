using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class SpellBuyList : BaseWebControl
	{
		private string string_0 = "SpellBuyList.ascx";
		private string string_1 = "all";
		private Repeater repeater_0;
		private Repeater repeater_1;
		private HtmlGenericControl htmlGenericControl_0;
		private HtmlGenericControl htmlGenericControl_1;
		private LinkButton linkButton_0;
		private LinkButton linkButton_1;
		private LinkButton linkButton_2;
		private LinkButton linkButton_3;
		private HtmlGenericControl htmlGenericControl_2;
		private HtmlGenericControl htmlGenericControl_3;
		private HtmlGenericControl htmlGenericControl_4;
		private Label label_0;
		private Label label_1;
		public static int int_0 = 0;
		[CompilerGenerated]
		private int int_1;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		[CompilerGenerated]
		private string string_4;
		[CompilerGenerated]
		private string string_5;
		public int ShowCount
		{
			get;
			set;
		}
		public string ShowCategoryCount
		{
			get;
			set;
		}
		private string CategoryCode
		{
			get;
			set;
		}
		private string Sort
		{
			get;
			set;
		}
		private string SortType
		{
			get;
			set;
		}
		public SpellBuyList()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			if (this.Page.Request.QueryString["SubstationID"] != null && !string.IsNullOrEmpty(this.Page.Request.QueryString["SubstationID"].ToString()))
			{
				this.string_1 = this.Page.Request.QueryString["SubstationID"].ToString();
			}
			this.label_0 = (Label)skin.FindControl("LabelPageCount");
			this.label_1 = (Label)skin.FindControl("LabelPageCount1");
			this.CategoryCode = ((ShopNum1.Common.Common.ReqStr("Guid") == "") ? "-1" : ShopNum1.Common.Common.ReqStr("Guid"));
			this.Sort = ((this.Page.Request.QueryString["sort"] == null) ? "id" : this.Page.Request.QueryString["sort"].ToString());
			this.SortType = ((this.Page.Request.QueryString["sorttype"] == null) ? "desc" : this.Page.Request.QueryString["sorttype"].ToString());
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.repeater_1 = (Repeater)skin.FindControl("RepeaterCategory");
			this.linkButton_0 = (LinkButton)skin.FindControl("LinkButtonDefault");
			this.linkButton_0.Click += new EventHandler(this.linkButton_0_Click);
			this.linkButton_1 = (LinkButton)skin.FindControl("LinkButtonNew");
			this.linkButton_1.Click += new EventHandler(this.linkButton_1_Click);
			this.linkButton_2 = (LinkButton)skin.FindControl("LinkButtonSales");
			this.linkButton_2.Click += new EventHandler(this.linkButton_2_Click);
			this.linkButton_3 = (LinkButton)skin.FindControl("LinkButtonPrice");
			this.linkButton_3.Click += new EventHandler(this.linkButton_3_Click);
			this.htmlGenericControl_2 = (HtmlGenericControl)skin.FindControl("SpanNew");
			this.htmlGenericControl_3 = (HtmlGenericControl)skin.FindControl("SpanSales");
			this.htmlGenericControl_4 = (HtmlGenericControl)skin.FindControl("SpanPrice");
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("pageDiv");
			this.htmlGenericControl_1 = (HtmlGenericControl)skin.FindControl("pageDiv2");
			if (this.Sort == "groupprice")
			{
				this.linkButton_3.CssClass = "hover";
				this.linkButton_2.CssClass = "";
				this.linkButton_0.CssClass = "";
				this.linkButton_1.CssClass = "";
				if (ShopNum1.Common.Common.ReqStr("sorttype") == "desc")
				{
					this.htmlGenericControl_4.Attributes.Add("class", "new");
				}
				else
				{
					this.htmlGenericControl_4.Attributes.Add("class", "price");
				}
			}
			if (this.Sort == "groupcount")
			{
				this.linkButton_3.CssClass = "";
				this.linkButton_2.CssClass = "hover";
				this.linkButton_0.CssClass = "";
				this.linkButton_1.CssClass = "";
				if (ShopNum1.Common.Common.ReqStr("sorttype") == "desc")
				{
					this.htmlGenericControl_3.Attributes.Add("class", "price");
				}
				else
				{
					this.htmlGenericControl_3.Attributes.Add("class", "new");
				}
			}
			if (this.Sort == "createtime")
			{
				this.linkButton_3.CssClass = "";
				this.linkButton_2.CssClass = "";
				this.linkButton_0.CssClass = "";
				this.linkButton_1.CssClass = "hover";
				if (ShopNum1.Common.Common.ReqStr("sorttype") == "desc")
				{
					this.htmlGenericControl_2.Attributes.Add("class", "price");
				}
				else
				{
					this.htmlGenericControl_2.Attributes.Add("class", "new");
				}
			}
			if (this.Sort == "id" || this.Sort == string.Empty || this.Sort == null)
			{
				this.linkButton_3.CssClass = "";
				this.linkButton_2.CssClass = "";
				this.linkButton_0.CssClass = "hover";
				this.linkButton_1.CssClass = "";
			}
			this.SpellBuyCategoryDataBind();
			this.SpellBuyDataBind(this.Sort, this.SortType);
		}
		private void linkButton_3_Click(object sender, EventArgs e)
		{
			this.Sort = "groupprice";
			this.SortType = ((this.Page.Request.QueryString["sorttype"] == null) ? "" : this.Page.Request.QueryString["sorttype"]);
			if (this.SortType == "desc" || this.SortType == "")
			{
				this.SortType = "asc";
			}
			else
			{
				this.SortType = "desc";
			}
			string text = GetPageName.RetDomainUrl("SpellBuyList");
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				text,
				"?Guid=",
				this.CategoryCode,
				"&sort=",
				this.Sort,
				"&sorttype=",
				this.SortType
			}));
		}
		private void linkButton_2_Click(object sender, EventArgs e)
		{
			this.Sort = "groupcount";
			this.SortType = ((this.Page.Request.QueryString["sorttype"] == null) ? "" : this.Page.Request.QueryString["sorttype"]);
			if (this.SortType == "asc" || this.SortType == "")
			{
				this.SortType = "desc";
			}
			else
			{
				this.SortType = "asc";
			}
			string text = GetPageName.RetDomainUrl("SpellBuyList");
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				text,
				"?Guid=",
				this.CategoryCode,
				"&sort=",
				this.Sort,
				"&sorttype=",
				this.SortType
			}));
		}
		private void linkButton_1_Click(object sender, EventArgs e)
		{
			this.Sort = "createtime";
			this.SortType = ((this.Page.Request.QueryString["sorttype"] == null) ? "" : this.Page.Request.QueryString["sorttype"]);
			if (this.SortType == "asc" || this.SortType == "")
			{
				this.SortType = "desc";
			}
			else
			{
				this.SortType = "asc";
			}
			string text = GetPageName.RetDomainUrl("SpellBuyList");
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				text,
				"?Guid=",
				this.CategoryCode,
				"&sort=",
				this.Sort,
				"&sorttype=",
				this.SortType
			}));
		}
		private void linkButton_0_Click(object sender, EventArgs e)
		{
			this.Sort = "id";
			string text = GetPageName.RetDomainUrl("SpellBuyList");
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				text,
				"?Guid=",
				this.CategoryCode,
				"&sort=",
				this.Sort,
				"&sorttype=",
				this.SortType
			}));
		}
		protected void SpellBuyCategoryDataBind()
		{
			try
			{
				int.Parse(this.ShowCategoryCount);
			}
			catch
			{
				this.ShowCategoryCount = "8";
			}
			ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
			DataTable productCategory = shopNum1_ProductCategory_Action.GetProductCategory("0", this.ShowCategoryCount);
			if (productCategory != null && productCategory.Rows.Count > 0)
			{
				this.repeater_1.DataSource = productCategory.DefaultView;
				this.repeater_1.DataBind();
			}
		}
		protected void SpellBuyDataBind(string strSortColumn, string strSortV)
		{
			ShopNum1_GroupProduct_Action shopNum1_GroupProduct_Action = (ShopNum1_GroupProduct_Action)LogicFactory.CreateShopNum1_GroupProduct_Action();
			int num = 1;
			if (ShopNum1.Common.Common.ReqStr("pageid") != "")
			{
				num = Convert.ToInt32(ShopNum1.Common.Common.ReqStr("pageid"));
			}
			PageList1 pageList = new PageList1();
			pageList.PageSize = this.ShowCount;
			pageList.PageID = num;
			string text = "  and State=1 ";
			if (this.CategoryCode != "-1" && this.CategoryCode != "")
			{
				text = text + " and productcategorycode like '" + this.CategoryCode + "%'";
			}
			if (this.string_1 != "all")
			{
				text = text + " and   SubstationID='" + this.string_1 + "'   ";
			}
			DataTable dataTable = shopNum1_GroupProduct_Action.SelectGroupList(this.ShowCount.ToString(), num.ToString(), text, "3", strSortColumn, strSortV);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				pageList.RecordCount = Convert.ToInt32(dataTable.Rows[0][0]);
			}
			else
			{
				pageList.RecordCount = 0;
			}
			PageListBll pageListBll = new PageListBll("SpellBuyList", true);
			pageListBll.ShowRecordCount = true;
			pageListBll.ShowPageCount = false;
			pageListBll.ShowPageIndex = false;
			pageListBll.ShowRecordCount = false;
			pageListBll.ShowNoRecordInfo = false;
			pageListBll.ShowNumListButton = true;
			pageListBll.PrevPageText = "上一页";
			pageListBll.NextPageText = "下一页 ";
			if (pageList.RecordCount < pageList.PageSize)
			{
				this.label_0.Text = (this.label_1.Text = "1");
			}
			else
			{
				this.label_0.Text = (this.label_1.Text = (pageList.RecordCount / pageList.PageSize).ToString());
			}
			if ((double)pageList.PageCount < (double)pageList.RecordCount / (double)pageList.PageSize)
			{
				pageList.PageCount++;
			}
			if (num > pageList.PageCount)
			{
				num = pageList.PageCount;
			}
			this.htmlGenericControl_0.InnerHtml = pageListBll.GetPageListVk(pageList);
			this.htmlGenericControl_1.InnerHtml = pageListBll.GetPageListVk(pageList);
			if (this.label_0.Text == "1")
			{
				this.htmlGenericControl_0.Visible = false;
				this.htmlGenericControl_1.Visible = false;
			}
			DataTable dataTable2 = shopNum1_GroupProduct_Action.SelectGroupList(this.ShowCount.ToString(), num.ToString(), text, "2", strSortColumn, strSortV);
			if (dataTable2 != null && dataTable2.Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataTable2.DefaultView;
				this.repeater_0.DataBind();
			}
		}
		public static string IsBegin(object begin, object object_0)
		{
			string result;
			if (DateTime.Parse(begin.ToString()) > DateTime.Now.ToLocalTime())
			{
				result = begin.ToString();
			}
			else
			{
				result = object_0.ToString();
			}
			return result;
		}
	}
}
