using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.MemberWebControl
{
	[ParseChildren(true)]
	public class M_SysMsgDetail : BaseMemberWebControl
	{
		private string string_0 = "M_SysMsgDetail.ascx";
		private Label label_0;
		private Label label_1;
		private Label label_2;
		private Label label_3;
		private Literal literal_0;
		public M_SysMsgDetail()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.label_0 = (Label)skin.FindControl("lblTitle");
			this.label_1 = (Label)skin.FindControl("lblSendUser");
			this.label_2 = (Label)skin.FindControl("lblReceiveUser");
			this.label_3 = (Label)skin.FindControl("lblDate");
			this.literal_0 = (Literal)skin.FindControl("LitContent");
			if (!this.Page.IsPostBack)
			{
				this.method_0();
			}
		}
		private void method_0()
		{
			ShopNum1_MessageInfo shopNum1_MessageInfo = new ShopNum1_MessageInfo();
			ShopNum1_MessageInfo_Action shopNum1_MessageInfo_Action = (ShopNum1_MessageInfo_Action)LogicFactory.CreateShopNum1_MessageInfo_Action();
			if (this.Page.Request.QueryString["guid"] != null)
			{
				shopNum1_MessageInfo.Guid = new Guid(ShopNum1.Common.Common.ReqStr("Guid").ToString());
				DataTable dataTable = shopNum1_MessageInfo_Action.Search("'" + ShopNum1.Common.Common.ReqStr("Guid").ToString() + "'");
				if (dataTable.Rows.Count > 0)
				{
					this.label_0.Text = dataTable.Rows[0]["Title"].ToString();
					this.label_1.Text = dataTable.Rows[0]["SendID"].ToString();
					this.label_2.Text = dataTable.Rows[0]["ReceiveID"].ToString();
					this.label_3.Text = dataTable.Rows[0]["SendTime"].ToString();
					this.literal_0.Text = dataTable.Rows[0]["Content"].ToString();
				}
			}
			if (ShopNum1.Common.Common.ReqStr("isread") != "1")
			{
				shopNum1_MessageInfo_Action.Update_SysUserMsgIsRead(ShopNum1.Common.Common.ReqStr("Guid").ToString());
			}
		}
	}
}
