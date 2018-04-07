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
	public class VideoIsHotList : BaseWebControl
	{
		private string string_0 = "VideoIsHotList.ascx";
		private Repeater repeater_0;
		private string string_1 = "all";
		[CompilerGenerated]
		private int int_0;
		public int ShowCount
		{
			get;
			set;
		}
		public VideoIsHotList()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShow");
			if (this.Page.Request.QueryString["SubstationID"] != null && !string.IsNullOrEmpty(this.Page.Request.QueryString["SubstationID"].ToString()))
			{
				this.string_1 = this.Page.Request.QueryString["SubstationID"].ToString();
			}
			if (this.Page.IsPostBack)
			{
			}
			this.method_0();
		}
		private void method_0()
		{
			ShopNum1_Video_Action shopNum1_Video_Action = (ShopNum1_Video_Action)LogicFactory.CreateShopNum1_Video_Action();
			this.repeater_0.DataSource = shopNum1_Video_Action.GetVideoHotList(this.ShowCount, this.string_1);
			this.repeater_0.DataBind();
		}
		public static string GetVideoCommentCount(string guid)
		{
			string result;
			try
			{
				ShopNum1_Video_Action shopNum1_Video_Action = (ShopNum1_Video_Action)LogicFactory.CreateShopNum1_Video_Action();
				result = shopNum1_Video_Action.GetVideoComment(guid).ToString();
			}
			catch (Exception)
			{
				result = "0";
			}
			return result;
		}
	}
}
