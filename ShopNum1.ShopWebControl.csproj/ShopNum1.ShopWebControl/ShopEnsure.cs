using ShopNum1.BusinessLogic;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System;
using System.Configuration;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class ShopEnsure : BaseWebControl
	{
		private string string_0 = "ShopEnsure.ascx";
		private Repeater repeater_0;
		[CompilerGenerated]
		private static string string_1;
		public static string MemLoginID
		{
			get;
			set;
		}
		public ShopEnsure()
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
			ShopEnsure.MemLoginID = shopNum1_ShopInfoList_Action.GetShopMemLoginIdByShopID(memloginId).ToString();
			this.repeater_0 = (Repeater)skin.FindControl("RepeaterData");
			this.method_0();
		}
		private void method_0()
		{
			Shop_Ensure_Action shop_Ensure_Action = (Shop_Ensure_Action)LogicFactory.CreateShop_Ensure_Action();
			DataTable shopapplyEnsure = shop_Ensure_Action.GetShopapplyEnsure(ShopEnsure.MemLoginID);
			this.repeater_0.DataSource = shopapplyEnsure;
			this.repeater_0.DataBind();
		}
		public static string ReturnImageUrl(object object_0)
		{
			string newValue = "http://" + ShopEnsure.MemLoginID + ConfigurationSettings.AppSettings["Domain"].ToString();
			return object_0.ToString().Replace("~/", newValue);
		}
	}
}
