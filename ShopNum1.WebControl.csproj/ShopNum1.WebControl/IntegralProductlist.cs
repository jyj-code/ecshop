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
	public class IntegralProductlist : BaseWebControl
	{
		private string string_0 = "IntegralProductlist.ascx";
		private string string_1 = "all";
		private Repeater repeater_0;
		private TextBox textBox_0;
		private HtmlGenericControl htmlGenericControl_0;
		private Label label_0;
		private Button button_0;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		public string ShowCount
		{
			get;
			set;
		}
		public string pageID
		{
			get;
			set;
		}
		public IntegralProductlist()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.button_0 = (Button)skin.FindControl("ButtonSure");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			if (this.Page.Request.QueryString["SubstationID"] != null && !string.IsNullOrEmpty(this.Page.Request.QueryString["SubstationID"].ToString()))
			{
				this.string_1 = this.Page.Request.QueryString["SubstationID"].ToString();
			}
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxIndex");
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterProductShow");
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("pageDiv");
			this.label_0 = (Label)skin.FindControl("LabelPageCount");
			this.method_0();
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(this.textBox_0.Text))
			{
				this.Page.Response.Redirect("integral.aspx?tag=" + this.Page.Request.QueryString["tag"].ToString() + "&pageid=" + this.textBox_0.Text.Trim());
			}
		}
		private void method_0()
		{
			int num;
			if (this.Page.Request.QueryString["PageID"] != null && !string.IsNullOrEmpty(this.Page.Request.QueryString["PageID"].ToString()))
			{
				num = Convert.ToInt32(this.Page.Request.QueryString["PageID"].ToString());
			}
			else
			{
				num = 1;
			}
			ShopNum1_Shop_ScoreProduct_Action shopNum1_Shop_ScoreProduct_Action = (ShopNum1_Shop_ScoreProduct_Action)LogicFactory.CreateShopNum1_Shop_ScoreProduct_Action();
			string searchwhere = " and  0=0   ";
			if (this.string_1 != "all")
			{
				searchwhere = "  AND  SubstationID='" + this.string_1 + "'    ";
			}
			PageList1 pageList = new PageList1();
			pageList.PageSize = Convert.ToInt32(this.ShowCount);
			pageList.PageID = num;
			DataTable dataTable = shopNum1_Shop_ScoreProduct_Action.SearchScoreProductList("OrderID", "DESC", this.ShowCount, num.ToString(), "1", searchwhere).Tables[0];
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				pageList.RecordCount = Convert.ToInt32(dataTable.Rows[0][0].ToString());
			}
			else
			{
				pageList.RecordCount = 0;
			}
			PageListBll pageListBll = new PageListBll("Integral", true);
			pageListBll.ShowRecordCount = true;
			pageListBll.ShowPageCount = false;
			pageListBll.ShowPageIndex = false;
			pageListBll.ShowRecordCount = false;
			pageListBll.ShowNoRecordInfo = false;
			pageListBll.ShowNumListButton = true;
			pageListBll.PrevPageText = "上一页";
			pageListBll.NextPageText = "下一页 ";
			this.textBox_0.Text = num.ToString();
			this.htmlGenericControl_0.InnerHtml = pageListBll.GetPageListVk(pageList);
			this.label_0.Text = pageList.PageCount.ToString();
			if ((double)pageList.PageCount < (double)pageList.RecordCount / (double)pageList.PageSize)
			{
				pageList.PageCount++;
			}
			if (num > pageList.PageCount)
			{
				num = pageList.PageCount;
			}
			DataTable dataTable2 = shopNum1_Shop_ScoreProduct_Action.SearchScoreProductList("OrderID", "DESC", this.ShowCount, num.ToString(), "0", searchwhere).Tables[0];
			if (dataTable2 != null && dataTable2.Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataTable2.DefaultView;
				this.repeater_0.DataBind();
			}
		}
	}
}
