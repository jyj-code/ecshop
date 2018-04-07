using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.MemberWebControl
{
	[ParseChildren(true)]
	public class M_RecommendCommision : BaseMemberWebControl
	{
		private string string_0 = "M_RecommendCommision.ascx";
		private TextBox textBox_0;
		private TextBox textBox_1;
		private Button button_0;
		private Repeater repeater_0;
		private HtmlGenericControl htmlGenericControl_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		public string pageid
		{
			get;
			set;
		}
		public string PageSize
		{
			get;
			set;
		}
		public M_RecommendCommision()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("pageDiv");
			this.pageid = ((ShopNum1.Common.Common.ReqStr("PageID") == "") ? "1" : ShopNum1.Common.Common.ReqStr("PageID"));
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxMemLoginID");
			this.textBox_1 = (TextBox)skin.FindControl("TextBoxOrderNumber");
			this.button_0 = (Button)skin.FindControl("ButtonSearch");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShow");
			this.method_0();
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			this.method_0();
		}
		private void method_0()
		{
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
			string text = string.Empty;
			if (!string.IsNullOrEmpty(this.textBox_0.Text.Trim()))
			{
				text = text + "  AND  MemLoginID=  '" + this.textBox_0.Text.Trim() + "'   ";
			}
			if (!string.IsNullOrEmpty(this.textBox_1.Text.Trim()))
			{
				text = text + "  AND  OrderNumber=  '" + this.textBox_1.Text.Trim() + "'   ";
			}
			CommonPageModel commonPageModel = new CommonPageModel();
			commonPageModel.Tablename = "SELECT  MemLoginID,OrderNumber,RecommendCommision,ReceiptTime  FROM  ShopNum1_OrderInfo WHERE  MemLoginID IN ( SELECT  MemLoginID   FROM ShopNum1_Member  where   PromotionMemLoginID='" + this.MemLoginID + "') AND  OderStatus=3  AND RecommendCommision>0";
			commonPageModel.Condition = "  AND   1=1   " + text + "   ";
			commonPageModel.Currentpage = this.pageid.ToString();
			commonPageModel.Resultnum = "3";
			commonPageModel.PageSize = this.PageSize.ToString();
			DataTable dataTable = shopNum1_Member_Action.SelectRecommendCommision_List(commonPageModel);
			PageList1 pageList = new PageList1();
			pageList.PageSize = Convert.ToInt32(this.PageSize);
			pageList.PageID = Convert.ToInt32(this.pageid.ToString());
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				pageList.RecordCount = Convert.ToInt32(dataTable.Rows[0][0]);
			}
			else
			{
				pageList.RecordCount = 0;
			}
			PageListBll pageListBll = new PageListBll("main/member/M_RecommendCommision.aspx", true);
			this.htmlGenericControl_0.InnerHtml = pageListBll.GetPageListNew(pageList);
			commonPageModel.Resultnum = "2";
			DataTable dataTable2 = shopNum1_Member_Action.SelectRecommendCommision_List(commonPageModel);
			this.repeater_0.DataSource = dataTable2.DefaultView;
			this.repeater_0.DataBind();
		}
	}
}
