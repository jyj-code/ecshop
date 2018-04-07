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
	public class AnnouncementDetail : BaseWebControl
	{
		private string string_0 = "AnnouncementDetail.ascx";
		private Repeater repeater_0;
		private Repeater repeater_1;
		private string string_1 = "上一篇：";
		private string string_2 = "下一篇：";
		[CompilerGenerated]
		private string string_3;
		public string StrGuid
		{
			get;
			set;
		}
		public string OnAnnouncementName
		{
			get
			{
				return this.string_1;
			}
			set
			{
				this.string_1 = value;
			}
		}
		public string NextAnnouncementName
		{
			get
			{
				return this.string_2;
			}
			set
			{
				this.string_2 = value;
			}
		}
		public AnnouncementDetail()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(System.Web.UI.Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.repeater_1 = (Repeater)skin.FindControl("RepeaterUpDown");
			this.StrGuid = ((this.Page.Request.QueryString["Guid"] == null) ? "" : this.Page.Request.QueryString["Guid"].ToString());
			this.method_0();
		}
		private void method_0()
		{
			ShopNum1_Announcement_Action shopNum1_Announcement_Action = (ShopNum1_Announcement_Action)LogicFactory.CreateShopNum1_Announcement_Action();
			DataTable annoucementDetails = shopNum1_Announcement_Action.GetAnnoucementDetails(this.StrGuid);
			if (annoucementDetails.Rows.Count > 0)
			{
				this.repeater_0.DataSource = annoucementDetails;
				this.repeater_0.DataBind();
			}
			DataTable announcementOnAndNext = shopNum1_Announcement_Action.GetAnnouncementOnAndNext(this.StrGuid, this.string_1, this.string_2);
			if (announcementOnAndNext.Rows.Count > 0)
			{
				this.repeater_1.DataSource = announcementOnAndNext.DefaultView;
				this.repeater_1.DataBind();
			}
		}
	}
}
