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
	public class AnnouncementNewList : BaseWebControl
	{
		private string string_0 = "AnnouncementNewList.ascx";
		private Repeater repeater_0;
		private string string_1 = "all";
		[CompilerGenerated]
		private string string_2;
		public string ShowCount
		{
			get;
			set;
		}
		public AnnouncementNewList()
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
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.method_0();
		}
		private void method_0()
		{
			if (this.ShowCount == null || string.IsNullOrEmpty(this.ShowCount))
			{
				this.ShowCount = "12";
			}
			ShopNum1_Announcement_Action shopNum1_Announcement_Action = (ShopNum1_Announcement_Action)LogicFactory.CreateShopNum1_Announcement_Action();
			DataTable annoucementNew = shopNum1_Announcement_Action.GetAnnoucementNew(this.ShowCount, this.string_1);
			if (annoucementNew.Rows.Count > 0)
			{
				this.repeater_0.DataSource = annoucementNew;
				this.repeater_0.DataBind();
			}
		}
	}
}
