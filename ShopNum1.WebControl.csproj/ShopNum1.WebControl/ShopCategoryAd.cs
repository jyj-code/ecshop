using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
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
	public class ShopCategoryAd : BaseWebControl
	{
		private string string_0 = "ShopCategoryAd.ascx";
		private Image image_0;
		private HtmlAnchor htmlAnchor_0;
		[CompilerGenerated]
		private string string_1;
		public string AdID
		{
			get;
			set;
		}
		public ShopCategoryAd()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			string categorycode = (this.Page.Request.QueryString["code"] == null) ? "-1" : this.Page.Request.QueryString["code"];
			this.image_0 = (Image)skin.FindControl("ImageCategoryInfoAd");
			this.htmlAnchor_0 = (HtmlAnchor)skin.FindControl("ACategoryInfoAd");
			ShopNum1_CategoryAdPayMent_Action shopNum1_CategoryAdPayMent_Action = (ShopNum1_CategoryAdPayMent_Action)LogicFactory.CreateShopNum1_CategoryAdPayMent_Action();
			DataTable dataTable = shopNum1_CategoryAdPayMent_Action.SearchAdInfo(this.AdID, categorycode, "4");
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				if (dataTable.Rows[0]["AdvertisementPic"].ToString() != string.Empty)
				{
					this.image_0.ImageUrl = this.Page.ResolveUrl("~/ImgUpload/MemberImg/CategoryAdImg/" + dataTable.Rows[0]["AdvertisementPic"].ToString());
					this.htmlAnchor_0.HRef = dataTable.Rows[0]["AdvertisementLike"].ToString();
					this.htmlAnchor_0.Title = dataTable.Rows[0]["AdvertisementContent"].ToString();
				}
				else if (dataTable.Rows[0]["AdvertisementDPic"].ToString() != string.Empty)
				{
					this.image_0.ImageUrl = this.Page.ResolveUrl("~/ImgUpload/" + dataTable.Rows[0]["AdvertisementDPic"].ToString());
					this.htmlAnchor_0.HRef = dataTable.Rows[0]["AdDefaultLike"].ToString();
					this.htmlAnchor_0.Title = dataTable.Rows[0]["AdIntroduce"].ToString();
				}
				else
				{
					this.image_0.ImageUrl = this.Page.ResolveUrl("~/ImgUpload/" + dataTable.Rows[0]["CategoryAdDefalutPic"].ToString());
					this.htmlAnchor_0.HRef = dataTable.Rows[0]["CategoryAdDefalutLike"].ToString();
					this.htmlAnchor_0.Title = dataTable.Rows[0]["CategoryAdIntroduce"].ToString();
				}
				this.image_0.Style.Add(HtmlTextWriterStyle.Height, dataTable.Rows[0]["Height"].ToString() + "px");
				this.image_0.Style.Add(HtmlTextWriterStyle.Width, dataTable.Rows[0]["Width"].ToString() + "px");
			}
			else
			{
				DataTable dataTable2 = shopNum1_CategoryAdPayMent_Action.SearchAdInfo(this.AdID, "4");
				if (dataTable2 != null && dataTable2.Rows.Count > 0)
				{
					this.image_0.ImageUrl = this.Page.ResolveUrl("~/ImgUpload/" + dataTable2.Rows[0]["CategoryAdDefalutPic"].ToString());
					this.htmlAnchor_0.HRef = dataTable2.Rows[0]["CategoryAdDefalutLike"].ToString();
					this.htmlAnchor_0.Title = dataTable2.Rows[0]["CategoryAdIntroduce"].ToString();
					this.image_0.Style.Add(HtmlTextWriterStyle.Height, dataTable2.Rows[0]["Height"].ToString() + "px");
					this.image_0.Style.Add(HtmlTextWriterStyle.Width, dataTable2.Rows[0]["Width"].ToString() + "px");
				}
				else
				{
					this.image_0.Visible = false;
					this.htmlAnchor_0.Visible = false;
				}
			}
		}
	}
}
