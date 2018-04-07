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
	public class SupplyDemandListSearch : BaseWebControl
	{
		private string string_0 = "SupplyDemandListSearch.ascx";
		private Label label_0;
		private Repeater repeater_0;
		private Repeater repeater_1;
		private Panel panel_0;
		private TextBox textBox_0;
		private Button button_0;
		private HiddenField hiddenField_0;
		private HiddenField hiddenField_1;
		private HtmlGenericControl htmlGenericControl_0;
		private Label label_1;
		private TextBox textBox_1;
		private Button button_1;
		private string string_1 = GetPageName.RetDomainUrl("SupplyDemandListSearch");
		private string string_2 = "all";
		private Label label_2;
		private int int_0;
		private string string_3;
		private string string_4;
		private string string_5;
		private string string_6;
		private string string_7;
		private bool bool_0 = false;
		[CompilerGenerated]
		private int int_1;
		public int ShowCount
		{
			get;
			set;
		}
		public SupplyDemandListSearch()
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
				this.string_2 = this.Page.Request.QueryString["SubstationID"].ToString();
			}
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.repeater_0.ItemDataBound += new RepeaterItemEventHandler(this.repeater_0_ItemDataBound);
			this.repeater_1 = (Repeater)skin.FindControl("RepeaterSupplyCategory");
			this.panel_0 = (Panel)skin.FindControl("Panel1");
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxCity");
			this.button_0 = (Button)skin.FindControl("ButtonCity");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.hiddenField_0 = (HiddenField)skin.FindControl("HiddenFieldAddCode");
			this.hiddenField_1 = (HiddenField)skin.FindControl("HiddenFieldAdd");
			this.label_2 = (Label)skin.FindControl("LabelAdress");
			this.label_0 = (Label)skin.FindControl("LabelShowCategory");
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("pageDiv");
			this.label_1 = (Label)skin.FindControl("LabelPageCount");
			this.textBox_1 = (TextBox)skin.FindControl("TextBoxIndex");
			this.button_1 = (Button)skin.FindControl("ButtonSure");
			this.button_1.Click += new EventHandler(this.button_1_Click);
			this.int_0 = 1;
			try
			{
				this.int_0 = int.Parse(this.Page.Request.QueryString["PageID"]);
			}
			catch
			{
				this.int_0 = 1;
			}
			this.string_3 = ((this.Page.Request.QueryString["search"] == null) ? "-1" : this.Page.Request.QueryString["search"].ToString());
			this.string_4 = ((this.Page.Request.QueryString["Code"] == null) ? "-1" : this.Page.Request.QueryString["Code"].ToString());
			this.string_5 = ((this.Page.Request.QueryString["addcode"] == null) ? "-1" : this.Page.Request.QueryString["addcode"].ToString());
			this.string_6 = ((this.Page.Request.QueryString["ordername"] == null) ? "CreateTime" : this.Page.Request.QueryString["ordername"].ToString());
			if (!this.Page.IsPostBack)
			{
			}
			try
			{
				string nameById = ShopNum1.Common.Common.GetNameById("Name", "ShopNum1_SupplyDemandCategory", "   AND  Code='" + this.string_4 + "'   ");
				if (!string.IsNullOrEmpty(nameById))
				{
					this.label_0.Text = nameById;
				}
				else
				{
					this.label_0.Text = "全部信息";
				}
			}
			catch (Exception)
			{
				this.label_0.Text = "全部信息";
			}
			this.method_0();
			this.method_2();
			if (this.Page.Request.QueryString["addcode"] != null && !string.IsNullOrEmpty(this.Page.Request.QueryString["addcode"].ToString()))
			{
				string nameById2 = ShopNum1.Common.Common.GetNameById("Name", "ShopNum1_Region", "   AND   Code='" + this.Page.Request.QueryString["addcode"].ToString() + "'   ");
				if (!string.IsNullOrEmpty(nameById2))
				{
					this.label_2.Text = nameById2;
				}
				else
				{
					this.label_2.Text = "所在地";
				}
			}
			else
			{
				this.label_2.Text = "所在地";
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
		}
		private void repeater_0_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType != ListItemType.AlternatingItem && e.Item.ItemType != ListItemType.Item)
			{
			}
		}
		private void method_0()
		{
			ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
			shopNum1_ProductCategory_Action.TableName = "ShopNum1_SupplyDemandCategory";
			DataTable productCategoryName = shopNum1_ProductCategory_Action.GetProductCategoryName("0");
			if (productCategoryName != null && productCategoryName.Rows.Count > 0)
			{
				this.repeater_1.DataSource = productCategoryName.DefaultView;
				this.repeater_1.DataBind();
			}
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			string text = this.textBox_1.Text.Trim();
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_1,
				"?search=",
				this.string_3,
				"&supplyCategoryCode=",
				this.string_4,
				"&supplyAddressCode=",
				this.string_5,
				"&ordername=",
				this.string_6,
				"&PageID=",
				text
			}));
		}
		private void method_1(object sender, EventArgs e)
		{
			this.bool_0 = true;
			this.ViewState["PageData"] = null;
			this.method_2();
		}
		private void method_2()
		{
			PageList1 pageList = new PageList1();
			pageList.PageSize = this.ShowCount;
			pageList.PageID = this.int_0;
			ShopNum1_SupplyDemandCheck_Action shopNum1_SupplyDemandCheck_Action = (ShopNum1_SupplyDemandCheck_Action)LogicFactory.CreateShopNum1_SupplyDemandCheck_Action();
			DataSet dataSet = shopNum1_SupplyDemandCheck_Action.SearchSupply(this.ShowCount.ToString(), this.int_0.ToString(), this.string_3, this.string_4, this.string_5, this.string_6, "1", this.string_2);
			if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
			{
				pageList.RecordCount = Convert.ToInt32(dataSet.Tables[0].Rows[0][0]);
			}
			else
			{
				pageList.RecordCount = 0;
			}
			PageListBll pageListBll = new PageListBll("SupplyDemandListSearch", true);
			pageListBll.ShowRecordCount = true;
			pageListBll.ShowPageCount = false;
			pageListBll.ShowPageIndex = false;
			pageListBll.ShowRecordCount = false;
			pageListBll.ShowNoRecordInfo = false;
			pageListBll.ShowNumListButton = true;
			pageListBll.PrevPageText = "上一页";
			pageListBll.NextPageText = "下一页 ";
			this.textBox_1.Text = this.int_0.ToString();
			this.htmlGenericControl_0.InnerHtml = pageListBll.GetPageListVk(pageList);
			this.label_1.Text = pageList.PageCount.ToString();
			DataSet dataSet2 = shopNum1_SupplyDemandCheck_Action.SearchSupply(this.ShowCount.ToString(), this.int_0.ToString(), this.string_3, this.string_4, this.string_5, this.string_6, "0", this.string_2);
			if (dataSet2 != null && dataSet2.Tables[0].Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataSet2.Tables[0];
				this.repeater_0.DataBind();
			}
			else if (this.string_4 == "-1")
			{
				this.panel_0.Visible = false;
			}
			else
			{
				this.panel_0.Visible = true;
			}
		}
		public static string GetMember(object MemberLoginID, object CompanyName, object MemberType)
		{
			string result;
			if (MemberType.ToString() != "0")
			{
				result = CompanyName.ToString();
			}
			else
			{
				result = MemberLoginID.ToString();
			}
			return result;
		}
	}
}
