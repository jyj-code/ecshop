using ShopNum1.BusinessLogic;
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
	public class ShopCommentStatReport : BaseWebControl
	{
		private string string_0 = "ShopCommentStatReport.ascx";
		private Repeater repeater_0;
		private string string_1;
		[CompilerGenerated]
		private int int_0;
		[CompilerGenerated]
		private static string string_2;
		[CompilerGenerated]
		private string string_3;
		public int ShowCount
		{
			get;
			set;
		}
		public static string ShopID
		{
			get;
			set;
		}
		public string MemLoginID
		{
			get;
			set;
		}
		public ShopCommentStatReport()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			ShopCommentStatReport.ShopID = ((this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString());
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = new ShopNum1_ShopInfoList_Action();
			this.MemLoginID = shopNum1_ShopInfoList_Action.GetShopMemLoginIdByShopID(ShopCommentStatReport.ShopID).ToString();
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShow");
			this.string_1 = ((this.Page.Request.QueryString["guid"] == null) ? "-1" : this.Page.Request.QueryString["guid"]);
			if (this.Page.IsPostBack)
			{
			}
			this.method_0();
		}
		private void method_0()
		{
			Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action();
			DataTable shopInfo = shop_ShopInfo_Action.GetShopInfo(this.MemLoginID);
			this.repeater_0.DataSource = shopInfo.DefaultView;
			this.repeater_0.DataBind();
			foreach (RepeaterItem repeaterItem in this.repeater_0.Items)
			{
				HiddenField arg_64_0 = (HiddenField)repeaterItem.FindControl("ha");
				HiddenField arg_75_0 = (HiddenField)repeaterItem.FindControl("hc");
				HiddenField arg_86_0 = (HiddenField)repeaterItem.FindControl("hs");
			}
		}
	}
}
