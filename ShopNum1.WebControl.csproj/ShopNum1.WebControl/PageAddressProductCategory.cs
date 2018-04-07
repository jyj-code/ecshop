using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class PageAddressProductCategory : BaseWebControl
	{
		private string string_0 = "PageAddress.ascx";
		private Literal literal_0;
		[CompilerGenerated]
		private string string_1;
		public string ProductCategoryID
		{
			get;
			set;
		}
		public PageAddressProductCategory()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.ProductCategoryID = ((this.Page.Request.QueryString["ProductCategoryID"] == null) ? "0" : this.Page.Request.QueryString["ProductCategoryID"]);
			this.literal_0 = (Literal)skin.FindControl("PageAddress");
			if (this.Page.IsPostBack)
			{
			}
			this.Bind();
		}
		public void Bind()
		{
			StringBuilder stringBuilder = new StringBuilder();
			HtmlAnchor htmlAnchor = new HtmlAnchor();
			htmlAnchor.InnerText = "首页";
			htmlAnchor.HRef = "http://" + this.Page.Request.Url.Host + "/";
			stringBuilder.Append(PageAddressProductCategory.RenderControl(htmlAnchor));
			ShopNum1_PageAddress_Action shopNum1_PageAddress_Action = (ShopNum1_PageAddress_Action)LogicFactory.CreateShopNum1_PageAddress_Action();
			DataTable productCategoryPageAddress = shopNum1_PageAddress_Action.GetProductCategoryPageAddress(this.ProductCategoryID);
			for (int i = 0; i < productCategoryPageAddress.Rows.Count; i++)
			{
				htmlAnchor.InnerText = productCategoryPageAddress.Rows[i]["Name"].ToString();
				htmlAnchor.HRef = GetPageName.RetUrl("ProductListCategory", productCategoryPageAddress.Rows[i]["ID"].ToString(), "ProductCategoryID");
				stringBuilder.Append("&nbsp;&gt;&nbsp;" + PageAddressProductCategory.RenderControl(htmlAnchor));
			}
			this.literal_0.Text = stringBuilder.ToString();
		}
		public static string RenderControl(System.Web.UI.Control control)
		{
			StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture);
			HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
			control.RenderControl(htmlTextWriter);
			htmlTextWriter.Flush();
			htmlTextWriter.Close();
			return stringWriter.ToString();
		}
	}
}
