using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.MemberWebControl
{
	[ParseChildren(true)]
	public class M_ComplaintsDetailed : BaseMemberWebControl
	{
		private string string_0 = "M_ComplaintsDetailed.ascx";
		private Repeater repeater_0;
		private Button button_0;
		public M_ComplaintsDetailed()
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
			this.Page.Response.Redirect("M_Complaints.aspx");
		}
		public void BindData(string ID)
		{
			ShopNum1_OrderComplaintsReplyList_Action shopNum1_OrderComplaintsReplyList_Action = (ShopNum1_OrderComplaintsReplyList_Action)LogicFactory.CreateShopNum1_OrderComplaintsReplyList_Action();
			DataTable dataTable = shopNum1_OrderComplaintsReplyList_Action.SearchComplaint(ID);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataTable.DefaultView;
				this.repeater_0.DataBind();
			}
		}
	}
}
