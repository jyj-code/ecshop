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
	public class A_PwdSer : BaseMemberWebControl
	{
		private string string_0 = "A_PwdSer.ascx";
		private Label label_0;
		private Label label_1;
		private Image image_0;
		private LinkButton linkButton_0;
		private LinkButton linkButton_1;
		private LinkButton linkButton_2;
		private HiddenField hiddenField_0;
		public A_PwdSer()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.label_0 = (Label)skin.FindControl("Lab_SafeRank");
			this.label_1 = (Label)skin.FindControl("Lab_SafeRankTitle");
			this.image_0 = (Image)skin.FindControl("Image_SafeRankImg");
			this.linkButton_0 = (LinkButton)skin.FindControl("LinkButton_Mobile");
			this.linkButton_1 = (LinkButton)skin.FindControl("LinkButton_Email");
			this.linkButton_2 = (LinkButton)skin.FindControl("LinkButton_Set");
			this.hiddenField_0 = (HiddenField)skin.FindControl("hfTradePwd");
			ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
			DataTable dataTable = new DataTable();
			try
			{
				dataTable = shopNum1_Member_Action.CheckSafeRank(this.MemLoginID, "and");
				if (dataTable.Rows.Count > 0)
				{
					this.label_0.Text = "高";
					this.label_1.Text = "账号已经设置了交易密码和手机绑定，请保管好手机，交易密码可重置";
					this.image_0.ImageUrl = "/Main/Account/images/jidongt03.jpg";
					this.linkButton_0.Visible = false;
					this.linkButton_1.Visible = false;
				}
				else
				{
					dataTable = shopNum1_Member_Action.CheckSafeRank(this.MemLoginID, "or");
					if (dataTable.Rows.Count > 0)
					{
						this.label_0.Text = "中";
						this.label_1.Text = "账号已经设置了交易密码和手机绑定，请保管好手机，交易密码可重置";
						this.image_0.ImageUrl = "/Main/Account/images/jidongt02.jpg";
						string a = dataTable.Rows[0]["IsEmailActivation"].ToString();
						string a2 = dataTable.Rows[0]["IsMobileActivation"].ToString();
						if (a != "1")
						{
							this.label_1.Text = "您的账户安全级别一般，为确保您账户安全，请您尽快提高安全等级，绑定邮箱";
							this.linkButton_1.Visible = true;
							this.linkButton_0.Visible = false;
						}
						else if (a2 != "1")
						{
							this.label_1.Text = "您的账户安全级别一般，为确保您账户安全，请您尽快提高安全等级，绑定手机号码";
							this.linkButton_0.Visible = true;
							this.linkButton_1.Visible = false;
						}
					}
					else
					{
						this.label_0.Text = "低";
						this.label_1.Text = "您的账户安全级别较低，为确保您账户安全，请您尽快提高安全等级";
						this.image_0.ImageUrl = "/Main/Account/images/jidongt01.jpg";
						this.linkButton_0.Text = "手机绑定|";
						this.linkButton_1.Text = "邮箱绑定";
						this.linkButton_0.Visible = true;
						this.linkButton_1.Visible = true;
						this.hiddenField_0.Value = "0";
					}
				}
			}
			catch
			{
			}
		}
	}
}
