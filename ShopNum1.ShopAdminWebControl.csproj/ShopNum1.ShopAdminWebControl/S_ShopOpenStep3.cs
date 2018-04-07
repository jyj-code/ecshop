using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_ShopOpenStep3 : BaseMemberWebControl
	{
		private string string_0 = "S_ShopOpenStep3.ascx";
		private Label label_0;
		private HtmlGenericControl htmlGenericControl_0;
		private Label label_1;
		private Label label_2;
		private Label label_3;
		private HtmlGenericControl htmlGenericControl_1;
		private HtmlGenericControl htmlGenericControl_2;
		public S_ShopOpenStep3()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlGenericControl_2 = (HtmlGenericControl)skin.FindControl("OpenLink");
			this.label_0 = (Label)skin.FindControl("LabelShow");
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("showCss");
			this.htmlGenericControl_1 = (HtmlGenericControl)skin.FindControl("showFailedReason");
			this.label_1 = (Label)skin.FindControl("LabelOperateUser");
			this.label_2 = (Label)skin.FindControl("LabelAuditTime");
			this.label_3 = (Label)skin.FindControl("LabelAuditFailedReason");
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
			DataTable shopByMemLoginID = shopNum1_ShopInfoList_Action.GetShopByMemLoginID(this.MemLoginID);
			int num = 0;
			if (shopByMemLoginID != null && shopByMemLoginID.Rows.Count > 0)
			{
				num = Convert.ToInt32(shopByMemLoginID.Rows[0]["IsAudit"].ToString());
				this.label_1.Text = shopByMemLoginID.Rows[0]["OperateUser"].ToString();
				this.label_2.Text = shopByMemLoginID.Rows[0]["AuditTime"].ToString();
				this.label_3.Text = shopByMemLoginID.Rows[0]["AuditFailedReason"].ToString();
			}
			if (num == 2)
			{
				this.htmlGenericControl_1.Visible = true;
				this.htmlGenericControl_2.Visible = false;
				this.label_0.Text = "店铺审核未通过！";
				this.htmlGenericControl_0.Attributes["class"] = "dianpsh1";
			}
		}
	}
}
