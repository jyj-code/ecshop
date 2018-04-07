using ShopNum1.BusinessLogic;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class VideoDetail : BaseWebControl
	{
		private string string_0 = "VideoDetail.ascx";
		private Repeater repeater_0;
		private string string_1;
		[CompilerGenerated]
		private int int_0;
		[CompilerGenerated]
		private string string_2;
		public int ShowCount
		{
			get;
			set;
		}
		public string MemLoginID
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
			string memloginId = (this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString();
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = new ShopNum1_ShopInfoList_Action();
			this.MemLoginID = shopNum1_ShopInfoList_Action.GetShopMemLoginIdByShopID(memloginId).ToString();
			this.string_1 = ((this.Page.Request.QueryString["guid"] == null) ? "-1" : this.Page.Request.QueryString["guid"].ToString());
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			if (!this.Page.IsPostBack)
			{
			}
			try
			{
				Shop_Video_Action shop_Video_Action = (Shop_Video_Action)LogicFactory.CreateShop_Video_Action();
				shop_Video_Action.AddBroadcastCount(1, this.string_1);
			}
			catch (Exception)
			{
			}
			this.method_0();
		}
		private void method_0()
		{
			Shop_Video_Action shop_Video_Action = (Shop_Video_Action)LogicFactory.CreateShop_Video_Action();
			DataTable videoInfoByGuidAndMemLoginID = shop_Video_Action.GetVideoInfoByGuidAndMemLoginID(this.string_1, this.MemLoginID);
			if (videoInfoByGuidAndMemLoginID != null && videoInfoByGuidAndMemLoginID.Rows.Count > 0)
			{
				this.repeater_0.DataSource = videoInfoByGuidAndMemLoginID.DefaultView;
				this.repeater_0.DataBind();
			}
		}
		public static string GetVideo(object video, string height, string width)
		{
			string input = video.ToString();
			Regex regex = new Regex("height=\"[0-9]+\"", RegexOptions.IgnoreCase);
			input = regex.Replace(input, "height=\"" + height + "\"");
			Regex regex2 = new Regex("width=\"[0-9]+\"", RegexOptions.IgnoreCase);
			return regex2.Replace(input, "width=\"" + width + "\"");
		}
		public static string IsShow(object object_0)
		{
			string a = object_0.ToString();
			string result;
			if (a == "0")
			{
				result = "否";
			}
			else if (a == "1")
			{
				result = "是";
			}
			else
			{
				result = "";
			}
			return result;
		}
	}
}
