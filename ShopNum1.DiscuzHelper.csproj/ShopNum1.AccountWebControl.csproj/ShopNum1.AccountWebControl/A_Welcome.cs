using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.AccountWebControl
{
	[ParseChildren(true)]
	public class A_Welcome : BaseMemberWebControl
	{
		private string string_0 = "A_Welcome.cs";
		private Repeater repeater_0;
		public A_Welcome()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("Rep_AoccountDetail");
			if (!this.Page.IsPostBack)
			{
				this.method_0();
			}
		}
		private void method_0()
		{
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
			DataTable memberAccount = shopNum1_Member_Action.GetMemberAccount(this.MemLoginID);
			try
			{
				if (memberAccount.Rows.Count > 0)
				{
					this.repeater_0.DataSource = memberAccount;
					this.repeater_0.DataBind();
				}
			}
			catch
			{
			}
		}
	}
}
