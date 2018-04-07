using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	public class DefaultAdvertisement : BaseWebControl
	{
		private string string_0 = "DefaultAdvertisement.ascx";
		private Repeater repeater_0;
		private HtmlImage htmlImage_0;
		public DefaultAdvertisement()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterSmall");
			this.htmlImage_0 = (HtmlImage)skin.FindControl("AdBigImg");
			this.BindAd();
		}
		public void BindAd()
		{
			string filePath = this.Page.Request.FilePath;
			string a = filePath.Substring(filePath.LastIndexOf('/') + 1);
			if (a == "")
			{
			}
			ShopNum1_DefaultAdImg_Action shopNum1_DefaultAdImg_Action = (ShopNum1_DefaultAdImg_Action)LogicFactory.CreateShopNum1_DefaultAdImg_Action();
			DataTable defaultData = shopNum1_DefaultAdImg_Action.DefaultData;
			if (defaultData != null && defaultData.Rows.Count != 0)
			{
				DataView defaultView = defaultData.DefaultView;
				defaultView.Sort = "orderID";
				this.repeater_0.DataSource = defaultView;
				this.repeater_0.DataBind();
				string arg_96_0 = this.htmlImage_0.ClientID;
				this.htmlImage_0.Src = defaultData.Rows[0]["imgsrc"].ToString();
			}
		}
	}
}
