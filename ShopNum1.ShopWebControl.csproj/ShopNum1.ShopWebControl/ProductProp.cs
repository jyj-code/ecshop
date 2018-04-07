using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web.UI;
namespace ShopNum1.ShopWebControl
{
	[ParseChildren(true)]
	public class ProductProp : BaseWebControl
	{
		private string string_0 = "ProductProp.ascx";
		public static DataTable dt_Prop = null;
		[CompilerGenerated]
		private string string_1;
		protected string guid
		{
			get;
			set;
		}
		public ProductProp()
		{
			if (base.SkinFilename == null)
			{
				base.SkinFilename = this.string_0;
			}
		}
		protected override void InitializeSkin(Control skin)
		{
			if (this.Page.Request.QueryString["ShopID"] != null)
			{
				this.Page.Request.QueryString["ShopID"].ToString();
			}
			if (!this.Page.IsPostBack)
			{
				this.guid = ((this.Page.Request.QueryString["guid"] == null) ? "-1" : this.Page.Request.QueryString["guid"]);
				if (this.guid != "-1")
				{
					this.method_0();
				}
			}
		}
		public static DataTable dt_SubPropv(string strPropID)
		{
			ShopNum1_ShopProRelateProp_Action shopNum1_ShopProRelateProp_Action = (ShopNum1_ShopProRelateProp_Action)LogicFactory.CreateShopNum1_ShopProRelateProp_Action();
			return shopNum1_ShopProRelateProp_Action.SelectPropByIdAndPid(strPropID, ShopNum1.Common.Common.ReqStr("guid"));
		}
		public static string GetPropValue(string strID)
		{
			ShopNum1_ShopProductPropValue_Action shopNum1_ShopProductPropValue_Action = new ShopNum1_ShopProductPropValue_Action();
			return shopNum1_ShopProductPropValue_Action.GetPropValue(strID);
		}
		private void method_0()
		{
			ShopNum1_ShopProductProp_Action shopNum1_ShopProductProp_Action = (ShopNum1_ShopProductProp_Action)LogicFactory.CreateShopNum1_ShopProductProp_Action();
			ProductProp.dt_Prop = shopNum1_ShopProductProp_Action.SelectProByProductGuid(this.guid);
		}
	}
}
