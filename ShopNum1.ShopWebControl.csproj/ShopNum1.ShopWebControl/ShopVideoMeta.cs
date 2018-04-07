using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class ShopVideoMeta : BaseWebControl
	{
		private string string_0 = "ShopVideoMeta.ascx";
		private Literal literal_0;
		private Literal literal_1;
		private Literal literal_2;
		[CompilerGenerated]
		private string string_1;
		public string MemLoginID
		{
			get;
			set;
		}
		public ShopVideoMeta()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.literal_0 = (Literal)skin.FindControl("LiteralPageTitle");
			this.literal_1 = (Literal)skin.FindControl("LiteralPagekeywords");
			this.literal_2 = (Literal)skin.FindControl("LiteralPagedescription");
			if (this.Page.IsPostBack)
			{
			}
			string guid = (this.Page.Request.QueryString["guid"] == null) ? "0" : this.Page.Request.QueryString["guid"].ToString();
			Shop_Video_Action shop_Video_Action = (Shop_Video_Action)LogicFactory.CreateShop_Video_Action();
			DataTable videoInfo = shop_Video_Action.GetVideoInfo(guid);
			this.literal_0.Text = "\n<title>" + videoInfo.Rows[0]["Title"].ToString() + "</title>\n";
			this.literal_1.Text = "<meta name=\"keywords\" content=\"" + videoInfo.Rows[0]["KeyWords"].ToString() + "\">\n";
			this.literal_2.Text = "<meta name=\"description\" content=\"" + videoInfo.Rows[0]["Content"].ToString() + "\">\n";
		}
	}
}
