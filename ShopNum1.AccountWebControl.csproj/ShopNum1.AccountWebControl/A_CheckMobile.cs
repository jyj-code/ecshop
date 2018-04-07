using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.AccountWebControl
{
	[ParseChildren(true)]
	public class A_CheckMobile : BaseMemberWebControl
	{
		private string string_0 = "A_CheckMobile.ascx";
		private HtmlInputText htmlInputText_0;
		private Label label_0;
		private Label label_1;
		public A_CheckMobile()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlInputText_0 = (HtmlInputText)skin.FindControl("M_code");
			this.label_0 = (Label)skin.FindControl("nextmobile");
			this.label_1 = (Label)skin.FindControl("Lab_MemLoginID");
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
			this.label_0.Text = shopNum1_Member_Action.GetAdvancePayment(this.MemLoginID).Rows[0]["Mobile"].ToString();
		}
	}
}
