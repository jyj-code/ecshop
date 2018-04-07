using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class ProduceSearch : BaseWebControl
	{
		private string string_0 = "ProduceSearch.ascx";
		private TextBox textBox_0;
		private TextBox textBox_1;
		private TextBox textBox_2;
		private Button button_0;
		[CompilerGenerated]
		private string string_1;
		public string MemLoginID
		{
			get;
			set;
		}
		public ProduceSearch()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			string memloginId = (this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString();
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = new ShopNum1_ShopInfoList_Action();
			this.MemLoginID = shopNum1_ShopInfoList_Action.GetShopMemLoginIdByShopID(memloginId).ToString();
			this.textBox_0 = (TextBox)skin.FindControl("TextBoxKeywordsSearch");
			this.textBox_1 = (TextBox)skin.FindControl("TextBoxPriceStartSearch");
			this.textBox_2 = (TextBox)skin.FindControl("TextBoxPriceEndSearch");
			this.button_0 = (Button)skin.FindControl("ButtonSearch");
			this.button_0.Click += new EventHandler(this.textBox_2_TextChanged);
			this.textBox_0.TextChanged += new EventHandler(this.textBox_2_TextChanged);
			this.textBox_2.TextChanged += new EventHandler(this.textBox_2_TextChanged);
			if (this.Page.IsPostBack)
			{
			}
		}
		private void textBox_2_TextChanged(object sender, EventArgs e)
		{
			string text = string.Empty;
			string text2 = this.textBox_0.Text;
			try
			{
				string text3 = Convert.ToDecimal(this.textBox_1.Text).ToString();
				string text4 = Convert.ToDecimal(this.textBox_2.Text).ToString();
				text = string.Concat(new string[]
				{
					"http://",
					HttpContext.Current.Request.Url.Host,
					"/ProductSearchList.aspx?keywords=",
					text2,
					"&priceStart=",
					text3,
					"&priceEnd=",
					text4
				});
				this.Page.Response.Write("<script>window.location.href='" + text + "';</script>");
			}
			catch (Exception ex)
			{
				if (ex.Message != "ee.Message\tUnable to evaluate expression because the code is optimized or a native frame is on top of the call stack.\tstring")
				{
					MessageBox.Show(ex.Message);
					text = string.Concat(new string[]
					{
						"http://",
						HttpContext.Current.Request.Url.Host,
						"/ProductSearchList.aspx?keywords=",
						text2,
						"&priceStart=&priceEnd="
					});
					this.Page.Response.Redirect(text);
				}
			}
		}
	}
}
