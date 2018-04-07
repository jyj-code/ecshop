using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class VideoDetail : BaseWebControl
	{
		private string string_0 = "VideoDetail.ascx";
		private Repeater repeater_0;
		[CompilerGenerated]
		private string string_1;
		public string Guid
		{
			get;
			set;
		}
		public VideoDetail()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.Guid = ((this.Page.Request.QueryString["guid"] == null) ? "0" : this.Page.Request.QueryString["guid"].ToString());
			if (this.Page.Request.Cookies[this.Guid] == null)
			{
				ShopNum1_Video_Action shopNum1_Video_Action = (ShopNum1_Video_Action)LogicFactory.CreateShopNum1_Video_Action();
				shopNum1_Video_Action.AddVideoCout("BroadcastCount", this.Guid);
			}
			else
			{
				HttpCookie httpCookie = this.Page.Request.Cookies[this.Guid];
				if (httpCookie["VideGuid"] != this.Guid)
				{
					ShopNum1_Video_Action shopNum1_Video_Action = (ShopNum1_Video_Action)LogicFactory.CreateShopNum1_Video_Action();
					shopNum1_Video_Action.AddVideoCout("BroadcastCount", this.Guid);
				}
			}
			this.method_0();
		}
		private void method_0()
		{
			ShopNum1_Video_Action shopNum1_Video_Action = (ShopNum1_Video_Action)LogicFactory.CreateShopNum1_Video_Action();
			this.repeater_0.DataSource = shopNum1_Video_Action.GetVideoDetail(this.Guid);
			this.repeater_0.DataBind();
			HttpCookie httpCookie = new HttpCookie(this.Guid);
			httpCookie.Values.Add("VideGuid", this.Guid);
			this.Page.Response.AppendCookie(httpCookie);
		}
		public static string GetVideo(object video, string height, string width)
		{
			string input = video.ToString();
			Regex regex = new Regex("height=\"[0-9]+\"", RegexOptions.IgnoreCase);
			input = regex.Replace(input, "height=\"" + height + "\"");
			Regex regex2 = new Regex("width=\"[0-9]+\"", RegexOptions.IgnoreCase);
			return regex2.Replace(input, "width=\"" + width + "\"");
		}
	}
}
