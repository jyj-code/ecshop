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
	public class NewsCategoryList : BaseWebControl
	{
		private string string_0 = "NewsCategoryList.ascx";
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
		public string MemLoginID
		{
			get;
			set;
		}
		public NewsCategoryList()
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
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			if (this.Page.IsPostBack)
			{
			}
			this.method_0();
		}
		private void method_0()
		{
			Shop_NewsCategory_Action shop_NewsCategory_Action = (Shop_NewsCategory_Action)LogicFactory.CreateShop_NewsCategory_Action();
			DataTable newsCategoryList = shop_NewsCategory_Action.GetNewsCategoryList(this.MemLoginID, "1");
			this.repeater_0.DataSource = newsCategoryList;
			this.repeater_0.DataBind();
		}
	}
}
