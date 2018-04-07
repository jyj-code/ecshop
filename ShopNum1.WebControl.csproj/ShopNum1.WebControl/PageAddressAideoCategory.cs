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
	public class PageAddressAideoCategory : BaseWebControl
	{
		private string string_0 = "PageAddress.ascx";
		private Literal literal_0;
		[CompilerGenerated]
		private string string_1;
		public string Guids
		{
			get;
			set;
		}
		public PageAddressAideoCategory()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.Guids = ((this.Page.Request.QueryString["categoryid"] == null) ? "0" : this.Page.Request.QueryString["categoryid"]);
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
			stringBuilder.Append(PageAddressAideoCategory.RenderControl(htmlAnchor));
			ShopNum1_PageAddress_Action shopNum1_PageAddress_Action = (ShopNum1_PageAddress_Action)LogicFactory.CreateShopNum1_PageAddress_Action();
			DataTable videoCategoryPageAddress = shopNum1_PageAddress_Action.GetVideoCategoryPageAddress(this.Guids);
			for (int i = 0; i < videoCategoryPageAddress.Rows.Count; i++)
			{
				htmlAnchor.InnerText = videoCategoryPageAddress.Rows[i]["Name"].ToString();
				htmlAnchor.HRef = GetPageName.RetUrl("VideoSearchList", videoCategoryPageAddress.Rows[i]["ID"].ToString(), "categoryid");
				stringBuilder.Append("&nbsp;&gt;&nbsp;" + PageAddressAideoCategory.RenderControl(htmlAnchor));
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
