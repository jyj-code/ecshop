using ShopNum1.BusinessLogic;
using ShopNum1.CityFactory;
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
	public class ShopListSearch : BaseWebControl
	{
		private string string_0 = "ShopListSearch.ascx";
		private Label label_0;
		private HiddenField hiddenField_0;
		private Repeater repeater_0;
		private TextBox textBox_0;
		private TextBox textBox_1;
		private Button button_0;
		private string string_1 = "all";
		private HtmlGenericControl htmlGenericControl_0;
		private Label label_1;
		private TextBox textBox_2;
		private Button button_1;
		private Panel panel_0;
		private DataList dataList_0;
		private HiddenField hiddenField_1;
		private HiddenField hiddenField_2;
		private LinkButton linkButton_0;
		private LinkButton linkButton_1;
		private LinkButton linkButton_2;
		private HtmlGenericControl htmlGenericControl_1;
		private HtmlGenericControl htmlGenericControl_2;
		private HtmlGenericControl htmlGenericControl_3;
		private Label label_2;
		private string string_2 = GetPageName.RetDomainUrl("ShopListSearch");
		private ShopNum1_ProuductChecked_Action shopNum1_ProuductChecked_Action_0 = (ShopNum1_ProuductChecked_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ProuductChecked_Action();
		private string string_3;
		public string shopName;
		private int int_0;
		private string string_4;
		private string string_5;
		public string memberid;
		public string addcode;
		[CompilerGenerated]
		private int int_1;
		[CompilerGenerated]
		private string string_6;
		[CompilerGenerated]
		private string string_7;
		public int ShowCount
		{
			get;
			set;
		}
		public string CityShowCount
		{
			get;
			set;
		}
		public string ShowRelatedProduct
		{
			get;
			set;
		}
		public ShopListSearch()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			string text = this.textBox_2.Text.Trim();
			if (Convert.ToInt32(this.textBox_2.Text.Trim()) > Convert.ToInt32(this.label_1.Text))
			{
				this.textBox_2.Text = this.label_1.Text;
				text = this.label_1.Text;
			}
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_2,
				"?search=",
				this.shopName,
				"&code=",
				this.string_3,
				"&memberid=",
				this.memberid,
				"&sort=",
				this.string_4,
				"&ordername=",
				this.string_5,
				"&addcode=",
				this.addcode,
				"&pageid=",
				text
			}));
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.label_0 = (Label)skin.FindControl("LabelAddress");
			this.hiddenField_0 = (HiddenField)skin.FindControl("HiddenFieldAddCode");
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.repeater_0.ItemDataBound += new RepeaterItemEventHandler(this.repeater_0_ItemDataBound);
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("pageDiv");
			this.label_1 = (Label)skin.FindControl("LabelPageCount");
			this.textBox_2 = (TextBox)skin.FindControl("TextBoxIndex");
			this.button_1 = (Button)skin.FindControl("ButtonSure");
			this.button_1.Click += new EventHandler(this.button_1_Click);
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxShopname");
			this.textBox_0.TextChanged += new EventHandler(this.textBox_0_TextChanged);
			this.textBox_1 = (TextBox)skin.FindControl("TextBoxMember");
			this.textBox_1.TextChanged += new EventHandler(this.textBox_1_TextChanged);
			this.button_0 = (Button)skin.FindControl("ButtonSearch");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.dataList_0 = (DataList)skin.FindControl("DataListRelatedProduct");
			this.hiddenField_1 = (HiddenField)skin.FindControl("HiddenFieldOrdername");
			this.hiddenField_2 = (HiddenField)skin.FindControl("HiddenFieldOrdeState");
			this.linkButton_0 = (LinkButton)skin.FindControl("LinkButtonRenqi");
			this.linkButton_0.Click += new EventHandler(this.linkButton_0_Click);
			this.linkButton_1 = (LinkButton)skin.FindControl("LinkButtonSales");
			this.linkButton_1.Click += new EventHandler(this.linkButton_1_Click);
			this.linkButton_2 = (LinkButton)skin.FindControl("LinkButtonXinyong");
			this.linkButton_2.Click += new EventHandler(this.linkButton_2_Click);
			this.htmlGenericControl_1 = (HtmlGenericControl)skin.FindControl("IRenqi");
			this.htmlGenericControl_2 = (HtmlGenericControl)skin.FindControl("ISales");
			this.htmlGenericControl_3 = (HtmlGenericControl)skin.FindControl("IXinyong");
			this.panel_0 = (Panel)skin.FindControl("PanelNoFind");
			this.label_2 = (Label)skin.FindControl("LabelAdress");
			this.string_3 = ((ShopNum1.Common.Common.ReqStr("code") == "") ? "-1" : ShopNum1.Common.Common.ReqStr("code"));
			this.hiddenField_1.Value = (this.string_5 = ((ShopNum1.Common.Common.ReqStr("ordername") == "") ? "salesum" : ShopNum1.Common.Common.ReqStr("ordername")));
			this.string_4 = ((ShopNum1.Common.Common.ReqStr("sort") == "") ? "desc" : ShopNum1.Common.Common.ReqStr("sort"));
			this.addcode = ((ShopNum1.Common.Common.ReqStr("addcode") == "") ? "-1" : ShopNum1.Common.Common.ReqStr("addcode"));
			this.shopName = ((ShopNum1.Common.Common.ReqStr("search") == "") ? "-1" : ShopNum1.Common.Common.ReqStr("search"));
			this.memberid = ((ShopNum1.Common.Common.ReqStr("memberid") == "") ? "-1" : ShopNum1.Common.Common.ReqStr("memberid"));
			this.int_0 = 1;
			try
			{
				this.int_0 = int.Parse(ShopNum1.Common.Common.ReqStr("PageID"));
			}
			catch
			{
				this.int_0 = 1;
			}
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
					"/ShopListSearch",
					ShopListSearch.GetOverrideUrlName()
				});
			}
			if (this.Page.IsPostBack)
			{
			}
			this.hiddenField_0.Value = this.addcode;
			this.BindData();
			this.method_0(this.string_5, this.string_4);
			if (this.Page.Request.QueryString["addcode"] != null && !string.IsNullOrEmpty(this.Page.Request.QueryString["addcode"].ToString()))
			{
				string nameById = ShopNum1.Common.Common.GetNameById("Name", "ShopNum1_Region", "   AND   Code='" + this.Page.Request.QueryString["addcode"].ToString() + "'   ");
				if (!string.IsNullOrEmpty(nameById))
				{
					this.label_2.Text = nameById;
				}
				else
				{
					this.label_2.Text = "所有地区";
				}
			}
			else
			{
				this.label_2.Text = "所有地区";
			}
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
		private void textBox_1_TextChanged(object sender, EventArgs e)
		{
			this.shopName = this.textBox_0.Text.Trim().Replace("'", "");
			this.memberid = this.textBox_1.Text.Trim().Replace("'", "");
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_2,
				"?search=",
				this.shopName,
				"&code=",
				this.string_3,
				"&memberid=",
				this.memberid,
				"&sort=",
				this.string_4,
				"&ordername=",
				this.string_5,
				"&addcode=",
				this.addcode
			}));
		}
		private void textBox_0_TextChanged(object sender, EventArgs e)
		{
			this.shopName = this.textBox_0.Text.Trim().Replace("'", "");
			this.memberid = this.textBox_1.Text.Trim().Replace("'", "");
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_2,
				"?search=",
				this.shopName,
				"&code=",
				this.string_3,
				"&memberid=",
				this.memberid,
				"&sort=",
				this.string_4,
				"&ordername=",
				this.string_5,
				"&addcode=",
				this.addcode
			}));
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			this.shopName = this.textBox_0.Text.Trim().Replace("'", "");
			this.memberid = this.textBox_1.Text.Trim().Replace("'", "");
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_2,
				"?search=",
				this.shopName,
				"&code=",
				this.string_3,
				"&memberid=",
				this.memberid,
				"&sort=",
				this.string_4,
				"&ordername=",
				this.string_5,
				"&addcode=",
				this.addcode
			}));
		}
		private void repeater_0_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				Repeater repeater = (Repeater)e.Item.FindControl("RepeaterShopEnsure");
				HiddenField hiddenField = (HiddenField)e.Item.FindControl("HiddenFieldMemLoginID");
				string shopid = hiddenField.Value.Trim().Replace("'", "");
				ShopNum1_Ensure_Action shopNum1_Ensure_Action = new ShopNum1_Ensure_Action();
				DataTable shopapplyEnsure = shopNum1_Ensure_Action.GetShopapplyEnsure(shopid);
				repeater.DataSource = shopapplyEnsure.DefaultView;
				repeater.DataBind();
			}
		}
		protected void BindData()
		{
			PageList1 pageList = new PageList1();
			pageList.PageSize = this.ShowCount;
			pageList.PageID = this.int_0;
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
			DataSet dataSet;
			if (this.string_1 == "all")
			{
				dataSet = shopNum1_ShopInfoList_Action.SearchShopList(this.addcode, this.string_3, this.string_5, this.string_4, this.shopName, this.memberid, this.ShowCount.ToString(), this.int_0.ToString(), "1");
			}
			else
			{
				dataSet = shopNum1_ShopInfoList_Action.SearchShopList(this.addcode, this.string_3, this.string_5, this.string_4, this.shopName, this.memberid, this.ShowCount.ToString(), this.int_0.ToString(), "1", this.string_1);
			}
			if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
			{
				pageList.RecordCount = Convert.ToInt32(dataSet.Tables[0].Rows[0][0]);
			}
			else
			{
				pageList.RecordCount = 0;
			}
			PageListBll pageListBll = new PageListBll("ShopListSearch", true);
			pageListBll.ShowRecordCount = true;
			pageListBll.ShowPageCount = false;
			pageListBll.ShowPageIndex = false;
			pageListBll.ShowRecordCount = false;
			pageListBll.ShowNoRecordInfo = false;
			pageListBll.ShowNumListButton = true;
			pageListBll.PrevPageText = "上一页";
			pageListBll.NextPageText = "下一页 ";
			this.textBox_2.Text = this.int_0.ToString();
			this.htmlGenericControl_0.InnerHtml = pageListBll.GetPageListVk(pageList);
			this.label_1.Text = pageList.PageCount.ToString();
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
				dataSet2 = shopNum1_ShopInfoList_Action.SearchShopList(this.addcode, this.string_3, this.string_5, this.string_4, this.shopName, this.memberid, this.ShowCount.ToString(), this.int_0.ToString(), "0");
			}
			else
			{
				dataSet2 = shopNum1_ShopInfoList_Action.SearchShopList(this.addcode, this.string_3, this.string_5, this.string_4, this.shopName, this.memberid, this.ShowCount.ToString(), this.int_0.ToString(), "0", this.string_1);
			}
			if (dataSet2 != null && dataSet2.Tables[0].Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataSet2.Tables[0];
				this.repeater_0.DataBind();
			}
			else
			{
				this.panel_0.Visible = true;
			}
		}
		private void linkButton_2_Click(object sender, EventArgs e)
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
				this.string_2,
				"?search=",
				this.shopName,
				"&code=",
				this.string_3,
				"&memberid=",
				this.memberid,
				"&sort=",
				this.string_4,
				"&ordername=",
				this.string_5,
				"&addcode=",
				this.addcode
			}));
		}
		private void linkButton_1_Click(object sender, EventArgs e)
		{
			if (this.string_5 == "salesum")
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
				this.string_5 = "salesum";
				this.string_4 = "desc";
			}
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_2,
				"?search=",
				this.shopName,
				"&code=",
				this.string_3,
				"&memberid=",
				this.memberid,
				"&sort=",
				this.string_4,
				"&ordername=",
				this.string_5,
				"&addcode=",
				this.addcode
			}));
		}
		private void linkButton_0_Click(object sender, EventArgs e)
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
				this.string_2,
				"?search=",
				this.shopName,
				"&code=",
				this.string_3,
				"&memberid=",
				this.memberid,
				"&sort=",
				this.string_4,
				"&ordername=",
				this.string_5,
				"&addcode=",
				this.addcode
			}));
		}
		private void method_0(string string_8, string string_9)
		{
			string_8 = string_8.ToLower();
			if (string_9 == "desc")
			{
				if (string_8 == "salesum")
				{
					this.hiddenField_2.Value = "销量从高到低";
					this.linkButton_1.CssClass = "comSort selected";
					this.htmlGenericControl_2.Attributes.Add("class", "comSort-dSel");
				}
				if (string_8 == "orderid")
				{
					this.hiddenField_2.Value = "默认排序";
				}
				if (string_8 == "clickcount")
				{
					this.hiddenField_2.Value = "人气从高到低";
					this.linkButton_0.CssClass = "comSort selected";
					this.htmlGenericControl_1.Attributes.Add("class", "comSort-dSel");
				}
				if (string_8 == "shopreputation")
				{
					this.hiddenField_2.Value = "信用从高到低";
					this.linkButton_2.CssClass = "comSort selected";
					this.htmlGenericControl_3.Attributes.Add("class", "comSort-dSel");
				}
			}
			else
			{
				if (string_8 == "salesum")
				{
					this.hiddenField_2.Value = "销量从低到高";
					this.linkButton_1.CssClass = "comSort selected";
					this.htmlGenericControl_2.Attributes.Add("class", "comSort-uSel");
				}
				if (string_8 == "orderid")
				{
					this.hiddenField_2.Value = "默认排序";
				}
				if (string_8 == "clickcount")
				{
					this.hiddenField_2.Value = "人气从低到高";
					this.linkButton_0.CssClass = "comSort selected";
					this.htmlGenericControl_1.Attributes.Add("class", "comSort-uSel");
				}
				if (string_8 == "shopreputation")
				{
					this.hiddenField_2.Value = "信用从低到高";
					this.linkButton_2.CssClass = "comSort selected";
					this.htmlGenericControl_3.Attributes.Add("class", "comSort-uSel");
				}
			}
		}
	}
}
