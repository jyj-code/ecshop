using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class BrandDetail : BaseWebControl
	{
		private string string_0 = "BrandDetail.ascx";
		private Repeater repeater_0;
		private HiddenField hiddenField_0;
		private Repeater repeater_1;
		private Repeater repeater_2;
		private HtmlGenericControl htmlGenericControl_0;
		private Label label_0;
		private TextBox textBox_0;
		private Button button_0;
		private HtmlGenericControl htmlGenericControl_1;
		private HtmlGenericControl htmlGenericControl_2;
		private TextBox textBox_1;
		private TextBox textBox_2;
		private LinkButton linkButton_0;
		private LinkButton linkButton_1;
		private LinkButton linkButton_2;
		private LinkButton linkButton_3;
		private LinkButton linkButton_4;
		private LinkButton linkButton_5;
		private LinkButton linkButton_6;
		private LinkButton linkButton_7;
		private LinkButton linkButton_8;
		private LinkButton linkButton_9;
		private LinkButton linkButton_10;
		private LinkButton linkButton_11;
		private LinkButton linkButton_12;
		private HtmlGenericControl htmlGenericControl_3;
		private HtmlGenericControl htmlGenericControl_4;
		private HtmlGenericControl htmlGenericControl_5;
		private HtmlGenericControl htmlGenericControl_6;
		private Label label_1;
		private HiddenField hiddenField_1;
		private HiddenField hiddenField_2;
		private TextBox textBox_3;
		private Button button_1;
		private string string_1 = GetPageName.RetDomainUrl("BrandDetail");
		private HtmlGenericControl htmlGenericControl_7;
		private ShopNum1_ProuductChecked_Action shopNum1_ProuductChecked_Action_0 = (ShopNum1_ProuductChecked_Action)LogicFactory.CreateShopNum1_ProuductChecked_Action();
		private string string_2;
		private string string_3;
		private int int_0;
		private string string_4;
		private string string_5;
		public string brandguid;
		public string Pvalue;
		public string style;
		private Dictionary<string, string> dictionary_0;
		public string addcode;
		public string string_6;
		[CompilerGenerated]
		private int int_1;
		[CompilerGenerated]
		private string string_7;
		[CompilerGenerated]
		private string string_8;
		[CompilerGenerated]
		private string string_9;
		public int ShowCount
		{
			get;
			set;
		}
		private string strStartPrice
		{
			get;
			set;
		}
		private string strEndPrice
		{
			get;
			set;
		}
		public string CityShowCount
		{
			get;
			set;
		}
		public BrandDetail()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.htmlGenericControl_7 = (HtmlGenericControl)skin.FindControl("hideProduct");
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.hiddenField_0 = (HiddenField)skin.FindControl("HiddenFieldGuid");
			this.repeater_1 = (Repeater)skin.FindControl("RepeaterGrid");
			this.repeater_2 = (Repeater)skin.FindControl("RepeaterProductShow");
			this.repeater_2.ItemDataBound += new RepeaterItemEventHandler(this.repeater_2_ItemDataBound);
			this.textBox_1 = (TextBox)skin.FindControl("TextBoxStartPrice");
			this.textBox_1.Text = this.strStartPrice;
			this.textBox_2 = (TextBox)skin.FindControl("TextBoxEndPrice");
			this.textBox_2.Text = this.strEndPrice;
			this.linkButton_0 = (LinkButton)skin.FindControl("LinkButtonSearch");
			this.linkButton_0.Click += new EventHandler(this.linkButton_0_Click);
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("pageDiv");
			this.label_0 = (Label)skin.FindControl("LabelPageCount");
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxIndex");
			this.button_0 = (Button)skin.FindControl("ButtonSure");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.htmlGenericControl_1 = (HtmlGenericControl)skin.FindControl("divGrid");
			this.htmlGenericControl_2 = (HtmlGenericControl)skin.FindControl("divList");
			this.linkButton_1 = (LinkButton)skin.FindControl("LinkButtonRenqi");
			this.linkButton_1.Click += new EventHandler(this.linkButton_1_Click);
			this.linkButton_2 = (LinkButton)skin.FindControl("LinkButtonSales");
			this.linkButton_2.Click += new EventHandler(this.linkButton_2_Click);
			this.linkButton_3 = (LinkButton)skin.FindControl("LinkButtonXinyong");
			this.linkButton_3.Click += new EventHandler(this.linkButton_3_Click);
			this.linkButton_4 = (LinkButton)skin.FindControl("LinkButtonPrice");
			this.linkButton_4.Click += new EventHandler(this.linkButton_4_Click);
			this.linkButton_5 = (LinkButton)skin.FindControl("LinkButtonGrid");
			this.linkButton_5.Click += new EventHandler(this.linkButton_5_Click);
			this.linkButton_6 = (LinkButton)skin.FindControl("LinkButtonList");
			this.linkButton_6.Click += new EventHandler(this.linkButton_6_Click);
			this.linkButton_7 = (LinkButton)skin.FindControl("LinkButtonPriceUp");
			this.linkButton_7.Click += new EventHandler(this.linkButton_7_Click);
			this.linkButton_8 = (LinkButton)skin.FindControl("LinkButtonPriceDown");
			this.linkButton_8.Click += new EventHandler(this.linkButton_8_Click);
			this.linkButton_9 = (LinkButton)skin.FindControl("LinkButtonSalesDown");
			this.linkButton_9.Click += new EventHandler(this.linkButton_9_Click);
			this.linkButton_10 = (LinkButton)skin.FindControl("LinkButtonCreateTime");
			this.linkButton_10.Click += new EventHandler(this.linkButton_10_Click);
			this.linkButton_11 = (LinkButton)skin.FindControl("LinkButtonDefault");
			this.linkButton_11.Click += new EventHandler(this.linkButton_11_Click);
			this.linkButton_12 = (LinkButton)skin.FindControl("LinkButtonSortStatus");
			this.label_1 = (Label)skin.FindControl("LabelAddress");
			this.hiddenField_1 = (HiddenField)skin.FindControl("HiddenFieldAddCode");
			this.hiddenField_2 = (HiddenField)skin.FindControl("HiddenFieldAdd");
			this.textBox_3 = (TextBox)skin.FindControl("TextBoxCity");
			this.button_1 = (Button)skin.FindControl("ButtonCity");
			this.button_1.Click += new EventHandler(this.button_1_Click);
			this.htmlGenericControl_3 = (HtmlGenericControl)skin.FindControl("IRenqi");
			this.htmlGenericControl_4 = (HtmlGenericControl)skin.FindControl("ISales");
			this.htmlGenericControl_5 = (HtmlGenericControl)skin.FindControl("IXinyong");
			this.htmlGenericControl_6 = (HtmlGenericControl)skin.FindControl("IPrice");
			this.strStartPrice = ShopNum1.Common.Common.ReqStr("minprice");
			this.strEndPrice = ShopNum1.Common.Common.ReqStr("maxprice");
			this.string_2 = ((ShopNum1.Common.Common.ReqStr("code") == "") ? "-1" : ShopNum1.Common.Common.ReqStr("code"));
			this.string_3 = ((ShopNum1.Common.Common.ReqStr("search") == "") ? "-1" : ShopNum1.Common.Common.ReqStr("search"));
			this.brandguid = ((ShopNum1.Common.Common.ReqStr("brandguid") == "") ? "-1" : ShopNum1.Common.Common.ReqStr("brandguid"));
			this.Pvalue = ((ShopNum1.Common.Common.ReqStr("Pvalue") == "") ? "-1" : ShopNum1.Common.Common.ReqStr("Pvalue"));
			this.style = ((ShopNum1.Common.Common.ReqStr("style") == null) ? "list" : ShopNum1.Common.Common.ReqStr("style"));
			this.string_5 = ((ShopNum1.Common.Common.ReqStr("ordername") == "") ? "orderid" : ShopNum1.Common.Common.ReqStr("ordername"));
			this.string_4 = ((ShopNum1.Common.Common.ReqStr("sort") == "desc") ? "desc" : "asc");
			this.addcode = ((ShopNum1.Common.Common.ReqStr("addcode") == "") ? "-1" : ShopNum1.Common.Common.ReqStr("addcode"));
			this.string_6 = ((ShopNum1.Common.Common.ReqStr("add") == "") ? "-1" : ShopNum1.Common.Common.ReqStr("add"));
			this.int_0 = 1;
			try
			{
				this.int_0 = int.Parse(ShopNum1.Common.Common.ReqStr("pageid"));
			}
			catch
			{
				this.int_0 = 1;
			}
			Func<string, bool> func = new Func<string, bool>(this.method_3);
			if (this.Pvalue != "-1")
			{
				func(this.Pvalue);
			}
			if (this.Page.IsPostBack)
			{
			}
			if (ShopNum1.Common.Common.ReqStr("guid") != "")
			{
				this.hiddenField_0.Value = ShopNum1.Common.Common.ReqStr("guid");
			}
			else
			{
				this.hiddenField_0.Value = "-1";
			}
			this.method_0();
			this.method_2(ShopNum1.Common.Common.ReqStr("ordername"), ShopNum1.Common.Common.ReqStr("sort"));
			if (string.IsNullOrEmpty(this.addcode) || this.addcode == "-1")
			{
				this.hiddenField_2.Value = this.string_6;
			}
			else
			{
				this.hiddenField_1.Value = this.addcode;
			}
		}
		private void method_0()
		{
			ShopNum1_Brand_Action shopNum1_Brand_Action = (ShopNum1_Brand_Action)LogicFactory.CreateShopNum1_Brand_Action();
			DataTable editInfo = shopNum1_Brand_Action.GetEditInfo("'" + this.brandguid + "'");
			if (editInfo.Rows.Count == 1)
			{
				this.method_1();
			}
			else
			{
				this.htmlGenericControl_7.Visible = false;
			}
			this.repeater_0.DataSource = editInfo.DefaultView;
			this.repeater_0.DataBind();
		}
		private void repeater_2_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				Repeater repeater = (Repeater)e.Item.FindControl("RepeaterShopEnsure");
				HiddenField hiddenField = (HiddenField)e.Item.FindControl("HiddenFieldMemLoginID");
				string shopid = hiddenField.Value.Trim().Replace("'", "");
				ShopNum1_Ensure_Action shopNum1_Ensure_Action = (ShopNum1_Ensure_Action)LogicFactory.CreateShopNum1_Ensure_Action();
				DataTable shopapplyEnsure = shopNum1_Ensure_Action.GetShopapplyEnsure(shopid);
				repeater.DataSource = shopapplyEnsure.DefaultView;
				repeater.DataBind();
			}
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			string text = this.textBox_3.Text.Trim().Replace("'", "");
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_1,
				"?search=",
				this.string_3,
				"&code=",
				this.string_2,
				"&brandguid=",
				this.brandguid,
				"&Pvalue=",
				this.Pvalue,
				"&sort=",
				this.string_4,
				"&ordername=",
				this.string_5,
				"&style=",
				this.style,
				"&minprice=",
				this.strStartPrice,
				"&maxprice=",
				this.strEndPrice,
				"&add=",
				text
			}));
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			string text = this.textBox_0.Text.Trim();
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_1,
				"?search=",
				this.string_3,
				"&code=",
				this.string_2,
				"&brandguid=",
				this.brandguid,
				"&Pvalue=",
				this.Pvalue,
				"&sort=",
				this.string_4,
				"&ordername=",
				this.string_5,
				"&style=",
				this.style,
				"&minprice=",
				this.strStartPrice,
				"&maxprice=",
				this.strEndPrice,
				"&addcode=",
				this.addcode,
				"&pageid=",
				text
			}));
		}
		private void linkButton_4_Click(object sender, EventArgs e)
		{
			if (this.string_5 == "shopprice")
			{
				this.string_4 = ((this.Page.Request.QueryString["sort"] == null) ? "" : this.Page.Request.QueryString["sort"]);
				if (this.string_4 == "desc" || this.string_4 == "")
				{
					this.string_4 = "asc";
				}
				else
				{
					this.string_4 = "desc";
				}
			}
			else
			{
				this.string_5 = "shopprice";
				this.string_4 = "desc";
			}
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_1,
				"?code=",
				this.string_2,
				"&brandguid=",
				this.brandguid,
				"&Pvalue=",
				this.Pvalue,
				"&sort=",
				this.string_4,
				"&ordername=",
				this.string_5,
				"&style=",
				this.style,
				"&minprice=",
				this.strStartPrice,
				"&maxprice=",
				this.strEndPrice,
				"&addcode=",
				this.addcode
			}));
		}
		private void linkButton_3_Click(object sender, EventArgs e)
		{
			if (this.string_5 == "shopreputation")
			{
				this.string_4 = ((this.Page.Request.QueryString["sort"] == null) ? "-1" : this.Page.Request.QueryString["sort"].ToString());
				if (this.string_4 == "asc" || this.string_4 == "-1")
				{
					this.string_4 = "desc";
				}
				else
				{
					this.string_4 = "asc";
				}
			}
			else
			{
				this.string_5 = "shopreputation";
				this.string_4 = "desc";
			}
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_1,
				"?code=",
				this.string_2,
				"&brandguid=",
				this.brandguid,
				"&Pvalue=",
				this.Pvalue,
				"&sort=",
				this.string_4,
				"&ordername=",
				this.string_5,
				"&style=",
				this.style,
				"&minprice=",
				this.strStartPrice,
				"&maxprice=",
				this.strEndPrice,
				"&addcode=",
				this.addcode
			}));
		}
		private void linkButton_2_Click(object sender, EventArgs e)
		{
			if (this.string_5 == "salenumber")
			{
				this.string_4 = ((this.Page.Request.QueryString["sort"] == null) ? "" : this.Page.Request.QueryString["sort"]);
				if (this.string_4 == "asc" || this.string_4 == "")
				{
					this.string_4 = "desc";
				}
				else
				{
					this.string_4 = "asc";
				}
			}
			else
			{
				this.string_5 = "salenumber";
				this.string_4 = "desc";
			}
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_1,
				"?code=",
				this.string_2,
				"&brandguid=",
				this.brandguid,
				"&Pvalue=",
				this.Pvalue,
				"&sort=",
				this.string_4,
				"&ordername=",
				this.string_5,
				"&style=",
				this.style,
				"&minprice=",
				this.strStartPrice,
				"&maxprice=",
				this.strEndPrice,
				"&addcode=",
				this.addcode
			}));
		}
		private void linkButton_1_Click(object sender, EventArgs e)
		{
			if (this.string_5 == "collectcount")
			{
				this.string_4 = ((this.Page.Request.QueryString["sort"] == null) ? "" : this.Page.Request.QueryString["sort"]);
				if (this.string_4 == "asc" || this.string_4 == "")
				{
					this.string_4 = "desc";
				}
				else
				{
					this.string_4 = "asc";
				}
			}
			else
			{
				this.string_5 = "collectcount";
				this.string_4 = "desc";
			}
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_1,
				"?code=",
				this.string_2,
				"&brandguid=",
				this.brandguid,
				"&Pvalue=",
				this.Pvalue,
				"&sort=",
				this.string_4,
				"&ordername=",
				this.string_5,
				"&style=",
				this.style,
				"&minprice=",
				this.strStartPrice,
				"&maxprice=",
				this.strEndPrice,
				"&addcode=",
				this.addcode
			}));
		}
		private void linkButton_6_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_1,
				"?code=",
				this.string_2,
				"&brandguid=",
				this.brandguid,
				"&Pvalue=",
				this.Pvalue,
				"&sort=",
				this.string_4,
				"&ordername=",
				this.string_5,
				"&style=list&minprice=",
				this.strStartPrice,
				"&maxprice=",
				this.strEndPrice,
				"&addcode=",
				this.addcode
			}));
		}
		private void linkButton_5_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_1,
				"?code=",
				this.string_2,
				"&brandguid=",
				this.brandguid,
				"&Pvalue=",
				this.Pvalue,
				"&sort=",
				this.string_4,
				"&ordername=",
				this.string_5,
				"&style=grid&minprice=",
				this.strStartPrice,
				"&maxprice=",
				this.strEndPrice,
				"&addcode=",
				this.addcode
			}));
		}
		private void linkButton_7_Click(object sender, EventArgs e)
		{
			this.string_5 = "shopprice";
			this.string_4 = "asc";
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_1,
				"?code=",
				this.string_2,
				"&brandguid=",
				this.brandguid,
				"&Pvalue=",
				this.Pvalue,
				"&sort=",
				this.string_4,
				"&ordername=",
				this.string_5,
				"&style=",
				this.style,
				"&minprice=",
				this.strStartPrice,
				"&maxprice=",
				this.strEndPrice,
				"&addcode=",
				this.addcode
			}));
		}
		private void linkButton_8_Click(object sender, EventArgs e)
		{
			this.string_5 = "shopprice";
			this.string_4 = "desc";
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_1,
				"?code=",
				this.string_2,
				"&brandguid=",
				this.brandguid,
				"&Pvalue=",
				this.Pvalue,
				"&sort=",
				this.string_4,
				"&ordername=",
				this.string_5,
				"&style=",
				this.style,
				"&minprice=",
				this.strStartPrice,
				"&maxprice=",
				this.strEndPrice,
				"&addcode=",
				this.addcode
			}));
		}
		private void linkButton_9_Click(object sender, EventArgs e)
		{
			this.string_5 = "salenumber";
			this.string_4 = "desc";
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_1,
				"?code=",
				this.string_2,
				"&brandguid=",
				this.brandguid,
				"&Pvalue=",
				this.Pvalue,
				"&sort=",
				this.string_4,
				"&ordername=",
				this.string_5,
				"&style=",
				this.style,
				"&minprice=",
				this.strStartPrice,
				"&maxprice=",
				this.strEndPrice,
				"&addcode=",
				this.addcode
			}));
		}
		private void linkButton_10_Click(object sender, EventArgs e)
		{
			this.string_5 = "createtime";
			this.string_4 = "desc";
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_1,
				"?code=",
				this.string_2,
				"&brandguid=",
				this.brandguid,
				"&Pvalue=",
				this.Pvalue,
				"&sort=",
				this.string_4,
				"&ordername=",
				this.string_5,
				"&style=",
				this.style,
				"&minprice=",
				this.strStartPrice,
				"&maxprice=",
				this.strEndPrice,
				"&addcode=",
				this.addcode
			}));
		}
		private void linkButton_11_Click(object sender, EventArgs e)
		{
			this.string_5 = "orderid";
			this.string_4 = "desc";
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_1,
				"?code=",
				this.string_2,
				"&brandguid=",
				this.brandguid,
				"&Pvalue=",
				this.Pvalue,
				"&sort=",
				this.string_4,
				"&ordername=",
				this.string_5,
				"&style=",
				this.style,
				"&minprice=",
				this.strStartPrice,
				"&maxprice=",
				this.strEndPrice,
				"&addcode=",
				this.addcode
			}));
		}
		private void linkButton_0_Click(object sender, EventArgs e)
		{
			this.strStartPrice = this.textBox_1.Text.Trim();
			this.strEndPrice = this.textBox_2.Text.Trim();
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_1,
				"?search=",
				this.string_3,
				"&code=",
				this.string_2,
				"&brandguid=",
				this.brandguid,
				"&Pvalue=",
				this.Pvalue,
				"&sort=",
				this.string_4,
				"&ordername=",
				this.string_5,
				"&style=",
				this.style,
				"&minprice=",
				this.strStartPrice,
				"&maxprice=",
				this.strEndPrice,
				"&addcode=",
				this.addcode
			}));
		}
		private void method_1()
		{
			PageList1 pageList = new PageList1();
			pageList.PageSize = this.ShowCount;
			pageList.PageID = this.int_0;
			DataSet furnitureProduct = this.shopNum1_ProuductChecked_Action_0.GetFurnitureProduct(this.addcode, this.string_6, this.string_2, this.string_5, this.string_4, this.strStartPrice, this.strEndPrice, this.string_3, this.brandguid, this.ShowCount.ToString(), this.int_0.ToString(), "1", this.dictionary_0);
			if (furnitureProduct != null && furnitureProduct.Tables[0].Rows.Count > 0)
			{
				pageList.RecordCount = Convert.ToInt32(furnitureProduct.Tables[0].Rows[0][0]);
			}
			else
			{
				pageList.RecordCount = 0;
			}
			PageListBll pageListBll = new PageListBll("BrandDetail", true);
			pageListBll.ShowRecordCount = true;
			pageListBll.ShowPageCount = false;
			pageListBll.ShowPageIndex = false;
			pageListBll.ShowRecordCount = false;
			pageListBll.ShowNoRecordInfo = false;
			pageListBll.ShowNumListButton = true;
			pageListBll.PrevPageText = "上一页";
			pageListBll.NextPageText = "下一页 ";
			this.htmlGenericControl_0.InnerHtml = pageListBll.GetPageListVk(pageList);
			this.label_0.Text = pageList.PageCount.ToString();
			if ((double)pageList.PageCount < (double)pageList.RecordCount / (double)pageList.PageSize)
			{
				pageList.PageCount++;
			}
			if (this.int_0 > pageList.PageCount)
			{
				this.int_0 = pageList.PageCount;
			}
			this.textBox_0.Text = this.int_0.ToString();
			DataSet furnitureProduct2 = this.shopNum1_ProuductChecked_Action_0.GetFurnitureProduct(this.addcode, this.string_6, this.string_2, this.string_5, this.string_4, this.strStartPrice, this.strEndPrice, this.string_3, this.brandguid, this.ShowCount.ToString(), this.int_0.ToString(), "0", this.dictionary_0);
			if (furnitureProduct2 != null && furnitureProduct2.Tables[0].Rows.Count > 0)
			{
				if (this.style == "list")
				{
					this.repeater_2.DataSource = furnitureProduct2.Tables[0];
					this.repeater_2.DataBind();
				}
				else
				{
					this.repeater_1.DataSource = furnitureProduct2.Tables[0];
					this.repeater_1.DataBind();
				}
			}
		}
		private void method_2(string string_10, string string_11)
		{
			if (this.style == "list")
			{
				this.htmlGenericControl_2.Style.Add("display", "block");
				this.htmlGenericControl_1.Style.Add("display", "none");
			}
			else
			{
				this.htmlGenericControl_2.Style.Add("display", "none");
				this.htmlGenericControl_1.Style.Add("display", "block");
			}
			string_10 = string_10.ToLower();
			if (this.string_4 == "desc")
			{
				if (string_10 == "shopprice")
				{
					this.linkButton_12.Text = "价格从高到低";
					this.linkButton_4.CssClass = "comSort selected";
					this.htmlGenericControl_6.Attributes.Add("class", "comSort-dSel");
				}
				if (string_10 == "salenumber")
				{
					this.linkButton_12.Text = "销量从高到低";
					this.linkButton_2.CssClass = "comSort selected";
					this.htmlGenericControl_4.Attributes.Add("class", "comSort-dSel");
				}
				if (string_10 == "createtime")
				{
					this.linkButton_12.Text = "按发布时间排序";
				}
				if (string_10 == "orderid")
				{
					this.linkButton_12.Text = "默认排序";
				}
				if (string_10 == "collectcount")
				{
					this.linkButton_12.Text = "人气从高到低";
					this.linkButton_1.CssClass = "comSort selected";
					this.htmlGenericControl_3.Attributes.Add("class", "comSort-dSel");
				}
				if (string_10 == "shopreputation")
				{
					this.linkButton_12.Text = "信用从高到低";
					this.linkButton_3.CssClass = "comSort selected";
					this.htmlGenericControl_5.Attributes.Add("class", "comSort-dSel");
				}
			}
			else
			{
				if (string_10 == "shopprice")
				{
					this.linkButton_12.Text = "价格从低到高";
					this.linkButton_4.CssClass = "comSort selected";
					this.htmlGenericControl_6.Attributes.Add("class", "comSort-uSel");
				}
				if (string_10 == "salenumber")
				{
					this.linkButton_12.Text = "销量从低到高";
					this.linkButton_2.CssClass = "comSort selected";
					this.htmlGenericControl_4.Attributes.Add("class", "comSort-uSel");
				}
				if (string_10 == "createtime")
				{
					this.linkButton_12.Text = "按发布时间排序";
				}
				if (string_10 == "orderid")
				{
					this.linkButton_12.Text = "默认排序";
				}
				if (string_10 == "collectcount")
				{
					this.linkButton_12.Text = "人气从低到高";
					this.linkButton_1.CssClass = "comSort selected";
					this.htmlGenericControl_3.Attributes.Add("class", "comSort-uSel");
				}
				if (string_10 == "shopreputation")
				{
					this.linkButton_12.Text = "信用从低到高";
					this.linkButton_3.CssClass = "comSort selected";
					this.htmlGenericControl_5.Attributes.Add("class", "comSort-uSel");
				}
			}
		}
		[CompilerGenerated]
		private bool method_3(string string_10)
		{
			string[] array = string_10.Split(new char[]
			{
				'-'
			});
			if (array.Length != 0)
			{
				this.dictionary_0 = new Dictionary<string, string>();
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					string text = array2[i];
					string[] array3 = text.Split(new char[]
					{
						'a'
					});
					if (array3.Length == 2)
					{
						this.dictionary_0.Add(array3[0], array3[1]);
					}
				}
			}
			return true;
		}
	}
}
