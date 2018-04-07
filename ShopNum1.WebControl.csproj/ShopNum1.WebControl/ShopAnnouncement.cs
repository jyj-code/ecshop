using ShopNum1.BusinessLogic;
using ShopNum1.Common;
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
	public class ShopAnnouncement : BaseWebControl
	{
		private string string_0 = "ShopAnnouncement.ascx";
		private Repeater repeater_0;
		[CompilerGenerated]
		private string string_1;
		public string ShowCategory
		{
			get;
			set;
		}
		public ShopAnnouncement()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.method_0();
		}
		private void method_0()
		{
			ShopNum1_Announcement_Action shopNum1_Announcement_Action = (ShopNum1_Announcement_Action)LogicFactory.CreateShopNum1_Announcement_Action();
			DataTable shopAnnouncementNew = shopNum1_Announcement_Action.GetShopAnnouncementNew(ShopSettings.GetValue("ShopAnnouncementCount"), this.ShowCategory);
			if (shopAnnouncementNew.Rows.Count > 0)
			{
				this.repeater_0.DataSource = shopAnnouncementNew;
				this.repeater_0.DataBind();
			}
		}
	}
}