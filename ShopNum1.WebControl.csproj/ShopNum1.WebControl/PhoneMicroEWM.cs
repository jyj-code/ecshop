using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	public class PhoneMicroEWM : BaseWebControl
	{
		private Image image_0;
		private string string_0 = "all";
		private string string_1 = "PhoneMicroEWM.ascx";
		[CompilerGenerated]
		private string string_2;
		public string TypeEWM
		{
			get;
			set;
		}
		public PhoneMicroEWM()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_1;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.image_0 = (Image)skin.FindControl("imgPhoneMicroEWM");
			if (this.Page.Request.QueryString["SubstationID"] != null && !string.IsNullOrEmpty(this.Page.Request.QueryString["SubstationID"].ToString()))
			{
				this.string_0 = this.Page.Request.QueryString["SubstationID"].ToString();
			}
			if (this.string_0 == "all")
			{
				XmlOperator.ReadXmlReturnNodeList(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "ShopSetting");
				string relativeUrl = XmlOperator.ReadXmlReturnNode(this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), this.TypeEWM);
				this.image_0.ImageUrl = this.Page.ResolveUrl(relativeUrl);
			}
			else
			{
				XmlOperator.ReadXmlReturnNodeList(this.Page.Server.MapPath(Globals.ApplicationPath + "/City/" + this.string_0 + "/Settings/ShopSetting.xml"), "ShopSetting");
				string relativeUrl = XmlOperator.ReadXmlReturnNode(this.Page.Server.MapPath(Globals.ApplicationPath + "/City/" + this.string_0 + "/Settings/ShopSetting.xml"), this.TypeEWM);
				this.image_0.ImageUrl = this.Page.ResolveUrl(relativeUrl);
			}
		}
	}
}
