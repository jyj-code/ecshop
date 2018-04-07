using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class HelpListIndex : BaseWebControl
	{
		private string string_0 = "HelpListIndex.ascx";
		private Repeater repeater_0;
		private Button button_0;
		private TextBox textBox_0;
		private string string_1;
		public HelpListIndex()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.button_0 = (Button)skin.FindControl("ButtonAgainSearch");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxSearch");
			if (this.Page.IsPostBack)
			{
			}
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			this.string_1 = ((this.textBox_0.Text.Trim().Replace("'", "") == string.Empty) ? "-1" : this.textBox_0.Text.Trim().Replace("'", ""));
			string url = GetPageName.AgentRetUrl("HelpListSearch", this.string_1, "search");
			this.Page.Response.Redirect(url);
		}
	}
}
