using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace ShopNum1.ShopNewWebControl
{
	[ParseChildren(true)]
	public class Show_ShopInfoV82 : BaseWebControl
	{
		private string string_0 = "Show_ShopInfoV82.ascx";
		private HtmlGenericControl htmlGenericControl_0;
		[CompilerGenerated]
		private string string_1;
		public string ColumnName
		{
			get;
			set;
		}
		public Show_ShopInfoV82()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			this.htmlGenericControl_0 = (HtmlGenericControl)skin.FindControl("divShopIntro");
			string str = (this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString();
			this.htmlGenericControl_0.InnerHtml = HttpUtility.HtmlDecode(ShopNum1.Common.Common.GetNameById(this.ColumnName, "shopnum1_shopinfo", " and ShopId='" + str + "'"));
		}
	}
}
