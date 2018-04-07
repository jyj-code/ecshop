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
	public class S_ZtcApply_Detail : BaseMemberWebControl
	{
		private string string_0 = "S_ZtcApply_Detail.ascx";
		private Repeater repeater_0;
		private Button button_0;
		public S_ZtcApply_Detail()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.button_0 = (Button)skin.FindControl("ButtonBackList");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShow");
			if (this.Page.Request.QueryString["guid"] != null)
			{
				this.GetDataInfo();
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect("S_ZtcApply_List.aspx");
		}
		public void GetDataInfo()
		{
			ShopNum1_ZtcApply_Action shopNum1_ZtcApply_Action = (ShopNum1_ZtcApply_Action)LogicFactory.CreateShopNum1_ZtcApply_Action();
			DataTable infoByGuid = shopNum1_ZtcApply_Action.GetInfoByGuid(this.Page.Request.QueryString["guid"].ToString());
			if (infoByGuid != null && infoByGuid.Rows.Count > 0)
			{
				this.repeater_0.DataSource = infoByGuid.DefaultView;
				this.repeater_0.DataBind();
			}
		}
	}
}
