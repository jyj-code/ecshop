using ShopNum1.MultiBaseWebControl;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.AccountWebControl
{
	[ParseChildren(true)]
	public class A_UpPayPwdSucceed : BaseMemberWebControl
	{
		private string string_0 = "A_UpPayPwdSucceed.ascx";
		private Label label_0;
		private Button button_0;
		public A_UpPayPwdSucceed()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.label_0 = (Label)skin.FindControl("Lab_MemLoginID");
			this.label_0.Text = this.MemLoginID;
		}
	}
}
