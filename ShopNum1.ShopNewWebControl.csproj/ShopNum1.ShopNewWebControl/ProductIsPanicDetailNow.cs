using ShopNum1.BusinessLogic;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopNewWebControl
{
	[ParseChildren(true)]
	public class ProductIsPanicDetailNow : BaseWebControl
	{
		private string string_0 = string.Empty;
		private string string_1 = "ProductIsPanicDetailNow.ascx";
		private Repeater repeater_0;
		private Image image_0;
		private string string_2;
		[CompilerGenerated]
		private static string string_3;
		[CompilerGenerated]
		private string string_4;
		[CompilerGenerated]
		private string string_5;
		[CompilerGenerated]
		private string string_6;
		public static string MemLoginID
		{
			get;
			set;
		}
		public string ShowCount
		{
			get;
			set;
		}
		public string MemberLoginID
		{
			get;
			set;
		}
		public string MemberType
		{
			get;
			set;
		}
		public ProductIsPanicDetailNow()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_1;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			string memloginId = (this.Page.Request.QueryString["ShopID"] == null) ? "0" : this.Page.Request.QueryString["ShopID"].ToString();
			ShopNum1_ShopInfoList_Action shopNum1_ShopInfoList_Action = new ShopNum1_ShopInfoList_Action();
			ProductIsPanicDetailNow.MemLoginID = shopNum1_ShopInfoList_Action.GetShopMemLoginIdByShopID(memloginId).ToString();
			this.string_2 = ((this.Page.Request.QueryString["guid"] == null) ? "-1" : this.Page.Request.QueryString["guid"].ToString());
			Shop_ShopInfo_Action shop_ShopInfo_Action = (Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action();
			DataTable memLoginInfo = shop_ShopInfo_Action.GetMemLoginInfo(ProductIsPanicDetailNow.MemLoginID);
			this.MemberType = memLoginInfo.Rows[0]["MemberType"].ToString();
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.image_0 = (Image)skin.FindControl("Image1");
			if (this.Page.IsPostBack)
			{
			}
			this.method_0();
		}
		private void method_0()
		{
			Shop_Product_Action shop_Product_Action = (Shop_Product_Action)LogicFactory.CreateShop_Product_Action();
			DataTable spellListFor = shop_Product_Action.GetSpellListFor(ProductIsPanicDetailNow.MemLoginID, this.ShowCount, "0");
			if (spellListFor.Rows.Count > 0)
			{
				this.repeater_0.DataSource = spellListFor;
				this.repeater_0.DataBind();
			}
		}
	}
}
