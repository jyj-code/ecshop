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
	public class M_SupplyDemandCommentDetail : BaseMemberWebControl
	{
		private string string_0 = "M_SupplyDemandCommentDetail.ascx";
		private Repeater repeater_0;
		private Button button_0;
		public M_SupplyDemandCommentDetail()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShow");
			this.button_0 = (Button)skin.FindControl("ButtonGoBack");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			if (this.Page.Request.QueryString["guid"] != null)
			{
				this.GetData(this.Page.Request.QueryString["guid"].ToString());
			}
		}
		public void GetData(string guid)
		{
			ShopNum1_SupplyDemandComment_Action shopNum1_SupplyDemandComment_Action = (ShopNum1_SupplyDemandComment_Action)LogicFactory.CreateShopNum1_SupplyDemandComment_Action();
			DataTable dataTable = shopNum1_SupplyDemandComment_Action.SearchByGuid("'" + guid + "'");
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataTable.DefaultView;
				this.repeater_0.DataBind();
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect("M_Comment.aspx?type=0&pageid=1");
		}
	}
}
