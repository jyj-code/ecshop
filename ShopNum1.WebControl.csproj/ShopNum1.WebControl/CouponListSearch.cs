using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class CouponListSearch : BaseWebControl
	{
		private string string_0 = "CouponListSearch.ascx";
		private HiddenField hiddenField_0;
		private HiddenField hiddenField_1;
		private HiddenField hiddenField_2;
		private HtmlGenericControl htmlGenericControl_0;
		private HtmlImage htmlImage_0;
		private LinkButton linkButton_0;
		private Panel panel_0;
		private Repeater repeater_0;
		private Repeater repeater_1;
		private string string_1 = "all";
		private DropDownList dropDownList_0;
		private DropDownList dropDownList_1;
		private DropDownList dropDownList_2;
		private HiddenField hiddenField_3;
		private Label label_0;
		private HtmlGenericControl htmlGenericControl_1;
		private Label label_1;
		private TextBox textBox_0;
		private Button button_0;
		private string string_2 = GetPageName.RetDomainUrl("couponslist");
		private ShopNum1_Coupon_Action shopNum1_Coupon_Action_0 = (ShopNum1_Coupon_Action)LogicFactory.CreateShopNum1_Coupon_Action();
		private int int_0;
		private string string_3;
		private string string_4;
		private string string_5;
		private string string_6;
		[CompilerGenerated]
		private int int_1;
		[CompilerGenerated]
		private string string_7;
		public int ShowCount
		{
			get;
			set;
		}
		private string category
		{
			get;
			set;
		}
		public CouponListSearch()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			string text = this.textBox_0.Text.Trim();
			if (Convert.ToInt32(this.textBox_0.Text.Trim()) > Convert.ToInt32(this.label_1.Text))
			{
				this.textBox_0.Text = this.label_1.Text;
				text = this.label_1.Text;
			}
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_2,
				"?category=",
				this.category,
				"&order=",
				this.string_4,
				"&sdesc=",
				this.string_3,
				"&addcode=",
				this.string_6,
				"&pageid=",
				text
			}));
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.hiddenField_0 = (HiddenField)skin.FindControl("HiddenFieldCategory");
			this.hiddenField_1 = (HiddenField)skin.FindControl("HiddenFieldOrdername");
			this.hiddenField_2 = (HiddenField)skin.FindControl("HiddenFieldOrdeState");
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("IRenqi");
			this.repeater_1 = (Repeater)skin.FindControl("RepeaterData");
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterCategory");
			this.panel_0 = (Panel)skin.FindControl("PanelNofind");
			this.linkButton_0 = (LinkButton)skin.FindControl("LinkButtonRenqi");
			this.linkButton_0.Click += new EventHandler(this.linkButton_0_Click);
			this.dropDownList_0 = (DropDownList)skin.FindControl("DropDownListRegionCode1");
			this.dropDownList_0.SelectedIndexChanged += new EventHandler(this.DropDownListRegionCode1_SelectedIndexChanged);
			this.dropDownList_1 = (DropDownList)skin.FindControl("DropDownListRegionCode2");
			this.dropDownList_1.SelectedIndexChanged += new EventHandler(this.DropDownListRegionCode2_SelectedIndexChanged);
			this.dropDownList_2 = (DropDownList)skin.FindControl("DropDownListRegionCode3");
			this.dropDownList_2.SelectedIndexChanged += new EventHandler(this.dropDownList_2_SelectedIndexChanged);
			this.hiddenField_3 = (HiddenField)skin.FindControl("HiddenFieldRegionCode");
			this.label_0 = (Label)skin.FindControl("lblAddress");
			this.htmlGenericControl_1 = (HtmlGenericControl)skin.FindControl("pageDiv");
			this.label_1 = (Label)skin.FindControl("LabelPageCount");
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxIndex");
			this.button_0 = (Button)skin.FindControl("ButtonSure");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			if (this.Page.Request.QueryString["SubstationID"] != null && !string.IsNullOrEmpty(this.Page.Request.QueryString["SubstationID"].ToString()))
			{
				this.string_1 = this.Page.Request.QueryString["SubstationID"].ToString();
			}
			this.string_5 = ((this.Page.Request.QueryString["catename"] == null) ? "全部" : this.Page.Request.QueryString["catename"].ToString());
			this.hiddenField_1.Value = (this.string_4 = ((this.Page.Request.QueryString["order"] == null) ? "createtime" : this.Page.Request.QueryString["order"].ToString()));
			this.string_3 = ((this.Page.Request.QueryString["sdesc"] == null) ? "desc" : this.Page.Request.QueryString["sdesc"].ToString());
			this.string_4 = ((this.Page.Request.QueryString["order"] == null) ? "createtime" : this.Page.Request.QueryString["order"].ToString());
			this.category = ((this.Page.Request.QueryString["category"] == null) ? "-1" : this.Page.Request.QueryString["category"].ToString());
			this.string_6 = ((this.Page.Request.QueryString["addcode"] == null) ? "-1" : this.Page.Request.QueryString["addcode"].ToString());
			if (this.string_6 == "")
			{
				this.string_6 = "-1";
			}
			this.int_0 = 1;
			try
			{
				this.int_0 = int.Parse(this.Page.Request.QueryString["PageID"]);
			}
			catch
			{
				this.int_0 = 1;
			}
			if (this.Page.IsPostBack)
			{
			}
			this.DropDownListRegionCode1Bind();
			this.CouponsDataBind();
			this.CouponsData();
			this.method_0(this.string_4, this.string_3);
		}
		private void linkButton_0_Click(object sender, EventArgs e)
		{
			if (this.string_4 == "browsercount")
			{
				this.string_3 = ((this.Page.Request.QueryString["sdesc"] == null) ? "" : this.Page.Request.QueryString["sdesc"]);
				if (this.string_3 == "asc" || this.string_3 == "")
				{
					this.string_3 = "desc";
				}
				else
				{
					this.string_3 = "asc";
				}
			}
			else
			{
				this.string_4 = "browsercount";
				this.string_3 = "desc";
			}
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_2,
				"?category=",
				this.category,
				"&catename=",
				this.string_5,
				"&addcode=",
				this.string_6,
				"&order=",
				this.string_4,
				"&sdesc=",
				this.string_3
			}));
		}
		protected void CouponsDataBind()
		{
			ShopNum1_CouponType_Action shopNum1_CouponType_Action = (ShopNum1_CouponType_Action)LogicFactory.CreateShopNum1_CouponType_Action();
			DataTable dataTable = shopNum1_CouponType_Action.search(-1, 1);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataTable.DefaultView;
				this.repeater_0.DataBind();
			}
		}
		protected void CouponsData()
		{
			try
			{
				if (this.string_6 != "-1")
				{
                    this.label_0.Text = ShopNum1.Common.Common.cut(ShopNum1.Common.Common.GetNameById("name", "ShopNum1_region", " And code like '" + this.string_6 + "%'"), 3);
				}
				else
				{
					this.label_0.Text = "全部";
				}
			}
			catch
			{
				this.label_0.Text = "全部";
			}
			this.SetShopRegionCode();
			PageList1 pageList = new PageList1();
			pageList.PageSize = this.ShowCount;
			pageList.PageID = this.int_0;
			DataTable dataTable;
			if (this.string_1 == "all")
			{
				dataTable = this.shopNum1_Coupon_Action_0.SearchCouponByType(this.category, this.hiddenField_3.Value, this.string_4, this.string_3, this.ShowCount.ToString(), this.int_0.ToString(), "1");
			}
			else
			{
				dataTable = this.shopNum1_Coupon_Action_0.SearchCouponByType(this.category, this.hiddenField_3.Value, this.string_4, this.string_3, this.ShowCount.ToString(), this.int_0.ToString(), "1", this.string_1);
			}
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				pageList.RecordCount = Convert.ToInt32(dataTable.Rows[0][0]);
			}
			else
			{
				pageList.RecordCount = 0;
			}
			PageListBll pageListBll = new PageListBll("couponslist", true);
			pageListBll.ShowRecordCount = true;
			pageListBll.ShowPageCount = false;
			pageListBll.ShowPageIndex = false;
			pageListBll.ShowRecordCount = false;
			pageListBll.ShowNoRecordInfo = false;
			pageListBll.ShowNumListButton = true;
			pageListBll.PrevPageText = "上一页";
			pageListBll.NextPageText = "下一页 ";
			this.textBox_0.Text = this.int_0.ToString();
			this.htmlGenericControl_1.InnerHtml = pageListBll.GetPageListVk(pageList);
			this.label_1.Text = pageList.PageCount.ToString();
			if ((double)pageList.PageCount < (double)pageList.RecordCount / (double)pageList.PageSize)
			{
				pageList.PageCount++;
			}
			if (this.int_0 > pageList.PageCount)
			{
				this.int_0 = pageList.PageCount;
			}
			DataTable dataTable2;
			if (this.string_1 == "all")
			{
				dataTable2 = this.shopNum1_Coupon_Action_0.SearchCouponByType(this.category, this.hiddenField_3.Value, this.string_4, this.string_3, this.ShowCount.ToString(), this.int_0.ToString(), "0");
			}
			else
			{
				dataTable2 = this.shopNum1_Coupon_Action_0.SearchCouponByType(this.category, this.hiddenField_3.Value, this.string_4, this.string_3, this.ShowCount.ToString(), this.int_0.ToString(), "0", this.string_1);
			}
			if (dataTable2 != null && dataTable2.Rows.Count > 0)
			{
				this.repeater_1.DataSource = dataTable2;
				this.repeater_1.DataBind();
				this.panel_0.Visible = false;
				this.repeater_1.Visible = true;
				for (int i = 0; i < this.repeater_1.Items.Count; i++)
				{
					this.htmlImage_0 = (HtmlImage)this.repeater_1.Items[i].FindControl("ImgCoupon");
					this.htmlImage_0.Src = this.Page.ResolveUrl(dataTable2.Rows[i]["ImgPath"].ToString());
				}
			}
			else
			{
				this.panel_0.Visible = true;
				this.repeater_1.Visible = false;
			}
		}
		private void method_0(string string_8, string string_9)
		{
			string_8 = string_8.ToLower();
			if (string_9 == "desc")
			{
				if (string_8 == "createtime")
				{
					this.hiddenField_2.Value = "默认排序";
				}
				if (string_8 == "browsercount")
				{
					this.hiddenField_2.Value = "人气从高到低";
					this.linkButton_0.CssClass = "comSort selected";
					this.htmlGenericControl_0.Attributes.Add("class", "comSort-dSel");
				}
			}
			else
			{
				if (string_8 == "createtime")
				{
					this.hiddenField_2.Value = "默认排序";
				}
				if (string_8 == "browsercount")
				{
					this.hiddenField_2.Value = "人气从低到高";
					this.linkButton_0.CssClass = "comSort selected";
					this.htmlGenericControl_0.Attributes.Add("class", "comSort-uSel");
				}
			}
		}
		protected string GetWebFilePath(string ShopID)
		{
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
			DataTable openTimeByShopID = shopNum1_ShopInfoList_Action.GetOpenTimeByShopID(ShopID);
			string text = DateTime.Parse(openTimeByShopID.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
			string text2 = string.Concat(new string[]
			{
				"~/ImgUpload/",
				text.Replace("-", "/"),
				"/shop",
				ShopID,
				"/Coupon/"
			});
			if (!Directory.Exists(HttpContext.Current.Server.MapPath(text2)))
			{
				Directory.CreateDirectory(HttpContext.Current.Server.MapPath(text2));
			}
			return text2;
		}
		public void SetShopRegionCode()
		{
			string text = string.Empty;
			if (this.Page.Request["CouponListSearch$ctl00$DropDownListRegionCode1"] != null && this.Page.Request["CouponListSearch$ctl00$DropDownListRegionCode1"] != "-1")
			{
				text = this.Page.Request["CouponListSearch$ctl00$DropDownListRegionCode1"].ToString().Split(new char[]
				{
					'/'
				})[0];
			}
			if (this.Page.Request["CouponListSearch$ctl00$DropDownListRegionCode2"] != null && this.Page.Request["CouponListSearch$ctl00$DropDownListRegionCode2"] != "-1")
			{
				text = text + "," + this.Page.Request["CouponListSearch$ctl00$DropDownListRegionCode2"].ToString().Split(new char[]
				{
					'/'
				})[0];
			}
			if (this.Page.Request["CouponListSearch_ctl00_DropDownListRegionCode3"] != null && this.Page.Request["CouponListSearch_ctl00_DropDownListRegionCode3"] != "-1")
			{
				text = text + "," + this.Page.Request["CouponListSearch_ctl00_DropDownListRegionCode3"].ToString().Split(new char[]
				{
					'/'
				})[0];
			}
			if (text == string.Empty)
			{
			}
			this.hiddenField_3.Value = this.string_6;
		}
		private void dropDownList_2_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.CouponsDataBind();
			this.CouponsData();
			this.method_0(this.string_4, this.string_3);
		}
		protected void DropDownListRegionCode1Bind()
		{
			this.dropDownList_0.Items.Clear();
			this.dropDownList_0.Items.Add(new ListItem("-省级-", "-1"));
			ShopNum1_Region_Action shopNum1_Region_Action = (ShopNum1_Region_Action)LogicFactory.CreateShopNum1_Region_Action();
			DataTable dataTable = shopNum1_Region_Action.SearchtRegionCategory(0, 0);
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				this.dropDownList_0.Items.Add(new ListItem(dataTable.Rows[i]["Name"].ToString(), dataTable.Rows[i]["Code"].ToString() + "/" + dataTable.Rows[i]["ID"].ToString()));
			}
			this.DropDownListRegionCode1_SelectedIndexChanged(null, null);
		}
		protected void DropDownListRegionCode1_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.CouponsDataBind();
			this.dropDownList_1.Items.Clear();
			this.dropDownList_1.Items.Add(new ListItem("-市级-", "-1"));
			if (this.dropDownList_0.SelectedValue != "-1")
			{
				ShopNum1_Region_Action shopNum1_Region_Action = (ShopNum1_Region_Action)LogicFactory.CreateShopNum1_Region_Action();
				DataTable dataTable = shopNum1_Region_Action.SearchtRegionCategory(Convert.ToInt32(this.dropDownList_0.SelectedValue.Split(new char[]
				{
					'/'
				})[1].ToString()), 0);
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.dropDownList_1.Items.Add(new ListItem(dataTable.Rows[i]["Name"].ToString(), dataTable.Rows[i]["Code"].ToString() + "/" + dataTable.Rows[i]["ID"].ToString()));
				}
			}
			this.DropDownListRegionCode2_SelectedIndexChanged(null, null);
		}
		protected void DropDownListRegionCode2_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.dropDownList_2.Items.Clear();
			this.dropDownList_2.Items.Add(new ListItem("-县级-", "-1"));
			if (this.dropDownList_1.SelectedValue != "-1")
			{
				this.CouponsDataBind();
				ShopNum1_Region_Action shopNum1_Region_Action = (ShopNum1_Region_Action)LogicFactory.CreateShopNum1_Region_Action();
				DataTable dataTable = shopNum1_Region_Action.SearchtRegionCategory(Convert.ToInt32(this.dropDownList_1.SelectedValue.Split(new char[]
				{
					'/'
				})[1].ToString()), 0);
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.dropDownList_2.Items.Add(new ListItem(dataTable.Rows[i]["Name"].ToString(), dataTable.Rows[i]["Code"].ToString() + "/" + dataTable.Rows[i]["ID"].ToString()));
				}
			}
		}
	}
}
