using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_ReportDetailed : BaseShopWebControl
	{
		private string string_0 = "S_ReportDetailed.ascx";
		private Repeater repeater_0;
		private Button button_0;
		public S_ReportDetailed()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShow");
			this.button_0 = (Button)skin.FindControl("ButtonBackList");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			if (this.Page.Request.QueryString["ID"] != null)
			{
				this.BindData(this.Page.Request.QueryString["ID"].ToString());
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect("S_MemberReport.aspx");
		}
		public void BindData(string ID)
		{
			ShopNum1_MemberReport_Action shopNum1_MemberReport_Action = (ShopNum1_MemberReport_Action)LogicFactory.CreateShopNum1_MemberReport_Action();
			DataTable reportDetailByID = shopNum1_MemberReport_Action.GetReportDetailByID(ID);
			if (reportDetailByID != null && reportDetailByID.Rows.Count > 0)
			{
				this.repeater_0.DataSource = reportDetailByID.DefaultView;
				this.repeater_0.DataBind();
			}
		}
	}
}
