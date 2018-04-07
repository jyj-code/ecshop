using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class AgentAllSearch : BaseWebControl
	{
		private string string_0 = "AgentAllSearch.ascx";
		private DropDownList dropDownList_0;
		private TextBox textBox_0;
		private Button button_0;
		public AgentAllSearch()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			if (this.Page.Request.QueryString["ShopID"] != null)
			{
				this.Page.Request.QueryString["ShopID"].ToString();
			}
			this.dropDownList_0 = (DropDownList)skin.FindControl("DropDownListType");
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxSearchWhere");
			this.button_0 = (Button)skin.FindControl("ButtonAllSearch");
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.method_0();
		}
		private void button_0_Click(object sender, EventArgs e)
		{
			this.Page.Response.Redirect(this.SetUrl(this.dropDownList_0.SelectedValue + this.textBox_0.Text));
		}
		private void method_0()
		{
			string str = string.Empty;
			if (ShopSettings.IsOverrideUrl)
			{
				str = ShopSettings.overrideUrlName;
			}
			else
			{
				str = ".aspx";
			}
			this.dropDownList_0.Items.Add(new ListItem("商品", "/ProductListSearch" + str + "?search="));
			this.dropDownList_0.Items.Add(new ListItem("店铺", "/ShopListSearch" + str + "?search="));
			this.dropDownList_0.Items.Add(new ListItem("文章", "/ArticleListSearch" + str + "?search="));
			this.dropDownList_0.Items.Add(new ListItem("分类", "/CategoryListSearch" + str + "?search="));
			this.dropDownList_0.Items.Add(new ListItem("供求", "/SupplyDemandListSearch" + str + "?search="));
		}
		public string SetUrl(string page)
		{
			return "http://" + ConfigurationManager.AppSettings["Domain"] + page;
		}
	}
}
