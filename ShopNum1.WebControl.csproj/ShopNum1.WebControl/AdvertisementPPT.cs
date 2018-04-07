using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class AdvertisementPPT : BaseWebControl
	{
		private string string_0 = "AdvertisementPPTTwo.ascx";
		private Repeater repeater_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		public string AdID
		{
			get;
			set;
		}
		public string AdType
		{
			get;
			set;
		}
		public AdvertisementPPT()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterPPT");
			this.BindAd();
		}
		public void BindAd()
		{
			ShopNum1_Advertisement_Action shopNum1_Advertisement_Action = (ShopNum1_Advertisement_Action)LogicFactory.CreateShopNum1_Advertisement_Action();
			DataTable dataSource = shopNum1_Advertisement_Action.ShowADByDivID(this.AdID, this.AdType);
			this.repeater_0.DataSource = dataSource;
			this.repeater_0.DataBind();
		}
	}
}
