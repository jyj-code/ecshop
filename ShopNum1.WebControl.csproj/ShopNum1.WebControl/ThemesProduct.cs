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
	public class ThemesProduct : BaseWebControl
	{
		private string string_0 = "ThemesProduct.ascx";
		private Repeater repeater_0;
		private HtmlGenericControl htmlGenericControl_0;
		private Label label_0;
		private TextBox textBox_0;
		private Button button_0;
		private Image image_0;
		private HtmlInputHidden htmlInputHidden_0;
		private string string_1 = GetPageName.RetDomainUrl("ThemesProduct");
		private ShopNum1_ProuductChecked_Action shopNum1_ProuductChecked_Action_0 = (ShopNum1_ProuductChecked_Action)LogicFactory.CreateShopNum1_ProuductChecked_Action();
		public string themeguid;
		private int int_0;
		public string memberid;
		[CompilerGenerated]
		private int int_1;
		public int ShowCount
		{
			get;
			set;
		}
		public ThemesProduct()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			string text = this.textBox_0.Text.Trim();
			if (Convert.ToInt32(this.textBox_0.Text.Trim()) > Convert.ToInt32(this.label_0.Text))
			{
				this.textBox_0.Text = this.label_0.Text;
				text = this.label_0.Text;
			}
			this.Page.Response.Redirect(string.Concat(new string[]
			{
				this.string_1,
				"?memberid=",
				this.memberid,
				"&pageid=",
				text
			}));
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("pageDiv");
			this.label_0 = (Label)skin.FindControl("LabelPageCount");
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxIndex");
			this.button_0 = (Button)skin.FindControl("ButtonSure");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.image_0 = (Image)skin.FindControl("ImageTheme");
			this.htmlInputHidden_0 = (HtmlInputHidden)skin.FindControl("HiddenEndDate");
			this.themeguid = ((ShopNum1.Common.Common.ReqStr("themeguid") == "") ? "-1" : ShopNum1.Common.Common.ReqStr("themeguid"));
			this.int_0 = 1;
			try
			{
				this.int_0 = int.Parse(ShopNum1.Common.Common.ReqStr("PageID"));
			}
			catch
			{
				this.int_0 = 1;
			}
			if (this.Page.IsPostBack)
			{
			}
			this.BindData();
		}
		protected void BindData()
		{
			string condition = string.Empty;
			if (this.themeguid != "-1")
			{
				condition = " and B.IsAudit=1 and ThemeGuid='" + this.themeguid + "'";
			}
			PageList1 pageList = new PageList1();
			pageList.PageSize = this.ShowCount;
			pageList.PageID = this.int_0;
			ShopNum1_Activity_Action shopNum1_Activity_Action = (ShopNum1_Activity_Action)LogicFactory.CreateShopNum1_Activity_Action();
			DataTable dataTable = shopNum1_Activity_Action.SelectThemeProductByGuid(this.ShowCount.ToString(), this.int_0.ToString(), condition, "0");
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				pageList.RecordCount = Convert.ToInt32(dataTable.Rows[0][0]);
			}
			else
			{
				pageList.RecordCount = 0;
			}
			PageListBll pageListBll = new PageListBll("ThemesProduct", true);
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
			DataTable dataTable2 = shopNum1_Activity_Action.SelectThemeProductByGuid(this.ShowCount.ToString(), this.int_0.ToString(), condition, "1");
			if (dataTable2 != null && dataTable2.Rows.Count > 0)
			{
				this.image_0.ImageUrl = dataTable2.Rows[0]["ThemeImage"].ToString();
				this.image_0.Visible = true;
				this.htmlInputHidden_0.Value = dataTable2.Rows[0]["EndDate"].ToString();
				this.repeater_0.DataSource = dataTable2;
				this.repeater_0.DataBind();
			}
		}
	}
}
