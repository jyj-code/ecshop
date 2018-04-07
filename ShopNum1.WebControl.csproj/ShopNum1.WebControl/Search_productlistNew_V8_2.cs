using ShopNum1.BusinessLogic;
using ShopNum1.CityFactory;
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
	public class Search_productlistNew_V8_2 : BaseWebControl
	{
		private string string_0 = "Search_productlistNew_V8_2.ascx";
		private Repeater repeater_0;
		private Repeater repeater_1;
		private HtmlGenericControl htmlGenericControl_0;
		private Label label_0;
		private TextBox textBox_0;
		private Button button_0;
		private HtmlGenericControl htmlGenericControl_1;
		private HtmlGenericControl htmlGenericControl_2;
		private Panel panel_0;
		private TextBox textBox_1;
		private TextBox textBox_2;
		private LinkButton linkButton_0;
		private Button button_1;
		private TextBox textBox_3;
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
		private LinkButton linkButton_13;
		private LinkButton linkButton_14;
		private LinkButton linkButton_15;
		private LinkButton linkButton_16;
		private LinkButton linkButton_17;
		private LinkButton linkButton_18;
		private LinkButton linkButton_19;
		private HtmlGenericControl htmlGenericControl_3;
		private HtmlGenericControl htmlGenericControl_4;
		private HtmlGenericControl htmlGenericControl_5;
		private HtmlGenericControl htmlGenericControl_6;
		private Label label_1;
		private HiddenField hiddenField_0;
		private HiddenField hiddenField_1;
		private string string_1 = "all";
		private TextBox textBox_4;
		private Button button_2;
		private string string_2 = GetPageName.RetDomainUrl("Search_productlist");
		private ShopNum1_ProuductChecked_Action shopNum1_ProuductChecked_Action_0 = (ShopNum1_ProuductChecked_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ProuductChecked_Action();
		private string string_3;
		private string string_4;
		private int int_0;
		private string string_5;
		private string string_6;
		public string brandguid;
		public string Pvalue;
		public string style;
		private Dictionary<string, string> dictionary_0;
		public string addcode;
		public string string_7;
		private string string_8;
		[CompilerGenerated]
		private int int_1;
		[CompilerGenerated]
		private string string_9;
		[CompilerGenerated]
		private string string_10;
		[CompilerGenerated]
		private string string_11;
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
		public Search_productlistNew_V8_2()
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
				ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)ShopNum1.CityFactory.LogicFactory.CreateShopNum1_SubstationManage_Action();
				string domainNameBySubstationID = shopNum1_SubstationManage_Action.GetDomainNameBySubstationID(this.string_1);
				this.string_2 = string.Concat(new string[]
				{
					"http://",
					domainNameBySubstationID,
					ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf('.')),
					"/Search_productlist",
					Search_productlistNew_V8_2.GetOverrideUrlName()
				});
			}
			this.strStartPrice = ShopNum1.Common.Common.ReqStr("minprice");
			this.strEndPrice = ShopNum1.Common.Common.ReqStr("maxprice");
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterGrid");
			this.repeater_1 = (Repeater)skin.FindControl("RepeaterProductShow");
			this.repeater_1.ItemDataBound += new RepeaterItemEventHandler(this.repeater_1_ItemDataBound);
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
			this.linkButton_19 = (LinkButton)skin.FindControl("LinkButtonAll");
			this.linkButton_19.Click += new EventHandler(this.linkButton_19_Click);
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
			this.linkButton_13 = (LinkButton)skin.FindControl("LinkButtonNoSale");
			this.linkButton_14 = (LinkButton)skin.FindControl("LinkButtonTG");
			this.linkButton_14.Click += new EventHandler(this.linkButton_14_Click);
			this.linkButton_15 = (LinkButton)skin.FindControl("LinkButtonZK");
			this.linkButton_15.Click += new EventHandler(this.linkButton_15_Click);
			this.linkButton_16 = (LinkButton)skin.FindControl("LinkButtonQG");
			this.linkButton_16.Click += new EventHandler(this.linkButton_16_Click);
			this.linkButton_17 = (LinkButton)skin.FindControl("LinkButtonZH");
			this.linkButton_17.Click += new EventHandler(this.linkButton_17_Click);
			this.linkButton_18 = (LinkButton)skin.FindControl("LinkButtonNoLimit");
			this.linkButton_18.Click += new EventHandler(this.linkButton_18_Click);
			this.label_1 = (Label)skin.FindControl("LabelAddress");
			this.hiddenField_0 = (HiddenField)skin.FindControl("HiddenFieldAddCode");
			this.hiddenField_1 = (HiddenField)skin.FindControl("HiddenFieldAdd");
			this.button_1 = (Button)skin.FindControl("ButtonAgainSearch");
			this.button_1.Click += new EventHandler(this.button_1_Click);
			this.textBox_3 = (TextBox)skin.FindControl("TextBoxSearch");
			this.textBox_4 = (TextBox)skin.FindControl("TextBoxCity");
			this.button_2 = (Button)skin.FindControl("ButtonCity");
			this.button_2.Click += new EventHandler(this.button_2_Click);
			this.htmlGenericControl_3 = (HtmlGenericControl)skin.FindControl("IRenqi");
			this.htmlGenericControl_4 = (HtmlGenericControl)skin.FindControl("ISales");
			this.htmlGenericControl_5 = (HtmlGenericControl)skin.FindControl("IXinyong");
			this.htmlGenericControl_6 = (HtmlGenericControl)skin.FindControl("IPrice");
			this.panel_0 = (Panel)skin.FindControl("PanelNoFind");
			this.string_3 = ((ShopNum1.Common.Common.ReqStr("code") == "") ? "-1" : ShopNum1.Common.Common.ReqStr("code"));
			this.string_4 = ((ShopNum1.Common.Common.ReqStr("search") == "") ? "-1" : ShopNum1.Common.Common.ReqStr("search").Replace("%2f", "/"));
			this.brandguid = ((ShopNum1.Common.Common.ReqStr("brandguid") == "") ? "-1" : ShopNum1.Common.Common.ReqStr("brandguid"));
			this.Pvalue = ((ShopNum1.Common.Common.ReqStr("Pvalue") == "") ? "-1" : ShopNum1.Common.Common.ReqStr("Pvalue"));
			this.style = ((ShopNum1.Common.Common.ReqStr("style") == "") ? "grid" : ShopNum1.Common.Common.ReqStr("style"));
			this.string_6 = ((ShopNum1.Common.Common.ReqStr("ordername") == "") ? "salenumber" : ShopNum1.Common.Common.ReqStr("ordername"));
			this.string_5 = ((ShopNum1.Common.Common.ReqStr("sort") == "" || ShopNum1.Common.Common.ReqStr("sort") == "desc") ? "desc" : "asc");
			this.addcode = ((ShopNum1.Common.Common.ReqStr("addcode") == "") ? "-1" : ShopNum1.Common.Common.ReqStr("addcode"));
			this.string_7 = ((ShopNum1.Common.Common.ReqStr("add") == "") ? "-1" : ShopNum1.Common.Common.ReqStr("add"));
			this.int_0 = 1;
			try
			{
				this.int_0 = int.Parse(ShopNum1.Common.Common.ReqStr("PageID"));
			}
			catch
			{
				this.int_0 = 1;
			}
			Func<string, bool> func = new Func<string, bool>(this.method_2);
			if (this.Pvalue != "-1")
			{
				func(this.Pvalue);
			}
			this.string_8 = ShopNum1.Common.Common.ReqStr("sale");
			if (!this.Page.IsPostBack)
			{
				this.method_1();
				if (string.IsNullOrEmpty(this.addcode) || this.addcode == "-1")
				{
					this.hiddenField_1.Value = this.string_7;
				}
				else
				{
					this.hiddenField_0.Value = this.addcode;
				}
			}
			this.method_0(ShopNum1.Common.Common.ReqStr("ordername"), this.string_5);
		}
		private void linkButton_19_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_2,
				"?search=",
				this.string_4,
				"&code=",
				this.string_3,
				"&brandguid=",
				this.brandguid,
				"&Pvalue=",
				this.Pvalue,
				"&sort=desc&ordername=",
				this.string_6,
				"&style=grid&minprice=",
				this.strStartPrice,
				"&maxprice=",
				this.strEndPrice,
				"&addcode=",
				this.addcode
			}));
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
		private void linkButton_14_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_2,
				"?search=",
				this.string_4,
				"&code=",
				this.string_3,
				"&brandguid=",
				this.brandguid,
				"&Pvalue=",
				this.Pvalue,
				"&sort=asc&ordername=",
				this.string_6,
				"&style=grid&minprice=",
				this.strStartPrice,
				"&maxprice=",
				this.strEndPrice,
				"&addcode=",
				this.addcode,
				"&sale=1"
			}));
		}
		private void linkButton_15_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_2,
				"?search=",
				this.string_4,
				"&code=",
				this.string_3,
				"&brandguid=",
				this.brandguid,
				"&Pvalue=",
				this.Pvalue,
				"&sort=asc&ordername=",
				this.string_6,
				"&style=grid&minprice=",
				this.strStartPrice,
				"&maxprice=",
				this.strEndPrice,
				"&addcode=",
				this.addcode,
				"&sale=2"
			}));
		}
		private void linkButton_16_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_2,
				"?search=",
				this.string_4,
				"&code=",
				this.string_3,
				"&brandguid=",
				this.brandguid,
				"&Pvalue=",
				this.Pvalue,
				"&sort=asc&ordername=",
				this.string_6,
				"&style=grid&minprice=",
				this.strStartPrice,
				"&maxprice=",
				this.strEndPrice,
				"&addcode=",
				this.addcode,
				"&sale=3"
			}));
		}
		private void linkButton_17_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_2,
				"?search=",
				this.string_4,
				"&code=",
				this.string_3,
				"&brandguid=",
				this.brandguid,
				"&Pvalue=",
				this.Pvalue,
				"&sort=asc&ordername=",
				this.string_6,
				"&style=grid&minprice=",
				this.strStartPrice,
				"&maxprice=",
				this.strEndPrice,
				"&addcode=",
				this.addcode,
				"&sale=4"
			}));
		}
		private void linkButton_18_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_2,
				"?search=",
				this.string_4,
				"&code=",
				this.string_3,
				"&brandguid=",
				this.brandguid,
				"&Pvalue=",
				this.Pvalue,
				"&sort=asc&ordername=",
				this.string_6,
				"&style=grid&minprice=",
				this.strStartPrice,
				"&maxprice=",
				this.strEndPrice,
				"&addcode=",
				this.addcode
			}));
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			string text = this.textBox_0.Text.Trim();
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_2,
				"?search=",
				this.string_4,
				"&code=",
				this.string_3,
				"&brandguid=",
				this.brandguid,
				"&Pvalue=",
				this.Pvalue,
				"&sort=",
				this.string_5,
				"&ordername=",
				this.string_6,
				"&style=",
				this.style,
				"&minprice=",
				this.strStartPrice,
				"&maxprice=",
				this.strEndPrice,
				"&addcode=",
				this.addcode,
				"&pageid=",
				text,
				"&sale=",
				this.string_8
			}));
		}
		private void repeater_1_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				Repeater repeater = (Repeater)e.Item.FindControl("RepeaterShopEnsure");
				HiddenField hiddenField = (HiddenField)e.Item.FindControl("HiddenFieldMemLoginID");
				string shopid = hiddenField.Value.Trim().Replace("'", "");
				ShopNum1_Ensure_Action shopNum1_Ensure_Action = (ShopNum1_Ensure_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Ensure_Action();
				DataTable shopapplyEnsure = shopNum1_Ensure_Action.GetShopapplyEnsure(shopid);
				repeater.DataSource = shopapplyEnsure.DefaultView;
				repeater.DataBind();
			}
		}
		private void button_2_Click(object sender, EventArgs e)
		{
			string text = this.textBox_4.Text.Trim().Replace("'", "");
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_2,
				"?search=",
				this.string_4,
				"&code=",
				this.string_3,
				"&brandguid=",
				this.brandguid,
				"&Pvalue=",
				this.Pvalue,
				"&sort=",
				this.string_5,
				"&ordername=",
				this.string_6,
				"&style=",
				this.style,
				"&minprice=",
				this.strStartPrice,
				"&maxprice=",
				this.strEndPrice,
				"&add=",
				text,
				"&sale=",
				this.string_8
			}));
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			this.string_4 = ((this.textBox_3.Text.Trim().Replace("'", "") == string.Empty) ? "-1" : this.textBox_3.Text.Trim().Replace("'", ""));
			string url = GetPageName.AgentRetUrl("Search_productlist", this.string_4, "search");
			this.Page.Response.Redirect(url);
		}
		private void linkButton_4_Click(object sender, EventArgs e)
		{
			if (this.string_6 == "shopprice")
			{
				this.string_5 = ((this.Page.Request.QueryString["sort"] == null) ? "" : this.Page.Request.QueryString["sort"]);
				if (this.string_5 == "desc")
				{
					this.string_5 = "asc";
				}
				else
				{
					this.string_5 = "desc";
				}
			}
			else
			{
				this.string_6 = "shopprice";
				this.string_5 = "desc";
			}
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_2,
				"?search=",
				this.string_4,
				"&code=",
				this.string_3,
				"&brandguid=",
				this.brandguid,
				"&Pvalue=",
				this.Pvalue,
				"&sort=",
				this.string_5,
				"&ordername=",
				this.string_6,
				"&style=",
				this.style,
				"&minprice=",
				this.strStartPrice,
				"&maxprice=",
				this.strEndPrice,
				"&addcode=",
				this.addcode,
				"&sale=",
				this.string_8
			}));
		}
		private void linkButton_3_Click(object sender, EventArgs e)
		{
			if (this.string_6 == "shopreputation")
			{
				this.string_5 = ((this.Page.Request.QueryString["sort"] == null) ? "-1" : this.Page.Request.QueryString["sort"].ToString());
				if (this.string_5 == "asc" || this.string_5 == "-1")
				{
					this.string_5 = "desc";
				}
				else
				{
					this.string_5 = "asc";
				}
			}
			else
			{
				this.string_6 = "shopreputation";
				this.string_5 = "desc";
			}
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_2,
				"?search=",
				this.string_4,
				"&code=",
				this.string_3,
				"&brandguid=",
				this.brandguid,
				"&Pvalue=",
				this.Pvalue,
				"&sort=",
				this.string_5,
				"&ordername=",
				this.string_6,
				"&style=",
				this.style,
				"&minprice=",
				this.strStartPrice,
				"&maxprice=",
				this.strEndPrice,
				"&addcode=",
				this.addcode,
				"&sale=",
				this.string_8
			}));
		}
		private void linkButton_2_Click(object sender, EventArgs e)
		{
			if (this.string_6 == "salenumber")
			{
				this.string_5 = ((this.Page.Request.QueryString["sort"] == null) ? "" : this.Page.Request.QueryString["sort"]);
				if (this.string_5 == "asc" || this.string_5 == "")
				{
					this.string_5 = "desc";
				}
				else
				{
					this.string_5 = "asc";
				}
			}
			else
			{
				this.string_6 = "salenumber";
				this.string_5 = "desc";
			}
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_2,
				"?search=",
				this.string_4,
				"&code=",
				this.string_3,
				"&brandguid=",
				this.brandguid,
				"&Pvalue=",
				this.Pvalue,
				"&sort=",
				this.string_5,
				"&ordername=",
				this.string_6,
				"&style=",
				this.style,
				"&minprice=",
				this.strStartPrice,
				"&maxprice=",
				this.strEndPrice,
				"&addcode=",
				this.addcode,
				"&sale=",
				this.string_8
			}));
		}
		private void linkButton_1_Click(object sender, EventArgs e)
		{
			if (this.string_6 == "collectcount")
			{
				this.string_5 = ((this.Page.Request.QueryString["sort"] == null) ? "" : this.Page.Request.QueryString["sort"]);
				if (this.string_5 == "asc" || this.string_5 == "")
				{
					this.string_5 = "desc";
				}
				else
				{
					this.string_5 = "asc";
				}
			}
			else
			{
				this.string_6 = "collectcount";
				this.string_5 = "desc";
			}
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_2,
				"?search=",
				this.string_4,
				"&code=",
				this.string_3,
				"&brandguid=",
				this.brandguid,
				"&Pvalue=",
				this.Pvalue,
				"&sort=",
				this.string_5,
				"&ordername=",
				this.string_6,
				"&style=",
				this.style,
				"&minprice=",
				this.strStartPrice,
				"&maxprice=",
				this.strEndPrice,
				"&addcode=",
				this.addcode,
				"&sale=",
				this.string_8
			}));
		}
		private void linkButton_6_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_2,
				"?search=",
				this.string_4,
				"&code=",
				this.string_3,
				"&brandguid=",
				this.brandguid,
				"&Pvalue=",
				this.Pvalue,
				"&sort=asc&ordername=",
				this.string_6,
				"&style=list&minprice=",
				this.strStartPrice,
				"&maxprice=",
				this.strEndPrice,
				"&addcode=",
				this.addcode,
				"&sale=",
				this.string_8
			}));
		}
		private void linkButton_5_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_2,
				"?search=",
				this.string_4,
				"&code=",
				this.string_3,
				"&brandguid=",
				this.brandguid,
				"&Pvalue=",
				this.Pvalue,
				"&sort=asc&ordername=",
				this.string_6,
				"&style=grid&minprice=",
				this.strStartPrice,
				"&maxprice=",
				this.strEndPrice,
				"&addcode=",
				this.addcode,
				"&sale=",
				this.string_8
			}));
		}
		private void linkButton_7_Click(object sender, EventArgs e)
		{
			this.string_6 = "shopprice";
			this.string_5 = "asc";
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_2,
				"?search=",
				this.string_4,
				"&code=",
				this.string_3,
				"&brandguid=",
				this.brandguid,
				"&Pvalue=",
				this.Pvalue,
				"&sort=",
				this.string_5,
				"&ordername=",
				this.string_6,
				"&style=",
				this.style,
				"&minprice=",
				this.strStartPrice,
				"&maxprice=",
				this.strEndPrice,
				"&addcode=",
				this.addcode,
				"&sale=",
				this.string_8
			}));
		}
		private void linkButton_8_Click(object sender, EventArgs e)
		{
			this.string_6 = "shopprice";
			this.string_5 = "desc";
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_2,
				"?search=",
				this.string_4,
				"&code=",
				this.string_3,
				"&brandguid=",
				this.brandguid,
				"&Pvalue=",
				this.Pvalue,
				"&sort=",
				this.string_5,
				"&ordername=",
				this.string_6,
				"&style=",
				this.style,
				"&minprice=",
				this.strStartPrice,
				"&maxprice=",
				this.strEndPrice,
				"&addcode=",
				this.addcode,
				"&sale=",
				this.string_8
			}));
		}
		private void linkButton_9_Click(object sender, EventArgs e)
		{
			this.string_6 = "salenumber";
			this.string_5 = "desc";
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_2,
				"?search=",
				this.string_4,
				"&code=",
				this.string_3,
				"&brandguid=",
				this.brandguid,
				"&Pvalue=",
				this.Pvalue,
				"&sort=",
				this.string_5,
				"&ordername=",
				this.string_6,
				"&style=",
				this.style,
				"&minprice=",
				this.strStartPrice,
				"&maxprice=",
				this.strEndPrice,
				"&addcode=",
				this.addcode,
				"&sale=",
				this.string_8
			}));
		}
		private void linkButton_10_Click(object sender, EventArgs e)
		{
			this.string_6 = "createtime";
			this.string_5 = "desc";
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_2,
				"?search=",
				this.string_4,
				"&code=",
				this.string_3,
				"&brandguid=",
				this.brandguid,
				"&Pvalue=",
				this.Pvalue,
				"&sort=",
				this.string_5,
				"&ordername=",
				this.string_6,
				"&style=",
				this.style,
				"&minprice=",
				this.strStartPrice,
				"&maxprice=",
				this.strEndPrice,
				"&addcode=",
				this.addcode,
				"&sale=",
				this.string_8
			}));
		}
		private void linkButton_11_Click(object sender, EventArgs e)
		{
			this.string_6 = "orderid";
			this.string_5 = "desc";
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_2,
				"?search=",
				this.string_4,
				"&code=",
				this.string_3,
				"&brandguid=",
				this.brandguid,
				"&Pvalue=",
				this.Pvalue,
				"&sort=",
				this.string_5,
				"&ordername=",
				this.string_6,
				"&style=",
				this.style,
				"&minprice=",
				this.strStartPrice,
				"&maxprice=",
				this.strEndPrice,
				"&addcode=",
				this.addcode,
				"&sale=",
				this.string_8
			}));
		}
		private void linkButton_0_Click(object sender, EventArgs e)
		{
			this.strStartPrice = this.textBox_1.Text.Trim();
			this.strEndPrice = this.textBox_2.Text.Trim();
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_2,
				"?search=",
				this.string_4,
				"&code=",
				this.string_3,
				"&brandguid=",
				this.brandguid,
				"&Pvalue=",
				this.Pvalue,
				"&sort=",
				this.string_5,
				"&ordername=",
				this.string_6,
				"&style=",
				this.style,
				"&minprice=",
				this.strStartPrice,
				"&maxprice=",
				this.strEndPrice,
				"&addcode=",
				this.addcode,
				"&sale=",
				this.string_8
			}));
		}
		private void method_0(string string_12, string string_13)
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
			string_12 = string_12.ToLower();
			if (this.string_5 == "desc")
			{
				if (string_12 == "shopprice")
				{
					this.linkButton_12.Text = "价格从高到低";
					this.linkButton_4.CssClass = "comSort comSort1 selected";
					this.htmlGenericControl_6.Attributes.Add("class", "comSort-dSel");
				}
				if (string_12 == "salenumber")
				{
					this.linkButton_12.Text = "销量从高到低";
					this.linkButton_2.CssClass = "comSort comSort1 selected";
					this.htmlGenericControl_4.Attributes.Add("class", "comSort-dSel");
				}
				if (string_12 == "createtime")
				{
					this.linkButton_12.Text = "按发布时间排序";
				}
				if (string_12 == "orderid")
				{
					this.linkButton_12.Text = "默认排序";
				}
				if (string_12 == "collectcount")
				{
					this.linkButton_12.Text = "人气从高到低";
					this.linkButton_1.CssClass = "comSort comSort1 selected";
					this.htmlGenericControl_3.Attributes.Add("class", "comSort-dSel");
				}
				if (string_12 == "shopreputation")
				{
					this.linkButton_12.Text = "信用从高到低";
					this.linkButton_3.CssClass = "comSort comSort1 selected";
					this.htmlGenericControl_5.Attributes.Add("class", "comSort-dSel");
				}
			}
			else
			{
				if (string_12 == "shopprice")
				{
					this.linkButton_12.Text = "价格从低到高";
					this.linkButton_4.CssClass = "comSort comSort1 selected";
					this.htmlGenericControl_6.Attributes.Add("class", "comSort-uSel");
				}
				if (string_12 == "salenumber")
				{
					this.linkButton_12.Text = "销量从低到高";
					this.linkButton_2.CssClass = "comSort comSort1 selected";
					this.htmlGenericControl_4.Attributes.Add("class", "comSort-uSel");
				}
				if (string_12 == "createtime")
				{
					this.linkButton_12.Text = "按发布时间排序";
				}
				if (string_12 == "orderid")
				{
					this.linkButton_12.Text = "默认排序";
				}
				if (string_12 == "collectcount")
				{
					this.linkButton_12.Text = "人气从低到高";
					this.linkButton_1.CssClass = "comSort comSort1 selected";
					this.htmlGenericControl_3.Attributes.Add("class", "comSort-uSel");
				}
				if (string_12 == "shopreputation")
				{
					this.linkButton_12.Text = "信用从低到高";
					this.linkButton_3.CssClass = "comSort comSort1 selected";
					this.htmlGenericControl_5.Attributes.Add("class", "comSort-uSel");
				}
			}
			string text = this.string_8;
			if (text != null)
			{
				if (!(text == "1"))
				{
					if (!(text == "2"))
					{
						if (!(text == "3"))
						{
							if (text == "4")
							{
								this.linkButton_13.Text = "组合套餐";
								this.linkButton_13.CssClass = "selected";
							}
						}
						else
						{
							this.linkButton_13.Text = "抢购活动";
							this.linkButton_13.CssClass = "selected";
						}
					}
					else
					{
						this.linkButton_13.Text = "限时折扣";
						this.linkButton_13.CssClass = "selected";
					}
				}
				else
				{
					this.linkButton_13.Text = "团购活动";
					this.linkButton_13.CssClass = "selected";
				}
			}
		}
		private void method_1()
		{
			try
			{
				this.int_0 = Convert.ToInt32(this.int_0);
			}
			catch
			{
				this.int_0 = 1;
			}
			PageList1 pageList = new PageList1();
			pageList.PageSize = this.ShowCount;
			pageList.PageID = this.int_0;
			DataSet dataSet;
			if (this.string_1 == "all")
			{
				dataSet = this.shopNum1_ProuductChecked_Action_0.V8_2_GetFurnitureProductNew(this.addcode, this.string_7, this.string_3, this.string_6, this.string_5, this.strStartPrice, this.strEndPrice, this.string_4, this.brandguid, this.ShowCount.ToString(), this.int_0.ToString(), "1", this.dictionary_0, this.string_8);
			}
			else
			{
				dataSet = this.shopNum1_ProuductChecked_Action_0.V8_2_GetFurnitureProductNew(this.addcode, this.string_7, this.string_3, this.string_6, this.string_5, this.strStartPrice, this.strEndPrice, this.string_4, this.brandguid, this.ShowCount.ToString(), this.int_0.ToString(), "1", this.dictionary_0, this.string_8, this.string_1);
			}
			if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
			{
				pageList.RecordCount = Convert.ToInt32(dataSet.Tables[0].Rows[0][0]);
			}
			else
			{
				pageList.RecordCount = 0;
			}
			PageListBll pageListBll = new PageListBll("Search_productlist", true);
			pageListBll.ShowRecordCount = true;
			pageListBll.ShowPageCount = false;
			pageListBll.ShowPageIndex = false;
			pageListBll.ShowRecordCount = false;
			pageListBll.ShowNoRecordInfo = false;
			pageListBll.ShowNumListButton = true;
			pageListBll.PrevPageText = "上一页";
			pageListBll.NextPageText = "下一页 ";
			this.textBox_0.Text = this.int_0.ToString();
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
			DataSet dataSet2;
			if (this.string_1 == "all")
			{
				dataSet2 = this.shopNum1_ProuductChecked_Action_0.V8_2_GetFurnitureProductNew(this.addcode, this.string_7, this.string_3, this.string_6, this.string_5, this.strStartPrice, this.strEndPrice, this.string_4, this.brandguid, this.ShowCount.ToString(), this.int_0.ToString(), "0", this.dictionary_0, this.string_8);
			}
			else
			{
				dataSet2 = this.shopNum1_ProuductChecked_Action_0.V8_2_GetFurnitureProductNew(this.addcode, this.string_7, this.string_3, this.string_6, this.string_5, this.strStartPrice, this.strEndPrice, this.string_4, this.brandguid, this.ShowCount.ToString(), this.int_0.ToString(), "0", this.dictionary_0, this.string_8, this.string_1);
			}
			if (dataSet2 != null && dataSet2.Tables[0].Rows.Count > 0)
			{
				this.repeater_1.DataSource = dataSet2.Tables[0];
				this.repeater_1.DataBind();
				this.repeater_0.DataSource = dataSet2.Tables[0];
				this.repeater_0.DataBind();
			}
			else
			{
				this.panel_0.Visible = true;
			}
		}
		public static string GetArea(object AddressValue)
		{
			string result;
			if (AddressValue.ToString().IndexOf(",") != -1)
			{
				result = AddressValue.ToString().Split(new char[]
				{
					','
				})[0];
			}
			else
			{
				result = AddressValue.ToString();
			}
			return result;
		}
		[CompilerGenerated]
		private bool method_2(string string_12)
		{
			string[] array = string_12.Split(new char[]
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
						'm'
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
