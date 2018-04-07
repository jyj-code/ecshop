using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.WebControl
{
	[ParseChildren(true)]
	public class CategoryInfoIsNew : BaseWebControl
	{
		private string string_0 = "CategoryInfoIsNew.ascx";
		private Repeater repeater_0;
		[CompilerGenerated]
		private string string_1;
		public string MemLoginID
		{
			get;
			set;
		}
		public CategoryInfoIsNew()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			string shopid = (this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString();
			Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action();
			this.MemLoginID = shop_ShopInfo_Action.GetMemberLoginidByShopid(shopid).ToString();
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShow");
			if (this.Page.IsPostBack)
			{
			}
			this.method_0();
		}
		private void method_0()
		{
			Shop_CategoryInfo_Action shop_CategoryInfo_Action = (Shop_CategoryInfo_Action)LogicFactory.CreateShop_CategoryInfo_Action();
			DataTable dataSource = shop_CategoryInfo_Action.Search(this.MemLoginID, "1");
			this.repeater_0.DataSource = dataSource;
			this.repeater_0.DataBind();
		}
	}
}
