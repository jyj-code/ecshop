using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class AnnouncementMoreList : BaseWebControl
	{
		private string string_0 = "AnnouncementMoreList.ascx";
		private Repeater repeater_0;
		public AnnouncementMoreList()
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
			DataTable annoucementList = shopNum1_Announcement_Action.GetAnnoucementList();
			if (annoucementList.Rows.Count > 0)
			{
				this.repeater_0.DataSource = annoucementList;
				this.repeater_0.DataBind();
			}
		}
	}
}
