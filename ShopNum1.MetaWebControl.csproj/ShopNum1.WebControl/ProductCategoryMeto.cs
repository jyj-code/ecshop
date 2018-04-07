using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class ProductCategoryMeto : BaseWebControl
	{
		private string string_0 = "ProductCategoryMeto.ascx";
		private Literal literal_0;
		private Literal literal_1;
		private Literal literal_2;
		public ProductCategoryMeto()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.literal_0 = (Literal)skin.FindControl("LiteralPageTitle");
			this.literal_1 = (Literal)skin.FindControl("LiteralPagekeywords");
			this.literal_2 = (Literal)skin.FindControl("LiteralPagedescription");
			if (this.Page.IsPostBack)
			{
			}
			ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
			string text = (this.Page.Request.QueryString["code"] == null) ? "0" : this.Page.Request.QueryString["code"];
			if (text != "0")
			{
				DataTable productCategoryMeto = shopNum1_ProductCategory_Action.GetProductCategoryMeto(text);
				if (productCategoryMeto.Rows.Count > 0)
				{
					this.literal_0.Text = "\n<title>" + productCategoryMeto.Rows[0]["Name"].ToString() + ShopNum1.Common.Common.GetCopyright() + "</title>\n";
					if (productCategoryMeto.Rows[0]["Keywords"].ToString() != string.Empty)
					{
						this.literal_1.Text = "<meta name=\"Keywords\" content=\"" + productCategoryMeto.Rows[0]["Keywords"].ToString() + ShopNum1.Common.Common.GetCopyright() + "\">\n";
					}
					else
					{
						this.literal_1.Text = "<meta name=\"Keywords\" content=\"" + productCategoryMeto.Rows[0]["Name"].ToString() + ShopNum1.Common.Common.GetCopyright() + "\">\n";
					}
					if (productCategoryMeto.Rows[0]["Description"].ToString() != string.Empty)
					{
						this.literal_2.Text = "<meta name=\"description\" content=\"" + productCategoryMeto.Rows[0]["Description"].ToString() + "\">\n";
					}
					else
					{
						this.literal_2.Text = "<meta name=\"description\" content=\"" + productCategoryMeto.Rows[0]["Name"].ToString() + ShopNum1.Common.Common.GetCopyright() + "\">\n";
					}
				}
			}
		}
		protected override void Render(HtmlTextWriter writer)
		{
			StringWriter stringWriter = new StringWriter();
			HtmlTextWriter writer2 = new HtmlTextWriter(stringWriter);
			this.literal_0.RenderControl(writer2);
			this.literal_1.RenderControl(writer2);
			this.literal_2.RenderControl(writer2);
			writer.Write(stringWriter.ToString());
		}
	}
}
