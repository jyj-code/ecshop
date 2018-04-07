using System;
using System.Web.UI.WebControls;
namespace ShopNum1.Control
{
	public class PasswordTextBox : TextBox
	{
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
				base.Attributes["value"] = value;
			}
		}
		public PasswordTextBox()
		{
			this.TextMode = TextBoxMode.Password;
		}
		protected override void OnPreRender(EventArgs eventArgs_0)
		{
			base.OnPreRender(eventArgs_0);
			base.Attributes["value"] = this.Text;
		}
	}
}
