using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.AccountWebControl
{
	[ParseChildren(true)]
	public class A_CheckEmail : BaseMemberWebControl
	{
		private string string_0 = "A_CheckEmail.ascx";
		private Label label_0;
		private Label label_1;
		public A_CheckEmail()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.label_0 = (Label)skin.FindControl("nextEmail");
			this.label_1 = (Label)skin.FindControl("Lab_MemLoginID");
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
			this.label_0.Text = shopNum1_Member_Action.GetAdvancePayment(this.MemLoginID).Rows[0]["Email"].ToString();
		}
	}
}
