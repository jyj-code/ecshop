using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class HelpDetail : BaseWebControl
	{
		private string string_0 = "HelpDetail.ascx";
		private Repeater repeater_0;
		private Button button_0;
		private TextBox textBox_0;
		private Label label_0;
		private string string_1;
		public HelpDetail()
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
			this.label_0 = (Label)skin.FindControl("LabelHelp");
			if (!this.Page.IsPostBack)
			{
			}
			try
			{
				string nameById = ShopNum1.Common.Common.GetNameById("HelpTypeGuid", "ShopNum1_Help", "  AND  Guid='" + this.Page.Request.QueryString["guid"].ToString() + "'");
				string nameById2 = ShopNum1.Common.Common.GetNameById("Name", "ShopNum1_HelpType", "  AND   Guid='" + nameById + "'");
				this.label_0.Text = nameById2;
			}
			catch (Exception)
			{
				this.label_0.Text = "帮助内容";
			}
			this.method_0();
		}
		private void method_0()
		{
			ShopNum1_Help_Action shopNum1_Help_Action = (ShopNum1_Help_Action)LogicFactory.CreateShopNum1_Help_Action();
			DataTable dataTable = shopNum1_Help_Action.SearchRemark(this.Page.Request.QueryString["guid"].ToString(), 0);
			if (dataTable.Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataTable.DefaultView;
				this.repeater_0.DataBind();
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
