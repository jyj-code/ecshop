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
	public class AdSimpleImage : BaseWebControl
	{
		private string string_0 = "AdSimpleImage.ascx";
		private Image image_0;
		private HtmlAnchor htmlAnchor_0;
		private string string_1 = "all";
		[CompilerGenerated]
		private string string_2;
		public string AdImgId
		{
			get;
			set;
		}
		public AdSimpleImage()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			if (this.Page.Request.QueryString["SubstationID"] != null && !string.IsNullOrEmpty(this.Page.Request.QueryString["SubstationID"].ToString()))
			{
				this.string_1 = this.Page.Request.QueryString["SubstationID"].ToString();
			}
			this.image_0 = (Image)skin.FindControl("ImageAd");
			this.htmlAnchor_0 = (HtmlAnchor)skin.FindControl("Imglink");
			DefaultAdvertismentOperate.xmlDataTable = null;
			DataTable dataTable;
			if (this.string_1 == "all")
			{
				dataTable = DefaultAdvertismentOperate.SelecByID(this.AdImgId);
			}
			else
			{
				dataTable = DefaultAdvertismentOperate.SelecByID(this.AdImgId, this.string_1);
			}
			if (dataTable != null && dataTable.Rows.Count != 0)
			{
				this.image_0.ImageUrl = dataTable.Rows[0]["imgSrc"].ToString();
				if (dataTable.Rows[0]["width"].ToString() != "")
				{
					this.image_0.Width = Convert.ToInt32(dataTable.Rows[0]["width"]);
				}
				this.image_0.Height = Convert.ToInt32(dataTable.Rows[0]["height"]);
				this.htmlAnchor_0.HRef = dataTable.Rows[0]["href"].ToString();
				this.htmlAnchor_0.Attributes.Add("adlink", this.htmlAnchor_0.HRef);
			}
		}
	}
}
