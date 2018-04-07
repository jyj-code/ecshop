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
	public class CategoryInfoMeto : BaseWebControl
	{
		private string string_0 = "CategoryInfoMeto.ascx";
		private Literal literal_0;
		private Literal literal_1;
		private Literal literal_2;
		public CategoryInfoMeto()
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
			ShopNum1_CategoryChecked_Action shopNum1_CategoryChecked_Action = (ShopNum1_CategoryChecked_Action)LogicFactory.CreateShopNum1_CategoryChecked_Action();
			string text = (this.Page.Request.QueryString["guid"] == null) ? "0" : this.Page.Request.QueryString["guid"];
			if (text != "0")
			{
				DataTable categoryInfoMeto = shopNum1_CategoryChecked_Action.GetCategoryInfoMeto(text);
				if (categoryInfoMeto.Rows.Count > 0)
				{
					this.literal_0.Text = "\n<title>" + categoryInfoMeto.Rows[0]["Title"].ToString() + ShopNum1.Common.Common.GetCopyright() + "</title>\n";
					if (categoryInfoMeto.Rows[0]["Keywords"].ToString() != string.Empty)
					{
						this.literal_1.Text = "<meta name=\"Keywords\" content=\"" + categoryInfoMeto.Rows[0]["Keywords"].ToString() + ShopNum1.Common.Common.GetCopyright() + "\">\n";
					}
					else
					{
						this.literal_1.Text = "<meta name=\"Keywords\" content=\"" + categoryInfoMeto.Rows[0]["Title"].ToString() + ShopNum1.Common.Common.GetCopyright() + "\">\n";
					}
					if (categoryInfoMeto.Rows[0]["Description"].ToString() != string.Empty)
					{
						this.literal_2.Text = "<meta name=\"description\" content=\"" + categoryInfoMeto.Rows[0]["Description"].ToString() + "\">\n";
					}
					else
					{
						this.literal_2.Text = "<meta name=\"description\" content=\"" + categoryInfoMeto.Rows[0]["Title"].ToString() + ShopNum1.Common.Common.GetCopyright() + "\">\n";
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
