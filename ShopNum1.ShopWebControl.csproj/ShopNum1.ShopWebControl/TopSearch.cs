using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class TopSearch : BaseWebControl
	{
		private string string_0 = "TopSearch.ascx";
		private TextBox textBox_0;
		private Button button_0;
		private Button button_1;
		public TopSearch()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxSearchWhere");
			this.button_0 = (Button)skin.FindControl("ButtonAllSearch");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.button_1 = (Button)skin.FindControl("ButtonIn");
			this.button_1.Click += new EventHandler(this.button_1_Click);
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect(GetPageName.RetDomainUrl("Search_productlist", this.textBox_0.Text, "search"));
		}
		private void button_1_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect(GetPageName.RetUrl("ProductSearchList", this.textBox_0.Text, "keywords"));
		}
	}
}
