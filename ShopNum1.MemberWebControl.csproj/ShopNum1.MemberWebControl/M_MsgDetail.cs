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
	public class M_MsgDetail : BaseMemberWebControl
	{
		private string string_0 = "M_MsgDetail.ascx";
		private Label label_0;
		private Label label_1;
		private Label label_2;
		private Label label_3;
		private Literal literal_0;
		public M_MsgDetail()
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
			ShopNum1_MemberMessage shopNum1_MemberMessage = new ShopNum1_MemberMessage();
			ShopNum1_MemberMessage_Action shopNum1_MemberMessage_Action = (ShopNum1_MemberMessage_Action)LogicFactory.CreateShopNum1_MemberMessage_Action();
			if (this.Page.Request.QueryString["guid"] != null)
			{
				shopNum1_MemberMessage.IsRead = new int?(Convert.ToInt32(ShopNum1.Common.Common.ReqStr("isread")));
				shopNum1_MemberMessage.Guid = new Guid(ShopNum1.Common.Common.ReqStr("Guid").ToString());
				DataTable dataTable = shopNum1_MemberMessage_Action.SelectMsg(shopNum1_MemberMessage);
				if (dataTable.Rows.Count > 0)
				{
					this.label_0.Text = Operator.FilterString(dataTable.Rows[0]["title"].ToString());
					this.label_1.Text = dataTable.Rows[0]["sendloginID"].ToString();
					this.label_2.Text = dataTable.Rows[0]["reLoginID"].ToString();
					this.label_3.Text = dataTable.Rows[0]["SendTime"].ToString();
					this.literal_0.Text = Operator.FilterString(dataTable.Rows[0]["Content"].ToString());
				}
			}
			if (ShopNum1.Common.Common.ReqStr("isread") != "1" && this.Page.Request.QueryString["isread"] != null && this.Page.Request.QueryString["isread"] != "2")
			{
				shopNum1_MemberMessage_Action.Update_MsgIsRead(ShopNum1.Common.Common.ReqStr("Guid").ToString());
			}
		}
	}
}
