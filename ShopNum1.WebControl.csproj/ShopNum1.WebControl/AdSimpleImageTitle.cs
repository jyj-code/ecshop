using ShopNum1.AdXml;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class AdSimpleImageTitle : BaseWebControl
	{
		private string string_0 = "AdSimpleImageTitle.ascx";
		private Image image_0;
		private HtmlAnchor htmlAnchor_0;
		private HtmlAnchor htmlAnchor_1;
		[CompilerGenerated]
		private string string_1;
		public string AdImgId
		{
			get;
			set;
		}
		public AdSimpleImageTitle()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.image_0 = (Image)skin.FindControl("ImageAd");
			this.htmlAnchor_0 = (HtmlAnchor)skin.FindControl("Imglink");
			this.htmlAnchor_1 = (HtmlAnchor)skin.FindControl("TitleLink");
			DataTable dataTable = DefaultAdvertismentOperate.SelecByID(this.AdImgId);
			if (dataTable != null && dataTable.Rows.Count != 0)
			{
				if (this.image_0 != null)
				{
					this.image_0.ImageUrl = dataTable.Rows[0]["imgSrc"].ToString();
					this.image_0.Width = Convert.ToInt32(dataTable.Rows[0]["width"]);
					this.image_0.Height = Convert.ToInt32(dataTable.Rows[0]["height"]);
					this.image_0.ToolTip = dataTable.Rows[0]["id"].ToString();
				}
				if (this.htmlAnchor_0 != null)
				{
					this.htmlAnchor_0.HRef = dataTable.Rows[0]["href"].ToString();
					this.htmlAnchor_0.Attributes.Add("adlink", this.htmlAnchor_0.HRef);
					this.htmlAnchor_0.Title = dataTable.Rows[0]["title"].ToString();
				}
				if (this.htmlAnchor_1 != null)
				{
					this.htmlAnchor_1.HRef = dataTable.Rows[0]["href"].ToString();
					this.htmlAnchor_1.InnerHtml = dataTable.Rows[0]["title"].ToString();
				}
			}
		}
	}
}
