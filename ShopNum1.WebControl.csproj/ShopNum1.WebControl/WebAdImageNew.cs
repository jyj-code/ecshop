using ShopNum1.AdXml;
using ShopNum1.BusinessLogic;
using ShopNum1.CityFactory;
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
	public class WebAdImageNew : BaseWebControl
	{
		private string string_0 = "WebAdImage.ascx";
		private HtmlAnchor htmlAnchor_0;
		private Image image_0;
		private string string_1 = "all";
		private DefaultAdvertPayOperateNoPath defaultAdvertPayOperateNoPath_0 = new DefaultAdvertPayOperateNoPath();
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		public string AdID
		{
			get;
			set;
		}
		public string String_0
		{
			get;
			set;
		}
		public WebAdImageNew()
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
			this.htmlAnchor_0 = (HtmlAnchor)skin.FindControl("NewImageID");
			this.image_0 = (Image)skin.FindControl("Images");
			this.GetUserData();
		}
		public void GetUserData()
		{
			if (this.string_1 == "all")
			{
				this.defaultAdvertPayOperateNoPath_0.Path = "~/Main/Themes/Skin_Default/Xml/PayAdImage.xml";
			}
			else
			{
				this.defaultAdvertPayOperateNoPath_0.Path = "~/City/" + this.string_1 + "/Themes/Skin_Default/Xml/PayAdImage.xml";
			}
			DataTable dataTable = null;
			try
			{
				dataTable = this.defaultAdvertPayOperateNoPath_0.SelecByID(this.AdID);
			}
			catch (Exception)
			{
				dataTable = null;
			}
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				this.image_0.Width = Unit.Pixel(Convert.ToInt32(dataTable.Rows[0]["width"].ToString()));
				this.image_0.Height = Unit.Pixel(Convert.ToInt32(dataTable.Rows[0]["height"].ToString()));
				this.image_0.ImageUrl = dataTable.Rows[0]["DefaultImage"].ToString();
				this.htmlAnchor_0.HRef = ((!dataTable.Rows[0]["Href"].ToString().StartsWith("http://")) ? ("http://" + dataTable.Rows[0]["Href"].ToString()) : dataTable.Rows[0]["Href"].ToString());
			}
			ShopNum1_SubstationManage_Action shopNum1_SubstationManage_Action = (ShopNum1_SubstationManage_Action)LogicFactory.CreateShopNum1_SubstationManage_Action();
			DataTable dataBySubstationID = shopNum1_SubstationManage_Action.GetDataBySubstationID(this.string_1);
			if (dataBySubstationID != null && dataBySubstationID.Rows.Count > 0)
			{
				dataBySubstationID.Rows[0]["CityCode"].ToString();
			}
			ShopNum1_AdvertPay_Action shopNum1_AdvertPay_Action = (ShopNum1_AdvertPay_Action)LogicFactory.CreateShopNum1_AdvertPay_Action();
			DataTable dataTable2 = shopNum1_AdvertPay_Action.SearchNowData(this.AdID, 1, this.string_1);
			if (dataTable2 != null && dataTable2.Rows.Count > 0)
			{
				this.image_0.ImageUrl = dataTable2.Rows[0]["Image"].ToString();
				if (dataTable2.Rows[0]["Website"].ToString().StartsWith("http://"))
				{
					this.htmlAnchor_0.Attributes["href"] = dataTable2.Rows[0]["Website"].ToString();
				}
				else
				{
					this.htmlAnchor_0.Attributes["href"] = "http://" + dataTable2.Rows[0]["Website"].ToString();
				}
			}
		}
	}
}
