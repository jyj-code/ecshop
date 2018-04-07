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
	public class SupplyListIsNew : BaseWebControl
	{
		private string string_0 = "SupplyList.ascx";
		private HiddenField hiddenField_0;
		private Repeater repeater_0;
		[CompilerGenerated]
		private string string_1;
		[CompilerGenerated]
		private string string_2;
		[CompilerGenerated]
		private string string_3;
		public string MemLoginID
		{
			get;
			set;
		}
		public string MemberLoginID
		{
			get;
			set;
		}
		public string shopName
		{
			get;
			set;
		}
		public SupplyListIsNew()
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
			this.hiddenField_0 = (HiddenField)skin.FindControl("HiddenFieldGuid");
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterShow");
			if (this.Page.IsPostBack)
			{
			}
			this.method_0();
		}
		private void method_0()
		{
			Shop_SupplyDemand_Action shop_SupplyDemand_Action = (Shop_SupplyDemand_Action)LogicFactory.CreateShop_SupplyDemand_Action();
			DataTable dataSource = shop_SupplyDemand_Action.Search(this.MemLoginID, "1");
			this.repeater_0.DataSource = dataSource;
			this.repeater_0.DataBind();
		}
		public static string TradeType(string type)
		{
			string result;
			if (type == "0")
			{
				result = "供";
			}
			else
			{
				result = "求";
			}
			return result;
		}
	}
}
