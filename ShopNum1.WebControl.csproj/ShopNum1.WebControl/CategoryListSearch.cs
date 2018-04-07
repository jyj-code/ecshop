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
	public class CategoryListSearch : BaseWebControl
	{
		private string string_0 = "CategoryListSearch.ascx";
		private Repeater repeater_0;
		private Repeater repeater_1;
		private Panel panel_0;
		private TextBox textBox_0;
		private Button button_0;
		private HiddenField hiddenField_0;
		private HiddenField hiddenField_1;
		private HtmlGenericControl htmlGenericControl_0;
		private Label label_0;
		private TextBox textBox_1;
		private Button button_1;
		private string string_1 = GetPageName.RetDomainUrl("SupplyDemandListSearch");
		private int int_0;
		private string string_2;
		private string string_3;
		private string string_4;
		private string string_5;
		private string string_6;
		private bool bool_0 = false;
		[CompilerGenerated]
		private int int_1;
		public int ShowCount
		{
			get;
			set;
		}
		public CategoryListSearch()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.repeater_0.ItemDataBound += new RepeaterItemEventHandler(this.repeater_0_ItemDataBound);
			this.repeater_1 = (Repeater)skin.FindControl("RepeaterSupplyCategory");
			this.panel_0 = (Panel)skin.FindControl("Panel1");
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxCity");
			this.button_0 = (Button)skin.FindControl("ButtonCity");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.hiddenField_0 = (HiddenField)skin.FindControl("HiddenFieldAddCode");
			this.hiddenField_1 = (HiddenField)skin.FindControl("HiddenFieldAdd");
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("pageDiv");
			this.label_0 = (Label)skin.FindControl("LabelPageCount");
			this.textBox_1 = (TextBox)skin.FindControl("TextBoxIndex");
			this.button_1 = (Button)skin.FindControl("ButtonSure");
			this.button_1.Click += new EventHandler(this.button_1_Click);
			this.int_0 = 1;
			try
			{
				this.int_0 = int.Parse(ShopNum1.Common.Common.ReqStr("PageID"));
			}
			catch
			{
				this.int_0 = 1;
			}
			this.string_2 = ((ShopNum1.Common.Common.ReqStr("search") == "") ? "-1" : ShopNum1.Common.Common.ReqStr("search"));
			this.string_3 = ((ShopNum1.Common.Common.ReqStr("code") == "") ? "-1" : ShopNum1.Common.Common.ReqStr("code"));
			this.string_4 = ((ShopNum1.Common.Common.ReqStr("addcode") == "") ? "-1" : ShopNum1.Common.Common.ReqStr("addcode"));
			this.string_5 = ((ShopNum1.Common.Common.ReqStr("ordername") == "") ? "A.CreateTime" : ShopNum1.Common.Common.ReqStr("ordername"));
			if (this.Page.IsPostBack)
			{
			}
			this.method_0();
			this.method_2();
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
			shopNum1_ProductCategory_Action.TableName = "ShopNum1_Category";
			DataTable productCategoryName = shopNum1_ProductCategory_Action.GetProductCategoryName("0");
			if (productCategoryName != null && productCategoryName.Rows.Count > 0)
			{
				this.repeater_1.DataSource = productCategoryName.DefaultView;
				this.repeater_1.DataBind();
			}
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			this.textBox_1.Text.Trim();
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_1,
				"?search=",
				this.string_2,
				"&supplyCategoryCode=",
				this.string_3,
				"&supplyAddressCode=",
				this.string_4,
				"&ordername=",
				this.string_5
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
			ShopNum1_CategoryChecked_Action shopNum1_CategoryChecked_Action = (ShopNum1_CategoryChecked_Action)LogicFactory.CreateShopNum1_CategoryChecked_Action();
			DataSet dataSet = shopNum1_CategoryChecked_Action.Search(this.ShowCount.ToString(), this.int_0.ToString(), this.string_2, this.string_3, this.string_4, this.string_5, "1");
			if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
			{
				pageList.RecordCount = Convert.ToInt32(dataSet.Tables[0].Rows[0][0]);
			}
			else
			{
				pageList.RecordCount = 0;
			}
			PageListBll pageListBll = new PageListBll("CategoryListSearch", true);
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
			this.label_0.Text = pageList.PageCount.ToString();
			pageList.PageCount = pageList.RecordCount / pageList.PageSize;
			if ((double)pageList.PageCount < (double)pageList.RecordCount / (double)pageList.PageSize)
			{
				pageList.PageCount++;
			}
			if (this.int_0 > pageList.PageCount)
			{
				this.int_0 = pageList.PageCount;
			}
			DataSet dataSet2 = shopNum1_CategoryChecked_Action.Search(this.ShowCount.ToString(), this.int_0.ToString(), this.string_2, this.string_3, this.string_4, this.string_5, "0");
			if (dataSet2 != null && dataSet2.Tables[0].Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataSet2.Tables[0];
				this.repeater_0.DataBind();
			}
			else if (this.string_3 == "-1")
			{
				string url = GetPageName.AgentRetUrl("SupplyDemandnofind", this.string_2, "search");
				this.Page.Response.Redirect(url);
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
