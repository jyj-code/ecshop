using ShopNum1.MultiBaseWebControl;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopAdminWebControl
{
	[ParseChildren(true)]
	public class S_ShopInfo_Company : BaseShopWebControl
	{
		private string string_0 = "S_ShopInfo_Company.ascx";
		private TextBox textBox_0;
		private TextBox textBox_1;
		private TextBox textBox_2;
		private TextBox textBox_3;
		private TextBox textBox_4;
		private TextBox textBox_5;
		private Button button_0;
		public S_ShopInfo_Company()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxCompanName");
			this.textBox_1 = (TextBox)skin.FindControl("TextBoxLegalPerson");
			this.textBox_2 = (TextBox)skin.FindControl("TextBoxRegistrationNum");
			this.textBox_3 = (TextBox)skin.FindControl("TextBoxBusinessTerm");
			this.textBox_4 = (TextBox)skin.FindControl("TextBoxBusinessScope");
			this.textBox_5 = (TextBox)skin.FindControl("TextBoxBusinessLicense");
			this.button_0 = (Button)skin.FindControl("ButtonSave");
			this.button_0.Click += new EventHandler(this.button_0_Click);
		}
		private void button_0_Click(object sender, EventArgs e)
		{
		}
	}
}
