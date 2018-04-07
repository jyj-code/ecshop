using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class VideoRelativelyList : BaseWebControl
	{
		private string string_0 = "VideoRelativelyList.ascx";
		private Repeater repeater_0;
		[CompilerGenerated]
		private int int_0;
		[CompilerGenerated]
		private string string_1;
		public int ShowCount
		{
			get;
			set;
		}
		public string Guid
		{
			get;
			set;
		}
		public VideoRelativelyList()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShow");
			this.Guid = ((this.Page.Request.QueryString["Guid"] == null) ? "" : this.Page.Request.QueryString["Guid"].ToString());
			if (this.Page.IsPostBack)
			{
			}
			this.method_0();
		}
		private void method_0()
		{
			ShopNum1_Video_Action shopNum1_Video_Action = (ShopNum1_Video_Action)LogicFactory.CreateShopNum1_Video_Action();
			this.repeater_0.DataSource = shopNum1_Video_Action.GetVideoRelativelyList(this.Guid, this.ShowCount);
			this.repeater_0.DataBind();
		}
	}
}
