using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class ProductDetailScoreInfo : BaseWebControl
	{
		private string string_0 = "ProductDetailScoreInfo.ascx";
		private Repeater repeater_0;
		[CompilerGenerated]
		private static string string_1;
		public static string MemLoginID
		{
			get;
			set;
		}
		public ProductDetailScoreInfo()
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
			ProductDetailScoreInfo.MemLoginID = shopNum1_ShopInfoList_Action.GetShopMemLoginIdByShopID(memloginId).ToString();
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterProductDetail");
			if (this.Page.IsPostBack)
			{
			}
			string a = (this.Page.Request.QueryString["guid"] == null) ? "0" : this.Page.Request.QueryString["guid"];
			if (a != "0")
			{
				this.method_0();
			}
		}
		private void method_0()
		{
			ShopNum1_Shop_ScoreProduct_Action shopNum1_Shop_ScoreProduct_Action = (ShopNum1_Shop_ScoreProduct_Action)LogicFactory.CreateShopNum1_Shop_ScoreProduct_Action();
			DataTable dataShopWeb = shopNum1_Shop_ScoreProduct_Action.GetDataShopWeb(1, 0, 1, this.Page.Request.QueryString["guid"].ToString());
			if (dataShopWeb.Rows.Count > 0)
			{
				this.repeater_0.DataSource = dataShopWeb.DefaultView;
				this.repeater_0.DataBind();
			}
		}
	}
}
